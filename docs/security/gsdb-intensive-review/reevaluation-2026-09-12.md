# Neubewertung der 13 GSDB-Findings / Reassessment of the 13 GSDB findings

## Deutscher Prüfblock

### Ergebnis und Beweisgrenze

Prüfdatum: 12.09.2026. Repository-Basis: `1428b42` auf `main`.
Arbeitsbranch: `codex/gsdb-findings-reevaluation`.
Auftrag: Neubewertung, Zuordnung neuer Teilnachweise und konkrete Folgearbeit.
Technischer Reviewer: Codex; zuständige Repository-Person: Thorsten Hindermann.
Dies ist kein unabhängiger menschlicher Vier-Augen-Review und keine neue Freigabe.

Alle 13 Findings wurden anhand ihrer verknüpften Kontrollen betrachtet.
Die Matrix zählt weiterhin 157 Punkte: 21 erfüllt, 62 teilweise erfüllt,
42 Open/Human-only und 32 N/A. Dazu gehören 16 externe Pflichten.
Es bleiben formal 13 offene Sammelbefunde, sieben High und sechs Medium.
Es wird keine neue Zahl erfüllter Kontrollen behauptet.

Die Neubewertung unterscheidet drei Ergebnisse:

- **Vorhandene Scope-Entscheidung, Vertragsintegration offen:** Finding 007.
- **Neue begrenzte Teilnachweise, projektweite Erfüllung offen:** besonders
  Findings 001, 002, 004, 006, 009, 010, 012 und 013.
- **Kein ausreichender zusätzlicher Abschlussnachweis:** Findings 003, 005,
  008 und 011. Konkrete vorhandene Kontrollen bleiben anerkannt.

Die Schweregrade sind die übernommenen Governance-Einstufungen, keine CVSS-Werte
für bestätigte Exploits. Insbesondere der High-Wert für Finding 007 wird nicht
als neu bestätigtes regulatorisches Risiko ausgegeben.

### Anwendbare Standards

NIST SSDF und CWE Top 25 gelten für diese Level-2-Arbeit. STRIDE/CAPEC,
OWASP Cheat Sheets/Proactive Controls und SAMM dienen als Review-Linsen.
SBOM bleibt für das verteilbare Produkt anwendbar; SLSA und OpenSSF bleiben
Lieferkettenziele. Ein historischer Scan ist kein frischer CVE-Bericht.
VEX ist in dieser Neubewertung N/A: Es wurde kein aktueller CVE-Fund disponiert.
AI-SBOM ist im dokumentierten Produktscope N/A, weil KI Entwicklungswerkzeug ist.
ASVS ist für diesen Dokumentations-/lokalen TUI-Scope N/A: keine neue HTTP-,
API- oder Authentifizierungsfläche. Zero Trust für die lokale Produktlaufzeit
ist N/A; Provider-/Entwicklungszugriffe bleiben separat zu prüfen.
C5 und CRA werden ausschließlich als bestehende projektbezogene N/A-Entscheidungen
vom 08.09.2026 übernommen, nicht rechtlich neu beurteilt. Wiedervorlage:
31.12.2026 oder früher bei den dort genannten Scopeänderungen.

### Neue Evidenz und deren Reichweite

| Quelle | Verwertbarer Nachweis | Grenze |
|---|---|---|
| [Assurance-Feldtest](../../maintenance/secure-development-assurance-v013-field-test.md) | Kontextkorrektur, vier Ready-Gates, positive und negative Vertragsprüfungen | Keine Produkt-, Risiko- oder allgemeine Freigabe |
| [Regulatorische Einordnung](../regulatory-applicability.md) | Dokumentierte Repository-Owner-Entscheidung zu CRA-N/A | NIS2/DORA bleiben Open; Datenschutz-Delivery bleibt gesondert anwendbar |
| [C5-Einordnung](../cloud-compliance-assurance.md) | N/A im lokalen Ausbildungsproduktscope | Kein Provider-Testat und keine pauschale Cloud-Assurance |
| [Intake-Sicherheit](../linked-intake-evidence.md) | Pfad-, UTF-8-, Hash-, Graph-, Proof- und Ausgabekontrollen | Gilt für den Renderer, nicht automatisch für Produktdateien oder Sandbox |
| [Governance v0.4.4](../../maintenance/autonomous-run-governance-v044.md) | Bindung an Git-Index, Dateitypen und Bytes | Kein SLSA-Provenance-Nachweis und keine Betriebssystem-Isolation |
| [CI](../../../.github/workflows/ci.yml) und [native Proof-Definition](../../../.github/workflows/linked-intake-evidence-native-proof.yml) | Reale Workflow-Konfiguration; gemischtes Action-Pinning | Definitionen sind keine aktuell ausgeführten Providerjobs |

### CRA: Was wurde tatsächlich geklärt?

Die Quelle vom 08.09.2026 dokumentiert CRA-N/A für das nichtkommerzielle
Ausbildungs- und Beispielprogramm. Deshalb wurden die Aussagen in CL-01-12,
CL-06-07 und CL-07-01 bis CL-07-12 berichtigt: Es fehlt nicht jede Entscheidung.
Die Anwendbarkeit anderer Regelwerke bleibt getrennt offen.

Der bestehende [GSDB-Validator](../../../scripts/validate-gsdb-intensive-review.ps1)
weist in `Assert-GsdbAssessmentFields` jeden Wert von `humanDecisionEvidence` außer
`NotProvided` zurück. Außerdem verbietet er `Fulfilled` bei `humanOnly=true`.
Seine Finding-Prüfung verlangt weiterhin mindestens eine reziproke Verknüpfung.
Der Vertrag kann daher einen nachvollziehbaren menschlichen Entscheidungsabschluss
noch nicht angemessen abbilden. Ihn einfach zu umgehen oder Flags zu entfernen
wäre kein belastbarer Abschluss.

Auch das [Schema](../../../specs/005-gsdb-intensive-review/contracts/evidence-matrix.schema.json)
bindet das Feld mit `const: NotProvided`. Das ist eine Grenze des bisherigen
Assessment-Vertrags, keine neu angeforderte menschliche Erlaubnis. Dieser
Neubewertungsauftrag liefert die fachliche Disposition; RV-01 beschreibt die
separate Implementierungsarbeit am Vertrag.

**Arbeitsauftrag GSDB-RV-01:** Entscheidungsreferenzen mit Quelle, Scope, Datum,
verantwortlicher Person, Review und Trigger im Vertrag unterstützen; fehlende,
erfundene und scopefremde Entscheidungen müssen weiterhin scheitern. Danach
alle zwölf CRA-Punkte einzeln bewerten: N/A kann Produktpflichten betreffen,
die Pflicht zur Dokumentation der Nichtanwendbarkeit selbst benötigt einen
Erfüllungsnachweis. CL-06-07 und der CRA-Anteil von CL-01-12 werden mitgeführt.
Abnahme: nachvollziehbare Zeilenentscheidungen, passende negative Vertragstests,
konsistente Summen und erhaltene Historie. Kein automatischer Pilot-/Releaseabschluss.

### Arbeitsaufträge und Abschlusskriterien je Finding

Die [aktualisierte Finding-Liste](open-findings.md) und die
[kanonische Matrix](evidence-matrix.json) enthalten Beobachtung und Folgearbeit
für jeden der 13 Befunde. Diese Tabelle ergänzt die konkrete Abnahme.

| Finding | Abschlusskriterium | Zuständigkeit und Reihenfolge |
|---|---|---|
| 001 | SLSA-/Scorecard-Nachweis oder genau begrenzter offener Rest; OWASP-Zuordnung, einzelne N/A-Begründungen und regulatorische Entscheidungen vollständig | Repository-Owner mit Security-Reviewer; CRA-Anteil nach RV-01 |
| 002 | Jede verknüpfte Architekturkontrolle besitzt Komponentenbezug, Wirksamkeitsbeleg und nachvollziehbare S-ADR-Disposition | Architektur-/Security-Rolle; nach Festlegung des Härtungsscopes |
| 003 | Datierter Suchumfang über Produkt und Build-Werkzeuge, Fundliste mit Krypto-Zweck und Algorithmus; jeder Ausschluss oder Ausnahme belegt | Technische Security-Rolle; unabhängig vorbereitbar |
| 004 | Neue Grenzen im Bedrohungsmodell erfasst; historische Pending-Aussagen gegen spätere Belege abgeglichen; Reviewer und Trigger dokumentiert | Architektur-/Security-Rolle; nach Scopeabgleich |
| 005 | Produkt-Restore mit Lockdateien, Update-/CVE-Prozess, Paketquellen-/Lizenzbeleg, kontrollierte Actions und reproduzierbarer Build; Provenance separat verifiziert | Build-/Delivery-Rolle; technisches Härtungspaket |
| 006 | Freigegebener CVD-Prozess und dokumentierte Probe vom Eingang bis Advisory/Patch; CRA-Meldepunkt separat disponiert | Repository-Owner; kein Versand realer Meldungen durch diesen Review |
| 007 | GSDB-RV-01 erfüllt und alle zwölf Punkte konsistent bewertet | Repository-Owner plus Vertragsimplementierung und unabhängiger Review |
| 008 | Reproduzierbare Negativtests für Datei-/Fehlergrenzen, wirksame Abhilfen für bestätigte Defekte und aktualisierter Code-Review | Produktentwicklung plus Security-Reviewer |
| 009 | Teilbelege pro Kontrolle zugeordnet; echte Werkzeug-, Lizenz-, Review-, Schulungs- und Risikoentscheidungen vorhanden, soweit anwendbar | Repository-Owner mit tatsächlichen menschlichen Reviewern |
| 010 | 14 Host-/Providerkontrollen mit datierten, bereinigten Nachweisen; zwei vergleichbare Builds für CL-10-09 | Host-/Repository-Verantwortlicher; keine Secrets in Belegen |
| 011 | Datenfluss-/Scopebewertung und begründete Einzelentscheidung zu beiden Konsultationen | Zuständige menschliche Datenschutz-/Repository-Rolle |
| 012 | Isolations-/Mount-/Netzwerk-/Secret-Negativtests an echter Zielsandbox plus Freigabe und Revalidierungsentscheidung | Sandbox-Verantwortlicher und menschlicher Reviewer |
| 013 | Jede der 16 Pflichten besitzt Prozess, zuständige Person, aktuelle Stichprobe und dokumentierten Abschluss | Repository-Owner; gemeinsame Belege wiederverwendbar |

Der bestehende Zieltermin 31.12.2026 bleibt eine Wiedervorlage, kein Nachweis
einer personell zugesagten Umsetzung. Die Rollen sind Arbeitszuordnungen;
dieser Review erfindet keine Bestellung externer Prüfer.

### Konkrete Prüfziele für Finding 008 und 012

In [Program.cs](../../../src/MicroCalc.Tui/Program.cs) weist `ExecuteSafe`
`ex.Message` direkt der sichtbaren Meldungszeile zu. Damit ist eine pauschale
Garantie bereinigter Fehlermeldungen durch diese Stelle nicht belegt.
Zu prüfen sind insbesondere Dateifehler mit privaten Pfaden. Es wurde hier
kein konkreter Datenabfluss reproduziert.

In [SpreadsheetJsonStorage.cs](../../../src/MicroCalc.Core/IO/SpreadsheetJsonStorage.cs)
liest `Load` mit `File.ReadAllText` die gesamte Datei; anschließend wird die
Engine vor Verarbeitung aller Zellen geleert. Prüffälle sind große Dateien,
`Cells=null`, null-Zelleinträge, ungültige Werte und Zustandskonsistenz nach
Ladefehlern. Dies sind aus dem Code abgeleitete Prüfhypothesen, keine neu
validierten Schwachstellen. Bestehende positive Tests ersetzen diese Nachweise nicht.

Die aktuelle Agentensitzung besitzt uneingeschränkten Dateisystemzugriff und
aktiviertes Netzwerk. Daraus folgt kein Urteil über alle Entwicklungsumgebungen;
es ist aber kein Nachweis einer abgeschotteten Zielsandbox.

### Prüfung, verbleibende Arbeit und Dokumentationsauswirkung

Der Review umfasst Dokumentenabgleich, Git-Diff, Quellstellenprüfung und lokale
Statusvalidierung. Er umfasst keinen neuen CVE-Onlinescan, Penetrationstest,
Provider-Audit, Rechtsentscheid oder Produkt-Build. Produkt-/API-Dateien und
generiertes HTML bleiben unverändert. Source-only-Dokumentation: semantische
Überschriften, DE/EN-Blöcke, textuelle Statuswerte und relative Links; kein
wesentlicher Inhalt hängt von Farbe oder Mausbedienung ab. DocFX ist nicht nötig.

Der Härtungsauftrag ist durch diese Neubewertung konkretisiert, nicht ausgeführt.
Die [Intake-Serie](../../../requirements/intakes/series/tinycalc-delivery/order.md)
führt Produkt-Härtung als Blocked und Sandbox-Härtung als Pending. Diese
Reihenfolge wurde nicht verändert. Für die zentrale Preset-Entscheidung nennt
der Assurance-Kontext weiterhin das Abwarten weiterer Feldtests und
`github/spec-kit#4455`; dieser gespeicherte nächste Schritt ist kein aktuell
geprüfter Remote-Status und blockiert die lokale Neubewertung nicht.

Lokale Prüfungen am 12.09.2026: GSDB `Validate` bestanden;
Documentation-Impact-Prüfung bestanden; Assurance baseline/delta/closure/
image-impact und Gesamtstatus jeweils `Ready`. `technicalValidation` ist
`Fulfilled`; `pilotAuthorization`, `projectAcceptance` und `generalRelease`
bleiben `Open`. Damit ist die technische Prüfung der Evidence abgeschlossen,
nicht die Härtung oder eine menschliche Freigabe.

## English review block

### Result and scope

All 13 findings were reassessed on 2026-09-12 against repository base `1428b42`.
Codex performed the technical review; Thorsten Hindermann is the repository
owner. This is not an independent human review or a new approval.
The formal totals remain 21 fulfilled, 62 partly fulfilled, 42 open human-only
controls and 32 N/A controls, plus 16 external duties. All 13 grouped findings
remain open, with inherited severities of seven High and six Medium.
These are governance ratings, not CVSS scores for confirmed exploits.

Finding 007 now means integration of an existing CRA scope decision, rather
than absence of every decision. Findings 001, 002, 004, 006, 009, 010, 012 and
013 have useful but bounded new evidence. Findings 003, 005, 008 and 011 have
no sufficient new closure evidence. No additional fulfilled controls are claimed.

### Standards and evidence

NIST SSDF and CWE Top 25 apply. STRIDE/CAPEC, OWASP Cheat Sheets/Proactive
Controls and SAMM guide review. SBOM applies to the distributable product;
SLSA and OpenSSF remain supply-chain goals. Historical scans are not current
CVE results. VEX is N/A for this review because no current CVE was disposed.
Product AI-SBOM is N/A because AI is development tooling only. ASVS is N/A
for this documentation/local TUI scope without HTTP/API/authentication surfaces.
Product Zero Trust is N/A for the local runtime; development-provider access
remains a separate question. CRA and C5 N/A are existing project decisions,
not legal conclusions newly reached here. Review by 2026-12-31 or on scope change.

The assurance field test proves contract behavior and four Ready gates.
Linked intake evidence proves bounded path, hash, graph and output controls.
Governance v0.4.4 binds staged paths, types and bytes to the Git index.
None proves all product controls, runtime isolation, signed provenance or human
approval. Workflow definitions do not prove current provider execution.

### CRA contract follow-up GSDB-RV-01

The 2026-09-08 regulatory document records the repository owner's CRA N/A
decision for the non-commercial training project. CL-01-12, CL-06-07 and all
twelve CL-07 rationales now acknowledge it. NIS2/DORA and other decisions stay
separate. The current validator rejects every human decision value other than
NotProvided, rejects Fulfilled on human-only rows, and requires reciprocal
finding links. Removing flags just to pass would not prove closure.

RV-01 must add decision provenance, scope, date, accountable person, review and
triggers to the contract, with negative tests for absent, fabricated and
out-of-scope decisions. Then assess each CRA control separately, including the
obligation to document non-applicability itself, and keep totals/history coherent.
No automatic pilot or release approval may follow.

### Acceptance criteria and owners

The bilingual finding list provides individual observations and actions.
001 needs standards evidence and separate regulatory dispositions; 002 needs
component-bound architecture effectiveness and S-ADR dispositions; 003 needs
a dated crypto inventory; 004 needs a reviewed threat-model update and checked
historical pending statements; 005 needs controlled product restore, updates,
dependency evidence, reproducibility and separately verified provenance.
006 needs an approved and exercised disclosure process; 007 needs RV-01;
008 needs negative file/error tests and fixes for confirmed defects; 009 needs
control-specific technical evidence plus real human decisions; 010 needs 14
sanitized host/provider records and reproducible CI evidence; 011 needs two
reasoned privacy-consultation decisions; 012 needs real sandbox isolation tests
and approvals; 013 needs a process, owner, current sample and closure criterion
for each of the 16 duties. Technical teams prepare evidence; accountable humans
make approvals. The 2026-12-31 target does not imply a staffing commitment.

### Concrete test targets and limits

ExecuteSafe displays ex.Message directly. Load reads a whole file and clears
the engine before all cells are processed. Test private-path errors, large or
malformed JSON, null cells, value boundaries and post-failure state consistency.
These are source-derived test hypotheses, not reproduced exploits. This agent
session has unrestricted filesystem access and enabled networking; it is not
evidence of an isolated target sandbox or of all other development environments.

This work reviews documents, Git changes, selected source locations and local
status validation. It does not run a new online CVE scan, penetration test,
provider audit, legal assessment or product build. Product/API/generated HTML
are unchanged. The source-only report uses semantic headings, bilingual text,
textual statuses and relative links. No DocFX regeneration is required.
Hardening is specified, not executed. The intake order remains unchanged.
The assurance context's recorded next action is to wait for other field tests
and github/spec-kit#4455 before a central preset decision; that is not a fresh
remote-status check and does not block this local reassessment.

Local checks on 2026-09-12 passed GSDB Validate and Documentation Impact.
Assurance baseline, delta, closure, image-impact and overall status are Ready.
Technical validation is Fulfilled; pilot authorization, project acceptance
and general release remain Open. This completes technical evidence validation,
not hardening or human approval.
