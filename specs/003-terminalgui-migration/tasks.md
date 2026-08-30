# Aufgaben / Tasks: Terminal.Gui-2.x-Migration

**Eingabe / Input**: Akzeptierte Artefakte unter `specs/003-terminalgui-migration/`, insbesondere `spec.md`, der remediierte `plan.md`, alle Planungs-Sidecars, `checklists/plan-review.md` und die 48 Anforderungen in `autonomous-run-gate-requirements.json`.
**Branch / Branch**: `003-terminalgui-migration`
**Autonomer Lauf / Autonomous run**: `38ad4c1d-bf85-4053-b585-eb490176b727`
**Liefermodus / Delivery mode**: `MergeAndSync`, an jeder Remote-, Bypass-, Merge- und Intake-Grenze erneut zu autorisieren.

## Ausführungsvertrag / Execution Contract

- Jede Aufgabe wird erst nach ihrem benannten Nachweis abgehakt. Ein fehlender
  Nachweis führt an der sicheren Grenze zu `Blocked` oder `Failed`, nie zu einer
  stillen Scope-Erweiterung.
- Produktänderungen sind ausschließlich in `src/MicroCalc.Tui/MicroCalc.Tui.csproj`
  und `src/MicroCalc.Tui/Program.cs` zulässig. Als einzige Automationsänderung
  ist die minimale plattformübergreifende Produkt-CI-Erweiterung in
  `.github/workflows/ci.yml` zulässig. `src/MicroCalc.Core/`, vorhandene Dateien
  unter `tests/`, `CALC.HLP`, Rename-Feature-Artefakte, Skripte, Agentenflächen,
  andere Workflows und Folgefeatures bleiben unverändert.
- `[P]` bedeutet echte Parallelisierbarkeit: Die markierten Aufgaben besitzen
  nach ihren Voraussetzungen verschiedene Writer-Pfade. Aufgaben ohne `[P]`
  werden seriell ausgeführt.
- Vor jedem einzelnen `dotnet build` oder `dotnet test` — auch wenn `dotnet test`
  durch `dotnet-coverage` gestartet wird — wird `Directory.Build.props`
  atomar auf `Major.3.Patch.Build` ausgerichtet: `Version`, `AssemblyVersion`
  und `FileVersion` bleiben identisch, `Patch` ist
  `git rev-list --count main..HEAD + 1`, und `Build` steigt genau einmal.
  Ein Zählereintrag in
  `specs/003-terminalgui-migration/evidence/version-evidence.md` bindet alten
  und neuen Wert, UTC-Zeit, Befehl, Exitcode und Commit-SHA. Kein Build- oder
  Testbefehl darf einen Zählerwert teilen oder mehr als eine Erhöhung auslösen.
- Restore-, Run-, Audit-, Merge- und reine Validator-Befehle erhöhen den
  Build-Zähler nicht. Nach dem letzten Build/Test wird vor Commit oder Push nur
  der prospektive Patchwert erneut ausgerichtet; dabei bleibt der erreichte
  Buildwert erhalten.
- Neue oder geänderte Lern- und Nutztexte sind Deutsch zuerst, Englisch danach,
  CEFR B2, semantisch und text-first. Nicht triviale Besitz-, Fokus- oder
  Eingabeentscheidungen in `Program.cs` erhalten moderate DE-first/EN-second-
  Warum-Kommentare; mechanische API-Syntax erhält keine wiederholenden Kommentare.
- Öffentliche APIs werden im akzeptierten Scope nicht geändert. Wenn dieser
  Trigger dennoch eintritt, wird vor der Änderung gestoppt; XML-Dokumentation,
  DocFX und der textorientierte A11Y-Smoke benötigen dann neue Autorität und
  dürfen nicht in Feature 003 hineingezogen werden.
- Jede Commit-erzeugende oder Commit-ändernde Aufgabe einschließlich der
  Provider-Merges in T070 und T079 muss die exakte Trailerzeile
  `Co-authored-by: Copilot <223556219+Copilot@users.noreply.github.com>` genau
  einmal erstellen oder erhalten und den tatsächlich erzeugten Commit sofort
  read-only prüfen. T080 ist die finale Wiederholungsprüfung, nicht die erste
  Prüfung eines Provider-Merge-Commits.

## Phase 1: Setup und Gate-Freeze / Setup and Gate Freeze

**Zweck / Purpose**: Akzeptierte Eingaben, Scope, Toolchain und veränderliche
Tokens vor jedem semantischen Eingriff fail-closed binden.

- [x] T001 Aktiven Run-State mit `pwsh -NoProfile -File .specify/presets/autonomous-run-governance/scripts/validate-autonomous-run-state.ps1 -State specs/003-terminalgui-migration/autonomous-run-state.json` prüfen und Branch, Run-ID sowie SHA-256 von Intake, Spec, Checklisten und Serienreview in `specs/003-terminalgui-migration/evidence/preflight.md` festhalten. **Voraussetzungen / Prerequisites**: gültiges `plan-review.result.json`; **Nachweis / Proof**: Validator-Exitcode 0 und identische Hashes für TG-GATE-001; **Sichere Grenze / Safe boundary**: bei Drift vor jeder weiteren Dateiänderung stoppen.
- [x] T002 Die 48 eindeutigen Gate-IDs, alle Planungsartefakte und den materialisierten Acht-Preset-Stack mit `jq` und `rg` gegen `specs/003-terminalgui-migration/autonomous-run-gate-requirements.json`, `plan.md`, Sidecars und `checklists/plan-review.md` prüfen; Ergebnis in `specs/003-terminalgui-migration/evidence/preflight.md` ergänzen. **Voraussetzungen**: T001; **Nachweis**: Gate-Anzahl 48, keine doppelten IDs, keine `NEEDS CLARIFICATION`- oder Template-Platzhalter, 40/40 Plan-Review-Checks bestanden, die ersten sieben Befunde in `checklists/analyze-remediation.md` und die zweiten sechs Befunde in `checklists/analyze-remediation-2.md` jeweils als `Fixed`; **Sichere Grenze**: bei fehlendem Artefakt oder offenem Marker nur Planungsremediation zulassen, keinen Produktcode ändern.
- [x] T003 Betriebssystem und vorhandene Werkzeuge (`pwsh`, `.NET 10`, `git`, `gh`, `rg`, `jq`, `dotnet-coverage`, `syft`) erfassen und Versionen in `specs/003-terminalgui-migration/evidence/preflight.md` dokumentieren. **Voraussetzungen**: T002; **Nachweis**: macOS sowie ausführbare, erwartete Toolchain oder klarer blockierender Fehlbestand; **Sichere Grenze**: keine Ersatzsprache und kein neues Repo-Skript einführen.
- [x] T004 Compile-, Laufzeit- und Ereignisoberfläche von `src/MicroCalc.Tui/Program.cs`, `src/MicroCalc.Tui/MicroCalc.Tui.csproj`, `tests/MicroCalc.Tui.Tests/` und allen Konsumenten mit `rg` inventarisieren und in `specs/003-terminalgui-migration/evidence/source-inventory.md` ablegen. **Voraussetzungen**: T003; **Nachweis**: v1-Lifecycle, acht `CtrlMask`-Treffer, null `AltMask`, Dialoge, Button-Events, 13 Bindings, Smoke-Bypass und unveränderte Testkonsumenten sind einzeln gezählt; **Sichere Grenze**: Inventar ist read-only und erweitert den Core-/Testscope nicht.
- [x] T005 Den beabsichtigten Exact-Path-Delivery-Set in `specs/003-terminalgui-migration/evidence/delivery-set-intent.md` aus `plan.md` ableiten und verbotene Pfadklassen ausdrücklich festhalten. `specs/003-terminalgui-migration/autonomous-run-state.json` als operativen, nicht getrackten und niemals zu stagenden lokalen Zustand prüfen und den exakten Pfad bei Bedarf ausschließlich in `.git/info/exclude` aufnehmen. **Voraussetzungen**: T004; **Nachweis**: nur die zwei TUI-Produktdateien, exakt `.github/workflows/ci.yml`, `Directory.Build.props`, benannte Feature-/Security-/Architecture-/A11Y-/Statistik-/PR-Evidenz sowie der spätere kausale Intake-Closeout sind enthalten; `git ls-files --error-unmatch` scheitert für den Run-State und `git check-ignore -v` belegt nur den lokalen Exclude; **Sichere Grenze**: Run-State niemals stagen oder committen; `src/MicroCalc.Core/`, `tests/`, Skripte, Agentenflächen, andere Workflows, `_site/` und Feature 004 bleiben ausgeschlossen.
- [x] T006 Versionsledger in `specs/003-terminalgui-migration/evidence/version-evidence.md` initialisieren und den unveränderten Ausgangswert aus `Directory.Build.props`, `main..HEAD`-Commitcount sowie die Regel „eine Erhöhung pro Build/Test-Aufruf“ erfassen. **Voraussetzungen**: T005; **Nachweis**: Major, Minor `3`, prospektiver Patch, Ausgangs-Build und drei identische Felder sind prüfbar; **Sichere Grenze**: noch keinen Build/Test ausführen und keine Version committen.
- [x] T007 Die veränderliche Terminal.Gui-Auswahl anhand NuGet Gallery, offiziellem `tui-cs/Terminal.Gui`-Repository und aktiviertem NuGet-Source-Set erneut prüfen und in `specs/003-terminalgui-migration/evidence/dependencies/package-selection.md` dokumentieren. **Voraussetzungen**: T003; **Nachweis**: `2.4.17` ist stabil, `net10.0` enthalten, Upstream gepflegt und Quelle vertrauenswürdig; **Sichere Grenze**: bei neuer stabiler 2.x-Version, abweichender Quelle, ungepflegtem Upstream oder bekanntem Advisory Auswahl stoppen; Paketänderungen bleiben auf Intake und exakte Version begrenzt, und ein blockierender Fund benötigt neue Autorität statt eines automatischen Upgrades.

**Checkpoint**: Scope, Gate-Basis, Source-Inventar, Versionierungsprotokoll und
Paket-Token sind eingefroren; noch wurde kein Produkt- oder Testcode geändert.

---

## Phase 2: Rot vor Implementierung / Red Before Implementation

**Zweck / Purpose**: Die zwei erlaubten roten Verträge erzeugen, ohne vorhandene
Testquellen oder FakeDriver-Arbeit anzulegen.

- [x] T008 Einen inline ausgeführten PowerShell-Source-Contract gegen `src/MicroCalc.Tui/MicroCalc.Tui.csproj` und `src/MicroCalc.Tui/Program.cs` starten, der exakte Version `2.4.17`, null `Application.Top`/statische Run-Shutdown-Aufrufe, `Application.Create`, `IApplication`, `.WithCtrl`, null `CtrlMask`/`AltMask` und die 13-Key-Matrix fordert. **Voraussetzungen**: T004 und T007; **Nachweis**: erwarteter Exitcode ungleich 0 ausschließlich wegen Version `1.19.0`, v1-Lifecycle, acht Masken und fehlender v2-Symbole in `specs/003-terminalgui-migration/evidence/red-green-refactor/source-contract-red.txt`; **Sichere Grenze**: unerwartete Core-, Test- oder Smoke-Befunde nicht als erwartetes Rot klassifizieren.
- [x] T009 Ausschließlich die `Terminal.Gui`-`PackageReference` in `src/MicroCalc.Tui/MicroCalc.Tui.csproj` von `1.19.0` auf exakt `2.4.17` setzen. **Voraussetzungen**: T008 mit erwarteter Red-Evidenz; **Nachweis**: Exact-Path-Diff zeigt nur die eine Version und keine Floating Range; **Sichere Grenze**: keine weitere Projekt-, Lockfile-, Workflow- oder Teständerung zusammenfassen.
- [x] T010 `dotnet restore MicroCalc.sln` ausführen und Restore-Log, aktive Quellen und `project.assets.json`-Paketauflösung unter `specs/003-terminalgui-migration/evidence/dependencies/` referenzieren. **Voraussetzungen**: T009; **Nachweis**: Restore erfolgreich aus der belegten Quelle, direkte Version `2.4.17`, Ziel `net10.0`; **Sichere Grenze**: Restore-, Quellen- oder Paketdrift blockiert vor Compile.
- [x] T011 `Directory.Build.props` atomar auf Minor `3`, prospektiven Patch und Build `+1` ausrichten, alle drei Versionsfelder gleich halten und genau einmal `dotnet build MicroCalc.sln --configuration Release --no-restore` ausführen. **Voraussetzungen**: T010; **Nachweis**: erwarteter dependency-only Compile-Fehler ausschließlich aus Terminal.Gui-v2-Inkompatibilitäten sowie ein einzelner Zählereintrag in `specs/003-terminalgui-migration/evidence/version-evidence.md`; **Sichere Grenze**: ein unerwarteter Core-/Test-/Toolchain-Fehler stoppt und zählt nicht als akzeptiertes Rot.
- [x] T012 Source-Contract-Red und dependency-only Compile-Red mit Befundliste, exakten Befehlen, Exitcodes, SHA-256 und erlaubter Fehlerklassifikation in `specs/003-terminalgui-migration/evidence/red-green-refactor/red-evidence.md` zusammenfassen. **Voraussetzungen**: T008 und T011; **Nachweis**: beide roten Zustände getrennt und reproduzierbar, TG-GATE-010 Red-Anteil vollständig; **Sichere Grenze**: keine grünen Behauptungen und keine Fehlerunterdrückung.
- [x] T013 Mit `git diff --exit-code -- src/MicroCalc.Core tests CALC.HLP` und `git diff --name-status` belegen, dass die Rotphase keine vorhandene Testquelle, Core-Datei, Hilfe oder Folgefeature-Datei geändert hat; Ergebnis in `specs/003-terminalgui-migration/evidence/red-green-refactor/red-evidence.md` ergänzen. **Voraussetzungen**: T012; **Nachweis**: Exitcode 0 für verbotene Pfade; **Sichere Grenze**: jeden verbotenen Diff vor Green zurücknehmen oder zur Autoritätsentscheidung stoppen, nicht weiter migrieren.

**Checkpoint**: Source-contract red und dependency-only compile red sind echt,
getrennt und fachlich erwartet; vorhandene Tests bleiben unverändert.

---

## Phase 3: User Story 1 – TUI zuverlässig starten und beenden / Start and Stop Reliably (P1, MVP)

**Ziel / Goal**: Einen repräsentativen grünen Lifecycle-Schnitt und danach alle
Menü-/Dialog-Lebenszyklen auf einer eindeutig besessenen `IApplication`-Instanz
bereitstellen.

**Unabhängiger Test / Independent Test**: Release-TUI startet, zeigt genau ein
Root-Fenster, öffnet und schließt Menü/Dialog, kehrt mit Fokus zurück und beendet
sich per Menü ohne Traceback; Smoke bleibt headless und liefert `SMOKE_OK`.

- [x] T014 [US1] Vor dem ersten geforderten grünen Whole-Solution-Build den kleinsten vollständig compile-kompatiblen Terminal.Gui-v2-Schnitt in `src/MicroCalc.Tui/Program.cs` implementieren: Smoke-Bypass vor Terminalinitialisierung, genau ein `Application.Create().Init()`/`IApplication`, eindeutig besessenes Root-Runnable, genau ein `app.Run(root)`, Menü-Quit über `app.RequestStop()`, Dispose von Root und App sowie die compilerbedingt notwendigen v2-Anpassungen für alle Dialog-/Button-/Event- und Keyboard-APIs einschließlich Entfernung aller `CtrlMask`-/`AltMask`-Ausdrücke. **Voraussetzungen**: T013; **Nachweis**: keine bekannte v1-Compile-Inkompatibilität bleibt für T015; spätere Aufgaben verfeinern Verhalten, Ownership und Evidenz, erzeugen aber keine erst dann aufzulösenden Compile-Blocker; **Sichere Grenze**: nur minimale Kompatibilität, keine neue Schicht, kein statisches Ersatz-Singleton, keine Core-/Teständerung.
- [x] T015 [US1] Build-Zähler in `Directory.Build.props` genau einmal erhöhen, drei Versionsfelder ausrichten und genau einmal `dotnet build MicroCalc.sln --configuration Release --no-restore` ausführen. **Voraussetzungen**: T014; **Nachweis**: Release-Build Exitcode 0 ohne neue Warnung und einzelner Ledger-Eintrag; **Sichere Grenze**: bei Compile-Fehler ausschließlich die in T014 geforderte minimale v2-Compile-Kompatibilität in `Program.cs` korrigieren; der Build darf nicht als grün gelten, solange Lifecycle-, Dialog-/Button-/Event- oder Keyboard-Compile-Blocker bestehen.
- [x] T016 [US1] `dotnet run --no-build --configuration Release --project src/MicroCalc.Tui/MicroCalc.Tui.csproj -- --smoke` mit 30-Sekunden-Grenze ausführen. **Voraussetzungen**: T015; **Nachweis**: Exitcode 0, genau ein sichtbares `SMOKE_OK`, keine Terminalinitialisierung, Log unter `specs/003-terminalgui-migration/evidence/red-green-refactor/vertical-slice-green.md`; **Sichere Grenze**: kein Smoke-Fehler darf durch interaktiven Fallback verdeckt werden.
- [x] T017 [US1] Den grünen Slice einmal manuell auf macOS starten, Root und Menü sichtbar prüfen und per Menü-Quit beenden. **Voraussetzungen**: T016; **Nachweis**: Start, genau ein Root, Menü-Quit, Terminalwiederherstellung und kein Traceback in `specs/003-terminalgui-migration/evidence/red-green-refactor/vertical-slice-green.md`; **Sichere Grenze**: dies ist nur Slice-Evidenz und ersetzt nicht die späteren zwei vollständigen Sitzungen.
- [x] T018 [US1] Die in T014 bereits compile-kompatiblen Dialogläufe, `PromptText`, `ShowHelp`, MessageBox-/Button-Aktionen und verschachtelten Stop-Anforderungen in `src/MicroCalc.Tui/Program.cs` auf vollständige Verhaltens-, Ownership- und Fokusparität mit derselben `IApplication`-Instanz, v2-`Accepting`-Vertrag und creator-owned Dispose verfeinern. **Voraussetzungen**: T017; **Nachweis**: jeder Root/Dialog besitzt genau einen Owner und kehrt zur aufrufenden Session zurück; **Sichere Grenze**: T018 darf keinen bis T015 aufgeschobenen Compile-Blocker voraussetzen und ändert Nutzertexte, Layoutabsicht, Core-Aufrufe oder Dateiformat nicht fachlich.
- [x] T019 [US1] Build-Zähler genau einmal erhöhen, drei Versionen ausrichten und genau einmal den Release-Build aus T015 wiederholen. **Voraussetzungen**: T018; **Nachweis**: grüner Compile nach Dialog-/Button-Migration und ein Ledger-Eintrag; **Sichere Grenze**: nur compilerbedingt notwendige v2-Anpassungen in `Program.cs` zulassen.
- [x] T020 [US1] Datei-, Funktions-, Eingabe- und Hilfedialog manuell auf macOS öffnen, vorwärts/rückwärts fokussieren, schließen und Rückkehr zum Root prüfen. **Voraussetzungen**: T019; **Nachweis**: Ausgangs-/Rückkehrfokus, sichere verschachtelte Session, kein Gesamt-App-Abbruch und kein interner Traceback in `specs/003-terminalgui-migration/evidence/manual-tui.md`; **Sichere Grenze**: bei Fokus- oder Ownership-Abweichung vor Tastaturmigration korrigieren.
- [x] T021 [US1] Lifecycle- und Dispose-Code in `src/MicroCalc.Tui/Program.cs` ohne neue Abstraktionsschicht refaktorieren und die geänderte Logik auf didaktischen Kommentarwert prüfen. **Voraussetzungen**: T020; **Nachweis**: keine doppelte App-Weitergabe/Dispose-Strecke; nur bei nicht offensichtlicher Besitz- oder Fokusentscheidung ein moderater DE-first/EN-second-Warum-Kommentar; **Sichere Grenze**: keine öffentliche API und kein CS1591-Suppressionsmechanismus einführen.
- [x] T022 [US1] Build-Zähler genau einmal erhöhen, drei Versionen ausrichten und genau einmal den Release-Build aus T015 ausführen. **Voraussetzungen**: T021; **Nachweis**: Refactor bleibt grün, Ledger enthält genau eine neue Erhöhung; **Sichere Grenze**: bei Regression T021 lokal zurückarbeiten, keinen Testscope hinzufügen.
- [x] T023 [US1] Lifecycle-Source-Contract gegen `src/MicroCalc.Tui/Program.cs` erneut ausführen und Ergebnis in `specs/003-terminalgui-migration/evidence/red-green-refactor/vertical-slice-green.md` binden. **Voraussetzungen**: T022; **Nachweis**: null `Application.Top`, null statische parameterlose Run-/Shutdown-Pfade, genau ein Create/Init/Root-Run und gebundene Stop-/Dispose-Wege; **Sichere Grenze**: User Story 2 beginnt erst bei vollständigem Lifecycle-Green.

**Checkpoint**: User Story 1 ist als MVP unabhängig start-, dialog- und
beendbar; der Lifecycle-Anteil von Red-Green-Refactor ist grün.

---

## Phase 4: User Story 2 – Tastaturbedienung beibehalten / Preserve Keyboard Operation (P1)

**Ziel / Goal**: Alle historischen Tastenwirkungen, Fokuspfade und beide
Beenden-Wege mit v2-Ereignissen erhalten.

**Unabhängiger Test / Independent Test**: Zwei instrumentierte macOS-Sitzungen
belegen exakt zwölf Navigationsinputs plus Menü-Quit und anschließend `Ctrl+Q`
als dreizehnten Input; unbekannte Tasten erhalten keine neue Wirkung.

- [x] T024 [US2] Die in T014 bereits compile-kompatiblen Window-/Dialog-Ereignisse und Keyboard-APIs verhaltensgetrieben auf den vollständigen v2-`KeyDown`/KeyBindings-, `.WithCtrl`- und Handled-Vertrag verfeinern. **Voraussetzungen**: T023; **Nachweis**: null alte `CtrlMask`-/`AltMask`-Ausdrücke und die Zuordnung für CursorUp, Ctrl+E, CursorDown, Ctrl+X, Ctrl+J, CursorRight, Ctrl+D, Ctrl+M, Enter, CursorLeft, Ctrl+S und Ctrl+A bleibt eins-zu-eins; **Sichere Grenze**: T024 darf keinen bis T015 aufgeschobenen Compile-Blocker voraussetzen, keine neue Tastenfunktion und keine Alt-Belegung einführen.
- [x] T025 [US2] Historisches `Ctrl+Q` in `src/MicroCalc.Tui/Program.cs` ausdrücklich an `app.RequestStop()` der aktiven Session binden und unbekannte/Steuerzeichen so behandeln, dass sie keine Navigation, Zellbearbeitung oder Quit-Aktion vortäuschen. **Voraussetzungen**: T024; **Nachweis**: geschlossene Key-Matrix mit genau einer Aktion je erkanntem Input und keiner neuen Wirkung unbekannter Inputs; **Sichere Grenze**: Escape-/Editor- und Printable-ASCII-Bestand nicht fachlich erweitern.
- [x] T026 [US2] Die vollständige Event-/Key-Migration in `src/MicroCalc.Tui/Program.cs` refaktorieren und auf moderate bilinguale Warum-Kommentare prüfen. **Voraussetzungen**: T025; **Nachweis**: keine doppelte Eventbehandlung; nicht offensichtliche Handled-, Quit- oder Input-Grenze DE-first/EN-second erklärt, mechanische Syntax unkommentiert; **Sichere Grenze**: keine Hilfsklasse, Testquelle oder FakeDriver-Abstraktion anlegen.
- [x] T027 [US2] Build-Zähler genau einmal erhöhen, drei Versionen ausrichten und genau einmal den Release-Build aus T015 ausführen. **Voraussetzungen**: T026; **Nachweis**: grüner Compile für alle v2-Events/Keys und einzelner Ledger-Eintrag; **Sichere Grenze**: compilerbedingte Korrekturen bleiben in den zwei erlaubten TUI-Dateien.
- [x] T028 [US2] Den vollständigen Source-Contract erneut ausführen und `rg`-Zählungen in `specs/003-terminalgui-migration/evidence/source-contract-green.md` erfassen. **Voraussetzungen**: T027; **Nachweis**: exakt `2.4.17`, null `CtrlMask`, null `AltMask`, null v1-Lifecycle, v2-Symbole vorhanden und genau 13 bindende Inputs nachvollziehbar; **Sichere Grenze**: Abweichung blockiert vor manueller Abnahme.
- [x] T029 [US2] Erste instrumentierte macOS-Sitzung mit `dotnet-coverage collect --output /tmp/tinycalc-003/coverage/manual-menu.coverage --output-format coverage -- dotnet run --no-build --configuration Release --project src/MicroCalc.Tui/MicroCalc.Tui.csproj` ausführen und Inputs 1–12 jeweils aus bekannter Zelle, Menü, Datei-/Funktions-/Eingabedialog, Vorwärts-/Rückwärtsfokus und Menü-Quit prüfen. **Voraussetzungen**: T028; **Nachweis**: Ausgangs-, Soll- und Ist-Zelle je Input, Dialogrückkehr, sichtbarer Fokus, Terminalrestauration, Exitstatus und Coverage-Datei in `specs/003-terminalgui-migration/evidence/manual-tui.md`; **Sichere Grenze**: ein Fehlversuch bleibt Befund und wird nicht als erster erfolgreicher Durchgang umgedeutet.
- [x] T030 [US2] Zweite instrumentierte macOS-Sitzung mit `dotnet-coverage collect --output /tmp/tinycalc-003/coverage/manual-ctrlq.coverage --output-format coverage -- dotnet run --no-build --configuration Release --project src/MicroCalc.Tui/MicroCalc.Tui.csproj` ausführen und `Ctrl+Q` einzeln als Input 13 und zweiten Quit-Pfad prüfen. **Voraussetzungen**: T029; **Nachweis**: Quit statt Zellinhalt, Exit ohne Traceback, Terminalrestauration und zweite Coverage-Datei in `specs/003-terminalgui-migration/evidence/manual-tui.md`; **Sichere Grenze**: Sitzung 2 bleibt getrennt von Menü-Quit und ersetzt Sitzung 1 nicht.
- [x] T031 [US2] `docs/accessibility/terminalgui-migration.md` aus beiden Sitzungen DE-first/EN-second, CEFR B2 und text-first erstellen; 13-Key-Matrix, Fokusfolge, Dialogrückkehr, beide Quit-Pfade und Terminalrestauration vollständig beschreiben. **Voraussetzungen**: T029 und T030; **Nachweis**: lineare Textalternative bleibt ohne Farbe, Screenshot oder Tabellenlayout verständlich; **Sichere Grenze**: kein A11Y-Redesign und keine neue Produktfunktion dokumentieren.
- [x] T032 [US2] WCAG 2.2 AA 1.4.1, 2.1.1, 2.1.2, 2.4.3 und 2.4.7 sowie die begründeten Pointer-/Bild-/Medien-N/As in `docs/accessibility/terminalgui-migration.md` gegen die echte Sitzungs-Evidenz abschließen. **Voraussetzungen**: T031; **Nachweis**: jedes anwendbare Kriterium hat Status, Beobachtung und Trigger; **Sichere Grenze**: fehlender sichtbarer Fokus oder Keyboard Trap blockiert, nicht als N/A behandeln.
- [x] T033 [US2] `git diff --exit-code -- tests src/MicroCalc.Core CALC.HLP` und die Source-/A11Y-Verträge erneut prüfen. **Voraussetzungen**: T032; **Nachweis**: bestehende Testquellen, Core und Hilfe unverändert; US2-Evidenz vollständig; **Sichere Grenze**: keine FakeDriver- oder andere Testquellenänderung zur Reparatur verwenden.

**Checkpoint**: User Story 2 ist mit exakt 13 Bindings, zwei Quit-Sitzungen und
WCAG-Textnachweis unabhängig verifiziert.

---

## Phase 5: User Story 3 – Regressionen schnell erkennen / Detect Regressions Quickly (P2)

**Ziel / Goal**: Bestehende Tests, Smoke, Paketgraph und Changed-Code-Coverage
ohne Änderung vorhandener Testquellen vollständig belegen.

**Unabhängiger Test / Independent Test**: Restore und Release-Build sind grün,
100 Prozent der vorhandenen Tests bestehen, Smoke endet in 30 Sekunden mit
genau einem `SMOKE_OK`, und zusammengeführte Changed-Code-Coverage ist mindestens
70 Prozent bei dokumentiertem 80-Prozent-Ziel.

- [x] T034 [US3] `dotnet restore MicroCalc.sln` am fertigen Produktstand wiederholen und Restore-Log, Quellen und genaue direkte/transitive Auflösung unter `specs/003-terminalgui-migration/evidence/dependencies/` aktualisieren. **Voraussetzungen**: T033; **Nachweis**: reproduzierbare `2.4.17`-Auflösung ohne unerwartete Quelle; **Sichere Grenze**: Paketdrift invalidiert T007/T010 und blockiert vor Build.
- [x] T035 [US3] Build-Zähler genau einmal erhöhen, drei Versionen ausrichten und genau einmal `dotnet build MicroCalc.sln --configuration Release --no-restore` ausführen. **Voraussetzungen**: T034; **Nachweis**: Release-Build Exitcode 0, keine neue Warning-as-Error und einzelner Ledger-Eintrag; **Sichere Grenze**: kein `--no-restore` ohne unmittelbar belegten T034-Restore.
- [x] T036 [US3] Build-Zähler erneut genau einmal erhöhen, drei Versionen ausrichten und genau einmal `dotnet test MicroCalc.sln --configuration Release --no-build` ausführen. **Voraussetzungen**: T035; **Nachweis**: 100 Prozent vorhandene Core-/TUI-xUnit-Tests grün und eigener Ledger-Eintrag; **Sichere Grenze**: keinen failing Test ändern, überspringen oder filtern.
- [x] T037 [US3] Den Smoke-Befehl aus T016 am finalen lokalen Produktstand erneut mit 30-Sekunden-Grenze ausführen. **Voraussetzungen**: T036; **Nachweis**: Exitcode 0 und genau ein `SMOKE_OK` in `specs/003-terminalgui-migration/evidence/regression.md`; **Sichere Grenze**: Smoke bleibt headless und verwendet den Build aus T035.
- [x] T038 [US3] Build-Zähler genau einmal erhöhen, drei Versionen ausrichten und die Coverage-Testausführung exakt einmal mit `dotnet-coverage collect --output /tmp/tinycalc-003/coverage/tests.coverage --output-format coverage -- dotnet test MicroCalc.sln --configuration Release --no-build` starten. **Voraussetzungen**: T037; **Nachweis**: Tests erneut vollständig grün, `tests.coverage` vorhanden und eigener Ledger-Eintrag; **Sichere Grenze**: dies ist genau ein Testaufruf und darf keine zweite Zählererhöhung oder Testquellenänderung auslösen.
- [x] T039 [US3] `dotnet-coverage collect --output /tmp/tinycalc-003/coverage/smoke.coverage --output-format coverage -- dotnet run --no-build --configuration Release --project src/MicroCalc.Tui/MicroCalc.Tui.csproj -- --smoke` ausführen. **Voraussetzungen**: T038; **Nachweis**: `smoke.coverage`, Exitcode 0 und `SMOKE_OK`; **Sichere Grenze**: kein Build/Test-Aufruf und deshalb keine zusätzliche Build-Erhöhung.
- [x] T040 [US3] Die vier Pflichtdateien mit `dotnet-coverage merge --output /tmp/tinycalc-003/coverage/terminalgui.cobertura.xml --output-format cobertura /tmp/tinycalc-003/coverage/tests.coverage /tmp/tinycalc-003/coverage/smoke.coverage /tmp/tinycalc-003/coverage/manual-menu.coverage /tmp/tinycalc-003/coverage/manual-ctrlq.coverage` zusammenführen. **Voraussetzungen**: T029, T030, T038 und T039; **Nachweis**: gültige Cobertura-Datei und SHA-256 aller fünf Coverage-Artefakte; **Sichere Grenze**: kein manueller Pfad darf ausgelassen oder durch synthetische Coverage ersetzt werden.
- [x] T041 [US3] Geänderte ausführbare Zeilen mit `git diff --unified=0 main...HEAD -- src/MicroCalc.Tui/Program.cs` deterministisch gegen Cobertura schneiden und Zähler, Nenner, ausgeschlossene Leer-/Klammer-/Kommentarzeilen, Toolversion und Ergebnis in `specs/003-terminalgui-migration/evidence/coverage-summary.md` festhalten. **Voraussetzungen**: T040; **Nachweis**: mindestens 70 Prozent, Zielstatus für 80 Prozent ausdrücklich benannt; **Sichere Grenze**: unter 70 Prozent blockiert ohne FakeDriver-, Testquellen- oder Scope-Erweiterung.
- [x] T042 [US3] Maschinenlesbare Paketberichte mit `dotnet package list --project MicroCalc.sln --include-transitive --format json --no-restore`, `--vulnerable --format json` und `--outdated --format json` unter `specs/003-terminalgui-migration/evidence/dependencies/` erzeugen, `dotnet nuget list source` und Upstream-Metadaten binden sowie für jedes direkte und transitive ausgelieferte Paket die autoritative Lizenzmetadatenquelle und den Lizenztext beziehungsweise SPDX-Ausdruck erfassen. **Voraussetzungen**: T034; **Nachweis**: kompletter Graph, bekannte Advisories, alle Paketlizenzen und Quellen, veraltete Pakete als Review statt ungeplanter Updates, SDK/UTC/SHA/Quelle; **Sichere Grenze**: jede bekannte Schwachstelle sowie jede unbekannte oder inkompatible Lizenz im ausgelieferten Graph blockiert; Paketupdates werden nicht automatisch in Feature 003 aufgenommen und benötigen bei einem Blocker neue Autorität.
- [x] T043 [US3] `docs/security/dependency-audit.md` DE-first/EN-second aus T007, T034 und T042 aktualisieren: direkte/transitive Menge, Maintenance, fail-closed Vulnerability-Schranke, für jedes ausgelieferte Paket Lizenz, Quelle, Kompatibilität und Disposition, OpenSSF-Verweis, Lockfile-/Automation-Rest und VEX-Trigger. **Voraussetzungen**: T042; **Nachweis**: null bekannte Schwachstellen sowie null unbekannte oder inkompatible Lizenzen im ausgelieferten Graph oder expliziter Block; VEX klassifiziert nur Fehlalarme/nicht ausgelieferte Komponenten und autorisiert keinen bekannten ausgelieferten Fund. **Sichere Grenze**: ein bekannter ausgelieferter Fund blockiert bis zu ausdrücklich autorisiertem und abgeschlossenem Update/Ersatz; kein Dependabot/Renovate/Dependency-Track- oder Lockfile-Scope implementieren.
- [x] T044 [US3] Lokale Regressionsevidenz in `specs/003-terminalgui-migration/evidence/regression.md` mit Restore-, Build-, Test-, Smoke-, Coverage- und No-Test-Source-Diff-Hashes abschließen. **Voraussetzungen**: T035–T043; **Nachweis**: jeder Befehl, Exitcode, Commit-SHA und Artefakthash vorhanden; **Sichere Grenze**: macOS-Evidenz nicht als Linux- oder Windows-Nachweis ausgeben.
- [x] T045 [US3] US3-Checkpoint gegen FR-005/-006/-010/-012/-013 und TG-GATE-003/-004/-007..011 prüfen. **Voraussetzungen**: T044; **Nachweis**: lokale Regression, Dependency und Coverage vollständig; echte Linux-/Windows-CI-Belege ausdrücklich noch als Delivery-Abhängigkeit markiert; **Sichere Grenze**: User Story 3 nicht als plattformvollständig bezeichnen, bevor T066 bestanden ist.

**Checkpoint**: Die lokale Regression ist unabhängig grün; die späteren echten
Linux-/Windows-Runner bleiben bewusste, blockierende Delivery-Gates.

---

## Phase 6: User Story 4 – Lieferumfang nachvollziehbar prüfen / Review the Delivery Scope (P3)

**Ziel / Goal**: Security-, Architektur-, A11Y-, Lieferketten-, Statistik- und
Review-Evidenz linear, bilingual und exact-head-fähig bereitstellen.

**Unabhängiger Test / Independent Test**: Ein Review kann Scope, Änderungen,
Risiken, Ausschlüsse, Status, N/A-Begründungen und nächste Schritte ohne Farbe,
Screenshot oder Spec-Kit-Vorwissen vollständig nachvollziehen.

- [x] T046 [P] [US4] Kontext-, Baustein-, Laufzeit-, Deployment-, Qualitäts-, Risiko- und Trust-Boundary-Sicht in `docs/architecture/terminalgui-migration.md` DE-first/EN-second, CEFR B2 und mit linearen Textalternativen dokumentieren; `docs/security/arc42-security.md` für Lifecycle, Trust Boundaries, Eingaben, Abhängigkeiten, Fehler, Logging und Deployment vollständig aktualisieren; genau einen fokussierten S-ADR `docs/security/adr/003-terminalgui-lifecycle-supply-chain.md` zu Lifecycle-Ownership und fail-closed Schwachstellen-/Lizenzentscheidungen erstellen. **Voraussetzungen**: T045; **Nachweis**: eine App-Instanz, creator-owned Runnables, unveränderte Core-/Datei-/Deployment-Grenze, keine neue Schicht, vollständiges arc42 Section 8 und ein fokussierter S-ADR mit Entscheidung, Alternativen, Folgen und Compliance-Nachweis; **Sichere Grenze**: kein allgemeiner ADR oder weiterer S-ADR ohne neuen Trigger, aber arc42 und dieser S-ADR dürfen nicht als N/A behandelt werden.
- [x] T047 [P] [US4] `docs/security/threat-model.md` für Tastatur-, Lifecycle-, Fehlerausgabe-, Core-Scope- und NuGet-Grenzen mit STRIDE/CIA, CAPEC-153, CAPEC-538, Mitigation und Restrisiko aktualisieren. **Voraussetzungen**: T045; **Nachweis**: Tampering/DoS/Disclosure plus bewertete Repudiation-/Elevation-Nichtanwendbarkeit und exact-head-Platzhalter; **Sichere Grenze**: neue Trust Boundary oder Angriffsklasse blockiert zur Neuplanung.
- [x] T048 [P] [US4] `docs/security/security-checklist.md` auf Feature 003 aktualisieren und NIST SSDF, CWE Top 25, Microsoft C# Secure Coding, geschlossene Inputs, Dispose bei Fehlern, sichere Endnutzerfehler, Dependency-Prüfung sowie keine neue Datei-/Netzwerk-/Deserialisierungsfläche belegen. **Voraussetzungen**: T045; **Nachweis**: alle anwendbaren Kontrollen mit Owner, Reviewer, Evidenz und Restrisiko; **Sichere Grenze**: kein Pflichtstandard darf N/A werden.
- [x] T049 [P] [US4] Manipulierte Taste, Paketmanipulation und sichere Beendigung in `docs/security/security-quality-scenarios.md` als messbare DE-first/EN-second-Szenarien aktualisieren. **Voraussetzungen**: T045; **Nachweis**: Stimulus, Umgebung, Reaktion, Messwert und Evidenzpfad für exact head; **Sichere Grenze**: keine erfundene Ausführungs- oder Penetrationstest-Evidenz.
- [x] T050 [P] [US4] `docs/security/samm-assessment.md` auf migrationsbedingte Prozessbefunde prüfen und entweder begründete Maßnahmen oder `reviewed, unchanged` mit exact-head-Trigger dokumentieren. **Voraussetzungen**: T045; **Nachweis**: OWASP-SAMM-Review mit Owner und Folgegrenze; **Sichere Grenze**: kein eigenständiges Prozessverbesserungsfeature starten.
- [x] T051 [P] [US4] Nach dem Release-Build `syft dir:src/MicroCalc.Tui/bin/Release/net10.0 -o spdx-json=docs/security/sbom/tinycalc-terminalgui.spdx.json` ausführen und mit `jq -e '.spdxVersion and .packages'` validieren. **Voraussetzungen**: T035 und T042; **Nachweis**: gültige SPDX-JSON-SBOM, Syft-Version, Quellverzeichnis, SHA-256 und Delivery-SHA-Zuordnung; **Sichere Grenze**: fehlende/inkonsistente SBOM blockiert und wird nicht manuell geschönt.
- [x] T052 [US4] `docs/security/supply-chain-evidence.md` mit SBOM-Hash, Paketgraph, fail-closed Vulnerability-Disposition, begrenzter VEX-Entscheidung, vollständiger direkter/transitiver Lizenzquelle/-kompatibilität/-disposition, AI-SBOM-N/A, echtem SLSA-v1.2-Provenance-Status sowie datiertem OpenSSF-Scorecard-Review für `tui-cs/Terminal.Gui` und `hindermath/TinyCalc` aktualisieren. Alle N/A-Sicherheitsbewertungen werden vor T053 entweder dort (VEX, AI-SBOM, Dependency Automation) oder in `docs/security/arc42-security.md` (ASVS, allgemeiner ADR, Zero Trust, C3A/C5, Regulatorik) mit Begründung und Trigger abgelegt. Danach `docs/security/README.md` von `Stub` auf abgeschlossen setzen und alle Pflichtartefakte einschließlich `docs/security/adr/003-terminalgui-lifecycle-supply-chain.md` indexieren. **Voraussetzungen**: T043, T046–T051; **Nachweis**: keine überhöhte SLSA-Level-Behauptung, null bekannte Schwachstellen und null unbekannte/inkompatible Lizenzen im ausgelieferten Graph, jeder N/A-Trigger am genehmigten Ort und kein fertiggestelltes Artefakt im README als Stub; **Sichere Grenze**: VEX darf nur Fehlalarme oder nicht ausgelieferte Komponenten klassifizieren; ein bekannter ausgelieferter Fund blockiert bis zu autorisiertem und abgeschlossenem Update/Ersatz.
- [x] T053 [US4] Alle neuen lern-/nutzseitigen Feature-, Security-, Architektur- und A11Y-Texte auf DE-first/EN-second, CEFR B2, semantische Überschriften, zeilenweise verständliche Tabellen und text-first-Aussagen prüfen und Ergebnis in `specs/003-terminalgui-migration/evidence/documentation-review.md` festhalten. **Voraussetzungen**: T046–T052; **Nachweis**: Leserpfad, Zielgruppen, Quelle/Owner, Navigation-N/A, Dokumentklasse, Sprache, Plattform, Distribution, Home-Sync-N/A und Trigger der akzeptierten Documentation-Impact-Entscheidung; **Sichere Grenze**: keine DocFX-, Home-Sync-, CALC.HLP- oder Agentenänderung ohne Trigger.
- [x] T054 [US4] `docs/PR_TEXT_TERMINALGUI_MIGRATION.md` DE-first/EN-second mit Problem, Lösung, TUI-Proof, Risiken, exact-path Delivery-Set, Test-/Smoke-/Coverage-/Plattformplan, Security/A11Y, Konfigurations-/API-Auswirkung, N/A-Entscheidungen und FakeDriver-Follow-up-Abgrenzung erstellen. **Voraussetzungen**: T046–T053; **Nachweis**: PR-Template-Felder vollständig und kein Rename-/Core-/Testquellen-Scope; **Sichere Grenze**: noch keinen PR eröffnen.
- [x] T055 [US4] Feature-003-Profil mit beobachtbarem Arbeitsfenster, Produktions-/Test-/Dokumentationszeilen, Baselines 80 und 125 Zeilen/Arbeitstag sowie 7,8 Stunden in `docs/project-statistics.config.json` ergänzen, `pwsh -NoProfile -File scripts/render-project-statistics.ps1 -Repo .` ausführen und anschließend mit `-CheckOnly` prüfen. **Voraussetzungen**: T054; **Nachweis**: `docs/project-statistics.md` besitzt chronologischen neuen Protokolleintrag, finale `## Gesamtstatistik`, aktualisierte ASCII-Trends und angrenzende CEFR-B2-Textalternativen; Check-only Exitcode 0; **Sichere Grenze**: vorhandenes Statistikskript nicht ändern und Testzeilen wegen unveränderter Tests korrekt als null/Bestand ausweisen.
- [x] T056 [US4] `specs/003-terminalgui-migration/autonomous-run-evidence.md` auf Implementierungsstand aktualisieren und jede anwendbare Gate-Evidenz, den exact-head-Placeholder, Owner/Reviewer, Restrisiko und nächste sichere Aktion verlinken. **Voraussetzungen**: T046–T055; **Nachweis**: kein ausgeführter Remote-/Merge-/PostMerge-Schritt wird vorweggenommen; **Sichere Grenze**: geplante Delivery bleibt `Pending`, bis echte Provider-Evidenz vorliegt.
- [x] T057 [US4] Die N/A-Trigger von TG-GATE-022..028, -031..034 und -046 gegen den tatsächlichen Diff neu bewerten. Security-/Supply-Chain-N/As müssen an den in T052 genehmigten Orten in `docs/security/arc42-security.md` oder `docs/security/supply-chain-evidence.md` verbleiben; Governance-N/As werden in `specs/003-terminalgui-migration/autonomous-run-evidence.md` und alle Dispositionen später in Schema-2.0-Evidenz festgehalten. **Voraussetzungen**: T056; **Nachweis**: VEX bedingt, ASVS, AI-SBOM, Zero Trust, C3A/C5, Regulatorik, allgemeiner ADR, Script-/Agent-/Parallel-Parität, XML/DocFX und Dependency-Automation besitzen Begründung, Trigger und genehmigten Evidenzort; fokussierter S-ADR und arc42 sind `Applicable` und vollständig, nicht N/A; **Sichere Grenze**: N/A-Dispositionen dürfen nicht still verschwinden, und keine N/A-Funktion, kein Paritätsskript, keine Agentendatei oder sonstige N/A-Implementierung wird ergänzt.
- [x] T058 [US4] Einen linearen Evidenzindex in `specs/003-terminalgui-migration/evidence/evidence-index.md` erstellen, der FR/CR/SC, vier User Stories und TG-GATE-001..048 auf vorhandene Artefakte und noch ausstehende Delivery-Belege abbildet. **Voraussetzungen**: T057; **Nachweis**: jede ID genau einmal primär zugeordnet, fehlende Provider-Evidenz als `Pending` statt `Pass`; **Sichere Grenze**: keine Gate-Anforderung umformulieren oder wegkürzen.

**Checkpoint**: User Story 4 ist als linearer, bilingualer Review-Payload bereit;
Remote-, Review-, Merge- und PostMerge-Fakten sind noch nicht vorgetäuscht.

---

## Phase 7: Exact-Head Delivery, Review und MergeAndSync / Delivery, Review, and MergeAndSync

**Zweck / Purpose**: Den fokussierten Implementierungs-PR nur mit aktueller
Autorität, echten Plattformlogs und schema-2.0-konvergierter Evidenz liefern.

- [x] T059 [US4] Als einzige Workflow-Änderung `.github/workflows/ci.yml` minimal so erweitern, dass für denselben PR-Head auf `ubuntu-latest` und `windows-latest` jeweils exakt `dotnet restore MicroCalc.sln`, `dotnet build MicroCalc.sln --configuration Release --no-restore`, `dotnet test MicroCalc.sln --configuration Release --no-build` und `dotnet run --no-build --configuration Release --project src/MicroCalc.Tui/MicroCalc.Tui.csproj -- --smoke` laufen und der Smoke-Schritt Exitcode 0 sowie exakt `SMOKE_OK` erzwingt. **Voraussetzungen**: T058; **Nachweis**: Diff enthält nur `.github/workflows/ci.yml`, beide echten Produkt-Runner, die vier Befehle und die exakte Token-Prüfung; **Sichere Grenze**: kein anderer Workflow, kein Script, keine Action-Version, kein Trigger und keine sonstige Automation wird geändert, soweit dies nicht minimal für diese beiden Produktjobs erforderlich ist.
- [x] T060 Run-State, Stop-Status, Branch, akzeptierte Hashes, `MergeAndSync`-Operation/Receipt und `gh auth status` unmittelbar vor Git-/Remote-Arbeit erneut prüfen. **Voraussetzungen**: T059; **Nachweis**: aktuelle Autorität für Commit/Push/PR, konkrete Repository-Identität und kein Stop/Drift in `specs/003-terminalgui-migration/autonomous-run-evidence.md`; **Sichere Grenze**: gespeicherter Modus allein reicht nicht, fehlende Autorität stoppt vor Commit.
- [x] T061 `Directory.Build.props` ohne Build/Test-Aufruf auf `Major.3.<git rev-list --count main..HEAD + 1>.<erreichter Build>` ausrichten und alle drei Versionsfelder gleich halten. **Voraussetzungen**: T060; **Nachweis**: prospektiver Feature-Commitcount, Minor 3, unveränderter letzter Buildwert und Versionseintrag; **Sichere Grenze**: nach dieser Ausrichtung keinen unbelegten Build/Test mehr starten.
- [x] T062 Jeden tatsächlich beabsichtigten Pfad einzeln mit `validate-autonomous-delivery-set.ps1 -Repo . -Intended <exact-path>`, `git diff --name-status main...HEAD`, `git diff --check` und verbotenen `git diff --exit-code`-Pfaden validieren. **Voraussetzungen**: T061; **Nachweis**: Indexbaum unverändert, nur T005-Pfade einschließlich exakt `.github/workflows/ci.yml`, kein Core/Test/Script/Agent/anderer-Workflow/`_site`/Feature-004-Diff; **Sichere Grenze**: unerwarteter Pfad blockiert vor Staging.
- [x] T063 Beabsichtigte Pfade exakt stagen, Delivery-Set nach Staging erneut read-only prüfen und einen fokussierten Conventional-Commit für Feature 003 mit der exakten Trailerzeile `Co-authored-by: Copilot <223556219+Copilot@users.noreply.github.com>` erstellen. **Voraussetzungen**: T062; **Nachweis**: Commit enthält nur den validierten Satz, Version `Major.3.Patch.Build` passt zum neuen Commitcount und `git log -1 --format=%B` enthält die Trailerzeile exakt einmal; **Sichere Grenze**: fehlender oder abweichender Trailer blockiert, kein `git add -A`, kein zweiter Themencommit und kein Push ohne T064.
- [ ] T064 Autorität, Stop-Status, Remote und Commit-SHA erneut prüfen, Delivery-Set-Validator wiederholen und Branch `003-terminalgui-migration` pushen. **Voraussetzungen**: T063; **Nachweis**: Remote-Head entspricht lokalem exact head und der exakte Co-author-Trailer ist weiterhin vorhanden; **Sichere Grenze**: Drift oder Providerfehler blockiert ohne Force-Push.
- [ ] T065 Mit authentifizierter `gh`-CLI genau einen fokussierten PR von `003-terminalgui-migration` nach `main` mit `docs/PR_TEXT_TERMINALGUI_MIGRATION.md` eröffnen und PR-Nummer/URL/headRefOid binden. **Voraussetzungen**: T064; **Nachweis**: PR-Scope, Body und exact head stimmen; **Sichere Grenze**: keinen zweiten Implementierungs-PR und keinen Closeout-PR vor PostMerge eröffnen.
- [ ] T066 Am unveränderten PR-Head echte Produkt-CI-Logs aus `.github/workflows/ci.yml` von `ubuntu-latest` und `windows-latest` binden, die jeweils die vier exakten Befehle aus T059 erfolgreich ausführen und Smoke mit Exitcode 0 sowie exakt `SMOKE_OK` belegen. **Voraussetzungen**: T065; **Nachweis**: Runner-OS, Workflow/Job, exakte vier Befehle, head SHA, Exitcodes und unveränderliche URLs in `specs/003-terminalgui-migration/evidence/platform-ci.md`; **Sichere Grenze**: ein Jobname, ein anderer Head, Teilbefehle oder ein Smoke ohne exakte Token-Prüfung sind unzureichend.
- [ ] T067 Alle lokalen und Provider-Artefakte auf den unveränderten PR-Head revalidieren und `/tmp/tinycalc-003/gates/premerge.json` im Schema 2.0 mit exakt einer `Primary`-Zeile pro TG-GATE-001..048, Supplemental-Zeilen nur zusätzlich, exakten `requiredScope`-Texten, Requirement-Hash, Befehlen, Plattformen, Exitcodes und Artefakthashes erzeugen; mit `validate-autonomous-gate-evidence.ps1` validieren. **Voraussetzungen**: T066; **Nachweis**: Validator-Exitcode 0 für `-Head <pr-head-sha>`; N/A-Zeilen kopieren Begründung/Trigger, Delivery-Gates belegen PreMerge-Bereitschaft und TG-GATE-048 belegt den exakten Trailer; **Sichere Grenze**: kein fehlendes Gate, falscher Scope oder Supplemental-Beleg darf Primary ersetzen.
- [ ] T068 PR-Checks mit `gh pr checks --watch`, PR-Zustand mit `gh pr view --json headRefOid,mergeStateStatus,reviewDecision,statusCheckRollup,url` und alle Review-Threads per GraphQL bis zur Konvergenz prüfen. **Voraussetzungen**: T067; **Nachweis**: alle Pflichtchecks grün, null offene Threads, null Changes Requested, erforderliche Reviewer vorhanden und headRefOid unverändert; **Sichere Grenze**: jeder neue Commit invalidiert T066/T067 und startet die betroffenen Prüfungen neu.
- [ ] T069 Unmittelbar vor einer bypass-fähigen Mergeaktion `operation.json` und `receipt.json` sowie Thorstens aktuelle Autorität für konkrete PR-Nummer und konkrete Repository-Policy revalidieren und Autorisierer, Scope, Grund und Restrisiko in `specs/003-terminalgui-migration/autonomous-run-evidence.md` und Gate-Evidenz festhalten. **Voraussetzungen**: T068; **Nachweis**: TG-GATE-047 vollständig und ausdrückliche Aussage, dass kein Fach-, Security-, A11Y-, Plattform-, Review- oder Exact-Head-Gate ersetzt wird; **Sichere Grenze**: `--admin` nur bei realer formaler Policy-Blockade, sonst normaler Merge.
- [ ] T070 Den fokussierten PR nach letzter Autoritäts-/Head-Prüfung mit `gh pr merge <pr-number> --merge --subject 'feat: migrate Terminal.Gui to 2.x' --body "Feature 003 Terminal.Gui migration.`n`nCo-authored-by: Copilot <223556219+Copilot@users.noreply.github.com>"` mergen; nur bei T069-bestätigtem konkretem Bedarf `--admin` ergänzen. Unmittelbar danach und vor T071 den tatsächlichen Merge-SHA mit `gh pr view <pr-number> --json mergeCommit --jq '.mergeCommit.oid'` lesen, seine tatsächliche Nachricht mit `gh api repos/{owner}/{repo}/commits/<merge-sha> --jq '.commit.message'` read-only abrufen und die exakte Trailerzeile genau einmal verlangen; dann das Provider-Ereignis in `specs/003-terminalgui-migration/evidence/delivery.md` erfassen. **Voraussetzungen**: T068 und T069; **Nachweis**: PR, reviewed head, tatsächlicher Merge-Commit und sofortige read-only Trailerprüfung exakt einmal; **Sichere Grenze**: kein Merge bei veraltetem Head, fehlendem Check oder offener Review; fehlender/abweichender/mehrfacher Trailer blockiert vor T071 und kann nicht erst durch T080 geheilt werden.
- [ ] T071 Lokal `main` mit `git switch main`, `git pull --ff-only` und `git rev-parse HEAD` auf den exakten Remote-Merge-Commit synchronisieren und SHA-Vergleich in `specs/003-terminalgui-migration/evidence/delivery.md` dokumentieren. **Voraussetzungen**: T070; **Nachweis**: lokales/remote `main` und Merge-Commit identisch; **Sichere Grenze**: kein Reset, Rebase oder nicht-fast-forward Sync.
- [ ] T072 `/tmp/tinycalc-003/gates/postmerge.json` im Schema 2.0 erzeugen, den normalisierten akzeptierten PreMerge-Hash und tatsächlichen Merge-Commit binden, `changedPaths` leer halten, wieder exakt eine Primary-Zeile je Gate liefern und mit `validate-autonomous-gate-evidence.ps1 -Head <reviewed-head> -MergeCommit <merge-sha>` validieren. **Voraussetzungen**: T071; **Nachweis**: Validator-Exitcode 0 und Merge/Sync/Head-Kausalität; **Sichere Grenze**: Intake-/Rename-Arbeit beginnt erst nach diesem bestandenen PostMerge-Gate.

**Checkpoint**: Implementierungs-PR ist reviewkonvergent gemerged, `main` exakt
synchronisiert und Schema-2.0-PostMerge-Evidenz gültig.

---

## Phase 8: Separater kausaler Closeout und finaler Leerlauf / Causal Closeout and Final Idle State

**Zweck / Purpose**: Erst nach dem Produktmerge das Lastenheft und exakt die
Serie `tinycalc-delivery` kausal schließen, ohne Feature 004 zu starten.

- [ ] T073 Nach T072 Run-State, PostMerge-Hash, Stop-Status und ausdrückliche aktuelle Autorität für Lastenheft-Rename, genau eine Serienmutation und gegebenenfalls den vorbenannten Closeout-PR revalidieren. **Voraussetzungen**: T072; **Nachweis**: Autorisierer, erlaubte Operationen und exact main in `specs/003-terminalgui-migration/autonomous-run-evidence.md`; **Sichere Grenze**: ohne neue Intake-Autorität keine Mutation, gespeicherte Merge-Autorität reicht nicht.
- [ ] T074 Vom synchronisierten `main` ausschließlich den vorbenannten Branch `codex/003-terminalgui-migration-closeout` erzeugen, auf dem macOS-Ausführungsort exakt `bash scripts/rename-lastenheft.sh requirements/intakes/active/Lastenheft_TerminalGui_Migration.md 003-terminalgui-migration` ausführen und den vom Skript erzeugten vorläufigen Closeout-Commit unmittelbar so amendieren, dass er die exakte Trailerzeile `Co-authored-by: Copilot <223556219+Copilot@users.noreply.github.com>` genau einmal enthält. **Voraussetzungen**: T073; **Nachweis**: exakter Zielpfad `requirements/intakes/active/Lastenheft_TerminalGui_Migration.003-terminalgui-migration.md`, keine Skriptänderung, genau ein vorläufiger Closeout-Commit und exakter Trailer laut `git log -1 --format=%B`; **Sichere Grenze**: auf macOS/Linux kein PowerShell-Rename, keinen alternativen Closeout-Branch, keinen Feature-004-Rename und vor T078 keinen zweiten Commit erzeugen.
- [ ] T075 Mit erneut bestätigter Serienautorität genau `speckit-intake-series-update` für `tinycalc-delivery` ausführen, Vorgängerlinie archivieren und nur die kausal notwendigen Serienartefakte unter `requirements/intakes/series/tinycalc-delivery/` aktualisieren. **Voraussetzungen**: T074; **Nachweis**: Operation/Receipt, archivierte Vorgängerlinie und Feature-003-Abschluss; **Sichere Grenze**: keine andere Serie, kein nächster Intake und keine Feature-004-Spezifikation starten.
- [ ] T076 Unmittelbar danach `speckit-intake-series-status` read-only ausführen und Ergebnis in `specs/003-terminalgui-migration/autonomous-run-evidence.md` festhalten. **Voraussetzungen**: T075; **Nachweis**: Serie gültig, kein nächstes Feature gestartet, `no-next-feature` ausdrücklich belegt; **Sichere Grenze**: Statusausgabe ist keine Autorität für weitere Arbeit.
- [ ] T077 Vor dem einzigen Closeout-PR-Merge alle getrackten Closeout-Nachweise abschließen: `docs/project-statistics.config.json` ergänzen, `pwsh -NoProfile -File scripts/render-project-statistics.ps1 -Repo .` plus `-CheckOnly` ausführen, `specs/003-terminalgui-migration/autonomous-run-evidence.md` um finalen Produkt-Merge-/PostMerge-/Serienstatus ergänzen und `specs/003-terminalgui-migration/evidence/delivery.md` mit Closeout-Head, erwarteter Provider-Verifikation und der terminalen getrackten Proof-Grenze vorbereiten. **Voraussetzungen**: T076; **Nachweis**: Statistikregeln erfüllt, alle bis zum Closeout-Head bekannten Fakten kausal erfasst und ausdrücklich festgelegt, dass spätere Closeout-PR-/Merge-/Sync-Fakten nur read-only in `.specify/runtime/autonomous-routing/38ad4c1d-bf85-4053-b585-eb490176b727/closeout-provider-evidence.json` belegt werden; **Sichere Grenze**: nach dem Closeout-Merge keine getrackte Datei, insbesondere weder `delivery.md` noch Run-State, mehr ändern.
- [ ] T078 Den kausalen Closeout-Diff mit Exact-Path-Delivery-Set-Validator, `git diff --name-status`, `git diff --check` und verbotenen Pfadprüfungen validieren, die nach T074 entstandenen autorisierten Serien-/Statistik-/Run-/Delivery-Evidenzänderungen exakt stagen und mit `git commit --amend --no-edit` in den vorhandenen Rename-Commit aufnehmen; danach die exakte Trailerzeile `Co-authored-by: Copilot <223556219+Copilot@users.noreply.github.com>` erneut maschinenlesbar prüfen. **Voraussetzungen**: T077; **Nachweis**: Branch besitzt genau einen finalen Closeout-Commit mit nur Rename, autorisierten Serienartefakten, notwendiger Statistik und getrackter Evidenz; `git log -1 --format=%B` enthält den Trailer exakt einmal; **Sichere Grenze**: fehlender Trailer blockiert, kein zweiter oder leerer Commit, kein dritter Branch/PR und kein Produkt-/Testdiff.
- [ ] T079 Nach erneuter Remote-Autoritätsprüfung den Closeout-Branch pushen, genau einen kausalen Closeout-PR eröffnen und Checks/Reviews bis null offene Befunde konvergieren. Den Provider-Merge mit `gh pr merge <closeout-pr-number> --merge --subject 'chore: close Feature 003 delivery' --body "Feature 003 causal closeout.`n`nCo-authored-by: Copilot <223556219+Copilot@users.noreply.github.com>"` ausführen, nur unter derselben engen T069-Grenze gegebenenfalls `--admin` ergänzen und unmittelbar danach den tatsächlichen Merge-SHA mit `gh pr view ... --json mergeCommit` sowie die tatsächliche Commit-Nachricht mit `gh api repos/{owner}/{repo}/commits/<merge-sha> --jq '.commit.message'` read-only prüfen; exakt eine Trailerzeile ist Pflicht, bevor lokales `main` per Fast-Forward synchronisiert wird. PR-Nummer, Closeout-Head, Checks, Reviews, Merge-Commit, sofortige Trailerprüfung sowie lokales/remote `main` ausschließlich read-only in `.specify/runtime/autonomous-routing/38ad4c1d-bf85-4053-b585-eb490176b727/closeout-provider-evidence.json` ablegen. **Voraussetzungen**: T078; **Nachweis**: Runtime-/Provider-Evidenz bindet alle Fakten, Hashes und die unmittelbare exakte Trailerprüfung; **Sichere Grenze**: fehlender/abweichender/mehrfacher Trailer blockiert vor Sync/T080; keine Änderung an getracktem `delivery.md`, Run-State oder sonstiger getrackter Datei, kein dritter Commit/PR; Admin-Bypass ersetzt kein technisches Gate.
- [ ] T080 Final Delivery-Set, beide Schema-2.0-Lifecycle-Nachweise, den unveränderten getrackten Closeout-Head, Runtime-/Provider-Evidenz, Merge-/Sync-Zustand, branchgestempeltes Lastenheft, Serienstatus und `no-next-feature` read-only prüfen und erst dann den autonomen Lauf als abgeschlossen melden. **Voraussetzungen**: T079; **Nachweis**: alle 80 Aufgaben, alle 48 Gates, alle N/A-Revalidierungen, Review, MergeAndSync, PostMerge und kausaler Closeout vollständig; exakter Trailer in jedem lokalen und Provider-erzeugten Commit-Task, wobei T070/T079 bereits unmittelbar geprüft wurden; nach dem Closeout-Merge null getrackte Writes und keine ausstehende nächste Aktion außer Leerlauf; der nach Prozessrückkehr aktualisierte lokale `autonomous-run-state.json` bleibt gemäß T005 ungetrackt und ignoriert und verändert daher weder `main` noch das Delivery-Set. **Sichere Grenze**: T080 ist finale Verifikation, niemals erste Trailerprüfung; der operative Run-State darf nie gestagt werden; jeder fehlende oder veraltete Beleg ergibt `Blocked`/`Failed`, niemals `Completed`, Feature 004 bleibt ungestartet und es entsteht kein dritter Commit/PR.

---

## Abhängigkeiten / Dependencies

```text
Phase 1 Gate-Freeze
  -> Phase 2 Source-Contract Red + Dependency-Only Compile Red
  -> US1 Complete v2 Compile-Compatibility Green + Lifecycle Refactor
  -> US2 Keyboard/Event Migration + Two Manual Sessions
  -> US3 Regression + Out-of-Process Coverage + Dependency Audit
  -> US4 Architecture/Security/A11Y/Supply-Chain/Statistics Evidence
  -> Exact-Head PR + Linux/Windows CI + Schema-2.0 PreMerge
  -> Review Convergence + Narrow-Bypass Revalidation + MergeAndSync
  -> Schema-2.0 PostMerge
  -> Separate Causal Lastenheft/Series Closeout
  -> Final Read-Only no-next-feature State
```

- US1 ist das MVP, benötigt aber die beiden roten Verträge aus Phase 2.
- US2 baut auf der grünen Lifecycle-Instanz auf, bleibt durch seine 13-Key-
  und Zwei-Sitzungs-Abnahme unabhängig verifizierbar.
- US3 nutzt die echten US1-/US2-Pfade für Coverage und verändert keine
  Testquelle.
- US4 kann erst nach stabiler Produkt-/Regressionsevidenz abgeschlossen werden.
  T046–T051 dürfen danach parallel laufen, weil ihre Writer-Pfade verschieden
  sind; T053 läuft danach seriell, liest diese Ergebnisse und schreibt einen
  eigenen Pfad.
- Delivery ist streng seriell, weil Commit-SHA, PR-Head, Reviews, Gate-Hashes,
  Merge-Commit und Intake-Linie kausal aufeinander folgen.

## Gate-Abdeckung / Gate Coverage

| Gate | Primäre Aufgaben / Primary tasks |
|---|---|
| TG-GATE-001..002 | T001–T002, T060, T073 |
| TG-GATE-003..004 | T007, T009–T010, T034, T042–T043 |
| TG-GATE-005..006 | T014–T023, T024–T028 |
| TG-GATE-007..009 | T015, T019, T022, T027, T035–T037, T066 |
| TG-GATE-010..011 | T008–T012, T014–T017, T021–T023, T029–T030, T038–T041 |
| TG-GATE-012..014 | T029–T032, T046–T058 |
| TG-GATE-015 | T005, T013, T033, T044, T059, T062, T078 |
| TG-GATE-016..018 | T046–T050 |
| TG-GATE-019..021 | T043, T051–T052, T066–T067 |
| TG-GATE-022..028, -031..034 | T052, T057, T067, T072 |
| TG-GATE-029..030 | T046, T052, T057, T067, T072 |
| TG-GATE-035 | T006, T011, T015, T019, T022, T027, T035–T036, T038, T061 |
| TG-GATE-036 | T055, T077 |
| TG-GATE-037..038 | T059, T066 |
| TG-GATE-039 | T005, T059, T062–T064, T078–T080 |
| TG-GATE-040 | T067, T072, T080 |
| TG-GATE-041 | T068, T079 |
| TG-GATE-042..043 | T060, T070–T072, T079–T080 |
| TG-GATE-044..045 | T073–T080 |
| TG-GATE-046 | T043, T057, T067, T072 |
| TG-GATE-047 | T069–T070, bei Bedarf T079 |
| TG-GATE-048 | T063–T064, T070, T074, T078–T080 |

## Umsetzungsstrategie / Implementation Strategy

1. **MVP zuerst**: Phase 1, beide Red-Verträge und T014 liefern vor T015 die
   minimale vollständige v2-Compile-Kompatibilität; US1 bis T023 verfeinert
   Lifecycle-, Dialog- und Ownership-Verhalten auf grünem Compile-Stand.
2. **Inkrementell**: US2 verfeinert Ereignisse und Tasten auf dem bereits
   compile-kompatiblen Stand; US3 beweist danach unveränderte Regression und
   reale Coverage.
3. **Evidence before delivery**: Security-, Architektur-, A11Y- und
   Supply-Chain-Dokumente werden vor dem ersten Commit vollständig vorbereitet,
   aber erst am unveränderten PR-Head als Gate-Evidenz akzeptiert.
4. **Fail closed**: Fehlende Windows-/Linux-Produkt-CI, Coverage unter 70
   Prozent, jede bekannte Schwachstelle oder unbekannte/inkompatible Lizenz im
   ausgelieferten Graph, Scope-Drift, offene Review oder falscher Head stoppt.
5. **Kausaler Abschluss**: Lastenheft und Serie werden erst nach gültigem
   Produkt-PostMerge getrennt geschlossen; kein Nachfolger startet automatisch.

## Format- und Vollständigkeitsprüfung / Format and Completeness Check

- Gesamtzahl / Total: **80 Aufgaben / tasks** (`T001`–`T080`).
- US1: **10**, US2: **10**, US3: **12**, US4: **14**.
- Setup/Red: **13**, Delivery: **13**, PostMerge-Closeout: **8**.
- Parallel markiert: **T046–T051**, ausschließlich unterschiedliche
  Writer-Pfade nach gemeinsamem Checkpoint T045.
- Jede Aufgabe besitzt stabile ID, exakte Pfade, Voraussetzungen, erwarteten
  Nachweis und sichere Grenze.
- Bestehende Testquellen, FakeDriver, Core, Rename-Feature, Skript-/Agent-
  Paritätsarbeit, andere Workflows und andere N/A-Implementierungen sind nicht
  eingeplant; `.github/workflows/ci.yml` ist die einzige enge Workflow-Ausnahme.
