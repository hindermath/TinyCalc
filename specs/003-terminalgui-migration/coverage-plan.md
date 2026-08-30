# Coverage- und TDD-Plan / Coverage and TDD Plan

## Rot-Grün-Aufräumen / Red-Green-Refactor

1. **Rot / Red:** Statischer Akzeptanzvertrag prüft auf v1-Symbole, exakte
   Paketversion, acht Masken-Migrationen, Lifecycle und Key-Matrix. Danach wird
   nur das Paket geändert; der erwartete Compile-Fehler beweist die
   Abhängigkeitsinkompatibilität. Keine vorhandene Testquelle ändert sich.
2. **Grün, vertikaler Schnitt / Green vertical slice:** Eine App-Instanz
   erstellen, initialisieren, minimales Root-Runnable ausführen, über einen
   Quit-Pfad stoppen und alles disposen. Vor dem ersten geforderten grünen
   Whole-Solution-Build müssen zusätzlich alle compilerbedingt nötigen v2-
   Anpassungen für Dialoge, Buttons, Events und Keyboard-APIs abgeschlossen
   sein. Erst dann müssen Release-Build plus Smoke grün sein.
3. **Aufräumen / Refactor:** Die bereits compile-kompatiblen Dialoge, Events
   und alle 13 Tasten auf Verhaltens-, Fokus- und Ownership-Parität verfeinern;
   doppelte Adapterlogik entfernen; vollständige Tests, Coverage und manuelle
   Abnahme ausführen.

*Red uses an external source contract and the dependency-only compile failure.
Before the first required green whole-solution build, the representative slice
spans create/init/root/run/quit/dispose plus minimum compile compatibility for
dialogs, buttons, events, and keyboard APIs. Refactor then improves behavioural,
focus, and ownership parity before full verification.*

Rohbelege liegen unter `/tmp/tinycalc-003/coverage/` und werden mit SHA-256 in
der Feature-Evidenz referenziert. Vor jedem `dotnet build` oder `dotnet test`
wird der repo-weite Build-Zähler serialisiert erhöht.

*Raw evidence lives under the stated temporary path and is referenced with
SHA-256. Before each build or test, the repository-wide build counter is
serially incremented.*

## Erfassungsbefehle / Collection Commands

```powershell
dotnet-coverage collect --output /tmp/tinycalc-003/coverage/tests.coverage --output-format coverage -- dotnet test MicroCalc.sln --configuration Release --no-build
dotnet-coverage collect --output /tmp/tinycalc-003/coverage/smoke.coverage --output-format coverage -- dotnet run --no-build --configuration Release --project src/MicroCalc.Tui/MicroCalc.Tui.csproj -- --smoke
dotnet-coverage collect --output /tmp/tinycalc-003/coverage/manual-menu.coverage --output-format coverage -- dotnet run --no-build --configuration Release --project src/MicroCalc.Tui/MicroCalc.Tui.csproj
dotnet-coverage collect --output /tmp/tinycalc-003/coverage/manual-ctrlq.coverage --output-format coverage -- dotnet run --no-build --configuration Release --project src/MicroCalc.Tui/MicroCalc.Tui.csproj
dotnet-coverage merge --output /tmp/tinycalc-003/coverage/terminalgui.cobertura.xml --output-format cobertura /tmp/tinycalc-003/coverage/tests.coverage /tmp/tinycalc-003/coverage/smoke.coverage /tmp/tinycalc-003/coverage/manual-menu.coverage /tmp/tinycalc-003/coverage/manual-ctrlq.coverage
```

Der erste manuelle Prozess deckt die zwölf Navigations-Eingaben, Dialoge,
Fokus und Menü-Quit ab. Der zweite Prozess deckt die dreizehnte Eingabe
`Ctrl+Q` und die erneute Terminalwiederherstellung ab. Beide Coverage-Dateien
sind Pflichtbestandteile des Merge-Befehls.

*The first manual process covers twelve navigation inputs, dialogs, focus, and
menu quit. The second covers the thirteenth input, `Ctrl+Q`, and terminal
restoration again. Both coverage files are mandatory merge inputs.*

## Changed-Code-Berechnung / Changed-code Calculation

1. `git diff --unified=0 main...HEAD -- src/MicroCalc.Tui/Program.cs`
   liefert hinzugefügte/geänderte Zeilennummern.
2. Generierte, leere, Klammer- und reine Kommentarzeilen werden nach einer im
   Bericht festgehaltenen, deterministischen Regel ausgeschlossen.
3. Cobertura-Zeilentreffer werden auf diese ausführbaren geänderten Zeilen
   geschnitten.
4. `covered / executable changed * 100` muss `>=70` sein; `>=80` ist das Ziel.
5. Nenner, Zähler, ausgeschlossene Zeilen und Toolversion werden in
   `specs/003-terminalgui-migration/evidence/coverage-summary.md` festgehalten.

*Changed lines come from the zero-context Git diff, deterministic non-executable
exclusions are recorded, and Cobertura hits are intersected with executable
changed lines. The minimum is 70%; the target is 80%.*

Eine fehlende oder nicht reproduzierbare Berechnung, ein Wert unter 70 %, ein
ausgelassener interaktiver Pfad oder eine Änderung vorhandener Testquellen
blockiert.

*Missing or irreproducible calculation, coverage below 70%, an omitted
interactive path, or an existing-test-source change blocks delivery.*
