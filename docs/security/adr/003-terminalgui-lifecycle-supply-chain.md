# S-ADR-003: Creator-owned Terminal.Gui-Lifecycle und fail-closed Lieferkette

## Deutscher Entscheidungsblock

### Laufnachweis

| Feld | Wert |
|---|---|
| Feature | 003, Terminal.Gui-v2-Migration |
| Phase | Implementierung |
| Branch | `003-terminalgui-migration` |
| Baseline | `886a13f8866e79fe6c13e6e1227217294aabdee8` plus geprüfter Arbeitsbaum; Exact Head folgt |
| Datum | 2026-08-30 |
| Status | Akzeptiert für Feature 003; Lieferung bleibt von CI und Exact Head abhängig |
| Entscheider | bindendes Intake und autorisierter autonomer Spec-Kit-Lauf; finale PR-Prüfung vor Merge |
| Standards | ISO 27001/27002 A.8.27 und A.8.28, NIST SSDF, CWE Top 25, STRIDE/CAPEC, SBOM/SLSA |

Diese Evidenz dient der internen Audit- und Zertifizierungsvorbereitung. Sie
ersetzt keine externe Auditierung, Rechtsberatung oder formale Zertifizierung.

### Kontext

Terminal.Gui v2 ersetzt den globalen v1-Lifecycle durch explizite
`IApplication`- und Runnable-Instanzen. TinyCalc besitzt ein Root und mehrere
verschachtelte Dialoge. Unklare Ownership könnte Ressourcen leaken, den
falschen Lauf stoppen oder Terminalzustände nach einem Fehler zurücklassen.

Gleichzeitig vergrößert Terminal.Gui 2.4.17 den ausgelieferten Paketgraph auf
eine direkte und 23 transitive Abhängigkeiten. Manipulierte Quellen, bekannte
Schwachstellen oder ungeklärte Lizenzen betreffen denselben Release wie der
Lifecycle-Code. Lifecycle und Lieferkette müssen deshalb als gemeinsame
sicherheitsrelevante Entscheidung fail-closed behandelt werden.

### Entscheidung

Wir verwenden genau eine, von `Program` erzeugte und besessene
`IApplication`-Instanz. `Program` initialisiert sie, erzeugt das Root und führt
dieses Root aus. Jeder Dialog ist creator-owned: Der aufrufende Handler erzeugt
ihn, führt ihn als verschachteltes Runnable aus und gibt ihn im gleichen
strukturierten Scope frei. Menü-Quit und `Ctrl+Q` fordern das Ende derselben
aktiven App an. `using`-Scopes geben Dialog, Root und App auch bei Fehlern frei.
Der Smoke-Pfad umgeht die Terminalinitialisierung vollständig.

Wir beziehen Terminal.Gui exakt in Version 2.4.17 nur im TUI-Projekt aus
NuGet.org. Direkte und transitive Pakete werden vor Lieferung vollständig auf
Quelle, bekannte Schwachstellen, Lizenz, Kompatibilität und Disposition
geprüft. Ein bekannter Fund im ausgelieferten Graph oder eine unbekannte oder
unvereinbare Lizenz sperrt die Lieferung. VEX darf nur einen belegten
Fehlalarm oder eine nicht ausgelieferte Komponente klassifizieren. Es darf
keinen bekannten ausgelieferten Fund autorisieren.

Admin-Bypass bleibt außerhalb dieser technischen Entscheidung. Er darf nur
eine formale GitHub-Merge-Policy überwinden, nachdem Lifecycle-, Security-,
A11Y-, Plattform-, Review- und Exact-Head-Gates bestanden sind.

### Begründung

Explizite Ownership macht Erzeugung, Lauf und Freigabe lokal nachvollziehbar.
Eine App-Instanz verhindert konkurrierende Eventloops und mehrdeutige
Stop-Ziele. Creator-owned Dialoge begrenzen ihre Lebensdauer und halten
verschachtelte Läufe verständlich. Ein getrennter Smoke-Pfad bleibt
deterministisch und benötigt keinen Terminaltreiber.

Die fail-closed Paketentscheidung verbindet Least Privilege, sichere Defaults,
Defense in Depth und Supply-Chain-Sicherheit: exakte Version und Registry
verringern Drift; Vulnerability- und Lizenzprüfung bilden unabhängige
Schranken; SBOM und Exact-Head-Evidenz binden das Ergebnis an die Lieferung.

### Verworfene Alternativen

#### A. Globaler statischer v1-Lifecycle oder Ersatz-Singleton

Diese Lösung würde v1-Semantik in v2 nachbauen, Ownership verstecken und Tests,
Dialog-Nesting sowie sichere Freigabe erschweren. Sie wurde verworfen.

#### B. Eine neue App-Instanz je Root oder Dialog

Mehrere Eventloops hätten mehrdeutige Stop-Ziele, zusätzliche Terminalzustände
und ein höheres Leak- und DoS-Risiko. Sie wurden verworfen.

#### C. Dialoge ohne strukturierten Owner

Eine spätere oder globale Freigabe könnte Fehlerpfade übersehen und Ressourcen
über ihre tatsächliche Nutzung hinaus halten. Sie wurde verworfen.

#### D. Lokale ProjectReference oder Anbieterquelle als Paket-Fallback

Ein Fallback würde den genehmigten NuGet-Vertrag, Reproduzierbarkeit und
Upstream-Bindung umgehen. Er wurde verworfen.

#### E. Bekannte Schwachstelle per VEX oder Admin-Bypass akzeptieren

VEX beschreibt Anwendbarkeit, ist aber keine Genehmigung für einen bekannten
ausgelieferten Fund. Admin-Bypass betrifft nur formale Merge-Policy. Beide
Varianten wurden als technische Substitution verworfen.

### Konsequenzen

Positive Folgen:

- eindeutige Lifecycle- und Stop-Ownership;
- strukturierte Freigabe auf Normal- und Fehlerpfaden;
- deterministischer Smoke ohne Terminalinitialisierung;
- reproduzierbarer, prüfbarer Paketgraph;
- fail-closed Verhalten bei Advisory- oder Lizenzproblemen;
- unabhängige Schutzschichten durch Build, Test, PTY, Coverage, Audit und CI.

Negative Folgen und Aufwand:

- jeder neue Dialog muss das creator-owned Muster einhalten;
- Paket-, Lizenz- und Advisory-Evidenz muss vor jedem Release erneuert werden;
- Linux und Windows benötigen echte Providerläufe;
- ein neuer Advisory-Fund kann die Lieferung trotz funktionalem Code stoppen;
- ohne Lockfile und Update-Automation bleibt ein bewusst dokumentierter
  Governance-Rest, der nicht Teil von Feature 003 ist.

Restrisiken:

- Terminaltreiber können sich je Betriebssystem abweichend verhalten;
- Advisory- und Lizenzmetadaten altern nach dem Prüfzeitpunkt;
- Provider- oder Registry-Kompromittierung kann nicht allein durch lokale
  Prüfung ausgeschlossen werden.

Die Mitigation sind echte Plattform-CI, Exact-Head-Revalidierung, SBOM/
Provenance, erneute Advisory-/Lizenzprüfung und OpenSSF-Upstream-Review.

### Compliance-Nachweis

| Prinzip oder Kontrolle | Status | Nachweis |
|---|---|---|
| Principle XII, sichere Code-Erzeugung | erfüllt | geschlossene Tastenzuordnung, strukturierte Freigabe, sichere Endnutzerfehler, vollständige Tests |
| Principle XIII, sichere Architektur | erfüllt | Trust Boundaries, eine App, creator-owned Ressourcen, Defense in Depth und fail-safe Defaults |
| NIST SSDF / CWE Top 25 | erfüllt im Feature-Scope | Spec, Security-Plan, Build/Test/Coverage und Security-Checkliste |
| ISO A.8.27 / A.8.28 | erfüllt im Feature-Scope | dieser S-ADR, arc42 Section 8, Dependency Audit und Threat Model |
| SBOM / SLSA | offen bis Lieferung | Exact-Head-Supply-Chain-Evidenz vor Merge |
| VEX | N/A bei aktuellem Graph | 0 bekannte Schwachstellen; Trigger ist ein belegter Fehlalarm oder nicht ausgelieferter Fund |
| Admin-Bypass-Grenze | bindend | Gate TG-GATE-047; keine technische Substitution |

### Neubewertung

Der S-ADR wird neu geöffnet bei einer zweiten App-Instanz, verändertem
Dialog-Nesting, neuer Datei-/Netzwerk-/Prozessgrenze, neuer Paketquelle,
Terminal.Gui-Versionsänderung, bekanntem Advisory, Lizenzänderung, neuer
Plattform oder geändertem Delivery-Verfahren.

## English decision block

### Context and decision

Terminal.Gui v2 uses explicit application and runnable instances. Ambiguous
ownership could leak resources, stop the wrong run, or leave terminal state
behind after an error. Terminal.Gui 2.4.17 also introduces one direct and 23
transitive shipped dependencies, so lifecycle and supply-chain controls affect
the same release boundary.

`Program` creates and owns exactly one `IApplication`, initialises it, creates
the root, and runs that root. Every dialog is creator-owned: its handler
creates, runs, and disposes it in the same structured scope. Menu quit and
`Ctrl+Q` stop the same active application. Structured disposal covers normal
and error paths. Smoke bypasses terminal initialisation.

Terminal.Gui is pinned to 2.4.17 only in the TUI project and restored from
NuGet.org. Every shipped direct and transitive package requires source,
vulnerability, license, compatibility, and disposition evidence. A known
shipped vulnerability or an unknown or incompatible license blocks delivery.
VEX may classify only a proven false positive or a component that is not
shipped. Admin bypass may address a formal GitHub merge policy only after all
technical gates pass.

### Alternatives and consequences

A static v1-style singleton was rejected because it hides ownership. Multiple
application instances were rejected because they create ambiguous event loops
and stop targets. Ownerless dialogs were rejected because error paths can miss
cleanup. A local project or vendor-source fallback was rejected because it
breaks the approved NuGet contract. VEX or admin bypass as acceptance of a
known shipped vulnerability was rejected because neither is technical risk
remediation.

The decision gives clear ownership, safe disposal, deterministic smoke, a
reproducible package graph, and fail-closed supply-chain gates. It also requires
every new dialog to follow the ownership pattern, repeats dependency evidence
for releases, and can block otherwise functional delivery when a new advisory
appears. Platform differences and ageing advisory data remain residual risks.

### Compliance and re-evaluation

This decision supports secure code generation, secure architecture, NIST SSDF,
CWE Top 25, ISO A.8.27/A.8.28, SBOM/SLSA evidence, and the narrow admin-bypass
boundary. It must be reopened when application count, dialog nesting, file,
network, or process boundaries, package source, Terminal.Gui version,
advisories, licenses, platforms, or delivery procedure change.

## Verknüpfte Dokumente / Related Documents

- `docs/architecture/terminalgui-migration.md`
- `docs/security/arc42-security.md`
- `docs/security/dependency-audit.md`
- `docs/security/threat-model.md`
- `specs/003-terminalgui-migration/spec.md`
- `specs/003-terminalgui-migration/security-plan.md`
