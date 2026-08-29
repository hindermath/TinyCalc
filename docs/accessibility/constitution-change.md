# Barrierefreiheitsnachweis / Accessibility Evidence: Constitution Change

## Umfang / Scope

- Feature oder Dokument / Feature or document: `002-constitution-change`,
  lokale Implementierung T001–T038 / local implementation T001–T038
- Reviewer: Codex, gerouteter Implementierungsprüfer / routed implementation reviewer
- Datum / Date: 2026-08-30
- Abgedeckte Versionen / Released versions covered: Constitution `1.17.0` und
  lokaler, noch nicht veröffentlichter Build-Kandidat ab `1.2.1.1` / local,
  unreleased build candidate from `1.2.1.1`

Diese Prüfung verwendet WCAG 2.2 Level AA soweit die Kriterien auf statische
Markdown-Texte und Vorlagen anwendbar sind. Ein text-first Nachweis bedeutet,
dass Status, Reihenfolge, Abhängigkeiten, Entscheidungen, Gates und nächste
Schritte ohne Farbe, Bildschirmposition oder Zeiger verständlich bleiben.

*This review applies WCAG 2.2 Level AA where its criteria fit static Markdown
and templates. Text-first means that status, order, dependencies, decisions,
gates, and next actions remain understandable without colour, screen position,
or pointer interaction.*

## Geprüfte Artefakte / Artefacts Reviewed

- CLI: `N/A` für Änderung / for change; kein CLI-Text oder Verhalten geändert
- Dokumentation / Documentation: beide Constitution-Dateien, fünf
  Agentenflächen, Security-Index/-Checkliste, Feature-Laufnachweis und späterer
  PR-/Statistiktext / both constitutions, five agent surfaces, security and
  feature evidence, later PR/statistics text
- HTML oder UI / HTML or UI: `N/A`; kein API-, XML-, DocFX-Navigations- oder
  Präsentationstrigger, keine UI-Änderung / no documented trigger or UI change
- Generierte Vorlagen / Generated templates: vier Projektvorlagen und vier
  Spec-Kit-Vorlagen / four project templates and four Spec Kit templates
- Fehlermeldungen und Logs / Error messages and logs: `N/A`; keine
  nutzerseitige Laufzeitausgabe geändert / no user-facing runtime output changed
- Changelog und Release Notes: `N/A`; kein Release in T001–T038

## Nachweis nach Säule / Evidence by Pillar

### WCAG 2.2 Level AA

- Wahrnehmbar / Perceivable (1.x): Pass. Überschriften und Listen sind
  semantisch; Bedeutung hängt nicht von Farbe ab; neue Bilder fehlen, daher
  sind neue Bildalternativen `N/A`.
- Bedienbar / Operable (2.x): `N/A` für Interaktion. Statische Quellen haben
  keine Pointer-, Zeit- oder Tastaturfunktion. Die Überschriftenfolge bietet
  einen linearen Navigationspfad.
- Verständlich / Understandable (3.x): Pass. Deutsch steht vor Englisch,
  beide Blöcke zielen auf CEFR B2, und Fachbegriffe wie Trust Boundary oder
  text-first werden bei erster Nutzung erklärt oder aus dem direkten Kontext
  verständlich gemacht.
- Robust (4.x): Pass. UTF-8-Markdown, semantische Überschriften, Listen,
  Tabellen und sprachmarkierte Codeblöcke bleiben für Screenreader,
  Braillezeilen und Textbrowser als Text verfügbar.
- Werkzeuge / Tooling: manuelle Quelltextprüfung und read-only
  Homogenitätsprüfung T028 (`score=100`, keine Failures/Warnungen).
  Axe/Lighthouse sind `N/A`, weil kein HTML erzeugt oder geändert wird.

*Perceivable, understandable, and robust static-document checks pass. Operable
interaction criteria and browser tooling are N/A because no interactive or HTML
artefact changes. The repository homogeneity check supplies the existing
automated text check in T028.*

### Tastatur, Screenreader und Braille / Keyboard, Screen Reader, and Braille

- Nur-Tastatur-Durchlauf / Keyboard-only walkthrough: `N/A`; keine interaktive
  Oberfläche geändert. Die lineare Quelltextreihenfolge wurde manuell geprüft.
- Screenreader-Durchlauf / Screen-reader walkthrough: Quellstruktur manuell auf
  Überschriften, Listen, Tabellenüberschriften und vollständige Linktexte
  geprüft; kein gerendertes UI-Artefakt ausgelöst.
- Braillezeile / Braille display: textuelle Vollständigkeit, ausgeschriebene
  Statuswerte und fehlende Farbabhängigkeit geprüft; kein Hardwaredurchlauf.
  Wiedervorlage bei UI-, HTML- oder PDF-Trigger.

*The source structure is suitable for linear screen-reader and Braille use.
No hardware or rendered-UI session is claimed; such a pass is re-evaluated if
HTML, UI, or PDF output changes.*

### Textmodus und CLI / Text Mode and CLI

- Reine ASCII-Ausgabe / Plain ASCII output: `N/A` für CLI; neue Diagramme
  entstehen erst durch den bestehenden Statistikrenderer in T037 und werden
  dort ASCII-only geprüft.
- `NO_COLOR=1` / `TERM=dumb`: `N/A`; keine CLI-Ausgabe geändert.
- Box-Zeichnung / Box-drawing tables: `N/A`; Markdown-Tabellen sind semantisch,
  keine handgezeichnete Box trägt Bedeutung.
- Textbrowser-Tauglichkeit / Text-browser suitability: Pass für alle neuen
  statischen Abschnitte; Status und nächste Aktionen sind ausgeschrieben.

### Zweisprachige Lieferung / Bilingual Delivery

- Deutsch zuerst, Englisch danach / DE first, EN second: Pass.
- Zweisprachige `DE / EN`-Überschriften oder Sidecar / headings or sidecar:
  Pass; Inline-Blöcke werden verwendet, kein Sidecar nötig.
- Deutsche Orthografie / German orthography: Pass für neue Texte; Umlaute und
  `ß` werden in lern- und nutzerseitiger Prosa verwendet. Historische ASCII-
  Begriffe in unveränderten Baseline-Abschnitten sind nicht Teil dieses
  Feature-Befunds.
- CEFR-B2-Lesbarkeit / CEFR B2 readability: Pass; Sätze sind direkt, und
  unvermeidbare Fachbegriffe erhalten Kontext.

### Codeblöcke und Diagramme / Code Blocks and Diagrams

- Sprach-Tags / Language tags: Pass; neue Befehls-/Ausgabeblöcke verwenden
  `text`. Kein neuer ungetaggter Codeblock.
- ASCII-Diagramme / ASCII diagrams: Noch kein manueller Diagramm-Writer;
  Statistikdiagramme werden in T037 aus der kanonischen JSON-Quelle gerendert
  und besitzen DE-zuerst/EN-danach-Erklärungen.
- Aussagekräftige Bilder / Meaningful images: `N/A`; keine Bilder hinzugefügt.

## Vollständiger Textpfad / Complete Text Path

Die neue Regel ist in dieser Reihenfolge lesbar: Constitution-Titel →
DE→EN/CEFR-B2-Regel → text-first/WCAG-Grenze → XML-/CS1591-Regel →
Warum-Kommentare → Rot-Grün-Aufräumen → Test-/Coverage-Trigger →
Feature-Evidenz → nächste sichere Aufgabe. Keine Information hängt nur von
Layout oder Symbolform ab; Pfeile werden zusätzlich in Worten erklärt.

*The reader path moves from the constitution rule through language,
accessibility, XML, comments, and TDD to evidence and the next safe task. No
essential information depends only on layout or symbols.*

## Querverweise / Cross-References

- A11Y-Checklistenpunkt / Accessibility checklist entry:
  `specs/002-constitution-change/checklists/autonomous-readiness.md`
- Zweisprachigkeitsnachweis / Bilingual content evidence:
  `specs/002-constitution-change/autonomous-run-evidence.md`
- CLI-Barrierefreiheit / CLI accessibility: `N/A` für Änderung; TUI-Smoke T033
- Security-Nachweis / Security evidence:
  `docs/security/security-checklist.md`

## DocFX-Entscheid / DocFX Decision

Finaler lokaler T027-Entscheid: `N/A`. `git diff --name-only` und
`git ls-files --others --exclude-standard` enthalten keine geänderte
API-Signatur, keinen XML-Kommentar, `docfx.json`, keine DocFX-Navigation und
keine API-Präsentation. Die späteren T029-/T036-/T037-Pfade sind ausschließlich
Markdown/JSON-Delivery- und Statistikevidenz und können diesen Trigger nicht
erzeugen. Sobald künftig einer dieser Trigger eintritt, sind
`docfx docfx.json`, ein repräsentativer Playwright/axe-Smoke und
`lynx -dump -nolist _site/index.html` gemeinsam verpflichtend.

*Final local T027 decision: N/A. No API signature, XML comment, DocFX
configuration, navigation, or API presentation changed. Later delivery and
statistics evidence cannot trigger DocFX. Any future trigger requires DocFX,
Playwright/axe, and lynx together.*

## Homogenitätsnachweis T028 / Homogeneity Evidence T028

Der erste read-only Lauf meldete ausschließlich einen vorbestehenden Drift im
markierten Statistikprofil-2-Block; der Worktree blieb unverändert. Der
kanonische Renderer erzeugte den Block anschließend mit `-WhatIf`, und
`apply_patch` übernahm nur diesen markierten Bereich. Ein schreibender
Rendererlauf war danach `CURRENT` und änderte nichts. Der bindende erneute
Homogenitätslauf bestand:

```text
pwsh -NoProfile -File scripts/check-homogeneity.ps1 -TargetDir . -DryRun -NoPatch -Json
Exitcode: 0
score: 100
failures: []
warnings: []
Worktree SHA before/after: 20dc9890a252af585a0e6dee5b833657c4fede627aeefc809d193bbeb564a61a
Worktree unchanged: true
```

*The binding rerun passed with score 100, no failure or warning, and an
identical worktree status hash before and after.*

## Folgeschritte / Follow-Up

- Offene Befunde / Open findings: keine / none.
- Erforderliche nächste Gates / Required next gates: T037 endgültiger
  Statistikrenderer; dies ist eine geplante Prüfung, kein offener A11Y-Fehler.
  T028 und die T029-/T030-Liefertextprüfung sind Pass.
- Owner: Repository-Maintainer; Reviewer: Codex.
- Wiedervorlage / Re-review trigger: API/XML/DocFX-, HTML/UI/PDF-, CLI-,
  Navigations-, Statistikmethodik- oder Scope-Änderung.

*No accessibility defect remains open. Scheduled later gates are not claimed
early and do not represent unresolved findings.*
