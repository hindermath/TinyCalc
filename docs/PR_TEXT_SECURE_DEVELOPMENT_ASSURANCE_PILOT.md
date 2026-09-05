# PR: Secure Development Assurance Governance v0.1.2 fuer TinyCalc installieren

## Problem

TinyCalc verwendet das zwoelfteilige Governance-Profil. Fuer den kontrollierten
Feldtest aus `hindermath/home-baseline#268` und `hindermath/TinyCalc#66` fehlen
noch der portable Evidence-Vertrag sowie die beiden read-only beziehungsweise
reviewgebundenen Secure-Development-Assurance-Oberflaechen.

Die urspruengliche v0.1.0-Installation zeigte zwei Paketfehler: ungueltige
erzeugte Validatorpfade (SDA-FT-001) und nichtdeterministische rohe Snapshots
(SDA-FT-002). v0.1.1 korrigierte beide Defekte. Die anschliessende unabhaengige
Pruefung fand mit SDA-FT-003 zwei weitere Eingabegrenzen: ungueltige oder
fehlende `acceptedRisks[].id`-Werte und mehrere aneinandergehaengte JSON-Wurzeln
konnten die Bash-Auswertung umgehen. v0.1.2 schliesst beide Grenzen
shell-paritaetisch.

*The original field-test installation exposed invalid generated validator
paths and nondeterministic read-only snapshots. v0.1.1 corrected those defects.
The independent follow-up review found invalid or missing accepted-risk IDs and
multiple concatenated JSON roots as additional Bash bypasses. v0.1.2 closes
both boundaries consistently in Bash and PowerShell.*

## Loesung

- das unveraenderliche Release-ZIP von
  `secure-development-assurance-governance` v0.1.2 mit dem verifizierten
  SHA-256
  `4eb30804bb3c329681e0b7d44187c8daeb3e9e4f250bb6003d5b746c0ad0b656`
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

*Install the immutable v0.1.2 field-test archive, its evidence contract and
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
- Exakte zentrale 13-Preset-Matrix fuer v0.1.2 pruefen
- `specify preset list`, `specify preset info`,
  `specify preset resolve secure-development-evidence-contract` und
  `specify check` bestanden
- Preset-Vertragstests einschliesslich positiver/negativer Kontexte,
  Read-only-Hashnachweis, Bash-/PowerShell- und LF/CRLF/BOM-Paritaet sowie
  RED/GREEN-Regressionen fuer Risk-IDs und genau eine JSON-Wurzel bestanden
- Komposition in einer temporaeren Git-Arbeitskopie: Disable/Enable, alte
  Profile 8 bis 12 und erneute Installation aus dem v0.1.2-Tag-ZIP zum exakten
  13-Preset-Profil bestanden. Die bekannte CLI-Remove-Grenze bleibt offen.
- Documentation-Impact-Validator, Secret-Scan, JSON-Pruefung und
  `git diff --check` bestanden

Paket-Merge: `02423602592ad0183454e259df628ab940436ba6`.
[Paket-CI 33976340466](https://github.com/hindermath/spec-kit-preset-secure-development-assurance-governance/actions/runs/33976340466)
besteht die vollstaendige Testsuite auf Linux, macOS und Windows am geprueften
Head `cf7e18fe7dc45dca93801a8c58d19c7dfc2f4fc1`. Das veroeffentlichte
[v0.1.2-Prerelease](https://github.com/hindermath/spec-kit-preset-secure-development-assurance-governance/releases/tag/v0.1.2)
und sein echtes Tag-ZIP bestehen alle acht Oberflaechen. Source-Merge
`610352901d35d5885044ffe3355a7767396cc63a` uebernimmt dieselben Bytes. Die
unveraenderten aktuellen
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
- v0.1.0 und v0.1.1 bleiben unveraendert; v0.1.2 ist das aktuelle
  Feldtest-Prerelease
- Spec Kit 0.12.11 kann beim Multi-Agent-Remove zwei unbenutzbare Claude-Skills
  zuruecklassen. Das Runbook beschreibt die enge gepruefte Bereinigung;
  vollstaendiger Uninstall-Erfolg wird deshalb nicht behauptet.

*The current owner authority allows formal-rule-only bypass, never bypass of
a failed substantive gate. RL-SE and then GSDB start only after this
installation is merged and synchronized. Preserve all human decisions and
scope exclusions. Report the known CLI removal limitation honestly.*
