# PR: Text-first-Mermaid-Diagramme für Lastenhefte / Text-first Mermaid diagrams for requirement documents

## Problem / Problem

Deutsch:
Komplexe Abhängigkeiten, Zustände, Übergaben und Ablaufreihenfolgen in
Lastenheften waren bisher nur allgemein text-first geregelt. Eine dauerhafte
Regel für ergänzende, versionskontrollierbare Mermaid-Diagramme fehlte.

English:
Complex dependencies, states, handoffs, and ordered flows in requirement
documents were covered by the general text-first rule only. A durable rule for
supplementary, version-controlled Mermaid diagrams was missing.

## Lösung / Solution

Deutsch:
Das Level-2-Autorenprofil verlangt bei mindestens drei zusammenhängenden
Elementen ein knappes Mermaid-Diagramm, wenn es die Verständlichkeit verbessert.
Die vollständige deutsch-englische Textbeschreibung steht zuerst und bleibt
normativ. Der aktuelle TinyCalc-Serienreview dient als konkretes Beispiel. Alle
Agentenrichtlinien und ihre Quelltemplates wurden synchronisiert. Constitution
v1.17.3 und ihr Spec-Kit-Spiegel verankern die Regel kanonisch.

English:
The Level-2 authoring profile now requires a concise Mermaid diagram for three
or more connected elements when it materially improves clarity. The complete
German-English text explanation comes first and remains normative. The current
TinyCalc series review provides a concrete example. All agent guidance files
and their source templates are synchronized. Constitution v1.17.3 and its
Spec Kit mirror bind the rule canonically.

## Risiken / Risks

- Mermaid-Unterstützung kann je nach Markdown-Renderer fehlen. Der vollständige
  Begleittext verhindert Informationsverlust. / Mermaid support may be absent
  in some Markdown renderers. The complete accompanying text prevents loss of
  information.
- Einfache Lastenhefte werden nicht mit unnötigen Diagrammen belastet; fehlender
  Mehrwert wird als `N/A` dokumentiert. / Simple requirement documents do not
  receive unnecessary diagrams; missing material benefit is recorded as `N/A`.
- Keine Produkt-, Runtime- oder Abhängigkeitsänderung. / No product, runtime, or
  dependency change.

## Testplan / Test Plan

- Agentenflächen und Quelltemplates auf dieselbe Mermaid-Regel prüfen.
- Constitution und Spec-Kit-Spiegel auf Bytegleichheit und Evidenzbindung prüfen.
- Den Intake-Serienreview mit Bash und PowerShell validieren.
- Markdown, Mermaid-Quellblock, UTF-8 und `git diff --check` prüfen.
- Projektstatistik deterministisch regenerieren und im Check-only-Modus prüfen.

*Verify agent-source parity, validate the intake series review through Bash and
PowerShell, inspect Markdown/Mermaid/UTF-8 and patch hygiene, and confirm the
deterministically generated statistics block in check-only mode.*
