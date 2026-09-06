# Aufgaben: GSDB-Intensivprüfung / Tasks: Intensive GSDB Review

**Eingabe / Input**: Die akzeptierten Artefakte in
`specs/005-gsdb-intensive-review/`, der bindende Intake
`requirements/intakes/active/Lastenheft_GSDB-Spec-Kit-Intensivpruefung.md`
und der autonome Lauf `69674c80-911c-40ff-9a0e-004f7b13b832`.

**Branch / Branch**: `005-gsdb-intensive-review`
**Liefermodus / Delivery mode**: `MergeAndSync`
**Aufgabenstatus / Task status**: Alle Aufgaben sind für die spätere
Implementierungsphase offen; diese Tasks-Phase führt keine Aufgabe aus.

## Ausführungsvertrag / Execution Contract

- Die Aufgaben werden in der angegebenen Abhängigkeitsreihenfolge ausgeführt.
  `[P]` erlaubt nur die parallele Bearbeitung verschiedener Writer-Pfade nach
  dem gemeinsamen Vorgänger. Eine Aufgabe wird erst nach ihrem benannten
  Nachweis abgehakt. / Tasks run in the stated dependency order. `[P]` permits
  parallel work only on distinct writer paths after the shared predecessor. A
  task is checked only after its named evidence exists.
- Das Feature bewertet und dokumentiert. Es härtet weder `src/MicroCalc.Core/`
  noch `src/MicroCalc.Tui/`, ändert keine Produktfunktion und führt keine
  Human-only-Entscheidung aus. Formale Freigabe, rechtliche Freigabe,
  Risikoakzeptanz, Secret-Rotation, Providerfreigabe und Änderung der
  Branch-Protection bleiben `Open`, solange echte externe menschliche Evidenz
  fehlt. / The feature assesses and documents. It does not harden product code,
  change product behaviour, or perform Human-only decisions. Formal or legal
  approval, risk acceptance, secret rotation, provider approval, and branch
  protection changes remain `Open` without genuine external human evidence.
- NIST SSDF und CWE Top 25 sind immer `Applicable`. C# ist eine erlaubte MSL,
  ersetzt aber keine Prüfung sicherer APIs, Eingaben, Deserialisierung,
  Fehlerpfade, Datei-I/O, Abhängigkeiten oder nativer Grenzen. ASVS,
  Produkt-AI-SBOM und Produkt-Zero-Trust bleiben mit den akzeptierten Triggern
  `N/A`; SBOM, VEX-Entscheidung, SLSA/Provenance, OpenSSF, STRIDE/CIA/CAPEC,
  Delivery-Zero-Trust, SAMM, BSI C3A/C5, Regulatorik, Datenschutz und WCAG 2.2
  AA werden ausdrücklich geprüft. / NIST SSDF and CWE Top 25 always apply. C#
  is an allowed MSL but does not waive the listed secure-development reviews.
- Lesertexte sind Deutsch zuerst, danach vollständig Englisch, auf CEFR-B2-
  Niveau, text-first und ohne farb- oder layoutabhängige Bedeutung. Jede
  Abweichung wird als Befund, `N/A` mit Begründung und Trigger oder `Open` mit
  Owner, Follow-up und Trigger erfasst. / Reader-facing text is German first,
  then complete English, CEFR B2, text-first, and independent of colour or
  layout. Every exception is recorded as a finding, justified triggered `N/A`,
  or owned `Open` follow-up.
- Vor jedem `dotnet build` und `dotnet test` wird der Build-Zähler genau einmal
  erhöht. Vor jedem Commit und Push sind `Version`, `AssemblyVersion` und
  `FileVersion` in `Directory.Build.props` identisch als
  `1.5.<voraussichtliche Feature-Commit-Zahl einschließlich anstehendem Commit>.<erhöhter Build-Zähler>`.
  / Increment the build counter exactly once before every build and test; align
  all three version fields to the stated formula before every commit and push.
- Providerverweigerung, fehlender oder veralteter Check, fehlender Review,
  ungelöster Thread, anderer Head oder bloß grüner Jobname ohne Befehlsnachweis
  ist kein Pass. Ein bekannter kritischer CVE blockiert. / Refused, missing, or
  stale provider evidence, review or head mismatch is not a pass. A known
  critical CVE blocks delivery.
- Jeder Remote-Schritt ist eine eigene Aufgabe. Normaler Merge ist bevorzugt.
  `--admin` ist nur nach dem ausdrücklich beschriebenen formalen Trigger und
  niemals als Ersatz für ein materielles Gate zulässig. / Every remote action
  is a distinct task. Normal merge is preferred; admin bypass is formal-only.

## Geschlossene Liefermengen / Closed Delivery Sets

### Feature-Liefermenge / Feature Delivery Set

Nur die folgenden repository-relativen Pfade dürfen in der Feature-Lieferung
vorkommen. Der tatsächliche Satz ist vor jedem Commit und Push als exakte
Teilmenge ohne Wildcards zu übergeben. `src/`, `tests/`, GSDB-Baselinequellen,
Constitutions, Solution-/Projektdateien und `_site/` bleiben unverändert; nur
`Directory.Build.props` und der exakte Laufzustands-Ausschluss in `.gitignore`
sind benannte Ausnahmen. / Only the following paths may occur in feature
delivery. Pass the exact actual subset without wildcards before every commit
and push.

```text
.gitignore
Directory.Build.props
.github/workflows/ci.yml
specs/intake-authoring-receipts/rename-microcalc-tinycalc.json
specs/005-gsdb-intensive-review/spec.md
specs/005-gsdb-intensive-review/plan.md
specs/005-gsdb-intensive-review/research.md
specs/005-gsdb-intensive-review/data-model.md
specs/005-gsdb-intensive-review/quickstart.md
specs/005-gsdb-intensive-review/tasks.md
specs/005-gsdb-intensive-review/autonomous-run-evidence.md
specs/005-gsdb-intensive-review/checklists/requirements.md
specs/005-gsdb-intensive-review/checklists/plan-review.md
specs/005-gsdb-intensive-review/checklists/analyze-remediation.md
specs/005-gsdb-intensive-review/checklists/script-parity.md
specs/005-gsdb-intensive-review/contracts/evidence-matrix.schema.json
specs/005-gsdb-intensive-review/contracts/autonomous-run-gate-requirements.json
docs/security/gsdb-intensive-review/source-inventory.md
docs/security/gsdb-intensive-review/evidence-matrix.json
docs/security/gsdb-intensive-review/evidence-matrix.md
docs/security/gsdb-intensive-review/preset-mapping.md
docs/security/gsdb-intensive-review/open-findings.md
docs/security/README.md
docs/security/threat-model.md
docs/security/arc42-security.md
docs/security/security-checklist.md
docs/security/dependency-audit.md
docs/security/security-quality-scenarios.md
docs/security/asvs-verification.md
docs/security/supply-chain-evidence.md
docs/security/zero-trust-applicability.md
docs/security/samm-assessment.md
docs/security/regulatory-applicability.md
docs/security/cloud-autonomy-applicability.md
docs/security/cloud-compliance-assurance.md
docs/accessibility/gsdb-intensive-review.md
docs/PR_TEXT_GSDB_INTENSIVE_REVIEW.md
docs/documentation-impact/gsdb-intensive-review.json
docs/project-statistics.md
scripts/validate-gsdb-intensive-review.ps1
scripts/validate-gsdb-intensive-review.sh
scripts/tests/gsdb-intensive-review/valid-assessment.json
scripts/tests/gsdb-intensive-review/test-validate-gsdb-intensive-review.ps1
scripts/tests/gsdb-intensive-review/test-validate-gsdb-intensive-review.sh
docs/man/validate-gsdb-intensive-review.1
```

Die drei Testdateien erzeugen alle negativen Varianten ausschließlich in einem
temporären Verzeichnis. Der Analyze-Bericht
`specs/005-gsdb-intensive-review/checklists/analyze-remediation.md` ist nach
erneuter Plan-/Tasks-Prüfung Bestandteil der geschlossenen Menge. Gleiches gilt
für die ausdrücklich genehmigte abgeleitete CI-Hash-Korrektur im vorhandenen
Intake-Autorisierungsbeleg; jeder weitere neue Pfad blockiert. / The three test
files generate all negative variants only in a temporary directory. The
Analyze report and the explicitly approved derived CI-hash correction in the
existing intake-authoring receipt are part of the closed set; any further path
blocks. The operational
`autonomous-run-state.json` remains local, is covered by the exact tracked
`.gitignore` entry before staging, and is never committed.

### Kausale Closeout-Liefermenge / Causal Closeout Delivery Set

Der einzige Closeout-Branch heißt
`codex/005-gsdb-intensive-review-closeout`; sein einziger Commit darf nur die
folgende exakte Teilmenge enthalten. / The only closeout branch has the stated
name and its single commit may contain only an exact subset of these paths.

```text
requirements/intakes/active/Lastenheft_GSDB-Spec-Kit-Intensivpruefung.md
requirements/intakes/active/Lastenheft_GSDB-Spec-Kit-Intensivpruefung.005-gsdb-intensive-review.md
requirements/intakes/series/tinycalc-delivery/manifest.json
requirements/intakes/series/tinycalc-delivery/operation.json
requirements/intakes/series/tinycalc-delivery/order.md
requirements/intakes/series/tinycalc-delivery/receipt.json
requirements/intakes/series/tinycalc-delivery/intake-review-request.json
requirements/intakes/series/tinycalc-delivery/intake-review-result.json
requirements/intakes/series/tinycalc-delivery/intake-review-report.md
specs/005-gsdb-intensive-review/autonomous-run-evidence.md
specs/005-gsdb-intensive-review/evidence/accepted-premerge.json
specs/005-gsdb-intensive-review/evidence/postmerge.json
```

Der erste Pfad ist die Löschung, der zweite der branchgestempelte Ersatz. Die
drei Review-Dateien werden nur gemeinsam in die tatsächliche Teilmenge
aufgenommen. Kein Nachfolge-Intake, Feature, Campaign-Artefakt oder Runtime-Log
wird getrackt. / The first path is deleted and the second is its branch-stamped
replacement. The three review files enter the actual subset only together.

## Phase 1: Vorimplementierungsnachweis und Scope-Freeze / Pre-implementation Evidence and Scope Freeze

- [x] T001 Betriebssystem mit `uname -s`, `pwsh`, .NET SDK, Git, `gh`, Bash,
  `jq`, DocFX und lynx prüfen und den beobachteten Stand in
  `specs/005-gsdb-intensive-review/autonomous-run-evidence.md` erfassen. /
  Detect the OS and required existing tools and record the observed versions.
  **Abhängigkeit / Dependency**: keine / none. **Nachweis / Evidence**:
  `specs/005-gsdb-intensive-review/autonomous-run-evidence.md`, Gate
  `GSDB-GATE-001`; fehlende Pflichtwerkzeuge blockieren, neue Werkzeuge werden
  nicht still eingeführt.
- [x] T002 Den aktiven Zustand mit
  `.specify/presets/autonomous-run-governance/scripts/validate-autonomous-run-state.ps1`,
  `requirements/intakes/series/tinycalc-delivery/intake-review-result.json` mit
  `.specify/presets/intake-review-governance/scripts/validate-intake-review-result.ps1`
  und `requirements/intakes/series/tinycalc-delivery/manifest.json` mit
  `.specify/presets/intake-sequencing-governance/scripts/validate-intake-series-manifest.ps1`
  prüfen. / Validate run, review, and series state. **Abhängigkeit**: T001.
  **Nachweis**: `specs/005-gsdb-intensive-review/autonomous-run-evidence.md`,
  `GSDB-GATE-001`; Branch, Run-ID, Ready-Review, ausgewählter
  `declaredEligible`-GSDB-Root und unselektierte andere Roots sind sichtbar.
- [x] T003 Alle abgeschlossenen Phasenergebnisse `specify`, `clarify`,
  `requirements-checklist`, `plan`, `plan-review`, `tasks` und `analyze` mit
  `.specify/presets/autonomous-run-governance/scripts/validate-autonomous-phase-result.ps1`
  gegen ihre Dateien unter
  `.specify/runtime/autonomous-routing/69674c80-911c-40ff-9a0e-004f7b13b832/`
  prüfen; `analyze` belegt `0/0` ausgeführte Implementierungsaufgaben,
  `implement` bleibt bis zu seinem echten Abschluss `Pending` oder `Running`. /
  Validate completed schema-1.0 phase results without treating phase completion
  as run completion; Analyze records zero executed implementation tasks.
  **Abhängigkeit**: T002. **Nachweis**:
  `specs/005-gsdb-intensive-review/autonomous-run-evidence.md`,
  `GSDB-GATE-002`.
- [x] T004 Branch/Head, Checkpoint, akzeptierte Hashes, Stop-Status,
  `MergeAndSync`-Autorität, Intake-Grenze und unveränderte User-Worktree-Pfade
  aus `specs/005-gsdb-intensive-review/autonomous-run-state.json` und
  `requirements/intakes/active/Lastenheft_GSDB-Spec-Kit-Intensivpruefung.md`
  revalidieren. Zusätzlich mit `shasum -a 256` beweisen, dass die aktuellen
  Analyse-Remediation-Hashes von Spec, Plan, Tasks und Gate-Vertrag exakt der
  Tabelle in `specs/005-gsdb-intensive-review/checklists/analyze-remediation.md`
  entsprechen; das validierte `analyze.result.json` bindet den Bericht selbst. /
  Revalidate authority, accepted entry hashes, and the exact Analyze-remediated
  hashes before any implementation write. **Abhängigkeit**: T003. **Nachweis**:
  `specs/005-gsdb-intensive-review/autonomous-run-evidence.md`,
  `GSDB-GATE-001`; Drift stoppt fail-closed.
- [x] T005 Die oben geschlossene Feature-Liefermenge und alle read-only
  Prüfpfade einzeln in `specs/005-gsdb-intensive-review/autonomous-run-evidence.md`
  festschreiben; insbesondere `src/`, `tests/`, `constitution.md`,
  `.specify/memory/constitution.md`, `docs/secure-development/`,
  `MicroCalc.sln`, Projektdateien und andere Workflows als unveränderlich
  markieren. Den exakten Pfad
  `specs/005-gsdb-intensive-review/autonomous-run-state.json` in `.gitignore`
  ausschließen und mit `git check-ignore -v` belegen; nur die Ignore-Regel,
  niemals der Laufzustand, wird getrackt. /
  Freeze exact writable and inspected paths and prove the operational run state
  is locally excluded from Git. **Abhängigkeit**:
  T004. **Nachweis**: `specs/005-gsdb-intensive-review/autonomous-run-evidence.md`,
  `GSDB-GATE-027`.
- [x] T006 Das vollständige kontrollierte GSDB-Inventar aus
  `docs/secure-development/baseline-manifest.json` mit Richtlinie,
  Sammelband, allen zwölf Dateien unter `docs/secure-development/checklisten/`,
  allen 15 Dateien unter `docs/secure-development/mitgeltende-dokumente/`,
  `docs/secure-development/Lernpfad_Sichere-Entwicklung_Lehrjahr-1-bis-3.md`,
  den vier verwalteten Referenzdateien und PDF/Prüfsumme mit Version, Datum,
  Scope und normalisiertem Hash erfassen. / Inventory every manifest-controlled
  source. **Abhängigkeit**: T005. **Nachweis**:
  `docs/security/gsdb-intensive-review/source-inventory.md`,
  `GSDB-GATE-003`.
- [x] T007 Beide getrennten Quellen `constitution.md` und
  `.specify/memory/constitution.md`, die Registry-Zeile `RiderProjects/TinyCalc`,
  die relevanten `.github/workflows/*.yml`, vorhandenen Validatoren,
  Intake-/Serienbelege und `docs/security/secure-development/2026-09-05-rl-se-self-assessment/`
  mit aktuellen Hashes, Locators und Freshness inventarisieren. / Inventory
  governance, workflow, validator, intake, and prior-evidence sources.
  **Abhängigkeit**: T006. **Nachweis**:
  `docs/security/gsdb-intensive-review/source-inventory.md`,
  `GSDB-GATE-003` und `GSDB-GATE-007`.
- [x] T008 Alle 13 installierten Presets inventarisieren: die acht
  Standard-Presets `security-governance`, `architecture-governance`,
  `isaqb-architecture-governance`, `a11y-governance`,
  `cross-platform-governance`, `agent-parity-governance`,
  `autonomous-run-governance`, `parallel-autonomous-run-governance` sowie
  `secure-development-assurance-governance`, `model-routing-governance`,
  `intake-authoring-governance`, `intake-review-governance` und
  `intake-sequencing-governance`; dabei
  `pwsh -NoProfile -File scripts/install-spec-kit-governance-presets.ps1 -CheckOnly`
  und `bash scripts/install-spec-kit-governance-presets.sh --check-only`
  read-only ausführen. / Inventory all 13 installed presets with version,
  priority or `NotInStandardMatrix`, and source hash, and validate the exact
  standard matrix through both existing check-only paths. **Abhängigkeit**:
  T007. **Nachweis**: `docs/security/gsdb-intensive-review/source-inventory.md`
  und `docs/security/gsdb-intensive-review/preset-mapping.md`,
  `GSDB-GATE-007`.
- [x] T009 Die 33 eindeutigen Gates aus
  `specs/005-gsdb-intensive-review/contracts/autonomous-run-gate-requirements.json`
  vor Implementierung mit PowerShell `ConvertFrom-Json` und `jq` syntaktisch,
  auf unbekannte Felder, doppelte IDs, 27 `Applicable` und sechs begründete
  `N/A` prüfen
  und jede spätere Evidenzstelle in
  `specs/005-gsdb-intensive-review/autonomous-run-evidence.md` vorab markieren.
  / Freeze the complete gate inventory and evidence destinations.
  **Abhängigkeit**: T008. **Nachweis**:
  `specs/005-gsdb-intensive-review/autonomous-run-evidence.md`, Gates
  `GSDB-GATE-001` bis `GSDB-GATE-033`.
- [x] T010 Die Grenzen „keine Produkt-Härtung“, „Human-only bleibt Open“,
  „keine konkreten Modellnamen“, „keine parallele Kampagne“ und
  „kein Nachfolgefeature“ gegen `specs/005-gsdb-intensive-review/spec.md`,
  `plan.md`, `research.md`, `data-model.md`, `quickstart.md` und beide Verträge
  prüfen. / Confirm all non-goals before RED. **Abhängigkeit**: T009.
  **Nachweis**: `specs/005-gsdb-intensive-review/autonomous-run-evidence.md`,
  `GSDB-GATE-033`.

## Phase 2: RED, kleinstes GREEN und Negativ-Fixtures / RED, Minimal GREEN, and Negative Fixtures

**Ziel / Goal**: Der read-only Vertrag scheitert zuerst beobachtbar aus dem
fachlichen Grund, akzeptiert dann nur den kleinsten gültigen Helper und erhält
erst danach die vollständige Negativsuite. / The read-only contract first fails
for the intended reason, then accepts the smallest valid helper, and only then
receives the complete negative suite.

- [x] T011 [US1] In
  `scripts/tests/gsdb-intensive-review/test-validate-gsdb-intensive-review.ps1`
  einen kompilierbaren/ausführbaren Vertragstest für einen frischen fehlenden
  Temp-Pfad schreiben, der `GSDB001` und einen Nichtnull-Exit erwartet, und ihn
  vor Implementierung ausführen. / Write and run the first PowerShell RED test.
  **Abhängigkeit**: T010. **Erwartetes Rot / Expected RED**: Die geforderte
  `GSDB001`-Semantik ist noch nicht implementiert. **Nachweis**:
  `specs/005-gsdb-intensive-review/autonomous-run-evidence.md`,
  `GSDB-GATE-005`.
- [x] T012 [US1] In
  `scripts/tests/gsdb-intensive-review/test-validate-gsdb-intensive-review.sh`
  denselben fehlenden-Pfad-Vertrag für Bash schreiben und vor Wrapper-
  Implementierung ausführen. / Write and run the Bash RED contract.
  **Abhängigkeit**: T011. **Erwartetes Rot**: fehlende identische
  Fehlerklasse/Exitcode-Semantik. **Nachweis**:
  `specs/005-gsdb-intensive-review/autonomous-run-evidence.md`,
  `GSDB-GATE-005`.
- [x] T013 [US1] `scripts/validate-gsdb-intensive-review.ps1` minimal mit
  `Set-StrictMode -Version Latest`, sicherer Parameterprüfung, bilingualer
  Comment-based Help und der Funktion `Test-GsdbIntensiveReview` implementieren,
  sodass nur fehlende Datei, UTF-8/JSON-Fehler und Schemafehler deterministisch
  `GSDB001` liefern. / Implement the smallest PowerShell GREEN.
  **Abhängigkeit**: T011-T012. **Nachweis**: T011 besteht; keine dynamische
  Ausführung oder interne/secret-haltige Fehlerausgabe;
  `scripts/validate-gsdb-intensive-review.ps1`, `GSDB-GATE-005`.
- [x] T014 [US1] `scripts/validate-gsdb-intensive-review.sh` als dünnen
  Bash-3.x-kompatiblen Wrapper mit `set -euo pipefail`, gequoteten Variablen,
  sicherem End-of-options-Verhalten, `--help` und Delegation an
  `pwsh -NoProfile` implementieren. / Implement the minimal strict Bash GREEN.
  **Abhängigkeit**: T013. **Nachweis**: T012 besteht und PowerShell/Bash liefern
  denselben Status, Fehlertext und Exitcode; `GSDB-GATE-005` und
  `GSDB-GATE-021` in `specs/005-gsdb-intensive-review/autonomous-run-evidence.md`.
- [x] T015 [US1] In
  `scripts/tests/gsdb-intensive-review/valid-assessment.json` nur den kleinsten
  gültigen Source-/Row-Helper-Vertrag anlegen und ausdrücklich als
  `fixtureMode`, nicht als vollständige Produktionsmatrix, kennzeichnen. /
  Create the smallest valid helper fixture. **Abhängigkeit**: T014.
  **Nachweis**: beide Testeinstiege akzeptieren nur den Helper-Modus;
  `GSDB-GATE-005`.
- [x] T016 [US1] Die Tests in beiden Dateien unter
  `scripts/tests/gsdb-intensive-review/` um zur Laufzeit erzeugte negative
  Temp-Fixtures für `GSDB002` bis `GSDB010` erweitern und vor semantischer
  Implementierung ausführen. / Add and run the full negative fixture suite
  after minimal GREEN. **Abhängigkeit**: T015. **Erwartetes Rot**: mindestens
  eine noch fehlende fachliche Klasse schlägt den Test fehl. **Nachweis**:
  `specs/005-gsdb-intensive-review/autonomous-run-evidence.md`,
  `GSDB-GATE-005`.
- [x] T017 [US1] `scripts/validate-gsdb-intensive-review.ps1` um sichere
  Normalisierung, Pfadgrenzen, reale Quellenbindung, exakte ID-Mengen,
  Statusachsen, Pflichtfelder, Evidenz-Locators, Human-only-Grenzen,
  Findings-Verknüpfung und abgeleitete Summary ergänzen. / Implement only the
  semantics needed for `GSDB002`-`GSDB010`. **Abhängigkeit**: T016.
  **Nachweis**: alle PowerShell-Negativ-Fixtures scheitern ausschließlich mit
  ihrer erwarteten Klasse; `GSDB-GATE-005`, `GSDB-GATE-006`.
- [x] T018 [US1] Die Bash-Fixtures gegen dieselbe Engine laufen lassen und
  Parameter, stdout, stderr, Fehlerklassen und Exitcodes zeilenweise mit dem
  PowerShell-Einstieg vergleichen. / Prove Bash parity for every fixture.
  **Abhängigkeit**: T017. **Nachweis**:
  `specs/005-gsdb-intensive-review/checklists/script-parity.md`,
  `GSDB-GATE-021`.
- [x] T019 [US1] `docs/man/validate-gsdb-intensive-review.1` mit Name,
  Synopsis, Optionen, read-only-Grenze, Fehlerklassen, Exitcodes, Beispielen
  und bilingualem Verweis erstellen; die PowerShell-Hilfe und Bash-`--help`
  dagegen prüfen. / Add and verify the Unix man page and both help surfaces.
  **Abhängigkeit**: T018. **Nachweis**:
  `specs/005-gsdb-intensive-review/checklists/script-parity.md`,
  `GSDB-GATE-021`.
- [x] T020 [US1] `-WhatIf`/Dry-run in
  `specs/005-gsdb-intensive-review/checklists/script-parity.md` begründet als
  `N/A` festhalten, weil beide Einstiege ausschließlich lesen; jede spätere
  Schreibfunktion ist der Trigger. / Record the accepted dry-run disposition.
  **Abhängigkeit**: T019. **Nachweis**: `GSDB-GATE-021`.
- [x] T021 [US1] Validator und Tests minimal refactoren, nur didaktisch
  wertvolle Warum-Kommentare DE-first/EN-second ergänzen und anschließend
  beide Testdateien, `bash -n scripts/validate-gsdb-intensive-review.sh` und
  `scripts/invoke-psscriptanalyzer.ps1` erneut grün ausführen. / Refactor and
  rerun the complete validator regression. **Abhängigkeit**: T020.
  **Nachweis**: `specs/005-gsdb-intensive-review/autonomous-run-evidence.md`,
  Gates `GSDB-GATE-005`, `GSDB-GATE-021`, `GSDB-GATE-026`.

## Phase 3: User Story 1 – Vollständige Abdeckung / Complete Coverage (P1, MVP)

**Unabhängiger Test / Independent Test**: Beide Einstiegspunkte beweisen
12/12 Familien, exakt 157/157 kanonische IDs, 157 inhaltsgleiche
Sammelbandblöcke, vollständige kontrollierte Quellen und 13/13 Presets.

- [x] T022 [US1] Das bereits akzeptierte Schema
  `specs/005-gsdb-intensive-review/contracts/evidence-matrix.schema.json` in
  `scripts/validate-gsdb-intensive-review.ps1` einbinden und unknown properties,
  UTF-8 ohne BOM, LF, ISO-Daten, sichere relative `/`-Pfade und kleingeschriebene
  64-stellige Hashes fail-closed prüfen. / Bind the accepted schema and data
  conventions. **Abhängigkeit**: T021. **Nachweis**:
  `specs/005-gsdb-intensive-review/autonomous-run-evidence.md`,
  `GSDB-GATE-005` und `GSDB-GATE-006`.
- [x] T023 [US1] Aus den exakten Überschriften der zwölf Dateien
  `docs/secure-development/checklisten/CL_01_Standards-Anwendbarkeit.md` bis
  `docs/secure-development/checklisten/CL_12_Agentische-KI-Sandbox.md` die
  Familienzählung `12/13/15/10/13/11/12/13/17/17/12/12 = 157` ableiten. /
  Derive the exact canonical set rather than trusting the manifest count.
  **Abhängigkeit**: T022. **Nachweis**:
  `docs/security/gsdb-intensive-review/source-inventory.md` und
  `specs/005-gsdb-intensive-review/autonomous-run-evidence.md`,
  `GSDB-GATE-003`.
- [x] T024 [US1] Jeden der 157 kanonischen Blöcke mit
  `docs/secure-development/Checklistensammelband_Sichere-Entwicklung.md`
  vergleichen; gleiche Gesamt-/Unique-Zählung und Inhaltsparität verlangen,
  jede Abweichung als Finding behandeln. / Prove full compendium identity and
  content parity. **Abhängigkeit**: T023. **Nachweis**:
  `docs/security/gsdb-intensive-review/source-inventory.md`,
  `GSDB-GATE-004`.
- [x] T025 [US1] `docs/security/gsdb-intensive-review/evidence-matrix.json`
  mit Baseline-Bindung und allen SourceBindings aus T006-T008 initialisieren;
  geplante oder nicht verfügbare Evidenz darf kein `Fulfilled` stützen. /
  Initialize the production assessment with complete source bindings.
  **Abhängigkeit**: T024. **Nachweis**: Matrix-Schema und `GSDB-GATE-003`.
- [x] T026 [US1] Genau eine `checklistRows`-Zeile für jede der 157 IDs in
  `docs/security/gsdb-intensive-review/evidence-matrix.json` anlegen, mit allen
  Feldern aus FR-005 und ohne Sammelzeile oder Duplikat. / Populate the exact
  checklist-row set. **Abhängigkeit**: T025. **Nachweis**:
  `scripts/validate-gsdb-intensive-review.ps1 -Action Validate`,
  `GSDB-GATE-006`.
- [x] T027 [US1] Alle Pflichten aus
  `docs/secure-development/Richtlinie_Sichere-Entwicklung.md` und den 15
  Dateien unter `docs/secure-development/mitgeltende-dokumente/`, die nicht
  durch eine CL-ID abgedeckt sind, als stabile `GSDB-DUTY-NNN`-Zeilen in
  `docs/security/gsdb-intensive-review/evidence-matrix.json` erfassen. /
  Capture every external duty outside checklist coverage. **Abhängigkeit**:
  T026. **Nachweis**: `GSDB-GATE-007`.
- [x] T028 [US1] Die 13 Preset-Zeilen aus T008 mit Version, Priorität oder
  `NotInStandardMatrix`, CL-/Gate-Zuordnung, Scope, Evidenz, Owner, Reviewer,
  Follow-up, Trigger und Restrisiko in
  `docs/security/gsdb-intensive-review/evidence-matrix.json` eintragen. /
  Populate all preset assessments. **Abhängigkeit**: T027. **Nachweis**:
  13/13 sowie 8/8 Standardmatrix, `GSDB-GATE-007`.
- [x] T029 [US1] `ValidateSources`, `ValidateCompendium`, `ValidateMappings`
  und `Validate` über `scripts/validate-gsdb-intensive-review.ps1` sowie
  `validate` über `scripts/validate-gsdb-intensive-review.sh` ausführen. /
  Execute full production GREEN through both entrypoints. **Abhängigkeit**:
  T028. **Nachweis**: `specs/005-gsdb-intensive-review/autonomous-run-evidence.md`
  mit Befehlen, Exitcodes, UTC-Zeit und Matrix-Hash; Gates
  `GSDB-GATE-003` bis `GSDB-GATE-007`.
- [x] T030 [US1] US1 unabhängig gegen FR-001 bis FR-004 und SC-001 prüfen;
  fehlende, doppelte, unbekannte oder falsch zugeordnete IDs, Quellen oder
  Blöcke blockieren. / Run the complete-coverage checkpoint. **Abhängigkeit**:
  T029. **Nachweis**: `docs/security/gsdb-intensive-review/evidence-matrix.json`
  und `specs/005-gsdb-intensive-review/autonomous-run-evidence.md`, Gates
  `GSDB-GATE-003`-`007`.

## Phase 4: User Story 2 – Ehrliche Entscheidungen / Honest Decisions (P1)

**Unabhängiger Test / Independent Test**: Je ein `Applicable`, `N/A`, `Open`,
nicht erfüllter und Human-only-Punkt führt von kanonischer Quelle über beide
Statusachsen zu aktueller Evidenz oder einem vollständigen Befund.

- [x] T031 [US2] Alle 157 CL-Zeilen und alle externen Pflichten in
  `docs/security/gsdb-intensive-review/evidence-matrix.json` fachlich bewerten;
  `Open` nur für ungeklärte Anwendbarkeit, `N/A` nur mit `Not Assessed`, und
  fehlende Erfüllungsevidenz bei bekanntem Scope als `Applicable` plus
  nicht-erfüllter Status und Finding behandeln. / Apply the two-axis status
  semantics to every row. **Abhängigkeit**: T030. **Nachweis**:
  `GSDB-GATE-006`.
- [x] T032 [US2] Human-only-Zeilen in
  `docs/security/gsdb-intensive-review/evidence-matrix.json` auf
  `humanDecisionEvidence: NotProvided` und einen nicht-erfüllten Status
  begrenzen; fehlende Fachreviewer mit Owner, Follow-up, Termin, Trigger und
  Restrisiko offen halten. / Enforce the Human-only boundary. **Abhängigkeit**:
  T031. **Nachweis**: null unbelegte Freigaben, `GSDB-GATE-006`.
- [x] T033 [US2] NIST SSDF und CWE Top 25 gegen Lifecycle, Formeleingaben,
  Fehler, Datei-I/O, Abhängigkeiten und Delivery prüfen und die konkrete
  Zuordnung in `docs/security/security-checklist.md`,
  `docs/security/threat-model.md` und
  `docs/security/gsdb-intensive-review/evidence-matrix.json` dokumentieren. /
  Map both always-applicable standards without blanket fulfilment claims.
  **Abhängigkeit**: T032. **Nachweis**: `GSDB-GATE-008`.
- [x] T034 [US2] C#-MSL-Status, sichere APIs, Eingaben, Deserialisierung,
  Fehlerausgabe, Pfade, Datei-I/O, native Grenzen und Abhängigkeiten read-only
  gegen `src/MicroCalc.Core/`, `src/MicroCalc.Tui/`, `tests/` und Projektdateien
  prüfen; Ergebnisse in `docs/security/security-checklist.md` und der Matrix
  erfassen. / Review secure coding without changing product code.
  **Abhängigkeit**: T033. **Nachweis**: `GSDB-GATE-009`.
- [x] T035 [P] [US2] Kontext-, Baustein-, Laufzeit- und Deployment-Sicht in
  `docs/architecture/maintenance-tui.md` und
  `docs/architecture/terminalgui-migration.md` read-only gegen vier
  Trust-Boundary-Gruppen und die Prinzipien Defense in Depth, Least Privilege,
  Fail-Safe Defaults, Angriffsflächenreduktion, Separation of Concerns, sichere
  Konfiguration und Supply-Chain-Sicherheit prüfen; aktuelle Tatsachen in
  `docs/security/arc42-security.md` fortschreiben. / Reassess architecture
  views and secure-architecture principles. **Abhängigkeit**: T034.
  **Nachweis**: `docs/security/arc42-security.md`, `GSDB-GATE-010`; kein neuer
  ADR/S-ADR, Trigger bleibt eine autorisierte Architekturentscheidung.
- [x] T036 [P] [US2] STRIDE/CIA und relevante CAPEC-Patterns für Datei/Formel,
  Managed/Native, Repository/Build und Agent/Provider in
  `docs/security/threat-model.md` sowie messbare Szenarien in
  `docs/security/security-quality-scenarios.md` aktualisieren. / Reassess the
  four threat-boundary groups. **Abhängigkeit**: T034. **Nachweis**:
  `GSDB-GATE-010`; keine Mitigation wird implementiert.
- [x] T037 [P] [US2] OWASP ASVS in `docs/security/asvs-verification.md` als
  `N/A` für die unveränderte lokale TUI mit Web/API/HTTP/Auth-Trigger belegen;
  keine ASVS-Stufe erfinden. / Record the accepted product ASVS disposition.
  **Abhängigkeit**: T034. **Nachweis**: `GSDB-GATE-011`.
- [x] T038 [P] [US2] Produkt-AI-SBOM in
  `docs/security/supply-chain-evidence.md` als `N/A` für reine
  Entwicklungswerkzeug-Nutzung mit Trigger für Modell, Dataset,
  Inferenzdienst oder AI-Runtime dokumentieren. / Record AI-SBOM applicability.
  **Abhängigkeit**: T034. **Nachweis**: `GSDB-GATE-014`.
- [x] T039 [P] [US2] Produkt-Zero-Trust als `N/A` und Delivery-Zero-Trust für
  Repository, CI, Identität und Provider als `Applicable` in
  `docs/security/zero-trust-applicability.md` getrennt prüfen. / Separate
  product and delivery-environment Zero Trust. **Abhängigkeit**: T034.
  **Nachweis**: `GSDB-GATE-015` und `GSDB-GATE-016`.
- [x] T040 [P] [US2] BSI-C3A-Cloud-Autonomie für Repository/CI/Artefaktprovider
  in `docs/security/cloud-autonomy-applicability.md` mit Scope, Quelle, Datum,
  Owner, Reviewer, Trigger und Restrisiko bewerten. / Create the current C3A
  applicability record. **Abhängigkeit**: T034. **Nachweis**:
  `GSDB-GATE-017`.
- [x] T041 [P] [US2] BSI-C5-Cloud-Assurance getrennt in
  `docs/security/cloud-compliance-assurance.md` mit denselben Pflichtfeldern
  bewerten, ohne Providerfreigabe oder Zertifizierung zu behaupten. / Create
  the separate current C5 assurance record. **Abhängigkeit**: T034.
  **Nachweis**: `GSDB-GATE-017`.
- [x] T042 [P] [US2] NIS2, CRA, EU AI Act, DORA und Datenschutz jeweils
  einzeln mit aktueller Primärquelle, Prüftag, Scope, Owner, Reviewer, Trigger
  und Restrisiko in `docs/security/regulatory-applicability.md` bewerten;
  rechtliche Freigabe bleibt Human-only. / Create separate evidence-based
  regulatory decisions. **Abhängigkeit**: T034. **Nachweis**:
  `GSDB-GATE-018`.
- [x] T043 [P] [US2] OWASP SAMM für das langlebige Projekt in
  `docs/security/samm-assessment.md` aktuell bewerten und Folgeaktionen nur als
  separaten, nicht automatisch gestarteten Auftrag dokumentieren. / Reassess
  SAMM maturity and follow-up. **Abhängigkeit**: T034. **Nachweis**:
  `GSDB-GATE-018`.
- [x] T044 [US2] T035-T043 zusammenführen, Widersprüche und veraltete Evidenz
  in `docs/security/gsdb-intensive-review/evidence-matrix.json` als stabile
  Findings verlinken und vorhandene Security-Dateien nur bei aktueller neuer
  Tatsache ändern. / Integrate architecture, security, and regulatory results.
  **Abhängigkeit**: T035-T043. **Nachweis**: `GSDB-GATE-008`-`018`.
- [x] T045 [US2] Feature-004-Evidenz unter
  `docs/security/secure-development/2026-09-05-rl-se-self-assessment/` auf Hash,
  Datum, Scope, Locator und Widerspruch prüfen; Wiederverwendung oder Ablehnung
  jeder relevanten Aussage in der Feature-005-Matrix kennzeichnen. / Revalidate
  prior evidence rather than copying it. **Abhängigkeit**: T044. **Nachweis**:
  `GSDB-GATE-007`.
- [x] T046 [US2] Alle Lücken und Konflikte als sortierte
  `GSDB-FINDING-NNN`-Objekte mit Schweregrad, Quellen, zweisprachiger
  Beobachtung, Owner, Reviewer, Folgearbeit, Trigger, Restrisiko,
  Delivery-Impact und Status in
  `docs/security/gsdb-intensive-review/evidence-matrix.json` abschließen. /
  Complete the machine-readable finding set. **Abhängigkeit**: T045.
  **Nachweis**: `GSDB-GATE-006`, `GSDB-GATE-009`.
- [x] T047 [US2] Alle formalen, rechtlichen, Provider-, Risiko- und
  Zertifizierungsentscheidungen in der Matrix und in
  `docs/security/gsdb-intensive-review/open-findings.md` als Human-only `Open`
  halten; kein offenes Produkt-Hardening ausführen. / Preserve honest open
  human boundaries and assessment-only scope. **Abhängigkeit**: T046.
  **Nachweis**: SC-002/SC-003 und `GSDB-GATE-006`.

## Phase 5: User Story 3 – Verständliche Nacharbeit / Understandable Follow-up (P2)

**Unabhängiger Test / Independent Test**: Für jeden Befund sind Status, Owner,
Abhängigkeit, Evidenz und nächster Schritt in beiden Sprachen ohne Farbe oder
grafische Position auffindbar.

- [x] T048 [P] [US3] `docs/security/gsdb-intensive-review/source-inventory.md`
  als vollständige DE-first/EN-second CEFR-B2-Lesesicht der Quellenbindung mit
  erklärten Fachbegriffen und linearen Tabellen fertigstellen. / Complete the
  accessible source-inventory view. **Abhängigkeit**: T047. **Nachweis**:
  `GSDB-GATE-019`.
- [x] T049 [P] [US3] Aus
  `docs/security/gsdb-intensive-review/evidence-matrix.json` die vollständige
  bilinguale Lesesicht
  `docs/security/gsdb-intensive-review/evidence-matrix.md` mit 157 Zeilen,
  externen Pflichten, Summary, Statusachsen und Human-only-Grenze erzeugen. /
  Produce the complete human-readable matrix. **Abhängigkeit**: T047.
  **Nachweis**: `GSDB-GATE-006`, `GSDB-GATE-019`.
- [x] T050 [P] [US3] `docs/security/gsdb-intensive-review/preset-mapping.md`
  mit allen 13 Presets, Versionen, Prioritäten, 8er-Standardmatrix,
  CL-/Gate-Mapping und klassifizierter alter Sechs-/Siebener-Drift erstellen. /
  Complete the preset mapping. **Abhängigkeit**: T047. **Nachweis**:
  `GSDB-GATE-007`, `GSDB-GATE-019`.
- [x] T051 [P] [US3] `docs/security/gsdb-intensive-review/open-findings.md`
  nach Schweregrad und Abhängigkeit ordnen und für jeden Befund beide Sprachen,
  Owner, Reviewer, erwarteten Nachweis, Termin, Trigger und Restrisiko nennen. /
  Produce actionable findings without performing hardening. **Abhängigkeit**:
  T047. **Nachweis**: SC-004/SC-005 und `GSDB-GATE-019`.
- [x] T052 [US3] Den Leserpfad in `docs/security/README.md` von der
  Security-Übersicht zur GSDB-Matrix, zum Quelleninventar, Preset-Mapping und
  offenen Nacharbeit ergänzen; aussagekräftige relative Linktexte verwenden. /
  Add the required security reader path. **Abhängigkeit**: T048-T051.
  **Nachweis**: `docs/security/README.md`, `GSDB-GATE-025`.
- [x] T053 [US3] `docs/accessibility/gsdb-intensive-review.md` mit manueller
  Prüfung von DE-first/EN-second, CEFR B2, echten Umlauten und `ß`, Überschriften,
  Lesereihenfolge, Linktexten, Sprachparität, WCAG 2.2 AA 1.3.1/1.3.2/1.4.1/
  2.4.6 sowie den Grenzen von Textreview und Zertifizierung erstellen. /
  Record the Markdown accessibility proof. **Abhängigkeit**: T052.
  **Nachweis**: `GSDB-GATE-019`.
- [x] T054 [US3] Documentation Impact `UpdateRequired`, Zielgruppen,
  kanonische Quelle/Owner, Reader Path, Navigation, Dokumentklasse,
  Sprachpartner, macOS-/CI-Plattformbeleg, öffentliche Verteilung nach Review,
  Home-Sync-`N/A` und Trigger in
  `docs/documentation-impact/gsdb-intensive-review.json` erfassen. / Create the
  complete documentation-impact record. **Abhängigkeit**: T053.
  **Nachweis**: `GSDB-GATE-025`.
- [x] T055 [US3] Alle Leserartefakte aus T048-T054 sowie die geänderten
  `docs/security/*.md` auf gleiche DE/EN-Aussagen, CEFR B2, text-first-Status,
  aussagekräftige Links, korrekte Orthografie und fehlende Secret-/Personendaten
  prüfen. / Perform the full bilingual and text-first review. **Abhängigkeit**:
  T054. **Nachweis**: `docs/accessibility/gsdb-intensive-review.md`,
  `GSDB-GATE-019`.
- [x] T056 [US3] `docfx docfx.json` ausführen und den repräsentativen Pfad
  `_site/docs/security/gsdb-intensive-review/evidence-matrix.html` mit
  `lynx -dump -nolist` prüfen; `_site/` nicht tracken. / Regenerate DocFX and run
  the mandatory lynx smoke. **Abhängigkeit**: T055. **Nachweis**:
  `docs/accessibility/gsdb-intensive-review.md`, `GSDB-GATE-020`.
- [x] T057 [US3] Das vorhandene geprüfte Playwright/axe-Harness suchen und,
  wenn verfügbar, gegen repräsentative `_site/`-Seiten ausführen; andernfalls
  die Nichtverfügbarkeit mit Datum, Suchscope, Owner und Trigger in
  `docs/accessibility/gsdb-intensive-review.md` dokumentieren. / Run the
  preferred browser accessibility smoke when available, otherwise record an
  honest unavailable disposition. **Abhängigkeit**: T056. **Nachweis**:
  `GSDB-GATE-020`; kein Screenreader-Nutzertest oder WCAG-Zertifikat behaupten.
- [x] T058 [US3] US3 gegen FR-005, FR-011, FR-012 und SC-004/SC-005 prüfen. /
  Run the independently readable follow-up checkpoint. **Abhängigkeit**: T057.
  **Nachweis**: `docs/accessibility/gsdb-intensive-review.md` und
  `docs/security/gsdb-intensive-review/open-findings.md`,
  `GSDB-GATE-019`/`020`.

## Phase 6: User Story 4 – Nachweisbarer Abschluss / Evidence-based Closeout (P2)

**Unabhängiger Test / Independent Test**: Jedes der 33 Gates führt zu einem
konkreten aktuellen Beleg oder einer begründeten `N/A`-Zeile; spätere
Provider-, Merge- und Sync-Fakten bleiben bis zu ihrem Ereignis `Pending`.

- [x] T059 [US4] `.github/workflows/ci.yml` minimal um Linux-/Windows-
  PowerShell-Fixtures und -Produktmatrix sowie Linux-Bash-Fixtures und
  vollständiges Matrix-GREEN ergänzen; bestehende Produktjobs, Trigger und
  Action-Versionen nur im zwingend notwendigen Umfang berühren. / Add exact
  Linux/Windows validator execution and Bash parity to existing CI.
  **Abhängigkeit**: T058. **Nachweis**: `.github/workflows/ci.yml`,
  `GSDB-GATE-005`, `GSDB-GATE-021`, `GSDB-GATE-023`.
- [x] T060 [US4] `docs/PR_TEXT_GSDB_INTENSIVE_REVIEW.md` DE-first/EN-second mit
  Problem, Lösung, betroffenen Projekten, geschlossenem Pfadsatz,
  Test-/Plattformnachweisen, Risiken, Security/A11Y, Konfigurations-/API-
  Auswirkung, Human-only-Grenze und Nicht-Härtung erstellen. / Prepare the
  complete focused PR description. **Abhängigkeit**: T059. **Nachweis**:
  `GSDB-GATE-025` und später `GSDB-GATE-028`; noch keinen PR erstellen.
- [x] T061 [US4] Die 33 Gate-Anforderungen aus
  `specs/005-gsdb-intensive-review/contracts/autonomous-run-gate-requirements.json`
  auf konkrete Artefakte, Befehle, Runner/Plattformen, Owner/Reviewer,
  Restrisiken und Pending-Delivery-Nachweise in
  `specs/005-gsdb-intensive-review/autonomous-run-evidence.md` abbilden. /
  Build the complete gate-to-evidence map. **Abhängigkeit**: T060.
  **Nachweis**: Gates `GSDB-GATE-001`-`033`, keine ausgelassene ID.
- [x] T062 [US4] Das installierte Secure-Development-Assurance-Statuskommando
  read-only gegen
  `docs/security/secure-development/2026-09-05-rl-se-self-assessment/`
  ausführen und Scope/Freshness als Feature-005-Input, nicht als neue Freigabe,
  in `specs/005-gsdb-intensive-review/autonomous-run-evidence.md` festhalten. /
  Run bounded prior-assurance status. **Abhängigkeit**: T061. **Nachweis**:
  `GSDB-GATE-007` und `GSDB-GATE-026`.
- [x] T063 [US4] Einen unabhängigen, begrenzten technischen Secure-Development-
  Review des aktuellen Matrix-/Security-/Architekturstands ausführen; Befunde
  nur innerhalb der geschlossenen Feature-Pfade beheben oder als Blocker
  behandeln. / Obtain one independent bounded technical review. **Abhängigkeit**:
  T062. **Nachweis**: Review-Pfad und Hash in
  `specs/005-gsdb-intensive-review/autonomous-run-evidence.md`; Human-only-
  Pilot-, Projekt-, Rechts- und Risikoakzeptanz bleiben `Open`.
- [x] T064 [US4] `scripts/test-documentation-impact.ps1` und
  `scripts/validate-documentation-impact.ps1 -Evidence docs/documentation-impact/gsdb-intensive-review.json`
  ausführen und das Ergebnis in
  `specs/005-gsdb-intensive-review/autonomous-run-evidence.md` binden. / Validate
  documentation impact. **Abhängigkeit**: T063. **Nachweis**:
  `GSDB-GATE-025`.
- [x] T065 [US4] Die unveränderte Agenten-Guidance `AGENTS.md`, `CLAUDE.md`,
  `GEMINI.md`, `.github/copilot-instructions.md`,
  `.github/agents/copilot-instructions.md`, beide Constitutions und betroffene
  Templates auf Parität prüfen; `NoUpdateRequired` mit Trigger in
  `docs/documentation-impact/gsdb-intensive-review.json` festhalten. / Prove
  shared guidance remains unchanged and aligned. **Abhängigkeit**: T064.
  **Nachweis**: `GSDB-GATE-025`, `GSDB-GATE-026`; eine echte Regelkorrektur
  blockiert zur gesonderten Autorisierung.
- [x] T066 [US4] US4 gegen FR-013/FR-014 und SC-006 prüfen; Remote-, Merge-,
  PostMerge- und Sync-Zeilen in
  `specs/005-gsdb-intensive-review/autonomous-run-evidence.md` bleiben bis zum
  realen Ereignis `Pending`. / Run the pre-delivery truthfulness checkpoint.
  **Abhängigkeit**: T065. **Nachweis**: `GSDB-GATE-028`-`033` sind nicht
  vorweggenommen.

## Phase 7: Lokale Regression, Supply Chain und Konvergenz / Local Regression, Supply Chain, and Convergence

- [x] T067 Aktuelle direkte und transitive Pakete mit
  `dotnet list MicroCalc.sln package --include-transitive`, veraltete Pakete mit
  `dotnet list MicroCalc.sln package --outdated --include-transitive` und
  Schwachstellen mit
  `dotnet list MicroCalc.sln package --vulnerable --include-transitive`
  erfassen; NuGet-Quellen und die
  Abwesenheit/Existenz von Dependabot, Renovate und zentralem Dependency-Track
  prüfen. / Capture the current dependency state. **Abhängigkeit**: T066.
  **Nachweis**: `docs/security/dependency-audit.md`, `GSDB-GATE-013` und
  `GSDB-GATE-024`; kritischer CVE blockiert, Updates werden nicht implementiert.
- [x] T068 Den aktuellen Release-Ausgabebaum mit bestehendem Werkzeug in
  `.specify/runtime/autonomous-routing/69674c80-911c-40ff-9a0e-004f7b13b832/current-sbom.spdx.json`
  als temporäre SPDX-SBOM erfassen, gegen
  `docs/security/sbom/tinycalc-terminalgui.spdx.json` vergleichen und Hash,
  Scope sowie Drift in `docs/security/supply-chain-evidence.md` dokumentieren. /
  Reassess current SBOM without adding the temporary file to delivery.
  **Abhängigkeit**: T067. **Nachweis**: `GSDB-GATE-012`; fehlendes vorhandenes
  Werkzeug wird `Unavailable` mit Owner/Trigger, nicht als Pass dokumentiert.
- [x] T069 VEX für jeden aktuellen bekannten ausgelieferten Fund,
  SLSA/Provenance-Grenze, Action-Pinning, Lizenzen und OpenSSF-Posture in
  `docs/security/supply-chain-evidence.md` und
  `docs/security/dependency-audit.md` aktualisieren; keinen unbelegten SLSA-
  Level oder Score behaupten. / Complete current VEX, provenance, licence, and
  OpenSSF review. **Abhängigkeit**: T068. **Nachweis**:
  `GSDB-GATE-012`, `GSDB-GATE-013`, `GSDB-GATE-024`.
- [x] T070 `scripts/validate-gsdb-intensive-review.ps1 -Action ValidateFixtures`,
  `ValidateSources`, `ValidateCompendium`, `ValidateMappings`, `Validate` und
  die entsprechenden Bash-Fixture-/Validate-Aufrufe am finalen Matrixstand
  ausführen. / Run all matrix and fixture validations. **Abhängigkeit**: T069.
  **Nachweis**: `specs/005-gsdb-intensive-review/autonomous-run-evidence.md`,
  `GSDB-GATE-003`-`007`, `GSDB-GATE-021`.
- [x] T071 `scripts/invoke-psscriptanalyzer.ps1`,
  `bash -n scripts/validate-gsdb-intensive-review.sh`,
  `scripts/scan-agent-secrets.ps1 -FailOnHigh -WorkspaceRoot .`,
  `scripts/scan-agent-secrets.sh --fail-on-high .` und den verfügbaren lokalen
  gitleaks-Scan ausführen. / Run static, shell, secret, and leak checks.
  **Abhängigkeit**: T070. **Nachweis**:
  `specs/005-gsdb-intensive-review/autonomous-run-evidence.md`,
  `GSDB-GATE-026`; fehlender Scanner bleibt datiert `Unavailable`.
- [x] T072 `scripts/check-homogeneity.ps1 -TargetDir . -DryRun -NoPatch` und
  `scripts/check-homogeneity.sh --dry-run --no-patch .` ausführen und
  bestätigen, dass keine getrackten Runnerprofile, privaten absoluten Pfade,
  Runtime-Logs, Secrets oder Agentenzustände in der geschlossenen Liefermenge
  liegen. / Run both homogeneity paths and forbidden-content checks.
  **Abhängigkeit**: T071. **Nachweis**: `GSDB-GATE-026`.
- [x] T073 `scripts/validate-requirements-intake-alignment.ps1 -RepositoryRoot .`
  und `scripts/validate-requirements-intake-alignment.sh --repository-root .`
  sowie Intake-Review-/Serienvalidatoren in PowerShell und Bash read-only
  ausführen. / Validate current intake alignment and shell parity.
  **Abhängigkeit**: T072. **Nachweis**:
  `specs/005-gsdb-intensive-review/autonomous-run-evidence.md`,
  `GSDB-GATE-001`, `GSDB-GATE-032` bleibt für Closeout `Pending`.
- [x] T074 Produktcode-TDD und Changed-Product-Coverage in
  `specs/005-gsdb-intensive-review/autonomous-run-evidence.md` als `N/A`
  belegen, weil `git diff --exit-code -- src tests` keinen Produktdelta zeigt;
  Trigger sind jeder `src/`- oder Produkt-Test-/Verhaltensdelta, danach gelten
  beobachtbares RED/GREEN, mindestens 70 Prozent und Ziel 80 Prozent. / Prove
  the scoped coverage N/A. **Abhängigkeit**: T073. **Nachweis**:
  `GSDB-GATE-022`.
- [x] T075 Den voraussichtlichen Feature-Commitcount einschließlich des
  anstehenden Commits bestimmen, den Build-Zähler genau einmal erhöhen und
  `Version`, `AssemblyVersion`, `FileVersion` in `Directory.Build.props`
  identisch auf `1.5.<prospektiv>.<Build>` setzen. / Align version before the
  Release build. **Abhängigkeit**: T074. **Nachweis**:
  `specs/005-gsdb-intensive-review/autonomous-run-evidence.md`,
  `GSDB-GATE-023`, `GSDB-GATE-027`.
- [x] T076 `dotnet restore MicroCalc.sln` und genau einmal
  `dotnet build MicroCalc.sln --configuration Release --no-restore` ausführen. /
  Restore and build the unchanged product and new evidence tooling context.
  **Abhängigkeit**: T075. **Nachweis**: Befehl, Version, UTC-Zeit und Exitcode
  in `specs/005-gsdb-intensive-review/autonomous-run-evidence.md`,
  `GSDB-GATE-023`.
- [x] T077 Den Build-Zähler erneut genau einmal erhöhen, alle drei Felder in
  `Directory.Build.props` identisch halten und genau einmal
  `dotnet test MicroCalc.sln --configuration Release --no-build` ausführen. /
  Increment once and run the full xUnit suite. **Abhängigkeit**: T076.
  **Nachweis**: alle Core-/TUI-Tests grün, `GSDB-GATE-023`.
- [x] T078 `dotnet run --no-build --configuration Release --project
  src/MicroCalc.Tui/MicroCalc.Tui.csproj -- --smoke` ohne neuen Build/Test
  ausführen und Exitcode 0 sowie exakt eine Zeile `SMOKE_OK` verlangen. / Run
  the exact non-interactive smoke. **Abhängigkeit**: T077. **Nachweis**:
  `specs/005-gsdb-intensive-review/autonomous-run-evidence.md`,
  `GSDB-GATE-023`.
- [x] T079 `docs/project-statistics.md` nach vollständiger Implementierungs-
  evidenz aktualisieren: Branch/Phase, sichtbares Arbeitsfenster,
  Produktions-/Test-/Dokumentationszeilen, Arbeitspakete, 80/125 Zeilen pro
  Arbeitstag, 7,8 Stunden, 21,5 Tage/Monat, chronologisches Ledger und finale
  ASCII-Trends; danach `scripts/render-project-statistics.ps1 -Repo . -CheckOnly`
  ausführen. / Refresh and validate project statistics. **Abhängigkeit**: T078.
  **Nachweis**: `docs/project-statistics.md`, `GSDB-GATE-025`.
- [x] T080 Wegen der Statistik- und Security-Markdown-Änderungen
  `docfx docfx.json`, den lynx-Smoke aus T056 und die in T057 disponierte
  Playwright/axe-Prüfung erneut am finalen Dokumentstand ausführen. / Repeat
  DocFX and accessibility proof on the final docs. **Abhängigkeit**: T079.
  **Nachweis**: `docs/accessibility/gsdb-intensive-review.md`,
  `GSDB-GATE-019`, `GSDB-GATE-020`, `GSDB-GATE-025`.
- [x] T081 Alle lokalen Gates T067-T080, Matrix-Summary, 157-ID-Beweis,
  13-Preset-Beweis, Security-/Architektur-/Regulatorik-Aussagen und offene
  Human-only-Punkte in
  `specs/005-gsdb-intensive-review/autonomous-run-evidence.md` finalisieren;
  Provider-Gates bleiben `Pending`. / Close local evidence without claiming
  remote completion. **Abhängigkeit**: T080. **Nachweis**:
  `GSDB-GATE-003`-`027` mit ehrlicher Anwendbarkeit.

## Phase 8: Feature-Commit, PR, Exact Head, PreMerge und Merge / Feature Delivery

- [x] T082 Unmittelbar vor Git-/Remote-Arbeit Run-State, Stop-Status,
  Branch/Head, akzeptierte Hashes, `MergeAndSync`, Remote-Identität und
  `gh auth status` erneut read-only prüfen. / Revalidate current delivery
  authority. **Abhängigkeit**: T081. **Nachweis**:
  `.specify/runtime/autonomous-routing/69674c80-911c-40ff-9a0e-004f7b13b832/provider-evidence.json`,
  `GSDB-GATE-001`, `GSDB-GATE-028`.
- [x] T083 `Directory.Build.props` ohne Build/Test auf die für den anstehenden
  Commit gültige `1.5.<prospektiv>.<erreichter Build>`-Version ausrichten und
  drei identische Felder prüfen. / Re-align the version immediately before the
  commit. **Abhängigkeit**: T082. **Nachweis**: Runtime-Provider-Evidenz,
  `GSDB-GATE-027`.
- [x] T084 Jeden tatsächlich beabsichtigten Feature-Pfad aus der geschlossenen
  Liste einzeln an
  `.specify/presets/autonomous-run-governance/scripts/validate-autonomous-delivery-set.ps1
  -Repo . -Intended <exact-list>` übergeben und Index/Worktree vorher/nachher
  vergleichen; zusätzlich `git diff --check` und verbotene Pfade prüfen. /
  Validate the exact tracked/untracked/staged/unstaged delivery set read-only.
  **Abhängigkeit**: T083. **Nachweis**: Runtime-Provider-Evidenz,
  `GSDB-GATE-027`.
- [x] T085 Nur die in T084 bestätigten Pfade explizit stagen, den Validator
  erneut ausführen und `git diff --cached --check` bestehen. / Stage only the
  validated feature subset. **Abhängigkeit**: T084. **Nachweis**:
  `.specify/runtime/autonomous-routing/69674c80-911c-40ff-9a0e-004f7b13b832/provider-evidence.json`,
  `GSDB-GATE-027`; kein `git add -A`.
- [x] T086 Genau einen fokussierten Conventional Commit für Feature 005
  erstellen. / Create the focused feature commit. **Abhängigkeit**: T085.
  **Nachweis**: Commit-Pfade und Version entsprechen T084/T083 in der
  Runtime-Provider-Evidenz, `GSDB-GATE-027`.
- [x] T087 Commitcount, Commit-SHA, drei Versionsfelder, exakte Pfade und
  sauberen Index sofort read-only prüfen. / Verify the local commit before any
  push. **Abhängigkeit**: T086. **Nachweis**: Runtime-Provider-Evidenz,
  `GSDB-GATE-027`.
- [ ] T088 Autorität und Delivery-Set erneut prüfen und Branch
  `005-gsdb-intensive-review` ohne Force-Push pushen. / Push the feature branch.
  **Abhängigkeit**: T087. **Remote-Aktion / Remote action**: genau dieser Push.
  **Nachweis**: Remote-Head = lokaler Head in `provider-evidence.json`,
  `GSDB-GATE-028`.
- [ ] T089 Mit authentifizierter `gh`-CLI genau einen fokussierten PR von
  `005-gsdb-intensive-review` nach `main` mit
  `docs/PR_TEXT_GSDB_INTENSIVE_REVIEW.md` erstellen. / Create exactly one
  feature PR. **Abhängigkeit**: T088. **Remote-Aktion**: PR-Erstellung.
  **Nachweis**: Nummer, URL, Base/Head und `headRefOid` in
  `provider-evidence.json`, `GSDB-GATE-028`.
- [ ] T090 `gh pr checks --required --watch --fail-fast` für den unveränderten
  PR-Head ausführen. / Wait for required checks only. **Abhängigkeit**: T089.
  **Remote-Aktion**: Provider-Check-Abfrage/Warten. **Nachweis**:
  `provider-evidence.json`, `GSDB-GATE-028`; Refusal/Skip/Stale ist kein Pass.
- [ ] T091 Die tatsächlichen Workflow-/Job-Logs für Linux-/Windows-Produkt-
  und Validatorjobs, Bash-Parität, Homogenität, Anforderungen, PSScriptAnalyzer,
  Agent-Secret-Scan und gitleaks am selben Head read-only abrufen. / Bind real
  runner, platform, command, exit-code, and immutable URL evidence.
  **Abhängigkeit**: T090. **Remote-Aktion**: Log-Abfrage. **Nachweis**:
  `provider-evidence.json`, Gates `GSDB-GATE-005`, `021`, `023`, `026`, `028`.
- [ ] T092 Einen unabhängigen Exact-Head-Review von Matrix, Security,
  Architektur, A11Y, Supply Chain und geschlossenem Delivery-Set veranlassen
  und nur nachweisbare technische Befunde übernehmen; Human-only-Genehmigungen
  bleiben offen. / Obtain independent exact-head technical review evidence.
  **Abhängigkeit**: T091. **Remote-Aktion**: Review-Anforderung, soweit der
  Provider sie unterstützt. **Nachweis**:
  `.specify/runtime/autonomous-routing/69674c80-911c-40ff-9a0e-004f7b13b832/review-evidence.json`,
  `GSDB-GATE-028`.
- [ ] T093 PR-Zustand mit
  `gh pr view --json headRefOid,reviewDecision,mergeStateStatus,reviews,statusCheckRollup`
  und alle Review-Threads mit einer echten `gh api graphql`-Abfrage am selben
  Head lesen. / Inspect reviews and actionable threads. **Abhängigkeit**: T092.
  **Remote-Aktion**: Review-/Thread-Abfrage. **Nachweis**:
  `review-evidence.json`, `GSDB-GATE-028`.
- [ ] T094 Jeden materiellen Review-/CI-Befund nur in den geschlossenen
  Feature-Pfaden beheben, alle betroffenen lokalen Gates neu ausführen und bei
  null Befunden ausdrücklich `NoChangeRequired` in `review-evidence.json`
  festhalten. / Converge findings without scope expansion. **Abhängigkeit**:
  T093. **Nachweis**: `review-evidence.json`, `GSDB-GATE-028`; neue Pfade
  blockieren zur Plan-/Tasks-Revalidierung.
- [ ] T095 Falls T094 einen getrackten Delta erzeugt, Build-/Versionsformel,
  exakten Delivery-Set-Validator, Staging und cached diff erneut ausführen und
  genau einen fokussierten Remediation-Commit erstellen; andernfalls die
  begründete Nichtausführung als erfüllt protokollieren. / Create at most one
  exact-scope remediation commit when evidence requires it. **Abhängigkeit**:
  T094. **Nachweis**: `provider-evidence.json`, `GSDB-GATE-027`/`028`.
- [ ] T096 Falls T095 einen Commit erzeugt hat, diesen ohne Force-Push pushen;
  andernfalls den unveränderten Remote-Head bestätigen. / Push only the
  reviewed remediation head when one exists. **Abhängigkeit**: T095.
  **Remote-Aktion**: optionaler einzelner Push mit dokumentierter
  `NoChangeRequired`-Alternative. **Nachweis**: `provider-evidence.json`,
  `GSDB-GATE-028`.
- [ ] T097 Required Checks, konkrete Logs, unabhängigen Review und Threads nach
  T096 auf dem nun exakten Head vollständig wiederholen und Konvergenz mit null
  `Changes Requested` und null ungelösten actionable Threads belegen. / Re-run
  exact-head provider convergence after any head decision. **Abhängigkeit**:
  T096. **Remote-Aktion**: Check-/Review-/Thread-Revalidierung.
  **Nachweis**: `provider-evidence.json` und `review-evidence.json`,
  `GSDB-GATE-028`.
- [ ] T098 Eine frische temporäre Schema-2.0-PreMerge-Datei
  `.specify/runtime/autonomous-routing/69674c80-911c-40ff-9a0e-004f7b13b832/premerge-gate-evidence.json`
  mit normalisiertem Requirements-Hash, exaktem reviewed Head, genau einer
  `Primary`-Zeile je `GSDB-GATE-001`-`033`, echten Befehlen/Runnern/Hashes und
  ohne Mergebehauptung erzeugen. / Generate exact-head PreMerge evidence.
  **Abhängigkeit**: T097. **Nachweis**: `GSDB-GATE-030`.
- [ ] T099 T098 mit
  `.specify/presets/autonomous-run-governance/scripts/validate-autonomous-gate-evidence.ps1
  -Requirements specs/005-gsdb-intensive-review/contracts/autonomous-run-gate-requirements.json
  -Evidence <premerge> -Head <reviewed-head>` validieren. / Validate schema-2.0
  PreMerge. **Abhängigkeit**: T098. **Nachweis**: Exitcode 0 und normalisierter
  PreMerge-Hash in `provider-evidence.json`, `GSDB-GATE-030`.
- [ ] T100 Unmittelbar vor Merge Autorität, Head, Required Checks, Reviews,
  Threads, materielle Gates und Provider-Merge-Policy erneut read-only prüfen
  und zwischen normalem Pfad T101 und dem formal-only Pfad T102-T107 entscheiden.
  / Select the merge path fail-closed. **Abhängigkeit**: T099.
  **Remote-Aktion**: letzte Status-/Policy-Abfrage. **Nachweis**:
  `provider-evidence.json`, `GSDB-GATE-028`/`029`/`030`.
- [ ] T101 Wenn normaler Merge möglich ist, `GSDB-GATE-029` als weiterhin
  begründetes `N/A` belegen und den Feature-PR mit
  `gh pr merge --merge --delete-branch` mergen. / Perform the preferred normal
  merge. **Abhängigkeit**: T100; gegenseitig ausschließend zu T102-T107.
  **Remote-Aktion**: normaler Merge. **Nachweis**: Providerantwort in
  `provider-evidence.json`, `GSDB-GATE-031`.
- [ ] T102 Nur wenn T100 beweist, dass alle materiellen Gates grün sind und
  ausschließlich eine formale Merge-Regel blockiert, `GSDB-GATE-029` in
  `specs/005-gsdb-intensive-review/contracts/autonomous-run-gate-requirements.json`
  auf `Applicable` mit dem erforderlichen `--admin`-Token umstellen; sonst
  `NotTriggered` protokollieren. / Activate bypass requirements only under the
  accepted formal trigger. **Abhängigkeit**: T100; Alternative zu T101.
  **Nachweis**: `review-evidence.json`, `GSDB-GATE-029`.
- [ ] T103 Für den durch T102 ausgelösten Vertragsdelta Version, exakte
  Liefermenge, lokale Gates und unabhängigen Review neu binden und genau einen
  fokussierten Commit erstellen; bei `NotTriggered` keine Git-Aktion. /
  Commit the formal-only contract change when triggered. **Abhängigkeit**:
  T102. **Nachweis**: `provider-evidence.json`, `GSDB-GATE-027`-`030`.
- [ ] T104 Den T103-Commit ohne Force-Push pushen oder bei `NotTriggered` keine
  Remote-Aktion ausführen. / Push the activated bypass contract head only.
  **Abhängigkeit**: T103. **Remote-Aktion**: optionaler einzelner Push.
  **Nachweis**: `provider-evidence.json`, `GSDB-GATE-029`.
- [ ] T105 Für den T104-Head Required Checks, konkrete Logs, unabhängigen
  Review, Reviewentscheidung und Threads erneut vollständig konvergieren; bei
  `NotTriggered` die Nichtausführung binden. / Revalidate every material gate
  after bypass-contract change. **Abhängigkeit**: T104. **Remote-Aktion**:
  optionale Provider-Revalidierung. **Nachweis**: `provider-evidence.json` und
  `review-evidence.json`, `GSDB-GATE-028`/`029`.
- [ ] T106 Für den T105-Head die PreMerge-Datei aus T098 neu erzeugen und mit
  dem Befehl aus T099 validieren; alte PreMerge-Evidenz verwerfen. / Regenerate
  exact-head PreMerge after formal activation. **Abhängigkeit**: T105.
  **Nachweis**: `premerge-gate-evidence.json`, `GSDB-GATE-029`/`030`.
- [ ] T107 Nur nach T102-T106 und unmittelbar erneuter Head-/Policy-Prüfung
  `gh pr merge --merge --admin --delete-branch` ausführen; andernfalls nicht
  ausführen. / Perform admin merge only for the sole formal blocker.
  **Abhängigkeit**: T106; Alternative zu T101. **Remote-Aktion**: optionaler
  Admin-Merge. **Nachweis**: `provider-evidence.json`, `GSDB-GATE-029`/`031`;
  keine Branch-Protection-Änderung oder Providerfreigabe.
- [ ] T108 Den tatsächlichen Feature-Merge mit
  `gh pr view --json mergedAt,mergeCommit,state,headRefOid` und den
  Commit-Eltern read-only prüfen. / Verify provider merge facts.
  **Abhängigkeit**: T101 oder T107. **Remote-Aktion**: Merge-Verifikation.
  **Nachweis**: `provider-evidence.json`, `GSDB-GATE-031`.
- [ ] T109 Lokal `git switch main` und `git pull --ff-only` ausführen und
  lokales, Remote-`main` und echten Feature-Merge-Commit vergleichen. / Fast-
  forward local main after feature merge. **Abhängigkeit**: T108.
  **Remote-Aktion**: Fast-forward-Fetch/Pull. **Nachweis**:
  `provider-evidence.json`, `GSDB-GATE-031`; kein Reset/Rebase.
- [ ] T110 Die temporäre Schema-2.0-Datei
  `.specify/runtime/autonomous-routing/69674c80-911c-40ff-9a0e-004f7b13b832/postmerge-gate-evidence.json`
  mit akzeptiertem PreMerge-Hash, reviewed Feature-Head, echtem Merge-Commit
  und leerem `changedPaths` erzeugen und mit
  `validate-autonomous-gate-evidence.ps1` validieren. / Generate and validate
  causal PostMerge evidence. **Abhängigkeit**: T109. **Nachweis**:
  `GSDB-GATE-031`.

## Phase 9: Kausaler Intake-/Serien-Closeout / Causal Intake and Series Closeout

- [ ] T111 Nach gültigem T110 Run-State, Stop-Status, synchronisiertes `main`,
  PostMerge-Hash und aktuelle Autorität für genau Intake-Branch-Stamp, eine
  Serienaktualisierung und einen Closeout-PR revalidieren. / Revalidate narrow
  closeout authority. **Abhängigkeit**: T110. **Nachweis**:
  `.specify/runtime/autonomous-routing/69674c80-911c-40ff-9a0e-004f7b13b832/closeout-provider-evidence.json`,
  `GSDB-GATE-032`.
- [ ] T112 Vom synchronisierten `main` ausschließlich Branch
  `codex/005-gsdb-intensive-review-closeout` erzeugen. / Create the pre-named
  causal closeout branch. **Abhängigkeit**: T111. **Nachweis**:
  `closeout-provider-evidence.json`, `GSDB-GATE-032`; keinen anderen Branch.
- [ ] T113 Den akzeptierten PreMerge-Snapshot unverändert nach
  `specs/005-gsdb-intensive-review/evidence/accepted-premerge.json` und die
  validierte PostMerge-Evidenz nach
  `specs/005-gsdb-intensive-review/evidence/postmerge.json` übernehmen und
  beide erneut validieren. / Persist the causal lifecycle evidence.
  **Abhängigkeit**: T112. **Nachweis**: beide Hashes, `GSDB-GATE-030`/`031`.
- [ ] T114 Auf macOS das vorhandene Bash-Rename-Skript exakt für
  `requirements/intakes/active/Lastenheft_GSDB-Spec-Kit-Intensivpruefung.md`
  und Branch `005-gsdb-intensive-review` ausführen, sodass nur
  `requirements/intakes/active/Lastenheft_GSDB-Spec-Kit-Intensivpruefung.005-gsdb-intensive-review.md`
  entsteht; die PowerShell-Variante read-only auf Paritätssemantik prüfen. /
  Apply the single intake branch stamp. **Abhängigkeit**: T113.
  **Nachweis**: exakter Delete/Add-Paarpfad in `closeout-provider-evidence.json`,
  `GSDB-GATE-032`; keinen anderen Intake umbenennen.
- [ ] T115 Mit der erneut bestätigten Serienautorität genau eine
  `speckit-intake-series-update`-Lebenszyklusoperation für
  `requirements/intakes/series/tinycalc-delivery/manifest.json` ausführen und
  nur `operation.json`, `order.md`, `receipt.json` sowie gemeinsam
  `intake-review-request.json`, `intake-review-result.json`,
  `intake-review-report.md` aktualisieren, soweit der Workflow sie erzeugt. /
  Perform exactly one preserved-lineage series update. **Abhängigkeit**: T114.
  **Nachweis**: alle geänderten Dateien unter
  `requirements/intakes/series/tinycalc-delivery/`, `GSDB-GATE-032`; keine
  zweite Mutation und kein nächstes Target starten.
- [ ] T116 Serienmanifest, Receipt, Review-Result und Requirements-Alignment
  nach T115 mit den vorhandenen PowerShell- und Bash-Validatoren prüfen und
  `speckit-intake-series-status` ausschließlich read-only ausführen. /
  Validate series lifecycle and shell parity. **Abhängigkeit**: T115.
  **Nachweis**: `specs/005-gsdb-intensive-review/autonomous-run-evidence.md`
  und `closeout-provider-evidence.json`, `GSDB-GATE-032`.
- [ ] T117 `specs/005-gsdb-intensive-review/autonomous-run-evidence.md` mit
  Feature-Merge, akzeptiertem Pre/PostMerge, Intake-Stamp, genau einer
  Serienmutation, Closeout-Head und noch `Pending` Provider-Closeout
  aktualisieren; dieselben Zwischenfakten im lokal ausgeschlossenen
  `specs/005-gsdb-intensive-review/autonomous-run-state.json` fortschreiben. /
  Prepare tracked readable closeout evidence and local operational state
  without claiming the future closeout merge. **Abhängigkeit**: T116.
  **Nachweis**: `GSDB-GATE-032`; der Laufzustand bleibt ungetrackt.
- [ ] T118 Die tatsächliche Closeout-Teilmenge aus der geschlossenen Liste
  einzeln mit `validate-autonomous-delivery-set.ps1`, `git diff --check`,
  verbotenen Produkt-/Folgefeature-Pfaden und Review-Datei-Atomizität prüfen. /
  Validate the exact causal closeout delivery set. **Abhängigkeit**: T117.
  **Nachweis**: `closeout-provider-evidence.json`, `GSDB-GATE-027`/`032`.
- [ ] T119 Die bestätigten Closeout-Pfade explizit stagen und genau einen
  single-commit-fähigen fokussierten Closeout-Commit erstellen; Version und
  Produktpfade bleiben unverändert. / Create exactly one closeout commit.
  **Abhängigkeit**: T118. **Nachweis**: Commit-Pfadliste und sauberer Index in
  `closeout-provider-evidence.json`, `GSDB-GATE-032`.
- [ ] T120 Autorität und exakten Closeout-Satz erneut prüfen und
  `codex/005-gsdb-intensive-review-closeout` ohne Force-Push pushen. / Push the
  closeout branch. **Abhängigkeit**: T119. **Remote-Aktion**: genau dieser Push.
  **Nachweis**: Remote-/Lokal-Head identisch, `GSDB-GATE-032`.
- [ ] T121 Mit `gh` genau einen kausalen, evidence-only Closeout-PR nach `main`
  erstellen. / Create exactly one causal closeout PR. **Abhängigkeit**: T120.
  **Remote-Aktion**: PR-Erstellung. **Nachweis**: Nummer, URL, Head/Base in
  `closeout-provider-evidence.json`, `GSDB-GATE-032`.
- [ ] T122 `gh pr checks --required --watch --fail-fast` für den exakten
  Closeout-Head ausführen und konkrete Runner-/Befehlslogs binden. / Converge
  required closeout checks. **Abhängigkeit**: T121. **Remote-Aktion**:
  Check-/Log-Abfrage. **Nachweis**: `closeout-provider-evidence.json`,
  `GSDB-GATE-028`/`032`.
- [ ] T123 Reviews, `Changes Requested` und actionable Threads mit
  `gh pr view` und `gh api graphql` am unveränderten Closeout-Head bis null
  offene materielle Befunde prüfen; fehlende menschliche Fachfreigabe nicht
  erfinden. / Converge closeout review evidence. **Abhängigkeit**: T122.
  **Remote-Aktion**: Review-/Thread-Abfrage. **Nachweis**:
  `closeout-provider-evidence.json`, `GSDB-GATE-028`/`032`.
- [ ] T124 Unmittelbar vor Closeout-Merge Autorität, Head, Checks, Reviews und
  Policy prüfen; normalen Merge wählen. Admin ist nur zulässig, wenn
  `GSDB-GATE-029` bereits im akzeptierten Vertrag `Applicable` ist, alle
  materiellen Gates grün sind und allein eine formale Regel blockiert;
  andernfalls blockieren. / Select the closeout merge path fail-closed.
  **Abhängigkeit**: T123. **Remote-Aktion**: letzte Status-/Policy-Abfrage.
  **Nachweis**: `closeout-provider-evidence.json`, `GSDB-GATE-029`/`032`.
- [ ] T125 Den Closeout-PR normal mit `gh pr merge --merge --delete-branch`
  mergen; nur unter der vollständig belegten T124-Grenze `--admin` ergänzen. /
  Merge the causal closeout PR. **Abhängigkeit**: T124. **Remote-Aktion**:
  genau ein normaler oder formal-only Admin-Merge. **Nachweis**:
  `closeout-provider-evidence.json`, `GSDB-GATE-031`/`032`.
- [ ] T126 Den tatsächlichen Closeout-Merge-Commit, Eltern, Head und Status mit
  `gh pr view`/`gh api` sofort read-only prüfen. / Verify provider closeout
  merge facts. **Abhängigkeit**: T125. **Remote-Aktion**: Merge-Verifikation.
  **Nachweis**: `closeout-provider-evidence.json`, `GSDB-GATE-032`.
- [ ] T127 Lokal `main` erneut ausschließlich mit `git pull --ff-only` auf den
  Remote-Closeout-Merge synchronisieren und SHA-Gleichheit prüfen. / Fast-
  forward local main after closeout. **Abhängigkeit**: T126. **Remote-Aktion**:
  Fast-forward-Fetch/Pull. **Nachweis**: `closeout-provider-evidence.json`,
  `GSDB-GATE-031`/`032`; danach keine getrackten Writes.

## Phase 10: Finale Nur-Lese-Prüfung und Leerlauf / Final Read-only Validation and Idle Boundary

- [ ] T128 Feature- und Closeout-Liefermengen, 157/157 IDs, 12/12 Familien,
  Sammelbandparität, 13/13 Presets, vollständige Findings, alle lokalen Gates,
  beide PR-Heads/Merges, akzeptierte Schema-2.0-Pre/PostMerge-Kausalität,
  branchgestempelten Intake, genau eine Serienaktualisierung, Remote-/lokales
  `main` und Branchbereinigung vollständig read-only prüfen. / Run the final
  end-to-end validation. **Abhängigkeit**: T127. **Nachweis**:
  `closeout-provider-evidence.json`, Gates `GSDB-GATE-001`-`032`; jeder fehlende
  oder alte Beleg ergibt `Blocked`/`Failed`, niemals `Completed`.
- [ ] T129 Die PowerShell- und Bash-Varianten für Run-State, Requirements-
  Alignment, Serienmanifest, Receipt und GSDB-Matrix im finalen Zustand erneut
  read-only ausführen. / Repeat all final cross-shell validators.
  **Abhängigkeit**: T128. **Nachweis**: `closeout-provider-evidence.json`,
  `GSDB-GATE-021`, `GSDB-GATE-026`, `GSDB-GATE-032`.
- [ ] T130 `GSDB-GATE-033` final als `N/A` mit dem akzeptierten Trigger prüfen:
  kein Nachfolge-Intake, kein Nachfolgefeature und keine parallele Kampagne
  wurde angelegt, ausgewählt, gestartet oder mutiert. / Prove the explicit
  no-next-feature boundary. **Abhängigkeit**: T129. **Nachweis**:
  `.specify/runtime/autonomous-routing/69674c80-911c-40ff-9a0e-004f7b13b832/closeout-provider-evidence.json`
  und `specs/005-gsdb-intensive-review/autonomous-run-state.json`,
  `GSDB-GATE-033`; einzige nächste Aktion ist Leerlauf.
- [ ] T131 Erst nach T130 den operativen autonomen Laufzustand auf `Completed`
  mit terminalen Closeout-Feldern setzen und das strukturierte Implement-
  Phasenergebnis mit **131/131** ausgeführten Aufgaben sowie vollständiger
  Gate-Evidenz erzeugen; danach erfolgen keine getrackten Änderungen. / Mark
  the run complete only after the no-successor proof and all other task and gate
  evidence are complete. **Abhängigkeit**: T130. **Nachweis**:
  `specs/005-gsdb-intensive-review/autonomous-run-state.json` und
  `.specify/runtime/autonomous-routing/69674c80-911c-40ff-9a0e-004f7b13b832/implement.result.json`,
  `GSDB-GATE-002`, `GSDB-GATE-032`, `GSDB-GATE-033`; der lokal ausgeschlossene
  Laufzustand und das Runtime-Phasenergebnis ändern weder `main` noch eine
  Liefermenge.

## Abhängigkeiten / Dependencies

```text
T001-T010  Autorität, Quellen und geschlossene Liefermengen
  -> T011-T015  beobachtbares RED und kleinstes GREEN
  -> T016-T021  vollständige Negativ-Fixtures und Parität
  -> T022-T030  US1: 157-ID-/Sammelband-/Quellen-/Preset-Beweis
  -> T031-T047  US2: ehrliche Status-, Human-only-, Security- und Architekturprüfung
  -> T048-T058  US3: bilinguale, text-first Nacharbeit und A11Y
  -> T059-T066  US4: Gate-Matrix, unabhängiger Review und Delivery-Wahrheit
  -> T067-T081  aktuelle Supply Chain, Regression, Statistik und lokale Gates
  -> T082-T099  exakter Feature-Commit/PR/Review/PreMerge
  -> T100-T110 normaler oder formal-only Merge, Fast-forward und PostMerge
  -> T111-T127 vorbenannter kausaler Intake-/Serien-Closeout und zweiter Merge
  -> T128-T130 finale Nur-Lese-Prüfung und no-next-feature
  -> T131 terminales Completed mit 131/131 Aufgaben
```

- T035-T043 dürfen nach T034 parallel laufen, weil sie unterschiedliche
  Writer-Pfade besitzen; T044 integriert sie seriell. / T035-T043 may run in
  parallel after T034 because writer paths differ; T044 integrates them.
- T048-T051 dürfen nach T047 parallel laufen; T052 wartet auf alle vier. /
  T048-T051 may run in parallel; T052 joins them.
- Die beiden Mergepfade sind explizite Alternativen: T101 normal oder
  T102-T107 formal-only. T108 verlangt genau einen erfolgreichen Pfad. / The
  two merge paths are explicit alternatives; T108 requires exactly one.
- Ab T082 ist die Reihenfolge streng seriell, weil Version, Commit, PR-Head,
  Reviews, Gate-Hashes, Merge-Commit, Intake-Linie und Sync kausal aufeinander
  folgen. / Delivery and closeout are strictly serial.

## Anforderungsabdeckung und Evidenzpfade / Requirement Coverage and Evidence Paths

| Anforderung / Requirement | Ausführbare Aufgaben / Executable tasks | Verbindliche Evidenzpfade / Binding evidence paths |
|---|---|---|
| `FR-001` | T002, T004, T010, T030 | `specs/005-gsdb-intensive-review/autonomous-run-evidence.md`; `docs/security/gsdb-intensive-review/evidence-matrix.json` |
| `FR-002` | T006-T008, T025 | `docs/security/gsdb-intensive-review/source-inventory.md`; `docs/security/gsdb-intensive-review/evidence-matrix.json` |
| `FR-003` | T023, T026, T029-T030 | `docs/security/gsdb-intensive-review/source-inventory.md`; `docs/security/gsdb-intensive-review/evidence-matrix.json`; `specs/005-gsdb-intensive-review/autonomous-run-evidence.md` |
| `FR-004` | T024, T027, T029-T030 | `docs/security/gsdb-intensive-review/source-inventory.md`; `docs/security/gsdb-intensive-review/evidence-matrix.json` |
| `FR-005` | T017, T026, T031, T046, T049, T051, T058 | `docs/security/gsdb-intensive-review/evidence-matrix.json`; `docs/security/gsdb-intensive-review/evidence-matrix.md`; `docs/security/gsdb-intensive-review/open-findings.md` |
| `FR-006` | T017, T031-T032, T047 | `docs/security/gsdb-intensive-review/evidence-matrix.json`; `docs/security/gsdb-intensive-review/open-findings.md` |
| `FR-007` | T033-T034, T044 | `docs/security/security-checklist.md`; `docs/security/gsdb-intensive-review/evidence-matrix.json` |
| `FR-008` | T008, T028, T050 | `docs/security/gsdb-intensive-review/preset-mapping.md`; `docs/security/gsdb-intensive-review/evidence-matrix.json` |
| `FR-009` | T007, T025, T044-T045 | `docs/security/gsdb-intensive-review/source-inventory.md`; `docs/security/gsdb-intensive-review/evidence-matrix.json` |
| `FR-010` | T032, T047, T066 | `docs/security/gsdb-intensive-review/evidence-matrix.json`; `docs/security/gsdb-intensive-review/open-findings.md`; `specs/005-gsdb-intensive-review/autonomous-run-evidence.md` |
| `FR-011` | T046-T047, T051, T058 | `docs/security/gsdb-intensive-review/evidence-matrix.json`; `docs/security/gsdb-intensive-review/open-findings.md` |
| `FR-012` | T048-T055, T058 | `docs/accessibility/gsdb-intensive-review.md`; `docs/security/gsdb-intensive-review/evidence-matrix.md`; `docs/security/gsdb-intensive-review/open-findings.md` |
| `FR-013` | T061, T066, T081-T110, T111-T131 | `specs/005-gsdb-intensive-review/autonomous-run-evidence.md`; `.specify/runtime/autonomous-routing/69674c80-911c-40ff-9a0e-004f7b13b832/provider-evidence.json`; `.specify/runtime/autonomous-routing/69674c80-911c-40ff-9a0e-004f7b13b832/review-evidence.json`; `.specify/runtime/autonomous-routing/69674c80-911c-40ff-9a0e-004f7b13b832/premerge-gate-evidence.json`; `.specify/runtime/autonomous-routing/69674c80-911c-40ff-9a0e-004f7b13b832/postmerge-gate-evidence.json`; `.specify/runtime/autonomous-routing/69674c80-911c-40ff-9a0e-004f7b13b832/closeout-provider-evidence.json` |
| `FR-014` | T025, T029, T031, T044-T046, T066 | `docs/security/gsdb-intensive-review/evidence-matrix.json`; `docs/security/gsdb-intensive-review/source-inventory.md`; `specs/005-gsdb-intensive-review/autonomous-run-evidence.md` |
| `SC-001` | T023-T030 | `docs/security/gsdb-intensive-review/source-inventory.md`; `docs/security/gsdb-intensive-review/evidence-matrix.json`; `specs/005-gsdb-intensive-review/autonomous-run-evidence.md` |
| `SC-002` | T026, T031-T032, T046-T047, T070 | `docs/security/gsdb-intensive-review/evidence-matrix.json`; `docs/security/gsdb-intensive-review/open-findings.md` |
| `SC-003` | T032, T037-T047, T055, T063, T066 | `docs/security/gsdb-intensive-review/evidence-matrix.json`; `docs/security/gsdb-intensive-review/open-findings.md`; `specs/005-gsdb-intensive-review/autonomous-run-evidence.md` |
| `SC-004` | T008, T027-T028, T045-T046, T050-T051, T058 | `docs/security/gsdb-intensive-review/preset-mapping.md`; `docs/security/gsdb-intensive-review/evidence-matrix.json`; `docs/security/gsdb-intensive-review/open-findings.md` |
| `SC-005` | T048-T058, T080 | `docs/accessibility/gsdb-intensive-review.md`; `docs/security/gsdb-intensive-review/evidence-matrix.md`; `docs/security/gsdb-intensive-review/open-findings.md` |
| `SC-006` | T061, T066, T081, T090-T110, T111-T131 | `specs/005-gsdb-intensive-review/autonomous-run-evidence.md`; `.specify/runtime/autonomous-routing/69674c80-911c-40ff-9a0e-004f7b13b832/provider-evidence.json`; `.specify/runtime/autonomous-routing/69674c80-911c-40ff-9a0e-004f7b13b832/review-evidence.json`; `.specify/runtime/autonomous-routing/69674c80-911c-40ff-9a0e-004f7b13b832/premerge-gate-evidence.json`; `.specify/runtime/autonomous-routing/69674c80-911c-40ff-9a0e-004f7b13b832/postmerge-gate-evidence.json`; `.specify/runtime/autonomous-routing/69674c80-911c-40ff-9a0e-004f7b13b832/closeout-provider-evidence.json` |

Alle 14 funktionalen Anforderungen und sechs messbaren Erfolgskriterien sind
damit mindestens einer ausführbaren Aufgabe und einem exakten Nachweispfad
zugeordnet. / All 14 functional requirements and six measurable success
criteria map to at least one executable task and one exact evidence path.

## Gate-Abdeckung und Evidenzpfade / Gate Coverage and Evidence Paths

| Gate | Primäre Aufgaben / Primary tasks | Verbindlicher Evidenzpfad / Binding evidence path |
|---|---|---|
| `GSDB-GATE-001` | T001-T004, T082, T111, T128 | `specs/005-gsdb-intensive-review/autonomous-run-evidence.md`; `.specify/runtime/autonomous-routing/69674c80-911c-40ff-9a0e-004f7b13b832/provider-evidence.json` |
| `GSDB-GATE-002` | T003, T131 | `.specify/runtime/autonomous-routing/69674c80-911c-40ff-9a0e-004f7b13b832/specify.result.json`; `.specify/runtime/autonomous-routing/69674c80-911c-40ff-9a0e-004f7b13b832/clarify.result.json`; `.specify/runtime/autonomous-routing/69674c80-911c-40ff-9a0e-004f7b13b832/requirements-checklist.result.json`; `.specify/runtime/autonomous-routing/69674c80-911c-40ff-9a0e-004f7b13b832/plan.result.json`; `.specify/runtime/autonomous-routing/69674c80-911c-40ff-9a0e-004f7b13b832/plan-review.result.json`; `.specify/runtime/autonomous-routing/69674c80-911c-40ff-9a0e-004f7b13b832/tasks.result.json`; `.specify/runtime/autonomous-routing/69674c80-911c-40ff-9a0e-004f7b13b832/analyze.result.json`; `.specify/runtime/autonomous-routing/69674c80-911c-40ff-9a0e-004f7b13b832/implement.result.json` |
| `GSDB-GATE-003` | T006-T008, T023, T025, T029 | `docs/security/gsdb-intensive-review/source-inventory.md`; `docs/security/gsdb-intensive-review/evidence-matrix.json` |
| `GSDB-GATE-004` | T024, T029 | `docs/security/gsdb-intensive-review/source-inventory.md`; `specs/005-gsdb-intensive-review/autonomous-run-evidence.md` |
| `GSDB-GATE-005` | T011-T018, T021, T029, T070 | `scripts/tests/gsdb-intensive-review/test-validate-gsdb-intensive-review.ps1`; `scripts/tests/gsdb-intensive-review/test-validate-gsdb-intensive-review.sh`; `specs/005-gsdb-intensive-review/autonomous-run-evidence.md` |
| `GSDB-GATE-006` | T017, T025-T032, T046-T049, T070 | `docs/security/gsdb-intensive-review/evidence-matrix.json`; `docs/security/gsdb-intensive-review/evidence-matrix.md` |
| `GSDB-GATE-007` | T007-T008, T027-T028, T045, T050, T062 | `docs/security/gsdb-intensive-review/preset-mapping.md`; `docs/security/gsdb-intensive-review/evidence-matrix.json` |
| `GSDB-GATE-008` | T033, T044 | `docs/security/security-checklist.md`; `docs/security/gsdb-intensive-review/evidence-matrix.json` |
| `GSDB-GATE-009` | T034, T044, T046 | `docs/security/security-checklist.md`; `docs/security/gsdb-intensive-review/open-findings.md` |
| `GSDB-GATE-010` | T035-T036, T044 | `docs/security/threat-model.md`; `docs/security/arc42-security.md`; `docs/security/security-quality-scenarios.md` |
| `GSDB-GATE-011` | T037 | `docs/security/asvs-verification.md` |
| `GSDB-GATE-012` | T068-T069 | `docs/security/supply-chain-evidence.md`; `.specify/runtime/autonomous-routing/69674c80-911c-40ff-9a0e-004f7b13b832/current-sbom.spdx.json` |
| `GSDB-GATE-013` | T067, T069 | `docs/security/dependency-audit.md`; `docs/security/supply-chain-evidence.md` |
| `GSDB-GATE-014` | T038 | `docs/security/supply-chain-evidence.md` |
| `GSDB-GATE-015` | T039 | `docs/security/zero-trust-applicability.md` |
| `GSDB-GATE-016` | T039, T044 | `docs/security/zero-trust-applicability.md`; `docs/security/gsdb-intensive-review/evidence-matrix.json` |
| `GSDB-GATE-017` | T040-T041, T044 | `docs/security/cloud-autonomy-applicability.md`; `docs/security/cloud-compliance-assurance.md` |
| `GSDB-GATE-018` | T042-T043, T044 | `docs/security/regulatory-applicability.md`; `docs/security/samm-assessment.md` |
| `GSDB-GATE-019` | T048-T055, T058, T080 | `docs/accessibility/gsdb-intensive-review.md` |
| `GSDB-GATE-020` | T056-T057, T080 | `docs/accessibility/gsdb-intensive-review.md`; `_site/docs/security/gsdb-intensive-review/evidence-matrix.html` |
| `GSDB-GATE-021` | T012-T021, T059, T070, T091, T129 | `specs/005-gsdb-intensive-review/checklists/script-parity.md`; `docs/man/validate-gsdb-intensive-review.1`; `.specify/runtime/autonomous-routing/69674c80-911c-40ff-9a0e-004f7b13b832/provider-evidence.json` |
| `GSDB-GATE-022` | T074, T128 | `specs/005-gsdb-intensive-review/autonomous-run-evidence.md` |
| `GSDB-GATE-023` | T075-T078, T091 | `specs/005-gsdb-intensive-review/autonomous-run-evidence.md`; `.specify/runtime/autonomous-routing/69674c80-911c-40ff-9a0e-004f7b13b832/provider-evidence.json` |
| `GSDB-GATE-024` | T067-T069 | `docs/security/dependency-audit.md`; `docs/security/supply-chain-evidence.md` |
| `GSDB-GATE-025` | T052-T055, T060, T064-T065, T079-T080 | `docs/documentation-impact/gsdb-intensive-review.json`; `docs/project-statistics.md`; `docs/security/README.md` |
| `GSDB-GATE-026` | T021, T065, T071-T073, T091, T129 | `specs/005-gsdb-intensive-review/autonomous-run-evidence.md`; `.specify/runtime/autonomous-routing/69674c80-911c-40ff-9a0e-004f7b13b832/provider-evidence.json` |
| `GSDB-GATE-027` | T005, T075, T083-T087, T095, T103, T118-T119 | `Directory.Build.props`; `.specify/runtime/autonomous-routing/69674c80-911c-40ff-9a0e-004f7b13b832/provider-evidence.json`; `.specify/runtime/autonomous-routing/69674c80-911c-40ff-9a0e-004f7b13b832/closeout-provider-evidence.json` |
| `GSDB-GATE-028` | T082, T088-T097, T100, T122-T124 | `.specify/runtime/autonomous-routing/69674c80-911c-40ff-9a0e-004f7b13b832/provider-evidence.json`; `.specify/runtime/autonomous-routing/69674c80-911c-40ff-9a0e-004f7b13b832/review-evidence.json`; `.specify/runtime/autonomous-routing/69674c80-911c-40ff-9a0e-004f7b13b832/closeout-provider-evidence.json` |
| `GSDB-GATE-029` | T100-T107, T124-T125 | `specs/005-gsdb-intensive-review/contracts/autonomous-run-gate-requirements.json`; `.specify/runtime/autonomous-routing/69674c80-911c-40ff-9a0e-004f7b13b832/premerge-gate-evidence.json`; `.specify/runtime/autonomous-routing/69674c80-911c-40ff-9a0e-004f7b13b832/provider-evidence.json` |
| `GSDB-GATE-030` | T098-T099, T106, T113 | `.specify/runtime/autonomous-routing/69674c80-911c-40ff-9a0e-004f7b13b832/premerge-gate-evidence.json`; `specs/005-gsdb-intensive-review/evidence/accepted-premerge.json` |
| `GSDB-GATE-031` | T101/T107, T108-T110, T125-T127 | `.specify/runtime/autonomous-routing/69674c80-911c-40ff-9a0e-004f7b13b832/postmerge-gate-evidence.json`; `specs/005-gsdb-intensive-review/evidence/postmerge.json`; `.specify/runtime/autonomous-routing/69674c80-911c-40ff-9a0e-004f7b13b832/closeout-provider-evidence.json` |
| `GSDB-GATE-032` | T111-T131 | `requirements/intakes/active/Lastenheft_GSDB-Spec-Kit-Intensivpruefung.005-gsdb-intensive-review.md`; `requirements/intakes/series/tinycalc-delivery/manifest.json`; `requirements/intakes/series/tinycalc-delivery/operation.json`; `requirements/intakes/series/tinycalc-delivery/order.md`; `requirements/intakes/series/tinycalc-delivery/receipt.json`; `requirements/intakes/series/tinycalc-delivery/intake-review-request.json`; `requirements/intakes/series/tinycalc-delivery/intake-review-result.json`; `requirements/intakes/series/tinycalc-delivery/intake-review-report.md`; `specs/005-gsdb-intensive-review/autonomous-run-state.json`; `.specify/runtime/autonomous-routing/69674c80-911c-40ff-9a0e-004f7b13b832/closeout-provider-evidence.json` |
| `GSDB-GATE-033` | T010, T130-T131 | `specs/005-gsdb-intensive-review/autonomous-run-state.json`; `.specify/runtime/autonomous-routing/69674c80-911c-40ff-9a0e-004f7b13b832/closeout-provider-evidence.json` |

## Format- und Vollständigkeitsprüfung / Format and Completeness Check

- Gesamtzahl / Total: **131 Aufgaben / tasks** (`T001`-`T131`).
- Alle Aufgaben sind offen; diese Generierungsphase führt **0 von 131**
  Implementierungsaufgaben aus. / All tasks remain open; this generation phase
  executes **0 of 131** implementation tasks.
- Jede Aufgabe besitzt eine stabile ID, konkrete repository-relative Writer-
  oder Evidenzpfade, explizite Abhängigkeiten, erwartete Evidenz und eine
  fail-closed Grenze. / Every task has a stable ID, exact paths, dependencies,
  evidence, and a fail-closed boundary.
- Alle Remote-Aktionen sind getrennte Aufgaben; Feature- und Closeout-Merge,
  Providerverifikation und beide lokalen Fast-forwards sind kausal getrennt. /
  Every remote action is distinct and causally ordered.
- Produkt-Härtung, Human-only-Erledigung, neue konkrete Modellnamen,
  Nachfolgefeature und parallele Kampagne sind nicht eingeplant. / Product
  hardening, Human-only completion, concrete model names, successor work, and
  parallel campaigns are excluded.
