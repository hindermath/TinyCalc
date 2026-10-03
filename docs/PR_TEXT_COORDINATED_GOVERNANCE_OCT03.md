# Governance-Pilot TinyCalc / TinyCalc governance pilot

## Problem und Loesung / Problem and solution

DE: Neue veroeffentlichte Quellen benoetigen einheitliche Versionen und
Evidence-Bindungen. Fuenf Presets im vorhandenen 14er-Profil und Wartung #317
uebernehmen; beide Constitutions, fuenf Agent-Dateien und Vorlagen abstimmen.
GSDB/RL-SE technisch erneuern, ohne Findings oder Freigaben aufzuwerten.
EN: Integrate five released presets and approved maintenance files; align
shared guidance and bounded evidence bindings, preserving existing decisions.

## Risiko und Grenze / Risk and boundary

DE: Kein Produktfeature, keine API-/DocFX-Aenderung, Werkzeuginstallation,
Serienaktivierung, Community-Einreichung oder breiterer Flotten-Rollout.
Admin-Bypass nur nach gruener exakter Head-CI; Mergecommit behaelt Statistik-
Quellhistorie. Weitere Implementierungs-Gates brauchen einen neuen Auftrag.
EN: No product feature or broader rollout. Exact-head green CI remains mandatory;
use a merge commit to preserve the reproducible statistics ancestry.

## Tests / Tests

DE: 14-Preset-CheckOnly in beiden Shells; Security/Architecture- und drei
Intake-Vertraege; GSDB-Negative und Produktion, RL-SE; Read-only-Hash-Paritaet
ueber 89 Dateien; 89 Wartungstests mit zwoelf dokumentierten Skips; 79
PowerShell-Dateien befundfrei. Restore, Release-Build, 82 xUnit-Tests und
SMOKE_OK. Statistik nach sauberem Quellencommit rendern und pruefen.
EN: Local package, matrix, evidence, maintenance and product regressions pass.
Native Linux/Windows and final merge CI are recorded in the PR and hand-off.

[Technischer Nachweis / Evidence](maintenance/coordinated-governance-oct03.md).
Tracking: https://github.com/hindermath/TinyCalc/issues/92.
