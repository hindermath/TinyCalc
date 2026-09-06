# Barrierefreiheitsprüfung der GSDB-Intensivprüfung / Accessibility Review

## Deutscher Prüfblock

| Feld | Ergebnis |
|---|---|
| Prüftag | 2026-09-06 |
| Scope | GSDB-Leserpfad, geänderte Security-Dokumente und DocFX-Ausgabe |
| Owner | Dokumentations- und Accessibility-Rolle |
| Reviewer | unabhängige technische Review-Rolle |
| Basis | WCAG 2.2 AA, soweit auf Markdown und generiertes HTML anwendbar |

Die Dokumente verwenden Deutsch zuerst und Englisch danach auf CEFR-B2-Niveau.
Echte Umlaute wie ä, ö und ü sowie das ß bleiben als UTF-8 erhalten. Semantische
Überschriften, lineare Tabellen und aussagekräftige Linktexte tragen die
Bedeutung; Farbe, Mausposition oder ein Bild sind nicht erforderlich.

Manuell geprüft wurden WCAG 2.2 Kriterien 1.3.1 (Information und Beziehungen),
1.3.2 (sinnvolle Reihenfolge), 1.4.1 (Farbe nicht allein), 2.4.6
(Überschriften und Beschriftungen) sowie die DE/EN-Aussagen. Die 157-Zeilen-
Tabelle hat eine lineare Summary und verweist für Details auf die kanonische
JSON-Datei. Befunde nennen Status, Owner, Reviewer, Nachweis, Termin, Trigger
und Restrisiko auch ohne visuelles Layout.

Der Textreview beweist keine Screenreader-Nutzerstudie und kein WCAG-Zertifikat.
DocFX und lynx werden nach jeder finalen Markdown-Änderung erneut ausgeführt.
Ein vorhandenes geprüftes Playwright/axe-Harness wird repositoryweit gesucht;
wenn es fehlt, bleibt das Ergebnis `Unavailable` statt erfundenem Pass.

## English review block

The documents use German first and English second at CEFR B2 readability.
Semantic headings, linear tables, meaningful links, and text summaries carry
all essential meaning without color, pointer position, or images. Manual review
covers WCAG 2.2 AA criteria 1.3.1, 1.3.2, 1.4.1, and 2.4.6. The finding view
names status, owner, reviewer, expected evidence, due date, trigger, and
residual risk. This text review is not a screen-reader user study or WCAG
certification. DocFX, lynx, and the available browser harness are recorded
after execution.

## Ausführungsnachweis / Execution Evidence

- DocFX: Der vorgeschriebene projektbasierte Einstieg `docfx docfx.json`
  bestand am 2026-09-06 mit Exitcode 0 und 0 Fehlern. Die 53 Warnungen betreffen
  bereits sichtbare Dokumentationshinweise und werden nicht als Fehlerfreiheit
  umgedeutet. Weder Projektdateien noch `docfx.json` wurden für den Lauf
  verändert. / The required project-based `docfx docfx.json` entry passed on
  2026-09-06 with exit code 0 and zero errors. The 53 warnings remain visible
  documentation advisories and are not presented as warning-free. Neither
  project files nor `docfx.json` were changed for the run.
- lynx: `lynx -dump -nolist
  _site/docs/security/gsdb-intensive-review/evidence-matrix.html` bestand mit
  Exitcode 0. Der lineare Dump enthält 308 Zeilen, die Überschrift, die
  Summary mit 157 Zeilen sowie `CL-01-01` und `CL-12-12`. / The representative
  lynx command passed with exit code 0. Its 308-line linear dump contains the
  heading, the 157-row summary, and both boundary IDs.
- Playwright/axe: `Unavailable` am 2026-09-06. Die repositoryweite Suche über
  Dateinamen (`package.json`, Lockfile, `playwright.config.*`, `*axe*`,
  `*playwright*`) fand kein Harness. Acht Texttreffer sind ausschließlich
  Governance-, README- oder Intake-Hinweise, keine ausführbare Implementierung.
  Owner ist die Dokumentations- und Accessibility-Rolle; Trigger ist ein
  installiertes und geprüftes Playwright/axe-Harness oder eine Änderung der
  DocFX-Templates. / `Unavailable` on 2026-09-06. The repository-wide filename
  search found no harness; eight text references are guidance only. The owner
  is the documentation and accessibility role, and the trigger is an installed
  reviewed harness or a DocFX-template change.
