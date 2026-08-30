# TUI-Lesbarkeit und Dialogbestaetigung

## Deutscher PR-Block

### Problem

Das schreibgeschuetzte Tabellen-Grid verwendete eine von Terminal.Gui
abgeleitete Vordergrundfarbe, die auf dem hellen Hintergrund praktisch
unsichtbar war. In den gemeinsamen Texteingabedialogen wurde ausserdem der
zuletzt hinzugefuegte Button `Cancel` zum Default. Eine nachtraegliche optische
Markierung von `OK` setzte das funktionale Enter-Ziel nicht zurueck.

### Loesung

- Das Grid verwendet explizite kontrastreiche Rollen: Schwarz auf Hellgrau
  fuer normale und schreibgeschuetzte Inhalte sowie Weiss auf Blau fuer
  hervorgehobene Inhalte.
- Nach dem Hinzufuegen von `OK` und `Cancel` werden `IsDefault` und
  `DefaultAcceptView` konsistent auf `OK` gesetzt.
- Enter aus dem fokussierten Textfeld bestaetigt damit Werte-, Load-, Save-,
  Print- und Formatdialoge; Escape bricht weiterhin ab.
- Regressionstests sichern beide Farbzustandsgruppen sowie Enter-Binding,
  Accept-Weiterleitung und den einzigen Default-Button ab.

### Risiken

- Terminalfarbpaletten koennen benutzerdefiniert sein; die gewaehlten
  Grundfarben bleiben jedoch klar verschieden und textbasiert erkennbar.
- Alle Texteingabedialoge teilen denselben Helfer. Die Enter-Korrektur wirkt
  deshalb bewusst auf alle genannten Dialoge.
- Core-Berechnung, Dateiformat, Formelauswertung und Abhaengigkeiten bleiben
  unveraendert.

### Testplan

- `dotnet test MicroCalc.sln --configuration Release`
- Erwartung: 76 Core- und 6 TUI-Tests erfolgreich.
- Reale PTY-Pruefung: Wert eingeben, Enter druecken, Rueckkehr zum Grid und
  sauberer Exit mit Strg+Q.
- DocFX-Neubau sowie textorientierter Gegencheck mit `lynx` und Playwright.

## English PR block

### Problem

Terminal.Gui derived an almost invisible foreground for the read-only grid on
its light background. The shared text prompts also made the last added
`Cancel` button the default. Restoring only the visual `OK` role did not restore
the functional Enter target.

### Solution

- The grid now uses explicit contrasting normal, read-only, disabled, focused,
  and active roles.
- After both buttons are added, `IsDefault` and `DefaultAcceptView` consistently
  target `OK`.
- Enter confirms value, load, save, print, and format prompts while Escape
  continues to cancel.
- Regression tests cover both color groups and the complete
  Enter-to-accept-to-OK route.

### Risks and test plan

User-defined terminal palettes can vary, but the selected base colors remain
distinct. The shared prompt behavior changes intentionally for all listed
dialogs. Core calculations, file formats, formula evaluation, and dependencies
do not change. The full Release test suite, a real PTY Enter path, DocFX build,
and text-oriented accessibility checks must pass before merge.
