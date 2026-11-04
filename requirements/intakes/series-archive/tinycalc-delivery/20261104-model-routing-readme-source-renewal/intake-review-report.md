# TinyCalc-Serienreview / TinyCalc series review

## Deutsch

Ergebnis: **NeedsRemediation**. Review-ID: `d4536c4f-4113-4ec5-a996-41ace9efb428`.
Basis: `0351afd6cd46f121ae795550f09f90ac29e9d37d`; UTC: 2026-11-03T22:38:12Z.
13 Ziele, vier Wurzeln, neun harte Abhängigkeiten, null Campaign-Worker.
Befunde: Critical 0, **High 1**, Medium 0, Low 0. Keine akzeptierten Risiken,
keine offenen Klärungsfragen. Ein High-Befund verhindert die Freigabe.

### IR002: Erneuter README-Quelldrift

Die Quellen-Erneuerung wurde regulär durchgeführt. Danach ergänzte die
Model-Routing-Lieferung #133 die README um den Hinweis auf Governance 0.2.3.
Die aktuelle README hat den normalisierten SHA-256 `8c3b47ff92d562f1243f64e61864837e9e690ff250399add7d962bd3ebf419be`.
Die Receipts für Rename MicroCalc/TinyCalc und TUI-Funktionsabnahme und
Regressionsvertrag binden weiterhin
`832e7bbdd813f954baf01b50e7f42e28b53c4980709c8472ccfb7b6a3b938b24`.
Beide installierten Validatoren melden erneut `source hash drift: README.md`
(Exit 2). Dies ist ein gemeinsamer Herkunftsbefund, keine festgestellte
Änderung an Produktfunktion oder Lastenheft-Inhalt.

Owner: Thorsten Hindermann für die Quellenübernahme; autorisierte
Intake-Authoring-Reparatur für die technische Erneuerung. Disposition: offen.
Neubewertung: nach genehmigter Erneuerung dieser beiden Bindungen und bei
weiterem Quellen-, Ziel-, Policy- oder Seriendrift.

### Prüfumfang und Grenzen

Alle 13 strikt als UTF-8 gelesenen Zielhashes stimmen mit dem archivierten
angenommenen Review `0cb1a45b-9f8e-40a6-b102-1477e13b1332` überein. Dessen fachliche Bewertung
von Zielgruppe, Vorwissen, Begriffen, DE/EN-Verständlichkeit, atomaren
Anforderungen, messbaren Abnahmen, Scope, Nicht-Zielen, Sicherheit,
Datenschutz, A11Y und Plattformgrenzen wird für die unveränderten Inhalte
ausdrücklich weiterverwendet. Dies ist kein neuer unabhängiger Fachreview.
Die aktuelle Quellenfrische wurde dagegen vollständig neu geprüft.
Historischer Befund IR001 bleibt erledigt; historische Tests und Abnahmen
werden nicht als heute ausgeführte Prüfungen übernommen.

Konfiguration 2.0, Inventar, Benennungsprofil, vier Rollen und sechs
Sammlungspfade sind gültig. Manifest und Serienreceipt bestehen ihre
Validatoren. Reihenfolge, IDs, vier Wurzeln und neun harte Abhängigkeiten
bleiben unverändert. Migration → Funktionsabnahme → A11Y → Rename bleibt
verbindlich. A11Y bleibt der deklarierte Eligible-Kandidat, Sandbox eine
unabhängige Pending-Wurzel; Eligible bedeutet keine Startberechtigung.
Keine weiteren fachlichen Befunde werden aus dieser begrenzten Wiederprüfung
abgeleitet. Keine neue Risikoannahme oder Produkt-/Plattformabnahme.

| Authoring-Receipt | Validator-Exit |
|---|---:|
| `specs/intake-authoring-receipts/a11y-tui.json` | 0 |
| `specs/intake-authoring-receipts/constitution-change.json` | 0 |
| `specs/intake-authoring-receipts/didactic-inline-code-comment-hardening.json` | 0 |
| `specs/intake-authoring-receipts/formelkopie-und-tabellenoperationen-v1.json` | 0 |
| `specs/intake-authoring-receipts/gsdb-spec-kit-intensivpruefung.json` | 0 |
| `specs/intake-authoring-receipts/legacy-kompatibilitaet-v1.json` | 0 |
| `specs/intake-authoring-receipts/pl0-zellfunktionen-v1.json` | 0 |
| `specs/intake-authoring-receipts/rename-microcalc-tinycalc.json` | 2 |
| `specs/intake-authoring-receipts/rl-se-checklist-selbstpruefung.json` | 0 |
| `specs/intake-authoring-receipts/sandbox-gestuetzte-secure-development-haertung.json` | 0 |
| `specs/intake-authoring-receipts/secure-development-hardening.json` | 0 |
| `specs/intake-authoring-receipts/terminalgui-migration.json` | 0 |
| `specs/intake-authoring-receipts/tui-funktionsabnahme-und-regressionsvertrag.json` | 2 |

### Ergebnisvalidierung und nächster Schritt

Die maschinenlesbare Ergebnisvalidierung wird mit Bash und PowerShell
ausgeführt; ihre Ausführungsprotokolle liegen in `review-validation.json`.
Ein gültiges NeedsRemediation-Ergebnis bestätigt die korrekte Darstellung
des blockierten Zustands; es bedeutet keinen grünen Gesamt-Alignment-Check.
Der Gesamtcheck bleibt wegen der beiden Quellbindungen fehlerhaft.

Nächste Aktion: diese beiden README-Bindungen über eine ausdrücklich
autorisierte Authoring-Erneuerung übernehmen, Vorgänger archivieren und
Intake-Inhalte sowie IDs unverändert erhalten. Danach erneut:
`$speckit-intake-review requirements/intakes/series/tinycalc-delivery/manifest.json`.
Bis dahin kein Specify- oder Produktlauf und keine Merge-Freigabe aus diesem
Review. Der Review selbst ist abgeschlossen.

Der frühere Ready-Review bleibt unter
`requirements/intakes/series-archive/tinycalc-delivery/20261103-dependabot-readme-source-renewal/`
erhalten und wird ausdrücklich ersetzt. Der unmittelbar vorherige Pending-
Bericht ist bytegleich unter `requirements/intakes/series-archive/tinycalc-delivery/20261103-model-routing-drift-review/pending-intake-review-report.md` archiviert.

Dokumentationsentscheidung: **UpdateRequired**. Owner: Thorsten Hindermann.
Kanonische Quelle: aktueller Review-Request und gebundene Intake-/Quellstände;
Leserpfad: dieser Bericht und benachbartes JSON-Ergebnis für Maintainer und
Lernbegleitung. DE/EN in einem Dokument, textorientiertes Markdown/JSON,
Source-only, kein Home-Sync. Neubewertung nach Quellen-Erneuerung oder Drift.
Keine Produktcodeänderung, kein Build, keine native Screenreader-Abnahme.

## English

Outcome: **NeedsRemediation**. Coverage: 13 targets, four roots, nine hard
dependencies and zero campaign workers. Findings: Critical 0, High 1,
Medium 0, Low 0. No accepted risks or unanswered clarification questions.
Review identity, exact revision, UTC time and receipt validation exits appear
above. IR002 blocks acceptance: the README changed again after the approved
source renewal, when #133 added Model Routing Governance 0.2.3 delivery notes.
The Rename and TUI functional acceptance receipts still bind the earlier
README hash. Both validators exit 2; the other eleven receipts pass.

All 13 normalized target hashes match the archived accepted review exactly.
Its semantic assessment is explicitly reused for unchanged contracts; this
is not a new independent semantic review. Current provenance, configuration,
inventory, manifest, series receipt and DAG were checked again. Requirements,
IDs, scope, status and ordering are unchanged. A11Y remains the declared
Eligible candidate, Sandbox an independent Pending root. Eligibility grants
no authority. Historical IR001 remains resolved; no past product, platform
or accessibility proof is presented as a current run.

Owner: Thorsten Hindermann for source adoption and authorized intake-authoring
repair for renewal. Disposition: open. Next: explicitly authorize renewal of
these two README bindings, archive predecessors, preserve intake bytes and
IDs, then rerun the Series review command shown above. Re-evaluate on any
source, target, policy or series drift. No implementation or risk acceptance
is implied. This review is complete; it does not authorize a product run or
merge. Bash and PowerShell result-validator outcomes are recorded separately
in review-validation.json; a valid blocked result does not make overall
alignment pass. Previous Ready evidence and the pending report are preserved.

Documentation impact: UpdateRequired; owner Thorsten Hindermann. This DE/EN
text-first report and machine result are source-only, with no Home sync.
No product code, build or native screenreader acceptance is part of this review.
