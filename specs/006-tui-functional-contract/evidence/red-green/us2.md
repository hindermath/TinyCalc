# US2: tatsächliches Rot–Grün–Refactor / Actual red–green–refactor

## Deutscher Nachweis

Datum: 2026-10-10. Branch `006-tui-functional-contract`, lokale Umsetzung,
Basiscommit `ffc3d56a8975341a686ff6985570369abefcfd2a`. Keine Remote-Lieferung.
Die TRX-Dateien liegen in den ignorierten `TestResults` der beiden Testprojekte.
Historische rote Dateien werden nicht überschrieben oder als aktuell grün umetikettiert.

1. Build 56: 28 reale Menü-/Paletten-/Buchstaben-/Lifecycle-Fälle, 12 Pass,
   16 Fail. Menü-Pfeile wurden vom Rasterdispatcher abgefangen, Palettenbuchstaben
   hatten keine Hotkeys, und Help fand die ausgelieferte Ressource nicht.
2. Build 57: Core-Dateifälle 12, davon 3 Pass/9 Fail; TUI-Datei-/Dialog-/Druck-/Hilfefälle
   64, davon 52 Pass/12 Fail. Alle 44 Bestätigungs-/Abbruchfälle und drei Druckfälle
   waren bereits grün. Ungültiges Load ersetzte jedoch AutoCalc/Zellen teilweise;
   ungültige Datensätze wurden ignoriert oder führten zu internen Nullfehlern.
3. Minimale Korrekturen: vollständiges JSON-Staging vor Clear/Übernahme,
   verständliche InvalidDataException; Ressourcenauflösung für direktes und
   Resources-Verzeichnis; aktive Menüs besitzen ihre Tastatur; explizite
   Paletten-Hotkeys. Kein Paketupgrade, neues Dateiformat oder Produkt-Testmodus.
4. Build 58: Core 12/12, TUI 90/92. Zwei reale Menüfälle zeigten noch veraltete
   sichtbare Recalc-/AutoCalc-Texte. Nach erfolgreicher Menüaktion wird nun ebenfalls
   RefreshUi ausgeführt. Build 59: alle 18 Menü-/Palettenrouten grün.
5. Build 60: vollständige Solution, **Core 217 + TUI 363 = 580 Pass**, null Fail,
   null Skip und keine Compilerwarnung. Zusätzlich sind fehlendes Load,
   Save-/Print-I/O-Fehler und bestehende Druckdatei-Inhalte geprüft. Fehler und
   Abbruch vergleichen Auswahl, AutoCalc und alle 147 Zellen; Dateiresultate
   werden gegen eigene synthetische Dateien geprüft. Quit verlangt natürliches
   Produktende, nicht das automatische Ende des Testadapters.

Ausführung: `dotnet test MicroCalc.sln --configuration Release --no-restore
--logger 'trx;LogFileName=us2-green-final.trx' --blame-hang-timeout 180s`.
Die UI-Sitzungen laufen seriell im echten Terminal.Gui-IApplication über
Framework-Tastaturinjektion. Dies ist **kein PTY-, VoiceOver-, Linux- oder Windows-Nachweis**.
T032/T040 bleiben bis zur vollständigen Tupel-/Plattformbindung offen.

| Historisches Artefakt | SHA-256 |
|---|---|
| Core `us2-red.trx` | `7394e3414a00d06ce973d84efda3a973db98e8647889046a90a68bb6bb5d4d07` |
| TUI `us2-red.trx` | `ea9e7586d009de9936dc04cbe01a5aa7fd34dc4db8f8498dda03c0673e6205ca` |
| Core `us2-green.trx` | `cdec83e65573ea30ca4a5f545413a88bca7de7b77b71e1a7d1355c332a684357` |
| TUI `us2-green.trx` (zwei offene Menüdefekte) | `14e82fe52861d6a83fa3722ccafc45e8f8802ddef4cfd4601a5d4eee7b22174c` |
| TUI `us2-menu-green.trx` | `51626a7657e746a87c43eaa98eafe66d6285a68ff0cfe589cdf586bbc9d0359c` |
| Core `us2-green-final.trx` | `bbaa6386fde1e62984e9c4dd33f8137fa675bf110d646664d1d21d2bd4bb34f5` |
| TUI `us2-green-final.trx` | `8c6a846f10f8ea570ff3ec2cabef99d59bf0f0a5c055a20a0bd9a069b13d94dd` |

### Quellenangleichung T039

README und beide CALC.HLP sowie migrierte Hilfe erläutern geklärte Kontexte,
Aliaswege, Formelregeln und bestehende 70-Zeichen-Grenze DE-first/EN-second.
COUNT-Backtick und A23-Beispiele sind korrigiert. Das historische Ursprungsinventar
behält seine Herkunftshashes; SourceMap bindet dagegen die aktuellen Dateibytes
und die extrahierten TuiSession-Anker. Keine Pflicht-ID wurde entfernt.

Drei generische Dialog-Entwurfsorakel wurden präzisiert, nicht Produktangebote
umdefiniert: Clear-Enter mit explizitem Yes-Fokus, Palette-Enter mit Recalc-Fokus
und der vorhandene Recalc-Befehl statt eines nicht vorhandenen Palette-OK-Buttons.
Baseline-Digest `3c426701b89d9ddbdc4d9cc575587e2b1a67049246219e75dc4d4b8a0beb2421`;
SourceMap-Digest `f74ee7542b86277b4fc049900830c6c3f1506f086b1ec07d0f286baa65b61d56`.
`pwsh -NoProfile -File scripts/tests/tui-contract/test-foundation.ps1`: Exit 0,
17 Familien, 364 unabhängige Pfade und gültige Quellen-/Digestfixtures.

## English evidence

On 2026-10-10, builds 56–57 recorded genuine command, resource and atomic-load
regressions before product corrections. Already-correct dialog and print tests
were not artificially broken. Build 58 left two stale visible menu labels;
RefreshUi after successful menu actions fixed them, with all 18 routes passing
in build 59. Build 60 ran the full solution: **217 Core + 363 TUI = 580 passing
tests, zero failed/skipped, no compiler warnings**. The table binds the original
TRX bytes, including the intermediate run with two remaining failures.

Real framework views and keyboard dispatch are used, with independent file and
whole-sheet assertions. Failed/cancelled operations preserve selection, AutoCalc,
all 147 cells and owned file content. Print's second prompt cannot overwrite an
existing file early. Quit must end naturally. These results do not claim native
PTY, VoiceOver, Linux/Windows or final per-tuple acceptance; T032/T040 remain Open.

All offered documentation now explains the clarified contexts and formula rules,
without new scope or removed IDs. Current source hashes are separate from origin
hashes. Three draft dialog descriptions were aligned with existing Yes/Recalc
controls, not invented OK controls. Foundation validation passes all 17 families,
364 paths, schemas, current source anchors and digest fixtures with exit zero.
