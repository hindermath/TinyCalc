# Architektur der Terminal.Gui-v2-Migration

## Deutscher Architekturblock

### 1. Zweck und Randbedingungen

Feature 003 ersetzt ausschließlich die Terminal.Gui-v1-Anbindung von
`MicroCalc.Tui` durch Terminal.Gui 2.4.17. Die Tabellenkalkulation, Formeln,
Dateiformate, Hilfedatei und vorhandenen Tests bleiben fachlich unverändert.
Es entsteht keine neue Anwendungsschicht, kein Netzwerkdienst und keine neue
Persistenz. Die Architekturentscheidung betrifft nur Lifecycle, Tastencodes,
Widgets, Dialoge und die NuGet-Lieferkette der TUI.

Anwendbare Sicherheitsgrundlagen sind NIST SSDF, CWE Top 25, Microsoft Secure
Coding für C#/.NET, STRIDE mit CAPEC für risikoreiche Pfade, SBOM/SLSA für die
Lieferung und WCAG 2.2 AA für die Tastatur- und Fokusbedienung.

### 2. Kontextsicht

```text
Mensch und Tastatur
        |
        | TB-1: lokale, nicht vertrauenswürdige Eingabesequenz
        v
MicroCalc.Tui  ---->  MicroCalc.Core  ---->  lokale JSON-/Hilfedateien
        |                    |                    |
        |                    +-- fachlich unverändert
        |                                         TB-2: bestehende Dateigrenze
        |
        +-- Terminal.Gui 2.4.17
                    ^
                    |
          TB-3: NuGet.org-Lieferkette
          nur bei Restore/Build, nicht zur Laufzeit
```

Textalternative: Ein Mensch steuert die lokale TUI mit der Tastatur. Die TUI
ruft das unveränderte Core auf, das vorhandene lokale Dateien nutzt. Die
Tastatureingabe, die bestehende Dateigrenze und die Paketlieferkette sind
Vertrauensgrenzen. Zur Laufzeit gibt es keine Netzwerkverbindung.

### 3. Bausteinsicht

| Baustein | Verantwortung | Eigentum und Grenze |
|---|---|---|
| `MicroCalc.Tui.Program` | Composition Root, Startmodus, UI-Aufbau, Tastenzuordnung, Dialogaufrufe und sichere Beendigung | erzeugt und besitzt genau eine `IApplication`-Instanz sowie Root und Dialoge |
| Terminal.Gui 2.4.17 | Terminaltreiber, Eventloop, Fokus, Widgets und Tastenereignisse | externe Bibliothek; exakt gepinnt und vollständig auditiert |
| `MicroCalc.Core` | Tabellenmodell, Berechnung, Formeln und bestehendes Datei-I/O | unverändert; die TUI nutzt weiter die vorhandene API |
| lokale Ressourcen | Arbeitsblätter und `CALC.HLP` | bestehende Pfade und Formate; keine Migration |
| Smoke-Pfad | deterministische Startprüfung ohne Terminal | umgeht `IApplication.Init()` vollständig und gibt nur `SMOKE_OK` aus |

Die TUI bleibt Composition Root und dünner Adapter. Sie führt weder Service
Locator noch statisches Ersatz-Singleton, Repository-Abstraktion oder neue
Domänenschicht ein. Creator-owned bedeutet: Der Code, der eine ausführbare
Terminal.Gui-Ressource erzeugt, besitzt auch deren Lauf und Freigabe.

### 4. Laufzeitsicht

```text
Programmstart
    |
    +-- --smoke --> deterministische Prüfungen --> SMOKE_OK --> Exit 0
    |
    +-- interaktiv
           |
           v
      Create Application
           |
         Init
           |
      Create Root --> Run(Root)
                         |
                         +--> Create Dialog
                         |       |
                         |     Run(Dialog)
                         |       |
                         |     Dispose Dialog
                         |       |
                         |       +--> zurück zu Root
                         |
                         +--> Menü-Quit oder Ctrl+Q
                                  |
                              RequestStop
                                  |
      Run kehrt zurück <-----------+
           |
      Dispose Root
           |
      Dispose Application
           |
         Exit
```

Textalternative: Der Smoke-Modus beendet sich ohne Terminalinitialisierung.
Im interaktiven Modus wird genau eine App erzeugt und initialisiert. Das Root
läuft in dieser App. Jeder Dialog wird vom Aufrufer erzeugt, verschachtelt
ausgeführt und danach freigegeben. Menü-Quit und `Ctrl+Q` fordern das Ende
derselben aktiven Sitzung an. Danach werden Root und App auch auf Fehlerpfaden
durch strukturierte `using`-Bereiche freigegeben.

### 5. Deployment-Sicht

```text
Entwicklung und CI                         Zielsystem
------------------                        ----------
NuGet.org -- Restore --> .NET-10-Build --> lokaler .NET-10-Prozess
                         |                 ohne Dienstkonto
                         +-- Tests         ohne offenen Port
                         +-- Smoke         ohne Container
                         +-- SBOM/Evidenz  mit Benutzerrechten
```

Textalternative: Die Abhängigkeiten kommen beim Restore aus NuGet.org. Der
Build erzeugt eine lokale .NET-10-Anwendung. Sie läuft mit den Rechten des
angemeldeten Menschen, öffnet keinen Netzwerkport und benötigt weder Container
noch privilegierte Installation. macOS liefert die lokale Evidenz; Linux und
Windows müssen getrennt in echter CI nachgewiesen werden.

### 6. Qualitätsziele und Risiken

| Priorität | Qualitätsziel | Architekturmittel | Hauptrisiko | Prüfnachweis |
|---:|---|---|---|---|
| 1 | Verhaltensparität | geschlossene Matrix aus 13 bestehenden Eingaben | Taste wird doppelt oder nicht behandelt | Quellvertrag, reale PTY-Sitzungen |
| 2 | Ressourcenintegrität | eine App, creator-owned Root/Dialoge, strukturierte Freigabe | verschachtelter Lauf stoppt die falsche Ebene oder leakt Ressourcen | Build, Smoke, manuelle Quit-Pfade |
| 3 | Core-Stabilität | unveränderte Projekt- und Dateigrenze | unbeabsichtigte Fachänderung | leerer Diff für Core, Tests und `CALC.HLP` |
| 4 | Lieferkettensicherheit | exakte Version, NuGet.org, Vulnerability- und Lizenz-Gate | manipuliertes, verwundbares oder rechtlich ungeklärtes Paket | Paketgraph, SBOM, Lizenznachweis |
| 5 | Plattformparität | gleicher Repository-Befehl auf drei Betriebssystemen | Terminaltreiber verhält sich abweichend | macOS lokal, Linux/Windows in Provider-CI |
| 6 | Barrierefreiheit | Tastatur-first, stabile Fokusfolge, textuelle Statusanzeige | Fokus oder Information ist nicht wahrnehmbar | WCAG-2.2-AA-Prüfung und Bedienpfad |

### 7. Trust Boundaries und Defense in Depth

| Grenze | Eingabe oder Asset | Primäre Kontrolle | Unabhängige zweite Kontrolle | Fail-safe-Verhalten |
|---|---|---|---|---|
| TB-1 Tastatur | Terminal-Tastencodes und Ereignisfolge | geschlossene Zuordnung auf 13 bekannte Aktionen; unbekannte Taste löst keine privilegierte Aktion aus | reale PTY-Abnahme und Quellvertrag | Eingabe ignorieren oder sicheren Dialogzustand behalten |
| TB-2 lokale Dateien | bestehende Arbeitsblatt- und Hilfedateien | unverändertes Core-I/O und vorhandene Validierung | vorhandene Tests und verbotener Scope-Diff | bestehende sichere Fehlerbehandlung; keine neue Offenlegung |
| TB-3 Lieferkette | direktes und transitives NuGet-Paket | exakte Terminal.Gui-Version und NuGet.org-Quelle | Vulnerability-, Lizenz-, SBOM- und Exact-Head-Gate | bekannte Schwachstelle oder offene Lizenz sperrt Lieferung |
| TB-4 CI/Delivery | Provider-Artefakte und Commit-SHA | Exact-Head-Bindung | unabhängige Plattformjobs und Gate-Schema | kein Merge bei Drift oder fehlender Plattform |

Defense in Depth besteht aus Quellvertrag, Compiler, vollständigen Tests,
Headless-Smoke, echten PTY-Sitzungen, Coverage, Paketprüfung und Exact-Head-CI.
Least Privilege wird durch den lokalen Einprozessbetrieb ohne Dienstkonto oder
Port erhalten. Sichere Defaults bedeuten: keine unbekannte Taste als Aktion,
keine unbekannte Lizenz, keine bekannte ausgelieferte Schwachstelle und keine
Mergefreigabe bei fehlender Evidenz.

### 8. Architekturentscheidung und Gültigkeit

Ein allgemeiner ADR ist nicht nötig, weil Intake und Plan die Wahl der
UI-Komponente bereits festlegen. Der sicherheitsrelevante Zusammenhang aus
Lifecycle-Ownership und Lieferketten-Gates ist dagegen in genau einem S-ADR
festgehalten:
`docs/security/adr/003-terminalgui-lifecycle-supply-chain.md`.
`docs/security/arc42-security.md` beschreibt die Querschnittskonzepte.

Die Sicht wird neu geprüft, wenn sich App-Anzahl, Runtime-Nesting, Datei- oder
Netzwerkgrenze, Paketquelle, Terminal.Gui-Version, Plattformmatrix oder
Delivery-Verfahren ändert.

## English architecture block

### 1. Purpose and constraints

Feature 003 only replaces the Terminal.Gui v1 integration in `MicroCalc.Tui`
with Terminal.Gui 2.4.17. Spreadsheet behaviour, formulas, file formats, help,
and existing tests remain functionally unchanged. No service, persistence
mechanism, or application layer is added.

### 2. Context and building blocks

The keyboard user crosses TB-1 into `MicroCalc.Tui`. The TUI calls unchanged
`MicroCalc.Core`, which retains the existing local-file boundary TB-2.
Terminal.Gui enters through the NuGet.org supply-chain boundary TB-3 during
restore and build only; there is no runtime network connection. The German
context diagram above is the shared linear system map.

`MicroCalc.Tui.Program` remains the composition root and thin v2 adapter. It
creates and owns one `IApplication`, the root runnable, and every dialog.
Terminal.Gui provides the driver, event loop, focus, widgets, and key events.
Core retains the domain, formula, and file responsibilities. Smoke is a
separate deterministic path that bypasses terminal initialisation.

### 3. Runtime and deployment

Interactive startup creates one application, initialises it, creates the root,
and runs that root. A dialog is created, run as a nested creator-owned runnable,
and disposed before control returns to the root. Menu quit and `Ctrl+Q` request
stop for the same active session. Structured disposal releases root and
application on normal and error paths. The German runtime diagram above is the
shared step-by-step representation.

The deliverable remains one local .NET 10 process with user privileges, no
service account, no listening port, no container, and no privileged install.
macOS provides local evidence. Linux and Windows require separate real CI
evidence and may not be inferred from macOS.

### 4. Quality, risk, and trust boundaries

The primary qualities are behavioural parity, resource integrity, Core
stability, supply-chain security, platform parity, and accessibility. The
shared quality table maps each goal to a risk and evidence path. TB-1 keyboard,
TB-2 existing local files, TB-3 NuGet supply chain, and TB-4 CI delivery are the
explicit trust boundaries.

Defense in depth combines source contracts, compiler checks, the full test
suite, headless smoke, real PTY sessions, coverage, package review, and
exact-head CI. Fail-safe defaults reject unknown actions, block unknown or
incompatible licenses and known shipped vulnerabilities, and deny merge when
required evidence is missing.

Exactly one focused security ADR records lifecycle ownership and fail-closed
supply-chain decisions. Reassessment is required if application count,
runtime nesting, file or network boundaries, package source, Terminal.Gui
version, platform matrix, or delivery procedure changes.
