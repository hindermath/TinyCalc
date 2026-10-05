# Authoring v0.3.7: technische Nachpruefung / Technical recheck

Stand / Date: 2026-10-05. Owner: Thorsten Hindermann.
Documentation Impact: `UpdateRequired`.

DE: Auftrag und Freigabe umfassen den Authoring-Patch, technische GSDB-Versions-/
Hashbindungen und MergeAndSync mit Admin-Bypass nach erfolgreichen technischen
Checks. Keine neue Produkt-, Risiko- oder Releasefreigabe, kein Produktfeature
und kein weiterer Flotten-Rollout. Menschliche Entscheidungen bleiben getrennt.

EN: Authorized scope is the patch, technical GSDB version/hash refresh and admin
delivery after successful technical checks. No new product, risk or release
acceptance, feature or wider fleet rollout. Human decisions remain separate.

## Unveraenderliche Quelle / Immutable source

- [Release v0.3.7](https://github.com/hindermath/spec-kit-preset-intake-authoring-governance/releases/tag/v0.3.7).
- Tag commit: `dbf135e89ba583fb27294f84e487cf1a5826604f`.
- Tag-ZIP SHA-256: `fc20a010c2124977249f926677d1bb2b03b81e7cd2a549bc4c7489de837e1427`.
- Normalized manifest SHA-256: `3ece036a3aa5921a70501f3ba846e38dfaa8ff3505e79aabc2f6db679c44bcaa`.
- [Central integration PR #326](https://github.com/hindermath/home-baseline/pull/326).

DE: Nur Authoring neu installiert, Prioritaet 64 und die anderen 13 Presets
erhalten. Fuenf zentrale Matrizen und fuenf Vorlagen gezielt propagiert; aktuelle
Guidance, Constitution und Quellen-Lock gemeinsam aktualisiert. Bekannte
historische v0.3.6-Receipts bleiben gueltig und werden nicht umgeschrieben.

EN: Reinstall only Authoring, preserving priority 64 and the other thirteen
presets. Propagate five central matrices and five templates; align guidance,
constitutions and source lock. Known historical v0.3.6 receipts remain valid.

## GSDB: neue Bindung, keine Promotion / New binding, no promotion

DE: Die technische Nachpruefung erneuert genau fuenf geaenderte Source-Inventory-
Bindungen: Authoring-Manifest, Registry, beide Constitutions und AGENTS.md.
Die Authoring-Presetbewertung nennt v0.3.7; Zuordnungen und Statusachsen bleiben
erhalten. 157 Kontrollzeilen, 16 externe Pflichten, 13 Findings und alle Summen
werden strukturell mit dem vorherigen Stand verglichen und unveraendert gehalten.
Gesamt-Reviewdatum, menschliche Reviewer und Entscheidungen bleiben erhalten.
Neue Negativfaelle blockieren auch den v0.3.6-Manifesthash (GSDB002) und die alte
Presetbewertungsversion (GSDB008). Der Validator wird nicht abgeschwaecht.

EN: Refresh exactly five changed inventory bindings: manifest, registry, both
constitutions and AGENTS.md. The Authoring assessment names v0.3.7, preserving
mappings and states. Compare all 157 controls, 16 external duties, 13 findings
and summaries structurally. Preserve the overall review date, human reviewers
and decisions. Reject the old manifest hash (GSDB002) and assessment version
(GSDB008); no validation tolerance is weakened.

DE: Das vollstaendige 14er-Profil wurde in beiden Shells geprueft, ebenso
GSDB-Quellen, Sammelband, Zuordnungen, Vollpruefung und Negativfaelle sowie RL-SE.
Installierte Vorlagen, Secret-Scan, PSScriptAnalyzer und Homogeneity bestanden.
Restore, Release-Build, xUnit und nichtinteraktiver TUI-Smoke pruefen bestehendes
Verhalten, keine neue Featureabnahme. Buildzaehler vor Build/Test: 29/30.
Lokal auf macOS: Restore und Release-Build ohne Warnungen/Fehler, 76 Core- und
sechs TUI-Tests erfolgreich, `SMOKE_OK`. GSDB-Pruefungen und Fixtures bestanden;
RL-SE meldet `RLSE_VALIDATION_OK` (157/157). Native CI und exakte Merge-Links
werden im PR festgehalten.

EN: Validation: full fourteen-preset checks in both shells; GSDB source,
compendium, mapping, full validation and negative fixtures; RL-SE validation;
installed templates, secret scan, PSScriptAnalyzer and homogeneity. Restore,
Release build, xUnit tests and non-interactive TUI smoke exercise existing product
regression, not new feature acceptance. The tracked build counter was incremented
before local build/test (29/30). Local macOS: restore and Release build passed
with zero warnings/errors; 76 Core plus six TUI tests passed, smoke returned
`SMOKE_OK`. GSDB full/sources/compendium/mappings and negative fixtures passed,
RL-SE returned `RLSE_VALIDATION_OK` (157/157). Native CI and exact merge links
are recorded in the PR.

DE: Zielgruppe sind Maintainer und GSDB-Reviewer. Leserpfad: Statistik-Ledger ->
dieser Bericht -> GSDB-Matrix und PR. Kanonische Quelle: unveraenderliches
Preset-Tag und zentrale Matrix; das Projekt verantwortet seine Evidence.
Dokumentklasse: technische Integration/Nachpruefung. Sprache: DE zuerst, EN
danach. Distribution: nur dieses Repository; Home Runtime separat in Level 0.
Wiedervorlage bei Quellendrift oder vor dem naechsten Produktlauf. Statistik-
methodik bleibt erhalten; Reproduzierbarkeit ist keine KI-Produktivitaetsmessung.
Unveraenderliche Upstream-Paketdateien, einschliesslich README, bleiben in ihrer
veroeffentlichten Sprache erhalten; lokale Nachweise sind zweisprachig.

EN: Audience: maintainers and GSDB reviewers.
Reader path: statistics ledger -> this report -> GSDB matrix and PR.
Canonical source: immutable preset tag and central matrix; project owns evidence.
Class: technical integration/revalidation. Language: inline DE-first/EN-second.
Distribution: repository only; Home Runtime is delivered in Level 0 separately.
Re-Evaluation: source drift or next product-start preflight. Statistics keep
their existing methodology; reproducibility is not measured AI productivity.
Immutable upstream package files, including README, retain their published
language; locally owned evidence is bilingual.
