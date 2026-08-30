# Terminal.Gui-v2-Migration

## Deutscher PR-Block

### Zusammenfassung

Dieser Pull Request migriert ausschließlich `MicroCalc.Tui` von Terminal.Gui
1.19.0 auf die stabile Version 2.4.17. Der explizite v2-Lifecycle verwendet
genau eine `IApplication`, ein creator-owned Root und creator-owned Dialoge.
Die 13 bestehenden Navigations- und Beenden-Eingaben behalten ihre Bedeutung.

Es gibt keine MicroCalc-zu-TinyCalc-Umbenennung, keine neue Tabellenfunktion,
keine Core- oder Testquellenänderung und keinen FakeDriver.

### Problem

Die TUI verwendet v1-APIs für globalen Lifecycle, Tastaturmasken, Dialogläufe,
Buttons und Events. Terminal.Gui 2.4.17 stellt diese Flächen auf explizite App-
und Runnable-Instanzen sowie neue Tastencodes um. Ein reiner Paketwechsel
kompiliert deshalb nicht und könnte ohne klare Ownership Fokus, Dialogrückkehr,
Quit oder Terminalrestauration beschädigen.

### Lösung

- `Terminal.Gui` ist ausschließlich in `MicroCalc.Tui.csproj` exakt auf
  2.4.17 gepinnt.
- `Program` erzeugt, initialisiert und entsorgt genau eine App-Instanz.
- Root und Dialoge werden vom Erzeuger ausgeführt und im gleichen Scope
  freigegeben.
- Menü-Quit und `Ctrl+Q` rufen `RequestStop` für dieselbe aktive Sitzung auf.
- `Key.WithCtrl` und v2-Cursor-/Enter-Schlüssel ersetzen die alten Masken.
- `--smoke` bleibt vor jeder Terminalinitialisierung und gibt exakt
  `SMOKE_OK` aus.
- Security-, A11Y-, Architektur-, Paket-, Lizenz-, SBOM- und
  Regressionsevidenz bindet den lokalen Stand; Plattform und Exact Head folgen
  vor Merge.

### Scope

- [ ] `MicroCalc.Core` — absichtlich unverändert
- [x] `MicroCalc.Tui` — Paket- und v2-Adaptermigration
- [ ] vorhandene Testquellen — absichtlich unverändert
- [x] Dokumentation und Liefernachweise
- [x] CI/CD — später ausschließlich die minimale Änderung an
  `.github/workflows/ci.yml` für Linux und Windows

### Exakter Delivery-Set

Produkt- und Konfigurationspfade:

```text
src/MicroCalc.Tui/MicroCalc.Tui.csproj
src/MicroCalc.Tui/Program.cs
Directory.Build.props
.github/workflows/ci.yml
```

Der vollständige file-by-file Delivery-Set ist in
`specs/003-terminalgui-migration/evidence/delivery-set-intent.md` verbindlich
aufgeführt. Er enthält ausschließlich benannte Feature-Artefakte unter
`specs/003-terminalgui-migration/`, diese PR-Beschreibung,
`docs/accessibility/terminalgui-migration.md`,
`docs/architecture/terminalgui-migration.md`, die einzeln benannten
`docs/security/`-Artefakte und die vorhandenen Statistikdateien.

Explizit ausgeschlossen sind:

```text
src/MicroCalc.Core/
tests/
CALC.HLP
scripts/
Agenten-Guidance und Presets
andere Workflows als .github/workflows/ci.yml
docfx.json und _site/
Feature 004 und FakeDriver-Arbeit
andere Intake-Serien
Build-, Test-, Coverage- und Cache-Ausgaben
```

Der lokale `autonomous-run-state.json` gehört nie zum Commit.

### Verhaltens- und TUI-Nachweis

- genau 13 bestehende Tastaturbindungen: 8 Ctrl-, 4 Cursor- und 1 Enter-Pfad;
- null `Key.CtrlMask`, null `Key.AltMask` und null v1-Lifecycle-Aufrufe;
- zwei getrennte reale PTY-Sitzungen für Menü-Quit und `Ctrl+Q`;
- Start bei `A1`, Menüöffnung, Navigation, Eingabe-, Funktions- und
  Dateidialog, `Tab`, `Shift+Tab`, `Esc` und sichere Dialogrückkehr;
- Exitcode 0, kein Traceback und beobachtete Terminalrestauration;
- keine beabsichtigte Abweichung vom klassischen MicroCalc-Verhalten.

Textnachweis:
`specs/003-terminalgui-migration/evidence/manual-tui.md` und
`docs/accessibility/terminalgui-migration.md`.

### Test- und Plattformplan

Lokal auf macOS `osx-arm64` bestanden:

```text
dotnet restore MicroCalc.sln
dotnet build MicroCalc.sln --configuration Release --no-restore
dotnet test MicroCalc.sln --configuration Release --no-build
dotnet run --no-build --configuration Release \
  --project src/MicroCalc.Tui/MicroCalc.Tui.csproj -- --smoke
```

Ergebnis: Release-Build mit 0 Warnungen und 0 Fehlern, 79/79 Tests bestanden,
0 übersprungen, Smoke Exit 0 und exakt `SMOKE_OK`. Reale Out-of-process-
Coverage aus Tests, Smoke und PTY-Sitzungen erreicht 82 von 100 geänderten
ausführbaren Zeilen, also 82,0 Prozent. Die Mindestschranke 70 Prozent und das
Ziel 80 Prozent sind bestanden.

Vor Merge müssen echte `ubuntu-latest`- und `windows-latest`-Jobs dieselben
vier Produktbefehle auf demselben unveränderten PR-Head ausführen. macOS-
Evidenz wird nicht als Ersatz gewertet.

### Security und Lieferkette

- NIST SSDF, CWE Top 25, Microsoft C# Secure Coding, STRIDE/CIA,
  CAPEC-153 und CAPEC-538 sind dokumentiert.
- Der ausgelieferte Graph enthält 1 direkte und 23 transitive NuGet.org-
  Abhängigkeiten.
- Bekannte Schwachstellen: 0.
- Lizenzstatus: 23 MIT, 1 BSD-2-Clause, 0 unbekannt, 0 unvereinbar.
- Die gültige SPDX-2.3-SBOM enthält alle 24 NuGet-Pakete.
- VEX darf nur Fehlalarme oder nicht ausgelieferte Komponenten klassifizieren;
  ein bekannter ausgelieferter Fund blockiert.
- AI-SBOM ist N/A, weil KI nur Entwicklungswerkzeug ist.
- Für den aktuellen Output existiert keine verifizierbare SLSA-v1.2-
  Provenance-Attestation; deshalb wird kein SLSA Build Level behauptet.
- Der datierte OpenSSF-Review erfindet keinen Aggregatwert, wenn kein
  veröffentlichter Bericht vorliegt.

### Barrierefreiheit

WCAG 2.2 AA 1.4.1, 2.1.1, 2.1.2, 2.4.3 und 2.4.7 sind lokal geprüft. Die TUI
bleibt tastatur-first, besitzt eine nachvollziehbare Fokusreihenfolge,
sichtbaren Fokus und textuelle Statusinformation. Pointer-, Bild-, Medien- und
Animationskriterien sind begründet N/A und besitzen Re-Evaluation-Trigger.

### Konfigurations- und API-Auswirkung

- Paketkonfiguration: `Terminal.Gui` exakt 2.4.17 im TUI-Projekt.
- Repository-Version: `Version`, `AssemblyVersion` und `FileVersion` bleiben
  gemäß Build-Ledger identisch.
- CI: nur minimale Linux-/Windows-Produktjobs in `ci.yml`.
- Öffentliche API: keine neue oder geänderte API.
- XML-/DocFX-Dokumentation: keine Änderung und kein Regenerations-Trigger.
- Core, Dateiformat und `CALC.HLP`: unverändert.

### N/A-Entscheidungen

ASVS, Zero Trust, allgemeiner Architektur-ADR, BSI C3A/C5 und die benannten
Regulatorik-Profile sind für den engen lokalen Feature-Scope begründet N/A oder
ohne Feature-Delta; Trigger stehen in arc42 Abschnitt 11. VEX, AI-SBOM und
Dependency-Automation stehen in der Supply-Chain-Evidenz. DocFX, Home-Sync,
Produkt-Hilfe und Agentenparität wurden nicht ausgelöst.

### Risiken und Mitigation

| Risiko | Mitigation |
|---|---|
| plattformspezifisches Terminalverhalten | echte Linux-/Windows-Jobs und macOS-PTY-Nachweis |
| falsches Stop-Ziel oder Ressourcenleck | eine App, creator-owned Dialoge, strukturierte Freigabe, zwei Quit-Pfade |
| Core-/Testregression | ausgeschlossener Diff und vollständige 79 Tests |
| Supply-Chain-Manipulation | exakte Version/Quelle, Vulnerability-/Lizenz-Gate, SBOM und Exact Head |
| Evidenz gehört zu anderem Commit | ein Feature-Commit, Provider-Head-Bindung und Schema-2.0-Gates |

### FakeDriver-Follow-up

Ein FakeDriver oder eine neue TUI-Testabstraktion ist ausdrücklich nicht Teil
von Feature 003. Die reale PTY-Evidenz schließt diesen Migrationsauftrag. Eine
spätere FakeDriver-Arbeit gehört zu einem eigenen Intake beziehungsweise
Feature 004 und darf diesen PR weder erweitern noch blockierende Evidenz
ersetzen.

### Merge- und Review-Grenze

Der PR wird erst nach grünen Providerchecks, null offenen Review-
Konversationen, unverändertem PR-Head, vollständiger Schema-2.0-Gate-Evidenz
und Exact-Head-Revalidierung zusammengeführt. DeliveryMode ist
`MergeAndSync`. Admin-Bypass darf nur eine reale formale Merge-Policy
überwinden; er ersetzt kein Fach-, Security-, A11Y-, Plattform-, Review- oder
Exact-Head-Gate.

## English PR block

### Summary and problem

This pull request migrates only `MicroCalc.Tui` from Terminal.Gui 1.19.0 to the
stable 2.4.17 release. Terminal.Gui v2 requires explicit application and
runnable instances and different lifecycle, key, dialog, button, and event
APIs. A package-only change does not compile and could break focus, dialog
return, quit, or terminal restoration without clear ownership.

### Solution and scope

Terminal.Gui is pinned to 2.4.17 only in the TUI project. `Program` owns one
application, the root, and every dialog. Both quit paths stop the same session,
and smoke stays before terminal initialisation. The exact file-by-file delivery
set is recorded in `specs/003-terminalgui-migration/evidence/delivery-set-intent.md`.
Core, existing test sources, help, scripts, agent guidance, other workflows,
DocFX, Feature 004, FakeDriver work, and generated outputs are excluded.

### Evidence and tests

Local macOS evidence passes: warning-free Release build, all 79 tests with no
skips, exact `SMOKE_OK`, two separate real PTY quit sessions, all 13 existing
key bindings, and 82.0 percent changed executable coverage. Linux and Windows
must run the same four product commands on the unchanged pull-request head
before merge.

The shipped graph contains one direct and 23 transitive NuGet.org packages,
zero known vulnerabilities, and zero unknown or incompatible licenses. The
SPDX 2.3 SBOM contains all 24 NuGet packages. No SLSA Build Level is claimed
because no verifiable provenance attestation exists yet.

Keyboard operation, focus, visible focus, and text status meet the documented
WCAG 2.2 AA checks. Public APIs, XML/DocFX, Core, file format, and `CALC.HLP`
do not change.

### Risks, non-applicability, and delivery

Platform driver differences, lifecycle ownership, Core regression,
supply-chain manipulation, and commit/evidence drift are mitigated by real
platform jobs, structured ownership, the excluded-scope diff, package/SBOM
gates, and exact-head validation. ASVS, Zero Trust, AI-SBOM, current VEX,
DocFX, home sync, and dependency automation have explicit narrow N/A decisions
and triggers in the security evidence.

FakeDriver work is outside Feature 003 and belongs to a separate intake or
Feature 004. Merge requires green provider checks, no open review threads, an
unchanged reviewed head, and complete exact-head gates. MergeAndSync is
authorized; admin bypass may address only a real formal merge policy and never
replace a technical or review gate.
