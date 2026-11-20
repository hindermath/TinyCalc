# Agentenregeln im Detail / Detailed agent guidance

Beginne mit [AGENTS.md](../AGENTS.md). Die folgenden Abschnitte gelten für die jeweils genannten Einstiege. Pfade in Beispielen beziehen sich auf den Repository-Stamm.

Start with [AGENTS.md](../AGENTS.md). The following sections apply to the named entry files. Paths in examples are relative to the repository root.

## Coding Style & Naming Conventions

Einstiege / Entry files: `AGENTS.md`

Follow `.editorconfig`:
- UTF-8, LF, final newline, trimmed trailing whitespace.
- 4 spaces for `*.cs`; 2 spaces for `*.csproj`, `*.sln`, `*.md`, `*.yml`, `*.yaml`, `*.json`.

C# conventions in this repo:
- `PascalCase` for types and public members.
- `_camelCase` for private readonly fields.
- Keep nullable reference types enabled; avoid disabling warnings without reason.

## Agentische Skriptausfuehrung / Agentic Script Execution

Einstiege / Entry files: `AGENTS.md`, `CLAUDE.md`, `GEMINI.md`, `.github/copilot-instructions.md`, `.github/agents/copilot-instructions.md`

- Vor jeder Automationsaufgabe zuerst das Betriebssystem pruefen. Wenn ein passendes PowerShell-7-Skript oder Cmdlet vorhanden ist und `pwsh` verfuegbar ist, diese Variante bevorzugen. Fuer strukturierte lokale Automationen ist C# ueber `.NET` oder `mono` ein zulaessiger zweiter Weg, wenn Typisierung, Dateiformate oder Wiederverwendbarkeit dadurch klar besser werden. Erst wenn PowerShell oder C# nicht sinnvoll passen, die OS-nahe vorhandene Repo-Variante nutzen, auf macOS/Linux typischerweise Bash. Keine neue Sprache nur aus Bequemlichkeit einfuehren, wenn ein bestehendes Repo-Skript denselben Zweck erfuellt.
- Detect the operating system before each automation task. If a matching PowerShell 7 script or cmdlet exists and `pwsh` is available, prefer that variant. For structured local automation, C# via `.NET` or `mono` is an acceptable second option when type safety, file formats, or reuse clearly benefit from it. Only when PowerShell or C# is not a good fit, use the existing OS-native repository variant, typically Bash on macOS/Linux. Do not introduce a new language merely for convenience when an existing repository script already solves the task.

## Project Statistics

Einstiege / Entry files: `AGENTS.md`

- When shared AI-agent guidance, workflow conventions, or statistics methodology changes, review and update `AGENTS.md`, `CLAUDE.md`, `GEMINI.md`, `.github/copilot-instructions.md`, and `.github/agents/copilot-instructions.md` together when they are affected.
- Shared guidance must not be updated in only one of these files; any intentional agent-specific divergence must be documented in the same change.
- Maintain `docs/project-statistics.md` as the living statistics ledger for the repository.
- Update the file after each completed Spec-Kit implementation phase, after each agent-driven repository change, or when a refresh is explicitly requested.
- Within the `## Fortschreibungsprotokoll` table, keep entries in strict chronological order: oldest entry at the top, newest and most recently added entry at the bottom; entries with the same date keep their insertion order.
- Keep a final top-level `## Gesamtstatistik` block as the last section of `docs/project-statistics.md`; do not append later top-level sections after it.
- Inside that final `## Gesamtstatistik` block, maintain compact ASCII-only trend diagrams directly below the textual overall summary and refresh them with every statistics update; cover at least the artifact mix, the documented branch/phase curves, the documented acceleration factors from agentic AI plus Spec-Kit/SDD support, and a direct comparison between experienced-developer effort, Thorsten-solo effort, and the visible AI-assisted delivery window.
- Keep each short CEFR-B2 explanation directly adjacent to its matching ASCII diagram group.
- When progression across an X-axis improves comprehension, add simple ASCII X/Y charts as a second visualization layer; keep them approximate, readable in plain Markdown, and explained in CEFR-B2 language.
- Keep the statistics section plain-text friendly for Braille displays, screen readers, and text browsers; diagrams and explanations must not rely on color or visual layout alone.
- When DocFX content, documentation navigation, or API presentation changes, validate representative `_site/` pages through a text-oriented review path, preferably with a local Playwright accessibility snapshot.
- Treat every successful `docfx` regeneration as requiring the matching text-oriented A11y smoke check in the same work item.
- Each update must record branch or phase, observable work window, production/test/documentation line counts, main work packages, the conservative manual baseline of 80 manually created lines per workday across code, tests, and documentation, and the repo-specific Thorsten-Solo comparison baseline of 125 lines per workday for this Pascal-derived port.
- When effort is converted into months, use explicit assumptions such as 21.5 workdays per month and, if applicable, 30 vacation days per year through calendar year 2026 and 31 vacation days per year from calendar year 2027 onward under a TVoeD-style 5-day-week calendar.
- When reporting acceleration, compare both manual references against visible Git active days and label the result as a blended repository speedup rather than a stopwatch measurement.
- When hour values are shown, convert the day-based estimates with the TVoeD working-day baseline of `7.8 hours` (`7h 48m`) per day.

## Gemeinsame Governance-Ergaenzung / Shared Governance Addendum

Einstiege / Entry files: `AGENTS.md`, `CLAUDE.md`, `GEMINI.md`, `.github/copilot-instructions.md`, `.github/agents/copilot-instructions.md`

- Alle nutzerseitigen Artefakte muessen barrierefrei gedacht und geprueft werden: CLI-Ausgaben, Dokumentation, HTML, UI und generierte Templates; WCAG 2.2 Level AA ist die Standard-Basis, sobald die Kriterien auf das Artefakt anwendbar sind.
- All user-facing artefacts must be designed and reviewed for accessibility: CLI output, documentation, HTML, UI, and generated templates; WCAG 2.2 Level AA is the default baseline wherever the criteria apply.

- Fuer C#/.NET-Repositories gilt standardmaessig eine Thorsten-Solo-Basis von `125` Zeilen/Arbeitstag, sofern das Repo keinen abweichenden, begruendeten Wert dokumentiert.
- The default Thorsten-solo baseline for C#/.NET repositories is `125` lines/workday unless the repository documents a justified deviation.

## Shared Parent Guidance

Einstiege / Entry files: `AGENTS.md`

- The shared parent file `/Users/thorstenhindermann/RiderProjects/AGENTS.md` intentionally stores only repo-spanning baseline rules.
- Keep repository-specific build, test, workflow, architecture, and feature guidance in this repository's own files; when both layers exist, the repository-local files are the more specific authority.

---

## Memory-Safe Languages (MSL) / Speichersichere Sprachen

Einstiege / Entry files: `AGENTS.md`, `CLAUDE.md`, `GEMINI.md`, `.github/copilot-instructions.md`, `.github/agents/copilot-instructions.md`

- Level-2-Projekte SOLLEN eine speichersichere Sprache (Memory-Safe Language, MSL) als primäre Laufzeit verwenden, wenn die Zielplattform es erlaubt.
- Verbindliche MSL-Erlaubnisliste, Regeln und Begründungspflicht: siehe `constitution.md`, Prinzip XI.
- MSL-Kurzliste: Rust, Swift, C#, F#, Java, Kotlin, Scala, Go, Dart, Python, Ruby, JavaScript, TypeScript, Haskell, OCaml, Erlang, Elixir, Ada, SPARK.
- **Nicht** MSL (Begründung im Level-2-`constitution.md` erforderlich): C, C++, klassisches Objective-C, Assembly, `cc65`-C89, Zig (pre-1.0), Nim (manual), D ohne GC.
- In Nicht-MSL-Repositories (z. B. `C64Projects/cc65`) die im Level-2-`constitution.md` hinterlegte Begründung im Plan- und Task-Kontext erwähnen.
- `speckit.constitution` und `speckit.specify` SOLLEN bei Nicht-MSL-Primärsprache einen **nicht blockierenden** Hinweis ausgeben (Tooling-Aufgabe, separate Umsetzung).
- Änderungen an dieser Empfehlung erfordern ein gemeinsames Update in `constitution.md`, `.specify/memory/constitution.md`, `AGENTS.md`, `CLAUDE.md`, `GEMINI.md`, `.github/copilot-instructions.md` und `.github/agents/copilot-instructions.md`.

*Level-2 projects SHOULD use a memory-safe language (MSL) as their primary runtime when the target platform allows. Authoritative rules: `constitution.md`, Principle XI. MSL short list: Rust, Swift, C#/F#, Java/Kotlin/Scala, Go, Dart, Python, Ruby, JavaScript/TypeScript, Haskell, OCaml, Erlang/Elixir, Ada/SPARK. Non-MSL languages (C, C++, Assembly, `cc65`, Zig pre-1.0, …) require a documented justification in the Level-2 `constitution.md`. In non-MSL repositories (e.g. `C64Projects/cc65`), surface the documented justification in plans and tasks. `speckit.constitution` and `speckit.specify` SHOULD emit a non-blocking advisory warning when the primary language is not an MSL — tracked as a separate tooling task. Changes to this recommendation require a joint update across `constitution.md`, `.specify/memory/constitution.md`, and all four agent guidance files.*

## Sichere Code-Erzeugung / Secure Code Generation (ISO 27001/27002 A.8.28)

Einstiege / Entry files: `AGENTS.md`, `CLAUDE.md`, `GEMINI.md`, `.github/copilot-instructions.md`, `.github/agents/copilot-instructions.md`

- KI-generierter und menschlich geschriebener Code MUSS den etablierten Secure-Coding-Best-Practices der Zielsprache und des Frameworks folgen. LLMs erzeugen nicht zuverlässig sicheren Code; explizite Durchsetzung ist erforderlich.
- Verbindliche Regeln und sprachspezifische Anforderungen: siehe `constitution.md`, Prinzip XII.
- Sprachspezifische Kurzregeln (Detailprofil: `.specify/templates/secure-coding-language-rules-template.md`):
  - **C / C89**: Bounds-Checking, kein `gets()`, kein ungeprueftes `sprintf()`/`strcpy()`, CERT C.
  - **C# / .NET**: parametrisierte Queries, Output-Encoding gegen XSS, Anti-Forgery-Tokens, sichere Deserialisierung, Microsoft Secure Coding Guidelines.
  - **Rust**: `unsafe` isolieren und begruenden, keine Panic-Pfade aus nicht vertrauenswuerdigem Input, Deserialisierung validieren, `cargo audit` oder gleichwertig verwenden.
  - **Go**: HTTP-/Client-Timeouts setzen, `context` propagieren, SSRF pruefen, `crypto/rand` nutzen, `govulncheck` oder gleichwertig verwenden.
  - **Swift**: keine Force-Unwraps auf nicht vertrauenswuerdigen Daten, dekodierte Eingaben validieren, Keychain/CryptoKit/TLS-Defaults nutzen, Datei-URLs einschraenken.
  - **Java / Kotlin**: DTOs validieren, Persistence-Zugriffe parametrisieren, Deserialisierung beschraenken, Auth/CSRF/CORS/Session-Defaults pruefen.
  - **Python**: Boundary-Input validieren, keine unsichere Deserialisierung oder dynamische Ausfuehrung, `subprocess`/Dateipfade einschraenken, Dependency-Audit nutzen.
  - **TypeScript / JavaScript**: Runtime-Input validieren, XSS/Prototype-Pollution/SSRF pruefen, keine dynamische Code-Ausfuehrung, Lockfiles auditieren.
  - **SQL**: nur parametrisierte Statements, kein dynamisches SQL aus nicht vertrauenswuerdigem Input.
  - **Bash**: Variable in Anfuehrungszeichen (`"$var"`), kein `eval` auf nicht vertrauenswuerdigem Input, `--` End-of-Options.
  - **PowerShell**: `Set-StrictMode -Version Latest`, validierte Parameter, kein `Invoke-Expression` auf nicht vertrauenswuerdigem Input.
- Kryptografie: aktuelle Algorithmen (AES-256, RSA >= 3072, SHA-256+, Ed25519); veraltete (MD5, SHA-1 für Signaturen, DES, RC4) nur mit expliziter Risikobegründung.
- Fehlerbehandlung darf keine internen Zustände, Stack-Traces oder Verbindungszeichenketten an Endbenutzer preisgeben.
- Hinzugefügte Abhängigkeiten müssen aktiv gepflegt sein und dürfen keine bekannten kritischen CVEs aufweisen.
- Code-Reviews MÜSSEN eine Sicherheitsperspektive für Eingabeverarbeitung, Authentifizierung, Autorisierung, Kryptografie und Datei-/Netzwerk-I/O enthalten.
- Änderungen an dieser Regel erfordern ein gemeinsames Update in `constitution.md`, `.specify/memory/constitution.md`, `AGENTS.md`, `CLAUDE.md`, `GEMINI.md`, `.github/copilot-instructions.md` und `.github/agents/copilot-instructions.md`.

*AI-generated and human-written code MUST follow the secure-coding best practices of the target language and framework. Authoritative rules: `constitution.md`, Principle XII, and `.specify/templates/secure-coding-language-rules-template.md`. Language-specific short rules cover C/C89, C#/.NET, Rust, Go, Swift, Java/Kotlin, Python, TypeScript/JavaScript, SQL, Bash, and PowerShell. MSL status does not replace secure API, I/O, auth, SQL, crypto, logging, or dependency review. Cryptography: use current algorithms (AES-256, SHA-256+, Ed25519); deprecated (MD5, SHA-1 for signatures, DES, RC4) only with explicit risk acknowledgement. Error handling must not expose internals. Dependencies must have no known critical CVEs. Code reviews must include a security perspective for input handling, auth, crypto, and I/O. Changes require a joint update across `constitution.md`, `.specify/memory/constitution.md`, and all four agent guidance files.*

## Sichere Software-Architektur / Secure Software Architecture (ISO 27001/27002 A.8.27)

Einstiege / Entry files: `AGENTS.md`, `CLAUDE.md`, `GEMINI.md`, `.github/copilot-instructions.md`, `.github/agents/copilot-instructions.md`

- KI-generierte und menschlich geschriebene Software-Architektur MUSS etablierten sicheren Architekturprinzipien folgen. Sicherer Code (Prinzip XII) ohne sichere Architektur reicht nicht aus — beide Ebenen müssen zusammenwirken.
- Verbindliche Regeln und sprachspezifische Architekturvorgaben: siehe `constitution.md`, Prinzip XIII.
- Verbindliche Architekturprinzipien:
  - **Trust Boundaries**: Explizite Vertrauensgrenzen definieren; alle Eingaben an Vertrauensgrenzen validieren und bereinigen.
  - **Defense in Depth**: Mindestens zwei unabhängige Sicherheitsschichten für kritische Assets.
  - **Least Privilege**: Jede Komponente, jeder Dienst und Prozess arbeitet mit minimalen Berechtigungen.
  - **Fail-Safe Defaults**: Zugriff standardmäßig verweigern, explizit gewähren; Fehlerpfade fallen in sicheren Zustand zurück.
  - **Angriffsfläche reduzieren**: Ungenutzte Endpunkte, Dienste und Debug-Funktionen deaktivieren oder entfernen.
  - **Separation of Concerns**: Authentifizierung, Autorisierung, Logging und Eingabevalidierung als Cross-Cutting Concerns implementieren, nicht ad-hoc verstreuen.
  - **Sichere Konfiguration**: Secrets in plattformgeeigneten Secret-Stores (z. B. Azure Key Vault, macOS Keychain), nie im Quellcode oder in Git-tracked Config-Dateien.
  - **Supply-Chain-Sicherheit**: Abhängigkeiten aus verifizierten Registries; Lock-Files committen; verwundbare Abhängigkeiten vor Release ersetzen.
- Änderungen an dieser Regel erfordern ein gemeinsames Update in `constitution.md`, `.specify/memory/constitution.md`, `AGENTS.md`, `CLAUDE.md`, `GEMINI.md`, `.github/copilot-instructions.md` und `.github/agents/copilot-instructions.md`.

*AI-generated and human-written software architecture MUST follow secure-architecture principles. Authoritative rules: `constitution.md`, Principle XIII. Core principles: trust boundaries (validate all input at system boundaries), defense in depth (at least two independent security layers), least privilege (minimum required permissions), fail-safe defaults (deny by default), attack surface reduction (disable unused features), separation of concerns (auth/logging/validation as cross-cutting concerns), secure configuration (secrets in secret stores, never in code or Git), supply-chain security (verified registries, lock files, no known-vulnerable dependencies). Principles XII + XIII together form the complete secure-development approach: XII = tactical code-level security, XIII = strategic architecture-level security. Changes require a joint update across `constitution.md`, `.specify/memory/constitution.md`, and all four agent guidance files.*

## Agentischer Security-Workflow / Agentic Security Workflow

Einstiege / Entry files: `AGENTS.md`, `CLAUDE.md`, `GEMINI.md`, `.github/copilot-instructions.md`, `.github/agents/copilot-instructions.md`

- In `spec.md`, `plan.md` und `tasks.md` die anwendbaren Standards samt Evidenzpfad festhalten.
- Bei Bedrohungsmodellen `STRIDE` als Basis und bei risikoreichen Flows zusätzlich relevante `CAPEC`-Patterns verwenden.
- Bei Web/API-Features den `ASVS`-Level und den Verifikationsumfang in `docs/security/` oder gleichwertiger Projektdokumentation ablegen.
- KI-Nutzung explizit klassifizieren: Entwicklungswerkzeug, keine KI im ausgelieferten/betriebenen System, oder KI-Runtime-/Produktkomponente; `AI-SBOM` entsprechend als `N/A` begründen oder in der Supply-Chain-Evidenz dokumentieren.
- Bei Release-/Artefakt-Arbeit `SBOM`, `AI-SBOM`, `VEX`, Provenance/SLSA-Nachweise und gegebenenfalls `OpenSSF Scorecard` in Release- oder Sicherheitsdokumentation einplanen.
- Bei Architekturänderungen `Zero Trust`-Anwendbarkeit und bei langlebigen Projekten `SAMM`-Folgeaktionen prüfen.
- Default-Evidenzpfad: `docs/security/asvs-verification.md`, `docs/security/supply-chain-evidence.md`, `docs/security/zero-trust-applicability.md`, `docs/security/samm-assessment.md`; Abweichungen nur mit lokal dokumentierter Begründung.

*Capture the applicable standards and the evidence path in `spec.md`, `plan.md`, and `tasks.md`. Use `STRIDE` as the base for threat modeling and add relevant `CAPEC` patterns for the highest-risk flows. For web/API work, record the chosen `ASVS` level and verification scope in `docs/security/` or equivalent project documentation. Classify AI usage as development tooling, absent from the released/operated system, or AI runtime/product component; document `AI-SBOM` as `N/A` or as supply-chain evidence accordingly. For release and artefact work, plan `SBOM`, `AI-SBOM`, `VEX`, provenance/SLSA evidence, and `OpenSSF Scorecard` review where applicable. For architectural changes, evaluate `Zero Trust`; for long-lived projects, consider `OWASP SAMM` follow-up actions. The default evidence path is `docs/security/asvs-verification.md`, `docs/security/supply-chain-evidence.md`, `docs/security/zero-trust-applicability.md`, and `docs/security/samm-assessment.md`, unless the repository documents a justified equivalent location.*

## Spec-Kit-Modell-Routing / Spec Kit Model Routing

Einstiege / Entry files: `AGENTS.md`, `CLAUDE.md`, `GEMINI.md`, `.github/copilot-instructions.md`, `.github/agents/copilot-instructions.md`

- Modellwahl ist operative Agenten-Routing-Guidance, keine Feature-Anforderung. Modellnamen nicht in `spec.md`, `plan.md`, `tasks.md` oder einzelne Feature-Specs schreiben; diese Artefakte muessen reproduzierbar bleiben, auch wenn Modellnamen wechseln oder ein anderer KI-Agent verwendet wird.
- Der jeweilige Agent soll diese Empfehlungen auf seine aktuell verfuegbaren Modelle abbilden; keine feste Anbieter- oder Modellbindung ableiten.
- Fuer Spec-Kit-Spezifikation, Klaerung, Planung, Tasks und Analyse (`/speckit-specify`, `/speckit-clarify`, `/speckit-plan`, `/speckit-tasks`, `/speckit-analyze`; je nach Agent auch `/speckit.specify` usw.) das staerkste verfuegbare Frontier-Reasoning-/Coding-Modell bevorzugen.
- Fuer vollstaendige, lang laufende `/speckit-implement`-Laeufe das staerkste verfuegbare Long-Running-Agent-Modell bevorzugen; das Frontier-Modell nutzen, wenn maximale Urteilsguete wichtiger ist als Laufzeitstabilitaet.
- Fuer fokussierte Reviews oder CI-Fixes ein coding-optimiertes Modell bevorzugen.
- Fuer triviale Bereinigung, Formatierung oder risikoarme mechanische Edits ist ein schnelles kleines Coding-Modell akzeptabel.

*Model choice is operational agent-routing guidance, not a feature requirement. Do not pin model names in `spec.md`, `plan.md`, `tasks.md`, or individual feature specs; those artifacts must stay reproducible even when model names change or another AI agent is used. Each agent should map these recommendations to its currently available models; do not derive a fixed vendor or model requirement. For Spec-Kit specification, clarification, planning, task generation, and analysis (`/speckit-specify`, `/speckit-clarify`, `/speckit-plan`, `/speckit-tasks`, `/speckit-analyze`; or `/speckit.specify` etc. depending on the agent surface), prefer the strongest available frontier reasoning/coding model. For complete long-running `/speckit-implement` runs, prefer the strongest available long-running agent model; use the frontier model when maximum judgment quality is more important than runtime stability. For focused review or CI fixes, prefer a coding-optimized model. For trivial cleanup, formatting, or low-risk mechanical edits, a fast small coding model is acceptable.*

## Spec-Kit-Preset-Pflege / Spec Kit Preset Maintenance

Einstiege / Entry files: `AGENTS.md`

- Standard-Preset-Set: `security-governance` v0.7.5 prio 10, `architecture-governance` v0.6.6 prio 20, `isaqb-architecture-governance` v0.2.6 prio 30, `a11y-governance` v0.4.7 prio 40, `cross-platform-governance` v0.2.6 prio 50, `agent-parity-governance` v0.4.6 prio 60, `autonomous-run-governance` v0.4.12 prio 70, `parallel-autonomous-run-governance` v0.2.13 prio 80.
- `autonomous-run-governance` v0.4.12 prio 70 ist Teil der Standard-Achtermatrix. Ein vollständiger autonomer Lauf bleibt ausdrücklich delegationspflichtig; die Installation allein erteilt weder Ausführungsberechtigung noch Remote-, Merge-, Bypass- oder Provider-Rechte und `LocalImplementation` bleibt Default. Dokumentations-, Status-, Schema- oder Evidence-Änderungen gelten erst dann als testfrei, wenn keine ausführbaren Validatoren die geänderten Pfade, Marker, Schemas oder Zustandswerte konsumieren. Vor autorisierten Commits wird der exakt beabsichtigte Kandidat mit dem Delivery-Set-Validator im Staged-Modus einschließlich exakter Pfad- und Index-Hash-Bindung geprüft; fremde Änderungen bleiben unberührt. Vor einem Merge wird jeder Acceptance-Gate dem tatsächlich ausgeführten Workflow, Job, Runner beziehungsweise der Plattform und dem Befehl zugeordnet; grüne Namen oder ein Bypass ersetzen keinen technischen Nachweis. Bewusst pausierte Läufe werden als `PausedByUser` gespeichert und nur über `speckit.autonomous-resume` fortgesetzt; `speckit.autonomous-stop` wirkt kooperativ am nächsten sicheren Grenzpunkt, und ein gespeicherter Delivery-Modus ist keine aktuelle Berechtigung. Nach Preset- oder Governance-Drift werden neue zwingende Korrektheits-, Sicherheits-, Berechtigungs- und Evidenzregeln minimal mit akzeptierten Plan-, Task- und Checklist-Artefakten abgeglichen; reine Effizienzpräferenzen lösen keine rückwirkende Neugenerierung aus. Die lesbare Skill-Überschrift `Deliver` ist kein Run-State-Wert; für Remote-Closeout gelten ausschließlich `Publish`, `Review` oder `MergeAndSync`.
- `parallel-autonomous-run-governance` v0.2.13 prio 80 ist Teil der Standard-Achtermatrix. Die Installation startet keine Kampagne und erteilt keine zusaetzlichen Remote-, Merge-, Bypass-, Abbruch-, Secret- oder Provider-Rechte. Kampagnen bleiben ausdruecklich delegationspflichtig, verwenden getrennte Worktrees und maximal drei gleichzeitig aktive Worker. Schema 1.1 erlaubt ein `runnerProfile` je Worker mit Kampagnen-Fallback; Modell und Reasoning-Stufe sind optionale, nicht geheime Metadaten und werden ohne Deklaration nicht erraten. Konsolidierung verlangt exakten Head, aktuelle Review- und Check-Evidenz, ist nach Teilmerges fortsetzbar und setzt `Completed` erst nach Synchronisation, manifestdeklarierten idempotenten Post-Merge-Aktionen und Abschlussvalidierung.
- `a11y-governance` v0.4.7 ergänzt didaktische Inline-Code-Kommentar-Governance für neue oder geänderte nicht-triviale Logik.
- `security-governance` v0.7.5 fuehrt `AI-SBOM` weiter als bedingt anwendbare Supply-Chain-Evidenz, ergänzt sprachspezifische Secure-Coding-Profile und ergänzt regulatorische Anwendbarkeit für NIS2, CRA, EU AI Act und DORA. Reine Entwicklungswerkzeug-Nutzung bleibt `N/A`; KI-Runtime-/Produktkomponenten benoetigen Evidenz nach G7/BSI AI-SBOM-Clustern; Beispielprodukt, Entwicklungswerkzeuge und Organisation werden getrennt auf DS-GVO, KI-VO, CRA, NIS2 und DORA geprueft; Ausbildungszweck ist keine pauschale Ausnahme, unbekannte Anwendbarkeit bleibt Open.
- `architecture-governance` v0.6.6 ergänzt `BSI C3A` als bedingte Cloud-Autonomie-Evidenz und `BSI C5` als bedingte Cloud-Compliance-Assurance-Evidenz für Cloud-Service-Auswahl, Provider-Abhängigkeiten, Audit-/Nachweisstand, Shared Responsibility und Betriebsnachweise.
- Alle acht Presets enthalten ab diesem Release-Block audit-ready Spec-Kit-Run-Evidenz: `Applicable` / `N/A` / `Open`, Begründung, Evidenzpfad, Reviewer, Restrisiko und Follow-up muessen im aktuellen Spec-Kit-Lauf dokumentiert werden.
- Die ursprünglichen sechs Presets sind seit 2026-05-04 und `autonomous-run-governance` v0.4.12 ist seit 2026-07-17 im `github/spec-kit` Community-Katalog enthalten und liegen zusätzlich als veröffentlichte Repos unter `https://github.com/hindermath/spec-kit-preset-*`.
- `parallel-autonomous-run-governance` v0.2.13 ist eigenstaendig veroeffentlicht und wurde mit `github/spec-kit#3591` fuer den Community-Katalog eingereicht.
- Registrierte Level-0-, Level-1- und Level-2-Repositories installieren bei vorhandener Spec-Kit-Integration standardmäßig alle acht Presets aus `scripts/config/spec-kit-governance-presets.json`, sofern keine begründete Ausnahme dokumentiert ist.
- Referenz-Rollout für alle acht Presets: `RiderProjects/TinyPl0`, `RiderProjects/TinyCalc`, `RiderProjects/TuiVision`, `RiderProjects/InventarWorkerService`.
- Installation erfolgt bevorzugt mit `install-spec-kit-governance-presets.*` aus der zentralen Matrix; die Skriptlogik enthaelt keine fest eingebauten Versionen. Bei neuen Preset-Releases zuerst die Matrix aktualisieren, dann bestehende Repos bewusst mit `--force` / `-Force` nachziehen.
- Flotten-Rollouts erfassen Level-0, Level-1 und Level-2 explizit. Eine reine Level-2-Registry beweist keine vollstaendige Abdeckung; jeder Zielstatus wird bis Installation, exakter Matrixvalidierung, Commit, Push und Remote-Synchronisation verfolgt.
- Vor dem Staging werden generierte Preset-/Agentenpfade mit dem gesamten Arbeitsbaum abgeglichen. Fremde Aenderungen bleiben unberuehrt; bei Konflikten wird ein sauberer Worktree statt eines erzwungenen Misch-Commits verwendet.
- Aktuelle normative Sechs-/Siebenerangaben werden auf die Achtermatrix migriert. Historische Statistik-, Changelog-, Feldnachweis- und Kompatibilitaetsangaben bleiben erhalten und werden durch einen dokumentierten Allowlist-Scan unterschieden.
- Provider-/Billing-Ablehnung, technischer Gate-Fehler und bestandener Gate sind getrennte Ergebnisse. Bypass oder gruene Sammelnamen ersetzen keinen exakten technischen Nachweis.
- `.specify/presets/` und generierte Agenten-/Command-Dateien committen, wenn Presets Projekt-Policy sind; `.specify/presets/.cache/` nie committen.
- Nach Installation oder Update prüfen: `specify preset list`, mindestens ein `specify preset info <id>`, bei Template-Fragen zusätzlich `specify preset resolve <template>`.
- Die lokalen Arbeitskopien unter `~/SpecKitPresetProjects/` gehören zu den eigenständigen GitHub-Produktquellen; Home Baseline verwaltet Profile und Release-Bezüge, keine kanonischen Preset-Scaffolds.
- Verbesserungen im jeweiligen eigenständigen GitHub-Preset-Repository entwickeln, testen und veröffentlichen; Installationen nur mit ausdrücklichem Rollout-Auftrag nachziehen.
- Bei Änderungen an Preset-Regeln immer prüfen, ob `constitution.md`, `.specify/memory/constitution.md`, `AGENTS.md`, `CLAUDE.md`, `GEMINI.md`, `.github/copilot-instructions.md` und `scripts/templates/*` ebenfalls aktualisiert werden müssen.
- Bei jeder Preset-Version oder Prioritätsänderung zuerst `scripts/config/spec-kit-governance-presets.json` aktualisieren und danach README-Tabellen, Constitution, Agenten-Dateien, `scripts/templates/speckit-workflow-section.md` und Agenten-Templates gemeinsam prüfen.

*Fleet rollouts explicitly cover level 0, level 1, and level 2 and track each
target through installation, exact matrix validation, commit, push, and remote
synchronization. Separate generated paths from unrelated work before staging.
Migrate current normative six/seven references while preserving allowlisted
history and compatibility aliases. Provider refusal, technical gate failure,
and passing evidence are distinct; bypass is not technical proof.*
- Community-/Katalog-Abstimmung läuft über `github/spec-kit#2362`.

*Standard preset set: `security-governance` v0.7.5 prio 10, `architecture-governance` v0.6.6 prio 20, `isaqb-architecture-governance` v0.2.6 prio 30, `a11y-governance` v0.4.7 prio 40, `cross-platform-governance` v0.2.6 prio 50, `agent-parity-governance` v0.4.6 prio 60, `autonomous-run-governance` v0.4.12 prio 70, and `parallel-autonomous-run-governance` v0.2.13 prio 80. `a11y-governance` v0.4.7 adds didactic inline-code-comment governance for new or changed non-trivial logic. `architecture-governance` v0.6.6 adds conditional `BSI C3A` cloud-autonomy evidence and `BSI C5` cloud-compliance assurance evidence for cloud-service selection, provider dependencies, audit/assurance status, shared responsibility, and operational evidence. `security-governance` v0.7.5 keeps conditional `AI-SBOM` evidence, language-specific secure-coding profiles, and regulatory applicability screening for NIS2, CRA, EU AI Act, and DORA: development-tool-only AI usage is `N/A`, AI runtime/product components require G7/BSI AI-SBOM cluster evidence, and private training projects separately assess product, tooling and organisational regulatory `N/A` when no regulated scope exists. All eight presets now include audit-ready Spec-Kit run evidence: `Applicable` / `N/A` / `Open`, rationale, evidence path, reviewer, residual risk, and follow-up must be documented for the current Spec-Kit run. The original six presets have been in the `github/spec-kit` community catalog since 2026-05-04, and `autonomous-run-governance` v0.4.12 was verified there on 2026-07-17. All eight are also published under `https://github.com/hindermath/spec-kit-preset-*`. `parallel-autonomous-run-governance` v0.2.13 was submitted to the community catalog as `github/spec-kit#3591`. Registered level-0, level-1, and level-2 repositories with Spec Kit default to all eight presets from `scripts/config/spec-kit-governance-presets.json` unless a justified exception is documented. Use `install-spec-kit-governance-presets.*` so preset versions stay centralized in the matrix. Commit `.specify/presets/` and generated agent command updates when presets are project policy, but never commit `.specify/presets/.cache/`. Verify installs with `specify preset list`, `specify preset info`, and where relevant `specify preset resolve`. Develop and release presets in their standalone GitHub repositories; update installed integrations only under explicit rollout authority. Preset-rule changes and preset version/priority changes require reviewing the central matrix, constitution, README tables/install snippets, all agent guidance files, and relevant templates together. Community/catalog coordination happens in `github/spec-kit#2362`.*

<!-- EN: AGENTS.md placeholder
[DE-Zusammenfassung: AGENTS.md enthält Anweisungen für den Codex Agenten im home-baseline Repository.]
-->

## Hinweise / Notes

Einstiege / Entry files: `AGENTS.md`

- Diese Datei bleibt bewusst kompakt und ergänzt die projektspezifische Dokumentation.
- This file intentionally stays compact and complements the project-specific documentation.

## Project Overview

Einstiege / Entry files: `CLAUDE.md`

MicroCalc is a modern C#/.NET 10 port of the historical Borland MicroCalc Pascal spreadsheet example (`CALC.PAS`, `CALC.INC`, `CALC.HLP`). It uses Terminal.Gui for its TUI and demonstrates agentic AI-driven legacy porting. The original Pascal files at the repo root serve as behavioral reference for formula semantics, help content, and UI parity.

## Solution Structure

Einstiege / Entry files: `CLAUDE.md`

```text
MicroCalc.sln
src/
  MicroCalc.Core/          # Domain logic — no UI dependencies
    Engine/                # MicroCalcEngine (orchestrates all spreadsheet operations)
    Formula/               # FormulaEvaluator + recursive-descent Parser
    Model/                 # Spreadsheet, Cell, CellAddress, SpreadsheetSpec, CellStatusFlags
    IO/                    # SpreadsheetJsonStorage, SpreadsheetPrinter
  MicroCalc.Tui/           # Terminal.Gui front end
    Program.cs             # Entry point; supports --smoke flag
    Help/                  # HelpDocument (loads CALC.HLP)
    Smoke/                 # TuiSmokeRunner (non-interactive verification)
    Resources/CALC.HLP     # Bundled help asset
tests/
  MicroCalc.Core.Tests/    # xUnit: MicroCalcEngineTests, FormulaGoldenTests
  MicroCalc.Tui.Tests/     # xUnit: TuiSmokeTests
```

**Key constants** (defined in `SpreadsheetSpec`): columns A–G, 21 rows (147 cells), cell input limit 70 chars, default field width 10.

## Build and Test Commands

Einstiege / Entry files: `CLAUDE.md`

```bash
# Restore
dotnet restore MicroCalc.sln

# Build (CI-aligned)
dotnet build MicroCalc.sln --configuration Release --no-restore

# Run all tests (CI-aligned)
dotnet test MicroCalc.sln --configuration Release --no-build

# Run single test class
dotnet test tests/MicroCalc.Core.Tests/MicroCalc.Core.Tests.csproj --configuration Release --filter "FullyQualifiedName~FormulaGoldenTests"

# Start interactive TUI
dotnet run --project src/MicroCalc.Tui/MicroCalc.Tui.csproj

# Smoke run (non-interactive CI check)
dotnet run --no-build --configuration Release --project src/MicroCalc.Tui/MicroCalc.Tui.csproj -- --smoke
```

CI (`.github/workflows/ci.yml`) runs on `main` and all `codex/**` branches using Release configuration.

## Architecture: Core Layer

Einstiege / Entry files: `CLAUDE.md`

`MicroCalcEngine` is the single façade for all spreadsheet operations: `EditCell`, `Recalculate`, `FormatRange`, `Move`, `Clear`, and rendering helpers. It holds a `Spreadsheet` (the cell grid) and a `FormulaEvaluator`.

`FormulaEvaluator` uses a hand-rolled recursive-descent `Parser` (private nested class). Supported syntax:
- Arithmetic: `+`, `-`, `*`, `/`, `^`
- Cell reference: `A1`
- Range sum: `A1>B5` (using `>` as range operator, not `SUM()`)
- Functions: `ABS`, `SQRT`, `SQR`, `SIN`, `COS`, `ARCTAN`, `LN`, `LOG`, `EXP`, `FACT`
- Cyclic reference detection via `HashSet<CellAddress>` per evaluation

`CellStatusFlags` is a `[Flags]` enum controlling cell type (`Text`, `Constant`, `Formula`, `Calculated`, `Locked`, `OverWritten`). Text overflow into adjacent cells is managed explicitly by `MicroCalcEngine`.

Save format is JSON (`.mcalc.json`); no legacy `.MCS` import.

## Branching and PR Conventions

Einstiege / Entry files: `CLAUDE.md`

- All work branches use either the agent branch form `codex/<short-topic>` or the numbered Spec-Kit form `NNN-short-description`.
- When a dedicated feature branch has implemented the requirements of a Lastenheft, rename that file to `Lastenheft_<topic>.<feature-branch>.md` so the delivered scope stays traceable.
- One focused PR per topic; add a PR description file `docs/PR_TEXT_<TOPIC>.md`.
- Tests must pass under `--configuration Release` (not just Debug).
- When a test calls `dotnet run --no-build`, pass the build configuration explicitly.

## Repo Version Scheme

Einstiege / Entry files: `CLAUDE.md`

`Directory.Build.props` carries the repo-wide `Version`, `AssemblyVersion`, and `FileVersion` values for all projects using `Major.Minor.Patch.Build`:
- `Minor` = current Spec-Kit feature/branch number, interpreted numerically as the canonical PR number for versioning (`002` -> `2`) and used immediately even before a GitHub PR exists
- `Patch` = current commit count in that feature/PR branch (after committing the current change)
- `Build` = manual build counter incremented before every `dotnet build` or `dotnet test`

Align the three version fields in `Directory.Build.props` whenever a commit is created or the branch is updated on a numbered Spec-Kit branch, before pushing.

## Code Style

Einstiege / Entry files: `CLAUDE.md`

Governed by `.editorconfig`:
- UTF-8, LF line endings, final newline, no trailing whitespace.
- `*.cs`: 4-space indentation; `*.csproj`, `*.sln`, `*.md`, `*.yml`, `*.json`: 2-space indentation.
- C# conventions: `PascalCase` for types/public members, `_camelCase` for private readonly fields.
- Nullable reference types are enabled; do not suppress without reason.

## Help File Resolution

Einstiege / Entry files: `CLAUDE.md`

`CALC.HLP` must be resolvable at runtime. It lives both at `src/MicroCalc.Tui/Resources/CALC.HLP` (bundled as a resource) and at the repo root (legacy reference). Path changes must preserve both locations.

## Active Technologies

Einstiege / Entry files: `CLAUDE.md`

- C# 14 / .NET 10 + xUnit 2.x (tests); Terminal.Gui (TUI — untouched by this feature) (001-project-context)
- N/A — JSON persistence format unchanged; new functions evaluated at runtime from (001-project-context)

## Recent Changes

Einstiege / Entry files: `CLAUDE.md`

- 001-project-context: Added C# 14 / .NET 10 + xUnit 2.x (tests); Terminal.Gui (TUI — untouched by this feature)

## Project Statistics

Einstiege / Entry files: `CLAUDE.md`

- When shared AI-agent guidance, workflow conventions, or statistics methodology changes, review and update `AGENTS.md`, `CLAUDE.md`, `GEMINI.md`, `.github/copilot-instructions.md`, and `.github/agents/copilot-instructions.md` together when they are affected.
- Shared guidance must not be updated in only one of these files; any intentional agent-specific divergence must be documented in the same change.
- Maintain `docs/project-statistics.md` as the living statistics ledger for the repository.
- Update the file after each completed Spec-Kit implementation phase, after each agent-driven repository change, or when a refresh is explicitly requested.
- Within the `## Fortschreibungsprotokoll` table, keep entries in strict chronological order: oldest entry at the top, newest and most recently added entry at the bottom; entries with the same date keep their insertion order.
- Keep a final top-level `## Gesamtstatistik` block as the last section of `docs/project-statistics.md`; no later top-level section should follow it.
- Inside that final `## Gesamtstatistik` block, maintain compact ASCII-only trend diagrams directly below the textual overall summary and refresh them together with every statistics update; cover at least the artifact mix, the documented branch/phase curves, the documented acceleration factors from agentic AI plus Spec-Kit/SDD support, and a direct comparison between experienced-developer effort, Thorsten-solo effort, and the visible AI-assisted delivery window.
- Keep each short CEFR-B2 explanation directly adjacent to its matching ASCII diagram group.
- When the data benefits from progression across an X-axis, add simple ASCII X/Y charts as a second visualization layer; keep them approximate, readable in plain Markdown, and explained in CEFR-B2 language.
- Keep the statistics section plain-text friendly for Braille displays, screen readers, and text browsers; diagrams and explanations must stay understandable without relying on color or visual layout alone.
- When DocFX content, documentation navigation, or API presentation changes, validate representative `_site/` pages through a text-oriented review path, preferably with a local Playwright accessibility snapshot.
- Treat every successful `docfx` regeneration as requiring the matching text-oriented A11y smoke check in the same work item.
- Each update must capture branch or phase, observable work window, production/test/documentation line counts, main work packages, the conservative manual baseline of 80 manually created lines per workday across code, tests, and documentation, and the repo-specific Thorsten-Solo comparison baseline of 125 lines per workday for this Pascal-derived port.
- When effort is converted into months, use explicit assumptions such as 21.5 workdays per month and, if applicable, 30 vacation days per year through calendar year 2026 and 31 vacation days per year from calendar year 2027 onward under a TVoeD-style 5-day-week calendar.
- When reporting acceleration, compare both manual references against visible Git active days and label the result as a blended repository speedup rather than a stopwatch measurement.
- When hour values are shown, convert the day-based estimates with the TVoeD working-day baseline of `7.8 hours` (`7h 48m`) per day.

## Shared Parent Guidance

Einstiege / Entry files: `CLAUDE.md`

- The shared parent file `/Users/thorstenhindermann/RiderProjects/AGENTS.md` intentionally stores only repo-spanning baseline rules.
- Keep repository-specific build, test, workflow, architecture, and feature guidance in this repository's own files; when both layers exist, the repository-local files are the more specific authority.
<!-- claude-init-done -->

## Spec-Kit-Preset-Pflege / Spec Kit Preset Maintenance

Einstiege / Entry files: `CLAUDE.md`, `GEMINI.md`, `.github/copilot-instructions.md`, `.github/agents/copilot-instructions.md`

- Standard-Preset-Set: `security-governance` v0.7.5 prio 10, `architecture-governance` v0.6.6 prio 20, `isaqb-architecture-governance` v0.2.6 prio 30, `a11y-governance` v0.4.7 prio 40, `cross-platform-governance` v0.2.6 prio 50, `agent-parity-governance` v0.4.6 prio 60, `autonomous-run-governance` v0.4.12 prio 70, `parallel-autonomous-run-governance` v0.2.13 prio 80.
- `autonomous-run-governance` v0.4.12 prio 70 ist Teil der Standard-Achtermatrix. Ein vollständiger autonomer Lauf bleibt ausdrücklich delegationspflichtig; die Installation allein erteilt weder Ausführungsberechtigung noch Remote-, Merge-, Bypass- oder Provider-Rechte und `LocalImplementation` bleibt Default. Dokumentations-, Status-, Schema- oder Evidence-Änderungen gelten erst dann als testfrei, wenn keine ausführbaren Validatoren die geänderten Pfade, Marker, Schemas oder Zustandswerte konsumieren. Vor autorisierten Commits wird der exakt beabsichtigte Kandidat mit dem Delivery-Set-Validator im Staged-Modus einschließlich exakter Pfad- und Index-Hash-Bindung geprüft; fremde Änderungen bleiben unberührt. Vor einem Merge wird jeder Acceptance-Gate dem tatsächlich ausgeführten Workflow, Job, Runner beziehungsweise der Plattform und dem Befehl zugeordnet; grüne Namen oder ein Bypass ersetzen keinen technischen Nachweis. Bewusst pausierte Läufe werden als `PausedByUser` gespeichert und nur über `speckit.autonomous-resume` fortgesetzt; `speckit.autonomous-stop` wirkt kooperativ am nächsten sicheren Grenzpunkt, und ein gespeicherter Delivery-Modus ist keine aktuelle Berechtigung. Nach Preset- oder Governance-Drift werden neue zwingende Korrektheits-, Sicherheits-, Berechtigungs- und Evidenzregeln minimal mit akzeptierten Plan-, Task- und Checklist-Artefakten abgeglichen; reine Effizienzpräferenzen lösen keine rückwirkende Neugenerierung aus. Die lesbare Skill-Überschrift `Deliver` ist kein Run-State-Wert; für Remote-Closeout gelten ausschließlich `Publish`, `Review` oder `MergeAndSync`.
- `parallel-autonomous-run-governance` v0.2.13 prio 80 ist Teil der Standard-Achtermatrix. Die Installation startet keine Kampagne und erteilt keine zusaetzlichen Remote-, Merge-, Bypass-, Abbruch-, Secret- oder Provider-Rechte. Kampagnen bleiben ausdruecklich delegationspflichtig, verwenden getrennte Worktrees und maximal drei gleichzeitig aktive Worker. Schema 1.1 erlaubt ein `runnerProfile` je Worker mit Kampagnen-Fallback; Modell und Reasoning-Stufe sind optionale, nicht geheime Metadaten und werden ohne Deklaration nicht erraten. Konsolidierung verlangt exakten Head, aktuelle Review- und Check-Evidenz, ist nach Teilmerges fortsetzbar und setzt `Completed` erst nach Synchronisation, manifestdeklarierten idempotenten Post-Merge-Aktionen und Abschlussvalidierung.
- `a11y-governance` v0.4.7 ergänzt didaktische Inline-Code-Kommentar-Governance für neue oder geaenderte nicht-triviale Logik.
- `security-governance` v0.7.5 fuehrt `AI-SBOM` weiter als bedingt anwendbare Supply-Chain-Evidenz, ergänzt sprachspezifische Secure-Coding-Profile und ergänzt regulatorische Anwendbarkeit für NIS2, CRA, EU AI Act und DORA. Reine Entwicklungswerkzeug-Nutzung bleibt `N/A`; KI-Runtime-/Produktkomponenten benoetigen Evidenz nach G7/BSI AI-SBOM-Clustern; Beispielprodukt, Entwicklungswerkzeuge und Organisation werden getrennt auf DS-GVO, KI-VO, CRA, NIS2 und DORA geprueft; Ausbildungszweck ist keine pauschale Ausnahme, unbekannte Anwendbarkeit bleibt Open.
- `architecture-governance` v0.6.6 ergänzt `BSI C3A` als bedingte Cloud-Autonomie-Evidenz und `BSI C5` als bedingte Cloud-Compliance-Assurance-Evidenz für Cloud-Service-Auswahl, Provider-Abhängigkeiten, Audit-/Nachweisstand, Shared Responsibility und Betriebsnachweise.
- Alle acht Presets enthalten ab diesem Release-Block audit-ready Spec-Kit-Run-Evidenz: `Applicable` / `N/A` / `Open`, Begründung, Evidenzpfad, Reviewer, Restrisiko und Follow-up muessen im aktuellen Spec-Kit-Lauf dokumentiert werden.
- Die ursprünglichen sechs Presets sind seit 2026-05-04 und `autonomous-run-governance` v0.4.12 ist seit 2026-07-17 im `github/spec-kit` Community-Katalog enthalten und liegen zusätzlich als veröffentlichte Repos unter `https://github.com/hindermath/spec-kit-preset-*`.
- `parallel-autonomous-run-governance` v0.2.13 ist eigenstaendig veroeffentlicht und wurde mit `github/spec-kit#3591` fuer den Community-Katalog eingereicht.
- Registrierte Level-0-, Level-1- und Level-2-Repositories installieren bei vorhandener Spec-Kit-Integration standardmäßig alle acht Presets aus `scripts/config/spec-kit-governance-presets.json`, sofern keine begründete Ausnahme dokumentiert ist.
- Referenz-Rollout für alle acht Presets: `RiderProjects/TinyPl0`, `RiderProjects/TinyCalc`, `RiderProjects/TuiVision`, `RiderProjects/InventarWorkerService`.
- Installation erfolgt bevorzugt mit `install-spec-kit-governance-presets.*` aus der zentralen Matrix; die Skriptlogik enthaelt keine fest eingebauten Versionen. Bei neuen Preset-Releases zuerst die Matrix aktualisieren, dann bestehende Repos bewusst mit `--force` / `-Force` nachziehen.
- Flotten-Rollouts erfassen Level-0, Level-1 und Level-2 explizit. Eine reine Level-2-Registry beweist keine vollstaendige Abdeckung; jeder Zielstatus wird bis Installation, exakter Matrixvalidierung, Commit, Push und Remote-Synchronisation verfolgt.
- Vor dem Staging werden generierte Preset-/Agentenpfade mit dem gesamten Arbeitsbaum abgeglichen. Fremde Aenderungen bleiben unberuehrt; bei Konflikten wird ein sauberer Worktree statt eines erzwungenen Misch-Commits verwendet.
- Aktuelle normative Sechs-/Siebenerangaben werden auf die Achtermatrix migriert. Historische Statistik-, Changelog-, Feldnachweis- und Kompatibilitaetsangaben bleiben erhalten und werden durch einen dokumentierten Allowlist-Scan unterschieden.
- Provider-/Billing-Ablehnung, technischer Gate-Fehler und bestandener Gate sind getrennte Ergebnisse. Bypass oder gruene Sammelnamen ersetzen keinen exakten technischen Nachweis.
- `.specify/presets/` und generierte Agenten-/Command-Dateien committen, wenn Presets Projekt-Policy sind; `.specify/presets/.cache/` nie committen.
- Nach Installation oder Update prüfen: `specify preset list`, mindestens ein `specify preset info <id>`, bei Template-Fragen zusätzlich `specify preset resolve <template>`.
- Die lokalen Arbeitskopien unter `~/SpecKitPresetProjects/` gehören zu den eigenständigen GitHub-Produktquellen; Home Baseline verwaltet Profile und Release-Bezüge, keine kanonischen Preset-Scaffolds.
- Verbesserungen im jeweiligen eigenständigen GitHub-Preset-Repository entwickeln, testen und veröffentlichen; Installationen nur mit ausdrücklichem Rollout-Auftrag nachziehen.
- Bei Änderungen an Preset-Regeln immer prüfen, ob `constitution.md`, `.specify/memory/constitution.md`, `AGENTS.md`, `CLAUDE.md`, `GEMINI.md`, `.github/copilot-instructions.md` und `scripts/templates/*` ebenfalls aktualisiert werden müssen.
- Bei jeder Preset-Version oder Prioritätsänderung zuerst `scripts/config/spec-kit-governance-presets.json` aktualisieren und danach README-Tabellen, Constitution, Agenten-Dateien, `scripts/templates/speckit-workflow-section.md` und Agenten-Templates gemeinsam prüfen.

*Fleet rollouts explicitly cover level 0, level 1, and level 2 and track each
target through installation, exact matrix validation, commit, push, and remote
synchronization. Separate generated paths from unrelated work before staging.
Migrate current normative six/seven references while preserving allowlisted
history and compatibility aliases. Provider refusal, technical gate failure,
and passing evidence are distinct; bypass is not technical proof.*
- Community-/Katalog-Abstimmung läuft über `github/spec-kit#2362`.

*Standard preset set: `security-governance` v0.7.5 prio 10, `architecture-governance` v0.6.6 prio 20, `isaqb-architecture-governance` v0.2.6 prio 30, `a11y-governance` v0.4.7 prio 40, `cross-platform-governance` v0.2.6 prio 50, `agent-parity-governance` v0.4.6 prio 60, `autonomous-run-governance` v0.4.12 prio 70, and `parallel-autonomous-run-governance` v0.2.13 prio 80. `a11y-governance` v0.4.7 adds didactic inline-code-comment governance for new or changed non-trivial logic. `architecture-governance` v0.6.6 adds conditional `BSI C3A` cloud-autonomy evidence and `BSI C5` cloud-compliance assurance evidence for cloud-service selection, provider dependencies, audit/assurance status, shared responsibility, and operational evidence. `security-governance` v0.7.5 keeps conditional `AI-SBOM` evidence, language-specific secure-coding profiles, and regulatory applicability screening for NIS2, CRA, EU AI Act, and DORA: development-tool-only AI usage is `N/A`, AI runtime/product components require G7/BSI AI-SBOM cluster evidence, and training projects assess product, development tooling and organisation separately, including GDPR; unknown applicability remains Open, without blanket educational exemptions. All eight presets now include audit-ready Spec-Kit run evidence: `Applicable` / `N/A` / `Open`, rationale, evidence path, reviewer, residual risk, and follow-up must be documented for the current Spec-Kit run. The original six presets have been in the `github/spec-kit` community catalog since 2026-05-04, and `autonomous-run-governance` v0.4.12 was verified there on 2026-07-17. All eight are also published under `https://github.com/hindermath/spec-kit-preset-*`. `parallel-autonomous-run-governance` v0.2.13 was submitted to the community catalog as `github/spec-kit#3591`. Registered level-0, level-1, and level-2 repositories with Spec Kit default to all eight presets from `scripts/config/spec-kit-governance-presets.json` unless a justified exception is documented. Use `install-spec-kit-governance-presets.*` so preset versions stay centralized in the matrix. Commit `.specify/presets/` and generated agent command updates when presets are project policy, but never commit `.specify/presets/.cache/`. Verify installs with `specify preset list`, `specify preset info`, and where relevant `specify preset resolve`. Develop and release presets in their standalone GitHub repositories; update installed integrations only under explicit rollout authority. Preset-rule changes and preset version/priority changes require reviewing the central matrix, constitution, README tables/install snippets, all agent guidance files, and relevant templates together. Community/catalog coordination happens in `github/spec-kit#2362`.*

<!-- EN: AGENTS.md placeholder
[DE-Zusammenfassung: AGENTS.md enthält Anweisungen für den Codex Agenten im home-baseline Repository.]
-->

## Hinweise / Notes

Einstiege / Entry files: `CLAUDE.md`, `GEMINI.md`

- Diese Datei ergaenzt die projektspezifische Dokumentation mit agentischen Arbeitsregeln.
- This file complements the project-specific documentation with agent-oriented working rules.

## Einordnung / Scope

Einstiege / Entry files: `CLAUDE.md`

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

Einstiege / Entry files: `GEMINI.md`

MicroCalc .NET 10 is a modern C# port of the classic Borland Turbo Pascal MicroCalc spreadsheet application. It serves as a showcase for "agentic" porting, demonstrating how legacy code can be systematically transformed into a modern architecture.

- **Primary Language:** C# (.NET 10)
- **UI Framework:** [Terminal.Gui](https://github.com/gui-cs/Terminal.Gui)
- **Architecture:** Clean separation between Domain Logic (Core) and Presentation (TUI).
- **Legacy Context:** Based on the original `CALC.PAS`, `CALC.INC`, and `CALC.HLP` files.

## Key Commands

Einstiege / Entry files: `GEMINI.md`

### Building the Project
```bash
dotnet restore MicroCalc.sln
dotnet build MicroCalc.sln --configuration Release --no-restore
```

### Running the Application
```bash
dotnet run --project src/MicroCalc.Tui/MicroCalc.Tui.csproj
```

### Running Tests
```bash
dotnet test MicroCalc.sln --configuration Release --no-build
```

### Running Smoke Tests
Executes a non-interactive validation of the TUI components.
```bash
dotnet run --no-build --configuration Release --project src/MicroCalc.Tui/MicroCalc.Tui.csproj -- --smoke
```

## Branching & PR Workflow

Einstiege / Entry files: `GEMINI.md`

- Create working branches either as `codex/<short-topic>` or, for Spec-Kit-driven work, as `NNN-short-description`.
- Do not push directly to `main`; merge via pull request.
- When a dedicated feature branch has implemented the requirements of a Lastenheft, rename that file to `Lastenheft_<Thema>.<feature-branch>.md` so the delivered requirement scope stays traceable in the repository.
- `Directory.Build.props` defines the repo-wide `Version`, `AssemblyVersion`, and `FileVersion` values with `Major.Minor.Patch.Build`; on numbered Spec-Kit branches, `Minor` is the numerically interpreted feature/branch number (`002` -> `2`), `Patch` is the branch commit count after the current commit, and `Build` only increases before `dotnet build` or `dotnet test`.

## Development Conventions

Einstiege / Entry files: `GEMINI.md`

### Architecture & Design
- **Separation of Concerns:** Keep the `MicroCalc.Core` independent of `Terminal.Gui`. The Core should handle all data manipulation and calculations.
- **Formula Engine:** Follow the recursive descent pattern for parsing. Ensure any new functions or operators are added to the evaluator logic and backed by golden tests.
- **Persistence:** Use JSON (`.mcalc.json`) as the primary storage format.

### UI & Interaction
- **Keybindings:** Maintain compatibility with classic navigation (Arrow keys) and the `/` command palette trigger.
- **Help System:** Help content is loaded from `CALC.HLP`. Ensure the `HelpDocument` logic remains robust to file path resolutions.

### Testing
- **Golden Tests:** Use `FormulaGoldenTests.cs` for verifying complex formula calculations against expected outputs.
- **Smoke Tests:** Any major UI refactoring should be verified via the `--smoke` flag.
- **Coverage:** Aim for high coverage in the `Core` project, especially for the formula evaluator.

### Documentation & Language
- Provide documentation and didactic comments bilingually: German first, English second.
- Keep both language blocks at CEFR B2 readability.
- Large normative documents such as `Pflichtenheft*.md` and `Lastenheft*.md` may use a synchronized English sidecar with suffix `.EN.md` instead of an oversized inline-bilingual file; the German version remains canonical unless explicitly marked otherwise.
- Maintain complete XML documentation for affected public APIs (`<summary>`, `<param>`,
  `<returns>`, `<exception>` where applicable).
- Do not suppress CS1591 globally.
- If API signatures or XML comments change, regenerate DocFX output in the same change set.
- New or changed non-trivial logic must be reviewed for didactic inline-comment value when it affects learner understanding or maintainability.
- Inline comments explain why a decision, trade-off, constraint, historical deviation, or proof boundary exists; do not add comments that merely restate obvious code.
- Keep inline-comment intensity moderate: normally 1-3 lines before a non-trivial block, with German-first/English-second CEFR-B2 text for didactic explanation blocks.

## Legacy Reference

Einstiege / Entry files: `GEMINI.md`

The original Pascal files (`CALC.PAS`, `CALC.INC`) and the help file (`CALC.HLP`) are stored in the root directory. These are the source of truth for behavior and feature parity.

## Documentation

Einstiege / Entry files: `GEMINI.md`

- `Pflichtenheft.md`: Canonical requirements index.
- `requirements/baseline/PLAN_MICROCALC_CSHARP_DOTNET10.pre-intake-split.2026-07-26.md`: Historical migration strategy and feature mapping.
- `CONTRIBUTING.md`: Guidelines for contributions.
- `README.md`: General project overview and quick start.

## Project Statistics

Einstiege / Entry files: `GEMINI.md`

- When shared AI-agent guidance, workflow conventions, or statistics methodology changes, review and update `AGENTS.md`, `CLAUDE.md`, `GEMINI.md`, `.github/copilot-instructions.md`, and `.github/agents/copilot-instructions.md` together when they are affected.
- Shared guidance must not be updated in only one of these files; any intentional agent-specific divergence must be documented in the same change.
- Maintain `docs/project-statistics.md` as the living statistics ledger for the repository.
- Update the file after each completed Spec-Kit implementation phase, after each agent-driven repository change, or when a refresh is explicitly requested.
- Within the `## Fortschreibungsprotokoll` table, keep entries in strict chronological order: oldest entry at the top, newest and most recently added entry at the bottom; entries with the same date keep their insertion order.
- Keep a final top-level `## Gesamtstatistik` block as the last section of `docs/project-statistics.md`; do not append later top-level sections after it.
- Inside that final `## Gesamtstatistik` block, maintain compact ASCII-only trend diagrams directly below the textual overall summary and refresh them with every statistics update; cover at least the artifact mix, the documented branch/phase curves, the documented acceleration factors from agentic AI plus Spec-Kit/SDD support, and a direct comparison between experienced-developer effort, Thorsten-solo effort, and the visible AI-assisted delivery window.
- Keep each short CEFR-B2 explanation directly adjacent to its matching ASCII diagram group.
- When progression across an X-axis improves comprehension, add simple ASCII X/Y charts as a second visualization layer; keep them approximate, readable in plain Markdown, and explained in CEFR-B2 language.
- Keep the statistics section plain-text friendly for Braille displays, screen readers, and text browsers; diagrams and explanations must not rely on color or visual layout alone.
- When DocFX content, documentation navigation, or API presentation changes, validate representative `_site/` pages through a text-oriented review path, preferably with a local Playwright accessibility snapshot.
- Treat every successful `docfx` regeneration as requiring the matching text-oriented A11y smoke check in the same work item.
- Each update must capture branch or phase, observable work window, production/test/documentation line counts, main work packages, the conservative manual baseline of 80 manually created lines per workday across code, tests, and documentation, and the repo-specific Thorsten-Solo comparison baseline of 125 lines per workday for this Pascal-derived port.
- When effort is converted into months, use explicit assumptions such as 21.5 workdays per month and, if applicable, 30 vacation days per year through calendar year 2026 and 31 vacation days per year from calendar year 2027 onward under a TVoeD-style 5-day-week calendar.
- When reporting acceleration, compare both manual references against visible Git active days and label the result as a blended repository speedup rather than a stopwatch measurement.
- When hour values are shown, convert the day-based estimates with the TVoeD working-day baseline of `7.8 hours` (`7h 48m`) per day.

## Shared Parent Guidance

Einstiege / Entry files: `GEMINI.md`

- Die gemeinsamen Dateien `/Users/thorstenhindermann/RiderProjects/AGENTS.md` und `/Users/thorstenhindermann/RiderProjects/GEMINI.md` speichern die repo-uebergreifenden Basisregeln.
- Diese Projekt-Datei ist die spezifischere Autoritaet fuer projektspezifische Build-Befehle, Workflows, Architektur und Features.

## Zentrale Verzeichnisse / Key Directories

Einstiege / Entry files: `GEMINI.md`

- `~/scripts/`: Zentrale Automatisierungsskripte (Bootstrap, Secret-Scan, Hook-Installer).
- `~/`: Weitere Workspace-Verzeichnisse werden per `bootstrap-workspace` angelegt und hier eingetragen.
- `~/.gemini/`: Globale Gemini-Konfiguration und persistente Erinnerungen.

## Entwicklungskonventionen / Development Conventions

Einstiege / Entry files: `GEMINI.md`

- **Plattformunabhängigkeit & Dokumentation:** Alle kritischen Skripte müssen sowohl als `.sh` (Bash) als auch als `.ps1` (PowerShell Core) vorliegen. Jedes Skript erfordert eine Unix man-Page (`.sh`, in `docs/man/`), eine vollständige PowerShell-Hilfe (`.ps1`) und muss zusätzlich als PowerShell Cmdlet (Advanced Function) im `Verb-Noun` Format verfügbar sein.
- **Sicherheits-Standard:** Jedes Projekt muss über einen `pre-push` Hook verfügen, der Secret-Scanning in Agenten-Verzeichnissen durchführt.
- **Git-Strategie:** Keine Submodules; stattdessen werden Sub-Repos durch die Baseline-Skripte in der `.gitignore` des übergeordneten Workspaces erfasst.

## Projektstatus / Repository Status

Einstiege / Entry files: `GEMINI.md`

- **Sichtbarkeit:** Öffentliches **Template-Repo** — über „Use this template" nutzbar; kein Fork, keine History-Übertragung
- **Lizenz:** MIT
- **Branch-Schutz:** PR-Pflicht auf `main`; Admin (Eigentümer) kann direkt pushen (`enforce_admins: false`)
- **CI-Runner:** Ubuntu 22.04 · macOS 15 · Windows 2022
- **Compliance-Score:** 100 % (25/25 Checks)

## Bekannte Fallstricke / Known Pitfalls

Einstiege / Entry files: `GEMINI.md`

### `gh auth login --web` bleibt hängen / `gh auth login --web` Hangs
Browser-Callback kommt in Hintergrundprozessen nicht an.
In **interaktivem Terminal** ausführen.

### `glab auth login --web` bleibt hängen / `glab auth login --web` Hangs
Browser-Callback kommt in Hintergrundprozessen nicht an.
In **interaktivem Terminal** ausführen.

### `gh`-Keyring ungültig (Windows) / `gh` Keyring Invalid (Windows)
Windows Credential Store korrupt.
`gh auth logout` + neu anmelden; danach `gh auth setup-git`.

### `ssh-agent` startet nicht (Windows) / `ssh-agent` Does Not Start (Windows)
Service deaktiviert, Admin nötig.
HTTPS + `gh auth setup-git` verwenden.

### `CursorPosition`-Fehler in PS-Subprocess / `CursorPosition` Error in PowerShell Subprocess
PowerShell-Profil (Oh-My-Posh) lädt im Subprozess.
`-NoProfile` zu `pwsh -File`-Aufrufen hinzufügen.

### `migrate-workspace.*` läuft parallel in Timeouts / `migrate-workspace.*` Times Out in Parallel
Jeder Migrationslauf startet `init-stats.*` und aktualisiert die Level-0/1/2-Statistiken global.
Mehrere parallele Läufe können sich gegenseitig ausbremsen. Erst Vorschau (`-WhatIf`/`--dry-run`),
dann echte Migrationen seriell pro Workspace mit längerem Timeout ausführen.

### `git pull` meldet divergierende Branches (Linux) / `git pull` Reports Divergent Branches (Linux)
Kein globales Rebase-Setup.
`git config --global pull.rebase true`.

### Push rejected: `fetch first` / Push Rejected: `fetch first`
Remote ist neuer als lokal.
`git pull --rebase --autostash && git push`.

### Test-Skript blockiert Pull / Test Script Blocks Pull
Output-Datei wird vor `pull` geschrieben.
`git pull --rebase --autostash origin main`.

### Lastenheft nach Feature-Abschluss nicht umbenannt / Lastenheft Not Renamed After Feature Completion
`tasks.md` enthielt keinen Rename-Schritt (seit constitution v1.1.1 behoben).
`bash scripts/rename-lastenheft.sh <LH-Datei> <branch-name>` oder `pwsh scripts/rename-lastenheft.ps1 -File <LH-Datei> -BranchName <branch-name>`.

### Windows: `$env:HOME` ist leer, nicht `$null` / Windows: `$env:HOME` Is Empty, Not `$null`
```powershell
# Falsch (??-Operator fängt '' nicht ab):
$home = $env:HOME ?? $env:USERPROFILE
# Richtig:
$home = if ($env:HOME) { $env:HOME } else { $env:USERPROFILE }
```

### CI: Scanner-Verzeichnis / CI: Scanner Directory
```bash
# Falsch (CWD = Repo-Root, Dateien nicht gefunden):
bash scripts/check-homogeneity.sh home-baseline
# Richtig (aus dem Parent heraus):
cd "$(dirname "$GITHUB_WORKSPACE")"
bash "$(basename "$GITHUB_WORKSPACE")/scripts/check-homogeneity.sh" "$(basename "$GITHUB_WORKSPACE")"
```

### `.gitignore`-Whitelist / `.gitignore` Whitelist
Jede neue Datei muss explizit als `!DATEINAME` in `.gitignore` eingetragen werden, sonst wird `git add` lautlos ignoriert (z. B. `LICENSE`).

### `bootstrap-workspace`: GitHub-Username / `bootstrap-workspace`: GitHub Username
Früher hardcodiert. Jetzt dynamisch:
```bash
GH_USER=$(gh api user --jq '.login')
```

### Doppelte Überschriften in TOC / Duplicate heading anchors
Gleiche Heading-Texte → GitHub hängt `-1`, `-2` an. TOC-Links für zweite Vorkommen müssen den Suffix enthalten.

### Pflicht für bilinguale Headings / Bilingual Heading Requirement
Format: `## DE / EN` — immer. Nur-Deutsch verletzt WCAG 2.4.6 und bilinguales Konsistenzgebot.
Ausnahme: Eigennamen wie `### Homogeneity Guardian` oder `### Compliance-Check`.

### Code-Blöcke immer mit Sprach-Tag (WCAG 4.1.1) / Code Blocks Must Always Have a Language Tag (WCAG 4.1.1)
Bare ` ``` ` ohne Sprache ist ein A11Y-Fehler. Für ASCII/Dialog/Verzeichnisse: ` ```text `.

### CHANGELOG.md hinzugefügt / CHANGELOG.md Added
Dokumentiert Versionen v0.1.0–v0.4.0. Muss in `.gitignore`-Whitelist (`!CHANGELOG.md`) eingetragen sein.

### ASCII-Box-Drawing-Tabellen: Zeilenbreite / ASCII Box-Drawing Tables: Line Width
Alle Zeilen einer `text`-Code-Block-Tabelle müssen exakt gleich breit sein. Ein überzähliges Leerzeichen vor dem schließenden `│` macht die Zeile 1 Zeichen zu lang.
Prüfen: PowerShell `$line.Length` oder `wc -m` (Bash) für jede Rahmen-Zeile.

### Spec-Kit-Verzeichnis initialisieren / Initialize the Spec-Kit Directory
Nie manuell aus `~/home-baseline-tmp/` kopieren. Stattdessen:
`specify init --here --force --integration {agent}` je Agent für `agy`, `opencode`, `claude`, `copilot` und `codex` ausführen.

### Spec-Kit-Updates repo-weit / Repository-Wide Spec-Kit Updates
Fuer Level 0, Level 1 und Level 2 nicht mehr per Hand in jedem Repo nachziehen.
Stattdessen zuerst `bash scripts/update-spec-kit.sh --dry-run` bzw.
`pwsh scripts/update-spec-kit.ps1 -WhatIf` ausfuehren, danach bei Bedarf
`--commit --push` / `-Commit -Push`.

Das Skript erkennt neue Repos dynamisch ueber `.git` plus `.specify/`, sichert
`.specify/memory/constitution.md`, legt die lokalen Governance-Templates wieder
auf und nimmt `RiderProjects/TuiVision` normal mit. OpenCode wird nur ueber
`.opencode/command/*.md` getrackt; `.opencode`-Caches, Sessions, Logs,
Credentials und lokale Abhaengigkeiten bleiben ausgeschlossen.

Die Standard-Template-Quelle ist das oeffentliche `home-baseline`-Repo, aus dem
das Skript laeuft. Private Repos wie `RiderProjects/TuiVision` duerfen nur
bewusst mit `--template-source` / `-TemplateSource` als Override genutzt werden.

### GitHub-Housekeeping: Archivierung, Sichtbarkeit, Forks und Stars / GitHub Housekeeping: Archiving, Visibility, Forks, and Stars
`archived` bedeutet bei GitHub nur read-only, nicht unsichtbar. Public archived Repos bleiben ohne Anmeldung sichtbar.
Archivierte Repos sind API-seitig read-only; Sichtbarkeit ändern geht deshalb nur über:
`archived=false` → `private=true` → `archived=true`.

Öffentliche Forks lassen sich nicht einfach auf private setzen. Optionen: öffentlich archiviert lassen, löschen, oder als private Mirror-Repos neu anlegen. Vor Löschungen die Repo-Liste eng festlegen; `gh repo delete` benötigt ggf. `gh auth refresh -h github.com -s delete_repo`.

Für Aktivitätsbewertungen `pushedAt` statt `updatedAt` verwenden, weil `updatedAt` durch Metadatenänderungen springt. Stars sind kontogebundene Metadaten und können über `DELETE /user/starred/{owner}/{repo}` entfernt werden; danach `user/starred` gegenprüfen.

## Architecture

Einstiege / Entry files: `.github/copilot-instructions.md`, `.github/agents/copilot-instructions.md`

Two production projects plus two test projects, strict dependency direction:
`MicroCalc.Core` has no UI dependency; `MicroCalc.Tui` references Core.

**`MicroCalc.Core`** – all spreadsheet logic:
- `Engine/MicroCalcEngine` – single façade for all operations (`EditCell`, `Recalculate`, `FormatRange`, `Move`, `Clear`). Call `EditCell` to store a value; it triggers `Recalculate` automatically when `AutoCalc` is on.
- `Formula/FormulaEvaluator` – evaluates an expression string against a `Spreadsheet`. Internally delegates to a private `Parser` (recursive-descent). Cyclic reference detection uses a `HashSet<CellAddress>` per evaluation call.
- `Model/Spreadsheet` + `Model/Cell` – the data grid. Grid bounds are fixed constants in `SpreadsheetSpec` (columns A–G, 21 rows).
- `IO/SpreadsheetJsonStorage` – save/load to `.mcalc.json`. No legacy `.MCS` format.

**`MicroCalc.Tui`** – Terminal.Gui front end. `Program.cs` is the entry point; it checks for `--smoke` and delegates to `TuiSmokeRunner` before touching Terminal.Gui.

**Legacy reference files** at repo root (`CALC.PAS`, `CALC.INC`, `CALC.HLP`) are Pascal source and help content kept for behavior parity; they are not compiled.

## Key Conventions

Einstiege / Entry files: `.github/copilot-instructions.md`, `.github/agents/copilot-instructions.md`

### Formula syntax (non-obvious)
- Range sum uses `>` as the operator: `A1>B5` means "sum A1 through B5", not a comparison.
- No `SUM()` function — use the `A1>B5` syntax instead.
- Supported functions: `ABS`, `SQRT`, `SQR`, `SIN`, `COS`, `ARCTAN`, `LN`, `LOG`, `EXP`, `FACT`, `MIN`, `MAX`, `AVERAGE`, `COUNT`, `ROUND`, `IF`. Function names are case-insensitive.
- `IF(condition,trueVal,falseVal)` — conditions use `>` as greater-than comparison inside `IF`. Outside `IF`, `A1>B5` is a range sum, not a comparison.
- `ROUND(value,decimals)` — rounds to the given number of decimal places.
- Error messages from the parser are in German (the codebase language for user-facing strings).

### `CellStatusFlags` is a `[Flags]` enum — check with `HasFlag`
- `Text` = plain string cell
- `Constant` = numeric or expression cell (stored value)
- `Formula` = contains a cell reference or range (recalculated on `Recalculate`)
- `Calculated` = formula has been evaluated and has a current value
- `OverWritten` = cell is visually occupied by text overflow from the cell to its left
- `Locked` = cell blocked because the preceding cell uses an expanded field width

A cell can simultaneously be `Constant | Formula` (a formula that has been evaluated).

### Text overflow
When a text cell's content exceeds `DefaultFieldWidth` (10), `MicroCalcEngine.ApplyTextOverflow` marks adjacent right-hand cells as `OverWritten`. `ClearOverwrittenTrail` reverses this when the source cell is edited. Always call through `EditCell`, not by mutating `Cell` directly.

### `SpreadsheetSpec` constants
Fixed grid: columns `A`–`G` (7 columns), 21 rows, 147 total cells. Cell input capped at 70 characters. Default field width 10, default decimals 2. All bounds checks go through `SpreadsheetSpec.IsColumnInRange` / `IsRowInRange`.

### Testing pattern
- `FormulaGoldenTests` — `[Theory]`/`[MemberData]` table of expression → expected value. Add new cases here for any formula behaviour change.
- `MicroCalcEngineTests` — integration-style tests through the engine façade.
- `TuiSmokeTests` — calls `TuiSmokeRunner.Run(...)` which exercises help loading and basic rendering without a Terminal.Gui window.

### Branching & PRs
- Work branches: `codex/<short-topic>` or numbered Spec-Kit branches `NNN-short-description`
- When a dedicated feature branch has implemented the requirements of a Lastenheft, rename that file to `Lastenheft_<topic>.<feature-branch>.md` so the delivered scope stays traceable.
- Add a PR description file: `docs/PR_TEXT_<TOPIC>.md`
- Commits follow Conventional Commit prefixes: `feat:`, `fix:`, `test:`, `docs:`, `chore:`

### Documentation & language
- All code comments and documentation must be **bilingual: German block first, English block second**, both at CEFR B2 readability.
- Large normative documents such as `Pflichtenheft*.md` and `Lastenheft*.md` may use a synchronized English sidecar with suffix `.EN.md` instead of an oversized inline-bilingual file; the German version remains canonical unless explicitly marked otherwise.
- Public APIs require complete XML docs (`<summary>`, `<param>`, `<returns>`, `<exception>` where applicable). Do not suppress CS1591 globally — missing XML docs are treated as build errors.
- When API signatures or XML comments change, regenerate DocFX output in the same PR.
- New or changed non-trivial logic must be reviewed for didactic inline-comment value when it affects learner understanding or maintainability.
- Inline comments explain why a decision, trade-off, constraint, historical deviation, or proof boundary exists; do not add comments that merely restate obvious code.
- Keep inline-comment intensity moderate: normally 1-3 lines before a non-trivial block, with German-first/English-second CEFR-B2 text for didactic explanation blocks.

### TDD expectation
- For behavior changes, write tests first and make them fail (RED) before implementation.
- Implement against failing tests, then verify GREEN in `Release` configuration.

### Code style (`.editorconfig`)
- `*.cs`: 4-space indent; `*.csproj`, `*.sln`, `*.md`, `*.yml`, `*.json`: 2-space indent
- UTF-8, LF line endings, final newline, no trailing whitespace
- `PascalCase` for types and public members; `_camelCase` for private readonly fields
- Nullable reference types enabled — do not suppress without reason

## Project Statistics

Einstiege / Entry files: `.github/copilot-instructions.md`, `.github/agents/copilot-instructions.md`

- When shared AI-agent guidance, workflow conventions, or statistics methodology changes, review and update `AGENTS.md`, `CLAUDE.md`, `GEMINI.md`, `.github/copilot-instructions.md`, and `.github/agents/copilot-instructions.md` together when they are affected.
- Shared guidance must not be updated in only one of these files; any intentional agent-specific divergence must be documented in the same change.
- Maintain `docs/project-statistics.md` as the living statistics ledger for the repository.
- Update the file after each completed Spec-Kit implementation phase, after each agent-driven repository change, or when a refresh is explicitly requested.
- Within the `## Fortschreibungsprotokoll` table, keep entries in strict chronological order: oldest entry at the top, newest and most recently added entry at the bottom; entries with the same date keep their insertion order.
- Keep a final top-level `## Gesamtstatistik` block as the last section of `docs/project-statistics.md`; do not append later top-level sections after it.
- Inside that final `## Gesamtstatistik` block, maintain compact ASCII-only trend diagrams directly below the textual overall summary and refresh them with every statistics update; cover at least the artifact mix, the documented branch/phase curves, the documented acceleration factors from agentic AI plus Spec-Kit/SDD support, and a direct comparison between experienced-developer effort, Thorsten-solo effort, and the visible AI-assisted delivery window.
- Keep each short CEFR-B2 explanatory text directly adjacent to its matching ASCII diagram group.
- When the data benefits from progression across an X-axis, add simple ASCII X/Y charts as a second visualization layer; keep them approximate, readable in plain Markdown, and explained in CEFR-B2 language.
- Keep the statistics section plain-text friendly for Braille displays, screen readers, and text browsers; diagrams and explanations must stay understandable without relying on color or visual layout alone.
- When DocFX content, documentation navigation, or API presentation changes, validate representative `_site/` pages through a text-oriented review path, preferably with a local Playwright accessibility snapshot.
- Treat every successful `docfx` regeneration as requiring the matching text-oriented A11y smoke check in the same work item.
- Each update must capture branch or phase, observable work window, production/test/documentation line counts, main work packages, the conservative manual baseline of 80 manually created lines per workday across code, tests, and documentation, and the repo-specific Thorsten-Solo comparison baseline of 125 lines per workday for this Pascal-derived port.
- When effort is converted into months, use explicit assumptions such as 21.5 workdays per month and, if applicable, 30 vacation days per year through calendar year 2026 and 31 vacation days per year from calendar year 2027 onward under a TVoeD-style 5-day-week calendar.
- When reporting acceleration, compare both manual references against visible Git active days and label the result as a blended repository speedup rather than a stopwatch measurement.
- When hour values are shown, convert the day-based estimates with the TVoeD working-day baseline of `7.8 hours` (`7h 48m`) per day.

## Workspace Baseline (vollständig aus `RiderProjects/.github/copilot-instructions.md`)

Einstiege / Entry files: `.github/copilot-instructions.md`, `.github/agents/copilot-instructions.md`

Diese Regeln gelten für alle Repositories in diesem Workspace. Projektspezifische Regeln in dieser Datei haben Vorrang, wenn sie konkreter sind. GitHub Copilot liest keine übergeordneten `copilot-instructions.md`-Dateien automatisch; daher sind die Workspace-Regeln hier vollständig eingebettet.

### Dokumentation
- Leitprinzip: `Programmierung #include<everyone>` — Diese Lernbeispiele richten sich an Azubis (Fachinformatiker AE/SI), die auf Deutsch und Englisch arbeiten, **sowie** an sehbehinderte Lernende, die Braille-Displays, Screen-Reader oder Textbrowser nutzen. Barrierefreiheit ist Pflichtanforderung, kein Nice-to-have. / *These learning examples target apprentices working in German and English, **and** visually impaired learners using Braille displays, screen readers, or text browsers. Accessibility is mandatory.*
- Deutsch und Englisch zielen beide auf CEFR-B2-Lesbarkeit; Reihenfolge: **Deutsch zuerst, Englisch danach**.
- **Die deutsche Fassung ist kanonisch**, außer dieses Repository markiert eine andere Sprache explizit als primär.
- Große normative Dokumente (`Pflichtenheft*.md`, `Lastenheft*.md`) verwenden eine synchronisierte `.EN.md`-Sidecar-Datei statt einer überlangen Inline-Zweisprachigkeit.
- Bilinguales CEFR-B2-Deliverable ist ein **formales Abnahmekriterium** für learner-facing Dokumentation und aktive Anforderungsartefakte.

### Barrierefreiheit (Accessibility)
- Generiertes HTML-Dokumentation muss **WCAG 2.2 Level AA** erfüllen.
- Semantische Überschriften, Listen, Tabellen und ASCII/Text-First-Diagramme bevorzugen.
- **Wesentliche Bedeutung NICHT nur durch Farbe, Layout oder Maus-only-Affordances kodieren.**
- Guides, Statistiken, Beispiele und generierte API-Dokumentation müssen in text-first Assistive-Setups lesbar bleiben.
- Der dokumentierte **A11Y-Nachweispfad ist ein formales Abnahmekriterium** für learner-facing Dokumentation und aktive Anforderungsartefakte.

### DocFX-Review-Regel
- Wenn ein Repository Dokumentation mit `docfx` neu generiert, muss **dasselbe Work-Item** auch den passenden A11Y-Review ausführen.
- Bevorzugtes Toolchain: **Node 24 LTS**, **`npm`**, **`@axe-core/playwright`**, **`lynx`**.
- Playwright + axe für automatisierte Smoke-Checks verwenden; `lynx` als zusätzlichen Textbrowser-Prüfpfad.

### Statistik-Ledger
- `docs/project-statistics.md` als lebendes Ledger pflegen, wenn diese Datei im Repository existiert.
- Den abschließenden Top-Level-Block `## Gesamtstatistik` als letzten Abschnitt halten.
- ASCII-Diagramme textbrowserfreundlich halten und **kurze CEFR-B2-Erklärungen direkt neben** das jeweilige Diagramm platzieren.
- Dokumentierte **Beschleunigungsfaktoren aus Agentic AI plus Spec-Kit/SDD** einschließen sowie einen Vergleich zwischen experienced-developer-Aufwand, Thorsten-solo-Aufwand und dem sichtbaren AI-assisted-Delivery-Fenster (sofern dieses Repository diese Metriken führt).

### Änderungsdisziplin
- **Nicht davon ausgehen**, dass eine Cross-Repository-Regel projekt-spezifische Build-, Test- oder Release-Anforderungen ersetzt.
- Wenn eine gemeinsame Regel sich ändert und mehrere Repositories betroffen sind, lokale Projektguidance **und** das jeweilige Statistik-Ledger gemeinsam aktualisieren.
- `CODEX_CROSS_REPO_PROMPTS.md` synchron halten, wenn sich übergreifende Prompting-Guidance ändert, damit der wiederverwendbare Prompt mit der aktuellen Baseline übereinstimmt.

## Allgemeine Architekturdokumentation / General Architecture Documentation

Einstiege / Entry files: `.github/copilot-instructions.md`, `.github/agents/copilot-instructions.md`

- Bei architekturrelevanten Änderungen MUSS iSAQB/arc42-Evidenz geprüft werden: Architekturziele, Kontextsicht, Bausteinsicht, Laufzeitsicht, Deployment-Sicht, Qualitätszenarien, ADRs, Architekturrisiken und technische Schulden.
- Standardpfad: `docs/architecture/`; ADRs als einzelne Dateien in `docs/architecture/adr/`.
- Verwende die installierten Templates `architecture-vision-template.md`, `context-view-template.md`, `building-block-view-template.md`, `runtime-view-template.md`, `deployment-view-template.md`, `quality-scenarios-template.md`, `architecture-decision-template.md` und `architecture-risks-template.md`, sofern anwendbar.
- Nichtanwendbarkeit immer als `N/A` mit kurzer Begründung dokumentieren; keine stillschweigende Auslassung.

*Architecture-relevant changes MUST check iSAQB/arc42 evidence: architecture goals, context view, building-block view, runtime view, deployment view, quality scenarios, ADRs, architecture risks, and technical debt. Default path: `docs/architecture/`; ADRs live in `docs/architecture/adr/`. Use the installed architecture templates where applicable. Record non-applicability as `N/A` with justification rather than omitting it silently.*
