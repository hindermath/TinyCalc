# PR: Secure Development Assurance Governance v0.1.0 fuer TinyCalc installieren

## Problem

TinyCalc verwendet das zwoelfteilige Governance-Profil. Fuer den kontrollierten
Feldtest aus `hindermath/home-baseline#268` und `hindermath/TinyCalc#66` fehlen
noch der portable Evidence-Vertrag sowie die beiden read-only beziehungsweise
reviewgebundenen Secure-Development-Assurance-Oberflaechen.

## Loesung

- das unveraenderliche Release-ZIP von
  `secure-development-assurance-governance` v0.1.0 mit dem freigegebenen
  SHA-256
  `d9effc395e590d1ffe832d059f8681501da1d1b6e7d44d79a3e61929bc5229c1`
  geprueft und installiert
- das optionale 13-Preset-Profil aktiviert; das neue Preset hat Prioritaet 15,
  waehrend `security-governance` v0.6.2 unveraendert Prioritaet 10 behaelt
- `$speckit-secure-development-status` und
  `$speckit-secure-development-review` fuer Codex und Claude sowie die
  entsprechenden Copilot- und OpenCode-Befehlsflaechen erzeugt
- den portablen `secure-development-evidence-contract` als neue
  Preset-Schnittstelle installiert
- Documentation Impact und Projektstatistik fuer die Installation
  fortgeschrieben

Die Installation startet keinen Spec-Kit-Lauf und veraendert weder
TinyCalc-Produktcode noch Produkt-API. Das wegen
`hindermath/absdd-image-sandbox#52` ausgeschlossene Sandbox-Lastenheft bleibt
ausserhalb dieses PRs.

## Documentation Impact

Entscheidung: `GeneratedUpdate`. Kanonische Quelle ist das installierte,
hashgepruefte Preset unter
`.specify/presets/secure-development-assurance-governance/`; die Spec-Kit-
Preset-Installation erzeugt daraus die Agenten- und Command-Flaechen. Die
Projektstatistik wird aus Git-Historie und
`docs/project-statistics.config.json` erzeugt. Es ist kein Home-Sync noetig.
Der strukturierte Nachweis liegt unter
`docs/documentation-impact/secure-development-assurance-pilot.json`.

## Validierung

- Release-ZIP erneut geladen und SHA-256 bytegenau bestaetigt
- 13-Preset-`CheckOnly` unter Bash und PowerShell bestanden
- `specify preset list`, `specify preset info`,
  `specify preset resolve secure-development-evidence-contract` und
  `specify check` bestanden
- Preset-Vertragstests einschliesslich positiver/negativer Kontexte,
  Read-only-Hashnachweis sowie Bash-/PowerShell- und LF/CRLF/BOM-Paritaet
  bestanden
- Komposition in einer temporaeren Git-Arbeitskopie bestanden: Disable,
  Enable, Remove, exaktes 12-Preset-Profil und erneute Installation aus dem
  unveraenderten Tag-ZIP zum exakten 13-Preset-Profil
- Documentation-Impact-Validator, Secret-Scan, JSON-Pruefung und
  `git diff --check` bestanden

## Grenzen und Risiken

- keine menschliche Pilot-, Projekt- oder Releasefreigabe wird abgeleitet
- kein Admin-Bypass und keine Community-Einreichung
- keine C5-, Konformitaets- oder Zertifizierungsbehauptung
- die fachliche Feldtest-Evidence entsteht erst in den zwei getrennten,
  sequenziellen Spec-Kit-Laeufen
