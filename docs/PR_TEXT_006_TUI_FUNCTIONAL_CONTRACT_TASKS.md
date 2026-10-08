# Feature 006: Aufgaben und Analysekorrekturen / Tasks and analysis corrections

## Zusammenfassung / Summary

Die vollständige Aufgabenliste operationalisiert den freigegebenen TUI-Funktionsvertrag. Sie enthält 83 offene Aufgaben in sieben Phasen und vier Stories. Alle 17 Funktionsfamilien, 17 FR, sechs SC und ursprünglichen Task-IDs bleiben erhalten.

*The complete task list operationalises the approved TUI functional contract with 83 open tasks, seven phases and four stories. All baseline families, requirements, success criteria and original task IDs remain intact.*

## Problem und Lösung / Problem and solution

Die erste Analyse fand eine fehlende Test-first-Reihenfolge für Evidence-Producer, historische Freigabestatus und einen nicht ausreichend beschriebenen TUI-Testzugang vor der Session-Extraktion. T014A verlangt jetzt kompilierbare rote Producer-Tests vor T015. Spec und Plan unterscheiden abgeschlossenen Owner-Review von noch offenen Implementierungs-/Preflight-Gates. T016 beschreibt einen isolierten testseitigen Legacy-UI-Adapter; T019 nutzt echte Eingabewege vor T020. Formelkorrekturen folgen weiterhin test-first in T026–T030. Die wiederholte Dokumentanalyse ergab keine verbleibenden Befunde.

*Producer tests now precede implementation. Current review status is distinguished from execution authority. A test-only adapter provides real UI input before session extraction; formula corrections remain test-first. Repeated document analysis found no remaining findings.*

## Umfang und Verhalten / Scope and behaviour

- [x] Dokumentation / Documentation
- [ ] Core, TUI, Produkttests oder CI geändert / Product code, tests or CI changed

Keine Produktimplementierung, Paket-/Lockdateiänderung, öffentliche API, Assembly-Version, DocFX-Ausgabe oder Intake-Mutation. Migration → Funktionsabnahme → A11Y → Rename bleibt erhalten. Alle Tasks bleiben offen. Merge dieses Dokumentations-PRs erteilt keine Produktabnahme oder Implementierungsfreigabe.

*Documentation only: no product implementation, dependency/API/version/DocFX or intake changes. Preserve the feature order. All tasks remain open; merging these documents grants neither implementation authority nor product acceptance.*

## Prüfplan / Test plan

- [x] Read-only Analyze: C1/I1/U1 behoben; vollständige Anforderungsabdeckung / Findings resolved; complete requirement-to-task coverage
- [x] 83 eindeutige Tasks, T001–T082 erhalten, T014A additiv / Unique stable tasks with additive T014A
- [x] `git diff --check` / Whitespace validation
- [ ] Delivery-set, Secret-, Governance-, Homogenitäts- und Statistikprüfung vor Lieferung abschließen / Complete local delivery validation
- [ ] Technische PR-Checks am exakten Head prüfen / Verify technical checks at the exact head

Lokale Build-/Test-/Smoke-/Restore-Läufe und Screenshots sind N/A: Produkt und UI bleiben unverändert. Bestehende CI bleibt verbindlich; geplante Produktnachweise werden nicht als ausgeführt behauptet.

*Local runtime checks and screenshots are N/A for unchanged product/UI. Existing CI remains binding. Future product evidence is not represented as executed.*

## Risiken und Lieferung / Risks and delivery

Der Testadapter ist eine geplante Strategie, kein bereits ausgeführter Nachweis. Der tatsächliche Dependency-Pin und Framework-Fähigkeiten müssen im späteren Preflight geprüft werden; Infrastrukturfehler zählen nicht als fachliches Rot. NIST SSDF/CWE Top 25 und textorientierte bilinguale B2-Dokumentation bleiben anwendbar. Produkt-ASVS, AI-SBOM und Zero Trust bleiben gemäß freigegebenem lokalem Scope N/A; keine neue Release-/Supply-Chain-Abnahme.

*The adapter is a planned strategy requiring later preflight, not runtime proof. Infrastructure failure cannot count as functional red. Retain applicable security and accessible bilingual documentation boundaries and existing scoped N/A decisions.*

Der Owner hat Commit, Push und DeliveryMode MergeAndSync mit Admin-Bypass beauftragt. Der Bypass betrifft formale Freigaben, nicht fehlgeschlagene technische Prüfungen. Kein Folgefeature oder Implementierungslauf wird gestartet.

*The owner authorised commit, push and exact-head MergeAndSync with admin bypass. Bypass does not replace technical validation. No follow-up feature or implementation run starts.*
