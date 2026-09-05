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

### 7. Feature 003 Terminal.Gui-v2-Migration

- Status: lokale Implementierung und Evidenz bis einschliesslich T054
  abgeschlossen; Plattformnachweise und die exakte PR-Head-Lieferung stehen
  noch aus.
- Beobachtbares Arbeitsfenster: 2026-08-30 10:50 bis 15:55 Uhr
  (`Europe/Berlin`), ein sichtbarer lokaler Aktivtag.
- Arbeitspakete: Spezifikation, Plan und Tasks; Migration der TUI auf
  Terminal.Gui 2.4.17; reale PTY-Nachweise; Build-, Test-, Smoke- und
  Coverage-Nachweise; Architektur-, Security-, A11Y-, SBOM- und PR-Dokumente.
- Aenderungsvolumen vor dem Statistik-Selbstnachweis; das Statistik-Ledger,
  seine Konfiguration und `Directory.Build.props` sind ausgeschlossen:
  - Produktionscode: `+142 / -102 = 40` Zeilen netto
  - Testcode: `+0 / -0 = 0` Zeilen netto
  - Dokumentation und Evidenz: `+9219 / -279 = 8940` Zeilen netto
  - Gesamt: `+9361 / -381 = 8980` Zeilen netto
- Konservative Referenz mit 80 Zeilen pro Arbeitstag:
  - `112.3` Arbeitstage
  - `875.6` Stunden bei `7.8` Stunden bzw. 7 Stunden 48 Minuten pro Tag
  - `5.2` Monate bei 21.5 Arbeitstagen pro Monat
- Thorsten-Solo-Referenz mit 125 Zeilen pro Arbeitstag:
  - `71.8` Arbeitstage
  - `560.4` Stunden bei `7.8` Stunden pro Tag
  - `3.3` Monate bei 21.5 Arbeitstagen pro Monat
- Gegen einen sichtbaren Aktivtag entspricht dies einer gemischten
  Repository-Lieferdichte von `112.3x` bzw. `71.8x`. Diese Faktoren sind
  keine Stoppuhrmessung und schreiben die Leistung keiner einzelnen Person
  oder KI zu.

*The local implementation and evidence are complete through T054; platform
and exact-PR-head proof are still pending. The 8,980 net lines contain 40
production, zero test, and 8,940 documentation/evidence lines. At 7.8 hours
per workday, they correspond to 112.3 conservative manual days (875.6 hours,
5.2 months) or 71.8 Thorsten-solo days (560.4 hours, 3.3 months). The 112.3x
and 71.8x values describe blended repository delivery density, not stopwatch
time.*

### 8. Feature 003 kausaler Closeout

- Status: Produkt-PR am unveränderten Head gemerged, `main` per Fast-Forward
  synchronisiert, Schema-2.0-PostMerge bestanden und kausale Serienmutation
  fuer den separaten Closeout vorbereitet.
- Beobachtbares Arbeitsfenster: 2026-08-30 16:46 bis 17:01 Uhr
  (`Europe/Berlin`), ein sichtbarer Aktivtag.
- Arbeitspakete: PR-Checks und unabhängiger Review; enger Admin-Bypass;
  Produktmerge und unmittelbare Trailerpruefung; Fast-Forward-Sync;
  PostMerge-Snapshot; branchgestempeltes Lastenheft; byteidentische
  Serienarchivierung; Nachfolger-Manifest/-Receipt; read-only Serienstatus und
  terminale getrackte Provider-Proof-Grenze.
- Aenderungsvolumen vor dem Statistik-Selbstnachweis; Statistik-Ledger,
  Konfiguration und `Directory.Build.props` sind ausgeschlossen:
  - Produktionscode: `0` Zeilen
  - Testcode: `0` Zeilen
  - Dokumentation und Evidenz: `669` Zeilen netto
  - Gesamt: `669` Zeilen netto
- Konservative Referenz mit 80 Zeilen pro Arbeitstag:
  - `8.4` Arbeitstage
  - `65.2` Stunden bei `7.8` Stunden pro Tag
  - `0.4` Monate bei 21.5 Arbeitstagen pro Monat
- Thorsten-Solo-Referenz mit 125 Zeilen pro Arbeitstag:
  - `5.4` Arbeitstage
  - `41.7` Stunden bei `7.8` Stunden pro Tag
  - `0.2` Monate bei 21.5 Arbeitstagen pro Monat
- Gegen einen sichtbaren Aktivtag entspricht dies einer gemischten
  Repository-Lieferdichte von `8.4x` beziehungsweise `5.4x`, nicht einer
  Stoppuhrmessung.
- Die exakt benannten terminalen Closeout-Proof-Dateien sind in Phase `003x`
  manuell mit diesen 669 Nettozeilen bilanziert, aber aus dem automatischen
  Snapshot und der Git-History-Kurve ausgeschlossen. Dadurch muss der einzige
  Closeout-Commit seinen eigenen, erst nach dem Commit bekannten SHA nicht im
  generierten Statistikblock enthalten. Produktcode, Tests und alle anderen
  Repository-Artefakte bleiben von dieser engen Selbstreferenz-Ausnahme
  unberuehrt.

*The causal Feature 003 closeout contains no product or test-code change and
669 net documentation/evidence lines before its statistics self-proof. This
corresponds to 8.4 conservative manual days (65.2 hours, 0.4 months) or 5.4
Thorsten-solo days (41.7 hours, 0.2 months). The visible one-day comparison is
blended repository delivery density, not stopwatch time. The exact terminal
closeout proof files are counted manually in phase 003x but excluded from the
automatic snapshot/history to avoid a one-commit SHA self-reference.*

### 9. Tabellen-Grid-Kontrast / Spreadsheet Grid Contrast

- Status: lokal implementiert und durch den vollstaendigen Release-Testlauf
  bestaetigt.
- Beobachtbares Arbeitsfenster: eine kurze Agentensitzung am 2026-08-30.
- Arbeitspakete: explizite Terminal.Gui-Farben fuer `Normal`, `ReadOnly` und
  `Disabled`; kontrastreiche Rollen fuer `Focus` und `Active`; zwei
  Regressionstests fuer beide Zustandsgruppen.
- Aenderungsvolumen vor dem Statistik-Selbstnachweis; Statistik-Ledger,
  Konfiguration und `Directory.Build.props` sind ausgeschlossen:
  - Produktionscode: `30` Zeilen netto
  - Testcode: `30` Zeilen netto
  - Dokumentation: `0` Zeilen
  - Gesamt: `60` Zeilen netto
- Konservative Referenz mit 80 Zeilen pro Arbeitstag: `0.8` Arbeitstage,
  `5.9` Stunden und `0.0` Monate bei 21.5 Arbeitstagen pro Monat.
- Thorsten-Solo-Referenz mit 125 Zeilen pro Arbeitstag: `0.5` Arbeitstage,
  `3.7` Stunden und `0.0` Monate.
- Gegen einen sichtbaren Aktivtag sind `0.8x` und `0.5x` gemischte
  Repository-Lieferdichte und keine Stoppuhrmessung.

*The spreadsheet grid contrast fix explicitly defines readable Terminal.Gui
roles for normal, read-only, disabled, focused, and active states. The change
contains 30 net production and 30 net test lines. This corresponds to 0.8
conservative manual workdays (5.9 hours) or 0.5 Thorsten-solo workdays (3.7
hours); these values describe blended repository delivery density, not
stopwatch time.*

### 10. OK als Default im Werte-Dialog / OK as the Value Dialog Default

- Status: lokal implementiert und durch den vollstaendigen Release-Testlauf
  bestaetigt.
- Beobachtbares Arbeitsfenster: eine kurze Agentensitzung am 2026-08-30.
- Arbeitspakete: Terminal.Gui-Buttonrolle und `DefaultAcceptView` nach dem
  Hinzufuegen beider Dialogbuttons explizit auf `OK` zurueckgesetzt;
  Regressionstest fuer Enter-Binding, Accept-Weiterleitung und genau einen
  Default-Button; realer PTY-Nachweis mit Werteingabe und Enter.
- Aenderungsvolumen vor dem Statistik-Selbstnachweis; Statistik-Ledger,
  Konfiguration und `Directory.Build.props` sind ausgeschlossen:
  - Produktionscode: `12` Zeilen netto
  - Testcode: `37` Zeilen netto
  - Dokumentation: `0` Zeilen
  - Gesamt: `49` Zeilen netto
- Konservative Referenz mit 80 Zeilen pro Arbeitstag: `0.6` Arbeitstage,
  `4.8` Stunden und `0.0` Monate bei 21.5 Arbeitstagen pro Monat.
- Thorsten-Solo-Referenz mit 125 Zeilen pro Arbeitstag: `0.4` Arbeitstage,
  `3.1` Stunden und `0.0` Monate.
- Gegen einen sichtbaren Aktivtag sind `0.6x` und `0.4x` gemischte
  Repository-Lieferdichte und keine Stoppuhrmessung.

*The value dialog now restores `OK` as its sole default and default accept view
after Terminal.Gui has added both buttons. The change contains 12 net
production and 37 net test lines. This corresponds to 0.6 conservative manual
workdays (4.8 hours) or 0.4 Thorsten-solo workdays (3.1 hours); these values
describe blended repository delivery density, not stopwatch time.*

### 11. Gemeinsame TUI-Fix-Lieferung / Combined TUI Fix Delivery

- Status: bilinguale PR-Beschreibung fuer MergeAndSync vorbereitet.
- Beobachtbares Arbeitsfenster: dieselbe Agentensitzung am 2026-08-30.
- Arbeitspakete: Problem, Loesung, Risiken und Testplan fuer Grid-Kontrast und
  Enter-Weiterleitung nachvollziehbar auf Deutsch und Englisch dokumentiert.
- Aenderungsvolumen vor dem Statistik-Selbstnachweis; Statistik-Ledger und
  Konfiguration sind ausgeschlossen:
  - Produktionscode: `0` Zeilen
  - Testcode: `0` Zeilen
  - Dokumentation: `68` Zeilen netto
  - Gesamt: `68` Zeilen netto
- Konservative Referenz mit 80 Zeilen pro Arbeitstag: `0.9` Arbeitstage,
  `6.6` Stunden und `0.0` Monate bei 21.5 Arbeitstagen pro Monat.
- Thorsten-Solo-Referenz mit 125 Zeilen pro Arbeitstag: `0.5` Arbeitstage,
  `4.2` Stunden und `0.0` Monate.
- Gegen einen sichtbaren Aktivtag sind `0.9x` und `0.5x` gemischte
  Repository-Lieferdichte und keine Stoppuhrmessung.

*The bilingual delivery description records the problem, solution, risks, and
test plan for both TUI fixes. Its 68 net documentation lines correspond to 0.9
conservative manual workdays (6.6 hours) or 0.5 Thorsten-solo workdays (4.2
hours); these values describe blended repository delivery density, not
stopwatch time.*

### 12. Feature 004 RL-SE-Checklist-Selbstpruefung

- Status: lokale Bewertung, Assurance-Gates, unabhaengiger Review,
  Dokumentation, Produktregression und plattformuebergreifende CI-Definition
  abgeschlossen; Provider- und Exact-Head-Gates stehen noch aus.
- Beobachtbares Arbeitsfenster: 2026-09-05 18:45 bis 20:20 Uhr
  (`Europe/Berlin`), ein sichtbarer Aktivtag.
- Arbeitspakete: Spec-Kit-Spezifikation, Plan, Tasks und Analyse; 157-Zeilen-
  Matrix; PowerShell-/Bash-Validator; Baseline-3.2.0-Neubindung; vier
  Assurance-Gates; einmaliger unabhaengiger Closure-Review; DE-first/EN-second-
  Bericht; priorisierte Folgearbeit; Documentation Impact; PR- und
  Evidence-Index; Release-Build, 82 Tests und Smoke; Linux-/Windows-CI-
  Erweiterung.
- Aenderungsvolumen vor dem Statistik-Selbstnachweis; Statistik-Ledger,
  Konfiguration und `Directory.Build.props` sind ausgeschlossen:
  - Produktionscode: `0` Zeilen
  - Testcode: `0` Zeilen
  - Dokumentation, Governance, Evidence und Validator-Tooling:
    `+6711 / -9 = 6702` Zeilen netto
  - Gesamt: `6702` Zeilen netto
- Konservative Referenz mit 80 Zeilen pro Arbeitstag: `83.8` Arbeitstage,
  `653.4` Stunden bei 7.8 Stunden pro Tag und `3.9` Monate bei 21.5
  Arbeitstagen pro Monat.
- Thorsten-Solo-Referenz mit 125 Zeilen pro Arbeitstag: `53.6` Arbeitstage,
  `418.2` Stunden bei 7.8 Stunden pro Tag und `2.5` Monate.
- Gegen einen sichtbaren Aktivtag sind `83.8x` und `53.6x` blended repository
  speedup beziehungsweise Lieferdichte. Diese Werte sind keine
  Stoppuhrmessung.

*The local RL-SE assessment covers all 157 canonical items, paired validators,
four Ready assurance gates, one independent closure review, bilingual reader
evidence, explicit follow-up, and unchanged-product regression. Its 6,702 net
documentation, governance, evidence, and validator-tooling lines correspond to
83.8 conservative manual days (653.4 hours, 3.9 months) or 53.6 Thorsten-solo
days (418.2 hours, 2.5 months). These one-visible-day comparisons describe
blended repository delivery density, not stopwatch time; provider and
exact-head gates remain pending.*

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
| 2026-07-23 | Intake Authoring und Review | Neun aktive Lastenhefte als hashgebundene Legacy-Intakes normalisiert; Einzel- und Serienreview `Ready` mit null offenen Findings, Fragen oder Risiken; keine Produktcode- oder Laufzeitänderung. |
| 2026-07-26 | Requirements- und Intake-Struktur konsolidiert | Der historische Produktplan und alle neun Vorgänger-Lastenhefte bleiben hashgebunden erhalten. Ein schlanker `Pflichtenheft.md`-Index, eine aktive Intake-Ablage, eine kanonische Serie, supersedierende Receipts und config-gesteuerte Bash-/PowerShell-/CI-Validatoren ersetzen konkurrierende Reihenfolgen. Constitution ist genau der eine `Eligible` Intake; kein Spec-Kit-Feature und keine Produkt-, API-, Abhängigkeits- oder Laufzeitänderung wurden gestartet. |
| 2026-08-29 | PL/0-Zellfunktionen-V1 als Intake und Serienziel aufgenommen | Auf Branch `codex/pl0-intake-v1` wurde der genehmigte TinyCalc-Intake fuer kompilierte `PL0.<Name>(...)`-Zellfunktionen angelegt und an Position 7 hinter Secure-Development-Hardening in die kanonische Serie aufgenommen. Version 1 umfasst das strenge TinyCalc-PL/0-Profil, den schrittweisen Debugger sowie ein fail-closed Integrationsgate: TinyPl0 muss seinen korrespondierenden Intake abgeschlossen haben, und `TinyPl0.Core` sowie `TinyPl0.Vm` muessen in derselben stabilen Version auf NuGet.org vorliegen; eine lokale `ProjectReference` ist kein Fallback. Vorgaengermanifest und -receipt wurden byteidentisch archiviert, der Nachfolger supersediert sie mit erhaltener Lineage; Governance-Renderer und Coverage-Nachweis wurden auf zehn Ziele nachgezogen. Aenderungsumfang vor dieser Ledger-Fortschreibung: `0` Produktionscode-Zeilen, `0` Testcode-Zeilen und `+665 / -45` Dokumentations-, Governance- und Automationszeilen einschliesslich unveraenderbarer Archivevidenz. Konservative Manualreferenz: 80 Zeilen/Tag = `8.3` Tage (ca. `64.8` Stunden); Thorsten-Solo-Referenz: 125 Zeilen/Tag = `5.3` Tage (ca. `41.5` Stunden); bei einem sichtbaren Aktivtag entspricht dies einem blended repository speedup von `8.3x` bzw. `5.3x`. Sichtbares Arbeitsfenster: 1 Agentensitzung am 2026-08-29. Validierung: Intake- und Serienvalidatoren in Bash und PowerShell, Gesamt-Alignment, JSON-Parsing, Hash-/Archivpruefung und `git diff --check`; kein `dotnet build`/`dotnet test`, weil keine Produkt-, Test-, API- oder Laufzeitaenderung erfolgte. |
| 2026-08-29 | TinyCalc-Delivery-Serie nach PL/0-Erweiterung vollstaendig geprueft | Der bisherige Neun-Ziel-Review wurde nachweisbar durch einen neuen Review aller zehn aktuellen Ziele, vier Wurzeln und sechs internen Hard Gates ersetzt. Zielhashes, DAG, Lifecycle, Authority-Grenzen sowie das externe TinyPl0-/NuGet-Gate sind konsistent. Ergebnis `NeedsRemediation`: `IR001` bewertet die fehlenden deutsch-englischen CEFR-B2-Erklaerungen fuer fortgeschrittene Compiler-, Debugger-, Runtime- und Supply-Chain-Begriffe im PL/0-Intake als mittleren Lernverstaendlichkeitsbefund; keine Risiken wurden akzeptiert und keine Frage blieb offen. Zusaetzlicher Aenderungsumfang gegenueber der Intake-Aufnahme vor dieser Ledger-Fortschreibung: `0` Produktionscode-Zeilen, `0` Testcode-Zeilen und `+197 / -33` Dokumentations-, Governance- und Automationszeilen einschliesslich hashgebundener Supersession-Evidenz. Konservative Manualreferenz: 80 Zeilen/Tag = `2.5` Tage (ca. `19.2` Stunden); Thorsten-Solo-Referenz: 125 Zeilen/Tag = `1.6` Tage (ca. `12.3` Stunden); bei einem sichtbaren Aktivtag entspricht dies einem blended repository speedup von `2.5x` bzw. `1.6x`. Sichtbares Arbeitsfenster: dieselbe Agentensitzung am 2026-08-29. Validierung: Schema-2.0-Konfiguration, Gesamt-Alignment und Review-Resultat jeweils in Bash und PowerShell, Renderer-Drift, Request-Bindung, Zielhashes, Supersession-Hashes und `git diff --check`; kein `dotnet build`/`dotnet test`, weil keine Produkt-, Test-, API- oder Laufzeitaenderung erfolgte. |
| 2026-08-29 | Lernverstaendlichkeitsbefund `IR001` repariert und Serie erneut geprueft | Der ausdrueckliche `speckit-intake-repair`-Aufruf autorisierte ausschließlich die Reparatur des mittleren Befunds im PL/0-Zellfunktionen-Intake. Ein neuer deutsch-englischer CEFR-B2-Begriffsabschnitt erklaert PL/0/P-Code/VM, Integer- und Cache-Grenzen, Debuggerzustand, NuGet-Vertrag sowie Security- und Supply-Chain-Begriffe vor ihrer fachlichen Verwendung. Scope, Nicht-Ziele, Anforderungen, Abnahmeschwellen, Reihenfolge, Gates, Security-/A11Y-Entscheidungen und Delivery Authority blieben unveraendert. Der vollstaendige Nachreview supersediert das Remediation-Ergebnis und ist fuer zehn Ziele, vier Wurzeln und sechs interne Hard Gates `Ready`, ohne verbleibende Findings, akzeptierte Risiken oder offene Fragen. Zusaetzlicher Aenderungsumfang gegenueber dem Remediation-Review vor dieser Ledger-Fortschreibung: `0` Produktionscode-Zeilen, `0` Testcode-Zeilen und `+106 / -28` Dokumentations-, Governance- und Automationszeilen. Konservative Manualreferenz: 80 Zeilen/Tag = `1.3` Tage (ca. `10.3` Stunden); Thorsten-Solo-Referenz: 125 Zeilen/Tag = `0.8` Tage (ca. `6.6` Stunden); bei einem sichtbaren Aktivtag entspricht dies einem blended repository speedup von `1.3x` bzw. `0.8x`. Sichtbares Arbeitsfenster: dieselbe Agentensitzung am 2026-08-29. Validierung: Zielhash vor der Reparatur, Schema-2.0-Konfiguration, Gesamt-Alignment und Review-Resultat jeweils in Bash und PowerShell, vollständige Serien-Neupruefung, Renderer-Drift, Request-Bindung und `git diff --check`; kein `dotnet build`/`dotnet test`, weil keine Produkt-, Test-, API- oder Laufzeitaenderung erfolgte. |
| 2026-08-29 | MergeAndSync-Lieferung fuer PL/0-Intake vorbereitet | Fuer den fokussierten PR wurde eine bilinguale Beschreibung mit Problem, Loesung, Risiken und Testplan angelegt. Sie dokumentiert ausdruecklich, dass dieser Liefergegenstand nur Intake- und Governance-Artefakte umfasst, keine PL/0-Implementierung oder NuGet-Veroeffentlichung startet und die bestehende `LocalImplementation`-Grenze nicht erweitert. Zusaetzlicher Aenderungsumfang vor dieser Ledger-Fortschreibung: `0` Produktionscode-Zeilen, `0` Testcode-Zeilen und `+59` Dokumentationszeilen. Konservative Manualreferenz: 80 Zeilen/Tag = `0.7` Tage (ca. `5.8` Stunden); Thorsten-Solo-Referenz: 125 Zeilen/Tag = `0.5` Tage (ca. `3.7` Stunden); sichtbares Arbeitsfenster: dieselbe Agentensitzung am 2026-08-29. Der Nutzer hat Commit, Push und `MergeAndSync` mit Admin-Bypass fuer diesen PR ausdruecklich autorisiert. |
| 2026-08-30 | Feature 002 Constitution-Abgleich lokal implementiert / Feature 002 constitution alignment implemented locally | Arbeitsfenster: eine geroutete Agentensitzung und ein sichtbarer lokaler Aktivtag am 2026-08-30. Arbeitspakete: Eingangsgates, bytegleiche Constitution-Spiegel, fuenf Agentenflaechen, acht Vorlagen, vollstaendige oeffentliche XML-Inventur, Release-Build, Security-/A11Y-Nachweis, PR-Text und lokale Tests. Beobachteter Nettoumfang vor dem Statistik-Selbstnachweis: `0` Produktionscode-Zeilen, `0` Testcode-Zeilen und `+3185 / -81 = 3104` Dokumentations-/Governancezeilen; `.specify/runtime/` und das Statistik-Ledger selbst sind ausgeschlossen. Konservative Referenz 80 Zeilen/Arbeitstag: `38.8` Tage, `302.6` Stunden bei 7.8 Stunden/Tag und `1.8` Monate bei 21.5 Arbeitstagen/Monat. Thorsten-Solo-Referenz 125 Zeilen/Arbeitstag: `24.8` Tage, `193.7` Stunden und `1.2` Monate. Gegen einen sichtbaren Aktivtag entspricht dies einem blended repository speedup bzw. einer Lieferdichte von `38.8x` und `24.8x`, nicht einer Stoppuhrmessung. Validierung: Hash-/State-/Regelmatrizen, 76/76 XML-API-Zeilen, Restore, Build mit 0 Warnungen/Fehlern, 79/79 xUnit-Tests, `SMOKE_OK`, keine bekannte verwundbare Abhaengigkeit, kein High-Secret-Fund und Homogenitaet 100. *Work window: one routed session and one visible local active day on 2026-08-30. The 3,104 net documentation/governance lines imply 38.8 conservative manual days (302.6 hours, 1.8 months) or 24.8 Thorsten-solo days (193.7 hours, 1.2 months). The 38.8x and 24.8x values describe blended repository delivery density, not stopwatch time.* |
| 2026-08-30 | TinyCalc-Serie nach Feature 002 fortgeschrieben und CI-Negativtest entkoppelt | Der abgeschlossene Constitution-Intake wurde auf `Completed` gesetzt und TerminalGui-Migration als einziges naechstes Ziel auf `Eligible` angehoben; Reihenfolge, vier Wurzeln und sechs Abhaengigkeiten blieben erhalten. Manifest und Receipt des Vorgaengers wurden byteidentisch archiviert, der Nachfolger wahrt die Supersession-Lineage. Ein zunaechst plattformuebergreifend fehlgeschlagener Governance-Negativtest setzte noch starr den ersten Serieneintrag statt des tatsaechlich `Eligible` Ziels auf `Pending`; die Fixture sucht dieses Ziel nun statusbasiert und bleibt damit bei kuenftigen Serienfortschreibungen stabil. Arbeitsfenster: eine Agentensitzung und ein sichtbarer Aktivtag am 2026-08-30. Aenderungsumfang vor diesem Statistik-Selbstnachweis: `0` Produktionscode-Zeilen, `+3 / -1 = 2` Testcode-Zeilen und `+245 / -51 = 194` Dokumentations-, Governance- und Automationszeilen einschliesslich unveraenderbarer Archivevidenz. Konservative Manualreferenz: 80 Zeilen/Tag = `2.5` Tage (ca. `19.1` Stunden); Thorsten-Solo-Referenz: 125 Zeilen/Tag = `1.6` Tage (ca. `12.2` Stunden); gegen einen sichtbaren Aktivtag entspricht dies einem blended repository speedup von `2.5x` bzw. `1.6x`, nicht einer Stoppuhrmessung. Validierung: vollstaendiges PowerShell-Alignment, acht status- und hashbezogene Negativ-Fixtures, Serien- und Receipt-Gates sowie die vorhandenen CI-Build-, Test-, Secret- und Homogenitaetspruefungen. *The completed Constitution intake is now `Completed`, TerminalGui migration is the sole `Eligible` target, and the negative fixture now locates that target by status. The 196 net test and governance lines correspond to 2.5 conservative manual days or 1.6 Thorsten-solo days; these are blended delivery-density comparisons, not stopwatch measurements.* |
| 2026-08-30 | Feature 003 Terminal.Gui-v2-Migration lokal dokumentiert / Feature 003 Terminal.Gui v2 migration documented locally | Arbeitsfenster: 2026-08-30 10:50 bis 15:55 Uhr (`Europe/Berlin`), ein sichtbarer Aktivtag. Die lokale Migration, reale PTY-Nachweise, Coverage sowie Architektur-, Security-, A11Y-, SBOM- und PR-Evidenz sind bis T054 abgeschlossen; Plattform- und Exact-Head-Nachweise bleiben Delivery-Gates. Umfang vor dem Statistik-Selbstnachweis: `+142 / -102 = 40` Produktionscode-Zeilen, `0` Testcode-Zeilen und `+9219 / -279 = 8940` Dokumentations-/Evidenzzeilen, insgesamt `8980` Zeilen netto. Bei `7.8` Stunden/Tag entsprechen sie `112.3` konservativen Arbeitstagen (`875.6` Stunden, `5.2` Monate) oder `71.8` Thorsten-Solo-Tagen (`560.4` Stunden, `3.3` Monate). Gegen einen Aktivtag sind `112.3x` und `71.8x` gemischte Lieferdichte, keine Stoppuhrmessung. *The 8,980 net lines comprise 40 production, zero test, and 8,940 documentation/evidence lines. Platform and exact-head proof remain pending delivery gates; the stated factors describe blended delivery density.* |
| 2026-08-30 | Feature 003 Produktlieferung und kausaler Closeout vorbereitet / Feature 003 product delivery and causal closeout prepared | Arbeitsfenster: 2026-08-30 16:46 bis 17:01 Uhr (`Europe/Berlin`), ein sichtbarer Aktivtag. Produkt-PR `#60` wurde nach Linux-/Windows-CI, unabhängigem befundfreiem Review, null Threads und Exact-Head-Gates gemerged; der Provider-Trailer wurde sofort geprueft und `main` per Fast-Forward synchronisiert. Der PostMerge-Snapshot bestand; das Lastenheft ist branchgestempelt, die Serie mit byteidentischer Vorgängerlinie kausal fortgeschrieben und read-only ohne Drift geprueft. Umfang vor dem Statistik-Selbstnachweis: `0` Produktionscode-Zeilen, `0` Testcode-Zeilen und `669` Dokumentations-/Evidenzzeilen netto. Konservative Referenz: `8.4` Tage bzw. `65.2` Stunden und `0.4` Monate; Thorsten-Solo-Referenz: `5.4` Tage bzw. `41.7` Stunden und `0.2` Monate. Gegen einen sichtbaren Aktivtag sind `8.4x` und `5.4x` gemischte Lieferdichte, keine Stoppuhrmessung. Der einzige Closeout-PR und seine Providerfakten folgen read-only ohne weiteren getrackten Write. *The product PR is merged and synchronized, PostMerge passed, and the causal intake closeout is prepared. The 669 net documentation/evidence lines imply 8.4 conservative or 5.4 Thorsten-solo days; later provider facts remain read-only.* |
| 2026-08-30 | Tabellen-Grid-Kontrast korrigiert / Spreadsheet grid contrast corrected | Arbeitsfenster: eine kurze Agentensitzung am 2026-08-30. Arbeitspakete: explizite Terminal.Gui-Palette fuer normale und schreibgeschuetzte Grid-Darstellung, kontrastreiche Hervorhebungsrollen sowie zwei Regressionstests. Umfang vor dem Statistik-Selbstnachweis: `30` Produktionscode-Zeilen, `30` Testcode-Zeilen und `0` Dokumentationszeilen, insgesamt `60` Nettozeilen; Versionsmetadaten und Statistikdateien sind ausgeschlossen. Konservative Referenz: `0.8` Arbeitstage bzw. `5.9` Stunden; Thorsten-Solo-Referenz: `0.5` Arbeitstage bzw. `3.7` Stunden. Gegen einen sichtbaren Aktivtag sind `0.8x` und `0.5x` gemischte Lieferdichte, keine Stoppuhrmessung. Validierung: Release-Build innerhalb von `dotnet test`, 76/76 Core-Tests und 5/5 TUI-Tests; keine neue Abhaengigkeit. *The grid now uses explicit high-contrast normal/read-only and highlighted roles. The 60 net production and test lines correspond to 0.8 conservative or 0.5 Thorsten-solo workdays; all 81 tests pass and no dependency was added.* |
| 2026-08-30 | OK und Enter im Werte-Dialog wiederhergestellt / OK and Enter restored in the value dialog | Arbeitsfenster: eine kurze Agentensitzung am 2026-08-30. Terminal.Gui setzt beim Hinzufuegen den jeweils letzten Dialogbutton als Default; nach unveraendert sichtbarer Reihenfolge `OK`, `Cancel` werden deshalb die Buttonrolle und `DefaultAcceptView` explizit auf `OK` gesetzt. Umfang vor dem Statistik-Selbstnachweis: `12` Produktionscode-Zeilen, `37` Testcode-Zeilen und `0` Dokumentationszeilen, insgesamt `49` Nettozeilen; Versionsmetadaten und Statistikdateien sind ausgeschlossen. Konservative Referenz: `0.6` Arbeitstage bzw. `4.8` Stunden; Thorsten-Solo-Referenz: `0.4` Arbeitstage bzw. `3.1` Stunden. Validierung: Release-Build innerhalb von `dotnet test`, 76/76 Core-Tests und 6/6 TUI-Tests sowie realer PTY-Lauf mit Werteingabe und Enter; keine neue Abhaengigkeit. *The value dialog now restores OK as its sole default and default accept view after both buttons are added. The 49 net production and test lines correspond to 0.6 conservative or 0.4 Thorsten-solo workdays; all 82 tests and a real Enter-key PTY path pass, with no dependency added.* |
| 2026-08-30 | Gemeinsame TUI-Fix-Lieferung vorbereitet / Combined TUI fix delivery prepared | Arbeitsfenster: dieselbe Agentensitzung am 2026-08-30. Eine bilinguale PR-Beschreibung dokumentiert Problem, Loesung, Risiken und Testplan fuer Grid-Kontrast sowie `OK`-/Enter-Weiterleitung. Umfang vor dem Statistik-Selbstnachweis: `0` Produktionscode-Zeilen, `0` Testcode-Zeilen und `68` Dokumentationszeilen netto. Konservative Referenz: `0.9` Arbeitstage bzw. `6.6` Stunden; Thorsten-Solo-Referenz: `0.5` Arbeitstage bzw. `4.2` Stunden. Der Nutzer hat Commit, Push und DeliveryMode `MergeAndSync` mit Admin-Bypass ausdruecklich autorisiert; materielle Gates bleiben verbindlich. *The 68 net documentation lines provide the bilingual PR problem, solution, risks, and test plan. They correspond to 0.9 conservative or 0.5 Thorsten-solo workdays; material gates remain mandatory.* |
| 2026-09-01 | Vollstaendigen TUI-Funktionsvertrag und erweiterbare Intake-Roadmap vorbereitet / Complete TUI contract and extensible intake roadmap prepared | Arbeitsfenster: eine sichtbare Agentensitzung am 2026-09-01 auf Branch `codex/tinycalc-intake-regression-roadmap`. Arbeitspakete: vollstaendiger TUI-/README-/Hilfe-Funktionsvertrag mit stabilen IDs und Impact-Matrix, A11Y-/Rename-/PL0-Fortschreibung, getrennte Lastenhefte fuer MCS-Legacy-Kompatibilitaet und strukturelle Tabellenoperationen, 13-Ziele-Serie mit vier Wurzeln und neun Hard Gates, hashgebundene Vorgänger- und Review-Evidenz, Renderer-/Coverage-Nachzug sowie bilinguale PR-Beschreibung. Umfang vor diesem Statistik-Selbstnachweis: `0` Produktionscode-Zeilen, `0` Testcode-Zeilen und `+7293 / -723 = 6570` Dokumentations-, Intake-, Governance- und Automationszeilen netto einschliesslich unveraenderbarer Archivevidenz; der Renderer-Anteil betraegt davon `+130 / -58 = 72` Nettozeilen. Konservative Referenz: `82.1` Arbeitstage, ca. `640.6` Stunden und `3.8` Monate bei 21.5 Arbeitstagen/Monat. Thorsten-Solo-Referenz: `52.6` Arbeitstage, ca. `410.0` Stunden und `2.4` Monate. Gegen einen sichtbaren Aktivtag sind `82.1x` und `52.6x` blended repository speedup bzw. Lieferdichte, keine Stoppuhrmessung. Lokale Validierung: Intake-, Serien-, Review- und Governance-Gates in PowerShell und Bash, acht Negativ-Fixtures, Hash-/Archiv-Lineage, Secret-Scan, Homogenitaet, JSON-/Markdown-/Diff-Pruefungen; kein lokaler Produkt-Build, weil Produktcode, Tests, APIs und Laufzeit unveraendert sind und die verpflichtende Linux-/Windows-CI als Delivery-Gate abgewartet wird. Der Nutzer hat Commit, Push und DeliveryMode `MergeAndSync` mit Admin-Bypass ausdruecklich autorisiert. *One visible session prepared the complete functional contract and extensible thirteen-target roadmap. The 6,570 net documentation, intake, governance, and automation lines correspond to 82.1 conservative or 52.6 Thorsten-solo days; these values describe blended repository delivery density, not stopwatch time. Product code and tests remain unchanged, while remote Linux and Windows CI stays mandatory before merge.* |
| 2026-09-03 | TinyPl0-Lieferstufe im PL/0-Intake aktualisiert / TinyPl0 delivery stage refreshed in the PL/0 intake | Arbeitsfenster: eine sichtbare Agentensitzung am 2026-09-03 auf Branch `codex/pl0-delivery-evidence-refresh`. Arbeitspakete: die ueberholte Noch-nicht-Aussage durch den stabilen Release `v0.4.1`, Quellcommit und erfolgreichen Build-/SBOM-/VEX-/Provenienz-/Attestierungs-/Publish-/Consumer-Lauf ersetzt; beide versionsgleichen NuGet.org-Pakete als Remote-Snapshots gebunden; TinyCalc-Preflight und internen Security-Vorgaenger weiterhin offen und blockierend gehalten; Intake-, Receipt-, Serien- und Review-Vorgaenger byteidentisch archiviert; aktiven Alt-Review supersediert; Renderer, Alignment und bilinguale PR-Beschreibung nachgezogen. Umfang vor diesem Statistik-Selbstnachweis: `0` Produktionscode-Zeilen, `0` Testcode-Zeilen und `+1600 / -440 = 1160` Dokumentations-, Intake-, Governance- und Automationszeilen netto einschliesslich unveraenderbarer Archivevidenz. Konservative Referenz: `14.5` Arbeitstage, ca. `113.1` Stunden und `0.7` Monate bei 21.5 Arbeitstagen/Monat. Thorsten-Solo-Referenz: `9.3` Arbeitstage, ca. `72.4` Stunden und `0.4` Monate. Gegen einen sichtbaren Aktivtag sind `14.5x` und `9.3x` blended repository speedup beziehungsweise Lieferdichte, keine Stoppuhrmessung. Validierung: Live-Release-/Workflow-/NuGet-Abgleich, Authoring- und Serienvalidatoren in PowerShell und Bash, explizit ausstehender Review, Alignment, Hash-/Archiv-Lineage, JSON, UTF-8, Secret-Scan, Markdown und `git diff --check`. Beide Homogenitaetsvarianten bestanden 28 von 29 Pruefungen und meldeten ausschliesslich den erwarteten Statistik-Profil-Drift: Der Renderer darf bei schmutzigem Arbeitsbaum nicht schreiben, waehrend Commit und Stash nicht autorisiert sind. NIST SSDF und CWE Top 25 bleiben anwendbar; SBOM/VEX/SLSA sind gebundene Liefernachweise, waehrend ASVS, Zero Trust und Produkt-AI-SBOM begruendet `N/A` bleiben. Kein `dotnet build`, `dotnet test`, Restore, Paketupgrade oder DocFX-Neubau, weil Produktcode, Tests, APIs, Abhaengigkeiten, Laufzeit und DocFX-Inhalte unveraendert sind. Keine Commit-, Push-, PR-, Merge- oder Bypass-Berechtigung. *One visible session corrected the delivery snapshot, bound release and public-package evidence, preserved the open TinyCalc preflight and blocked lifecycle, and archived all superseded governance evidence. The 1,160 net documentation and governance lines correspond to 14.5 conservative or 9.3 Thorsten-solo days; these values describe blended delivery density, not stopwatch time. Both homogeneity variants have only the expected statistics drift because the clean-tree renderer cannot write without commit authority. No product or remote delivery action is authorised.* |
| 2026-09-04 | TinyCalc-Delivery-Serie nach PL/0-Liefernachweis erneut geprueft / TinyCalc delivery series re-reviewed after PL/0 delivery evidence | Arbeitsfenster: eine sichtbare Agentensitzung am 2026-09-04 auf Branch `codex/tinycalc-delivery-intake-review`. Der vollständige schema-1.1-Serienreview bindet 13 aktuelle Zielhashes, vier Wurzeln, neun Hard Gates und die Supersession-Lineage. Der TinyPl0-Release `v0.4.1`, Quellcommit, erfolgreiche SBOM-/VEX-/Provenienz-/Publish-/Consumer-Jobs und beide versionsgleichen NuGet.org-Pakete wurden live bestätigt. Die externe Lieferstufe ist erfüllt; TinyCalc-Pin, Locked Restore, Driftklassifikation, Contract-Tests und der interne Secure-Development-Vorgänger bleiben offen, sodass PL/0 weiterhin korrekt `Blocked` ist. Review-Ergebnis: `Ready`, keine Findings, akzeptierten Risiken oder offenen Fragen. Umfang vor diesem Statistik-Selbstnachweis: `0` Produktionscode-Zeilen, `0` Testcode-Zeilen und `+438 / -10 = 428` Dokumentations-/Governance- und Automationszeilen netto. Konservative Referenz: `5.4` Arbeitstage, ca. `41.7` Stunden und `0.2` Monate; Thorsten-Solo-Referenz: `3.4` Arbeitstage, ca. `26.7` Stunden und `0.2` Monate. Gegen einen sichtbaren Aktivtag sind `5.4x` und `3.4x` blended repository speedup beziehungsweise Lieferdichte, keine Stoppuhrmessung. Validierung: Schema-2.0-Konfiguration, Request-Bindung, Zielhashes, DAG, Serienmanifest/-Receipt, Review-Ergebnis und Gesamt-Alignment jeweils in PowerShell und Bash sowie Live-Release-/NuGet-Abgleich, JSON, UTF-8, Secret-Scan und `git diff --check`. Kein Produkt-Build, Restore, Paketupgrade oder DocFX-Neubau. Der Nutzer hat anschließend Commit, Push und DeliveryMode `MergeAndSync` mit Admin-Bypass ausdrücklich autorisiert; technische Gates bleiben verbindlich. *One visible session re-reviewed all thirteen targets after the PL/0 evidence update. The external package delivery is verified, while every TinyCalc integration and predecessor gate remains open. The 428 net governance and automation lines correspond to 5.4 conservative or 3.4 Thorsten-solo days; these are blended delivery-density comparisons, not stopwatch measurements. The user subsequently authorised governed MergeAndSync delivery; technical gates remain mandatory.* |
| 2026-09-04 | Secure Development Assurance Governance v0.1.0 installiert / Secure Development Assurance Governance v0.1.0 installed | Arbeitsfenster: eine sichtbare Agentensitzung am 2026-09-04 auf Branch `codex/secure-development-assurance-pilot`. Das unveraenderliche Release-ZIP wurde mit SHA-256 `d9effc395e590d1ffe832d059f8681501da1d1b6e7d44d79a3e61929bc5229c1` bestaetigt und als dreizehntes Preset installiert. `security-governance` v0.6.2 bleibt Prioritaet 10; das neue Assurance-Preset v0.1.0 verwendet Prioritaet 15 und erzeugt ausschliesslich den portablen Evidence-Vertrag sowie Status-/Review-Oberflaechen. Umfang vor diesem Statistik-Selbstnachweis: `0` Produktionscode-Zeilen, `0` Testcode-Zeilen und `+3327 / -0 = 3327` Dokumentations-, Governance-, Validator- und Testzeilen netto. Konservative Referenz: `41.6` Arbeitstage, ca. `324.4` Stunden und `1.9` Monate; Thorsten-Solo-Referenz: `26.6` Arbeitstage, ca. `207.6` Stunden und `1.2` Monate. Gegen einen sichtbaren Aktivtag sind `41.6x` und `26.6x` blended repository speedup beziehungsweise Lieferdichte, keine Stoppuhrmessung. Validierung: exakte 13-Preset-Matrix unter Bash und PowerShell, `preset list/info/resolve`, `specify check`, Vertrags- und Shell-Paritaetstests, Read-only-Hashnachweis, LF/CRLF/BOM-Fixtures, temporaere Disable-/Enable-/Remove-/12er-/Reinstall-Komposition, Documentation Impact, JSON, Secret-Scan und `git diff --check`. Produktcode, Tests, API und Laufzeit bleiben unveraendert; die Installation startet keinen Spec-Kit-Lauf. *One visible session verified and installed the immutable v0.1.0 release as the thirteenth preset. The 3,327 net governance, validator, test, and documentation lines correspond to 41.6 conservative or 26.6 Thorsten-solo workdays; these are blended delivery-density comparisons, not stopwatch measurements. Product behavior remains unchanged and the two field-test runs start only after this installation is delivered.* |
| 2026-09-05 | Assurance-Preset v0.1.1 korrigiert installiert / Corrected assurance preset v0.1.1 installed | Arbeitsfenster: eine sichtbare Sitzung am 2026-09-05 auf dem bestehenden Branch `codex/secure-development-assurance-pilot`. Arbeitspakete: hashgeprueftes unveraenderliches v0.1.1-Archiv, korrigierte Validatorpfade und rohe Snapshots, acht erzeugte Agentenflaechen, aktuelle Dokumentationsauswirkung und formale Bypass-Grenze. Umfang vor diesem Statistik-Selbstnachweis: `0` Produktcode- und `0` Produkttest-Zeilen; uebernommener Paketdelta und Dokumentation `+785 / -101 = 684` Nettozeilen, davon `343` Preset-Testzeilen, `17` Validatorzeilen und `324` Dokumentations-/Governance-/CI-Zeilen. Wiederverwendung, keine 684 neu entwickelten Produktzeilen. Konservative Referenz 80 Zeilen/Tag: `8.6` Arbeitstage, `66.7` Stunden; Thorsten-Solo 125: `5.5` Arbeitstage, `42.7` Stunden bei 7.8 Stunden/Tag. Gegen einen sichtbaren Aktivtag: `8.6x`/`5.5x` blended repository speedup, keine Stoppuhrmessung. Native Paket-CI auf drei Plattformen bestanden; lokale exakte 13er-Matrix, Maintenance-Regressionssuite (52 Tests, 3 bedingte Skips), Preset-Vertraege und Dokumentationsvalidator geprueft. Produkt-API, Laufzeit und DocFX bleiben unveraendert; kein Feature-Lauf gestartet. / Verified archive reuse and generated-surface correction; volume describes imported governance and evidence, not new product code. Native package gates pass; current TinyCalc delivery and the two substantive field tests remain separate. |
| 2026-09-05 | Assurance-Preset v0.1.2 mit strikten Evidence-Grenzen installiert / Assurance preset v0.1.2 installed with strict evidence boundaries | Arbeitsfenster: dieselbe sichtbare Sitzung am 2026-09-05 auf Branch `codex/secure-development-assurance-pilot`. Arbeitspakete: unveraendertes veroeffentlichtes v0.1.2-Archiv mit SHA-256 `4eb30804bb3c329681e0b7d44187c8daeb3e9e4f250bb6003d5b746c0ad0b656`, strikte skalare und nichtleere `acceptedRisks[].id`, genau eine JSON-Wurzel, Bash-/PowerShell-Paritaet, unabhaengige Kandidatenpruefung sowie aktualisierte Feldtest-Evidence. Umfang vor diesem Statistik-Selbstnachweis: `0` Produktcode- und `0` Produkttest-Zeilen; uebernommener Preset- und Dokumentationsdelta `+225 / -26 = 199` Nettozeilen, davon `98` Preset-Testzeilen, `17` Validatorzeilen und `84` Dokumentations-/Governance-Zeilen. Wiederverwendung, keine 199 neu entwickelten Produktzeilen. Konservative Referenz 80 Zeilen/Tag: `2.5` Arbeitstage und ca. `19.4` Stunden; Thorsten-Solo 125: `1.6` Arbeitstage und ca. `12.4` Stunden bei 7.8 Stunden/Tag. Gegen einen sichtbaren Aktivtag: `2.5x`/`1.6x` blended repository speedup, keine Stoppuhrmessung. Paket- und Source-Merge wurden providerseitig geprueft; native CI auf Linux, macOS und Windows, exakte 13er-Matrix, vollstaendige Preset-Vertraege, alle acht installierten Oberflaechen, Documentation Impact, JSON, Secret-Scan und `git diff --check` bestanden. NIST SSDF und CWE Top 25 gelten; ASVS, Zero Trust und Produkt-AI-SBOM sind fuer diese lokale Governance-Installation begruendet `N/A`. Produkt-API, Laufzeit und DocFX bleiben unveraendert; kein Feature-Lauf gestartet. / The immutable v0.1.2 archive closes accepted-risk ID and multiple-JSON-root bypasses consistently in both shells. The 199 net imported governance, validator, test, and documentation lines correspond to 2.5 conservative or 1.6 Thorsten-solo days; this is blended delivery density, not stopwatch time. Product behavior is unchanged, and both substantive field-test features remain separate. |
| 2026-09-05 | Feature 004 RL-SE-Selbstpruefung lokal abgeschlossen / Feature 004 RL-SE self-assessment completed locally | Arbeitsfenster: 2026-09-05 18:45 bis 20:50 Uhr (`Europe/Berlin`), ein sichtbarer Aktivtag. Arbeitspakete: vollstaendige 157-ID-Matrix, Baseline-3.2.0-Korrektur unter ausdruecklicher enger Autoritaet, beide Validatoren samt vollstaendiger JSON-Schema-Pruefung und robuster plattformuebergreifender Negativ-Fixture, vier Assurance-Gates, einmaliger unabhaengiger Review, DE-first/EN-second-Bericht, 42 Human-only- und 62 Follow-up-Grenzen, Dependency-/Produktregression, CI-, PR-, Documentation-Impact- und Evidence-Index. Umfang vor dem Statistik-Selbstnachweis: `0` Produktionscode-Zeilen, `0` Testcode-Zeilen und `+6769 / -9 = 6760` Dokumentations-, Governance-, Evidence- und Validator-Tooling-Zeilen netto. Konservative Referenz: `84.5` Arbeitstage, `659.1` Stunden und `3.9` Monate; Thorsten-Solo: `54.1` Arbeitstage, `421.8` Stunden und `2.5` Monate. Gegen einen sichtbaren Aktivtag sind `84.5x` und `54.1x` blended repository speedup, keine Stoppuhrmessung. Lokal bestanden: 157/157, Schema-Negativtest auch unter CI-Fehlersemantik, Assurance Ready, Review Ready, Build 0/0, 82/82 Tests, `SMOKE_OK`, 0 bekannte anfaellige Pakete sowie Dokumentations- und statische Gates. Die erste Provider-Runde war gruen; zwei spaet eingetroffene Review-Hinweise und der plattformabhaengige Harness-Fehler wurden behoben und verlangen eine neue Exact-Head-Runde. *The 6,760 net documentation, governance, evidence, and validator-tooling lines provide the complete local assessment without product or test-code changes. Manual comparisons are delivery-density estimates; the corrected exact head still requires provider convergence.* |

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
| Textbasis / Text base | 167501 lines |
| Textdateien / Text files | 1149 |
| Beobachtbarer Zeitraum / Observable period | 2025-09-07..2026-09-05 |
| Aktivtage / Active days | 76 |
| Relevante Commits / Relevant commits | 212 |
| Zeilen je Aktivtag / Lines per active day | 2204.0 |
| Peak-Tag im Fenster / Peak day in window | 2026-06-17 / 27058 |
| Peak-Woche im Fenster / Peak week in window | 2026-07-19 / 33630 |
| Laengste Serie / Longest streak | 8 days |
| Speedup vs. 80 lines/day | 27.5x |
| Speedup vs. 125 lines/day | 17.6x |
| Methodik / Methodology | v2; source `fb8f3e523aef` |

### Artefaktmix / Artifact Mix

```text
Produktiv / Production          [#...................]   1.7% | 2830
Tests                           [#...................]   4.1% | 6937
Dokumentation / Documentation   [###############.....]  73.7% | 123425
Skripte / Scripts               [###.................]  13.1% | 21907
Konfiguration / Configuration   [#...................]   5.6% | 9390
Daten und Medien / Data and media [....................]   0.0% | 0
Sonstiger Text / Other text     [#...................]   1.8% | 3012
```

Die Balken teilen die aktuelle getrackte Textbasis in stabile Kategorien. Prozent und Zeilenwert sind die genaue, textorientierte Aussage.

*The bars split the current tracked text base into stable categories. Percentages and line counts provide the exact text-first result.*

### Tagesaktivitaet / Daily Activity

```text
Wochen / Weeks 01..26 | 2025-09-07..2026-03-07
So/Su  0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 1 0 0 1
Mo/Mo  0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 1 0 0 0
Di/Tu  0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0
Mi/We  0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0
Do/Th  0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0
Fr/Fr  0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 4 4
Sa/Sa  0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 4 0 0 4 0
```

```text
Wochen / Weeks 27..52 | 2026-03-08..2026-09-05
So/Su  3 0 4 0 0 2 0 0 0 0 0 0 1 0 4 0 0 0 1 4 4 1 4 4 0 4
Mo/Mo  0 0 0 2 0 1 4 0 4 0 0 0 0 0 0 0 3 1 4 4 0 0 0 2 0 0
Di/Tu  0 0 0 3 0 0 0 0 3 0 0 3 0 0 0 0 2 0 3 4 4 0 0 0 0 4
Mi/We  0 0 1 0 0 0 3 0 2 0 0 0 2 0 4 0 2 0 0 2 4 0 0 0 0 0
Do/Th  0 0 0 0 0 0 0 4 0 0 0 1 0 4 1 0 0 0 1 4 0 0 4 0 0 3
Fr/Fr  0 0 2 4 0 2 4 0 0 0 4 2 2 0 3 2 3 4 4 4 1 0 0 0 0 4
Sa/Sa  0 0 2 0 0 0 0 0 0 0 0 0 0 0 4 0 4 4 0 4 2 0 2 0 3 4
```

DE: 0 = keine Aenderung; 1 = 1..79; 2 = 80..399; 3 = 400..1599; 4 = 1600+ geaenderte Textzeilen; - = noch nicht abgelaufen.

*EN: 0 = no change; 1 = 1..79; 2 = 80..399; 3 = 400..1599; 4 = 1600+ changed text lines; - = not elapsed.*

### Wochenvolumen / Weekly Volume

```text
Wochen / Weeks 01..26 | 2025-09-07..2026-03-07
   cap 20000 | . . . . . . . . . . . . . . . . . . . . . . . . . .
       16667 | . . . . . . . . . . . . . . . . . . . . . . . . . .
       13333 | . . . . . . . . . . . . . . . . . . . . . . . . . .
       10000 | . . . . . . . . . . . . . . . . . . . . . . . . # .
        6667 | . . . . . . . . . . . . . . . . . . . . . . . . # .
        3333 | . . . . . . . . . . . . . . . . . . . . . # . . # #
           0 +-----------------------------------------------------
```

```text
Wochen / Weeks 27..52 | 2026-03-08..2026-09-05
   cap 50000 | . . . . . . . . . . . . . . . . . . . . . . . . . .
       41667 | . . . . . . . . . . . . . . . . . . . . . . . . . .
       33333 | . . . . . . . . . . . . . . . . . . . # . . . . . #
       25000 | . . . . . . . . . . . . . . # . . . . # . . . . . #
       16667 | . . . . . . . . . . . . . . # . . . . # # . . . . #
        8333 | . . . . . . # . # . . . . . # . . # . # # . # . . #
           0 +-----------------------------------------------------
```

Das Wochenvolumen zeigt Additionen plus Loeschungen. Es ist Aenderungsaktivitaet, nicht die aktuelle Groesse des Repositories.

*Weekly volume shows additions plus deletions. It represents change activity, not the current repository size.*

### Kumulative Entwicklung / Cumulative Development

```text
Wochen / Weeks 01..26 | 2025-09-07..2026-03-07
   cap 50000 | . . . . . . . . . . . . . . . . . . . . . . . . . .
       41667 | . . . . . . . . . . . . . . . . . . . . . . . . . .
       33333 | . . . . . . . . . . . . . . . . . . . . . . . . . .
       25000 | . . . . . . . . . . . . . . . . . . . . . . . . . .
       16667 | . . . . . . . . . . . . . . . . . . . . . . . . # #
        8333 | . . . . . . . . . . . . . . . . . . . . . . . . # #
           0 +-----------------------------------------------------
```

```text
Wochen / Weeks 27..52 | 2026-03-08..2026-09-05
  cap 500000 | . . . . . . . . . . . . . . . . . . . . . . . . . .
      416667 | . . . . . . . . . . . . . . . . . . . . . . . . . .
      333333 | . . . . . . . . . . . . . . . . . . . . . . . . . .
      250000 | . . . . . . . . . . . . . . . . . . . . . . . . . .
      166667 | . . . . . . . . . . . . . . . . . . . . # # # # # #
       83333 | . . . . . . . . . . . . . . # # # # # # # # # # # #
           0 +-----------------------------------------------------
```

Die kumulative Kurve summiert nur das Brutto-Aenderungsvolumen im Fenster. Sie darf nicht als aktuelle Codebasis gelesen werden.

*The cumulative curve sums gross change volume within the window only. It must not be read as the current code base.*

### Phasenvolumen / Phase Volume

```text
Slots 0..13
   cap 10000 | . . . . . . . . . . . . . .
        8333 | . . . . . . . # . . . . . .
        6667 | # . . . . . . # . . . . . #
        5000 | # . . . . . . # . . . . . #
        3333 | # # . . . . . # . . . . . #
        1667 | # # # . . . # # . . . . # #
           0 +-----------------------------
             00 01 02 03 04 05 06 07 08 09 10 11 12 13
```

| Slot | Phase | Nettozeilen / Net lines |
|---:|---|---:|
| 0 | main / main | 7368 |
| 1 | Initialisierung / Initialization | 3456 |
| 2 | 001 / 001 | 2962 |
| 3 | Haertung / Hardening | 782 |
| 4 | 002 Versionierung / 002 versioning | 42 |
| 5 | Governance / Governance | 1089 |
| 6 | 002 Constitution / 002 constitution | 3104 |
| 7 | 003 Terminal.Gui / 003 Terminal.Gui | 8980 |
| 8 | 003 Closeout / 003 closeout | 705 |
| 9 | Grid-Kontrast / Grid contrast | 60 |
| 10 | Dialog-Default / Dialog default | 49 |
| 11 | TUI-Fix-Lieferung / TUI fix delivery | 68 |
| 12 | Assurance-Preset / Assurance preset | 3327 |
| 13 | 004 RL-SE-Selbstpruefung / 004 RL-SE self-assessment | 6760 |

Die festen Slots halten den Phasenvergleich auch bei fehlenden oder spaeter ergaenzten Werten stabil.

*Stable slots keep the phase comparison consistent when values are missing or added later.*

### Beschleunigungsfaktoren / Acceleration Factors

```text
Scale: 0..50x
80 lines/day       [###########.........] 27.5x
125 lines/day      [#######.............] 17.6x
```

Die Faktoren vergleichen sichtbare Lieferdichte mit den dokumentierten manuellen Referenzen. Sie messen keine Arbeitszeit.

*The factors compare visible delivery density with documented manual references. They do not measure working time.*

### Durchsatzvergleich / Throughput Comparison

```text
Scale: 0..5000 lines/day
Experienced manual [#...................] 80
Thorsten solo      [#...................] 125
Visible repository [#########...........] 2204.0
```

Die gemeinsame Skala vergleicht Referenzen und sichtbare Lieferdichte. Sie schreibt die Git-Aktivitaet keiner Person oder KI pauschal zu.

*The common scale compares references with visible delivery density. It does not attribute Git activity to a person or AI by default.*

### Textalternative / Text Alternative

DE: Das Fenster beginnt am 2025-09-07 und endet am 2026-09-05. Es enthaelt 76 aktive und 288 inaktive vergangene Tage. Peak-Tag: 2026-06-17 / 27058. Peak-Woche: 2026-07-19 / 33630. Laengste Serie: 8 Tage (2026-07-19..2026-07-26).

*EN: The window starts on 2025-09-07 and ends on 2026-09-05. It contains 76 active and 288 inactive elapsed days. Peak day: 2026-06-17 / 27058. Peak week: 2026-07-19 / 33630. Longest streak: 8 days (2026-07-19..2026-07-26).*

| Monat / Month | Geaenderte Textzeilen / Changed text lines |
|---|---:|
| 2025-10 | 0 |
| 2025-11 | 0 |
| 2025-12 | 0 |
| 2026-01 | 0 |
| 2026-02 | 17964 |
| 2026-03 | 14281 |
| 2026-04 | 17917 |
| 2026-05 | 13420 |
| 2026-06 | 37273 |
| 2026-07 | 74876 |
| 2026-08 | 26218 |
| 2026-09 | 20248 |

<!-- project-statistics-v2:end -->
