# OWASP-SAMM-Review: TinyCalc

## Deutscher Prüfblock

### Laufnachweis und Entscheidung

| Feld | Wert |
|---|---|
| Projekt | TinyCalc, Level 2 |
| Feature | 003, Terminal.Gui-v2-Migration |
| Branch | `003-terminalgui-migration` |
| Phase | Implementierung |
| Datum | 2026-08-30 |
| Rhythmus | releasebezogen und bei wesentlicher Prozessänderung |
| Owner | Repository-Maintainer |
| Reviewer | Security-/PR-Review am Exact Head |
| Entscheidung | **reviewed, unchanged**: Feature 003 ändert den projektweiten SAMM-Reifegrad nicht |

OWASP SAMM ist für das langlebige Repository als Verbesserungsrahmen
anwendbar. Dieser Lauf prüft nur, ob die Terminal.Gui-Migration einen neuen
Prozessbefund oder eine eigenständige Verbesserungsmaßnahme auslöst. Er ist
keine vollständige organisationsweite SAMM-Bewertung und vergibt deshalb
keinen unbelegten Reifegrad von 1, 2 oder 3.

Die interne Evidenz unterstützt Audit- und Zertifizierungsvorbereitung. Sie
ersetzt keine externe Auditierung, Rechtsberatung oder formale Zertifizierung.

### Feature-bezogener Snapshot

| SAMM-Funktion | Beobachteter Feature-003-Nachweis | Prozessbefund | Disposition |
|---|---|---|---|
| Governance | bindendes Intake, Constitution, Owner/Reviewer, sichere Stop- und Delivery-Grenzen | kein neuer Governance-Prozess nötig | reviewed, unchanged |
| Design | Architektur, Threat Model, S-ADR, arc42, Trust Boundaries und Qualitätsszenarien | vorhandener Spec-Kit-Prozess deckt die Migration ab | reviewed, unchanged |
| Implementation | Red-Green-Regression, C#-Secure-Coding-Profil, exakte Paketversion und Versionierungsledger | kein neuer Build- oder Defect-Prozess nötig | reviewed, unchanged |
| Verification | Build, 79 Tests, Smoke, reale PTY-Sitzungen, 82 Prozent Coverage, Vulnerability- und Lizenzprüfung | Provider- und Exact-Head-Abschluss ist Feature-Gate, kein neues Prozessfeature | reviewed, unchanged |
| Operations | lokale Desktop-TUI ohne Dienst, Remotezugriff oder neue Laufzeittelemetrie | keine neue Betriebs- oder Incident-Fläche | reviewed, unchanged |

### Bestehende Abschlussgrenzen, keine neuen Maßnahmen

Die folgenden Punkte sind bereits Aufgaben von Feature 003 und keine neue
SAMM-Roadmap:

- Linux- und Windows-Providerjobs sowie exaktes `SMOKE_OK` in T066;
- SPDX-SBOM, Supply-Chain-Evidenz und ehrlicher SLSA-/Provenance-Status in
  T051/T052;
- Exact-Head-Gates, Review und Commitbindung in T063 bis T068;
- enge Admin-Bypass-Revalidierung nur bei realer formaler Policy-Blockade.

Feature 003 startet ausdrücklich kein Dependabot-, Renovate-, Dependency-
Track-, Lockfile-, Telemetrie-, Incident-Management- oder allgemeines
Security-Training-Projekt. Ein solcher Prozessausbau benötigt einen eigenen
Auftrag und Owner.

### Owner, Folgegrenze und Trigger

| Punkt | Owner | Grenze oder Trigger | Aktion |
|---|---|---|---|
| Exact-Head-Revalidierung | Feature 003 / PR-Reviewer | nach dem einzigen Feature-Commit und vor Merge | diesen Review gegen finalen Diff bestätigen; bei Prozessänderung neu bewerten |
| neuer wiederkehrender Security-Befund | Repository-Maintainer | gleiche Finding-Klasse in mehreren Features oder Releases | getrenntes SAMM-Verbesserungs-Intake erwägen |
| neue Runtime-/Service-Grenze | Repository-Maintainer | Netzwerk, Authentifizierung, Dienst, Cloud oder Remoteverwaltung | vollständige Design-/Operations-Neubewertung |
| neue Dependency-Automation | Repository-Maintainer | eigener genehmigter Auftrag | Governance, Implementation und Verification neu bewerten |

### Exact-Head-Platzhalter

Status ist `Pending` bis T063/T067: Der finale PR-Head muss zeigen, dass Feature
003 ausschließlich die bereits dokumentierten Prozesse nutzt und keine
unerwartete Workflow-, Agenten-, Script-, Runtime- oder Betriebsänderung
enthält. Ist der Diff größer, wird `reviewed, unchanged` ungültig und das
Assessment wird vor Merge erneut geöffnet.

## English review block

### Decision and scope

OWASP SAMM is applicable as an improvement framework for this long-lived
repository. This Feature 003 review asks only whether the Terminal.Gui
migration creates a new process finding or a separate improvement action. It
is not a full organisational assessment and does not claim an unsupported
maturity level.

The decision is **reviewed, unchanged**. Existing Spec Kit governance covers
intake, ownership, secure stop, and delivery authority. Design already requires
architecture, threat modelling, arc42, and one focused security ADR.
Implementation and verification use Red-Green-Regression, secure C# review,
build, all tests, smoke, real PTY evidence, coverage, and package gates.
Operations remain unchanged because the product is still a local desktop TUI
without a service, remote access, or new telemetry.

Linux and Windows CI, SBOM/provenance, exact-head gates, and final review are
existing Feature 003 completion work, not a new SAMM roadmap. The feature does
not start dependency automation, lockfile, telemetry, incident-management, or
general training work.

The repository maintainer owns any future process improvement. Repeated
security findings, a new runtime or service boundary, approved dependency
automation, or an unexpected exact-head workflow/operations diff triggers a
new assessment. Until T063/T067, the exact-head confirmation remains pending.

## Evidenz und Referenzen / Evidence and References

- `docs/security/security-checklist.md`
- `docs/security/threat-model.md`
- `docs/security/arc42-security.md`
- `docs/security/dependency-audit.md`
- `specs/003-terminalgui-migration/tasks.md`
- [OWASP SAMM](https://owasp.org/www-project-samm/)
- Constitution Principles XIV and XVIII
