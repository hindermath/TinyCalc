# PR: Secure Development Assurance Governance v0.1.1 fuer TinyCalc installieren

## Problem

TinyCalc verwendet das zwoelfteilige Governance-Profil. Fuer den kontrollierten
Feldtest aus `hindermath/home-baseline#268` und `hindermath/TinyCalc#66` fehlen
noch der portable Evidence-Vertrag sowie die beiden read-only beziehungsweise
reviewgebundenen Secure-Development-Assurance-Oberflaechen.

Die urspruengliche v0.1.0-Installation zeigte zwei Paketfehler: ungueltige
erzeugte Validatorpfade (SDA-FT-001) und nichtdeterministische rohe Snapshots
(SDA-FT-002). Der kanonische v0.1.1-Patch korrigiert beide Defekte.

*The original field-test installation exposed invalid generated validator
paths and nondeterministic read-only snapshots. The canonical v0.1.1 patch
corrects both defects with observed red/green regressions.*

## Loesung

- das unveraenderliche Release-ZIP von
  `secure-development-assurance-governance` v0.1.1 mit dem verifizierten
  SHA-256
  `516eaba9b6ce258c27777e88decb7e45a1e1810cab5d3cb866738bc2326453a4`
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

*Install the immutable v0.1.1 field-test archive, its evidence contract and
eight generated agent surfaces. Preserve the thirteen-preset composition and
priorities. This installation changes no product code or API and starts no
Spec Kit feature. Sandbox work remains excluded.*

## Documentation Impact

Entscheidung: `GeneratedUpdate`. Kanonische Quelle ist das installierte,
hashgepruefte Preset unter
`.specify/presets/secure-development-assurance-governance/`; die Spec-Kit-
Preset-Installation erzeugt daraus die Agenten- und Command-Flaechen. Die
Projektstatistik wird aus Git-Historie und
`docs/project-statistics.config.json` erzeugt. Es ist kein Home-Sync noetig.
Der strukturierte Nachweis liegt unter
`docs/documentation-impact/secure-development-assurance-pilot.json`.

*Generated operational surfaces and statistics are updated from their
canonical sources. The structured documentation-impact record describes
reader paths, language, provenance and boundaries. No Home sync is required.*

NIST SSDF und CWE Top 25 gelten; Pfad-/Prozesssicherheit, Paket-Provenienz und
textorientierte A11Y werden geprueft. ASVS und Zero Trust: `N/A`, kein neuer
Web-/Remote-Dienst. Produkt-AI-SBOM: `N/A`, KI nur als Entwicklungswerkzeug.
Keine neuen Produktabhaengigkeiten; bestehende SBOM-/VEX-/SLSA-Nachweise werden
nicht ersetzt. Keine DocFX-Neugenerierung, da Produkt-API und HTML unveraendert
sind. Wiedervorlage bei neuem Dienst, Produkt-KI oder Runtime-Aenderung.

*Apply SSDF, CWE, safe process/path handling, release provenance and text
accessibility. Web-service, distributed-runtime and product-AI controls are
not applicable to this installation. Existing product supply-chain evidence
is not replaced. Reassess when the service, AI or runtime scope changes.*

## Validierung

- Release-ZIP erneut geladen und SHA-256 bytegenau bestaetigt
- Exakte zentrale 13-Preset-Matrix fuer v0.1.1 pruefen
- `specify preset list`, `specify preset info`,
  `specify preset resolve secure-development-evidence-contract` und
  `specify check` bestanden
- Preset-Vertragstests einschliesslich positiver/negativer Kontexte,
  Read-only-Hashnachweis sowie Bash-/PowerShell- und LF/CRLF/BOM-Paritaet
  bestanden
- Komposition in einer temporaeren Git-Arbeitskopie: Disable/Enable, alte
  Profile 8 bis 12 und erneute Installation aus dem v0.1.1-Tag-ZIP zum exakten
  13-Preset-Profil bestanden. Die bekannte CLI-Remove-Grenze bleibt offen.
- Documentation-Impact-Validator, Secret-Scan, JSON-Pruefung und
  `git diff --check` bestanden

Paket-Merge: `00e72dc1c0eedec3ea420072e79f3709573c6cf7`.
[Paket-CI 33971814720](https://github.com/hindermath/spec-kit-preset-secure-development-assurance-governance/actions/runs/33971814720)
besteht beide Tests auf Linux, macOS und Windows am geprueften Head
`41318dbebdbffbd00754dafc8b9064b5ba0eb677`. Auch die Installation aus dem
echten Tag-ZIP besteht alle acht Oberflaechen. Die unveraenderten aktuellen
TinyCalc-CI- und Review-Gates bleiben vor Merge zwingend; Paket-CI ersetzt sie
nicht.

*Native package tests pass on all three platforms, including both shells,
raw-byte mutations and generated surfaces. The actual tag archive passes
installation tests. Current TinyCalc CI and substantive review remain separate
pre-merge requirements; package success does not imply field-test acceptance.*

## Grenzen und Risiken

- keine menschliche Pilot-, Projekt- oder Releasefreigabe wird abgeleitet
- Aktuelle Owner-Freigabe ersetzt das fruehere Bypass-Verbot: MergeAndSync
  mit Admin-Bypass ausschliesslich fuer formale Merge-Regeln, niemals fuer
  fehlgeschlagene technische, Security-, A11Y-, fachliche Review- oder
  Evidence-Gates; keine Community-Einreichung
- keine C5-, Konformitaets- oder Zertifizierungsbehauptung
- die fachliche Feldtest-Evidence entsteht erst in den zwei getrennten,
  sequenziellen Spec-Kit-Laeufen
- v0.1.0 bleibt unveraendert; v0.1.1 ist ein Feldtest-Prerelease
- Spec Kit 0.12.11 kann beim Multi-Agent-Remove zwei unbenutzbare Claude-Skills
  zuruecklassen. Das Runbook beschreibt die enge gepruefte Bereinigung;
  vollstaendiger Uninstall-Erfolg wird deshalb nicht behauptet.

*The current owner authority allows formal-rule-only bypass, never bypass of
a failed substantive gate. RL-SE and then GSDB start only after this
installation is merged and synchronized. Preserve all human decisions and
scope exclusions. Report the known CLI removal limitation honestly.*
