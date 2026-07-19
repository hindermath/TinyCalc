# Projektstatistik MicroCalc

Stand: 2026-06-19 (aktualisiert nach Lastenheft-Abarbeitungsreihenfolge)

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
| Beobachtbarer Projektzeitraum | 2026-02-07 bis 2026-05-05 |
| Git-Commits gesamt | 68 |
| Autoren laut Git | 2 |
| Git-Aktivtage | 8 |
| Produktionscode aktuell | 16 Dateien / 2728 Zeilen |
| Testcode aktuell | 3 Dateien / 775 Zeilen |
| Dokumentation aktuell | 212 Dateien / 16876 Zeilen |
| Davon Spec-Kit-Artefakte | 46 Template-Dateien / 7922 Zeilen in `.specify/` |
| Davon Governance/Agent-Dateien | 5 Dateien / 1910 Zeilen |
| Gesamtbasis fuer Handschaetzung (inkl. Dokumentation) | 20379 Zeilen |
| Erfahrener Entwickler, konservative Untergrenze | 254.7 Arbeitstage |
| Erfahrener Entwickler, konservative Untergrenze in Stunden | 1987.0 Stunden (254.7 * 7.8) |
| Erfahrener Entwickler, brutto | 11.8 Arbeitsmonate (21.5 Tage/Monat) |
| Erfahrener Entwickler, TVoeD-Annahme | 13.4 Kalendermonate bzw. 1.1 Jahre |
| Thorsten solo, erfahrungsadjustierte Untergrenze | 163.0 Arbeitstage |
| Thorsten solo, erfahrungsadjustierte Untergrenze in Stunden | 1271.6 Stunden (163.0 * 7.8) |
| Thorsten solo, brutto | 7.6 Arbeitsmonate (21.5 Tage/Monat) |
| Thorsten solo, TVoeD-Annahme | 8.6 Kalendermonate bzw. 0.7 Jahre |
| Kleines Team (3 Personen, +20 % Koordination), Untergrenze | 101.9 Arbeitstage |
| Kleines Team (3 Personen, +20 % Koordination), TVoeD-Annahme | 5.4 Kalendermonate |
| Repo-weiter Beschleunigungsfaktor vs. konservative Referenz | 31.8x (254.7 / 8 Git-Aktivtage) |
| Repo-weiter Beschleunigungsfaktor vs. Thorsten-Referenz | 20.4x (163.0 / 8 Git-Aktivtage) |

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

### 5. Agentische Governance-Runde nach Spec-Kit-Preset-Integration

- Status: Arbeitsbaum-Aenderung am 2026-05-05
- Beobachtbarer Zeitraum: 2026-05-05 bis 2026-05-05
- Commit-Bild: aktueller Working-Tree-Aenderungssatz vor Commit
- Grundlegende Arbeiten: Constitution v1.13.0, allgemeine iSAQB/arc42-
  Architektur-Governance, A11Y-/Cross-Platform-/Agent-Parity-/CRA-
  Evidenzpfade, fehlende Preset-Templates nach `.specify/templates/`
  uebernommen und Agent-Guidance synchronisiert
- Git-/Arbeitsbaum-Aenderungsvolumen fuer den aktuellen Aenderungssatz vor
  dieser Statistik-Fortschreibung:
  - Produktionscode: 0 Zeilen
  - Testcode: 0 Zeilen
  - Dokumentation und Governance: +1099 / -10 Zeilen netto ueber geaenderte
    Governance-Dateien und 19 neue Spec-Kit-Template-Dateien
- Konservative Handarbeits-Basis fuer Code und Dokumentation:
  - 1089 Zeilen netto gesamt
  - 13.6 Arbeitstage fuer einen erfahrenen Entwickler
  - 106.2 Stunden auf TVoeD-Basis (`13.6 * 7.8`)
- Thorsten-Solo-Referenz:
  - 8.7 Arbeitstage
  - 68.0 Stunden auf TVoeD-Basis (`8.7 * 7.8`)
- Blended Repository Speedup gegen sichtbare 1 Agenten-Arbeitssitzung fuer
  diesen Aenderungssatz:
  - 13.6x gegen die konservative 80-Zeilen-Referenz
  - 8.7x gegen die Thorsten-Solo-Referenz mit 125 Zeilen pro Arbeitstag

## Einordnung der KI-/Spec-Kit-Wirkung

- Die beobachtbare manuelle Gesamtbasis liegt bereits bei 20379 Zeilen
  (Produktionscode + Tests + Dokumentation).
- Selbst mit der konservativen Obergrenze von 80 manuell erstellten Zeilen pro
  Arbeitstag ergibt sich bereits eine Untergrenze von 254.7
  Entwickler-Arbeitstagen.
- Unter TVoeD-Annahme mit 30 Urlaubstagen pro Jahr entspricht das fuer einen
  erfahrenen Entwickler ca. 13.4 Kalendermonaten bzw. 1.1 Arbeitsjahren; fuer
  ein 3er-Team mit 20 % Koordinationsaufschlag ca. 5.4 Kalendermonaten.
- Unter Einbezug von Thorstens Erfahrungsprofil sinkt die klassische
  Solo-Referenz fuer MicroCalc auf ca. 163.0 Arbeitstage bzw.
  8.6 TVoeD-Kalendermonate.
- Gegen die sichtbaren 8 Git-Aktivtage ergibt sich damit ein repo-weiter
  Beschleunigungsfaktor von ca. 31.8x gegen die konservative Referenz und
  ca. 20.4x gegen die erfahrungsadjustierte Thorsten-Referenz.
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
| 2026-05-05 | Constitution v1.13.0 nach sechs Spec-Kit-Governance-Presets | Die Verfassung wurde nach der Preset-Integration auf allgemeine iSAQB/arc42-Architektur-Governance erweitert; Plan-, Spec- und Tasks-Templates wurden um Architektur-, A11Y-, Cross-Platform-, Agent-Parity- und CRA-Evidenzpfade ergaenzt; 19 fehlende Preset-Templates wurden nach `.specify/templates/` uebernommen; die vier Agent-Dateien wurden synchronisiert. Diese Runde war reine Dokumentations-/Governance-Arbeit mit `0` Produktionscode-Zeilen, `0` Testcode-Zeilen und vor dieser Statistik-Fortschreibung `+1099 / -10` Dokumentationszeilen netto. Konservative Manualreferenz: 80 Zeilen/Tag = `13.6` Tage (ca. `106.2` Stunden); Thorsten-Solo-Referenz: 125 Zeilen/Tag = `8.7` Tage (ca. `68.0` Stunden); sichtbares Arbeitsfenster: 1 Agentensitzung am 2026-05-05. |
| 2026-06-05 | Didaktische Inline-Code-Kommentar-Haertung vorbereitet | `Lastenheft_Didactic-Inline-Code-Comment-Hardening.md` wurde als Specify-ready Intake fuer eine moderate Inline-Kommentar-Haertung angelegt. Der Lauf soll Engine-, Formula-, Recalc-, Textoverflow-, TUI- und Test-Helfer-Flows pruefen, ohne Runtime-Verhalten, Tabellenkalkulationsfunktionen oder TUI-Migration zu veraendern. `AGENTS.md`, `CLAUDE.md`, `GEMINI.md` und `.github/copilot-instructions.md` halten nun fest, dass neue oder geaenderte nicht-triviale Logik auf didaktischen Kommentarbedarf geprueft wird und Kommentare Warum, Trade-off, Randbedingung, historische Abweichung oder Proof-Grenze erklaeren muessen. Validierung: Doku-/Guidance-Suchcheck und `git diff --check`; keine Build-/Test-/DocFX-Ausfuehrung, weil nur Lastenheft, Guidance und Statistik geaendert wurden. |
| 2026-06-18 | Claude-Code-Review-Gate fuer Release-Please-PRs korrigiert | Die PR-Runs fuer Release-Please-PR `#20` standen zunaechst auf `action_required`; nach manuellem Re-run liefen `ci`, Gitleaks, Agent Secret Scan und Homogeneity Check erfolgreich. Der verbleibende Claude-Code-Review-Fehler entstand, weil der Workflow vom `github-actions[bot]` ausgeloest wurde und die Action Bot-Akteure ohne explizite Freigabe blockiert. `.github/workflows/claude-code-review.yml` erlaubt jetzt gezielt nur `github-actions[bot]` ueber `allowed_bots`, statt alle Bots per Wildcard freizugeben. Die danach sichtbaren Node-20-Deprecation-Annotationen wurden durch die Umstellung aller sechs Checkout-Schritte auf den offiziell verfuegbaren `actions/checkout@v6` und des .NET-Setup-Schritts auf `actions/setup-dotnet@v5` nachgezogen. Der macOS-Homogeneity-Job installiert `ripgrep` nun aus dem offiziellen Release-Archiv mit SHA-256-Pruefung statt ueber Homebrew, damit die Homebrew-Tap-Trust-Annotation aus der Runner-Umgebung nicht mehr entsteht. Diese Runde war reine CI-/Workflow-Konfiguration mit `0` Produktionscode-Zeilen, `0` Testcode-Zeilen, `0` Dokumentationszeilen vor dieser Statistik-Fortschreibung und `+19` Workflow-YAML-Zeilen netto; die Checkout- und Setup-Aktualisierungen sind versionsbezogene YAML-Ersetzungen ohne Netto-Zeilenzuwachs. Konservative Manualreferenz: 80 Zeilen/Tag = `0.2` Tage (ca. `1.9` Stunden); Thorsten-Solo-Referenz: 125 Zeilen/Tag = `0.2` Tage (ca. `1.2` Stunden); sichtbares Arbeitsfenster: 1 kurze Agentensitzung am 2026-06-18. |
| 2026-06-19 | Lastenheft-Abarbeitungsreihenfolge vorbereitet | Alle sechs vorbereiteten Lastenhefte wurden in eine spaetere Spec-Kit-Abarbeitungsreihenfolge gebracht: Constitution/Governance, Terminal.Gui-Migration, MicroCalc-zu-TinyCalc-Rename, TUI-A11Y, didaktische Inline-Kommentar-Haertung und abschliessende Secure-Development-Haertung. Die sichtbare Reihenfolge liegt in `docs/Lastenheft_Abarbeitungsreihenfolge.md`; `docs/WORKFLOW_NOTES.md` verweist darauf. Diese Runde startet keinen Spec-Kit-Lauf, erzeugt keine Branches, keine Specs, keine Tasks und keine Implementierung. Aenderungsumfang vor dieser Statistik-Fortschreibung: `0` Produktionscode-Zeilen, `0` Testcode-Zeilen und `+97` Dokumentationszeilen netto. Konservative Manualreferenz: 80 Zeilen/Tag = `1.2` Tage (ca. `9.5` Stunden); Thorsten-Solo-Referenz: 125 Zeilen/Tag = `0.8` Tage (ca. `6.1` Stunden); sichtbares Arbeitsfenster: 1 kurze Agentensitzung am 2026-06-19. |

## Statistikprofil-1-Archiv / Statistics Profile 1 Archive
Basis dieses Schlussblocks sind die aktuell dokumentierten Snapshot- und
Phasenwerte aus den Abschnitten `## Gesamtstand des Repositories` und
`## Phasen und grundlegende Arbeiten` weiter oben.

| Kennzahl | Verdichteter Gesamtblick |
|---|---:|
| Artefaktbasis gesamt | `20379` Zeilen |
| Produktions- und Testcode zusammen | `3503` Zeilen (`17.2 %`) |
| Dokumentationsanteil | `16876` Zeilen (`82.8 %`) |
| Spec-Kit-Anteil innerhalb der Doku | `7922` Zeilen (`46.9 %`) |
| Governance-/Agent-Anteil innerhalb der Doku | `1910` Zeilen (`11.3 %`) |
| Beobachtbarer Projektzeitraum | `2026-02-07` bis `2026-05-05` |
| Git-Commits pro sichtbarem Aktivtag | `8.5` (`68 / 8`) |
| Dokumentierte Gesamtzeilen pro sichtbarem Aktivtag | `2547.4` (`20379 / 8`) |
| Dokumentierte Gesamtzeilen pro Commit | `299.7` (`20379 / 68`) |
| Konservative Einzelentwickler-Untergrenze | `254.7` Arbeitstage / `1987.0` Stunden |
| Thorsten-Solo-Untergrenze | `163.0` Arbeitstage / `1271.6` Stunden |
| Kleines 3er-Team mit Koordinationsaufschlag | `101.9` Arbeitstage |
| Repo-weiter Speedup gg. 80-Zeilen-Referenz | `31.8x` |
| Repo-weiter Speedup gg. Thorsten-Referenz | `20.4x` |

Kurzfazit:
Der aktuell dokumentierte Snapshot ist klar dokumentationslastig: Rund
`82.8 %` der sichtbaren Basis liegen in Markdown-, Governance- und
Planungsartefakten, waehrend Produktions- und Testcode zusammen `17.2 %`
ausmachen. Das passt zum beobachtbaren Verlauf von `TinyCalc`, in dem
Portierung, Governance, Spezifikation und Nachweis sehr frueh stark
mitgewachsen sind. Die Beschleunigungsfaktoren beschreiben dabei keine
Stoppuhr, sondern die sichtbare Lieferdichte gegen konservative manuelle
Referenzen.

Short summary:
The currently documented snapshot is clearly documentation-heavy. About
`82.8 %` of the visible baseline sits in Markdown, governance, and planning
artifacts, while production and test code together make up `17.2 %`. This
matches the visible `TinyCalc` trajectory, where porting, governance,
specification, and proof artifacts grew strongly from the start. The
acceleration factors therefore describe visible delivery density, not a
stopwatch measurement.

### ASCII-Diagramme

```text
Artefaktmix nach aktuell dokumentiertem Snapshot (Zeilen)
Produktion     | #####                          | 2728 | 13.4 %
Tests          | #                              |  775 |  3.8 %
Dokumentation  | ############################## |16876 | 82.8 %
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
5 gov    | ####                     | 1089
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
5 gov    | ####                     | 13.6 d
```

Hier werden dieselben Pakete als konservative manuelle Referenz in
Arbeitstagen gezeigt. Damit wird sichtbar, wie gross derselbe Lieferumfang
ohne agentische Unterstuetzung aus klassischer Sicht waere.

Here the same packages are shown again as a conservative manual reference in
workdays. This makes visible how large the same delivery would look without
agentic support.

```text
Dokumentierte Beschleunigungsfaktoren durch agentische KI + Spec-Kit/SDD
Repo 80  | #####################    | 31.8x
Repo125  | ##############           | 20.4x
0 main   | ###############          | 23.0x
1 init   | ##############           | 21.6x
2 001    | ######################## | 37.0x
3 harden | ###                      |  4.9x
4 002v   | #                        |  0.5x
5 gov    | #########                | 13.6x
```

Dieses Diagramm zeigt die dokumentierten Beschleunigungsfaktoren. Es misst
nicht echte Uhrzeit, sondern die sichtbare Verdichtung des Lieferumfangs gegen
gewaehlte manuelle Referenzen.

This chart shows the documented acceleration factors. It does not measure real
clock time. Instead, it compares visible delivery density against the selected
manual references.

```text
Vergleich dokumentierter Gesamtaufwand / sichtbares KI-Lieferfenster
Erfahren   | ############################## | 254.7 d
Thorsten   | ###################            | 163.0 d
KI sichtbar| #                              |   8.0 d
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
1000 |           *   *
   0 +---+---+---+---+---+--->
      0   1   2   3   4   5
```

Die X-Achse zeigt die dokumentierten Phasen `0` bis `5`, die Y-Achse das grobe
Netto-Volumen in Zeilen. Das Diagramm ist bewusst einfach gehalten und soll vor
allem den starken Anfangssprung und den spaeteren Abfall des sichtbaren
Phasenvolumens schnell erklaeren.

The X-axis shows the documented phases `0` to `5`, while the Y-axis shows the
rough net volume in lines. The chart is intentionally simple and is meant to
explain quickly the strong early jump and the later decline in visible phase
volume.

## Gesamtstatistik / Overall Statistics

<!-- project-statistics-v2:begin -->

Profil 2 verwendet Git-getrackte Textdateien und sichtbare Git-Aktivitaet. Die Werte beschreiben Lieferdichte, keine persoenliche Arbeitszeit.

*Profile 2 uses Git-tracked text files and visible Git activity. The values describe delivery density, not personal working time.*

| Kennzahl / Metric | Wert / Value |
|---|---:|
| Textbasis / Text base | 95591 lines |
| Textdateien / Text files | 565 |
| Beobachtbarer Zeitraum / Observable period | 2026-02-07..2026-07-19 |
| Aktivtage / Active days | 53 |
| Relevante Commits / Relevant commits | 141 |
| Zeilen je Aktivtag / Lines per active day | 1803.6 |
| Peak-Tag im Fenster / Peak day in window | 2026-06-17 / 27058 |
| Peak-Woche im Fenster / Peak week in window | 2026-06-14 / 32513 |
| Laengste Serie / Longest streak | 5 days |
| Speedup vs. 80 lines/day | 22.5x |
| Speedup vs. 125 lines/day | 14.4x |
| Methodik / Methodology | v2; source `49cf4c6b8146` |

### Artefaktmix / Artifact Mix

```text
Produktiv / Production          [#...................]   2.9% | 2748
Tests                           [#...................]   1.6% | 1545
Dokumentation / Documentation   [#################...]  83.8% | 80105
Skripte / Scripts               [##..................]   8.2% | 7866
Konfiguration / Configuration   [#...................]   0.4% | 428
Daten und Medien / Data and media [....................]   0.0% | 0
Sonstiger Text / Other text     [#...................]   3.0% | 2899
```

Die Balken teilen die aktuelle getrackte Textbasis in stabile Kategorien. Prozent und Zeilenwert sind die genaue, textorientierte Aussage.

*The bars split the current tracked text base into stable categories. Percentages and line counts provide the exact text-first result.*

### Tagesaktivitaet / Daily Activity

```text
Wochen / Weeks 01..26 | 2025-07-27..2026-01-24
So/Su  0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0
Mo/Mo  0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0
Di/Tu  0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0
Mi/We  0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0
Do/Th  0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0
Fr/Fr  0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0
Sa/Sa  0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0
```

```text
Wochen / Weeks 27..52 | 2026-01-25..2026-07-25
So/Su  0 0 1 0 0 1 3 0 4 0 0 2 0 0 0 0 0 0 1 0 4 0 0 0 1 4
Mo/Mo  0 0 1 0 0 0 0 0 0 2 0 1 4 0 4 0 0 0 0 0 0 0 3 1 4 -
Di/Tu  0 0 0 0 0 0 0 0 0 3 0 0 0 0 3 0 0 3 0 0 0 0 2 0 3 -
Mi/We  0 0 0 0 0 0 0 0 1 0 0 0 3 0 2 0 0 0 2 0 4 0 2 0 0 -
Do/Th  0 0 0 0 0 0 0 0 0 0 0 0 0 4 0 0 0 1 0 4 1 0 0 0 1 -
Fr/Fr  0 0 0 0 4 4 0 0 2 4 0 2 4 0 0 0 4 2 2 0 3 2 3 4 4 -
Sa/Sa  0 4 0 0 4 0 0 0 2 0 0 0 0 0 0 0 0 0 0 0 4 0 4 4 0 -
```

DE: 0 = keine Aenderung; 1 = 1..79; 2 = 80..399; 3 = 400..1599; 4 = 1600+ geaenderte Textzeilen; - = noch nicht abgelaufen.

*EN: 0 = no change; 1 = 1..79; 2 = 80..399; 3 = 400..1599; 4 = 1600+ changed text lines; - = not elapsed.*

### Wochenvolumen / Weekly Volume

```text
Wochen / Weeks 01..26 | 2025-07-27..2026-01-24
Keine Aktivitaet / No activity
```

```text
Wochen / Weeks 27..52 | 2026-01-25..2026-07-25
   cap 50000 | . . . . . . . . . . . . . . . . . . . . . . . . . .
       41667 | . . . . . . . . . . . . . . . . . . . . . . . . . .
       33333 | . . . . . . . . . . . . . . . . . . . . . . . . . .
       25000 | . . . . . . . . . . . . . . . . . . . . # . . . . .
       16667 | . . . . . . . . . . . . . . . . . . . . # . . . . .
        8333 | . . . . # . . . . . . . # . # . . . . . # . . # . #
           0 +-----------------------------------------------------
```

Das Wochenvolumen zeigt Additionen plus Loeschungen. Es ist Aenderungsaktivitaet, nicht die aktuelle Groesse des Repositories.

*Weekly volume shows additions plus deletions. It represents change activity, not the current repository size.*

### Kumulative Entwicklung / Cumulative Development

```text
Wochen / Weeks 01..26 | 2025-07-27..2026-01-24
Keine Aktivitaet / No activity
```

```text
Wochen / Weeks 27..52 | 2026-01-25..2026-07-25
  cap 200000 | . . . . . . . . . . . . . . . . . . . . . . . . . .
      166667 | . . . . . . . . . . . . . . . . . . . . . . . . . .
      133333 | . . . . . . . . . . . . . . . . . . . . . . . . . #
      100000 | . . . . . . . . . . . . . . . . . . . . . . # # # #
       66667 | . . . . . . . . . . . . . . . . . . . # # # # # # #
       33333 | . . . . . . . . . # # # # # # # # # # # # # # # # #
           0 +-----------------------------------------------------
```

Die kumulative Kurve summiert nur das Brutto-Aenderungsvolumen im Fenster. Sie darf nicht als aktuelle Codebasis gelesen werden.

*The cumulative curve sums gross change volume within the window only. It must not be read as the current code base.*

### Phasenvolumen / Phase Volume

```text
Slots 0..5
   cap 10000 | . . . . . .
        8333 | . . . . . .
        6667 | # . . . . .
        5000 | # . . . . .
        3333 | # # . . . .
        1667 | # # # . . .
           0 +-------------
             00 01 02 03 04 05
```

| Slot | Phase | Nettozeilen / Net lines |
|---:|---|---:|
| 0 | main / main | 7368 |
| 1 | Initialisierung / Initialization | 3456 |
| 2 | 001 / 001 | 2962 |
| 3 | Haertung / Hardening | 782 |
| 4 | 002 Versionierung / 002 versioning | 42 |
| 5 | Governance / Governance | 1089 |

Die festen Slots halten den Phasenvergleich auch bei fehlenden oder spaeter ergaenzten Werten stabil.

*Stable slots keep the phase comparison consistent when values are missing or added later.*

### Beschleunigungsfaktoren / Acceleration Factors

```text
Scale: 0..50x
80 lines/day       [#########...........] 22.5x
125 lines/day      [######..............] 14.4x
```

Die Faktoren vergleichen sichtbare Lieferdichte mit den dokumentierten manuellen Referenzen. Sie messen keine Arbeitszeit.

*The factors compare visible delivery density with documented manual references. They do not measure working time.*

### Durchsatzvergleich / Throughput Comparison

```text
Scale: 0..2000 lines/day
Experienced manual [#...................] 80
Thorsten solo      [#...................] 125
Visible repository [##################..] 1803.6
```

Die gemeinsame Skala vergleicht Referenzen und sichtbare Lieferdichte. Sie schreibt die Git-Aktivitaet keiner Person oder KI pauschal zu.

*The common scale compares references with visible delivery density. It does not attribute Git activity to a person or AI by default.*

### Textalternative / Text Alternative

DE: Das Fenster beginnt am 2025-07-27 und endet am 2026-07-19. Es enthaelt 53 aktive und 305 inaktive vergangene Tage. Peak-Tag: 2026-06-17 / 27058. Peak-Woche: 2026-06-14 / 32513. Laengste Serie: 5 Tage (2026-07-10..2026-07-14).

*EN: The window starts on 2025-07-27 and ends on 2026-07-19. It contains 53 active and 305 inactive elapsed days. Peak day: 2026-06-17 / 27058. Peak week: 2026-06-14 / 32513. Longest streak: 5 days (2026-07-10..2026-07-14).*

| Monat / Month | Geaenderte Textzeilen / Changed text lines |
|---|---:|
| 2025-08 | 0 |
| 2025-09 | 0 |
| 2025-10 | 0 |
| 2025-11 | 0 |
| 2025-12 | 0 |
| 2026-01 | 0 |
| 2026-02 | 17964 |
| 2026-03 | 14288 |
| 2026-04 | 17917 |
| 2026-05 | 13420 |
| 2026-06 | 37318 |
| 2026-07 | 38178 |

<!-- project-statistics-v2:end -->
