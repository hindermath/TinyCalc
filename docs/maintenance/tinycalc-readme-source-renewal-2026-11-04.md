# TinyCalc: README-Quellen-Erneuerung / README source renewal

## Deutsch

Die ausdrückliche Freigabe vom 04.11.2026 betrifft ausschließlich die beiden
README-Quellenbindungen für Rename MicroCalc/TinyCalc und TUI-Funktionsabnahme
und Regressionsvertrag sowie den anschließenden Serienreview.
Die README-Ergänzung aus #133 beschreibt Model Routing Governance 0.2.3 und
ändert keine Lastenheft-Anforderung. Aktueller normalisierter README-SHA-256:
`8c3b47ff92d562f1243f64e61864837e9e690ff250399add7d962bd3ebf419be`.

Vorgänger der beiden Receipts und Intake-Dateien sind bytegleich archiviert.
Neue Receipt-IDs kennzeichnen neue Herkunftsnachweise; beide Intake-IDs,
sämtliche 13 Intake-Inhalte, Manifest, Serienreceipt, Reihenfolge, Wurzeln,
Abhängigkeiten und Lebenszykluszustände bleiben unverändert. Der vorhandene
Archiv-Resolver behandelt weiterhin den aktiven Alias des abgeschlossenen
TUI-Intakes; keine zweite aktive Datei wird angelegt.

Operation `c0149c9a-09c8-4108-b493-02e0daccd5b2` unter
`specs/intake-authoring-operations/` enthält Vorschlag, Freigabe, Hash-Lineage,
Archivpfade und Rücksetzgrenze. Der blockierte Review bleibt unter
`requirements/intakes/series-archive/tinycalc-delivery/20261104-model-routing-readme-source-renewal/`
erhalten. IR002 wird durch explizite Quellenübernahme behoben; seine historische
NeedsRemediation-Aussage wird nicht umgeschrieben.

Dokumentationsentscheidung **UpdateRequired**, Owner Thorsten Hindermann.
Zielgruppe: Maintainer und Lernbegleitung. Kanonische Quelle: genehmigte
Operation mit gebundenen Hashes; Leserpfad: dieser Wartungsnachweis und der
aktuelle Serienreview unter `requirements/intakes/series/tinycalc-delivery/`.
DE/EN in einer Datei, textorientiertes Markdown/JSON. Source-only, kein
Home-Sync, keine Produkt-API-, UI- oder Plattformänderung. Bei README-,
Quellen-, Ziel-, Policy- oder Seriendrift erneut prüfen. Dokumenten-Ready
ersetzt keine Produkt-, native Screenreader- oder Sicherheitsabnahme.

## English

The explicit approval of 4 November 2026 covers only the two README bindings
for Rename and TUI functional acceptance/regression, followed by Series review.
The #133 README addition documents Model Routing Governance 0.2.3 and changes
no intake requirement. The current README hash is adopted explicitly.

Both predecessor receipts and intake files are archived byte for byte. New
receipt IDs identify renewed provenance. Both intake IDs, all 13 target files,
the manifest, series receipt, order, roots, dependencies and lifecycle states
remain unchanged. Existing archive resolution retains the completed TUI
intake's alias without creating another active target. The operation and
archive paths above preserve approval, hashes, rollback limits and the blocked
review. Resolving IR002 does not rewrite its historical outcome.

Documentation impact **UpdateRequired**, owner Thorsten Hindermann. Readers:
maintainers and training support. The authorized operation and bound hashes
are canonical; this maintenance record and current Series report form the
reader path. German/English text-first Markdown/JSON; source-only, no Home sync
or product/API/UI/platform change. Re-evaluate on README, source, target, policy
or graph drift. Document acceptance grants no product or native acceptance.
