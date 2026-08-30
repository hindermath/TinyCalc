# Plan-Review-Checkliste / Plan Review Checklist: Terminal.Gui-2.x-Migration

**Zweck / Purpose**: Formales autonomes Review der Vollständigkeit, Klarheit,
Konsistenz und Messbarkeit von `plan.md` und allen Planungs-Sidecars vor der
Task-Erzeugung. / Formal autonomous review of plan and sidecar completeness,
clarity, consistency, and measurability before task generation.
**Erstellt / Created**: 2026-08-30
**Feature / Feature**: [spec.md](../spec.md)
**Plan / Plan**: [plan.md](../plan.md)
**Tiefe / Depth**: Formales blockierendes Review-Gate / Formal blocking review gate
**Akteur / Actor**: Autonomer Plan-Reviewer vor `/speckit.tasks` / Autonomous plan reviewer before `/speckit.tasks`
**Ergebnis / Result**: `Pass` nach vollständiger Remediation / `Pass` after complete remediation

**Hinweis / Note**: Diese Checkliste prüft die geschriebenen Anforderungen und
Evidenzverträge, nicht die noch nicht vorhandene Implementierung. / This
checklist reviews written requirements and evidence contracts, not the
not-yet-existing implementation.

## Verbindliche Eingaben und Scope / Binding Inputs and Scope

- [x] CHK001 Sind Run-ID, Branch, akzeptierter Intake, `Ready`-Review und alle
  sechs gebundenen Hashes vollständig und widerspruchsfrei benannt? / Are run,
  branch, intake, Ready review, and all six hashes complete and consistent?
  `[Completeness, Plan §Summary, Run State]` — **PASS**: Run-State-Validator
  besteht; alle sechs aktuellen SHA-256 stimmen mit den akzeptierten Werten.
- [x] CHK002 Bleibt der Produktänderungsumfang exakt auf
  `MicroCalc.Tui.csproj` und `Program.cs` begrenzt? / Is product scope limited
  exactly to those two TUI files? `[Consistency, Spec §Scope, Plan §Structure]`
  — **PASS**: Plan, Delivery-Set und Gate `TG-GATE-015/-039` schließen Core,
  Testquellen und weitere Produktpfade aus.
- [x] CHK003 Sind Core-Verhalten, Dateiformat, bestehende Testquellen, Rename,
  neue Funktionen und weitere Intakes als Nicht-Ziele vollständig erhalten? /
  Are all exclusions preserved? `[Coverage, Spec FR-008/-009, Plan §Structure]`
  — **PASS**: Keine Planung erweitert den akzeptierten Scope.
- [x] CHK004 Ist die FakeDriver-Arbeit eindeutig als separater Follow-up mit
  Owner, Evidenzpfad und Wiedervorlage begrenzt? / Is FakeDriver clearly bounded
  as a separate follow-up? `[Clarity, Spec R-TG-TC-06, Plan §Risks]` —
  **PASS**: Owner ist Repository-Maintainer; Trigger ist nach Feature 003 und
  vor der nächsten TUI-Funktionsänderung; kein automatischer Start.
- [x] CHK005 Ist die Reihenfolge Feature 003 vor Feature 004 einschließlich
  sicherem No-next-feature-Abschluss eindeutig? / Is ordering and safe
  no-next-feature closeout explicit? `[Consistency, Spec §Ordering, Gate
  TG-GATE-045]` — **PASS**: Statusprüfung ist read-only; kein Nachfolger wird
  gestartet.

## Abhängigkeit und technische Machbarkeit / Dependency and Technical Feasibility

- [x] CHK006 Ist die exakte stabile Terminal.Gui-Version anhand einer aktuellen
  autoritativen Quelle festgelegt und gegen Vorabversionen abgegrenzt? / Is the
  exact stable version selected from a current authoritative source and
  distinguished from prereleases? `[Dependency, Research R-01]` — **PASS**:
  NuGet Gallery am 2026-08-30: `2.4.17` stabil; `2.4.18-develop.*` prerelease.
- [x] CHK007 Ist die `.NET 10`-Kompatibilität als enthaltenes `net10.0`-Target
  und nicht nur als berechnete Kompatibilität belegt? / Is .NET 10 compatibility
  evidenced as an included target? `[Clarity, Research R-01, Dependency Plan]`
  — **PASS**: NuGet-Metadaten nennen `net10.0`; erneute Prüfung vor Restore und
  Release ist verpflichtend.
- [x] CHK008 Sind Paketquelle, exaktes Pinning, vollständiger transitiver Graph,
  Vulnerability-JSON und Maintenance-Posture messbar geplant? / Are source,
  pinning, graph, audit, and maintenance evidence measurable? `[Completeness,
  Dependency Plan, TG-GATE-003/-004]` — **PASS**: Befehle, Pfade, Blocker und
  mutable Revalidation-Trigger sind benannt.
- [x] CHK009 Ist der instanzbasierte Lifecycle mit Create, Init, Run,
  RequestStop, eindeutiger Ownership und Dispose vollständig und offiziell
  machbar belegt? / Is the instance lifecycle completely and authoritatively
  feasible? `[Feasibility, Research R-02, Architecture §Runtime]` — **PASS**:
  Offizielle v2-Dokumentation deckt jede geplante Lifecycle-Stufe ab.
- [x] CHK010 Sind verschachtelte Dialog-Sessions, Rückkehrziel und
  Creator-Owned-Dispose widerspruchsfrei spezifiziert? / Are nested sessions,
  return target, and disposal ownership consistent? `[Consistency, Data Model
  §AppSession/OwnedRunnable]` — **PASS**: Eine App-Instanz, Session-Stack und
  eindeutige Owner sind durchgängig festgelegt.
- [x] CHK011 Sind `.WithCtrl`, KeyDown/KeyBindings, Handled-Vertrag und
  `Button.Accepting` anhand offizieller v2-APIs realistisch geplant? / Are the
  keyboard and button APIs feasible from official v2 documentation?
  `[Feasibility, Research R-03, Plan §API Inventory]` — **PASS**: Alle
  Migrationsflächen sind belegt; die konkrete Wahl bleibt compiler- und
  verhaltensgetrieben innerhalb von `Program.cs`.

## Umsetzungsschnitt, Regression und Coverage / Slice, Regression, and Coverage

- [x] CHK012 Ist genau ein beobachtbarer Rot-Grün-Aufräumen-Ablauf mit getrennt
  erwarteten Fehlern beschrieben? / Is one observable red-green-refactor flow
  defined with bounded expected failures? `[Measurability, Coverage Plan
  §RGR, TG-GATE-010]` — **PASS**: Source-contract Red, dependency-only compile
  Red, Green vertical slice und Regression sind getrennt.
- [x] CHK013 Ist der repräsentative vertikale Schnitt von Smoke-Bypass über
  Create/Init/Root/Run/Quit bis Dispose vollständig? / Is the vertical slice
  complete end-to-end? `[Completeness, Plan §Vertical Slice]` — **PASS**:
  Release-Compile, `SMOKE_OK` und manueller Start/Quit bilden das Green-Gate.
- [x] CHK014 Ist ausgeschlossen, dass unerwartete Core-/Testfehler als erwartete
  Rotphase gruppiert werden? / Are unexpected Core/test failures excluded from
  expected red evidence? `[Safety, Plan §RGR]` — **PASS**: Nur lokal benannte
  Source-/Dependency-Fehler sind als erwartet zulässig.
- [x] CHK015 Ist Changed-Code-Coverage mit reproduzierbarem Nenner/Zähler,
  mindestens 70 Prozent und Ziel 80 Prozent objektiv messbar? / Is changed-code
  coverage objectively measurable? `[Acceptance Criteria, Coverage Plan
  §Changed-code]` — **PASS**: Diff-Basis, Ausschlüsse, Cobertura-Schnitt,
  Toolversion und Berichtspfad sind festgelegt.
- [x] CHK016 Deckt die Coverage-Planung Tests, Smoke und beide manuellen
  TUI-Sitzungen als getrennte Artefakte ab? / Does coverage include tests,
  smoke, and both manual sessions separately? `[Completeness, Coverage Plan
  §Collection]` — **PASS**: `manual-menu.coverage` und
  `manual-ctrlq.coverage` sind beide zwingende Merge-Eingaben.
- [x] CHK017 Sind vollständige bestehende Tests, unveränderte Testquellen und
  headless Smoke mit Exitcode 0, genau einem `SMOKE_OK` und 30-Sekunden-Grenze
  konsistent? / Are regression and smoke criteria consistent? `[Consistency,
  Spec FR-005/-006, TG-GATE-008/-009]` — **PASS**: Befehle, Token und
  Blockierbedingungen stimmen überein.

## Tastatur und Barrierefreiheit / Keyboard and Accessibility

- [x] CHK018 Sind genau 13 bindende Eingaben vollständig und ohne Doppelzählung
  definiert? / Are exactly 13 binding inputs fully defined without duplicate
  counting? `[Completeness, Accessibility Plan §13-key Matrix]` — **PASS**:
  Zwölf Navigationseingaben plus `Ctrl+Q` sind einzeln nummeriert.
- [x] CHK019 Sind Menü-Quit und `Ctrl+Q` in zwei ausführbaren Sitzungen statt in
  einer unmöglichen Sequenz geplant? / Are the two quit paths planned in two
  executable sessions? `[Consistency, Accessibility Plan §Manual Sequences,
  TG-GATE-012]` — **PASS nach Remediation**: Sitzung 1 endet per Menü, Sitzung 2
  prüft den 13. Input und endet per `Ctrl+Q`.
- [x] CHK020 Sind Fokusreihenfolge, sichtbarer Fokus, No Keyboard Trap,
  Terminalwiederherstellung und fehlender interner Traceback messbar? / Are
  focus, no-trap, restoration, and safe errors measurable? `[Acceptance
  Criteria, Accessibility Plan §WCAG]` — **PASS**: Ausgangs-/Zielzustand und
  Textbeleg sind je Sitzung vorgeschrieben.
- [x] CHK021 Sind WCAG 2.2 AA 1.4.1, 2.1.1, 2.1.2, 2.4.3 und 2.4.7 vollständig
  zugeordnet und andere Kriterien begründet N/A? / Are applicable WCAG criteria
  mapped and other items justified N/A? `[Coverage, CR-002, Accessibility
  Plan]` — **PASS**: Status, Evidenz und Trigger sind vorhanden.
- [x] CHK022 Sind DE-first/EN-second, CEFR B2, semantische Struktur und
  text-first-Ausgabe als Lieferkriterien definiert? / Are bilingual and
  text-first criteria explicit? `[Completeness, CR-014, TG-GATE-014]` —
  **PASS**: Plan und Sidecars verwenden lineare bilinguale Evidenz; JSON erhält
  einen bilingualen Begleitpfad.

## Sicherheit, Architektur und Lieferkette / Security, Architecture, and Supply Chain

- [x] CHK023 Sind NIST SSDF, CWE Top 25 und C#/.NET Secure Coding zwingend
  anwendbar und mit Owner, Reviewer und Evidenzpfad versehen? / Are mandatory
  security standards owned and evidenced? `[Completeness, Plan §Security
  Standards, TG-GATE-017]` — **PASS**: Kein Pflichtstandard ist N/A.
- [x] CHK024 Sind Tastatur- und NuGet-Grenzen mit STRIDE/CIA, CAPEC-153 und
  CAPEC-538 sowie Restrisiken vollständig beschrieben? / Are trust boundaries
  fully threat-modelled? `[Coverage, Security Plan §STRIDE, TG-GATE-016]` —
  **PASS**: Manipulation, DoS, Disclosure, Privileg-/Repudiation-N/A und
  Mitigationen sind benannt.
- [x] CHK025 Sind sichere Ressourcenbehandlung, geschlossene Eingabeabbildung,
  Fehler-Disclosure und keine neue Datei-/Netzwerk-/Deserialisierungsfläche
  eindeutig? / Are C# security boundaries clear? `[Clarity, Security Plan
  §Secure Implementation]` — **PASS**: Fail-safe- und Least-Privilege-Grenzen
  sind prüfbar.
- [x] CHK026 Sind SBOM, SLSA v1.2, OpenSSF Scorecard, Dependency Audit, SAMM und
  Security Quality Scenarios vollständig geplant? / Are supply-chain and
  maturity artefacts complete? `[Completeness, Supply-chain Plan,
  TG-GATE-018..021]` — **PASS**: Exakte Tools, Pfade, Heads und ehrliche
  Provenienzgrenzen sind festgelegt.
- [x] CHK027 Besitzen ASVS, VEX, AI-SBOM, Zero Trust, BSI C3A/C5, Regulatorik,
  ADR/S-ADR, arc42, DocFX, Script-/Agent-/Parallel-Parität und
  Dependency-Automation jeweils Begründung und Trigger? / Does every N/A have
  rationale and trigger? `[Completeness, TG-GATE-022..034/-046]` — **PASS**:
  JSON-Prüfung meldet keine leere N/A-Begründung oder Wiedervorlage.

## Plattformen, Version, Statistik und Delivery / Platforms, Version, Statistics, and Delivery

- [x] CHK028 Ist macOS als lokaler Build/Test/Smoke- und manueller TUI-Beleg
  eindeutig von Linux-/Windows-CI getrennt? / Is macOS proof distinct from CI
  platforms? `[Clarity, Plan §Technical Context]` — **PASS**: Plattformtoken
  und Evidenzrollen sind getrennt.
- [x] CHK029 Fordert Linux echte Restore-/Build-/Test-/Smoke-Befehle und erkennt
  den aktuellen Ubuntu-Job ohne Smoke nur als Teilbeleg? / Does Linux require
  all product commands and treat current CI as partial? `[Evidence Integrity,
  Research R-06, TG-GATE-037]` — **PASS nach Remediation**: Fehlender Smoke
  blockiert; grüner Jobname reicht nicht.
- [x] CHK030 Fordert Windows einen echten Produktjob mit denselben vier
  Befehlen und verwirft den Homogeneity-Job als Ersatz? / Does Windows require
  real product commands? `[Evidence Integrity, Research R-06, TG-GATE-038]` —
  **PASS**: Fehlender Job blockiert; nötiger Workflow-Scope erfordert vorherige
  Autorität.
- [x] CHK031 Ist die Versionsformel `Major.3.Patch.Build` mit drei identischen
  Feldern, prospektivem Commitcount und serialisiertem Counter vor jedem
  Build/Test vollständig? / Is version discipline complete? `[Measurability,
  Delivery Plan §Versioning, TG-GATE-035]` — **PASS**: Trigger und Befehlsbasis
  sind eindeutig.
- [x] CHK032 Sind Statistikprofil, Feature-Zeitraum, Produktions-/Test-/Doku-
  Zeilen, 80/125-Baselines, 7,8 Stunden und zugängliche ASCII-Trends vollständig
  gefordert? / Are statistics requirements complete? `[Completeness,
  TG-GATE-036]` — **PASS**: Konfigurations- und Ledger-Pfade sind benannt.
- [x] CHK033 Ist der Delivery-Set-Vertrag exact-path, indexschonend und gegen
  Core-, Test-, Script-, Agent-, `_site`- und Nachfolgerdiff abgesichert? / Is
  delivery-set integrity exact and non-mutating? `[Safety, Delivery Plan
  §Intended Delivery Set, TG-GATE-015/-039]` — **PASS**: Validator,
  `git diff --exit-code`, `--name-status` und `diff --check` sind gebunden.
- [x] CHK034 Sind Schema-2.0-PreMerge/-PostMerge, Requirement-Hash, genau eine
  Primary-Zeile pro Gate, temporärer Exact-Head und Merge-Commit-Bindung
  vollständig? / Is schema-2.0 lifecycle evidence complete? `[Completeness,
  Delivery Plan §Schema 2.0, TG-GATE-040]` — **PASS**: Template und installierter
  Validator sind exakt benannt; Schema 1.0 bleibt audit-only.
- [x] CHK035 Ist Review-Konvergenz ohne offene Threads, Changes Requested,
  fehlende Reviewer oder veralteten Head objektiv definiert? / Is review
  convergence objective? `[Acceptance Criteria, Delivery Plan §PR Review,
  TG-GATE-041]` — **PASS**: GitHub-CLI-/GraphQL-Evidenz und Revalidation-Trigger
  sind festgelegt.
- [x] CHK036 Ist `MergeAndSync` einschließlich Fast-forward-Sync vollständig,
  ohne gespeicherten Modus als Dauerrecht zu behandeln? / Is MergeAndSync
  complete without treating stored mode as continuing authority? `[Authority,
  Delivery Plan §MergeAndSync, TG-GATE-042/-043]` — **PASS**: Autorität wird an
  jeder Remote-Grenze erneut geprüft.
- [x] CHK037 Ist der enge Admin-Bypass auf konkreten PR und konkrete Policy
  begrenzt und mit Autorisierer, Grund, Umfang und Restrisiko belegt? / Is the
  narrow bypass concrete and fully evidenced? `[Authority, TG-GATE-047]` —
  **PASS nach Remediation**: Operation/Receipt nennen Thorsten; Bypass ersetzt
  kein Fach-, Security-, A11Y-, Plattform-, Review- oder Head-Gate.
- [x] CHK038 Sind Lastenheft-Rename, PostMerge-Reihenfolge, erneute
  Serienautorität, Archivlinie und read-only Serienstatus vollständig? / Is
  post-merge intake handling complete? `[Completeness, Delivery Plan §Causal
  Closeout, TG-GATE-044/-045]` — **PASS nach finaler Angleichung**: Auf
  macOS/Linux ist das vorhandene Bash-Skript constitution-konform gebunden;
  exakter Zielname und Reihenfolge sind benannt. / **PASS after final
  alignment**: the existing Bash script is constitution-compliant on
  macOS/Linux; exact target name and order are specified.
- [x] CHK039 Ist höchstens ein kausaler, single-commit-fähiger Closeout exakt
  vorbenannt und ein leerer oder dritter PR ausgeschlossen? / Is one exact
  causal closeout bounded? `[Safety, Plan §Phase 5]` — **PASS**:
  `codex/003-terminalgui-migration-closeout`; kein leerer/weiterer Pfad.
- [x] CHK040 Ist `Completed` nur nach vollständigen Aufgaben, Gates, Review,
  Merge, Sync, PostMerge, Intake-Follow-up und finaler Validierung erlaubt? /
  Is Completed restricted to terminal evidence? `[Acceptance Criteria,
  Delivery Evidence Contract §Completion]` — **PASS**: Jeder fehlende Beleg
  ergibt `Blocked`/`Failed`, nie `Completed`.

## Befunde und Konvergenz / Findings and Convergence

| ID | Schwere / Severity | Ursprünglicher Befund / Original finding | Behandlung und Evidenz / Disposition and evidence | Status |
|---|---|---|---|---|
| PRF-001 | High | Der aktuelle Linux-Job wurde als vollständiger Beleg beschrieben, obwohl `ci.yml` keinen Smoke ausführt; Windows besitzt keinen Produktjob. | `plan.md`, `research.md`, `quickstart.md` und `delivery-plan.md` behandeln Linux nun als Teilbeleg und beide Vollgates als blockierend; Workflow-Scope benötigt vor Änderung Autorität. | Fixed |
| PRF-002 | High | Enge Admin-Bypass-Autorität besaß keinen eigenständigen maschinenlesbaren Gate-Vertrag und keine konkrete Policy-/PR-Grenze. | `TG-GATE-047`, Delivery-Plan und Run-Evidence binden Thorsten, konkreten PR/Policy, Grund, Umfang, Restrisiko und das Verbot technischer Substitution. | Fixed |
| PRF-003 | Medium | Die 13-Key-Sequenz wollte `Ctrl+Q` prüfen und danach im selben Lauf Menü-Quit ausführen; Coverage hatte nur einen manuellen Prozess. | Accessibility-, Coverage- und Quickstart-Sidecar verwenden zwei Sitzungen und zwei Coverage-Dateien. | Fixed |
| PRF-004 | Medium | Der autonome Evidenz-Sidecar war auf Specify/Preflight veraltet und nicht bilingual. | Sidecar auf PlanReview aktualisiert, DE-first/EN-second und mit aktuellem nächsten sicheren Schritt. | Fixed |
| PRF-005 | Medium | Paket- und API-Auswahl war korrekt, aber aktuelle stabile/prerelease-, `net10.0`- und konkrete v2-API-Evidenz war zu knapp. | Research- und Dependency-Sidecar nennen Abrufdatum, NuGet-Status, `net10.0`, Lifecycle-, Keyboard- und Button-APIs plus Revalidation. | Fixed |

**Offene Befunde / Open findings**: Critical `0`, High `0`, Medium `0`, Low `0`.
**Akzeptierte neue Restrisiken / Newly accepted residual risks**: `0`.
Die bindende FakeDriver-Folgearbeit und fehlende Plattforminfrastruktur sind
keine still akzeptierten neuen Risiken: FakeDriver bleibt akzeptierter Intake-
Follow-up; fehlende echte Linux-/Windows-Evidenz blockiert die spätere Delivery.
/ *FakeDriver remains the accepted intake follow-up, while missing real Linux
or Windows evidence blocks later delivery rather than becoming silent risk.*

## Abschluss / Completion

Alle 40 Anforderungsqualitätsprüfungen bestehen nach Remediation. Der
Plan-Review-Payload ist vollständig; die Implementierungs-Gates sind geplant,
nicht vorzeitig als ausgeführt behauptet. `/speckit.tasks` darf erst nach einem
gültigen strukturierten `plan-review`-Phasenresultat beginnen. / *All 40
requirements-quality checks pass after remediation. Implementation gates are
planned, not claimed as executed. Tasks may begin only after a valid structured
plan-review phase result.*
