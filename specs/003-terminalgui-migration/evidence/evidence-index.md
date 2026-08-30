# Linearer Evidenzindex / Linear Evidence Index

## Zweck und Lesereihenfolge / Purpose and Reading Order

Jede Anforderungs-, Erfolgskriteriums-, User-Story- und Gate-ID besitzt in
diesem Dokument genau eine Primärzeile. `Pass lokal` gilt nur für beobachtete
Workspace-Evidenz. Provider-, Plattform-, Exact-Head-, Review-, Merge-, Sync-
und Closeout-Belege bleiben bis zu ihrer tatsächlichen Ausführung `Pending`.

*Each requirement, success criterion, user story, and gate identifier has
exactly one primary row. `Pass locally` covers only observed workspace proof.
Provider, platform, exact-head, review, merge, sync, and closeout proof remains
pending until it actually exists.*

## Funktionale Anforderungen / Functional Requirements

| Primär-ID / Primary ID | Zustand / State | Primäre Evidenz / Primary evidence |
|---|---|---|
| `FR-001` | `Pass lokal` | `dependencies/package-selection.md`, `packages-vulnerable.json` |
| `FR-002` | `Pass lokal` | `source-contract-green.md`, `manual-tui.md` |
| `FR-003` | `Pass lokal` | `source-contract-green.md`, `source-inventory.md` |
| `FR-004` | `Pass lokal` | `manual-tui.md`, `source-contract-green.md` |
| `FR-005` | `Pass lokal`; Plattform-Reproduktion `Pending` | `regression.md` |
| `FR-006` | `Pass lokal`; Plattform-Reproduktion `Pending` | `regression.md` |
| `FR-007` | `Pass lokal` | `manual-tui.md` |
| `FR-008` | `Pass lokal`; finaler Delivery-Diff `Pending` | `regression.md`, `documentation-review.md` |
| `FR-009` | `Pass lokal`; finaler Delivery-Diff `Pending` | `delivery-set-intent.md`, `documentation-review.md` |
| `FR-010` | `Pass lokal`; Exact-Head-Reproduktion `Pending` | `version-evidence.md`, `regression.md` |
| `FR-011` | `Pass lokal` | `docs/accessibility/terminalgui-migration.md`, `manual-tui.md` |
| `FR-012` | `Pass lokal`; Exact-Head-Rebind `Pending` | `dependencies/dependency-review.md`, `docs/security/dependency-audit.md`, `docs/security/supply-chain-evidence.md` |
| `FR-013` | `Pass lokal`; Exact-Head-Coverage `Pending` | `red-green-refactor/`, `coverage-summary.md`, `regression.md` |
| `FR-014` | `Pass lokal` | `documentation-review.md` |

## Verfassungsanforderungen / Constitution Requirements

| Primär-ID / Primary ID | Zustand / State | Primäre Evidenz / Primary evidence |
|---|---|---|
| `CR-001` | `Pass lokal` | `preflight.md`, `regression.md` |
| `CR-002` | `Pass lokal` | `docs/accessibility/terminalgui-migration.md` |
| `CR-003` | `Pass lokal` | `documentation-review.md` und die DE-first/EN-second-Artefakte |
| `CR-004` | `Pass lokal` | `docs/project-statistics.config.json`, `docs/project-statistics.md`, `autonomous-run-evidence.md` |
| `CR-005` | `Pass lokal` | `docs/security/security-checklist.md`, `docs/security/arc42-security.md` |
| `CR-006` | `Pass lokal`; Provideranteil `Pending` | `docs/security/security-checklist.md`, `threat-model.md`, `supply-chain-evidence.md` |
| `CR-007` | begründet `N/A` | `docs/security/arc42-security.md`, `asvs-verification.md` |
| `CR-008` | `Pass lokal`; SLSA-Providerbeleg `Pending` | `docs/security/sbom/tinycalc-terminalgui.spdx.json`, `supply-chain-evidence.md` |
| `CR-009` | begründet `N/A` | `docs/security/supply-chain-evidence.md` |
| `CR-010` | `Pass lokal` | `docs/security/threat-model.md` |
| `CR-011` | `Pass lokal` | `docs/security/README.md` und dessen indexierte Artefakte |
| `CR-012` | `Pass lokal` | `preflight.md`, `autonomous-run-evidence.md` |
| `CR-013` | `Pass lokal` | `documentation-review.md`, aktualisierte Zielartefakte |
| `CR-014` | `Pass lokal` | `documentation-review.md` |
| `CR-015` | `N/A` für API/DocFX; Kommentarprüfung `Pass` | `source-contract-green.md`, `documentation-review.md` |
| `CR-016` | `Pass lokal`; Exact-Head-Rebind `Pending` | `red-green-refactor/`, `coverage-summary.md` |

## Erfolgskriterien / Success Criteria

| Primär-ID / Primary ID | Zustand / State | Primäre Evidenz / Primary evidence |
|---|---|---|
| `SC-001` | `Pass lokal`; Delivery-Gates `Pending` | `us3-checkpoint.md`, dieser Index |
| `SC-002` | `Pass lokal` | `source-contract-green.md` |
| `SC-003` | `Pass lokal` | `manual-tui.md` |
| `SC-004` | `Pass lokal`; Plattform-Reproduktion `Pending` | `regression.md` |
| `SC-005` | `Pass lokal`; Plattform-Reproduktion `Pending` | `regression.md` |
| `SC-006` | `Pass lokal` | `manual-tui.md` |
| `SC-007` | `Pass lokal`; Exact-Head-Rebind `Pending` | `coverage-summary.md`, `red-green-refactor/` |
| `SC-008` | `Pass lokal`; Exact-Head-Rebind `Pending` | `dependencies/dependency-review.md`, `docs/security/supply-chain-evidence.md` |
| `SC-009` | `Pass lokal` | `docs/accessibility/terminalgui-migration.md` |
| `SC-010` | `Pass lokal`; finaler Delivery-Diff `Pending` | `regression.md`, `delivery-set-intent.md` |

## User Stories

| Primär-ID / Primary ID | Zustand / State | Primäre Evidenz / Primary evidence |
|---|---|---|
| `US1` | `Pass lokal` | `source-contract-green.md`, `manual-tui.md` |
| `US2` | `Pass lokal` | `manual-tui.md`, `docs/accessibility/terminalgui-migration.md` |
| `US3` | `Pass lokal`; Linux/Windows `Pending` | `us3-checkpoint.md`, `regression.md`, `coverage-summary.md` |
| `US4` | lokale Dokumentation `Pass`; Delivery `Pending` | `autonomous-run-evidence.md`, `delivery-set-intent.md`, `docs/PR_TEXT_TERMINALGUI_MIGRATION.md` |

## Autonome Gates / Autonomous Gates

| Primär-ID / Primary ID | Zustand / State | Primäre Evidenz / Primary evidence |
|---|---|---|
| `TG-GATE-001` | `Pass lokal` | `preflight.md`, `autonomous-run-evidence.md` |
| `TG-GATE-002` | `Pass lokal` | `plan.md` und alle bindenden Sidecars/Checklisten |
| `TG-GATE-003` | `Pass lokal` | `dependencies/package-selection.md`, `restore-final.txt` |
| `TG-GATE-004` | `Pass lokal`; Exact-Head-Rebind `Pending` | `dependencies/dependency-review.md`, maschinenlesbare Paketberichte |
| `TG-GATE-005` | `Pass lokal` | `source-contract-green.md`, `manual-tui.md` |
| `TG-GATE-006` | `Pass lokal` | `source-contract-green.md`, `manual-tui.md` |
| `TG-GATE-007` | `Pass lokal`; Exact-Head-Reproduktion `Pending` | `regression.md`, `version-evidence.md` |
| `TG-GATE-008` | `Pass lokal`; Plattform-Reproduktion `Pending` | `regression.md` |
| `TG-GATE-009` | `Pass lokal`; Plattform-Reproduktion `Pending` | `regression.md` |
| `TG-GATE-010` | `Pass lokal` | `red-green-refactor/` |
| `TG-GATE-011` | `Pass lokal`; Exact-Head-Rebind `Pending` | `coverage-summary.md` |
| `TG-GATE-012` | `Pass lokal` | `manual-tui.md` |
| `TG-GATE-013` | `Pass lokal` | `docs/accessibility/terminalgui-migration.md` |
| `TG-GATE-014` | `Pass lokal` | `documentation-review.md` |
| `TG-GATE-015` | vorläufig `Pass`; finaler Diff `Pending` | `delivery-set-intent.md` |
| `TG-GATE-016` | `Pass lokal` | `docs/security/threat-model.md` |
| `TG-GATE-017` | `Pass lokal` | `docs/security/security-checklist.md`, `docs/security/README.md` |
| `TG-GATE-018` | `Pass lokal`; Exact-Head-Rebind `Pending` | `docs/security/security-quality-scenarios.md`, `samm-assessment.md` |
| `TG-GATE-019` | `Pass lokal`; Commit-Bindung `Pending` | `docs/security/sbom/tinycalc-terminalgui.spdx.json`, `sbom-generation.md` |
| `TG-GATE-020` | lokale Haltung `Pass`; Provider-Provenance `Pending` | `docs/security/supply-chain-evidence.md` |
| `TG-GATE-021` | `Pass lokal` | datierter Review in `docs/security/supply-chain-evidence.md` |
| `TG-GATE-022` | bedingt `N/A` | `docs/security/supply-chain-evidence.md` |
| `TG-GATE-023` | begründet `N/A` | `docs/security/arc42-security.md`, `asvs-verification.md` |
| `TG-GATE-024` | begründet `N/A` | `docs/security/supply-chain-evidence.md` |
| `TG-GATE-025` | begründet `N/A` | `docs/security/arc42-security.md`, `zero-trust-applicability.md` |
| `TG-GATE-026` | begründet `N/A` | `docs/security/arc42-security.md` |
| `TG-GATE-027` | begründet `N/A` | `docs/security/arc42-security.md` |
| `TG-GATE-028` | kein Feature-Delta / `N/A` | `docs/security/arc42-security.md` |
| `TG-GATE-029` | `Pass lokal` | `docs/security/adr/003-terminalgui-lifecycle-supply-chain.md` |
| `TG-GATE-030` | `Pass lokal` | `docs/security/arc42-security.md` |
| `TG-GATE-031` | begründet `N/A` | `autonomous-run-evidence.md` |
| `TG-GATE-032` | begründet `N/A` | `autonomous-run-evidence.md` |
| `TG-GATE-033` | begründet `N/A` | `autonomous-run-evidence.md` |
| `TG-GATE-034` | begründet `N/A` | `autonomous-run-evidence.md` |
| `TG-GATE-035` | Zwischenstand `Pass`; finale Commitzahl `Pending` | `version-evidence.md`, `Directory.Build.props` |
| `TG-GATE-036` | `Pass lokal` | `docs/project-statistics.config.json`, `docs/project-statistics.md` |
| `TG-GATE-037` | `Pending` | `platform-ci.md`: echter Ubuntu-Produktjob am PR-Head fehlt noch |
| `TG-GATE-038` | `Pending` | `platform-ci.md`: echter Windows-Produktjob am PR-Head fehlt noch |
| `TG-GATE-039` | vorläufig `Pass`; Commitbeleg `Pending` | `delivery-set-intent.md`, späterer Index-/Commit-Diff |
| `TG-GATE-040` | `Pending` | spätere Schema-2.0 PreMerge-/PostMerge- und Closeout-Evidenz |
| `TG-GATE-041` | `Pending` | späterer unveränderter Review-Head und aufgelöste Threads |
| `TG-GATE-042` | `Pending` | späterer fokussierter `MergeAndSync`-Beleg |
| `TG-GATE-043` | `Pending` | späterer Fast-forward-Sync auf den Produkt-Merge-Commit |
| `TG-GATE-044` | `Pending` | späterer branchgestempelter Intake und autorisierter Serien-Closeout |
| `TG-GATE-045` | `Pending` | späterer read-only Serien-/Providerabschluss ohne Folgefeature |
| `TG-GATE-046` | begründet `N/A` | `docs/security/supply-chain-evidence.md` |
| `TG-GATE-047` | Autorität vorhanden; konkrete PR-Revalidierung `Pending` | `autonomous-run-evidence.md` |
| `TG-GATE-048` | `Pending` | spätere unmittelbare Trailerprüfung jedes tatsächlichen Commits |

## Linearer Abschluss / Linear Closeout

Der nächste sichere Schritt ist die minimale, bereits autorisierte Änderung
von `.github/workflows/ci.yml`. Erst reale Providerdaten dürfen die als
`Pending` markierten Zeilen umstufen. FakeDriver, Rename, Core, vorhandene
Tests, Skripte, Agentenflächen, andere Workflows und Folgefeatures bleiben
außerhalb dieses Liefergegenstands.

*The next safe step is the minimum authorised change to the CI workflow. Only
real provider data may advance pending rows. FakeDriver, rename, Core, existing
tests, scripts, agent surfaces, other workflows, and successor features remain
outside this delivery.*
