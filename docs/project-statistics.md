# Projektstatistik MicroCalc

Stand: 2026-03-30 (aktualisiert mit finalem `## Gesamtstatistik`-Block, ASCII-/X/Y-Diagrammen und textorientierter A11Y-Statistikbaseline)

## Zweck und Pflege

Diese Datei ist das fortlaufende Statistik-Register fuer MicroCalc. Sie wird
nach jeder abgeschlossenen Spec-Kit-Implementierungsphase, nach jeder
agentischen Aenderung am Repository und auf explizite Anforderung
fortgeschrieben.

## Methodik

- Quellen: Git-Historie, lokale und Remote-Branch-Referenzen, aktueller
  Dateistand.
- Ausgeschlossen: `.codex/`, `_site/`, `api/`, `bin/`, `obj/` sowie sonstige
  generierte Artefakte.
- Produktionscode: `src/**/*.cs`
- Testcode: `tests/**/*.cs`
- Dokumentation: Markdown-Dateien in Repository-Wurzel, `docs/`, `specs/`,
  `.github/` und `.specify/`.
- Leitsatz fuer diese Datei und die zugehoerigen Lernmaterialien:
  `Programmierung #include<everyone>`. Inhalte muessen fuer Braille-Zeile,
  Screenreader und Textbrowser lesbar bleiben; ASCII-Diagramme und ihre
  Kurztexte sind deshalb bewusst plain-text-freundlich aufgebaut.
- Fuer erzeugte HTML-Dokumentation gilt WCAG 2.2 Konformitaetsstufe AA als
  konkrete Pruefbasis; besonders wichtig sind Seitensprache,
  Bypass-Mechanismen, sichtbarer Tastaturfokus, Non-Text-Contrast und
  verstaendliche Landmark-Struktur.
- Wenn sich DocFX-Inhalte, Navigationsstruktur oder API-Praesentation aendern,
  werden repraesentative `_site/`-Seiten ueber einen textorientierten
  Reviewpfad geprueft, bevorzugt mit lokalem Playwright-Accessibility-Snapshot
  und `lynx` als zusaetzlichem Textbrowser-Gegencheck.
- Jeder erfolgreiche `docfx`-Neubau gilt in diesem Repository erst dann als
  vollstaendig, wenn im selben Arbeitsschritt auch der passende textorientierte
  A11Y-Review dokumentiert oder ausgefuehrt wurde.
- Die konservative Handarbeits-Basis in dieser Datei zaehlt Produktionscode,
  Testcode und Dokumentation gemeinsam als manuell zu erstellenden Umfang.
- Die konservative Handarbeits-Basis folgt dem Beitrag
  [Adapt or Disappear: How AI Turned a 2-Year Project into a 1-Week Sprint](https://www.holgerscode.com/blog/2026/02/23/adapt-or-disappear-how-ai-turned-a-2-year-project-into-a-1-week-sprint/#a-note-on-the-orm-29000-lines-you-never-have-to-write):
  maximal 80 manuell erstellte Zeilen pro Arbeitstag fuer einen erfahrenen
  Entwickler.
- Umrechnung in Zeitraeume:
  durchschnittlich 21.5 Arbeitstage pro Monat (Mittel aus 21-22 Arbeitstagen);
  unter TVoeD-Annahme mit 30 Urlaubstagen pro Jahr bis einschliesslich 2026 und
  31 Urlaubstagen pro Jahr ab 2027 (jeweils 5-Tage-Woche) ergeben sich
  `21.5 * 12 - 30 = 228` produktive Arbeitstage pro Jahr fuer Zeitraeume bis
  2026 bzw. `21.5 * 12 - 31 = 227` produktive Arbeitstage pro Jahr ab 2027.
- TVoeD-Stundenbasis in dieser Datei:
  `7.8 Stunden` bzw. `7 Stunden 48 Minuten` pro Arbeitstag fuer zusaetzliche
  Stundenumrechnungen.
- Abgeleitete Formeln in dieser Datei:
  Einzelentwickler `((Produktionscode + Testcode + Dokumentation) / 80)`;
  3er-Team `Einzelentwickler / 3 * 1.2` mit 20 % Koordinationsaufschlag.
- Zusatzannahmen fuer die erfahrungsadjustierte Thorsten-Referenz:
  - Allgemeiner Expertenaufschlag `* 1.25`, weil Thorsten seit Februar 1985
    mehr als 40 Jahre Softwareentwicklungspraxis einbringt und seit 2001 mit
    .NET/C# arbeitet.
  - Legacy-Portierungsaufschlag `* 1.25`, weil MicroCalc als Pascal-basierte
    Portierung zusaetzlich von 10 bis 15 Jahren Turbo-Pascal-Erfahrung
    profitiert.
  - Daraus ergibt sich fuer MicroCalc eine erfahrungsadjustierte Solo-Referenz
    von `80 * 1.25 * 1.25 = 125` manuell erstellten Zeilen pro Arbeitstag.
- Beschleunigungsfaktoren vergleichen Referenz-Arbeitstage mit sichtbaren
  `Git-Aktivtagen`. Sie sind als repo-weiter Output-zu-Aktivtag-Indikator
  formuliert und keine exakte Zeiterfassung.

## Erfahrungsprofil und Beschleunigungsmodell

- Referenzprofil fuer die erfahrungsadjustierte Zweitrechnung:
  - mehr als 40 Jahre Softwareentwicklung seit Februar 1985
  - langjaehrige .NET-/C#-Praxis seit 2001
  - 10 bis 15 Jahre Turbo-Pascal-/Legacy-Portierungserfahrung
- MicroCalc fuehrt deshalb neben der konservativen 80-Zeilen-Referenz eine
  zweite Thorsten-Solo-Referenz mit `125 Zeilen/Arbeitstag`.
- Die Beschleunigungsfaktoren messen die Verdichtung des sichtbaren Outputs
  gegenueber einer klassischen Portierung mit identischem fachlichem Anspruch.

## Gesamtstand des Repositories

| Kennzahl | Wert |
|---|---:|
| Beobachtbarer Projektzeitraum | 2026-02-07 bis 2026-03-06 |
| Git-Commits gesamt | 68 |
| Autoren laut Git | 2 |
| Git-Aktivtage | 7 |
| Produktionscode aktuell | 16 Dateien / 2728 Zeilen |
| Testcode aktuell | 3 Dateien / 775 Zeilen |
| Dokumentation aktuell | 54 Dateien / 5742 Zeilen |
| Davon Spec-Kit-Artefakte | 11 Dateien / 2139 Zeilen |
| Davon Governance/Agent-Dateien | 5 Dateien / 533 Zeilen |
| Gesamtbasis fuer Handschaetzung (inkl. Dokumentation) | 9245 Zeilen |
| Erfahrener Entwickler, konservative Untergrenze | 115.6 Arbeitstage |
| Erfahrener Entwickler, konservative Untergrenze in Stunden | 901.7 Stunden (115.6 * 7.8) |
| Erfahrener Entwickler, brutto | 5.4 Arbeitsmonate (21.5 Tage/Monat) |
| Erfahrener Entwickler, TVoeD-Annahme | 6.1 Kalendermonate bzw. 0.5 Jahre |
| Thorsten solo, erfahrungsadjustierte Untergrenze | 74.0 Arbeitstage |
| Thorsten solo, erfahrungsadjustierte Untergrenze in Stunden | 577.2 Stunden (74.0 * 7.8) |
| Thorsten solo, brutto | 3.4 Arbeitsmonate (21.5 Tage/Monat) |
| Thorsten solo, TVoeD-Annahme | 3.9 Kalendermonate bzw. 0.3 Jahre |
| Kleines Team (3 Personen, +20 % Koordination), Untergrenze | 46.2 Arbeitstage |
| Kleines Team (3 Personen, +20 % Koordination), TVoeD-Annahme | 2.4 Kalendermonate |
| Repo-weiter Beschleunigungsfaktor vs. konservative Referenz | 16.5x (115.6 / 7 Git-Aktivtage) |
| Repo-weiter Beschleunigungsfaktor vs. Thorsten-Referenz | 10.6x (74.0 / 7 Git-Aktivtage) |

## Branch-Ueberblick

| Branch/Ref | Letzte sichtbare Aktivitaet | Einordnung |
|---|---|---|
| `002-spec-kit-versioning` | 2026-03-27 | Arbeitsbranch fuer repo-weite Versionslogik auf Basis nummerierter Spec-Kit-Branches |
| `main` | 2026-03-06 | Integrationsbranch |
| `codex/spec-kit-init` | 2026-02-28 | Spec-Kit-/Governance-Bootstrap |
| `origin/001-project-context` | 2026-02-28 | Spec-Kit-Featurephase fuer erweiterte Formelbibliothek |
| `origin/codex/extended-formula-library` | 2026-02-28 | Implementierungsbranch fuer die Formel-Erweiterung |
| `origin/copilot/sub-pr-9` | 2026-02-27 | Agent-Hinweis-/Branch-Prefix-Korrektur |
| `origin/hindermath-patch-1` | 2026-03-01 | CI-Anpassung |

## Phasen und grundlegende Arbeiten

### 0. Bootstrap auf `main`

- Status: abgeschlossen und in `main` enthalten
- Beobachtbarer Zeitraum: 2026-02-07 bis 2026-02-27
- Commit-Bild: 29 Commits an 4 Git-Aktivtagen
- Grundlegende Arbeiten: initialer .NET-10-Port, Terminal.Gui-TUI,
  Formel-Golden-Tests, Smoke-Tests, PR-Prozess und erste Agent-Dateien
- Git-Aenderungsvolumen netto:
  - Produktionscode: 1913
  - Testcode: 738
  - Dokumentation: 4717
- Konservative Handarbeits-Basis fuer Code und Dokumentation:
  - 7368 Zeilen netto gesamt
  - 92.1 Arbeitstage fuer einen erfahrenen Entwickler
  - 4.3 Arbeitsmonate brutto bzw. 4.8 TVoeD-Kalendermonate
  - 36.8 Arbeitstage fuer ein 3er-Team (+20 % Koordination), entsprechend ca.
    1.9 TVoeD-Kalendermonaten

### 1. `codex/spec-kit-init`

- Status: abgeschlossen und in `main` enthalten
- Beobachtbarer Zeitraum: 2026-02-27 bis 2026-02-28
- Commit-Bild: 4 Commits an 2 Git-Aktivtagen
- Grundlegende Arbeiten: Constitution, Speckit-Dokumentation, Agent-Guidance,
  Branch-Konventionen, initiale Planungsgrundlage
- Git-Aenderungsvolumen netto:
  - Produktionscode: 0
  - Testcode: 0
  - Dokumentation: 3456
- Konservative Handarbeits-Basis fuer Code und Dokumentation:
  - 3456 Zeilen netto gesamt
  - 43.2 Arbeitstage fuer einen erfahrenen Entwickler
  - 2.0 Arbeitsmonate brutto bzw. 2.3 TVoeD-Kalendermonate
  - 17.3 Arbeitstage fuer ein 3er-Team (+20 % Koordination), entsprechend ca.
    0.9 TVoeD-Kalendermonaten
- Einordnung: dokumentations- und governance-getriebene Phase; die
  Zeilen-Schaetzung bleibt hier ein grober Naeherungswert fuer Prozess- und
  Spezifikationsarbeit.

### 2. `001-project-context` mit Implementierung auf `codex/extended-formula-library`

- Status: abgeschlossen und in `main` enthalten
- Beobachtbarer Zeitraum: 2026-02-28 bis 2026-02-28
- Commit-Bild: 19 Commits an 1 Git-Aktivtag
- Grundlegende Arbeiten: Feature-Spezifikation, Plan, Checklisten, Tasks sowie
  Implementierung von `MIN`, `MAX`, `AVERAGE`, `COUNT`, `IF` und `ROUND`
- Git-Aenderungsvolumen netto:
  - Produktionscode: 183
  - Testcode: 405
  - Dokumentation: 2374
- Konservative Handarbeits-Basis fuer Code und Dokumentation:
  - 2962 Zeilen netto gesamt
  - 37.0 Arbeitstage fuer einen erfahrenen Entwickler
  - 1.7 Arbeitsmonate brutto bzw. 1.9 TVoeD-Kalendermonate
  - 14.8 Arbeitstage fuer ein 3er-Team (+20 % Koordination), entsprechend ca.
    0.8 TVoeD-Kalendermonaten

### 3. Nachlauf und Härtung auf `main`

- Status: abgeschlossen und in `main` enthalten
- Beobachtbarer Zeitraum: 2026-03-01 bis 2026-03-06
- Commit-Bild: 16 Commits an 2 Git-Aktivtagen
- Grundlegende Arbeiten: Runtime-/Package-Anpassungen, CI-Nacharbeit,
  DocFX-Setup, bilinguale XML-Dokumentation, Skills- und Session-Kontext
- Git-Aenderungsvolumen netto:
  - Produktionscode: 632
  - Testcode: 0
  - Dokumentation: 150
- Konservative Handarbeits-Basis fuer Code und Dokumentation:
  - 782 Zeilen netto gesamt
  - 9.8 Arbeitstage fuer einen erfahrenen Entwickler
  - 0.5 Arbeitsmonate brutto bzw. 0.5 TVoeD-Kalendermonate
  - 3.9 Arbeitstage fuer ein 3er-Team (+20 % Koordination), entsprechend ca.
    0.2 TVoeD-Kalendermonaten

### 4. Branch `002-spec-kit-versioning`

- Status: in Arbeit auf Feature-Branch `002-spec-kit-versioning`
- Beobachtbarer Zeitraum: 2026-03-27 bis 2026-03-27
- Commit-Bild: aktueller Working-Tree-Aenderungssatz vor dem ersten Branch-Commit
- Grundlegende Arbeiten: nummerierte Spec-Kit-Branches als zulaessige
  Arbeitsform ergaenzt, repo-weite Versionslogik in `Directory.Build.props`
  eingefuehrt und die gemeinsame Agent-/Constitution-Governance darauf
  synchronisiert
- Git-/Arbeitsbaum-Aenderungsvolumen fuer den aktuellen Aenderungssatz:
  - Produktionscode: 0 Zeilen
  - Testcode: 0 Zeilen
  - Dokumentation und Governance: 35 Zeilen netto
  - Build-/Versionsmetadaten: 7 Zeilen in `Directory.Build.props`
- Konservative Handarbeits-Basis fuer Code und Dokumentation:
  - 42 Zeilen netto gesamt
  - 0.5 Arbeitstage fuer einen erfahrenen Entwickler
  - 3.9 Stunden auf TVoeD-Basis (`0.5 * 7.8`)
  - 0.0 Arbeitsmonate brutto bzw. 0.0 TVoeD-Kalendermonate
- Thorsten-Solo-Referenz:
  - 0.3 Arbeitstage
  - 2.3 Stunden auf TVoeD-Basis (`0.3 * 7.8`)
  - 0.0 Arbeitsmonate brutto bzw. 0.0 TVoeD-Kalendermonate
- Blended Repository Speedup gegen sichtbare 1 Git-Aktivtag fuer diesen
  Aenderungssatz:
  - 0.5x gegen die konservative 80-Zeilen-Referenz
  - 0.3x gegen die Thorsten-Solo-Referenz mit 125 Zeilen pro Arbeitstag

## Einordnung der KI-/Spec-Kit-Wirkung

- Die beobachtbare manuelle Gesamtbasis liegt bereits bei 9245 Zeilen
  (Produktionscode + Tests + Dokumentation).
- Selbst mit der konservativen Obergrenze von 80 manuell erstellten Zeilen pro
  Arbeitstag ergibt sich bereits eine Untergrenze von 115.6
  Entwickler-Arbeitstagen.
- Unter TVoeD-Annahme mit 30 Urlaubstagen pro Jahr entspricht das fuer einen
  erfahrenen Entwickler ca. 6.1 Kalendermonaten bzw. 0.5 Arbeitsjahren; fuer
  ein 3er-Team mit 20 % Koordinationsaufschlag ca. 2.4 Kalendermonaten.
- Unter Einbezug von Thorstens Erfahrungsprofil sinkt die klassische
  Solo-Referenz fuer MicroCalc auf ca. 74.0 Arbeitstage bzw.
  3.9 TVoeD-Kalendermonate.
- Gegen die sichtbaren 7 Git-Aktivtage ergibt sich damit ein repo-weiter
  Beschleunigungsfaktor von ca. 16.5x gegen die konservative Referenz und
  ca. 10.6x gegen die erfahrungsadjustierte Thorsten-Referenz.
- Die Git-Historie zeigt eine deutliche Verdichtung: sehr hoher Doku- und
  Planungsanteil bei gleichzeitig schneller Code- und Testumsetzung.

## Hinweise zum Arbeitsbaum

- Lokale `.codex/`-Metadaten waren im Arbeitsbaum geaendert. Diese Dateien sind
  bewusst aus der Statistik ausgeschlossen.

## Fortschreibungsprotokoll

| Datum | Ausloeser | Eintrag |
|---|---|---|
| 2026-03-21 | Erstanlage | Basisstatistik fuer `main`, `codex/spec-kit-init`, `001-project-context` und `codex/extended-formula-library` angelegt; Constitution, Templates und Agent-Dateien auf Pflegepflicht synchronisiert. |
| 2026-03-22 | Methodik-Update fuer Handarbeits-Schaetzung | Die Statistik rechnet Handarbeit jetzt auf Basis von Produktionscode, Testcode und Dokumentation gemeinsam; zusaetzlich werden Monatswerte auf Basis von 21.5 Arbeitstagen pro Monat sowie TVoeD-Kalenderwerte mit 30 Urlaubstagen pro Jahr ausgewiesen. |
| 2026-03-22 | Governance-Synchronisierung zur Statistiklogik | Constitution sowie die gemeinsamen Agent-Hinweise (`AGENTS.md`, `CLAUDE.md`, `GEMINI.md`, `.github/copilot-instructions.md`) wurden auf die neue Statistiklogik synchronisiert: Handarbeits-Schaetzung umfasst nun Code, Tests und Dokumentation gemeinsam; Monats- und TVoeD-Annahmen muessen explizit genannt werden. |
| 2026-03-22 | Agent-Secret-Scan und Repo-Haertung | `scripts/scan-agent-secrets.sh` aus TinyPl0 nach TinyCalc uebernommen, `.gitignore` gegen lokale Agent-Artefakte gehaertet und verfolgte `.codex`-State-/Session-/Auth-Dateien aus dem Commit-Bereich entfernt, sodass nur projektbezogene Prompt-Dateien in `.codex/` verbleiben. |
| 2026-03-22 | GitHub-Codex-Spec-Kit-Skills installiert | Die lokale Codex-Skill-Struktur `.agents/skills/` mit den neun `speckit-*`-Skills wurde aus TuiVision in TinyCalc uebernommen, damit die Spec-Kit-Kommandos auch in diesem Repository direkt als Skills verfuegbar sind. |
| 2026-03-25 | Erfahrungsadjustierte Beschleunigungsrechnung erweitert | Die Statistik fuehrt jetzt zusaetzlich zur konservativen 80-Zeilen-Referenz eine explizite Thorsten-Solo-Referenz mit Legacy-Portierungsaufschlag; dieselbe Methodik wurde in `AGENTS.md`, `CLAUDE.md`, `GEMINI.md` und `.github/copilot-instructions.md` synchronisiert. |
| 2026-03-25 | TVoeD-Stundenbasis ergänzt | Die Statistik weist zusaetzlich Stundenwerte auf Basis von `7,8 Stunden` bzw. `7 Stunden 48 Minuten` pro Arbeitstag aus; dieselbe Umrechnungsregel wurde in die gemeinsamen Agent-Dateien aufgenommen. |
| 2026-03-27 | TVoeD-Urlaubsregel ab 2027 nachgezogen | Die Statistik- und Agentenmethodik wurde auf die neue Stichtagsregel umgestellt: 30 Urlaubstage pro Jahr gelten nur bis einschliesslich 2026, ab dem Kalenderjahr 2027 werden unter TVoeD-Annahme 31 Urlaubstage bei unveraenderter 5-Tage-Woche verwendet. |
| 2026-03-27 | Branch `002-spec-kit-versioning` | Repo-weite Versionslogik fuer nummerierte Spec-Kit-Branches eingefuehrt: `Directory.Build.props` neu angelegt, die gemeinsame Agent-Governance und die Constitution auf `Minor = Spec-Kit-Feature-/Branch-Nummer als kanonische PR-Nummer` erweitert. |
| 2026-03-27 | Sortierung des Fortschreibungsprotokolls vereinheitlicht | Die Eintraege im Fortschreibungsprotokoll wurden auf strikt chronologische Reihenfolge gebracht: aeltester Eintrag oben, juengster und zuletzt eingetragener Eintrag unten. Dieselbe Regel wurde in der gemeinsamen Agent-Governance fuer dieses Repository festgeschrieben. |
| 2026-03-28 | Lastenheft-Branch-Suffix-Regel in Agent-Guidance verankert | Die gemeinsamen Agent-Dateien (`AGENTS.md`, `CLAUDE.md`, `GEMINI.md`, `.github/copilot-instructions.md`) wurden um die Governance-Regel erweitert, dass ein Lastenheft nach Umsetzung durch einen dedizierten Feature-Branch auf `Lastenheft_<Thema>.<feature-branch>.md` umzubenennen ist, damit die Rueckverfolgbarkeit im Repository erhalten bleibt; Aenderungsumfang dieser Runde vor dieser Ledger-Fortschreibung: 0 Produktionscode-Zeilen, 0 Testcode-Zeilen, +4 Dokumentationszeilen netto im Arbeitsbaum, konservative Handarbeits-Untergrenze 0.1 Arbeitstage bzw. 0.4 Stunden auf TVoeD-Basis, Monatsannahme weiterhin 21.5 Arbeitstage pro Monat. |
| 2026-03-30 | Inklusions-Leitsatz und DocFX-A11y-Baseline verankert | `README.md`, `AGENTS.md`, `CLAUDE.md`, `GEMINI.md` und `.github/copilot-instructions.md` wurden auf den Leitsatz `Programmierung #include<everyone>` nachgezogen: lernrelevante Doku und erzeugte HTML-/API-Dokumentation muessen fuer Braille-Zeile, Screenreader und Textbrowser nutzbar bleiben. Fuer DocFX-basierte HTML-Dokumentation ist WCAG 2.2 AA als praktische Baseline festgehalten; nach jedem DocFX-Neubau soll ein textorientierter A11y-Review mit Playwright/axe und `lynx` folgen. Diese Runde war reine Governance-/Doku-Arbeit mit `0` Produktionscode-Zeilen, `0` Testcode-Zeilen und ca. `+37` Dokumentationszeilen netto. Konservative Manualreferenz: 80 Zeilen/Tag = `0.5` Tage (ca. `4.1` Stunden); Thorsten-Solo-Referenz: 125 Zeilen/Tag = `0.3` Tage (ca. `2.6` Stunden); sichtbares Arbeitsfenster: 1 kurze Agentensitzung am 2026-03-30. |
| 2026-03-30 | Abschlusspruefung fuer Bilingualitaet und A11Y in Planungsdokument verankert | Im zentralen Migrationsplan `PLAN_MICROCALC_CSHARP_DOTNET10.md` wurde ein ausdruecklicher Abschlussblock fuer Dokumentation und Barrierefreiheit ergaenzt: Lernrelevante Dokumente muessen in Deutsch und Englisch auf CEFR-B2-Niveau vorliegen; grosse normative Dokumente duerfen als synchron gepflegte `.EN.md`-Parallelfassung gefuehrt werden; fuer erzeugte HTML-Dokumentation gilt WCAG 2.2 AA als Baseline und nach jedem `docfx`-Neubau ist ein textorientierter A11Y-Review vorgesehen. Diese Runde war reine Dokumentationsarbeit mit `0` Produktionscode-Zeilen, `0` Testcode-Zeilen und ca. `+8` Dokumentationszeilen netto. Konservative Manualreferenz: 80 Zeilen/Tag = `0.1` Tage (ca. `0.8` Stunden); Thorsten-Solo-Referenz: 125 Zeilen/Tag = `0.1` Tage (ca. `0.5` Stunden); sichtbares Arbeitsfenster: 1 kurze Agentensitzung am 2026-03-30. |
| 2026-03-30 | Parent-Guidance bewusst auf repo-uebergreifende Regeln begrenzt | In den lokalen Guidance-Dateien von `TinyCalc` ist jetzt ausdruecklich vermerkt, dass `/Users/thorstenhindermann/RiderProjects/AGENTS.md` nur gemeinsame Basisregeln fuer mehrere Repositories traegt. Repository-spezifische Build-, Test-, Workflow-, Architektur- und Feature-Vorgaben bleiben bewusst in `TinyCalc` selbst und sind dort die spezifischere Autoritaet. Diese Runde war reine Dokumentationsarbeit mit `0` Produktionscode-Zeilen, `0` Testcode-Zeilen und ca. `+10` Dokumentationszeilen netto. Konservative Manualreferenz: 80 Zeilen/Tag = `0.1` Tage (ca. `1.0` Stunden); Thorsten-Solo-Referenz: 125 Zeilen/Tag = `0.1` Tage (ca. `0.6` Stunden); sichtbares Arbeitsfenster: 1 kurze Agentensitzung am 2026-03-30. |
| 2026-03-30 | Fehlende Shared-Baseline-Regeln aus `TuiVision` in `TinyCalc` nachgezogen | Die lokalen Guidance-Dateien (`AGENTS.md`, `CLAUDE.md`, `GEMINI.md`, `.github/copilot-instructions.md`) und diese Statistikdatei wurden nur bei den repo-uebergreifenden Restluecken nachgezogen: `.EN.md`-Option fuer grosse normative Dokumente, formale Abschlusspruefung fuer bilinguale CEFR-B2-Doku plus dokumentierten A11Y-Nachweis, textfirst-/ASCII-Regeln fuer Statistik und Doku, finaler `## Gesamtstatistik`-Block als Schlusssektion, CEFR-B2-Erklaertexte direkt an ASCII-Diagrammen sowie zusaetzliche ASCII-X/Y-Darstellung. MicroCalc-spezifische Architektur-, Feature-, Branch- und Build-Regeln blieben bewusst unveraendert. Diese Runde war reine Dokumentations-/Governance-Arbeit mit `0` Produktionscode-Zeilen, `0` Testcode-Zeilen und `+258 / -2` Dokumentationszeilen netto ueber die betroffenen Guidance- und Statistikdateien. Konservative Manualreferenz: 80 Zeilen/Tag = `3.2` Tage (ca. `25.2` Stunden); Thorsten-Solo-Referenz: 125 Zeilen/Tag = `2.1` Tage (ca. `16.1` Stunden); sichtbares Arbeitsfenster: 1 kurze Agentensitzung am 2026-03-30. |

## Gesamtstatistik

Basis dieses Schlussblocks sind die aktuell dokumentierten Snapshot- und
Phasenwerte aus den Abschnitten `## Gesamtstand des Repositories` und
`## Phasen und grundlegende Arbeiten` weiter oben.

| Kennzahl | Verdichteter Gesamtblick |
|---|---:|
| Artefaktbasis gesamt | `9245` Zeilen |
| Produktions- und Testcode zusammen | `3503` Zeilen (`37.9 %`) |
| Dokumentationsanteil | `5742` Zeilen (`62.1 %`) |
| Spec-Kit-Anteil innerhalb der Doku | `2139` Zeilen (`37.3 %`) |
| Governance-/Agent-Anteil innerhalb der Doku | `533` Zeilen (`9.3 %`) |
| Beobachtbarer Projektzeitraum | `2026-02-07` bis `2026-03-06` |
| Git-Commits pro sichtbarem Aktivtag | `9.7` (`68 / 7`) |
| Dokumentierte Gesamtzeilen pro sichtbarem Aktivtag | `1320.7` (`9245 / 7`) |
| Dokumentierte Gesamtzeilen pro Commit | `136.0` (`9245 / 68`) |
| Konservative Einzelentwickler-Untergrenze | `115.6` Arbeitstage / `901.7` Stunden |
| Thorsten-Solo-Untergrenze | `74.0` Arbeitstage / `577.2` Stunden |
| Kleines 3er-Team mit Koordinationsaufschlag | `46.2` Arbeitstage |
| Repo-weiter Speedup gg. 80-Zeilen-Referenz | `16.5x` |
| Repo-weiter Speedup gg. Thorsten-Referenz | `10.6x` |

Kurzfazit:
Der aktuell dokumentierte Snapshot ist klar dokumentationslastig: Rund
`62.1 %` der sichtbaren Basis liegen in Markdown-, Governance- und
Planungsartefakten, waehrend Produktions- und Testcode zusammen `37.9 %`
ausmachen. Das passt zum beobachtbaren Verlauf von `TinyCalc`, in dem
Portierung, Governance, Spezifikation und Nachweis sehr frueh stark
mitgewachsen sind. Die Beschleunigungsfaktoren beschreiben dabei keine
Stoppuhr, sondern die sichtbare Lieferdichte gegen konservative manuelle
Referenzen.

Short summary:
The currently documented snapshot is clearly documentation-heavy. About
`62.1 %` of the visible baseline sits in Markdown, governance, and planning
artifacts, while production and test code together make up `37.9 %`. This
matches the visible `TinyCalc` trajectory, where porting, governance,
specification, and proof artifacts grew strongly from the start. The
acceleration factors therefore describe visible delivery density, not a
stopwatch measurement.

### ASCII-Diagramme

```text
Artefaktmix nach aktuell dokumentiertem Snapshot (Zeilen)
Produktion     | ##############                 | 2728 | 29.5 %
Tests          | ####                           |  775 |  8.4 %
Dokumentation  | ############################## | 5742 | 62.1 %
```

Dieses Diagramm zeigt, wie der aktuell dokumentierte Repository-Snapshot
zwischen Produktionscode, Tests und Dokumentation verteilt ist. Laengere Balken
bedeuten mehr Zeilen innerhalb derselben Vergleichsgruppe.

This chart shows how the currently documented repository snapshot is split
between production code, tests, and documentation. Longer bars mean more lines
inside the same comparison group.

```text
Dokumentierte Phasenbasis nach Netto-Volumen (Zeilen)
0 main   | ######################## | 7368
1 init   | ###########              | 3456
2 001    | ##########               | 2962
3 harden | ###                      |  782
4 002v   | #                        |   42
```

Dieses Diagramm zeigt die grob sichtbare Netto-Basis der dokumentierten
Phasenpakete. So wird schnell lesbar, welche Phase besonders viel sichtbaren
Umfang erzeugt hat.

This chart shows the rough net size of the documented phase packages. It makes
it easy to see which phase created especially large visible scope.

```text
Konservative Handarbeits-Referenz je dokumentierter Phase (Arbeitstage)
0 main   | ######################## | 92.1 d
1 init   | ###########              | 43.2 d
2 001    | ##########               | 37.0 d
3 harden | ###                      |  9.8 d
4 002v   | #                        |  0.5 d
```

Hier werden dieselben Pakete als konservative manuelle Referenz in
Arbeitstagen gezeigt. Damit wird sichtbar, wie gross derselbe Lieferumfang
ohne agentische Unterstuetzung aus klassischer Sicht waere.

Here the same packages are shown again as a conservative manual reference in
workdays. This makes visible how large the same delivery would look without
agentic support.

```text
Dokumentierte Beschleunigungsfaktoren durch agentische KI + Spec-Kit/SDD
Repo 80  | ###########              | 16.5x
Repo125  | #######                  | 10.6x
0 main   | ###############          | 23.0x
1 init   | ##############           | 21.6x
2 001    | ######################## | 37.0x
3 harden | ###                      |  4.9x
4 002v   | #                        |  0.5x
```

Dieses Diagramm zeigt die dokumentierten Beschleunigungsfaktoren. Es misst
nicht echte Uhrzeit, sondern die sichtbare Verdichtung des Lieferumfangs gegen
gewaehlte manuelle Referenzen.

This chart shows the documented acceleration factors. It does not measure real
clock time. Instead, it compares visible delivery density against the selected
manual references.

```text
Vergleich dokumentierter Gesamtaufwand / sichtbares KI-Lieferfenster
Erfahren   | ############################## | 115.6 d
Thorsten   | ###################            |  74.0 d
KI sichtbar| ##                             |   7.0 d
```

Dieses Diagramm vergleicht die drei Gesamtperspektiven direkt: konservative
Erfahrungsreferenz, Thorsten-Solo-Referenz und sichtbares KI-Lieferfenster.
Der Abstand zwischen den Balken macht die dokumentierte Verdichtung gut lesbar.

This chart compares the three overall perspectives directly: conservative
experienced-developer reference, Thorsten solo reference, and the visible
AI-assisted delivery window. The distance between the bars makes the documented
delivery compression easy to read.

```text
ASCII-X/Y-Verlauf der dokumentierten Phasenbasis (Zeilen)
8000 | *
7000 | *
6000 |
5000 |
4000 |   *
3000 |   *   *
2000 |
1000 |           *
   0 +---+---+---+---+--->
      0   1   2   3   4
```

Die X-Achse zeigt die dokumentierten Phasen `0` bis `4`, die Y-Achse das grobe
Netto-Volumen in Zeilen. Das Diagramm ist bewusst einfach gehalten und soll vor
allem den starken Anfangssprung und den spaeteren Abfall des sichtbaren
Phasenvolumens schnell erklaeren.

The X-axis shows the documented phases `0` to `4`, while the Y-axis shows the
rough net volume in lines. The chart is intentionally simple and is meant to
explain quickly the strong early jump and the later decline in visible phase
volume.
