# Quickstart: GSDB-Intensivpruefung / Intensive GSDB Review

## Zweck / Purpose

**DE:** Diese Befehlsfolge beschreibt die spaetere reproduzierbare Pruefung und
Lieferung. Sie ist keine bereits ausgefuehrte Freigabe. Human-only-
Entscheidungen, rechtliche Bewertung und Produkt-Haertung bleiben getrennt.

**EN:** This command sequence describes the later reproducible assessment and
delivery. It is not an already executed approval. Human-only decisions, legal
assessment, and product hardening remain separate.

## 1. Preflight und aktueller Lauf / Preflight and Current Run

```powershell
pwsh -NoProfile -File .specify/presets/autonomous-run-governance/scripts/validate-autonomous-run-state.ps1 `
  -State specs/005-gsdb-intensive-review/autonomous-run-state.json

pwsh -NoProfile -File .specify/presets/intake-review-governance/scripts/validate-intake-review-result.ps1 `
  -Result requirements/intakes/series/tinycalc-delivery/intake-review-result.json `
  -Repo .

pwsh -NoProfile -File .specify/presets/intake-sequencing-governance/scripts/validate-intake-series-manifest.ps1 `
  -File requirements/intakes/series/tinycalc-delivery/manifest.json `
  -Repo .
```

Expected: active Feature 005 on `005-gsdb-intensive-review`, accepted hashes
match, series review is `Ready`, and GSDB is the only `declaredEligible` target
selected by current authority. The validator may also report structurally free
but unselected targets; they remain outside this feature. Any drift requires
revalidation before writes.

## 2. RED-Vertrag / RED Contract

Create a fresh missing path so RED remains reproducible after the real matrix
exists:

```powershell
$GsdbMissingMatrix = Join-Path ([IO.Path]::GetTempPath()) `
  ("tinycalc-gsdb-missing-{0}.json" -f [guid]::NewGuid())
pwsh -NoProfile -File scripts/validate-gsdb-intensive-review.ps1 `
  -Action Validate `
  -Assessment $GsdbMissingMatrix `
  -RepositoryRoot .
```

Expected: non-zero exit and `GSDB001`. This expected failure must be captured
separately and must not allow later gates to be skipped.

Run all focused negative and smallest-valid fixtures:

```powershell
pwsh -NoProfile -File scripts/validate-gsdb-intensive-review.ps1 `
  -Action ValidateFixtures `
  -Assessment docs/security/gsdb-intensive-review/evidence-matrix.json `
  -RepositoryRoot .

bash scripts/validate-gsdb-intensive-review.sh `
  --action validate-fixtures `
  --assessment docs/security/gsdb-intensive-review/evidence-matrix.json `
  --repository-root .
```

The fixture suite must cover `GSDB001` through `GSDB010`, including missing,
duplicate and unknown IDs; axis contradictions; unsafe paths; stale hashes;
missing learning stage, reviewer, locator, expected evidence, target date,
trigger or evidence; Human-only fabrication;
compendium mismatch; omitted preset/duty; and summary drift.

## 3. Quellen, Sammelband und GREEN / Sources, Compendium, and GREEN

```powershell
pwsh -NoProfile -File scripts/validate-gsdb-intensive-review.ps1 `
  -Action ValidateSources `
  -Assessment docs/security/gsdb-intensive-review/evidence-matrix.json `
  -RepositoryRoot .

pwsh -NoProfile -File scripts/validate-gsdb-intensive-review.ps1 `
  -Action ValidateCompendium `
  -Assessment docs/security/gsdb-intensive-review/evidence-matrix.json `
  -RepositoryRoot .

pwsh -NoProfile -File scripts/validate-gsdb-intensive-review.ps1 `
  -Action ValidateMappings `
  -Assessment docs/security/gsdb-intensive-review/evidence-matrix.json `
  -RepositoryRoot .

pwsh -NoProfile -File scripts/validate-gsdb-intensive-review.ps1 `
  -Action Validate `
  -Assessment docs/security/gsdb-intensive-review/evidence-matrix.json `
  -RepositoryRoot .

bash scripts/validate-gsdb-intensive-review.sh `
  --action validate `
  --assessment docs/security/gsdb-intensive-review/evidence-matrix.json `
  --repository-root .
```

Expected GREEN: `157/157` exact IDs, 12/12 families, 13/13 presets, complete
source inventory, reconciled compendium and external duties, internally derived
summary, and zero unsupported claims. An open product finding may remain only
with complete ownership/follow-up data and non-blocking assessment impact.
`Open` means unresolved applicability. A known applicable control with missing
fulfilment evidence stays `Applicable`, uses a non-fulfilled implementation
status, and links an owned finding with expected evidence and a target date.

## 4. Security, Supply Chain, and Assurance

```powershell
dotnet list MicroCalc.sln package --include-transitive
dotnet list MicroCalc.sln package --outdated --include-transitive
dotnet list MicroCalc.sln package --vulnerable --include-transitive

pwsh -NoProfile -File .specify/presets/secure-development-assurance-governance/scripts/validate-secure-development-assurance.ps1 `
  -EvidenceDirectory docs/security/secure-development/2026-09-05-rl-se-self-assessment `
  -Action Status
```

The old Feature-004 status is input evidence only. Feature 005 separately
reviews NIST SSDF, CWE Top 25, C# secure coding, STRIDE/CIA/CAPEC, SBOM, VEX,
SLSA/provenance, OpenSSF, Zero Trust delivery boundaries, BSI C3A/C5, regulation,
privacy and SAMM. A known unresolved critical CVE blocks delivery. Legal and
Human-only approvals remain open without genuine external evidence.
The review also records the observed absence or presence of Dependabot/Renovate
and central Dependency-Track ingestion. Missing automation becomes owned CL-05
follow-up; this assessment does not enable it silently.

## 5. Dokumentation, A11Y und Statistik / Documentation, A11Y, and Statistics

```powershell
pwsh -NoProfile -File scripts/test-documentation-impact.ps1
pwsh -NoProfile -File scripts/validate-documentation-impact.ps1 `
  -Evidence docs/documentation-impact/gsdb-intensive-review.json
pwsh -NoProfile -File scripts/check-homogeneity.ps1 `
  -TargetDir . `
  -DryRun `
  -NoPatch
pwsh -NoProfile -File scripts/render-project-statistics.ps1 `
  -Repo . `
  -CheckOnly

docfx docfx.json
lynx -dump -nolist _site/docs/security/gsdb-intensive-review/evidence-matrix.html
```

Manual text review records DE-first/EN-second parity, CEFR B2, heading order,
meaningful links, correct German umlauts and `ß`, linear reading order and
status/owner/follow-up meaning without colour. Because `docfx.json` includes
changed `docs/**/*.md`, DocFX regeneration and the representative lynx dump are
mandatory. Use Playwright/axe as the preferred additional smoke when the
reviewed toolchain is available; record an unavailable preferred harness rather
than silently claiming it ran. Text review is not a claimed screen-reader user
test or WCAG certification.

## 6. Script-, Secret- und Paritaetspruefung / Script, Secret, and Parity Checks

```powershell
pwsh -NoProfile -File scripts/invoke-psscriptanalyzer.ps1
pwsh -NoProfile -File scripts/scan-agent-secrets.ps1 `
  -FailOnHigh `
  -WorkspaceRoot .
```

```bash
bash -n scripts/validate-gsdb-intensive-review.sh
bash scripts/scan-agent-secrets.sh --fail-on-high .
bash scripts/check-homogeneity.sh --dry-run --no-patch .
```

Provider evidence additionally binds the gitleaks job and the actual workflow
commands/runners. No credential, runner profile, runtime log, private absolute
path or agent state may enter the tracked delivery set.

## 7. Produktregression / Product Regression

Before every build or test, update `Directory.Build.props` so `Version`,
`AssemblyVersion`, and `FileVersion` all use feature minor 5, the prospective
feature-branch commit count including the pending commit, and a newly
incremented build counter.

```powershell
dotnet restore MicroCalc.sln
dotnet build MicroCalc.sln --configuration Release --no-restore
dotnet test MicroCalc.sln --configuration Release --no-build
$GsdbSmokeOutput = @(
  dotnet run --no-build --configuration Release `
    --project src/MicroCalc.Tui/MicroCalc.Tui.csproj `
    -- --smoke
)
if ($LASTEXITCODE -ne 0) { exit $LASTEXITCODE }
if ($GsdbSmokeOutput.Count -ne 1 -or $GsdbSmokeOutput[0] -cne 'SMOKE_OK') {
  throw 'Smoke output must be exactly SMOKE_OK.'
}
$GsdbSmokeOutput
```

Linux and Windows evidence comes only from the `ci` job logs for the exact PR
head. Product changed-code coverage is N/A while `src/` and product behavior
remain unchanged. Any product delta blocks until RED/GREEN and the 70% minimum,
80% target are planned and demonstrated.

## 8. Liefermenge vor Commit/Push / Delivery Set Before Commit or Push

Pass every intended untracked path explicitly. The final list is derived from
`tasks.md` and the actual worktree; it is not guessed from this example.

```powershell
pwsh -NoProfile -File .specify/presets/autonomous-run-governance/scripts/validate-autonomous-delivery-set.ps1 `
  -Repo . `
  -Intended specs/005-gsdb-intensive-review/plan.md,docs/security/gsdb-intensive-review/evidence-matrix.json
git diff --cached --check
git status --short
```

The validator must leave index and worktree unchanged. Stage only approved
paths. Do not include ignored runtime evidence or unrelated user changes.

## 9. PR und Exact-Head-Review / PR and Exact-Head Review

Use authenticated `gh` only after current remote authority is revalidated:

```powershell
gh pr checks --required --watch --fail-fast
gh pr view --json headRefOid,reviewDecision,mergeStateStatus,reviews,statusCheckRollup
gh api graphql -f query='query { viewer { login } }'
```

The real GraphQL review-thread query is stored with the delivery evidence and
must target the current PR. Completion needs all required checks at the exact
head, no current `Changes Requested`, and no unresolved actionable thread. An
unavailable reviewer is missing, not approval.

## 10. Temporaeres PreMerge / Temporary PreMerge

Generate the schema-2.0 snapshot in the ignored run directory and bind it to
the full reviewed head and normalized requirements hash:

```powershell
$GsdbReviewedHead = git rev-parse HEAD
$GsdbPreMerge = '.specify/runtime/autonomous-routing/69674c80-911c-40ff-9a0e-004f7b13b832/premerge-gate-evidence.json'
pwsh -NoProfile -File .specify/presets/autonomous-run-governance/scripts/validate-autonomous-gate-evidence.ps1 `
  -Requirements specs/005-gsdb-intensive-review/contracts/autonomous-run-gate-requirements.json `
  -Evidence $GsdbPreMerge `
  -Head $GsdbReviewedHead
```

Every declared gate needs exactly one `Primary` row. Applicable entries contain
actual executed commands and runner/platform tokens from definitions or logs.
N/A entries contain rationale and trigger. PreMerge has no merge claim.

## 11. Merge und formale Bypass-Grenze / Merge and Formal Bypass Boundary

Normal merge is preferred:

```powershell
gh pr merge --merge --delete-branch
```

`GSDB-GATE-029` is initially N/A. Only if every material gate is green and the
sole exact-head provider blocker is a formal merge rule may the accepted
requirements be changed, reviewed again, and rebound to fresh PreMerge evidence
before this authorised command is used:

```powershell
gh pr merge --merge --admin --delete-branch
```

The bypass never replaces security, A11Y, evidence, platform, technical,
specialist, provider or review proof and does not authorise branch-protection
changes.

## 12. PostMerge, Intake-Stamp und Sync / PostMerge, Intake Stamp, and Sync

```powershell
gh pr view --json mergedAt,mergeCommit,state,headRefOid
git switch main
git pull --ff-only

$GsdbMergeCommit = git rev-parse HEAD
$GsdbReviewedHead = '<full reviewed feature head from accepted PreMerge>'
$GsdbPostMerge = '.specify/runtime/autonomous-routing/69674c80-911c-40ff-9a0e-004f7b13b832/postmerge-gate-evidence.json'
pwsh -NoProfile -File .specify/presets/autonomous-run-governance/scripts/validate-autonomous-gate-evidence.ps1 `
  -Requirements specs/005-gsdb-intensive-review/contracts/autonomous-run-gate-requirements.json `
  -Evidence $GsdbPostMerge `
  -Head $GsdbReviewedHead `
  -MergeCommit $GsdbMergeCommit
```

In the pre-named causal evidence-only branch
`codex/005-gsdb-intensive-review-closeout`, run the repository rename workflow
for only the GSDB intake so the result ends with
`.005-gsdb-intensive-review.md`. Update `tinycalc-delivery` exactly once with
preserved archives, lineage, order, roots and edges. Then validate:

```powershell
pwsh -NoProfile -File scripts/validate-requirements-intake-alignment.ps1 `
  -RepositoryRoot .
pwsh -NoProfile -File .specify/presets/intake-sequencing-governance/scripts/validate-intake-series-manifest.ps1 `
  -File requirements/intakes/series/tinycalc-delivery/manifest.json `
  -Repo .
pwsh -NoProfile -File .specify/presets/intake-sequencing-governance/scripts/validate-intake-series-receipt.ps1 `
  -File requirements/intakes/series/tinycalc-delivery/receipt.json `
  -Repo .

bash scripts/validate-requirements-intake-alignment.sh --repository-root .
bash .specify/presets/intake-sequencing-governance/scripts/validate-intake-series-manifest.sh \
  --file requirements/intakes/series/tinycalc-delivery/manifest.json \
  --repo .
bash .specify/presets/intake-sequencing-governance/scripts/validate-intake-series-receipt.sh \
  --file requirements/intakes/series/tinycalc-delivery/receipt.json \
  --repo .
```

The PostMerge snapshot binds the accepted PreMerge hash and actual merge commit
and has empty `changedPaths`. After the causal closeout PR, fast-forward local
`main` again, complete final read-only validation, clean feature/closeout
branches, and mark the run `Completed` only when all closeout fields are
terminal. Do not start another feature or campaign.
