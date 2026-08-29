# Sicherheits-Checkliste / Security Checklist: TinyCalc Feature 002

**Projekt / Project**: TinyCalc (Level-2)

**Feature**: `002-constitution-change`

**Phase**: Lokale Implementierung und Validierung T001–T038 / Local implementation and validation T001–T038

**Datum / Date**: 2026-08-30

**Status**: Pass für den lokalen Feature-Scope / Pass for the local feature scope

**Evidence Owner**: Repository-Maintainer

**Reviewer**: Codex, gerouteter Implementierungsprüfer / routed implementation reviewer

**Template-Quelle / Template Source**: `.specify/templates/security-checklist-template.md`

## Umfang und Sicherheitsgrenze / Scope and Security Boundary

Feature 002 ändert Governance, Agenten-Guidance, Vorlagen und lokale Evidenz.
Es ändert keinen C#-Produktcode, keine Tests, keine Abhängigkeit, keine
Trust Boundary (Vertrauensgrenze), keine Authentifizierung, keine Datenbank,
keine Kryptografie, kein Datei-/Netzwerkverhalten und keine Deployment-Fläche.
NIST SSDF und CWE Top 25 bleiben trotzdem verbindliche Review-Linsen.

*Feature 002 changes governance, agent guidance, templates, and local evidence.
It changes no C# product code, tests, dependency, trust boundary,
authentication, database, cryptography, file/network behaviour, or deployment
surface. NIST SSDF and the CWE Top 25 remain mandatory review lenses.*

## Paketprüfung T022 / Package Review T022

| Prüfung / Check | Ergebnis / Result | Disposition |
|---|---|---|
| `dotnet list MicroCalc.sln package --outdated --include-transitive` | Exitcode 0; Updates sind verfügbar / updates are available | Erfasst, keine Änderung in Feature 002 / recorded, no change in Feature 002 |
| `dotnet list MicroCalc.sln package --vulnerable --include-transitive` | Exitcode 0; keine bekannten verwundbaren Pakete in allen vier Projekten / no known vulnerable packages in all four projects | Pass |
| Kritische-CVE-Schranke / Critical-CVE gate | Kein kritischer Fund / no critical finding | Pass; jeder künftige kritische Fund blockiert Delivery |
| Projekt-/Paketdateien / Project and package files | Unverändert / unchanged | Pass |

Verfügbare Updates: `Terminal.Gui` 1.19.0 → 2.4.17,
`coverlet.collector` 8.0.0 → 10.0.1, `Microsoft.NET.Test.Sdk` 18.3.0 →
18.9.0, `xunit.runner.visualstudio` 3.1.5 → 4.0.0 sowie neuere transitive
Test-, CodeDom-, Management-, Newtonsoft.Json- und Analyzer-Pakete. Diese
Versionssprünge benötigen einen getrennten Funktions-/Migrationsauftrag und
gehören nicht in die text-only Governance-Änderung.

*Available direct and transitive updates are recorded. Major-version changes,
especially Terminal.Gui and the test stack, require a separate migration and
regression scope.*

## NIST-SSDF-Zuordnung / NIST SSDF Mapping

| Gruppe / Group | Feature-002-Nachweis / Feature 002 evidence | Status |
|---|---|---|
| PO – Prepare the Organization | Verbindliche Constitution, Agentenparität, Owner/Reviewer und exakte Tasks / binding constitution, agent parity, owner/reviewer, exact tasks | Pass |
| PS – Protect the Software | `.codex/`, Runtime, Secrets, Logs und Credentials sind aus dem Delivery-Satz ausgeschlossen; Secret-Scan T031 ohne High-Fund / sensitive paths excluded; T031 secret scan has no high finding | Pass |
| PW – Produce Well-Secured Software | C#-MSL, Principle XII, CS1591, Build, TDD-Trigger und öffentliche API-Inventur / C# MSL, secure coding, XML gate, build, TDD trigger, API inventory | Pass |
| RV – Respond to Vulnerabilities | Read-only Vulnerability-Scan, kritische-CVE-Schranke und getrennte Remediation-Grenze / vulnerability scan, critical gate, separate remediation boundary | Pass |

## CWE Top 25 und OWASP-Hilfen / CWE Top 25 and OWASP Guidance

Die CWE-Top-25-Linse wurde für Eingabevalidierung, Pfad-/Dateizugriff,
Injection, Authentifizierung/Autorisierung, Fehleroffenlegung, Ressourcen- und
Speichersicherheit geprüft. Weil keine ausführbare Logik geändert wird, entsteht
kein neuer CWE-Pfad. Die OWASP Cheat Sheet Series und OWASP Proactive Controls
dienen ergänzend für Validierung, Fehlerbehandlung, sichere Konfiguration und
Abhängigkeiten; die strengeren C#/.NET- und Repository-Regeln gehen vor.

*The CWE Top 25 review covered input validation, path/file access, injection,
authentication/authorization, error disclosure, resource handling, and memory
safety. No executable logic changes, so no new CWE path is introduced. OWASP
Cheat Sheets and Proactive Controls support the review; stricter repository and
.NET rules prevail.*

## Sprach- und Codeprüfung / Language and Code Review

| Bereich / Area | Status | Begründung und Wiedervorlage / Rationale and re-evaluation |
|---|---|---|
| C# als Memory-Safe Language | `Applicable`, Pass | C# ist auf der MSL-Liste; MSL ersetzt sichere APIs nicht / C# is allowed; MSL does not replace secure APIs |
| Parametrisierte Queries / SQL | `N/A` | Keine Datenbank- oder Query-Änderung; Wiedervorlage bei Persistence-/SQL-Scope / no database change |
| XSS, Output-Encoding, CSRF, CORS, Session | `N/A` | Keine Web-/HTTP-/Auth-Fläche; Wiedervorlage bei Web/API / no web or auth surface |
| Deserialisierung | `N/A` für Änderung / for change | JSON-Code unverändert; Wiedervorlage bei IO-/Model-Änderung / JSON code unchanged |
| Kryptografie und Secrets | `N/A` für Code / for code | Keine Krypto-/Secret-Verarbeitung geändert; Secret-Scan bleibt anwendbar / no crypto change; secret scan still applies |
| Datei- und Netzwerk-I/O | `N/A` für Änderung / for change | Keine IO- oder Netzwerklogik geändert; Wiedervorlage bei Pfad-/Transportänderung / no I/O change |
| Fehlerbehandlung und Logging | `N/A` für Änderung / for change | Keine Fehler- oder Logging-Fläche geändert; keine neue interne Offenlegung / no error/logging change |
| Öffentliche XML-Dokumentation | `Applicable`, Pass | 76/76 öffentliche Quelltext-API-Zeilen mit Pass oder elementbezogenem `N/A`; Build 0 Warnungen/0 Fehler / complete inventory and build |
| TDD und Changed-Code-Coverage | `N/A` | Reine Textarbeit; Wiedervorlage bei jeder Verhaltensänderung mit 70-%-Minimum/80-%-Ziel / text-only; recheck on behaviour change |

## Architektur- und Standardanwendbarkeit / Architecture and Standards Applicability

| Standard oder Evidenz / Standard or evidence | Status | Begründung und Wiedervorlage / Rationale and re-evaluation |
|---|---|---|
| OWASP ASVS | `N/A` | Kein Web/API/HTTP/Auth; Wiedervorlage bei entsprechendem Dienst / no web/API/auth |
| SBOM, VEX, SLSA | `N/A` | Keine Abhängigkeit, Pipeline oder ausgelieferte Komponente ändert sich; Wiedervorlage bei Paket-, CVE-, Release- oder CI-Trigger / no dependency, pipeline, or shipped-component change |
| AI-SBOM | `N/A` | KI ist nur Entwicklungswerkzeug; Wiedervorlage bei Produktmodell, Datensatz oder Inferenzdienst / development tooling only |
| STRIDE, CIA, CAPEC | `N/A` | Keine Trust Boundary oder Datenflussänderung; Wiedervorlage bei externem Input, Privileg, IO oder Integration / no boundary or flow change |
| S-ADR, arc42 Security | `N/A` | Keine Architekturentscheidung; Wiedervorlage bei Struktur-/Deployment-Änderung / no architecture decision |
| Security-Qualitätsszenarien | `N/A` | Kein neues Sicherheitsverhalten; Wiedervorlage bei Qualitätszieländerung / no new security behaviour |
| Zero Trust | `N/A` | Kein verteilter oder remote verwalteter Dienst / no distributed or remote service |
| OWASP SAMM | `N/A` | Kein Security-Prozess-/Reifegradwechsel; Wiedervorlage bei Prozessänderung / no process change |
| BSI C3A/C5 | `N/A` | Kein Cloud-Service oder Provider-Scope / no cloud/provider scope |
| NIS2, CRA, EU AI Act, DORA | `N/A` | Private Governance-Arbeit ohne Markt-, Produkt-KI-, Finanz-ICT- oder regulierten Dienst / private governance-only work |
| OpenSSF Scorecard | `N/A` | Keine neue Abhängigkeit oder Release-/Adoptionsbewertung / no adoption or release trigger |

Die folgenden Bestandsdokumente bleiben deshalb byte-unverändert:
`threat-model.md`, `dependency-audit.md`, `arc42-security.md`,
`security-quality-scenarios.md`, `adr/`, `asvs-verification.md`,
`supply-chain-evidence.md`, `zero-trust-applicability.md` und
`samm-assessment.md`.

*The listed security documents remain byte-unchanged because none of their
documented triggers occurred.*

## Restrisiken und nächste Grenze / Residual Risks and Next Boundary

- Veraltete Pakete sind bekannt, aber laut aktuellem Scan nicht verwundbar.
  Owner: Repository-Maintainer. Folgeschritt: getrennt autorisierte
  Abhängigkeits-/Terminal.Gui-Migration. Trigger: Sicherheitsfund, geplantes
  Upgrade oder Release-Auftrag.
- Spätere Remote-Gates bleiben ausstehend und werden nicht vorweggenommen. Der
  lokale Secret-Scan T031 ist Pass.
- Jede unerwartete Änderung an `src/`, `tests/`, Paket-, Workflow-, Skript- oder
  Architekturpfaden setzt die Anwendbarkeit erneut auf Prüfung.

*Outdated packages remain a tracked residual risk without a known
vulnerability. A separately authorized dependency migration owns that work.
The local secret scan passes; later remote gates remain pending and are not
claimed in advance.*
