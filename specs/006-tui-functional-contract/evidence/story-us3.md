# US3: echte Validatorgrenzen / Actual validator boundaries

## Deutscher Nachweis

Stand 2026-10-10. [Policy-Checkpoint](validator-policy-checkpoint.md) enthält
die vorherigen roten und grünen Schema-/Semantik-/Quellen-/Launcherfälle.
Die abschließende öffentliche Datei-Integration akzeptiert einen vollständig
synthetischen 1.092-Tupel-Satz, liefert identische Normal-/WhatIf-Ergebnisse,
verwirft Skip und falsche Testklasse und lässt Repositorybytes unverändert.
Exit 0 des Fixture-Skripts ist kein nativer Produkt-Pass.

Die tatsächliche Resultatbindung wurde separat über den
[macOS-Vollbeleg](platforms/macos/local-build105.md) ausgeführt: 364 Pfade aus
einem Run, exakte bestandene TRX-Theory/Klasse/ID, Zeitgrenzen, unabhängige
Assertion-Proofs und Hashes. Fünf manipulierte Kopien echter Belege wurden im
[UI-Checkpoint](executed-proof-checkpoint.md) abgelehnt. Smoke, Unit-only,
Filterläufe, synthetische Gate-Daten und HumanSupplement ersetzen kein Bundle.

T043/T049 sind damit als Validatorimplementierung und dokumentierter
technischer Bindungsnachweis abgeschlossen, nicht als Dreiplattform-Abnahme.
Neue Anforderungen sind zusätzlich an [US4](story-us4.md) gebunden.
Fehlende Linux-/Windows-, Human- oder unabhängige Reviews bleiben sperrend.

Originale unter ignoriertem `tests/MicroCalc.Tui.Tests/TestResults/`:

| Datei | SHA-256 |
|---|---|
| 006-validator-closeout.log | b5b7b70f11863505f8d261d3c28cd1a7efcd6d40b4f9644935757952976561ec |
| 006-execution-closeout.log | 348e4b993b5dcc0d59f40eb29549f7c7c922e0db7b9a4680e592307476980d44 |

Befehl: `pwsh -NoProfile -File scripts/tests/tui-contract/test-validator.ps1`.
Die acht TRX-Einzelguards liefen über `test-execution.ps1`. Keine Tests oder
Provider aus JSON ausgeführt; native Produktresultate behalten ihren eigenen
Build-/Arbeitsbaumdigest und werden nicht auf diese Dokumentation umetikettiert.

## English evidence

The public file integration accepts a complete synthetic 1,092-tuple fixture,
proves identical zero-write preview and rejects skipped/wrong-class execution.
Eight focused TRX guards pass. These are validator tests, not native acceptance.
Separate actual macOS collection binds all 364 paths to the passed test identity,
time, independent assertions and artefact hashes; tampered real-proof copies
are rejected. T043/T049 close validator implementation/documentation, not full
platform acceptance. Historical additions retain the separate US4 controls.
Missing native, human and independent proof remains blocking. The table binds
ignored originals without relabelling their historical execution context.
