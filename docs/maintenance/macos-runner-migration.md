# macOS-Runnerwechsel / macOS runner migration

## Betrieb / Operation

GitHub stellt macOS 14 am 2. November 2026 ein. Oktober-Ausfallfenster betreffen
Jobs mit dem alten Label. Bestehende macOS-14-Jobs verwenden deshalb explizit
`macos-15`; `macos-latest` ist keine feste Versionsbindung.

GitHub retires macOS 14 on 2 November 2026. October brownouts affect jobs using
the old label. Existing macOS 14 jobs therefore explicitly use `macos-15`;
`macos-latest` does not pin a version.

Quelle / Source: [GitHub retirement notice](https://github.blog/changelog/2026-10-01-github-actions-macos-14-runner-image-retirement/).

Homogeneity verwendet macOS 15. Produkt-Build, Tests und Smoke laufen weiterhin auf Linux/Windows; Requirements Intake Governance behaelt macos-latest. / Homogeneity uses macOS 15; product CI remains Linux/Windows and intake governance keeps macos-latest.

Maintenance TUI und PowerShell Analysis behalten ihre bestehende bedingte
Matrix: Nur benannte Referenz-Repositories starten macOS-/Windows-Jobs;
andere Kopien starten Linux. / These workflows retain their conditional matrix:
only named reference repositories run macOS/Windows; other copies run Linux.

## Pruefung und Lieferung / Verification and delivery

Auf dem aktuellen PR-Commit muessen die ausgelösten macOS-15-, Linux- und
Windows-Jobs erfolgreich sein. PowerShell, Python und Homebrew/ripgrep werden
durch die jeweiligen Workflow-Schritte geprueft. Nicht ausgefuehrte Jobs sind
kein Nachweis. Reviewbefunde vor dem an den Commit gebundenen Merge bearbeiten.
Admin-Bypass ersetzt keine technische Pruefung. Historische Evidence behalten.

Triggered macOS 15, Linux and Windows jobs must pass on the current PR commit.
Workflow steps exercise PowerShell, Python and Homebrew/ripgrep as applicable.
Missing execution proves nothing. Resolve review findings before the commit-bound
merge; admin bypass does not replace technical validation. Preserve historical evidence.

Documentation Impact: `UpdateRequired`. Owner: Repository Maintainer.
Zielgruppen / Audiences: Maintainer und KI-Agenten / maintainers and AI agents.
Leserpfad / Reader path: Agent-Guidance -> dieser Guide -> Workflow -> PR-Checks.
Kanonische Quelle / Canonical source: `.github/workflows/`.
Sprache / Language: DE zuerst, EN danach / German first, English second.
Dokumentklasse / Document class: ActiveSemantic.
Re-Evaluation: Runner-Abkuendigung, Toolchain- oder Required-Check-Aenderung.
Liefernachweise / Delivery evidence: PR-Checks und PR-Beschreibung / PR checks and description.

Distributionsklasse / Distribution class: sourceOnly. Kein Home-Sync fuer
dieses Repository / no Home sync for this repository.
