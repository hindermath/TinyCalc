# Archiv-Wegweiser / Archive Navigation

## Deutsch: unveraenderter Snapshot und gueltige Navigation

Dieses Verzeichnis bewahrt Manifest, Receipt, Operation und Reihenfolge der
TinyCalc-Lieferserie vor der Governance-Aktualisierung vom 2026-10-06. Die
gebundenen Dateien bleiben unveraendert. Deshalb verwenden die relativen Links
in `order.md` weiterhin den Basispfad des damaligen aktiven Serienverzeichnisses
und sind an dieser Archivposition nicht direkt nutzbar. Dieser ergaenzende
Wegweiser stellt gueltige, unveraenderliche Verbindungen bereit, ohne den
hashgebundenen Snapshot umzuschreiben.

Lokale Snapshot-Nachweise: [Manifest](manifest.json), [Receipt](receipt.json),
[Operation](operation.json) und [unveraenderte Reihenfolge](order.md).
Der zugehoerige fruehere Review wurde getrennt archiviert:
[Review-Supersession](../20261006-macos15-governance-refresh-review/superseded-review.json),
[Review-Request](../20261006-macos15-governance-refresh-review/intake-review-request.json),
[Review-Ergebnis](../20261006-macos15-governance-refresh-review/intake-review-result.json)
und [Review-Bericht](../20261006-macos15-governance-refresh-review/intake-review-report.md).

Die folgende Tabelle bildet alle 13 Mitglieder auf den unveraenderlichen
Git-Stand ab, aus dem dieser Serien-Snapshot entstand. Positionen, Status,
Abhaengigkeiten und Hashes bleiben im lokalen Manifest verbindlich.

| Position | Historischer Vertrag / Historical contract |
|---:|---|
| 1 | [Constitution](https://github.com/hindermath/TinyCalc/blob/09156155a571d94e29a2cd27c3d568f0fbcecc7a/requirements/intakes/archive/Lastenheft_Constitution_Change.002-constitution-change.md) |
| 2 | [Terminal.Gui](https://github.com/hindermath/TinyCalc/blob/09156155a571d94e29a2cd27c3d568f0fbcecc7a/requirements/intakes/archive/Lastenheft_TerminalGui_Migration.003-terminalgui-migration.md) |
| 3 | [TUI-Funktionsabnahme](https://github.com/hindermath/TinyCalc/blob/09156155a571d94e29a2cd27c3d568f0fbcecc7a/requirements/intakes/active/Lastenheft_TUI-Funktionsabnahme-und-Regressionsvertrag.md) |
| 4 | [A11Y](https://github.com/hindermath/TinyCalc/blob/09156155a571d94e29a2cd27c3d568f0fbcecc7a/requirements/intakes/active/Lastenheft_A11Y_TUI.md) |
| 5 | [Rename](https://github.com/hindermath/TinyCalc/blob/09156155a571d94e29a2cd27c3d568f0fbcecc7a/requirements/intakes/active/Lastenheft_Rename_MicroCalc_TinyCalc.md) |
| 6 | [Didaktik / Didactic](https://github.com/hindermath/TinyCalc/blob/09156155a571d94e29a2cd27c3d568f0fbcecc7a/requirements/intakes/active/Lastenheft_Didactic-Inline-Code-Comment-Hardening.md) |
| 7 | [Security](https://github.com/hindermath/TinyCalc/blob/09156155a571d94e29a2cd27c3d568f0fbcecc7a/requirements/intakes/active/Lastenheft_Secure-Development-Hardening.md) |
| 8 | [PL/0](https://github.com/hindermath/TinyCalc/blob/09156155a571d94e29a2cd27c3d568f0fbcecc7a/requirements/intakes/active/Lastenheft_PL0-Zellfunktionen_V1.md) |
| 9 | [Legacy](https://github.com/hindermath/TinyCalc/blob/09156155a571d94e29a2cd27c3d568f0fbcecc7a/requirements/intakes/active/Lastenheft_Legacy-Kompatibilitaet_V1.md) |
| 10 | [Tabellenoperationen / Sheet operations](https://github.com/hindermath/TinyCalc/blob/09156155a571d94e29a2cd27c3d568f0fbcecc7a/requirements/intakes/active/Lastenheft_Formelkopie-und-Tabellenoperationen_V1.md) |
| 11 | [Sandbox](https://github.com/hindermath/TinyCalc/blob/09156155a571d94e29a2cd27c3d568f0fbcecc7a/requirements/intakes/active/Lastenheft_Sandbox-gestuetzte-Secure-Development-Haertung.md) |
| 12 | [RL-SE](https://github.com/hindermath/TinyCalc/blob/09156155a571d94e29a2cd27c3d568f0fbcecc7a/requirements/intakes/archive/Lastenheft_RL-SE-Checklist-Selbstpruefung.004-rl-se-self-assessment.md) |
| 13 | [GSDB](https://github.com/hindermath/TinyCalc/blob/09156155a571d94e29a2cd27c3d568f0fbcecc7a/requirements/intakes/archive/Lastenheft_GSDB-Spec-Kit-Intensivpruefung.005-gsdb-intensive-review.md) |

Historische Feature-Nachweise: [002 Constitution](../../../../../specs/002-constitution-change/),
[004 RL-SE](../../../../../specs/004-rl-se-self-assessment/) und
[005 GSDB](../../../../../specs/005-gsdb-intensive-review/). Die uebrigen
Mitglieder hatten in diesem Snapshot keinen Feature-Verweis.

## English: unchanged snapshot and valid navigation

This directory preserves the TinyCalc delivery-series manifest, receipt,
operation, and order from before the 2026-10-06 governance update. The bound
files remain unchanged. Their relative links still use the former live-series
base path and therefore do not work directly from this archive location. This
companion file provides valid, immutable navigation without rewriting the
hash-bound snapshot.

The links above expose the local snapshot and its separately archived review.
The table maps all 13 members to the immutable Git revision from which the
series snapshot was created. The local manifest remains authoritative for
positions, status, dependencies, and hashes. The three feature links point to
existing local directories; the other members had no feature link in this
snapshot. This navigation aid changes no requirement, lifecycle state,
dependency, review decision, or delivery authority.
