# Architektur / Architecture

## Kontextsicht / Context View

```text
Keyboard user -> MicroCalc.Tui -> MicroCalc.Core -> local JSON/help files
                       |
                       +-> Terminal.Gui 2.4.17 from NuGet supply chain
```

Textalternative: Der Mensch gibt Tasten in die lokale TUI ein. Die TUI nutzt
unverändertes Core-Verhalten und lokale Dateien. Nur die Terminal- und
Paketgrenze ändert sich.

*Text alternative: A person enters keys into the local TUI. The TUI uses
unchanged Core behaviour and local files. Only the terminal and package
boundaries change.*

## Bausteinsicht / Building-block View

- `MicroCalc.Core`: unveränderte Domain-, Formel- und I/O-Komponente. /
  Unchanged domain, formula, and I/O component.
- `MicroCalc.Tui.Program`: Composition Root und v2-Adapter; erzeugt und besitzt
  `IApplication`, Root und Dialoge. / Composition root and v2 adapter; creates
  and owns the application, root, and dialogs.
- `Terminal.Gui 2.4.17`: externer Terminaltreiber und Widget-Runtime. / External
  terminal driver and widget runtime.

Keine neue Schicht, kein Service Locator und kein statisches Ersatz-Singleton
werden eingeführt.

*No new layer, service locator, or replacement static singleton is introduced.*

## Laufzeitsicht / Runtime View

```text
--smoke? --yes--> run deterministic checks -> print SMOKE_OK -> exit 0
    |
    no
    v
Create app -> Init -> create root -> Run(root)
                              |
                              +-> open/run/dispose dialog -> return to root
                              +-> menu quit or Ctrl+Q -> RequestStop
Run returns -> dispose root -> dispose app
```

Textalternative: Smoke umgeht die Terminalinitialisierung. Interaktiv gibt es
eine App-Instanz. Dialoge laufen verschachtelt und werden freigegeben. Beide
Quit-Pfade stoppen dieselbe aktive Session; anschließend werden Root und App
freigegeben.

*Text alternative: Smoke bypasses terminal initialisation. Interactive mode
uses one app instance. Dialogs run nested and are disposed. Both quit paths
stop the same active session; root and app are then disposed.*

## Deployment-Sicht / Deployment View

Die Anwendung bleibt ein lokaler .NET-10-Prozess ohne Netzwerkdienst, Container
oder privilegierte Installation. Entwicklung/manuelle Prüfung erfolgt auf
macOS; CI-Belege müssen separat von `ubuntu-latest` und `windows-latest`
stammen.

*The application remains one local .NET 10 process without a network service,
container, or privileged installation. Development/manual review occurs on
macOS; CI evidence must come separately from `ubuntu-latest` and
`windows-latest`.*

## Qualitäts- und Risikosicht / Quality and Risk View

| Ziel / Goal | Architekturmittel / Architectural measure | Risiko / Risk |
|---|---|---|
| Verhaltensparität / Behaviour parity | zentraler 13-Tasten-Vertrag, Smoke, manuelle Abnahme | Ereignis wird doppelt oder nicht behandelt |
| Ressourcenintegrität / Resource integrity | eindeutiger Owner, `using`, eine App-Instanz | verschachtelte Session stoppt falsche Ebene |
| Core-Stabilität / Core stability | Delivery-Set verbietet Core-/Testdiff | unbeabsichtigte fachliche Änderung |
| Lieferkette / Supply chain | exakte Version, Audit, SBOM, Upstream-Review | manipuliertes oder verwundbares Paket |
| Plattformparität / Platform parity | echte macOS-/Linux-/Windows-Belege | Terminaltreiber weicht je Plattform ab |

## Trust Boundaries und Defense in Depth

Vertrauensgrenzen sind lokale Tastatureingabe und NuGet-Paketbezug. Tastencodes
werden auf eine geschlossene Aktionsmenge abgebildet. Paket-Pinning,
Vulnerability Audit und SPDX-SBOM sichern die Lieferkette. Quellvertrag,
Compiler, Tests, Smoke und manuelle Abnahme sind unabhängige Prüfschichten.

*Trust boundaries are local keyboard input and NuGet package acquisition. Key
codes map to a closed action set. Package pinning, vulnerability audit, and an
SPDX SBOM protect the supply chain. Source contract, compiler, tests, smoke, and
manual acceptance are independent verification layers.*

## Architekturentscheidungen / Architecture Decisions

Ein allgemeiner, nicht sicherheitsbezogener ADR ist `N/A`, weil Intake und
Migration Guide die UI-Komponente bereits binden. Der fokussierte S-ADR
`docs/security/adr/003-terminalgui-lifecycle-supply-chain.md` und die
vollständige Aktualisierung von `docs/security/arc42-security.md` sind dagegen
verpflichtend. Sie dokumentieren Lifecycle-Ownership, Trust Boundaries,
Eingaben, Abhängigkeiten, Fehler, Logging, Deployment und die fail-closed
Entscheidungen für Schwachstellen und Lizenzen.

*A general non-security ADR is N/A because the intake and migration guide
already bind the UI component. The focused security ADR and the complete
update of `docs/security/arc42-security.md` are mandatory. They document
lifecycle ownership, trust boundaries, input, dependencies, errors, logging,
deployment, and the fail-closed vulnerability and licence decisions.*
