# Lastenheft: Terminal.Gui Migration 1.19.x → 2.x (TinyCalc)

**Dokument-Status:** Entwurf
**Erstellt:** 2026-03-31
**Betrifft:** `src/MicroCalc.Tui/` (ausschließlich — Core und Tests sind nicht betroffen)
**Empfohlener Durchführungszeitraum:** Als eigenständiger PR, idealerweise vor oder
gleichzeitig mit dem Rename-PR (`Lastenheft_Rename_MicroCalc_TinyCalc.md`), damit
beide Änderungen in einem sauberen Zustand zusammengeführt werden können.
**Abhängigkeit:** Keine Voraussetzung außer einem grünen `dotnet test MicroCalc.sln`.

---

## Ausgangslage

TinyCalc nutzt **Terminal.Gui 1.19.0** in genau **einer Datei**:
`src/MicroCalc.Tui/Program.cs`.

Es gibt **keine** Elmish-Abhängigkeit, **keine** FakeDriver-Tests und
**keinen** Einsatz von `Application.MainLoop`. Die Migration ist damit
die einfachste aller fünf Projekte im Workspace.

Das Zielbild ist das in TinyPl0 bereits umgesetzte **instanzbasierte
Lifecycle-Modell** von Terminal.Gui 2.0.0.

---

## Betroffene Stellen — vollständige Übersicht

**Datei:** `src/MicroCalc.Tui/Program.cs`

| Zeile (ca.) | Aktueller Code (v1.x) | Ziel (v2.x) |
|:-----------:|----------------------|-------------|
| 26 | `Application.Init();` | `Application.Init();` ¹ |
| 27 | `var top = Application.Top;` | `var top = Application.Top;` ¹ |
| 34 | `Application.Run();` | `Application.Run(top);` |
| 35 | `Application.Shutdown();` | `Application.Shutdown();` |
| 64 | `shortcut: Key.CtrlMask \| Key.Q` | `shortcut: Key.Ctrl + Key.Q` ² |
| 159, 275, 462, 472, 530, 537 | `Application.RequestStop()` | `Application.RequestStop()` ¹ |
| 195, 502, 544 | `Application.Run(dialog)` | `Application.Run(dialog)` ¹ |

¹ In v2 noch vorhanden; kein sofortiger Bruch, aber Lifecycle-Muster sollte
auf den empfohlenen v2-Stil umgestellt werden (siehe R-TG-TC-02).

² Key-Binding-API hat sich in v2 geändert: `Key.CtrlMask | Key.X` →
`Key.Ctrl + Key.X` oder `new Key(KeyCode.x, KeyModifier.Ctrl)`.

---

## Anforderungen

### R-TG-TC-01: Terminal.Gui auf 2.0.0 aktualisieren

Die `PackageReference` in `src/MicroCalc.Tui/MicroCalc.Tui.csproj` muss von
`Version="1.19.0"` auf `Version="2.0.0"` (oder die zum Zeitpunkt der Umsetzung
aktuelle 2.x-Version) angehoben werden.

### R-TG-TC-02: Lifecycle auf instanzbasiertes v2-Muster umstellen

Das empfohlene Muster in Terminal.Gui 2.x (analog zu TinyPl0) lautet:

```csharp
// v2-Empfehlung — direkt, kein top-Level nötig:
Application.Init();
// ... Setup ...
Application.Run<MainWindow>();
Application.Shutdown();
```

Oder falls eine explizite `Toplevel`-Instanz benötigt wird:

```csharp
Application.Init();
var top = new Toplevel();
top.Add(menu, window);
Application.Run(top);
Application.Shutdown();
```

Der bisherige Einstieg über `Application.Top` (statische Eigenschaft) ist in v2
noch vorhanden, aber deprecated. Er soll durch den direkten `Run<T>()`- oder
`Run(toplevel)`-Aufruf ersetzt werden.

### R-TG-TC-03: Key-Binding-API auf v2-Syntax umstellen

Alle Shortcut-Definitionen mit dem alten `Key.CtrlMask | Key.X`-Muster
müssen auf die v2-Syntax umgestellt werden.

| Alt (v1.x) | Neu (v2.x) |
|-----------|-----------|
| `Key.CtrlMask \| Key.Q` | `Key.Ctrl + Key.Q` |
| `Key.AltMask \| Key.X` | `Key.Alt + Key.X` |

### R-TG-TC-04: Smoke-Test muss nach Migration grün bleiben

TinyCalc hat einen eingebauten Smoke-Test-Modus (`--smoke`-Flag in Program.cs,
Klasse `TuiSmokeRunner`). Dieser muss nach der Migration unverändert
funktionieren:

```bash
dotnet run --no-build --configuration Release \
  --project src/MicroCalc.Tui/MicroCalc.Tui.csproj -- --smoke
# Erwartete Ausgabe: SMOKE_OK
```

### R-TG-TC-05: Alle bestehenden Tests müssen grün bleiben

```bash
dotnet test MicroCalc.sln --configuration Release
```

`MicroCalc.Core.Tests` und `MicroCalc.Tui.Tests` dürfen nach der Migration
keine neuen Fehler aufweisen.

### R-TG-TC-06: FakeDriver-Integrationstests einführen (mittelfristig)

Terminal.Gui 2.x bietet einen `FakeDriver` für Headless-Tests. Aktuell gibt es
keine TUI-spezifischen Tests. Nach der Migration sollen mindestens 3
FakeDriver-basierte Tests in `MicroCalc.Tui.Tests` ergänzt werden, die
grundlegende Keyboard-Navigation verifizieren (z. B. Menü öffnen, Zelle auswählen,
Quit-Shortcut auslösen). Dies ist **kein Pflichtziel dieses Migrations-PRs**,
aber ein empfohlener Folge-PR.

---

## Nicht im Scope

- Migration von `MicroCalc.Core` oder den Test-Projekten (kein Terminal.Gui)
- Neue Features oder Änderungen an der Formel-Engine
- MicroCalc → TinyCalc Umbenennung (separates Lastenheft)

---

## Akzeptanzkriterien

| ID | Kriterium |
|----|-----------|
| AK-TG-TC-01 | `MicroCalc.Tui.csproj` referenziert Terminal.Gui ≥ 2.0.0 |
| AK-TG-TC-02 | `Program.cs` nutzt kein veraltetes `Application.Top`-Muster mehr |
| AK-TG-TC-03 | Alle `Key.CtrlMask`-Ausdrücke durch v2-Syntax ersetzt |
| AK-TG-TC-04 | `--smoke`-Modus gibt `SMOKE_OK` aus |
| AK-TG-TC-05 | `dotnet test MicroCalc.sln --configuration Release` vollständig grün |
| AK-TG-TC-06 | TUI startet ohne Exception; Menü und Quit-Shortcut funktionieren manuell |

---

## Beispiel: Agentic-AI-Dialog (Platzhalter)

Dieser Abschnitt wird während der Umsetzung mit Commit-URLs und Zeitstempeln befüllt.
