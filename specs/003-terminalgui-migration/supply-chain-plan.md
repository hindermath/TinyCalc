# Lieferkettenplan / Supply-chain Plan

## SBOM

Nach erfolgreichem Release-Build erzeugt das lokal verfügbare Syft `1.51.0`
eine SPDX-JSON-SBOM aus dem auslieferbaren TUI-Drop:

*After a successful Release build, locally available Syft `1.51.0` creates an
SPDX JSON SBOM from the releasable TUI drop:*

```powershell
syft version
syft dir:src/MicroCalc.Tui/bin/Release/net10.0 -o spdx-json=docs/security/sbom/tinycalc-terminalgui.spdx.json
jq -e '.spdxVersion and .packages' docs/security/sbom/tinycalc-terminalgui.spdx.json
```

Die Begleitdatei `docs/security/supply-chain-evidence.md` nennt Toolversion,
Commit-SHA, Quellverzeichnis, SHA-256 der SBOM, Paketgraph, Audit-Ergebnis und
für jede direkte/transitive ausgelieferte Abhängigkeit Lizenz, Quelle,
Kompatibilität und Disposition.

*The companion supply-chain evidence records tool version, commit SHA, source
directory, SBOM SHA-256, package graph, audit result, and every shipped direct
or transitive dependency's licence, source, compatibility, and disposition.*

## Schwachstellen und Lizenzen / Vulnerabilities and Licences

Die Abschlussprüfung ist fail-closed: In keiner ausgelieferten direkten oder
transitiven Abhängigkeit darf eine bekannte Schwachstelle verbleiben. VEX darf
nur einen Fehlalarm oder eine bewertete nicht ausgelieferte Komponente
klassifizieren; es darf niemals den Versand einer bekannt verwundbaren
Abhängigkeit autorisieren. Ein bekannter ausgelieferter Fund blockiert, bis
Update oder Ersatz ausdrücklich autorisiert und abgeschlossen ist. Die
Paketänderung bleibt auf den bindenden Intake und Version `2.4.17` begrenzt;
ein Blocker erfordert neue Autorität statt eines stillen Versionswechsels.

*Final review is fail-closed: no known vulnerability may remain in a shipped
direct or transitive dependency. VEX may classify only a false positive or an
evaluated non-shipped component; it can never authorise shipping a known-
vulnerable dependency. A known shipped finding blocks until update or
replacement is explicitly authorised and complete. Package change remains
bounded to the binding intake and version `2.4.17`; a blocker requires new
authority rather than a silent version change.*

Der Dependency Audit und die Supply-Chain-Evidence erfassen für jedes direkte
und transitive ausgelieferte Paket die Lizenzkennung beziehungsweise den
autoritativen Lizenztext, die Metadatenquelle, die Kompatibilität mit TinyCalc
und die abschließende Disposition. Vor Delivery müssen null unbekannte und null
inkompatible ausgelieferte Lizenzen verbleiben.

*The dependency audit and supply-chain evidence record each shipped direct and
transitive package's licence identifier or authoritative licence text, metadata
source, compatibility with TinyCalc, and final disposition. Delivery requires
zero unknown and zero incompatible shipped licences.*

## SLSA und Provenienz / SLSA and Provenance

SLSA v1.2 ist anwendbar, weil CI und ein verteilbares Artefakt existieren. Der
Nachweis ist der reale Status, keine Zielbehauptung:

*SLSA v1.2 applies because CI and a distributable artefact exist. Evidence
states actual status, not an aspirational claim:*

```powershell
git rev-parse HEAD
gh run list --branch 003-terminalgui-migration --limit 20
gh run view <run-id> --json headSha,event,status,conclusion,jobs,url
gh run view <run-id> --job <job-id> --log
```

Der Bericht prüft Source/Build/Provenance-Anforderungen. Ohne unveränderliche,
verifizierbare Attestation wird kein SLSA-Level oberhalb des wirklich belegten
Status genannt. Linux- und Windows-Produktjobs müssen die exakten Restore-,
Build-, Test- und Smoke-Kommandos zeigen.

*The report checks source, build, and provenance requirements. Without an
immutable verifiable attestation, no SLSA level above the evidenced status is
stated. Linux and Windows product jobs must show exact restore, build, test,
and smoke commands.*

## Weitere Artefakte / Other Artefacts

| Artefakt / Artefact | Status | Behandlung / Treatment |
|---|---|---|
| OpenSSF Scorecard | Applicable | Upstream `tui-cs/Terminal.Gui` und TinyCalc prüfen; Datum/Commit/Ergebnis dokumentieren. |
| VEX | N/A, bedingt | Disposition in `docs/security/supply-chain-evidence.md`; nur Fehlalarme oder nicht ausgelieferte Komponenten klassifizieren, niemals einen bekannten ausgelieferten Fund freigeben. |
| AI-SBOM | N/A | KI ist ausschließlich Entwicklungswerkzeug; Trigger ist eine KI-Runtime-/Produktkomponente. |
| Dependency Track | N/A | keine Server-/Automationsfreigabe; Trigger ist eigenes Supply-Chain-Feature. |
| Signierte Release-Attestation | N/A für diesen Scope | Trigger ist Release-/Workflow-Scope oder Repository-Policy. |

## Fail-safe Gate

Fehlende SBOM, inkonsistente Paketversion, jede bekannte Schwachstelle in einer
ausgelieferten Abhängigkeit, eine unbekannte oder inkompatible ausgelieferte
Lizenz, unklarer Provenienzstatus oder ein behauptetes, aber unbelegtes
SLSA-Level blockiert Delivery.

*A missing SBOM, inconsistent package version, any known vulnerability in a
shipped dependency, an unknown or incompatible shipped licence, unclear
provenance status, or unsupported SLSA-level claim blocks delivery.*
