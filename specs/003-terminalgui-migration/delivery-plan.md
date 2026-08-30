# Lieferplan / Delivery Plan

## Autoritätsgrenzen / Authority Boundaries

Diese Planphase führt keine Implementierung, Build-/Test-Ausführung, Version,
Statistik, Commit-, Remote-, PR-, Merge- oder Intake-Aktion aus. Jede spätere
Phase prüft Run-ID, Branch, Intake-/Spec-Hashes, Delivery-Modus und Stop-Status
erneut. Die aktuelle vollständige Feature-003-Autorität umfasst exakt die
minimale Produkt-CI-Änderung an `.github/workflows/ci.yml`; Scope-Drift oder
jeder andere Workflow-/Automationsdiff benötigt neue ausdrückliche Autorität.

*This planning phase performs no implementation, build/test, version,
statistics, commit, remote, PR, merge, or intake action. Every later phase
revalidates run ID, branch, intake/spec hashes, delivery mode, and stop state.
Current complete Feature 003 authority includes exactly the minimum product-CI
change in `.github/workflows/ci.yml`; scope drift or any other workflow or
automation diff needs new explicit authority.*

Die gespeicherte Authority-Evidenz liegt in
`requirements/intakes/series/tinycalc-delivery/operation.json` und
`receipt.json`: Thorsten autorisierte `MergeAndSync` und einen engen
Admin-Bypass. Das ist kein Dauerrecht. Unmittelbar vor einem konkreten
PR-/Policy-Eingriff werden Autorisierer, PR, Policy, Umfang, Grund und
Restrisiko erneut festgehalten. Der Bypass darf ausschließlich eine formale
Merge-Berechtigungs- oder Ruleset-Grenze überwinden und niemals fehlende
Reviews, Checks, Plattformbefehle, Security-/A11Y-Nachweise oder einen falschen
Head ersetzen. / *Stored authority evidence names Thorsten and covers
`MergeAndSync` plus a narrow admin bypass, but is not continuing permission.
Revalidate authorizer, concrete PR and policy, scope, rationale, and residual
risk immediately before use. The bypass may address only a formal merge
permission or ruleset boundary, never missing reviews, checks, platform
commands, security/accessibility proof, or a wrong head.*

## Beabsichtigter Delivery-Set / Intended Delivery Set

Vor jedem Commit werden die tatsächlich beabsichtigten Pfade einzeln benannt
und geprüft. Produktionscode ist auf TUI-Projektdatei und `Program.cs`
beschränkt. Exakt `.github/workflows/ci.yml` ist als einzige Workflow-Ausnahme
enthalten, um auf `ubuntu-latest` und `windows-latest` Restore, Release-Build,
vollständige Release-Tests und Smoke mit Exitcode 0 sowie exakt `SMOKE_OK` für
den PR-Head auszuführen. Core, vorhandene Testquellen, Skripte, Agentenflächen
und alle anderen Workflows dürfen nicht erscheinen.

*Before every commit, each intended path is named and validated. Product code
is limited to the TUI project file and `Program.cs`. Exactly
`.github/workflows/ci.yml` is the sole workflow exception for the four product
commands and exact smoke token on Ubuntu and Windows at the PR head. Core,
existing test sources, scripts, agent surfaces, and every other workflow must
not appear.*

```powershell
pwsh -NoProfile -File .specify/presets/autonomous-run-governance/scripts/validate-autonomous-delivery-set.ps1 -Repo . -Intended <each-exact-intended-path>
git diff --name-status main...HEAD
git diff --check
```

Die Workflow-Änderung bleibt auf die minimal nötigen Produktjobs und Befehle in
`.github/workflows/ci.yml` begrenzt. Sie darf keine andere Action-Version,
Automation oder Workflow-Datei fachlich ändern. Beide Runner müssen denselben
exakten PR-Head belegen; Namen oder Teilbefehle reichen nicht.

*The workflow change stays limited to the minimum required product jobs and
commands in `.github/workflows/ci.yml`. It may not change any other action
version, automation, or workflow file. Both runners must prove the same exact PR
head; names or partial commands are insufficient.*

## Versionierung / Versioning

`Directory.Build.props` hält `Version`, `AssemblyVersion` und `FileVersion`
gleich. Für Branch 003 gilt `Major.<3>.<Patch>.<Build>`: Major bleibt bestehend,
Minor ist `3`, Patch ist `git rev-list --count main..HEAD + 1` vor dem aktuellen
Commit. Build wird vor jedem `dotnet build` und `dotnet test` serialisiert um
eins erhöht. Versionen werden vor Commit/Push erneut geprüft.

*All three repository-wide versions remain equal. Minor is 3, patch is the
feature commit count including the pending commit, and build increments
serially before each build or test.*

Jede Aufgabe, die einen Commit erzeugt oder amended, einschließlich der durch
den Provider erzeugten Produkt- und Closeout-Merge-Commits, muss die exakte Trailerzeile
`Co-authored-by: Copilot <223556219+Copilot@users.noreply.github.com>` setzen
oder erhalten und unmittelbar am tatsächlich erzeugten Commit read-only prüfen.
Lokale Commits verwenden `git log -1 --format=%B`; Provider-Merge-Commits werden
über `gh pr view` und `gh api` gelesen. Ein fehlender, abweichender oder
mehrfacher Trailer blockiert vor dem nächsten Schritt. / *Every task that
creates or amends a commit, including provider-generated product and closeout
merge commits, must set or preserve the exact trailer line and verify it
immediately on the actual commit. Local commits use `git log`; provider merge
commits are read through `gh pr view` and `gh api`. A missing, different, or
duplicate trailer blocks before the next step.*

## PR und Review-Konvergenz / PR and Review Convergence

Mit authentifizierter `gh`-CLI wird genau ein fokussierter PR erstellt. Die
Beschreibung `docs/PR_TEXT_TERMINALGUI_MIGRATION.md` enthält Problem, Lösung,
Risiken, Testplan, TUI-Textnachweis, Plattformbelege und Delivery-Set.

*One focused PR is created with authenticated `gh`. Its description contains
problem, solution, risks, test plan, textual TUI evidence, platform evidence,
and delivery set.*

```powershell
gh auth status
gh pr create --base main --head 003-terminalgui-migration --title <title> --body-file docs/PR_TEXT_TERMINALGUI_MIGRATION.md
gh pr checks <pr-number> --watch
gh pr view <pr-number> --json headRefOid,mergeStateStatus,reviewDecision,statusCheckRollup,url
gh api graphql -f query='<review-threads-query>' -F owner=<owner> -F name=<repo> -F number=<pr-number>
```

Konvergenz bedeutet: alle erforderlichen Checks grün, keine offene
Review-Konversation, keine Changes-Requested-Entscheidung, alle Befunde behoben
oder begründet akzeptiert und der geprüfte PR-Head unverändert. Jeder neue
Commit invalidiert die betroffenen Nachweise.

*Convergence means all required checks pass, no review thread remains open, no
changes-requested decision remains, all findings are fixed or explicitly
accepted, and the reviewed PR head is unchanged. A new commit invalidates
affected evidence.*

## Schema-2.0-Gates / Schema 2.0 Gates

Anforderungen stehen in `autonomous-run-gate-requirements.json`. PreMerge
bindet den PR-Head und enthält für jedes Gate genau eine Primary-Zeile;
Supplemental-Zeilen sind nur zusätzliche Belege. PostMerge bindet den
normalisierten PreMerge-Hash und den tatsächlichen Merge-Commit, hat keine
verbleibenden `changedPaths` und deckt wieder jeden Gate-Scope ab.

*Requirements live in the gate-requirements JSON. PreMerge binds the PR head
and has exactly one primary row per gate; supplemental rows only add proof.
PostMerge binds the normalised pre-merge hash and actual merge commit, has no
remaining changed paths, and again covers every gate scope.*

```powershell
pwsh -NoProfile -File .specify/presets/autonomous-run-governance/scripts/validate-autonomous-gate-evidence.ps1 -Requirements specs/003-terminalgui-migration/autonomous-run-gate-requirements.json -Evidence /tmp/tinycalc-003/gates/premerge.json -Head <pr-head-sha>
pwsh -NoProfile -File .specify/presets/autonomous-run-governance/scripts/validate-autonomous-gate-evidence.ps1 -Requirements specs/003-terminalgui-migration/autonomous-run-gate-requirements.json -Evidence /tmp/tinycalc-003/gates/postmerge.json -Head <reviewed-pr-head-sha> -MergeCommit <merge-commit-sha>
```

## MergeAndSync

Nach Review-Konvergenz, Autoritätsprüfung und gültigem PreMerge-Nachweis wird
der repositoryübliche Merge-Modus mit `gh pr merge` verwendet. Danach wird
lokales `main` per Fast-Forward synchronisiert und der exakte Merge-Commit für
PostMerge-Evidenz erfasst.

*After review convergence, authority revalidation, and valid pre-merge
evidence, the repository-approved mode is used with `gh pr merge`. Local main
is then fast-forward synced and the exact merge commit is captured for
post-merge evidence.*

Falls die konkret revalidierte GitHub-Policy den ausdrücklich autorisierten
engen Bypass benötigt, wird `--admin` nur zu demselben unten geplanten
`gh pr merge`-Aufruf mit explizitem `--subject` und `--body` hinzugefügt und nur
nach vollständiger Gate- und Review-Konvergenz verwendet. Ohne konkreten Bedarf
wird kein Bypass ausgeübt. / *If the concretely revalidated GitHub policy
requires the explicitly authorized narrow bypass, add `--admin` only to the
same merge command planned below with explicit `--subject` and `--body`, and
only after complete gate and review convergence. Do not exercise a bypass when
it is unnecessary.*

```powershell
$mergeTrailer = 'Co-authored-by: Copilot <223556219+Copilot@users.noreply.github.com>'
$mergeBody = "Feature 003 Terminal.Gui migration.`n`n$mergeTrailer"
gh pr merge <pr-number> --merge --subject 'feat: migrate Terminal.Gui to 2.x' --body $mergeBody
$mergeCommit = gh pr view <pr-number> --json mergeCommit --jq '.mergeCommit.oid'
$mergeMessage = gh api "repos/{owner}/{repo}/commits/$mergeCommit" --jq '.commit.message'
$exactTrailerLines = @($mergeMessage -split '\r?\n' | Where-Object { $_ -eq $mergeTrailer })
if ($exactTrailerLines.Count -ne 1) { throw 'Product merge commit trailer verification failed.' }
git switch main
git pull --ff-only
git rev-parse HEAD
```

Die Prüfung des tatsächlichen Produkt-Merge-Commits erfolgt innerhalb von T070
unmittelbar nach `gh pr merge` und vor T071. T080 ist die abschließende
Gesamtprüfung, nicht die erste Trailerprüfung. Für den Closeout-Merge in T079
gilt derselbe Ablauf mit `--subject 'chore: close Feature 003 delivery'` und
`--body "Feature 003 causal closeout.`n`n$mergeTrailer"`; auch dort werden
Merge-SHA und tatsächliche Commit-Nachricht sofort per `gh pr view`/`gh api`
gelesen und exakt eine Trailerzeile verlangt, bevor Synchronisation oder
Abschlussprüfung fortgesetzt wird.

*T070 verifies the actual product merge commit immediately after `gh pr merge`
and before T071. T080 is final verification, not the first trailer check. T079
uses the same flow for closeout with the stated subject/body options and
immediately reads the actual merge SHA and message through `gh pr view`/`gh
api`, requiring exactly one trailer line before sync or final verification.*

## Kausaler Abschluss und Intake-Serie / Causal Closeout and Intake Series

Nach Merge wird das Lastenheft gemäß Governance zu
`Lastenheft_TerminalGui_Migration.003-terminalgui-migration.md` umbenannt. Falls
dies nicht im Feature-PR möglich war, darf nur der vorbenannte kausale
Closeout-Branch `codex/003-terminalgui-migration-closeout` verwendet werden.
Die Umbenennung nutzt auf dem macOS-Ausführungsort gemäß Constitution das
vorhandene Bash-Skript: `bash scripts/rename-lastenheft.sh requirements/intakes/active/Lastenheft_TerminalGui_Migration.md 003-terminalgui-migration`.
Erst nach erfolgreichem PostMerge-Gate und
erneuter ausdrücklicher Autorität folgt `speckit-intake-series-update`; danach
wird der Serienstatus read-only geprüft. Es wird kein nächstes Feature gestartet.
Vor dem einzigen Closeout-PR-Merge werden Rename, Serienartefakte, Statistik,
Run-Evidenz und der getrackte Delivery-Vertrag in genau einem Closeout-Commit
mit dem exakten Co-author-Trailer abgeschlossen. Dies ist die terminale Grenze
für getrackte Belege.

*After merge, the repository Bash script required for macOS/Linux renames the
intake to the branch-qualified file. If it could not be included in the feature PR, only
the predeclared `codex/003-terminalgui-migration-closeout` branch may be used.
Only after a passing post-merge gate and renewed explicit authority may
`speckit-intake-series-update` run, followed by a read-only series status check.
No next feature starts. Before the single closeout pull request merges, rename,
series artefacts, statistics, run evidence, and the tracked delivery contract
are completed in exactly one closeout commit with the exact co-author trailer.
This is the terminal boundary for tracked evidence.*

Nach dem Closeout-Merge werden PR-, Check-, Review-, Merge- und Sync-Fakten nur
read-only beim Provider gelesen und in
`.specify/runtime/autonomous-routing/38ad4c1d-bf85-4053-b585-eb490176b727/closeout-provider-evidence.json`
abgelegt. Danach dürfen weder getracktes `delivery.md` noch Run-State oder eine
andere getrackte Datei geändert werden; ein dritter Commit oder PR ist verboten.
/ *After the closeout merge, provider and sync facts are read only and stored
in the named runtime evidence. No tracked file may change afterwards. The
feature-local `autonomous-run-state.json` is operational runtime state, remains
untracked and locally ignored throughout delivery, and may therefore be updated
by the phase wrapper without changing `main`. No third commit or pull request
may be created.*

## Abschlussbedingung / Completion Condition

Delivery ist erst abgeschlossen, wenn Version, Statistik, Security/A11Y,
Dependency/SBOM/SLSA einschließlich null bekannter Schwachstellen und null
unbekannter/inkompatibler Lizenzen im ausgelieferten Graph, Coverage,
Linux/Windows CI, manuelle macOS-Abnahme,
Delivery-Set, Review, MergeAndSync, Schema-2.0-PostMerge und autorisierter
Intake-Follow-up vollständig belegt sind. Ein fehlender Beleg ergibt `Blocked`
oder `Failed`, niemals `Completed`.

*Delivery completes only with full evidence for every named item. Missing
evidence yields Blocked or Failed, never Completed.*
