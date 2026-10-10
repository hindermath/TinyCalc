# Produktabnahme vorbereiten / Prepare product acceptance

## Deutscher Ablauf

Stand: 2026-10-10. Feature 006, PR #104. **Vorbereitet, nicht durchgeführt und
nicht abgenommen.** Dieses Dokument operationalisiert T065/T076/T077; es
verändert weder Intake noch Abnahmekriterien. Thorsten trifft die
Produktentscheidung. Codex bereitet technische Belege vor und dokumentiert
tatsächliche Beobachtungen. Keine Daybreak-Anmeldung oder externe Organisation
ist für diesen Ablauf erforderlich.

### 1. Technische Übergabe vor dem Termin

Historische Ausgangsbasis: `a9759f544fe47a5a3759ccc829ac319d1513e219`.
Der neue Prüfstand wird nach der Dokumentations-/Statistiklieferung eingefroren.
Seine genaue SHA, Binary und abgeschlossenen technischen Originale stehen im
separaten lokalen `tests/MicroCalc.Tui.Tests/TestResults/voiceover-candidate.json`.
Dieses Laufmanifest entsteht erst nach tatsächlicher Prüfung. Es ist kein
behaupteter finaler Abnahme-/Liefercommit und keine menschliche Zustimmung.
Vor Beginn nennen wir den tatsächlich verwendeten Commit, die Vertragsrevision
und die passende Release-Binary samt SHA-256. Kein unbemerktes Rebuild oder
Wechsel der Version während der Sitzung. Ein alter lokaler Build darf nicht
allein durch `--no-build` als aktueller Build ausgegeben werden.

| Voraussetzung | Stand bei Vorbereitung | Vor endgültiger Entscheidung |
|---|---|---|
| Linux/Windows | [Push-CI-Originale 38080340767](platforms/native-ci-38080340767.md) ausgewertet: je 671 Tests, 364 Pfade, 462 Assertions, 1147 Referenzhashes gültig am genannten Head | Nachweise am vereinbarten finalen Stand binden |
| macOS | [Build 105](platforms/macos/local-build105.md) mit realen PTYs ist historisch | erforderlichen aktuellen Release-/PTY-/Suite-Nachweis herstellen |
| Security/Architektur | [unabhängiger Review](../../../docs/security/secure-development/006-tui-functional-contract/independent-review.md) samt Korrekturdelta vorhanden | abschließenden Umfang und finale Bindung bestätigen |
| Supply Chain | geprüfte Locks, datierter Audit und Build-105-SBOM vorhanden | T068: aktuelle SBOM, Lizenz-/CVE-Prüfung und tatsächliche Herkunft binden; kein Paketupgrade |
| HTML-Dokumentation | [fünf axe/ARIA/lynx-Stichproben](../../../docs/accessibility/006-docfx-axe.md) automatisch grün | finale Dokumentationsbindung und offene manuelle Prüffälle beurteilen |
| Claude-Review | fehlgeschlagen, ausdrücklich zurückgestellt | kein Pass behaupten; nicht durch Ownerentscheidung oder formalen Bypass ersetzen |
| Human/Owner | nicht durchgeführt / nicht entschieden | die beiden getrennten Protokolle unten tatsächlich ausfüllen |

Codex beurteilt SC-001 bis SC-006 im [Abnahmeprotokoll](acceptance.md) anhand
der technischen Originale. Die menschliche Stichprobe ersetzt weder die
364 automatisierten Pfade noch die drei Plattformen. Solange materielle
Voraussetzungen fehlen, darf der Bedienlauf als Vorabprüfung stattfinden,
aber keine endgültige Produktabnahme auslösen. Kein Accepted, Merge oder
Serienabschluss allein durch Zustimmung zu dieser Anleitung.

### 2. Sichere Umgebung und Start

Nur eine neue leere Tabelle und synthetische Daten verwenden. Ein vorhandenes
Blatt zuerst außerhalb dieses Laufs sichern; dieses Prüfblatt niemals über eine
Nutzerdatei speichern. Der Ablauf benötigt Terminalgrößen 80x24 und 120x40.
Die Terminalanzeige selbst bestätigt die tatsächlich verwendete Größe.

Einmal in PowerShell 7 ein eigenes Testverzeichnis erzeugen:

```powershell
$acceptanceDirectory = [IO.Directory]::CreateTempSubdirectory('tinycalc-owner-').FullName
$acceptanceFile = Join-Path $acceptanceDirectory 'owner-roundtrip.mcalc.json'
$missingFile = Join-Path $acceptanceDirectory 'does-not-exist.mcalc.json'
$acceptanceFile
$missingFile
```

Die beiden ausgegebenen absoluten Pfade für die Dateidialoge bereithalten.
Nur `owner-roundtrip.mcalc.json` wird beim Test angelegt. Das Verzeichnis
bleibt zur Nachprüfung erhalten; keine automatische rekursive Löschung.

Nach bestätigter Binary-/Commitbindung aus der eingefrorenen Kopie starten:

```powershell
$candidate = Get-Content './tests/MicroCalc.Tui.Tests/TestResults/voiceover-candidate.json' -Raw | ConvertFrom-Json
if ((Get-FileHash -LiteralPath $candidate.binary -Algorithm SHA256).Hash.ToLowerInvariant() -cne $candidate.binarySha256) {
    throw 'Pruefbinary stimmt nicht mit dem Manifest ueberein / Test binary does not match manifest.'
}
dotnet $candidate.binary
```

Dieser Start baut nichts und verwendet nicht einen später überschriebenen
Repository-Build. Ein fehlender oder nicht passend gebundener Build geht an
Codex zurück; nicht durch einen unprotokollierten Neubau ersetzen.

### 3. Funktionaler Bedienlauf

Formeln **ohne führendes Gleichheitszeichen** eingeben. Im Raster öffnen
druckbare Zeichen den Editor; dort bestätigt Enter. Esc im Raster öffnet den
vorhandenen Inhalt, Esc im Editor bricht ab. Im Raster bewegt Enter dagegen
nach rechts. Diese Kontexte sind absichtlich verschieden.

Für Befehle öffnet `/` im Raster die Palette. Mit Tab/Shift-Tab den benannten
Button wählen und Enter drücken. Im Editor bleibt `/` normaler Eingabetext.

| Schritt | Aktion | Erwartetes Ergebnis |
|---|---|---|
| F01 | Leeres Blatt bei 120x40 betrachten, mit Pfeilen zwischen A1/B1/A2 navigieren | Köpfe A–G, Zeilen 01–21, aktive Adresse und AutoCalc sichtbar; Orientierung nicht nur über Farbe |
| F02 | A1: `1`, B1: `2`, C1: `A1+B1`, jeweils Enter im Editor | Werte 1, 2, 3; Dialog schließt ohne vorheriges Tab auf OK; Fokus wieder im Raster |
| F03 | Auf C1 Esc, Inhalt ändern, dann Esc zum Abbruch | C1 bleibt Formel `A1+B1` mit Ergebnis 3; verständliche Abbruchmeldung und Rasterfokus |
| F04 | D1: `2^3^2`; E1: `8/2`; G1: `Test` | D1 = 512, E1 = 4, G1 ist Text; Slash innerhalb des Editors öffnet keine Palette |
| F05 | F1: `7`; danach auf F1 `SQRT(-1)` eingeben und Enter | verständlicher Fehler ohne Stacktrace; F1 behält 7; andere Zellen unverändert |
| F06 | A1 neu mit `4` belegen, dann Palette → Recalc | C1 = 6; erfolgreiche Neuberechnung wird gemeldet |
| F07 | Palette → Save; Dateifeld vollständig durch den vorbereiteten acceptanceFile-Pfad ersetzen; Enter aus dem Textfeld | Datei wird angelegt; Erfolgsmeldung; kein Tab auf OK nötig |
| F08 | A1 mit `9` belegen, C1 = 11 beobachten; Palette → Load mit acceptanceFile-Pfad; Enter | A1 = 4, B1 = 2, C1 = 6, D1 = 512, E1 = 4, F1 = 7, G1 = Test wiederhergestellt |
| F09 | Save öffnen, anderen Pfad eingeben, Esc; Load öffnen, anderen Pfad eingeben, Esc | keine neue Datei durch Save-Abbruch; Blatt durch beide Abbrüche unverändert; Fokus zurück |
| F10 | Load mit dem vorbereiteten missingFile-Pfad bestätigen | verständliche Fehlermeldung; gesamtes Blatt bleibt unverändert; keine Teilübernahme |
| F11 | Help über Menü öffnen; Text scrollen, N/P, Next/Prev, Tab/Shift-Tab und Esc/Close bedienen | lesbarer Text/Seitenstatus, Buttons erreichbar, Rückkehr zum Raster; kein Fokusfang |
| F12 | Palette → Clear; ausdrücklich No wählen; anschließend Fenster auf 80x24 verkleinern | Blatt unverändert; aktive Zelle, Texte und Dialoge auch bei Mindestgröße benutzbar |
| F13 | Bei 80x24 F02/F03 mit den vorhandenen Inhalten sowie Save-Abbruch und Help wiederholen | Enter/Abbruch, Fokus und Lesbarkeit bleiben korrekt; keine neue Nutzerdaten-Datei |
| F14 | Ctrl-Q zum Beenden | Terminal kehrt in benutzbaren Zustand zurück; eigener gespeicherter Teststand bleibt erhalten |

Bei unerwartetem Verhalten Schritt, Größe, Taste und tatsächlichen Text
notieren. Betroffenen Schritt als Fail oder Open markieren und zur Korrektur
zurückgeben. Keine pauschale Wiederholung bereits unveränderter grüner Tests.

### 4. Tatsächliches Funktionsprotokoll

Alle Felder bleiben bis zum echten Lauf offen:

- Person: **Open**.
- Datum/Zeit mit Zeitzone: **Open**.
- tatsächlicher Commit / Vertragsrevision / Binary-SHA-256: **Open**.
- macOS / Terminal und Version / Größen: **Open**.
- Ergebnisse F01–F14: je **Open**, später Pass/Fail mit konkreter Beobachtung.
- Befunde und betroffene Schritte: **Open**, nicht automatisch „keine“.

Antwortformat im Chat, jeweils nur nach tatsächlicher Prüfung:

```text
Funktionslauf: Person ..., Datum ..., Commit ..., Binary ...
F01: Pass/Fail/Open – beobachtet ...
... bis F14, einschließlich tatsächlich geprüfter Größen ...
Befunde: ...
```

### 5. Separates VoiceOver-Protokoll

VoiceOver tatsächlich bedienen, nicht nur einschalten. Die
[bestehende vollständige Prüfliste](../../../docs/accessibility/006-tui-functional-contract.md)
mit A11Y-CALC-01 bis -10 bleibt verbindlich. Für beide Größen prüfen:
Raster/Adresse/Typ/AutoCalc lesen; Eingabe/Bestätigung/Abbruch und Fokus verfolgen;
Menü/Palette und Dateidialoge bedienen; Fehler verstehen; Hilfe lesen, blättern,
scrollen und schließen; Clear abbrechen und Terminal nach Quit beurteilen.

Protokoll getrennt von Funktions- und technischer Evidenz führen:

- Bedienperson, Datum/Zeit/Zeitzone: **Open**.
- macOS-, Terminal- und VoiceOver-Version: **Open**.
- tatsächlicher Commit / Vertragsrevision / Binary-SHA-256: **Open**.
- pro Größe 80x24 und 120x40: tatsächlich gesprochene/erreichbare Information,
  Fokuswechsel, verwendete Tasten und Hindernisse: **Open**.
- A11Y-CALC-01 bis -10: je Ergebnis, Beobachtung und zugehöriger F-Schritt
  oder technischer Beleg: **Open**.
- manuelle HTML-Prüffälle aus dem axe-Nachweis: **Open**; fehlende Prüfung
  nicht aus einem erfolgreichen TUI-Lauf ableiten.

Wenn VoiceOver wesentliche Inhalte nicht zugänglich macht, ist das ein Befund,
nicht „nicht anwendbar“. Screenshots und automatisierte PTYs ersetzen diesen
Nachweis nicht. Keine neue Organisation oder Zertifizierung verlangen.

### 6. Getrennte Produktentscheidung

Erst nach vollständigen technischen Pflichtbelegen, unabhängiger Prüfung,
tatsächlichem Human-Nachweis und null offenen In-Scope-Fehlern entscheidet
Thorsten. Beispiel für eine **spätere**, noch nicht erteilte Entscheidung:

> Ich nehme Feature 006 auf Commit [tatsächliche SHA] und Vertragsrevision
> [Revision] aufgrund der vollständigen vorgelegten Nachweise sowie meiner
> dokumentierten Bedienprüfung ab. Die zugeordneten menschlichen
> A11Y-Nachweise liegen vor. Offene In-Scope-Fehler: keine.

Bei fehlenden Voraussetzungen lautet der Status weiterhin Open/Blocked,
nicht „Accepted mit technischen Ausnahmen“. Codex übernimmt nur tatsächlich
erteilte Aussagen mit Herkunft/Datum in `acceptance.md`. Eine weitere
Evidence-only-Lieferrevision benötigt die vorgeschriebene neue technische
Bindung; alte Läufe und menschliche Beobachtungen werden niemals auf einen
anderen Commit umetikettiert. Reine Textänderungen lösen nicht automatisch
eine neue menschliche Sitzung aus; ihre Anwendbarkeit bleibt ausdrücklich
zu begründen. MergeAndSync erst nach gültigen Gates; kein Folgefeature.

## English procedure

Prepared on 2026-10-10 for Feature 006, PR #104; **not executed or accepted**.
This guide supports T065/T076/T077 without changing scope or acceptance rules.
Thorsten owns product acceptance; Codex supplies technical evidence and records
actual observations. No Daybreak account or external organisation is needed.

### Technical handover and safe start

The historical starting head is
`a9759f544fe47a5a3759ccc829ac319d1513e219`. The new test head is frozen after
documentation/statistics delivery. The separate local
`tests/MicroCalc.Tui.Tests/TestResults/voiceover-candidate.json` records its exact
SHA, copied binary and completed technical originals only after actual checks.
This is not a final delivery-head or human-acceptance claim. Historical push CI
38080340767 succeeded for that head; downloaded originals prove 671 passing
tests, 364 paths, 462 assertions and 1147 valid references per OS, as separately
recorded. Historical macOS Build 105, SBOM and reviews must not be
relabelled. Current supply-chain provenance, final common-head proof and manual
checks remain required. Deferred failed Claude review is not a pass.

Before starting, name the actual commit, contract revision and matching release
binary SHA-256. Do not silently rebuild or change the version during the session.
Use the PowerShell snippet above to create one owned temporary directory and
new round-trip/missing-file paths. Never overwrite user files. Retain the test
directory for inspection; no automatic recursive cleanup. Start the bound
Release copy with the hash-checked direct `dotnet` command above. Missing or stale binaries
must go back to Codex, not trigger an unrecorded build.

### Functional steps and expected observations

Enter formulas without a leading equals sign. Printable grid input opens the
editor; Enter accepts there, while Esc cancels. Grid Esc edits existing content;
grid Enter moves right. Grid slash opens the palette; editor slash is literal.
Use Tab/Shift-Tab and Enter to choose named palette buttons.

1. F01: At 120x40 inspect headers/rows, cell address and AutoCalc, then navigate
   with arrows. Orientation must not rely on colour alone.
2. F02: Enter A1 `1`, B1 `2`, C1 `A1+B1`; results 1, 2, 3. Enter from the editor
   accepts without tabbing to OK and returns focus to the grid.
3. F03: Edit C1 with grid Esc, change text, cancel with editor Esc. The original
   formula/result 3 remain, with clear cancellation and restored focus.
4. F04: Enter D1 `2^3^2`, E1 `8/2`, G1 `Test`; expect 512, 4 and text. Editor
   slash must not open the palette.
5. F05: Set F1 to `7`, then submit `SQRT(-1)`; clear error, no stack trace,
   original 7 retained and no changes elsewhere.
6. F06: Change A1 to `4`, choose Recalc; C1 becomes 6 and success is reported.
7. F07: Save to the prepared acceptanceFile path by Enter in the text field;
   actual file created and success reported, without tabbing to OK.
8. F08: Change A1 to `9`, observe C1 = 11, then Load the saved path. Restore
   A1 = 4, B1 = 2, C1 = 6, D1 = 512, E1 = 4, F1 = 7, G1 = Test.
9. F09: Cancel Save and Load after changing their path fields. No unwanted file
   or worksheet mutation; return focus to the grid.
10. F10: Load the prepared nonexistent path. Clear error and unchanged whole
    worksheet, without partial replacement.
11. F11: Open Help through the menu; scroll, use N/P, Next/Prev, Tab/Shift-Tab,
    Esc/Close. Readable page state, reachable buttons and no focus trap.
12. F12: Choose Clear, explicitly No; preserve the sheet. Resize to 80x24 and
    inspect selection, text and usable dialogs.
13. F13: At 80x24 repeat F02/F03 with existing contents, Save cancellation and
    Help. Preserve correct acceptance/cancellation, focus and readability.
14. F14: Ctrl-Q quits and restores a usable terminal; keep the owned saved file.

Record person, timestamp/time zone, actual commit/revision/binary, OS/terminal
versions and dimensions. Every F01–F14 outcome starts Open and becomes Pass or
Fail only with an actual observation. Record problems explicitly; do not infer
“none”. Correct failures before acceptance without repeating unchanged passing
checks indiscriminately. This sample supplements, never replaces, full automated
path coverage and native platform evidence.

### Separate human accessibility and owner decision

Use the linked full A11Y list, preserving every A11Y-CALC-01 through -10.
Actually operate VoiceOver at 80x24 and 120x40. Record the person, time zone,
macOS/terminal/VoiceOver versions, actual commit/revision/binary, spoken or
reachable information, focus, keys and barriers. Map each ID to an observation
and F-step or technical proof. Keep manual HTML checks separate. Everything
starts Open; screenshots, enabling VoiceOver or automated PTYs do not prove
human usability. Inaccessible essential content is a finding, not N/A.

Only after all technical, independent and required human proof is valid, with
zero open in-scope defects, may Thorsten expressly accept the named commit and
contract revision. Codex records the actual decision and its source/date in
acceptance.md. Missing gates remain Open/Blocked, not acceptance with technical
exceptions. A later evidence-only delivery commit requires renewed technical
binding; never relabel old runs or human observations. Text-only changes do not
automatically require another human session; document applicability. Final
MergeAndSync remains gated and starts no follow-up feature.
