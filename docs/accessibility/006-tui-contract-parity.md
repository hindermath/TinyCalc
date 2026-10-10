# Native Scriptparität / Native script parity

## Deutscher Nachweisblock

Feature 006, Stand 2026-10-10. [Vertragsleitfaden](../contracts/tui/README.md)
und [Manpage](../man/test-tinycalc-contract.1.md) sind textfirst und DE/EN.
`test-launchers.ps1` führt tatsächliche CLI-/Cmdlet-/Hilfepfade aus, statt
Befehlsnamen als Pass zu zählen. Fehlende vollständige Evidence bleibt Exit 2.

Prüfumfang: PowerShell normal und WhatIf, dot-sourced Cmdlet, identische
kanonische JSON-Befunde/Counts/Digests, vollständige bilinguale Parameterhilfe,
kein ANSI, leeres stderr und unveränderte Repositorybytes. Bash normal und
dry-run sind zusätzlich auf macOS/Linux Pflicht; nicht als Windows-Pflicht
oder ungetesteter Windows-Pass ausgeben. Die vorhandene Manpage erklärt
dieselben Optionen, Exitcodes und schreibfreien Grenzen.

macOS: tatsächlicher früherer Lauf `006-launchers-final.log`, Exit 0,
SHA-256 `b4b11c9269fb3228ba148f2b4aff17070622e6130d32563f57cdb4d396e1a526`.
Das ist lokaler Zwischenbeleg, kein neuer finaler Headnachweis.

Linux/Windows: `ci.yml`, Job `build-test (ubuntu-latest/windows-latest)`,
Step `Validate native launcher and zero-write parity`. Tatsächlicher Befehl
`pwsh -NoProfile -File scripts/tests/tui-contract/test-launchers.ps1`.
Eigenes `TestResults/launcher-parity.log` wird mit den nativen Artefakten
hochgeladen; Fehlerstatus propagiert unverändert. Bis der jeweilige aktuelle
Run erfolgreich beendet ist, bleibt dieser Plattformnachweis Open. Ein grüner
Workflow-Strukturtest oder geplantes Uploadziel ist kein Ausführungsnachweis.
T064 bleibt für vollständige native/finale Parität offen. Der neue Workflow-
Ablehnungsfall war zuerst rot; danach bestehen sieben Guards einschließlich
sechs Abschwächungen. Das belegt Schutzlogik, nicht native Ausführung.

## English evidence block

The text-first bilingual guide/manpage document the same options, exit codes
and read-only boundaries. Actual launcher tests compare PowerShell normal and
preview, the dot-sourced cmdlet, canonical diagnostics/counts/digests, bilingual
help, no ANSI/standard error and zero repository writes. Bash normal/dry-run
additionally applies on macOS/Linux, never as invented Windows proof.

The hashed macOS log is a real historical local checkpoint, not a new final
head. Native Linux/Windows CI executes the listed command and uploads its own
log with native artefacts, propagating failures. Both platform proof and T064
remain Open until actual current executions and final bindings are available.
The new workflow rejection first failed, then all seven guards passed,
including six deliberate weakenings; this is not native execution proof.
