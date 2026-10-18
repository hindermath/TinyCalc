# A11Y-Prüfvertrag / Accessibility Verification Contract

## Erhaltung und additive IDs / Preservation and Additive IDs

Verbindlich sind [Spec](../spec.md), [Plan](../plan.md), das Intake und der aktive [Produktvertrag](../../../docs/contracts/tui/product-contract.json). Alle zehn `A11Y-CALC-01` bis `10`, 17 Funktionsfamilien und jeder aktive Alias-/Erfolgs-/Abbruch-/Fehler-/Grenzweg bleiben erhalten. 364 bestehende Pflichttupel je OS, 1.092 insgesamt, sind keine durch dieses Dokument verkleinerbare Auswahl.

*The linked specification, plan, intake and active product contract govern scope. Preserve all existing accessibility anchors, functional families and individual paths. Existing tuple counts are a baseline, not permission to select fewer cases.*

Die folgenden additiven Kennungen sind Designanker für spätere ausführbare Zuordnung, keine implementierte Vertragsrevision und keine neue Abdeckungsgutschrift. Jeder Anker wird auf alle einschlägigen Einzelwege expandiert; keine Sammelzeile ersetzt Einzelresultate.

*The following additive IDs are design anchors for future executable mapping, not an implemented contract revision or coverage credit. Expand each across all applicable individual paths.*

| Neue stabile ID / New stable ID | Prüfpflicht / Obligation | Intake |
|---|---|---|
| A11Y-007-INPUT-001 | Direkte Zahl/Text/Formel ohne End-Zwischentaste; VO aus/an getrennt / direct typing, reader states separate | R-06/07/10 |
| A11Y-007-FOCUS-001 | Jeder Dialogaktionsfokus benennt tatsächliche Aktion unmittelbar eindeutig / immediate actual action naming | R-06/08 |
| A11Y-007-FEEDBACK-001 | Erfolg, Abbruch, Fehler und Zellkontext als Text / outcome and context text | R-02/06 |
| A11Y-007-HELP-001 | Vollständige kontextuelle DE/EN-Referenz und geprüfte Reader-Hinweise / complete help and bounded reader guidance | R-01/03/09 |
| A11Y-007-CONTRAST-001 | Text/Fokus/Auswahl aller Oberflächen mit Messung und Nicht-Farb-Bedeutung / measured contrast and text alternatives | R-05 |
| A11Y-007-PTY-001 | Reale Prozesswege, Größenwechsel und Rücksetzung / process interaction and restoration | R-07/08 |
| A11Y-007-BINDING-001 | Quellen/Pin/Locks/Commit vollständig, negativ gegen Drift/Fehlnachweise / full binding and rejection tests | R-04/10 |
| A11Y-007-DOCS-001 | DocFX Snapshot/axe/lynx und manuelle Restkriterien getrennt / docs proof and manual gaps | R-03/09/10 |

## Native Fokusabnahme / Native Focus Acceptance

Mac A mit Terminal.app/VoiceOver; Versionen und Einstellungen je Sitzung. In jedem betroffenen Dialog Tab und Shift-Tab zwischen Feld und allen Aktionen bewegen. Tatsächliches Fokusziel unabhängig protokollieren und mit unmittelbar erfolgter Sprachansage vergleichen. OK und Cancel müssen unterscheidbar benannt werden, bevor die Bedienperson eine weitere Leseaktion ausführt. Name falsch/fehlend/gleichlautend: Fail. Nur Zeilentext sichtbar oder zusätzlich gelesen: kein Pass. Erfolg, Abbruch, Fehlerrückkehr und Default-Aktion müssen daneben fachlich korrekt bleiben.

*Use the actual Mac A Terminal.app/VoiceOver configuration. Move both directions through fields/actions in every affected dialog; record actual focus independently and compare immediate speech. OK and Cancel must be distinctly named without a further reading action. Wrong/missing/indistinguishable names fail; visible or additionally read line text cannot pass this criterion. Preserve every dialog outcome and default action.*

80x24/120x40 sind Pflicht; 120x28 ergänzt B01/B02-Reproduktion. Vorher/nachher mit synthetischen Daten, Referenzcommit/Binary, Startbefehl, Arbeitsverzeichnis, Sprache/Verbosity/Cursorkopplung und Readerzustand protokollieren. Historischer Host bleibt unbestätigt; neue Sitzung bestätigt ihn nicht rückwirkend. Keine feste Millisekundenschwelle erfinden: unmittelbar bedeutet beim Fokuswechsel ohne zusätzliche Leseschritte, nicht eine zugesagte Sprachlatenz.

*Required sizes remain 80x24/120x40 with supplementary 120x28. Record complete before/after configuration and synthetic data. New sessions do not retrospectively identify the historical host. Immediate means on focus change without extra reading, not an invented speech-latency SLA.*

## Orakel, Manipulationsschutz und Gate / Oracles, Tamper Protection and Gate

Direkte Eingabe muss jedes Zeichen unverändert ergänzen, vorhandene Modus-/Aliasverträge zusätzlich prüfen. Dateien/Tabellen bei Abbruch byte-/zustandsgleich; nur beabsichtigte synthetische Schreibaktionen zulassen. Farbwerte nur mit tatsächlich wirksamer Palette, Terminalprofil und Messung bewerten. Kontrollierbarkeit unbekannt: Open/Incomplete, keine erfundene Kontrasterfüllung.

*Direct typing preserves every character; test existing modes/aliases separately. Cancellation preserves file/sheet state and only intended synthetic writes are permitted. Contrast needs actual effective colours/profile and measurement; unknown control cannot establish a pass.*

Vor späterem Code neue Vertragswege mit unabhängiger Quellenzuordnung und beobachtbarem Rot binden. Negative Fälle: fehlende/duplizierte IDs, stale Commit/Binary, manipulierte Hashes, fremde Plattform, Skip/Timeout, abgeschwächtes Orakel, fehlende native Sitzung, nur Zeilenlesen, fehlendes Kontrastmaß, fehlender Lock/Pin, nicht eindeutig archivierte Quelle. Jede Verletzung muss eine vollständige Abnahme verhindern; Tests des Validators dürfen nicht ihre eigene Erfolgsevidence erfinden.

*Bind new paths before code using independent sources and observable red tests. Reject missing/duplicate identities, stale or tampered bindings, wrong platform, skipped/timed-out/weakened execution, absent native proof, line-reading substitutes, missing contrast measures, pins/locks and ambiguous archived sources. Validator tests cannot manufacture their own passing product proof.*

Alle acht AK-Zeilen separat auswerten. Linux/Windows-Vollautomation, macOS-PTY, VoiceOver und HTML-Prüfung getrennt auf demselben Kandidaten. Narrator/NVDA optional zusätzlich mit eigener Bindung; kein automatischer neuer Pflichtscope und keine Ableitung aus VoiceOver. Braillegeräte-Kompatibilität nur mit tatsächlichem Gerätnachweis. Vollständiger Funktionsnenner bleibt unabhängig von Changed-Code-Coverage.

*Assess all eight acceptance rows independently. Bind complete automated, PTY, native reader and HTML evidence to one candidate. Narrator/NVDA evidence is additional and independent; actual Braille hardware requires its own proof. Functional path coverage and changed-code coverage are distinct.*
