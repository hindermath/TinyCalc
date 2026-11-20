# MicroCalc – Copilot Instructions

## Verbindlicher Einstieg / Required starting point

DE: Arbeite im Repository TinyCalc. Prüfe die Projektkonstitution und die nachstehenden
Build-, Test- und Freigaberegeln. Verwende `MicroCalc.sln` für die projektweiten Prüfungen.
Halte gemeinsame Regeln in allen fünf Agenten-Dateien synchron und dokumentiere Abweichungen.
Bei Level-2-Arbeit die anwendbaren Sicherheitsstandards nennen, `N/A` begründen und die
Nachweise im Plan und in den Aufgaben festhalten. Sichere Eingabegrenzen, minimale
Berechtigungen und geschützte Zugangsdaten sind verbindlich. Prüfe anwendbare WCAG 2.2 AA
Kriterien und dokumentiere offene Nachweise. Pflege die Projektstatistik nach den markierten Regeln.

EN: Work in the TinyCalc repository. Read the project constitution and the build,
test and delivery rules below. Use `MicroCalc.sln` for solution-wide checks.
Keep shared rules in sync across all five agent files and document differences.
Name the applicable security standards for Level 2 work, justify `N/A`, and record
evidence in plans and tasks. Validate trust boundaries, apply least privilege and
protect credentials. Check applicable WCAG 2.2 AA criteria and record gaps in evidence.
Maintain project statistics according to the marked rules.

[Verbindliche Detailregeln / Required detailed rules](../docs/agent-guidance.md):
Lies vor der Arbeit die Abschnitte zu deiner Aufgabe, insbesondere vor Änderungen an Code,
Architektur, Agentenwerkzeugen oder Spec-Kit-Presets.
Read the sections relevant to your task before work, especially before changing code,
architecture, agent tooling or Spec Kit presets.

## Build & Test

```bash
# Restore
dotnet restore MicroCalc.sln

# Build (CI-aligned)
dotnet build MicroCalc.sln --configuration Release --no-restore

# Run all tests (CI-aligned)
dotnet test MicroCalc.sln --configuration Release --no-build

# Run a single test class
dotnet test tests/MicroCalc.Core.Tests/MicroCalc.Core.Tests.csproj --configuration Release --filter "FullyQualifiedName~FormulaGoldenTests"

# Smoke run (non-interactive, validates TUI without Terminal.Gui window)
# Always pass --configuration explicitly with --no-build; CI uses Release
dotnet run --no-build --configuration Release --project src/MicroCalc.Tui/MicroCalc.Tui.csproj -- --smoke

# Start interactive TUI
dotnet run --project src/MicroCalc.Tui/MicroCalc.Tui.csproj
```

CI runs on `main` and all `codex/**` branches using the Release configuration.

`Directory.Build.props` carries the repo-wide `Version`, `AssemblyVersion`, and `FileVersion` values for all projects using `Major.Minor.Patch.Build`:
- `Minor` = current Spec-Kit feature/branch number, interpreted numerically as the canonical PR number for versioning (`002` -> `2`) and used immediately even before a GitHub PR exists
- `Patch` = current commit count in that feature/PR branch (after committing the current change)
- `Build` = manual build counter incremented before every `dotnet build` or `dotnet test`

On numbered Spec-Kit branches, align those three version fields before pushing.

## Inclusion & Accessibility

- Follow `Programmierung #include<everyone>`: Diese Lernbeispiele richten sich an Azubis (Fachinformatiker AE/SI), die auf Deutsch und Englisch arbeiten, **sowie** an sehbehinderte Lernende, die Braille-Displays, Screen-Reader oder Textbrowser nutzen. Barrierefreiheit ist Pflichtanforderung, kein Nice-to-have. / *These learning examples target apprentices working in German and English, **and** visually impaired learners using Braille displays, screen readers, or text browsers. Accessibility is mandatory.*
- Prefer semantic headings, lists, tables, and ASCII/text-first diagrams; do not encode essential meaning only through color, layout, or pointer-only affordances.
- Treat WCAG 2.2 conformance level AA as the concrete review baseline for generated HTML documentation, especially for page language, bypass blocks, keyboard focus visibility, non-text contrast, and readable landmark structure.
- If `docfx` output is regenerated, follow it with a text-oriented accessibility review, preferably with Playwright + `@axe-core/playwright` and a `lynx` cross-check.
- Recommended A11y toolchain for DocFX-based repos: Node 24 LTS, `npm`, Playwright, `@axe-core/playwright`, and `lynx`.
- Treat bilingual CEFR-B2 delivery and the documented A11Y proof path as formal completion criteria for learner-facing documentation and active requirement artifacts.

## Level-2-Umgebungsregister / Level-2 Environment Registry

- Die zentrale `constitution.md` enthält das verbindliche Level-2 Project Environment Registry.
- Spec-Kit-Pläne und Copilot-Arbeit in Level-2-Projekten müssen die passende Registry-Zeile als verbindlichen Kontext für Runtime, Build/Test, A11Y, Statistik und Agentenflächen verwenden.
- Änderungen an einer Level-2-Runtime, Toolchain oder Statistik-Basis müssen `constitution.md`, `.specify/memory/constitution.md` und betroffene KI-Agenten-Dateien gemeinsam prüfen.

*The central `constitution.md` contains the binding Level-2 Project Environment Registry. Spec-Kit plans and Copilot work in Level-2 projects must use the matching registry row as binding context for runtime, build/test, A11Y, statistics, and agent surfaces. Changes to Level-2 runtime, toolchain, or statistics baselines require a joint review of `constitution.md`, `.specify/memory/constitution.md`, and affected AI-agent files.*

## Sicherheitsdokumentation / Security Documentation (XII–XVIII Extensions)

- Jedes Level-2-Projekt MUSS die folgenden Sicherheitsdokumente pflegen, basierend auf den Templates in `.specify/templates/`:
  - **Bedrohungsmodell / Threat Model** (`threat-model-template.md`) — STRIDE-Methodik, Trust Boundaries, Risikobewertung, CAPEC-Referenzen (Prinzip XIII + XVII)
  - **Security Architecture Decision Records (S-ADR)** (`adr-template.md`) — architektonische Sicherheitsentscheidungen mit Compliance-Nachweis (Prinzip XIII)
  - **arc42 Section 8 Sicherheits-Querschnittskonzepte** (`arc42-security-template.md`) — Authentifizierung, Autorisierung, Verschlüsselung, Eingabevalidierung, Fehlerbehandlung, Logging, Abhängigkeiten, Deployment (Prinzip XIII)
  - **Sicherheits-Checkliste / Security Checklist** (`security-checklist-template.md`) — sprachspezifische Code-Review-Checkliste (Prinzip XII)
  - **Abhängigkeits-Audit / Dependency Audit** (`dependency-audit-template.md`) — CVE-Tracking, Lizenz-Compliance, Supply-Chain-Sicherheit (Prinzip XII)
  - **Sicherheits-Qualitätsszenarien / Security Quality Scenarios** (`security-quality-scenarios-template.md`) — iSAQB CPSA-F Qualitätsszenario-Methodik (Prinzip XII + XIII, SHOULD)
  - **ASVS-Verifikation / ASVS Verification** (`asvs-verification-template.md`) — OWASP ASVS Level, Scope und Evidenz (Prinzip XV, Web-/API-Projekte MUST)
  - **Supply-Chain-Evidenz / Supply Chain Evidence** (`supply-chain-evidence-template.md`) — SBOM, AI-SBOM, VEX, SLSA, OpenSSF Scorecard (Prinzip XVI, releasefähige Projekte MUST; AI-SBOM nur bei KI-Runtime-/Produktkomponenten)
  - **Zero-Trust-Anwendbarkeit / Zero Trust Applicability** (`zero-trust-applicability-template.md`) — NIST SP 800-207-Bewertung (Prinzip XVIII, verteilte Systeme SHOULD)
  - **SAMM-Bewertung / SAMM Assessment** (`samm-assessment-template.md`) — OWASP SAMM Reifegrad und Verbesserungsplan (Prinzip XVIII, langlebige Projekte SHOULD)
- Projektspezifische Instanzen werden in `docs/security/` gepflegt; S-ADRs als einzelne Dateien in `docs/security/adr/`.

*Every Level-2 project MUST maintain security documents based on templates in `.specify/templates/`: threat model (STRIDE+CAPEC), S-ADRs, arc42 Section 8 security concepts, security checklist, dependency audit, security quality scenarios (SHOULD), ASVS verification (web/API MUST), supply-chain evidence (release-capable MUST; AI-SBOM when AI runtime/product components apply), Zero Trust applicability note (distributed systems SHOULD), and SAMM assessment (long-lived projects SHOULD). Project-specific instances live in `docs/security/`; S-ADRs in `docs/security/adr/`. See `constitution.md`, Principles XII–XVIII for authoritative requirements.*

## Sicherheitsstandards & Anwendbarkeit / Security Standards & Applicability

- Vor jeder Level-2-Aufgabe die anwendbaren Sicherheitsstandards aus `constitution.md`, Prinzipien XIV-XX bestimmen und explizit benennen.
- `NIST SSDF` und `CWE Top 25` gelten immer für Level-2-Arbeit.
- `OWASP ASVS` gilt für Web-, API-, HTTP- und authentifizierte Dienste; der gewählte ASVS-Level muss benannt werden.
- `SBOM` gilt für releasefähige oder verteilbare Artefakte; `VEX`, wenn bekannte Schwachstellen in ausgelieferten oder geprüften Komponenten bewertet werden müssen.
- `AI-SBOM` gilt projektartabhängig bei KI-Modellen, KI-Diensten, Trainings-/Embedding-Daten, Inferenz-Infrastruktur oder KI-Runtime-Komponenten im ausgelieferten oder betriebenen System; reine Entwicklungswerkzeug-Nutzung wird als `N/A` mit Toolchain-Begründung dokumentiert.
- `SLSA` gilt als Soll-Vorgabe für CI/CD- oder veröffentlichte Artefakte; `Zero Trust` ist für verteilte, servicebasierte, cloudnahe oder remote-verwaltete Systeme explizit zu prüfen.
- `CAPEC` soll in Bedrohungsmodellen für die risikoreichsten Angriffswege verwendet werden; `OWASP SAMM` soll für langlebige Projekte/Workspaces in Verbesserungspläne einfließen.
- `OWASP Cheat Sheet Series`, `OWASP Proactive Controls` und bei öffentlichen OSS-Repositories oder kritischen Abhängigkeiten `OpenSSF Scorecard` sind als ergänzende Referenzen zu berücksichtigen.
- Nichtanwendbarkeit immer als `N/A` mit kurzer Begründung dokumentieren; keine stillschweigende Auslassung.

*At the start of every Level-2 task, determine and name the applicable security standards from `constitution.md`, Principles XIV-XX. `NIST SSDF` and `CWE Top 25` always apply. `OWASP ASVS` applies to web/API/HTTP/auth-bearing services; `SBOM` applies to releasable or distributable artefacts; `AI-SBOM` applies when AI models, AI services, datasets, inference infrastructure, or AI runtime components are part of the released or operated system; `VEX` applies when known vulnerabilities in shipped/evaluated components need a disposition statement. `SLSA` is the target model for CI/CD and published artefacts; `Zero Trust` must be explicitly evaluated for distributed, service-based, cloud, or remotely managed systems. `CAPEC`, `OWASP SAMM`, `OWASP Cheat Sheet Series`, `OWASP Proactive Controls`, and `OpenSSF Scorecard` are supporting references where relevant. Record non-applicability as `N/A` with justification rather than omitting it silently.*

## GitHub/GitLab CLI First / GitHub/GitLab CLI zuerst

Für GitHub-Repositories zuerst die authentifizierte `gh` CLI für mögliche Schreibaktionen und Live-Repository-Operationen verwenden, einschließlich PR-/Issue-Kommentaren, PR-Statusprüfungen, Review-Follow-up, Workflow-Prüfung und Merge-/Statusabfragen. GitHub-Connector-Tools hauptsächlich für strukturierte Read-only-Inspektion oder Fälle nutzen, in denen die CLI nicht geeignet ist.

Für GitLab-Repositories die authentifizierte `glab` CLI zuerst für gleichwertige Aktionen verwenden. Bekanntermaßen fehlschlagende Connector-Schreibwege nicht wiederholt versuchen, wenn `gh`/`glab` die Aufgabe direkt erledigen kann.

For GitHub repositories, use the authenticated `gh` CLI first for feasible write actions and live repository operations, including PR/issue comments, PR status checks, review follow-up, workflow inspection, and merge/status queries. Use GitHub connector tools mainly for structured read-only inspection or when the CLI is not suitable.

For GitLab repositories, use the authenticated `glab` CLI first for equivalent actions. Do not repeatedly try connector write paths that are known to fail when `gh`/`glab` can perform the task directly.

## Secure Development Assurance – freigegebenes Projektprofil / Approved Project Profile

- Die unveraenderte Basis des optionalen 14er-Statistik-Piloten ist `secure-development-assurance-thirteen-governance-presets`: die bisherigen zwölf Presets plus `secure-development-assurance-governance` v0.1.10, aktiviert mit Priorität 15. Andere Profile und globale Defaults bleiben unverändert.
- Maßgebliche Produktquellen sind ausschließlich die veröffentlichten eigenständigen GitHub-Preset-Repositories. Lokale Installationen sind Integrationskopien, keine zusätzlichen Produktquellen; Änderungen entstehen im jeweiligen Preset-Repository, nicht in einem Home-Baseline-Scaffold.
- `speckit.secure-development-status` prüft Evidence strikt lesend. `speckit.secure-development-review` benötigt einen ausdrücklich beauftragten Gate-/Kontext-Review; die Installation startet keine Reviews und erteilt keine menschlichen Freigaben.
- Keine C5-Testat-, Zertifizierungs- oder vollständige Readiness-Prüfung; `Ready` gilt nur für den gebundenen Evidence-Kontext. Projektgeführte Baseline-Versionen werden nicht durch die Preset-Version ersetzt.
- Bedienung, Paketbindung, Erhaltungsnachweis und Grenzen: [Integrationsnachweis](../docs/maintenance/secure-development-assurance-integration.md), relativ zur Repository-Wurzel.

*The optional fourteen-preset statistics pilot retains this thirteen-preset base: its existing twelve presets plus Secure Development Assurance v0.1.8, enabled at priority 15. Other profiles and global defaults stay unchanged. Published standalone GitHub repositories are the only product sources; installed copies are integrations, not competing sources. Status is read-only; a gate review requires explicit context-specific authority. Installation starts no reviews and grants no human approvals. This is not a C5 attestation, certification, or full readiness check; `Ready` is evidence-context-specific. The project baseline retains its own version. See the integration record relative to the repository root.*

## Governance-Pilot und Liefergrenzen / Governance pilot and delivery boundaries

DE: Das 14er-Profil bindet Security 0.7.4, Architecture 0.6.5 und Intake
Authoring 0.3.10 / Review 0.2.7 / Sequencing 0.2.13. Produkt, Werkzeuge und
Organisation werden regulatorisch getrennt bewertet; Ausbildungszweck und
AI-SBOM N/A ersetzen keine DS-GVO-/KI-VO-Anwendbarkeitspruefung.
Unbekannte Rollen, Jurisdiktionen oder direkte/vertragliche Pflichten bleiben Open.
Die urspruenglichen sechs Presets plus Secure Development Assurance werden
jaehrlich am 3. Oktober geprueft, naechster Termin 2027-10-03 um 10:00
Europe/Berlin. Anlassreviews verschieben den Termin nicht; Automation liest nur.
Stufe A ist Home Baseline/betroffene Home Runtime; B umfasst zwei benannte
public Level-2-Piloten. C (restliche public Level-2-Verbraucher) und D
(restliche Flotte) brauchen jeweils einen separaten Auftrag. Admin-Bypass
ersetzt keine technische Pruefung. Installation startet keine Implementierung.

EN: The fourteen-preset profile binds the five released versions above.
Assess product, tooling and organisation separately; unknown regulatory
scope remains Open. Education and AI-SBOM N/A are not blanket exemptions.
Review the original six presets plus Assurance every 3 October, next
2027-10-03 at 10:00 Europe/Berlin; event reviews do not reset this date.
Automation only reads. Deliver central/runtime first, then two named public
Level-2 pilots. Further public Level-2 consumers and the remaining fleet each
need a separate request. Installation grants no product execution authority.

Evidence: [pilot integration](docs/maintenance/coordinated-governance-oct03.md).
Policy: `docs/maintenance/governance-review-and-rollout.md` in the Level-0 source.

## macOS-CI-Runner / macOS CI runners

Bisherige macOS-14-Jobs verwenden explizit `macos-15`. Die bestehende
Repository-Auswahl fuer Linux-only-Wartungsjobs bleibt erhalten. Ein gruener
CI-Lauf beweist nur die ausgefuehrten Checks, keine Produkt-Plattformabnahme.
Bei Runnerwechseln auch verpflichtende Checknamen und Migrationsvorlagen
pruefen. Betrieb und Pruefgrenzen: `docs/maintenance/macos-runner-migration.md`.

Existing macOS 14 jobs explicitly use `macos-15`. Keep the existing repository
selection for Linux-only maintenance jobs. Successful CI proves the executed
checks, not product platform acceptance. Review required check names and
migration templates whenever runner labels change. See the linked guide.

<!-- learner-a11y-baseline:start -->
## Didaktische und sprachliche Klarheit / Pedagogical and Linguistic Clarity

- Lern- und nutzerseitige Texte stehen auf Deutsch zuerst und Englisch danach und zielen auf CEFR B2.
- Status, Abhängigkeiten, Entscheidungen und nächste Schritte bleiben text-first sowie soweit anwendbar nach WCAG 2.2 Level AA für Braillezeilen, Screenreader und Textbrowser vollständig.
- Öffentliche C#-Typen und -Mitglieder erhalten `<summary>` sowie alle fachlich anwendbaren `<param>`, `<returns>` und `<exception>`; lokale Variablen sind keine XML-Dokumentationsziele.
- CS1591 bleibt eine Build-Schranke und wird nicht global unterdrückt. Änderungen an API-Signaturen oder XML-Kommentaren regenerieren DocFX und lösen denselben textorientierten A11Y-Smoke aus.
- Neue oder geänderte nicht triviale Logik erhält in moderater Dichte zweisprachige Warum-Kommentare zu Entscheidungen, Abwägungen, Grenzen oder historischen Abweichungen.
- Künftige Funktionen und Fehlerkorrekturen belegen Rot → Grün → Aufräumen mit konkreter Testdatei, beobachtbarem roten Fehler, grüner Implementierungsdatei sowie Regression/Aufräumen.
- Reine Governance-/Textarbeit darf TDD und Changed-Code-Coverage nur mit Begründung und Wiedervorlage `N/A` setzen. Bei geändertem Produktcode gelten mindestens 70 Prozent Coverage und das Ziel 80 Prozent.

*Learner-facing and user-facing text is German first and English second at CEFR B2. Status, dependencies, decisions, and next actions remain complete in text and, where applicable, meet WCAG 2.2 Level AA for Braille displays, screen readers, and text browsers. Public C# types and members receive `<summary>` plus every technically applicable `<param>`, `<returns>`, and `<exception>`; local variables are not XML documentation targets. CS1591 remains an unsuppressed build gate, and API-signature or XML-comment changes regenerate DocFX with the same text-oriented accessibility smoke check. New or changed non-trivial logic uses moderate bilingual why-comments. Future features and fixes provide exact red, green, regression, and refactor evidence. Governance-only or text-only work may mark TDD and changed-code coverage `N/A` only with a rationale and re-evaluation trigger; changed product code has a 70% minimum and an 80% target.*

## Hinweise zur Lernenden- und A11Y-Basis / Notes on the Learner and A11Y Baseline

- Verbindliche Zielgruppen ab dem ersten Ausbildungsjahr sind
  Fachinformatiker*innen aller vier Fachrichtungen, IT-System-Elektroniker*innen,
  Kaufleute für IT-System-Management und Kaufleute für Digitalisierungsmanagement
  sowie Entwickelnde ohne vertieftes Governance-Wissen.
- Lern-, Bedien-, Governance- und Spec-Kit-Inhalte stehen auf Deutsch zuerst
  und Englisch danach, verwenden ungefähr CEFR B2 und erklären Fachbegriffe
  beim ersten Auftreten.
- Spec-Kit-Erfahrung wird nicht vorausgesetzt. Befehle, Artefakte, Zustände und
  Übergänge werden beim ersten Gebrauch verständlich eingeführt.
- Abhängigkeiten, Zustände und Entscheidungen erhalten eine vollständige
  textorientierte Erklärung; eine ausschließlich visuelle Darstellung genügt
  nicht.
- `Programmierung #include<everyone>` und WCAG 2.2 Level AA gelten als
  verbindliche Prüfbasis, soweit die Kriterien auf das Artefakt anwendbar sind.

*The binding audience starts in the first training year and includes IT
specialist apprentices across all four disciplines, IT systems electronics
technicians, both IT management occupations and developers without specialist
governance knowledge. Learner, usage,
governance, and Spec Kit content is German-first/English-second at about CEFR
B2, explains technical terms at first use, assumes no prior Spec Kit
experience, and never relies on visual-only dependency, state, or decision
information. `Programmierung #include<everyone>` and WCAG 2.2 Level AA are the
review baseline wherever applicable.*
<!-- learner-a11y-baseline:end -->

<!-- SPECKIT START -->
For additional context about technologies to be used, project structure,
shell commands, and other important information, read the current plan
<!-- SPECKIT END -->

<!-- statistics-profile-2-guidance:begin -->
## Statistikprofil 2 / Statistics Profile 2

- Verbindlich sind `docs/project-statistics.config.json` und der markierte Profil-2-Block in `docs/project-statistics.md`; aktualisieren mit `render-project-statistics.*`.
- Profil 2 zeigt exakte KPI, Artefaktmix, 52-Wochen-Aktivitaet, Wochen- und kumulatives Volumen, belastbare Phasen oder Monatsfallback sowie Speedup-Vergleiche.
- Nur ASCII verwenden: Heatmap `0..4`, `-` fuer noch nicht abgelaufene Tage und Gauges `#`/`.`; jedes Textdiagramm bleibt hoechstens 100 Zeichen breit.
- Jede Grafik braucht genaue Zahlen und eine bilinguale CEFR-B2-Textalternative, Deutsch zuerst und Englisch danach.
- Methodik v2 wertet Git-getrackten Text und Bruttoaenderungen aus Nicht-Merge-Commits aus; Ledger, `STATS.md` und Binaerdaten bleiben ausgeschlossen.
- Referenzen dieses Repositories: `80` Zeilen/Arbeitstag konservativ und `125` Zeilen/Arbeitstag Thorsten-Solo. Speedup bleibt Lieferdichte, keine Stoppuhr- oder Personenbewertung.
- Dieser Vertrag ersetzt aeltere Visualisierungsvorgaben; historische Ledger-Eintraege und archivierte Profil-1-Diagramme bleiben unveraendert.
- Gemeinsame Aenderungen werden synchron in `AGENTS.md`, `CLAUDE.md`, `GEMINI.md`, `.github/copilot-instructions.md` und `.github/agents/copilot-instructions.md` gepflegt.

*Profile 2 is governed by the JSON configuration and generated marker block. Use ASCII `0..4`, `-`, and `#`/`.`, exact values, German-first bilingual CEFR-B2 alternatives, and a 100-character chart limit. Methodology v2 excludes the ledger, `STATS.md`, and binaries. This repository uses manual references of `80` and `125` lines per workday. Speedup describes delivery density, not stopwatch or personal performance. This contract supersedes older visualization rules while retaining historical entries and archived Profile 1 charts.*
<!-- statistics-profile-2-guidance:end -->

<!-- requirements-intake-governance:begin -->
## Requirements- und Intake-Governance / Requirements and Intake Governance

- `Pflichtenheft.md` ist der schlanke Einstieg; verbindliche Reihenfolge und Zustände stehen im Serienmanifest unter `requirements/intakes/series/`.
- Neue oder aktualisierte Lastenhefte gehören nach `requirements/intakes/active/`; abgeschlossene, ersetzte und optionale Intakes werden getrennt archiviert.
- Nur `Eligible` bezeichnet den bevorzugten nächsten Intake. Der Zustand erteilt keine Ausführungs-, Remote- oder Merge-Berechtigung.

*`Pflichtenheft.md` is the slim entry point; binding order and states live in the series manifest. Active, completed, superseded, and optional intakes remain separated. `Eligible` only identifies the preferred next intake and grants no execution, remote, or merge authority.*
<!-- requirements-intake-governance:end -->

<!-- BEGIN spec-kit-diagrams-completion -->
## Mermaid und Spec-Kit-Abschlussbericht / Mermaid and Spec Kit completion report

Neue Lastenhefte enthalten bei hilfreichen Abläufen, Zuständen oder Abhängigkeiten
lesbaren Mermaid-Quelltext im Markdown und eine gleichwertige Textalternative.
Bei einfachen Inhalten die Nichtanwendung kurz begründen. Diagramme bilden die
verbindlichen Text-/Manifestquellen ab; Farbe allein trägt keine Bedeutung.
Nach jedem vollständig abgeschlossenen Spec-Kit-Feature-Lauf den vollständigen
Ergebnisbericht im Chat anzeigen und im Feature-Verzeichnis als
`completion-report.md` versionieren. Einzelne Planungs-/Status-/Review-Kommandos
lösen keinen solchen Bericht aus; blockierte oder pausierte Läufe als
Zwischenbericht kennzeichnen. Vorlage: `.specify/templates/completion-report-template.md`;
Regel: `docs/spec-kit-diagrams-and-completion-reports.md`.
Ergebnis, Tests, Dokumentation, Git-gebundene Umfangszahlen, Verlauf und Restpunkte
belegen. Programmlogik von generierter Evidence, Git-Wandzeit von aktiver
Arbeitszeit und bestandene von ausgefallenen Prüfungen unterscheiden. Finale
Merge-/Sync-Evidence im Chat und bestehenden Closeout-Nachweis ergänzen; keine
zusätzlichen Commits allein für selbstreferenzielle Berichts-/Statistikwerte.
Diese Projektregel und lokale Vorlagen bei Spec-Kit-Updates erhalten.

*New intakes use readable Mermaid Markdown and equivalent text alternatives for
useful workflows, states or dependencies; justify omission for simple content.
Diagrams reflect authoritative text/manifests and never rely on color alone.
After each completed feature run, show the full outcome report in chat and
version completion-report.md in the feature directory using the shared template
and rule above. Individual planning/status/review commands do not trigger it;
paused/blocked runs receive interim reports. Evidence outcomes, tests, docs,
Git-bound counts, delivery history and remaining work. Distinguish code from
volume generated as evidence, elapsed from active time, and passed from failed
checks. Add final merge/sync proof in chat and existing closeout evidence, without
commits solely for self-referential counts or IDs. Preserve local rules/templates
across Spec Kit updates.*
<!-- END spec-kit-diagrams-completion -->

<!-- project-statistics-pilot:begin -->
## Optionaler Statistik-Pilot / Optional Statistics Pilot

Dieses Projekt verwendet im genehmigten Pilotbranch das Profil
`project-statistics-fourteen-governance-presets`: unveraenderte 13er-Basis plus
`project-statistics-governance` v0.1.4, aktiviert mit Prioritaet 90.
Das Preset dient reproduzierbarer Projekttransparenz, nicht der Bewertung von
Lernenden, Qualitaet oder KI-Zeitersparnis. Die bestehende Statistik bleibt
kanonisch. Der kuenftige getrennte Kontext ist `docs/project-statistics-pilot/`;
Referenz-Modellrechnungen bleiben ausgeschaltet. Installation startet weder
Messung noch Spec-Kit-Feature und erteilt keine Commit-/Push-/Mergefreigabe.
Integrationsnachweis: `docs/maintenance/project-statistics-installation-v010.md`
relativ zur Repository-Wurzel. Kein Home-Runtime-Sync und keine globale
Default-Aenderung. Operative Profilzuordnung erst nach gepruefter Lieferung.

This project's approved pilot branch opts into fourteen presets: the unchanged
thirteen-preset base plus Project Statistics Governance v0.1.3 at priority 90.
It provides reproducible project transparency, not learner ratings, quality
scores or AI time-savings measurements. Existing statistics remain canonical;
the future pilot context is separate and reference estimates remain off.
Installation starts no measurement or Spec Kit feature and grants no delivery
authority. See the integration record relative to the repository root.
No Home Runtime sync or global default change; operational assignment follows
reviewed delivery.
<!-- project-statistics-pilot:end -->
