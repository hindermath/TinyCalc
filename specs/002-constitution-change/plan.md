# Implementierungsplan: Constitution-Abgleich / Implementation Plan: Constitution Alignment

**Branch / Branch**: `002-constitution-change` | **Datum / Date**: 2026-08-29 | **Spezifikation / Specification**: [spec.md](spec.md)
**Verbindliche Eingabe / Binding input**: `requirements/intakes/active/Lastenheft_Constitution_Change.002-constitution-change.md`
**Autonomer Lauf / Autonomous run**: `d42bfa06-0a67-492e-968d-80309788b383`
**Liefermodus / Delivery mode**: `MergeAndSync`; jede spätere Git-, Remote-,
Review-, Bypass- oder Merge-Aktion benötigt an ihrer Grenze erneut passende
aktuelle Autorität. Diese Planungsphase führt keine solche Aktion aus. / Every
later Git, remote, review, bypass, or merge action needs matching current
authority at its boundary. This planning phase performs no such action.

## Zusammenfassung / Summary

Feature 002 ergänzt die TinyCalc-Governance um den klar abgegrenzten Abschnitt
„Didaktische und sprachliche Klarheit / Pedagogical and Linguistic Clarity“.
Security-First bleibt Prinzip I. Die Änderung macht den Lernweg Test Driven
Development (TDD) mit Rot, Grün und Aufräumen für spätere Funktionen und
Fehlerkorrekturen sichtbar. Sie hält Constitution, Memory-Spiegel, fünf
Agentenflächen und betroffene Vorlagen semantisch synchron. Die bereits aktive
Schranke für öffentliche XML-Dokumentation wird geprüft, nicht neu gebaut.

*Feature 002 adds the clearly scoped TinyCalc governance section “Pedagogical
and Linguistic Clarity”. Security-First remains Principle I. The change makes
the red, green, and refactor learning path of Test Driven Development (TDD)
visible for later features and fixes. It keeps the constitution, memory mirror,
five agent surfaces, and all four constitution-dependent Spec Kit templates
semantically aligned. The existing
public XML documentation gate is verified rather than rebuilt.*

Die Umsetzung verändert keine Tabellenkalkulationsfunktion, Produktlogik,
Laufzeitgrenze, Abhängigkeit, Serialisierung, TUI, Workflow-Datei, Skript,
Cmdlet oder Manpage. Der spätere Intake zur vollständigen Nacharbeit vorhandener
Inline-Kommentare bleibt an seinem Serienplatz und wird nicht gestartet.

*Implementation changes no spreadsheet feature, product logic, runtime
boundary, dependency, serialization, TUI, workflow file, script, cmdlet, or man
page. The later intake for full remediation of existing inline comments keeps
its series position and is not started.*

## Verbindliche Basis / Binding Baseline

Vor jeder späteren semantischen Phase werden diese normalisierten SHA-256-Werte
erneut geprüft. Eine Abweichung stoppt die Arbeit und verlangt Revalidierung.

*These normalized SHA-256 values are checked again before every later semantic
phase. Any mismatch stops work and requires revalidation.*

| Artefakt / Artefact | Akzeptierter SHA-256 / Accepted SHA-256 |
|---|---|
| `requirements/intakes/active/Lastenheft_Constitution_Change.002-constitution-change.md` | `04c4e1ba93d626463829a07f33b5591a6417b6aeaf89e805b637ab1bf5c26a0a` |
| `requirements/intakes/series/tinycalc-delivery/intake-review-result.json` | `6f33209dedb2c51525f4443e44e1877466bb096bc030a748484936b96299559b` |
| `requirements/intakes/series/tinycalc-delivery/intake-review-request.json` | `7020241199793ab1d94575a7d1f804b27fd916c7cde8597adb22ee654876d042` |
| `requirements/intakes/series/tinycalc-delivery/manifest.json` | `ef266cf99627d10a17282db966826fff26a0705ec1afca355eeb7c7079a25e72` |
| `specs/002-constitution-change/spec.md` | `1f8196fab5ff0a2d0aba6fd59b58d6fbb24edca48dadc80f68437273f016ca65` |
| `specs/002-constitution-change/checklists/requirements.md` | `19e6a79a937f8a921602398813468aaf32e35a58f6325f6fbb83f1b014dea2ca` |

Die Spezifikation enthält genau 16 Intake-Zeilen. Nur `IR-004`, `IR-012`,
`IR-013` und `IR-015` erzeugen Arbeit. `AlreadySatisfied`, `N/A` und `FollowUp`
werden nicht als verdeckte Implementierungsaufgaben behandelt.

*The specification contains exactly 16 intake rows. Only `IR-004`, `IR-012`,
`IR-013`, and `IR-015` create work. `AlreadySatisfied`, `N/A`, and `FollowUp`
are not treated as hidden implementation tasks.*

## Technischer Kontext / Technical Context

| Feld / Field | Entscheidung / Decision |
|---|---|
| Sprache und Version / Language and version | .NET 10 mit C# 14 als Standard-Sprachversion des `net10.0` SDK; C# steht auf der MSL-Erlaubnisliste. / .NET 10 with C# 14 as the default language version of the `net10.0` SDK; C# is on the MSL allow-list. |
| Hauptabhängigkeiten / Primary dependencies | `Terminal.Gui` 1.19.0 für die TUI; xUnit, Microsoft.NET.Test.Sdk und Coverlet für Tests. Keine Abhängigkeit wird in diesem Feature geändert. / `Terminal.Gui` 1.19.0 for the TUI; xUnit, Microsoft.NET.Test.Sdk, and Coverlet for tests. This feature changes no dependency. |
| Speicherung / Storage | JSON-Dateien des bestehenden `.mcalc.json`-Formats und Dateisystemzugriffe bleiben unverändert; für die Governance-Änderung `N/A`. / Existing `.mcalc.json` files and file-system access remain unchanged; `N/A` for this governance change. |
| Testsystem / Testing | xUnit-Suiten in `tests/MicroCalc.Core.Tests` und `tests/MicroCalc.Tui.Tests`, Release-Build, TUI-Smoke sowie textbasierte Governance-Prüfungen. / xUnit suites, Release build, TUI smoke, and text-based governance checks. |
| Zielplattform / Target platform | TinyCalc bleibt plattformübergreifend auf .NET 10; lokale Planung auf macOS, bestehende CI-Evidenz auf Ubuntu sowie Homogenitätsprüfung auf Ubuntu, macOS und Windows. / TinyCalc remains cross-platform on .NET 10; local planning uses macOS, existing CI uses Ubuntu, and homogeneity runs on Ubuntu, macOS, and Windows. |
| Projekttyp / Project type | Mehrprojektige C#-Lösung mit Core-Bibliothek und Terminal.Gui-TUI; dieses Feature ist reine Governance- und Dokumentationsarbeit. / Multi-project C# solution with a core library and Terminal.Gui TUI; this feature is governance and documentation work only. |
| Leistungsziel / Performance goal | `N/A`: keine Laufzeit- oder Benutzerinteraktion ändert sich. / `N/A`: no runtime or user interaction changes. |
| Einschränkungen / Constraints | DE zuerst, EN danach, CEFR B2, text-first, WCAG 2.2 AA; Security-First bleibt Prinzip I; bytegleiche Constitution-Spiegel; keine spätere Intake-Ausführung. / German first, English second, CEFR B2, text-first, WCAG 2.2 AA; Security-First remains Principle I; byte-identical constitution mirrors; no later intake execution. |
| Umfang / Scale | Zwei Constitution-Dateien, fünf Agentenflächen, vier Projektvorlagen, vier betroffene Spec-Kit-Vorlagen sowie Feature-, Security-, A11Y-, Statistik- und PR-Evidenz. / Two constitution files, five agent surfaces, four project templates, four affected Spec Kit templates, plus feature, security, accessibility, statistics, and PR evidence. |

## Umfang und feste Reihenfolge / Scope and Fixed Order

1. Akzeptierte Hashes und die eindeutige Klassifikation der 16 Intake-Zeilen
   bilden die Eingangsschranke.
2. Der neue TinyCalc-Abschnitt wird unter dem bestehenden Level-2-Addendum
   ergänzt. Die gemeinsame Home-Baseline und Security-First-Prinzip I werden
   nicht umbenannt oder geschwächt.
3. `constitution.md` und `.specify/memory/constitution.md` werden als ein
   bytegleiches Spiegelpaar geschrieben.
4. Die Constitution-Version wird wegen des neuen Abschnitts von `1.16.0` auf
   `1.17.0` erhöht, `Last Amended` auf das Lieferdatum gesetzt und der Sync
   Impact Report vollständig aktualisiert. Die in der Constitution und allen
   Agentenflächen dokumentierte Acht-Preset-Matrix wird an die unveränderte
   ausführbare Quelle angeglichen.
5. Die fünf Agentenflächen und betroffenen Vorlagen werden als ein
   serialisierter Paritätssatz geändert und danach gemeinsam geprüft.
6. Die bestehende CS1591-Schranke wird zuerst statisch und danach durch einen
   Release-Build geprüft. Eine einmalige öffentliche API-Inventur prüft darüber
   hinaus anwendbare `<param>`-, `<returns>`- und `<exception>`-Elemente, ohne
   eine neue dauerhafte Schranke zu bauen.
7. Security-, A11Y- und Statistikevidenz wird nach den tatsächlichen Triggern
   aktualisiert.
8. Erst nach lokaler Validierung dürfen spätere Delivery-Schritte beginnen.
   Feature 002 startet, entsperrt oder bearbeitet keinen späteren Intake.

*Accepted hashes and the 16 unique classifications form the entry gate. The
TinyCalc section is added inside the existing Level-2 addendum without changing
the shared baseline or Security-First Principle I. Constitution mirrors are
written together, followed by the serialized agent and template parity set.
The existing CS1591 gate is checked rather than duplicated. Security,
accessibility, and statistics evidence follows real triggers. Delivery may
start only after local validation, and feature 002 starts no later intake.*

## Constitution-Prüfung / Constitution Check

**Eingangsgate / Entry gate**: bestanden für die Planung. Die akzeptierten
Artefakte stimmen mit dem Run-State überein, die Checkliste ist vollständig,
und es gibt keinen offenen Klärungsmarker. / Passed for planning. Accepted
artefacts agree with run state, the checklist is complete, and no clarification
marker remains.

| Prüfpunkt / Checkpoint | Status und Planung / Status and plan |
|---|---|
| Branch- und PR-Fluss / Branch and PR flow | `Applicable`. Arbeit bleibt auf `002-constitution-change`. Der spätere PR erhält `docs/PR_TEXT_CONSTITUTION_CHANGE.md`. Diese Phase führt keinen Commit, Push, PR oder Merge aus. Gespeicherter `MergeAndSync`-Status ersetzt keine aktuelle Autorität. / Work stays on the feature branch; later PR evidence has an exact path. No Git or remote action occurs now. |
| .NET 10 und C# 14 / .NET 10 and C# 14 | `Applicable`, bereits aus Registry und `net10.0` belegt. Das SDK wählt C# 14 standardmäßig; kein `LangVersion`-Override und keine Toolchain-Änderung werden geplant. / Already evidenced by the registry and `net10.0`; no override or toolchain change is planned. |
| Architektur und Schichten / Architecture and layers | `N/A` für Änderungen. `MicroCalc.Core` bleibt unabhängig von `Terminal.Gui`; TUI, Engine, Formula, Model und IO ändern sich nicht. Wiedervorlage bei Struktur-, Schnittstellen-, Runtime- oder Deployment-Änderung. / No architecture change; re-evaluate on a structural or runtime trigger. |
| Zweisprachige Dokumentation / Bilingual documentation | `Applicable`. Jede neue oder geänderte lern- oder nutzerseitige Passage steht DE zuerst und EN danach auf CEFR B2. Fachbegriffe werden bei erster Verwendung erklärt. / All affected prose follows DE-first/EN-second CEFR B2 and explains terms on first use. |
| XML-Dokumentation und CS1591 / XML documentation and CS1591 | `Applicable` als Regression. Beide Produktprojekte müssen `GenerateDocumentationFile=true` und `CS1591` in `WarningsAsErrors` behalten. Öffentliche Elemente erhalten nur fachlich anwendbare XML-Tags; lokale Variablen bleiben ausgeschlossen. / Applicable as a regression check; no invented tags for locals. |
| DocFX und HTML-A11Y / DocFX and HTML accessibility | `N/A` für den geplanten Basissatz, weil keine API-Signatur, kein XML-Kommentar, keine DocFX-Navigation und keine API-Präsentation geändert wird. Wenn die CS1591-Prüfung eine echte XML-Lücke erzwingt oder ein anderer Trigger entsteht, werden `docfx docfx.json` und der textorientierte A11Y-Smoke im selben Arbeitsgegenstand verpflichtend. / Not triggered by the baseline change; any real API/XML/DocFX trigger makes both checks mandatory. |
| TDD Rot-Grün-Aufräumen / TDD red-green-refactor | `N/A` für diese reine Governance- und Textänderung: kein Produktverhalten wird geändert. Die neue Regel verlangt für spätere Funktionen und Fehlerkorrekturen beobachtbare rote, grüne und Regressions-/Aufräum-Evidenz. Wiedervorlage bei jeder Logikänderung. / Not applicable to the current text-only implementation; mandatory for later behaviour changes. |
| Testabdeckung / Test coverage | `N/A` als Changed-Code-Gate, da kein Produktionscode geändert wird. Der vorhandene Repo-Vertrag erzwingt derzeit keinen festen Schwellenwert. Falls unerwartet Produktcode nötig wird, wird Coverlet vor dieser Änderung als Gate aktiviert: mindestens 70 %, Ziel 80 %. / No changed production code; if that scope changes, Coverlet uses a 70% minimum and 80% target before implementation continues. |
| NuGet-Aktualität und Pinning / NuGet currency and pinning | `Applicable` als Read-only-Prüfung, Änderung `N/A`. Veraltete oder verwundbare Pakete werden erfasst; dieses Feature ändert keine Version und kein Lockfile. Ein kritischer Fund blockiert die Lieferung und erhält einen getrennt autorisierten Sicherheitsweg. / Read-only assessment only; no package or lock-file change. A critical finding blocks delivery. |
| Serialisierung und Datenkonventionen / Serialization and data conventions | `N/A`. `.mcalc.json`, JSON-Optionen, Zellgrenzen und Pascal-Parität ändern sich nicht. Wiedervorlage bei Model-, IO- oder Dateiformatänderung. / No model, IO, or file-format change. |
| Versionierung / Versioning | `Applicable` erst in der Umsetzung. Vor jedem `dotnet build` oder `dotnet test` werden `Version`, `AssemblyVersion` und `FileVersion` in `Directory.Build.props` gemeinsam nach `Major.Minor.Patch.Build` fortgeschrieben; der gemeinsame Writer wird serialisiert. / Applies during implementation; all three fields move together before every build or test and the writer is serialized. |
| MSL und sichere C#-Entwicklung / MSL and secure C# development | `Applicable`. C# ist speichersicher, ersetzt aber nicht die Prüfung gegen Principle XII. Da kein C# geändert wird, dokumentiert `docs/security/security-checklist.md` die sprachspezifischen Codepunkte als begründetes `N/A`. / C# is memory-safe, but Principle XII still applies; code-specific rows are justified N/A. |
| Sichere Architektur / Secure architecture | `N/A` für neue Maßnahmen. Es entstehen keine Trust Boundary, Berechtigung, Secret-Fläche, Eingabe, Datenfluss- oder Deployment-Änderung. Defense in depth, Least Privilege und fail-safe defaults bleiben unverändert. / No new security architecture measure is triggered. |
| Security-First / Security-first | `Applicable`. Keine Datei aus `.codex/`, keine Logs, History-, SQLite-, Secret- oder Credential-Datei gehört in den Lieferumfang. `scripts/scan-agent-secrets.ps1` und die bestehende CI prüfen den Kandidaten. / Agent state, logs, databases, and credentials stay outside the delivery set. |
| A11Y und Inklusion / Accessibility and inclusion | `Applicable` für Markdown, Agenten-Guidance, Vorlagen und Statistik. WCAG 2.2 AA wird soweit auf statische Dokumente anwendbar geprüft; Status, Abhängigkeiten, Entscheidungen und nächste Schritte bleiben textuell vollständig. / Applies to changed documentation and templates with complete text alternatives. |
| Projektstatistik / Project statistics | `Applicable`. `docs/project-statistics.config.json` erhält einen stabilen Feature-002-Slot mit beobachteten Werten; `docs/project-statistics.md` erhält genau einen chronologisch letzten Ledger-Eintrag und einen neu gerenderten finalen Profil-2-Block. Baselines: 80 und 125 Zeilen/Arbeitstag. / One new ledger entry and refreshed Profile 2 using the binding baselines. |
| Agentenparität / Agent parity | `Applicable`. Alle fünf lokalen Flächen und vier Projektvorlagen werden atomar geprüft. Es ist keine absichtliche Abweichung geplant. / All five local surfaces and four project templates are reviewed atomically; no deviation is planned. |

### Sicherheitsstandards und Evidenz / Security Standards and Evidence

NIST SSDF und CWE Top 25 gelten in jedem Level-2-Lauf. Der Evidence Owner ist
der Repository-Maintainer; der Reviewer wird vor Abschluss im Nachweis benannt.
`Open` ist für diesen Plan nicht erforderlich. / NIST SSDF and CWE Top 25 apply
to every Level-2 run. The repository maintainer owns evidence; the reviewer is
named before closeout. This plan needs no `Open` status.

| Standard oder Evidenz / Standard or evidence | Status | Pfad, Begründung und Wiedervorlage / Path, rationale, and re-evaluation |
|---|---|---|
| NIST SSDF | `Applicable` | `docs/security/security-checklist.md` ordnet Prepare, Protect, Produce und Respond dem Feature zu. Wiedervorlage in Tasks, Umsetzung, Review und Abschluss. / The checklist maps the feature to all SSDF groups; re-evaluate in every later phase. |
| CWE Top 25 | `Applicable` | Review-Linse in `docs/security/security-checklist.md`; keine neue Eingabe-, Code-, Auth-, Krypto- oder IO-Fläche. Wiedervorlage bei Code- oder Buildlogikänderung. / Review lens with no new attack surface; re-evaluate on code or build-logic change. |
| OWASP Cheat Sheets und Proactive Controls | `Applicable` als Review-Hilfe / as review guidance | Verlinkung in `docs/security/security-checklist.md`; strengere .NET-Regeln gehen vor. / Linked from the security checklist; stricter .NET rules prevail. |
| OWASP ASVS | `N/A` | Kein Web-, API-, HTTP- oder Auth-Scope; `docs/security/asvs-verification.md` bleibt unverändert. Wiedervorlage bei entsprechendem Dienst. / No web/API/auth scope; re-evaluate on such a service. |
| SBOM, VEX und SLSA | `N/A` | Keine Abhängigkeit, Release-Pipeline oder ausgelieferte Komponente ändert sich; `docs/security/supply-chain-evidence.md` bleibt unverändert. Wiedervorlage bei Release-, CVE-, Paket- oder Pipelineänderung. / No dependency, artefact, or pipeline trigger. |
| AI-SBOM | `N/A` | KI ist Entwicklungswerkzeug, nicht Runtime oder Produktbestandteil. Wiedervorlage bei Modell, Datensatz, Inferenzdienst oder KI-Infrastruktur im Produkt. / AI is development tooling only. |
| OpenSSF Scorecard | `N/A` | Keine neue externe Abhängigkeit und keine Adoption oder Release-Bewertung. Wiedervorlage bei einem solchen Trigger. / No dependency-adoption or release trigger. |
| STRIDE, CIA und CAPEC | `N/A` | Keine Trust Boundary oder Datenflussänderung; `docs/security/threat-model.md` bleibt unverändert. Wiedervorlage bei externem Input, Privileg, Datei-, Netzwerk- oder Integrationsänderung. / No threat-model trigger. |
| S-ADR, arc42 Security und Qualitätsszenarien | `N/A` | Keine Architekturentscheidung; `docs/security/adr/`, `docs/security/arc42-security.md` und `docs/security/security-quality-scenarios.md` bleiben unverändert. / No architecture decision. |
| Zero Trust | `N/A` | Kein verteiltes oder remote verwaltetes System; `docs/security/zero-trust-applicability.md` bleibt unverändert. / No distributed-system trigger. |
| OWASP SAMM | `N/A` | Das Feature ändert keinen Security-Prozess; `docs/security/samm-assessment.md` bleibt unverändert. Wiedervorlage bei Prozess- oder Reifegradänderung. / No security-process trigger. |
| BSI C3A und BSI C5 | `N/A` | Kein Cloud-Service, Provider, Hosting oder Cloud-Assurance-Scope. Wiedervorlage bei Cloud-Betrieb oder Providerbindung. / No cloud or provider trigger. |
| NIS2, CRA, EU AI Act und DORA | `N/A` | Private Governance-Arbeit ohne Marktbereitstellung, regulierten Dienst, Produkt-KI oder Finanz-ICT. Wiedervorlage bei einem regulatorischen Trigger. / Private governance work without a regulatory trigger. |
| Dependency Audit | `N/A` für Änderung / for update | `docs/security/dependency-audit.md` bleibt unverändert, weil keine Abhängigkeit geändert wird; Read-only-Befunde werden im Feature-Check vermerkt. / No dependency update; read-only findings are noted in the feature review. |
| Security Checklist | `Applicable` | `docs/security/security-checklist.md` wird aus dem Stub zu einem prüfbaren TinyCalc-/Feature-002-Nachweis; `docs/security/README.md` aktualisiert den Status. / The stub becomes audit-ready feature evidence and its index status changes. |

### Preset-Anwendbarkeit / Preset Applicability

Die verbindliche Acht-Preset-Matrix aus
`scripts/config/spec-kit-governance-presets.json` bleibt unverändert:
`security-governance` 0.6.2, `architecture-governance` 0.5.2,
`isaqb-architecture-governance` 0.2.2, `a11y-governance` 0.4.3,
`cross-platform-governance` 0.2.2, `agent-parity-governance` 0.4.2,
`autonomous-run-governance` 0.4.1 und
`parallel-autonomous-run-governance` 0.2.6. Die Werte stammen aus der
ausführbaren Quelle; dieses Feature ändert die Matrix nicht. / The values come
from the executable source of truth; this feature does not change the matrix.

*The binding eight-preset matrix remains unchanged.*

| Preset | Status und konkrete Folge / Status and concrete consequence |
|---|---|
| Security | `Applicable`: Security-Checkliste, SSDF/CWE-Review, Secret-Scan. / Security checklist, SSDF/CWE review, secret scan. |
| Architecture | `N/A` für Änderungen: keine Trust Boundary, S-ADR- oder arc42-Aktualisierung. / No architecture evidence update. |
| iSAQB Architecture | `N/A`: keine Kontext-, Baustein-, Runtime-, Deployment- oder Qualitätsszenarioänderung; `docs/architecture/` bleibt unverändert. / No architecture-view change. |
| A11Y | `Applicable`: `docs/accessibility/constitution-change.md`, DE→EN, CEFR B2, text-first; kein HTML-Smoke ohne DocFX-Trigger. / Feature accessibility evidence; no HTML smoke without a trigger. |
| Cross-Platform | `N/A`: kein Skript, Cmdlet, Workflow oder Manpage wird geändert. Wiedervorlage bei Automationsänderung. / No tooling surface change. |
| Agent Parity | `Applicable`: fünf Agentenflächen, vier Projektvorlagen und betroffene Spec-Kit-Vorlagen. / Full parity set. |
| Autonomous Run | `Applicable`: vorhandene Run-State-, Gate-, Phasen- und Delivery-Evidenzpfade werden verwendet; diese Phase liefert nur Plan und Result-JSON. / Existing run-state and result contracts apply. |
| Parallel Autonomous Run | `N/A`: keine Kampagne, kein Worker-Manifest, kein paralleler Writer. / No campaign or parallel worker. |

### Dokumentationsauswirkung / Documentation Impact

**Entscheidung / Decision**: `UpdateRequired`

| Feld / Field | Festlegung / Determination |
|---|---|
| Quelle und Owner / Source and owner | `constitution.md`, Repository-Maintainer; `.specify/memory/constitution.md` ist der bytegleiche Spiegel. / The constitution is canonical and its memory copy is byte-identical. |
| Zielgruppen / Audiences | Auszubildende ab dem ersten Ausbildungsjahr, Lehrende, Entwickler, Reviewer und KI-Agenten. / First-year apprentices, teachers, developers, reviewers, and AI agents. |
| Leserpfad / Reader path | Constitution oder Agentenfläche → didaktische Sprach-, XML- und TDD-Regel → Feature-Evidenz → nächste sichere Aktion. / Governance entry → rules → evidence → next safe action. |
| Betroffene Klassen / Affected classes | Normative Governance, Agenten-Guidance, generierte Projektvorlagen, Spec-Kit-Vorlagen, Security-/A11Y-Nachweis, PR-Text und Statistik. / Governance, guidance, templates, evidence, PR text, and statistics. |
| Navigation / Navigation | Der neue Abschnitt bleibt im bestehenden TinyCalc-Level-2-Addendum; keine Hauptnavigation ändert sich. / The section stays in the existing addendum; no main navigation changes. |
| Sprachpartner / Language partner | Inline DE zuerst, EN danach; kein `.EN.md`-Sidecar nötig. / Inline DE first, EN second; no sidecar needed. |
| Plattform- und Beispielnachweis / Platform and example proof | Markdown ist plattformneutral; Build/Test laufen nach Registry, Agentenparität auf den vorhandenen CI-Plattformen. / Markdown is platform-neutral; build/test and parity use the registry contract. |
| Distribution / Distribution | `sourceOnly`; keine Produktverteilung oder Home-Synchronisation. / Source-only; no product distribution or Home sync. |
| Generierte Ableitungen / Generated derivations | Projektstatistik wird aus `docs/project-statistics.config.json` gerendert. DocFX bleibt ohne Trigger unverändert. / Statistics are rendered from JSON; DocFX stays unchanged without a trigger. |
| Validierung / Validation | Hash-, Spiegel-, Paritäts-, Markdown-, CS1591-, Build-, Test-, Smoke-, Security-, A11Y-, Secret- und Statistikprüfungen gemäß Matrix unten. / Validation follows the matrix below. |
| Review-Evidenz / Review evidence | `docs/accessibility/constitution-change.md`, `docs/security/security-checklist.md`, `docs/PR_TEXT_CONSTITUTION_CHANGE.md`, `specs/002-constitution-change/autonomous-run-evidence.md`. |
| Wiedervorlage / Re-evaluation | Jede Änderung an API, XML, DocFX, Preset-Matrix, Runtime, Agentenparität oder Statistikmethodik. / Any API, XML, DocFX, preset, runtime, parity, or statistics-method change. |

**Nachentwurfs-Gate / Post-design gate**: bestanden. Alle Constitution-Punkte
sind `Applicable` oder begründet `N/A`; kein Punkt bleibt `Open`. Es gibt keine
Complexity-Ausnahme. / Passed. Every checkpoint is applicable or justified
N/A, no item remains open, and no complexity exception exists.

## Projektstruktur / Project Structure

### Feature-Artefakte / Feature Artefacts

```text
specs/002-constitution-change/
├── spec.md
├── plan.md
├── tasks.md                                  # spätere /tasks-Phase / later tasks phase
├── checklists/
│   ├── autonomous-readiness.md
│   └── requirements.md
├── autonomous-run-evidence.md
├── autonomous-run-gate-requirements.json
└── autonomous-run-state.json
```

`research.md`, `data-model.md`, `contracts/` und `quickstart.md` sind für diese
Governance-Änderung `N/A`: Es gibt keine offene technische Frage, Entität,
Schnittstelle, Datenmigration oder neue Bedienfolge. Die Entscheidungen stehen
vollständig in diesem Plan. / These design artefacts are not applicable because
there is no open research question, entity, contract, migration, or new user
flow. This plan contains the complete decisions.

### Geplanter Änderungssatz / Planned Change Set

```text
constitution.md
.specify/
├── feature.json
├── memory/constitution.md
└── templates/
  ├── constitution-template.md
  ├── plan-template.md
  ├── spec-template.md
  └── tasks-template.md

AGENTS.md
CLAUDE.md
GEMINI.md
.github/
├── copilot-instructions.md
└── agents/copilot-instructions.md

scripts/templates/
├── AGENTS.md.tmpl
├── CLAUDE.md.tmpl
├── GEMINI.md.tmpl
└── copilot-instructions.tmpl

docs/
├── accessibility/constitution-change.md
├── security/
│   ├── README.md
│   └── security-checklist.md
├── PR_TEXT_CONSTITUTION_CHANGE.md
├── project-statistics.config.json
└── project-statistics.md

Directory.Build.props                        # nur Build-Zähler / build counter only
specs/002-constitution-change/
├── autonomous-run-evidence.md
├── autonomous-run-gate-requirements.json
├── autonomous-run-state.json
├── checklists/
│   ├── autonomous-readiness.md
│   └── requirements.md
├── plan.md
├── spec.md
└── tasks.md
```

`src/`, `tests/`, `docfx.json`, `_site/`, `api/`, Workflows, Paketdateien und
Review-Anfrage und Serienmanifest bleiben inhaltlich unverändert. Das bindende
Lastenheft wird erst nach vollständig validierter Umsetzung durch das
verfassungsmäßige Rename-Skript in
`requirements/intakes/active/Lastenheft_Constitution_Change.002-constitution-change.md`
umbenannt; sein Inhalt und SHA-256 bleiben identisch. Diese Archivierung startet
keinen Folge-Intake. `.specify/templates/constitution-template.md` erhält die
vollständige didaktische Regel statt nur eines knappen TDD-Beispiels;
`.specify/templates/plan-template.md`, `.specify/templates/spec-template.md`
und `.specify/templates/tasks-template.md` erhalten die jeweils anwendbaren
Planungs-, Anforderungs- und Rot-Grün-Aufräumen-/`N/A`-Evidenzverträge.

*Product source, tests, DocFX output, workflows, and packages remain unchanged.
The binding intake is renamed with identical content and hash; review, request,
and manifest stay unchanged. The constitution, plan, spec, and task templates
receive their role-appropriate pedagogical evidence contracts.*

**Strukturentscheidung / Structure decision**: Die bestehende Core-/TUI-
Struktur bleibt unverändert. Dieses Feature ändert ausschließlich Governance
und Nachweise an ihren vorhandenen kanonischen Orten. / The existing Core/TUI
structure remains unchanged; the feature changes governance and evidence only
at their established canonical locations.

## Umsetzungsphasen / Implementation Phases

### Phase 0 – Eingang und Scope einfrieren / Freeze Input and Scope

- Akzeptierte Hashes mit `shasum -a 256` prüfen.
- Genau 16 eindeutige `IR-`-Zeilen und die vier `Applicable`-Zeilen prüfen.
- Unaufgelöste Klärungs- oder `Open`-Marker sowie einen gestarteten späteren
  Intake ausschließen.
- Run-State und Gate-Anforderungen vor der ersten Implementierungsänderung
  erneut validieren.

*Verify accepted hashes, the 16 classifications, absence of unresolved
markers, and the current autonomous state before the first implementation
change.*

### Phase 1 – Kanonische Governance schreiben / Write Canonical Governance

- Im TinyCalc-Level-2-Addendum von `constitution.md` einen begrenzten Abschnitt
  „Didaktische und sprachliche Klarheit / Pedagogical and Linguistic Clarity“
  ergänzen.
- DE→EN, CEFR B2, text-first, anwendbare öffentliche XML-Dokumentation,
  moderate Warum-Kommentare und TDD Rot→Grün→Aufräumen eindeutig festlegen.
- Security-First-Prinzip I und die gemeinsame Home-Baseline unverändert lassen.
- Constitution-Version semantisch auf `1.17.0` erhöhen, `Last Amended` auf den
  Liefertermin setzen, den Sync Impact Report aktualisieren und die veralteten
  Acht-Preset-Matrizen in `constitution.md` und
  `.specify/memory/constitution.md` ausdrücklich an
  `scripts/config/spec-kit-governance-presets.json` angleichen.
- Den fertigen kanonischen Inhalt bytegleich nach
  `.specify/memory/constitution.md` übertragen; beide Dateien als einen
  serialisierten Writer behandeln.

*Add the scoped TinyCalc rule, preserve Security-First, and update both
constitution copies as one serialized write unit.*

### Phase 2 – Agenten- und Vorlagenparität / Agent and Template Parity

- Dieselbe Regel atomar in `AGENTS.md`, `CLAUDE.md`, `GEMINI.md`,
  `.github/copilot-instructions.md` und
  `.github/agents/copilot-instructions.md` ergänzen.
- `scripts/templates/AGENTS.md.tmpl`, `scripts/templates/CLAUDE.md.tmpl`,
  `scripts/templates/GEMINI.md.tmpl` und
  `scripts/templates/copilot-instructions.tmpl` synchron nachziehen. Die eine
  Copilot-Vorlage versorgt beide Copilot-Zieloberflächen.
- `.specify/templates/constitution-template.md`,
  `.specify/templates/plan-template.md`, `.specify/templates/spec-template.md`
  und `.specify/templates/tasks-template.md` auf den jeweils anwendbaren
  didaktischen, sprachlichen, XML- und TDD-Evidenzvertrag bringen.
- Keine Modellnamen in Spec, Plan, Tasks oder Vorlagen schreiben und keine
  unbegründete agentenspezifische Abweichung zulassen.

*Apply the same rule to all maintained agent surfaces and affected templates.
Keep model routing provider-neutral and record no unexplained deviation.*

### Phase 3 – Dokumentationsschranke und Sicherheitsnachweis / Documentation Gate and Security Evidence

- Beide Produktprojekte statisch auf Dokumentationserzeugung und aktive
  CS1591-Fehlerbehandlung prüfen; globale Unterdrückung ausschließen.
- Die vorhandene öffentliche API einmalig vollständig inventarisieren und jede
  fachlich anwendbare Signatur gegen `<summary>`, `<param>`, `<returns>` und
  `<exception>` prüfen. Nicht anwendbare Elemente erhalten eine begründete
  `N/A`-Disposition; lokale Variablen bleiben ausgeschlossen.
- Release-Build als eigentlichen Regressionstest ausführen. Nur wenn dabei
  eine echte öffentliche XML-Lücke erscheint, wird die anwendbare
  Dokumentation ergänzt.
- `docs/security/security-checklist.md` mit Feature-ID, Phase, Owner, Reviewer,
  NIST-SSDF-/CWE-Top-25-Zuordnung, N/A-Begründungen, Restrisiko und
  Wiedervorlagen ausfüllen; Status in `docs/security/README.md` anpassen.
- Abhängigkeiten read-only auf Aktualität und bekannte Verwundbarkeit prüfen.
  Keine Paketänderung gehört in dieses Feature.

*Verify the existing XML documentation gate and complete feature-specific
security evidence. Package checks are read-only and cause no dependency
change.*

### Phase 4 – A11Y und Dokumentationsentscheid / Accessibility and Documentation Decision

- `docs/accessibility/constitution-change.md` aus der A11Y-Evidenzvorlage
  erstellen. Geprüft werden Überschriften, DE→EN-Reihenfolge, CEFR B2,
  Fachbegriffserklärung, deutsche Orthografie, Codeblock-Tags, Textalternativen
  sowie Braille-, Screenreader- und Textbrowser-Tauglichkeit statischer Texte.
- DocFX-Trigger nach dem endgültigen Änderungssatz erneut prüfen.
- Ohne API-/XML-/Navigation-/Präsentationstrigger wird DocFX mit Begründung
  als `N/A` dokumentiert. Bei Trigger sind DocFX und Playwright/axe plus
  `lynx` im selben Arbeitsgegenstand verpflichtend; ein halber Nachweis ist
  kein Pass.

*Create static-document accessibility evidence and re-evaluate the DocFX
trigger. Generation and HTML accessibility either both run or both remain a
justified N/A.*

### Phase 5 – Statistik und Liefertext / Statistics and Delivery Text

- In `docs/project-statistics.config.json` einen stabilen Phase-002-Slot mit
  den nach Umsetzung beobachteten Nettozeilen ergänzen.
- In `docs/project-statistics.md` genau einen neuen chronologischen Eintrag am
  Ende des Fortschreibungsprotokolls ergänzen. Er enthält Arbeitsfenster,
  Produktions-/Test-/Dokumentationszeilen, Arbeitspakete, 80-/125-Baselines,
  7,8 Stunden, 21,5 Arbeitstage/Monat und den als Lieferdichte bezeichneten
  blended repository speedup.
- Profil 2 neu rendern und sicherstellen, dass `## Gesamtstatistik / Overall
  Statistics` der letzte Top-Level-Abschnitt bleibt.
- `docs/PR_TEXT_CONSTITUTION_CHANGE.md` zweisprachig mit Problem, Lösung,
  Risiken, Testplan, DocFX-Entscheid und Evidence-Pfaden erstellen.

*Add one chronological statistics entry, refresh Profile 2 from its JSON
source, and prepare the bilingual PR description.*

### Phase 6 – Lokale Konvergenz und spätere Lieferung / Local Convergence and Later Delivery

- Versionen vor jedem Build/Test regelgerecht und serialisiert fortschreiben.
- Restore, Release-Build, vollständige xUnit-Suite und TUI-Smoke ausführen.
- Homogenitäts- und Secret-Prüfung mit explizitem Repository-Root ausführen;
  Exitcode, Standardausgabe und Fehlerkanal prüfen.
- Beabsichtigten tracked/untracked Delivery-Satz read-only validieren. Fremde
  Änderungen und `.codex`-/Runtime-Logs bleiben ausgeschlossen.
- `specs/002-constitution-change/autonomous-run-evidence.md` mit tatsächlich
  ausgeführten Befehlen, Plattformen, Ergebnissen, Triggerentscheidungen und
  Restrisiken aktualisieren.
- Erst danach kann eine getrennte Delivery-Grenze aktuelle Autorität prüfen.
  Gespeicherter Modus oder Admin-Bypass ersetzt weder Gates noch exakten Head.
- Vor der Archivierung werden Intake, Review, Request und Manifest erneut gegen
  die akzeptierten Hashes geprüft. Als letzter Polish-Schritt wird nur das
  bindende Lastenheft mit dem vorhandenen Rename-Skript branchgestempelt; sein
  Inhalt bleibt unverändert. Im selben Rename-Commit wird ausschließlich der
  akzeptierte Intake-Pfad im Run-State auf den branchgestempelten Namen bei
  identischem Hash aktualisiert. Review, Request und Manifest bleiben unverändert.
  Der Seriencontroller darf erst nach vollständigem Abschluss in einem
  getrennten, autorisierten Schritt über den nächsten Intake entscheiden.

*Converge locally, validate the exact delivery set, and update run evidence.
Any later delivery boundary must re-check authority and exact head. Accepted
intake artefacts stay unchanged, and this feature does not start its successor.*

## Validierungs- und Evidenzmatrix / Validation and Evidence Matrix

Die folgenden Befehle sind für die spätere Umsetzung verbindlich. Wo ein
Befehl `dotnet build` oder `dotnet test` enthält, wird direkt davor der
Build-Zähler in `Directory.Build.props` erhöht. / These commands bind the later
implementation. The build counter is incremented immediately before every
`dotnet build` or `dotnet test` command.

| Gate | Befehl oder Prüfung / Command or check | Erfolg / Success | Evidenzpfad / Evidence path |
|---|---|---|---|
| Eingabehashes / Input hashes | `shasum -a 256 requirements/intakes/active/Lastenheft_Constitution_Change.002-constitution-change.md requirements/intakes/series/tinycalc-delivery/intake-review-result.json requirements/intakes/series/tinycalc-delivery/intake-review-request.json requirements/intakes/series/tinycalc-delivery/manifest.json specs/002-constitution-change/spec.md specs/002-constitution-change/checklists/requirements.md` | Alle sechs Werte entsprechen der Tabelle. / All six match. | `specs/002-constitution-change/autonomous-run-evidence.md` |
| Intake-Klassifikation / Intake classification | `rg -n '^\| IR-[0-9]{3} \|' specs/002-constitution-change/spec.md` und `rg -n '\[NEEDS[ ]CLARIFICATION:|\| .*\| Open \|' specs/002-constitution-change/spec.md specs/002-constitution-change/checklists/requirements.md` | Genau 16 eindeutige Zeilen, vier `Applicable`, keine ungeklärte Markierung. / Exactly 16 unique rows, four applicable, no unresolved marker. | `specs/002-constitution-change/checklists/requirements.md` |
| Constitution-Spiegel / Constitution mirror | `cmp -s constitution.md .specify/memory/constitution.md` | Exitcode 0 und Security-First bleibt Prinzip I. / Exit 0 and Security-First remains Principle I. | `specs/002-constitution-change/autonomous-run-evidence.md` |
| Regelvollständigkeit / Rule completeness | `rg -n 'Didaktische und sprachliche Klarheit|Pedagogical and Linguistic Clarity|Rot.*Grün.*Aufräumen|red.*green.*refactor|CS1591' constitution.md .specify/memory/constitution.md AGENTS.md CLAUDE.md GEMINI.md .github/copilot-instructions.md .github/agents/copilot-instructions.md scripts/templates/AGENTS.md.tmpl scripts/templates/CLAUDE.md.tmpl scripts/templates/GEMINI.md.tmpl scripts/templates/copilot-instructions.tmpl .specify/templates/constitution-template.md .specify/templates/plan-template.md .specify/templates/spec-template.md .specify/templates/tasks-template.md` | Jede der fünf Agentenflächen, vier Projektvorlagen und vier Constitution-abhängigen Spec-Kit-Vorlagen enthält die für ihre Rolle vollständige didaktische, sprachliche, XML-/CS1591- und TDD-Semantik. Fehlende Einzeldatei oder Semantik ist ein Fehler. / Every agent surface, project template, and constitution-dependent Spec Kit template carries the complete role-appropriate pedagogical, language, XML/CS1591, and TDD semantics. A missing file or semantic element fails the gate. | `docs/PR_TEXT_CONSTITUTION_CHANGE.md` |
| Homogenität / Homogeneity | `pwsh -NoProfile -File scripts/check-homogeneity.ps1 -TargetDir . -DryRun -NoPatch -Json` | Exitcode 0; keine automatische Korrektur. CI wiederholt auf Ubuntu, macOS und Windows. / Exit 0, no auto-fix; CI repeats on three platforms. | Lokale Ausgabe in `specs/002-constitution-change/autonomous-run-evidence.md`; CI-Run-Links vor Delivery / Local summary in run evidence; CI links before delivery |
| CS1591-Konfiguration / CS1591 configuration | `rg -n '<GenerateDocumentationFile>true</GenerateDocumentationFile>|<WarningsAsErrors>.*CS1591' src/MicroCalc.Core/MicroCalc.Core.csproj src/MicroCalc.Tui/MicroCalc.Tui.csproj` und `rg -n 'NoWarn|CS1591' Directory.Build.props src tests` | Beide Produktprojekte erzeugen XML; keine globale CS1591-Unterdrückung. / Both produce XML; no global suppression. | `specs/002-constitution-change/autonomous-run-evidence.md` |
| Öffentliche XML-Vollständigkeit / Public XML completeness | Inventur aller öffentlichen Typen und Mitglieder in `src/MicroCalc.Core` und `src/MicroCalc.Tui`; Abgleich jeder Signatur mit dem XML-Kommentar und den fachlich anwendbaren `<summary>`, `<param>`, `<returns>` und `<exception>`-Elementen. / Inventory every public type and member and compare its signature with all applicable XML elements. | Jede API-Zeile besitzt `Pass` oder ein begründetes elementbezogenes `N/A`; keine lokale Variable wird dokumentiert. / Every API row has Pass or an element-specific N/A; locals are excluded. | `specs/002-constitution-change/autonomous-run-evidence.md` |
| Constitution-Metadaten und Presets / Constitution metadata and presets | `rg`- und JSON-Abgleich von Version `1.17.0`, Lieferdatum, Sync Impact Report und Acht-Preset-Matrix mit `scripts/config/spec-kit-governance-presets.json`. / Compare version, date, sync report, and matrix with the executable source. | Beide Constitution-Dateien und alle gepflegten Agentenflächen sind synchron; keine alte Matrixversion bleibt. / Mirrors and agent surfaces agree; no stale matrix version remains. | `specs/002-constitution-change/autonomous-run-evidence.md` |
| Restore | `dotnet restore MicroCalc.sln` | Exitcode 0. | `specs/002-constitution-change/autonomous-run-evidence.md` |
| Build | `dotnet build MicroCalc.sln --configuration Release --no-restore` | Exitcode 0, keine CS1591-Lücke. / Exit 0, no CS1591 gap. | `specs/002-constitution-change/autonomous-run-evidence.md` und CI `ci/build-test` / and CI job |
| Tests | `dotnet test MicroCalc.sln --configuration Release --no-build` | Alle xUnit-Tests grün. / All xUnit tests pass. | `specs/002-constitution-change/autonomous-run-evidence.md` und CI `ci/build-test` / and CI job |
| TUI-Smoke | `dotnet run --no-build --configuration Release --project src/MicroCalc.Tui/MicroCalc.Tui.csproj -- --smoke` | Exitcode 0. | `specs/002-constitution-change/autonomous-run-evidence.md` |
| Coverage | Basisscope: begründetes `N/A`. Falls Produktcode in Scope kommt: `dotnet test MicroCalc.sln --configuration Release --collect:"XPlat Code Coverage"` | Basisscope: kein geänderter Code. Bei Trigger: ≥70 %, Ziel ≥80 %. / Baseline: no changed code; on trigger use thresholds. | `specs/002-constitution-change/autonomous-run-evidence.md` |
| Paketaktualität / Package currency | `dotnet list MicroCalc.sln package --outdated --include-transitive` und `dotnet list MicroCalc.sln package --vulnerable --include-transitive` | Befunde dokumentiert; kein kritischer CVE. Keine Paketänderung. / Findings recorded; no critical CVE; no update. | `docs/security/security-checklist.md` |
| Secret-Scan | `pwsh -NoProfile -File scripts/scan-agent-secrets.ps1 -WorkspaceRoot . -FailOnHigh` | Exitcode 0, keine High-Funde. / No high finding. | `specs/002-constitution-change/autonomous-run-evidence.md` und CI `Homogeneity Check` / and CI job |
| Security Review | Manuelle Matrix gegen Principle XII, NIST SSDF, CWE Top 25 und OWASP-Hilfen. / Manual matrix review. | Alle anwendbaren Zeilen `OK`; jede andere Zeile begründet `N/A`; Reviewer benannt. / Applicable rows OK, all others justified N/A, reviewer named. | `docs/security/security-checklist.md` |
| Markdown-A11Y | Manuelle Prüfung plus vorhandene Homogenitätsprüfung. / Manual review plus homogeneity check. | DE→EN, CEFR B2, semantische Überschriften, Tags und vollständige Textpfade bestanden. / Language, headings, tags, and text paths pass. | `docs/accessibility/constitution-change.md` |
| DocFX-Trigger | Endgültigen Delivery-Satz auf API-, XML-, Navigation- und Präsentationsänderung prüfen. / Inspect final delivery set for documented triggers. | Ohne Trigger begründetes `N/A`. Bei Trigger: `docfx docfx.json`, repräsentativer Playwright/axe-Smoke und `lynx -dump -nolist _site/index.html` alle erfolgreich. / Justified N/A or all three pass. | `docs/accessibility/constitution-change.md` und `specs/002-constitution-change/autonomous-run-evidence.md` |
| Statistik | `pwsh -NoProfile -File scripts/render-project-statistics.ps1 -Repo .` danach `pwsh -NoProfile -File scripts/render-project-statistics.ps1 -Repo . -CheckOnly -Json` | Renderer und Check-only erfolgreich; genau ein neuer Ledger-Eintrag; Gesamtstatistik bleibt letzte H2. / Renderer and check pass; one entry; final statistics section preserved. | `docs/project-statistics.config.json`, `docs/project-statistics.md` |
| Phasenresultat / Phase result | `pwsh -NoProfile -File .specify/presets/autonomous-run-governance/scripts/validate-autonomous-phase-result.ps1 -Repo . -Result .specify/runtime/autonomous-routing/d42bfa06-0a67-492e-968d-80309788b383/plan-review.result.json -PhaseId plan-review -ExitCode 0` | Plan-Review-Ergebnis `Completed`, Payload-Hash stimmt mit dem abschließend geprüften Plan überein. / The plan-review result is completed and its payload hash matches the finally reviewed plan. | `.specify/runtime/autonomous-routing/d42bfa06-0a67-492e-968d-80309788b383/plan-review.result.json` |

## Autonome Liefer- und Abschlussnachweise / Autonomous Delivery and Closeout Evidence

Planung und Plan-Review schreiben ausschließlich `plan.md` sowie ihr jeweiliges
maschinenlesbares Phasenresultat. Für die spätere Umsetzung und Lieferung sind
folgende Pfade vorab festgelegt. / Planning and plan review write only the plan
and their respective machine-readable phase results. The following paths are
fixed for later implementation and delivery.

| Zweck / Purpose | Exakter Pfad / Exact path |
|---|---|
| Akzeptierte Gate-Anforderungen / Accepted gate requirements | `specs/002-constitution-change/autonomous-run-gate-requirements.json` |
| Laufstatus / Run state | `specs/002-constitution-change/autonomous-run-state.json` |
| Lesbare kumulative Evidenz / Human-readable cumulative evidence | `specs/002-constitution-change/autonomous-run-evidence.md` |
| Plan-Phasenresultat / Plan phase result | `.specify/runtime/autonomous-routing/d42bfa06-0a67-492e-968d-80309788b383/plan.result.json` |
| Plan-Review-Phasenresultat / Plan-review phase result | `.specify/runtime/autonomous-routing/d42bfa06-0a67-492e-968d-80309788b383/plan-review.result.json` |
| Temporäre PreMerge-Gate-Evidenz / Temporary PreMerge gate evidence | `.specify/runtime/autonomous-routing/d42bfa06-0a67-492e-968d-80309788b383/premerge-gate-evidence.json` |
| Temporäre PostMerge-Gate-Evidenz / Temporary PostMerge gate evidence | `.specify/runtime/autonomous-routing/d42bfa06-0a67-492e-968d-80309788b383/postmerge-gate-evidence.json` |
| Read-only Delivery-Satz / Read-only delivery set | `.specify/runtime/autonomous-routing/d42bfa06-0a67-492e-968d-80309788b383/delivery-set.json` |
| A11Y-Nachweis / Accessibility evidence | `docs/accessibility/constitution-change.md` |
| Security-Nachweis / Security evidence | `docs/security/security-checklist.md` |
| PR-Beschreibung / PR description | `docs/PR_TEXT_CONSTITUTION_CHANGE.md` |
| Statistikquelle und Ausgabe / Statistics source and output | `docs/project-statistics.config.json`, `docs/project-statistics.md` |
| Vorbenannter Closeout-Branch / Pre-named closeout branch | `002-constitution-change-closeout`, nur falls nach dem ersten Merge terminale tracked Evidenz aktualisiert werden muss / only if terminal tracked evidence must change after the first merge |

Vor einem späteren Merge wird jede Zeile aus den Gate-Anforderungen genau einem
tatsächlich ausgeführten Workflow, Job, Runner oder einer Plattform und einem
Befehl zugeordnet. Ein grüner Anzeigename und ein Admin-Bypass sind keine
technische Evidenz. PreMerge bindet den vollständig geprüften exakten Head;
PostMerge bindet kausal den akzeptierten PreMerge-Hash an den tatsächlichen
Merge-Commit und die synchronisierte Standard-Branch-Prüfung. Bei bewusstem
Stopp wird am nächsten sicheren Grenzpunkt pausiert; eine Fortsetzung verlangt
den vorgesehenen Resume-Weg und erneute Drift-, Scope-, Hash-, Routing- und
Autoritätsprüfung.

*Before a later merge, every required gate maps to an actually executed
workflow, job, runner or platform, and command. A green display name and admin
bypass are not technical evidence. PreMerge binds the exact reviewed head;
PostMerge causally binds that accepted evidence to the real merge commit and
default-branch validation. A deliberate stop pauses at the next safe boundary,
and resume requires drift, scope, hash, routing, and authority revalidation.*

## Risiken und Gegenmaßnahmen / Risks and Mitigations

| Risiko / Risk | Gegenmaßnahme / Mitigation |
|---|---|
| Security-First wird versehentlich verdrängt. / Security-First is displaced. | Neuer Abschnitt nur im TinyCalc-Addendum; Überschrift und Position werden ausdrücklich geprüft. / Scope the section to the addendum and check heading and position. |
| Agenten- oder Vorlagenflächen driften semantisch. / Agent or template surfaces drift. | Ein serialisierter Änderungssatz, `rg`-Matrix und Homogenitätsprüfung; keine absichtliche Abweichung. / Serialized update, search matrix, and homogeneity check. |
| XML-Regel erzeugt sinnlose Kommentare. / XML rule creates useless comments. | Nur öffentliche, fachlich anwendbare Elemente; lokale Variablen ausgeschlossen. / Public and applicable elements only; locals excluded. |
| DocFX wird zu breit oder gar nicht ausgelöst. / DocFX trigger is too broad or missed. | Endgültigen Delivery-Satz gegen vier dokumentierte Trigger prüfen; DocFX und HTML-A11Y sind gekoppelt. / Recheck four triggers and couple generation with HTML accessibility. |
| Ein Text-Feature wird fälschlich als TDD-Pass ausgegeben. / Text work is misreported as a TDD pass. | Aktuelle Umsetzung begründet `N/A`; zukünftige Verhaltensänderungen brauchen beobachtbare Rot-/Grün-/Aufräum-Evidenz. / Current work is N/A; future behaviour work needs observable evidence. |
| Build-Zähler oder Statistikdatei wird parallel überschrieben. / Build counter or statistics is overwritten concurrently. | Version, Agentenflächen, Evidence und Statistik sind serialisierte Writer. / Treat shared mutable files as serialized writers. |
| Gespeicherte Delivery Authority wird als aktuelle Erlaubnis verstanden. / Stored delivery authority is treated as current permission. | Vor jeder Git-/Remote-/Bypass-Grenze aktuelle Autorität und exakten Head prüfen. / Re-check authority and exact head at every delivery boundary. |
| Ein späterer Intake wird zu früh gestartet. / A later intake starts early. | Beim branchgestempelten Lastenheft werden nur die drei Selbstpfade der aktivierten Prompts angepasst und die davon abhängige aktive Intake-Governance neu gerendert. Scope und Authority bleiben unverändert; kein Next-/Update-/Start-Befehl gehört zu diesem Feature. / Only the three enabled-prompt self-paths and their derived active intake governance are refreshed; scope and authority remain unchanged and no successor command runs. |

## Komplexitätsnachverfolgung / Complexity Tracking

Keine Constitution-Verletzung und keine begründungspflichtige
Komplexitätsausnahme. Die vorhandene Zwei-Projekt-Architektur bleibt
unverändert. / No constitution violation or complexity exception. The existing
two-project architecture remains unchanged.

## Plan-Abschlusskriterien / Plan Completion Criteria

- Alle vier `Applicable`-Intake-Punkte besitzen geordnete Arbeitspakete und
  exakte Evidenzpfade.
- Alle `N/A`-, `AlreadySatisfied`- und `FollowUp`-Grenzen bleiben erhalten.
- Constitution-, Security-, A11Y-, Agenten-, DocFX-, Statistik- und autonome
  Gates sind entschieden; kein Gate bleibt `Open`.
- Der Plan enthält keine Implementierung und hat keine Git- oder Remote-Aktion
  ausgeführt.
- Das strukturierte Plan-Review-Resultat verweist auf diese Datei und enthält
  ihren normalisierten SHA-256-Wert.

*All applicable intake items have ordered work and exact evidence paths. All
non-goals and deferred boundaries remain intact. Every governance and delivery
gate is decided, no item is open, no implementation or Git/remote action has
occurred, and the structured result binds this plan by normalized SHA-256.*
