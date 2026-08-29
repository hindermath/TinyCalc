# Aufgaben: Constitution-Abgleich / Tasks: Constitution Alignment

**Eingabe / Input**: `specs/002-constitution-change/spec.md` und der geprüfte
`specs/002-constitution-change/plan.md`

**Branch / Branch**: `002-constitution-change`

**Autonomer Lauf / Autonomous run**: `d42bfa06-0a67-492e-968d-80309788b383`

**Liefermodus / Delivery mode**: `MergeAndSync` mit ausdrücklich autorisierter,
eng begrenzter Admin-Bypass-Grenze / with an explicitly authorized, narrow
admin-bypass boundary

## Aufgabenformat und Ausführungsregeln / Task Format and Execution Rules

- Format: `[ID] [Story?] Beschreibung mit exakten Dateien und Nachweisen / Description with exact files and evidence`.
- Die Reihenfolge `T001` bis `T071` ist verbindlich. Es gibt keine `[P]`-Aufgaben:
  Constitution, Agentenflächen, Vorlagen, Laufstatus, Evidenz, Version und
  Statistik sind gemeinsame Writer und werden vollständig serialisiert. / The
  order from `T001` through `T071` is mandatory. There are no parallel tasks;
  all shared writers are serialized.
- Diese Tasks-Phase erzeugt nur diese Datei und ihr maschinenlesbares
  Phasenresultat. Implementierung, Git- und Remote-Aktionen beginnen erst in der
  dafür autorisierten Implementierungs- beziehungsweise Delivery-Phase. / This
  tasks phase creates only this file and its machine-readable phase result.
- Ein Task ist nur abgeschlossen, wenn der genannte Befehl beziehungsweise die
  Prüfung erfolgreich war und der genannte Evidenzpfad das Ergebnis enthält.
  `N/A` benötigt immer Begründung und Wiedervorlage; `Open` benötigt Owner,
  Folgeschritt und Auslöser. / A task completes only with successful named proof
  at the exact evidence path. `N/A` and `Open` require the declared rationale.

## Phase 1: Eingangsgates und Vorimplementierungsnachweis / Entry Gates and Pre-implementation Evidence

**Zweck / Purpose**: Akzeptierte Artefakte, Scope, Runner-Vertrag und alle
bedingten Prüfpfade vor der ersten fachlichen Änderung einfrieren. / Freeze the
accepted artefacts, scope, runner contract, and conditional gates before the
first implementation edit.

- [x] T001 Validieren, dass `.specify/runtime/autonomous-routing/d42bfa06-0a67-492e-968d-80309788b383/plan-review.result.json` mit `pwsh -NoProfile -File .specify/presets/autonomous-run-governance/scripts/validate-autonomous-phase-result.ps1 -Repo . -Result .specify/runtime/autonomous-routing/d42bfa06-0a67-492e-968d-80309788b383/plan-review.result.json -PhaseId plan-review -ExitCode 0` den Status `Completed` und den zum Phasenabschluss gebundenen Plan-Hash liefert; der aktuelle Plan-Hash `d293164136765a24a9b14cd9c2325be208fafdf9ee251c77151a22d6ba750a1f` unterscheidet sich ausschließlich durch die dokumentierte whitespace-only Delivery-Remediation der gebundenen Spec-/Checklisten-Hashes. Befehl, Exitcode, Standardausgabe und sauberer Fehlerkanal stehen in `specs/002-constitution-change/autonomous-run-evidence.md`. / Validate the phase-bound review hash and document the current plan hash as a whitespace-only delivery remediation.
- [x] T002 Die sechs akzeptierten Dateien aus `specs/002-constitution-change/plan.md` mit `shasum -a 256` prüfen und zusätzlich mit `rg -n '^\| IR-[0-9]{3} \|' specs/002-constitution-change/spec.md` genau 16 eindeutige Intake-Zeilen, nur `IR-004`, `IR-012`, `IR-013`, `IR-015` als `Applicable` sowie keine `NEEDS CLARIFICATION`-/`Open`-Markierung belegen; Ergebnisse nach `specs/002-constitution-change/autonomous-run-evidence.md`. / Re-prove all accepted hashes, classifications, and absence of unresolved markers in the run evidence.
- [x] T003 `specs/002-constitution-change/autonomous-run-state.json` mit `pwsh -NoProfile -File .specify/presets/autonomous-run-governance/scripts/validate-autonomous-run-state.ps1 -State specs/002-constitution-change/autonomous-run-state.json` prüfen und `specs/002-constitution-change/autonomous-run-gate-requirements.json` gegen `.specify/presets/autonomous-run-governance/templates/autonomous-run-gate-requirements-template.json` auf Schema 1.0, eindeutige Gate-IDs, `Applicable`-/`N/A`-Grenzen, Command-/Runner-Tokens, Begründungen und Wiedervorlagen prüfen; Nachweis in `specs/002-constitution-change/autonomous-run-evidence.md`. / Validate run state and the pre-existing gate-requirements contract before implementation.
- [x] T004 Mit `rg` alle ausführbaren Validatoren ermitteln, die einen geplanten Pfad, Marker, Schemawert oder Status aus `constitution.md`, `.specify/memory/constitution.md`, den fünf Agentenflächen, den sechs Vorlagen, `docs/security/`, `docs/accessibility/`, `docs/project-statistics*`, `Directory.Build.props` oder `specs/002-constitution-change/` lesen; die verbindliche Prüfliste und jeden begründeten Nicht-Trigger nach `specs/002-constitution-change/autonomous-run-evidence.md` schreiben. / Search executable validator dependencies before treating the work as documentation-only and record every triggered or justified non-triggered validator.
- [x] T005 Den Vorzustand mit `git status --short --branch`, der aktuellen Branch-Identität und einer ausdrücklichen Liefer-Allowlist erfassen; `.codex/`, `.specify/runtime/`, Logs, SQLite-/History-/Credential-Dateien, fremde Änderungen und der nicht gestartete Folge-Intake bleiben ausgeschlossen. Die Allowlist und erkannte fremde/unversionierte Pfade in `specs/002-constitution-change/autonomous-run-evidence.md` dokumentieren. / Capture the initial worktree and exact delivery allow-list without staging or mutation.
- [x] T006 In `specs/002-constitution-change/autonomous-run-evidence.md` die aktuelle TDD-Entscheidung als `N/A` belegen: Diese Änderung ist ausschließlich Governance/Text und ändert weder `src/` noch Verhalten. Gleichzeitig die Wiedervorlage festhalten, dass jede künftige Funktion oder Fehlerkorrektur vor der Umsetzung einen kompilierbaren, beobachtbar roten Test, danach Grün-Evidenz und abschließend Regression/Aufräumen benötigt. Coverage ist aktuell ebenfalls `N/A`; bei unerwartetem Produktcode gelten mindestens 70 % und das 80-%-Ziel. / Record the current text-only TDD and changed-code coverage N/A while binding future red-green-refactor evidence.
- [x] T007 In `specs/002-constitution-change/autonomous-run-evidence.md` die Level-2-Anwendbarkeit vor Implementierung festhalten: NIST SSDF, CWE Top 25, C#-MSL/Secure Coding und WCAG 2.2 AA sind `Applicable`; OWASP ASVS, SBOM/VEX/SLSA, AI-SBOM, STRIDE/CAPEC, S-ADR/arc42, Zero Trust, BSI C3A/C5, SAMM, Regulierung, Architektur- und Skript-/Cmdlet-Parität sind mit den Triggern aus `spec.md`/`plan.md` begründet `N/A`. / Record every applicable standard and every exact N/A rationale before implementation.
- [x] T008 `specs/002-constitution-change/checklists/autonomous-readiness.md` und `specs/002-constitution-change/autonomous-run-state.json` serialisiert auf den Vorimplementierungs-Checkpoint setzen: Tasks/Analyze müssen konvergiert, der exakte nächste Schritt muss T009 sein, Task-Gesamtzahl und aktueller Checkbox-Stand müssen mit `tasks.md` übereinstimmen; danach Run-State erneut validieren. / Advance readiness and machine state only after all entry evidence passes, with task counts matching this file.

**Checkpoint / Checkpoint**: Keine fachliche Datei wurde vor vollständiger
Vorimplementierungsevidenz geändert. / No feature file changed before complete
pre-implementation evidence.

---

## Phase 2: User Story 1 – Einheitliche Lernregeln / Consistent Learning Rules (Priorität / Priority: P1)

**Ziel / Goal**: Der kanonische TinyCalc-Regelsatz ist verständlich,
zweisprachig und auf allen verbindlichen Einstiegen semantisch gleich. / The
canonical TinyCalc rules are understandable, bilingual, and semantically equal
at every binding entry point.

**Unabhängiger Test / Independent test**: Security-First bleibt Prinzip I;
Spiegel, Agentenflächen und Vorlagen enthalten Titel, DE→EN, CEFR B2,
text-first A11Y, anwendbare öffentliche XML-Dokumentation und den TDD-Vertrag.

- [x] T009 [US1] `constitution.md` ausschließlich im TinyCalc-Level-2-Addendum um „Didaktische und sprachliche Klarheit / Pedagogical and Linguistic Clarity“ ergänzen: DE zuerst/EN danach, CEFR B2, text-first/WCAG 2.2 AA, vollständige anwendbare öffentliche XML-Dokumentation, keine XML-Dokumentation für lokale Variablen, moderate zweisprachige Warum-Kommentare und künftiges Rot→Grün→Aufräumen; Security-First-Prinzip I und die gemeinsame Home-Baseline unverändert lassen. Wegen des neuen Abschnitts Constitution-Version `1.16.0` → `1.17.0`, `Last Amended` auf den Liefertermin und Sync Impact Report vollständig aktualisieren sowie die Acht-Preset-Matrix ausdrücklich auf `0.6.2`, `0.5.2`, `0.2.2`, `0.4.3`, `0.2.2`, `0.4.2`, `0.4.1`, `0.2.6` aus `scripts/config/spec-kit-governance-presets.json` setzen. Danach denselben vollständigen Inhalt im selben serialisierten Task bytegleich nach `.specify/memory/constitution.md` übertragen. / Add the scoped canonical rule, update semantic metadata, sync report, and both constitution preset matrices from the executable source, then copy the complete result byte-identically.
- [x] T010 [US1] Das Spiegelpaar mit `cmp -s constitution.md .specify/memory/constitution.md` prüfen und mit `rg -n` belegen, dass Security-First weiter Prinzip I ist und der neue Titel nur im TinyCalc-Addendum steht; Exitcode und Fundstellen nach `specs/002-constitution-change/autonomous-run-evidence.md`. / Prove byte identity, preserved Principle I, and correct addendum placement.
- [x] T011 [US1] Den vollständigen gemeinsamen Regelsatz in einem serialisierten Writer über `AGENTS.md`, `CLAUDE.md`, `GEMINI.md`, `.github/copilot-instructions.md` und `.github/agents/copilot-instructions.md` synchronisieren; dabei auch die dort veralteten acht Preset-Versionen exakt an `scripts/config/spec-kit-governance-presets.json` (`0.6.2`, `0.5.2`, `0.2.2`, `0.4.3`, `0.2.2`, `0.4.2`, `0.4.1`, `0.2.6`) angleichen. Keine agentenspezifische Abweichung und keinen Modellnamen als Feature-Anforderung einführen. / Synchronize all five maintained agent surfaces atomically, including the exact executable eight-preset matrix.
- [x] T012 [US1] Danach, nicht parallel zu T011, dieselbe Regel in `scripts/templates/AGENTS.md.tmpl`, `scripts/templates/CLAUDE.md.tmpl`, `scripts/templates/GEMINI.md.tmpl` und `scripts/templates/copilot-instructions.tmpl` synchronisieren; belegen, dass die Copilot-Vorlage beide Zieloberflächen vollständig versorgt. / Synchronize the four project agent templates as the next serialized writer.
- [x] T013 [US1] `.specify/templates/constitution-template.md`, `.specify/templates/plan-template.md`, `.specify/templates/spec-template.md` und `.specify/templates/tasks-template.md` um die jeweils anwendbare, providerneutrale didaktische, sprachliche, XML- und TDD-Evidenzregel ergänzen; bestehende Security-, Architektur-, MSL-, A11Y- und Agentenparitätsvorgaben nicht abschwächen. / Propagate the new constitution section to every constitution-dependent Spec Kit template with role-appropriate semantics.
- [x] T014 [US1] Mit einer expliziten `rg`-Matrix über beide Constitution-Dateien, alle fünf Agentenflächen, vier Projektvorlagen und alle vier Spec-Kit-Vorlagen Titel, DE→EN/CEFR B2, text-first, anwendbare XML-/CS1591-Regel, Warum-Kommentare und TDD prüfen. Zusätzlich Constitution-Version, `Last Amended`, Sync Impact Report und jede Preset-Version gegen `scripts/config/spec-kit-governance-presets.json` abgleichen; jede Datei muss die für ihre Rolle vollständige Semantik enthalten. Fundstellen und „keine absichtliche Abweichung“ im Laufnachweis referenzieren. / Run the full semantic, metadata, and executable-preset parity matrix.

**Checkpoint / Checkpoint**: US1 ist unabhängig prüfbar; die normative
Governance ist synchron, ohne Produkt- oder Architekturänderung. / US1 is
independently verifiable with no product or architecture change.

---

## Phase 3: User Story 3 – Sichtbarer TDD-Lernweg / Visible TDD Learning Path (Priorität / Priority: P2)

**Ziel / Goal**: Reine Textarbeit ist ehrlich `N/A`; künftige
Verhaltensänderungen erhalten einen verpflichtenden Rot-Grün-Aufräumen-Pfad. /
Text-only work is honestly N/A while future behaviour changes require a visible
red-green-refactor path.

**Unabhängiger Test / Independent test**: Jede betroffene Governance-Fläche
fordert beobachtbare Rot-, Grün- und Regression/Aufräum-Evidenz oder eine
begründete, erneut zu prüfende `N/A`-Entscheidung.

- [x] T015 [US3] `.specify/templates/tasks-template.md` so ändern, dass jede künftige Funktion oder Fehlerkorrektur konkrete Testdatei, erwarteten roten Fehler, grüne Implementierungsdatei und abschließende Regression/Aufräum-Evidenz vorgeben muss; reine Governance-/Textarbeit darf nur mit Begründung und Wiedervorlage `N/A` sein. Die Mindestabdeckung 70 % und das Ziel 80 % müssen bei geändertem Produktcode als explizite Gates erhalten bleiben. / Make the tasks template require exact future red-green-refactor and triggered coverage evidence.
- [x] T016 [US3] Über `constitution.md`, `.specify/memory/constitution.md`, die fünf Agentenflächen, vier Projektvorlagen, `.specify/templates/constitution-template.md` und `.specify/templates/tasks-template.md` mit `rg -n 'Rot.*Grün.*Aufräumen|red.*green.*refactor|N/A|70|80'` die vollständige TDD-/Coverage-Semantik prüfen; die aktuelle Text-only-`N/A`-Entscheidung und den künftigen Trigger in `specs/002-constitution-change/autonomous-run-evidence.md` bestätigen. / Prove the complete TDD contract across all affected surfaces.
- [x] T017 [US3] Prüfen, dass `src/` und `tests/` im Delivery-Satz unverändert sind. Falls die Prüfung eine Produktlogikänderung zeigt, nicht weiterarbeiten: Run-State `NeedsRevalidation` setzen und vor jeder Codeänderung konkrete RED-Test-, GREEN-Implementierungs- und REFACTOR-/Coverage-Aufgaben durch erneute Analyze-/Tasks-Konvergenz ergänzen. / Hard-stop and re-plan if the text-only assumption drifts into product logic.

**Checkpoint / Checkpoint**: US3 ist unabhängig durch die Governance- und
Tasks-Vorlagenprüfung belegt. / US3 is independently evidenced by the governance
and tasks-template checks.

---

## Phase 4: User Story 2 – Öffentliche XML-Dokumentationsschranke / Public XML Documentation Gate (Priorität / Priority: P1)

**Ziel / Goal**: Die bestehende CS1591-Schranke bleibt aktiv und vollständig,
ohne eine zweite Implementierung zu erzeugen. / Preserve the existing CS1591
gate without duplicating it.

**Unabhängiger Test / Independent test**: Beide Produktprojekte erzeugen XML,
behandeln CS1591 als Fehler und bestehen den Release-Build ohne globale
Unterdrückung.

- [x] T018 [US2] Mit `rg -n '<GenerateDocumentationFile>true</GenerateDocumentationFile>|<WarningsAsErrors>.*CS1591' src/MicroCalc.Core/MicroCalc.Core.csproj src/MicroCalc.Tui/MicroCalc.Tui.csproj` beide Produktgates und mit `rg -n 'NoWarn|CS1591' Directory.Build.props src tests` das Fehlen einer globalen CS1591-Unterdrückung prüfen. Zusätzlich alle öffentlichen Typen und Mitglieder in `src/MicroCalc.Core` und `src/MicroCalc.Tui` inventarisieren und jede Signatur manuell gegen `<summary>`, fachlich anwendbare `<param>`, `<returns>` und `<exception>` prüfen; jede API-Zeile erhält `Pass` oder ein elementbezogen begründetes `N/A`, lokale Variablen bleiben ausgeschlossen. Vollständige Inventur in `specs/002-constitution-change/autonomous-run-evidence.md`. / Prove both compiler gates and perform a complete public-API XML element inventory rather than relying on CS1591 alone.
- [x] T019 [US2] `dotnet restore MicroCalc.sln` ausführen und Exitcode, Standardausgabe und Fehlerkanal in `specs/002-constitution-change/autonomous-run-evidence.md` dokumentieren; Restore darf keine Paketdatei oder Abhängigkeit ändern. / Restore the accepted dependency graph without changing package state.
- [x] T020 [US2] Unmittelbar vor dem Release-Build den `Build`-Teil in `Directory.Build.props` genau einmal erhöhen und `Version`, `AssemblyVersion`, `FileVersion` bytegleich nach `Major.2.Patch.Build` halten; dann `dotnet build MicroCalc.sln --configuration Release --no-restore` ausführen und Versionsübergang sowie Buildausgabe im Laufnachweis festhalten. / Serialize the required build-counter increment immediately before the Release build.
- [x] T021 [US2] Build und T018-Inventur gemeinsam als harte Dokumentationsschranke auswerten: Exitcode 0 genügt nur zusammen mit vollständigen `Pass`-/`N/A`-Zeilen für alle öffentlichen APIs. Bei einer CS1591- oder Elementlücke den Lauf vor jeder Quelltextänderung auf `NeedsRevalidation` setzen und die exakt betroffene `src/.../*.cs`-Datei mit anwendbaren `<summary>`, `<param>`, `<returns>` und `<exception>`-Aufgaben durch erneute Analyze-/Tasks-Konvergenz aufnehmen; niemals CS1591 unterdrücken. / Require both compiler and complete applicable-element inventory evidence.

**Checkpoint / Checkpoint**: US2 ist unabhängig durch statische Konfiguration
und erfolgreichen Release-Build belegt. / US2 is independently proven by static
configuration and the Release build.

---

## Phase 5: Security-, A11Y- und Dokumentationsevidenz / Security, Accessibility, and Documentation Evidence

**Zweck / Purpose**: Anwendbare Level-2-Nachweise vollständig ausfüllen und
jeden Nicht-Trigger explizit begründen. / Complete applicable Level-2 evidence
and justify every non-trigger.

- [x] T022 `dotnet list MicroCalc.sln package --outdated --include-transitive` und `dotnet list MicroCalc.sln package --vulnerable --include-transitive` read-only ausführen; Ergebnisse, Exitcodes und die Schranke „kein kritischer CVE“ in `docs/security/security-checklist.md` erfassen. Keine Paket-, Projekt- oder Lock-Datei ändern; ein kritischer Fund blockiert Delivery und erhält Owner sowie getrennten Sicherheits-Folgeschritt. / Record read-only currency and vulnerability results without package changes.
- [x] T023 `docs/security/security-checklist.md` als Feature-002-Nachweis mit Feature-ID, Phase, Owner, namentlich bestimmtem Reviewer, NIST-SSDF-Gruppen, CWE-Top-25-Linse, OWASP Cheat Sheets/Proactive Controls, C#-MSL/Secure-Coding-Prüfung, Package-Befunden, Restrisiken und Wiedervorlagen ausfüllen; nicht anwendbare Code-, Auth-, SQL-, Krypto-, IO- und Architekturpunkte begründet `N/A` markieren. / Complete the audit-ready security checklist with owner, reviewer, applicable controls, N/A rationale, and residual risk.
- [x] T024 `docs/security/README.md` serialisiert auf den neuen Feature-002-Status und den Pfad `docs/security/security-checklist.md` aktualisieren; `docs/security/threat-model.md`, `docs/security/dependency-audit.md`, `docs/security/arc42-security.md`, `docs/security/security-quality-scenarios.md`, `docs/security/adr/`, `docs/security/asvs-verification.md`, `docs/security/supply-chain-evidence.md`, `docs/security/zero-trust-applicability.md` und `docs/security/samm-assessment.md` unverändert lassen und ihre Nicht-Trigger in der Checkliste belegen. / Update only the security index and checklist; prove why all other security evidence remains unchanged.
- [x] T025 `docs/accessibility/constitution-change.md` aus `.specify/templates/a11y-evidence-template.md` erstellen und WCAG 2.2 AA soweit auf statische Texte anwendbar, semantische Überschriften, DE-zuerst/EN-danach, CEFR B2, Erklärungen bei erster Fachbegriff-Nutzung, deutsche Orthografie, Codeblock-Sprach-Tags, Textalternativen sowie Braille-, Screenreader- und Textbrowser-Tauglichkeit prüfen. / Create the exact static-document accessibility evidence from the installed template.
- [x] T026 Alle geänderten lern- und nutzerseitigen Markdown-/Vorlagendateien manuell gegen `docs/accessibility/constitution-change.md` prüfen; Status, Reihenfolge, Abhängigkeiten, Gates und nächste Aktionen müssen vollständig aus Text verständlich sein und dürfen nicht von Farbe, Layout oder Pointer-Interaktion abhängen. Befunde schließen oder mit Owner/Trigger als `Open` blockieren. / Perform the complete text-first and bilingual review; unresolved findings block progress.
- [x] T027 Den endgültigen Änderungssatz mit `git diff --name-only` und `git ls-files --others --exclude-standard` auf API-Signaturen, XML-Kommentare, `docfx.json`, DocFX-Navigation und API-Präsentation prüfen. Beim Basisscope in `docs/accessibility/constitution-change.md` und `specs/002-constitution-change/autonomous-run-evidence.md` begründet `N/A` dokumentieren. Bei Trigger vor Fortsetzung gemeinsam `docfx docfx.json`, einen repräsentativen Playwright/axe-Smoke und `lynx -dump -nolist _site/index.html` erfolgreich ausführen; kein Teilnachweis gilt als Pass. / Re-evaluate the DocFX trigger against the final paths and either record exact N/A or complete all coupled HTML checks.
- [x] T028 Mit `pwsh -NoProfile -File scripts/check-homogeneity.ps1 -TargetDir . -DryRun -NoPatch -Json` die statische A11Y-/Sprach- und Homogenitätsevidenz ergänzen; Exitcode 0, JSON-Ausgabe und unveränderter Arbeitsbaum sind Pflicht und werden in `docs/accessibility/constitution-change.md` sowie `specs/002-constitution-change/autonomous-run-evidence.md` referenziert. / Run the existing non-mutating homogeneity proof and bind it to accessibility evidence.

**Checkpoint / Checkpoint**: Security und A11Y sind auditfähig; jede nicht
geänderte Evidenzdatei besitzt eine dokumentierte Begründung und Wiedervorlage.

---

## Phase 6: Liefertext, Statistik und lokale Konvergenz / Delivery Text, Statistics, and Local Convergence

**Zweck / Purpose**: Den vollständigen lokalen Kandidaten dokumentieren,
testen und statistisch aus der kanonischen Quelle rendern. / Document, test,
and render statistics for the complete local candidate.

- [x] T029 `docs/PR_TEXT_CONSTITUTION_CHANGE.md` zweisprachig (DE zuerst, EN danach) mit Problem, Lösung, betroffenen Governance-/Template-Flächen, Risiken, NIST-SSDF-/CWE-Review, A11Y, Testplan, CS1591-Ergebnis, DocFX-Entscheid, Versionsschema, Delivery-/Admin-Bypass-Grenze und allen Evidence-Pfaden erstellen. / Create the complete bilingual PR description before any PR is opened.
- [x] T030 Die vollständige Regelmatrix mit dem exakten `rg`-Befehl aus `specs/002-constitution-change/plan.md` über beide Constitution-Dateien, fünf Agentenflächen, vier Projektvorlagen und vier Spec-Kit-Vorlagen ausführen; außerdem `cmp -s`, Constitution-Metadaten und die Acht-Preset-Matrix erneut prüfen. Jede fehlende Datei, alte Version oder Semantik blockiert; Ergebnis nach `docs/PR_TEXT_CONSTITUTION_CHANGE.md` und `specs/002-constitution-change/autonomous-run-evidence.md`. / Re-run mirror, semantic, metadata, and preset parity over the complete propagated set.
- [x] T031 `pwsh -NoProfile -File scripts/scan-agent-secrets.ps1 -WorkspaceRoot . -FailOnHigh` mit explizitem Repository-Root ausführen; Exitcode 0, erforderliche Ausgabe, sauberer Fehlerkanal und keine High-Funde nach `specs/002-constitution-change/autonomous-run-evidence.md`. / Run the explicit-root secret gate and fail on any high finding.
- [x] T032 Unmittelbar vor `dotnet test` den `Build`-Teil in `Directory.Build.props` erneut genau einmal erhöhen und alle drei Versionsfelder synchron halten; dann `dotnet test MicroCalc.sln --configuration Release --no-build` ausführen und alle Core-/TUI-xUnit-Ergebnisse in `specs/002-constitution-change/autonomous-run-evidence.md` festhalten. / Increment the build counter immediately before the full xUnit suite and record all results.
- [x] T033 `dotnet run --no-build --configuration Release --project src/MicroCalc.Tui/MicroCalc.Tui.csproj -- --smoke` ausführen; Exitcode 0 und Ausgabe nach `specs/002-constitution-change/autonomous-run-evidence.md`. / Run and record the non-interactive TUI smoke gate.
- [x] T034 Den Changed-Code-Coverage-Entscheid erneut prüfen: Solange `src/`/`tests/` unverändert sind, das bestehende `N/A` mit Trigger bestätigen. Falls Produktcode durch T017/T021 autorisiert in Scope kam, unmittelbar vor `dotnet test MicroCalc.sln --configuration Release --collect:"XPlat Code Coverage"` den Build-Zähler erneut erhöhen und mindestens 70 % sowie das 80-%-Ziel in `specs/002-constitution-change/autonomous-run-evidence.md` belegen; Unterschreitung blockiert. / Reconfirm coverage N/A or run the triggered 70% minimum/80% target gate with its own version increment.
- [x] T035 `specs/002-constitution-change/autonomous-run-evidence.md`, `docs/security/security-checklist.md`, `docs/accessibility/constitution-change.md` und `docs/PR_TEXT_CONSTITUTION_CHANGE.md` als letzten gemeinsamen Evidenz-Writer serialisiert auf tatsächlich ausgeführte Befehle, Plattformen, Exitcodes, Outputs, N/A-Entscheidungen, Reviewer, Restrisiken und nächste Grenzen abgleichen; keine vorgreifende Merge- oder PostMerge-Behauptung eintragen. / Finalize all local evidence without claiming future remote facts.
- [x] T036 Die beobachteten Nettozeilen des nun vollständigen lokalen Änderungssatzes nach Produktions-, Test- und Dokumentationszeilen ermitteln und genau einen stabilen Phase-002-Slot in `docs/project-statistics.config.json` ergänzen; Arbeitsfenster, Arbeitspakete, 80-/125-Zeilen-Baselines, 7,8 Stunden und 21,5 Arbeitstage/Monat verwenden und die Beschleunigung ausdrücklich als blended repository speedup/Lieferdichte kennzeichnen. / Add exactly one canonical Phase-002 statistics source entry using observed values and binding baselines.
- [x] T037 Direkt nach T036 `pwsh -NoProfile -File scripts/render-project-statistics.ps1 -Repo .` und danach `pwsh -NoProfile -File scripts/render-project-statistics.ps1 -Repo . -CheckOnly -Json` ausführen; `docs/project-statistics.md` muss genau einen neuen chronologisch letzten Fortschreibungsprotokoll-Eintrag und aktualisierte text-first ASCII-Trends enthalten, während `## Gesamtstatistik / Overall Statistics` der letzte Top-Level-Abschnitt bleibt. / Render and check the statistics output from its JSON source.
- [x] T038 Die Checklisten in `specs/002-constitution-change/checklists/requirements.md` und `specs/002-constitution-change/checklists/autonomous-readiness.md` gegen alle lokalen Nachweise prüfen und nur tatsächlich erfüllte Punkte markieren; `specs/002-constitution-change/autonomous-run-state.json` auf den letzten lokalen Pass, exakten nächsten Schritt T039, aktuelle Task-Zahlen und noch ausstehende Remote-Grenzen setzen und erneut validieren. / Reconcile checklists and run state with actual local evidence; remote items remain pending.

**Checkpoint / Checkpoint**: Der lokale Kandidat ist vollständig, getestet,
dokumentiert und statistisch konsistent; Remote-Fakten bleiben ausdrücklich
offen. / The local candidate is complete and validated while remote facts remain
explicitly pending.

---

## Phase 7: Delivery-Set, Versionierung und exakter Commit-Kandidat / Delivery Set, Versioning, and Exact Commit Candidate

**Zweck / Purpose**: Die unveränderliche beabsichtigte Liefermenge vor jeder
Git-Schreibaktion beweisen und nur diese Dateien stagen. / Prove the intended
delivery set before every Git write and stage only those paths.

- [x] T039 Mit `pwsh -NoProfile -File .specify/presets/autonomous-run-governance/scripts/validate-autonomous-delivery-set.ps1 -Repo . -Intended <jede beabsichtigte unversionierte Datei>` alle geänderten tracked Dateien und jede beabsichtigte unversionierte Datei aus der T005-Allowlist read-only prüfen; JSON-Ausgabe nach `.specify/runtime/autonomous-routing/d42bfa06-0a67-492e-968d-80309788b383/delivery-set.json` schreiben. Der Validator muss Index/Arbeitsbaum unverändert lassen, unerwartete unversionierte Pfade melden und Runtime-Logs, `.codex` sowie fremde Änderungen ausschließen. / Validate every intended untracked path explicitly and persist the read-only result at the exact runtime path.
- [x] T040 `.specify/runtime/autonomous-routing/d42bfa06-0a67-492e-968d-80309788b383/delivery-set.json` gegen den vollständigen geplanten Änderungssatz aus `plan.md` prüfen, einschließlich `.specify/feature.json`, Run-State, Gate-Anforderungen und beider Feature-Checklisten. `src/`, `tests/`, Paket-/Workflow-/DocFX-/Review-/Manifest-Dateien müssen unverändert sein; der erst in T044 autorisierte branchgestempelte Intake-Rename ist die einzige Intake-Ausnahme. Jeder andere unerwartete Pfad setzt den Run-State auf `NeedsRevalidation`. / Reconcile every planned feature artefact and allow only the later exact intake rename exception.
- [x] T041 Unmittelbar vor dem ersten Feature-Commit die Version serialisiert ausrichten: `Minor=2`, `Patch=git rev-list --count main..HEAD + 1`, `Build` bleibt der letzte manuelle Zähler; alle drei Felder müssen identisch sein. Die Herleitung und den geplanten zweiten Rename-Commit in `specs/002-constitution-change/autonomous-run-evidence.md` festhalten. / Align all three version fields to the predicted first feature commit and record the later final rename boundary.
- [x] T042 Nach T041 den Delivery-Set-Validator aus T039 erneut ausführen und sein JSON atomar ersetzen; anschließend nur die darin bestätigten beabsichtigten Pfade explizit mit `git add -- <path...>` stagen, `git diff --cached --check` ausführen und `git diff --cached --name-only` exakt mit `git status --short` und der Allowlist abgleichen. Fremde Index-/Arbeitsbaumänderungen bleiben unangetastet; Nachweis nach `specs/002-constitution-change/autonomous-run-evidence.md`. / Revalidate, stage only the exact candidate, and prove the cached path inventory and whitespace gate.
- [x] T043 Vor der Commit-Grenze `specs/002-constitution-change/autonomous-run-state.json` auf aktuelle Autorität, exakten Candidate-Head-Vorgänger, Delivery-Set-Hash und nächsten Schritt T044 setzen; den State validieren und prüfen, dass kein Stop/Pause vorliegt. / Bind the machine state to the validated candidate before committing.
- [ ] T044 Einen fokussierten Conventional-Commit für Feature 002 mit dem verpflichtenden Trailer `Co-authored-by: Copilot <223556219+Copilot@users.noreply.github.com>` erstellen, ohne Amend fremder Historie und ohne Runtime-Evidence. Danach bei sauberem Index die drei Versionsfelder auf `Patch=git rev-list --count main..HEAD + 1` erhöhen und im Run-State ausschließlich den akzeptierten Intake-Pfad auf `requirements/intakes/active/Lastenheft_Constitution_Change.002-constitution-change.md` bei identischem SHA-256 umstellen; beide Änderungen stagen. `pwsh -NoProfile -File scripts/rename-lastenheft.ps1 -File requirements/intakes/active/Lastenheft_Constitution_Change.md -BranchName 002-constitution-change` erzeugt den verfassungsmäßigen letzten Polish-Commit. Er darf nur Versionsfelder, Run-State-Pfad und den branchgestempelten inhaltsgleichen Intake enthalten. Für beide Commits prüfen, dass finaler Commitcount, Patch-Wert und validierte Liefermenge übereinstimmen; beide IDs erfassen. / Create the feature commit, then the separate version-aligned rename commit that also updates the accepted run-state path atomically.
- [ ] T045 Direkt vor Push Branch, exakten Commit-Head, sauberen Kandidaten, drei identische Versionsfelder und fortbestehende aktuelle `MergeAndSync`-Autorität erneut prüfen; Drift oder Autoritätsverlust blockiert und setzt `NeedsRevalidation`. / Revalidate exact head, version, candidate cleanliness, and current authority immediately before push.

**Checkpoint / Checkpoint**: Der exakte lokale Commit ist versionsrichtig und
entspricht bytegenau der validierten Liefermenge. / The exact local commit is
version-correct and matches the validated delivery set.

---

## Phase 8: Autorisiertes Publish und Review-Konvergenz / Authorized Publish and Review Convergence

**Zweck / Purpose**: Den exakten Kandidaten veröffentlichen und technische
Checks sowie Reviews für denselben Head konvergieren. / Publish the exact
candidate and converge checks and reviews for that same head.

- [ ] T046 Den Branch `002-constitution-change` mit der authentifizierten `gh`-/Git-CLI zum konfigurierten Origin pushen; Remote-Branch und exakten Remote-Head gegen T044 prüfen und Provider-/Run-IDs in `specs/002-constitution-change/autonomous-run-evidence.md` beziehungsweise im Runtime-State erfassen. Kein Force-Push. / Push the exact authorized branch without force and verify the remote head.
- [ ] T047 Den Pull Request nach `main` mit `docs/PR_TEXT_CONSTITUTION_CHANGE.md` erstellen oder aktualisieren; PR-Nummer, URL, Base/Head, Mergeability und aktuellen Head mit `gh pr view --json` erfassen. Einen fremden PR weder verändern noch schließen. / Create or update the focused PR and record immutable identifiers.
- [ ] T048 Mit `gh pr checks` und `gh run view` alle erforderlichen Checks für den exakten PR-Head abwarten und pro Gate Workflow, Job, unveränderliche Run-ID, tatsächliche Plattform/Runner und aus Definition oder Log abgeleiteten ausgeführten Befehl erfassen; grüne Namen allein sind keine Evidenz. Die Zuordnung für `SPEC-GATE-001` bis `SPEC-GATE-005` in der temporären Runtime-Arbeitsgrundlage für T053 vorbereiten. / Converge exact-head checks and capture actual commands and platforms, not display names.
- [ ] T049 Reviews und Threads mit `gh pr view`/`gh api` prüfen: keine aktuelle Change Request, kein handlungsrelevanter Thread und alle erforderlichen Reviewer vorhanden. Nicht verfügbare Reviewer gelten als fehlend. Technische oder Review-Lücken blockieren und dürfen nicht durch Admin-Bypass ersetzt werden. / Converge reviews and actionable threads without treating absence as approval.
- [ ] T050 Die Homogenitätsprüfung auf Ubuntu, macOS und Windows als eigenständige CI-Evidenz außerhalb von `SPEC-GATE-004` erfassen. `SPEC-GATE-004` erhält genau eine Primary-Zeile aus dem tatsächlichen Ubuntu-`dotnet test`-Job mit den Tokens `dotnet`, `test` und `ubuntu`; keine macOS-/Windows-Homogenitätszeile wird als Supplemental dieses Gates ausgegeben. Fehlende Plattform- oder Command-Evidenz blockiert weiterhin ihr jeweiliges Gate. / Keep three-platform homogeneity evidence separate and map SPEC-GATE-004 to exactly one truthful Ubuntu dotnet-test Primary row.
- [ ] T051 Unmittelbar vor der Merge-Evidence aktuelle Nutzerautorität für `MergeAndSync` und den konkret benannten PR erneut prüfen. Für einen möglichen Admin-Bypass Autorisierer, konkrete Policy, Umfang, Grund und Restrisiko im Runtime-Nachweis erfassen; Bypass bleibt auf Berechtigung/Ruleset begrenzt und darf keine fachliche, Security-, A11Y-, Review- oder Exact-Head-Lücke überdecken. / Revalidate the explicit merge and narrow bypass authority for the concrete PR.
- [ ] T052 Den Run-State an der Review-Grenze mit exaktem PR-Head, Check-/Review-Status, nächstem Schritt T053 und letztem Passing Gate aktualisieren und validieren; eine Unterbrechung ohne vertrauenswürdiges Ergebnis wird `NeedsRevalidation`, ein Nutzerstopp `PausedByUser` am sicheren Grenzpunkt. / Persist the review boundary and safe stop/resume semantics.

**Checkpoint / Checkpoint**: Checks, Plattformnachweise und Reviews sind für
denselben unveränderten Head konvergiert. / Checks, platform proof, and reviews
have converged for one unchanged head.

---

## Phase 9: Temporäre Schema-2.0-PreMerge-Evidenz und Merge / Temporary Schema-2.0 PreMerge Evidence and Merge

**Zweck / Purpose**: Alle akzeptierten Gates an den exakt geprüften Head binden
und erst danach die autorisierte Merge-Grenze betreten. / Bind every accepted
gate to the exact reviewed head before entering the merge boundary.

- [ ] T053 Aus `.specify/presets/autonomous-run-governance/templates/autonomous-run-gate-evidence-template.json` die temporäre Datei `.specify/runtime/autonomous-routing/d42bfa06-0a67-492e-968d-80309788b383/premerge-gate-evidence.json` als Schema 2.0/`PreMerge` erzeugen: neuer UUID-Snapshot, UTC-Zeit, normalisierter Hash von `specs/002-constitution-change/autonomous-run-gate-requirements.json`, vollständiger T044/T048-Head, leere Merge-/AcceptedPreMerge-Felder, tatsächliche `changedPaths`, je Gate genau eine Primary-Zeile und nur zugeordnete Supplemental-Zeilen mit tatsächlichen Commands, Plattformen, Run-IDs und unveränderlichen Referenzen. / Create the exact temporary provider-neutral PreMerge snapshot from the installed template.
- [ ] T054 Die PreMerge-Datei mit `pwsh -NoProfile -File .specify/presets/autonomous-run-governance/scripts/validate-autonomous-gate-evidence.ps1 -Requirements specs/002-constitution-change/autonomous-run-gate-requirements.json -Evidence .specify/runtime/autonomous-routing/d42bfa06-0a67-492e-968d-80309788b383/premerge-gate-evidence.json -Head <vollständiger-geprüfter-head>` validieren; fehlende/duplizierte Primary-Zeilen, veralteter Head, widersprüchliche N/A-Werte, Token-Mismatch oder unzugeordnetes Supplemental blockieren. Validatorausgabe und normalisierten PreMerge-Hash im Runtime-State erfassen. / Validate complete gate coverage and retain the normalized PreMerge hash.
- [ ] T055 Nach T054 erneut belegen, dass lokaler Head, Remote-PR-Head und `reviewedHead` identisch sind, alle Checks/Reviews weiterhin aktuell sind und `premerge-gate-evidence.json` uncommitted/temporär bleibt. Jede Änderung invalidiert den Snapshot und verlangt T048–T054 erneut. / Re-prove exact-head immutability and keep PreMerge evidence temporary.
- [ ] T056 Die konkrete Merge-Methode gegen Repository-Policy prüfen und den PR mit `gh pr merge <PR> --merge --delete-branch` mergen; nur wenn genau die in T051 autorisierte Policy den Merge sonst blockiert und alle technischen/Review-Gates vollständig sind, `gh pr merge <PR> --merge --delete-branch --admin` verwenden. Tatsächlichen Befehl, Bypass-Entscheid, Providerantwort und Merge-Commit im Runtime-Nachweis erfassen. / Perform the policy-compliant merge, using the narrow authorized admin flag only at this exact boundary and never as evidence substitution.
- [ ] T057 Unmittelbar nach Providerbestätigung mit `gh pr view <PR> --json state,mergedAt,mergeCommit,headRefOid,baseRefName` den tatsächlichen Merge-Commit und den gemergten Kandidaten-Head prüfen; ein unbekannter, falscher oder nicht terminaler Zustand wird nicht als Pass interpretiert. / Verify the actual merge commit and merged candidate immediately after the provider operation.

**Checkpoint / Checkpoint**: Der Merge ist kausal auf validierte PreMerge-
Evidenz und aktuelle Autorität zurückführbar. / The merge is causally bound to
validated PreMerge evidence and current authority.

---

## Phase 10: PostMerge, Branch-Bereinigung, Main-Sync und Abschluss / PostMerge, Branch Cleanup, Main Sync, and Closeout

**Zweck / Purpose**: Den tatsächlichen Merge kausal belegen, Branches bereinigen,
`main` fast-forward synchronisieren und den Lauf erst nach finaler Prüfung
abschließen. / Causally prove the merge, clean branches, fast-forward `main`,
and complete only after final validation.

- [ ] T058 Aus derselben installierten Vorlage `.specify/runtime/autonomous-routing/d42bfa06-0a67-492e-968d-80309788b383/postmerge-gate-evidence.json` als getrennten Schema-2.0-`PostMerge`-Snapshot erzeugen: neuer UUID/UTC-Zeitpunkt, derselbe Requirements-Hash und `reviewedHead`, `acceptedPreMergePath` auf die temporäre PreMerge-Datei, `acceptedPreMergeSha256` auf deren normalisierten T054-Hash, `mergeCommit` auf T057 und `changedPaths: []`; nur kausal neue Providerfakten ergänzen. / Create the separate causal PostMerge snapshot with no product delta.
- [ ] T059 PostMerge mit `pwsh -NoProfile -File .specify/presets/autonomous-run-governance/scripts/validate-autonomous-gate-evidence.ps1 -Requirements specs/002-constitution-change/autonomous-run-gate-requirements.json -Evidence .specify/runtime/autonomous-routing/d42bfa06-0a67-492e-968d-80309788b383/postmerge-gate-evidence.json -Head <vollständiger-geprüfter-feature-head> -MergeCommit <tatsächlicher-merge-commit>` validieren; akzeptierter PreMerge-Hash, tatsächlicher Merge-Commit und leere Restdifferenz müssen bestehen. / Validate the causal PostMerge binding and empty remaining delta.
- [ ] T060 Prüfen, dass der Remote-Feature-Branch durch den autorisierten Merge gelöscht wurde; falls nicht, nur den exakt gemergten Remote-Branch `002-constitution-change` löschen. Keine andere Branch- oder Providerressource verändern. Ergebnis mit `git ls-remote --heads origin 002-constitution-change` belegen. / Confirm or perform narrow remote feature-branch cleanup only after merge proof.
- [ ] T061 Zum lokalen `main` wechseln, `git fetch origin main` ausführen und ausschließlich per `git merge --ff-only origin/main` synchronisieren; kein Rebase, Force oder nicht-fast-forward Merge. Danach `git rev-parse main`, `git rev-parse origin/main` und T057-Merge-Commit abgleichen. / Fast-forward local main to the remote default branch and prove exact synchronization.
- [ ] T062 Erst nach erfolgreichem T061 den vollständig gemergten lokalen Branch `002-constitution-change` löschen; vor der Löschung mit `git branch --merged main` seine Merge-Zugehörigkeit prüfen. Keine ungemergte oder fremde Branch löschen. / Delete only the proven merged local feature branch.
- [ ] T063 Auf synchronisiertem `main` die finalen read-only Gates ausführen: sauberer `git status --short`, identische lokale/remote Main-SHAs, PR `MERGED`, PostMerge-Validator weiterhin erfolgreich, erwartete Feature-Dateien im Merge-Commit, keine Runtime-Datei im Commit und keine gestartete/fortgeschriebene spätere Intake-Serie. Ergebnisse in der temporären Runtime-Evidenz sammeln. / Run final read-only repository, provider, PostMerge, and series-boundary validation on synchronized main.
- [ ] T064 Falls tracked Run-State/Evidenz nach dem ersten Merge sonst falsche Pending-Werte behalten, vom nach T061 synchronisierten `main` ausdrücklich den vorbenannten Branch `002-constitution-change-closeout` erstellen und nur `specs/002-constitution-change/autonomous-run-state.json`, `specs/002-constitution-change/autonomous-run-evidence.md` und `specs/002-constitution-change/checklists/autonomous-readiness.md` terminal aktualisieren. Der Closeout ist evidence-only und single-commit-capable; keine Produkt-, Governance-, Paket-, Workflow- oder nächste-Feature-Änderung. Ist kein tracked Delta nötig, `N/A` in Runtime-Evidence dokumentieren und keinen leeren Branch/PR erzeugen. / Create the pre-named isolated closeout branch from synchronized main only when terminal tracked evidence truly requires a delta.
- [ ] T065 Falls T064 einen echten Closeout-Diff erzeugt, vor Commit/Push erneut `Minor=2`, vorausberechneten Patch-Commitcount und alle drei identischen Felder prüfen, den Delivery-Set-Validator ausführen, nur die drei Evidence-/State-Pfade plus Version stagen, `git diff --cached --check` bestehen und mit dem verpflichtenden `Co-authored-by: Copilot <223556219+Copilot@users.noreply.github.com>`-Trailer committen. Den Branch pushen und den evidence-only PR mit aktuellen Checks/Reviews nach derselben eng begrenzten `MergeAndSync`-Policy mergen; danach `main` erneut per Fast-forward synchronisieren und Closeout-Branches bereinigen. / If needed, deliver the isolated closeout through the full versioned exact-candidate path with the mandatory trailer.
- [ ] T066 Den finalen Run-State mit `stage`/`status` terminal, `mergeOrPublication`, `defaultBranchSync`, `postMergeActions` und `finalValidation` jeweils `Completed`, leerem Stop-Grund, letztem Passing Gate, exakter nächster Aktion „none“ und Checkbox-Zahlen aus `tasks.md` validieren; der installierte Run-State-Validator muss Exitcode 0 liefern. Wenn T064/T065 `N/A` war, dieselben terminalen Fakten bleiben im nicht versionierten Orchestrator-State und werden dort validiert. / Validate every schema-1.1 terminal closeout field and authoritative task count.
- [ ] T067 Den finalen Dokumentationsentscheid erneut prüfen: Basisscope `N/A` für DocFX bleibt nur gültig, wenn der gemergte Delivery-Satz keinen API/XML/Navigation/Presentation-Trigger enthält; andernfalls müssen DocFX, Playwright/axe und `lynx` aus demselben finalen Head erfolgreich belegt sein. / Revalidate the DocFX disposition against the actually merged set.
- [ ] T068 Die finale Security-/A11Y-/Version-/Statistikbilanz read-only prüfen: keine kritischen CVEs/High-Secrets, NIST SSDF/CWE abgeschlossen, beide Constitution-Dateien bytegleich, fünf Agentenflächen/vier Projektvorlagen/vier Spec-Kit-Vorlagen semantisch vollständig, drei Versionsfelder identisch, genau ein Phase-002-Statistikeintrag und Gesamtstatistik letzter Top-Level-Abschnitt. / Run the final cross-artifact closeout audit.
- [ ] T069 Task- und Artefaktzählung aus `specs/002-constitution-change/tasks.md`, alle bewusst übersprungenen Bedingungen mit `N/A`, Review-/Check-Zustand, Remote-IDs, Feature-/Merge-/gegebenenfalls Closeout-Commit, PreMerge-/PostMerge-Hashes, Branch-Bereinigung und lokale/remote Main-Synchronität in der terminalen Runtime-Evidenz zusammenfassen. / Summarize exact counts, skips, identifiers, hashes, cleanup, and synchronization.
- [ ] T070 Read-only belegen, dass das vor T041 geprüfte bindende Lastenheft nach T044 als `requirements/intakes/active/Lastenheft_Constitution_Change.002-constitution-change.md` denselben akzeptierten SHA-256 besitzt, der bereits im Rename-Commit aktualisierte Run-State genau diesen Pfad führt, Review-Ergebnis, Review-Anfrage und Serienmanifest unverändert bleiben und kein Next-/Update-/Start-Befehl für den folgenden Intake ausgeführt wurde. T070 erzeugt keinen tracked Delta; nur ein späterer getrennt autorisierter Serienentscheid darf fortfahren. / Read-only prove the already atomic content-identical rename, accepted path, unchanged review/series evidence, and no successor start.
- [ ] T071 Erst wenn T001–T070 und alle ausgelösten Gates belegt sind, den autonomen Lauf als `Completed` melden; andernfalls `Blocked` oder `NeedsRevalidation` mit genauer Ursache, Owner, nächstem Schritt und Wiedervorlage verwenden. Keine Retrospektive, kein nächstes Feature und keine weitere Remote-Aktion implizit starten. / Report Completed only after every task and gate is evidenced; never infer the next feature or extra authority.

**Finaler Checkpoint / Final checkpoint**: Feature 002 ist nur dann vollständig,
wenn lokaler und entfernter `main` synchron sind, die kausale PostMerge-Evidenz
gültig ist, Branches sicher bereinigt sind und alle terminalen Run-State-Gates
`Completed` melden. / Feature 002 is complete only with synchronized default
branches, valid causal PostMerge evidence, safe cleanup, and terminal run-state
gates.

---

## Abhängigkeiten und feste Ausführungsreihenfolge / Dependencies and Fixed Execution Order

```text
Phase 1: T001-T008  Eingang und Vorimplementierung / Entry and pre-implementation
    -> Phase 2: T009-T014  US1 kanonische Governance und Parität / canonical governance
        -> Phase 3: T015-T017  US3 TDD-Vertrag / TDD contract
            -> Phase 4: T018-T021  US2 XML-/CS1591-Schranke / XML gate
                -> Phase 5: T022-T028  Security und A11Y
                    -> Phase 6: T029-T038  lokale Konvergenz und Statistik
                        -> Phase 7: T039-T045  Delivery-Set, Version, Kandidat
                            -> Phase 8: T046-T052  Publish und Review
                                -> Phase 9: T053-T057  PreMerge und Merge
                                    -> Phase 10: T058-T071  PostMerge und Abschluss
```

- US1 muss vor US3 abgeschlossen sein, weil die gemeinsamen Governance-Writer
  nur einmal und serialisiert geändert werden. US3 prüft seinen TDD-Anteil
  danach unabhängig. / US1 precedes US3 because shared governance writers are
  edited once; US3 then verifies its TDD slice independently.
- US2 hängt von den finalen Governance-Regeln ab, verändert aber im Basisscope
  keinen Produktcode. Ein CS1591- oder Produktcode-Trigger stoppt und verlangt
  neue exakte Aufgaben. / US2 changes no product code in the baseline; a trigger
  forces exact re-planning.
- Version, Laufstatus, Laufnachweis, Agentenflächen, Vorlagen und Statistik
  besitzen jeweils nur einen aktiven Writer. / Each shared mutable artefact has
  one active writer.
- PreMerge bleibt temporär und darf den geprüften Head nicht selbst ändern.
  PostMerge entsteht erst kausal nach dem tatsächlichen Merge. / PreMerge stays
  temporary; PostMerge is created only after the actual merge.

## Abnahmekriterien der Aufgabenphase / Tasks-phase Acceptance Criteria

- Alle vier `Applicable`-Intake-Punkte sind durch konkrete Tasks abgedeckt;
  `AlreadySatisfied`, `N/A` und `FollowUp` erzeugen keine versteckte Umsetzung.
- Jede Aufgabe nennt exakte Dateien, Befehle oder Evidenz und besitzt eine
  objektive Pass-/Blockiergrenze.
- Der aktuelle text-only TDD-/Coverage-Status ist begründet `N/A`; der künftige
  Rot-Grün-Aufräumen-Vertrag ist verbindlich und testbar.
- Pre-implementation, lokale Validierung, Versionierung, Delivery-Set,
  PreMerge, enger Admin-Bypass, PostMerge, Branch-Cleanup, Main-Sync und finale
  Validierung stehen in der erforderlichen Reihenfolge.
- Diese Tasks-Phase hat keine Implementierung und keine Git-/Remote-Aktion
  ausgeführt.
