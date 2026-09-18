# TinyCalc-Statistik-Feldtest / TinyCalc statistics field test

## Zweck und Status / Purpose and status

Dieser getrennte Pilot prueft Project Statistics Governance v0.1.0 an einem
C#/.NET-Ausbildungsprojekt. Er liefert reproduzierbare Projekttransparenz,
keine Personenrangliste, Qualitaetsbewertung oder gemessene KI-Zeitersparnis.
Die bestehende [Projektstatistik](../project-statistics.md) bleibt kanonisch.
Fachliche Pilotabnahme, native CI und Lieferung bleiben offen, bis ihre
konkreten Nachweise vorliegen. Installation allein bedeutet keine Abnahme.

This separate pilot tests v0.1.0 in a C#/.NET training project. It provides
reproducible project transparency, not people ratings, quality scores or
measured AI time savings. Existing statistics remain authoritative. Human
acceptance, native CI and delivery remain open until explicitly evidenced.

## Quellen und Kontext / Sources and context

- [Projekttracking / Project tracking](https://github.com/hindermath/TinyCalc/issues/84)
- [Zentrales Tracking / Central tracking](https://github.com/hindermath/spec-kit-preset-project-statistics-governance/issues/1)
- [Installation und Herkunft / Installation and provenance](../maintenance/project-statistics-installation-v010.md)
- [Messbericht / Measurement report](report.md), [Snapshot](snapshot.json),
  [Konfiguration / Configuration](config.json).
- Paket / package: v0.1.0, Commit `7e824ca8de11212aefdc5b05d7d05637f5343dab`.
- ZIP SHA-256: `d8ad7d5eef920f50b629121b64ba8123c22ec4f6dadd14da5cd826d1c50f420a`.
- Ausgangsstand / baseline: `31f4c729d0992823c6512d88d92d6a5bd9bbd63c`.

Am 18.09.2026 wurde das veroeffentlichte Pre-Release erneut aufgeloest und das
Tag-ZIP frisch geprueft. Alle 26 installierten Paketdateien stimmen bytegenau
mit Archiv und Installationsreceipt ueberein. Bash und PowerShell bestaetigen
exakt 14 aktive Presets mit den vorgesehenen Versionen und Prioritaeten.
Keine durch GitHub erzwungene Release-Unveraenderbarkeit wird behauptet.

The release and archive were freshly checked on 2026-09-18. All 26 installed
payload files match the archive and receipt byte for byte; both installer
check-only entrypoints confirm the exact fourteen-preset profile. This does
not claim platform-enforced release immutability.

Die Konfiguration verwendet `project-transparency/1`, UTC und 52 Wochen.
Referenzrechnungen sind ausgeschaltet. Quellrevision und Stichtag stehen im
Snapshot; der Pilotordner wird automatisch von seiner Messung ausgeschlossen.
Die bestehende Profil-2-Statistik verwendet weiterhin Europe/Berlin und ihre
unveraenderten Referenzen 80/125. Unterschiedliche Aktivtage sind deshalb
moeglich und keine personenbezogene Leistungsmessung.

The pilot uses UTC, 52 weeks and disabled reference estimates. Its snapshot
binds revision and cutoff; its own context is excluded from measurement.
Existing Profile 2 keeps Europe/Berlin and references 80/125 unchanged.
Different active-day counts can therefore be valid and do not rate people.

## Bedienung und Pruefung / Operation and verification

Zuerst den aktuellen Git-Stand und die Konfiguration pruefen. Status schreibt
nichts. Update benoetigt einen ausdruecklichen Auftrag, Vorschau und sauberen
Arbeitsbaum. Fachliche Quellen vor Messung committen; erzeugte Ausgaben danach
getrennt committen. Kein Fetch, Tool-Install oder Git-Delivery durch das Preset.

First inspect Git state and configuration. Status is read-only. Update needs
explicit authority, preview and a clean worktree. Commit authored sources
before measurement, then generated outputs separately. The preset performs
no fetch, tool installation or Git delivery.

```bash
bash .specify/presets/project-statistics-governance/scripts/project-statistics.sh status --repo . --config docs/project-statistics-pilot/config.json --json
bash .specify/presets/project-statistics-governance/scripts/project-statistics.sh update --repo . --config docs/project-statistics-pilot/config.json --dry-run --json
```

```powershell
pwsh -NoProfile -File .specify/presets/project-statistics-governance/scripts/project-statistics.ps1 -Action Status -Repo . -Config docs/project-statistics-pilot/config.json -Json
```

Der neue native Workflow prueft den aktuellen Kandidaten und dessen eigenen
Messstand auf Ubuntu und Windows. Er verwendet keine historischen Home-Pins.
Eine getrennte temporaere Arbeitskopie prueft LF/CRLF, mit/ohne UTF-8-BOM und
Read-only-Hashes; rohe Git-Blobs umgehen absichtlich Clean-Filter.
Die installierte Suite prueft Drift (Exit 1), fehlende Voraussetzungen und
ungueltige Eingaben (Exit 2), erfolgreiche aktuelle Ergebnisse (Exit 0).
Windows prueft PowerShell; Bash-/Unix-only-Faelle werden dort nicht behauptet.

Native CI validates the current candidate and its own measurement on Ubuntu
and Windows without historical Home pins. Isolated fixtures test encoding
parity, read-only hashes and raw blobs without Git clean-filter normalization.
Installed tests cover expected exit codes 0/1/2. Windows proves PowerShell;
it does not prove Bash or Unix-only behavior. Hash evidence is not a full I/O trace.

## Dokumentationsauswirkung und Grenzen / Documentation impact and limits

`UpdateRequired` fuer Pilotanleitung und CI-Nachweis; `GeneratedUpdate` fuer
die jeweiligen separat erzeugten Statistikbloecke. Owner: Thorsten Hindermann.
Zielgruppen: Lernende, Maintainer, Reviewer. Leserpfad: Installation -> dieser
Pilot -> Messbericht -> technische Evidence -> menschliche Sichtung.
Kanonische Quellen: gepinnte Preset-Produktquelle, Projekt-Git und Konfiguration.
ActiveSemantic; DE zuerst/EN danach; lokale Projektdateien, kein Runtime-Sync.
Wiedervorlage bei Paket-, Konfigurations-, Quellen-, Runner- oder Umfangswechsel.
Keine neue Produkt-API, Runtime, Referenzbasis, Feature-Reihenfolge oder
Agenten-Regel; Constitution und gemeinsame Guidance bleiben unveraendert.

Documentation impact is UpdateRequired for pilot guidance/CI and separately
GeneratedUpdate for rendered statistics. The maintainer owns these bilingual,
text-first project-local records. Reevaluate when package, configuration,
source, runner or scope changes. No API, runtime, reference baseline, feature
order or shared agent rule changes; no Home Runtime sync.

NIST SSDF und CWE Top 25 gelten fuer die begrenzte Skript-/Lieferkettenpruefung;
SLSA wird durch Quellen-/Hashbindung unterstuetzt, ohne Level-Behauptung.
ASVS und KI-Runtime-SBOM: N/A, keine Web/API- oder Modellruntime-Aenderung.
Kein Produktartefakt, daher kein neuer SBOM/VEX- oder Zertifizierungsanspruch.
Keine Architektur-/Zero-Trust-Aenderung. TDD und Changed-Code-Coverage fuer
Produktcode N/A; Workflow-Logik erhaelt ausfuehrbare Tests und statische Pruefung.
Lokale .NET-Builds werden in diesem reinen Pilotdelta nicht gestartet, um den
verbindlichen Buildzaehler nicht ohne Produktauftrag zu aendern. Die bestehenden
Build-/Test-/Smoke-Checks bleiben vor Merge Pflicht; keine neue TUI-Abnahme.

Security scope covers script and source provenance, not product security
effectiveness or compliance. No product code changes or local build-counter
mutation; existing CI build/test/smoke gates remain mandatory before merge.
Human acceptance, central field report, stable release and community submission
are separate decisions. Tracking remains open until the central report merges.
