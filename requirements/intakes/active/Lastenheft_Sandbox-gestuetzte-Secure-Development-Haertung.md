<!-- intake-authoring:begin -->
# Lastenheft: Sandbox-gestuetzte Secure-Development-Haertung

## Lesehilfe und Workflow / Reading Guide and Workflow

Deutsch: Grundlegende Tabellen-, Datei- und Tastaturbedienung genügt zum Einstieg;
Spec-Kit- oder Security-Erfahrung wird nicht vorausgesetzt. Ein Intake legt den
Umfang fest. `Specify` erstellt nur `spec.md` (Anforderungen), `plan.md` beschreibt
den Lösungsweg und `tasks.md` einzelne Schritte. `Autonomous` führt einen separat
beauftragten Lauf aus. `LocalImplementation` erlaubt lokale Arbeit, keine
Veröffentlichung. `Eligible` bezeichnet einen Kandidaten, keine Startfreigabe.
Ein Receipt ist ein Herkunftsnachweis; Evidence ein prüfbarer Beleg und ein Hash
ein Inhaltsfingerabdruck. Preflight bedeutet Vorprüfung, Gate eine Prüfschranke.

Deutsch: Secure Coding schützt Codepfade, Secure Architecture ihre
Vertrauensgrenzen (Trust Boundaries). Eine MSL ist eine speichersichere Sprache,
ersetzt aber keine Eingabeprüfung. I/O heißt Ein-/Ausgabe, Auth Anmeldung und
Berechtigung, Crypto Kryptografie. Eine Sandbox begrenzt Prozesszugriffe;
Mounts stellen Host-Dateien bereit, Tokens sind Zugriffsschlüssel, Caches
Zwischenspeicher. SBOM listet Software, AI-SBOM KI-Komponenten, VEX die
Betroffenheit von bekannten Schwachstellen, SLSA Build-Herkunft und Integrität.
NIST SSDF beschreibt sichere Entwicklung, CWE Fehlerarten, STRIDE Bedrohungen,
CAPEC Angriffsmuster, ASVS Web-Prüfungen, Zero Trust Zugriffe ohne stilles
Vertrauen, SAMM Security-Reife und Scorecard OSS-Sicherheitspraktiken. C3A/C5
betreffen Cloud-Autonomie/Nachweise. WCAG AA ist die anwendbare A11Y-Basis;
CEFR B2 bezeichnet verständliche Sprache. CI automatisiert Prüfungen, DocFX
erzeugt Dokumentation, axe prüft Barrieren und lynx liest Seiten als Text.
Ein Lockfile fixiert Abhängigkeiten. Diese Erläuterungen erweitern den Umfang nicht.

English: Basic spreadsheet, file and keyboard use is enough to begin. Prior
Spec Kit/security experience is not assumed. The intake defines scope. Specify
creates only spec.md (requirements), plan.md describes the approach and tasks.md
lists work steps. Autonomous executes a separately requested run.
LocalImplementation permits local work, not publication. Eligible identifies a
candidate, not start permission. A receipt records provenance; evidence is
verifiable proof and a hash a content fingerprint. Preflight means preliminary
check; a gate is a mandatory checkpoint.

English: Secure coding protects code paths, secure architecture their trust
boundaries. An MSL is memory-safe but still needs validation. I/O means input/output,
Auth authentication/authorization and Crypto cryptography. A sandbox limits
process access; mounts expose host files, tokens are access keys and caches
store intermediate results. SBOM inventories software, AI-SBOM AI components,
VEX vulnerability impact and SLSA build origin/integrity. NIST SSDF covers secure
development, CWE weaknesses, STRIDE threats, CAPEC attack patterns, ASVS web
verification, Zero Trust access without implicit trust, SAMM security maturity
and Scorecard OSS practices. C3A/C5 concern cloud autonomy/assurance. WCAG AA is
the applicable A11Y baseline; CEFR B2 the readability level. CI automates checks,
DocFX generates documentation, axe checks accessibility and lynx reads pages as
text. A lockfile fixes dependencies. These explanations add no scope or authority.


**Dokumenttyp:** Spec-Kit Intake / Lastenheft\
**Status:** Vorbereitung fuer spaeteren Spec-Kit-Lauf, kein gestarteter Lauf\
**Projekt:** TinyCalc\
**Zielgruppe:** Fachinformatiker*innen in Ausbildung, Entwickler*innen, Reviewer und KI-Agenten

## Ziel / Goal

Dieses Lastenheft beschreibt einen spaeteren Spec-Kit-Lauf, der prueft, wie dieses Level-2-Repository sicher, nachvollziehbar und ausbildungsgeeignet in oder mit der `absdd-image-sandbox` bearbeitet werden kann. Der Lauf soll die sichere Entwicklung vorbereiten und dokumentieren, aber in diesem Intake noch keine technische Haertung ausfuehren.

*This intake describes a later Spec Kit run that checks how this level-2 repository can be worked on securely, traceably, and in a training-friendly way in or with `absdd-image-sandbox`. The run should prepare and document secure development, but this intake does not execute technical hardening yet.*

## Projektkontext / Project Context

| Feld / Field | Wert / Value |
|---|---|
| Runtime / Language | .NET 10 / C# spreadsheet and Terminal.Gui TUI port; Pascal reference artefacts for behaviour parity |
| Build & Test Baseline | dotnet restore/build/test MicroCalc.sln; xUnit suites; non-interactive TUI smoke mode |
| Docs / A11Y Baseline | DocFX changes require text-oriented A11Y smoke review; documentation and didactic comments stay DE-first/EN-second at CEFR B2 |
| Statistics Baseline | Manual conservative 80; Thorsten-Solo 125 for this Pascal-derived C#/.NET port |
| Agent Surfaces | AGENTS.md, CLAUDE.md, GEMINI.md, .github/copilot-instructions.md, Spec-Kit surfaces |

## Eingaben / Inputs

- Zentrale Richtlinie `docs/secure-development/Richtlinie_Sichere-Entwicklung.md`.
- `docs/secure-development/checklisten/CL_12_Agentische-KI-Sandbox.md`.
- `docs/secure-development/mitgeltende-dokumente/Leitlinie_Sichere-Entwicklungs-Sandbox.md`.
- Vorhandenes `Lastenheft_Secure-Development-Hardening.md` dieses Repositories.
- Die acht Governance-Presets: `security-governance`, `architecture-governance`, `isaqb-architecture-governance`, `a11y-governance`, `cross-platform-governance`, `agent-parity-governance`, `autonomous-run-governance`, `parallel-autonomous-run-governance`.
- Sandbox-Kontext `container-images/absdd-image-sandbox`.

## Scope

- Pruefen, welche Projektpfade in die Sandbox gemountet werden duerfen.
- Pruefen, welche Schreibgrenzen fuer KI-Agenten gelten muessen.
- Pruefen, ob Build, Test, Dokumentation und relevante Smoke-Checks in der Sandbox sinnvoll laufen koennen.
- Pruefen, welche Secrets, Tokens, Nutzerprofile, Caches oder lokalen Tooldaten ausserhalb des Repositories bleiben muessen.
- Pruefen, welche SBOM-, Dependency-, Scan- und Review-Nachweise fuer spaetere Haertung erforderlich sind.
- Pruefen, welche `docs/security/`-Nachweise im spaeteren Lauf neu erstellt oder aktualisiert werden muessen.

## Nicht-Ziele / Non-Goals

- Kein Start eines Spec-Kit-Laufs durch dieses Dokument.
- Keine direkte Codeaenderung.
- Keine automatische technische Haertung.
- Kein automatisches Fuellen von `docs/security/`.
- Keine Aenderung am `absdd-image-sandbox`-Image.
- Keine Behauptung, dass alle MSL-Toolchains in der Sandbox bereits vollstaendig vorhanden sind.

## Anforderungen / Requirements

1. Der spaetere Spec-Kit-Lauf trennt fuer alle einschlaegigen Sandbox- und Secure-Development-Pruefpunkte Anwendbarkeit (`Applicable`, `N/A`, `Open`) und Umsetzung (`Fulfilled`, `Partly Fulfilled`, `Not Fulfilled`, `Not Assessed`).
2. Der Lauf nennt konkrete Evidenzpfade fuer Mounts, Schreibrechte, Agenten-Konfiguration, Build/Test, SBOM/Dependency-Audit und Review.
3. Der Lauf beschreibt, welche Arbeiten sinnvoll in der Sandbox stattfinden und welche lokal oder in CI bleiben muessen.
4. Der Lauf prueft, ob die Sandbox ausreichend sicher ist, ohne die Arbeitsfaehigkeit fuer Auszubildende und Entwickler*innen unnoetig einzuschraenken.
5. Der Lauf nutzt DE/EN, CEFR B2 und WCAG 2.2 AA fuer nutzerseitige Dokumentation.
6. Offene oder nicht vollstaendig erfuellte Punkte erhalten Folgeaktion (`nextAction`), Owner und Termin (`dueAt`); N/A erhaelt Begruendung und Neubewertungstrigger. Nichts wird stillschweigend ausgelassen.

## Akzeptanzkriterien / Acceptance Criteria

- `spec.md`, `plan.md` und `tasks.md` eines spaeteren Spec-Kit-Laufs nennen die Sandbox-Anwendbarkeit und Evidenzpfade.
- `Lastenheft_Secure-Development-Hardening.md` bleibt als fachlicher Vorlaeufer erhalten.
- Keine projektspezifischen Secrets oder privaten Host-Pfade werden in versionierte Dateien uebernommen.
- Der Lauf entscheidet nachvollziehbar, ob und wie `absdd-image-sandbox` fuer dieses Projekt genutzt werden kann.
- Falls ein Pruefpunkt nicht greift, steht `N/A` mit kurzer Begruendung im jeweiligen Artefakt.

## Optimaler Spec-Kit Specify Prompt

```text
Ersetzter Alt-Prompt: speckit-specify Nutze requirements/intakes/active/Lastenheft_Sandbox-gestuetzte-Secure-Development-Haertung.md als verbindliche Eingabedatei. Erstelle die Feature-Spezifikation fuer einen Sandbox-gestuetzten Secure-Development-Haertungslauf im Repository TinyCalc.

Ziel: Pruefe, wie TinyCalc sicher, nachvollziehbar und ausbildungsgeeignet in oder mit der absdd-image-sandbox bearbeitet werden kann. Starte keine Implementierung und fuehre keine technische Haertung aus.

Beruecksichtige:
- Richtlinie Sichere Entwicklung.
- CL_12 Agentische KI in Sandbox-Umgebungen.
- Leitlinie_Sichere-Entwicklungs-Sandbox.md.
- Lastenheft_Secure-Development-Hardening.md dieses Repositories.
- Alle acht Governance-Presets mit auditfaehigen Applicable/N/A/Open-Entscheidungen.
- Projektkontext: .NET 10 / C# spreadsheet and Terminal.Gui TUI port; Pascal reference artefacts for behaviour parity.
- Build/Test-Baseline: dotnet restore/build/test MicroCalc.sln; xUnit suites; non-interactive TUI smoke mode.
- Dokumentations- und A11Y-Basis: DocFX changes require text-oriented A11Y smoke review; documentation and didactic comments stay DE-first/EN-second at CEFR B2.
- Keine Secrets, privaten Host-Pfade oder lokalen Nutzerprofile in versionierte Dateien uebernehmen.
```
## Vollständiger englischer Vertragsblock / Complete English Contract

Deutsch: Die Ergänzung übersetzt den vorhandenen Vertrag ohne technische
Härtung. Die deutschen Regeln und die Serienreihenfolge bleiben verbindlich.

### English: goal, context, inputs and boundaries

Prepare a later run to assess secure, traceable, training-friendly work in/with
absdd-image-sandbox; this intake executes no hardening. TinyCalc uses .NET 10/C#,
Terminal.Gui and Pascal parity sources. Baseline: restore/build/test MicroCalc.sln,
xUnit and non-interactive TUI smoke. DocFX changes require text-oriented A11Y
smoke; docs/didactic comments stay DE-first/EN-second B2. Statistics baselines
are manual 80 and Thorsten-solo 125 lines/workday. Agent surfaces: AGENTS, CLAUDE,
GEMINI, Copilot instructions and Spec Kit.
Inputs: secure-development guideline; checklist CL_12_Agentische-KI-Sandbox.md;
Leitlinie_Sichere-Entwicklungs-Sandbox.md under its mitgeltende-dokumente/;
existing Secure-Development-Hardening intake; eight security/architecture/iSAQB/
A11Y/cross-platform/agent-parity/autonomous/parallel-autonomous presets;
and container-images/absdd-image-sandbox context.
Scope: assess allowed mounts, agent write limits, feasible sandbox build/test/
docs/smoke, secrets/tokens/profiles/caches/tool data that stay outside the repo,
later SBOM/dependency/scan/review proof and future docs/security creation/updates.
Non-goals: no run started by this document, direct code change, automatic
hardening/security-doc filling, sandbox-image change or claim that all MSL
toolchains are already installed.

### English: requirements (same numbering)

1. Separate applicability (Applicable/N/A/Open) from implementation (Fulfilled/Partly Fulfilled/Not Fulfilled/Not Assessed) for all relevant sandbox/security checks.
2. Name concrete mount/permission/agent/build/test/SBOM/dependency/review evidence.
3. Explain what belongs in the sandbox versus local execution or CI.
4. Assess safety without unnecessarily restricting apprentice/developer work.
5. Use DE/EN, B2 and applicable WCAG 2.2 AA for user-facing docs.
6. Record nextAction, owner and dueAt for open or incompletely fulfilled items; N/A requires rationale and a re-evaluation trigger. Never omit an item silently.

### English: acceptance, sequence and prompts

Acceptance: future spec/plan/tasks name sandbox applicability/evidence; existing
Secure Development remains contextual predecessor; no project secrets/private
host paths enter versioned files; the run explains whether/how the sandbox is
usable; every non-applicable item has a short N/A rationale in its artifact.
The manifest retains Sandbox as an independent root; contextual sequencing
does not introduce a new hard dependency.
The superseded old prompt is historical. Canonical Specify prepares only this
specification, considering all stated inputs/baselines and audit-ready
applicability decisions, without implementation/hardening. Separately requested
Autonomous stays LocalImplementation: no remote/PR/merge/bypass/secrets/provider/
follow-up authority is granted.


## Governance-Nachtrag 2026-10-21 / Governance Addendum 2026-10-21

Deutsch: GSDB 3.4.4 und Secure Development Assurance 0.1.5 sind der geprüfte Quellenstand dieses Nachtrags, keine dauerhafte Versionsbindung. Vor einem späteren Lauf Quellen erneut prüfen. Der Kontrollabgleich der 50 Änderungen steht in `docs/maintenance/gsdb-344-intake-control-impact.json`; die aktuelle GSDB-Matrix mit 157 IDs und der RL-SE-Nachweis unter `docs/security/secure-development/2026-10-20-tinycalc-gsdb344/` sind ergänzende, kontextgebundene Belege, keine automatische Erfüllung dieses Intakes.

Deutsch: Anwendbarkeit, Umsetzung und Gate-Ergebnis sind getrennte Angaben. Anwendbarkeit ist `Applicable`, `N/A` oder `Open` (noch ungeklärt); Umsetzung ist `Fulfilled`, `Partly Fulfilled`, `Not Fulfilled` oder `Not Assessed`. Gate-Ergebnisse heißen `Ready`, `ReadyWithAcceptedRisks`, `NeedsRemediation` oder `Blocked`; `Ready` ist mit offenen oder unerfüllten Pflichtpunkten unzulässig. N/A benötigt Grund und Neubewertungstrigger; offene oder unvollständig erfüllte Punkte benötigen Folgeaktion, Owner und Termin. `AlreadySatisfied`/`FollowUp` sind nur Planungshinweise, kein Ersatz für diese Statusachsen oder aktuelle Belege. Historische Ergebnisse bleiben datiert erhalten; zurückgenommene Positivaussagen nicht als aktuelle Erfüllung wiederverwenden. Eine Risikoannahme bleibt menschliche Entscheidung.

English: GSDB 3.4.4 and Secure Development Assurance 0.1.5 are the checked sources for this addendum, not permanent version pins. Recheck sources before a later run. The 50-control impact map is `docs/maintenance/gsdb-344-intake-control-impact.json`; the current 157-ID GSDB matrix and RL-SE evidence under `docs/security/secure-development/2026-10-20-tinycalc-gsdb344/` are context-bound inputs, not automatic fulfilment of this intake.

English: Applicability, implementation and gate outcome are separate. Applicability is Applicable, N/A or Open (undecided); implementation is Fulfilled, Partly Fulfilled, Not Fulfilled or Not Assessed. Gate outcomes are Ready, ReadyWithAcceptedRisks, NeedsRemediation or Blocked; Ready is invalid with open or unfulfilled mandatory items. N/A needs a reason and re-evaluation trigger; open or incomplete items need nextAction, owner and dueAt. AlreadySatisfied/FollowUp are planning labels only. Keep dated historical results and do not reuse withdrawn positive claims as current fulfilment. Risk acceptance remains a human decision.

<!-- intake-authoring:prompts -->
## Kopierbare Spec-Kit-Prompts / Copy-Ready Spec Kit Prompts

Die folgenden Alternativen starten keinen Lauf automatisch. Der autonome
Prompt ist auf `LocalImplementation` begrenzt und erteilt keine Remote-,
PR-, Merge-, Bypass-, Secret- oder Provider-Berechtigung.

*The alternatives below do not start a run automatically. The autonomous
prompt is limited to `LocalImplementation` and grants no remote,
pull-request, merge, bypass, secret, or provider authority.*

### Specify

<!-- spec-kit-command-id: speckit.specify -->
```text
$speckit-specify Use requirements/intakes/active/Lastenheft_Sandbox-gestuetzte-Secure-Development-Haertung.md as the binding intake. Preserve its scope, non-goals, ordering, governance, evidence, and acceptance criteria. Create or update only the matching feature specification. Do not implement, commit, push, create a pull request, merge, or start another feature.
```

### Autonomous

<!-- spec-kit-command-id: speckit.autonomous -->
```text
$speckit-autonomous Execute one complete autonomous Spec Kit run using requirements/intakes/active/Lastenheft_Sandbox-gestuetzte-Secure-Development-Haertung.md as the binding intake. Delivery mode: LocalImplementation. Preserve all scope, ordering, security, accessibility, evidence, and acceptance boundaries. Do not push, create or merge a pull request, use bypass authority, expose secrets, or start a follow-up feature.
```
<!-- intake-authoring:end -->
