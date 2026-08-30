# Sicherheits-Querschnittskonzepte: TinyCalc

## Deutscher Prüfblock

### Laufnachweis

| Feld | Wert |
|---|---|
| Projekt | TinyCalc, Level 2 |
| Feature | 003, Terminal.Gui-v2-Migration |
| Phase | Implementierung |
| Branch | `003-terminalgui-migration` |
| Baseline | `886a13f8866e79fe6c13e6e1227217294aabdee8` plus geprüfter Arbeitsbaum; Exact Head folgt |
| Datum | 2026-08-30 |
| Evidenzverantwortung | Codex im autorisierten autonomen Spec-Kit-Lauf |
| Review | Exact-Head- und PR-Review vor Merge |
| Entscheidung | arc42 Abschnitt 8 ist anwendbar und für Feature 003 ausgefüllt |

Geprüfte Grundlagen sind ISO 27001/27002 A.8.27 und A.8.28, Constitution
Principles XII–XVIII, NIST SSDF, CWE Top 25, Microsoft Secure Coding für
C#/.NET, STRIDE, CAPEC, SBOM/SLSA und WCAG 2.2 AA. Die Evidenz liegt in
`docs/architecture/terminalgui-migration.md`, den Dateien unter
`specs/003-terminalgui-migration/evidence/` und dem S-ADR
`docs/security/adr/003-terminalgui-lifecycle-supply-chain.md`.

Diese interne Evidenz unterstützt Audit- und Zertifizierungsvorbereitung. Sie
ersetzt keine externe Auditierung, Rechtsberatung oder formale Zertifizierung.

### 1. Lifecycle und Ressourcenbesitz

```text
Program
  |
  +-- besitzt genau eine IApplication
  |       |
  |     Init
  |       |
  |     Run(Root) -----------+
  |       |                  |
  |       +-- Run(Dialog) -- Dispose Dialog
  |       |
  |     RequestStop
  |       |
  |     Run kehrt zurück
  |       |
  +-- Dispose Root
  +-- Dispose IApplication
```

Textalternative: `Program` erzeugt und besitzt eine App-Instanz. Nach der
Initialisierung führt sie genau ein Root aus. Dialoge sind creator-owned:
Der Aufrufer erzeugt, startet und entsorgt sie. Beide Quit-Pfade beenden die
aktive App. Strukturierte `using`-Bereiche geben Dialog, Root und App auch bei
einer Ausnahme frei.

Der `--smoke`-Pfad führt keine Terminalinitialisierung aus. Damit besitzt er
keine Terminalressource und kann deterministisch mit `SMOKE_OK` und Exitcode 0
enden. Es gibt kein globales App-Singleton und keinen versteckten zweiten
Eventloop.

### 2. Trust Boundaries und Eingabevalidierung

| Grenze | Eingang | Validierung und Begrenzung | Sicherer Fehlerzustand |
|---|---|---|---|
| TB-1 Tastatur | Terminal.Gui-`Key` und Event-Reihenfolge | geschlossene Abbildung der 13 bestehenden Navigations- und Quit-Eingaben; keine dynamische Codeausführung | unbekannte Eingabe ohne privilegierte Aktion; Fokus und Root bleiben kontrolliert |
| TB-2 lokale Dateien | vorhandenes Arbeitsblatt und `CALC.HLP` | bestehende Core-Parser, Pfade und Tests; in Feature 003 unverändert | vorhandener Fehlerpfad; keine neue interne Detailausgabe |
| TB-3 Paketquelle | NuGet-Pakete und Metadaten | exakte Version, NuGet.org-Quelle, vollständiger transitiver Graph, Vulnerability- und Lizenzprüfung | Restore-/Delivery-Block bei Drift, Fund oder offener Lizenz |
| TB-4 CI und Git | Commit, PR-Head und Provider-Artefakte | Exact-Head-Hash, Plattformjobs, Gate-Schema und Review | kein Merge bei Drift oder fehlendem Primärnachweis |

Tastatureingaben sind Steuerdaten, kein Text für SQL, Shell, Deserialisierung
oder Netzwerk. Menü- und Dialogaktionen rufen nur fest verdrahtete Handler auf.
Das Feature fügt keine neue Datei-, Netzwerk-, Prozess- oder
Deserialisierungsfläche hinzu.

### 3. Authentifizierung und Autorisierung

Authentifizierung ist `N/A`: TinyCalc ist eine lokale Einzelbenutzer-TUI ohne
Konto, Identitätsanbieter, API, Remotezugriff oder Dienst-zu-Dienst-Verbindung.
Autorisierung ist ebenfalls `N/A`: Es gibt keine Rollen, Mandanten oder
geschützten Remote-Ressourcen. Die Anwendung läuft mit den bestehenden Rechten
des angemeldeten Betriebssystemkontos und fordert keine Rechteerhöhung an.

Trigger für eine Neubewertung sind Benutzerkonten, geteilte Dateien mit
Anwendungsrichtlinien, Netzwerkzugriff, Remote-Steuerung, Dienstmodus oder ein
privilegierter Installationspfad. Bis dahin gilt Least Privilege durch den
unveränderten lokalen Benutzerprozess.

### 4. Verschlüsselung und Geheimnisse

Anwendungsseitige Verschlüsselung ist `N/A`, weil Feature 003 weder Netzwerk
noch neue vertrauliche Persistenz einführt. Die bestehenden lokalen
Arbeitsblattdaten ändern ihren Schutzbedarf nicht. Es werden keine Schlüssel,
Tokens oder Passwörter im Produktcode oder in getrackter Konfiguration
gespeichert.

SHA-256 dient ausschließlich als Integritätsnachweis für Evidenz und Artefakte,
nicht als Passwort- oder Signaturverfahren. Pakettransport zu NuGet.org nutzt
die TLS-Prüfung des .NET-/NuGet-Clients. Eine neue Remoteverbindung, geheime
Konfiguration oder schützenswerte neue Datenspeicherung löst eine eigene
Kryptografie- und Key-Management-Entscheidung aus.

### 5. Fehlerbehandlung und Informationspreisgabe

- Endnutzerfehler bleiben kurz, handlungsbezogen und ohne Stacktrace,
  Paketquellen-Zugangsdaten oder interne Verbindungsdaten.
- Strukturierte Freigabe beendet Terminalzustände auch nach Fehlern.
- Ein Fehler beim Aufbau oder Lauf eines Dialogs darf keinen zweiten Eventloop
  und keine verwaiste App-Instanz hinterlassen.
- Der Smoke-Pfad gibt nur das öffentliche Erfolgstoken `SMOKE_OK` aus; ein
  Fehler führt zu einem von null verschiedenen Exitcode.
- Build- und CI-Diagnosen dürfen technische Details in Provider-Artefakten
  enthalten, aber keine Geheimnisse. Authentifizierte lokale Paketquellen
  werden aus getrackter Evidenz ausgeschlossen.
- Der Admin-Bypass darf ausschließlich eine formale Merge-Policy umgehen und
  niemals einen Fach-, Security-, A11Y-, Plattform-, Review- oder
  Exact-Head-Fehler verdecken.

### 6. Logging und Audit Trail

TinyCalc führt kein Produkt-Telemetrie- oder Audit-Log ein. Für eine lokale
Einzelbenutzer-TUI ohne Authentifizierung wäre ein dauerhaftes Nutzerprotokoll
unverhältnismäßig und würde eine neue Datenschutz- und Dateifläche schaffen.

Der Lieferprozess erzeugt stattdessen unveränderlich bindbare technische
Evidenz: Befehle, Exitcodes, Commit-SHAs, Plattform, Testzahlen, Coverage,
Paketgraph, Lizenzstatus, SBOM/Provenance und PR-Review. Geheimnisse,
vollständige Umgebungsvariablen und authentifizierte Quellen-URLs werden nicht
gespeichert. Neue Telemetrie, Mehrbenutzerbetrieb oder eine Compliance-Pflicht
für Nutzungsprotokolle würde Logging, Aufbewahrung, Löschung und DSGVO neu
bewerten.

### 7. Abhängigkeitsverwaltung und Lieferkette

| Kontrolle | Entscheidung |
|---|---|
| Primäre Registry | NuGet.org; 24/24 ausgelieferte Pakete durch Cache-/Asset-Metadaten gebunden |
| Direkte Abhängigkeit | genau `Terminal.Gui` 2.4.17 im TUI-Projekt |
| Transitiver Graph | 23 Pakete, vollständig in maschinenlesbarer Evidenz |
| Schwachstellen | 0 bekannte; jeder bekannte ausgelieferte Fund blockiert fail-closed |
| Lizenzen | 23 MIT, 1 BSD-2-Clause; 0 unbekannt, 0 unvereinbar |
| Updates | veraltete Versionen sind Review-Hinweise; keine automatische Scope-Erweiterung |
| VEX | nur für belegten Fehlalarm oder nicht ausgelieferte Komponente; nie als Akzeptanz eines bekannten ausgelieferten Funds |
| Lockfile/Automation | kein `packages.lock.json`, Dependabot, Renovate oder Dependency-Track in Feature 003; separat zu autorisieren |
| Release-Evidenz | SPDX-SBOM, Provenance/SLSA-Ziel, OpenSSF-Review und Exact-Head-Bindung folgen vor Merge |

Der vollständige Audit steht in `docs/security/dependency-audit.md`. Ein neuer
Restore, eine Quellen- oder Projektänderung, ein Advisory oder eine
Lizenzänderung invalidiert den Snapshot und löst die erneute Prüfung aus.

### 8. Deployment-Sicherheit

```text
NuGet.org
   |
Restore und Audit
   |
Release-Build ---- Tests ---- Smoke ---- SBOM/Evidenz
   |
lokaler .NET-10-Prozess
   +-- Benutzerrechte
   +-- kein offener Port
   +-- kein Container oder Dienst
   +-- bestehende lokale Dateien
```

Textalternative: Restore und Audit beziehen Pakete aus NuGet.org. Nach Build,
Tests, Smoke und Lieferkettenevidenz läuft die Anwendung als lokaler .NET-10-
Prozess mit Benutzerrechten. Sie öffnet keinen Port, wird nicht als Dienst
installiert und verwendet die vorhandenen lokalen Dateien.

Härtungsregeln sind: Release-Konfiguration, keine Debug-Endpunkte, keine
Verbose-Stacktraces für Endnutzer, keine unnötigen Dienste, keine
Rechteerhöhung, echte Plattform-CI auf macOS/Linux/Windows und Merge nur vom
unveränderten geprüften PR-Head. HTTPS-/WAF-Regeln sind wegen fehlender
Webfläche `N/A`; eine solche Fläche würde ASVS und Zero Trust neu aktivieren.

### 9. Defense in Depth und sichere Defaults

Mindestens zwei unabhängige Schichten schützen jeden kritischen Pfad:

- Tastatur: geschlossene Handler plus Quellvertrag und reale PTY-Abnahme.
- Lifecycle: creator-owned `using`-Freigabe plus Build, Smoke und beide
  beobachteten Quit-Pfade.
- Core-Scope: Delivery-Set plus leerer Git-Diff und vollständige Tests.
- Lieferkette: exakte Version/Quelle plus Vulnerability-, Lizenz-, SBOM- und
  Exact-Head-Gates.
- Plattform: lokale macOS-Evidenz plus getrennte Linux-/Windows-Providerjobs.

Sichere Defaults sind deny-by-default: unbekannte Eingabe erzeugt keine neue
Aktion, unbekannte Lizenz oder bekannte Schwachstelle sperrt, fehlende
Plattformevidenz sperrt und ein formaler Admin-Bypass ersetzt keine technische
Prüfung.

### 10. Audit-Matrix und Restrisiken

| Prüfpunkt | Ergebnis | Restrisiko oder Trigger |
|---|---|---|
| Lifecycle-Ownership | OK | neue App-Instanz oder anderes Nesting öffnet den S-ADR |
| Trust Boundaries | OK | neue Datei-, Netzwerk-, Dienst- oder Prozessgrenze löst Threat-Model-Update aus |
| Eingabevalidierung | OK | neue Taste oder Freitextausführung benötigt neuen Vertrag |
| Fehler und Logging | OK | neue Telemetrie oder Remote-Diagnose benötigt Datenschutz-/Disclosure-Prüfung |
| Abhängigkeiten | lokal OK | Advisory, Quelle, Version oder Lizenzänderung invalidiert Snapshot |
| Deployment | lokal OK | Linux/Windows und Exact Head bleiben bis Provider-Gate offen |
| Auth/Authz/Krypto | N/A, begründet | neue Identität, Rolle, Remoteverbindung oder geheime Persistenz aktiviert die Kontrollen |

Das verbleibende Risiko liegt in Plattformabweichungen des Terminaltreibers
und in der zeitlichen Alterung von Advisory-Daten. Beide Risiken bleiben bis
zum Provider- und Exact-Head-Gate offen und werden nicht durch Dokumentation
allein als behoben betrachtet.

### 11. Begründetes N/A-Register

| Bewertung | Feature-003-Status | Begründung | Re-Evaluation-Trigger |
|---|---|---|---|
| OWASP ASVS | N/A | keine Web-, HTTP-, API-, Authentifizierungs- oder Session-Fläche | Einführung einer dieser Flächen; dann ASVS-Level und Verifikationsumfang festlegen |
| allgemeiner Architektur-ADR | N/A | Intake und Plan binden Terminal.Gui v2 bereits; der sicherheitsrelevante Lifecycle-/Supply-Chain-Anteil ist im fokussierten S-ADR anwendbar dokumentiert | neue allgemeine Architekturwahl oder neue Schicht |
| Zero Trust nach NIST SP 800-207 | N/A | lokaler Einprozessbetrieb ohne verteilten Dienst, Remoteverwaltung oder Dienstidentität | Netzwerk-, Cloud-, Service-, Remote- oder Identitätsgrenze |
| BSI C3A | N/A im Feature-Scope | kein Cloud-Service, Cloud-API oder Cloud-Kundenbetrieb | Cloud-Funktion oder Cloud-Service-Lieferung |
| BSI C5 | N/A im Feature-Scope | TinyCalc betreibt für diese TUI keinen Cloud-Dienst und verarbeitet keine Kundendaten in einer Cloud | Cloud-Betrieb oder Beauftragung eines Cloud-Service-Providers |
| NIS2 | kein Feature-Delta; N/A für diese technische Änderung | keine neue kritische/hochwichtige Dienstleistung oder Betreiberrolle; eine organisationsrechtliche Einordnung wird nicht behauptet | geänderter Betreiber-, Dienst- oder Organisationsscope; externe Rechtsprüfung |
| Cyber Resilience Act | kein Feature-Delta; keine Rechtsentscheidung | die Migration ändert keine Vermarktungs-, Hersteller- oder Distributionsrolle; die projektweite CRA-Einordnung bleibt einer separaten Release-/Rechtsprüfung vorbehalten | kommerzielle oder sonstige Marktbereitstellung, Herstellerpflicht oder Release-Policy |
| EU AI Act | N/A | KI ist nur Entwicklungswerkzeug; keine KI-Runtime oder Produktfunktion | ausgeliefertes Modell, KI-Dienst, Datensatz oder Inferenzkomponente |
| DORA | N/A | kein Finanzunternehmen, ICT-Drittdienst für Finanzunternehmen oder Finanz-Remote-Service im Feature-Scope | entsprechender Kunde, Vertrag oder Betriebsmodell |

Die N/A-Aussagen sind enge technische Feature-Entscheidungen und keine
allgemeine Rechtsberatung. Jeder genannte Trigger setzt die jeweilige
Disposition vor weiterer Lieferung auf `Open`.

## English review block

### Run evidence and scope

This arc42 Section 8 review covers TinyCalc Feature 003 on branch
`003-terminalgui-migration`. It applies ISO 27001/27002 A.8.27 and A.8.28,
Constitution Principles XII–XVIII, NIST SSDF, CWE Top 25, Microsoft secure
coding guidance for C#/.NET, STRIDE/CAPEC, SBOM/SLSA, and WCAG 2.2 AA. The
evidence supports internal audit preparation and is not an external audit,
legal opinion, or certification.

### Lifecycle, boundaries, and input

`Program` creates and owns one `IApplication`. It initialises the application,
creates and runs one root, and creates, runs, and disposes each nested dialog.
Menu quit and `Ctrl+Q` stop the same active session. Structured disposal covers
normal and error paths. Smoke bypasses terminal initialisation and has no
terminal resource to own.

TB-1 is keyboard input, TB-2 is the unchanged local-file boundary, TB-3 is the
NuGet supply chain, and TB-4 is exact-head CI and delivery. Keyboard events map
to a closed set of existing handlers and cannot execute dynamic code. No new
file, network, process, SQL, shell, or deserialisation surface is introduced.

### Authentication, authorization, cryptography, errors, and logging

Authentication and authorization are not applicable to the local
single-user TUI without accounts, roles, remote access, or services. The
process keeps the current operating-system user's privileges and does not
elevate. Application-level encryption is not applicable because the feature
adds no network or confidential persistence. SHA-256 is used only for evidence
integrity, while NuGet transport uses the .NET client's TLS validation.

User-facing errors must not expose stack traces, authenticated package-source
details, secrets, or internal connection data. Disposal restores terminal
state on failures. No product telemetry or audit log is added; delivery
evidence records commands, exit codes, commits, platforms, test results,
coverage, package state, and provenance without secrets. Accounts, remote
access, telemetry, or protected new storage would trigger reassessment.

### Dependencies and deployment

The shipped graph contains one direct Terminal.Gui 2.4.17 package and 23
transitive packages, all from NuGet.org. It has zero known vulnerabilities and
zero unknown or incompatible licenses. Known shipped vulnerabilities or open
licenses block delivery. VEX can classify only a proven false positive or a
component that is not shipped. Lockfile and update automation remain separate
governance scope.

The application remains one local .NET 10 process with user privileges, no
listening port, no service, no container, and the unchanged local files. Real
Linux and Windows CI and exact-head validation remain mandatory. Web hardening,
ASVS, and Zero Trust are not applicable unless a web, service, remote, or
authenticated boundary is introduced.

The German N/A register is authoritative for feature-specific applicability.
ASVS, a general architecture ADR, Zero Trust, BSI C3A/C5, NIS2, CRA, the EU AI
Act, and DORA each have an explicit rationale and re-evaluation trigger. These
are narrow technical feature dispositions, not general legal advice.

### Defense in depth and residual risk

Closed input handlers plus real PTY evidence protect keyboard paths. Creator-
owned disposal plus build, smoke, and both quit paths protect lifecycle.
Delivery-set constraints plus Git diff and full tests protect Core. Exact
source/version plus vulnerability, license, SBOM, and exact-head gates protect
the supply chain. Separate provider jobs protect platform parity.

Residual risk remains in platform-specific terminal-driver behaviour and the
ageing of advisory data. Provider CI and final exact-head review must close
those risks; documentation alone does not close them.

## Referenzen / References

- `docs/architecture/terminalgui-migration.md`
- `docs/security/dependency-audit.md`
- `docs/security/adr/003-terminalgui-lifecycle-supply-chain.md`
- `specs/003-terminalgui-migration/spec.md`
- Constitution Principles XII–XVIII
- arc42 Section 8 and iSAQB CPSA-F quality concepts
