# Autonome Lauf-Evidenz: GSDB-Intensivpruefung

## Laufrahmen / Run frame

**DE:** Lauf `69674c80-911c-40ff-9a0e-004f7b13b832` bearbeitet ausschliesslich
den bindenden GSDB-Intake auf Branch `005-gsdb-intensive-review`. Autorisierter
DeliveryMode ist `MergeAndSync`. Der ausdruecklich genehmigte Admin-Bypass darf
nur eine verbleibende formale Merge-Regel ueberwinden, nachdem alle materiellen
technischen, Sicherheits-, Barrierefreiheits-, Governance-, Evidenz- und
Review-Gates erfolgreich sind. Kein Folge-Feature wird gestartet.

**EN:** Run `69674c80-911c-40ff-9a0e-004f7b13b832` handles only the binding
GSDB intake on branch `005-gsdb-intensive-review`. The authorised delivery mode
is `MergeAndSync`. The explicitly approved admin bypass may only overcome a
remaining formal merge rule after every material technical, security,
accessibility, governance, evidence, and review gate has passed. No follow-up
feature will be started.

## Preflight

- Operating system: macOS (`Darwin`); PowerShell 7 is used where a matching
  repository script exists.
- Base commit: `f287223307b8c1ac00e67129354030a61e8dd39d`; local `main` and
  `origin/main` matched at start.
- Intake: `Lastenheft_GSDB-Spec-Kit-Intensivpruefung.md`, normalized SHA-256
  `efd35926e427cc80bdcb098aebc25ad506e2a6e4aadb73627a2317854d0b1aa7`.
- Intake review: `Ready`, review ID
  `123a085b-5987-4790-958a-c96fc9369f1c`; both review validators passed.
- Series: GSDB is the only `Eligible` target and an independent root. Pending
  or blocked targets are not started.
- Model routing: local profile refreshed and validated as `Aligned`; concrete
  model names remain runtime evidence and are not feature requirements.
- Security: NIST SSDF and CWE Top 25 always apply. STRIDE/CAPEC,
  SBOM/VEX/SLSA, WCAG 2.2 AA, AI-SBOM, ASVS and Zero Trust require explicit
  `Applicable`, `N/A`, or `Open` dispositions with evidence and triggers.

## Evidence log

| Phase | Status | Evidence or next proof |
|---|---|---|
| Preflight | Pass | `autonomous-run-state.json`; current review, series and routing validators |
| Specify | Pass | `spec.md`; validated runtime `specify.result.json` binds the exact payload hash |
| Clarify | Pass | Zero questions; corrected the stale XI-XIX reference to binding Principles XI-XVIII |
| Requirements checklist | Pass | `checklists/requirements.md`; 42/42 quality items and structured payload hash pass |
| Plan | Pass | `plan.md`, research, data model, quickstart and two contracts; 33 gates declared before implementation |
| Plan review | Pass | `checklists/plan-review.md`; 1 Critical, 3 High, 9 Medium and 1 Low resolved, 0 material open |
| Tasks | Pass | `tasks.md`; 131 sequential unchecked tasks, ten phases and closed feature/closeout delivery sets |
| Analyze | Pass | Validated `analyze.result.json`; no Critical/High finding remains |
| Implement | Active | T001-T117 complete; causal closeout PR and terminal read-only validation remain |
| Delivery | Active | Feature PR 70 is merged and synchronized; closeout provider merge remains `Pending` |

## Wiederaufnahme-Audit / Resume audit

**DE:** Der erste Specify-Preflight wurde vor fachlichen Aenderungen blockiert,
weil der Login-PATH noch Codex CLI 0.152.0 vor der installierten Desktop-CLI
0.153.4 aufloeste. Der akzeptierte Modellkatalog, das Profil und das Modell
blieben unveraendert. CLI 0.153.4 bestand denselben Read-only-Preflight. Branch,
Head, Intake- und Review-Hashes, Presets, Scope und aktuelle Remote-Autoritaet
blieben unveraendert. Da noch keine fachliche Phase akzeptiert war, ergab der
Pflichtregel-Delta-Audit keinen Artefakt-Nachtrag.

**EN:** The first Specify preflight was blocked before semantic changes because
the login PATH still resolved Codex CLI 0.152.0 ahead of the installed desktop
CLI 0.153.4. The accepted model catalogue, profile, and model did not change.
CLI 0.153.4 passed the same read-only preflight. Branch, head, intake and review
hashes, presets, scope, and current remote authority remained unchanged. As no
semantic phase had yet been accepted, the mandatory-rule delta audit required
no artifact amendment.

## Grenzen / Boundaries

**DE:** Dieser Lauf bewertet und dokumentiert. Er behauptet keine pauschale
Sicherheit, menschliche Freigabe, Zertifizierung, Rechtsberatung oder
Providerfreigabe. Offene Punkte benoetigen Owner, Follow-up,
Re-Evaluation-Trigger und Restrisiko.

**EN:** This run assesses and documents. It does not claim general security,
human approval, certification, legal advice, or provider approval. Open items
require an owner, follow-up, re-evaluation trigger, and residual risk.

## Clarify-Ergebnisvertrag / Clarify result contract

**DE:** Die Fachphase beendete ihre Pruefung mit null Fragen und genau einer
belegbaren Korrektur. Ihr abschliessender lesbarer Bericht ueberschrieb jedoch
die reservierte JSON-Ergebnisdatei. Der Lauf blieb deshalb zunaechst blockiert.
Nach unabhaengiger Pruefung des einzigen Spec-Deltas wurde nur der strikte
Schema-1.0-Ergebnisvertrag neu geschrieben. PowerShell- und Bash-Validator
binden nun denselben Payload-Hash; die Fachphase wurde nicht wiederholt.

**EN:** The semantic phase finished with zero questions and exactly one
evidenced correction. Its readable final report overwrote the reserved JSON
result file, so the run initially remained blocked. After independent review
of the sole specification delta, only the strict schema-1.0 result contract was
rewritten. PowerShell and Bash validators now bind the same payload hash; the
semantic phase was not repeated.

## Implementierungs-Preflight T001-T005 / Implementation Preflight T001-T005

**DE:** Der Preflight wurde am 2026-09-06 auf macOS ausgeführt, bevor eine
Implementierungsdatei geändert wurde. Die beobachteten Werkzeuge sind Darwin,
PowerShell 7.6.5, .NET SDK 10.0.400, Git 2.50.1, GitHub CLI 2.97.0, GNU Bash
5.3.15, jq 1.7.1, DocFX 2.78.5 und lynx 2.9.3. Alle für T001 benannten
Pflichtwerkzeuge waren vorhanden; es wurde kein neues Werkzeug installiert.

**EN:** The preflight ran on 2026-09-06 on macOS before any implementation
file was changed. The observed tools are Darwin, PowerShell 7.6.5, .NET SDK
10.0.400, Git 2.50.1, GitHub CLI 2.97.0, GNU Bash 5.3.15, jq 1.7.1, DocFX
2.78.5, and lynx 2.9.3. Every tool named by T001 was available; no new tool
was installed.

### Autorität und Vorgänger / Authority and predecessors

- `validate-autonomous-run-state.ps1 -State specs/005-gsdb-intensive-review/autonomous-run-state.json`: `PASS`, Run `69674c80-911c-40ff-9a0e-004f7b13b832`, Stage `Implement`, Status `Active`, Aufgaben `0/131`.
- `validate-intake-review-result.ps1 -Result requirements/intakes/series/tinycalc-delivery/intake-review-result.json`: `PASS`, Review `123a085b-5987-4790-958a-c96fc9369f1c`, `Series`, `Ready`, 13 Ziele.
- `validate-intake-series-manifest.ps1 -File requirements/intakes/series/tinycalc-delivery/manifest.json -Repo . -Json`: `PASS`; GSDB ist der einzige `declaredEligible` Root. TUI-Abnahme und Sandbox-Härtung sind nur strukturell `eligible`, nicht ausgewählt und bleiben unverändert. / GSDB is the only `declaredEligible` root. TUI acceptance and sandbox hardening are structurally `eligible` only, are not selected, and remain unchanged.
- Die Phasenergebnisse `specify`, `clarify`, `requirements-checklist`, `plan`, `plan-review`, `tasks` und `analyze` bestanden `validate-autonomous-phase-result.ps1` jeweils mit Exitcode 0 und dem im Laufzustand gespeicherten Ergebnis- und Payload-Hash. `analyze` meldet absichtlich `0/0`; `implement` bleibt bis zur vollständigen lokalen Evidenz `Running`. / All seven predecessor results passed with their recorded hashes. Analyze intentionally reports `0/0`; implement remains Running until local evidence is complete.
- Branch und Head sind `005-gsdb-intensive-review` und `f287223307b8c1ac00e67129354030a61e8dd39d`. Der Checkpoint ist identisch, `deliveryMode` ist `MergeAndSync`, kein Stop ist angefordert und `authorityRevalidationRequired` ist `false`.
- Alle 15 akzeptierten Artefakte stimmen mit den im Laufzustand gespeicherten SHA-256-Werten überein. Die Analyze-Tabelle stimmt insbesondere für `spec.md` (`99e9103c...a05d27`), `plan.md` (`92ae4f8a...1f9d`), `tasks.md` (`a98aadb4...05c605`) und den Gate-Vertrag (`a071ee2d...2d349`). Das validierte Analyze-Ergebnis bindet den Bericht mit `d45e6c6b...dff47e`.
- Die drei vorbestehenden ungetrackten Dateien `intake-review-request.json`, `intake-review-result.json` und `intake-review-report.md` unter `requirements/intakes/series/tinycalc-delivery/` gehören zum späteren kausalen Closeout. Sie werden in T001-T081 weder verändert noch entfernt.

### Geschlossene Feature-Liefermenge / Closed feature delivery set

```text
.gitignore
Directory.Build.props
.github/workflows/ci.yml
specs/005-gsdb-intensive-review/spec.md
specs/005-gsdb-intensive-review/plan.md
specs/005-gsdb-intensive-review/research.md
specs/005-gsdb-intensive-review/data-model.md
specs/005-gsdb-intensive-review/quickstart.md
specs/005-gsdb-intensive-review/tasks.md
specs/005-gsdb-intensive-review/autonomous-run-evidence.md
specs/005-gsdb-intensive-review/checklists/requirements.md
specs/005-gsdb-intensive-review/checklists/plan-review.md
specs/005-gsdb-intensive-review/checklists/analyze-remediation.md
specs/005-gsdb-intensive-review/checklists/script-parity.md
specs/005-gsdb-intensive-review/contracts/evidence-matrix.schema.json
specs/005-gsdb-intensive-review/contracts/autonomous-run-gate-requirements.json
docs/security/gsdb-intensive-review/source-inventory.md
docs/security/gsdb-intensive-review/evidence-matrix.json
docs/security/gsdb-intensive-review/evidence-matrix.md
docs/security/gsdb-intensive-review/preset-mapping.md
docs/security/gsdb-intensive-review/open-findings.md
docs/security/README.md
docs/security/threat-model.md
docs/security/arc42-security.md
docs/security/security-checklist.md
docs/security/dependency-audit.md
docs/security/security-quality-scenarios.md
docs/security/asvs-verification.md
docs/security/supply-chain-evidence.md
docs/security/zero-trust-applicability.md
docs/security/samm-assessment.md
docs/security/regulatory-applicability.md
docs/security/cloud-autonomy-applicability.md
docs/security/cloud-compliance-assurance.md
docs/accessibility/gsdb-intensive-review.md
docs/PR_TEXT_GSDB_INTENSIVE_REVIEW.md
docs/documentation-impact/gsdb-intensive-review.json
docs/project-statistics.md
scripts/validate-gsdb-intensive-review.ps1
scripts/validate-gsdb-intensive-review.sh
scripts/tests/gsdb-intensive-review/valid-assessment.json
scripts/tests/gsdb-intensive-review/test-validate-gsdb-intensive-review.ps1
scripts/tests/gsdb-intensive-review/test-validate-gsdb-intensive-review.sh
docs/man/validate-gsdb-intensive-review.1
```

**DE:** Ausschließlich Pfade aus dieser Liste dürfen durch T001-T081 geändert
werden. Der lokale Laufzustand ist durch die exakte getrackte Regel
`specs/005-gsdb-intensive-review/autonomous-run-state.json` ausgeschlossen und
wird nie gestaged oder committed. `_site/` und die temporäre SBOM sind nur
lokaler Prüfausstoß.

**EN:** T001-T081 may change only paths from this list. The local run state is
excluded by the exact tracked rule
`specs/005-gsdb-intensive-review/autonomous-run-state.json` and is never staged
or committed. `_site/` and the temporary SBOM are local validation output only.

### Unveränderliche Prüfziele / Read-only assessment targets

```text
src/MicroCalc.Core/
src/MicroCalc.Tui/
tests/MicroCalc.Core.Tests/
tests/MicroCalc.Tui.Tests/
docs/secure-development/
docs/security/secure-development/2026-09-05-rl-se-self-assessment/
constitution.md
.specify/memory/constitution.md
MicroCalc.sln
src/MicroCalc.Core/MicroCalc.Core.csproj
src/MicroCalc.Tui/MicroCalc.Tui.csproj
tests/MicroCalc.Core.Tests/MicroCalc.Core.Tests.csproj
tests/MicroCalc.Tui.Tests/MicroCalc.Tui.Tests.csproj
```

**DE:** Andere Workflows als `.github/workflows/ci.yml`, alle Produktquellen,
Produkttests, kontrollierten GSDB-Baselinequellen, beide Constitutions,
Solution- und Projektdateien bleiben unverändert. `Directory.Build.props` ist
nur für die vorgeschriebene Versionierung freigegeben.

**EN:** Workflows other than `.github/workflows/ci.yml`, all product sources,
product tests, controlled GSDB baseline sources, both constitutions, solution,
and project files remain unchanged. `Directory.Build.props` is writable only
for the prescribed versioning update.

## Quellen-, Preset- und Gate-Freeze T006-T010 / Source, Preset, and Gate Freeze T006-T010

**DE:** Das kontrollierte Manifest bindet 36 Dateien. Das Quelleninventar nennt
jede Datei mit Version, Datum, Scope, Locator und aktuellem Hash. Beide
Constitutions sind byte-identisch und enthalten die Registry-Zeile
`RiderProjects/TinyCalc`. Relevante Workflows, Validatoren, Intake-/Serienbelege
und die sechs Feature-004-Evidenzdateien wurden mit aktuellem Hash und
Freshness-Klasse erfasst.

**EN:** The controlled manifest binds 36 files. The source inventory names
each file with version, date, scope, locator, and current hash. Both
constitutions are byte-identical and contain the `RiderProjects/TinyCalc`
registry row. Relevant workflows, validators, intake and series records, and
the six Feature 004 evidence files were captured with current hashes and
freshness classes.

- ID-Ableitung / ID derivation: 157 Vorkommen, 157 eindeutige IDs, null Duplikate; Familien `12/13/15/10/13/11/12/13/17/17/12/12`.
- Sammelband / compendium: 157 Vorkommen und dieselbe eindeutige ID-Menge; Inhaltsparität wird in T024 maschinell geprüft.
- Presets: 13 installiert und aktiviert; acht Standardmatrix-Mitglieder plus fünf `NotInStandardMatrix`. Die Check-only-Einstiege melden erwartungsgemäß nur diese fünf Extras; jede Standard-ID, Version, Priorität und Manifestdatei stimmt mit Matrix und Registry überein.
- Gate-Vertrag: PowerShell `ConvertFrom-Json` und `jq` ergeben 33 eindeutige IDs, 27 `Applicable`, sechs `N/A`, null unbekannte Felder, null Duplikate, null fehlende Trigger und null unbegründete `N/A`.
- Nicht-Ziele / non-goals: keine Produkt-Härtung, keine agentisch behauptete Human-only-Entscheidung, keine konkreten Modellnamen in Feature-Artefakten, keine parallele Kampagne und kein Nachfolgefeature.

### Gate-zu-Evidenz-Vormerkung / Gate-to-evidence reservation

| Gate | Vorimplementierungs-Disposition / Pre-implementation disposition | Verbindlicher lokaler oder späterer Nachweis / Binding local or later evidence |
|---|---|---|
| GSDB-GATE-001 | Applicable | Dieses Laufprotokoll; Run-, Review-, Serien- und Hashvalidatoren |
| GSDB-GATE-002 | Applicable | Sieben validierte Vorgänger-`*.result.json`; lokales `implement.result.json` nach T081 |
| GSDB-GATE-003 | Applicable | `docs/security/gsdb-intensive-review/source-inventory.md`; Matrix |
| GSDB-GATE-004 | Applicable | Quelleninventar; Sammelbandparität des Validators |
| GSDB-GATE-005 | Applicable | PowerShell-/Bash-Fixtures und dieses Laufprotokoll |
| GSDB-GATE-006 | Applicable | `evidence-matrix.json` und `evidence-matrix.md` |
| GSDB-GATE-007 | Applicable | `preset-mapping.md`; Matrix; revalidierte Feature-004-Evidenz |
| GSDB-GATE-008 | Applicable | `docs/security/security-checklist.md`; Matrix |
| GSDB-GATE-009 | Applicable | Security-Checkliste; `open-findings.md` |
| GSDB-GATE-010 | Applicable | Threat Model, arc42-Sicherheit, Qualitätsszenarien |
| GSDB-GATE-011 | N/A | `docs/security/asvs-verification.md`; Trigger Web/API/HTTP/Auth |
| GSDB-GATE-012 | Applicable | Supply-Chain-Evidenz; temporäre aktuelle SPDX-SBOM |
| GSDB-GATE-013 | Applicable | Dependency Audit; VEX-Entscheidung |
| GSDB-GATE-014 | N/A | Supply-Chain-Evidenz; Trigger Produktmodell/-dataset/-inferenz/-runtime |
| GSDB-GATE-015 | N/A | Zero-Trust-Anwendbarkeit; Trigger verteilte Produktgrenze |
| GSDB-GATE-016 | Applicable | Delivery-Zero-Trust in `zero-trust-applicability.md` und Matrix |
| GSDB-GATE-017 | Applicable | BSI C3A- und C5-Anwendbarkeitsdokumente |
| GSDB-GATE-018 | Applicable | Regulatorik-/Datenschutzentscheidungen und SAMM |
| GSDB-GATE-019 | Applicable | `docs/accessibility/gsdb-intensive-review.md`; Textreview |
| GSDB-GATE-020 | Applicable | DocFX-Ausgabe, lynx und verfügbares Playwright/axe-Harness |
| GSDB-GATE-021 | Applicable | Script-Paritätscheckliste, Manpage, lokale und spätere CI-Belege |
| GSDB-GATE-022 | N/A | Kein Delta unter `src/` oder `tests/`; Trigger jedes Produktdelta |
| GSDB-GATE-023 | Applicable | Restore, Release-Build, xUnit und exaktes `SMOKE_OK`; CI später Pending |
| GSDB-GATE-024 | Applicable | Direkte/transitive, veraltete und verwundbare Pakete; Automationsposture |
| GSDB-GATE-025 | Applicable | Dokumentations-Impact, Reader Path, Statistik und A11Y |
| GSDB-GATE-026 | Applicable | PSScriptAnalyzer, Bash, Secrets, gitleaks, Homogenität und Intake-Parität |
| GSDB-GATE-027 | Applicable | `.gitignore`, Version und späterer exakter Delivery-Set-Nachweis |
| GSDB-GATE-028 | Pending | Provider-, CI- und Review-Evidenz erst T082-T097 |
| GSDB-GATE-029 | N/A | Normaler Merge bevorzugt; formaler Alleinblocker ist Trigger |
| GSDB-GATE-030 | Pending | Temporäres Schema-2.0-PreMerge erst T098-T099 |
| GSDB-GATE-031 | Pending | Merge, PostMerge und Fast-forward erst T101-T110 |
| GSDB-GATE-032 | Pending | Intake-/Serien-Closeout und zweiter Merge erst T111-T131 |
| GSDB-GATE-033 | N/A | Kein Nachfolger; neue ausdrückliche Delegation nach vollständigem Closeout ist Trigger |

**DE:** `Pending` ist kein Pass. Die lokalen T001-T081 dürfen die Provider-,
Merge-, PreMerge-, PostMerge-, Serien- oder terminalen Closeout-Ereignisse nicht
vorwegnehmen.

**EN:** `Pending` is not a pass. Local tasks T001-T081 must not anticipate
provider, merge, PreMerge, PostMerge, series, or terminal closeout events.

## RED/GREEN-Nachweis T011-T016 / RED/GREEN evidence T011-T016

**DE:** Der erste PowerShell-Test gegen einen frischen fehlenden Temp-Pfad
lief ausführbar rot, weil die verlangte `GSDB001`-Semantik noch nicht
existierte. Der entsprechende Bash-Vertrag lief vor dem Wrapper ebenfalls rot.
Danach akzeptierte die kleinste PowerShell-Implementierung fehlende Dateien,
ungültiges UTF-8/JSON und Schemafehler deterministisch als `GSDB001`. Der
Bash-3-kompatible Wrapper delegierte mit `pwsh -NoProfile`, ohne den
übergebenen ungültigen Wert auszugeben. Die als `fixtureMode` markierte
Minimaldatei wurde von beiden Einstiegen akzeptiert.

**EN:** The first executable PowerShell test against a fresh missing temporary
path was red because the required `GSDB001` semantics did not yet exist. The
matching Bash contract was also red before the wrapper existed. The smallest
PowerShell implementation then classified missing files, invalid UTF-8/JSON,
and schema failures deterministically as `GSDB001`. The Bash-3-compatible
wrapper delegated through `pwsh -NoProfile` without echoing the supplied
invalid value. Both entry points accepted the minimal file marked as
`fixtureMode`.

- T011: PowerShell missing-path RED observed before validator implementation.
- T012: Bash missing-path RED observed before wrapper implementation.
- T013: minimal PowerShell GREEN for `GSDB001`, with strict mode and no
  dynamic execution.
- T014: minimal strict Bash wrapper GREEN with matching exit/output semantics.
- T015: minimal `fixtureMode` helper accepted through both entry points.
- T016: runtime-generated fixtures for `GSDB002` through `GSDB010` were
  executed and each reached its intended non-zero semantic class before the
  broader production semantics were added.

## Implementierungsblocker ab T017 / Implementation blocker from T017

**DE:** Der unabhängige begrenzte technische Review des vorläufigen
Matrix-/Validatorstands hat T017 nicht freigegeben. Alle 379
`supports.de/en`-Texte und die 157 Begründungen sind noch generische
Statusvorlagen statt quellenspezifischer Beobachtungen. Zehn Locators in
JSON-, Skript- und Registry-Quellen werden nicht aufgelöst. Der Wert
`summary.unsupportedClaims` wird nicht aus den Zeilen abgeleitet.
Feature-005-Integrationsprüfungen binden bei mehreren Sicherheitsdokumenten
nur den Pfad oder eine ältere/allgemeine Überschrift. Außerdem fehlen
Negativfälle für Traversal-/Windows-/Backslash- und Symlink-Grenzen,
ungebundene oder veraltete Evidenz, Preset-Checklist-Drift, umgekehrte,
verwaiste oder herabgestufte Findings, generische Bilingualität sowie
ungültige Status-/Metadatenkombinationen. Der überprüfte vorläufige
Matrix-Hash ist
`59892da03518c00fc44beb49fefc9dcadc3fa374e7b405f44a66ebb24c4d15e4`.

**EN:** The independent bounded technical review did not release T017. All
379 `supports.de/en` texts and the 157 rationales remain generic status
templates rather than source-specific observations. Ten locators in JSON,
script, and registry sources are not resolved. The
`summary.unsupportedClaims` value is not derived from the rows. Several
Feature 005 integration checks bind only a path or an older/general heading
in the security documents. Negative coverage also lacks traversal, Windows,
backslash, and symlink boundaries; unbound or stale evidence; preset checklist
drift; reverse, orphaned, or severity-downgraded findings; generic bilingual
templates; and invalid status/metadata combinations. The reviewed preliminary
matrix hash is
`59892da03518c00fc44beb49fefc9dcadc3fa374e7b405f44a66ebb24c4d15e4`.

**DE:** Damit ist T017 der erste nicht abgeschlossene sequenzielle Schritt.
T018-T081 bleiben ungeprüft. Während der Fehlersuche bereits erzeugte
nachgelagerte Entwürfe und diagnostische Ausgaben sind keine
Aufgabenerfüllung. Insbesondere scheiterte der vorgeschriebene
`docfx docfx.json`-Aufruf mit Exitcode 255 an einem lokalen
Roslyn-MSBuild-Build-Host-Named-Pipe-Timeout; nur der Inhalts-Fallback und der
`lynx`-Textpfad waren erfolgreich. Der exakt einmal ausgeführte
`dotnet build MicroCalc.sln --configuration Release --no-restore` lief von
`2026-09-06T12:11:56Z` bis `2026-09-06T12:21:58Z` und endete mit Exitcode
1, zwei `NU1900`-Warnungen, null Compilerfehlern und einem Timeout beim
Abruf der konfigurierten Paketquelle. Deren Adresse wird nicht protokolliert.
Wegen strikter Abhängigkeiten werden diese späteren Versuche weder als T056
noch als T076 oder als Folgeaufgabe gezählt. Die vorläufige
Versionsanhebung wurde zurückgenommen.

**EN:** T017 is therefore the first incomplete sequential step, and T018-T081
remain unchecked. Downstream drafts and diagnostic output already produced
during investigation do not count as task completion. In particular, the
required `docfx docfx.json` command failed with exit code 255 because the
local Roslyn MSBuild build-host named pipe timed out; only the content fallback
and the `lynx` text path succeeded. The exactly-once
`dotnet build MicroCalc.sln --configuration Release --no-restore` ran from
`2026-09-06T12:11:56Z` to `2026-09-06T12:21:58Z` and ended with exit code
1, two `NU1900` warnings, zero compiler errors, and a timeout while accessing
the configured package source. Its address is not recorded. Strict
dependencies mean these later attempts count neither as T056 nor T076 nor any
successor task. The preliminary version increment was reverted.

Applicable security standards for this Level-2 assessment remain NIST SSDF and
CWE Top 25. STRIDE/CAPEC, SBOM/VEX/SLSA, WCAG 2.2 AA, delivery Zero Trust,
SAMM, BSI C3A/C5, regulatory/privacy review, and OpenSSF evidence remain in
scope. ASVS, product AI-SBOM, and product Zero Trust retain their accepted
triggered N/A dispositions; no certification, legal approval, provider
approval, or risk acceptance is claimed.

## T017-Wiederaufnahme / T017 resume

**DE:** Der festgefahrene Wiederaufnahmeprozess wurde am sicheren Grenzpunkt
ohne laufenden Test-Unterprozess beendet; seine fokussierten Änderungen blieben
erhalten. Der PowerShell-Vertragstest bestand anschließend einmalig mit allen
Fehlerklassen `GSDB001` bis `GSDB010` sowie den ergänzten Pfad-, Locator-,
Evidenz-, Preset-, Finding-, Status-, Metadaten- und Redaktionsgrenzen. Der
Bash-Vertrag bestand danach einmalig mit identischem stdout, stderr und
Exitcode. Damit sind T017 und T018 erfüllt; frühere nachgelagerte Diagnose-
versuche bleiben weiterhin ohne Erfüllungswirkung.

**EN:** The stalled resume process was stopped at a safe boundary with no test
child process running, while its focused changes were preserved. The
PowerShell contract test then passed once with all `GSDB001` through `GSDB010`
classes and the added path, locator, evidence, preset, finding, status,
metadata, and redaction boundaries. The Bash contract then passed once with
identical stdout, stderr, and exit-code behaviour. T017 and T018 are therefore
complete; earlier downstream diagnostic attempts still do not count as task
completion.

## Hilfe- und Qualitätsvertrag T019-T021 / Help and quality contract T019-T021

**DE:** Manpage, Bash-Hilfe und PowerShell-`Get-Help` beschreiben Aktionen,
Read-only-Grenze, `GSDB001` bis `GSDB010` und Exitcodes. Dry-run/`WhatIf` ist
für den ausschließlich lesenden Validator begründet `N/A`. Die beiden neuen
PowerShell-Dateien bestanden PSScriptAnalyzer mit der Repository-Konfiguration;
die beiden zuvor gefundenen automatischen Variablennamen wurden behoben. Die
vollständigen PowerShell- und Bash-Vertragstests sowie die Bash-Syntax waren
bereits am unveränderten semantischen Stand grün und wurden nicht unnötig
wiederholt.

**EN:** The man page, Bash help, and PowerShell `Get-Help` describe the
actions, read-only boundary, `GSDB001` through `GSDB010`, and exit codes.
Dry-run/`WhatIf` is justified as `N/A` for the read-only validator. Both new
PowerShell files passed PSScriptAnalyzer with the repository settings after
the two previously found automatic-variable names were corrected. The full
PowerShell and Bash contract suites and Bash syntax were already green for the
unchanged semantic state and were not repeated unnecessarily.

## Vollständige Produktionsmatrix T022-T032 / Complete production matrix T022-T032

**DE:** Am `2026-09-06T13:31:31Z` bestanden `ValidateSources`,
`ValidateCompendium`, `ValidateMappings` und `Validate` über PowerShell sowie
das vollständige Bash-`validate` jeweils mit Exitcode 0. Die Matrix enthält
exakt 157 eindeutige CL-Zeilen in zwölf Familien, 16 externe Pflichten, 13
Preset-Bewertungen einschließlich acht Standard-Presets, 42 Human-only-Zeilen
und 13 offene Findings. Fehlende, doppelte und unbekannte IDs sowie unbelegte
positive Aussagen stehen jeweils auf null. Der Matrix-Hash ist
`4974b96b1e83336bb3cd807beddcb73f6b028b6c31c15b793b04cdf9e682bdf3`.

## Bewertung und Leserpfad T033-T058 / Assessment and reader path T033-T058

**DE:** Die fachliche Matrixprüfung bestätigte aktuelle, getrennte Aussagen
für NIST SSDF, CWE Top 25, C#/.NET-Secure-Coding, sichere Architektur,
STRIDE/CAPEC, ASVS, AI-SBOM, Produkt- und Delivery-Zero-Trust, BSI C3A/C5,
NIS2, CRA, EU AI Act, DORA, Datenschutz und OWASP SAMM. Formale, rechtliche,
Provider-, Risiko- und Zertifizierungsentscheidungen bleiben Human-only und
`Open`; es wurde keine Härtung ausgeführt. Die 157-Zeilen-Lesesicht, das
Quelleninventar, das 13-Preset-Mapping, die 13 sortierten Findings, der
Security-Leserpfad und der Dokumentationseinfluss sind DE-first/EN-second und
text-first vorhanden. `docfx docfx.json` bestand mit Exitcode 0 und 0 Fehlern;
der repräsentative `lynx -dump -nolist`-Pfad enthält 308 Zeilen sowie
`CL-01-01` und `CL-12-12`. Ein ausführbares Playwright/axe-Harness ist im
Repository nicht vorhanden und bleibt mit Owner und Trigger `Unavailable`.

**EN:** The substantive matrix review confirmed current, separate statements
for NIST SSDF, CWE Top 25, C#/.NET secure coding, secure architecture,
STRIDE/CAPEC, ASVS, AI-SBOM, product and delivery Zero Trust, BSI C3A/C5,
NIS2, CRA, the EU AI Act, DORA, privacy, and OWASP SAMM. Formal, legal,
provider, risk, and certification decisions remain Human-only and `Open`; no
hardening was performed. The 157-row reader view, source inventory, 13-preset
mapping, 13 sorted findings, security reader path, and documentation-impact
record are German-first/English-second and text-first. `docfx docfx.json`
passed with exit code 0 and zero errors; the representative
`lynx -dump -nolist` path contains 308 lines and both `CL-01-01` and
`CL-12-12`. No executable Playwright/axe harness exists in the repository, so
the disposition remains `Unavailable` with an owner and trigger.

## Abschlussnachweis US4 T059-T066 / US4 completion evidence T059-T066

**DE:** CI führt die PowerShell-Fixtures und Produktionsaktionen auf Linux und
Windows sowie Bash auf Linux aus. Der zweisprachige PR-Text beschreibt Scope,
Risiken, Tests, Security, A11Y und Human-only-Grenzen. Alle 33 Gate-IDs besitzen
eine Zuordnung; Remote-, Merge-, PreMerge-, PostMerge- und Sync-Fakten bleiben
bis zum echten Ereignis `Pending`. Der read-only Assurance-Status für Feature
004 meldete Baseline, Delta, Closure und Image-Impact `Ready`, technische
Validierung `Fulfilled` sowie Pilot-, Projekt- und allgemeine Freigabe `Open`.
Der unabhängige begrenzte Review im Laufprotokoll mit SHA-256
`fa639a74e06e78b874ba383b66d5a861c99de23fa92ab2e666e39bafc0b80b78`
fand am vorläufigen Matrix-Hash
`59892da03518c00fc44beb49fefc9dcadc3fa374e7b405f44a66ebb24c4d15e4`
fünf materielle Befundgruppen. Diese wurden nicht umgangen: die aktuellen
Negativ-Fixtures decken sie einzeln ab, beide Vertragssuiten bestanden und der
aktuelle Produktionshash
`4974b96b1e83336bb3cd807beddcb73f6b028b6c31c15b793b04cdf9e682bdf3`
bestand alle vier semantischen Aktionen über PowerShell und den vollständigen
Bash-Vertrag. Zwei zusätzliche read-only Provider-Versuche lieferten wegen
fehlender Fortschrittsausgabe kein verwertbares Ergebnis und werden nicht als
weiterer Review-Pass behauptet. Documentation-Impact-Fixtures (10 Fälle) und
die aktuelle Evidenz (2 Einträge) bestanden. Gemeinsame Agenten-Guidance blieb
unverändert, beide Constitutions sind byte-identisch, und `NoUpdateRequired`
ist mit Trigger dokumentiert.

**EN:** CI runs the PowerShell fixtures and production actions on Linux and
Windows and Bash on Linux. The bilingual PR text covers scope, risks, tests,
security, accessibility, and Human-only boundaries. All 33 gate IDs are
mapped; remote, merge, PreMerge, PostMerge, and sync facts remain `Pending`
until their real events. The read-only Feature 004 assurance status reported
baseline, delta, closure, and image impact as `Ready`, technical validation as
`Fulfilled`, and pilot, project, and general release decisions as `Open`.
The independent bounded review recorded in the run log with SHA-256
`fa639a74e06e78b874ba383b66d5a861c99de23fa92ab2e666e39bafc0b80b78`
identified five material finding groups against preliminary matrix hash
`59892da03518c00fc44beb49fefc9dcadc3fa374e7b405f44a66ebb24c4d15e4`.
They were not bypassed: current negative fixtures cover them individually,
both contract suites passed, and current production hash
`4974b96b1e83336bb3cd807beddcb73f6b028b6c31c15b793b04cdf9e682bdf3`
passed all four semantic PowerShell actions and the complete Bash contract.
Two additional read-only provider attempts produced no usable result because
they emitted no progress; they are not claimed as another review pass.
Documentation-impact fixtures (10 cases) and current evidence (2 entries)
passed. Shared agent guidance stayed unchanged, both constitutions are
byte-identical, and `NoUpdateRequired` is recorded with a trigger.

**EN:** At `2026-09-06T13:31:31Z`, `ValidateSources`,
`ValidateCompendium`, `ValidateMappings`, and `Validate` passed through
PowerShell, and the complete Bash `validate` passed, all with exit code 0.
The matrix contains exactly 157 unique CL rows in twelve families, 16 external
duties, 13 preset assessments including eight standard presets, 42 Human-only
rows, and 13 open findings. Missing, duplicate, and unknown IDs and unsupported
positive claims are all zero. The matrix hash is
`4974b96b1e83336bb3cd807beddcb73f6b028b6c31c15b793b04cdf9e682bdf3`.

## Lieferkettenstatus T067-T069 / Supply-chain status T067-T069

**DE:** Der credential-freie lokale Paket-Snapshot bestätigte einen direkten
und 23 transitive Paketknoten, keine gemeldeten Updates und keine bekannten
Schwachstellen; der externe Graph ist hashgleich zum früheren Online-Nachweis.
Dependabot, Renovate und eine zentrale Dependency-Track-Einspeisung fehlen und
bleiben offene Nacharbeit. Syft 1.51.0 erzeugte die temporäre SPDX-2.3-SBOM mit
29 Einträgen und SHA-256
`802e95731f30096b62f461ca5499db218c4f84fd886e0edca032387a8ca29564`.
Die externe Paketmenge stimmt mit der getrackten Vergleichs-SBOM überein; nur
die eigene Assembly-Version driftet. VEX ist mangels Fund `N/A`, SLSA bleibt
Ziel ohne behaupteten Level, Provenance ist nicht signiert, Action-Pinning ist
gemischt und ein aktueller OpenSSF-Aggregatwert wird nicht behauptet.

**EN:** The credential-free local package snapshot confirmed one direct and
23 transitive package nodes, no reported updates, and no known
vulnerabilities; the external graph hash matches the prior online evidence.
Dependabot, Renovate, and central Dependency-Track ingestion are absent and
remain open follow-up. Syft 1.51.0 produced the temporary SPDX 2.3 SBOM with
29 entries and SHA-256
`802e95731f30096b62f461ca5499db218c4f84fd886e0edca032387a8ca29564`.
Its external package set matches the tracked comparison SBOM; only the local
assembly version differs. VEX is `N/A` without a finding, SLSA remains a
target without a claimed level, provenance is unsigned, action pinning is
mixed, and no current OpenSSF aggregate score is claimed.

## Finale Validator- und Workspace-Gates T070-T072 / Final validator and workspace gates T070-T072

**DE:** PowerShell bestand `ValidateFixtures`, `ValidateSources`,
`ValidateCompendium`, `ValidateMappings` und `Validate`; Bash bestand die
vollständigen Negativ-Fixtures und `validate`. PSScriptAnalyzer 1.25.0 prüfte
73 Dateien ohne Warning oder Error, und die Bash-Syntax ist gültig. Der reale
Git-Diff und die getrackten Dateien sind secret-frei. Der breite Workspace-
Scan erkannte erwartungsgemäß die lokale, exakt gitignorierte Codex-Auth- und
History-Ablage; deshalb wurde zusätzlich der exakte gestagte Lieferbaum als
credential-freier Git-Baum `8d25eae0d7daedf99d4dd6b66815340509b21e0c`
geprüft. Dort meldete der Bash-Scanner `high=0`, `medium=0`; der separate
redigierte gitleaks-Staged-Scan bestand. Nach der mechanischen Aktualisierung
des vorgesehenen Statistikprofils bestanden PowerShell- und Bash-Homogenität
mit 29/29 Checks und 100 Prozent.

**EN:** PowerShell passed `ValidateFixtures`, `ValidateSources`,
`ValidateCompendium`, `ValidateMappings`, and `Validate`; Bash passed the full
negative fixtures and `validate`. PSScriptAnalyzer 1.25.0 checked 73 files
without a warning or error, and Bash syntax is valid. The real Git diff and
tracked files contain no secret. The broad workspace scan correctly detected
the local, exactly gitignored Codex authentication and history store, so the
exact staged delivery tree was also checked as credential-free Git tree
`8d25eae0d7daedf99d4dd6b66815340509b21e0c`. In that tree the Bash scanner
reported `high=0`, `medium=0`; the separate redacted staged gitleaks scan
passed. After the intended statistics profile was mechanically refreshed,
PowerShell and Bash homogeneity passed all 29 checks at 100 percent.

## Blocker T073 / T073 blocker

**DE:** Der vorgeschriebene Alignment-Lauf fand exakt einen kausalen Drift:
T059 ändert `.github/workflows/ci.yml`, während
`specs/intake-authoring-receipts/rename-microcalc-tinycalc.json` den bisherigen
normalisierten CI-Hash bindet. Die technische Korrektur ist eine enge
Aktualisierung dieses abgeleiteten Receipt-Hashs und seine Aufnahme in die
Feature-Liefermenge; ohne diese Scope-Erweiterung kann T073 nicht ehrlich grün
werden.

**EN:** The required alignment run found exactly one causal drift: T059
changes `.github/workflows/ci.yml`, while
`specs/intake-authoring-receipts/rename-microcalc-tinycalc.json` binds the
previous normalized CI hash. The technical correction is a narrow update of
that derived receipt hash and inclusion of the receipt in the feature delivery
set; T073 cannot honestly pass without that scope extension.

## Genehmigte T073-Korrektur und Version T073-T075 / Approved T073 correction and version T073-T075

**DE:** Thorsten genehmigte die enge Scope-Erweiterung ausdrücklich. Der
normalisierte CI-Hash und Git-Blob wurden ausschließlich in
`specs/intake-authoring-receipts/rename-microcalc-tinycalc.json` aktualisiert;
Plan, Tasks und PR-Text nennen den Pfad. Danach bestanden Requirements-/Intake-
Alignment, Intake-Review und Serienmanifest jeweils in PowerShell und Bash.
`git diff --exit-code -- src tests` bestätigte keinen Produkt- oder Testdelta;
Produkt-TDD und Changed-Product-Coverage sind deshalb mit dem dokumentierten
Trigger `N/A`. Der Branch besitzt noch keinen Commit gegenüber `main`; der
prospektive Feature-Commitcount ist eins. Die drei Versionsfelder wurden für
den Release-Build identisch auf `1.5.1.20` gesetzt. Eine vorläufige
Diagnoseversion 21 hatte keine Erfüllungswirkung und wurde vor T075 auf den
korrekten ersten Zählerstand 20 zurückgeführt.

**EN:** Thorsten explicitly approved the narrow scope extension. The
normalized CI hash and Git blob were updated only in
`specs/intake-authoring-receipts/rename-microcalc-tinycalc.json`; the plan,
tasks, and PR text name the path. Requirements/intake alignment, intake review,
and the series manifest then passed through both PowerShell and Bash.
`git diff --exit-code -- src tests` confirmed no product or test delta, so
product TDD and changed-product coverage are `N/A` with the documented trigger.
The branch has no commit beyond `main`, so the prospective feature commit count
is one. All three version fields were aligned to `1.5.1.20` for the Release
build. A preliminary diagnostic version 21 had no completion effect and was
returned to the correct first counter value 20 before T075.

## Release-Regression T076-T078 / Release regression T076-T078

**DE:** `dotnet restore MicroCalc.sln` bestand im credential-freien lokalen
Paketkontext mit Exitcode 0, ohne Warning oder Error. Der exakt einmalige
Release-Build mit Version `1.5.1.20` und `--no-restore` bestand mit Exitcode 0.
Danach wurde der Buildzähler genau einmal auf `1.5.1.21` erhöht.
`dotnet test MicroCalc.sln --configuration Release --no-build` bestand exakt
einmal mit 76 Core- und 6 TUI-Tests, null Fehlern und null Übersprüngen. Der
anschließende `dotnet run --no-build --configuration Release --project
src/MicroCalc.Tui/MicroCalc.Tui.csproj -- --smoke` endete mit Exitcode 0 und
gab exakt eine Zeile `SMOKE_OK` aus.

**EN:** `dotnet restore MicroCalc.sln` passed in the credential-free local
package context with exit code 0 and no warning or error. The single Release
build at version `1.5.1.20` with `--no-restore` passed with exit code 0. The
build counter was then incremented exactly once to `1.5.1.21`.
`dotnet test MicroCalc.sln --configuration Release --no-build` ran exactly
once and passed 76 Core and 6 TUI tests with zero failures and zero skips. The
following `dotnet run --no-build --configuration Release --project
src/MicroCalc.Tui/MicroCalc.Tui.csproj -- --smoke` exited zero and emitted
exactly one `SMOKE_OK` line.

## Projektstatistik T079 / Project statistics T079

**DE:** Das chronologische Ledger und der finale `Gesamtstatistik`-Block mit
ASCII-Trends wurden am vollständigen lokalen Implementierungsstand über Profil
2 aktualisiert. Der Check-only-Vertrag meldete `CURRENT`, 189001 Textzeilen,
76 sichtbare Aktivtage und den Quellenstand `fb8f3e523aef`. Die dokumentierten
Vergleiche verwenden weiterhin 80/125 Zeilen je Arbeitstag, 7,8 Stunden und
21,5 Arbeitstage je Monat und bezeichnen die Beschleunigung als gemischten
Repository-Speedup.

**EN:** The chronological ledger and final `Gesamtstatistik` block with ASCII
trends were refreshed for the complete local implementation state through
Profile 2. The check-only contract reported `CURRENT`, 189001 text lines, 76
visible active days, and source revision `fb8f3e523aef`. The documented
comparisons retain 80/125 lines per workday, 7.8 hours, and 21.5 workdays per
month and label acceleration as a blended repository speedup.

## Lokaler Abschluss T080-T081 / Local closeout T080-T081

**DE:** Der finale `docfx docfx.json`-Lauf nach Statistik- und Security-
Änderungen bestand mit Exitcode 0, 53 sichtbaren Warnungen und 0 Fehlern. Der
repräsentative lynx-Dump besitzt erneut 308 Zeilen und beide Grenz-IDs
`CL-01-01` und `CL-12-12`. Die dokumentierte Playwright/axe-Disposition bleibt
ehrlich `Unavailable`, weil kein ausführbares geprüftes Harness vorhanden ist.
Damit sind die lokalen Gates T001-T081 geschlossen: 157/157 IDs in 12/12
Familien, 16 externe Pflichten, 13/13 Presets einschließlich 8/8
Standardmatrix, 0 unbelegte Positivaussagen, 13 offene Findings und 42 offene
Human-only-Zeilen. Provider-, Exact-Head-, PreMerge-, Merge-, PostMerge-,
Closeout- und Sync-Nachweise bleiben bis zum tatsächlichen Ereignis `Pending`.

**EN:** The final `docfx docfx.json` run after statistics and security changes
passed with exit code 0, 53 visible warnings, and zero errors. The
representative lynx dump again contains 308 lines and both boundary IDs
`CL-01-01` and `CL-12-12`. The documented Playwright/axe disposition honestly
remains `Unavailable` because no executable reviewed harness exists. All local
gates T001-T081 are therefore closed: 157/157 IDs across 12/12 families, 16
external duties, 13/13 presets including the 8/8 standard matrix, zero
unsupported positive claims, 13 open findings, and 42 open Human-only rows.
Provider, exact-head, PreMerge, merge, PostMerge, closeout, and sync evidence
remain `Pending` until the corresponding real event.

## Erster PR-Head: Windows-Befund / First PR head: Windows finding

**DE:** PR 70 wurde auf Head
`ab11a9f197f7f431d4d0f51985167aa921665eba` eröffnet. Der erste CI-Lauf
`34039191930` schlug im Windows-Validatorjob materiell fehl: PowerShells
`ConvertTo-Json` erzeugte dort CRLF in Laufzeit-Fixtures, sodass der
vorgeschaltete LF-Vertrag `GSDB001` statt der erwarteten semantischen
Fehlerklasse meldete. Ubuntu wurde durch Fail-fast abgebrochen. Dieser Befund
wird nicht umgangen. Die beiden Fixture-Writer normalisieren ihre JSON-Ausgabe
nun explizit auf LF; Produktcode und Produktionsmatrix bleiben unverändert.
Für den prospektiven zweiten Branch-Commit und den erneuten Build wurde die
Version regelkonform auf `1.5.2.22` gesetzt.

**EN:** PR 70 was opened at head
`ab11a9f197f7f431d4d0f51985167aa921665eba`. Initial CI run `34039191930`
failed materially in the Windows validator job: PowerShell `ConvertTo-Json`
used CRLF for runtime fixtures, so the preceding LF contract returned
`GSDB001` instead of the intended semantic failure class. Ubuntu was cancelled
by fail-fast. This finding is not bypassed. Both fixture writers now normalize
their JSON output explicitly to LF; product code and the production matrix are
unchanged. Version `1.5.2.22` aligns the prospective second branch commit and
the remediation build counter.

## Exakter Feature-Head und Review T082-T106 / Exact feature head and review T082-T106

**DE:** PR 70 konvergierte nach zwei eng begrenzten Korrekturzyklen auf den
exakten Head `3fbcfdc984eb619b4854e5e74b2a65d554ceeaf1`. Alle 20 tatsächlichen
Checks waren erfolgreich. Der unabhängige Claude-Review-Lauf `34041219376`
bestand; `Changes Requested` und ungelöste actionable Threads waren jeweils
null. GitHub meldete weiterhin ausschließlich `REVIEW_REQUIRED`. Deshalb wurde
`GSDB-GATE-029` nach erneuter Prüfung auf `Applicable` gesetzt; der Bypass blieb
auf diese formale Regel begrenzt. Der neue Schema-2.0-PreMerge-Snapshot hat
SHA-256 `d926db3b9933b768ded951802abac01bdee5ae7ff40b75e8bf090035c1dc2aca`,
deckt alle 33 Gates genau einmal als `Primary` ab und enthält keine
Mergebehauptung.

**EN:** PR 70 converged after two narrowly scoped remediation cycles at exact
head `3fbcfdc984eb619b4854e5e74b2a65d554ceeaf1`. All 20 actual checks passed.
Independent Claude review run `34041219376` passed; both Changes Requested and
unresolved actionable threads were zero. GitHub still reported only
`REVIEW_REQUIRED`. `GSDB-GATE-029` was therefore activated after another
review, while bypass authority remained limited to that formal rule. The new
schema-2.0 PreMerge snapshot has SHA-256
`d926db3b9933b768ded951802abac01bdee5ae7ff40b75e8bf090035c1dc2aca`,
covers all 33 gates exactly once as `Primary`, and claims no merge fact.

## Feature-Merge und PostMerge T107-T110 / Feature merge and PostMerge T107-T110

**DE:** Der formal begrenzte Admin-Merge schloss PR 70 am
`2026-09-06T15:13:41Z` als Merge-Commit
`81fce22905a8caf4a3874e50fe2be5a1d7c7a812`. Seine Eltern sind der vorherige
`main`-Head `f287223307b8c1ac00e67129354030a61e8dd39d` und der exakt geprüfte
Feature-Head. Lokales `main` und `origin/main` wurden ausschließlich per
Fast-Forward auf denselben Merge-Commit synchronisiert. Der persistierte
PostMerge-Snapshot besitzt SHA-256
`a7fd5ebf754d5b9e11cdaa29e31ead76c9f1c3e315c5df41549c5e5d7fec8f40`,
bindet den akzeptierten PreMerge-Hash, den echten Merge-Commit und eine leere
`changedPaths`-Liste.

**EN:** The formal-only admin merge closed PR 70 at `2026-09-06T15:13:41Z`
as merge commit `81fce22905a8caf4a3874e50fe2be5a1d7c7a812`. Its parents are prior
`main` head `f287223307b8c1ac00e67129354030a61e8dd39d` and the exact reviewed
feature head. Local `main` and `origin/main` were synchronized only by
fast-forward to the same merge commit. The persisted PostMerge snapshot has
SHA-256 `a7fd5ebf754d5b9e11cdaa29e31ead76c9f1c3e315c5df41549c5e5d7fec8f40`,
binds the accepted PreMerge hash and actual merge commit, and records an empty
`changedPaths` list.

## Kausaler Serien-Closeout T111-T117 / Causal series closeout T111-T117

**DE:** Der Branch `codex/005-gsdb-intensive-review-closeout` wurde nur vom
synchronisierten `main` erzeugt. Der GSDB-Intake ist branchgestempelt und im
neuen Manifest als `Completed` geführt. Genau eine Serienoperation mit ID
`5415a66a-8944-411d-9914-9b090cb6bb5b` aktualisierte 13 Ziele, vier Wurzeln
und neun bindende Kanten; kein Ziel ist als `Eligible` ausgewählt. Die
Validatoren nennen lediglich zwei strukturell berechtigte, aber weiterhin
`Pending` bleibende Kandidaten. Das Vorgänger-Manifest und -Receipt wurden
byte-identisch unter `20260906T151949Z` archiviert und über die Hashes
`24552c219bd516067da0c2fe6f6be39a935aac8f3e38f7237db9b505d68ad99b`
beziehungsweise
`b4c0fca16a66a3a7242ae6dfa85af262e5c206cc794444f551d7fa0f25852094`
gebunden. PowerShell und Bash bestanden Manifest, Receipt und vollständiges
Requirements-Alignment. Der getrennte Intake-Review bleibt nach der
hashgebundenen Mutation ausdrücklich `Pending` und wurde nicht erfunden.

Die ursprüngliche enge Closeout-Pfadliste nannte die Serienarchive und
deterministisch generierten Alignment-Artefakte nicht vollständig. Um die
verbindlichen Anforderungen `preserved archives` und Cross-Shell-Alignment
ehrlich zu erfüllen, umfasst derselbe evidence-only Commit zusätzlich genau
die beiden Archive, Root-Reihenfolge, GSDB-Receipt, Generator,
Alignment-Validator und dessen Negativ-Fixture sowie die kausal erforderliche
Statistikbindung. Produktcode, Produktabhängigkeiten und Folgefeatures bleiben
unverändert. Closeout-Head, Checks, Review, Merge und finaler Sync sind bis zu
ihrem tatsächlichen Providerereignis `Pending`.

**EN:** Branch `codex/005-gsdb-intensive-review-closeout` was created only
from synchronized `main`. The GSDB intake is branch-stamped and recorded as
`Completed` in the new manifest. Exactly one series operation with ID
`5415a66a-8944-411d-9914-9b090cb6bb5b` updated 13 targets, four roots, and
nine binding edges; no target is declared `Eligible`. The validators only
report two structurally eligible candidates which remain `Pending` and are
not selected. The predecessor manifest and receipt were archived
byte-identically under `20260906T151949Z` and bound by hashes
`24552c219bd516067da0c2fe6f6be39a935aac8f3e38f7237db9b505d68ad99b`
and `b4c0fca16a66a3a7242ae6dfa85af262e5c206cc794444f551d7fa0f25852094`.
PowerShell and Bash passed manifest, receipt, and complete requirements
alignment validation. The separate Intake Review explicitly remains `Pending`
after the hash-bound mutation and was not invented.

The original narrow closeout path list did not fully name the series archives
and deterministic alignment artefacts. To satisfy the binding preserved-
archive and cross-shell alignment requirements honestly, the same
evidence-only commit also contains exactly the two archives, root order, GSDB
receipt, generator, alignment validator and its negative fixture, plus the
causally required statistics binding. Product code, product dependencies, and
successor features remain unchanged. Closeout head, checks, review, merge, and
final synchronization remain `Pending` until their real provider events.

## Enge Closeout-CI-Korrektur / Narrow closeout CI remediation

**DE:** Der erste exakte Closeout-Head `9dc5da77548467aedcbb432c3a3e85d2497ae413`
bestand die unabhängige Review-, Secret-, Governance-, Homogenitäts- und
Analyseprüfung. Der Build-Test fand jedoch materiell korrekt, dass die
GSDB-Quellenbindung noch auf den vor dem Closeout gültigen Intake-Pfad und
Manifest-Hash zeigte. Dieser Fehler wird nicht umgangen: Matrix und
Quelleninventar binden nun den branchgestempelten Intake mit SHA-256
`f4dcb3fac6cb755faed296847ffd40170f0d008fa3640e5e5fa5bc38e4af5375`
und das abgeschlossene Serienmanifest mit SHA-256
`586424d2424b31f16c1461583affb3b0204886ccca0e79fb59af7759842b6703`.
Der daraus entstandene Closeout-Matrix-Hash ist
`ba992efb1468cf6cb523c42ca96222f0997b367cfa899ca30fb902a918245846`.
Beide vollständigen Fixture-Suiten und alle Produktionsaktionen bestanden
danach erneut. Die früher im Bericht genannten Matrix-Hashes bleiben
historische Nachweise des jeweils geprüften Feature-Heads.

**EN:** The first exact closeout head
`9dc5da77548467aedcbb432c3a3e85d2497ae413` passed independent review,
secret, governance, homogeneity, and analysis checks. The build-test correctly
found a material issue, however: the GSDB source binding still referenced the
intake path and manifest hash valid before closeout. This failure is not
bypassed. The matrix and source inventory now bind the branch-stamped intake
at SHA-256
`f4dcb3fac6cb755faed296847ffd40170f0d008fa3640e5e5fa5bc38e4af5375`
and the completed series manifest at SHA-256
`586424d2424b31f16c1461583affb3b0204886ccca0e79fb59af7759842b6703`.
The resulting closeout matrix SHA-256 is
`ba992efb1468cf6cb523c42ca96222f0997b367cfa899ca30fb902a918245846`.
Both complete fixture suites and every production action passed again. Earlier
matrix hashes in this report remain historical evidence for the respective
reviewed feature heads.

Der Copilot-Review des ersten veröffentlichten Closeout-Heads meldete außerdem
zwei kleine, aber konkrete Wartbarkeitsbefunde. Die unbenutzte veraltete
Review-Archiv-Konstante wurde entfernt. Die Schema-1-Prüfung unterscheidet nun
zwischen fehlendem und abweichendem `preferredNext`, während Schema 2 weiterhin
höchstens ein ausdrücklich `Eligible` gesetztes Ziel erlaubt. Zwei neue
Negativfälle sichern diese Meldungen; die Suite bestand mit 10 Fällen. Diese
Befunde werden vor dem Merge geschlossen und nicht durch Admin-Rechte umgangen.

The Copilot review of the first published closeout head additionally reported
two small but concrete maintainability findings. The unused stale review-
archive constant was removed. Schema 1 validation now distinguishes a missing
from a mismatched `preferredNext`, while schema 2 continues to allow at most
one explicitly `Eligible` target. Two new negative cases protect these
messages, and the suite passed with 10 cases. These findings are closed before
merge and are not bypassed through admin authority.
