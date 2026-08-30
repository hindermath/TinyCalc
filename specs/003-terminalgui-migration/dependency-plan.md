# Abhängigkeitsplan / Dependency Plan

## Auswahl / Selection

Direkte Änderung: `Terminal.Gui` von `1.19.0` auf exakt `2.4.17` ausschließlich
in `src/MicroCalc.Tui/MicroCalc.Tui.csproj`. Version, Ziel-Framework und
transitiver Graph werden bei der Umsetzung neu aus NuGet aufgelöst und als
JSON archiviert. Floating Ranges sind nicht zulässig.

*Direct change: `Terminal.Gui` moves from `1.19.0` to exact `2.4.17` only in the
TUI project. Version, target framework, and transitive graph are resolved again
from NuGet during implementation and archived as JSON. Floating ranges are not
allowed.*

Die NuGet Gallery wurde am 2026-08-30 als aktuelle autoritative Paketquelle
geprüft: `2.4.17` ist stabil, neuere `2.4.18-develop.*`-Einträge sind
Vorabversionen, und das Paket enthält `net10.0`. Diese veränderlichen Fakten und
die tatsächlich aktivierte Restore-Quelle werden vor Implementierung und
Release erneut belegt. / *The NuGet Gallery was checked on 2026-08-30 as the
current authoritative package source: `2.4.17` is stable, newer
`2.4.18-develop.*` entries are prerelease, and the package includes `net10.0`.
Re-evidence these mutable facts and the enabled restore source before
implementation and release.*

## Verbindliche Befehle / Binding Commands

```powershell
dotnet restore MicroCalc.sln
dotnet nuget list source
dotnet package list --project MicroCalc.sln --include-transitive --format json --no-restore
dotnet package list --project MicroCalc.sln --include-transitive --vulnerable --format json --no-restore
gh api repos/tui-cs/Terminal.Gui
```

Ausgaben gehen nach `specs/003-terminalgui-migration/evidence/dependencies/` und
werden in `docs/security/dependency-audit.md` mit UTC-Zeit, SDK, Commit-SHA,
Paketquellen und Bewertung zusammengefasst.

*Outputs go to the feature dependency-evidence directory and are summarised in
the dependency audit with UTC time, SDK, commit SHA, package sources, and
assessment.*

## Entscheidungsregeln / Decision Rules

- Restore-, Paketgraph- oder Audit-Fehler blockiert. / Restore, graph, or audit
  failure blocks.
- Eine andere als die belegte vertrauenswürdige Quelle, eine neuere stabile
  2.x-Version oder ein geändertes Target-Framework löst vor Fortsetzung eine
  erneute Auswahlprüfung aus; kein automatisches Upgrade ist erlaubt. / A
  different trusted source, a newer stable 2.x release, or changed target
  framework triggers renewed selection review; no automatic upgrade is allowed.
- Jede bekannte Schwachstelle in einer direkten oder transitiven ausgelieferten
  Abhängigkeit blockiert die Lieferung bis zu einem ausdrücklich autorisierten
  und abgeschlossenen Update oder Ersatz. VEX darf nur Fehlalarme oder
  bewertete, nicht ausgelieferte Komponenten klassifizieren und niemals einen
  bekannten ausgelieferten Fund freigeben. / Any known vulnerability in a
  direct or transitive shipped dependency blocks delivery until an explicitly
  authorised update or replacement is complete. VEX may classify only false
  positives or evaluated non-shipped components and never permits a known
  shipped finding.
- Upstream muss aktiv gepflegt sein; Release, Repository und Maintainer-Posture
  werden belegt. / Upstream must be actively maintained; release, repository,
  and maintainer posture are recorded.
- Der Scope führt keinen neuen Lockfile-Modus ein. Trigger ist eine
  repositoryweite Lockfile-Policy oder ein reproduzierbares-Restore-Befund. /
  This scope introduces no new lockfile mode. A repository-wide lockfile policy
  or reproducible-restore finding triggers reconsideration.
- Dependabot/Renovate/Dependency-Track bleiben N/A. Trigger ist ein eigenes
  Supply-Chain-Automatisierungsfeature oder eine Hosting-Freigabe. / Those
  automation systems remain N/A until a dedicated supply-chain feature or
  hosting approval.

## Lieferobjekte / Deliverables

`docs/security/dependency-audit.md`, maschinenlesbarer Paketgraph,
Vulnerability-Report und Verweis auf SPDX-SBOM. Ein leerer Vulnerability-Report
ist ein Nachweis, aber keine Garantie gegen zukünftige Funde.

*Deliverables are the dependency audit, machine-readable package graph,
vulnerability report, and SPDX reference. An empty vulnerability report is
evidence, not a guarantee against future findings.*
