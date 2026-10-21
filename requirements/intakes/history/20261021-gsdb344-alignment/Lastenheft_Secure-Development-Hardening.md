<!-- intake-authoring:begin -->
# Lastenheft: Secure-Development-Hardening

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


**Repository:** TinyCalc\
**Dokumenttyp:** Spec-Kit Intake / Lastenheft\
**Status:** vorbereitet fuer separaten Spec-Kit-Haertungslauf\
**Stand:** 2026-06-17

## 1. Zweck

Dieses Lastenheft beschreibt den Eingangsumfang fuer einen spaeteren Spec-Kit-Haertungslauf. Ziel ist zu pruefen, ob TinyCalc den Vorgaben aus `docs/secure-development/`, der Projekt-Constitution und den installierten Governance-Presets genuegt, und wo Nachweise oder Haertungen noch fehlen.

Das Lastenheft selbst nimmt keine Umsetzung vor. Es erzeugt nur den verbindlichen Pruef- und Dokumentationsrahmen fuer den spaeteren Lauf.

## 2. Ausgangslage

TinyCalc ist ein Tabellenkalkulations- und TUI-Projekt mit historischer Pascal-/MicroCalc-Paritaet, Terminal.Gui-Oberflaeche, Berechnungslogik, Dateiartefakten und didaktischer Dokumentation. Sicherheitsrelevante Schwerpunkte sind Eingabevalidierung, Formel- und Datenverarbeitung, Dateipfade, UI-Zustaende, Ausgabeformate und robuste Fehlerbehandlung.

Die wiederverwendbare sichere-Entwicklung-Basis liegt in `docs/secure-development/`. Projektspezifische Sicherheitsnachweise gehoeren weiterhin nach `docs/security/` oder in die jeweils erzeugten Spec-Kit-Artefakte.

## 3. Zielbild des spaeteren Haertungslaufs

Der spaetere Spec-Kit-Lauf soll alle relevanten Pruefpunkte klassifizieren und dokumentieren:

- `Applicable`: der Pruefpunkt gilt fuer TinyCalc und muss mit Evidenzpfad, Entscheidung und Ergebnis dokumentiert werden.
- `N/A`: der Pruefpunkt gilt nicht fuer diesen Lauf und muss mit kurzer Begruendung dokumentiert werden.
- `Open`: der Pruefpunkt gilt, ist aber noch nicht ausreichend erfuellt; Folgeaufgabe, Risiko oder technische Haertung ist zu dokumentieren.

Nicht anwendbare Punkte duerfen nicht stillschweigend ausgelassen werden.

## 4. Pruefgrundlagen

Der spaetere Lauf muss mindestens diese Grundlagen beruecksichtigen:

- `docs/secure-development/Richtlinie_Sichere-Entwicklung.md`
- `docs/secure-development/checklisten/`
- `docs/secure-development/Checklistensammelband_Sichere-Entwicklung.md`
- `constitution.md` und `.specify/memory/constitution.md`
- `docs/security/` als Standard-Evidenzpfad fuer projektspezifische Nachweise
- installierte Governance-Presets:
  - security-governance
  - architecture-governance
  - a11y-governance
  - agent-parity-governance
  - cross-platform-governance
  - isaqb-architecture-governance

## 5. Scope

Im spaeteren Spec-Kit-Lauf sollen insbesondere geprueft werden:

- Tabellen-, Zell-, Formel- und Berechnungslogik
- Eingabevalidierung, Fehlerbehandlung und deterministische Resultate
- Datei- und Import-/Exportpfade, inklusive Pfadvalidierung und Fehlermeldungen
- Terminal.Gui-Interaktion, Tastaturbedienung, Fokusfuehrung und A11Y
- Pascal-/MicroCalc-Paritaet, soweit sie als fachliche Sicherheits- oder Integritaetsanforderung wirkt
- Build-, Test- und CI-Verhalten
- Dependency- und Supply-Chain-Nachweise
- Dokumentation, Beispiele und Ausbildungsartefakte
- Agentenflaechen, Spec-Kit-Artefakte und Governance-Presets

## 6. Abgrenzung

Dieses Lastenheft loest keinen Haertungslauf aus und aendert keine Produktionslogik. Es werden keine Tests, keine Security-Evidenzen in `docs/security/`, keine Spec-Kit-Feature-Branches und keine Implementierungsartefakte erzeugt. Diese Schritte folgen separat durch den spaeteren Spec-Kit-Lauf.

## 7. Mindestanforderungen an den spaeteren Spec-Kit-Lauf

1. Relevante Checklisten aus `docs/secure-development/` auswaehlen und jede Auswahl begruenden.
2. Alle Pruefpunkte als `Applicable`, `N/A` oder `Open` dokumentieren.
3. Fuer `Applicable`-Punkte konkrete Evidenzpfade in `docs/security/`, Testdateien, Codeverweisen oder Spec-Kit-Artefakten benennen.
4. Fuer `N/A`-Punkte eine kurze technische oder fachliche Begruendung erfassen.
5. Fuer `Open`-Punkte Risiko, Folgeaktion und Prioritaet festhalten.
6. Secure Coding und Secure Architecture gemeinsam bewerten; MSL-Status ersetzt keine sichere API-, I/O-, Auth-, Crypto-, Logging- oder Dependency-Pruefung.
7. Formel-, Datei-, UI- und Persistenzgrenzen als Trust Boundaries behandeln.
8. A11Y- und didaktische Kommentar-Governance fuer TUI, CLI-Ausgaben und Dokumentation pruefen.
9. Supply-Chain-, SBOM-, AI-SBOM-, C3A-/C5- und regulatorische Punkte nur anwenden, wenn sie fuer TinyCalc fachlich greifen; sonst als `N/A` mit Begruendung erfassen.
10. Am Ende eine nachvollziehbare Ergebnisuebersicht mit offenen Risiken, akzeptierten Restrisiken und Folgeaufgaben erstellen.

## 8. Erwartete Ergebnisartefakte des spaeteren Laufs

Der spaetere Spec-Kit-Lauf soll mindestens folgende Ergebnisarten erzeugen oder aktualisieren:

| Artefakt | Erwartung |
|---|---|
| Spec-Kit `spec.md` | Haertungsziel, Scope, Nicht-Ziele und Pruefgrundlagen dokumentiert |
| Spec-Kit `plan.md` | Pruefstrategie, Governance-Presets und Evidenzpfade dokumentiert |
| Spec-Kit `tasks.md` | Konkrete Pruef-, Dokumentations- und Haertungsaufgaben ableitbar |
| `docs/security/` | Projektspezifische Nachweise oder begruendete `N/A`-Eintraege |
| Tests/CI | Nur falls aus dem Haertungslauf erforderlich, mit klarer Begruendung |
| Abschlussnotiz | Ergebnis, offene Punkte und Restrisiken auditfaehig zusammengefasst |

## 9. Akzeptanzkriterien fuer den spaeteren Haertungslauf

- Alle relevanten Punkte aus `docs/secure-development/` sind sichtbar behandelt.
- Kein relevanter Sicherheitsstandard aus Constitution oder Governance-Presets wurde stillschweigend ausgelassen.
- Jeder ausgelassene Punkt ist als `N/A` begruendet.
- Jeder offene Punkt ist als `Open` mit Folgeaktion dokumentiert.
- Jede positive Aussage zur Einhaltung verweist auf konkrete Evidenz.
- TinyCalc bleibt nach moeglichen spaeteren Haertungen baubar und testbar.

---

## Spec-Kit-Intake-Reife / Spec Kit Intake Readiness

Dieses Lastenheft ist als Eingabedatei fuer einen spaeteren `/speckit-specify`-Lauf vorgesehen. Vor dem Start muss der aktuelle Repository-Stand geprueft werden, damit bereits erledigte oder ueberholte Punkte nicht erneut umgesetzt werden.

*This requirements document is intended as input for a later `/speckit-specify` run. Before starting, check the current repository state so already completed or superseded items are not implemented again.*

Der spaetere Lauf muss mindestens klassifizieren:

- `Applicable`: gilt fuer diesen Lauf und braucht Umsetzung oder Evidenz.
- `AlreadySatisfied`: ist im aktuellen Stand bereits nachweisbar erledigt.
- `N/A`: gilt fuer diesen Lauf nicht und braucht eine kurze Begruendung.
- `Open`: gilt, ist aber noch nicht ausreichend geklaert oder belegt.
- `FollowUp`: fachlich relevant, aber nicht Teil dieses Laufs.

## Kopierbarer `/speckit-specify`-Prompt / Copyable `/speckit-specify` Prompt

```text
Ersetzter Alt-Prompt: speckit-specify Nutze requirements/intakes/active/Lastenheft_Secure-Development-Hardening.md als verbindliche Eingabedatei. Erstelle die Feature-Spezifikation fuer einen Secure-Development-Hardening-Lauf im Repository TinyCalc.

Ziel: Pruefe das Lastenheft gegen den aktuellen Repository-Stand und erstelle eine belastbare Spec-Kit-Spezifikation, die fuer Auszubildende, Entwickler*innen, Reviewer und KI-Agenten nachvollziehbar ist.

Pflichtpunkte:
- Lies dieses Lastenheft vollstaendig und uebernehme vorhandene Anforderungen, Scope-Grenzen, Reihenfolgehinweise und Akzeptanzkriterien.
- Pruefe, welche Punkte bereits umgesetzt, ueberholt oder noch offen sind.
- Klassifiziere Anforderungen als `Applicable`, `AlreadySatisfied`, `N/A`, `Open` oder `FollowUp`.
- Plane nur `Applicable`-Punkte fuer diesen Lauf.
- Dokumentiere fuer `N/A` und `FollowUp` jeweils eine kurze Begruendung.
- Beachte `constitution.md`, `.specify/memory/constitution.md`, AGENTS/CLAUDE/GEMINI/Copilot-Guidance, installierte Spec-Kit-Presets, Secure-Development-Basis, A11Y-Regeln, CEFR-B2-Verstaendlichkeit und didaktische Kommentar-Governance.
- Starte keinen weiteren Lastenheft-Lauf und kombiniere mehrere Lastenhefte nur, wenn die Kopplung fachlich begruendet und dokumentiert ist.

Erzeuge eine Spezifikation mit Scope, Nicht-Zielen, Anforderungen, Abhaengigkeiten, Akzeptanzkriterien, Risiken, Teststrategie, Evidenzpfaden und offenen Folgepunkten.
```
## Vollständiger englischer Vertragsblock / Complete English Contract

Deutsch: Die englische Fassung ergänzt die Kurztexte. Die deutschen Abschnitte
bleiben kanonisch; Umfang, Reihenfolge und Abnahme sind unverändert.

### English: purpose, context, inputs and scope

This intake prepares, but does not execute, a later TinyCalc hardening run.
Check conformance to docs/secure-development, the constitution and installed
governance presets, identifying missing evidence/hardening. TinyCalc is a
spreadsheet/Terminal.Gui TUI port with Pascal/MicroCalc parity, calculation,
files and training docs. Relevant boundaries are validation, formulas/data,
paths, UI states, output and robust errors. Reusable guidance lives in
docs/secure-development; project proof stays in docs/security or Spec Kit artifacts.
Minimum inputs there are Richtlinie_Sichere-Entwicklung.md, checklisten/ and
Checklistensammelband_Sichere-Entwicklung.md; both constitutions; docs/security;
installed security, architecture, A11Y, agent-parity, cross-platform and iSAQB
presets. This minimum list does not replace the current installed preset matrix.
Scope: sheet/cell/formula/calculation logic; validation/errors/determinism;
file/import/export paths and diagnostics; TUI keyboard/focus/A11Y; parity where
security/integrity matters; build/tests/CI; dependency/supply-chain proof;
docs/examples/training; agent surfaces, Spec Kit artifacts and presets.
Non-goals: this document starts no run and creates no product logic, tests,
security implementation proof, feature branch or implementation artifacts.
Those steps belong to the separately requested later run.

### English: minimum requirements (section 7, same numbering)

1. Select relevant secure-development checklists and justify every selection.
2. Classify all checks Applicable (applies, with evidence/decision/result),
   N/A (does not apply, with rationale) or Open (not sufficiently met).
3. Name concrete Applicable evidence in security docs, tests, code or Spec Kit artifacts.
4. Explain N/A technically or functionally.
5. Record risk, follow-up and priority for Open items.
6. Assess coding and architecture together; memory safety replaces no API,
   I/O, Auth, Crypto, logging or dependency assessment.
7. Treat formula/file/UI/persistence boundaries as trust boundaries.
8. Assess A11Y/didactic-comment rules for TUI, CLI and docs.
9. Apply supply-chain/SBOM/AI-SBOM/C3A/C5/regulatory checks only where relevant;
   otherwise record justified N/A, never silent omission.
10. Produce a traceable overview of results, open risks, accepted residual
    risks and follow-ups. Recording acceptance grants no acceptance authority.

### English: artifacts, acceptance and readiness

spec.md documents goal/scope/non-goals/inputs; plan.md strategy/presets/evidence;
tasks.md concrete review/documentation/hardening work; docs/security proof or
justified N/A; tests/CI only if required by later hardening, with rationale;
an auditable closeout note records results/open items/residual risks.
Acceptance: every relevant guidance item visibly addressed; no relevant standard
silently omitted; all omissions justified N/A; Open items have follow-ups;
every positive conformance claim has concrete proof; TinyCalc remains buildable
and testable after later hardening.
Before Specify, check current state to avoid repeating completed/superseded work.
Classify Applicable, AlreadySatisfied (proved), N/A, Open or FollowUp (relevant,
outside this run). Plan only Applicable work and justify N/A/FollowUp. Preserve
the intake/constitution/agent/guidance/A11Y/B2/didactic rules. Start no other
intake run or combine intakes without documented justified coupling. The marked
old prompt is historical, not another command. Canonical Specify creates only
the matching specification; separately requested Autonomous stays LocalImplementation,
with no push/PR/merge/bypass/secrets/provider/follow-up authority.


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
$speckit-specify Use requirements/intakes/active/Lastenheft_Secure-Development-Hardening.md as the binding intake. Preserve its scope, non-goals, ordering, governance, evidence, and acceptance criteria. Create or update only the matching feature specification. Do not implement, commit, push, create a pull request, merge, or start another feature.
```

### Autonomous

<!-- spec-kit-command-id: speckit.autonomous -->
```text
$speckit-autonomous Execute one complete autonomous Spec Kit run using requirements/intakes/active/Lastenheft_Secure-Development-Hardening.md as the binding intake. Delivery mode: LocalImplementation. Preserve all scope, ordering, security, accessibility, evidence, and acceptance boundaries. Do not push, create or merge a pull request, use bypass authority, expose secrets, or start a follow-up feature.
```
<!-- intake-authoring:end -->
