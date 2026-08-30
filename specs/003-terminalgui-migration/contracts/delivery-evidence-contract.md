# Liefernachweisvertrag / Delivery Evidence Contract

## Rollen und Bindung / Roles and Binding

- `PreMerge`: bindet den unveränderten PR-Head und enthält je Gate genau eine
  Primary-Zeile; Supplemental-Zeilen dürfen sie ergänzen. / Binds the unchanged
  PR head with exactly one primary row per gate; supplemental rows may add proof.
- `PostMerge`: bindet den akzeptierten PreMerge-Hash und den synchronisierten
  Merge-Commit; je Gate gilt wieder genau eine Primary-Zeile. / Binds the
  accepted pre-merge hash and synced merge commit, again with one primary row
  per gate.
- Jeder Eintrag enthält Gate-ID, Scope, SHA, UTC-Zeit, exakten Befehl,
  Runner/Plattform, Exitcode, Ergebnis und Artefakt-Hash. / Each row contains
  gate ID, scope, SHA, UTC time, exact command, platform, exit code, outcome,
  and artefact hash.

## Pflichtartefakte / Required Artefacts

Plan/Tasks, Source- und Testgrenzen, RGR-Slice, Release-Build/Test/Smoke,
13-Key-/Quit-/Fokus-A11Y, Changed-Code-Coverage, Dependency Audit, Threat Model,
Security Checklist/Scenarios, SAMM, SPDX-SBOM, SLSA/OpenSSF, Statistik,
Versionierung, Linux-/Windows-Protokolle, Delivery-Set, Review-Konvergenz,
MergeAndSync, die enge Admin-Bypass-Autorität und Intake-Closeout müssen ihre
Gate-IDs abdecken.

*The corresponding planning, implementation, verification, supply-chain,
delivery, narrow admin-bypass authority, and closeout artefacts must cover
their declared gate IDs.*

## N/A-Vertrag / N/A Contract

ASVS, VEX, AI-SBOM, Zero Trust, BSI C3A/C5, Regulatorik, allgemeiner ADR,
Skriptparität, Agentenparität, Parallelkampagne, DocFX und
Dependency-Automation sind nur mit der in der Gate-Datei genannten Begründung
N/A. Jeder Trigger aktiviert eine erneute Anwendbarkeitsprüfung und verhindert
die Übernahme alter N/A-Evidenz.

*Each named N/A gate is valid only with the rationale in the gate file. Any
trigger forces re-evaluation and prevents reuse of old N/A evidence.*

Der fokussierte S-ADR und die vollständige arc42-Section-8-Aktualisierung sind
für Feature 003 `Applicable` und Pflichtartefakte; sie dürfen nicht durch eine
N/A-Disposition ersetzt werden. / *The focused security ADR and complete
arc42 Section 8 update are Applicable and required for Feature 003; an N/A
disposition cannot replace them.*

## Gültigkeit / Validity

Ein Evidence-Dokument ist ungültig bei fehlendem Gate, falschem Scope,
abweichendem Befehl-/Plattformtoken, nicht passendem SHA, späterem Commit,
ungeklärtem Befund oder fehlendem Artefakt-Hash. Ein fehlerhafter Primärnachweis
kann nicht durch ergänzende Evidenz überschrieben werden.

*Evidence is invalid for a missing gate, wrong scope, command/platform token
mismatch, wrong SHA, later commit, unresolved finding, or missing artefact hash.
Supplemental evidence cannot override failing primary evidence.*

## Completion

`Completed` ist nur zulässig, wenn jede anwendbare Anforderung bestanden, jede
N/A-Entscheidung erneut bestätigt, Review konvergiert, MergeAndSync ausgeführt
und PostMerge-Primary-Evidenz schema-2.0-gültig ist.

*Completed is allowed only when every applicable requirement passes, every N/A
decision is reconfirmed, review converges, MergeAndSync finishes, and schema-2.0
post-merge primary evidence validates.*

`autonomous-run-state.json` ist operativer lokaler Zustand, bleibt ungetrackt,
wird niemals gestagt und gehört nicht zum Delivery-Set. Seine Aktualisierung
durch den Phase-Wrapper nach Prozessrückkehr ist daher kein getrackter
Post-Closeout-Write. / *The autonomous run state is local operational state,
remains untracked, is never staged, and is excluded from the delivery set. A
phase-wrapper update after process return is therefore not a tracked
post-closeout write.*
