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

Direkte Eingabe im regulären Einfügemodus muss Folgezeichen ergänzen; den ausdrücklich gewählten Überschreibmodus und vorhandene Aliasse separat nach ihrem bestehenden Vertrag prüfen. Start in leerer Zelle, erste Taste öffnet den Editor, restliche Zeichen ohne End/Home/Pfeil-Zwischentaste tippen. Kontrollorakel: `123` → Inhalt `123` und Wert 123; `abc` → Textinhalt `abc`; `1+2` → Formelinhalt `1+2` und Wert 3 nach Bestätigung. Bereits vor Bestätigung muss der Editor alle Zeichen enthalten. Diese synthetischen Fälle ersetzen nicht den vollständigen EDIT-/Formelvertrag. VoiceOver aus/an getrennt, Abbruch erhält Vorzustand. Dateien/Tabellen bei Abbruch byte-/zustandsgleich; nur beabsichtigte synthetische Schreibaktionen zulassen. Farbwerte nur mit tatsächlich wirksamer Palette, Terminalprofil und Messung bewerten. Kontrollierbarkeit unbekannt: Open/Incomplete, keine erfundene Kontrasterfüllung.

*Direct typing in ordinary insert mode appends subsequent characters; separately preserve deliberate overwrite and alias semantics. From an empty cell, type the first character to open the editor, then the remainder without navigation. Synthetic oracles are 123 with contents/value 123, abc as text, and 1+2 with formula contents and value 3 after confirmation; require all characters before confirmation too. These samples do not replace the full contract. Separate reader states and preserve cancellation. Contrast needs effective colours/profile and actual measurement; unknown control cannot establish a pass.*

Für A11Y-007-CONTRAST-001 pro Raster, Auswahl, Menü, Dialog, Status und Nachricht alle relevanten Normal-/Fokus-/Auswahlzustände mit Farbpaar, Messmethode und Verhältnis protokollieren. 4,5:1 für normalen Text; 3:1 nur bei belegter großer Textdarstellung beziehungsweise erforderlichen Nicht-Text-Indikatoren nach [WCAG 1.4.3/1.4.11](https://www.w3.org/TR/WCAG22/#non-text-contrast). Abweichungen vom vom Autor kontrollierbaren Zustand und begründete Ausnahmen getrennt ausweisen, keine globale AA-Aussage aus einer Palette ableiten. Zusätzliche Textbedeutung bleibt unabhängig vom Kontrast Pflicht.

*Record effective colour pairs, method and ratio for all relevant states on every listed surface. Preserve 4.5:1 normal text and the justified 3:1 cases for large text or required non-text indicators. Separate author-control limits and justified exceptions; one palette cannot prove overall AA. Textual meaning remains independently mandatory.*

Vor späterem Code neue Vertragswege mit unabhängiger Quellenzuordnung und beobachtbarem Rot binden. Negative Fälle: fehlende/duplizierte IDs, stale Commit/Binary, manipulierte Hashes, fremde Plattform, Skip/Timeout, abgeschwächtes Orakel, fehlende native Sitzung, nur Zeilenlesen, fehlendes Kontrastmaß, fehlender Lock/Pin, nicht eindeutig archivierte Quelle. Jede Verletzung muss eine vollständige Abnahme verhindern; Tests des Validators dürfen nicht ihre eigene Erfolgsevidence erfinden.

*Bind new paths before code using independent sources and observable red tests. Reject missing/duplicate identities, stale or tampered bindings, wrong platform, skipped/timed-out/weakened execution, absent native proof, line-reading substitutes, missing contrast measures, pins/locks and ambiguous archived sources. Validator tests cannot manufacture their own passing product proof.*

Alle acht AK-Zeilen separat auswerten. Linux/Windows-Vollautomation, macOS-PTY, VoiceOver und HTML-Prüfung getrennt auf demselben Kandidaten. Narrator/NVDA optional zusätzlich mit eigener Bindung; kein automatischer neuer Pflichtscope und keine Ableitung aus VoiceOver. Braillegeräte-Kompatibilität nur mit tatsächlichem Gerätnachweis. Vollständiger Funktionsnenner bleibt unabhängig von Changed-Code-Coverage.

*Assess all eight acceptance rows independently. Bind complete automated, PTY, native reader and HTML evidence to one candidate. Narrator/NVDA evidence is additional and independent; actual Braille hardware requires its own proof. Functional path coverage and changed-code coverage are distinct.*
