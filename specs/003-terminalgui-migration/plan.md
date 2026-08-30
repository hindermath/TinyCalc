# Implementierungsplan / Implementation Plan: Terminal.Gui-2.x-Migration

**Branch / Branch**: `003-terminalgui-migration` | **Datum / Date**: 2026-08-30 | **Spezifikation / Spec**: `specs/003-terminalgui-migration/spec.md`
**Eingabe / Input**: `requirements/intakes/active/Lastenheft_TerminalGui_Migration.md`, akzeptierter SHA-256 `fd59040e8bb736b0944e74ab855b72a3a8b843487ae64509926d4a9e79c68160`
**Autonomer Lauf / Autonomous run**: `38ad4c1d-bf85-4053-b585-eb490176b727`, Phase `Plan`, Liefermodus `MergeAndSync` unter erneuter Autoritätsprüfung

## Zusammenfassung / Summary

TinyCalc ersetzt ausschließlich in `MicroCalc.Tui` die direkte
Terminal.Gui-Abhängigkeit `1.19.0` durch die stabile Version `2.4.17`. Der
Einstieg wird auf das instanzbasierte `IApplication`-Modell mit eindeutigem
Besitz und Dispose-Lebenszyklus umgestellt. Namespaces, Ereignisse, Dialogläufe
und die acht alten Masken-Ausdrücke werden auf die v2-API übertragen. Die 13
vorhandenen Navigations- und Beenden-Eingaben, beide Beenden-Wege und der
headless Smoke-Modus bleiben fachlich gleich. `MicroCalc.Core`, Dateiformate und
vorhandene Testquellen ändern sich nicht.

*TinyCalc changes only `MicroCalc.Tui`, upgrading Terminal.Gui from `1.19.0` to
the stable `2.4.17`. Startup moves to the instance-based `IApplication` model
with explicit ownership and disposal. Namespaces, events, dialog runs, and the
eight legacy mask expressions move to the v2 API. The 13 existing navigation
and quit inputs, both quit paths, and headless smoke mode retain their behaviour.
Core, storage formats, and existing test sources remain unchanged.*

## Aufgelöster Template-Stack / Resolved Template Stack

`pwsh -NoProfile -File .specify/scripts/powershell/setup-plan.ps1 -Json` hat
den materialisierten Kern aus `.specify/templates/plan-template.md` kopiert.
Die installierte Registry und `scripts/config/spec-kit-governance-presets.json`
legen folgenden wirksamen Stack fest. Ein Preset ohne Plan-Provider bleibt als
Anwendbarkeitsprüfung Teil der Governance, fügt aber keinen Planabschnitt ein.

*The PowerShell setup command copied the materialised core plan template. The
installed registry and canonical preset matrix resolve the following active
stack. A preset without a plan provider still participates in applicability
review but adds no plan section.*

| Priorität / Priority | Preset | Version | Wirksame Planfolge / Effective plan consequence |
|---:|---|---:|---|
| 10 | `security-governance` | 0.6.2 | MSL, sichere C#-Entwicklung, Dependency Audit, SBOM/SLSA und Standardsmatrix |
| 20 | `architecture-governance` | 0.5.2 | Trust Boundaries, STRIDE/CAPEC, S-ADR/arc42, Zero Trust, SAMM, C3A/C5 |
| 30 | `isaqb-architecture-governance` | 0.2.2 | Kontext-, Baustein-, Laufzeit-, Deployment-, Qualitäts- und Risikosicht |
| 40 | `a11y-governance` | 0.4.3 | WCAG 2.2 AA, Tastatur/Fokus, Textzugang, DE-first/EN-second, CEFR B2 |
| 50 | `cross-platform-governance` | 0.2.2 | Plattformnachweis; Skript-/Cmdlet-Parität begründet `N/A` |
| 60 | `agent-parity-governance` | 0.4.2 | Gemeinsame Agentenflächen begründet `N/A` |
| 70 | `autonomous-run-governance` | 0.4.1 | Gate-Anforderungen vor Code, vertikaler Schnitt, Delivery-Set, Schema 2.0, Stop/Resume |
| 80 | `parallel-autonomous-run-governance` | 0.2.6 | Keine Plan-Erweiterung; Kampagne begründet `N/A` |

Der optionale Git-Hook vor und nach `speckit.plan` wird nicht ausgeführt, weil
der aktuelle Phasenauftrag Commit und Remote-Aktionen ausdrücklich verbietet.

*The optional Git hooks around planning are not executed because the current
phase explicitly forbids commits and remote actions.*

## Technischer Kontext / Technical Context

**Sprache/Version / Language/Version**: .NET 10, C# 14, beobachtetes lokales SDK
`10.0.400`; C# ist eine erlaubte speichersichere Sprache.
**Primäre Abhängigkeiten / Primary dependencies**: `Terminal.Gui` exakt
`2.4.17`, am 2026-08-30 in der NuGet Gallery als aktuelle stabile 2.x-Version
mit enthaltenem `net10.0` geprüft; `MicroCalc.Core` als unveränderte
ProjectReference.
**Speicher / Storage**: bestehende lokale JSON-Tabellendateien und `CALC.HLP`;
Schema, Serialisierung und Referenzartefakte bleiben unverändert.
**Tests / Testing**: xUnit `2.9.3`, Microsoft.NET.Test.Sdk `18.3.0`,
coverlet.collector `8.0.0`, prozessübergreifendes `dotnet-coverage` für den
interaktiven TUI-Lauf. Vorhandene Testquellen bleiben unverändert.
**Zielplattform / Target platform**: Entwicklung und manuelle TUI-Abnahme auf
macOS; Release-Build/Test/Smoke als getrennte Linux- und Windows-CI-Gates. Die
autorisierte minimale Änderung an `.github/workflows/ci.yml` ergänzt für den
exakten PR-Head auf `ubuntu-latest` und `windows-latest` jeweils Restore,
Release-Build, vollständige Release-Tests und Smoke mit Exitcode 0 sowie exakt
`SMOKE_OK`. Jobnamen oder Teilbefehle sind kein Ersatz.
**Projekttyp / Project type**: lokale, einprozessige Terminal-Anwendung mit
Core-Bibliothek.
**Leistungsziele / Performance goals**: Smoke endet innerhalb von 30 Sekunden;
keine neue wahrnehmbare Verzögerung bei Start, Navigation, Dialog oder Quit.
**Grenzen / Constraints**: Produktdiff nur in `MicroCalc.Tui.csproj` und
`Program.cs`; einzige Automationsänderung exakt `.github/workflows/ci.yml`;
keine FakeDriver-Tests, keine Änderung vorhandener Testquellen, kein anderer
Workflow, kein Rename im Produkt-PR und keine Folgefunktion.
**Umfang / Scale**: ein Anwendungsprozess, ein Root-Runnable, verschachtelte
Dialog-Sessions, 13 bindende Tasteneingaben und zwei Quit-Pfade.

## Verfassungsprüfung / Constitution Check

### Vor Phase 0 / Before Phase 0

| Prüffeld / Checkpoint | Entscheidung und Nachweisvertrag / Decision and evidence contract |
|---|---|
| Branch und PR / Branch and PR | `Applicable`. Eigener Branch `003-terminalgui-migration`, fokussierter Implementierungs-PR und nur bei kausal nötigen Post-Merge-Artefakten genau ein vorbenannter Closeout-Pfad `codex/003-terminalgui-migration-closeout`. |
| Delivery Authority / Delivery authority | `Applicable`. `requirements/intakes/series/tinycalc-delivery/operation.json` und `receipt.json` belegen Thorsten als Autorisierer für `MergeAndSync` und eng begrenzten Admin-Bypass. Direkt vor dem konkreten PR/Policy-Eingriff erneut prüfen; der Bypass gilt nur für Merge-Berechtigung/Ruleset und niemals für fehlende Fach-, Security-, A11Y-, Review-, Plattform- oder Exact-Head-Evidenz. |
| Level-2-Register / Level-2 registry | `Applicable`. TinyCalc-Zeile bindet .NET 10/C#, Solution-Restore/Build/Test, xUnit, Smoke, DE/EN-A11Y, Statistik `80`/`125` und Agentenflächen. |
| Toolchain | `Applicable`. `net10.0`, C# 14 und Release mit aktivem CS1591 bleiben erhalten; Terminal.Gui `2.4.17` zielt offiziell auf .NET 10. |
| MSL und Secure Coding | `Applicable`. C# ist MSL; Ressourcenbesitz, Event-Eingaben, Fehlerausgabe und Paketgrenze werden trotzdem nach Principle XII geprüft. |
| Architekturgrenze | `Applicable`. Nur TUI-Laufzeitkopplung, lokale Tastatureingabe und NuGet-Lieferkette ändern sich. Core-Schnittstelle, Datei-I/O, Rechte und Deployment bleiben gleich. |
| Defense in Depth | `Applicable`. Exakte Paketversion plus Restore-Audit/SBOM; Quellverträge plus Build/Test/Smoke/manuelle TUI-Abnahme bilden unabhängige Schichten. |
| Fail-safe und Least Privilege | `Applicable`. Ungepflegte oder bekannt verwundbare ausgelieferte Pakete, unbekannte oder inkompatible ausgelieferte Lizenzen, fehlende Coverage oder Plattformbelege blockieren. Es entstehen keine neuen Rechte, Secrets oder Netzwerkfunktionen. |
| Bilingual/A11Y | `Applicable`. Neue Nachweise sind DE zuerst, EN danach, CEFR B2 und text-first. Die TUI wird gegen WCAG 2.2 AA 1.4.1, 2.1.1, 2.1.2, 2.4.3 und 2.4.7 manuell geprüft. |
| Public XML/DocFX | `N/A` im geplanten Scope. `Program` ist intern und keine öffentliche Signatur soll geändert werden. Trigger: jede öffentliche API- oder XML-Kommentaränderung; dann DocFX plus Text-/A11Y-Smoke gemeinsam. |
| Warum-Kommentare / Why-comments | Mechanische API-Syntax ist `N/A`. Eine nicht offensichtliche Besitz-, Fokus- oder Eingabeentscheidung macht moderate DE/EN-Warum-Kommentare `Applicable`. |
| Rot-Grün-Aufräumen | `Applicable`. Ein statischer Akzeptanzvertrag und der dependency-only Kompatibilitätszustand liefern Rot. Vor dem ersten geforderten grünen Whole-Solution-Build werden Lifecycle, Dialog-/Button-/Event- und Keyboard-APIs minimal vollständig compile-kompatibel migriert; spätere Schritte verfeinern Verhalten und Evidenz. |
| Coverage | `Applicable`. Changed-Code mindestens 70 %, Ziel 80 %. Out-of-process Coverage umfasst Smoke, Tests und den manuellen TUI-Lauf, ohne Testquellen zu ändern. |
| Dependency-Pinning | `Applicable`. Direkte Version exakt `2.4.17`, keine Floating Range. Ein neuer Repo-Lockfile-Modus ist außerhalb des akzeptierten Scopes; Neubewertung bei repositoryweiter Lockfile-Policy. |
| Serialisierung/Daten | `N/A` für Änderung. JSON-Format und Core-Datenmodell bleiben byte-/verhaltenskompatibel. Trigger: jede Änderung unter Core/IO/Model oder am Dateiformat. |
| Statistik | `Applicable`. `docs/project-statistics.md` und Konfiguration erhalten Feature-003-Werte mit 80/125 Zeilen pro Arbeitstag und 7,8 Stunden pro Tag. |
| Versionierung | `Applicable`. `Minor=3`; `Patch=git rev-list --count main..HEAD + 1` vor jedem Commit; `Build` steigt serialisiert vor jedem `dotnet build` und `dotnet test`; alle drei Felder bleiben gleich. |
| Agentenparität | `N/A`. Keine gemeinsame Regel, Vorlage oder Modell-Routing-Datei ändert sich. Trigger: erste solche Änderung. |
| Skriptparität | `N/A`. Kein Skript, Cmdlet oder Wrapper wird erstellt oder geändert. Die einzige Automationsänderung ist die autorisierte Produkt-CI-Matrix in `.github/workflows/ci.yml` mit identischen .NET-Befehlen auf Ubuntu und Windows; Trigger: jede weitere Automationsdatei oder abweichende Plattformlogik. |

### Sicherheitsstandards / Security Standards

Owner der Implementierung ist der Implementer; der Repository-Maintainer
besitzt die Evidenz. Security-, C#-, A11Y- und PR-Reviewer werden im Laufnachweis
vor Abschluss namentlich oder durch unveränderliche Review-ID gebunden.

*The implementer owns code work and the repository maintainer owns evidence.
Security, C#, accessibility, and PR reviewers are bound by name or immutable
review identifier before closeout.*

| Standard oder Artefakt / Standard or artefact | Status | Evidenz und Wiedervorlage / Evidence and re-evaluation |
|---|---|---|
| NIST SSDF SP 800-218 | `Applicable` | `docs/security/security-checklist.md`; Prepare, Protect, Produce, Respond plus exact-head delivery. |
| CWE Top 25 und C#/.NET | `Applicable` | Eingabe-, Ausnahme-, Ressourcen- und Dependency-Review im Security-Check. |
| STRIDE/CIA, CAPEC-153 und CAPEC-538 | `Applicable` | `docs/security/threat-model.md`; Tastatur- und NuGet-Grenze, Restrisiko und Review. |
| Security Quality Scenarios | `Applicable` | `docs/security/security-quality-scenarios.md`; manipulierte Taste, Paketmanipulation, sichere Beendigung. |
| OWASP Cheat Sheets/Proactive Controls | `Applicable` | Ergänzende Review-Linse; strengere C#/.NET-Regeln gehen vor. |
| OWASP ASVS | `N/A` | Kein Web/API/HTTP/Auth/Mehrbenutzer. Trigger: entsprechender Dienst. |
| SBOM | `Applicable` | SPDX-JSON unter `docs/security/sbom/`; mit `syft` aus dem Release-Drop erzeugt und in `supply-chain-evidence.md` referenziert. |
| SLSA v1.2 | `Applicable` | Exakter CI-Head, Workflow/Job/Befehl und realer Provenance-Status in `docs/security/supply-chain-evidence.md`; kein höheres Level ohne Attestation behaupten. |
| VEX | `N/A` bedingt | Solange kein zu bewertender Fund vorliegt. VEX darf nur Fehlalarme oder bewertete nicht ausgelieferte Komponenten klassifizieren; eine bekannte Schwachstelle in einer ausgelieferten direkten oder transitiven Abhängigkeit blockiert bis zur ausdrücklich autorisierten und abgeschlossenen Aktualisierung oder Ersetzung. |
| AI-SBOM | `N/A` | KI ist nur Entwicklungswerkzeug. Trigger: Modell, Datensatz, Inferenzdienst oder KI-Runtime im Produkt. |
| OpenSSF Scorecard | `Applicable` | Upstream-Posture von `tui-cs/Terminal.Gui` in `docs/security/dependency-audit.md`; Version und Abrufzeit festhalten. |
| Dependency Automation/Track | `N/A` für Änderung | Kein Dependabot/Renovate/Dependency-Track-Scope. Fehlen wird als Restrisiko dokumentiert; Trigger: Supply-Chain-Automatisierungsfeature oder Hosting-Freigabe. |
| OWASP SAMM | `Applicable` | `docs/security/samm-assessment.md` auf migrationsbedingte Befunde prüfen; bei keinem neuen Befund „reviewed, unchanged“ belegen. |
| Fokussierter S-ADR | `Applicable` | `docs/security/adr/003-terminalgui-lifecycle-supply-chain.md` hält Lifecycle-Ownership und die fail-closed Entscheidung für Schwachstellen und Lizenzen fest. Ein allgemeiner nicht sicherheitsbezogener ADR bleibt ohne neue Komponente oder Schicht `N/A`. |
| arc42 Section 8 | `Applicable` | `docs/security/arc42-security.md` wird für Lifecycle, Trust Boundaries, Eingaben, Abhängigkeiten, Fehler, Logging und Deployment vollständig aktualisiert. |
| Lizenz-Compliance | `Applicable` | `docs/security/dependency-audit.md` und `docs/security/supply-chain-evidence.md` belegen für jede direkte/transitive ausgelieferte Abhängigkeit Lizenz, Quelle, Kompatibilität und Disposition; null unbekannte oder inkompatible ausgelieferte Lizenzen. |
| Security-Index | `Applicable` | `docs/security/README.md` wird vor der Dokumentationsprüfung von `Stub` auf abgeschlossen gesetzt und indexiert den S-ADR sowie alle Security-Artefakte und N/A-Evidenzorte. |
| Zero Trust | `N/A` | Lokale Einzelprozess-TUI. Trigger: verteilte, Remote- oder Cloud-Architektur. |
| BSI C3A/C5 | `N/A` | Keine Cloud-/Provider-Auswahl. Trigger: Cloud, Hosting oder Managed Service. |
| NIS2, CRA, EU AI Act, DORA | `N/A` | Kein neuer Markt-, Kunden-, Betreiber-, KI- oder Finanzsektor-Scope. Trigger: entsprechender Rechts-/Lieferkontext. |
| OpenSSF Scorecard für TinyCalc selbst | `Applicable` als Repository-Review | Öffentlicher OSS-Delivery-Kontext wird vor Merge geprüft; keine Score-Schwelle ohne lokale Policy erfinden. |

### Preset-Anwendbarkeit / Preset Applicability

Security, Architektur, iSAQB, A11Y und autonome Ausführung sind `Applicable`.
Cross-Platform ist für Produktplattformen `Applicable`, für Skriptparität
`N/A`. Agentenparität und parallele autonome Ausführung sind `N/A` mit den oben
genannten Triggern. Kein Checkpoint bleibt `Open`.

*Security, architecture, iSAQB, accessibility, and autonomous delivery apply.
Cross-platform governance applies to product platforms but not scripts. Agent
parity and parallel autonomous execution are N/A with the stated triggers. No
checkpoint remains Open.*

### Dokumentationswirkung / Documentation Impact

**Entscheidung / Decision**: `UpdateRequired`

| Feld / Field | Festlegung / Decision |
|---|---|
| Quelle/Owner | Intake und `spec.md`; Repository-Maintainer. |
| Zielgruppen | Nutzer*innen, Auszubildende ab Jahr 1, Entwickler*innen, Reviewer, KI-Agenten. |
| Leserpfad | Feature-Plan → Architektur/Security/A11Y/Coverage → PR-Nachweis → autonomer Abschluss. |
| Dokumentklassen | Feature-Design, Architektur, Security, A11Y, Dependency/Supply Chain, Coverage, Statistik, PR. |
| Navigation | Keine DocFX-Navigation; Pfade werden aus Plan und PR verlinkt. |
| Sprache | Inline DE-first/EN-second, CEFR B2; maschinenlesbare JSON/XML-Artefakte besitzen bilinguale Begleittexte. |
| Plattformbeleg | macOS manuell; Linux und Windows durch echte CI-Runner und Befehlslogs. |
| Distribution | Source/PR plus SPDX-SBOM; keine Home-Synchronisation. |
| Generierte Ableitungen | Statistikprofil und SPDX-SBOM; DocFX `N/A` ohne Trigger. |
| Review-Evidenz | `autonomous-run-evidence.md`, Feature-Evidenzdateien und unveränderliche PR-/CI-Referenzen. |
| Trigger | API/XML/DocFX, neue Nutzertexte, Plattformabweichung, Paketfund oder Scope-Drift. |

## Projektstruktur / Project Structure

### Planungsartefakte / Planning Artefacts

```text
specs/003-terminalgui-migration/
├── spec.md
├── plan.md
├── research.md
├── data-model.md
├── architecture.md
├── security-plan.md
├── accessibility-plan.md
├── dependency-plan.md
├── supply-chain-plan.md
├── coverage-plan.md
├── delivery-plan.md
├── quickstart.md
├── contracts/
│   ├── tui-compatibility-contract.md
│   └── delivery-evidence-contract.md
├── checklists/
│   ├── requirements.md
│   └── plan-review.md
├── autonomous-run-gate-requirements.json
├── autonomous-run-evidence.md
└── autonomous-run-state.json           # lokal-operativ, ungetrackt, nie Delivery-Set
```

`tasks.md` entsteht erst in `/speckit.tasks`. Rohberichte werden später unter
`specs/003-terminalgui-migration/evidence/` oder einem ausdrücklich benannten
temporären Pfad erzeugt. Diese Planphase erzeugt keine Implementierungsevidenz.

*`tasks.md` is created only by the tasks phase. Raw reports later live under the
feature evidence directory or an explicitly named temporary path. Planning does
not claim implementation evidence.*

### Geplanter Änderungssatz / Planned Change Set

```text
src/MicroCalc.Tui/
├── MicroCalc.Tui.csproj                  # Terminal.Gui 2.4.17
└── Program.cs                            # v2 namespaces, lifecycle, events, keys

Directory.Build.props                    # ausschließlich Versionsvertrag

.github/workflows/ci.yml                 # einzige Workflow-Ausnahme: Ubuntu/Windows Produkt-CI

docs/
├── PR_TEXT_TERMINALGUI_MIGRATION.md
├── accessibility/terminalgui-migration.md
├── architecture/terminalgui-migration.md
├── project-statistics.config.json
├── project-statistics.md
└── security/
    ├── README.md
    ├── arc42-security.md
    ├── adr/003-terminalgui-lifecycle-supply-chain.md
    ├── dependency-audit.md
    ├── samm-assessment.md                # nur neuer Befund oder reviewed/unchanged
    ├── security-checklist.md
    ├── security-quality-scenarios.md
    ├── supply-chain-evidence.md
    ├── threat-model.md
    └── sbom/tinycalc-terminalgui.spdx.json

specs/003-terminalgui-migration/           # Plan, Tasks, Evidence, State
requirements/intakes/active/
└── Lastenheft_TerminalGui_Migration.003-terminalgui-migration.md
requirements/intakes/series/tinycalc-delivery/  # nur autorisierter Post-Merge-Nachfolger
```

`src/MicroCalc.Core`, `tests/`, `CALC.HLP`, `docfx.json`, `_site/`, Agenten- und
Spec-Kit-Vorlagen, Skripte, alle anderen Workflows und Feature-004-Artefakte
bleiben unverändert.

*Core, tests, help, DocFX, agent/template/script surfaces, every other workflow,
and Feature 004 remain unchanged.*

**Strukturentscheidung / Structure decision**: Die vorhandene Core-/TUI-Grenze
bleibt. `Program` erhält die v2-Adapterarbeit, aber keine neue Projekt- oder
Abstraktionsschicht. `IApplication` wird an Lifecycle-abhängige Builder und
Callbacks übergeben; ein neues statisches Application-Singleton wird nicht
eingeführt.

## Technisches Design / Technical Design

### Instanz-Lifecycle / Instance Lifecycle

1. `--smoke` wird vor jeder Terminal-Initialisierung ausgewertet.
2. `Application.Create()` erzeugt genau eine `IApplication`-Instanz.
3. `Init()` startet den Terminal-Treiber; `using` garantiert Dispose auch bei
   Fehlern.
4. Ein explizit erzeugtes Root-Runnable besitzt Menu und Hauptfenster.
5. `app.Run(root)` läuft genau einmal; der Erzeuger disposed Root und Dialoge.
6. Verschachtelte Dialoge laufen über dieselbe Instanz und kehren zur
   vorherigen Session zurück.
7. Menü-Quit und `Ctrl+Q` rufen `app.RequestStop()` für die aktive Session auf.

*Smoke bypasses terminal initialisation. One `IApplication` instance owns the
driver lifecycle. The creator owns and disposes root and dialog runnables.
Nested dialogs use the same app and return to the prior session. Both quit paths
request a stop through that instance.*

### API-Migrationsinventar / API Migration Inventory

- Imports werden auf `Terminal.Gui.App`, `Terminal.Gui.Input`,
  `Terminal.Gui.ViewBase` und `Terminal.Gui.Views` oder die durch `2.4.17`
  tatsächlich verlangten v2-Namespaces aufgeteilt.
- Statisches `Application.Top`, parameterloses `Application.Run()` und
  `Application.Shutdown()` werden entfernt.
- `Application.Run(dialog)` und `Application.RequestStop()` werden durch die
  gebundene Instanz ersetzt; Besitz/Dispose wird sichtbar.
- `Key.CtrlMask | Key.X` wird zu `Key.X.WithCtrl`; Alt-Masken bleiben null.
- `KeyPress`/`KeyEventEventArgs` werden auf v2-`KeyDown` bzw. KeyBindings mit
  korrektem Handled-Vertrag migriert.
- `Button.Clicked`, Konstruktoren und Property-Namen werden nur soweit geändert,
  wie der Compiler für v2 verlangt; Nutzertexte und Layoutabsicht bleiben gleich.
- `Ctrl+Q` bleibt ausdrücklich erhalten, obwohl v2 standardmäßig `Esc` als Quit
  nutzen kann; die Anwendung bindet ihr historisches Verhalten bewusst.

### Rot-Grün-Aufräumen und vertikaler Schnitt / Red-Green-Refactor and Vertical Slice

**Rot / Red**: Ein PowerShell-Akzeptanzvertrag prüft vor der Änderung die exakte
Paketversion, verbotene statische Lifecycle-Symbole, Masken und v2-Symbole und
muss auf dem Ausgangsstand mit erwarteten Befunden fehlschlagen. Danach wird
nur die PackageReference geändert; der erste Release-Compile/Test-Aufruf ist
als erwartete Kompatibilitäts-Rotphase lokal gebunden. Unerwartete Fehler oder
Core/Testfehler dürfen nicht als erwartetes Rot gruppiert werden.

**Repräsentativer vertikaler Schnitt / Representative vertical slice**:
Vor dem ersten geforderten grünen Whole-Solution-Build umfasst der minimale
compile-kompatible Schnitt `--smoke`-Bypass, `IApplication` Create/Init, Root,
`app.Run(root)`, Quit und Dispose sowie alle compilerbedingt nötigen v2-
Anpassungen für Dialoge, Buttons, Events und Keyboard-APIs. Erst danach darf
Release grün gefordert werden; Smoke `SMOKE_OK` und manueller Start/Quit belegen
den repräsentativen Ablauf.

**Weitere Grünphase / Further green work**: Die bereits compile-kompatiblen
v2-Events, Dialogläufe und 13 Tasteneingaben werden in kleinen Schritten auf
vollständige Verhaltens-, Fokus-, Ownership- und Evidenzparität verfeinert.

**Aufräumen / Refactor**: Wiederholte App-Weitergabe und Dispose-Pfade werden
vereinfacht, ohne neue Schicht. Verbotene APIs bleiben bei null Treffern;
vollständige Tests, Coverage und manuelle Matrix folgen.

Vorhandene Testquellen bleiben unverändert. Das Rot entsteht durch ausführbare
Akzeptanzverträge und den echten Dependency-Kompatibilitätszustand; FakeDriver
bleibt Follow-up.

## Umsetzungsphasen / Implementation Phases

### Phase 0 – Revalidieren und Gates einfrieren / Revalidate and Freeze Gates

- Hashes, Ready-Review, Branch, Run-State, Preset-Stack und Scope prüfen.
- `autonomous-run-gate-requirements.json` validieren und unverändert als
  Anforderungsbasis für Schema-2.0-Evidence binden.
- Vollständige Compile-/Execution-Surface und alle Validator-Konsumenten mit
  `rg` inventarisieren.
- Terminal.Gui `2.4.17`, NuGet-Quelle, Wartungsstatus und .NET-10-Ziel erneut
  prüfen; Drift blockiert.

### Phase 1 – Rot und vollständiger Compile-Kompatibilitäts-Schnitt / Red and Complete Compile-Compatibility Slice

- Build-Zähler vor jedem Build/Test serialisiert erhöhen.
- Statischen Rot-Vertrag ausführen und erwartete Fehler einzeln dokumentieren.
- Nur PackageReference ändern, Dependency-Rot erfassen.
- Kleinsten instanzbasierten Root-Lifecycle einschließlich Smoke-Bypass und
  Quit-Anbindungen sowie die minimale vollständige v2-Compile-Kompatibilität
  für Dialoge, Buttons, Events und Keyboard-APIs implementieren; erst danach
  Green-Build, Smoke und manuellen Start/Quit belegen.

### Phase 2 – API-, Dialog- und Tastaturmigration / API, Dialog, and Keyboard Migration

- Die bereits compile-kompatiblen Namespace-, Konstruktor-, Event- und
  Property-Änderungen in `Program.cs` verhaltensgetrieben verfeinern.
- Alle Dialoge über dieselbe `IApplication`-Instanz starten und im Owner
  disposen; Rückkehrfokus prüfen.
- Acht Masken-Ausdrücke entfernen und 13 Eingaben mit `WithCtrl`/v2-Key-Syntax
  abbilden; keine unbekannte Taste neu deuten.
- Nach jedem kleinen Schritt den vorher definierten Green-Vertrag ausführen;
  kein Schritt darf erst dann einen für den ersten Green-Build nötigen
  Compile-Blocker auflösen.

### Phase 3 – Regression, Coverage und Plattformen / Regression, Coverage, and Platforms

- Release-Restore, Build, vollständige Tests und Smoke ausführen.
- `dotnet-coverage` für Tests, Smoke und manuellen TUI-Lauf sammeln und zu
  Cobertura zusammenführen; Diff-Zeilen gegen `main` auf Treffer abbilden.
- Mindestens 70 % Changed-Code-Coverage belegen; 80 % anstreben und Ergebnis
  mit Zähler/Nenner dokumentieren.
- Manuell alle 13 Eingaben, Menü/Dialog-Rückkehr, Menü-Quit und `Ctrl+Q` auf
  macOS in zwei Sitzungen ausführen: zwölf Navigationsinputs plus Menü-Quit,
  danach `Ctrl+Q` als dreizehnter Input und zweiter Quit-Pfad. SC-006 bewertet
  wörtlich den ersten Versuch jeder Sitzung; ein Fehlversuch bleibt ein
  gescheiterter Akzeptanzlauf und darf nicht als „erster erfolgreicher Versuch“
  umgedeutet werden.
- `.github/workflows/ci.yml` als einzige Workflow-Änderung minimal um echte
  Produktjobs auf `ubuntu-latest` und `windows-latest` ergänzen; beide führen
  für den exakten PR-Head Restore, Release-Build, vollständige Release-Tests
  und Smoke mit Exitcode 0 sowie exakt `SMOKE_OK` aus. Die echten Logs binden;
  Jobnamen oder Teilbelege genügen nicht.

### Phase 4 – Security, Architektur, A11Y und Dokumentation / Evidence

- STRIDE/CAPEC, Security-Checkliste, Dependency Audit, SAMM-Review und
  Qualitäts-Szenarien aktualisieren.
- `docs/security/arc42-security.md` vollständig für Lifecycle, Trust Boundaries,
  Eingaben, Abhängigkeiten, Fehler, Logging und Deployment aktualisieren und
  den fokussierten S-ADR
  `docs/security/adr/003-terminalgui-lifecycle-supply-chain.md` für
  Lifecycle-Ownership sowie fail-closed Schwachstellen-/Lizenzentscheidungen
  erstellen.
- Vollständigen Paketgraph und Vulnerability-JSON erfassen. Jede bekannte
  Schwachstelle in einer ausgelieferten direkten oder transitiven Abhängigkeit
  blockiert bis zu einer ausdrücklich autorisierten und abgeschlossenen
  Aktualisierung oder Ersetzung. VEX klassifiziert nur Fehlalarme oder
  bewertete nicht ausgelieferte Komponenten und autorisiert keinen bekannten
  ausgelieferten Fund.
- Für jede direkte und transitive ausgelieferte Abhängigkeit Lizenz, Quelle,
  Kompatibilität und Disposition belegen; unbekannte oder inkompatible
  ausgelieferte Lizenzen blockieren.
- Release-Drop mit `syft` als SPDX-JSON inventarisieren; SLSA-Status ohne
  überhöhte Level-Behauptung dokumentieren.
- Alle N/A-Sicherheitsdispositionen in den benannten Security-/Supply-Chain-
  Nachweisen ablegen und `docs/security/README.md` vor der umfassenden
  Dokumentationsprüfung von `Stub` auf abgeschlossen setzen sowie den S-ADR
  indexieren.
- Architektur- und A11Y-Nachweise DE-first/EN-second, CEFR B2 und text-first
  abschließen.
- Statistikprofil und PR-Text aktualisieren; DocFX bleibt nur ohne Trigger
  `N/A`.

### Phase 5 – Review, MergeAndSync und Serien-Follow-up / Delivery and Follow-up

- Nur beabsichtigte getrackte und benannte unversionierte Pfade mit dem
  Delivery-Set-Validator prüfen; Indexzustand erhalten.
- Version auf `1.3.<prospektiver Commitcount>.<Build>` ausrichten, fokussiert
  mit der exakten Trailerzeile
  `Co-authored-by: Copilot <223556219+Copilot@users.noreply.github.com>`
  committen, Trailer maschinenlesbar prüfen, pushen und PR erstellen, sofern
  aktuelle Autorität dies weiterhin erlaubt.
- Schema-2.0-PreMerge-Evidence an exakten Head und Requirement-Hash binden;
  reale Workflow-Befehle und Runner aus Definition/Logs erfassen.
- Review-Threads und Change Requests bis null konvergieren; fehlender Reviewer
  ist keine Zustimmung. Thorstens enge Admin-Bypass-Autorität unmittelbar vor
  dem konkreten PR und der konkreten Policy revalidieren und mit Autorisierer,
  Umfang, Grund und Restrisiko belegen; sie ersetzt kein technisches oder
  Review-Gate. Den Produktmerge mit expliziten `gh pr merge --subject`- und
  `--body`-Optionen ausführen, die den exakten Co-author-Trailer in den
  Provider-Merge-Commit aufnehmen; den tatsächlichen Merge-Commit sofort
  read-only beim Provider lesen und den Trailer exakt einmal prüfen, bevor
  `main` fast-forward synchronisiert wird.
- Schema-2.0-PostMerge-Evidence an akzeptierten PreMerge-Hash und tatsächlichen
  Merge-Commit binden.
- Erst nach Implementierungsmerge und neuer Autoritätsprüfung das Lastenheft
  branchgestempelt umbenennen und genau die Serie `tinycalc-delivery` mit
  archivierter Vorgängerlinie aktualisieren. Nur Status prüfen; Feature 004
  bleibt ungestartet. Alle getrackten Closeout-Nachweise werden vor dem einzigen
  Closeout-PR-Merge in dessen einen Commit aufgenommen; auch dieser Commit und
  sein Amend enthalten den exakten Co-author-Trailer. Auch der Closeout-Merge
  verwendet explizite Subject-/Body-Optionen mit Trailer und prüft den
  tatsächlichen Provider-Merge-Commit unmittelbar read-only. Nach dem Merge werden
  Provider- und Sync-Fakten ausschließlich read-only in Runtime-Evidenz
  verifiziert. `delivery.md` und alle anderen getrackten Dateien bleiben danach
  unverändert. Der feature-lokale Run-State bleibt von Anfang bis Ende
  ungetrackt, wird lokal über `.git/info/exclude` verborgen und darf nie in ein
  Delivery-Set gelangen; dadurch kann der Phase-Wrapper ihn nach Rückkehr
  aktualisieren, ohne `main` zu verändern. Ein dritter Commit oder PR ist
  verboten.
- Falls diese kausalen Post-Merge-Artefakte einen Diff erzeugen, genau den
  vorbenannten Branch `codex/003-terminalgui-migration-closeout` verwenden;
  kein leerer PR und kein dritter Folgepfad. `Completed` erst nach terminalem
  Merge, Sync, Post-Merge-Aktionen und finaler Validierung.

## Validierungs- und Evidenzmatrix / Validation and Evidence Matrix

Die ausführlichen Befehle und Plattformen stehen in `quickstart.md`,
`coverage-plan.md`, `supply-chain-plan.md`, `delivery-plan.md` und dem
maschinenlesbaren Gate-Artefakt. Jede spätere Evidence-Zeile kopiert ihren
`requiredScope` exakt.

*Detailed commands and platforms live in the focused planning artefacts and the
machine-readable gate contract. Every later evidence row copies its required
scope exactly.*

Das strukturierte Plan-Review-Phasenresultat liegt gemäß aktivem Runner-Profil
exakt unter
`.specify/runtime/autonomous-routing/38ad4c1d-bf85-4053-b585-eb490176b727/plan-review.result.json`.
Es bindet als Payload den nach Remediation abschließend geprüften `plan.md`-Hash
und darf erst nach 40/40 bestandenen Punkten in `checklists/plan-review.md`,
gültigem Run-State und vollständigen Review-Gates `Completed` melden. / *The
structured plan-review result uses the exact runner path above and binds the
finally remediated `plan.md` hash. It may report `Completed` only after 40/40
plan-review checks, valid run state, and complete review-gate evidence.*

```powershell
pwsh -NoProfile -File .specify/presets/autonomous-run-governance/scripts/validate-autonomous-phase-result.ps1 -Repo . -Result .specify/runtime/autonomous-routing/38ad4c1d-bf85-4053-b585-eb490176b727/plan-review.result.json -PhaseId plan-review -ExitCode 0
```

| Bereich / Area | Abschlusskriterium / Completion criterion | Primärer Evidenzpfad / Primary evidence path |
|---|---|---|
| Intake/Scope | Hashes gleich; nur erlaubter Produkt-/Evidenzumfang | `autonomous-run-evidence.md` |
| Dependency | 2.4.17 exakt, vollständiger Graph, null bekannte Schwachstellen und null unbekannte/inkompatible Lizenzen in ausgelieferten Paketen | `docs/security/dependency-audit.md` |
| Lifecycle/Keys | null alte Muster; ein Instanz-Lifecycle; 13 Eingaben | Architektur-, Coverage- und A11Y-Nachweis |
| Build/Test/Smoke | Release grün; 100 % bestehende Tests; `SMOKE_OK` | Run-Evidence und CI-Logs |
| Coverage | Changed lines >=70 %, Ziel 80 %, Rot/Grün/Refactor | `specs/003-terminalgui-migration/evidence/coverage-summary.md` |
| Security | SSDF/CWE/STRIDE/CAPEC/SAMM, vollständiges arc42, fokussierter S-ADR und abgeschlossener Security-Index | `docs/security/` |
| Supply Chain | SPDX-SBOM, Lizenz-Compliance, fail-closed Vulnerability-Status und ehrlicher SLSA-Status | `docs/security/supply-chain-evidence.md` |
| A11Y/Language | WCAG-Tastatur/Fokus und DE/EN CEFR B2 bestanden | `docs/accessibility/terminalgui-migration.md` |
| Delivery | Delivery-Set, schema 2.0, Reviews, Merge, Sync | temporäre Gate-Evidence plus Run-Evidence |
| Follow-up | Intake archiviert/Serie validiert; kein Nachfolger gestartet | Serienoperation und Statusausgabe |

## Risiken und technische Schulden / Risks and Technical Debt

| Risiko / Risk | Mitigation und Gate / Mitigation and gate |
|---|---|
| v2.4.17 besitzt mehr Breaking Changes als das Intake-Beispiel. | Compilergetriebenes Inventar, nur `Program.cs`, kleine Green-Schritte. |
| Instanz- und Dialogbesitz erzeugt Leaks oder beendet falsche Session. | „Creator owns and disposes“, verschachtelte Session- und Rückkehrprüfung. |
| Neue Key-API verändert Fokus oder Quit. | 13-Tasten-Matrix, zwei Quit-Pfade, unbekannte Taste als Negativfall. |
| Coverage ist ohne Teständerung schwer erreichbar. | Out-of-process Instrumentierung des echten manuellen TUI-Laufs; Gate bleibt blockierend. |
| Vollständige Linux-/Windows-Produkt-CI fehlt im aktuellen `ci.yml`. | Die aktuelle vollständige Feature-003-Autorität erlaubt exakt die minimale Änderung an `.github/workflows/ci.yml`: dieselben vier Produktbefehle plus exakte `SMOKE_OK`-Prüfung auf Ubuntu und Windows für den PR-Head; jeder andere Workflow-/Automationsdiff bleibt verboten. |
| Transitive Paketmenge wächst. | Restore-Audit, vollständiger JSON-Graph, SPDX-SBOM, Lizenz-Compliance, Upstream-Posture und fail-closed Schranke für jede bekannte ausgelieferte Schwachstelle. Paketänderungen bleiben auf Intake und exakte Version begrenzt; ein blockierender Fund benötigt neue Autorität für Update oder Ersatz. |
| Kein Repository-Lockfile und keine sichtbare Dependency-Automation. | Exakte direkte Version; Restrisiko dokumentieren; Neubewertung in eigenem Supply-Chain-Hardening-Scope. |
| Post-Merge-Fakten erzeugen selbstinvalidierenden Diff. | Alle getrackten Closeout-Belege werden vor dem einzigen Closeout-PR-Merge committed. Danach werden Provider-/Sync-Fakten nur read-only in Runtime-Evidenz geprüft; kein getrackter Write, dritter Commit oder PR. |

Die beabsichtigte Testlücke ohne FakeDriver bleibt bekannte technische Schuld
mit Owner Repository-Maintainer. Sie wird nach Feature 003 und vor einer
weiteren TUI-Funktionsänderung neu bewertet, aber nicht automatisch gestartet.

## Komplexitätsverfolgung / Complexity Tracking

| Abweichung / Deviation | Warum erforderlich / Why needed | Einfachere Alternative verworfen / Simpler alternative rejected |
|---|---|---|
| Changed-Code-Coverage über Tests plus echten manuellen Prozess | Testquellen und FakeDriver sind bindend außerhalb des Scopes, Coverage bleibt aber blockierend. | Nur vorhandene xUnit-Coverage würde die interaktiven geänderten Zeilen nicht ehrlich messen. |
| Linux- und Windows-CI als getrennte Delivery-Gates | Der Phaseninput bindet auf beiden echten Runnern Restore, Build, Tests und Smoke; der aktuelle Ubuntu-Job ist nur Teilbeleg und Windows fehlt. | Ein grüner Ubuntu-Job ohne Smoke oder ein Windows-förmiger Homogeneity-Job ist kein vollständiger technischer Beleg. |
| Kein neuer Lockfile-Modus | Das Feature darf keine repositoryweite Restore-Policy oder Test-/Core-Projekte ändern. | Lockfiles nur für einen Teil der Solution würden einen uneinheitlichen, nicht durch Intake akzeptierten Modus schaffen. |

**Nachentwurfs-Gate / Post-design gate**: bestanden. Alle Verfassungs-,
Security-, Architektur-, A11Y-, Cross-Platform-, Agent-, autonomen und
parallelen Checkpoints sind `Applicable` oder mit Begründung und
Wiedervorlage `N/A`. Die Designartefakte und Gate-Anforderungen existieren vor
jeder Implementierungsänderung. Offene Fachentscheidung und `NEEDS
CLARIFICATION` verbleiben nicht.
