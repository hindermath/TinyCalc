# PR-Text: Constitution-Abgleich / PR Text: Constitution Alignment

## Deutsch

### Problem

Die TinyCalc-Governance beschrieb zweisprachige Dokumentation,
Barrierefreiheit, öffentliche XML-Dokumentation und Tests bereits an mehreren
Stellen. Ein gemeinsamer, ausdrücklich benannter Lern-Grundsatz sowie ein
sichtbarer Rot-Grün-Aufräumen-Nachweis für künftige Funktionen und
Fehlerkorrekturen fehlten jedoch. Zusätzlich enthielten Constitution und
Agentenflächen veraltete Darstellungen der ausführbaren Acht-Preset-Matrix.

### Lösung

- Der Abschnitt „Didaktische und sprachliche Klarheit“ wurde ausschließlich im
  TinyCalc-Level-2-Addendum ergänzt. Security-First bleibt unverändert Prinzip I.
- Deutsch steht zuerst, Englisch danach; beide Blöcke zielen auf CEFR B2.
  Status, Abhängigkeiten, Entscheidungen und nächste Schritte bleiben
  text-first und soweit anwendbar WCAG-2.2-AA-tauglich.
- Öffentliche C#-APIs benötigen `<summary>` sowie alle fachlich anwendbaren
  `<param>`, `<returns>` und `<exception>`. Lokale Variablen sind keine
  XML-Dokumentationsziele; CS1591 bleibt eine nicht unterdrückte Build-Schranke.
- Neue oder geänderte nicht triviale Logik wird auf moderate zweisprachige
  Warum-Kommentare geprüft.
- Künftige Funktionen und Fehlerkorrekturen verlangen konkrete rote Test-,
  grüne Implementierungs- und Regressions-/Aufräum-Evidenz. Changed-Code-
  Coverage hat bei Trigger mindestens 70 Prozent und das Ziel 80 Prozent.
- Constitution-Version `1.17.0`, `Last Amended` `2026-08-30` und die acht
  Preset-Versionen wurden mit
  `scripts/config/spec-kit-governance-presets.json` ausgerichtet.

### Betroffene Governance- und Vorlagenflächen

- `constitution.md` und `.specify/memory/constitution.md` byte-identisch;
- fünf Agentenflächen: `AGENTS.md`, `CLAUDE.md`, `GEMINI.md`,
  `.github/copilot-instructions.md`,
  `.github/agents/copilot-instructions.md`;
- vier Projektvorlagen unter `scripts/templates/`;
- vier Spec-Kit-Vorlagen: Constitution, Plan, Spec und Tasks;
- Feature-, Security-, A11Y-, Statistik- und dieser Liefernachweis.

Es gibt keine absichtliche agentenspezifische Abweichung. Modellwahl bleibt
operative lokale Routing-Evidenz und ist keine Feature-Anforderung.

### Security-Review

NIST SSDF und CWE Top 25 wurden als verpflichtende Level-2-Linsen angewendet.
Die Checkliste ordnet PO, PS, PW und RV zu und prüft ergänzend OWASP Cheat
Sheets/Proactive Controls sowie die C#/.NET-Secure-Coding-Regeln. Der read-only
Vulnerability-Scan meldet in allen vier Projekten keine bekannte verwundbare
Abhängigkeit und keinen kritischen CVE. Verfügbare Paketupdates sind als
Restrisiko erfasst, aber nicht Teil dieses text-only Features.

OWASP ASVS, SBOM/VEX/SLSA, AI-SBOM, STRIDE/CAPEC, S-ADR/arc42, Zero Trust,
BSI C3A/C5, SAMM und regulatorische Evidenz sind mit konkreter Begründung und
Wiedervorlage `N/A`. Der lokale Secret-Scan ist Teil des Testplans. `.codex/`,
Runtime-Logs, Credentials, History- und SQLite-Dateien bleiben aus dem
Delivery-Satz ausgeschlossen.

### A11Y-Review

Die statische Prüfung deckt WCAG 2.2 Level AA soweit anwendbar, semantische
Überschriften, DE-zuerst/EN-danach, CEFR B2, Fachbegriffserklärung,
Codeblock-Tags sowie Braille-, Screenreader- und Textbrowser-Tauglichkeit ab.
Der bindende Homogenitätslauf erreicht `score=100` ohne Failure oder Warning.
Status und nächste Aktionen sind vollständig als Text vorhanden; kein Befund
bleibt offen.

### Öffentliche XML-Dokumentation und DocFX

Beide Produktprojekte erzeugen XML-Dokumentation und behandeln CS1591 als
Fehler. Die einmalige manuelle Inventur umfasst 76/76 ausdrücklich öffentliche
Quelltext-API-Zeilen; jede Zeile besitzt `Pass` oder ein elementbezogen
begründetes `N/A`. Der Release-Build endet mit 0 Warnungen und 0 Fehlern.

DocFX ist für diesen Änderungssatz `N/A`: Keine API-Signatur, kein
XML-Kommentar, `docfx.json`, keine DocFX-Navigation und keine API-Präsentation
wurde geändert. Bei künftigem Trigger sind `docfx docfx.json`,
Playwright/axe und `lynx` gemeinsam verpflichtend.

### Versionsschema

`Version`, `AssemblyVersion` und `FileVersion` bleiben repo-weit identisch.
`Minor=2` folgt dem nummerierten Spec-Kit-Branch, `Patch=1` dem aktuellen
Feature-Commitcount vor späterer Delivery und `Build` wird unmittelbar vor
jedem Build/Test einmal erhöht. Der Release-Build lief mit `1.2.1.1`; vor dem
lokalen Testlauf wurden alle drei Felder auf `1.2.1.2` erhöht.

### Risiken

- Große Paketversionssprünge, besonders Terminal.Gui 2.x und Testwerkzeuge,
  benötigen einen getrennten Migrationsauftrag.
- Vollständige Bestandsnacharbeit vorhandener didaktischer Kommentare bleibt
  beim ausdrücklich reservierten Folge-Intake.
- Remote-Checks, Reviewer-Verfügbarkeit, Exact-Head-PreMerge, Merge und
  PostMerge sind noch keine lokalen Fakten und werden hier nicht behauptet.

### Testplan und lokaler Stand

| Prüfung | Stand |
|---|---|
| Akzeptierte Hashes, 16 Intake-Zeilen, keine offene Klärung | Pass |
| Run-State und Gate-Vertrag | Pass |
| Constitution-Spiegel, Metadaten und Acht-Preset-Matrix | Pass |
| 15-Dateien-Regelmatrix und 13-Dateien-TDD-Matrix | Pass |
| Öffentliche XML-Inventur 76/76 | Pass |
| `dotnet restore MicroCalc.sln` | Pass |
| `dotnet build MicroCalc.sln --configuration Release --no-restore` | Pass, 0 Warnungen/0 Fehler |
| Paketaktualität und Vulnerability-Scan | Pass; Updates erfasst, keine bekannte Vulnerability |
| Statischer A11Y-Review und Homogenität | Pass, Score 100 |
| Vollständige xUnit-Suite | Pass: Core 76/76, TUI 3/3, 0 Fehler, 0 übersprungen |
| TUI-Smoke | Pass: `SMOKE_OK` |
| Secret-Scan | Pass: keine Secrets im Git-Diff, keine Secrets in getrackten Dateien, kein High-Fund |
| Changed-Code-Coverage | Begründet `N/A`: `src/` und `tests/` unverändert; Trigger 70-%-Minimum/80-%-Ziel |
| Statistikrenderer und Check-only | Endgültige Ausführung in T037 |

### Delivery- und Admin-Bypass-Grenze

Diese lokale Phase führt ausschließlich T001–T038 aus. Sie staged, committet,
pusht, erstellt/ändert keinen PR, mergt nicht, benennt kein Lastenheft um,
wechselt keinen Branch und führt T039–T071 nicht aus. Ein gespeicherter
`MergeAndSync`-Modus ist keine aktuelle Remote-Berechtigung. Der erlaubte enge
Admin-Bypass wurde lokal nicht benutzt und darf später ausschließlich eine
Merge-Berechtigungs-/Ruleset-Grenze übersteuern, niemals fachliche, Security-,
A11Y-, Review- oder Exact-Head-Evidenz.

### Evidenzpfade

- `specs/002-constitution-change/autonomous-run-evidence.md`
- `specs/002-constitution-change/autonomous-run-state.json`
- `specs/002-constitution-change/checklists/autonomous-readiness.md`
- `docs/security/security-checklist.md`
- `docs/accessibility/constitution-change.md`
- `docs/project-statistics.config.json`
- `docs/project-statistics.md`

## English

### Problem

TinyCalc already described bilingual documentation, accessibility, public XML
documentation, and testing in several places. It lacked one explicitly named
learning principle and a visible red-green-refactor evidence path for future
features and bug fixes. Constitution and agent surfaces also displayed stale
versions of the executable eight-preset matrix.

### Solution

- “Pedagogical and Linguistic Clarity” was added only to the TinyCalc Level-2
  addendum. Security-First remains Principle I.
- German comes first and English second at CEFR B2. Status, dependencies,
  decisions, and next actions remain text-first and meet WCAG 2.2 Level AA
  where applicable.
- Public C# APIs require `<summary>` and every applicable `<param>`,
  `<returns>`, and `<exception>`. Local variables are not XML documentation
  targets, and CS1591 remains an unsuppressed build gate.
- New or changed non-trivial logic is reviewed for moderate bilingual
  why-comments.
- Future features and fixes require exact red-test, green-implementation, and
  regression/refactor evidence. Triggered changed-code coverage has a 70%
  minimum and an 80% target.
- Constitution 1.17.0, the 2026-08-30 amendment date, and all eight preset
  versions now match the executable JSON source.

### Affected Surfaces

The change synchronizes both constitutions, five agent surfaces, four project
templates, four Spec Kit templates, and the required feature, security,
accessibility, statistics, and delivery evidence. No intentional agent-specific
deviation exists, and model selection remains operational routing evidence
rather than a feature requirement.

### Security and Accessibility

The review applies NIST SSDF and the CWE Top 25, supported by OWASP guidance
and the C#/.NET secure-coding profile. Read-only package checks report available
updates but no known vulnerable package in any project and no critical CVE.
Every non-triggered security standard or document has a rationale and a
re-evaluation trigger.

The static accessibility review covers applicable WCAG 2.2 Level AA,
meaningful headings, bilingual CEFR-B2 delivery, first-use explanations,
language-tagged code blocks, and text-browser, screen-reader, and Braille
suitability. Homogeneity passes with score 100 and no open finding.

### XML Documentation and DocFX

Both product projects generate XML and treat CS1591 as an error. The manual
inventory covers 76/76 explicitly public source API rows, and the Release build
passes with no warning or error. DocFX is N/A because no API signature, XML
comment, DocFX configuration, navigation, or API presentation changed. Any
future trigger requires DocFX, Playwright/axe, and lynx together.

### Versioning, Risks, and Test Plan

The three repository-wide version fields stay identical. Minor 2 follows the
numbered Spec Kit branch, Patch 1 follows the current feature commit count
before later delivery, and Build increments once immediately before each build
or test. The Release build used 1.2.1.1, and the complete xUnit run used the
required next counter 1.2.1.2.

Large dependency updates require a separate migration. The later didactic
comment inventory remains assigned to its reserved intake. Remote checks,
reviews, exact-head evidence, merge, and post-merge are not claimed locally.
The detailed German test table and linked evidence paths form the authoritative
local test plan. xUnit, smoke, and secret scan pass; only the final statistics
render/check remains scheduled in T037.

### Delivery and Admin-Bypass Boundary

This routed phase executes T001–T038 only. It does not stage, commit, push,
create or update a PR, merge, rename the Lastenheft, switch branches, or execute
T039–T071. Stored `MergeAndSync` state grants no current remote authority. The
narrow admin bypass was not used locally and may never substitute for
technical, security, accessibility, review, or exact-head evidence.
