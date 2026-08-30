# Sicherheitsplan / Security Plan

## Klassifikation / Classification

TinyCalc ist eine lokale, einprozessige TUI. Feature 003 ändert die
Tastatur-/Terminalgrenze und eine externe NuGet-Abhängigkeit, aber keine
Authentifizierung, Autorisierung, Kryptografie, Netzwerkkommunikation, Secrets
oder persistierte Daten. KI wird nur als Entwicklungswerkzeug verwendet.

*TinyCalc is a local, single-process TUI. Feature 003 changes the
keyboard/terminal boundary and one external NuGet dependency, but no
authentication, authorisation, cryptography, networking, secrets, or persisted
data. AI is development tooling only.*

## Standards und Evidenz / Standards and Evidence

| Standard/Artefakt | Status | Geplanter Nachweis / Planned evidence | Trigger bei N/A / Trigger when N/A |
|---|---|---|---|
| NIST SSDF SP 800-218 | Applicable | `docs/security/security-checklist.md`, exact-head delivery | — |
| CWE Top 25, Microsoft C# Secure Coding | Applicable | Input-, Fehler-, Ressourcen- und Dependency-Review | — |
| STRIDE/CIA und CAPEC | Applicable | `docs/security/threat-model.md` | — |
| OWASP Cheat Sheets/Proactive Controls | Applicable | ergänzende Review-Referenz | — |
| Security Quality Scenarios | Applicable | `docs/security/security-quality-scenarios.md` | — |
| SBOM | Applicable | `docs/security/sbom/tinycalc-terminalgui.spdx.json` | — |
| SLSA v1.2 | Applicable | tatsächlicher Provenienzstatus in `docs/security/supply-chain-evidence.md` | — |
| OpenSSF Scorecard | Applicable | Upstream- und TinyCalc-Repository-Review | — |
| OWASP SAMM | Applicable | `docs/security/samm-assessment.md`, reviewed/unchanged oder Befund | — |
| OWASP ASVS | N/A | kein Web/API/HTTP/Auth | erster Web-, API-, HTTP- oder Auth-Scope |
| VEX | N/A, bedingt | Disposition in `docs/security/supply-chain-evidence.md`; nur Fehlalarme oder nicht ausgelieferte Komponenten | jeder zu bewertende Fund; ein bekannter ausgelieferter Fund blockiert |
| AI-SBOM | N/A | KI nur Toolchain, keine Produktkomponente | KI-Modell, Daten, Inferenz oder Runtime im Produkt |
| Zero Trust | N/A | lokaler Einzelprozess | verteilte, Remote-, Cloud- oder Servicearchitektur |
| BSI C3A/C5 | N/A | kein Cloud-/Provider-Scope | Cloud, Hosting oder Managed Service |
| NIS2/CRA/EU AI Act/DORA | N/A | kein neuer regulierter Markt-/Betreiber-/KI-/Finanzscope | geänderter Liefer- oder Betriebskontext |
| Fokussierter S-ADR | Applicable | `docs/security/adr/003-terminalgui-lifecycle-supply-chain.md`: Lifecycle-Ownership und fail-closed Lieferkettenentscheidung | Änderung an Ownership, Paketgraph oder Lieferentscheidung |
| Allgemeiner ADR | N/A | keine neue nicht sicherheitsbezogene Komponente oder Schicht; Disposition in `docs/security/arc42-security.md` | alternative Komponente oder neue Schicht |
| arc42 Section 8 | Applicable | `docs/security/arc42-security.md`: Lifecycle, Trust Boundaries, Eingaben, Abhängigkeiten, Fehler, Logging und Deployment vollständig aktualisieren | jede Änderung eines Querschnittskonzepts |
| Dependency-Lizenzen | Applicable | direkte/transitive Lizenzen, Quelle, Kompatibilität und Disposition in `dependency-audit.md` und `supply-chain-evidence.md` | jede Paketgraphänderung |
| Security-Index | Applicable | `docs/security/README.md` von `Stub` auf abgeschlossen setzen und S-ADR sowie N/A-Evidenzorte indexieren | jedes neue oder geänderte Security-Artefakt |

## STRIDE- und CIA-Bedrohungsmodell / STRIDE and CIA Threat Model

| Grenze/Asset | Kategorie | Angriffsweg und CAPEC | Behandlung / Treatment | Restrisiko |
|---|---|---|---|---|
| Tastatureingabe | Tampering, DoS; Integrität/Verfügbarkeit | manipulierte oder wiederholte Events, CAPEC-153 Input Data Manipulation | geschlossene Key-Matrix, genau eine Aktion, Unknown-Key ohne neue Wirkung, manueller 13-Key-Test | Terminaltreiber kann plattformspezifisch abweichen |
| App-/Dialog-Lifecycle | DoS; Verfügbarkeit | falsche Stop-Ebene, Event-Reentrancy | eine App-Instanz, eindeutiger Owner, verschachtelter Rückkehrvertrag, beide Quit-Pfade | Framework-interne Fehler bleiben möglich |
| NuGet-Lieferkette | Spoofing/Tampering; Integrität | Dependency Confusion/Supply Chain, CAPEC-538 Modification During Distribution | exakte Paket-ID/-Version, verifizierte Registry, Audit, SBOM, Upstream-Review | transitive oder zukünftige Schwachstelle |
| Fehlerausgabe | Information Disclosure; Vertraulichkeit | interner Stacktrace an Nutzer | bestehende sichere Fehlergrenze beibehalten; keine Secrets/Connection Strings | lokale Diagnose kann begrenzte technische Daten benötigen |
| Core/Dateien | Tampering; Integrität | Scope-Drift verändert fachliche Daten | Delivery-Set verbietet Core-, Test- und Dateiformatdiff | Reviewfehler, durch Exact-Path-Gate reduziert |

Repudiation und Elevation of Privilege erhalten keinen neuen Angriffsweg: Es
gibt keine Identität, Audit-Trail-Anforderung oder erhöhte Berechtigung. Dies ist
eine bewertete Nichtanwendbarkeit, keine stillschweigende Auslassung.

*Repudiation and elevation of privilege gain no new attack path: there is no
identity, audit-trail requirement, or elevated permission. This is assessed
non-applicability, not silent omission.*

## Sichere Umsetzung / Secure Implementation

- Eingaben nur über Terminal.Gui-Typen und eine geschlossene Aktionszuordnung;
  keine dynamische Codeausführung. / Inputs only through Terminal.Gui types and
  a closed action mapping; no dynamic execution.
- Dispose-Pfade müssen auch bei Ausnahmen greifen; Nutzerfehler enthalten keine
  internen Pfade, Secrets oder Stacktraces. / Disposal must survive exceptions;
  user errors expose no internal paths, secrets, or stack traces.
- Keine neue Deserialisierung, Query, Datei- oder Netzwerkoperation. / No new
  deserialisation, query, file, or network operation.
- Jede bekannte Schwachstelle in einer ausgelieferten direkten oder transitiven
  Abhängigkeit blockiert, bis eine ausdrücklich autorisierte Aktualisierung
  oder Ersetzung abgeschlossen ist. VEX darf nur Fehlalarme oder bewertete
  nicht ausgelieferte Komponenten klassifizieren und niemals einen bekannten
  ausgelieferten Fund freigeben. Paketänderungen bleiben auf Intake und exakte
  Version begrenzt; ein Blocker benötigt neue Autorität. / *Every known
  vulnerability in a shipped direct or transitive dependency blocks until an
  explicitly authorised update or replacement is complete. VEX may classify
  only false positives or evaluated non-shipped components and can never
  release a known shipped finding. Package changes remain bounded to the intake
  and exact version; a blocker needs new authority.*
- Für jede ausgelieferte direkte oder transitive Abhängigkeit werden Lizenz,
  Quelle, Kompatibilität und Disposition belegt. Unbekannte oder inkompatible
  Lizenzen blockieren. / *Every shipped direct or transitive dependency has
  licence, source, compatibility, and disposition evidence. Unknown or
  incompatible licences block.*

## Abnahmekriterien / Acceptance Criteria

Security ist erst erfüllt, wenn Threat Model, Checklist, Dependency Audit,
Quality Scenarios, SAMM-Review, vollständiges arc42 Section 8, fokussierter
S-ADR, abgeschlossener `docs/security/README.md` und Supply-Chain-Evidence den
exakten Delivery-Commit nennen, keine bekannte Schwachstelle in einer
ausgelieferten Abhängigkeit besteht und keine unbekannte oder inkompatible
ausgelieferte Lizenz verbleibt.

*Security passes only when the threat model, checklist, dependency audit,
quality scenarios, SAMM review, complete arc42 Section 8, focused security ADR,
completed security README, and supply-chain evidence name the exact delivery
commit, with no known vulnerability in a shipped dependency and no unknown or
incompatible shipped licence.*
