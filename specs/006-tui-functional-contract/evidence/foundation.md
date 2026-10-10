# Vertragsfundament / Contract foundation

## Deutscher Nachweisblock

2026-10-10, T009–T015/T017–T018. Das unabhängige Inventar bindet fünf Quellen
und die geklärte Spec, 17 Familien und 364 einzeln benannte Pfade. Navigations-
aliase innen/am Rand, ASCII 32–126, alle Funktionen und Pflichtorakel, Menü/
Palette, Dialogabbruch und Terminalgrößen sind enthalten. Groß-/Kleinbuchstaben
P/p und N/n behalten getrennte Eingaben, aber eindeutig benannte Hilfe-IDs.
Source-Map erfasst COUNT-Backtick und A23-Beispiel als noch zu korrigierende
Dokumentationsdefekte; kein Angebot wurde entfernt. RQ-001–RQ-003 sind geklärt,
nicht als Produkt-Pass ausgegeben.

Zehn strikte Entitätsschemas, explizite Byte-Kanonisierung, unabhängiger Nenner,
17 FR/sechs SC und additiver erster Vertrag vor Produktänderungen. T013 bindet
FunctionalImpact+A11yImpact+TestInfrastructureImpact, 30/180/5-Sekunden-Fristen
und orakelspezifische numerische Toleranzen. Keine Ausnahme für unveränderten Pin.

`pwsh -NoProfile -File scripts/tests/tui-contract/test-foundation.ps1
-RepositoryRoot .`: Exit 0. Nachweis: Schemas, eindeutige Pfade, vollständige
Inventarzuordnung, Source-Bytes/Anker, Decision-/Baseline-/Source-Map-Digests,
Unicode-/Array-/Zahlen-/Duplikatfixtures und konkrete negative Schemafälle.
Weitere Drift-/Pfad-/Testschwächungs-Fixtures sind für T041–T049 definiert;
deren künftiger Validator-Erfolg wird nicht vorweggenommen.

T014A/T015 Rot–Grün–Refactor und vollständige bestehende Regression:
[Producer-Protokoll](red-green/producers.md). Architektur-/Securitydesign steht
in `docs/architecture/tui-functional-contract.md`, zugehörigem Session-ADR,
`docs/security/adr/004-tui-contract-evidence.md` und ergänzten Threat-/arc42-/
Qualitätsszenarien. Unabhängiger Review bleibt Open, keine Zertifizierung.
G2 wurde nach T016 geöffnet: tatsächlicher Legacy-UI-Adapter bestanden, danach
T019 fachliches Rot und T020 Session-Extraktion; siehe [US1-Protokoll](red-green/us1.md).
Kein Produkt-Pass aus den Foundation-Fixtures abgeleitet. Aktuelle Extraktions-
Quellbindungen folgen in T039; der frühere Foundation-Exit bleibt historisch.

## English evidence block

The independent source inventory and first additive contract cover seventeen
families and 364 individually named paths, all seventeen requirements and six
acceptance criteria. Known documentation defects remain visible, not claimed
fixed; clarified semantic decisions are not product pass results. Ten strict
entity schemas and explicit canonical byte rules bind inputs and decisions.
The read-only foundation command passed schema, denominator, source/anchor,
digest and canonical/negative-schema fixtures. Later full-validator negative
cases remain future work, not presumed green.

The linked protocol records genuine producer red–green–refactoring and local
baseline regression. Architecture/security design records trust boundaries and
open independent review. Actual T016 infrastructure opened G2 before the recorded
T019 domain red and T020 extraction. Fixture success does not become product
acceptance. Current extraction source bindings remain a T039 follow-up; the
earlier foundation result remains historical, not relabelled as current.
