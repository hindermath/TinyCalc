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
Aufbauend auf der durch PR #83 eingeführten allgemeinen Mermaid-Regel präzisiert
das Level-2-Autorenprofil die barrierefreie Reihenfolge. Die vollständige
deutsch-englische Textbeschreibung steht zuerst und bleibt normativ. Direkt
danach folgt bei hilfreichen Abläufen, Zuständen oder Abhängigkeiten ein knappes,
versionskontrolliertes Mermaid-Diagramm, dessen Quelltext keine zusätzliche
Information trägt. Eine kurze Textalternative direkt unter dem Diagramm fasst
die wesentlichen Beziehungen auf Deutsch zuerst und Englisch danach zusammen.
Der aktuelle TinyCalc-Serienreview dient als konkretes Beispiel. Alle
Agentenrichtlinien und ihre Quelltemplates wurden synchronisiert. Constitution
v1.18.1 und ihr Spec-Kit-Spiegel verankern die Präzisierung kanonisch.

English:
Building on the general Mermaid rule introduced by PR #83, the Level-2 authoring
profile specifies the accessible order. The complete German-English text
explanation comes first and remains normative. A concise, version-controlled
Mermaid diagram follows directly when workflows, states, or dependencies benefit
from it, and its source carries no additional information. A short German-first,
English-second text alternative immediately below summarizes the essential
relationships. The current TinyCalc series review provides a concrete example.
All agent guidance files and source templates are synchronized. Constitution
v1.18.1 and its Spec Kit mirror canonically bind the refinement.

## Risiken / Risks

- Mermaid-Unterstützung kann je nach Markdown-Renderer fehlen. Der vollständige
  Begleittext verhindert Informationsverlust. / Mermaid support may be absent
  in some Markdown renderers. The complete accompanying text prevents loss of
  information.
- Einfache Lastenhefte werden nicht mit unnötigen Diagrammen belastet; die
  Nichtanwendung wird kurz begründet. / Simple requirement documents do not
  receive unnecessary diagrams; omission is briefly justified.
- Keine Produkt-, Runtime- oder Abhängigkeitsänderung. / No product, runtime, or
  dependency change.

## Testplan / Test Plan

- Agentenflächen und Quelltemplates auf dieselbe Mermaid-Regel prüfen.
- Die verpflichtende Textalternative direkt unter dem Diagramm prüfen.
- Constitution und Spec-Kit-Spiegel auf Bytegleichheit und Evidenzbindung prüfen.
- Den Intake-Serienreview mit Bash und PowerShell validieren.
- Markdown, Mermaid-Quellblock, UTF-8 und `git diff --check` prüfen.
- Projektstatistik deterministisch regenerieren und im Check-only-Modus prüfen.

*Verify agent-source parity, validate the intake series review through Bash and
PowerShell, inspect Markdown/Mermaid/UTF-8 and patch hygiene, and confirm the
deterministically generated statistics block in check-only mode.*
