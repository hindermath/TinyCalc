# Feature 006: TUI-Funktionsvertrag / TUI functional contract

## Deutscher Überblick

**Draft – nicht mergefähig, keine Produktabnahme.** 70/83 Tasks nachgewiesen.
[Abschlussfortschritt](../specs/006-tui-functional-contract/evidence/closure-checkpoint.md)
trennt tatsächliche Implementierung von Human- und endgültiger Lieferabnahme.

Problem: bestätigte Formel-, Anzeige-, Tastatur-, Hilfe- und Load-Defekte sowie
fehlende unabhängige Vertrags-/Evidenzinfrastruktur.
Lösung: test-first Produktkorrekturen, interne reale Session, vier unveränderte
Locks, unabhängige Orakel, echte macOS-PTY und fail-closed read-only Validator.
Alle 17 Familien und 364 Pfade bleiben erhalten.

- Historischer macOS-Build 105: 669 Pass, null Fail/Skip, 364 Pfade,
  462 Assertions, Changed-Line-Coverage 488/503 = 97,02 %.
- [Native CI 38077169518](../specs/006-tui-functional-contract/evidence/platforms/native-ci-38077169518.md):
  je Linux/Windows 671 Pass, null Fail/Skip, 364 Pfade, 462 Assertions.
  Feature-Head und tatsächlich ausgeführter PR-Testmerge sind getrennt gebunden.
- [Unabhängiger Quell-/Delta-Review](security/secure-development/006-tui-functional-contract/independent-review.md)
  durchgeführt; JSON-Lesegrenze nach echtem Rot korrigiert. Danach vollständige
  synthetische 1092-Tupel-/Zero-write-Integration und gezielte Policy-/Pfadtests grün.
- [DocFX/axe/lynx](accessibility/006-docfx-axe.md): gezielte Linknamen-/Kontrast-/
  Zielgrößen-/Namespace-Korrekturen; fünf Seiten ohne automatische Verstöße oder
  fehlende Artikelziele. Manuelle Prüffälle bleiben ausdrücklich offen.

| Gate | Tatsächlicher Nachweis / verbleibende Grenze |
|---|---|
| Funktion/PTY | macOS Build 105, reale Binary, 80x24/120x40, vollständige Suite/Collector; kein neuer finaler Head |
| Native Linux/Windows | ci.yml, build-test auf ubuntu-latest/windows-latest; Capture → ungefiltertes dotnet test → Collect → Upload; originale TRX/Bundles und Digests ausgewertet |
| Launcher | beide nativen Jobs: pwsh -NoProfile -File scripts/tests/tui-contract/test-launchers.ps1, echte Logs; finale gemeinsame Parität offen |
| Smoke | beide nativen Jobs: dotnet run --no-build --configuration Release --project src/MicroCalc.Tui/MicroCalc.Tui.csproj -- --smoke |
| Validator | synthetische vollständige Fixtures/WhatIf, unveränderte Repositorybytes; kein nativer Produkt- oder Human-Pass |
| Dokumentation | DocFX 115 null Fehler/83 bestehende Warnungen; fünf Playwright/axe/ARIA- und lynx-Stichproben; spätere Textänderungen/finale Bindung gesondert |
| Human/Owner | echte VoiceOver-Bedienung und getrennte Produktentscheidung ausstehend |
| Lieferung | finale gemeinsame Head-/Vertragsbindung, aktuelle Lieferprovenienz und sauber gebundene Statistik ausstehend |

Projekte: MicroCalc.Core, MicroCalc.Tui und beide vorhandenen Tests.
Keine neue öffentliche C#-API, Paketupgrades oder Produktabhängigkeiten.
TUI-Captures bleiben gehashte Roh-/Textoriginale, keine synthetische Human-Evidenz.
Nur ein technischer GSDB-Quellhash wurde nach Checklistenfortschreibung erneuert;
Kontrollbewertungen, regulatorische Entscheidungen, Intakes und Serie unverändert.

Risiken: untrusted JSON-/Datei-/Git-Evidenz verlangt strikte Grenzen. Neuer
begrenzter Streamleser bindet Parser und Digest an denselben Snapshot.
Coverage enthält derzeit alle neun geänderten Produktdateien; vollständig
fehlende Instrumentierung wäre künftig separat zu erkennen. Human-A11Y und
Owner-Abnahme bleiben Pflicht. Historische Resultate werden nicht umetikettiert.
Claude-Providerfehler ist zurückgestellt, nicht bestanden. MergeAndSync und
Admin-Bypass sind nur für formale Regeln genehmigt; kein materielles Gate umgehen.
Kein Folgefeature und kein NuGet-Update in diesem PR.

## English overview

Draft only: 70/83 tasks evidenced, not accepted or merge-ready. Actual native
Linux/Windows jobs each pass 671 tests and all 364 paths, with original bytes,
digests, provider head and testmerge distinctly recorded. Historical macOS
coverage/PTY proof is not relabelled to that head.

Independent source/delta review is complete. The actual JSON resource-limit
bug was corrected test-first, retaining complete validator/zero-write proof.
The bounded DocFX overlay fixes sampled name/contrast/target/link failures;
five pages have no automatic axe violations or missing article targets.
Manual checks, real human VoiceOver, owner acceptance, final common-head proof
and delivery provenance remain mandatory. No public API, product dependency,
package graph, intake state or follow-up feature changed. Formal-rule admin
bypass never replaces material gates; deferred Claude failure is not a pass.
