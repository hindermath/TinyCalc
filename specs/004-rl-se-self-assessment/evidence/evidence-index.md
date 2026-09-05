# Evidence-Index: RL-SE-Selbstpruefung / RL-SE Self-Assessment

## Leseregel / Reading Rule

**DE:** Dieser Index ordnet Anforderungen und Governance-Presets konkreten
Repository-Nachweisen zu. `Erfuellt` bezeichnet nur bereits ausgefuehrte
lokale Arbeit. `Pending` bezeichnet spaetere Exact-Head- oder Provider-Gates
und nimmt keinen Erfolg vorweg. `N/A` nennt immer einen Trigger.

**EN:** This index maps requirements and governance presets to concrete
repository evidence. `Fulfilled` covers only completed local work. `Pending`
marks later exact-head or provider gates and does not claim success in advance.
Every `N/A` entry states a trigger.

## RLSE-GATE-001 bis -020

| ID | Status | Konkreter Nachweis / Concrete evidence |
|---|---|---|
| RLSE-GATE-001 | Erfuellt / Fulfilled | `autonomous-run-state.json`; beide installierten Run-State-Validatoren binden Lauf `faae97c9-e61b-480e-b6dd-24b8121868d0`. Der getrackte Stand reicht kausal bis T053; T054/T055 bleiben Provider- und terminale Runtime-Aufgaben. |
| RLSE-GATE-002 | Erfuellt / Fulfilled | `docs/secure-development/baseline-manifest.json`, `baseline.json`, `assessment-matrix.json`; Baseline 3.2.0, 12 Familien, 157 IDs und 30 Hashbindungen. |
| RLSE-GATE-003 | Erfuellt / Fulfilled | `scripts/validate-rl-se-assessment.ps1`, `.sh`, `quickstart.md`, `autonomous-run-evidence.md`; reproduzierbares RED, 157/157 GREEN und finaler Linux-/Windows-CI-Lauf `33985257787` am Head `ebda8ad45d455f9a2a7d82daa73a86be0fecde50`. |
| RLSE-GATE-004 | Erfuellt / Fulfilled | `assessment-matrix.json`; 21 positive, 32 N/A, 42 Open und 62 FollowUp, mit Human-only-Grenze. |
| RLSE-GATE-005 | Erfuellt / Fulfilled | `baseline.json`, `deltas/rl-se-assessment.json`, `closure.json`, `image-impact.json`; read-only Status und genau ein Closure-Review sind `Ready`. |
| RLSE-GATE-006 | Erfuellt / Fulfilled | `evidence-matrix.md`, `docs/security/threat-model.md`, `security-checklist.md`, `samm-assessment.md`, `regulatory-applicability.md`; keine Rechts- oder Zertifizierungsbehauptung. |
| RLSE-GATE-007 | Erfuellt / Fulfilled | `dependency-audit.md`, `sbom/tinycalc-terminalgui.spdx.json`, `supply-chain-evidence.md` und PR #68; 0 bekannte Schwachstellen, VEX N/A sowie gruene Supply-Chain-/Secret-Gates. Die dokumentierte SLSA-/Provenance-Grenze bleibt unveraendert ehrlich. |
| RLSE-GATE-008 | N/A | `docs/security/asvs-verification.md`; lokaler TUI ohne Web/API/Auth. Trigger: Web-, API-, HTTP-, Auth- oder Remote-Service. |
| RLSE-GATE-009 | N/A | `docs/security/supply-chain-evidence.md`; KI ist nur Entwicklungswerkzeug. Trigger: ausgelieferte oder betriebene KI-Runtime, Modell, Datensatz oder Inferenzdienst. |
| RLSE-GATE-010 | N/A | `docs/security/zero-trust-applicability.md`; lokaler Einprozess-TUI. Trigger: Cloud-, Remote-, Service- oder Netzwerkarchitektur. |
| RLSE-GATE-011 | Erfuellt / Fulfilled | `evidence-matrix.md` und `autonomous-run-evidence.md`; DE-first/EN-second, CEFR B2, lineare Textalternative und WCAG-2.2-AA-Grenze. |
| RLSE-GATE-012 | Erfuellt / Fulfilled | `.specify/presets/.registry`, `plan.md`, `autonomous-run-evidence.md` und `requirements/intakes/series/tinycalc-delivery/manifest.json`; 13 Presets, RL-SE `Completed`, GSDB als einziger deklarierter `Eligible`-Kandidat und kein gestartetes Folgefeature. Der Review des Vorgaengermanifests ist supersediert archiviert; ein aktueller Serienreview wird nicht vorgetaeuscht. |
| RLSE-GATE-013 | Erfuellt / Fulfilled | `docs/documentation-impact/rl-se-self-assessment.json`, `docs/project-statistics.config.json` und `docs/project-statistics.md`; Feature- und kausaler Closeout-Impact sind aktuell und der Statistik-Check ist reproduzierbar. |
| RLSE-GATE-014 | Erfuellt / Fulfilled | `tasks.md` T041-T043/T053 und `delivery.md`; Feature- und Closeout-Satz wurden exakt validiert. `src/`, `tests/`, APIs und DocFX besitzen im Closeout kein Delta. |
| RLSE-GATE-015 | Erfuellt / Fulfilled | `autonomous-run-evidence.md`; Restore, Build 0/0, 82/82 Tests, exakt `SMOKE_OK` sowie Linux-/Windows-Produkt- und Matrixjobs in CI-Lauf `33985257787`. |
| RLSE-GATE-016 | Erfuellt / Fulfilled | `autonomous-run-evidence.md`; Homogenitaet, Agent-Secret-Scan, gitleaks, PSScriptAnalyzer, Bash-Syntax, JSON-/Markdown- und Dokumentationsgates bestanden lokal und beim Provider. |
| RLSE-GATE-017 | Erfuellt / Fulfilled | PR #68, CI `33985257787` und Claude-Review `33985257791`/Job `101357470647` binden den unveraenderten Head `ebda8ad45d455f9a2a7d82daa73a86be0fecde50`; null aktive Threads und null `Changes Requested`. |
| RLSE-GATE-018 | Erfuellt / Fulfilled | `evidence/accepted-premerge.json`; Schema 2.0, 20/20 `Primary`, finaler Feature-Head und normalisierter Hash `bacb87d1a195b6a3b45c94084aaccf3cb7e8f6de164f68dc39b32f1750f987c5`. |
| RLSE-GATE-019 | Feature-Merge erfuellt; Closeout Pending / Feature merge fulfilled; closeout pending | `evidence/postmerge.json` und `evidence/delivery.md` binden Provider-Merge `aa647ec39ff7b1013f19a551d9d34ca919069474`, leeres Produktdelta, Fast-Forward und den formal-only Bypass. Nur der einzelne evidence-only Closeout-PR bleibt kausal offen. |
| RLSE-GATE-020 | Pending | Der branchgestempelte Intake und der aktualisierte Serienstatus sind getrackt vorbereitet. Closeout-Provider-Merge, Branchbereinigung, finaler Fast-Forward und Runtime-Status `Completed` folgen ausschliesslich in T054/T055; GSDB bleibt ungestartet. |

## Funktionale Anforderungen FR-001 bis FR-018

| ID | Status | Konkreter Nachweis / Concrete evidence |
|---|---|---|
| FR-001 | Erfuellt / Fulfilled | `research.md` R-001 und `docs/secure-development/mitgeltende-dokumente/Verzahnung_Richtlinie_Checklisten_Spec-Kit-Presets.md`. |
| FR-002 | Erfuellt / Fulfilled | `assessment-matrix.json` und beide Validatoren: 157/157 eindeutige kanonische IDs. |
| FR-003 | Erfuellt / Fulfilled | Matrixschema und Validator begrenzen jede Zeile auf genau eine Hauptdisposition. |
| FR-004 | Erfuellt / Fulfilled | Jede Zeile traegt `applicability` und `implementationStatus` aus dem erlaubten Modell. |
| FR-005 | Erfuellt / Fulfilled | Matrixschema, Validator und 157 Zeilen enthalten Begruendung, Evidenz/Open, Owner, Aktion, Trigger und Restrisiko. |
| FR-006 | Erfuellt / Fulfilled | 21 `AlreadySatisfied`-Zeilen verweisen auf konkrete lokale Evidenz; fachlicher Review in `autonomous-run-evidence.md`. |
| FR-007 | Erfuellt / Fulfilled | 32 N/A- und 62 FollowUp-Zeilen tragen Begruendung und Trigger/Folgeinformation. |
| FR-008 | Erfuellt / Fulfilled | 42 Open-Zeilen tragen Owner, High-Prioritaet, Risiko, Aktion und Trigger. |
| FR-009 | Erfuellt / Fulfilled | Alle 42 Human-only-Zeilen bleiben `Open`, nicht `Fulfilled`, und `humanDecisionEvidence` ist `NotProvided`. |
| FR-010 | Erfuellt / Fulfilled | Baseline-Bindung umfasst Richtlinie, Sammelband, 12 Checklisten und 30 kontrollierte Texte; Matrix und Bericht referenzieren Security, CI und Tests. |
| FR-011 | Erfuellt / Fulfilled | Preset-Mapping in diesem Index und Matrixreferenzen je relevantem Kontrollbereich. |
| FR-012 | Erfuellt / Fulfilled | `evidence-matrix.md` enthaelt Scope, Quellen, Familien, Risiken, Human-only-Grenzen, Folgearbeit und Trigger. |
| FR-013 | Erfuellt / Fulfilled | Leserbericht, PR-Text, Quickstart und Laufnachweis sind DE-first/EN-second und textorientiert. |
| FR-014 | Erfuellt / Fulfilled | `git diff -- src tests` bleibt leer; keine externe Haertung oder menschliche Entscheidung ausgefuehrt. |
| FR-015 | Erfuellt / Fulfilled | 104 Open-/FollowUp-Zeilen bleiben getrennt autorisierungspflichtige Arbeit. |
| FR-016 | Erfuellt / Fulfilled | Beide Matrix-Validatoren pruefen IDs, Statuswerte, Pfade, Human-only-Regel und Hashbindungen reproduzierbar. |
| FR-017 | Erfuellt / Fulfilled | Lokaler Build, 82 Tests, Smoke und Governance-Evidenz sowie gruene Linux-/Windows-Jobs im finalen CI-Lauf `33985257787`. |
| FR-018 | Erfuellt / Fulfilled | Projektspezifische Evidence liegt unter `docs/security/secure-development/2026-09-05-rl-se-self-assessment/`. |

## Constitution Requirements CR-001 bis CR-016

| ID | Status | Konkreter Nachweis / Concrete evidence |
|---|---|---|
| CR-001 | Erfuellt / Fulfilled | `plan.md` Technical Context und `autonomous-run-evidence.md` binden die TinyCalc-Level-2-Zeile (.NET 10, xUnit, Smoke, A11Y, Statistik). |
| CR-002 | Erfuellt / Fulfilled | Textorientierter WCAG-2.2-AA-Review in `autonomous-run-evidence.md`. |
| CR-003 | Erfuellt / Fulfilled | Neue Leserartefakte sind Deutsch zuerst und Englisch danach auf CEFR-B2-Niveau. |
| CR-004 | Erfuellt / Fulfilled | Statistik-Config und Ledger enthalten Feature 004 und seinen kausalen Closeout getrennt, verwenden 80/125 Zeilen pro Arbeitstag, 7.8 Stunden und 21.5 Arbeitstage pro Monat und bestehen `-CheckOnly`. |
| CR-005 | Erfuellt / Fulfilled | C#/.NET bleibt MSL-Produktlaufzeit; kein Produktcode-Delta ersetzt Secure Coding. |
| CR-006 | Erfuellt / Fulfilled | `evidence-matrix.md`, Threat Model und Security Checklist behandeln NIST SSDF, CWE Top 25, STRIDE/CAPEC und SAMM. |
| CR-007 | N/A | `asvs-verification.md`; Trigger ist eine Web/API/HTTP/Auth-Flaeche. |
| CR-008 | Lokal erfuellt / Locally fulfilled | Dependency Audit, SPDX-SBOM, VEX-Grenze, SLSA/Provenance und OpenSSF sind dokumentiert; Provider-Provenance bleibt ehrlich Pending. |
| CR-009 | N/A | Produkt-AI-SBOM in `supply-chain-evidence.md`; Trigger ist eine KI-Produktkomponente. |
| CR-010 | N/A | Zero Trust und Architekturdelta; Trigger ist eine neue verteilte Trust Boundary. |
| CR-011 | Erfuellt / Fulfilled | Pflichtnachweise liegen an den etablierten Pfaden in `docs/security/` und im datierten Assessment-Kontext. |
| CR-012 | Erfuellt / Fulfilled | 13-Preset-Inventar und Mapping-Tabelle dieses Indexes. |
| CR-013 | Erfuellt / Fulfilled | `docs/documentation-impact/rl-se-self-assessment.json`: drei aktuelle Eintraege fuer Assessment, unveraenderte Agentenflaechen und deterministischen Governance-Closeout; `sourceOnly`, Home-Sync false. |
| CR-014 | Erfuellt / Fulfilled | Matrix, Bericht und Laufspur nennen Status, Abhaengigkeiten, Entscheidungen und naechste Aktionen textuell. |
| CR-015 | N/A | Kein API-, XML-Kommentar-, Produktkommentar- oder DocFX-Navigationsdelta; Trigger ist eine entsprechende Aenderung. |
| CR-016 | N/A | Kein Produkt-/Testcode-Delta; Trigger aktiviert Produkt-TDD sowie 70-Prozent-Mindest- und 80-Prozent-Zielcoverage. |

## Erfolgskriterien SC-001 bis SC-008

| ID | Status | Konkreter Nachweis / Concrete evidence |
|---|---|---|
| SC-001 | Erfuellt / Fulfilled | 157/157; fehlend 0, doppelt 0, unbekannt 0. |
| SC-002 | Erfuellt / Fulfilled | 100 Prozent der Zeilen bestehen Schema- und Pflichtfeldpruefung. |
| SC-003 | Erfuellt / Fulfilled | 21/21 positive Aussagen besitzen konkrete pruefbare Evidence; unbelegt 0. |
| SC-004 | Erfuellt / Fulfilled | 104/104 N/A/Open/FollowUp-Zeilen besitzen die vorgeschriebene Folgeinformation; stille Auslassung 0. |
| SC-005 | Erfuellt / Fulfilled | 12 Familien, mitgeltende Dokumente, beide Constitutions und 13 Presets sind sichtbar behandelt. |
| SC-006 | Erfuellt / Fulfilled | Alle materiellen lokalen Gates, echte Linux-/Windows-CI und der unabhaengige Provider-Review sind am unveraenderten Feature-Head gruen; nur der formale kausale Closeout steht noch aus. |
| SC-007 | Erfuellt / Fulfilled | Textreview bestaetigt DE-first/EN-second, CEFR B2, lineare Alternative und keine Farb-/Layoutabhaengigkeit. |
| SC-008 | Erfuellt / Fulfilled | Kein automatisches Hardening und kein Produktdelta; Follow-up bleibt getrennt autorisierungspflichtig. |

## Governance-Preset-Mapping

| Preset | Version / Prioritaet | Zuordnung, Status und Trigger / Mapping, status, and trigger |
|---|---:|---|
| `security-governance` | 0.6.2 / 10 | CL-01, CL-05, CL-06, CL-07, CL-08, CL-09; `security-checklist.md`, Supply Chain und Matrix. Trigger: Security-Preset- oder Baseline-Aenderung. |
| `secure-development-assurance-governance` | 0.1.2 / 15 | RLSE-GATE-002/-005; vier Ready-Gates, Status und einmaliger Closure-Review. Trigger: Evidence-/Accepted-Risk-/Review-Aenderung. |
| `architecture-governance` | 0.5.2 / 20 | CL-02 und CL-04; Threat Model und arc42. Kein Architekturdelta. Trigger: neue Komponente, Datenfluss oder Trust Boundary. |
| `isaqb-architecture-governance` | 0.2.2 / 30 | CL-02; `docs/security/arc42-security.md`. Trigger: Architektur- oder Qualitaetsszenario-Aenderung. |
| `a11y-governance` | 0.4.3 / 40 | RLSE-GATE-011, CR-002/-003, SC-007; Leserbericht und Textreview. Trigger: Lesertext, Navigation oder HTML-Ausgabe. |
| `cross-platform-governance` | 0.2.2 / 50 | CL-08/CL-10, beide Validator-Einstiege und gruene Linux-/Windows-Jobs im finalen CI-Lauf `33985257787`. |
| `agent-parity-governance` | 0.4.2 / 60 | CR-013; `NoUpdateRequired`, weil keine Agentenflaeche geaendert wird. Trigger: gemeinsame Guidance oder generierte Skills. |
| `model-routing-governance` | 0.1.4 / 61 | Phasen-Routing und Ergebnisse in Run-State/Runtime; Modellnamen bleiben ausserhalb der Feature-Anforderungen. Trigger: Routing-Policy oder Role Binding. |
| `intake-authoring-governance` | 0.3.1 / 64 | Bindender RL-SE-Intake und Authoring-Receipt. Trigger: Intake-Inhalt, Schema oder Hash. |
| `intake-review-governance` | 0.2.1 / 65 | Review `05b0ee98-6bd1-420c-a4bc-3ae15e59f1c4` war fuer das Vorgaengermanifest `Ready` und ist nach der Serienmutation byteidentisch supersediert archiviert. Ein aktueller Review bleibt bewusst ausstehend; Trigger: gesonderter `speckit-intake-review`. |
| `intake-sequencing-governance` | 0.2.3 / 66 | RL-SE ist `Completed`; GSDB ist als einziger deklarierter Kandidat `Eligible`, aber nicht gestartet. TUI-Feldtest und Sandbox bleiben `Pending`, sieben lineare Nachfolger `Blocked`. Trigger: weitere Serienmutation. |
| `autonomous-run-governance` | 0.4.1 / 70 | Run-State, Phase-Gates, Exact-Head-Plan und MergeAndSync-Grenze. Trigger: Authority, Head, Stop oder Delivery-Status. |
| `parallel-autonomous-run-governance` | 0.2.6 / 80 | N/A fuer diesen ausdruecklich seriellen Einzelfeature-Lauf. Trigger: Autorisierung einer parallelen Kampagne oder mehrerer gleichzeitiger Ziele. |

## Offene Delivery-Grenze / Open Delivery Boundary

**DE:** Dieser Index belegt den vollstaendigen Feature-Merge kausal. Er nimmt
nur den noch ausstehenden evidence-only Closeout-PR, dessen Provider-Merge,
Branchbereinigung und terminalen Runtime-Abschluss nicht vorweg. Diese Schritte
werden am unveraenderten Closeout-Head read-only geprueft und blockieren bei
einem materiellen Fehler. Die drei menschlichen Freigabeentscheidungen bleiben
`Open`; GSDB wird nicht gestartet.

**EN:** This index causally proves the complete feature merge. It does not
pre-claim the remaining evidence-only closeout pull request, its provider
merge, branch cleanup, or terminal runtime completion. Those steps are checked
read-only on the unchanged closeout head and any material failure blocks them.
The three human approval decisions remain `Open`; GSDB is not started.
