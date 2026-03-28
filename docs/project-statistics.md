# Projektstatistik MicroCalc

Stand: 2026-03-22

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
- Die konservative Handarbeits-Basis in dieser Datei zaehlt Produktionscode,
  Testcode und Dokumentation gemeinsam als manuell zu erstellenden Umfang.
- Die konservative Handarbeits-Basis folgt dem Beitrag
  [Adapt or Disappear: How AI Turned a 2-Year Project into a 1-Week Sprint](https://www.holgerscode.com/blog/2026/02/23/adapt-or-disappear-how-ai-turned-a-2-year-project-into-a-1-week-sprint/#a-note-on-the-orm-29000-lines-you-never-have-to-write):
  maximal 80 manuell erstellte Zeilen pro Arbeitstag fuer einen erfahrenen
  Entwickler.
- Umrechnung in Zeitraeume:
  durchschnittlich 21.5 Arbeitstage pro Monat (Mittel aus 21-22 Arbeitstagen);
  unter TVoeD-Annahme mit 30 Urlaubstagen pro Jahr ergeben sich
  `21.5 * 12 - 30 = 228` produktive Arbeitstage pro Jahr bzw.
  durchschnittlich 19.0 produktive Tage pro Kalendermonat.
- Abgeleitete Formeln in dieser Datei:
  Einzelentwickler `((Produktionscode + Testcode + Dokumentation) / 80)`;
  3er-Team `Einzelentwickler / 3 * 1.2` mit 20 % Koordinationsaufschlag.

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
| Erfahrener Entwickler, brutto | 5.4 Arbeitsmonate (21.5 Tage/Monat) |
| Erfahrener Entwickler, TVoeD-Annahme | 6.1 Kalendermonate bzw. 0.5 Jahre |
| Kleines Team (3 Personen, +20 % Koordination), Untergrenze | 46.2 Arbeitstage |
| Kleines Team (3 Personen, +20 % Koordination), TVoeD-Annahme | 2.4 Kalendermonate |

## Branch-Ueberblick

| Branch/Ref | Letzte sichtbare Aktivitaet | Einordnung |
|---|---|---|
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

## Einordnung der KI-/Spec-Kit-Wirkung

- Die beobachtbare manuelle Gesamtbasis liegt bereits bei 9245 Zeilen
  (Produktionscode + Tests + Dokumentation).
- Selbst mit der konservativen Obergrenze von 80 manuell erstellten Zeilen pro
  Arbeitstag ergibt sich bereits eine Untergrenze von 115.6
  Entwickler-Arbeitstagen.
- Unter TVoeD-Annahme mit 30 Urlaubstagen pro Jahr entspricht das fuer einen
  erfahrenen Entwickler ca. 6.1 Kalendermonaten bzw. 0.5 Arbeitsjahren; fuer
  ein 3er-Team mit 20 % Koordinationsaufschlag ca. 2.4 Kalendermonaten.
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
| 2026-03-28 | Lastenheft-Branch-Suffix-Regel in Agent-Guidance verankert | Die gemeinsamen Agent-Dateien (`AGENTS.md`, `CLAUDE.md`, `GEMINI.md`, `.github/copilot-instructions.md`) wurden um die Governance-Regel erweitert, dass ein Lastenheft nach Umsetzung durch einen dedizierten Feature-Branch auf `Lastenheft_<Thema>.<feature-branch>.md` umzubenennen ist, damit die Rueckverfolgbarkeit im Repository erhalten bleibt; Aenderungsumfang dieser Runde vor dieser Ledger-Fortschreibung: 0 Produktionscode-Zeilen, 0 Testcode-Zeilen, +4 Dokumentationszeilen netto im Arbeitsbaum, konservative Handarbeits-Untergrenze 0.1 Arbeitstage bzw. 0.4 Stunden auf TVoeD-Basis, Monatsannahme weiterhin 21.5 Arbeitstage pro Monat. |
