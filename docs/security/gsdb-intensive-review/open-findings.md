# Offene GSDB-Befunde / Open GSDB Findings

## Neubewertung / Reassessment

**DE:** Am 12.09.2026 wurden alle 13 Sammelbefunde neu bewertet. Sie bleiben formal Open; Finding 007 betrifft jetzt die Überführung einer vorhandenen CRA-Scope-Entscheidung. Die 42 Human-only-Markierungen zählen Vertragszustände, nicht 42 nachweislich fehlende Entscheidungen. Details, Teilnachweise und Abnahmekriterien: [Neubewertung](reevaluation-2026-09-12.md).

**EN:** All 13 grouped findings were reassessed on 2026-09-12. They remain formally Open; finding 007 now concerns integration of an existing CRA scope decision. The 42 human-only flags count contract states, not 42 proven missing decisions. See the linked reassessment for partial evidence and acceptance criteria.

## GSDB-FINDING-001: Standardsnachweise und verbleibende regulatorische Entscheidungen / Standards evidence and remaining regulatory decisions

- Schweregrad / Severity: High
- Status / Delivery impact: Open / DoesNotBlockCompletedAssessment
- Quellen / Sources: CL-01-05, CL-01-09, CL-01-10, CL-01-11, CL-01-12
- Owner: TinyCalc security governance role; Reviewer: Independent technical security review role
- Beobachtung / Observation: CRA-N/A ist seit 08.09.2026 dokumentiert; NIS2/DORA bleiben offen. SLSA-Level und aktueller Scorecard-Gesamtnachweis fehlen weiterhin. / CRA N/A has been documented since 2026-09-08; NIS2/DORA remain open. SLSA level and current aggregate Scorecard evidence remain absent.
- Folgearbeit / Follow-up: CRA-Scope auf CL-01-12 abbilden; SLSA, Scorecard, OWASP-Kontrollen und jede N/A-Begründung einzeln mit Nachweis und Prüfer abschließen. / Map the CRA scope to CL-01-12; close SLSA, Scorecard, OWASP controls and each N/A rationale individually with evidence and reviewer.
- Zieltermin / Target date: 2026-12-31; frühere Neubewertung bei Scope- oder Evidenzänderung / earlier reassessment on scope or evidence change.
- Restrisiko / Residual risk: Die offene Lücke bleibt sichtbar und wird nicht als erfüllt dargestellt. / The open gap remains visible and is not presented as fulfilled.

## GSDB-FINDING-002: Projektweite Architekturwirksamkeit unvollständig belegt / Project-wide architecture effectiveness is incompletely evidenced

- Schweregrad / Severity: Medium
- Status / Delivery impact: Open / DoesNotBlockCompletedAssessment
- Quellen / Sources: CL-02-02, CL-02-03, CL-02-04, CL-02-05, CL-02-06, CL-02-07, CL-02-08, CL-02-09, CL-02-10
- Owner: TinyCalc security governance role; Reviewer: Independent technical security review role
- Beobachtung / Observation: arc42 und Bedrohungsmodell liegen vor. Neue Intake-Pfad-, Graph- und Ausgabekontrollen belegen einen Werkzeugslice, nicht die gesamte Produktarchitektur. / arc42 and the threat model exist. New intake path, graph and output controls prove one tooling slice, not the whole product architecture.
- Folgearbeit / Follow-up: CL-02-02 bis CL-02-10 gegen reale Komponenten prüfen; zwei unabhängige Schutzschichten für kritische Assets, Rechte, Defaults und S-ADR-Anwendbarkeit mit positiven und negativen Prüfbelegen dokumentieren. / Review CL-02-02 through CL-02-10 against real components; document two independent controls for critical assets, privileges, defaults and S-ADR applicability with positive and negative evidence.
- Zieltermin / Target date: 2026-12-31; frühere Neubewertung bei Scope- oder Evidenzänderung / earlier reassessment on scope or evidence change.
- Restrisiko / Residual risk: Die offene Lücke bleibt sichtbar und wird nicht als erfüllt dargestellt. / The open gap remains visible and is not presented as fulfilled.

## GSDB-FINDING-003: Kryptografie-Inventar und Ausschlussnachweise fehlen / Cryptography inventory and exclusion evidence are missing

- Schweregrad / Severity: Medium
- Status / Delivery impact: Open / DoesNotBlockCompletedAssessment
- Quellen / Sources: CL-03-03, CL-03-06, CL-03-11
- Owner: TinyCalc security governance role; Reviewer: Independent technical security review role
- Beobachtung / Observation: Richtlinien und Code-Review sind vorhanden; ein vollständiges aktuelles Inventar für CL-03-03, CL-03-06 und CL-03-11 ist nicht nachgewiesen. / Policies and code review exist; a complete current inventory for CL-03-03, CL-03-06 and CL-03-11 is not evidenced.
- Folgearbeit / Follow-up: Produkt und Build-Skripte nach Hash-/Krypto-Aufrufen inventarisieren; Zweck, Algorithmus und Eigenbau-Ausschluss je Fund prüfen, Abwesenheit und Ausnahmen nachvollziehbar dokumentieren. / Inventory hash/crypto calls in product and build scripts; review purpose, algorithm and absence of custom crypto for each result; document absence and exceptions reproducibly.
- Zieltermin / Target date: 2026-12-31; frühere Neubewertung bei Scope- oder Evidenzänderung / earlier reassessment on scope or evidence change.
- Restrisiko / Residual risk: Die offene Lücke bleibt sichtbar und wird nicht als erfüllt dargestellt. / The open gap remains visible and is not presented as fulfilled.

## GSDB-FINDING-004: Bedrohungsmodell: Änderungs- und Reviewnachweis vervollständigen / Threat model: complete change and review evidence

- Schweregrad / Severity: Medium
- Status / Delivery impact: Open / DoesNotBlockCompletedAssessment
- Quellen / Sources: CL-04-08, CL-04-09
- Owner: TinyCalc security governance role; Reviewer: Independent technical security review role
- Beobachtung / Observation: Das Modell enthält STRIDE/CAPEC und einen Nachtrag vom 06.09.2026. Der Intake-Renderer besitzt neue lokale Bedrohungsnachweise; ein projektweiter Reviewabschluss fehlt. / The model contains STRIDE/CAPEC and a 2026-09-06 addendum. The intake renderer has new local threat evidence; project-wide review closure is missing.
- Folgearbeit / Follow-up: Neue Renderer-/Liefergrenzen zum Modell zuordnen, ältere Pending-Aussagen gegen Abschlussbelege prüfen und datierten Review mit Änderungs- und Wiedervorlagetrigger ablegen. / Map new renderer/delivery boundaries to the model, check older pending claims against completion evidence and record a dated review with change and re-review triggers.
- Zieltermin / Target date: 2026-12-31; frühere Neubewertung bei Scope- oder Evidenzänderung / earlier reassessment on scope or evidence change.
- Restrisiko / Residual risk: Die offene Lücke bleibt sichtbar und wird nicht als erfüllt dargestellt. / The open gap remains visible and is not presented as fulfilled.

## GSDB-FINDING-005: Lieferkette: Provenance und Betriebsnachweise offen / Supply chain: provenance and operational evidence remain open

- Schweregrad / Severity: Medium
- Status / Delivery impact: Open / DoesNotBlockCompletedAssessment
- Quellen / Sources: CL-05-04, CL-05-05, CL-05-06, CL-05-07, CL-05-08, CL-05-09, CL-05-10, CL-05-11, CL-05-12
- Owner: TinyCalc security governance role; Reviewer: Independent technical security review role
- Beobachtung / Observation: SBOM und historische Paket-/Lizenzberichte liegen vor. Produkt-Lockdateien und Update-Konfiguration fehlen; CI nutzt teilweise Major-Tags. Eine signierte Provenance ist nicht belegt. / SBOM and historical package/license reports exist. Product lock files and update configuration are absent; CI partly uses major tags. Signed provenance is not evidenced.
- Folgearbeit / Follow-up: Produkt-Lockdateien und kontrolliertes Restore, Update-/CVE-Prozess, Action-Pinning, reproduzierbaren Build, Lizenzprüfung und Secret-Schutz nachweisen; Attestation am Artefakthash verifizieren oder unbelegten SLSA-Level ausdrücklich beibehalten. / Evidence product lock files and controlled restore, update/CVE process, action pinning, reproducible builds, licence checks and secret protection; verify an attestation against the artifact hash or explicitly retain an unproven SLSA level.
- Zieltermin / Target date: 2026-12-31; frühere Neubewertung bei Scope- oder Evidenzänderung / earlier reassessment on scope or evidence change.
- Restrisiko / Residual risk: Die offene Lücke bleibt sichtbar und wird nicht als erfüllt dargestellt. / The open gap remains visible and is not presented as fulfilled.

## GSDB-FINDING-006: Schwachstellenprozess offen; CRA-Teilscope dokumentiert / Vulnerability process open; CRA sub-scope documented

- Schweregrad / Severity: High
- Status / Delivery impact: Open / DoesNotBlockCompletedAssessment
- Quellen / Sources: CL-06-01, CL-06-02, CL-06-03, CL-06-04, CL-06-05, CL-06-06, CL-06-07, CL-06-08, CL-06-09, CL-06-10, CL-06-11
- Owner: TinyCalc security governance role; Reviewer: Independent technical security review role
- Beobachtung / Observation: CRA-N/A ist dokumentiert, aber CL-06-07 noch nicht fachlich nachgeführt. CVD-Freigabe, erreichbarer Meldekanal und erprobte Reaktion sind nicht vollständig nachgewiesen. / CRA N/A is documented, but CL-06-07 has not been reconciled. CVD approval, a reachable reporting channel and an exercised response are not fully evidenced.
- Folgearbeit / Follow-up: CL-06-07 mit Scope-Entscheidung abgleichen; CVD-Verantwortlichen, Meldekanal, Fristen, Triage, Advisory und Patch-Prozess festlegen und anhand einer simulierten Meldung prüfen. / Reconcile CL-06-07 with the scope decision; define CVD ownership, reporting channel, deadlines, triage, advisories and patch process, then exercise a simulated report.
- Zieltermin / Target date: 2026-12-31; frühere Neubewertung bei Scope- oder Evidenzänderung / earlier reassessment on scope or evidence change.
- Restrisiko / Residual risk: Die offene Lücke bleibt sichtbar und wird nicht als erfüllt dargestellt. / The open gap remains visible and is not presented as fulfilled.

## GSDB-FINDING-007: CRA-Scope dokumentiert; Überführung in GSDB-Vertrag offen / CRA scope documented; integration into the GSDB contract open

- Schweregrad / Severity: High
- Status / Delivery impact: Open / DoesNotBlockCompletedAssessment
- Quellen / Sources: CL-07-01, CL-07-02, CL-07-03, CL-07-04, CL-07-05, CL-07-06, CL-07-07, CL-07-08, CL-07-09, CL-07-10, CL-07-11, CL-07-12
- Owner: TinyCalc security governance role; Reviewer: Independent technical security review role
- Beobachtung / Observation: Die Repository-Owner-Entscheidung vom 08.09.2026 dokumentiert CRA-N/A im nichtkommerziellen Ausbildungsscope. Die frühere Aussage, es liege keinerlei Entscheidung vor, ist überholt. Offen bleibt die zeilenspezifische Vertragsintegration, nicht eine pauschale CRA-Konformitätsumsetzung. / The repository-owner decision of 2026-09-08 documents CRA N/A for the non-commercial training scope. The earlier claim that no decision exists is outdated. Row-specific contract integration remains open, not blanket CRA conformity implementation.
- Folgearbeit / Follow-up: Nachweisformat für vorhandene menschliche Entscheidungen mit Herkunft, Scope, Datum und Wiedervorlage ergänzen und negativ testen; CL-07-01 bis CL-07-12 einzeln disponieren. N/A-Dokumentation selbst bleibt prüfpflichtig. Keine Änderung auf Fulfilled durch bloßen Preset-Erfolg. / Extend the evidence format for existing human decisions with provenance, scope, date and review trigger, including negative tests; assess CL-07-01 through CL-07-12 individually. N/A documentation itself still needs verification. Preset success alone must never imply Fulfilled.
- Zieltermin / Target date: 2026-12-31; frühere Neubewertung bei Scope- oder Evidenzänderung / earlier reassessment on scope or evidence change.
- Restrisiko / Residual risk: Die offene Lücke bleibt sichtbar und wird nicht als erfüllt dargestellt. / The open gap remains visible and is not presented as fulfilled.

## GSDB-FINDING-008: Produkt-Codeprüfung und Fehler-/Dateigrenzen nachweisen / Evidence product code review and error/file boundaries

- Schweregrad / Severity: Medium
- Status / Delivery impact: Open / DoesNotBlockCompletedAssessment
- Quellen / Sources: CL-08-01, CL-08-02, CL-08-06, CL-08-07, CL-08-08, CL-08-09, CL-08-10, CL-08-11, CL-08-12
- Owner: TinyCalc security governance role; Reviewer: Independent technical security review role
- Beobachtung / Observation: Produktcode ist seit 30.08.2026 unverändert. ExecuteSafe zeigt ex.Message an; Load liest die ganze Datei und leert die Engine vor Verarbeitung aller Zellen. Das sind konkrete Prüfziele, keine hier reproduzierten Exploits. / Product code is unchanged since 2026-08-30. ExecuteSafe displays ex.Message; Load reads the whole file and clears the engine before processing all cells. These are concrete review targets, not exploits reproduced in this review.
- Folgearbeit / Follow-up: Ungültige/große JSON-Dateien, null-Zellen, Feldgrenzen, Zustandskonsistenz nach Ladefehlern und Dateifehlerausgaben prüfen; bereinigte Benutzermeldungen, Ressourcenlimits und passende Regressionen anhand des tatsächlichen Ergebnisses umsetzen. / Test malformed/large JSON files, null cells, field limits, state consistency after load failures and file error output; implement sanitized user messages, resource limits and suitable regressions according to actual results.
- Zieltermin / Target date: 2026-12-31; frühere Neubewertung bei Scope- oder Evidenzänderung / earlier reassessment on scope or evidence change.
- Restrisiko / Residual risk: Die offene Lücke bleibt sichtbar und wird nicht als erfüllt dargestellt. / The open gap remains visible and is not presented as fulfilled.

## GSDB-FINDING-009: KI-Workflow: technische Teilbelege und menschliche Reviews trennen / AI workflow: separate technical partial evidence and human reviews

- Schweregrad / Severity: High
- Status / Delivery impact: Open / DoesNotBlockCompletedAssessment
- Quellen / Sources: CL-09-01, CL-09-02, CL-09-03, CL-09-04, CL-09-05, CL-09-06, CL-09-07, CL-09-08, CL-09-09, CL-09-10, CL-09-11, CL-09-12, CL-09-13, CL-09-14, CL-09-15, CL-09-16, CL-09-17
- Owner: TinyCalc security governance role; Reviewer: Independent technical security review role
- Beobachtung / Observation: Verlinkte Intake-Belege und Governance v0.4.4 stärken Zuordnung und Lieferintegrität. Werkzeugfreigaben, Vier-Augen-Review, Schulung und Risikoentscheidungen werden dadurch nicht belegt. / Linked intake evidence and governance v0.4.4 improve traceability and delivery integrity. They do not prove tool approval, four-eyes review, training or risk decisions.
- Folgearbeit / Follow-up: Technische Nachweise den CL-09-Kontrollen zuordnen; Paketexistenz/CVE, Prompt-Daten, Telemetrie und PR-Kennzeichnung prüfen. Menschliche Freigaben, Lizenzklärung, Review und Schulung als getrennte Belege erfassen. / Map technical evidence to CL-09 controls; check package existence/CVEs, prompt data, telemetry and PR marking. Record human approval, licence clearance, review and training separately.
- Zieltermin / Target date: 2026-12-31; frühere Neubewertung bei Scope- oder Evidenzänderung / earlier reassessment on scope or evidence change.
- Restrisiko / Residual risk: Die offene Lücke bleibt sichtbar und wird nicht als erfüllt dargestellt. / The open gap remains visible and is not presented as fulfilled.

## GSDB-FINDING-010: Host-/Providerkontrollen nicht vollständig nachgewiesen / Host/provider controls are not fully evidenced

- Schweregrad / Severity: High
- Status / Delivery impact: Open / DoesNotBlockCompletedAssessment
- Quellen / Sources: CL-10-01, CL-10-02, CL-10-03, CL-10-04, CL-10-05, CL-10-07, CL-10-08, CL-10-09, CL-10-10, CL-10-11, CL-10-12, CL-10-13, CL-10-14, CL-10-15, CL-10-16
- Owner: TinyCalc security governance role; Reviewer: Independent technical security review role
- Beobachtung / Observation: Neue native Workflow-Definitionen und lokale Validatoren sind vorhanden. Sie belegen weder Host-Verschlüsselung/MFA noch aktive Remote-Regeln, Backup-Erfolg oder Zugriffsrezertifizierung. / New native workflow definitions and local validators exist. They prove neither host encryption/MFA nor active remote rules, successful recovery or access recertification.
- Folgearbeit / Follow-up: Für alle 14 Human-only-Punkte datierte, bereinigte Host-/Providerbelege mit verantwortlicher Person erfassen; CL-10-09 durch zwei vergleichbare Builds belegen. Workflow-Dateien nicht als ausgeführte Jobs ausgeben. / Capture dated, sanitized host/provider evidence with an accountable person for all 14 human-only items; evidence CL-10-09 with two comparable builds. Do not present workflow files as executed jobs.
- Zieltermin / Target date: 2026-12-31; frühere Neubewertung bei Scope- oder Evidenzänderung / earlier reassessment on scope or evidence change.
- Restrisiko / Residual risk: Die offene Lücke bleibt sichtbar und wird nicht als erfüllt dargestellt. / The open gap remains visible and is not presented as fulfilled.

## GSDB-FINDING-011: Datenschutzkonsultationen: Anwendbarkeit weiter offen / Privacy consultations: applicability remains open

- Schweregrad / Severity: High
- Status / Delivery impact: Open / DoesNotBlockCompletedAssessment
- Quellen / Sources: CL-11-06, CL-11-07
- Owner: TinyCalc security governance role; Reviewer: Independent technical security review role
- Beobachtung / Observation: Die Regulatorikquelle trennt Produkt-N/A und anwendbare Delivery-Datenverarbeitung. Eine Entscheidung zu Datenschutzbeauftragtem oder Aufsichtsbehörde fehlt weiterhin. / The regulatory source separates product N/A and applicable delivery data processing. A decision on the data protection officer or supervisory authority is still absent.
- Folgearbeit / Follow-up: Datenflüsse von Repository, Provider, Support und Telemetrie abgrenzen; zuständige Person dokumentiert je CL-11-06/-07 die Anwendbarkeit und gegebenenfalls Konsultation. Keine Behördenpflicht allein aus Open ableiten. / Scope repository, provider, support and telemetry data flows; the accountable person records applicability and any consultation for CL-11-06/-07. Open alone does not establish a duty to contact an authority.
- Zieltermin / Target date: 2026-12-31; frühere Neubewertung bei Scope- oder Evidenzänderung / earlier reassessment on scope or evidence change.
- Restrisiko / Residual risk: Die offene Lücke bleibt sichtbar und wird nicht als erfüllt dargestellt. / The open gap remains visible and is not presented as fulfilled.

## GSDB-FINDING-012: Sandbox-Isolation und Freigaben bleiben offen / Sandbox isolation and approvals remain open

- Schweregrad / Severity: High
- Status / Delivery impact: Open / DoesNotBlockCompletedAssessment
- Quellen / Sources: CL-12-01, CL-12-02, CL-12-03, CL-12-04, CL-12-05, CL-12-07, CL-12-09, CL-12-10, CL-12-11, CL-12-12
- Owner: TinyCalc security governance role; Reviewer: Independent technical security review role
- Beobachtung / Observation: Index-/Pfadprüfungen reduzieren Manipulationsrisiken. Sie sind kein Nachweis für Laufzeit-Isolation. Diese Review-Sitzung läuft mit uneingeschränktem Dateisystemzugriff und aktiviertem Netzwerk. / Index/path checks reduce tampering risks. They are not runtime isolation evidence. This review session has unrestricted filesystem access and enabled networking.
- Folgearbeit / Follow-up: Zielsandbox definieren; abgewiesene Zugriffe außerhalb erlaubter Mounts, Netzwerkrestriktionen und Secret-Isolation testen. Werkzeug-/Modellfreigabe, menschlichen Review und Revalidierung mit tatsächlichen Entscheidungsbelegen dokumentieren. / Define the target sandbox; test denied access outside allowed mounts, network restrictions and secret isolation. Record tool/model approval, human review and revalidation with actual decision evidence.
- Zieltermin / Target date: 2026-12-31; frühere Neubewertung bei Scope- oder Evidenzänderung / earlier reassessment on scope or evidence change.
- Restrisiko / Residual risk: Die offene Lücke bleibt sichtbar und wird nicht als erfüllt dargestellt. / The open gap remains visible and is not presented as fulfilled.

## GSDB-FINDING-013: Sechzehn Richtlinienpflichten benötigen Wirksamkeitsnachweise / Sixteen policy duties need effectiveness evidence

- Schweregrad / Severity: Medium
- Status / Delivery impact: Open / DoesNotBlockCompletedAssessment
- Quellen / Sources: GSDB-DUTY-001, GSDB-DUTY-002, GSDB-DUTY-003, GSDB-DUTY-004, GSDB-DUTY-005, GSDB-DUTY-006, GSDB-DUTY-007, GSDB-DUTY-008, GSDB-DUTY-009, GSDB-DUTY-010, GSDB-DUTY-011, GSDB-DUTY-012, GSDB-DUTY-013, GSDB-DUTY-014, GSDB-DUTY-015, GSDB-DUTY-016
- Owner: TinyCalc security governance role; Reviewer: Independent technical security review role
- Beobachtung / Observation: Richtlinien und vier technisch bereite Assurance-Gates liegen vor. Organisatorische Wirksamkeit, Notfallübung, Schulung und Freigaben folgen daraus nicht. / Policies and four technically ready assurance gates exist. Organizational effectiveness, recovery exercises, training and approvals do not follow from them.
- Folgearbeit / Follow-up: GSDB-DUTY-001 bis -016 jeweils mit verantwortlicher Person, konkretem Prozess, aktueller Stichprobe und Abschlusskriterium versehen; gemeinsame Nachweise wiederverwenden, aber jede Pflicht einzeln prüfen. / For GSDB-DUTY-001 through -016 record an accountable person, concrete process, current sample and closure criterion; reuse shared evidence but verify each duty separately.
- Zieltermin / Target date: 2026-12-31; frühere Neubewertung bei Scope- oder Evidenzänderung / earlier reassessment on scope or evidence change.
- Restrisiko / Residual risk: Die Bewertung ersetzt keine organisatorische oder rechtliche Freigabe. / The assessment does not replace organizational or legal approval.
