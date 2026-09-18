# Lokale Pruefevidence / Local verification evidence

## Stand / Status

Am 2026-09-18 auf macOS arm64 gestartet; PowerShell 7.6.6, Git 2.54.0,
Spec Kit 0.12.8. Installation unveraendert: v0.1.0, 26 Paketdateien.
Git-Ausgangsstand `31f4c729d0992823c6512d88d92d6a5bd9bbd63c` sauber,
volle Historie, Remote-main identisch; keine Partial-Clone-Konfiguration.

Started on macOS arm64 with the stated versions and unchanged package. The
initial checkout was clean, complete and matched remote main.

## Bisherige Pruefungen / Checks so far

| Pruefung / Check | Ergebnis / Result |
| --- | --- |
| Explizite 14er-Matrix, Bash und PowerShell CheckOnly | Je Exit 0 / each exit 0 |
| Payload gegen Receipt und frisch verifiziertes Tag-ZIP | 26/26 bytegleich / byte-identical |
| Init-Vorschau, dann Init im expliziten Pilotkontext | Exit 0; DRY_RUN / INITIALIZED |
| Installierte deterministische Suite | Exit 0; 67 Assertions, Unix, PowerShell 7.6.6 |
| YAML-Struktur | PASS |
| Kandidatenmessung, Paritaet und Read-only-Nachweis | Nach sauberem Inhaltscommit / after clean content commit |
| Native GitHub Linux-/Windows-Pruefung | Noch nicht ausgefuehrt / not yet executed |
| Fachliche Abnahme und Remote-Lieferung | Offen / open |

Die Fixture-Suite prueft erwartete Fehlerausgaenge 1 und 2 in temporaeren
Repositories. Das ist kein Nachweis fuer menschliche Abnahme oder Produkt-
Sicherheit. Der isolierte Kandidatentest folgt nach der ersten Messung.

The fixture suite checks expected exits 1 and 2 in temporary repositories.
It does not prove human acceptance or product security. Isolated candidate
checks follow the first measurement.
