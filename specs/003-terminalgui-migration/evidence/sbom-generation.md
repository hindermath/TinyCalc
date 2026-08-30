# SPDX-SBOM-Erzeugung / SPDX SBOM Generation

## Deutscher Nachweis

Stand: 2026-08-30, macOS `darwin/arm64`

Baseline: `886a13f8866e79fe6c13e6e1227217294aabdee8` plus geprüfter
Feature-003-Arbeitsbaum

Ausgeführter Befehl:

```text
syft dir:src/MicroCalc.Tui/bin/Release/net10.0 -o spdx-json=docs/security/sbom/tinycalc-terminalgui.spdx.json
```

Validierung:

```text
jq -e '.spdxVersion and .packages' docs/security/sbom/tinycalc-terminalgui.spdx.json
```

Beide Befehle endeten mit Exitcode `0`. Verwendet wurde Syft 1.51.0,
Schema 16.1.10, auf `darwin/arm64`. Die Quelle ist ausschließlich der bereits
gebaute Release-Ordner `src/MicroCalc.Tui/bin/Release/net10.0`.

Die erzeugte Datei verwendet SPDX 2.3, ist 86.298 Byte groß und enthält 29
Syft-Einträge. Dazu gehören alle 24 ausgelieferten NuGet-Pakete, die
Anwendung, der gescannte Ordner und von Syft getrennt erkannte native
`libonigwrap`-Artefakte. Der Abgleich gegen `licenses-shipped.json` bestätigt
24 von 24 NuGet-Paketen; `Terminal.Gui` ist genau einmal in Version 2.4.17
enthalten.

| Artefakt | SHA-256 |
|---|---|
| `docs/security/sbom/tinycalc-terminalgui.spdx.json` | `3193a0f53e962ccaac8741331203990ba727a7ca0901ef17a8e3403678ffb398` |
| Release-`MicroCalc.Tui.dll` | `0d36bd68e97d1b6025254514d67c9ec3655af4501f58d3f4ea9688c3be6488a1` |
| Release-`MicroCalc.Core.dll` | `e7100515a628e1260ba9b79fd064cf3e698c1f70f67ed1b7b7ddfdf25ab10eda` |

Diese Zuordnung bindet die lokale SBOM an genau den geprüften Release-Output.
Sie ist noch kein Exact-Head-Liefernachweis. Nach dem Feature-Commit muss die
SBOM aus dem unveränderten PR-Head reproduziert oder neu erzeugt und in T067
erneut gehasht werden. Eine Abweichung blockiert die Lieferung.

## English evidence

Both the Syft generation command and the exact `jq` validation command exited
zero. Syft 1.51.0 with schema 16.1.10 scanned only the existing
`src/MicroCalc.Tui/bin/Release/net10.0` output on `darwin/arm64`.

The 86,298-byte SPDX 2.3 document contains 29 Syft entries: all 24 shipped
NuGet packages, the application, the scanned directory, and native
`libonigwrap` artifacts identified separately by Syft. Cross-checking the
license inventory finds all 24 NuGet packages, with exactly one Terminal.Gui
2.4.17 entry.

The shared SHA-256 table above binds the SBOM to the local TUI and Core release
DLLs. This is not exact-head delivery evidence yet. After the feature commit,
the SBOM must be reproduced or regenerated from the unchanged pull-request
head and rehashed in T067. Any mismatch blocks delivery.
