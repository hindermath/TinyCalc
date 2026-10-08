# Feature 006: Plan und Anforderungsreview / Plan and requirements review

## Deutsch

### Zusammenfassung und Problem

Dieser PR liefert die vollständige TUI-Funktionsvertragsplanung, Forschung,
Daten-/Schnittstellenentwürfe, Prüfablauf und Checklisten mit Durchführungshinweisen.
Die geprüften Formel-/Bedienkonflikte sind durch Owner-Antworten geklärt.
Eine zusätzlich verlangte externe qualifizierte Planfreigabe war für den
dokumentierten privaten persönlichen Projektscope unverhältnismäßig.

### Lösung und Umfang

- Scope: Docs und erforderliche Versionsmetadaten; kein Core-/TUI-Produktcode,
  keine Tests, CI-/Paket-/Lock-/API-/DocFX-Änderungen.
- Alle 17 Familien/FR und sechs SC erhalten; drei ursprüngliche Quellenbefunde
  geklärt, 36 Anforderungsqualitäts-Punkte Pass (keine Produktabnahme).
- Owner-Scope-Entscheidung dokumentiert, zusätzliche externe Review-Pflicht
  supersediert. Öffentliches Repository bleibt öffentlich; keine pauschale
  regulatorische N/A-Entscheidung. Anlassprüfung und technische Gates bleiben.
- Finale Assembly-Felder `1.6.6.30`: Feature 006, sechster Branch-Commit nach
  separatem Statistik-Render; Buildzähler 30 ohne Build/Test unverändert.
- Statistik-Ledger und vorhandenen Statistikrenderer kontrolliert fortschreiben.

### Verhaltenshinweise, Risiken und Review

Keine Laufzeitänderung. Dokumentiert sind Kontextregeln für historische Tasten,
strikte FACT-Grenzen, rechtsassoziative Potenzen, endliche Ergebnisse, Bogenmaß,
LN/LOG-Basen und ROUND-Grenzen. Spätere Produktänderungen verlangen test-first
Regressionen, Preflight/Locks und Plattform-/A11Y-/Security-Nachweise.
Owner prüft diesen PR; kein Merge, Implementierungsstart oder Folgefeature.

### Prüfplan und Checkliste

- [x] Anforderungen, bilinguale B2-Dokumentation und Textlesbarkeit geprüft.
- [x] PowerShell-/Bash-Intake-/Serien-/Review-/Alignment-Validatoren bestanden.
- [x] UTF-8/LF, 17 FR/sechs SC, Secret-Scan und `git diff --check` geprüft.
- [x] Statistik zuerst Vorschau, dann sauberer Render und CheckOnly.
- [ ] GitHub-Checks und Owner-PR-Review: im PR live prüfen, nicht vorwegnehmen.
- Build/Test, interaktive Navigation, Recalc, Save/Load, Print, Help und
  Screenshots: N/A für diesen dokumentenbezogenen PR ohne UI-Verhaltensänderung.

## English

### Summary, problem and solution

Deliver the complete feature-006 plan, research, data/interface designs,
validation procedure and requirement checklists. Preserve all 17 families/FR
and six acceptance criteria. Owner answers resolve the identified source gaps;
all 36 requirement-quality items pass, not product acceptance.
Record the personal-project scope and supersede the disproportionate added
external review prerequisite. Public repository visibility, dated regulatory
dispositions, concrete-trigger reassessment and technical gates remain intact.

### Scope, risks and test plan

Documentation and required version metadata only; no runtime code, tests, CI,
dependencies, locks, public APIs or DocFX changes. Final version `1.6.6.30` binds
feature 006 and its sixth commit after statistics, with no build-counter increase. Future product changes
need test-first regression and dependency/platform/accessibility/security proof.
PowerShell/Bash governance validators, UTF-8/LF, contract-identity completeness,
secret scan and diff checks pass. Preview, clean render and check the existing
statistics output. GitHub checks and owner review are verified separately in
the PR. Build/test, interactive product checks and UI captures are N/A here.
No merge, implementation start or next feature is authorised.
