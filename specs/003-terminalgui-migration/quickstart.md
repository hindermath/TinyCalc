# Umsetzungs-Quickstart / Implementation Quickstart

Dieser Quickstart ist ein späterer Ausführungsvertrag. Die Planphase führt die
Befehle nicht aus.

*This quickstart is a later execution contract. The planning phase does not run
these commands.*

## 1. Zustand und Toolchain / State and Toolchain

```powershell
pwsh -NoProfile -File .specify/presets/autonomous-run-governance/scripts/validate-autonomous-run-state.ps1 -State specs/003-terminalgui-migration/autonomous-run-state.json
git branch --show-current
git status --short
dotnet --version
pwsh --version
syft version
dotnet-coverage --version
```

Run-ID, `003-terminalgui-migration`, Intake-/Spec-Hashes, Delivery-Autorität und
Stop-Status müssen passen.

*Run ID, branch, intake/spec hashes, delivery authority, and stop state must
match.*

## 2. Rot / Red

Source-Vertrag gegen v1-Symbole und Key-/Lifecycle-Anforderungen ausführen,
dann ausschließlich die exakte Paketversion `2.4.17` setzen. Vor dem erwarteten
dependency-only Release-Build Build-Zähler erhöhen; Compile-Fehler als Red
archivieren. Vorhandene Testquellen bleiben unverändert.

*Run the source contract, then set only exact package version 2.4.17. Increment
the build counter before the expected dependency-only Release build and archive
the compile failure as Red. Existing test sources remain unchanged.*

## 3. Grüner vertikaler Schnitt / Green Vertical Slice

Create/Init/Root/Run/Quit/Dispose als kleinsten durchgängigen Schnitt migrieren.
Vor dem ersten geforderten grünen Whole-Solution-Build außerdem alle
compilerbedingt nötigen v2-Anpassungen für Dialoge, Buttons, Events und
Keyboard-APIs abschließen. Vor jedem folgenden Build/Test den Build-Zähler
erneut serialisiert erhöhen:

*Migrate create/init/root/run/quit/dispose as the smallest end-to-end slice.
Before the first required green whole-solution build, also complete every
compiler-required v2 adjustment for dialogs, buttons, events, and keyboard
APIs. Increment the build counter serially before each following build/test:*

```powershell
dotnet restore MicroCalc.sln
dotnet build MicroCalc.sln --configuration Release --no-restore
dotnet run --no-build --configuration Release --project src/MicroCalc.Tui/MicroCalc.Tui.csproj -- --smoke
```

Smoke muss exakt `SMOKE_OK` und Exitcode 0 liefern.

*Smoke must produce exact token `SMOKE_OK` and exit code 0.*

## 4. Refactor und vollständige Prüfung / Refactor and Full Verification

Die bereits compile-kompatiblen Namespaces, Events, Dialoge und alle acht
Masken-Ausdrücke/13 Eingaben auf Verhaltens-, Fokus- und Ownership-Parität
verfeinern, danach:

*Refine the already compile-compatible namespaces, events, dialogs, and all
eight mask expressions/13 inputs for behavioural, focus, and ownership parity,
then run:*

```powershell
dotnet test MicroCalc.sln --configuration Release --no-build
dotnet package list --project MicroCalc.sln --include-transitive --format json --no-restore
dotnet package list --project MicroCalc.sln --include-transitive --vulnerable --format json --no-restore
```

Coverage folgt exakt `coverage-plan.md`. Die macOS-TUI wird zweimal gestartet:
zuerst zwölf Navigations-Eingaben, Dialog-/Fokusprüfung und Menü-Quit; danach
die dreizehnte Eingabe `Ctrl+Q` als zweiter Quit-Pfad. Beide Sitzungen müssen
das Terminal wiederherstellen. Für SC-006 zählt wörtlich der erste Versuch
jeder Sitzung; ein Fehlversuch darf nicht als erster erfolgreicher Lauf
umbenannt werden.

*Coverage follows the coverage plan. Run the macOS TUI twice: first twelve
navigation inputs, dialog/focus checks, and menu quit; then the thirteenth
input, Ctrl+Q, as the second quit path. Both sessions must restore the
terminal. SC-006 literally uses the first attempt for each session; a failed
attempt cannot be relabelled as the first successful run.*

## 5. Plattform und Lieferkette / Platform and Supply Chain

`.github/workflows/ci.yml` wird als einzige Workflow-Änderung minimal so
erweitert, dass Linux (`ubuntu-latest`) und Windows (`windows-latest`) für den
exakten PR-Head Restore, Release-Build, vollständige Release-Tests und Smoke mit
Exitcode 0 sowie exakt `SMOKE_OK` real ausführen. SBOM, Dependency Audit,
SLSA-Status und OpenSSF-Review folgen den jeweiligen Plänen. Kein
Plattformbeleg darf aus einem Namen, Teilbefehl oder einem anderen OS abgeleitet
werden; kein anderer Workflow- oder Automationsdiff ist erlaubt.

*As the sole workflow change, `.github/workflows/ci.yml` is minimally extended
so Linux and Windows actually run restore, Release build, complete Release
tests, and smoke with exit code zero and exact `SMOKE_OK` for the exact PR head.
No platform evidence may be inferred from a name, partial command, or another
OS, and no other workflow or automation diff is authorised.*

## 6. Dokumentation und Delivery / Documentation and Delivery

Security-, A11Y-, Architektur-, Statistik- und PR-Nachweise DE-first/EN-second
abschließen; Version ausrichten; Delivery-Set validieren; Schema-2.0-PreMerge,
Review-Konvergenz, MergeAndSync und Schema-2.0-PostMerge gemäß `delivery-plan.md`
ausführen. Der Intake-Follow-up benötigt danach erneute Autorität.

*Complete bilingual evidence, align version, validate the delivery set, and
follow the pre-merge, review, merge/sync, and post-merge contracts. Intake
follow-up then requires renewed authority.*
