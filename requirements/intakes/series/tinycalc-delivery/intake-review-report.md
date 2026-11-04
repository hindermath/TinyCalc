# TinyCalc-Serienreview nach README-Erneuerung / Series review after renewal

## Deutsch

Ergebnis: **Ready** für Intake-Dokumentenqualität und aktuelle Quellenbindung.
Review-ID `dce96041-569e-447b-814c-2d5e14103ef9`, geprüfte Basis
`0351afd6cd46f121ae795550f09f90ac29e9d37d`, Datum 04.11.2026 Europe/Berlin;
genauer UTC-Zeitpunkt im JSON. 13 Ziele, vier Wurzeln, neun harte Abhängigkeiten,
null Campaign-Worker. Critical 0, High 0, Medium 0, Low 0; keine akzeptierten
Risiken und keine offenen Klärungsfragen. **IR002 ist behoben.**

### Erneuerung und Identität

Die ausdrücklich genehmigte Operation `c0149c9a-09c8-4108-b493-02e0daccd5b2`
erneuert ausschließlich die README-Bindungen für Rename und TUI-Funktionsvertrag.
Die Ergänzung aus #133 beschreibt Model Routing Governance 0.2.3; sie ändert
keine Intake-Anforderung. Beide neuen Receipts binden den README-SHA-256
`8c3b47ff92d562f1243f64e61864837e9e690ff250399add7d962bd3ebf419be`.
Ihre Vorgänger und zugehörigen Intake-Dateien sind bytegleich archiviert.
Die Intake-IDs bleiben erhalten: Rename `b4f18668-0276-45ee-8a6f-16a8bd8b833d`,
TUI-Vertrag `40e85866-18d3-4cc8-b667-a1de8da44b10`. Nur Receipt-IDs sind neu.

Der blockierte Review `d4536c4f-4113-4ec5-a996-41ace9efb428` mit Request,
Ergebnis, Bericht und Prüfprotokoll bleibt im Serienarchiv
`20261104-model-routing-readme-source-renewal/` erhalten und wird ausdrücklich
ersetzt. Seine historische Aussage wird nicht umgeschrieben. Die Operation
unter `specs/intake-authoring-operations/` enthält Freigabe und Hash-Lineage.

### Abdeckung und Grenzen

Alle 13 Zieldateien werden strikt als UTF-8 ohne NUL gelesen. Normalisierte
Hashes und Git-Blobs stehen im Ergebnis. Alle Zielhashes stimmen exakt mit
dem archivierten angenommenen Review `0cb1a45b-9f8e-40a6-b102-1477e13b1332`
überein; dessen fachliche Bewertung wird für unveränderte Inhalte ausdrücklich
weiterverwendet. Dies ist kein neuer unabhängiger Fachreview. Aktuelle
Quellenbindung, Kontext, Berechtigung, Identität und Übergaben werden neu geprüft.

Wiederverwendete fachliche Abdeckung: Zielgruppe, Vorwissen, Begriffserklärungen,
DE/EN-B2 und textorientierte Leserpfade; Ziel, Scope/Nicht-Ziele, atomare
Anforderungen und messbare Abnahmen; Sicherheit, Datenschutz, A11Y, Plattform,
Supply-Chain, Risiken, Referenzen und normativ übereinstimmende Prompts.
Historische oder erledigte Intakes bleiben historische Quellen. Frühere
Produkt-Pass-Aussagen werden nicht als heutige Tests übernommen. IR001 bleibt
erledigt; es entsteht keine neue Risikoannahme oder Produktfreigabe.

Die unveränderte Serie umfasst:

1. Constitution Change — Completed, erste Wurzel.
2. Terminal.Gui Migration — Completed.
3. TUI-Funktionsabnahme und Regressionsvertrag — Completed.
4. A11Y TUI — deklarierter Eligible-Kandidat.
5. Rename MicroCalc/TinyCalc — Blocked durch A11Y.
6. Didactic Inline Code Comment Hardening — Blocked durch Rename.
7. Secure Development Hardening — Blocked durch Kommentar-Hardening.
8. PL/0-Zellfunktionen V1 — Blocked durch Secure Development.
9. Legacy-Kompatibilität V1 — Blocked durch PL/0.
10. Formelkopie und Tabellenoperationen V1 — Blocked durch Legacy-Kompatibilität.
11. Sandbox-Härtung — unabhängige Pending-Wurzel.
12. RL-SE-Selbstprüfung — unabhängige Completed-Wurzel.
13. GSDB-Intensivprüfung — unabhängige Completed-Wurzel.

Neun HardCompletionGate-Kanten verbinden die ersten zehn Ziele in dieser
Reihenfolge. Schema 2.0 trennt de-DE von der Implementierungssprache;
Benennungsprofil, vier Rollen, sechs Sammlungen, Index, begrenzte Archiv-Aliasse
und Inventar stimmen überein. Keine neue Lücke, Überschneidung oder Zuständigkeit
aus der README-Ergänzung. Alle 13 Intake-Inhalte, Manifest, Serienreceipt,
Reihenfolge und Lebenszyklusstatus bleiben bytegleich. Eligible ist keine
Startfreigabe. A11Y und Rename behalten ihre Funktions-/Plattform-Gates.

### Prüfungen und nächster Schritt

Aktuelle Ausgänge stehen in `review-validation.json`: vollständiges Alignment
in Bash und PowerShell mit allen 13 Receipts, Manifest, Serienreceipt und
Review; beide Operationsvalidatoren; Byte-/Hash-Erhaltung, UTF-8/LF, Secrets
und Diffprüfung. Erst diese Prüfungen schließen die isolierte Erneuerung ab.
Keine historischen DocFX- oder Screenreader-Prüfungen werden als neu ausgeführt
ausgegeben; kein Produkt-Build oder Restore ist für diesen Dokumentenauftrag nötig.

Dokumentationsentscheidung **UpdateRequired**, Owner Thorsten Hindermann;
Wartungsnachweis `docs/maintenance/tinycalc-readme-source-renewal-2026-11-04.md`.
Kanonisch sind Request, gebundene Intakes und genehmigte Operation.
Textorientiertes Markdown/JSON mit DE/EN, Source-only, kein Home-Sync.
Neubewertung bei README-, Quellen-, Ziel-, Policy- oder Seriendrift.
Keine Produkt-, native VoiceOver- oder Plattformabnahme.

Nächster separater Befehl: `$speckit-intake-series-next tinycalc-delivery`.
Er ermittelt Kandidaten und Blocker, ohne Produktimplementierung zu starten.

## English

Outcome **Ready** for written intake quality and current provenance. Review
identity, exact base and UTC timestamp are bound in the JSON. Coverage:
13 targets, four roots, nine hard dependencies, zero campaign workers. No
Critical/High/Medium/Low findings, accepted risks or unanswered questions.
IR002 is resolved through explicitly authorized renewal, not hash bypass.

The #133 README addition documents Model Routing Governance 0.2.3 and changes
no intake requirement. Both new receipts bind the current README hash above.
Predecessor receipts and target files are archived byte for byte. Intake IDs,
all 13 intake contents, manifest, series receipt, graph, order and lifecycle
states remain unchanged. The previous blocked review is archived and explicitly
superseded without rewriting history. New receipt IDs identify new provenance.

All strict UTF-8 normalized target hashes match the archived accepted review.
Its assessment of audience, prior knowledge, terminology, equivalent DE/EN B2,
text-first usability, scope, atomic requirements, measurable acceptance,
security/privacy/A11Y/platform/supply-chain, risks, references and prompt
authority is explicitly reused. This is not a new independent semantic review.
Current provenance, context, authority, identities and handoffs are reviewed
again. Historical product evidence is not presented as a current run.

The thirteen-member inventory above preserves the order: Constitution, GUI
migration and functional contract are completed; A11Y is Eligible; Rename,
comments, secure development, PL/0, legacy compatibility and table operations
remain blocked in sequence. Sandbox is an independent Pending root; RL-SE and
GSDB are independent Completed roots. The first ten members have nine ordered
hard gates. Schema 2.0 language, naming, four roles, six collections, index,
archive aliases and inventory agree. The README addition creates no gap,
overlap or ownership change. Eligible grants no execution authority.

Current Bash/PowerShell alignment, operation, preservation, encoding, secret
and diff outcomes are recorded in review-validation.json. No product build,
restore, new DocFX proof or native acceptance is claimed. Documentation impact
UpdateRequired; owner Thorsten Hindermann; bilingual maintenance record above;
source-only, no Home sync. Re-evaluate on source, target, README, policy or graph
drift. No human risk acceptance or product implementation is implied.

Next separate command: `$speckit-intake-series-next tinycalc-delivery`.
It lists candidates and blockers; it does not start product implementation.
