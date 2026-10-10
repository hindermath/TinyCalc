using System.Security.Cryptography;
using System.Text;
using System.Text.Json.Nodes;
using MicroCalc.ContractEvidence;

namespace MicroCalc.Tui.Tests;

internal sealed class ExecutedPathProof
{
    private static readonly UTF8Encoding Utf8 = new(false, true);
    private static readonly string ResultsRoot = Path.Combine(FormulaContractCases.RepositoryRoot, "tests/MicroCalc.Tui.Tests/TestResults");
    private static readonly Lazy<string> RunDirectory = new(() => Path.Combine(ResultsRoot, "contract-cases", Guid.NewGuid().ToString("N")));
    private DateTimeOffset _startedAt = DateTimeOffset.UtcNow;
    private readonly string _pathId;
    private readonly string _capabilityId;
    private readonly JsonObject _path;
    private readonly JsonArray _assertions = [];
    private readonly JsonObject _expected = [];
    private readonly JsonObject _observed = [];
    private readonly HashSet<string> _ids = new(StringComparer.Ordinal);
    private bool _failed;
    private bool _completed;
    private bool _begun;

    internal ExecutedPathProof(string pathId)
    {
        var contract = JsonNode.Parse(File.ReadAllText(Path.Combine(FormulaContractCases.RepositoryRoot,
            "docs/contracts/tui/product-contract.json")))!;
        var matches = contract["capabilities"]!.AsArray().SelectMany(capability => capability!["paths"]!.AsArray()
            .Where(path => path!["pathId"]!.GetValue<string>() == pathId)
            .Select(path => (Capability: capability!, Path: path!))).ToArray();
        if (matches.Length != 1 || matches[0].Path["automatable"]!.GetValue<bool>() != true)
            throw new ArgumentException("Exactly one automated contract path is required.", nameof(pathId));
        _pathId = pathId;
        _capabilityId = matches[0].Capability["id"]!.GetValue<string>();
        _path = (JsonObject)matches[0].Path.DeepClone();
    }

    internal void BeginExecution()
    {
        if (_begun || _failed || _completed || _assertions.Count != 0)
            throw new InvalidOperationException("An executed path cannot restart its proof clock.");
        _begun = true;
        // DE: Den tatsächlichen UI-Pfad messen, nicht Fixture-/Treiberinitialisierung vor der ersten Eingabe.
        // EN: Time the actual UI path, not fixture/driver initialization before its first input.
        _startedAt = DateTimeOffset.UtcNow;
    }

    internal EvidenceProducer.Decision Observe(string id, JsonObject expected, JsonObject actual)
    {
        if (_failed || _completed) return Reject("ClosedExecution");
        if (string.IsNullOrWhiteSpace(id) || !_ids.Add(id)) return Reject("DuplicateAssertion");
        if (!EvidenceProducer.TypedObservation(expected) || !EvidenceProducer.TypedObservation(actual)) return Reject("MissingObservation");
        if (!Same(expected, actual) || !expected.Select(pair => pair.Key).ToHashSet(StringComparer.Ordinal)
            .SetEquals(actual.Select(pair => pair.Key))) return Reject("FailedAssertion");
        foreach (var pair in expected)
        {
            if ((_expected.ContainsKey(pair.Key) && !JsonNode.DeepEquals(_expected[pair.Key], pair.Value))
                || (_observed.ContainsKey(pair.Key) && !JsonNode.DeepEquals(_observed[pair.Key], actual[pair.Key])))
                return Reject("ConflictingObservation");
        }
        foreach (var pair in expected)
        {
            _expected[pair.Key] = pair.Value?.DeepClone();
            _observed[pair.Key] = actual[pair.Key]?.DeepClone();
        }
        _assertions.Add(new JsonObject
        {
            ["id"] = id, ["expected"] = expected.DeepClone(), ["actual"] = actual.DeepClone(), ["passed"] = true,
        });
        return new(true, "Accepted");
    }

    internal JsonObject? Complete(string directory, string gridText, string statusText, IReadOnlyDictionary<string, byte[]>? artifacts = null)
    {
        var finishedAt = DateTimeOffset.UtcNow;
        var required = new JsonObject { ["focus"] = _path["focusAfter"]!.DeepClone() };
        foreach (var pair in _path["expectedState"]!.AsObject())
            if (pair.Key is not ("descriptionDe" or "descriptionEn")) required[pair.Key] = pair.Value?.DeepClone();
        if (_failed || _completed || _assertions.Count == 0 || (finishedAt - _startedAt).TotalSeconds > 30
            || !Same(required, _expected) || !Same(required, _observed)) return null;
        artifacts ??= new Dictionary<string, byte[]>();
        if (artifacts.Count > 16 || artifacts.Sum(pair => (long)pair.Value.Length) > 20971520
            || artifacts.Any(pair => pair.Value.Length == 0 || pair.Key is "grid.txt" or "status.txt"
                || !System.Text.RegularExpressions.Regex.IsMatch(pair.Key, "^[a-z][a-z0-9-]{0,63}\\.(bin|txt)$",
                    System.Text.RegularExpressions.RegexOptions.CultureInvariant, TimeSpan.FromMilliseconds(100))))
            throw new ArgumentException("Raw proof artifacts require bounded bytes and safe unique names.", nameof(artifacts));
        _completed = true;
        EnsureOwnedDirectory(directory);
        Directory.CreateDirectory(directory);
        // DE: Vertrags-IDs sind Daten, keine Dateinamen; auch manipulierte IDs dürfen keinen Pfad wählen.
        // EN: Contract IDs are data, not file names; even manipulated IDs must never select an output path.
        var name = "path-" + Convert.ToHexString(SHA256.HashData(Utf8.GetBytes(_pathId)))[..16].ToLowerInvariant()
            + "-" + Guid.NewGuid().ToString("N");
        var staging = Path.Combine(directory, name + ".tmp");
        var final = Path.Combine(directory, name);
        Directory.CreateDirectory(staging);
        try
        {
            // DE: Erst nach echten Assertions publizieren; Roh-Istwerte bleiben erhalten, auch bei erlaubter Rundung.
            // EN: Publish only after real assertions; preserve raw actual values even with approved rounding tolerance.
            var assertionProof = new JsonObject
            {
                ["capabilityId"] = _capabilityId, ["pathId"] = _pathId,
                ["scenarioKind"] = _path["scenarioKind"]!.DeepClone(), ["testRef"] = _path["testRefs"]![0]!.DeepClone(),
                ["startedAt"] = _startedAt.ToString("O"), ["finishedAt"] = finishedAt.ToString("O"),
                ["assertions"] = _assertions.DeepClone(),
            };
            File.WriteAllText(Path.Combine(staging, "assertions.json"), assertionProof.ToJsonString() + "\n", Utf8);
            File.WriteAllText(Path.Combine(staging, "grid.txt"), gridText + "\n", Utf8);
            File.WriteAllText(Path.Combine(staging, "status.txt"), statusText + "\n", Utf8);
            // DE: Rohdaten werden im selben atomaren Beleg publiziert; spätere Änderungen der Capture-Datei zählen nicht.
            // EN: Publish raw bytes within the same atomic proof; later capture-file changes cannot alter it.
            foreach (var pair in artifacts) File.WriteAllBytes(Path.Combine(staging, pair.Key), pair.Value);
            var artifactRefs = new JsonArray(Artifact(staging, final, "grid.txt"), Artifact(staging, final, "status.txt"));
            foreach (var nameOfArtifact in artifacts.Keys.Order(StringComparer.Ordinal)) artifactRefs.Add(Artifact(staging, final, nameOfArtifact));
            var record = new JsonObject
            {
                ["capabilityId"] = _capabilityId, ["pathId"] = _pathId,
                ["scenarioKind"] = _path["scenarioKind"]!.DeepClone(), ["kind"] = "Automated", ["outcome"] = "Pass",
                ["testRef"] = _path["testRefs"]![0]!.DeepClone(),
                ["assertionProofRef"] = Reference(staging, final, "assertions.json"),
                ["assertions"] = _assertions.DeepClone(), ["startedAt"] = _startedAt.ToString("O"),
                ["finishedAt"] = finishedAt.ToString("O"), ["observedState"] = _observed.DeepClone(),
                ["artifactRefs"] = artifactRefs,
            };
            File.WriteAllText(Path.Combine(staging, "path-result.json"), record.ToJsonString() + "\n", Utf8);
            // DE: Ein atomarer Verzeichniswechsel verhindert sichtbare Teilbelege; dies ist noch kein Plattform-Bundle.
            // EN: Atomic directory publication prevents visible partial proof; this is not yet a platform bundle.
            Directory.Move(staging, final);
            return record;
        }
        finally
        {
            if (Directory.Exists(staging)) Directory.Delete(staging, recursive: true);
        }
    }

    internal JsonObject? Complete(string gridText, string statusText) => Complete(RunDirectory.Value, gridText, statusText);

    internal JsonObject? Complete(string gridText, string statusText, IReadOnlyDictionary<string, byte[]> artifacts) => Complete(RunDirectory.Value, gridText, statusText, artifacts);

    private EvidenceProducer.Decision Reject(string code)
    {
        _failed = true;
        return new(false, code);
    }

    private bool Same(JsonObject expected, JsonObject actual) => EvidenceProducer.SameObservation(expected, actual, _pathId);

    private static string Reference(string staging, string final, string file) =>
        Path.GetRelativePath(FormulaContractCases.RepositoryRoot, Path.Combine(final, file)).Replace('\\', '/')
        + "#sha256=" + Convert.ToHexString(SHA256.HashData(File.ReadAllBytes(Path.Combine(staging, file)))).ToLowerInvariant();

    private static JsonObject Artifact(string staging, string final, string file)
    {
        var reference = Reference(staging, final, file).Split("#sha256=", StringSplitOptions.None);
        return new JsonObject { ["path"] = reference[0], ["sha256"] = reference[1] };
    }

    private static void EnsureOwnedDirectory(string directory)
    {
        var full = Path.GetFullPath(directory);
        var relative = Path.GetRelativePath(ResultsRoot, full);
        if (relative == ".." || relative.StartsWith(".." + Path.DirectorySeparatorChar, StringComparison.Ordinal)
            || Path.IsPathRooted(relative)) throw new ArgumentException("Proof output must stay in owned TestResults.", nameof(directory));
        for (var item = new DirectoryInfo(full); item is not null; item = item.Parent)
            if (item.LinkTarget is not null) throw new IOException("Proof output cannot traverse symbolic links.");
    }
}
