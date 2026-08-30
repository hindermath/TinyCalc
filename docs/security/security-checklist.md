# Sicherheits-Checkliste: TinyCalc Feature 003

## Deutscher Prüfblock

### Laufnachweis

| Feld | Wert |
|---|---|
| Projekt und Sprache | TinyCalc, Level 2, C# / .NET 10 |
| Feature | 003, Terminal.Gui-v2-Migration |
| Phase | Implementierung |
| Branch | `003-terminalgui-migration` |
| Baseline | `886a13f8866e79fe6c13e6e1227217294aabdee8` plus geprüfter Arbeitsbaum; Exact Head folgt |
| Datum | 2026-08-30 |
| Owner | autorisierter autonomer Feature-003-Lauf |
| Reviewer | technische Exact-Head- und PR-Prüfung vor Merge |
| Entscheidung | lokal bestanden; Plattform-, SBOM- und Exact-Head-Gates bleiben offen |

Anwendbar sind ISO 27001/27002 A.8.28, NIST SSDF, CWE Top 25, Microsoft
Secure Coding für C#/.NET, OWASP Proactive Controls sowie die Architektur- und
Supply-Chain-Regeln der Constitution. C# ist eine speichersichere Sprache;
dies ersetzt keine Prüfung von APIs, Eingaben, Fehlern, Ressourcen und
Abhängigkeiten.

Diese Checkliste ist interne Audit- und Zertifizierungsvorbereitung. Sie
ersetzt keine externe Auditierung, Rechtsberatung oder formale Zertifizierung.

### Scope und Sicherheitsgrenzen

Feature 003 ändert nur `MicroCalc.Tui`: Terminal.Gui wird exakt auf 2.4.17
gesetzt, und `Program` nutzt den expliziten v2-Lifecycle sowie die v2-
Tastencodes. `MicroCalc.Core`, Testquellen, Formelverhalten, Dateiformat und
`CALC.HLP` bleiben unverändert. Es entstehen keine neue Datei-, Netzwerk-,
SQL-, Shell-, Deserialisierungs-, Authentifizierungs- oder Kryptografiefläche.

Explizite Vertrauensgrenzen sind Tastatur, bestehendes Core-/Datei-I/O,
NuGet-Lieferkette sowie Git/CI/Exact Head. Der vollständige STRIDE-/CAPEC-
Nachweis steht in `docs/security/threat-model.md`.

### Pflichtstandards und Review-Linsen

| Standard oder Profil | Status | Owner | Reviewer | Evidenz | Restrisiko oder Trigger |
|---|---|---|---|---|---|
| NIST SSDF | Pass im lokalen Scope | Feature 003 | PR-Reviewer | Plan, Tasks, Red/Green, Regression, Dependency Audit | Provider- und Exact-Head-Belege offen |
| CWE Top 25 | Pass im lokalen Scope | Feature 003 | Security-Reviewer | geschlossene Eingaben, sichere Fehler, kein Injection-/Pfad-/Deserialisierungs-Neuscope | neue Input- oder I/O-Fläche öffnet Prüfung |
| Microsoft Secure Coding C#/.NET | Pass | Feature 003 | C#-Reviewer | eine App, strukturierte Freigabe, Nullable/Build 0 Warnungen | neue API oder Fehlerfläche öffnet Prüfung |
| STRIDE/CAPEC | Pass, Exact Head offen | Feature 003 | Security-Reviewer | Threat Model mit CAPEC-153/-538 | neue Trust Boundary blockiert zur Neuplanung |
| WCAG 2.2 AA | Pass lokal | Feature 003 | A11Y-Reviewer | 13 Tasten, Fokus, zwei Quit-Pfade, textuelle Statusanzeige | neue UI-Information oder Fokusänderung |
| SBOM/SLSA/OpenSSF | Pending bis Lieferung | Delivery | PR-Reviewer | Dependency Audit und Supply-Chain-Plan | T052/T067 müssen Exact Head binden |

Keiner der verpflichtenden Standards wird als `N/A` behandelt.

### Eingabeverarbeitung

| Prüfschritt | Status | Nachweis | Restrisiko |
|---|---|---|---|
| Tastencodes an TB-1 auf bekannte Aktionen begrenzt | Pass | 13er-Quellvertrag, reale PTY-Sitzungen | Terminaltreiber kann plattformspezifisch abweichen |
| Keine dynamische Codeausführung aus Eingaben | Pass | keine Nutzung von `eval`, Shell, Reflection-Dispatch oder `Invoke-Expression` im Produktpfad | neue Command-/Script-Funktion würde neu prüfen |
| Unbekannte Taste erzeugt keine privilegierte Aktion | Pass | geschlossene Handler und sichere Standardbehandlung | neue Taste braucht Vertrags- und A11Y-Update |
| Kein neuer Freitext an SQL, Shell, URL oder HTML | N/A, begründet | Feature besitzt keine solche Senke | Trigger ist eine neue Senke |
| Bestehendes Core-/Datei-I/O unverändert | Pass | `git diff --exit-code -- tests src/MicroCalc.Core CALC.HLP` Exit 0 | Exact-Head-Wiederholung offen |

### Lifecycle, Ressourcen und Fehler

| Prüfschritt | Status | Nachweis | Restrisiko |
|---|---|---|---|
| genau eine `IApplication` | Pass | Architektur, S-ADR und Quellvertrag | zweite App würde S-ADR neu öffnen |
| Root und Dialoge creator-owned | Pass | lokale `using`-Scopes und dokumentierter Lauf | neuer Dialog muss Muster einhalten |
| Freigabe auf Fehlerpfaden | Pass | strukturierte Freigabe von Dialog, Root und App | Provider-Terminalzustand noch offen |
| Menü-Quit und `Ctrl+Q` stoppen dieselbe Sitzung sicher | Pass | zwei getrennte reale PTY-Sitzungen, Exit 0 | Linux/Windows T066 |
| Smoke initialisiert kein Terminal | Pass | Exit 0, exakt `SMOKE_OK` | Startup-Änderung löst neuen Smoke aus |
| Endnutzerfehler enthalten keinen Stacktrace oder Secret | Pass | Disclosure-Regel und Evidenz-Secret-Scan; authentifizierte Quelle nicht getrackt | neue Diagnoseausgabe neu prüfen |
| Interner Fehler fällt in sicheren Zustand | Pass | Dispose und von null verschiedener Fehler-Exit; keine technische Gate-Umgehung | alternative Providerfehler in CI prüfen |

### C#/.NET-Sprachprofil

| Regel | Status | Begründung oder Evidenz |
|---|---|---|
| Nullable- und Compilerregeln aktiv | Pass | Release-Build: 0 Warnungen, 0 Fehler |
| öffentliche API vollständig dokumentiert | Pass für Änderung | Feature fügt keine öffentliche API hinzu oder ändert sie |
| SQL nur parametrisiert | N/A | kein SQL oder Datenbankzugriff im Feature |
| XSS-Encoding, Anti-Forgery, CORS, HTTPS | N/A | keine Web-, HTTP- oder API-Fläche |
| sichere Deserialisierung | N/A für Änderung | bestehendes JSON-/Datei-I/O unverändert; keine neue Deserialisierung |
| sichere Kryptografie und Key Management | N/A | keine Krypto-, Secret- oder geschützte Persistenzänderung |
| Dependency Injection für Security-Services | N/A | keine Security-Services; eine lokale Composition Root bleibt erhalten |
| sichere Endnutzerfehler | Pass | keine Stacktraces, Quellzugangsdaten oder internen Verbindungen |
| Ressourcenfreigabe | Pass | `IDisposable`/`using` für App, Root und Dialoge |

### Abhängigkeiten und Supply Chain

| Kontrolle | Status | Evidenz | Blockregel |
|---|---|---|---|
| verifizierte Registry | Pass | 24/24 ausgelieferte Pakete aus NuGet.org | andere Quelle oder Drift blockiert |
| direkter/transitiver Graph | Pass | 1 direkt, 23 transitiv in `packages-all.json` | unvollständiger Graph blockiert |
| bekannte Schwachstellen | Pass: 0 | `packages-vulnerable.json` | jeder bekannte ausgelieferte Fund blockiert bis autorisiertem Fix |
| Lizenzen | Pass | 23 MIT, 1 BSD-2-Clause; 0 unbekannt/unvereinbar | offener oder unvereinbarer Fall blockiert |
| VEX | N/A aktuell | kein Fund und kein Fehlalarm | nur Fehlalarm/nicht ausgelieferte Komponente; nie Fundakzeptanz |
| Lockfile | offen außerhalb Scope | kein `packages.lock.json` | separates Intake oder Autorität erforderlich |
| Update-Automation | offen außerhalb Scope | kein Dependabot/Renovate/Dependency-Track | keine stille Scope-Erweiterung |
| SBOM/Provenance | Pending | T052/T067 | muss unveränderten PR-Head binden |

### NIST-SSDF-Zuordnung

| Gruppe | Umsetzung in Feature 003 | Status |
|---|---|---|
| PO – Prepare the Organization | bindendes Intake, Owner/Reviewer, Security-Standards, enge Delivery-Autorität | Pass |
| PS – Protect the Software | NuGet.org, keine Secrets in Evidenz, Exact-Head-Plan, enger Admin-Bypass | lokal Pass; Remote offen |
| PW – Produce Well-Secured Software | C#-Profil, Red/Green, eine App, sichere Freigabe, Build/Test/Smoke/Coverage | Pass lokal |
| RV – Respond to Vulnerabilities | maschinenlesbarer Scan, fail-closed Blocker, VEX-Grenze, Recheck-Trigger | Pass lokal |

### CWE-Top-25-Fokus

- CWE-20 Improper Input Validation: geschlossene Tastenzuordnung und
  CAPEC-153-Nachweis.
- CWE-400 Uncontrolled Resource Consumption: eine App, creator-owned Dialoge,
  sichere Stop-Pfade und Terminalrestauration.
- CWE-200 Exposure of Sensitive Information: keine Stacktraces oder
  authentifizierten Paketquellen in Endnutzerausgabe/getrackter Evidenz.
- CWE-494 Download of Code Without Integrity Check und CWE-829 Inclusion of
  Functionality from Untrusted Control Sphere: NuGet.org-Bindung, exakte
  Version, Graph-, Advisory-, Lizenz-, SBOM- und Provenance-Gates.
- Injection-, Auth-, SQL-, Pfadtraversal- und unsichere
  Deserialisierungswege entstehen nicht neu; jeder entsprechende Scope-Trigger
  setzt diese Aussage auf offen.

### Audit-Matrix und Freigabe

| Kategorie | Pass | Offen | N/A, begründet |
|---|---:|---:|---:|
| Pflichtstandards | 5 | 1 | 0 |
| Eingaben und Scope | 4 | 0 | 1 |
| Lifecycle und Fehler | 7 | 0 | 0 |
| C#/.NET-Profil | 4 | 0 | 5 |
| Supply Chain | 4 | 2 | 2 |

Lokale Freigabe: **Pass für den aktuellen Arbeitsbaum.** Keine vollständige
Delivery-Freigabe: Linux, Windows, SBOM/Provenance, Provider-Review und Exact
Head bleiben verbindlich offen. Owner ist Feature 003; Reviewer ist der spätere
Security-/PR-Reviewer. Neue Trust Boundary, Abhängigkeit, Datei-/Netzwerk-
Fläche, Deserialisierung, Authentifizierung oder privilegierte Operation
blockiert zur Neuplanung.

## English review block

### Scope and mandatory criteria

This checklist covers TinyCalc Feature 003 on branch
`003-terminalgui-migration`. It applies ISO A.8.28, NIST SSDF, the CWE Top 25,
Microsoft secure coding guidance for C#/.NET, STRIDE/CAPEC, WCAG 2.2 AA, and
supply-chain controls. C# is memory-safe, but that does not replace secure API,
input, error, resource, or dependency review.

The feature changes only the TUI package and Terminal.Gui v2 integration. Core,
tests, formulas, file format, and `CALC.HLP` remain unchanged. No new file,
network, SQL, shell, deserialisation, authentication, or cryptography surface
is introduced.

### Review result

Keyboard input maps to the closed existing action set and cannot execute
dynamic code. One creator-owned application, root, and dialog scopes provide
safe normal and error cleanup. Both quit paths and smoke pass. User-facing
errors expose no stack trace, secret, or authenticated package-source detail.

The shipped dependency graph contains one direct and 23 transitive NuGet.org
packages. It has zero known vulnerabilities and zero unknown or incompatible
licenses. A known shipped vulnerability or unresolved license blocks delivery.
VEX cannot authorize such a finding. Lockfile and update automation remain
separate, explicitly open governance scope.

The local checklist passes. It is not full delivery approval: Linux, Windows,
SBOM/provenance, provider review, and exact-head evidence remain mandatory.
The owner is Feature 003 and the reviewer is the final security/pull-request
reviewer. Any new trust boundary, dependency, file or network path,
deserialisation, authentication, or privileged operation requires replanning.

## Evidenz / Evidence

- `docs/architecture/terminalgui-migration.md`
- `docs/security/arc42-security.md`
- `docs/security/threat-model.md`
- `docs/security/dependency-audit.md`
- `docs/security/adr/003-terminalgui-lifecycle-supply-chain.md`
- `specs/003-terminalgui-migration/evidence/regression.md`
- `specs/003-terminalgui-migration/evidence/coverage-summary.md`
