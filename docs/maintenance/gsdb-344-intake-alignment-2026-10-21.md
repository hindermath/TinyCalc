# Governance-/Intake-Abgleich 2026-10-21 / Governance and Intake Alignment

## Auftrag und Ausgangslage / Authority and Baseline

Deutsch: Thorsten hat diesen lokalen Dokumentenabgleich samt getrenntem unabhängigem Serienreview ausdrücklich beauftragt. Basis ist `5dc92cfd53b6afc785e39e465472a4fe263352cd`, der Merge von PR #114; PR #113 lieferte GSDB 3.4.4 und Assurance 0.1.5. Ein Receipt ist ein Herkunftsnachweis, ein Hash ein Inhaltsfingerabdruck und ein Gate eine Prüfschranke. Quellen übernehmen bedeutet nicht, Produktkonformität nachzuweisen.

English: Thorsten explicitly requested local document alignment and a separate independent Series review. The base is the PR #114 merge; PR #113 delivered GSDB 3.4.4 and Assurance 0.1.5. A receipt records provenance, a hash fingerprints content and a gate is a checkpoint. Source adoption does not prove product conformance.

## Änderungen und Erhaltung / Changes and Preservation

Deutsch: Vorprüfung: zehn aktuelle Authoring-Receipts, drei erwartete Quellenabweichungen: PL/0 gegen AGENTS.md, Rename und die abgeschlossene Funktionsabnahme 006 gegen README.md. Das bisherige Serienreview bindet unveränderte Zielhashes, prüft aber nicht die neue Governance-Basis. Die Impact-Matrix `docs/maintenance/gsdb-344-intake-control-impact.json` ordnet genau 50 geänderte Kontroll-IDs ihren künftigen Härtungs-/Sandbox-Aufträgen und bestehenden Feature-007-Verträgen zu. `AlreadyCovered` beschreibt Dokumentenabdeckung, nicht Implementierung; alle Produktbewertungen dort sind `Not Assessed`.

English: Preflight found ten current receipts and three expected source drifts: PL/0 against AGENTS.md, Rename and completed Feature 006 against README.md. The prior review binds unchanged target hashes but does not assess the new governance baseline. The impact matrix maps exactly 50 changed controls to future hardening/sandbox work and existing Feature 007 contracts. AlreadyCovered means document coverage only, never product implementation.

Deutsch: Fünf Receipts werden unter gleicher Intake-ID mit neuen Receipt-/Operation-IDs erneuert. PL/0, Rename und das archivierte 006-Lastenheft bleiben byteidentisch; für 006 ändert sich ausschließlich die administrative Herkunftsbindung. Die Härtungs- und Sandbox-Intakes trennen Anwendbarkeit, Umsetzung und Gate-Ergebnis. Das A11Y-Intake bleibt byteidentisch. Feature 007 erhält GA-007-01–03 und Präzisierungen an T003/T005/T047/T048; alle 60 Aufgaben bleiben offen. Zehn A11Y-Anforderungen, acht Abnahmekriterien, CQ-001/CQ-002, 17 Familien und die Mindestbaseline 364 Wege je Plattform bleiben erhalten.

English: Renew five receipts with retained intake identities and new receipt/operation identities. PL/0, Rename and the archived 006 intake keep identical bytes; only administrative provenance changes for 006. Hardening/sandbox intakes separate applicability, implementation and gate outcome. The A11Y intake is unchanged. Feature 007 adds GA-007-01–03 and clarifies four existing tasks without executing any of its 60 tasks. Preserve all requirements, criteria, clarified decisions and full functional baseline.

Deutsch: Die Serie behält 13 Ziele, vier Wurzeln, neun bindende Kanten und sämtliche Status. Migration → Funktionsabnahme → A11Y → Rename bleibt bindend. Sandbox bleibt eine unabhängige Pending-Wurzel. TinyPl0s externe Lieferung ist weiterhin kein TinyCalc-Preflight. Historische GSDB-/RL-SE-/Produktabnahmen und zurückgenommene Positivaussagen werden nicht umgeschrieben oder als neue Erfüllung übernommen. Ein zusätzlicher externer Rollenfreigabezwang wird nicht eingeführt.

English: Preserve all series cardinalities, edges, statuses and order. Sandbox remains an independent Pending root. External TinyPl0 delivery does not satisfy TinyCalc integration gates. Do not rewrite historical GSDB/RL-SE/product acceptance or transfer withdrawn positives. Introduce no external qualified-role approval requirement.

## Quellen, Lineage und Review / Sources, Lineage and Review

- Verbindliche Serie / Binding series: `../../requirements/intakes/series/tinycalc-delivery/manifest.json`
- Operation und Hash-Lineage / Operation and hash lineage: `../../specs/intake-authoring-operations/44f5901d-e5d9-42b8-b975-4693195d034f/lineage.json`
- Genehmigter Änderungsumfang / Approved change scope: `../../specs/intake-authoring-operations/44f5901d-e5d9-42b8-b975-4693195d034f/proposal.json`
- Archivierter, supersedierter Review / Archived superseded review: `../../requirements/intakes/series-archive/tinycalc-delivery/20261021-gsdb344-alignment/superseded-review.json`
- Aktuelle GSDB-Matrix / Current GSDB matrix: `../security/gsdb-intensive-review/evidence-matrix.json`
- Aktuelle RL-SE-Matrix / Current RL-SE matrix: `../security/secure-development/2026-10-20-tinycalc-gsdb344/rl-se-assessment-matrix.json`
- Feature 007: `../../specs/007-tui-accessibility/spec.md`

Deutsch: Die oben genannten JSON- und Featurequellen sind Repository-Dateien, keine von der unveränderten DocFX-Konfiguration veröffentlichten HTML-Ressourcen. Pfade dienen der Quellennavigation, nicht als behauptete HTML-Links.

English: The JSON and feature sources above are repository files, not HTML resources published by the unchanged DocFX configuration. Paths support source navigation without claiming published HTML links.

Deutsch: Vorgänger-Intakes, Receipts, Manifest, Operation, Reihenfolge und Review-Artefakte werden byteidentisch archiviert. Der alte Review wird ausdrücklich supersediert. Nach validierter Aktualisierung folgt zunächst ein rein lesender Serienstatus und erst danach der getrennt beauftragte unabhängige Review aller 13 Ziele samt Feature-007-Abgleich. Ergebnis und Dateihashes werden separat festgehalten; bis dahin kein Ready behaupten. Ein unabhängiger Agent prüft Dokumente, keine menschliche Produktabnahme.

English: Archive predecessor documents and evidence byte-identically, explicitly superseding the prior review. After validating the update, inspect Series status read-only, then conduct the separately authorised independent review of all 13 targets and Feature 007 alignment. Bind outcomes to file hashes. No Ready claim before review, and no human/product acceptance inferred from an independent agent.

## Standards und Nachweisgrenzen / Standards and Evidence Boundaries

Deutsch: NIST SSDF und CWE Top 25 gelten für Quellen-, Daten- und Evidenzintegrität dieser Dokumentenarbeit. WCAG 2.2 AA gilt für anwendbare Dokumentationskriterien; textorientiert, Deutsch zuerst/Englisch danach, CEFR B2. Bestehende SAMM-/Cheat-Sheet-/Proactive-Controls-/Scorecard-Kontexte bleiben Referenzen. Produkt-SBOM/VEX/SLSA-Neuerzeugung ist hier N/A, da keine Produkt-/Release-/CI-Artefakte erzeugt werden; Trigger ist eine spätere Lieferung. ASVS-Level, Produkt-AI-SBOM und Produkt-Zero-Trust sind hier N/A ohne Web-/Auth-/KI-Runtime-/verteilte Produktänderung; bei solchem Scope erneut prüfen. KI ist Entwicklungswerkzeug; daraus folgt kein pauschales regulatorisches N/A für Werkzeugbetrieb oder Organisation. Regulatorische Tatsachen und Entscheidungen werden hier nicht neu bewertet oder als Rechtsberatung ausgegeben.

English: SSDF/CWE apply to document and evidence integrity; applicable WCAG AA, text-first bilingual B2 govern documentation. Retain supporting maturity/OSS contexts. New product SBOM/VEX/SLSA evidence is N/A without product/release/CI artefacts, triggered by later delivery. ASVS/product AI-SBOM/product Zero Trust are N/A without relevant web/auth/AI-runtime/distributed product changes. Development-only AI does not establish blanket regulatory exclusions for tooling or organisations. This work makes no new legal determination.

## Durchführung und verbleibende Grenzen / Execution and Remaining Boundaries

Deutsch: Gesamt-Alignment, Authoring-/Serienvalidatoren, Konfiguration, Operation und Dokumentationsimpact bestehen im Kandidaten beide Shell-Wege. Die vorhandenen Alignmentfixtures bestehen mit zehn Legacy- und 26 verknüpften Fällen. 17 Archivpaare sind bytegleich, 820 geschützte Dateien unverändert. Der getrennte unabhängige Review ist Ready nur für Dokumentenqualität: 13 Ziele, 50 Kontroll-IDs, sechs neue Checklistenpunkte und 32 hashgebundene Eingaben. IR001 (Medium: vermischte Open-Bedeutung im aktiven Reifeblock) wurde korrigiert und unabhängig nachgeprüft; null offene Befunde, Fragen oder akzeptierte Risiken. Konkrete Schlussprüfungen und Exitcodes stehen in `specs/intake-authoring-operations/44f5901d-e5d9-42b8-b975-4693195d034f/validation.json`. Dokumentationsimpact: UpdateRequired; Leserpfad Serie → dieser Bericht → Kontrollmatrix → Feature 007 → Review. Nur Quellen, kein Home-Sync.

English: Both shell paths pass candidate alignment, authoring/series, configuration, operation and documentation-impact checks. Existing fixtures pass ten legacy and 26 linked cases. Seventeen archives match bytes and 820 protected files are unchanged. Separate independent review is Ready for document quality only, covering 13 targets, 50 controls, six new checks and 32 hash-bound inputs. Medium finding IR001 was corrected and independently rechecked; no open findings, questions or accepted risks. The separate validation JSON records final commands, exit codes and boundaries. Documentation impact is UpdateRequired, source-only with no Home sync.

Deutsch: Kein Produktbuild, Produkttest, Restore, Upgrade, Implementierungsstart, Commit, Push, PR, Merge oder Admin-Bypass. `sheet.mcalc.json` bleibt ausgeschlossen. Das Statistikledger wird fortgeschrieben; der generierte Profil-2-Block bleibt am bisherigen sauberen Quellenstand, bis ein separat genehmigter Quellencommit regelkonformes Preview/Render/Check erlaubt. Keine frischen Gesamtzahlen oder Beschleunigungswerte behaupten. Ein neues Diagramm ist nicht nötig: Reihenfolge und Zuordnung sind in Text und bestehenden Serienansichten vollständig beschrieben.

English: No product build/test/restore/upgrade, implementation or Git delivery. Exclude the private sheet. Update the ledger without presenting the old clean-source generated block as freshly rendered; a later authorised source commit enables preview/render/check. Do not invent new totals or speedup claims. Existing text and series views already explain the relationships without a new diagram.

## HTML-/A11Y-Smoke und offene Punkte / HTML Accessibility Smoke and Open Items

Deutsch: Manifestgebundenes DocFX 2.81.0 erzeugt HTML mit unveränderter Konfiguration und ohne `metadata` oder Produktbuild. Sechs tatsächlich erzeugte Seiten wurden mit Chrome/Playwright-ARIA-Snapshot, axe 4.14.0 und UTF-8-lynx geprüft: dieser Bericht, PR-Entwurf, Statistik, README, A11Y-Intake und archivierte Funktionsabnahme 006. Keine gemeldeten axe-Verstöße; jeweils deutsche Seitensprache, ein Hauptbereich, benannter erster Tastaturfokus und lynx Exit 0. Die axe-Quelle wurde versionsgenau von der offiziellen Registry geladen und vor Ausführung mit SHA-512 geprüft, nur im Speicher verwendet; keine Paketinstallation oder Projektabhängigkeit wurde geändert. Der erste Smoke-Versuch verwendete irrtümlich `index.html` statt der tatsächlich erzeugten `README.html` und wurde nach Korrektur wiederholt.

Deutsch: `color-contrast` und teilweise `link-in-text-block` bleiben unvollständig bewertet; Sprachwechsel nach 3.1.2, vollständige Tastaturwege und native Reader-/Braille-Nachweise sind nicht abgenommen. Drei bestehende defekte HTML-Quelllinks bleiben offen: zwei im Statistikledger zu nicht veröffentlichten Serienreports, einer im archivierten 006-Lastenheft zum alten relativen A11Y-Pfad. Keine neuen defekten Inhaltslinks im Bericht oder PR-Entwurf. Historische Texte werden deswegen nicht umgeschrieben. Der erste vollständige HTML-Build meldete 113 Warnungen; spätere Fehler-Level-Ausgabe bedeutet nicht, dass alte Warnungen behoben sind. Der maschinenlesbare Smoke-Nachweis liegt bei `specs/intake-authoring-operations/44f5901d-e5d9-42b8-b975-4693195d034f/html-a11y.json`. Automatischer Smoke ist keine vollständige WCAG-AA-Zusage.

Deutsch: Statistik-Preview liefert DRY_RUN mit Drift, Check-only DRIFT (Exit 1). Der generierte Block bleibt absichtlich unverändert. Die Homogenitätsprüfung meldet in beiden Shells ausschließlich den offenen Profil-2-Statistikpunkt; kein vollständiger Homogenitäts-Pass wird behauptet. Kein Dirty-Guard-Bypass, Commit oder Stash.

English: Pinned DocFX builds actual HTML without changing configuration, generating API metadata or building products. Six actual pages received Chrome/Playwright snapshots, axe 4.14.0 and UTF-8 lynx checks: no reported axe violations, German page language, one main landmark, named initial keyboard focus and successful text dumps. Fetch the exact QA tool from the official registry, verify SHA-512 and use it only in memory, without package installation. Corrected the initial smoke's nonexistent index.html to actual README.html and repeated it.

English: Contrast and some link assessments remain incomplete; language-of-parts, full keyboard interaction and native reader/Braille proof are not accepted. Three existing broken HTML source links remain in historical statistics/006 material; no new broken content links occur in the report or PR draft. Preserve historical text. The first full build had 113 warnings; quieter later logging does not prove them fixed. The separate HTML JSON binds bounded smoke evidence, not full WCAG conformance.

English: Statistics preview reports drift, and check-only exits 1. Leave the generated block unchanged. Both homogeneity paths report only this pending Profile 2 item, not a complete pass. No clean-tree guard bypass, commit or stash.
