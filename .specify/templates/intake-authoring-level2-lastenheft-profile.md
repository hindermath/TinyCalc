# Level-2 Lastenheft Authoring Profile

## Identity

- Profile ID: `level2-lastenheft`
- Applies when: An active Level-2 requirements document is prepared for one later Spec Kit feature.
- Target path rule: Preserve the repository-owned `Lastenheft_*.md` path and processing order.
- Language rule: German first and English second, CEFR B2.

## Required Sections

Preserve purpose, current and target state, scope, non-goals, atomic
requirements, quality and governance boundaries, dependencies, risks,
expected artifacts, evidence, measurable acceptance, assumptions, and
ordering. Every active intake ends with exactly one copy-ready Specify prompt
and one copy-ready Autonomous prompt. Creating or reviewing an intake starts
no feature.

## Naming And Ordering

Preserve stable filenames, predecessor gates, and archived feature suffixes.
Ordering conflicts are material and must not be guessed.

## Quality Gates

Apply the repository C#/.NET secure-coding profile, including validated inputs, parameterized persistence access, safe serialization, output encoding, and dependency evidence.

Apply repository security, privacy, architecture, A11Y, agent-parity,
cross-platform, statistics, and evidence rules. Use text-first WCAG 2.2 AA
where applicable. The Autonomous prompt defaults to `LocalImplementation`
and grants no remote, bypass, secret, provider, or follow-up-feature authority.

Wenn mindestens drei zusammenhängende Abhängigkeiten, Zustände, Übergaben,
Verzweigungen oder geordnete Schritte wesentlich von einer Visualisierung
profitieren, folgt direkt nach der vollständigen deutsch-englischen
text-first-Erklärung ein knappes Mermaid-Diagramm. Mermaid bleibt ergänzend:
Der lesbare Markdown-Quelltext wird versioniert, und kein Status, keine
Reihenfolge, Entscheidung oder nächste Aktion darf nur im Diagramm stehen.
Bei einem einfachen Intake ohne wesentlichen Klarheitsgewinn wird `N/A`
dokumentiert.

When three or more connected dependencies, states, handoffs, branches, or
ordered steps materially benefit from visualization, include one concise
Mermaid diagram immediately after the complete German-first/English-second
text-first explanation. Mermaid remains supplementary: keep its readable
Markdown source version-controlled, and encode no status, order, decision, or
next action only in the diagram. Record `N/A` when a simple intake gains no
material clarity from a diagram.
