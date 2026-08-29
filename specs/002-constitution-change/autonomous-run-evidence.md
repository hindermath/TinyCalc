# Evidenz des autonomen Laufs / Autonomous Run Evidence

## Identität und Autorität / Identity and Authority

| Feld / Field | Wert / Value |
|---|---|
| Feature | `002-constitution-change` |
| Akzeptierte Eingaben / Accepted inputs | Binding intake, current review result and request, series manifest, accepted specification and requirements checklist |
| Liefermodus / Delivery mode | `MergeAndSync` |
| Autoritätsquelle / Authority source | Aktuelle geroutete Nutzeranweisung vom 30. August 2026 für ausschließlich T001–T038; keine Git-, Remote- oder Delivery-Aktion / Current routed user request of 30 August 2026 for T001–T038 only; no Git, remote, or delivery action |
| Evidenz-Owner / Evidence owner | Repository-Maintainer |
| Run-State | `specs/002-constitution-change/autonomous-run-state.json` |
| Status | `Active` |

Der Admin-Bypass darf nur Regeln zur Merge-Berechtigung übersteuern. Er ersetzt
keine fehlende fachliche, Security-, A11Y- oder Exact-Head-Evidenz.

*The admin bypass may override merge-permission rules only. It cannot replace
missing functional, security, accessibility, or exact-head evidence.*

## Modell-Routing / Model Routing

Der lokale Codex-Katalog ist mit `balanced-v1` und `fail-closed` ausgerichtet.
Konkrete Modellnamen bleiben lokale Ausführungsevidenz und sind keine
Feature-Anforderung. Jede semantische Phase läuft in einem neuen Prozess.

*The local Codex catalog is aligned with `balanced-v1` and `fail-closed`.
Concrete model names remain local execution evidence, not feature requirements.
Each semantic phase runs in a new process.*

## Konvergenz / Convergence

| Gate | Zustand / State | Evidenz / Evidence |
|---|---|---|
| Preflight | Pass | Intake-Review `Ready`, sechs akzeptierte Artefakte, Branch und Feature stimmen überein / Intake review is `Ready`; six accepted artifacts, branch, and feature agree |
| Clarify | Pass | Geroutetes Phasenresultat validiert / Routed phase result validated |
| Checklists | Pass | Requirements-Checkliste vollständig; autonome Abschlusszeilen bleiben bis zu ihren tatsächlichen Grenzen offen / Requirements checklist complete; autonomous closeout rows remain open until their actual boundaries |
| Plan Review | Pass | `Completed`; normalisierter Plan-Hash `4c6cffaec2bb85cd43a82e7f19c1bb3ba73455d69cdb559261ce59d0d038d308` |
| Tasks | Pass | 71 Aufgaben serialisiert und durch Analyze geprüft / 71 tasks serialized and analyzed |
| Analyze | Pass | Keine Critical-, High- oder ungelöste Medium-Feststellung / No Critical, High, or unresolved Medium finding |
| Implementation | Pass | T001–T038 lokal vollständig belegt; T039–T071 sind ausdrücklich gesperrt / T001–T038 are fully evidenced locally; T039–T071 are explicitly prohibited |

## Validierungs- und Liefergrenzen / Validation and Delivery Boundaries

- Die Gate-Anforderungen stehen vor der ersten Implementierungsänderung in
  `autonomous-run-gate-requirements.json`.
- Der geplante Delivery-Set-Validator erhält das Repository-Root und jede
  beabsichtigte unversionierte Datei ausdrücklich.
- DocFX und die HTML-A11Y-Prüfung werden nur bei ihrem dokumentierten Trigger
  ausgeführt; ein Skip erhält eine Begründung.
- Vor dem Merge wird ein temporärer Schema-2.0-`PreMerge`-Snapshot für den
  exakt geprüften Head erzeugt und validiert.
- Nach dem Merge bindet ein kausaler `PostMerge`-Snapshot den PreMerge-Hash und
  den tatsächlichen Merge-Commit.

*Gate requirements exist before the first implementation edit. Delivery-set
validation receives an explicit repository root and every intended untracked
file. DocFX and HTML accessibility run only when triggered, with a documented
skip otherwise. A temporary schema-2.0 PreMerge snapshot binds the exact
reviewed head; PostMerge evidence binds its hash to the actual merge commit.*

## Fortsetzung / Resume

- Letztes erfolgreiches Gate: T001–T038 lokal vollständig validiert.
- Nächste genaue Aktion: T039 nach erneuter Delivery-Autoritätsprüfung.
- Restrisiko: Remote-Checks und Review-Verfügbarkeit sind erst nach Push
  bekannt; fehlende fachliche Evidenz blockiert auch mit Admin-Bypass.
- Out-of-Scope-Follow-up: vollständige Bestandsnacharbeit didaktischer
  Inline-Kommentare bleibt beim späteren Intake
  `Lastenheft_Didactic-Inline-Code-Comment-Hardening.md`.

*Last passing gate: T001–T038 passed all local evidence. The next exact action
is T039 after separate delivery-authority revalidation. Remote checks and
reviewer availability are known only
after a later, separately authorized push; missing technical evidence blocks
even with admin bypass. Full didactic inline-comment inventory remediation
remains with its later intake.*

## Lokale Implementierung T001–T008 / Local Implementation T001–T008

### T001 – akzeptiertes Plan-Review / Accepted Plan Review

Ausgeführt auf macOS mit PowerShell 7:

```text
pwsh -NoProfile -File .specify/presets/autonomous-run-governance/scripts/validate-autonomous-phase-result.ps1 -Repo . -Result .specify/runtime/autonomous-routing/d42bfa06-0a67-492e-968d-80309788b383/plan-review.result.json -PhaseId plan-review -ExitCode 0
Exitcode: 0
Standardfehler: leer (0 Byte)
Ergebnis: Completed
Payload SHA-256: 4c6cffaec2bb85cd43a82e7f19c1bb3ba73455d69cdb559261ce59d0d038d308
Normalisierter Ergebnis-SHA-256: 0a22068cab20a5fd17de0ebe4395739fc523cde3462cb2adf4958f0fefda9393
```

*Executed on macOS with PowerShell 7. The command returned exit code 0, an
empty error stream, `Completed`, and the accepted normalized plan payload
hash.*

### T002 – akzeptierte Eingaben und Klassifikation / Accepted Inputs and Classification

`shasum -a 256` bestätigte alle sechs akzeptierten Werte:

| Pfad / Path | SHA-256 | Status |
|---|---|---|
| `requirements/intakes/active/Lastenheft_Constitution_Change.002-constitution-change.md` | `04c4e1ba93d626463829a07f33b5591a6417b6aeaf89e805b637ab1bf5c26a0a` | Pass; exact enabled-prompt self-paths / exakte Selbstpfade der aktivierten Prompts |
| `requirements/intakes/series/tinycalc-delivery/intake-review-result.json` | `6f33209dedb2c51525f4443e44e1877466bb096bc030a748484936b96299559b` | Pass; branch-stamped active-intake propagation / propagation of the branch-stamped active intake |
| `requirements/intakes/series/tinycalc-delivery/intake-review-request.json` | `7020241199793ab1d94575a7d1f804b27fd916c7cde8597adb22ee654876d042` | Pass; branch-stamped active-intake propagation / propagation of the branch-stamped active intake |
| `requirements/intakes/series/tinycalc-delivery/manifest.json` | `ef266cf99627d10a17282db966826fff26a0705ec1afca355eeb7c7079a25e72` | Pass; branch-stamped active-intake propagation / propagation of the branch-stamped active intake |
| `specs/002-constitution-change/spec.md` | `1f8196fab5ff0a2d0aba6fd59b58d6fbb24edca48dadc80f68437273f016ca65` | Pass; path-only Delivery-Remediation / delivery remediation |
| `specs/002-constitution-change/checklists/requirements.md` | `19e6a79a937f8a921602398813468aaf32e35a58f6325f6fbb83f1b014dea2ca` | Pass; whitespace-only Delivery-Remediation / delivery remediation |

`rg -n '^\| IR-[0-9]{3} \|' specs/002-constitution-change/spec.md` ergab
genau 16 eindeutige Zeilen. Nur `IR-004`, `IR-012`, `IR-013` und `IR-015`
sind `Applicable`. Die Suche
`rg -n '\[NEEDS[ ]CLARIFICATION:|\| .*\| Open \|'` über Spezifikation und
Requirements-Checkliste ergab keinen Treffer.

*The accepted hashes match. The specification contains exactly 16 unique
intake rows; only IR-004, IR-012, IR-013, and IR-015 are applicable, and no
unresolved marker exists.*

### T003 – Laufzustand und Gate-Vertrag / Run State and Gate Contract

```text
pwsh -NoProfile -File .specify/presets/autonomous-run-governance/scripts/validate-autonomous-run-state.ps1 -State specs/002-constitution-change/autonomous-run-state.json
Exitcode: 0
Standardausgabe: PASS: run d42bfa06-0a67-492e-968d-80309788b383, feature specs/002-constitution-change, stage Analyze, status Active, tasks 0/71
Standardfehler: leer (0 Byte)
```

Der zusätzliche strukturierte Abgleich gegen
`.specify/presets/autonomous-run-governance/templates/autonomous-run-gate-requirements-template.json`
bestand mit Exitcode 0: Schema `1.0`, fünf eindeutige Gate-IDs, nur
`Applicable` oder `N/A`, Pflicht-Tokens für anwendbare Gates sowie Begründung
und Wiedervorlage für `N/A` sind vollständig.

*The run-state validator and the structured gate-contract comparison passed
with clean error streams.*

### T004 – ausgelöste Validatoren / Triggered Validators

Die Abhängigkeitssuche über `.specify/`, `scripts/`, `.github/` und `tests/`
ergab die folgende verbindliche lokale Prüfliste:

| Prüfer / Validator | Trigger und Entscheidung / Trigger and decision |
|---|---|
| `validate-autonomous-phase-result.ps1` | T001 und finales Implement-Phasenresultat; ausgelöst / triggered |
| `validate-autonomous-run-state.ps1` | T003, T008 und T038; ausgelöst / triggered |
| `check-homogeneity.ps1` | Agentenflächen, Vorlagen, Sprache und A11Y; T028 ausgelöst / triggered |
| `render-project-statistics.ps1` | Statistikquelle und Markdown-Ausgabe; T037 ausgelöst / triggered |
| `scan-agent-secrets.ps1` | vollständiger lokaler Kandidat; T031 ausgelöst / triggered |
| `dotnet restore`, `dotnet build`, `dotnet test` | Paketgraph, CS1591 und Regression; T019, T020 und T032 ausgelöst / triggered |
| `dotnet list ... --outdated/--vulnerable` | Read-only Paketbefund; T022 ausgelöst / triggered |
| `cmp`- und `rg`-Matrizen | Constitution-Spiegel, Metadaten, Presets, TDD und XML; T010, T014, T016, T018 und T030 ausgelöst / triggered |
| DocFX, Playwright/axe und `lynx` | `N/A`: kein API-, XML-, Navigations- oder API-Präsentationspfad im geplanten Basisscope; Wiedervorlage T027 bei finalem Pfad-Trigger / re-evaluate at T027 |
| Autonomous delivery-set/gate-evidence validators | `N/A` in dieser Route: beginnen erst T039 beziehungsweise T053 und sind ausdrücklich gesperrt / start only at prohibited later tasks |
| Preset-/Autonomous-Regressionstests | `N/A`: keine Preset-, Schema-, Validator- oder Runtime-Semantik wird geändert; Wiedervorlage bei Scope-Drift / re-evaluate on scope drift |
| Cross-platform Skript-/Cmdlet-Parität | `N/A`: kein Skript, Cmdlet, Workflow oder Manpage wird geändert; Wiedervorlage bei Automationsänderung / re-evaluate on automation change |

### T005 – Ausgangszustand und Liefer-Allowlist / Initial State and Delivery Allow-list

Der Vorzustand war Branch `002-constitution-change`, kein tracked Diff und nur
die bereits erzeugten unversionierten Feature-/Routingartefakte unter
`.specify/feature.json`, `.specify/runtime/autonomous-routing/d42bfa06-0a67-492e-968d-80309788b383/`
und `specs/002-constitution-change/`. Die lokale Implementierungs-Allowlist
umfasst ausschließlich:

- beide Constitution-Dateien;
- fünf Agentenflächen, vier Projektvorlagen und vier Spec-Kit-Vorlagen;
- `Directory.Build.props`;
- `docs/security/README.md`, `docs/security/security-checklist.md`,
  `docs/accessibility/constitution-change.md`,
  `docs/PR_TEXT_CONSTITUTION_CHANGE.md`,
  `docs/project-statistics.config.json` und `docs/project-statistics.md`;
- `.specify/feature.json` sowie die bereits akzeptierten Feature-Artefakte in
  `specs/002-constitution-change/`, einschließlich beider Checklisten,
  Gate-Anforderungen, Laufstatus, Laufnachweis, Spec, Plan und Tasks.

`.codex/`, `.specify/runtime/`, Logs, SQLite-, History-, Credential- und
Secret-Dateien, `src/`, `tests/`, Paket-/Lock-, Workflow-, DocFX-, Review- und
Manifestdateien sowie der Folge-Intake sind ausgeschlossen. Die Runtime-Datei
des Phasenresultats ist ausschließlich Orchestratorausgabe und nie Teil des
Delivery-Satzes. T039–T071 sowie jede Git-/Remote-Mutation bleiben gesperrt.

*The branch and initial untracked paths were captured before feature edits.
Only the listed governance, evidence, version, statistics, and accepted feature
artifacts are allowed. Runtime files remain orchestrator-only and excluded from
delivery.*

### T006 – TDD und Coverage / TDD and Coverage

Status für Feature 002: `N/A`. T001–T038 ändern ausschließlich Governance,
Text, Evidenz und die vorgeschriebenen Versionsfelder; `src/` und `tests/`
bleiben unverändert. Deshalb gibt es heute weder einen ehrlichen roten
Produkttest noch Changed-Code-Coverage. Wiedervorlage: Jede künftige Funktion
oder Fehlerkorrektur benötigt vor der Umsetzung einen kompilierbaren,
beobachtbar roten Test, danach grüne Implementierung und abschließend
Regression/Aufräumen. Falls unerwartet Produktcode in Scope kommt, stoppt der
Lauf vor der Änderung und verlangt mindestens 70 Prozent Coverage mit Ziel 80
Prozent.

*TDD and changed-code coverage are N/A for this text-only feature. Any future
behaviour change reopens the red-green-refactor contract and the 70% minimum /
80% target coverage gate before implementation.*

### T007 – Level-2-Anwendbarkeit / Level-2 Applicability

| Standard oder Regel / Standard or rule | Status und Begründung / Status and rationale |
|---|---|
| NIST SSDF, CWE Top 25 | `Applicable`; Feature-Review in `docs/security/security-checklist.md` |
| C# als MSL und sichere C#-Entwicklung | `Applicable`; keine C#-Änderung, deshalb codebezogene Detailzeilen mit Wiedervorlage `N/A` |
| WCAG 2.2 AA, DE→EN, CEFR B2, text-first | `Applicable` auf geänderte Markdown- und Vorlagentexte |
| OWASP Cheat Sheets und Proactive Controls | `Applicable` als ergänzende Review-Hilfe |
| OWASP ASVS | `N/A`: keine Web-, API-, HTTP- oder Auth-Fläche; Wiedervorlage bei entsprechendem Dienst |
| SBOM, VEX, SLSA und OpenSSF Scorecard | `N/A`: keine Abhängigkeit, Release-Pipeline oder ausgelieferte Komponente ändert sich; Wiedervorlage bei Paket-, CVE-, Pipeline- oder Release-Trigger |
| AI-SBOM | `N/A`: KI ist Entwicklungswerkzeug, keine Produkt-/Runtime-Komponente; Wiedervorlage bei Modell, Datensatz oder Inferenzdienst im Produkt |
| STRIDE/CIA/CAPEC, S-ADR, arc42 und Security-Qualitätsszenarien | `N/A`: keine Trust Boundary, Architektur oder Datenflussänderung; Wiedervorlage bei externem Input, IO, Privileg oder Integration |
| Zero Trust | `N/A`: kein verteilter oder remote verwalteter Dienst |
| BSI C3A/C5 und Regulierung | `N/A`: kein Cloud-, Markt-, Finanz-ICT- oder Produkt-KI-Trigger |
| OWASP SAMM | `N/A`: dieses Feature ändert keinen Security-Prozess; Wiedervorlage bei Reifegrad-/Prozessänderung |
| Architektur sowie Skript-/Cmdlet-Parität | `N/A`: keine Runtime-, Schichten-, Skript-, Cmdlet-, Workflow- oder Manpage-Änderung |

*Every Level-2 standard is either applicable with an evidence path or N/A with
a concrete rationale and re-evaluation trigger. This table follows the accepted
specification and plan.*

### T008 – Vorimplementierungs-Checkpoint / Pre-implementation Checkpoint

Tasks und Laufzustand wurden serialisiert abgeglichen: 8 von 71 Aufgaben sind
tatsächlich abgeschlossen, der normalisierte `tasks.md`-Hash ist in beiden
State-Feldern
`79f6dda0deb43813ee9a319f0bf48e0f9d162ecf3f0471634d0260e96fd88cfb`,
Stage `Implement`, Status `Active`, nächster exakter Schritt T009. Der erneute
Validatorlauf bestand:

```text
PASS: run d42bfa06-0a67-492e-968d-80309788b383, feature specs/002-constitution-change, stage Implement, status Active, tasks 8/71
Exitcode: 0
Standardfehler: leer
```

*Tasks, readiness text, and state agree at the pre-implementation checkpoint.
No governance file was changed before T001–T007 evidence passed.*

## Governance- und TDD-Konvergenz T009–T017 / Governance and TDD Convergence T009–T017

### T009–T010 – Constitution und Spiegel / Constitution and Mirror

- Constitution-Version: `1.17.0`; Übergang im Sync Impact Report:
  `1.16.0 -> 1.17.0`.
- `Last Amended`: `2026-08-30`.
- Security-First bleibt unverändert `### I. Security-First (NON-NEGOTIABLE)`.
- Der neue Titel steht genau einmal und nur im TinyCalc-Level-2-Addendum.
- Die Acht-Preset-Matrix entspricht
  `scripts/config/spec-kit-governance-presets.json`: `0.6.2`, `0.5.2`,
  `0.2.2`, `0.4.3`, `0.2.2`, `0.4.2`, `0.4.1`, `0.2.6` bei den
  Prioritäten 10 bis 80.
- `cmp -s constitution.md .specify/memory/constitution.md` lieferte Exitcode 0.

*The version, amendment date, sync report, Principle I, addendum placement, and
executable preset matrix are correct. The two constitution files are
byte-identical.*

### T011–T014 – Agenten- und Vorlagenparität / Agent and Template Parity

Der serialisierte Regelsatz wurde in fünf Agentenflächen, vier
Projektvorlagen und vier Constitution-abhängige Spec-Kit-Vorlagen übertragen.
Die Copilot-Vorlage benennt ausdrücklich beide Ziele
`.github/copilot-instructions.md` und
`.github/agents/copilot-instructions.md`. Die vollständige `rg`-Matrix aus dem
Plan lieferte Exitcode 0, 63 Fundstellen und alle 15 Dateien. Ein zusätzlicher
strukturierter Check bestätigte in 15/15 Dateien Titel, DE→EN/CEFR B2,
text-first/WCAG 2.2 AA, `<summary>`, `<param>`, `<returns>`, `<exception>`,
CS1591, Warum-Kommentare, TDD, `N/A` und Coverage-Schwellen. Alle fünf
Agentenflächen enthalten jede aktuelle Preset-ID mit Version und Priorität.
Es gibt keine absichtliche agentenspezifische Abweichung und keinen Modellnamen
als Feature-Anforderung.

*All 15 propagated files passed the role-appropriate semantics matrix. All five
agent surfaces match the executable eight-preset source. There is no
intentional agent-specific deviation.*

### T015–T017 – sichtbarer TDD-Pfad und Scope-Schranke / Visible TDD Path and Scope Gate

`.specify/templates/tasks-template.md` verlangt für künftige Funktionen und
Fehlerkorrekturen konkrete rote Testdatei, Testname, Befehl und erwarteten
Fehler; danach die exakte grüne Implementierungsdatei und abschließend
Regression/Aufräumen. Bei Produktcode gelten mindestens 70 Prozent Coverage
und das Ziel 80 Prozent. Textarbeit benötigt begründetes `N/A`,
Wiedervorlage und den Nachweis unveränderter Produkt-/Testpfade.

Der vorgeschriebene `rg`-Abgleich über 13 TDD-relevante Flächen bestand mit
Exitcode 0; jede Datei enthält die geordnete Rot-/Grün-/Aufräum-Semantik,
`N/A`, `70` und `80`. `git diff --name-only -- src tests` und
`git ls-files --others --exclude-standard -- src tests` blieben leer. Damit
bleiben TDD und Changed-Code-Coverage für Feature 002 begründet `N/A`; kein
Replan-Trigger trat ein.

*The future task contract is exact and testable. Product and test paths remain
unchanged, so the current text-only TDD and changed-code coverage disposition
remains N/A without triggering re-planning.*

## Öffentliche XML-Inventur T018 / Public XML Inventory T018

Beide Produktprojekte setzen `GenerateDocumentationFile=true` und ergänzen
`CS1591` in `WarningsAsErrors`. Die Suche nach `NoWarn|CS1591` fand nur diese
beiden positiven `WarningsAsErrors`-Zeilen; eine globale Unterdrückung existiert
nicht.

Die Inventur umfasst jede im Quelltext ausdrücklich öffentliche Deklaration.
Bei positional records umfasst die benannte Deklarationszeile Typ,
Primärkonstruktor und erzeugte Eigenschaften; deren vom Compiler unterstützte
Dokumentation steht in den `<param>`-Elementen der Record-Deklaration.
Compilererzeugte Gleichheits-, Deconstruct- und implizite Konstruktor-Member
sowie `public`-Member in `internal` oder `private` Typen sind keine eigene
Quelltext-XML-Dokumentationsfläche. Deshalb sind insbesondere
`FormulaParseException`, `FormulaEvaluator.Parser`, die privaten
JSON-Dokumenttypen und `HelpDocument` begründet ausgeschlossen. Lokale
Variablen sind ebenfalls ausgeschlossen.

*Both product projects generate XML and treat CS1591 as an error without global
suppression. The inventory covers every explicitly public source declaration.
Positional record rows include their primary constructor and generated
properties through the compiler-supported `<param>` documentation. Generated
members and public members inside non-public types have no separate public
source-documentation target.*

Legende: `P` = Pass; `N/A-P` = keine Parameter; `N/A-R` = Typ, Eigenschaft,
Konstante oder `void`; `N/A-E` = keine direkt ausgelöste, fachlich deklarierte
Ausnahme. Allgemeine Laufzeit-/Dateisystemausnahmen sind kein eigener stabiler
Domänenvertrag. / Legend: `P` = pass; the `N/A` codes identify the exact
non-applicable element.

| Nr. | Öffentliche API / Public API | `<summary>` | `<param>` | `<returns>` | `<exception>` |
|---:|---|---|---|---|---|
| 1 | `Direction` | P | N/A-P | N/A-R | N/A-E |
| 2 | `Direction.Up` | P | N/A-P | N/A-R | N/A-E |
| 3 | `Direction.Down` | P | N/A-P | N/A-R | N/A-E |
| 4 | `Direction.Left` | P | N/A-P | N/A-R | N/A-E |
| 5 | `Direction.Right` | P | N/A-P | N/A-R | N/A-E |
| 6 | `EditResult` einschließlich Primärkonstruktor und `Success`, `Message`, `ErrorPosition` / including primary constructor and properties | P | P (3/3) | N/A-R | N/A-E |
| 7 | `RecalculateResult` einschließlich Primärkonstruktor und `Success`, `Errors` / including primary constructor and properties | P | P (2/2) | N/A-R | N/A-E |
| 8 | `RecalculateResult.Ok()` | P | N/A-P | P | N/A-E |
| 9 | `MicroCalcEngine` | P | N/A-P | N/A-R | N/A-E |
| 10 | `MicroCalcEngine.Sheet` | P | N/A-P | N/A-R | N/A-E |
| 11 | `MicroCalcEngine.AutoCalc` | P | N/A-P | N/A-R | N/A-E |
| 12 | `MicroCalcEngine.CurrentCell` | P | N/A-P | N/A-R | N/A-E |
| 13 | `MicroCalcEngine.Clear()` | P | N/A-P | N/A-R (`void`) | N/A-E |
| 14 | `MicroCalcEngine.SetAutoCalc(bool)` | P | P (1/1) | N/A-R (`void`) | N/A-E |
| 15 | `MicroCalcEngine.ToggleAutoCalc()` | P | N/A-P | N/A-R (`void`) | N/A-E |
| 16 | `MicroCalcEngine.EditCell(CellAddress, string)` | P | P (2/2) | P | N/A-E |
| 17 | `MicroCalcEngine.Recalculate()` | P | N/A-P | P | N/A-E |
| 18 | `MicroCalcEngine.FormatRange(char, int, int, int, int)` | P | P (5/5) | N/A-R (`void`) | P (`ArgumentOutOfRangeException`) |
| 19 | `MicroCalcEngine.Move(CellAddress, Direction)` | P | P (2/2) | P | N/A-E |
| 20 | `MicroCalcEngine.GetCellTypeText(CellAddress)` | P | P (1/1) | P | N/A-E |
| 21 | `MicroCalcEngine.RenderGridText()` | P | N/A-P | P | N/A-E |
| 22 | `MicroCalcEngine.GetStatusLine()` | P | N/A-P | P | N/A-E |
| 23 | `EvaluationResult` einschließlich Primärkonstruktor und fünf Eigenschaften / including primary constructor and five properties | P | P (5/5) | N/A-R | N/A-E |
| 24 | `EvaluationResult.Failed(string, int)` | P | P (2/2) | P | N/A-E |
| 25 | `EvaluationResult.Ok(double, bool)` | P | P (2/2) | P | N/A-E |
| 26 | `FormulaEvaluator` | P | N/A-P | N/A-R | N/A-E |
| 27 | `FormulaEvaluator.Evaluate(string, Spreadsheet)` | P | P (2/2) | P | N/A-E; Parsefehler werden als Ergebnis geliefert / parse failures are returned |
| 28 | `SpreadsheetJsonStorage` | P | N/A-P | N/A-R | N/A-E |
| 29 | `SpreadsheetJsonStorage.Save(string, MicroCalcEngine)` | P | P (2/2) | N/A-R (`void`) | N/A-E |
| 30 | `SpreadsheetJsonStorage.Load(string, MicroCalcEngine)` | P | P (2/2) | N/A-R (`void`) | P (`InvalidDataException`) |
| 31 | `SpreadsheetPrinter` | P | N/A-P | N/A-R | N/A-E |
| 32 | `SpreadsheetPrinter.ExportText(Spreadsheet, string, int)` | P | P (3/3) | N/A-R (`void`) | N/A-E |
| 33 | `Cell` | P | N/A-P | N/A-R | N/A-E |
| 34 | `Cell.Status` | P | N/A-P | N/A-R | N/A-E |
| 35 | `Cell.Contents` | P | N/A-P | N/A-R | N/A-E |
| 36 | `Cell.Value` | P | N/A-P | N/A-R | N/A-E |
| 37 | `Cell.Decimals` | P | N/A-P | N/A-R | N/A-E |
| 38 | `Cell.FieldWidth` | P | N/A-P | N/A-R | N/A-E |
| 39 | `Cell.Clone()` | P | N/A-P | P | N/A-E |
| 40 | `CellAddress` | P | N/A-P | N/A-R | N/A-E |
| 41 | `CellAddress(char, int)` | P | P (2/2) | N/A-R (Konstruktor / constructor) | P (`ArgumentOutOfRangeException`) |
| 42 | `CellAddress.Column` | P | N/A-P | N/A-R | N/A-E |
| 43 | `CellAddress.Row` | P | N/A-P | N/A-R | N/A-E |
| 44 | `CellAddress.ToString()` | P | N/A-P | P | N/A-E |
| 45 | `CellAddress.TryParse(string, out CellAddress)` | P | P (2/2) | P | N/A-E; Fehlschlag wird `false` / failure returns `false` |
| 46 | `CellStatusFlags` | P | N/A-P | N/A-R | N/A-E |
| 47 | `CellStatusFlags.None` | P | N/A-P | N/A-R | N/A-E |
| 48 | `CellStatusFlags.Constant` | P | N/A-P | N/A-R | N/A-E |
| 49 | `CellStatusFlags.Formula` | P | N/A-P | N/A-R | N/A-E |
| 50 | `CellStatusFlags.Text` | P | N/A-P | N/A-R | N/A-E |
| 51 | `CellStatusFlags.OverWritten` | P | N/A-P | N/A-R | N/A-E |
| 52 | `CellStatusFlags.Locked` | P | N/A-P | N/A-R | N/A-E |
| 53 | `CellStatusFlags.Calculated` | P | N/A-P | N/A-R | N/A-E |
| 54 | `Spreadsheet` | P | N/A-P | N/A-R | N/A-E |
| 55 | `Spreadsheet.Spreadsheet()` | P | N/A-P | N/A-R (Konstruktor / constructor) | N/A-E |
| 56 | `Spreadsheet.Reset()` | P | N/A-P | N/A-R (`void`) | N/A-E |
| 57 | `Spreadsheet.GetCell(CellAddress)` | P | P (1/1) | P | N/A-E |
| 58 | `Spreadsheet.GetCell(char, int)` | P | P (2/2) | P | N/A-E; Bereichsvalidierung gehört dem dokumentierten `CellAddress`-Vertrag / range validation belongs to the documented address contract |
| 59 | `Spreadsheet.AddressesRowMajor()` | P | N/A-P | P | N/A-E |
| 60 | `SpreadsheetSpec` | P | N/A-P | N/A-R | N/A-E |
| 61 | `SpreadsheetSpec.MinColumn` | P | N/A-P | N/A-R | N/A-E |
| 62 | `SpreadsheetSpec.MaxColumn` | P | N/A-P | N/A-R | N/A-E |
| 63 | `SpreadsheetSpec.RowCount` | P | N/A-P | N/A-R | N/A-E |
| 64 | `SpreadsheetSpec.ColumnCount` | P | N/A-P | N/A-R | N/A-E |
| 65 | `SpreadsheetSpec.DefaultDecimals` | P | N/A-P | N/A-R | N/A-E |
| 66 | `SpreadsheetSpec.DefaultFieldWidth` | P | N/A-P | N/A-R | N/A-E |
| 67 | `SpreadsheetSpec.CellInputLimit` | P | N/A-P | N/A-R | N/A-E |
| 68 | `SpreadsheetSpec.Columns()` | P | N/A-P | P | N/A-E |
| 69 | `SpreadsheetSpec.IsColumnInRange(char)` | P | P (1/1) | P | N/A-E |
| 70 | `SpreadsheetSpec.IsRowInRange(int)` | P | P (1/1) | P | N/A-E |
| 71 | `SpreadsheetSpec.ColumnToIndex(char)` | P | P (1/1) | P | P (`ArgumentOutOfRangeException`) |
| 72 | `SpreadsheetSpec.IndexToColumn(int)` | P | P (1/1) | P | P (`ArgumentOutOfRangeException`) |
| 73 | `SpreadsheetSpec.FormatNumber(Cell)` | P | P (1/1) | P | N/A-E |
| 74 | `TuiSmokeResult` einschließlich Primärkonstruktor und `Success`, `Errors` / including primary constructor and properties | P | P (2/2) | N/A-R | N/A-E |
| 75 | `TuiSmokeRunner` | P | N/A-P | N/A-R | N/A-E |
| 76 | `TuiSmokeRunner.Run(string, string?)` | P | P (2/2) | P | N/A-E; Ausnahmen werden in Fehlerzeilen umgewandelt / exceptions become error rows |

Ergebnis: 76/76 Quelltext-API-Zeilen besitzen `Pass` oder eine
elementbezogene `N/A`-Begründung. Es gibt keine XML-Lücke und deshalb keinen
T021-Replan-Trigger.

*Result: 76/76 source API rows have a pass or element-specific N/A. No XML gap
was found, so T021 does not trigger re-planning.*

## Restore und Build T019–T021 / Restore and Build T019–T021

### T019 – Restore

```text
dotnet restore MicroCalc.sln
Exitcode: 0
Standardausgabe:
  Wiederherzustellende Projekte werden ermittelt...
  Alle Projekte sind für die Wiederherstellung auf dem neuesten Stand.
Fehlerkanal: keine Fehlerausgabe
```

Der anschließende Pfadabgleich zeigte keine Änderung an `*.csproj`,
`*.props`, `*.targets`, `packages.lock.json` oder
`Directory.Packages.props`. Der akzeptierte Paketgraph blieb unverändert.

*Restore passed and reported every project up to date. No package, project, or
lock file changed.*

### T020 – Build-Zähler und Release-Build / Build Counter and Release Build

Unmittelbar vor dem Build wurden `Version`, `AssemblyVersion` und
`FileVersion` gemeinsam von `1.2.1.0` auf `1.2.1.1` erhöht. Der Minor-Wert
bleibt branchgebunden `2`, der Patch-Wert bleibt `1`, und Build wurde genau
einmal erhöht.

```text
dotnet build MicroCalc.sln --configuration Release --no-restore
Exitcode: 0
MicroCalc.Core: Pass
MicroCalc.Tui: Pass
MicroCalc.Core.Tests: Pass
MicroCalc.Tui.Tests: Pass
Warnungen: 0
Fehler: 0
Zeit: 00:00:01.73
```

*All four projects built successfully under version 1.2.1.1 with no warning or
error.*

### T021 – gemeinsame XML-Schranke / Combined XML Gate

Der Release-Build mit aktiver CS1591-Fehlerbehandlung und die vollständige
76/76-Elementinventur sind gemeinsam `Pass`. Es fehlt weder ein öffentlicher
`<summary>`-Kommentar noch ein fachlich anwendbares `<param>`, `<returns>` oder
`<exception>`. Keine Unterdrückung und keine Quelltextänderung waren nötig;
der Lauf bleibt `Active` und benötigt keine erneute Analyze-/Tasks-Konvergenz.

*The compiler gate and element-level inventory pass together. No suppression,
source edit, or re-planning trigger occurred.*

## Security und A11Y T022–T028 / Security and Accessibility T022–T028

### T022–T024 – Paket- und Security-Nachweis / Package and Security Evidence

Die beiden read-only Paketbefehle bestanden mit Exitcode 0. Der
Aktualitätscheck meldete verfügbare direkte und transitive Updates; Feature 002
ändert bewusst keine Paketdatei. Der Vulnerability-Check meldete für
`MicroCalc.Core`, `MicroCalc.Tui` und beide Testprojekte keine bekannten
verwundbaren Pakete und damit keinen kritischen CVE. Private Paketquellen wurden
nicht in Artefakte übernommen.

`docs/security/security-checklist.md` enthält Feature-ID, Phase,
Repository-Maintainer als Owner, Codex als namentlichen Reviewer, NIST-SSDF-
Gruppen, CWE-Top-25-Linse, OWASP-Hilfen, C#-MSL-/Secure-Coding-Dispositionen,
Paketbefunde, Restrisiken und Wiedervorlagen. Der Security-Index verweist auf
den lokalen Pass. Alle nicht ausgelösten Security-Dokumente blieben mit ihren
Vorzustands-Hashes unverändert; die Begründungen stehen in der Checkliste.

*Package currency findings are recorded without dependency changes. All four
projects report no known vulnerable package. The audit-ready checklist and
index are current, while non-triggered security artefacts remain unchanged.*

### T025–T026 – statischer A11Y-Review / Static Accessibility Review

`docs/accessibility/constitution-change.md` wurde aus der installierten
Evidenzstruktur erstellt. 19 geänderte lern-/nutzerseitige Markdown- und
Vorlagendateien bestanden den Überschriften-Sprungcheck. `git diff --check`
ist sauber. Neue Blöcke sind DE-zuerst/EN-danach auf CEFR B2, verwenden
sprachmarkierte `text`-Codeblöcke, enthalten keine Bilder und tragen keine
Information nur über Farbe, Layout oder Pointer. Die lineare Textreihenfolge
erklärt Status, Abhängigkeiten, Gates und nächste Schritte. Es bleibt kein
A11Y-Befund `Open`.

*All 19 changed learner-facing or user-facing Markdown/template files passed
the heading and whitespace review. New text is bilingual, text-first, and free
of colour-, layout-, image-, or pointer-only meaning. No accessibility finding
remains open.*

### T027 – DocFX-Trigger / DocFX Trigger

Die endgültige Pfadprüfung über `git diff --name-only` und die beabsichtigten
unversionierten Feature-Pfade fand keine API-/XML-, `docfx.json`-, Navigations-
oder API-Präsentationsänderung. DocFX, Playwright/axe und `lynx` sind gemeinsam
begründet `N/A`. Die späteren Delivery-/Statistiktexte können diesen Trigger
nicht verändern.

*No coupled DocFX/HTML accessibility trigger exists in the local delivery
paths. The full coupled check remains N/A with a future re-evaluation trigger.*

### T028 – Homogenität / Homogeneity

Der erste read-only Lauf fand nur einen vorbestehenden Drift des markierten
Profil-2-Blocks und änderte den Worktree nicht. Der kanonische `-WhatIf`-
Renderer lieferte den Ersatzblock, der mit `apply_patch` übernommen wurde; ein
anschließender normaler Renderer meldete `CURRENT`. Der bindende erneute Lauf:

```text
pwsh -NoProfile -File scripts/check-homogeneity.ps1 -TargetDir . -DryRun -NoPatch -Json
Exitcode: 0
JSON: {"score":100,"by_level":{"0":100,"1":0,"2":0},"failures":[],"warnings":[]}
Status-Hash vorher/nachher: 20dc9890a252af585a0e6dee5b833657c4fede627aeefc809d193bbeb564a61a
Arbeitsbaum unverändert: true
```

*The binding homogeneity rerun passed with score 100, no finding, and an
unchanged worktree status hash.*

## Liefertext und lokale Tests T029–T038 / Delivery Text and Local Tests T029–T038

### T029–T030 – PR-Text und vollständige Regelmatrix / PR Text and Full Rule Matrix

`docs/PR_TEXT_CONSTITUTION_CHANGE.md` enthält Deutsch zuerst und Englisch
danach: Problem, Lösung, alle Governance-/Vorlagenflächen, Risiken,
NIST-SSDF-/CWE-Review, A11Y, Testplan, 76/76-CS1591-Ergebnis,
DocFX-`N/A`, Versionsschema, Delivery-/Admin-Bypass-Grenze und Evidenzpfade.
Es wurde kein PR erstellt oder geändert.

Der exakte Regelbefehl aus dem Plan sowie Spiegel-, Metadaten- und
Preset-Abgleich ergaben:

```text
RULE_MATRIX_EXIT=0
RULE_MATRIX_MATCHES=63
RULE_MATRIX_FILES=15
MIRROR_EXIT=0
PRESET_MATRIX_PASS=8
AGENT_SURFACES_PASS=5
Constitution: 1.17.0; Last Amended: 2026-08-30
Security-First: Principle I
```

*The bilingual delivery text is complete without opening a PR. All 15 rule
surfaces, both mirrors, five agent surfaces, and eight preset entries pass.*

### T031 – Secret-Scan

```text
pwsh -NoProfile -File scripts/scan-agent-secrets.ps1 -WorkspaceRoot . -FailOnHigh
Exitcode: 0
OK: Keine Secrets im aktuellen Git-Diff gefunden.
OK: Keine Secrets in git-getrackten Dateien gefunden.
Fehlerkanal: keine Fehlerausgabe
```

Kein High-Fund liegt vor. Runtime, `.codex/` und private lokale Paketquellen
bleiben außerhalb des Delivery-Satzes und werden in keiner Evidenz gespeichert.

*The explicit-root scan passes with no high finding. Sensitive runtime and
machine-local sources remain outside delivery and evidence.*

### T032 – Versionszähler und xUnit

Unmittelbar vor `dotnet test` wurden alle drei Versionsfelder genau einmal von
`1.2.1.1` auf `1.2.1.2` erhöht. Der bindende Lauf:

```text
dotnet test MicroCalc.sln --configuration Release --no-build
Exitcode: 0
MicroCalc.Core.Tests: 76 bestanden, 0 fehlgeschlagen, 0 übersprungen
MicroCalc.Tui.Tests: 3 bestanden, 0 fehlgeschlagen, 0 übersprungen
Gesamt: 79 bestanden
```

*All 79 xUnit tests pass under the required next repository version counter.*

### T033 – TUI-Smoke

```text
dotnet run --no-build --configuration Release --project src/MicroCalc.Tui/MicroCalc.Tui.csproj -- --smoke
Exitcode: 0
Ausgabe: SMOKE_OK
```

### T034 – Coverage-Entscheid / Coverage Decision

`git diff --name-only -- src tests` und
`git ls-files --others --exclude-standard -- src tests` blieben erneut leer.
Changed-Code-Coverage bleibt deshalb begründet `N/A`; kein zusätzlicher
Coverage-Test und kein weiterer Build-Zähler sind ausgelöst. Wiedervorlage bei
jeder Produktcodeänderung: mindestens 70 Prozent, Ziel 80 Prozent.

*Product and test paths remain unchanged. Coverage stays N/A without another
test or build-counter increment; any future product-code change reopens the
70% minimum and 80% target.*

### T035–T038 – gemeinsamer Evidenzabgleich / Shared Evidence Reconciliation

Dieser Laufnachweis, Security, A11Y, Statistik und PR-Text stimmen mit den
lokalen Ergebnissen überein. Der Statistik-Check meldet `CURRENT`, der Run-State
`Validate`, `Active` und 38/71; Checklisten stehen auf 20/20 und 10/14. Keine
Datei behauptet Git-, Remote-, Merge- oder PostMerge-Fakten. T039 ist nächster
exakter Schritt und benötigt eine getrennte Delivery-Autoritätsprüfung.

*All local evidence agrees: statistics are current, state is active at 38/71,
and checklists are 20/20 and 10/14. No future delivery fact is claimed. T039
is next only after separate delivery-authority revalidation.*

### T039–T041 – Delivery-Set und erste Commit-Version / Delivery Set and First Commit Version

Der read-only Validator bestand mit 20 geänderten tracked Dateien und 11
ausdrücklich beabsichtigten unversionierten Dateien. Es gibt keine fremde
unversionierte Datei; `.specify/runtime/` bleibt lokal ausgeschlossen. Der
Index-Baum blieb `dc31dd9820f2f1f11d8cc8bf74b6e5eec9ea47e4`.

*The read-only validator passed with 20 changed tracked files and 11 explicitly
intended untracked files. No unrelated untracked path exists, runtime evidence
remains local, and the index tree stayed unchanged.*

Vor dem ersten Commit ist `main..HEAD=0`; deshalb ist der vorausberechnete
Patch-Wert `1`. `Version`, `AssemblyVersion` und `FileVersion` stehen gemeinsam
auf `1.2.1.2`: Major 1, Minor 2, Patch 1, Build 2.

*Before the first commit, `main..HEAD=0`, so the predicted patch is 1. All three
version fields are aligned at `1.2.1.2`.*

Der zweite read-only Lauf bestand ebenfalls. Danach wurden genau die 31 vom
Validator bestätigten Pfade gestaged. `git diff --cached --check` war leer und
`git status --short` zeigte weder einen unstaged noch einen fremden Pfad. Der
Kandidaten-Vorgänger ist `72d5766daca7206e90b9998ca77bb769b9d9218a`.

*The second read-only pass also succeeded. Exactly 31 validator-approved paths
were staged, the cached whitespace check was clean, and no unstaged or unrelated
path remained. The candidate predecessor is the recorded full commit ID.*

Der erste Feature-Commit ist
`1870af18ea3af37f1c4322b6e4d4ff5354731823`. Er enthält genau die 31
validierten Pfade und den verpflichtenden Co-author-Trailer. Der folgende
Polish-Commit wurde auf Patch 2 ausgerichtet und enthielt nur Version,
Run-State-Pfad und die zunächst inhaltsgleiche branchgestempelte Intake-Datei.
Die anschließende CI-Remediation änderte ausschließlich drei Selbstpfade der
aktivierten Prompts und regenerierte die davon abhängige aktive
Intake-Governance; Scope und Authority blieben unverändert.

*The first feature commit is the recorded full object ID. It contains exactly
the 31 validated paths and the mandatory co-author trailer. The following
polish commit was aligned to patch 2 and initially contained only version,
run-state path, and the content-identical branch-stamped intake. The following
CI remediation changes only the three enabled-prompt self-paths and regenerates
their derived active intake governance; scope and authority remain unchanged.*

Das Statistikprofil schließt nun zusätzlich `Directory.Build.props` und seine
eigene Konfigurationsdatei aus. Damit beeinflussen rein mechanische
Versionsfortschreibungen und Statistik-Metadaten die fachliche Lieferdichte
nicht mehr und erzeugen keinen selbstreferenziellen Render-Zyklus.

*The statistics profile now also excludes `Directory.Build.props` and its own
configuration file. Purely mechanical version increments and statistics
metadata therefore no longer distort delivery density or create a
self-referential render cycle.*

## Autorisierter Remote-Abschluss / Authorized Remote Closeout

- Feature-Head: `e726128fcca1717989d72a269c8d6f7a67846d96`
- Pull Request: `#57`, `https://github.com/hindermath/TinyCalc/pull/57`
- CI: 19 von 19 Checks erfolgreich; Build/Test-Run `33280429437`, Ubuntu-Job
  `99174565736`, 79 von 79 Tests erfolgreich
- Review: Claude-Review-Check erfolgreich; keine Review-Kommentare, keine
  Inline-Threads und keine Change Request. GitHub meldete nur die formale
  `REVIEW_REQUIRED`-Repository-Regel.
- Admin-Bypass: von Thorsten für `MergeAndSync` ausdrücklich autorisiert und
  ausschließlich auf diese formale Review-/Ruleset-Grenze angewendet; kein
  technisches, Security-, A11Y-, Exact-Head- oder Evidenzgate wurde umgangen.
- PreMerge-Snapshot: Schema 2.0, Hash
  `a85e64cb58c6f8a847083e87a7e43d6f4619e78626995f66c5badfcdcbfb8647`
- Merge: `gh pr merge 57 --merge --delete-branch --admin`, bestätigt am
  `2026-08-29T23:15:58Z`, Merge-Commit
  `bb884ca8ceb59a1a9aeff76a0e97f5f1d5fe4064`
- PostMerge-Snapshot: Schema 2.0, Hash
  `4b1d470f1809272cce1927f3666dcfd737c7619079b6c64bbe44d1bbc15a8b05`
- Bereinigung und Sync: Remote- und lokaler Feature-Branch entfernt; lokaler
  und entfernter `main` identisch mit dem Merge-Commit
- DocFX/HTML-A11Y: `N/A`, weil der gemergte Satz keine API-, XML-, DocFX-
  Navigations- oder API-Präsentationsänderung enthält
- ASVS, Zero Trust, VEX und AI-SBOM: `N/A` gemäß Feature-Scope; NIST SSDF,
  CWE Top 25, C#-Secure-Coding, WCAG 2.2 AA und Supply-Chain-Prüfung bestanden
- Nachfolge-Intake: vor diesem Closeout weder gestartet noch fortgeschrieben

*PR #57 merged the exact reviewed head after all 19 checks passed. The explicit
admin bypass covered only GitHub's formal review/ruleset boundary. Both schema
2.0 snapshots validate and bind the reviewed head to the actual merge commit;
no technical, security, accessibility, or evidence gate was bypassed. Local and
remote main are synchronized, feature branches are cleaned up, and no successor
intake was started before this closeout.*
