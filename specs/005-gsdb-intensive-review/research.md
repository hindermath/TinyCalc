# Research: GSDB-Intensivpruefung / Intensive GSDB Review

## Zweck / Purpose

**DE:** Dieses Dokument haelt die technischen und fachlichen Entscheidungen
fest, die den Implementierungsplan reproduzierbar machen.

**EN:** This document records the technical and domain decisions that make the
implementation plan reproducible.

## Forschungsrahmen / Research Frame

**DE:** Die Forschung bindet nur Feature 005 und den akzeptierten GSDB-Intake.
Sie dokumentiert den am 2026-09-06 beobachteten Ausgangsstand. Ein vorhandener
Pfad oder frueherer Pass ist noch keine aktuelle Erfuellung. Produkt-Haertung,
rechtliche Freigabe, Zertifizierung und menschliche Risikoakzeptanz bleiben
ausserhalb dieser Arbeit.

**EN:** This research binds only Feature 005 and the accepted GSDB intake. It
records the baseline observed on 2026-09-06. An existing path or earlier pass
is not current fulfilment by itself. Product hardening, legal approval,
certification, and human risk acceptance remain outside this work.

## R-001 - Kanonische GSDB-Basis / Canonical GSDB Baseline

**Entscheidung / Decision:** `docs/secure-development/baseline-manifest.json`
Version 3.2.0 controls scope and versions. Its current SHA-256 is
`e7739adbf67b2d0f16273f52839c2cb6d4807753f7246b33bac6969b59355ad3`.
The guideline is 3.2.0, the compendium is 2.2.0 and generated, CL-01 through
CL-08 and CL-10/CL-11 are 2.0.0, and CL-09/CL-12 are 2.2.0. The manifest also
controls 15 related documents, one learning document, four managed reference
files (two index files and two translations), and two managed binary/integrity
files (the PDF and its checksum file).

**Begruendung / Rationale:** The manifest is the only bounded inventory. The
individual checklist files are canonical for stable IDs and control wording;
the compendium is a derived reader view. Related documents may contain duties
outside the 157 CL IDs, so they receive separate external-duty rows.

## R-002 - Verifizierte ID-Verteilung / Verified ID Distribution

**Entscheidung / Decision:** IDs are derived only from headings matching
`^#### CL-(0[1-9]|1[0-2])-[0-9]{2}:`. The observed counts are:

| Family | IDs | Area |
|---|---:|---|
| CL-01 | 12 | Standards applicability |
| CL-02 | 13 | Secure architecture |
| CL-03 | 15 | Cryptographic minimum rules |
| CL-04 | 10 | Threat modelling |
| CL-05 | 13 | Supply chain/build integrity |
| CL-06 | 11 | Vulnerability disclosure |
| CL-07 | 12 | CRA applicability |
| CL-08 | 13 | Security code review |
| CL-09 | 17 | AI-assisted code generation |
| CL-10 | 17 | Secure development environment |
| CL-11 | 12 | Privacy impact assessment |
| CL-12 | 12 | Agentic AI sandbox |
| **Total** | **157** | **12 families** |

**Begruendung / Rationale:** The generated compendium also contains exactly 157
unique and 157 total CL-ID occurrences. Implementation must compare full
canonical blocks as well as identity/count; matching counts alone do not prove
content parity.

## R-003 - Quellenrangfolge und Konflikte / Source Precedence and Conflicts

**Entscheidung / Decision:** Precedence is: accepted intake for feature scope;
both constitutions for governance; baseline manifest for controlled inventory;
individual CL file for a checklist item; guideline/related documents for
cross-cutting duties; compendium only as generated parity view; current project
artefact for TinyCalc evidence. A contradiction creates a finding and never a
silent source selection.

**Begruendung / Rationale:** This order separates requirement authority,
generic control wording, and project evidence. It also prevents the generated
compendium or old project reports from overriding canonical sources.

## R-004 - Feature-004-Evidenzgrenze / Feature 004 Evidence Boundary

**Entscheidung / Decision:** Feature 004 is a reusable source only after scope,
date, hash, locator, and contradiction review. Its current validator reports
157/157 IDs. Its matrix records 21 `AlreadySatisfied`, 32 `N/A`, 42 `Open`, and
62 `FollowUp` rows; 104 rows therefore remain open or follow-up. Closure marks
technical validation fulfilled, while pilot authorization, project acceptance,
and general release remain `Open` with `NotProvided` evidence.

**Begruendung / Rationale:** Feature 004 proves that its own contract passed; it
does not prove Feature-005 completeness, current vulnerability state, legal
scope, provider posture, or human approval. Its 30 source bindings match the
current baseline hashes at planning time, but implementation re-computes them.

## R-005 - Status- und Human-only-Modell / Status and Human-only Model

**Entscheidung / Decision:** Each assessment row has two independent axes:
`Applicable`, `N/A`, or `Open`; and `Fulfilled`, `Partly Fulfilled`,
`Not Fulfilled`, or `Not Assessed`. `Open` is reserved for unresolved
applicability. `N/A` requires `Not Assessed`, rationale, owner, reviewer,
follow-up, trigger, and residual risk. Missing fulfilment evidence prevents
`Fulfilled`, requires a finding and due follow-up, but leaves known scope
`Applicable`. A Human-only row cannot be `Fulfilled` from agent evidence and
records `humanDecisionEvidence: "NotProvided"`. This Feature-005 schema accepts
no agent-authored human decision record; genuine later human evidence remains
an external reference and requires a separately authorised schema/review update.

**Begruendung / Rationale:** Applicability is not success. This model prevents
an absent reviewer, formal approval, legal decision, secret rotation, provider
approval, or branch-protection decision from becoming an inferred pass.

## R-006 - Evidenzstaerke und Aktualitaet / Evidence Strength and Freshness

**Entscheidung / Decision:** Evidence must use repository-relative paths and a
concrete locator (heading, ID, JSON pointer, line-independent key, immutable run
ID, or provider URL). Each reference records observation date, freshness
classification, and the exact claim it supports. File existence, directory
presence, green aggregate names, and stale clean scans are insufficient.

**Begruendung / Rationale:** Locators and timestamps make reuse reviewable and
reduce false positive fulfilment. Absolute/private paths, secrets, tokens,
personal data, and mutable unqualified links are forbidden.

## R-007 - Matrixvertrag und Validator / Matrix Contract and Validator

**Entscheidung / Decision:** Create a new Feature-005 JSON Schema and a paired
validator. `Test-GsdbIntensiveReview` in PowerShell owns typed semantic checks;
`validate-gsdb-intensive-review.ps1` exposes the script interface and the Bash
wrapper delegates with `pwsh -NoProfile`. Ship bilingual comment-based help,
one man page, a script-parity checklist, deterministic fixtures, and Linux/
Windows CI coverage. The row contract includes the GSDB-required learning stage,
expected follow-up evidence, and target date. `-WhatIf`/dry-run is N/A because
both entrypoints are read-only; any later mutation is its re-evaluation trigger.

**Begruendung / Rationale:** The Feature-004 validator does not enforce reviewer
and locator fields, non-CL duties, preset coverage, compendium content parity,
or current-freshness rules. One semantic engine avoids PowerShell/Bash drift.
No new runtime or product dependency is required.

## R-008 - TDD-Nachweis / TDD Evidence

**Entscheidung / Decision:** RED is repeatable through a fresh missing path and
focused malformed fixtures, including omitted learning stage, expected evidence,
or required target date. GREEN first accepts one valid source/row helper,
then the full production document only at complete scope. Regression runs both
entrypoints and all negative fixtures. Expected failures are isolated and must
show the named `GSDB...` failure class and non-zero exit.

**Begruendung / Rationale:** The approach demonstrates that the validator can
fail for owned reasons without pretending a one-row fixture is a valid
157-row production assessment. Product-code coverage remains N/A because no
product code changes.

## R-009 - Constitution und Level-2-Registry / Constitution and Registry

**Entscheidung / Decision:** `constitution.md` and
`.specify/memory/constitution.md` are byte-identical at
`c57f6e586d93a48b2254550367289e9e3e3ba6645ebb8f308f2e9e24dc7c93b9`.
The `RiderProjects/TinyCalc` row binds .NET 10/C#, `MicroCalc.sln`, xUnit, TUI
smoke, DocFX/A11Y coupling, DE-first/EN-second CEFR B2, statistics baselines
80/125 lines per workday, and five coordinated agent surfaces.

**Begruendung / Rationale:** Feature planning can use one shared rule set but
must keep both paths in the source inventory. A future mismatch is a blocking
governance finding, not an assumed intentional divergence.

## R-010 - Preset-Inventar / Preset Inventory

**Entscheidung / Decision:** The installed set contains 13 presets. The binding
standard matrix is security 0.6.2/10, architecture 0.5.2/20, iSAQB 0.2.2/30,
A11Y 0.4.3/40, cross-platform 0.2.2/50, agent parity 0.4.2/60, autonomous
0.4.1/70, and parallel autonomous 0.2.6/80. Additional installed presets are
secure-development-assurance 0.1.2, model-routing 0.1.4, intake-authoring
0.3.1, intake-review 0.2.1, and intake-sequencing 0.2.3.

**Begruendung / Rationale:** All 13 require a disposition and mapping. Old
six-/seven-preset wording is classified as drift. Parallel campaign execution
is N/A because only one feature is commissioned; explicit multi-target
delegation is its trigger. Concrete model names are runtime-only and never
enter feature artefacts.

## R-011 - Sicherheitsstandards / Security Standards

**Entscheidung / Decision:** NIST SSDF and CWE Top 25 are always Applicable.
STRIDE/CIA/CAPEC, C# secure coding, SBOM, SLSA/provenance, OpenSSF supporting
evidence, OWASP SAMM, and delivery-environment Zero Trust are Applicable.
VEX is an Applicable decision gate driven by a current scan. ASVS, product
AI-SBOM, and product Zero Trust are N/A with Web/API/auth, AI-runtime, and
distributed-architecture triggers respectively. BSI C3A/C5, NIS2, CRA, EU AI
Act, DORA, and privacy require separate current applicability records; legal
approval is Human-only.

Dependency-update automation is currently absent: no local Dependabot or
Renovate configuration and no central Dependency-Track ingestion was found on
2026-09-06. The assessment records this as owned CL-05 follow-up and checks any
provider-side alert evidence separately; it does not introduce automation
without a separate hardening decision.

**Begruendung / Rationale:** The disposition follows Principles XI-XVIII and
the actual local-TUI plus remote-delivery architecture. `docs/security/` has
the core Feature-003 evidence and Feature-004 assessment context, but the
default regulatory, cloud-autonomy, and cloud-compliance files named by the
current specification are absent and must be created as evidence, not assumed.

## R-012 - Architekturentscheidung / Architecture Decision

**Entscheidung / Decision:** No product component, interface, runtime flow,
deployment, topology, ADR, or S-ADR is changed. Existing context, building-
block, runtime and deployment views, product trust boundaries, Defense in Depth,
Least Privilege, Fail-Safe Defaults, Attack Surface Reduction, separation of
security concerns, secure configuration, technical debt, and current
architecture/security documents are assessed. Findings become matrix rows and
follow-up, not automatic design changes.

**Begruendung / Rationale:** The requested result is an assessment. A new ADR
would falsely imply an architectural decision. The trigger for ADR/S-ADR work
is a separately authorised decision affecting structure, integration, quality
attributes, trust boundaries, or deployment.

## R-013 - Workflows und tatsaechliche Runner / Workflows and Actual Runners

**Entscheidung / Decision:** Gate requirements use command and runner tokens
from workflow definitions, then require job-log confirmation at delivery. The
main `ci` job runs restore/build/test/smoke on Ubuntu and Windows. Homogeneity
and agent-secret parity runs on Ubuntu, macOS, and Windows. Requirements intake
governance runs on all three. PSScriptAnalyzer currently resolves to Ubuntu for
TinyCalc. Separate Ubuntu jobs run agent-secret scan and gitleaks.

**Begruendung / Rationale:** A job name or matrix label does not prove the
executed command. Exact PreMerge evidence must quote the command observed in
the workflow definition or immutable job log and bind it to the reviewed head.

## R-014 - Dokumentation und A11Y / Documentation and Accessibility

**Entscheidung / Decision:** Documentation Impact is `UpdateRequired`. New
Markdown is DE-first/EN-second, CEFR B2, semantic, text-first, uses correct
German umlauts and `ß`, and is reviewed for WCAG 2.2 AA criteria applicable to
structure, reading order, links, headings, and non-colour meaning.
`docs/security/README.md` gains the reader-path link. Because `docfx.json`
includes all `docs/**/*.md`, DocFX regeneration and a representative lynx HTML
smoke are Applicable in the same work item. Playwright/axe is the preferred
additional check when its reviewed harness is available; absence is recorded
explicitly.

**Begruendung / Rationale:** The implementation delivers learner-facing and
review-facing evidence. A text review is valid scoped evidence but is not a
screen-reader user test or global WCAG certification.

## R-015 - Regression und Versionierung / Regression and Versioning

**Entscheidung / Decision:** Documentation-only scope does not waive consumer
regressions. Before build/test, align the repository version to feature minor 5,
the prospective feature-branch commit count including the pending commit, and
a freshly incremented build counter. Run restore, Release build, all xUnit
tests, and exact TUI `SMOKE_OK`.
Also run the matrix, governance, documentation, statistics, homogeneity,
secret, intake, and static-analysis gates selected in the gate contract.

**Begruendung / Rationale:** Evidence schemas, scripts, and CI configuration
are executable consumers even when product behavior is not intentionally
changed. The 70% minimum and 80% target apply only if product code changes;
such a delta is outside scope and blocks until re-planned.

## R-016 - Schema-2.0-Liefervertrag / Schema 2.0 Delivery Contract

**Entscheidung / Decision:** Gate requirements use the installed validator's
schema 1.0 template. New PreMerge and PostMerge evidence uses schema 2.0. The
requirements artifact is accepted before implementation; PreMerge remains
temporary and exact-head bound; PostMerge binds its normalized hash and the
actual merge commit with empty `changedPaths`.

**Begruendung / Rationale:** Calling the requirements document schema 2.0 would
make it invalid against the installed validator. Schema 2.0 belongs to new gate
evidence, while phase results remain schema 1.0. Historical schema-1.0 delivery
evidence is audit-only and never authorises this merge.

## R-017 - PR, Admin-Bypass und kausaler Abschluss / PR, Admin Bypass, and Causal Closeout

**Entscheidung / Decision:** Exact-head review and all material gates precede
merge. Normal merge is preferred. The Admin-Bypass gate begins N/A and can be
changed only when the sole remaining blocker is formal; changing it requires a
new reviewed head and regenerated PreMerge evidence. The causal closeout may
use only `codex/005-gsdb-intensive-review-closeout`, branch-stamp only the GSDB
intake, update the series once, validate both PowerShell and Bash closeout paths,
record PostMerge and sync, and must not start another intake.

**Begruendung / Rationale:** This preserves the accepted MergeAndSync authority
without treating bypass as security evidence or human specialist approval.
Post-merge and series facts cannot truthfully be recorded before the merge.

## R-018 - Serienstatus und Zielauswahl / Series Status and Target Selection

**Entscheidung / Decision:** The current manifest validator reports GSDB as the
only `declaredEligible` target, while its graph calculation also lists the TUI
field-test and sandbox-hardening roots as structurally eligible. Current run
authority selects only GSDB. The other roots remain unselected non-targets and
must not be started or mutated by Feature 005.

**Begruendung / Rationale:** This distinction resolves the apparent conflict
between readable evidence saying “only eligible” and the validator's separate
`eligible` and `declaredEligible` arrays. Implementation records the wording
drift as a traceable source/reconciliation item rather than silently choosing
one interpretation.

## Alternatives Rejected / Verworfene Alternativen

- **Feature-004-Matrix unveraendert kopieren / Copy Feature 004 unchanged:**
  rejected because Feature 005 has stricter source, reviewer, locator, preset,
  and freshness obligations.
- **Nur Markdown ohne Vertrag / Markdown only:** rejected because silent ID,
  source, status, or summary omissions would not fail deterministically.
- **Zwei unabhaengige Validatoren / Two independent validators:** rejected due
  to semantic drift; Bash delegates to the typed PowerShell contract.
- **Automatische Haertung / Automatic hardening:** rejected as out of scope and
  contrary to the accepted intake.
- **Vorab committed exact-head evidence / Commit exact-head evidence early:**
  rejected because the commit would invalidate its own reviewed-head claim.
