# GSDB-Nachprüfung: Statistik-Pilot / GSDB follow-up: statistics pilot

## Deutscher Prüfblock

Auftrag: ausdrücklich genehmigte technische Nachprüfung der Installation von
Project Statistics Governance v0.1.0, ohne Produkt-, Risiko- oder Releasefreigabe.
Geprüfter Installationsstand: `c4cbf8e9f1ae5f68e50ef9571abf45dd558e6156`;
ursprüngliche Basis: `2fd409b09bd7cc7486affdfd7434334f200515f9`.
Prüfdatum: 15.09.2026. Technischer Reviewer: Codex; Owner: Thorsten Hindermann.
Dies ist kein unabhängiger menschlicher Vier-Augen-Review.

### Quellenprüfung und begrenzte Zuordnung

- `AGENTS.md`: Der optionale Pilot und seine Grenze wurden ergänzt; die
  vorhandenen Sicherheitsregeln, Produktlaufzeit und menschlichen Zuständigkeiten
  bleiben bestehen. Die fünf gemeinsamen Guidance-Flächen wurden zusammen gepflegt.
- `.specify/presets/.registry`: Die bisherigen 13 Preset-Einträge bleiben
  unverändert. Neu ist ausschließlich das aktivierte Statistik-Preset v0.1.0
  mit Priorität 90. Die explizite 14er-Matrix ist die Installationsprüfbasis.
- Das veröffentlichte Manifest und der installierte Transparenzvertrag erlauben
  offline reproduzierbare Git-Statistik. Sie verbieten Personenranglisten und
  unbelegte Qualitäts-, Sicherheits-, Lernerfolgs- oder KI-Zeitersparnisaussagen.
- Das neue Preset wird daher nur Gate `GSDB-GATE-025` (Dokumentations- und
  Statistikpflege) zugeordnet. `mappedChecklistIds` bleibt leer: keine der
  157 Sicherheitskontrollen wird allein durch Statistik erfüllt.
- Die Standard-Achtermatrix bleibt unverändert. In der GSDB-Bewertung heißt
  seine Prioritätsklasse wie bei den anderen optionalen Presets
  `NotInStandardMatrix`; die tatsächliche Installationspriorität ist 90.

Die Quellenbindungen von Guidance und Registry wurden nach dieser Sichtung
aktualisiert; das neue Manifest ergänzt das Inventar auf 88 Quellen und
14 Presets. Die 157 Kontrollzeilen, 16 externen Pflichten und 13 offenen
Findings bleiben inhaltlich unverändert. Historische Feature-005-Zahlen und
Freigabegrenzen werden nicht rückwirkend umgeschrieben.

### Prüfung und Grenzen

Der ursprüngliche CI-Fehler war `GSDB002` wegen veralteter Quellenbindungen;
die Fixture-Suite erwartete bereits die nachgelagerte Fehlerklasse `GSDB006`.
Schema und Validator werden auf das explizit geprüfte 14er-Inventar fortgeführt.
Neue Negativtests verlangen Blockierung bei fehlendem Statistik-Preset,
falscher Version, falscher Prioritätsklasse, erfundener Kontrollzuordnung und
falscher Standardmatrix-Mitgliedschaft. Bestehende GSDB001–GSDB010- und
Bash-/PowerShell-Paritätsprüfungen bleiben verbindlich. Der finale
Ausführungsnachweis wird am exakten [PR-Head](https://github.com/hindermath/TinyCalc/pull/85)
dokumentiert; ein Testplan allein ist kein bestandener Test.

NIST SSDF und CWE Top 25 sind für diese Level-2-Integrationsprüfung anwendbar.
ASVS ist für diesen lokalen, nicht-Web/API-Delta N/A; AI-SBOM für neue
Produkt-KI N/A (nur Entwicklungswerkzeug), VEX ohne neue CVE-Disposition N/A.
Quellen-/Hashprüfung unterstützt Provenance, behauptet aber kein SLSA-Level.
Bestehende regulatorische Entscheidungen und offene menschliche Freigaben
bleiben unberührt. Keine Messung und kein neuer Spec-Kit-Feature-Lauf.

Documentation Impact: `UpdateRequired`. Owner: Repository-Maintainer.
Kanonisch: JSON-Matrix, lokales Schema und Validator; Leserpfad: Installation
→ diese Nachprüfung → Quelleninventar/Preset-Zuordnung → PR-Nachweise.
Zielgruppen: Lernende ab Lehrjahr 1, Maintainer und technische Reviewer.
Dokumentklasse: technische Evidence; Deutsch zuerst, Englisch danach in
derselben Datei, semantische Überschriften und textliche Statusangaben.
Repository-lokal/source-only, kein Home-Sync und keine neue Produkt-API.
Erneute Prüfung bei Preset-, Profil-, Quellen- oder Konfigurationsänderung,
spätestens vor der ersten eigenständig beauftragten Pilotmessung.

## English review block

This explicitly authorized technical follow-up reviews installation commit
`c4cbf8e9f1ae5f68e50ef9571abf45dd558e6156` against base
`2fd409b09bd7cc7486affdfd7434334f200515f9` on 2026-09-15. Codex performs the
technical review; Thorsten Hindermann owns the repository. It is not an
independent human review or a product, risk, or release approval.

The shared guidance adds the bounded optional pilot and preserves security,
runtime and authority rules. The registry preserves all thirteen prior entries
and adds only enabled Project Statistics Governance v0.1.0 at priority 90.
Its published manifest and installed contract support reproducible offline
Git statistics, not rankings, quality, security, learner attainment or measured
AI time savings. Therefore only documentation/statistics gate GSDB-GATE-025
is mapped, with no checklist-control claims. The standard eight are unchanged;
the assessment uses NotInStandardMatrix while actual installation priority is 90.

Reviewed source bindings are refreshed and the manifest increases the inventory
to 88 sources and 14 presets. All 157 control rows, 16 external duties and 13
open findings remain unchanged. Historical Feature 005 evidence is preserved.
The original stale-source GSDB002 failure is retained as the red observation.
Schema and validator cover the explicit fourteen-preset set; new negative
tests reject absence, wrong version, wrong priority class, fabricated control
mapping and false standard membership. Existing GSDB001–GSDB010 and shell
parity remain required; exact-head PR evidence records executed outcomes.

NIST SSDF/CWE Top 25 apply. ASVS is N/A for this non-web/API change, AI-SBOM
is N/A for new product AI, and VEX is N/A without a new CVE disposition.
Hash checks do not imply a SLSA level. No new measurement, feature execution,
regulatory decision or human approval occurs. Documentation impact is
UpdateRequired, owned by the maintainer, with bilingual text-first evidence
for first-year learners, maintainers and reviewers. The JSON/schema/validator
are canonical; installation links here, then to inventories and PR proof.
This is repository-local source-only documentation, without Home sync or API
changes. Reevaluate on relevant source/profile/configuration changes and before
the first separately authorized pilot measurement.
