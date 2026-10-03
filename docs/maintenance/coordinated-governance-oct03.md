# Koordinierter Governance-Pilot / Coordinated governance pilot

DE: Technischer Test-Nachlauf: zentrale Windows-CI in Home Baseline #322
fand einen OS-abhaengigen Namespacevergleich. PurePosixPath wertet jetzt
getrackte Manifestpfade plattformneutral aus; Backslash-/Drive-Pfade bleiben
ungueltig. Nur gemeinsamer Test, Nachweis und bestehende Statistikableitungen
aendern sich. Keine Paket-, Produkt-, Baseline- oder Evidence-Aenderung.
EN: Bounded follow-up to central #322 parses tracked manifest paths as POSIX
on every host and rejects backslash/drive paths. Only test, documentation and
existing statistics change; no product, package or assurance-evidence changes.

Datum / Date: 2026-10-03. Owner: Thorsten Hindermann.
Technical reviewer: Codex, not an independent human approval.
Source bindings are current; delivery evidence is recorded in hand-off #92.

## Umfang / Scope

DE: Das vorhandene 14er-Profil erhaelt Security 0.7.0, Architecture 0.6.1,
Intake Authoring 0.3.6, Review 0.2.4 und Sequencing 0.2.7. Die neun anderen
Pakete, Aktivierung und Prioritaeten bleiben erhalten. Das genehmigte
Wartungspaket aus Home Baseline #317 wird als Dateien und Registries
uebernommen; keine Werkzeuginstallation oder allgemeine Wartung.
Die [Quellenbindung](coordinated-governance-source-lock.json) nennt Tag-Commits
und unveraenderliche ZIP-SHA-256. Fuenf Agent-Guidance-Dateien, beide
Constitutions und zentrale Vorlagen sind gemeinsam ausgerichtet.
EN: Update only five released packages within the existing fourteen-preset
profile, retaining the other nine packages, activation and priorities.
Propagate approved maintenance files, never install tools. Align all five
guidance surfaces and both constitutions while preserving project-specific rules.

## Begrenzte Evidence-Nachpruefung / Bounded evidence follow-up

DE: Der rote Ausgangsnachweis war GSDB002: bereits vorbereitete neue
Preset-Quellen hatten noch alte Hashbindungen. Die fachliche Baseline wird
auf 3.3.0, der kanonisch generierte Sammelband auf 2.3.0 gebunden; alle
zwoelf unveraenderten Checklisten behalten zusammen 157 IDs.
Exakte Versionskonstanten im GSDB-Validator und Schema werden aktualisiert,
nicht erweitert. Die fokussierte synthetische Fixture bindet das neue Manifest.
Zusaetzliche Negative blockieren alle fuenf alten Preset-Versionen/Hashes und
die alte Baseline. Alte Fehlerklassen, kontrollierte Pfade, Kontroll-/Gate-
Zuordnungen und Standard-/Optional-Matrixklassen bleiben bestehen.
EN: The observed red GSDB002 failure proved stale bindings. Bind baseline
3.3.0 and generated compendium 2.3.0; the twelve unchanged checklists retain
all 157 IDs. Change exact constants and fixture bindings, never validation
tolerance. Additional negative tests reject all five previous releases and
the previous baseline, retaining the existing error classes and mappings.

DE: Die Statusachsen aller 157 Kontrollzeilen, 16 externen Pflichten,
13 Findings und Summen werden nicht aufgewertet. Nur betroffene technische
Versionen, Hashes und Locator-Bezuege werden erneuert. RL-SE-Baseline- und
Assessment-Bindungen folgen derselben kontrollierten Quelle. Alte Review-
und Gate-Entscheidungen bleiben historisch; dies ist kein neuer Vier-Augen-
Review und keine Produkt-, Risiko-, Rechts-, C5- oder Releasefreigabe.
EN: Preserve all control dispositions, external duties, findings and summary
counts. Refresh only affected technical versions, hashes and locators.
The RL-SE bindings follow the same controlled source. Historical reviews are
not new independent approvals, product acceptance or legal conclusions.

| Quelle / Source | Neuer normalisierter SHA-256 / New normalized SHA-256 |
| --- | --- |
| `.specify/presets/architecture-governance/preset.yml` | `860931928acf952882491f933f2498b4be7bf3a31cc07b4c649c23396b6a0988` |
| `.specify/presets/intake-authoring-governance/preset.yml` | `647920968d4f49290b0b04ed3a7cd3381f0303d21de224c02ed8351c961441ff` |
| `.specify/presets/intake-review-governance/preset.yml` | `72c9e3967464db4b1ddd0aba9deedcd7a9772abf55bbc1fa0a7c7adefffde732` |
| `.specify/presets/intake-sequencing-governance/preset.yml` | `172de02fac9360821550e719771efa419127b3b14dfae26a32a664a9607e3cbe` |
| `.specify/presets/security-governance/preset.yml` | `68214a39f7ebbbd949f1965dfe2ba98f960529662339abd106fa8eb366d97c4b` |
| `docs/secure-development/baseline-manifest.json` | `11279e2a66f820f1a58b0a4af0d9e22ec3fbf4a7d298cae798d3f10383c46ed0` |
| `docs/secure-development/Richtlinie_Sichere-Entwicklung.md` | `80d1b72f5648e2a948803767dabdfea491ed2c5b936dc8179c081389b32aa469` |
| `docs/secure-development/Checklistensammelband_Sichere-Entwicklung.md` | `701c695b800111684223e597bd463e68889cbce656de258ea6247a88eb6bf164` |
| `docs/secure-development/README.md` | `738d42fbeb19466b2f945cc6e0d74e63a70eba80e040ee803e7ac4983d20da83` |
| `constitution.md` | `76dbcab975bfd643a15f5b246676e6f1720250c2bdc6889f6c43c303fe1c6b14` |
| `.specify/memory/constitution.md` | `76dbcab975bfd643a15f5b246676e6f1720250c2bdc6889f6c43c303fe1c6b14` |
| `AGENTS.md` | `8f17db1ea82d6ee90511c14ecef476f561897e61e2f2135d36ae253a1131c67c` |
| `.specify/presets/.registry` | `4fa3e8b8f9671f1f80d36e7991cf7cd45b11dc79108327a75117fb0e5aebe9fb` |
| `docs/security/secure-development/2026-09-05-tinycalc-rl-se-self-assessment/assessment-matrix.json` | `eef2b2adbb4f32b478af41caf6a90189d438c6195f606783fbaf9e873bdbd3cf` |
| `docs/security/README.md` | `8bba53e79452efaf63e9a882e6351f86457e4418056b24ff99f559a648afb433` |

DE: Die folgenden aelteren Berichte behalten ihre datierten Tabellen; dieser
Nachlauf und die JSON-Matrix sind die aktuelle technische Quellenbindung.
EN: Preserve dated tables in earlier reports; this follow-up and the canonical
JSON matrix provide the current technical bindings.

## Technische Pruefung / Technical checks

Vierzehn-Preset-CheckOnly in Bash/PowerShell bestanden; Security-Vertrag mit
sechs synthetischen Beispielen und neun Negativfaellen sowie fuenf Architecture-
Tests bestanden. GSDB/RL-SE-Produktion validiert. Weitere genaue lokale und
native Ergebnisse werden vor Lieferung im PR und Hand-off #92 dokumentiert.
Product regression: restore, Release build, xUnit tests and non-interactive TUI smoke.
Observed locally: Release build 0 warnings/0 errors; 76 Core and 6 TUI xUnit
tests passed, no test skips; SMOKE_OK. Full maintenance regression: 89 tests,
twelve documented environment/platform skips. Three Intake configuration suites,
four agent-surface parity tests and pinned PSScriptAnalyzer (79 files) passed.
All four production GSDB actions passed in both shells. Matrix plus 88 sources
retained identical hashes before/after validation. Structural comparison proves
unchanged 157 control dispositions, sixteen duties, thirteen findings and summary.
Build counters are incremented before build and test, retaining Minor/Patch.
Keine Produkt-API-, XML-/DocFX- oder Funktionsaenderung; TDD/Changed-Code-Coverage
fuer dieses Governance-Delta N/A, vor Produktcode neu pruefen.
NIST SSDF/CWE und Paket-Provenienz gelten; kein neuer ASVS-Web/API-Scope,
Produkt-KI oder CVE-Disposition. Existing security and human findings remain open.

## Jahresreview, Stufen und Implementierungsgrenze / Review and delivery boundaries

DE: Der [zentrale Vertrag](governance-review-and-rollout.md) setzt die feste
Jahrespruefung fuer die urspruenglichen sechs Presets plus Assurance auf
3. Oktober, naechster Termin 2027-10-03 10:00 Europe/Berlin. Anlassreviews
verschieben ihn nicht. Automation liest und berichtet. A zentral/Home Runtime,
B Show-CommandTui400 und TinyCalc; C und D brauchen getrennte neue Auftraege.
EN: The linked policy fixes the annual review; event reviews do not reset it.
Automation only reports. Further public Level-2 consumers and remaining fleet
each require a separate new request.

DE: Beispielprodukt, Entwicklungswerkzeuge und Organisation getrennt auf
DS-GVO, KI-VO, CRA, NIS2 und DORA pruefen; Jurisdiktion, Rolle,
direkte/vertragliche Pflichten, Quelle, Owner, Reviewer und Evidence erfassen.
Ausbildung oder AI-SBOM N/A ist keine pauschale Ausnahme; unbekannt bleibt Open.
Vor einem gesondert beauftragten Produktlauf Intake-Review-Frische, Serien-/
Kandidatenstatus, lokale Modellrollen, benoetigte Werkzeuge und aktuelle
Delivery-Autoritaet erneut fail-closed pruefen. Hier nur berichtet:
kein Spec-Kit-Feature, keine Serienaktivierung und keine Produktimplementierung.
EN: Separate product, tooling and organisation scope; education is no blanket
exemption. Preserve unknown as Open. A later separately commissioned feature
must freshly check intake review, series/candidate, routing, tools and authority.
This integration starts no feature and grants no additional human approval.

Documentation Impact: UpdateRequired (integration and evidence), GeneratedUpdate
(existing statistics and canonical compendium); no Home Runtime sync from TinyCalc.
Reevaluation: source/version, regulatory scope, finding or delivery-authority change.
