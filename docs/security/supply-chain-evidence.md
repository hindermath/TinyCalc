# Supply-Chain-Evidenz: TinyCalc Feature 003

## Deutscher Prüfblock

### Laufnachweis und Geltungsbereich

| Feld | Wert |
|---|---|
| Projekt | TinyCalc, Level 2 |
| Feature | 003, Terminal.Gui-v2-Migration |
| Branch | `003-terminalgui-migration` |
| Baseline | `886a13f8866e79fe6c13e6e1227217294aabdee8` plus geprüfter Arbeitsbaum; Exact Head folgt |
| Datum | 2026-08-30 |
| Artefakt | lokaler Release-Ordner `src/MicroCalc.Tui/bin/Release/net10.0` |
| Owner | Feature 003 / Delivery |
| Reviewer | Supply-Chain- und PR-Review am unveränderten Exact Head |
| Standards | Constitution XIV/XVI, SPDX, SBOM, VEX, SLSA v1.2, OpenSSF Scorecard |
| Entscheidung | lokaler Paket-/SBOM-Gate bestanden; Provenance, Provider und Exact Head noch `Pending` |

Diese interne Evidenz dient der Audit- und Zertifizierungsvorbereitung. Sie
ersetzt keine externe Auditierung, Rechtsberatung oder formale Zertifizierung.

### Anwendbarkeitsmatrix

| Thema | Status | Begründung und Trigger |
|---|---|---|
| SBOM | anwendbar, lokal Pass | verteilbarer Release-Output; nach jedem neuen Build oder Exact-Head-Wechsel neu binden |
| AI-SBOM | N/A | KI ist ausschließlich Entwicklungswerkzeug; Trigger ist ein ausgeliefertes Modell, KI-Dienst, Datensatz, Inferenz- oder KI-Runtime-Bestandteil |
| VEX | N/A im aktuellen Graph | 0 bekannte Schwachstellen und kein Fehlalarm; Trigger ist ein belegter Fehlalarm oder eine bewertete nicht ausgelieferte Komponente |
| SLSA v1.2 / Provenance | anwendbar, Pending | aktuell keine verifizierbare Provenance-Attestation; Provider- und Exact-Head-Nachweis erforderlich |
| OpenSSF Scorecard | anwendbar, Review erfolgt | Upstream- und Eigenrepository wurden am 2026-08-30 geprüft; kein veröffentlichter Aggregatwert verfügbar |
| Dependency Automation | N/A für Feature 003 | kein genehmigter Dependabot-/Renovate-/Dependency-Track-/Lockfile-Scope; Trigger ist ein eigenes Supply-Chain-Intake |

### SPDX-SBOM

Ausgeführter Befehl:

```text
syft dir:src/MicroCalc.Tui/bin/Release/net10.0 -o spdx-json=docs/security/sbom/tinycalc-terminalgui.spdx.json
jq -e '.spdxVersion and .packages' docs/security/sbom/tinycalc-terminalgui.spdx.json
```

Syft 1.51.0, Schema 16.1.10, erzeugte auf `darwin/arm64` eine gültige
SPDX-2.3-JSON-Datei. `jq` endete mit Exitcode 0. Die SBOM enthält 29 Syft-
Einträge: alle 24 ausgelieferten NuGet-Pakete, die Anwendung, den gescannten
Ordner und getrennt erkannte native `libonigwrap`-Artefakte. Der
maschinenlesbare Lizenzbestand bestätigt 24 von 24 NuGet-Paketen und genau
Terminal.Gui 2.4.17.

| Artefakt oder Bindung | SHA-256 |
|---|---|
| SPDX-SBOM | `3193a0f53e962ccaac8741331203990ba727a7ca0901ef17a8e3403678ffb398` |
| Release-`MicroCalc.Tui.dll` | `0d36bd68e97d1b6025254514d67c9ec3655af4501f58d3f4ea9688c3be6488a1` |
| Release-`MicroCalc.Core.dll` | `e7100515a628e1260ba9b79fd064cf3e698c1f70f67ed1b7b7ddfdf25ab10eda` |
| `packages-all.json` | `7c717501d982e43a51b45cba70d8a2bdb181a67553106926bd06ce108344e2c0` |
| `packages-vulnerable.json` | `5a512fe3f66fb021353733e412c987ca854944f06c9ffc0a2d57a52274fd29e1` |
| `licenses-shipped.json` | `fe451cb2a9c14447078c549ed462ea5d2c9463711ba2947309a3e5ea256fb2a5` |

Die lokale Delivery-SHA-Zuordnung ist vollständig, aber noch nicht final. Nach
dem Feature-Commit wird die SBOM aus dem unveränderten PR-Head reproduziert
oder neu erzeugt und in T067 erneut gehasht. Eine Abweichung blockiert.

### Vollständiger ausgelieferter Paket- und Lizenzgraph

| Paket | Version | Beziehung | Lizenzquelle/SPDX | Paketquelle | Kompatibilität | Disposition |
|---|---:|---|---|---|---|---|
| `ColorHelper` | `1.8.1` | transitiv | `MIT`, licenses.nuget.org | NuGet.org | kompatibel | akzeptiert |
| `JetBrains.Annotations` | `2026.2.0` | transitiv | `MIT`, licenses.nuget.org | NuGet.org | kompatibel | akzeptiert |
| `Markdig` | `1.3.2` | transitiv | `BSD-2-Clause`, licenses.nuget.org | NuGet.org | kompatibel | akzeptiert |
| `Microsoft.Extensions.Configuration.Abstractions` | `10.0.7` | transitiv | `MIT`, licenses.nuget.org | NuGet.org | kompatibel | akzeptiert |
| `Microsoft.Extensions.Configuration.Binder` | `10.0.7` | transitiv | `MIT`, licenses.nuget.org | NuGet.org | kompatibel | akzeptiert |
| `Microsoft.Extensions.Configuration.FileExtensions` | `10.0.7` | transitiv | `MIT`, licenses.nuget.org | NuGet.org | kompatibel | akzeptiert |
| `Microsoft.Extensions.Configuration.Json` | `10.0.7` | transitiv | `MIT`, licenses.nuget.org | NuGet.org | kompatibel | akzeptiert |
| `Microsoft.Extensions.Configuration` | `10.0.7` | transitiv | `MIT`, licenses.nuget.org | NuGet.org | kompatibel | akzeptiert |
| `Microsoft.Extensions.DependencyInjection.Abstractions` | `10.0.9` | transitiv | `MIT`, licenses.nuget.org | NuGet.org | kompatibel | akzeptiert |
| `Microsoft.Extensions.FileProviders.Abstractions` | `10.0.7` | transitiv | `MIT`, licenses.nuget.org | NuGet.org | kompatibel | akzeptiert |
| `Microsoft.Extensions.FileProviders.Physical` | `10.0.7` | transitiv | `MIT`, licenses.nuget.org | NuGet.org | kompatibel | akzeptiert |
| `Microsoft.Extensions.FileSystemGlobbing` | `10.0.7` | transitiv | `MIT`, licenses.nuget.org | NuGet.org | kompatibel | akzeptiert |
| `Microsoft.Extensions.Logging.Abstractions` | `10.0.7` | transitiv | `MIT`, licenses.nuget.org | NuGet.org | kompatibel | akzeptiert |
| `Microsoft.Extensions.Options` | `10.0.9` | transitiv | `MIT`, licenses.nuget.org | NuGet.org | kompatibel | akzeptiert |
| `Microsoft.Extensions.Primitives` | `10.0.9` | transitiv | `MIT`, licenses.nuget.org | NuGet.org | kompatibel | akzeptiert |
| `Onigwrap` | `1.0.11` | transitiv | `MIT`, licenses.nuget.org | NuGet.org | kompatibel | akzeptiert |
| `System.IO.Abstractions` | `22.1.1` | transitiv | `MIT`, licenses.nuget.org | NuGet.org | kompatibel | akzeptiert |
| `Terminal.Gui` | `2.4.17` | direkt | `MIT`, licenses.nuget.org | NuGet.org | kompatibel | akzeptiert |
| `TestableIO.System.IO.Abstractions.Wrappers` | `22.1.1` | transitiv | `MIT`, licenses.nuget.org | NuGet.org | kompatibel | akzeptiert |
| `TestableIO.System.IO.Abstractions` | `22.1.1` | transitiv | `MIT`, licenses.nuget.org | NuGet.org | kompatibel | akzeptiert |
| `Testably.Abstractions.FileSystem.Interface` | `10.1.0` | transitiv | `MIT`, licenses.nuget.org | NuGet.org | kompatibel | akzeptiert |
| `TextMateSharp.Grammars` | `2.0.4` | transitiv | `MIT`, licenses.nuget.org | NuGet.org | kompatibel | akzeptiert |
| `TextMateSharp` | `2.0.4` | transitiv | `MIT`, licenses.nuget.org | NuGet.org | kompatibel | akzeptiert |
| `Wcwidth` | `4.0.1` | transitiv | `MIT`, licenses.nuget.org | NuGet.org | kompatibel | akzeptiert |

Die autoritativen Lizenztext-URLs, Repository-Metadaten und NUSPEC-Hashes
stehen vollständig in
`specs/003-terminalgui-migration/evidence/dependencies/licenses-shipped.json`.

### Schwachstellen und VEX-Disposition

Der maschinenlesbare NuGet.org-Scan meldet null bekannte Schwachstellen im
aktuellen direkten und transitiven Graph. Jede bekannte Schwachstelle in einer
ausgelieferten Komponente blockiert bis zu einem ausdrücklich autorisierten,
umgesetzten und vollständig geprüften Update oder Ersatz.

Es wird kein leeres VEX-Dokument erzeugt. VEX ist aktuell `N/A`, weil es weder
einen Fund noch einen Fehlalarm zu klassifizieren gibt. Ein späteres VEX darf
nur `not_affected` für einen belegten Fehlalarm oder eine bewertete, nicht
ausgelieferte Komponente dokumentieren. Es darf niemals eine bekannte
Schwachstelle im ausgelieferten Graph autorisieren.

### AI-SBOM-Disposition

AI-SBOM ist `N/A`. Codex und weitere KI-Agenten gehören zur Entwicklungs-
Toolchain, nicht zur ausgelieferten oder betriebenen TinyCalc-Anwendung. Das
Release enthält kein Modell, keinen KI-Dienst, keinen Trainings-, Fine-Tuning-,
Embedding- oder RAG-Datensatz und keine Inferenz-Infrastruktur. Eine spätere
KI-Runtime- oder Produktkomponente aktiviert die G7/BSI-Mindestelemente und
eine eigene AI-SBOM.

### Tatsächlicher SLSA-v1.2-/Provenance-Status

| SLSA-Aspekt | Tatsächlicher Status am 2026-08-30 |
|---|---|
| Source | Git-Baseline und Arbeitsbaum lokal gehasht; finaler Feature-Commit noch nicht erstellt |
| Build | lokaler macOS-Build mit dokumentierten Befehlen; kein vertrauenswürdiger Hosted-Builder-Nachweis für dieses Arbeitsbaum-Artefakt |
| Subject | lokale TUI-/Core-DLL- und SBOM-Hashes vorhanden |
| Provenance-Attestation | **nicht vorhanden**; keine signierte oder unabhängig verifizierbare SLSA-v1.2-Provenance für den aktuellen Output |
| SLSA Build Level | **kein Level behauptet**; vorhandene Logs und Hashes allein erfüllen keine höhere SLSA-Stufe |
| Nächster Gate | echte Providerjobs, unveränderter PR-Head und Schema-2.0-Evidenz; falls keine verifizierbare Attestation entsteht, bleibt der Level weiterhin unbelegt |

SLSA v1.2 ist als Ziel- und Bewertungsmodell anwendbar. Der ehrliche aktuelle
Status ist jedoch lokale Integritätsevidenz ohne verifizierbare Provenance-
Attestation. Weder GitHub-Logs noch Admin-Bypass dürfen als Ersatz für eine
Attestation oder als unbelegter SLSA-Level ausgegeben werden.

### Datierter OpenSSF-Scorecard-Review

Reviewzeit: `2026-08-30T13:53:59Z`. Die offizielle OpenSSF-Scorecard-API
lieferte für beide Repository-URLs HTTP 404. Es liegt daher kein veröffentlichter
aggregierter Scorecard-Bericht vor; es wird kein numerischer Score erfunden.
Die folgenden GitHub-Signale wurden mit der authentifizierten `gh`-CLI
read-only geprüft:

| Repository | gebundener Default-Head | Beobachtete positive Signale | Offene Signale/Disposition |
|---|---|---|---|
| `tui-cs/Terminal.Gui` | `48efa0c5c005763de035f2ee4afed28b7df98db3`, verifiziert, 2026-08-27 | öffentlich, MIT, aktiv gepflegt; 20 aktive Workflows, darunter Tests, CodeQL, Veröffentlichung und Dependabot | kein veröffentlichter Scorecard-Aggregatwert; klassische Branch-Protection-Regel nicht über GraphQL sichtbar; Security-Policy-URL vorhanden, Community-Datei nicht aufgelöst; Upstream-Risiko bleibt durch Pinning/Audit begrenzt |
| `hindermath/TinyCalc` | `886a13f8866e79fe6c13e6e1227217294aabdee8`, verifiziert, 2026-08-30 | öffentlich, MIT, aktiv gepflegt; aktive CI-, Secret-Scan-, Gitleaks- und Release-Workflows | kein veröffentlichter Scorecard-Aggregatwert; kein Dependabot, CodeQL oder Security-Policy-Dokument im aktuellen Repo; klassische Branch-Protection-Regel nicht sichtbar, formale Rulesets werden beim Delivery-Gate geprüft |

Die offenen Scorecard-Signale sind dokumentierte Verbesserungsbefunde, aber
kein Auftrag, Feature 003 um neue Automation, Policy oder Workflows zu
erweitern. Owner ist der Repository-Maintainer; Trigger ist ein separates
Security-/Supply-Chain-Intake oder ein konkreter Release-Blocker.

Viewer-Links:

- [Terminal.Gui OpenSSF Scorecard Viewer](https://securityscorecards.dev/viewer/?uri=github.com%2Ftui-cs%2FTerminal.Gui)
- [TinyCalc OpenSSF Scorecard Viewer](https://securityscorecards.dev/viewer/?uri=github.com%2Fhindermath%2FTinyCalc)

### Offene Lieferpunkte

| ID | Finding | Risiko | Owner | Abschluss |
|---|---|---|---|---|
| SC-003-01 | SBOM noch nicht an finalen PR-Head gebunden | hoch | Feature 003 | T067 reproduziert Hash am Exact Head |
| SC-003-02 | keine verifizierbare SLSA-v1.2-Provenance-Attestation | mittel | Delivery | Status ehrlich beibehalten; nur vorhandene Attestation darf Level ändern |
| SC-003-03 | Linux-/Windows-Produktjobs noch nicht ausgeführt | hoch | Feature 003 | T066 mit exakten Produktbefehlen |
| SC-003-04 | kein veröffentlichter OpenSSF-Aggregatwert für beide Repos | mittel | Repository-Maintainer | separates Improvement-Intake; kein Feature-003-Scope |
| SC-003-05 | keine Dependency-Automation oder Lockfile | mittel | Repository-Maintainer | separates genehmigtes Supply-Chain-Feature |

Lokaler Gate-Status: 0 bekannte Schwachstellen, 0 unbekannte oder
unvereinbare Lizenzen und eine gültige SPDX-SBOM. Delivery bleibt `Pending`,
bis Provider, Review und Exact Head vollständig belegt sind.

## English review block

### Scope and local result

This evidence covers the local Feature 003 release directory and applies SPDX
SBOM, AI-SBOM disposition, VEX rules, SLSA v1.2 provenance assessment, and an
OpenSSF Scorecard review. The local package/SBOM gate passes; provider,
provenance, and exact-head evidence remain pending.

Syft 1.51.0 generated a valid SPDX 2.3 JSON SBOM with 29 Syft entries. It
contains all 24 shipped NuGet packages, including exactly Terminal.Gui 2.4.17.
The shared hash table binds it to the local TUI and Core DLLs. The full package
table records relationship, license source/SPDX expression, NuGet.org source,
compatibility, and disposition for every shipped package.

The graph has zero known vulnerabilities and zero unknown or incompatible
licenses. A known shipped vulnerability or unresolved license blocks delivery.
VEX is currently not applicable and may later classify only a proven false
positive or a component that is not shipped. AI-SBOM is not applicable because
AI is development tooling only and no AI component is shipped or operated.

### Provenance and OpenSSF review

SLSA v1.2 is applicable as an assessment model, but the current output has no
signed or independently verifiable provenance attestation. Therefore no SLSA
Build Level is claimed. Local hashes and provider logs must not be presented as
an attestation.

At `2026-08-30T13:53:59Z`, the official OpenSSF API returned HTTP 404 for both
Terminal.Gui and TinyCalc, so no published aggregate score exists and none is
invented. The manual GitHub signal review found active maintenance, MIT
licenses, verified recent heads, and active CI in both repositories. Terminal.Gui
also exposes test, CodeQL, publishing, and Dependabot workflows. TinyCalc has
CI, secret scanning, Gitleaks, and release workflows but no local Dependabot,
CodeQL, or security-policy file. These are improvement findings, not authority
to expand Feature 003.

Delivery remains pending until Linux and Windows jobs, final review, and every
primary gate bind to the unchanged pull-request head. Any SBOM, graph, source,
advisory, license, or head mismatch blocks delivery.

## Evidenz und Referenzen / Evidence and References

- `docs/security/sbom/tinycalc-terminalgui.spdx.json`
- `specs/003-terminalgui-migration/evidence/sbom-generation.md`
- `docs/security/dependency-audit.md`
- `specs/003-terminalgui-migration/evidence/dependencies/`
- [SLSA v1.2](https://slsa.dev/spec/v1.2/)
- [OpenSSF Scorecard](https://securityscorecards.dev/)
- Constitution Principles XIV and XVI
