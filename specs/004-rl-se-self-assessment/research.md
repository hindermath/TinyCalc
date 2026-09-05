# Research: RL-SE-/Checklist-Selbstpruefung

## Forschungsrahmen / Research Frame

**DE:** Diese Entscheidungen binden nur den TinyCalc-Selbstpruefungslauf. Sie
veraendern weder die generische Baseline noch Produktcode und erteilen keine
menschliche Freigabe.

**EN:** These decisions bind only the TinyCalc self-assessment run. They change
neither the generic baseline nor product code and grant no human approval.

## R-001 - Quellenrangfolge

**Decision:** `docs/secure-development/baseline-manifest.json` Version 3.2.0
bestimmt Umfang und Versionen. Die zwoelf Einzelchecklisten sind fuer stabile
IDs und Inhalte kanonisch. Richtlinie und mitgeltende Dokumente liefern den
fachlichen Kontext. Der generierte Sammelband ist eine Paritaets-Lesesicht.

**Rationale:** Eine einzige ID-Quelle verhindert Doppelzaehlung. Der
Manifestwert `checklistItemCount: 157` ist ein unabhaengiger Sollwert.

**Rejected:** IDs aus Einzeldateien und Sammelband zusammenfuehren. Das wuerde
jede ID duplizieren und Quelle sowie Ableitung vermischen.

## R-002 - Statusmodell

**Decision:** Jede Zeile fuehrt die Intake-Hauptdisposition und beide
GSDB-Achsen. `AlreadySatisfied` wird nur als `Applicable` + `Fulfilled`
zugelassen. `FollowUp` besitzt weiterhin eine heutige Anwendbarkeit und einen
heutigen Umsetzungsstand. `N/A` verlangt `Not Assessed`.

**Rationale:** Das bewahrt die fuenf nutzerorientierten Intake-Begriffe und
bleibt zugleich kompatibel mit der zweiachsigen Baseline und dem Assurance-
Validator.

**Rejected:** Nur eine Achse oder freier Text. Beides waere nicht eindeutig
validierbar.

## R-003 - Evidenzstaerke

**Decision:** Eine positive Aussage benoetigt einen existierenden,
repository-relativen Pfad und eine konkrete Aussage, die dieser Pfad belegt.
Provider-Nachweise duerfen als stabile URL oder Lauf-ID ergaenzen, aber lokale
Pflichtfelder weder ersetzen noch Secrets oder private Pfade offenlegen.

**Rationale:** Dateiexistenz allein beweist keine Erfuellung. Lokale Referenzen
bleiben reproduzierbar und datenschutzarm.

**Rejected:** Ein pauschaler Verweis auf `docs/security/` je Familie. Er ist zu
unspezifisch fuer eine positive Kontrollaussage.

## R-004 - Human-only-Grenze

**Decision:** Technische Validierung, Pilotfreigabe, Projektabnahme und
allgemeine Freigabe bleiben vier getrennte Entscheidungen. Der Agent darf
technische Evidenz erzeugen, aber keine der menschlichen Entscheidungen aus
einem gruenen Validator ableiten. Ohne echte Entscheidung bleibt der Status
`Open`.

**Rationale:** Dies entspricht dem Assurance-Vertrag und verhindert erfundene
Zertifizierungs-, Audit- oder Rechtsaussagen.

## R-005 - Vertragsimplementierung

**Decision:** Ein kleiner PowerShell-7-Validator liest die JSON-Matrix, gewinnt
die kanonischen IDs aus den Einzelchecklisten und prueft Schema, Kardinalitaet,
Eindeutigkeit, Statuskombinationen, Pflichtfelder und sichere lokale Pfade. Ein
Bash-Wrapper bietet dieselbe Schnittstelle und ruft die gemeinsame
PowerShell-Implementierung mit `pwsh -NoProfile` auf.

**Rationale:** Das Repository bevorzugt PowerShell fuer strukturierte
Automation. Eine gemeinsame Implementierung vermeidet semantische Drift,
waehrend beide Plattform-Einstiege vorhanden bleiben.

**Rejected:** Zwei unabhaengige Parser. Der zusaetzliche Wartungsaufwand und das
Risiko unterschiedlicher Statusregeln ueberwiegen den Nutzen.

## R-006 - RED/GREEN-Evidenz

**Decision:** RED verwendet bei jeder Ausfuehrung einen garantiert fehlenden
Pfad in einem frisch benannten temporaeren Verzeichnis. Isolierte Row-Contract-
Tests verwenden eine gueltige Zeile und fokussierte ungueltige Varianten; sie
behaupten nicht, ein vollstaendiges Dokument zu sein. GREEN fuer das
Produktionsschema gilt erst bei der vollstaendigen 157-Zeilen-Matrix. Beide
Entry-Points laufen lokal sowie in der vorhandenen Linux/Windows-CI-Matrix.
Ausgaben und Exitcodes werden im Laufnachweis festgehalten.

**Rationale:** Auch bei Dokumentationsarbeit bleibt der Vertrag beobachtbar und
negativ getestet, ohne Product-TDD vorzutäuschen.

## R-007 - Sicherheitsstandards

**Decision:** NIST SSDF und CWE Top 25 sind immer anwendbar. STRIDE/CAPEC,
Supply Chain, SBOM und SLSA werden gegen den aktuellen Stand bewertet. VEX wird
bei einem konkreten Fund relevant. SAMM wird als Reifegrad-Folgepfad betrachtet.
ASVS, Produkt-AI-SBOM und Zero Trust sind fuer den unveraenderten lokalen TUI
`N/A` mit den in der Spezifikation genannten Triggern. CRA, NIS2, EU AI Act,
DORA, BSI C3A und C5 erhalten ausdrueckliche technische
Anwendbarkeitsentscheidungen, aber keine Rechts- oder Testataussage.

## R-008 - Architektur- und Dokumentationsdelta

**Decision:** Keine neue S-ADR und keine Produkt- oder DocFX-Aenderung. Der
neue Assurance-Kontext liegt unter `docs/security/secure-development/`; der
Security-Index wird nur fuer Auffindbarkeit angepasst. Nutzertexte sind
DE-first/EN-second, CEFR B2 und text-first. Statistik wird aktualisiert; die
fuenf Agenten-Guidance-Dateien bleiben unveraendert, solange keine gemeinsame
Regel geaendert wird.

## R-009 - Delivery und Lebenszyklus

**Decision:** PreMerge-Evidenz bleibt temporaer und bindet den exakt reviewten
Head. PostMerge bindet den akzeptierten PreMerge-Hash und den tatsaechlichen
Provider-Merge-Commit. Dafuer ist genau ein vorbenannter, evidence-only
Closeout ohne Produktdelta verbindlich. Danach bleiben Provider-Verifikation
und finaler Runtime-State read-only beziehungsweise ignoriert.

**Rationale:** Ein commiteter PreMerge-Snapshot wuerde seinen eigenen Head
veraendern. Die Trennung bewahrt kausale, nicht selbstwiderspruechliche Evidenz.
