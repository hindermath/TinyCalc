# TUI-Kompatibilitätsvertrag / TUI Compatibility Contract

## Lifecycle

- `--smoke` initialisiert keinen Terminaltreiber und endet mit Exitcode `0` und
  dem exakten Token `SMOKE_OK`. / Smoke never initialises the terminal
  driver and exits 0 with the exact token.
- Interaktiv existiert genau eine `IApplication`; Create, Init, Run, Stop und
  Dispose folgen in gültiger Reihenfolge. / Interactive mode has exactly one
  application with valid create/init/run/stop/dispose order.
- Root und Dialoge haben eindeutige Dispose-Owner; ein Dialog kehrt in die
  Hauptsession zurück. / Root and dialogs have clear disposal owners; dialogs
  return to the main session.
- Menü-Quit und `Ctrl+Q` beenden sauber und stellen das Terminal wieder her. /
  Menu quit and Ctrl+Q exit cleanly and restore the terminal.

## Eingaben / Inputs

```text
Up:    CursorUp, Ctrl+E
Down:  CursorDown, Ctrl+X, Ctrl+J
Right: CursorRight, Ctrl+D, Ctrl+M, Enter
Left:  CursorLeft, Ctrl+S, Ctrl+A
Quit:  Ctrl+Q
```

Das sind genau 13 bindende Eingaben. Jede erkannte Eingabe löst eine Aktion
aus. Unbekannte Eingaben erzeugen keine neue fachliche Wirkung.

*These are exactly 13 binding inputs. Each recognised input causes one action.
Unknown input gains no new domain effect.*

## Oberflächen und Fehler / Surfaces and Errors

Menüs, Datei-/Funktions-/Eingabedialoge, Hilfe und Fokusreihenfolge bleiben
funktional verfügbar. Endnutzerfehler enthalten keine Stacktraces, internen
Pfade oder Secrets. Core-Aufrufe, Dateiformate und vorhandene Testquellen sind
außerhalb des Änderungssatzes.

*Menus, file/function/input dialogs, help, and focus order remain available.
User-facing errors expose no stack traces, internal paths, or secrets. Core
calls, file formats, and existing test sources are outside the change set.*

## Abnahme / Acceptance

Der Vertrag wird durch Source-Inventar, Release-Build, vollständige bestehende
Tests, Smoke, Coverage und die manuelle macOS-Prüfung erfüllt. Linux und Windows
benötigen reale CI-Protokolle. Eine bloße Code-Inspektion ersetzt keinen
Plattformlauf.

*The contract is accepted through source inventory, Release build, all existing
tests, smoke, coverage, and manual macOS verification. Linux and Windows need
real CI logs. Code inspection cannot replace a platform run.*
