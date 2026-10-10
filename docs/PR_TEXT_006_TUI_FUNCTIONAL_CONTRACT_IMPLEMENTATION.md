# Feature 006: vollständige lokale Implementierung / Complete local implementation

## Deutscher Überblick

**Draft – noch nicht mergefähig, kein Feature-Abschluss.** 65/83 Tasks
vollständig nachgewiesen. [Abschlussfortschritt](../specs/006-tui-functional-contract/evidence/closure-checkpoint.md)
und [macOS-Vollbeleg](../specs/006-tui-functional-contract/evidence/platforms/macos/local-build105.md)
trennen lokale Automation von finaler Plattform-, Human- und Produktabnahme.

Problem: bestätigte Formel-, Anzeige-, Tastatur-, Hilfe- und Load-Integritätsdefekte
sowie fehlende unabhängige Vertrags-/Evidenzinfrastruktur.
Lösung: test-first Produktkorrekturen, interne echte Session, unveränderte vier
Locks, vollständige unabhängige Orakel, reale PTY-Beobachtung und fail-closed
read-only Vertragsprüfung. Alle 17 Familien und 364 Pfade bleiben erhalten.

- Lokale Solution Build 105: Core 217 + TUI 452 = 669 Pass, null Fail/Skip.
- Ein gemeinsamer tatsächlicher macOS-Lauf: 364 Pfade, 462 serialisierte Assertions.
- Geänderte ausführbare Produktzeilen: 488/503 = 97,02 %, Collector zurückgenommen.
- Synthetische 1.092-Tupel-Prüfung/WhatIf: identisch und schreibfrei; kein Produktbeleg.
- Schema-, Pfad-, Klassen-/TRX-/Hash-, Pin-/Impact-/Historien-/Workflowguards vorhanden.
- Native vollständige Linux/Windows-Läufe, finale Headbindung, VoiceOver,
  unabhängige Reviews und Owner-Produktabnahme bleiben Open.

Produkt-/Testprojekte: MicroCalc.Core, MicroCalc.Tui und beide vorhandenen Tests.
Keine neue öffentliche C#-API, Paketupgrades oder Produktabhängigkeiten.
Konfiguration: vier genehmigte Locks ohne Auflösungsdrift, native CI-Collector-
Integration und DocFX-Sprach-/Publikationskorrektur. Intakes/Serien unverändert.
TUI-Captures: gehashte Roh-/Textoriginale im lokalen macOS-Nachweis; keine
synthetischen Screenshots als native oder menschliche Belege ausgeben.

Testplan / Gatezuordnung:

| Gate | Tatsächliche Ausführung / nächster Pflichtnachweis |
|---|---|
| Lokale Funktion/PTY | macOS 27.0 arm64, Feature-006-local-build105; vollständiges dotnet test mit Coverage und TRX, danach collect-tui-contract-evidence.ps1 |
| Native Linux/Windows | ci.yml, build-test-Matrix auf ubuntu-latest/windows-latest; Capture → vollständiges dotnet test ohne Filter → Collect → Upload; aktueller Lieferhead noch ausstehend |
| Validator/Preview | PowerShell/Bash/Cmdlet, synthetische vollständige Fixtures und manipulierte echte Belegkopien; keine Produkt-/Providerstarts |
| Dokumentation | DocFX 106: null Fehler/88 Warnungen; fünf Playwright-ARIA-Seiten und drei Lynx-Texte; axe/abschließende Publikationsprüfung offen |
| Human-A11Y/Review | VoiceOver mit Mensch sowie unabhängige Security-/Architektur-/Produktprüfung und getrennte Owner-Abnahme ausstehend |

Risiken: Validator konsumiert nicht vertrauenswürdige JSON-/Datei-/Git-Evidenz.
Symlink-/Traversal-Abwehr, strikte Schemas, atomare Ausgabe, Zeit-/Klassen-/Hash-
Bindung und historische Test-first-Provenienz begrenzen Fälschungen; Selbstreview
ist kein unabhängiger Review. Historische beziehungsweise nicht finale Ergebnisse
werden nicht auf einen neuen Commit umetikettiert. Claude-Providerfehler ist auf
Ownerwunsch zurückgestellt, nicht bestanden. DeliveryMode MergeAndSync bleibt
genehmigt; Admin-Bypass betrifft ausschließlich formale Regeln, keine offenen
materiellen Gates. Keine Folgefeatures oder NuGet-Upgrades in diesem PR.

## English overview

This draft records complete local implementation, not feature acceptance:
65 of 83 tasks are fully evidenced. One actual macOS run passes 669 tests with
all 364 mandatory paths, 462 serialized independent assertions and 97.02%
changed executable-line coverage. Linked records retain real commands, captures,
run hashes and working-tree bindings. Synthetic full-validator fixtures and
zero-write preview are infrastructure proof, not native product acceptance.

Core/TUI/tests/docs change without new public APIs, package upgrades or product
dependencies. Approved locks retain the original resolution. CI collects full
native Linux/Windows proof; DocFX language/publication changes support the
learner reading path. Native final-head runs, human VoiceOver, independent
security/architecture/product review and owner acceptance remain Open.

The table maps gates to actual runners and commands rather than green job names.
Untrusted file/JSON/Git proof requires strict boundary checking; self-review is
not independent review. Old or dirty-tree evidence is never relabelled to a new
head. MergeAndSync and formal-rule bypass do not waive material gates. Deferred
Claude failure is not a pass. Preserve intake states and continue only Feature 006.
