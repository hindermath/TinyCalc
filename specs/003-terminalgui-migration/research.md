# Forschung und Entscheidungen / Research and Decisions

## Verbindliche Entscheidungen / Binding Decisions

### R-01: Terminal.Gui 2.4.17

**Entscheidung:** `MicroCalc.Tui` verwendet die exakte stabile Version `2.4.17`.
Sie zielt auf .NET 10 und ist die zum Planungszeitpunkt aktuelle stabile
2.x-Version. Floating Ranges bleiben verboten.

**Decision:** `MicroCalc.Tui` uses exact stable version `2.4.17`. It targets
.NET 10 and is the current stable 2.x release at planning time. Floating ranges
remain prohibited.

**Aktueller Primärquellennachweis / Current primary-source evidence
(2026-08-30):** Die NuGet Gallery führt `2.4.17` als aktuelle stabile Version;
`2.4.18-develop.*` ist nur als Vorabversion gelistet. Die Paketmetadaten
deklarieren `net10.0` als enthaltenes Ziel-Framework und zeigen die exakte
`PackageReference`-Version. Diese zeitabhängigen Fakten werden vor Restore und
Release erneut geprüft. / *The NuGet Gallery lists `2.4.17` as the current
stable version; `2.4.18-develop.*` is prerelease only. Package metadata declares
`net10.0` as an included target framework and shows the exact PackageReference
version. Revalidate these mutable facts before restore and release.*

**Quellen / Sources:** [NuGet-Paket](https://www.nuget.org/packages/Terminal.Gui),
[offizielles Repository](https://github.com/tui-cs/Terminal.Gui)

### R-02: Instanzbasierter Lebenszyklus

**Entscheidung:** Eine mit `Application.Create()` erzeugte `IApplication` wird
initialisiert, führt Root und Dialoge aus und wird eindeutig disposed. Dies
ersetzt statische v1-Aufrufe und verhindert uneindeutigen Ressourcenbesitz.

**Decision:** One `IApplication` created with `Application.Create()` is
initialised, runs the root and dialogs, and is disposed by a clear owner. This
replaces static v1 calls and avoids ambiguous resource ownership.

**Quellen / Sources:** [v1-Migrationsleitfaden](https://tui-cs.github.io/Terminal.Gui/docs/migratingfromv1),
[Application-Dokumentation](https://tui-cs.github.io/Terminal.Gui/docs/application)

Die aktuelle offizielle Dokumentation belegt `Application.Create().Init()`,
`app.Run(runnable)`, `app.RequestStop()` und den Dispose-Vertrag „Erzeuger
besitzt“. Ein vom Aufrufer erzeugtes Runnable wird vom Aufrufer disposed;
verschachtelte Sessions liegen auf derselben App-Instanz. / *Current official
documentation evidences `Application.Create().Init()`, `app.Run(runnable)`,
`app.RequestStop()`, and creator-owned disposal. A caller-created runnable is
disposed by the caller, while nested sessions share the same app instance.*

### R-03: Tastatur- und Ereignis-API

**Entscheidung:** Alte `CtrlMask`-Ausdrücke werden durch die v2-Tastendarstellung
mit `.WithCtrl` ersetzt. Eingaben werden über v2-Key-Events/KeyBindings und
Button-Aktionen über `Accepting` abgebildet. Die 13 Eingaben ändern ihr
fachliches Ergebnis nicht.

**Decision:** Legacy `CtrlMask` expressions move to the v2 key representation
with `.WithCtrl`. Input uses v2 key events/key bindings and button actions use
`Accepting`. The behaviour of all 13 inputs remains unchanged.

**Quellen / Sources:** [Keyboard-Dokumentation](https://tui-cs.github.io/Terminal.Gui/docs/keyboard),
[v1-Migrationsleitfaden](https://tui-cs.github.io/Terminal.Gui/docs/migratingfromv1)

Die aktuelle Dokumentation belegt `Key.Q.WithCtrl`, `KeyDown`/KeyBindings mit
behandeltem Rückgabevertrag und `Button.Accepting` als Ersatz für
`Button.Clicked`. Die konkrete Wahl zwischen KeyBinding und direktem KeyDown
bleibt compiler- und verhaltensgetrieben innerhalb von `Program.cs`. / *Current
documentation evidences `Key.Q.WithCtrl`, `KeyDown`/KeyBindings with handled
semantics, and `Button.Accepting` replacing `Button.Clicked`. The concrete
choice remains compiler- and behaviour-driven within `Program.cs`.*

### R-04: Testgrenze und Coverage

**Entscheidung:** Vorhandene Testquellen bleiben unverändert. Rot entsteht aus
einem statischen Akzeptanzvertrag und dem dependency-only
Inkompatibilitätszustand. `dotnet-coverage` sammelt Tests, Smoke und den
manuellen TUI-Prozess und führt die Cobertura-Dateien zusammen. Geänderte
ausführbare Zeilen müssen mindestens 70 %, angestrebt 80 %, erreichen.

**Decision:** Existing test sources remain unchanged. Red evidence comes from a
static acceptance contract and the dependency-only incompatibility state.
`dotnet-coverage` collects tests, smoke, and the manual TUI process and merges
the Cobertura files. Changed executable lines require at least 70%, targeting
80%.

**Quelle / Source:** [dotnet-coverage](https://learn.microsoft.com/en-us/dotnet/core/additional-tools/dotnet-coverage)

### R-05: Dependency Audit, SBOM und SLSA

**Entscheidung:** .NET-10-`dotnet package list` liefert Paket- und
Schwachstellenberichte. Das lokal verfügbare Syft `1.51.0` erzeugt SPDX-JSON
aus dem Release-Drop. SLSA wird nur mit tatsächlich vorhandener CI-Provenienz
bewertet; ohne signierte Attestation wird kein höheres Level behauptet.

**Decision:** .NET 10 `dotnet package list` supplies package and vulnerability
reports. Locally available Syft `1.51.0` generates SPDX JSON from the release
drop. SLSA is assessed only from actual CI provenance; no higher level is
claimed without a signed attestation.

**Quelle / Source:** [dotnet package list](https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-package-list)

### R-06: Plattformnachweis

**Entscheidung:** macOS ist Entwicklungs- und manueller Abnahmeort. Linux und
Windows benötigen echte Produkt-Restore-, Build-, Test- und Smoke-Protokolle.
Der vorhandene Ubuntu-Produktjob belegt nur Restore, Build und Tests, aber noch
keinen Smoke-Lauf; ein vollständiger Linux-Beleg fehlt daher ebenfalls. Ein
Windows-Jobname ohne Produktbefehle reicht nicht. Thorstens aktuelle
vollständige Feature-003-Autorität erlaubt deshalb exakt die minimale
Erweiterung von `.github/workflows/ci.yml` um dieselben vier Produktbefehle und
die exakte `SMOKE_OK`-Prüfung auf beiden Runnern für den PR-Head. Jede andere
Workflow- oder Automationsänderung bleibt ausgeschlossen.

**Decision:** macOS is the development and manual acceptance platform. Linux
and Windows require real product restore, build, test, and smoke logs. The
current Ubuntu product job proves restore, build, and tests but does not run
smoke, so full Linux evidence is also missing. A Windows job name without
product commands is insufficient. Thorsten's current complete Feature 003
authority therefore permits exactly the minimum `.github/workflows/ci.yml`
extension for the same four product commands and exact `SMOKE_OK` assertion on
both runners at the PR head. Every other workflow or automation change remains
excluded.

### R-07: Bewusste Nicht-Entscheidungen / Explicit Non-decisions

- Kein FakeDriver in Feature 003; erneute Prüfung in einem freigegebenen
  Follow-up. / No FakeDriver in Feature 003; reconsider in an authorised
  follow-up.
- Kein neues Repository-Lockfile-Schema; Trigger ist eine repositoryweite
  Lockfile-Policy. / No new repository lockfile scheme; a repository-wide
  lockfile policy is the trigger.
- Kein DocFX-Lauf ohne öffentliche API-, XML- oder Navigationsänderung. / No
  DocFX run without a public API, XML, or navigation change.
- Keine Core-, Dateiformat- oder Testquellenänderung. / No Core, storage format,
  or test-source change.

## Offene Punkte / Open Items

Es gibt keine offene technische Klärung für die Task-Erzeugung. Der echte
Windows-Nachweis ist eine spätere Delivery-Gate-Anforderung und kein
unaufgelöster Designpunkt.

*There is no unresolved technical clarification for task generation. Real
Windows evidence is a later delivery-gate requirement, not an open design
decision.*
