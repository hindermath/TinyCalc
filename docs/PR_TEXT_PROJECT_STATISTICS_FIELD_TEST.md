# Statistik-Pilot TinyCalc / TinyCalc statistics pilot

## Zusammenfassung und Problem / Summary and problem

Das installierte 14. Preset benoetigt einen eigenstaendigen praktischen
Feldnachweis im .NET-Projekt. Dieser PR ergaenzt einen getrennten Messkontext,
reproduzierbare Nachweise und native CI. Bestehende Statistiken bleiben kanonisch.

The installed fourteenth preset needs project-specific field evidence. This
PR adds an isolated measurement context and native CI without replacing legacy statistics.

## Loesung und Umfang / Solution and scope

- [x] Dokumentation / Documentation
- [x] CI/CD und Statistik-Fixtures / CI/CD and statistics fixtures
- [ ] MicroCalc.Core oder MicroCalc.Tui Produktcode / product code
- Keine Runtime-, API-, Versions- oder Funktionsaenderung. / No runtime, API, version or feature change.
- Anleitung, Quellenbindung und Grenzen: [Pilot](project-statistics-pilot/README.md).
- Ergebnisse und lokale Evidence: [Pruefbericht](project-statistics-pilot/local-evidence.md).

## Pruefung und Risiken / Validation and risks

Lokale Preset-Fixtures, Bash-/PowerShell-Status, Encoding-Paritaet,
Read-only-Hashes und Renderer pruefen die Statistik. Native Linux-/Windows-CI,
bestehende .NET-Builds/Tests/Smoke und fachliche Abnahme bleiben vor Lieferung
erforderlich. Keine interaktive TUI- oder neue Produktabnahme behauptet.
Hauptrisiko ist die Verwechslung von Git-Umfang mit Qualitaet oder Produktivitaet;
Referenzen sind aus und der Bericht benennt diese Grenze ausdruecklich.

Local fixtures, status parity, encoding, read-only hashes and renderers validate
statistics. Native CI and existing product checks remain delivery gates; no
interactive TUI acceptance is inferred. Git size/activity is not quality or
productivity. Reference estimates stay disabled.

## Dokumentation und Lieferung / Documentation and delivery

`UpdateRequired` fuer Anleitung/CI; getrennte `GeneratedUpdate` fuer Statistiken.
Owner Thorsten Hindermann; DE/EN, text-first, nur Projektquellen, kein Home-Sync.
Re-Evaluation bei Quellen-, Paket-, Kontext- oder Runner-Aenderung.
Review, Check-Abnahme und exakter Head muessen vor Merge erneut geprueft werden.
Keine automatische stabile Veroeffentlichung oder Community-Einreichung.

Review, green checks and exact head must be verified before merge. No automatic
stable release or community submission. Human acceptance remains separate.

Refs https://github.com/hindermath/TinyCalc/issues/84
Refs https://github.com/hindermath/spec-kit-preset-project-statistics-governance/issues/1
