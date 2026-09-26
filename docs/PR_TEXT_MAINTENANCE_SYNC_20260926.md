# Wartungssynchronisation / Maintenance synchronization

Problem: Die verteilten Wartungsskripte lagen hinter der geprueften Level-0-
Quelle. Ein grosses Paketinventar konnte das Argumentlimit ueberschreiten;
der Preset-Installer braucht die kanonische UTF-8-Behandlung.

Loesung: Vier Wartungsdateien aus home-baseline
`c7398fd0dedb05d7047b5013468fdde7e963eb38` uebernehmen (PRs 310/311),
einschliesslich Regressionstests und Installer-Manpage. Keine Produktlogik,
API, TUI, Abhaengigkeit, Preset-Matrix oder Assembly-Version wird geaendert.
Kein nummerierter Spec-Kit-Branch, kein lokaler .NET-Build/-Test, keine
DocFX-Regeneration; deshalb kein UI-Screenshot und kein neuer Buildzaehler.

Pruefplan und Nachweise: 18 kanonische Wartungstests auf WSL und 18 im
freigegebenen Container bestanden. Vor Commit werden exakte Lieferpfade,
Staged-Delivery-Set mit Indexbindung, Shell-Syntax, Whitespace und Gitleaks
geprueft. Die bestehende Statistik wird danach separat gerendert.
macOS bleibt primaer; WSL und Ubuntu-Container sind Kompatibilitaetsnachweise.

Risiko: begrenzte Synchronisation von Entwicklungswerkzeugen. Der Owner hat
am 2026-09-26 den bekannten GitHub-Actions-Billing-Ausfall bis zum erwarteten
Reset am 2026-10-01 ausdruecklich akzeptiert und MergeAndSync mit Admin-Bypass
bestaetigt. Nicht gestartete CI-Jobs gelten nicht als bestanden. Echte
technische Fehler werden nicht uebergangen; keine Billing-/Workflow-Aenderung.

Documentation Impact: UpdateRequired fuer diese PR-Beschreibung und die
kanonische Installer-Manpage; Owner Home Baseline/TinyCalc Maintainer.
Zielgruppe: Maintainer, Leserpfad PR → dieses Dokument →
`docs/man/install-spec-kit-governance-presets.1.md`. Quelle der Wartungsdateien
ist Level 0; diese Beschreibung ist source-only, ohne Home-Sync. Vorhandene
zweisprachige Textdarstellung und Navigation bleiben erhalten. GeneratedUpdate
fuer `docs/project-statistics.md` aus der bestehenden JSON-Konfiguration.
Wiedervorlage bei neuer Wartungsvertrags- oder Produktlogikaenderung.

*Problem: distributed maintenance scripts lagged behind the reviewed level-0
source. Adopt the four canonical files, including regression tests and help.
No product logic, API, TUI, dependencies, preset matrix or assembly version
changes. Eighteen maintenance tests passed in each of WSL and the approved
container; validate exact staging, syntax, whitespace and secrets before
commit, then render statistics. macOS remains primary. The owner explicitly
accepted the billing-only CI outage and authorized MergeAndSync/admin bypass
on 2026-09-26. Unexecuted jobs are not passed tests; real failures still stop
delivery. Documentation is text-first, bilingual, source-only except the
distributed manpage; re-evaluate on contract or product changes.*
