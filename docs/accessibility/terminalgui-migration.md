# Barrierefreiheitsnachweis der Terminal.Gui-Migration / Terminal.Gui Migration Accessibility Evidence

## Umfang / Scope

Dieser Nachweis gilt für Feature `003-terminalgui-migration` und den lokalen
Release-Build `1.3.1.10` auf macOS arm64. Er bewertet die Migration von
Terminal.Gui 1.19.0 auf 2.4.17. Es wurde keine neue Bedienfunktion und kein
Barrierefreiheits-Redesign eingeführt. Maßstab ist WCAG 2.2 Level AA, soweit
die Kriterien auf eine textbasierte Terminaloberfläche anwendbar sind.

*This evidence covers feature `003-terminalgui-migration` and local Release
build `1.3.1.10` on macOS arm64. It assesses the migration from Terminal.Gui
1.19.0 to 2.4.17. No new interaction or accessibility redesign was introduced.
WCAG 2.2 Level AA is applied where its criteria fit a text terminal UI.*

Die bindende Laufzeitevidenz steht in
`specs/003-terminalgui-migration/evidence/manual-tui.md`. Zwei getrennte echte
PTY-Sitzungen belegen Navigation, Dialoge, Fokus, beide Quit-Pfade und die
Wiederherstellung des Terminals. Beide Sitzungen endeten mit Exitcode `0` und
erzeugten gültige Coverage für `MicroCalc.Tui.Program` und `Program.cs`.

*The binding runtime evidence is in the named manual TUI evidence file. Two
separate real PTY sessions prove navigation, dialogs, focus, both quit paths,
and terminal restoration. Both sessions exited with code zero and produced
valid coverage for the migrated program.*

## Vollständiger linearer Bedienpfad / Complete Linear Interaction Path

Die Anwendung startet mit genau einem Root-Fenster in Zelle `A1`. Die
Statuszeile nennt die aktive Zelle als Text. Die folgenden zwölf Eingaben
bewegen die Auswahl jeweils genau einmal:

1. `CursorUp` und `Ctrl+E` bewegen von `A2` nach `A1`.
2. `CursorDown`, `Ctrl+X` und `Ctrl+J` bewegen von `A1` nach `A2`.
3. `CursorRight`, `Ctrl+D`, `Ctrl+M` und `Enter` bewegen von `A1` nach `B1`.
4. `CursorLeft`, `Ctrl+S` und `Ctrl+A` bewegen von `B1` nach `A1`.
5. `Ctrl+Q` ist die dreizehnte Eingabe. Sie bewegt keine Zelle und schreibt
   keinen Inhalt, sondern beendet die aktive Anwendungssitzung.

*The application starts with one root window at cell `A1`, and the status line
names the active cell in text. Up and Ctrl+E move up; Down, Ctrl+X, and Ctrl+J
move down; Right, Ctrl+D, Ctrl+M, and Enter move right; Left, Ctrl+S, and Ctrl+A
move left. Ctrl+Q is input 13: it neither moves nor edits a cell and instead
exits the active application session.*

Ein druckbares Zeichen öffnet den Eingabedialog. `/` öffnet den
Funktionsdialog. `Alt+F`, danach `L`, öffnet den Dateidialog. Jeder geprüfte
Dialog zeigt seinen Titel und seine Bedienelemente als Text. `Tab` bewegt den
Fokus vorwärts, `Shift+Tab` rückwärts. `Esc` schließt nur den Dialog und kehrt
zum Root-Fenster und zur ausgewählten Zelle zurück. Es gibt keine
Tastaturfalle.

*A printable character opens the input dialog, `/` opens the command dialog,
and Alt+F followed by L opens the load dialog. Each dialog names its title and
controls in text. Tab moves focus forward, Shift+Tab moves it backward, and Esc
closes only the dialog and returns to the root and selected cell. There is no
keyboard trap.*

Der erste Quit-Pfad verwendet `Alt+F`, danach `Q`. Der zweite Quit-Pfad
verwendet ausschließlich `Ctrl+Q` in einer neuen Sitzung. Beide Pfade enden
ohne Traceback. Alternate Screen, Mausmodi, Bracketed Paste und Cursor werden
zurückgesetzt. Diese Aussagen sind ohne Farbe, Screenshot oder räumliche
Tabellenauswertung vollständig verständlich.

*The first quit path uses Alt+F followed by Q. The second uses Ctrl+Q alone in
a fresh session. Both exit without a traceback and restore alternate screen,
mouse modes, bracketed paste, and cursor state. This account is complete
without colour, screenshots, or spatial table interpretation.*

## WCAG-2.2-AA-Prüfung / WCAG 2.2 AA Review

### 1.4.1 Farbe / Use of Color — Pass

Die aktive Zelle ist nicht nur farblich erkennbar: Sie besitzt eine sichtbare
Klammermarkierung, und die Statuszeile nennt ihre Adresse, zum Beispiel `A1`.
Dialoge, Felder und Schaltflächen tragen Textbezeichnungen. Der Fokus ist durch
Cursor, Rahmen- oder Pfeilmarkierung zusätzlich zur Farbdarstellung erkennbar.

*The active cell does not rely on colour: it has a visible bracket marker and
the status line names its address. Dialogs, fields, and buttons have text
labels. Cursor, border, or arrow markers identify focus in addition to colour.*

Wiedervorlage / Re-review trigger: Änderung an Farbprofil, Auswahlmarkierung,
Statuszeile oder Fokusdarstellung. / *Re-review if colour profiles, selection
markers, the status line, or focus presentation change.*

### 2.1.1 Tastatur / Keyboard — Pass

Alle zwölf Navigationsvarianten, Eingabe-, Funktions- und Dateidialog,
Vorwärts-/Rückwärtsfokus sowie beide Quit-Pfade wurden ausschließlich per
Tastatur in echten PTY-Sitzungen ausgeführt. Keine Maus war erforderlich.

*All twelve navigation inputs, the three dialog types, forward and reverse
focus, and both quit paths were exercised by keyboard alone in real PTY
sessions. No mouse was required.*

Wiedervorlage / Re-review trigger: neue oder geänderte Taste, Dialogaktion,
Menüaktion oder Pointer-Abhängigkeit. / *Re-review any changed key, dialog or
menu action, or new pointer dependency.*

### 2.1.2 Keine Tastaturfalle / No Keyboard Trap — Pass

`Tab` und `Shift+Tab` bewegten den Fokus in beide Richtungen. `Esc` verließ
Eingabe-, Funktions- und Dateidialog jeweils wieder zum Root. Menü-Quit und
`Ctrl+Q` beendeten kontrolliert. Kein Fokus blieb ohne Tastaturausweg hängen.

*Tab and Shift+Tab moved focus in both directions. Esc returned from every
tested dialog to the root. Menu quit and Ctrl+Q exited cleanly. No focus became
trapped without a keyboard path.*

Wiedervorlage / Re-review trigger: neuer modaler Dialog, geänderte
Escape-Behandlung oder verschachtelter Laufzyklus. / *Re-review any new modal
dialog, changed Escape handling, or nested run cycle.*

### 2.4.3 Fokusreihenfolge / Focus Order — Pass

Der Fokus beginnt im Eingabefeld beziehungsweise an der erwarteten Aktion.
`Tab` folgt der sichtbaren logischen Reihenfolge vom Feld zu den Schaltflächen;
`Shift+Tab` kehrt diese Reihenfolge um. Nach `Esc` ist wieder die zuvor
ausgewählte Zelle aktiv. Der Funktionsdialog hält den Fokus in seiner linearen
Auswahlfolge bis zum sicheren Rückweg.

*Focus starts in the input field or expected action. Tab follows the visible
logical order from field to buttons, Shift+Tab reverses it, and Esc restores
the previously selected cell. The command dialog keeps a linear choice order
until the safe return path is used.*

Wiedervorlage / Re-review trigger: Änderung an Dialogaufbau, Tab-Reihenfolge,
Default-Button oder Fokuswiederherstellung. / *Re-review changed dialog layout,
tab order, default button, or focus restoration.*

### 2.4.7 Sichtbarer Fokus / Focus Visible — Pass

Die aktive Zelle, Texteingabe und fokussierte Schaltfläche waren während der
manuellen Sitzung sichtbar unterscheidbar. Textcursor sowie Klammer-, Rahmen-
oder Pfeilmarkierungen ergänzen die Hervorhebung. Nach jedem Dialog war die
aktive Zelle in Statuszeile und Raster wieder erkennbar.

*The active cell, text input, and focused button were visibly distinct during
the manual sessions. Text cursor and bracket, border, or arrow markers
supplement highlighting. After each dialog, the active cell was again clear in
the status line and grid.*

Wiedervorlage / Re-review trigger: Theme-, Treiber-, Cursor-, Button- oder
Auswahländerung. Ein fehlender sichtbarer Fokus ist ein Blocker und darf nicht
als `N/A` eingestuft werden. / *Re-review theme, driver, cursor, button, or
selection changes. Missing visible focus is a blocker, never N/A.*

## Begründete Nichtanwendbarkeit / Reasoned Non-Applicability

- Pointer-Zielgröße und Dragging / Pointer target size and dragging: `N/A`.
  Die geprüfte Oberfläche ist vollständig tastaturgesteuert und bietet keine
  Drag-Geste oder notwendige Pointer-Aktion. Neu prüfen, sobald Maus- oder
  Touchbedienung Teil des Produkts wird.
- Bilder und andere Nicht-Text-Inhalte / Images and other non-text content:
  `N/A`. Die migrierte Oberfläche und dieser Nachweis enthalten keine Bilder,
  Icons mit alleiniger Bedeutung oder Screenshots. Neu prüfen, sobald solche
  Inhalte eingeführt werden.
- Audio, Video und zeitbasierte Medien / Audio, video, and timed media: `N/A`.
  TinyCalc gibt in diesem Feature keine Medien aus. Neu prüfen, sobald Audio,
  Video oder zeitabhängige Hilfe hinzukommt.
- Animation und Bewegung / Animation and motion: `N/A`. Die Bedienung hängt
  nicht von Animation ab; Terminal-Neuzeichnung transportiert keine
  zusätzliche Information. Neu prüfen bei animiertem Status oder Bewegung.

*Pointer sizing and dragging are N/A because no pointer action exists. Images
and non-text content are N/A because no image or meaning-only icon is present.
Timed media are N/A because the feature produces no audio or video. Animation
is N/A because redraws carry no extra meaning. Each decision must be reviewed
if the corresponding interaction or content is introduced.*

## Ergebnis und Grenzen / Result and Limits

Die fünf anwendbaren Kriterien bestehen auf dem lokalen macOS-Nachweis. Die
Prüfung belegt reale Tastaturbedienung und sichtbaren Fokus, beansprucht aber
keinen Hardware-Screenreader- oder Braille-Test. Weil alle wesentlichen
Informationen als Text vorliegen, bleibt der Nachweis linear lesbar. Echte
Linux- und Windows-Läufe sind eigene spätere Delivery-Gates und werden hier
nicht vorweggenommen.

*All five applicable criteria pass in the local macOS evidence. The review
proves real keyboard operation and visible focus, but does not claim a hardware
screen-reader or Braille test. Essential information remains linear text.
Real Linux and Windows runs are separate later delivery gates and are not
claimed here.*

## US2-Abschlussvertrag T033 / US2 Completion Contract T033

Der abschließende read-only Vertrag bestand auf demselben Produktstand:

```text
git diff --exit-code -- tests src/MicroCalc.Core CALC.HLP
Exitcode: 0
Terminal.Gui 2.4.17: 1 exakter direkter Eintrag
CtrlMask: 0
AltMask: 0
statischer v1-Lifecycle: 0
Application.Create().Init(): 1
WithCtrl-Bindings: 8
Cursor-Bindings: 4
Enter-Bindings: 1
Bindende Inputs gesamt: 13
A11Y-Pflichttokens und N/A-Begründungen: vollständig
US2_CONTRACT_PASS
```

Damit sind Testquellen, Core und `CALC.HLP` unverändert. Der Source-Contract
und die fünf WCAG-Kriterien stimmen mit den zwei manuellen Sitzungen überein.
Ein erster read-only Kalibrierungsversuch suchte nach einem nicht vorhandenen
Hilfsfunktionsnamen und zählte deshalb null Registrierungen; er änderte keine
Datei. Der abschließende Vertrag zählt die tatsächlichen Quelltokens mit der
belegten Aufteilung `8 + 4 + 1`.

*Test sources, Core, and `CALC.HLP` remain unchanged. Source and accessibility
contracts agree with both manual sessions. An initial read-only calibration
used a helper-function name that does not exist and therefore counted zero
registrations; it changed no file. The final contract counts the actual source
tokens with the proven `8 + 4 + 1` split.*
