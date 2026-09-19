# Wartungslieferung: Quellenbindung / Maintenance delivery: source binding

## Deutsch

Documentation Impact: UpdateRequired. Owner: Repository-Maintainer. Quelle:
`.github/workflows/powershell-analysis.yml`; Leserpfad: GSDB-Quelleninventar
und Evidence-Matrix. Source-only, kein Home-Sync, keine Produktcodeänderung.

Die Paketverteilung begrenzt Push-Läufe des PowerShell-Analyzers auf `main`
und beendet überholte Läufe derselben PR-/Branch-Gruppe. `pull_request` und
`workflow_dispatch` bleiben aktiv. Permissions, Runner-Matrix, gepinnte
Checkout-Action, Modulinstallation und eigentlicher Analysebefehl bleiben
unverändert. Jeder aktuelle PR-Head wird weiterhin geprüft; ein abgebrochener
älterer Lauf gilt nicht als bestandener Gate.

Codex hat diesen begrenzten Unterschied am 20.09.2026 technisch geprüft und
die normalisierte SHA-256-Bindung von SRC-043 in Matrix und Inventar erneuert.
Der alte Hash verursachte GSDB002 vor dem beabsichtigten Negativtest GSDB006.
Keine Kontrollbewertung, offene Findings oder menschliche Freigabe wurde
geändert. NIST SSDF und CWE Top 25 sind für diese CI-/Evidence-Änderung
anwendbar; neue Produkt-, SBOM- oder CVE-Nachweise werden nicht behauptet.
Wiedervorlage: jede weitere Änderung dieser Workflowquelle. Text-first,
Deutsch vor Englisch; keine farb- oder layoutabhängige Information.

## English

Documentation Impact: UpdateRequired. Owner: repository maintainer. Canonical
source: `.github/workflows/powershell-analysis.yml`; reader path: GSDB source
inventory and evidence matrix. Source-only; no Home sync or product change.

Distribution limits analyzer push runs to `main` and cancels superseded runs
within the same PR/branch group. Pull-request and manual triggers remain.
Permissions, runner matrix, pinned checkout action, module installation and
analysis command are unchanged. The current PR head still requires proof;
cancelled older runs are not passing gates.

Codex technically reviewed this bounded difference on 2026-09-20 and renewed
SRC-043's normalized SHA-256 binding in matrix and inventory. The stale hash
caused GSDB002 before the intended GSDB006 negative test. Control assessments,
open findings and human approvals remain unchanged. NIST SSDF/CWE Top 25 apply
to the CI/evidence change; no new product, SBOM or CVE proof is claimed.
Reevaluate on the next workflow-source change. Text-first, German then English.
