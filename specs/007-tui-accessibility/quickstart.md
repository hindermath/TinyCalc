# Prüfablauf für spätere Umsetzung / Verification Guide for Later Execution

## 1. Jetzt und später trennen / Separate Now from Later

Dieser Planlauf startet kein Produkt. Alle Build-/Test-/Restore-/Reader-Schritte unten gelten ausschließlich nach separater Umsetzungsfreigabe. Vorher Spec/Plan/Tasks und Quellenfrische prüfen; bei Drift stoppen. Keine privaten Dateien verwenden, insbesondere nicht `sheet.mcalc.json`.

*This planning run starts no product. The execution instructions below require separate implementation authority. Check approved artefacts and source freshness first; stop on drift and never use private data or sheet.mcalc.json.*

Lokaler sicherer macOS-Einstieg, PowerShell bevorzugt:

*Safe local macOS entry, preferring PowerShell:*

```powershell
pwsh -NoProfile -File scripts/validate-requirements-intake-alignment.ps1
pwsh -NoProfile -File scripts/render-project-statistics.ps1 -WhatIf -Json
```

Der bestehende `Test-TinyCalcContract`-Launcher ist lesend, benötigt aber zuerst die im Research dokumentierte Archivpfadkorrektur und aktuelle Bindungen. Nach dieser autorisierten Korrektur mit vollständigen 007-Evidence-/Pin-/Impactpfaden zuerst `-WhatIf -Json`, danach normale Validierung in beiden Shells; `-WhatIf` ist keine Produktabnahme. Keine Beispielpfade als existierende Nachweise ausgeben.

Vor erster Produktkorrektur die neuen Designanker auf Einzelwege/Plattformen expandieren, Quellen und Orakel binden und kompilierbare rote Regressionen vorbereiten. Die native Sitzung bekommt vorab protokollierte Erwartungen; fehlende Ausführung ist kein beobachtetes Rot. Danach frühe native Machbarkeit, direkte Eingabe/Korrektur und Vollregression in der Reihenfolge des Plans, keine nachträgliche Anpassung an grüne Resultate.

*Before product correction, expand design anchors into individual paths/platforms, bind sources/oracles and prepare compiling red regressions. Record native expectations before execution; missing execution is not red proof. Follow the plan's native-feasibility, correction and regression order without fitting expectations to results.*

*The read-only contract launcher needs the documented archive-path correction and current bindings first. After authorised repair, supply actual complete Feature 007 paths, preview then validate in both shells. Preview is not acceptance and example paths are not existing proof.*

## 2. Dependency, TDD und Version / Dependencies, TDD and Versioning

Vier Lockdateien und freigegebenen Graph vergleichen. Vor jedem späteren Build/Test Versionsfelder gemäß Branch 007 und Buildzähler synchron pflegen. Danach:

*Compare all locks/approved dependencies and align version fields before each authorised build/test, then:*

```text
dotnet restore MicroCalc.sln --locked-mode
dotnet build MicroCalc.sln --configuration Release --no-restore
dotnet test MicroCalc.sln --configuration Release --no-build --logger trx
dotnet run --no-build --configuration Release --project src/MicroCalc.Tui/MicroCalc.Tui.csproj -- --smoke
```

Gezielte neue Regressionen zuerst kompilierbar rot, dann minimale Korrektur und vollständige Suite. Kein Filter/Skip als Gesamtabnahme. Smoke muss Exit 0/SMOKE_OK liefern, bleibt Teilbeleg. Changed-Code-Coverage mindestens 70 %, Ziel 80 %, vollständige aktive Wege unabhängig davon 100 %. Lockdrift ist kein Anlass für automatisches Upgrade.

*Start with compiling failing regressions, then minimal fixes and full regression. Smoke/filter subsets are partial proof. Minimum 70% changed-code coverage, target 80%; all active paths require full coverage independently. Never upgrade automatically on drift.*

## 3. Frühe native Sitzung / Early Native Session

Mac A: tatsächliche Terminal.app-/macOS-/VoiceOver-/pwsh-Versionen und Einstellungen, Commit/Binary/Startweg/Größe/Zeit protokollieren. Mit synthetischer Eingabe B01 ohne End-Taste zuerst VoiceOver aus, dann an prüfen. B02: Tab/Shift-Tab über alle Aktionen; aktuelle Aktion muss sofort ohne zusätzlichen Leseschritt eindeutig benannt werden. Ansagetext nur aus tatsächlicher Beobachtung erfassen. Anfängliches Zeilenlesen und hilfreiches Control+Option+Pfeil bleiben separate Orientierung, kein Fokuspass.

*Record the full actual Mac A environment. Test direct typing without End with VoiceOver off/on. For every dialog action, compare Tab/Shift-Tab focus with immediate speech without extra reading. Record only observed speech; line reading is separate orientation evidence.*

Start aus dokumentiertem Arbeitsverzeichnis mit dem oben erzeugten Kandidaten (`dotnet run --no-build --configuration Release --project ...` oder explizites Release-DLL). Zusätzlich den berichteten `dotnet run --project ./src/MicroCalc.Tui`-Startweg in späterer autorisierter Reproduktion getrennt prüfen: er darf bauen und muss eigene Binary-/Commit-/Versionsbindung besitzen. Ein alter Debug-Build ist kein Nachweis für Release. Größen 80x24/120x40 sowie ergänzend 120x28.

*Start the bound candidate from the recorded directory without rebuilding, or use its explicit Release DLL. Separately reproduce the reported dotnet run path only when authorised: it may build and requires its own binary/version bindings. Old Debug proof is not Release proof. Test both baseline sizes and supplementary 120x28.*

Fehlende unmittelbare Aktion: Fail; keine Sitzung: Open; nicht abschließbare Prüfung: Incomplete. Bei nicht erfüllbarer Anforderung stoppen und Thorsten ansprechen; kein Frameworkwechsel oder automatischer Scopeabbau.

*Missing required speech fails; missing execution is Open; inconclusive execution is Incomplete. Stop for an unattainable requirement rather than switching frameworks or shrinking scope.*

## 4. Gesamtabnahme und Stopp / Full Acceptance and Stop

Echte macOS-PTY-Prozesspfade mit Terminalrücksetzung und vollständige native Linux-/Windows-Automation binden. Hosted macOS-Homogenität ist keine VoiceOver-Sitzung. Fehlende Hosts später durch eng beauftragte native CI ersetzen, nicht durch ungefragten Providerstart. Jede Evidenz bindet Commit, Quellen/Pin/Locks, Befehl, Runner/Host, Exit bei Automation, Payload-/Decision-SHA-256 und Prüfumfang; lesende Verifikationen separat zero-write.

*Bind actual PTY/restoration and complete native platform automation. Hosted governance CI is not VoiceOver evidence. Missing hosts require separately authorised native CI. Bind every result and prove read-only verification separately.*

DocFX nach betroffenen Hilfe-/Dokumentations-/API-Änderungen mit unveränderter Konfiguration erzeugen, repräsentative Seiten über Snapshot/axe und lynx prüfen; manuelle Kriterien und axe-Incomplete nicht als Pass ausgeben. Security-/Architekturreview und Owner-Abnahme getrennt, acht AK einzeln beurteilen. Danach ohne frischen Lieferauftrag lokal stoppen: kein Commit, Push, PR, Merge, Intake-Archivieren oder Rename-Start.

Für den HTML-Dokumentencheck `dotnet tool run docfx -- --version` und `dotnet tool run docfx -- build docfx.json --output <eigener temporärer Ordner>` verwenden; benötigtes Tool-Restore nur nach gesonderter Erlaubnis, kein Paketupdate. Version gemäß `.config/dotnet-tools.json`, derzeit 2.81.0. Die 007-Quellen werden von dieser Konfiguration nicht veröffentlicht: direktes Markdown-Review nicht mit HTML-Smoke verwechseln. DE/EN-Sprachwechsel, Kontrast-/Link-Incomplete und manuelle Kriterien bleiben separat zu bewerten.

*For HTML review use the explicit versioned local-tool commands above, with restore only when separately authorised and no upgrade. Current manifest version is 2.81.0. Feature 007 sources are not published by this configuration: distinguish Markdown review from HTML smoke and assess language changes and manual/incomplete checks separately.*

*Regenerate affected documentation and verify text accessibility, retaining incomplete/manual criteria. Separate technical review from owner acceptance and assess every criterion. Stop locally without fresh delivery authority.*
