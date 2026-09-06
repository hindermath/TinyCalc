#!/usr/bin/env bash
set -euo pipefail

script_dir=$(CDPATH= cd -- "$(dirname -- "$0")" && pwd)
repository_root=$(CDPATH= cd -- "$script_dir/../../.." && pwd)
validator_ps="$repository_root/scripts/validate-gsdb-intensive-review.ps1"
validator_sh="$repository_root/scripts/validate-gsdb-intensive-review.sh"
valid_fixture="$script_dir/valid-assessment.json"
production_assessment="$repository_root/docs/security/gsdb-intensive-review/evidence-matrix.json"
fixture_root=$(mktemp -d "${TMPDIR:-/tmp}/tinycalc-gsdb-fixtures.XXXXXX")
trap 'rm -rf -- "$fixture_root"' EXIT HUP INT TERM

run_and_capture() {
  entry=$1
  assessment_file=$2
  stdout_file=$3
  stderr_file=$4
  validation_root=${5:-$repository_root}
  set +e
  if [ "$entry" = ps ]; then
    pwsh -NoProfile -File "$validator_ps" -Action Validate \
      -Assessment "$assessment_file" -RepositoryRoot "$validation_root" \
      >"$stdout_file" 2>"$stderr_file"
  else
    bash "$validator_sh" --action validate --assessment "$assessment_file" \
      --repository-root "$validation_root" >"$stdout_file" 2>"$stderr_file"
  fi
  captured_exit=$?
  set -e
  return "$captured_exit"
}

assert_parity_failure() {
  assessment_file=$1
  expected_code=$2
  validation_root=${3:-$repository_root}
  ps_out="$fixture_root/${expected_code}.ps.out"
  ps_err="$fixture_root/${expected_code}.ps.err"
  sh_out="$fixture_root/${expected_code}.sh.out"
  sh_err="$fixture_root/${expected_code}.sh.err"

  ps_exit=0
  run_and_capture ps "$assessment_file" "$ps_out" "$ps_err" "$validation_root" || ps_exit=$?
  sh_exit=0
  run_and_capture sh "$assessment_file" "$sh_out" "$sh_err" "$validation_root" || sh_exit=$?

  [ "$ps_exit" -ne 0 ] && [ "$sh_exit" -eq "$ps_exit" ] || {
    echo "Exit-code mismatch for $expected_code: ps=$ps_exit sh=$sh_exit" >&2
    exit 1
  }
  cmp -s "$ps_out" "$sh_out" || {
    echo "stdout mismatch for $expected_code" >&2
    exit 1
  }
  cmp -s "$ps_err" "$sh_err" || {
    echo "stderr mismatch for $expected_code" >&2
    exit 1
  }
  grep -q "^${expected_code}:" "$ps_err" || {
    echo "Expected $expected_code in stderr" >&2
    exit 1
  }
}

missing_fixture="$fixture_root/missing.json"
assert_parity_failure "$missing_fixture" GSDB001

jq '(.sourceInventory[0].normalizedSha256) |= ascii_upcase' "$valid_fixture" >"$fixture_root/GSDB002.json"
jq '.checklistRows[0].id = "CL-99-99"' "$valid_fixture" >"$fixture_root/GSDB003.json"
jq '.fixtureCanonicalBlock = "canonical" | .fixtureCompendiumBlock = "different"' "$valid_fixture" >"$fixture_root/GSDB004.json"
jq 'del(.checklistRows[0].learningStage)' "$valid_fixture" >"$fixture_root/GSDB005.json"
jq '.checklistRows[0].evidence = []' "$valid_fixture" >"$fixture_root/GSDB006.json"
jq '.checklistRows[0].humanOnly = true' "$valid_fixture" >"$fixture_root/GSDB007.json"
jq '.presetAssessments = [] | .fixtureExpectedPresetIds = ["security-governance"]' "$valid_fixture" >"$fixture_root/GSDB008.json"
jq '.checklistRows[0].findingIds = ["GSDB-FINDING-001"] | .findings = []' "$valid_fixture" >"$fixture_root/GSDB009.json"
jq '.summary = {"checklistTotal": 2}' "$valid_fixture" >"$fixture_root/GSDB010.json"

for expected_code in GSDB002 GSDB003 GSDB004 GSDB005 GSDB006 GSDB007 GSDB008 GSDB009 GSDB010; do
  assert_parity_failure "$fixture_root/${expected_code}.json" "$expected_code"
done

jq '.checklistRows[0].evidence[0].path = "/tmp/not-repository-evidence"' \
  "$production_assessment" >"$fixture_root/production-absolute-evidence.json"
assert_parity_failure "$fixture_root/production-absolute-evidence.json" GSDB001

jq '.sourceInventory[0].path = "../outside.json"' "$valid_fixture" >"$fixture_root/traversal.json"
jq '.sourceInventory[0].path = "C:/outside.json"' "$valid_fixture" >"$fixture_root/windows-path.json"
jq '.sourceInventory[0].path = "docs\\outside.json"' "$valid_fixture" >"$fixture_root/backslash-path.json"
assert_parity_failure "$fixture_root/traversal.json" GSDB002
assert_parity_failure "$fixture_root/windows-path.json" GSDB002
assert_parity_failure "$fixture_root/backslash-path.json" GSDB002

symlink_root="$fixture_root/symlink-root"
mkdir -p "$symlink_root"
ln -s "$repository_root/docs/secure-development/baseline-manifest.json" "$symlink_root/linked-source.json"
jq '.sourceInventory[0].path = "linked-source.json"' "$valid_fixture" >"$fixture_root/symlink-boundary.json"
assert_parity_failure "$fixture_root/symlink-boundary.json" GSDB002 "$symlink_root"

jq '.checklistRows[0].evidence[0].locator = "Evidence for CL-01-01"' \
  "$production_assessment" >"$fixture_root/production-placeholder-locator.json"
assert_parity_failure "$fixture_root/production-placeholder-locator.json" GSDB006

jq '.checklistRows[0].evidence[0].locator = "definitely-missing-locator-target"' \
  "$production_assessment" >"$fixture_root/production-missing-locator.json"
assert_parity_failure "$fixture_root/production-missing-locator.json" GSDB006

jq '(.checklistRows[] | select(.id == "CL-01-03") | .evidence[] | select(.path == "docs/security/sbom/tinycalc-terminalgui.spdx.json")) |= (.locator = "definitely-missing-exact-locator" | .supports.de = "CL-01-03 bindet docs/security/sbom/tinycalc-terminalgui.spdx.json an definitely-missing-exact-locator." | .supports.en = "CL-01-03 binds docs/security/sbom/tinycalc-terminalgui.spdx.json at definitely-missing-exact-locator.")' \
  "$production_assessment" >"$fixture_root/json-locator.json"
jq '(.checklistRows[] | select(.id == "CL-10-06") | .evidence[] | select(.path == "scripts/scan-agent-secrets.ps1")) |= (.locator = "definitely-missing-exact-locator" | .supports.de = "CL-10-06 bindet scripts/scan-agent-secrets.ps1 an definitely-missing-exact-locator." | .supports.en = "CL-10-06 binds scripts/scan-agent-secrets.ps1 at definitely-missing-exact-locator.")' \
  "$production_assessment" >"$fixture_root/script-locator.json"
jq '(.checklistRows[] | select(.id == "CL-12-06") | .evidence[] | select(.path == ".specify/presets/.registry")) |= (.locator = "definitely-missing-exact-locator" | .supports.de = "CL-12-06 bindet .specify/presets/.registry an definitely-missing-exact-locator." | .supports.en = "CL-12-06 binds .specify/presets/.registry at definitely-missing-exact-locator.")' \
  "$production_assessment" >"$fixture_root/registry-locator.json"
assert_parity_failure "$fixture_root/json-locator.json" GSDB006
assert_parity_failure "$fixture_root/script-locator.json" GSDB006
assert_parity_failure "$fixture_root/registry-locator.json" GSDB006

jq '.checklistRows[0].evidence[0] |= (.path = "README.md" | .locator = "# TinyCalc" | .supports.de = "CL-01-01 bindet README.md an # TinyCalc." | .supports.en = "CL-01-01 binds README.md at # TinyCalc.")' \
  "$production_assessment" >"$fixture_root/unbound-evidence.json"
assert_parity_failure "$fixture_root/unbound-evidence.json" GSDB006

jq '(.sourceInventory[] | select(.path == "docs/security/threat-model.md") | .freshness) = "Stale"' \
  "$production_assessment" >"$fixture_root/stale-positive-evidence.json"
assert_parity_failure "$fixture_root/stale-positive-evidence.json" GSDB006

jq '.checklistRows[0].evidence[0].freshness = "Planned"' \
  "$production_assessment" >"$fixture_root/availability-freshness-drift.json"
assert_parity_failure "$fixture_root/availability-freshness-drift.json" GSDB006

jq '(.checklistRows[] | select(.id == "CL-01-02") | .evidence[] | select(.path == "docs/security/asvs-verification.md")) |= (.locator = "ASVS-Anwendbarkeit: TinyCalc Feature 003" | .supports.de = "CL-01-02 bindet docs/security/asvs-verification.md an ASVS-Anwendbarkeit: TinyCalc Feature 003." | .supports.en = "CL-01-02 binds docs/security/asvs-verification.md at ASVS-Anwendbarkeit: TinyCalc Feature 003.")' \
  "$production_assessment" >"$fixture_root/stale-feature-heading.json"
assert_parity_failure "$fixture_root/stale-feature-heading.json" GSDB006

jq '.checklistRows[0].rationale = {"de":"Der Kontrollpunkt CL-01-01 ist allgemein bewertet.","en":"The control CL-01-01 is assessed generically."}' \
  "$production_assessment" >"$fixture_root/generic-rationale.json"
assert_parity_failure "$fixture_root/generic-rationale.json" GSDB005

jq '.checklistRows[0].evidence[0].supports = {"de":"Der Locator CL-01-01 in constitution.md dokumentiert den aktuellen Teilnachweis.","en":"The locator CL-01-01 in constitution.md records the current evidence."}' \
  "$production_assessment" >"$fixture_root/generic-support.json"
assert_parity_failure "$fixture_root/generic-support.json" GSDB006

jq '.presetAssessments[0].mappedGateIds = ["GSDB-GATE-001"]' \
  "$production_assessment" >"$fixture_root/production-preset-drift.json"
assert_parity_failure "$fixture_root/production-preset-drift.json" GSDB008

jq '.presetAssessments[0].mappedChecklistIds |= .[1:]' \
  "$production_assessment" >"$fixture_root/preset-checklist-drift.json"
assert_parity_failure "$fixture_root/preset-checklist-drift.json" GSDB008

jq '.findings[0].sourceReferences |= .[1:]' \
  "$production_assessment" >"$fixture_root/production-finding-drift.json"
assert_parity_failure "$fixture_root/production-finding-drift.json" GSDB009

jq '.findings += [(.findings[0] | .id = "GSDB-FINDING-999")]' \
  "$production_assessment" >"$fixture_root/orphaned-finding.json"
assert_parity_failure "$fixture_root/orphaned-finding.json" GSDB009

jq '.findings[0].severity = "Low"' \
  "$production_assessment" >"$fixture_root/downgraded-finding.json"
assert_parity_failure "$fixture_root/downgraded-finding.json" GSDB009

jq '.checklistRows[0].severity = "Medium"' \
  "$production_assessment" >"$fixture_root/fulfilled-severity.json"
jq '(.checklistRows[] | select(.applicability == "Open") | .humanOnly) = false' \
  "$production_assessment" >"$fixture_root/open-without-human.json"
jq '(.checklistRows[] | select(.applicability == "N/A") | .severity) = "Medium"' \
  "$production_assessment" >"$fixture_root/na-with-severity.json"
assert_parity_failure "$fixture_root/fulfilled-severity.json" GSDB005
assert_parity_failure "$fixture_root/open-without-human.json" GSDB005
assert_parity_failure "$fixture_root/na-with-severity.json" GSDB005

sensitive_sentinel='sentinel-secret-value'
set +e
pwsh -NoProfile -File "$validator_ps" -Action "$sensitive_sentinel" \
  -Assessment "$valid_fixture" -RepositoryRoot "$repository_root" \
  >"$fixture_root/action.ps.out" 2>"$fixture_root/action.ps.err"
ps_action_exit=$?
bash "$validator_sh" --action "$sensitive_sentinel" \
  --assessment "$valid_fixture" --repository-root "$repository_root" \
  >"$fixture_root/action.sh.out" 2>"$fixture_root/action.sh.err"
sh_action_exit=$?
bash "$validator_sh" --unknown-option "$sensitive_sentinel" \
  >"$fixture_root/option.sh.out" 2>"$fixture_root/option.sh.err"
sh_option_exit=$?
set -e
[ "$ps_action_exit" -eq 1 ] && [ "$sh_action_exit" -eq 1 ] && [ "$sh_option_exit" -eq 1 ]
cmp -s "$fixture_root/action.ps.out" "$fixture_root/action.sh.out"
cmp -s "$fixture_root/action.ps.err" "$fixture_root/action.sh.err"
grep -qx 'GSDB001: unsupported action.' "$fixture_root/action.ps.err"
grep -qx 'GSDB001: unknown option.' "$fixture_root/option.sh.err"
if grep -q -- "$sensitive_sentinel" "$fixture_root/action.ps.out" \
    "$fixture_root/action.ps.err" "$fixture_root/action.sh.out" \
    "$fixture_root/action.sh.err" "$fixture_root/option.sh.out" \
    "$fixture_root/option.sh.err"; then
  printf '%s\n' 'Sensitive sentinel was echoed by an invalid-input path.' >&2
  exit 1
fi

ps_out="$fixture_root/valid.ps.out"
ps_err="$fixture_root/valid.ps.err"
sh_out="$fixture_root/valid.sh.out"
sh_err="$fixture_root/valid.sh.err"
run_and_capture ps "$valid_fixture" "$ps_out" "$ps_err"
run_and_capture sh "$valid_fixture" "$sh_out" "$sh_err"
cmp -s "$ps_out" "$sh_out"
cmp -s "$ps_err" "$sh_err"

printf '%s\n' 'PASS: Bash and PowerShell fixtures cover GSDB001-GSDB010 plus semantic mapping, evidence, finding, and redaction cases.'
