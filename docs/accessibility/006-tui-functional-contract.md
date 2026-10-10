# Feature 006: A11Y-Nachweisgrenzen / Accessibility proof boundaries

## Tatsächlicher Abnahmestand 11.10.2026 / Actual acceptance state

[Thorstens menschlicher Nachweis](../../specs/006-tui-functional-contract/evidence/human-acceptance-20261011.md)
schließt A11Y-CALC-08 und die menschlichen Anteile von 01/05/06/09: VoiceOver
27, Terminal 2.15, macOS 27.0.1, Safari 27.0.1, 11.10.2026 00:14:48
Europe/Berlin, Prüfcommit 737348d, Binary 1.6.17.116, Vertragsrevision 2.
V1–V6 Pass bei verifiziertem 120x40; 80x24 insgesamt Pass. F01–F14 und
HTML H1–H4 Pass, keine gemeldeten Befunde. Keine erfundenen gesprochenen Zitate.

01/03: vollständige DE/EN-Hilfe plus Bedienlauf. 02/06: echte unabhängige
Dialog-/Zustands-/Fokusassertions in 364 Pfaden je OS. 04: unveränderte vier
Locks und genehmigter Graph. 05/07: reale PTY 80x24/120x40 mit Text-/Kontrast-/
Fokusnachweisen; Auswahl zusätzlich Adresse/Klammern, nicht nur Farbe.
09: DocFX/axe/ARIA/lynx plus separate menschliche HTML-Stichprobe; visuelles
H4 ist keine numerische Messung. 10: unveränderte Pflicht-IDs und finale
Gatebindung gemäß [Lieferabschluss](../../specs/006-tui-functional-contract/evidence/delivery-closeout.md).
Die folgende Vorbereitung ist historisch. Kein Voll-WCAG-Zertifikat und kein
Abschluss des späteren eigenständigen A11Y-Features.

*Actual human evidence closes the human requirements on the frozen candidate.
The ten stable anchors retain their separate automated, PTY, documentation and
human proof. Final delivery binding remains required; no relabelling, numeric
H4 measurement, full-site certification or later-feature completion is claimed.*

## Deutscher Prüfblock

Verbindlich bleibt das verlinkte [A11Y-Intake](../../requirements/intakes/active/Lastenheft_A11Y_TUI.md).
Dies startet oder schließt dessen späteres Feature nicht ab. WCAG 2.2 AA gilt,
soweit Terminal/HTML-Kriterien anwendbar sind. Owner: Thorsten; Entwicklung
liefert technische Belege, unabhängiger Reviewer und menschliche VoiceOver-
Bedienperson bleiben getrennte Rollen. Wiedervorlage: vor Feature-006-Abnahme.

| Stabile Nachweis-ID | Anforderung | Tatsächlicher Stand / nächste Aktion |
|---|---|---|
| A11Y-CALC-01 | vollständige kontextuelle Tasten | DE/EN-Portreferenz und klare historische Einordnung in Hilfe; finale menschliche Durchsicht offen |
| A11Y-CALC-02 | sichtbares Erfolg/Abbruch/Fehler-Feedback | 364 Pfade auch in nativer Linux-/Windows-CI grün; finale gemeinsame Headbindung offen |
| A11Y-CALC-03 | strukturierte lesbare Hilfe | Seiten, Textscrolling, P/N, Prev/Next, Tab/Shift-Tab, Esc/Close; Hilfe-Fokusregression nach echtem Rot behoben |
| A11Y-CALC-04 | neutraler Pin-/Lock-Preflight | AlreadySatisfied nur für freigegebenen unveränderten Graph; 58 Policyfälle grün, kein Upgrade |
| A11Y-CALC-05 | Kontrast und nicht nur Farbe | echte PTY-Größen 80x24/120x40, Textkontrast ≥4,5; Auswahl zusätzlich Zelladresse/Klammern; reale VoiceOver-/Fokusabnahme offen |
| A11Y-CALC-06 | logischer Fokus/OK/Cancel | reale Dialogtests grün; Hilfe-Text und Buttons besitzen expliziten Fokusumlauf; menschliche Gesamtprüfung offen |
| A11Y-CALC-07 | reale PTY-Bedienpfade | ergänzender echter 80x24-Prozess: Navigation, Bearbeitung, Palette, Recalculate, Load/Fehler, Hilfe und Rücksetzung grün |
| A11Y-CALC-08 | menschliches VoiceOver | **Open**; Thorsten/benannte Bedienperson, keine synthetische Ersatzfreigabe |
| A11Y-CALC-09 | DocFX + Playwright/axe + lynx | [Automatisierte Stichprobe grün](006-docfx-axe.md); fünf Seiten, Sprache/Main/Text, null automatische Verstöße oder fehlende Artikelziele; manuelle Fälle/finale Bindung offen |
| A11Y-CALC-10 | additive ID-/Regressionsbindung | Zuordnung hier bleibt erhalten; finale Gate-/Commitbindung und alle alten aktiven IDs vor Abnahme prüfen |

Die IDs sind Nachweisanker, keine neue Feature- oder Serienpromotion. TERM-001,
HELP-001, DIALOG-001, FILE-001 und NAV-/EDIT-Pfade bleiben im unveränderten
funktionalen Nenner. Framework-Buffer unter nativen Linux-/Windows-Runners
ersetzen weder einen physischen Terminalfarbnachweis noch VoiceOver.

### Menschliche VoiceOver-Prüfliste

Am finalen Head starten: `dotnet run --no-build --configuration Release --project src/MicroCalc.Tui/MicroCalc.Tui.csproj`.
OS-, Terminal-, VoiceOver-Version, Head, Größe, Datum und tatsächlichen Reviewer
notieren. Keine privaten Tabellen oder Geheimnisse als Testdaten verwenden.

1. Bei 80x24 und 120x40 Raster, Adresse, Typ und AutoCalc ohne Farbdeutung lesen.
2. Zu B1 navigieren; `7` eingeben, Enter bestätigen. Editor mit Esc öffnen und
   Esc abbrechen: Wert unverändert, Fokus wieder im Raster.
3. Menü/Palette lesen, Recalculate auslösen und sichtbare Meldung prüfen.
4. Load/Save-Dialog mit Tab/Shift-Tab, OK/Enter und Cancel/Esc bedienen; fehlende
   Testdatei verständlich gemeldet, Blatt unverändert. Save nur in eigenes Testziel.
5. Help öffnen: Titel, Seitenstatus und Text lesen, P/N und Prev/Next bedienen,
   Text mit Pfeilen scrollen, alle Buttons erreichen; Esc/Close kehrt zurück.
6. Clear abbrechen und Quit auslösen; Terminalzustand und Datenintegrität prüfen.

Für jede ID konkrete Beobachtung und Pass/Fail/Open festhalten. Eine Zustimmung
zu dieser Prüfliste ist noch kein bestandener menschlicher Lauf.

## English review block

The linked intake's ten requirements apply to this feature's accessibility
impact without starting or completing the later accessibility feature. The
table separates actual local automated proof from native, human and final-head
obligations. Stable anchors do not promote the series or shrink functional scope.

Human VoiceOver remains Open. Record actual OS/terminal/VoiceOver versions,
reviewer, date, final head and both sizes. Use synthetic data to read grid/status,
navigate/edit/accept/cancel, operate menus and file dialogs, inspect errors,
page/scroll help with every button, cancel Clear and quit with restored terminal
state. Record observations and Pass/Fail/Open per ID. Agreement to the checklist
is not proof of execution. Framework rendering never substitutes for VoiceOver.
