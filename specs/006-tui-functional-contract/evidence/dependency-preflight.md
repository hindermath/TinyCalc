# Paket-Preflight / Dependency preflight

## Deutscher Nachweisblock

2026-10-10, macOS arm64/.NET SDK 10.0.401, Ausgangs-HEAD `ffc3d56a8975341a686ff6985570369abefcfd2a`, unveränderte Paketdeklarationen. T004–T006 verwenden den tatsächlich deklarierten Terminal.Gui-Pin 2.4.17, keine im Validator vorgegebene Version. Vor T005 fehlten alle vier Produkt-/Testlocks: Zustand Blocked. Thorstens ausdrückliche T005-Freigabe erlaubt ihre begrenzte Erzeugung und Prüfung ohne Upgrade.

Ausgeführt, jeweils Exit 0:

```text
dotnet restore MicroCalc.sln --use-lock-file --source https://api.nuget.org/v3/index.json
dotnet restore MicroCalc.sln --locked-mode --source https://api.nuget.org/v3/index.json
dotnet package list --project MicroCalc.sln --vulnerable --include-transitive --format json --no-restore --source https://api.nuget.org/v3/index.json
dotnet package list --project MicroCalc.sln --outdated --include-transitive --format json --no-restore --source https://api.nuget.org/v3/index.json
```

PowerShell verglich je Projekt alle `Direct`-/`Transitive`-Lockeinträge (ohne `Project`) mit den direkten/transitiven Paket-IDs und Versionen aus `specs/003-terminalgui-migration/evidence/dependencies/packages-all.json`, unabhängig von absoluten historischen Projektpfaden. Core: 0 Pakete; TUI: 24; Core.Tests: 14; Tui.Tests: 38. Alle vier Differenzmengen leer. Die Lockhashes stehen in `pin-decision.json`. Kein Upgrade, keine neue Abhängigkeit und keine unerwartete Auflösungsänderung.

Der Locked Restore bestätigt die aktuelle Kohärenz. `AlreadySatisfied` gilt ausschließlich für den unveränderten freigegebenen Paketgraphen; nicht für neue Funktions-, Plattform-, PTY- oder VoiceOver-Abnahme. Die vollständige Feature-Matrix bleibt Pflicht. Der Decision-Digest verwendet rekursiv ordinal sortierte Objektschlüssel, unveränderte Array-Reihenfolge, kompaktes JSON, UTF-8 ohne BOM und genau ein abschließendes LF; das eigene `decisionDigest`-Feld ist ausgeschlossen. T011 übernimmt diese Regel und bindet Paritätsfixtures.

Die einzige für diese Ausführungen verwendete Registry ist NuGet.org. Eine weitere benutzerspezifisch konfigurierte authentifizierte Quelle wurde durch die explizite Source-Auswahl ausgeschlossen; keine Zugangsdaten in Artefakten. Paketmetadaten aller 24 ausgelieferten Pakete bestätigen NuGet.org als tatsächliche Cache-Quelle.

Die aktuelle Online-Advisory-Abfrage nennt für keines der vier Projekte einen bekannten Fund. Neuere Versionen sind sichtbar, darunter Terminal.Gui 2.5.0, Markdig 1.4.0, Microsoft.Extensions 10.0.12 sowie Testwerkzeuge. Das sind Wartungshinweise, keine Upgradefreigabe. Alle 24 aktuellen NUSPEC-SHA-256 stimmen bytegenau mit `licenses-shipped.json` überein; Lizenztexte: 23 MIT, einmal BSD-2-Clause, null unbekannte oder unvereinbare ausgelieferte Lizenzen.

## English evidence block

Four missing locks initially blocked preflight. The owner's explicit T005 authority permitted bounded generation. Both restore commands and both live registry queries above exited zero. Per-project comparison against the previously reviewed graph found zero package-ID/version changes across 0/24/14/38 packages. All declarations are unchanged; no upgrades or new dependencies. The pin decision records lock hashes and a SHA-256 digest over recursively ordinal-sorted compact JSON with preserved array order, UTF-8 without BOM and one terminal LF, excluding its own digest field. T011 retains this rule and adds parity fixtures.

The current locked restore establishes coherence, not inherited product acceptance. Every future functional/platform/PTY/human-accessibility gate remains required. Only NuGet.org was used; the authenticated user source was excluded and no credentials are recorded. The live advisory report lists no vulnerable packages. Available newer versions are maintenance signals only. All 24 shipped NUSPEC hashes and approved licences match historical evidence: 23 MIT, one BSD-2-Clause, no unknown or incompatible shipped licence.
