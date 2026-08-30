# Abhängigkeits- und Lizenzprüfung

## Deutscher Nachweis

Stand: 2026-08-30T13:29:47Z

Umgebung: .NET SDK 10.0.400, `osx-arm64`, macOS 26.6.2

### Ausgeführte Prüfungen

```text
dotnet restore MicroCalc.sln
dotnet package list --project MicroCalc.sln --include-transitive --format json --no-restore
dotnet package list --project MicroCalc.sln --vulnerable --include-transitive --format json --source https://api.nuget.org/v3/index.json
dotnet package list --project MicroCalc.sln --outdated --include-transitive --format json --source https://api.nuget.org/v3/index.json
pwsh -NoLogo -NoProfile -File /tmp/tinycalc-003/export-shipped-licenses.ps1 -Assets src/MicroCalc.Tui/obj/project.assets.json -PackageRoot /Users/thorstenhindermann/.nuget/packages
```

Die Lösung enthält vier Projekte. Das ausgelieferte TUI-Projekt bindet genau
`Terminal.Gui` 2.4.17 direkt und 23 Pakete transitiv ein. Alle 24 Pakete wurden
aus der offiziellen NuGet.org-Quelle wiederhergestellt. Eine lokal konfigurierte,
authentifizierte Anbieterquelle wurde für die Prüfung ausgeblendet, im Nachweis
nicht gespeichert und von keinem ausgelieferten Paket verwendet.

Die Schwachstellenprüfung meldet null bekannte Schwachstellen. Der Bericht zu
neueren Versionen nennt 48 projektbezogene direkte oder transitive Treffer. Sie
sind ein Wartungshinweis und kein Auftrag für automatische Aktualisierungen.
Diese Feature-Lieferung ändert deshalb keine weitere Paketversion.

Für jedes ausgelieferte Paket sind Paket-ID, Version, direkte oder transitive
Beziehung, NuGet.org-Quelle, Lizenztyp, SPDX-Ausdruck, offizieller Lizenztext,
Repository-Metadaten und NUSPEC-Hash maschinenlesbar erfasst. Das Ergebnis ist:

- 24 von 24 Lizenzen bekannt und für die Verteilung akzeptiert
- 23 Pakete mit `MIT`
- 1 Paket (`Markdig` 1.3.2) mit `BSD-2-Clause`
- 0 unbekannte und 0 unvereinbare Lizenzen

`Terminal.Gui` 2.4.17 ist an den Upstream-Commit
`d0a0ed9b150d3fc8aacf4ab07b7f7d91264fe6d6` gebunden. Die Auswahl- und
Upstream-Begründung steht zusätzlich in `package-selection.md`.

Eine bekannte Schwachstelle oder eine unbekannte beziehungsweise unvereinbare
Lizenz in einem ausgelieferten Paket sperrt die Lieferung. Ein Versionshinweis
ohne bekannte Schwachstelle wird geprüft und dokumentiert, löst aber keine
ungeplante Aktualisierung aus.

### Maschinenlesbare Evidenz

| Datei | SHA-256 |
|---|---|
| `restore-final.txt` | `a9eaacfc32a9742e0323564dcf0a1088a0e982453eedf0f487f596651faf7157` |
| `packages-all.json` | `7c717501d982e43a51b45cba70d8a2bdb181a67553106926bd06ce108344e2c0` |
| `packages-vulnerable.json` | `5a512fe3f66fb021353733e412c987ca854944f06c9ffc0a2d57a52274fd29e1` |
| `packages-outdated.json` | `f11696f4e6bf46da177b95c5b62bb51b1bc10a2b8885036707dd5ebe99bfafa0` |
| `licenses-shipped.json` | `fe451cb2a9c14447078c549ed462ea5d2c9463711ba2947309a3e5ea256fb2a5` |
| `package-selection.md` | `5ed0d788ff71800e9002acbfaf9cd54c302d400f96bf247263dc8c0d12a15bb7` |

## English evidence

Timestamp: 2026-08-30T13:29:47Z

Environment: .NET SDK 10.0.400, `osx-arm64`, macOS 26.6.2

The solution contains four projects. The shipped TUI project has exactly one
direct dependency, `Terminal.Gui` 2.4.17, and 23 transitive dependencies. All
24 packages were restored from the official NuGet.org source. A locally
configured authenticated vendor source was excluded from the checks, was not
stored in the evidence, and did not provide any shipped package.

The vulnerability report contains zero known vulnerabilities. The outdated
report contains 48 project-specific direct or transitive results. They are
maintenance information, not authorization for automatic updates. No unrelated
package version is changed by this feature.

Every shipped package has machine-readable evidence for its ID, version,
relationship, NuGet.org source, license type, SPDX expression, authoritative
license text, repository metadata, and NUSPEC hash. All 24 licenses are known
and accepted for distribution: 23 are `MIT`, and `Markdig` 1.3.2 is
`BSD-2-Clause`. There are no unknown or incompatible licenses.

`Terminal.Gui` 2.4.17 is bound to upstream commit
`d0a0ed9b150d3fc8aacf4ab07b7f7d91264fe6d6`. The additional selection and
upstream rationale is recorded in `package-selection.md`.

A known vulnerability or an unknown or incompatible license in a shipped
package blocks delivery. A newer-version result without a known vulnerability
is reviewed and documented, but does not trigger an unplanned update.

The command list and SHA-256 table above are the shared authoritative execution
and integrity evidence for both language sections.
