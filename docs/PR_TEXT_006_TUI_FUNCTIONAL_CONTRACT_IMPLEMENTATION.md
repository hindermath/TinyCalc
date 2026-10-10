# Feature 006: Implementierungs-Zwischenstand / Implementation checkpoint

## Deutscher Überblick

**Draft – nicht mergefähig, kein abgeschlossener Feature-Lauf.** 39/83 Tasks
nachgewiesen. Vollständiger Status: [Implementierungs-Zwischenstand](../specs/006-tui-functional-contract/evidence/implementation-checkpoint.md).

Problem: bestätigte Formel-, Anzeige-, Tastatur-, Hilfe- und Load-Integritätsdefekte;
fehlende unabhängige Vertrags- und Evidenzinfrastruktur.
Lösung: minimale test-first Produktkorrekturen, interne echte Session, vier
genehmigte Locks ohne Auflösungsänderung und begonnene read-only Vertragsprüfung.

- [x] MicroCalc.Core, MicroCalc.Tui, Tests und Dokumentation
- [ ] CI-Vollvertragsintegration abgeschlossen
- [x] Lokale Solution: 580 Tests grün, null Fail/Skip (Build 60)
- [x] 28 semantische und acht Pfadsicherheitsfixtures grün
- [x] Synthetische vollständige Datei-/WhatIf-Prüfung, null Repository-Writes
- [ ] Native vollständige Linux-/Windows-Vertragsläufe
- [ ] Reale macOS-PTY-Captures und menschliche VoiceOver-Abnahme
- [ ] Finale Coverage/Security/Architektur/Supply-Chain-/Produktabnahme

Keine neue öffentliche C#-API, Paketupgrades oder Produktabhängigkeiten. Vier
fehlende Lockdateien sind ausdrücklich autorisiert. Das Produkt bleibt lokales
C#/.NET-10-TUI. Intakes/Serienzustände und Folgefeatures bleiben unverändert.
Die beabsichtigten Semantikänderungen sind die bereits geklärten mathematischen
Regeln, keine neue Featureausweitung. Synthetische Testfixtures und Framework-
Tastaturinjektion ersetzen keine echten Terminal-Captures oder Human-A11Y.

Read-only Preview: `pwsh -NoProfile -File scripts/test-tinycalc-contract.ps1 -WhatIf -Json`
meldet erwartungsgemäß `Blocked`/Exit 2 bei fehlenden vollständigen Run-Bundles.
Statistikvorschau: `pwsh -NoProfile -File scripts/render-project-statistics.ps1 -Repo . -WhatIf -Json`
liefert `DRY_RUN`/Exit 0. DocFX: null Fehler, 84 Warnungen; ARIA-/Lynx-Textprüfung
durchgeführt, fehlende HTML-Seitensprache ausdrücklich als offene A11Y-Grenze erfasst.
Validator-Sicherheitsrisiko: Dateipfade, JSON und Evidenz sind Vertrauensgrenzen;
Symlink-/Traversal-Abwehr und Hash-/Schema-Bindung sind getestet. Die begonnene
Prüfung ersetzt noch keine finale unabhängige Security-Abnahme.

Risiken: finale Plattform-/Zeilen-/Tupelabdeckung und unabhängige Prüfung stehen
aus. Die vorhandenen CI-Build/Test/Smoke-Jobs sind kein vollständiger Vertragsgate.
Admin-Bypass darf diese offenen materiellen Pflichten nicht umgehen.
DeliveryMode MergeAndSync ist genehmigt; Merge bleibt bis zum vollständigen
Feature-Nachweis gesperrt. Dieser PR dient der nachvollziehbaren Fortführung.

## English overview

**Draft, not merge-ready and not feature completion.** The checkpoint records
39/83 evidenced tasks, minimal test-first product fixes, an internal real UI
session, authorised unchanged dependency locks and initial read-only validation.
The complete local solution passed 580 tests; 28 semantic and eight safety
fixtures passed. Synthetic full-file validation proves zero-write preview parity,
not actual platform or human acceptance.

Core/TUI/tests/docs change without public API or new product dependencies.
Native full Linux/Windows contract CI, real macOS terminal captures, human
VoiceOver, coverage and final independent/security/architecture/supply-chain
acceptance remain Open. Existing green build/test/smoke jobs do not replace these
gates. MergeAndSync authority and formal-rule admin bypass never waive material
requirements. Preserve intake states and continue only this feature.

The read-only contract preview blocks with exit 2 because full run bundles are
missing; statistics preview returns DRY_RUN/exit 0. DocFX passed with 84 warnings.
ARIA/Lynx review ran, but missing HTML language remains an accessibility finding.
Validator security boundaries include paths, JSON and proof bindings; tested
defences do not replace the pending final independent security review.
