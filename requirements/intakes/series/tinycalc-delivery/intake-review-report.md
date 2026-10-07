# TinyCalc-Serienreview nach macOS-15-Governance-Aktualisierung

## Ergebnis und Grenze

Der vollständige Serienreview vom 6. Oktober 2026 ist `Ready`. Er umfasst alle
13 geordneten Ziele, vier Wurzeln, neun harte Abhängigkeiten und keine
Campaign-Worker. Es gibt keine Critical-, High-, Medium- oder Low-Befunde,
keine akzeptierten Risiken und keine offenen Fragen. Identität, Zeitpunkt,
Repository-Revision, Request-Bindung und Zielhashes stehen im
[maschinenlesbaren Ergebnis](intake-review-result.json).

Der Review ist Bereitschaftsnachweis, keine Ausführungsfreigabe. `Eligible`
bezeichnet nur den nächsten geeigneten Kandidaten. Alle künftigen
Feature-Prompts bleiben `LocalImplementation`; Commit, Push, Pull Request,
Merge, Bypass, Paketveröffentlichung, Provider-Zugriff und Folgefeatures
benötigen weiterhin eigene ausdrückliche Autorität.

## Prüfungsumfang

Jedes Ziel wurde erneut auf Identität, Zielgruppe, vorausgesetztes Wissen,
Erstgebrauchsbegriffe, Zweck, Scope, Nicht-Ziele, atomare Anforderungen,
messbare Abnahme, Abhängigkeiten, Risiken, Evidenz, Security, Datenschutz,
A11Y, Plattformen, Supply Chain, Referenzen, Prompts und Liefergrenzen geprüft.
Die Texte bleiben deutsch zuerst und englisch danach auf CEFR-B2-Niveau sowie
textorientiert verständlich. Es wurden keine Secrets, unnötigen
personenbezogenen Daten oder binären Reviewziele gefunden.

Zwölf Zielhashes sind gegenüber Review
`d2c44397-bb36-4557-9e44-5c62313d1e94` unverändert. Das geänderte
PL/0-Intake wurde vollständig neu geprüft. Seine Ergänzung bindet die
macOS-15-Runner-Migration, ohne Produktplattform, PL/0-Scope, Paketversion oder
Gate-Bedeutung zu verändern.

## PL/0-, CI- und Liefernachweis

Die neue CI-Grenze stimmt mit den aktuellen Workflowdateien und TinyCalc
[PR 99](https://github.com/hindermath/TinyCalc/pull/99) überein:

- Der Homogenitätsworkflow pinnt `macos-15`.
- Produkt-Build und Produkttests laufen weiterhin auf Linux und Windows.
- Requirements-Intake-Governance verwendet weiterhin `macos-latest`.
- Nur tatsächlich am exakten Commit ausgeführte Jobs zählen als CI-Evidenz.
- Hosted CI ersetzt keine native TUI-, PTY-, VoiceOver- oder A11Y-Abnahme.

Die externe TinyPl0-Stufe wurde live erneut geprüft: Release `v0.4.1` zeigt
auf Commit `edab567e1e7cd3ea8eb8e3bea425b54f24d4b506`; Workflow
`33757534918` ist erfolgreich und enthält Build, SBOM, VEX, Provenienz,
Attestierung, paarweise Veröffentlichung und öffentlichen Consumer-Test.
NuGet.org führt `TinyPl0.Core` und `TinyPl0.Vm` jeweils in Version `0.4.1`.

Dieser Nachweis erfüllt ausschließlich Stufe 1. TinyCalc muss weiterhin die
Integrationsversion auswählen und exakt pinnen, Locked Restore ausführen,
lokale `ProjectReference`s ausschließen, Dependency-Drift klassifizieren und
Compile-/Run-/Step-/Limit-/Abbruch-/Diagnose-Contract-Tests bestehen. Auch der
interne Secure-Development-Vorgänger bleibt blockierend. PL/0 bleibt daher an
Position 8 korrekt `Blocked`.

## Serie, Übergaben und Anwendbarkeit

Die Hauptkette bleibt Constitution -> Terminal.Gui -> TUI-Funktionsabnahme ->
A11Y -> Rename -> Didaktik -> Security -> PL/0 -> Legacy ->
Tabellenoperationen. Sandbox, RL-SE und GSDB sind eigene Wurzeln; RL-SE und
GSDB sind abgeschlossen. Alle 13 Ziele kommen genau einmal vor. Die vier
deklarierten Wurzeln entsprechen exakt den Null-Eingangs-Zielen; die neun
Kanten sind eindeutig, vorwärts gerichtet und zyklenfrei. Es gibt genau einen
`Eligible`-Kandidaten: TUI-Funktionsabnahme und Regressionsvertrag.

NIST SSDF und CWE Top 25 gelten. WCAG 2.2 AA gilt für anwendbare TUI-, HTML-
und Textkriterien. SBOM, VEX und SLSA bleiben Liefer- und
Schwachstellennachweise. STRIDE/CAPEC gelten an Ausführungs-, Datei-,
Dependency- und Sandbox-Vertrauensgrenzen; SAMM und OpenSSF Scorecard bleiben
ergänzender Reifegrad- und OSS-Kontext. ASVS ist ohne Web/API `N/A`, Zero Trust
ohne verteilte Laufzeit `N/A` und Produkt-AI-SBOM bei reiner
Entwicklungswerkzeug-Nutzung `N/A`.

## Audit und nächste Aktion

Dieser Review ersetzt den archivierten Review
`d2c44397-bb36-4557-9e44-5c62313d1e94`. Dessen Request, Ergebnis und Bericht
bleiben unter
[20261006-macos15-governance-refresh-review](../../series-archive/tinycalc-delivery/20261006-macos15-governance-refresh-review/)
erhalten. Manifest- und Serien-Receipt-Hashes, Vorgängerhash sowie die
Anwendbarkeitsentscheidungen sind im maschinenlesbaren Ergebnis gebunden.

Nächste getrennte Aktion, ohne automatischen Feature-Start:

```text
$speckit-intake-series-next tinycalc-delivery
```

## English report

The complete 6 October 2026 series review is `Ready`. It covers all 13 ordered
targets, four roots, nine hard dependencies, and zero campaign workers. There
are no findings at any severity, accepted risks, or open questions. The JSON
result binds the identity, timestamp, repository revision, request, and every
target hash.

Every target was re-evaluated for identity, audience and prior knowledge,
first-use terms, purpose, scope, non-goals, atomic requirements, measurable
acceptance, dependencies, risks, evidence, security, privacy, accessibility,
platforms, supply chain, references, prompts, and delivery authority. Twelve
target hashes are unchanged from the superseded review. The changed PL/0
target received a complete new semantic review.

The new CI boundary agrees with the current workflows and TinyCalc PR 99:
homogeneity pins `macos-15`; product build and tests remain on Linux and
Windows; intake governance retains `macos-latest`. Only jobs that ran on the
exact commit count as CI evidence. Hosted CI is not native TUI, PTY,
VoiceOver, or accessibility acceptance.

Live rechecking confirmed TinyPl0 release `v0.4.1`, source commit
`edab567e1e7cd3ea8eb8e3bea425b54f24d4b506`, successful release workflow
`33757534918`, and matching public `TinyPl0.Core` and `TinyPl0.Vm` version
`0.4.1`. The workflow records build, SBOM, VEX, provenance, attestation,
paired publication, and a clean public consumer. This proves external stage 1
only. TinyCalc's exact pin, locked restore, no-local-ProjectReference check,
drift classification, contract tests, and internal security predecessor remain
open and blocking. PL/0 therefore remains correctly `Blocked` at rank 8.

The graph remains complete, unique, forward-only, and acyclic. Its declared
roots equal the zero-indegree targets. TUI functional acceptance is the sole
`Eligible` candidate. Eligibility is ordering evidence, not implementation or
remote-delivery authority.

NIST SSDF, CWE Top 25, applicable WCAG 2.2 AA, SBOM/VEX/SLSA, and relevant
STRIDE/CAPEC remain in scope. SAMM and OpenSSF Scorecard remain supporting
context. ASVS is N/A without web/API, Zero Trust N/A without distributed
runtime, and product AI-SBOM N/A for development-tool-only AI. No product
certification, fresh release, or new vulnerability disposition is claimed.

This review supersedes `d2c44397-bb36-4557-9e44-5c62313d1e94` while its
archived evidence remains immutable. Readiness grants no commit, push, pull
request, merge, bypass, package publication, provider, or follow-up-feature
authority. The exact next action is:

```text
$speckit-intake-series-next tinycalc-delivery
```
