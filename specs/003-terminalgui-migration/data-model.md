# Laufzeit-Datenmodell / Runtime Data Model

## Umfang / Scope

Feature 003 ändert kein persistiertes Datenmodell, keine JSON-Struktur und
keine Core-Entität. Dieses Modell beschreibt nur Zustände und Nachweise der
TUI-Migration.

*Feature 003 changes no persisted data model, JSON structure, or Core entity.
This model describes only runtime state and migration evidence.*

## Entitäten / Entities

### AppSession

Felder: `ApplicationInstance`, `State`, `ActiveRunnable`, `Owner`. Zustände:

```text
Created -> Initialized -> MainRunning -> DialogRunning
                             ^                |
                             +----------------+
MainRunning -> Stopped -> Disposed
```

Textalternative: Eine Instanz wird einmal initialisiert. Dialoge kehren in die
Hauptsession zurück. Nach Stop folgt genau einmal Dispose.

*Text alternative: One instance is initialised once. Dialogs return to the main
session. Stop is followed by exactly one disposal.*

Invarianten: genau eine aktive `IApplication`; kein Run vor Init; Root und jeder
Dialog haben einen eindeutigen Dispose-Owner; Smoke erzeugt keine AppSession.

*Invariants: exactly one active `IApplication`; no run before init; root and
each dialog have one disposal owner; smoke creates no AppSession.*

### OwnedRunnable

Felder: `Kind` (`Root`, `Dialog`), `ParentSession`, `DisposalOwner`,
`ReturnTarget`. Ein Dialog darf die aktive App-Instanz nutzen, aber nicht deren
Besitz übernehmen.

*Fields: `Kind` (`Root`, `Dialog`), `ParentSession`, `DisposalOwner`, and
`ReturnTarget`. A dialog may use the active app instance but may not take its
ownership.*

### KeyBinding

Felder: `PhysicalKey`, `Modifiers`, `Action`, `Handled`. Die 13 bindenden
Instanzen stehen im Accessibility- und Compatibility-Vertrag. Jede erkannte
Taste löst genau eine Aktion aus; unbekannte Eingaben bleiben ohne neue
Nebenwirkung.

*Fields: `PhysicalKey`, `Modifiers`, `Action`, and `Handled`. The 13 binding
instances are listed in the accessibility and compatibility contracts. Each
recognised key causes exactly one action; unknown input gains no new side
effect.*

### PackageSelection

Felder: `PackageId=Terminal.Gui`, `Version=2.4.17`, `Direct=true`,
`TargetFramework=net10.0`, `AuditResult`, `UpstreamPosture`. Die Auswahl ist nur
gültig, wenn Restore, Paketgraph und Vulnerability Audit bestanden sind.

*Fields are the exact package, version, direct-reference flag, framework, audit
result, and upstream posture. The selection is valid only after restore,
package-graph, and vulnerability checks pass.*

### EvidenceSnapshot

Felder: `GateId`, `Scope`, `CommitSha`, `Command`, `RunnerOrPlatform`,
`TimestampUtc`, `ExitCode`, `ArtifactPath`, `ArtifactSha256`. Evidence-Zeilen
referenzieren den geprüften PR-Head. Der PostMerge-Snapshot bindet zusätzlich
den akzeptierten PreMerge-Hash und den tatsächlichen Merge-Commit.

*Fields identify the gate, scope, commit, command, platform, time, exit status,
artefact, and hash. Evidence rows reference the reviewed PR head. The post-merge
snapshot additionally binds the accepted pre-merge hash and actual merge commit.*

## Validierungsregeln / Validation Rules

- Zustandswechsel außerhalb der dargestellten Kanten blockieren. / State
  changes outside the shown edges block delivery.
- Persistierte Core-Daten und vorhandene Testquellen müssen im Delivery-Set
  fehlen. / Persisted Core data and existing test sources must not appear in
  the delivery set.
- Gate-Nachweise sind nur für exakt passenden Scope, Befehl, Plattform und SHA
  gültig. / Gate evidence is valid only for matching scope, command, platform,
  and SHA.
