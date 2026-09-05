# Aufgaben / Tasks: RL-SE-/Checklist-Selbstpruefung

**Eingabe / Input**: Akzeptierte Artefakte unter
`specs/004-rl-se-self-assessment/` und der bindende Intake
`requirements/intakes/active/Lastenheft_RL-SE-Checklist-Selbstpruefung.md`
**Branch / Branch**: `004-rl-se-self-assessment`
**Autonomer Lauf / Autonomous run**:
`faae97c9-e61b-480e-b6dd-24b8121868d0`
**Liefermodus / Delivery mode**: `MergeAndSync`; Admin-Bypass ist nur fuer
eine verbleibende formale Merge-Regel erlaubt.

## Ausfuehrungsvertrag / Execution Contract

- Die Aufgaben laufen seriell. Eine Aufgabe wird erst nach ihrem benannten
  Nachweis abgehakt; ein materielles technisches, Security-, A11Y-,
  Governance-, Evidenz- oder Review-Gate darf nicht umgangen werden.
- Der Lauf bewertet und dokumentiert. `src/`, `tests/`, Projektabhaengigkeiten,
  oeffentliche APIs, DocFX, Produktkonfiguration, Provider-Konfiguration und
  Agenten-Guidance bleiben unveraendert. Als einziger Workflow-Diff ist die
  Matrixvalidierung in `.github/workflows/ci.yml` zugelassen.
- Lesertexte sind DE-first/EN-second, CEFR B2 und text-first. WCAG 2.2 AA ist
  die A11Y-Basis; wesentliche Aussagen duerfen nicht nur von Farbe oder Layout
  abhaengen.
- Vor jedem lokalen `dotnet build` oder `dotnet test` wird der Build-Zaehler
  genau einmal erhoeht. Vor Commit/Push sind `Version`, `AssemblyVersion` und
  `FileVersion` auf `1.4.<prospektiver Feature-Commitcount>.<Build>` identisch.
- Jeder erzeugte Commit und beide Provider-Merge-Commits enthalten exakt
  einmal `Co-authored-by: Copilot <223556219+Copilot@users.noreply.github.com>`.
- Der operative `autonomous-run-state.json` und Runtime-Ergebnisse bleiben
  ignoriert und werden nie gestagt. GSDB darf erst nach T055 beginnen.

## Phase 1: Gate-Freeze und Quellenbindung / Gate Freeze and Source Binding

- [x] T001 Run-State mit beiden Preset-Validatoren pruefen und Branch, Run-ID,
  Basiscommit sowie akzeptierte Intake-/Serien-/Spec-/Plan-Hashes in
  `specs/004-rl-se-self-assessment/autonomous-run-evidence.md` festhalten.
  **Nachweis**: Bash und PowerShell Exitcode 0; **Grenze**: bei Drift stoppen.
- [x] T002 Betriebssystem und Werkzeuge (`pwsh`, `.NET 10`, `git`, `gh`,
  `jq`) pruefen und die TinyCalc-Zeile des Level-2-Umgebungsregisters aus
  `constitution.md` in der Lauf-Evidenz binden. **Nachweis**: macOS und
  erforderliche Versionen sichtbar; **Grenze**: keine neue Toolchain einfuehren.
- [x] T003 Baseline-Manifest 3.2.0, dessen kontrollierte Dokument-Hashes,
  exakt zwoelf kanonische Einzelchecklisten und exakt 157 eindeutige IDs
  maschinell einfrieren. **Nachweis**:
  `docs/security/secure-development/2026-09-05-rl-se-self-assessment/baseline.json`;
  **Grenze**: Sammelband bleibt nur Paritaets-Lesesicht.
- [x] T004 Alle dreizehn installierten Governance-Presets mit Version,
  Prioritaet und Status inventarisieren, ihre relevanten Pruefpunkte fuer T040
  extrahieren sowie Serie und Review-Freshness read-only pruefen. **Nachweis**:
  Lauf-Evidenz nennt 13/13 und unveraenderte Serie; **Grenze**: Inventar allein
  ersetzt nicht die T040-Zuordnung, kein Preset- oder Folgefeature-Update.
- [x] T005 Den beabsichtigten Delivery-Satz und die verbotenen Produkt-, Test-,
  Dependency-, DocFX-, Agenten- und Fremdworkflow-Pfade in
  `specs/004-rl-se-self-assessment/autonomous-run-evidence.md` festlegen.
  **Nachweis**: exakte Pfadliste; **Grenze**: jede Erweiterung erfordert neue
  Autoritaet.

## Phase 2: RED-Vertrag und kleinster Validator / RED Contract and Minimal Validator

**Zweck / Purpose**: Der Nachweis-Validator wird beobachtbar rot, bevor eine
vollstaendige Ergebnismatrix existiert.

- [x] T006 [US1] Einen frischen temporaeren Pfad erzeugen und den noch nicht
  vorhandenen PowerShell-Validator gegen die fehlende Matrix aufrufen.
  **Erwartetes Rot**: nicht-null Exitcode und benannte fehlende Matrix;
  **Nachweis**: Befehl, Ausgabe, Exitcode und UTC-Zeit in
  `specs/004-rl-se-self-assessment/autonomous-run-evidence.md`.
- [x] T007 [US1] `scripts/validate-rl-se-assessment.ps1` mit bilingualer
  Comment-based Help und dem genehmigten Cmdlet-Namen `Test-RlSeAssessment`
  anlegen. Es prueft Schema, Baseline-Bindung, 157 IDs, Statuskombinationen,
  Pflichtfelder, Human-only-Regeln und sichere repository-relative Pfade.
  **Voraussetzung**: T006; **Nachweis**: fehlende Matrix scheitert weiterhin
  aus dem richtigen Grund.
- [x] T008 [US1] `scripts/validate-rl-se-assessment.sh` als duennen Bash-
  Einstieg mit identischer CLI-Semantik, `--help` und Weitergabe an
  `pwsh -NoProfile` anlegen. **Voraussetzung**: T007; **Nachweis**: beide
  Einstiege liefern fuer dieselbe fehlende Matrix denselben Fehlerstatus.
- [x] T009 [US1] Isolierte Row-Contract-Fixtures ausserhalb der
  Produktionsmatrix fuer gueltige Zeile, Duplikat, ungueltige Statuskombination,
  POSIX-/Windows-/UNC-/Traversal-Pfad und Human-only-Fehlbehauptung ausfuehren.
  **Nachweis**: nur die gueltige Zeile besteht; keine Ein-Zeilen-Datei wird als
  vollstaendige Produktionsmatrix bezeichnet.
- [x] T010 [US1] Cross-Platform-Dokumentation fuer das interne Skript bewerten:
  Unix-Manpage ist `N/A`, weil kein Endnutzerkommando verteilt wird; Trigger ist
  eine oeffentliche CLI-Auslieferung. Die PowerShell-Hilfe und Bash-`--help`
  bleiben Pflicht. **Nachweis**: begruendete Entscheidung in der Lauf-Evidenz.

## Phase 3: User Story 1 - Vollstaendige Matrix (P1, MVP)

**Unabhaengiger Test / Independent test**: Beide Validator-Einstiege melden
157/157 kanonische IDs, null Duplikate und null unbekannte IDs.

- [x] T011 [US1] Das JSON-Schema aus
  `specs/004-rl-se-self-assessment/contracts/assessment-matrix.schema.json`
  im Validator verankern und jede `documentBindings`-Quelle gegen ihren
  normalisierten SHA-256 pruefen. **Voraussetzung**: T007-T009.
- [x] T012 [US1] Fuer jede kanonische ID genau eine fachlich konkrete Zeile in
  `docs/security/secure-development/2026-09-05-rl-se-self-assessment/assessment-matrix.json`
  erstellen; positive Aussagen benoetigen konkrete Evidenz, andere Aussagen
  Owner, Aktion, Prioritaet, Risiko und Trigger. **Grenze**: keine Erfuellung
  aus blosser Dateiexistenz ableiten.
- [x] T013 [US1] Alle Human-only-Zeilen auf `humanDecisionEvidence` =
  `NotProvided`, Disposition `Open` oder `FollowUp` und nicht `Fulfilled`
  begrenzen. **Nachweis**: Validator und explizite Zaehlsumme.
- [x] T014 [US1] Summary-Zahlen nach Familie, Disposition, Anwendbarkeit und
  Umsetzungsstand aus den 157 Zeilen ableiten und gegen die Matrix pruefen.
  **Nachweis**: jede Summendimension ergibt 157.
- [x] T015 [US1] Beide lokalen Einstiege gegen die vollstaendige Matrix
  ausfuehren. **Erwartetes Gruen**: Exitcode 0, `157/157`, null fehlend,
  doppelt oder unbekannt; **Nachweis**: Ausgabe und Hash in der Lauf-Evidenz.
- [x] T016 [US1] Den Validator minimal aufraeumen, PowerShell mit
  `invoke-psscriptanalyzer.ps1` sowie Shell mit `bash -n` pruefen und T009/T015
  wiederholen. **Nachweis**: alle Gruen-Nachweise unveraendert.
- [x] T017 [US1] Changed-product-code-Coverage als `N/A` dokumentieren, weil
  `src/` und `tests/` unveraendert bleiben; Mindestwert 70 %, Ziel 80 % werden
  neu geprueft, sobald Produktcode geaendert wird. **Nachweis**: Diff-Pruefung
  plus Wiedervorlage-Trigger in der Lauf-Evidenz.

## Phase 4: User Story 2 - Nachvollziehbare Entscheidungen (P2)

**Unabhaengiger Test / Independent test**: Je eine Stichprobe aus CL-01 bis
CL-12 fuehrt von ID ueber Begruendung zur konkreten Quelle und Evidenz.

- [x] T018 [US2] Die 157 Zeilen fachlich gegen Richtlinie, Einzelchecklisten,
  beide Constitutions, mitgeltende Dokumente, `docs/security/`, CI, Tests und
  Preset-Inventar pruefen; jede pauschale oder unbelegte positive Aussage in
  `Open` oder `FollowUp` korrigieren.
- [x] T019 [US2] NIST SSDF, CWE Top 25, C#-Secure-Coding, STRIDE/CAPEC und SAMM
  explizit zuordnen; ASVS, Produkt-AI-SBOM und Zero Trust mit den genehmigten
  `N/A`-Triggern festhalten. **Nachweis**: Matrix und Bericht widerspruchsfrei.
- [x] T020 [US2] SBOM, bedingtes VEX, SLSA/Provenance, OpenSSF sowie CRA,
  NIS2, EU AI Act, DORA und BSI C3A/C5 technisch bewerten, ohne Rechts-, Audit-
  oder Zertifizierungsaussage. **Nachweis**: konkrete Evidenz oder begruendetes
  `Open`/`FollowUp`/`N/A` je relevantem Punkt.
- [x] T021 [US2] Assurance-`baseline.json`,
  `deltas/rl-se-assessment.json`, `closure.json` und `image-impact.json` unter
  `docs/security/secure-development/2026-09-05-rl-se-self-assessment/`
  erzeugen und gegen Assurance Governance 0.1.2 validieren.
- [x] T022 [US2] `speckit-secure-development-status` read-only ausfuehren und
  nur einen echten technischen Pass akzeptieren. **Grenze**: menschliche
  Pilot-, Projekt- oder Allgemeinfreigabe bleibt getrennt und unbehauptet.
- [x] T023 [US2] Genau einen unabhaengigen
  `speckit-secure-development-review` ausfuehren und materielle Befunde vor
  Fortsetzung beheben oder als Laufblocker behandeln. **Nachweis**: frisches
  Reviewresultat zum unveraenderten Evidenz-Head.
- [x] T024 [US2] Den bilingualen, linearen Bericht
  `docs/security/secure-development/2026-09-05-rl-se-self-assessment/evidence-matrix.md`
  mit Umfang, Quellenstand, Familien-Summen, Restrisiken, Human-only-Grenzen,
  Folgearbeit und Triggern erzeugen.
- [x] T025 [US2] DE-first/EN-second, CEFR B2, Text-first und WCAG 2.2 AA fuer
  alle neuen Leserartefakte pruefen; Tabellen erhalten lineare Erklaerungen
  und keine Bedeutung haengt nur an Farbe/Layout. **Nachweis**: dokumentierter
  textorientierter Review.
- [x] T026 [US2] `docs/security/README.md` nur fuer die Auffindbarkeit des
  neuen Berichts ergaenzen; keine DocFX-Navigation aendern. **Nachweis**:
  funktionierender relativer Link und begruendetes DocFX-`N/A`.

## Phase 5: User Story 3 - Steuerbare Folgearbeit (P3)

**Unabhaengiger Test / Independent test**: Jede `Open`-/`FollowUp`-Zeile ist
ohne Produktdelta als konkreter spaeterer Arbeitsauftrag nutzbar.

- [x] T027 [US3] Alle `Open`- und `FollowUp`-Zeilen auf Rollen-Owner,
  Prioritaet, Risiko, konkrete Aktion, Trigger und Restrisiko pruefen; keine
  externe Aktion ausfuehren oder als erledigt behaupten.
- [x] T028 [US3] Folgearbeiten nach Prioritaet und Familie im Bericht
  zusammenfassen und die getrennte Autorisierungsgrenze fuer Haertung,
  Provider-Aktion, Rechtsbewertung und menschliche Freigabe sichtbar machen.
- [x] T029 [US3] Documentation Impact als `UpdateRequired`, Distribution als
  repository-intern, Home Sync als `NotRequired` und Agent-Parity als
  `NoUpdateRequired` mit Triggern dokumentieren und
  `scripts/test-documentation-impact.ps1` ausfuehren.
- [x] T030 [US3] Architekturdelta, allgemeine S-ADR, XML/API-Dokumentation,
  DocFX, Produkt-TDD, oeffentliche Manpage und automatische Dependency-Updates
  als `N/A` mit kurzer Begruendung und Re-Evaluierungstrigger dokumentieren.
- [x] T031 [US3] `docs/PR_TEXT_RL_SE_SELF_ASSESSMENT.md` mit Problem, Loesung,
  Scope, Risiken, Testplan, Security-/A11Y-/Konfigurationswirkung und
  Human-only-Grenze DE-first/EN-second erstellen.
- [x] T032 [US3] `specs/004-rl-se-self-assessment/autonomous-run-evidence.md`
  auf den abgeschlossenen Bewertungsstand bringen, ohne Remote-, Review-,
  Merge- oder PostMerge-Erfolg vorwegzunehmen.

## Phase 6: Regression und Governance / Regression and Governance

- [x] T033 `dotnet list MicroCalc.sln package --outdated` und vorhandenen
  Dependency-Audit read-only pruefen; Updates sind in diesem
  Bewertungsfeature `N/A`, konkrete kritische Funde blockieren jedoch die
  Lieferung und loesen VEX-Disposition aus.
- [x] T034 Vor dem Release-Build den Build-Zaehler einmal erhoehen, alle drei
  Versionsfelder angleichen, `dotnet restore MicroCalc.sln` und danach
  `dotnet build MicroCalc.sln --configuration Release --no-restore`
  ausfuehren. **Nachweis**: Version, UTC-Zeit, Befehl und Exitcode.
- [x] T035 Vor dem Test den Build-Zaehler erneut einmal erhoehen, dann
  `dotnet test MicroCalc.sln --configuration Release --no-build` ausfuehren.
  **Nachweis**: volle Testsuite gruen; keine weitere Zaehlererhoehung.
- [x] T036 Den Smoke mit `dotnet run --no-build --configuration Release
  --project src/MicroCalc.Tui/MicroCalc.Tui.csproj -- --smoke` ausfuehren und
  Exitcode 0 sowie exakt `SMOKE_OK` verlangen.
- [x] T037 Homogenitaet, Agent-Secret-Scan, gitleaks, PSScriptAnalyzer,
  Shell-Syntax, Dokumentations-Impact, Statistik-Check und beide Matrix-
  Validatoren jeweils einmal ausfuehren. **Grenze**: materieller Fund blockiert.
- [x] T038 `docs/project-statistics.config.json` und daraus
  `docs/project-statistics.md` fuer Feature 004 aktualisieren; Produktions- und
  Testzeilen bleiben als unveraendert ausgewiesen, Diagramme und Chronologie
  werden mit `render-project-statistics.ps1 -CheckOnly` validiert.
- [x] T039 `.github/workflows/ci.yml` minimal erweitern, sodass Linux und
  Windows den PowerShell-Einstieg und Linux zusaetzlich den Bash-Einstieg gegen
  exakt die 157-Zeilen-Matrix pruefen; bestehende Produktjobs bleiben erhalten.
- [x] T040 Alle 20 RLSE-GATEs, FR-001..018, CR-001..016, SC-001..008 sowie
  jeden in T004 als relevant ermittelten Pruefpunkt aller 13 Presets in
  `specs/004-rl-se-self-assessment/evidence/evidence-index.md` auf konkrete
  Nachweise oder begruendete `N/A`-Zeilen mit Trigger abbilden. **Nachweis**:
  keine Anforderungs- oder Preset-ID fehlt, keine Delivery-Tatsache wird
  vorweggenommen.

## Phase 7: Exact-Head Delivery und MergeAndSync / Delivery and MergeAndSync

- [x] T041 Run-State, Stop-Status, aktuelle Autoritaet, `gh auth status`,
  Remote, Basis und Arbeitsbaum pruefen; Version auf
  `1.4.<prospektiver Commitcount>.<erreichter Build>` ausrichten.
- [x] T042 Jeden beabsichtigten Pfad einzeln mit
  `validate-autonomous-delivery-set.ps1`, `git diff --check` und verbotenen
  Pfadpruefungen validieren; nur den exakten Satz stagen.
- [x] T043 Einen fokussierten Conventional Commit mit exakt einem Copilot-
  Co-author-Trailer erstellen und Commitcount, Version, Pfade und Trailer
  sofort read-only pruefen.
- [x] T044 Autoritaet und Delivery-Satz erneut pruefen, Branch ohne Force-Push
  pushen und Remote-Head an lokalen Exact Head binden.
- [x] T045 Genau einen PR nach `main` mit
  `docs/PR_TEXT_RL_SE_SELF_ASSESSMENT.md` eroeffnen; PR-Nummer, URL und
  `headRefOid` festhalten.
- [ ] T046 CI auf unveraendertem PR-Head bis Linux-/Windows-Produkt- und
  Matrixjobs gruen laufen lassen; konkrete Logs, Plattformen, Exitcodes und
  unveraenderliche URLs binden.
- [ ] T047 Alle PR-Reviews und Threads bis null actionable findings, null
  Changes Requested und unveraendertem Head konvergieren. Jeder neuer Commit
  invalidiert die betroffenen Exact-Head-Nachweise.
- [ ] T048 `/tmp/tinycalc-004-rlse/gates/premerge.json` als temporaere
  Schema-2.0-PreMerge-Evidenz mit exakt einer `Primary`-Zeile je
  RLSE-GATE-001..020 fuer den reviewten Head erstellen und mit
  `validate-autonomous-gate-evidence.ps1` pruefen.
- [ ] T049 Unmittelbar vor dem Merge Autoritaet, PR-Head, Checks, Reviews und
  formale Policy pruefen; normal mergen, oder `--admin` nur wenn ausschliesslich
  eine formale Regel verbleibt. Merge-Subject ist
  `docs: assess RL-SE checklist compliance`; der Merge-Body enthaelt exakt den
  Copilot-Trailer. Provider-Merge-SHA, Eltern und Trailer sofort read-only
  pruefen.
- [ ] T050 Lokal auf `main` wechseln und ausschliesslich per
  `git pull --ff-only` auf den Provider-Merge synchronisieren. Den akzeptierten
  PreMerge-Snapshot fuer den vorbenannten evidence-only Closeout bewahren;
  keinen GSDB-Lauf starten.

## Phase 8: Kausaler Closeout und finaler Zustand / Causal Closeout and Final State

- [ ] T051 Vom synchronisierten `main` den einzigen vorbenannten Branch
  `codex/004-rl-se-self-assessment-closeout` erzeugen, den akzeptierten
  PreMerge-Snapshot unveraendert als
  `specs/004-rl-se-self-assessment/evidence/accepted-premerge.json` und die
  gueltige Schema-2.0-PostMerge-Evidenz als
  `specs/004-rl-se-self-assessment/evidence/postmerge.json` mit
  `acceptedPreMergeSha256`, echtem Merge-Commit und leerem Produktdelta
  getrackt ablegen und validieren.
- [ ] T052 Das Lastenheft mit dem vorhandenen macOS/Linux-Bash-Skript exakt zu
  `requirements/intakes/active/Lastenheft_RL-SE-Checklist-Selbstpruefung.004-rl-se-self-assessment.md`
  umbenennen, danach genau `speckit-intake-series-update` fuer
  `requirements/intakes/series/tinycalc-delivery/manifest.json` kausal
  ausfuehren und `speckit-intake-series-status` read-only pruefen. **Grenze**:
  GSDB wird nur als naechster berechtigter Intake ausgewiesen, nicht gestartet.
- [ ] T053 Statistik, Run-/Delivery-Evidenz und alle Closeout-Pfade vorab
  vollstaendig abschliessen, den exakten Closeout-Satz validieren und genau
  einen Closeout-Commit mit exakt einem Copilot-Trailer erstellen. Nach dessen
  Provider-Merge sind keine getrackten Writes mehr erlaubt.
- [ ] T054 Closeout-Branch pushen, genau einen evidence-only PR eroeffnen,
  Checks/Reviews konvergieren und mit Subject
  `chore: close Feature 004 delivery` mergen; `--admin` bleibt formal-only.
  Provider-Merge-SHA, Eltern, Trailer und lokales/remote `main` werden sofort
  read-only geprueft und nur in
  `.specify/runtime/autonomous-routing/faae97c9-e61b-480e-b6dd-24b8121868d0/closeout-provider-evidence.json`
  abgelegt.
- [ ] T055 Final Delivery-Satz, PreMerge/PostMerge-Kausalitaet, Matrix 157/157,
  Assurance-Status/Review, beide PR-Merges, Lastenheft-Rename, Serienstatus,
  Branchbereinigung und Fast-Forward-Sync read-only pruefen. Erst dann den
  ignorierten Run-State auf `Completed` setzen. **Endzustand**: RL-SE vollstaendig
  MergeAndSync; erst danach darf ein gesonderter GSDB-Lauf beginnen.

## Abhaengigkeiten / Dependencies

```text
Gate-Freeze
  -> RED-Vertrag -> Validator -> 157-Zeilen-GREEN
  -> fachliche Anwendbarkeit + Assurance-Status/Review
  -> priorisierte Folgearbeit ohne Haertung
  -> Regression + Linux/Windows-CI
  -> Exact-Head-PR + PreMerge -> MergeAndSync
  -> einzelner kausaler Closeout + PostMerge
  -> finaler read-only Zustand -> GSDB erst danach
```

Die drei User Stories sind fachlich einzeln testbar, werden aber wegen der
gemeinsamen kanonischen Matrix und der vom Nutzer verlangten seriellen
Kampagne in der Reihenfolge P1, P2, P3 ausgefuehrt.

## Gate-Abdeckung / Gate Coverage

| Gate | Primaere Aufgaben / Primary tasks |
|---|---|
| RLSE-GATE-001..002 | T001-T004, T041, T055 |
| RLSE-GATE-003..004 | T006-T018, T024-T025 |
| RLSE-GATE-005 | T021-T023 |
| RLSE-GATE-006..010 | T019-T020, T030, T033 |
| RLSE-GATE-011 | T024-T026, T029-T031 |
| RLSE-GATE-012..013 | T004, T029, T038, T052 |
| RLSE-GATE-014..016 | T005, T017, T033-T042 |
| RLSE-GATE-017..018 | T045-T048 |
| RLSE-GATE-019 | T049-T054 |
| RLSE-GATE-020 | T050-T055 |
