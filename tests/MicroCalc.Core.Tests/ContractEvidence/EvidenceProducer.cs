using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Security.Cryptography;
using System.Globalization;

namespace MicroCalc.ContractEvidence;

internal static class EvidenceProducer
{
    internal sealed record Decision(bool Accepted, string Code);
    internal sealed record Context(string Commit, string WorkingTreeDigest, string ContractDigest,
        string PinDecisionDigest, string Platform, string Runner, string Job, string Command,
        IReadOnlyDictionary<string, string> ToolVersions, string ExecutionProofRef);

    internal static Decision Validate(JsonObject candidate, IReadOnlyCollection<string> requiredTuples, Context context)
    {
        if (requiredTuples.Count == 0 || requiredTuples.Distinct(StringComparer.Ordinal).Count() != requiredTuples.Count)
            return new(false, "InvalidDenominator");
        if (candidate["exitCode"]?.GetValue<int>() != 0)
            return new(false, "Timeout");
        if (candidate["contractDigest"]?.GetValue<string>() != context.ContractDigest)
            return new(false, "DigestMismatch");
        if (candidate["results"] is not JsonArray results)
            return new(false, "MissingResult");
        if (!DateTimeOffset.TryParse(candidate["startedAt"]?.GetValue<string>(), out var runStart)
            || !DateTimeOffset.TryParse(candidate["finishedAt"]?.GetValue<string>(), out var runEnd) || runEnd < runStart)
            return new(false, "InvalidTiming");

        var actual = new HashSet<string>(StringComparer.Ordinal);
        foreach (var node in results)
        {
            var tuple = node?["tuple"]?.GetValue<string>();
            if (tuple is null || !actual.Add(tuple))
                return new(false, "DuplicateResult");
            var parts = tuple.Split('|');
            if (parts.Length != 4 || parts[2] != context.Platform)
                return new(false, "WrongPlatform");
            if (node!["outcome"]?.GetValue<string>() != "Pass")
                return new(false, "Skipped");
            if (!DateTimeOffset.TryParse(node["startedAt"]?.GetValue<string>(), out var start)
                || !DateTimeOffset.TryParse(node["finishedAt"]?.GetValue<string>(), out var end)
                || start < runStart || end < start || end > runEnd)
                return new(false, "InvalidTiming");
            if (node["assertions"] is not JsonArray assertions || assertions.Count == 0)
                return new(false, "MissingAssertions");
            var ids = new HashSet<string>(StringComparer.Ordinal);
            var expectedState = new JsonObject();
            var actualState = new JsonObject();
            foreach (var assertion in assertions)
            {
                // DE: Ein behauptetes Pass-Flag genügt nicht; unabhängige Soll-/Ist-Werte müssen übereinstimmen.
                // EN: A claimed pass flag is insufficient; independent expected/actual observations must agree.
                if (assertion?["id"]?.GetValue<string>() is not { Length: > 0 }
                    || assertion["expected"] is null || assertion["actual"] is null
                    || assertion["passed"]?.GetValue<bool>() != true)
                    return new(false, "FailedAssertion");
                if (!ids.Add(assertion["id"]!.GetValue<string>())) return new(false, "DuplicateAssertion");
                if (assertion["expected"] is not JsonObject expected || assertion["actual"] is not JsonObject observed
                    || !TypedObservation(expected) || !TypedObservation(observed)) return new(false, "MissingObservation");
                if (!SameObservation(expected, observed, parts[1]) || !expected.Select(pair => pair.Key)
                    .ToHashSet(StringComparer.Ordinal).SetEquals(observed.Select(pair => pair.Key))) return new(false, "FailedAssertion");
                foreach (var pair in expected)
                {
                    if ((expectedState.ContainsKey(pair.Key) && !JsonNode.DeepEquals(expectedState[pair.Key], pair.Value))
                        || (actualState.ContainsKey(pair.Key) && !JsonNode.DeepEquals(actualState[pair.Key], observed[pair.Key])))
                        return new(false, "ConflictingObservation");
                    expectedState[pair.Key] = pair.Value?.DeepClone();
                    actualState[pair.Key] = observed[pair.Key]?.DeepClone();
                }
            }
        }
        if (!actual.SetEquals(requiredTuples))
            return new(false, "MissingResult");
        return new(true, "Accepted");
    }

    internal static JsonObject? Create(JsonObject candidate, IReadOnlyCollection<string> requiredTuples, Context context)
    {
        if (!Validate(candidate, requiredTuples, context).Accepted)
            return null;
        var startedAt = candidate["startedAt"]!.GetValue<string>();
        var finishedAt = candidate["finishedAt"]!.GetValue<string>();
        var results = new JsonArray();
        foreach (var item in candidate["results"]!.AsArray())
        {
            var parts = item!["tuple"]!.GetValue<string>().Split('|');
            var assertions = new JsonArray();
            foreach (var assertion in item["assertions"]!.AsArray())
                assertions.Add(new JsonObject
                {
                    ["id"] = assertion!["id"]!.DeepClone(),
                    ["expected"] = Observation(assertion["expected"]!),
                    ["actual"] = Observation(assertion["actual"]!),
                    ["passed"] = assertion["passed"]!.DeepClone(),
                });
            results.Add(new JsonObject
            {
                ["capabilityId"] = parts[0], ["pathId"] = parts[1], ["scenarioKind"] = parts[3],
                ["kind"] = "Automated", ["outcome"] = item["outcome"]!.DeepClone(),
                ["testRef"] = item["testRef"]!.DeepClone(),
                ["assertionProofRef"] = item["assertionProofRef"]!.DeepClone(),
                ["assertions"] = assertions, ["startedAt"] = item["startedAt"]!.DeepClone(),
                ["finishedAt"] = item["finishedAt"]!.DeepClone(),
                ["observedState"] = MergeActual(item["assertions"]!.AsArray()),
                ["artifactRefs"] = item["artifactRefs"]!.DeepClone(),
            });
        }
        var bundle = new JsonObject
        {
            ["schemaVersion"] = "1.0", ["runId"] = Guid.NewGuid().ToString(),
            ["commit"] = context.Commit, ["workingTreeDigest"] = context.WorkingTreeDigest,
            ["contractDigest"] = context.ContractDigest, ["pinDecisionDigest"] = context.PinDecisionDigest,
            ["platform"] = context.Platform, ["runner"] = context.Runner, ["job"] = context.Job,
            ["command"] = context.Command, ["toolVersions"] = JsonSerializer.SerializeToNode(context.ToolVersions),
            ["executionProofRef"] = context.ExecutionProofRef,
            ["startedAt"] = startedAt, ["finishedAt"] = finishedAt, ["exitCode"] = 0, ["results"] = results,
        };
        bundle["payloadDigest"] = CanonicalDigest(bundle);
        return bundle;
    }

    internal static Decision Publish(JsonObject candidate, IReadOnlyCollection<string> requiredTuples, Context context, string path, bool interrupt)
    {
        var decision = Validate(candidate, requiredTuples, context);
        if (!decision.Accepted)
            return decision;
        var temporary = path + "." + Guid.NewGuid().ToString("N") + ".tmp";
        try
        {
            // DE: Die finale Datei wird erst nach vollständigem Schreiben sichtbar; Abbruch ersetzt auch keinen alten Beleg.
            // EN: Publish only after a complete write; interruption must not replace an existing proof either.
            File.WriteAllText(temporary, interrupt ? "{\"partial\":" : Create(candidate, requiredTuples, context)!.ToJsonString() + "\n", new UTF8Encoding(false, true));
            if (interrupt)
                return new(false, "Interrupted");
            File.Move(temporary, path, overwrite: true);
            return decision;
        }
        finally
        {
            if (File.Exists(temporary))
                File.Delete(temporary);
        }
    }

    private static JsonObject Observation(JsonNode node) => node is JsonObject state
        ? (JsonObject)state.DeepClone()
        : new JsonObject { ["descriptionEn"] = node.GetValue<string>() };

    private static JsonObject MergeActual(JsonArray assertions)
    {
        var observed = new JsonObject();
        foreach (var assertion in assertions)
            foreach (var pair in assertion!["actual"]!.AsObject()) observed[pair.Key] = pair.Value?.DeepClone();
        return observed;
    }

    internal static bool SameObservation(JsonObject expected, JsonObject actual, string pathId)
    {
        foreach (var pair in expected)
        {
            if (!actual.ContainsKey(pair.Key)) return false;
            if (pair.Key != "value")
            {
                if (!JsonNode.DeepEquals(pair.Value, actual[pair.Key])) return false;
                continue;
            }
            if (!Number(pair.Value, out var left) || !Number(actual[pair.Key], out var right)) return false;
            var tolerance = pathId == "FUNC-LEGACY-fact-upper" ? Math.Abs(left) * 1e-14
                : new[] { "sin-", "cos-", "arctan-", "ln-", "exp-", "average-", "round-" }
                    .Any(part => pathId.Contains(part, StringComparison.Ordinal)) ? 1e-12 : 0;
            if (Math.Abs(left - right) > tolerance) return false;
        }
        return true;
    }

    private static bool Number(JsonNode? node, out double number)
    {
        number = 0;
        return node?.GetValueKind() == JsonValueKind.Number
            && double.TryParse(node.ToJsonString(), NumberStyles.Float, CultureInfo.InvariantCulture, out number)
            && double.IsFinite(number);
    }

    internal static bool TypedObservation(JsonObject observation)
    {
        if (observation.Count == 0) return false;
        foreach (var pair in observation)
        {
            var kind = pair.Value?.GetValueKind();
            var valid = pair.Key switch
            {
                "value" => Number(pair.Value, out _),
                "error" or "autoCalc" => kind is JsonValueKind.True or JsonValueKind.False,
                "selection" or "focus" => kind == JsonValueKind.String && pair.Value!.GetValue<string>().Length > 0,
                "contents" => kind == JsonValueKind.String,
                "dialog" => pair.Value is null || kind == JsonValueKind.String,
                "status" => pair.Value is JsonValue value && value.TryGetValue<int>(out var status) && status >= 0,
                "preservedFields" => pair.Value is JsonArray array && array.All(item => item is JsonValue text
                    && text.TryGetValue<string>(out var field) && field.Length > 0),
                "cells" => pair.Value is JsonObject cells && cells.All(cell => CellName(cell.Key)
                    && cell.Value?.GetValueKind() == JsonValueKind.String),
                _ => false,
            };
            if (!valid) return false;
        }
        return true;
    }

    private static bool CellName(string name) => name.Length is 2 or 3 && name[0] is >= 'A' and <= 'G'
        && int.TryParse(name.AsSpan(1), NumberStyles.None, CultureInfo.InvariantCulture, out var row)
        && row is >= 1 and <= 21 && name[1..] == row.ToString(CultureInfo.InvariantCulture);

    internal static string CanonicalDigest(JsonObject value, string excludeRootProperty = "")
    {
        var clone = (JsonObject)value.DeepClone();
        if (excludeRootProperty.Length > 0)
            clone.Remove(excludeRootProperty);
        using var stream = new MemoryStream();
        using (var writer = new Utf8JsonWriter(stream, new JsonWriterOptions { Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping }))
            WriteCanonical(writer, clone);
        stream.WriteByte((byte)'\n');
        return Convert.ToHexString(SHA256.HashData(stream.ToArray())).ToLowerInvariant();
    }

    private static void WriteCanonical(Utf8JsonWriter writer, JsonNode? node)
    {
        if (node is JsonObject map)
        {
            writer.WriteStartObject();
            foreach (var pair in map.OrderBy(pair => pair.Key, StringComparer.Ordinal))
            {
                writer.WritePropertyName(pair.Key);
                WriteCanonical(writer, pair.Value);
            }
            writer.WriteEndObject();
        }
        else if (node is JsonArray array)
        {
            writer.WriteStartArray();
            foreach (var item in array)
                WriteCanonical(writer, item);
            writer.WriteEndArray();
        }
        else if (node is null)
            writer.WriteNullValue();
        else
            node.WriteTo(writer);
    }
}
