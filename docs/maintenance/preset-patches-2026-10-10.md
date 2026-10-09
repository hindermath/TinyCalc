# Drei Preset-Patches und GSDB / Three preset patches and GSDB

Stand / Date: 2026-10-10. Owner: Thorsten Hindermann.
Documentation Impact: `UpdateRequired`.

DE: Freigegeben sind Security v0.7.1, Architecture v0.6.2 und Intake Sequencing
v0.2.8, gezielte technische GSDB-Versions-/Hashnachpruefung und MergeAndSync mit
Admin-Bypass nach gruenen technischen Checks. Keine neue Produkt-, Risiko-,
Pilot- oder Releasefreigabe und kein Produktlauf. Die elf anderen Presets,
Prioritaeten, historischen Receipts und Statistikmethodik bleiben erhalten.

EN: Authority covers the three patches, targeted technical GSDB version/hash
revalidation and admin delivery after successful technical checks. No new
product, risk, pilot or release acceptance and no product run. Preserve the
other eleven presets, priorities, historical receipts and statistics methodology.

## Quellen / Sources

[Zentrale Lieferung / Central delivery: PR #332](https://github.com/hindermath/home-baseline/pull/332),
Merge `224739c59311f5f0d64a3037135095288c0aa756`.
Der [Quellen-Lock / source lock](coordinated-governance-source-lock.json)
bindet die drei unveraenderlichen Tag-Commits und ZIP-Pruefsummen.
Die Patches korrigieren README-Befehle und Versionsmetadaten, nicht die
fachlichen Regeln oder Kontrollzuordnungen.

EN: The immutable source lock binds the three tag commits and ZIP hashes.
The patches correct installation commands and version metadata, not normative
rules or control mappings.

## Technische Nachpruefung / Technical revalidation

DE: Genau sieben Source-Inventory-Bindungen erneuert: drei Preset-Manifeste,
Registry, beide Constitutions und AGENTS.md. Drei Presetbewertungen erhalten
die neue Version und zugehoerige DE/EN-Erlaeuterung. Ein struktureller Vergleich
bestaetigt unveraenderte Kontrollzeilen, Findings, externe Pflichten, Summen,
Reviewdaten und menschliche Entscheidungen. Der Validator erwartet die neuen
Versionen; sechs neue Negativfaelle blockieren jeweils den vorigen Manifesthash
(GSDB002) und die vorige Bewertungsversion (GSDB008). Keine Toleranzabsenkung.

EN: Refresh exactly seven inventory bindings: three manifests, registry, both
constitutions and AGENTS.md. Update three assessment versions and their matching
DE/EN explanations. Structural comparison confirms unchanged controls, findings,
external duties, summaries, review dates and human decisions. Six added negative
cases reject preceding hashes (GSDB002) and versions (GSDB008); no weaker gate.

DE: Lokal bestanden: GSDB-Vollpruefung, Quellen, Sammelband und Zuordnungen;
RL-SE 157/157. Restore und Release-Build ohne Warnungen/Fehler, 76 Core- und
sechs TUI-Tests bestanden, `SMOKE_OK`. Der vorgeschriebene Buildzaehler wurde
vor Build/Test auf 31/32 erhoeht, keine Produkt-API geaendert. Pakettests,
Negativfaelle, volle 14er-Matrix beider Shells, Secret-Scan, PSScriptAnalyzer,
Homogeneity und Statistik sind Liefergates. Exakter Head und native CI sowie
Merge/Sync werden mit ihren tatsaechlichen Ergebnissen im PR dokumentiert.

EN: Local GSDB full/source/compendium/mapping checks and RL-SE 157/157 passed.
Restore and Release build had no warnings/errors; 76 Core and six TUI tests
passed, smoke returned SMOKE_OK. The required build counter was incremented to
31/32 before build/test without product API changes. Package/negative tests, both-shell
fourteen-preset checks, secret scan, static analysis, homogeneity and statistics
are delivery gates; record actual exact-head CI and merge/sync in the PR.

Audience / Zielgruppe: Maintainer und GSDB-Reviewer.
Reader path: Statistik-Ledger -> dieser Bericht -> Matrix/Quellen-Lock -> PR.
Canonical source: immutable preset tags and central profiles; owner: maintainer.
Class: technical revalidation; DE first / EN second; text-readable evidence.
Distribution: repository only; Home Runtime delivered separately in Level 0.
Reevaluation: source drift or next implementation preflight. Recheck intake
review freshness, series, local model routing and delivery authority then.
SSDF/CWE remain applicable; no new web/AI-product/cloud scope is introduced.
