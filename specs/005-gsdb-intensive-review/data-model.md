# Data Model: GSDB-Intensivpruefung / Intensive GSDB Review

## Zweck / Purpose

**DE:** Dieses Modell beschreibt die spaeter zu erzeugende
`evidence-matrix.json` und ihre Beziehungen. Es ist ein Pruefvertrag, kein
Sicherheitszertifikat und keine menschliche Freigabe.

**EN:** This model describes the future `evidence-matrix.json` and its
relationships. It is an assessment contract, not a security certificate or
human approval.

## Entity Relationship Overview / Entitaetsuebersicht

```text
Assessment
  |-- SourceBinding[] --------> real repository files
  |-- ChecklistRow[157] ------> exactly one canonical CL item each
  |-- ExternalDuty[] ---------> guideline/related duties outside CL IDs
  |-- PresetAssessment[13] ---> installed preset and mapped checkpoints
  |-- Finding[] --------------> gaps, conflicts, or hardening follow-up
  `-- Summary ----------------> counts derived from the collections above

ChecklistRow | ExternalDuty | PresetAssessment
  `-- EvidenceReference[] ----> source/evidence path plus exact locator

GateRequirement[] -----------> future schema-2.0 PreMerge/PostMerge entries
```

The text above is the complete relationship description; lines and indentation
are not the only carrier of meaning.

## Assessment

| Field | Type | Rule |
|---|---|---|
| `schemaVersion` | string | Exactly `1.0` for the feature matrix contract. |
| `assessmentId` | string | Exactly `tinycalc-gsdb-intensive-review-005`. |
| `reviewedAt` | date | ISO `YYYY-MM-DD`; the observation date, not a claimed approval date. |
| `repository` | string | Exactly `TinyCalc`. |
| `featurePath` | safe relative path | Exactly `specs/005-gsdb-intensive-review`. |
| `baseline` | object | Manifest path, version, normalized hash, observed CL count. |
| `sourceInventory` | `SourceBinding[]` | Complete controlled and assessed-source inventory. |
| `checklistRows` | `ChecklistRow[]` | Exactly 157 rows and exact equality with canonical IDs. |
| `externalDuties` | `ExternalDuty[]` | Guideline/related duties not represented by CL IDs. |
| `presetAssessments` | `PresetAssessment[]` | Exactly 13 installed preset IDs at the reviewed inventory. |
| `findings` | `Finding[]` | Every open gap/conflict and prioritised hardening candidate. |
| `summary` | `Summary` | Derived values; never manually trusted over row data. |

## Baseline Binding / Baseline-Bindung

| Field | Type | Rule |
|---|---|---|
| `manifestPath` | safe relative path | `docs/secure-development/baseline-manifest.json`. |
| `baselineVersion` | string | Must equal the real manifest value. |
| `manifestNormalizedSha256` | digest | Lowercase 64-character normalized SHA-256. |
| `declaredChecklistItemCount` | integer | Must equal the real manifest value. |
| `observedChecklistItemCount` | integer | Derived from canonical checklist headings; must equal 157 for the current accepted baseline. |
| `compendiumParity` | enum | `Matched` or `Finding`; never inferred from counts alone. |

## SourceBinding / Quellenbindung

| Field | Type | Rule |
|---|---|---|
| `sourceId` | stable string | Unique within the assessment. |
| `sourceClass` | enum | `Guideline`, `Checklist`, `Compendium`, `RelatedDocument`, `LearningDocument`, `ManagedReference`, `ManagedBinary`, `Constitution`, `Preset`, `ProjectEvidence`, `Workflow`, `Validator`, `Registry`, or `IntakeEvidence`. |
| `path` | safe relative path | No absolute path, drive prefix, `..`, secret path, or missing file. |
| `version` | non-blank string | Source version or explicit `Unversioned` with rationale in scope. |
| `reviewedAt` | date | Current observation date. |
| `normalizedSha256` | digest | UTF-8/LF-normalized lowercase SHA-256 for text; raw lowercase SHA-256 for managed binary. |
| `scope` | bilingual text | What part of the source is used. |
| `freshness` | enum | `Current`, `Revalidated`, `Stale`, `Conflicting`, or `Unresolved`. |
| `locator` | non-blank text | Heading, ID, JSON pointer, registry key, workflow job/step, or equivalent stable locator. |
| `findingIds` | unique string array | Findings caused by drift/conflict; empty only when none observed. |

### Source inventory completeness

- Every manifest-controlled guideline, checklist, compendium, related document,
  learning document, managed reference, and binary/hash pair is present.
- Both constitutions are separate bindings even when hashes match.
- Every installed preset, relevant workflow, validator, Feature-004 evidence
  root, current run/intake/series record, and Level-2 registry source is present.
- The 12 checklist paths match the manifest family mapping exactly.
- A stale or conflicting source remains inventoried and links to a finding.

## EvidenceReference / Evidenzverweis

| Field | Type | Rule |
|---|---|---|
| `path` | safe relative path | Must exist at validation time unless `availability` is `Planned` for an explicitly future artefact. |
| `locator` | non-blank text | Exact heading, control ID, JSON pointer, immutable run/job ID, or provider URL. |
| `observedAt` | date-time/date | When the evidence was checked. |
| `freshness` | enum | `Current`, `Revalidated`, `Stale`, `Conflicting`, or `Planned`. |
| `availability` | enum | `Existing`, `Planned`, or `Unavailable`. |
| `supports` | bilingual text | Exact claim supported; file existence alone is invalid. |

Rules:

1. Positive `Fulfilled` claims need at least one `Existing` and non-stale
   reference with a concrete locator.
2. `Planned` or `Unavailable` evidence cannot support `Fulfilled`.
3. Provider evidence complements but does not replace repository evidence
   required by the row contract.
4. No secret, token, private absolute path, or personal data is copied.

## ChecklistRow / Checklistenzeile

| Field | Type | Rule |
|---|---|---|
| `id` | string | `CL-01-01` through the exact canonical set; unique. |
| `sourcePath` | safe relative path | Must match the ID family and canonical checklist. |
| `sourceLocator` | non-blank text | Canonical heading text or equivalent stable anchor. |
| `applicability` | enum | `Applicable`, `N/A`, or `Open`. |
| `implementationStatus` | enum | `Fulfilled`, `Partly Fulfilled`, `Not Fulfilled`, or `Not Assessed`. |
| `learningStage` | enum | `Foundation`, `Intermediate`, or `Advanced`, derived from the canonical learning path. |
| `rationale` | bilingual text | Explains both axes without blanket claims. |
| `evidence` | `EvidenceReference[]` | Concrete supporting evidence or explicit planned/unavailable reference. |
| `owner` | non-blank text | Responsible role/person for the control or follow-up. |
| `reviewer` | non-blank text | Appropriate independent/specialist review role; unassigned blocks `Fulfilled` and makes applicability `Open` only when the reviewer must determine scope. |
| `followUp` | bilingual text | Concrete next action or explicit no-action rationale for evidenced fulfilment. |
| `expectedEvidence` | bilingual text | Concrete proof expected from follow-up, or justified no-additional-evidence text for fulfilled rows. |
| `targetDueAt` | date or `N/A` | ISO date for `Open`, `Partly Fulfilled`, `Not Fulfilled`, or `Not Assessed`; justified `N/A` only for fulfilled rows with no follow-up. |
| `reevaluationTrigger` | bilingual text | Concrete event that invalidates/reopens the decision. |
| `residualRisk` | bilingual text | Remaining risk after the current assessment. |
| `severity` | enum | `Critical`, `High`, `Medium`, `Low`, or `None`. |
| `humanOnly` | boolean | True for decisions an agent cannot perform or claim. |
| `humanDecisionEvidence` | string | Exactly `NotProvided` in this agent-authored Feature-005 matrix. Genuine later human evidence remains external and requires a separately authorised schema/review update. |
| `findingIds` | unique string array | Links open gaps/conflicts to `Finding`. |

### Checklist row invariants

1. Exactly 157 IDs are present; missing, duplicate, unknown, or wrong-family
   IDs fail.
2. `N/A` requires `Not Assessed`, rationale, follow-up, trigger, residual risk,
   owner, reviewer, learning stage, expected evidence, and target-date
   disposition.
3. `Applicable` + `Fulfilled` requires current concrete evidence and no
   unresolved contradiction for that claim.
4. `Open` means unresolved applicability only. Missing or unavailable
   fulfilment evidence blocks `Fulfilled`, requires a linked finding and due
   follow-up, and leaves known scope `Applicable`.
5. `humanOnly: true` with `NotProvided` cannot be `Fulfilled`.
6. A missing required reviewer blocks `Fulfilled` and links a finding. It uses
   applicability `Open` only when that reviewer is needed to decide scope.
7. Severity `None` is allowed only when no open control/finding risk remains.
8. Training year never changes project applicability.

## ExternalDuty / Externe Pflicht

| Field | Type | Rule |
|---|---|---|
| `id` | string | Stable `GSDB-DUTY-NNN`; unique. |
| `sourceId` | string | Existing `SourceBinding.sourceId`. |
| `sourceLocator` | non-blank text | Exact duty location. |
| `mappedChecklistIds` | unique ID array | Zero or more related CL IDs; empty explains why this duty is outside CL coverage. |
| status/evidence/learning/ownership fields | same as `ChecklistRow` | Same two-axis, freshness, learning-stage, target-date, Human-only, and follow-up rules. |

## PresetAssessment / Preset-Bewertung

| Field | Type | Rule |
|---|---|---|
| `presetId` | string | One of the 13 actually installed preset IDs; unique. |
| `version` | string | Exact installed version. |
| `priority` | integer or string | Binding priority, or explicit `NotInStandardMatrix` for additional presets. |
| `standardMatrixMember` | boolean | True for exactly the eight standard presets. |
| `applicability` | enum | `Applicable`, `N/A`, or `Open`. |
| `mappedChecklistIds` | unique ID array | Relevant CL IDs. |
| `mappedGateIds` | unique gate-ID array | Relevant Feature-005 gates. |
| `evidence` | `EvidenceReference[]` | Actual install/mapping evidence. |
| `rationale`, `owner`, `reviewer`, `followUp`, `reevaluationTrigger`, `residualRisk` | text | Mandatory for every row. |

An inventory row without checkpoint mapping is incomplete. Parallel campaign
execution is N/A with the explicit-delegation trigger; the preset itself still
remains inventoried and reviewed.

## Finding / Befund

| Field | Type | Rule |
|---|---|---|
| `id` | string | Stable `GSDB-FINDING-NNN`; unique and sortable. |
| `severity` | enum | `Critical`, `High`, `Medium`, or `Low`. |
| `sourceReferences` | unique string array | CL IDs, duty IDs, preset IDs, or source IDs. |
| `title` | bilingual text | Short and factual. |
| `observation` | bilingual text | Date, scope, exact locator, and contradiction/gap. |
| `owner` | non-blank text | Named role/person; no silent unowned finding. |
| `reviewer` | non-blank text | Specialist/human boundary as applicable. |
| `followUp` | bilingual text | Separately authorised concrete hardening or evidence action. |
| `reevaluationTrigger` | bilingual text | Event or date that reopens review. |
| `residualRisk` | bilingual text | Honest remaining exposure. |
| `deliveryImpact` | enum | `BlocksReview`, `BlocksDelivery`, or `DoesNotBlockCompletedAssessment`. |
| `status` | enum | `Open`, `AcceptedByHumanEvidence`, or `ResolvedByEvidence`. |

A complete assessment may contain `DoesNotBlockCompletedAssessment` open
product-hardening findings. Missing source/ID coverage, missing mandatory
fields, failed technical gates, or missing delivery evidence blocks completion.

## Summary

The validator derives and compares:

- `checklistTotal` = 157;
- per-family counts = 12/13/15/10/13/11/12/13/17/17/12/12;
- counts by applicability and implementation status;
- `humanOnlyTotal`, `openFindingTotal`, and severity totals;
- `sourceInventoryTotal` and counts by source class/freshness;
- `presetTotal` = 13 and `standardPresetTotal` = 8;
- `externalDutyTotal` from the actual duty collection;
- zero unexplained missing/duplicate/unknown IDs;
- zero unsupported Human-only, legal, security, approval, or certification
  claims.

## GateRequirement and GateEvidence

`contracts/autonomous-run-gate-requirements.json` uses requirements schema 1.0
because that is the installed validator contract. Each row contains stable
`gateId`, `Applicable` or `N/A`, exact scope, command tokens, runner/platform
tokens, rationale, and trigger.

New lifecycle evidence uses schema 2.0:

```text
Declared requirement (accepted before implementation)
  -> PreMerge (temporary; exact reviewed head; one Primary per gate)
  -> provider merge commit
  -> PostMerge (accepted PreMerge hash; merge commit; changedPaths = [])
  -> final run-state closeout
```

No arrow grants authority by itself. Every transition revalidates current
authority, head, requirements hash, and material gate status.

## State Transitions / Zustandsuebergaenge

```text
Unassessed
  -> N/A + Not Assessed + rationale/trigger
  -> Open + Not Assessed while applicability remains unresolved
  -> Applicable + Not/Partly Fulfilled
  -> Applicable + Fulfilled + current evidence

Any assessed state
  -> Open on source/evidence/reviewer drift
  -> reassess on trigger

Human-only + NotProvided
  -> remains non-Fulfilled
  -> changes only after genuine human evidence and fresh review
```

## Validation Failure Classes / Validierungsfehler

- `GSDB001`: Missing file, invalid UTF-8/JSON, or schema violation.
- `GSDB002`: Baseline/source inventory missing, stale hash, unsafe path, or
  unbound managed reference.
- `GSDB003`: Canonical CL ID missing, duplicate, unknown, or wrong-family.
- `GSDB004`: Compendium ID/content parity or source precedence violation.
- `GSDB005`: Invalid applicability/implementation combination or missing
  learning stage/rationale/owner/reviewer/follow-up/expected evidence/target
  date/trigger/residual risk.
- `GSDB006`: Positive claim lacks current concrete evidence or locator.
- `GSDB007`: Human-only, legal, certification, or approval boundary violated.
- `GSDB008`: External-duty, preset, workflow, or validator coverage incomplete.
- `GSDB009`: Finding linkage, priority, or delivery-impact rule invalid.
- `GSDB010`: Summary count, deterministic ordering, date, or normalized hash
  drift.
