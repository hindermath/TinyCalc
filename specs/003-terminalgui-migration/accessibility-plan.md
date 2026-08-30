# Barrierefreiheitsplan / Accessibility Plan

## Ziel / Goal

Die Terminal.Gui-2-Migration erhält vollständige Tastaturbedienung, sichtbaren
Fokus, verständliche Reihenfolge und textbasierte Nachweise nach WCAG 2.2 AA.
Neue Lerndokumentation ist Deutsch zuerst, Englisch danach und CEFR B2.

*The Terminal.Gui 2 migration preserves full keyboard operation, visible focus,
understandable order, and text-based evidence under WCAG 2.2 AA. New learner
documentation is German first, English second, at CEFR B2.*

## Bindende 13-Tasten-Matrix / Binding 13-key Matrix

| Nr. | Eingabe / Input | Ergebnis / Result |
|---:|---|---|
| 1 | `CursorUp` | eine Zelle nach oben / one cell up |
| 2 | `Ctrl+E` | eine Zelle nach oben / one cell up |
| 3 | `CursorDown` | eine Zelle nach unten / one cell down |
| 4 | `Ctrl+X` | eine Zelle nach unten / one cell down |
| 5 | `Ctrl+J` | eine Zelle nach unten / one cell down |
| 6 | `CursorRight` | eine Zelle nach rechts / one cell right |
| 7 | `Ctrl+D` | eine Zelle nach rechts / one cell right |
| 8 | `Ctrl+M` | eine Zelle nach rechts / one cell right |
| 9 | `Enter` | eine Zelle nach rechts / one cell right |
| 10 | `CursorLeft` | eine Zelle nach links / one cell left |
| 11 | `Ctrl+S` | eine Zelle nach links / one cell left |
| 12 | `Ctrl+A` | eine Zelle nach links / one cell left |
| 13 | `Ctrl+Q` | Anwendung beenden / quit application |

Jede Taste wird einzeln aus einem bekannten Zellzustand geprüft. Der Nachweis
nennt Ausgangszelle, erwartete Zielzelle, tatsächliche Zielzelle und Status.

*Each key is tested separately from a known cell. Evidence records source cell,
expected target cell, actual target cell, and status.*

## Manuelle Sequenzen / Manual Sequences

1. Erste macOS-Release-TUI starten und Startfokus identifizieren. / Start the
   first macOS Release TUI and identify initial focus.
2. Die zwölf Navigations-Eingaben (Matrix 1-12) einzeln aus bekannten
   Zellzuständen prüfen. / Verify the twelve navigation inputs (matrix 1-12)
   individually from known cells.
3. Menü, Datei-/Funktions-/Eingabedialog öffnen, Fokusreihenfolge vorwärts und
   rückwärts prüfen und Dialog schließen. / Open menu, file/function/input
   dialogs, verify forward and reverse focus order, then close them.
4. Ersten Lauf über den Menüpunkt beenden. / Quit the first run through the menu.
5. Zweite Release-TUI starten und die dreizehnte bindende Eingabe `Ctrl+Q`
   einzeln prüfen. / Start a second Release TUI and verify the thirteenth
   binding input, `Ctrl+Q`, individually.
6. Zweiten Lauf durch diesen `Ctrl+Q`-Nachweis beenden. / End the second run
   through that `Ctrl+Q` proof.
7. Terminalwiederherstellung und fehlende Tracebacks nach jedem Lauf prüfen. /
   Check terminal restoration and absence of tracebacks after each run.

Damit werden genau 13 Eingaben und zwei verschiedene Beenden-Wege in zwei
Sitzungen belegt. „Im ersten Durchgang“ bedeutet wörtlich der erste Versuch jeder
Sitzung, nicht der erste erfolgreiche Versuch. Scheitert einer dieser ersten
Versuche, ist SC-006 für diesen Akzeptanzlauf gescheitert; ein späterer Erfolg
darf den Fehlversuch nicht als ersten Durchgang umdeuten. Die zwei Beenden-Wege
bleiben auf zwei Prozesse verteilt. / *This proves exactly 13 inputs and two
different quit paths across two sessions. “First run” literally means the first
attempt for each session, not the first successful attempt. If either first
attempt fails, SC-006 fails for that acceptance run; a later success cannot
relabel the failed attempt as the first run. The two quit paths remain split
across two processes.*

## WCAG-2.2-AA-Matrix / WCAG 2.2 AA Matrix

| Kriterium / Criterion | Status | Evidenz / Evidence |
|---|---|---|
| 1.4.1 Use of Color | Applicable | Bedeutung darf nicht nur durch Farbe entstehen; Fokus zusätzlich durch Position/Marker/Text prüfen. |
| 2.1.1 Keyboard | Applicable | 13-Key-Matrix, Menüs und Dialoge ohne Pointer. |
| 2.1.2 No Keyboard Trap | Applicable | Fokus kann Dialoge verlassen; beide Quit-Pfade funktionieren. |
| 2.4.3 Focus Order | Applicable | vorwärts/rückwärts in Hauptansicht und Dialogen. |
| 2.4.7 Focus Visible | Applicable | aktueller Fokus ist textuell oder durch klaren Terminalmarker erkennbar. |
| Pointer Gestures/Dragging | N/A | TUI besitzt keinen Pointer-Primärpfad; Trigger: Maus-/Touchfunktion. |
| Images/Alt Text | N/A | keine Bilder; Trigger: nicht-textuelles UI-Artefakt. |
| Captions/Audio | N/A | keine Zeitmedien; Trigger: Audio/Video. |

Der Accessibility-Nachweis wird in
`docs/accessibility/terminalgui-migration.md` DE-first/EN-second abgelegt. Ein
Screenshot darf ergänzen, ersetzt aber niemals die textuelle Beschreibung.

*Accessibility evidence is stored in the stated file, German first and English
second. A screenshot may supplement but never replace the text description.*
