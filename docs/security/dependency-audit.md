# Abhängigkeits-Audit: TinyCalc

## Deutscher Prüfblock

### Laufnachweis und Entscheidung

| Feld | Wert |
|---|---|
| Projekt | TinyCalc, Level 2, C# / .NET 10 |
| Feature | 003, Terminal.Gui-v2-Migration |
| Phase | Implementierung, lokaler Abhängigkeitsabschluss |
| Branch | `003-terminalgui-migration` |
| Baseline | `886a13f8866e79fe6c13e6e1227217294aabdee8` plus geprüfter Arbeitsbaum; Exact-Head-Nachweis folgt vor Lieferung |
| Datum | 2026-08-30 |
| Evidenzverantwortung | Codex im autorisierten autonomen Spec-Kit-Lauf |
| Review | technische Exact-Head- und PR-Prüfung vor Merge |
| Entscheidung | lokal bestanden; null bekannte Schwachstellen und null unbekannte oder unvereinbare Lizenzen im ausgelieferten Graph |

Anwendbar sind NIST SSDF, CWE Top 25, Microsoft Secure Coding für C#/.NET,
SPDX-Lizenzprüfung, SBOM-/VEX-Entscheidung, SLSA als Zielbild und eine
OpenSSF-Scorecard-Prüfung für die öffentliche Hauptabhängigkeit. OWASP ASVS ist
für diese lokale TUI ohne Web-, HTTP-, API- oder Authentifizierungsfläche nicht
anwendbar. AI-SBOM ist nicht anwendbar, weil KI nur Entwicklungswerkzeug und
keine ausgelieferte Laufzeitkomponente ist. Zero Trust ist für den lokalen
Einprozessbetrieb nicht anwendbar; eine neue Remote- oder Dienstgrenze würde
eine Neubewertung auslösen. OWASP SAMM bleibt als Verbesserungsrahmen für das
langlebige Repository anwendbar.

Die Detailnachweise liegen unter
`specs/003-terminalgui-migration/evidence/dependencies/`. Der vollständige
Graph steht in `packages-all.json`, bekannte Advisories in
`packages-vulnerable.json`, Wartungshinweise in `packages-outdated.json` und
jede Paketlizenz samt Quelle, Lizenztext, Repository-Metadaten und NUSPEC-Hash
in `licenses-shipped.json`.

### Werkzeuge und Ergebnisse

| Prüfung | Werkzeug oder Quelle | Ergebnis |
|---|---|---|
| Restore und Paketquelle | .NET SDK 10.0.400, `dotnet restore`, Asset- und Cache-Metadaten | 24 von 24 ausgelieferten Paketen aus NuGet.org |
| Vollständiger Graph | `dotnet package list --include-transitive --format json` | 1 direkte und 23 transitive TUI-Abhängigkeiten |
| Schwachstellen | `dotnet package list --vulnerable --include-transitive --format json` nur gegen NuGet.org | 0 bekannte Schwachstellen |
| Wartung | `dotnet package list --outdated --include-transitive --format json` nur gegen NuGet.org | 48 projektbezogene Hinweise; keine automatische Änderung |
| Lizenzen | NUSPEC, SPDX-Ausdruck und `licenses.nuget.org` | 23 MIT, 1 BSD-2-Clause, 0 unbekannt, 0 unvereinbar |
| Upstream | NuGet-Metadaten und Repository-Commit | `Terminal.Gui` 2.4.17 an `d0a0ed9b150d3fc8aacf4ab07b7f7d91264fe6d6` gebunden |

Die Anwendung besitzt keine eigene Paket-Update-Automation und kein
`packages.lock.json`. Dieses Feature führt weder Dependabot, Renovate,
Dependency-Track noch einen Lockfile-Modus ein. Das ist bewusst offener
Governance-Scope und kein stillschweigend als erfüllt gewerteter Kontrollpunkt.
Die exakten Paketversionen und der wiederhergestellte Asset-Graph sind für
Feature 003 gebunden. Eine spätere Automatisierung benötigt ein eigenes Intake
oder ausdrückliche Feature-Autorität.

### Ausgelieferter Paket- und Lizenzgraph

| Paket | Version | Beziehung | Lizenz | Quelle | Kompatibilität | Disposition |
|---|---:|---|---|---|---|---|
| `ColorHelper` | `1.8.1` | transitiv | `MIT` | NuGet.org | kompatibel | akzeptiert |
| `JetBrains.Annotations` | `2026.2.0` | transitiv | `MIT` | NuGet.org | kompatibel | akzeptiert |
| `Markdig` | `1.3.2` | transitiv | `BSD-2-Clause` | NuGet.org | kompatibel | akzeptiert |
| `Microsoft.Extensions.Configuration.Abstractions` | `10.0.7` | transitiv | `MIT` | NuGet.org | kompatibel | akzeptiert |
| `Microsoft.Extensions.Configuration.Binder` | `10.0.7` | transitiv | `MIT` | NuGet.org | kompatibel | akzeptiert |
| `Microsoft.Extensions.Configuration.FileExtensions` | `10.0.7` | transitiv | `MIT` | NuGet.org | kompatibel | akzeptiert |
| `Microsoft.Extensions.Configuration.Json` | `10.0.7` | transitiv | `MIT` | NuGet.org | kompatibel | akzeptiert |
| `Microsoft.Extensions.Configuration` | `10.0.7` | transitiv | `MIT` | NuGet.org | kompatibel | akzeptiert |
| `Microsoft.Extensions.DependencyInjection.Abstractions` | `10.0.9` | transitiv | `MIT` | NuGet.org | kompatibel | akzeptiert |
| `Microsoft.Extensions.FileProviders.Abstractions` | `10.0.7` | transitiv | `MIT` | NuGet.org | kompatibel | akzeptiert |
| `Microsoft.Extensions.FileProviders.Physical` | `10.0.7` | transitiv | `MIT` | NuGet.org | kompatibel | akzeptiert |
| `Microsoft.Extensions.FileSystemGlobbing` | `10.0.7` | transitiv | `MIT` | NuGet.org | kompatibel | akzeptiert |
| `Microsoft.Extensions.Logging.Abstractions` | `10.0.7` | transitiv | `MIT` | NuGet.org | kompatibel | akzeptiert |
| `Microsoft.Extensions.Options` | `10.0.9` | transitiv | `MIT` | NuGet.org | kompatibel | akzeptiert |
| `Microsoft.Extensions.Primitives` | `10.0.9` | transitiv | `MIT` | NuGet.org | kompatibel | akzeptiert |
| `Onigwrap` | `1.0.11` | transitiv | `MIT` | NuGet.org | kompatibel | akzeptiert |
| `System.IO.Abstractions` | `22.1.1` | transitiv | `MIT` | NuGet.org | kompatibel | akzeptiert |
| `Terminal.Gui` | `2.4.17` | direkt | `MIT` | NuGet.org | kompatibel | akzeptiert |
| `TestableIO.System.IO.Abstractions.Wrappers` | `22.1.1` | transitiv | `MIT` | NuGet.org | kompatibel | akzeptiert |
| `TestableIO.System.IO.Abstractions` | `22.1.1` | transitiv | `MIT` | NuGet.org | kompatibel | akzeptiert |
| `Testably.Abstractions.FileSystem.Interface` | `10.1.0` | transitiv | `MIT` | NuGet.org | kompatibel | akzeptiert |
| `TextMateSharp.Grammars` | `2.0.4` | transitiv | `MIT` | NuGet.org | kompatibel | akzeptiert |
| `TextMateSharp` | `2.0.4` | transitiv | `MIT` | NuGet.org | kompatibel | akzeptiert |
| `Wcwidth` | `4.0.1` | transitiv | `MIT` | NuGet.org | kompatibel | akzeptiert |

Alle Lizenztexte und SPDX-Ausdrücke sind in der maschinenlesbaren Evidenz
gebunden. Es gibt keine Lizenzabweichung und keine benötigte Sondergenehmigung.

### Fail-closed-Regeln, VEX und Restrisiko

- Jede bekannte Schwachstelle in einem ausgelieferten direkten oder transitiven
  Paket sperrt Build-Freigabe und Merge, bis ein ausdrücklich autorisiertes
  Update oder ein Ersatz umgesetzt und vollständig geprüft wurde.
- Eine unbekannte oder unvereinbare Lizenz sperrt die Lieferung ebenfalls.
- Ein VEX-Eintrag darf nur einen belegten Fehlalarm oder eine nachweislich nicht
  ausgelieferte Komponente klassifizieren. VEX autorisiert keinen bekannten
  Fund im ausgelieferten Graph.
- Neuere Paketversionen sind Wartungshinweise. Sie erlauben in Feature 003 keine
  ungeplanten Updates.
- Das Restrisiko ist die zeitliche Alterung des statischen Snapshots. Deshalb
  werden Vulnerability-, Lizenz-, Source-, Restore- und Exact-Head-Prüfung vor
  dem Merge erneut ausgeführt. Ein neuer Advisory-, Quellen- oder Lizenzfund
  öffnet diese Entscheidung wieder.
- Die OpenSSF Scorecard des öffentlichen Terminal.Gui-Upstreams wird als
  ergänzende Release-Evidenz bewertet; ihr Ergebnis ersetzt weder den lokalen
  Paketgraph noch die Schwachstellen- und Lizenzschranken.

### Audit-Matrix

| Kontrollpunkt | Ergebnis | Evidenz oder offene Folgeaktion |
|---|---|---|
| Scope, Lauf und Standards zugeordnet | OK | Feature 003, Branch und Standards oben dokumentiert |
| Direkte und transitive Menge vollständig | OK | `packages-all.json`, `licenses-shipped.json` |
| Bekannte Schwachstellen | OK: 0 | `packages-vulnerable.json` |
| Unbekannte oder unvereinbare Lizenzen | OK: 0 | `licenses-shipped.json` |
| Verifizierte Registry | OK | NuGet.org für 24 von 24 ausgelieferten Paketen |
| Lockfile | offen | kein Lockfile in diesem Feature; separates Governance-Intake erforderlich |
| Update-Automation | offen | kein Dependabot/Renovate/Dependency-Track in diesem Feature |
| SBOM/SLSA/Provenance | offen bis Lieferung | Exact-Head-Supply-Chain-Evidenz folgt in Feature 003 |
| VEX | N/A | keine bekannte Schwachstelle und kein Fehlalarm zu klassifizieren |
| Gesamtergebnis | lokal bestanden | Plattform- und Exact-Head-Gates bleiben vor Merge verbindlich |

## English review block

### Run evidence and decision

This audit covers TinyCalc Feature 003 on branch `003-terminalgui-migration`.
The local dependency gate passes: the shipped TUI graph contains one direct
dependency and 23 transitive dependencies, with zero known vulnerabilities,
zero unknown licenses, and zero incompatible licenses. Exact-head and pull
request evidence remain mandatory before delivery.

Applicable criteria are NIST SSDF, CWE Top 25, Microsoft secure coding guidance
for C#/.NET, SPDX license review, SBOM/VEX decision rules, SLSA as the target
model, and an OpenSSF Scorecard review of the public primary dependency. OWASP
ASVS is not applicable because this local TUI adds no web, HTTP, API, or
authentication surface. AI-SBOM is not applicable because AI is development
tooling only. Zero Trust is not applicable to the local single-process runtime;
a remote or service boundary would trigger reassessment. OWASP SAMM remains a
useful improvement framework for this long-lived repository.

### Results and disposition

All 24 shipped packages came from NuGet.org. `Terminal.Gui` 2.4.17 is the only
direct package and is bound to upstream commit
`d0a0ed9b150d3fc8aacf4ab07b7f7d91264fe6d6`. The remaining 23 packages are
transitive. The shared package table above identifies every package, version,
relationship, license, source, compatibility result, and distribution
disposition. Its 23 MIT licenses and one BSD-2-Clause license are all accepted.

The outdated report contains 48 project-specific direct or transitive results.
They are maintenance signals and do not authorize automatic changes. This
feature does not add Dependabot, Renovate, Dependency-Track, or a NuGet lockfile.
Those remain explicitly open governance work rather than silently satisfied
controls.

The decision is fail-closed. Any known vulnerability in a shipped package, or
any unknown or incompatible license, blocks delivery until an explicitly
authorized replacement or update is implemented and fully revalidated. VEX may
classify only a proven false positive or a component that is not shipped; it
cannot authorize a known shipped finding. A changed advisory, source, license,
or exact-head graph reopens this audit.

The detailed machine-readable evidence is under
`specs/003-terminalgui-migration/evidence/dependencies/`. The German audit
matrix and the shared table above are also authoritative for this English
review block.

## Referenzen / References

- Constitution Principles XII–XVIII
- NIST Secure Software Development Framework (SSDF)
- CWE Top 25 Most Dangerous Software Weaknesses
- Microsoft Secure Coding Guidelines for .NET
- SPDX License List and `licenses.nuget.org`
- OpenSSF Scorecard
- OWASP Software Assurance Maturity Model (SAMM)
