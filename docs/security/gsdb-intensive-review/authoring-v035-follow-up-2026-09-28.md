# GSDB-Nachprüfung: Authoring v0.3.5 / GSDB follow-up: Authoring v0.3.5

## Deutscher Prüfblock

Auftrag: ausdrücklich genehmigte technische Nachprüfung der Versions- und
Quellenbindung im bestehenden Pilot-PR #91. Geprüfter Installationsstand:
`a6b0ad34e0996b905a8edf8e8d4b883568ce9546`. Datum: 28.09.2026.
Technischer Reviewer: Codex; Owner: Thorsten Hindermann. Kein unabhängiger
menschlicher Vier-Augen-Review und keine Produkt-, Risiko- oder Releasefreigabe.

### Sichtung und begrenzte Änderung

Das Preset-Manifest unterscheidet sich ausschließlich durch Version 0.3.5.
ID, Anforderungen, Templates, Commands und Tags sind unverändert. Die Registry
behält Aktivierung und Priorität 64; ihre übrigen 13 Einträge bleiben strukturell
identisch. Geändert sind Authoring-Version, Manifest-Hash, Installationszeitpunkt
und Eintragsposition. Alle 42 Paketdateien entsprechen dem veröffentlichten
Tag-Archiv; der lokale Generator-Backport ist damit durch das Release ersetzt.

Die Zuordnung zu CL-09/CL-12 (29 Zeilen) und Gates 001/032/033 bleibt sachlich
unverändert. Ein gültiges Generator-Receipt belegt nur den begrenzten Intake-Prozess,
nicht die Wirksamkeit aller Sicherheitskontrollen. Die Matrix aktualisiert
ausschließlich zwei Quellenbindungen und die Authoring-Bewertung. Alle 157
Kontrollzeilen, 16 externen Pflichten, 13 Findings, Summen und übrigen
Preset-Bewertungen bleiben unverändert. Historische Nachweise behalten ihre Daten.

| Quelle | Neuer normalisierter SHA-256 |
|---|---|
| `.specify/presets/intake-authoring-governance/preset.yml` | `74a5bd0afc28ab4b3a997b2831278dcd215171552cac9877095fd08176a4591f` |
| `.specify/presets/.registry` | `6e7cd819a136bafb3c8fcf2a1ccb9c06e200f3014dfc3bbc519439a5625d2e9f` |

### Regression und Liefergrenze

Roter Ausgangsnachweis: [native CI](https://github.com/hindermath/TinyCalc/actions/runs/36433404359)
scheiterte vor Produkt-Build/Test/Smoke mit `GSDB002`, während die spätere
Negativprüfung `GSDB006` erwartete. Der Validator erhält nur die exakte neue
Versionskonstante; Schema, Kontrollzuordnungen und Fehlerbedingungen bleiben bestehen.
Neue Negativfälle prüfen beide alten Quellen-Hashes (`GSDB002`) sowie Versionen
0.3.4 und 99.0.0 (`GSDB008`). Die bisherige GSDB001–GSDB010-Suite und alle vier
produktiven Prüfaktionen bleiben in Bash und PowerShell verpflichtend.
Die Prüfungen dürfen die gebundene Evidence nicht verändern.

Lokal ausgeführt und bestanden (je Exitcode 0): Bash-Paritätssuite, separate
PowerShell-Fixtures einschließlich der vier neuen Negativfälle, alle vier
produktiven Aktionen in beiden Shells, exakte 14-Preset-Matrix in beiden Shells,
PSScriptAnalyzer 1.25.0 für 79 Dateien und Secret-Scan. Matrix und sämtliche
88 gebundenen Quellen behalten vor/nach der PowerShell-Prüfung dieselben
SHA-256-Werte. Strukturvergleich bestätigt unveränderte Kontrollzeilen,
externe Pflichten, Findings, Summen und übrige Preset-Bewertungen.

Ausführungsresultate und finaler Head werden im [PR #91](https://github.com/hindermath/TinyCalc/pull/91)
dokumentiert. MergeAndSync mit Admin-Bypass setzt erfolgreiche technische Checks
voraus; der Bypass ersetzt keine fehlgeschlagene CI oder menschliche Freigabe.

Documentation Impact: `UpdateRequired`. Kanonisch sind Matrix und Validator;
Owner ist der Repository-Maintainer. Leserpfad: Integrationsbericht → diese
Nachprüfung → Quelleninventar/Preset-Zuordnung → PR-Evidence. Zielgruppen:
Lernende ab Lehrjahr 1, Maintainer und technische Reviewer. Repository-lokale,
textorientierte DE/EN-Evidence; kein Home-Sync. Wiedervorlage bei Quellen-,
Versions- oder Scopeänderungen. Beide Statistik-Kontexte behalten ihre Methodik.
Keine Produkt-API-, DocFX- oder Assembly-Änderung.

NIST SSDF/CWE Top 25 und Paket-Provenienz gelten. ASVS ist für dieses lokale
nicht-Web/API-Delta N/A; AI-SBOM für neue Produkt-KI N/A (Entwicklungswerkzeug),
VEX ohne neue CVE-Disposition N/A. Keine neue Abhängigkeit oder Architekturgrenze,
kein SLSA-Level- oder Konformitätsnachweis. Bestehende regulatorische und
menschliche Entscheidungen bleiben unverändert.

## English review block

The user explicitly authorized this bounded GSDB version/source-binding follow-up
for PR #91, based on installation head `a6b0ad34e0996b905a8edf8e8d4b883568ce9546`.
Review date: 2026-09-28. Codex performs the technical review; Thorsten Hindermann
owns the repository. This is not independent human review or product, risk or
release approval.

The manifest changes only its version to 0.3.5. ID, requirements, templates,
commands and tags remain unchanged. Registry priority 64 and activation remain;
all thirteen other entries are structurally identical. Only Authoring version,
manifest hash, installation timestamp and entry position change. All 42 package
files match the released tag archive, replacing the local generator backport.
The CL-09/CL-12 mapping (29 rows) and gates 001/032/033 still apply without stronger
security-effectiveness claims. Only two source bindings and the Authoring
assessment are refreshed. All 157 control rows, sixteen external duties,
thirteen findings, summaries and other preset assessments remain unchanged.
The table records new normalized hashes; historical evidence stays historical.

Native CI supplies the red observation: stale sources caused GSDB002 before the
expected GSDB006 negative case and before product build/test/smoke. The validator
changes only the exact version constant, preserving schema, mappings and failure
conditions. Added tests reject both old hashes (GSDB002) and old/unknown versions
(GSDB008). The GSDB001–GSDB010 suite and all four production checks must pass
in both shells without modifying evidence. Exact-head results are recorded in
PR #91. Admin bypass never replaces successful checks or grants human approval.

Local exit-0 results: Bash parity suite, separate PowerShell fixtures including
the four new negatives, all four production actions in both shells, exact
fourteen-preset validation in both shells, PSScriptAnalyzer 1.25.0 (79 files)
and secret scan. Matrix and all 88 bound sources have identical SHA-256 values
before/after PowerShell validation. Structural comparison confirms unchanged
control rows, external duties, findings, summaries and other preset assessments.

Documentation impact is UpdateRequired, owned by the maintainer. The canonical
matrix/validator link through the integration report, this bilingual text-first
follow-up, inventory/mapping and PR evidence for first-year learners, maintainers
and reviewers. Repository-local only; no Home sync. Reevaluate on source, version
or scope changes. Both statistics contexts retain their methodology. No product
API, DocFX or assembly change. NIST SSDF/CWE and provenance apply; ASVS, new product
AI-SBOM and VEX are N/A for this non-web/API, development-tool-only change without
a CVE disposition. No dependency, architecture, regulatory or human decision changes.
