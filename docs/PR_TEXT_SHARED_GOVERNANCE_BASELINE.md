# PR: Shared Governance Baseline fuer TinyCalc nachgezogen

## Problem

`TinyCalc` hatte bereits Teile der gemeinsamen repo-uebergreifenden Governance-,
Doku-, Bilingualitaets-, Statistik- und A11Y-Baseline, aber noch nicht alle
Feinregeln, die inzwischen in der Parent-Baseline, der zugehoerigen
Merknote und in `TuiVision` verankert sind.

## Loesung

- lokale Guidance-Dateien (`AGENTS.md`, `CLAUDE.md`, `GEMINI.md`,
  `.github/copilot-instructions.md`) auf die fehlenden Shared-Baseline-Punkte
  nachgezogen
- `.EN.md`-Option fuer grosse normative Dokumente ergaenzt
- Abschlusskriterium fuer bilinguale CEFR-B2-Doku und dokumentierten
  A11Y-Nachweis verankert
- Statistikregeln fuer finalen `## Gesamtstatistik`-Block, ASCII-Diagramme,
  CEFR-B2-Erklaertexte und ASCII-X/Y-Darstellungen nachgezogen
- `docs/project-statistics.md` mit Schlusssektion und textorientierter
  A11Y-/Inklusions-Methodik aktualisiert

## Risiken

- Kein funktionales Produkt- oder Laufzeitrisiko, weil nur Dokumentations- und
  Governance-Dateien geaendert wurden
- Statistikzahlen koennen bei spaeteren Repo-Aenderungen erneut refresh-beduerftig
  werden, was aber dem normalen Pflegeprozess entspricht

## Testplan

- Manuelle Diff-Pruefung der betroffenen Guidance-Dateien
- Manuelle Kontrolle, dass `docs/project-statistics.md` mit `## Gesamtstatistik`
  endet
- Keine Code- oder Testausfuehrung, weil keine Produktions- oder Testlogik
  geaendert wurde
