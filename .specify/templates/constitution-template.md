# [PROJECT_NAME] Constitution
<!-- Example: Spec Constitution, TaskFlow Constitution, etc. -->

## Core Principles

### [PRINCIPLE_1_NAME]
<!-- Example: I. Library-First -->
[PRINCIPLE_1_DESCRIPTION]
<!-- Example: Every feature starts as a standalone library; Libraries must be self-contained, independently testable, documented; Clear purpose required - no organizational-only libraries -->

### [PRINCIPLE_2_NAME]
<!-- Example: II. CLI Interface -->
[PRINCIPLE_2_DESCRIPTION]
<!-- Example: Every library exposes functionality via CLI; Text in/out protocol: stdin/args → stdout, errors → stderr; Support JSON + human-readable formats -->

### [PRINCIPLE_3_NAME]
<!-- Example: III. Test-First (NON-NEGOTIABLE) -->
[PRINCIPLE_3_DESCRIPTION]
<!-- Example: TDD mandatory: Tests written → User approved → Tests fail → Then implement; Red-Green-Refactor cycle strictly enforced -->

### [PRINCIPLE_4_NAME]
<!-- Example: IV. Integration Testing -->
[PRINCIPLE_4_DESCRIPTION]
<!-- Example: Focus areas requiring integration tests: New library contract tests, Contract changes, Inter-service communication, Shared schemas -->

### [PRINCIPLE_5_NAME]
<!-- Example: V. Observability, VI. Versioning & Breaking Changes, VII. Simplicity -->
[PRINCIPLE_5_DESCRIPTION]
<!-- Example: Text I/O ensures debuggability; Structured logging required; Or: MAJOR.MINOR.BUILD format; Or: Start simple, YAGNI principles -->

## [SECTION_2_NAME]
<!-- Example: Additional Constraints, Security Requirements, Performance Standards, etc. -->

[SECTION_2_CONTENT]
<!-- Example: Technology stack requirements, compliance standards, deployment policies, etc. -->

## [SECTION_3_NAME]
<!-- Example: Development Workflow, Review Process, Quality Gates, etc. -->

[SECTION_3_CONTENT]
<!-- Example: Code review requirements, testing gates, deployment approval process, etc. -->

## Lernenden- und A11Y-Basis / Learner and A11Y Baseline

Learner-facing and user-facing work MUST name its audience and review path.
For Home Baseline, the ABS-DD sandbox, TuiVision, TinyPl0, TinyCalc, and
InventarWorkerService, content MUST be understandable from the first training
year for IT specialist apprentices and both IT management occupations. It MUST
be German-first/English-second at approximately CEFR B2, explain technical
terms at first use, assume no prior Spec Kit experience, provide text-first
dependency/state/decision information, and apply WCAG 2.2 Level AA wherever
the criteria are applicable.

## Didaktische und sprachliche Klarheit / Pedagogical and Linguistic Clarity

Lern- und nutzerseitige Texte stehen auf Deutsch zuerst und Englisch danach
und zielen auf CEFR B2. Status, Abhängigkeiten, Entscheidungen und nächste
Schritte bleiben text-first und soweit anwendbar nach WCAG 2.2 Level AA
zugänglich.

Öffentliche APIs erhalten vollständige XML-Dokumentation mit `<summary>` und
allen fachlich anwendbaren `<param>`, `<returns>` und `<exception>`-Elementen;
lokale Variablen sind keine XML-Dokumentationsziele. Eine aktive CS1591-
Schranke darf nicht global unterdrückt werden. Nicht triviale Logik nutzt in
moderater Dichte zweisprachige Warum-Kommentare.

Funktionen und Fehlerkorrekturen belegen Rot → Grün → Aufräumen. Reine
Governance-/Textarbeit darf TDD und Changed-Code-Coverage nur mit Begründung und
Wiedervorlage `N/A` setzen. Bei geändertem Produktcode gelten mindestens 70
Prozent Coverage und das Ziel 80 Prozent.

*Learner-facing and user-facing text is German first and English second at
CEFR B2. Status, dependencies, decisions, and next actions remain text-first
and accessible under WCAG 2.2 Level AA where applicable. Public APIs receive
complete XML documentation with `<summary>` and every applicable `<param>`,
`<returns>`, and `<exception>`; local variables are not XML documentation
targets, and CS1591 is not globally suppressed. Non-trivial logic uses moderate
bilingual why-comments. Features and bug fixes provide red-green-refactor
evidence. Text-only work needs a justified, re-evaluated `N/A`; changed product
code has a 70% coverage minimum and an 80% target.*

## Governance
<!-- Example: Constitution supersedes all other practices; Amendments require documentation, approval, migration plan -->

[GOVERNANCE_RULES]
<!-- Example: All PRs/reviews must verify compliance; Complexity must be justified; Use [GUIDANCE_FILE] for runtime development guidance -->

**Version**: [CONSTITUTION_VERSION] | **Ratified**: [RATIFICATION_DATE] | **Last Amended**: [LAST_AMENDED_DATE]
<!-- Example: Version: 2.1.1 | Ratified: 2025-06-13 | Last Amended: 2025-07-16 -->
