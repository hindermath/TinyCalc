# Forschung und Entscheidungen / Research and Decisions

**Datum / Date:** 2026-10-12. Read-only Quellenprüfung; keine Produkt-/Screenreader-Ausführung.

*Read-only source review; no product or screen-reader execution.*

## RQ-001: Bestehende Architektur erhalten / Preserve Existing Architecture

**Entscheidung:** Die interne `TuiSession` bleibt einziger produktiver UI-Pfad. `Program` behält Start/Smoke, Core bleibt unabhängig. `PromptText` erzeugt Label, TextField, OK/Cancel und Default-Button-Korrektur; Hilfe besitzt eigenen Fokusumlauf. Kleine gemeinsame interne Hilfen nur bei wirklich wiederholter Logik, keine öffentliche API oder neue Bibliothek.

*Decision: retain TuiSession as the single production interaction path, Program for lifecycle/smoke and independent Core. Existing prompts and help supply focus/label integration points. Extract small internal helpers only for demonstrated repetition; no new public API/library.*

**Quellen:** `src/MicroCalc.Tui/TuiSession.cs`, `Program.cs`, `TerminalStateLease.cs`, `GridColorScheme.cs`, `docs/architecture/tui-functional-contract.md`. Alternative vollständiger Rewrite verworfen: unnötige Vertrags-/Regressionsgefahr, nicht beauftragt.

*Sources: existing production and architecture files above. Reject a rewrite because it unnecessarily risks contracts and exceeds authority.*

## RQ-002: Native Fokusansage früh prüfen / Verify Native Focus Speech Early

**Entscheidung:** CQ-001/CQ-002 sind verbindlich: Mac A/Terminal.app/VoiceOver, aktuelle Umgebung je Lauf; unmittelbare eindeutige Aktion ohne zusätzliche Leseschritte. Read-only Quellen reichen nicht für Machbarkeit. Gate beim nächsten autorisierten Produktlauf, vor breiter Korrektur. Beim Scheitern Fail/Open und Thorsten um Entscheidung bitten. Keine Zusage eines erreichbaren nativen Rollenmodells.

*Decision: apply both accepted clarifications and test native feasibility before broad correction in a separately authorised execution. Read-only sources cannot prove it. Failure requires an explicit decision, not a compatibility promise.*

[Apple](https://support.apple.com/en-ca/guide/terminal/trml1020/mac) beschreibt Terminaltextlesen, Control/Option-Navigation und getrennte/gekoppelte Cursor. [Microsoft](https://learn.microsoft.com/en-us/dotnet/standard/building-console-apps) beschreibt Console-Zeichen-/Stream-I/O. Daraus wird hier nur die Nachweisgrenze abgeleitet: diese Quellen belegen nicht TinyCalcs unmittelbare Aktionsansage. Geprüft am 12.10.2026. Der Suchtreffer `gui-cs.github.io/Terminal.GuiV2Docs/docs/` lieferte beim Öffnen 404 und wird nicht als Fähigkeitsnachweis verwendet. Maßgeblich bleibt der tatsächliche freigegebene Paketstand, nicht eine vermutete aktuelle API.

*Apple documents terminal text reading and cursor navigation; Microsoft documents character/stream console I/O. Inference: neither source establishes TinyCalc's immediate action announcement. Checked on 12 October 2026. The old Terminal.Gui V2 docs search result returned 404 and supplies no capability proof. Use the actual approved package, not an assumed current API.*

Zeilenlesen als gleichwertige Abnahmealternative ist durch Antwort A ausgeschlossen. Eine neue Bridge, ein Frameworkwechsel oder Ersatzmodus benötigt gesonderte Entscheidung und Scopeprüfung, nicht stillschweigende Planung als bereits freigegebene Lösung.

*Line reading cannot substitute for acceptance. A bridge, framework change or replacement mode needs separate scope/design authority.*

## RQ-003: Bericht und Reproduktion trennen / Separate Reports from Reproduction

[Issue #107 samt Kommentaren](https://github.com/hindermath/TinyCalc/issues/107) erneut read-only eingesehen. B01/B02 und hilfreiches Zeilenlesen bleiben berichtet, nicht vom Agenten reproduziert. `tests/MicroCalc.Tui.Tests/UiContractActions.cs` enthält den zusätzlichen End-Tippweg; ein neuer Regressionstest muss direkte Folgezeichen ohne diese Zwischenaktion ausführen. Keine bestätigte Ursache aus diesem Unterschied ableiten. Historische Pass-Protokolle unverändert lassen.

*Re-read issue #107 and its comments read-only. Reports remain reports, not agent reproduction. The input helper's inserted End motivates an independent direct-typing test, not a root-cause claim. Preserve historical acceptance files.*

## RQ-004: Baseline, Bindungen und Archivpfad / Baseline, Bindings and Archive Path

**Entscheidung:** Die unabhängige Feature-006-Baseline und stabilen IDs erhalten; neue A11Y-Wege additiv binden. Bestehende Producer, Assertion-Proofs, Gate-/Bundle-Schemas und lesende Validatoren erweitern statt einen konkurrierenden Nenner schaffen. Menschliche Sprache bleibt eigene Evidenz, keine künstliche automatisierte Assertion.

*Retain the independent baseline and stable IDs. Extend existing proof machinery instead of creating a competing denominator; native human speech remains separate proof.*

**Befund:** `scripts/test-tinycalc-contract.ps1` liest das Funktions-Intake über `requirements/intakes/active/Lastenheft_TUI-Funktionsabnahme-und-Regressionsvertrag.md`. Die vorhandene Governance archiviert es unter `requirements/intakes/archive/`. Alignment besteht, aber ein Validatorlauf wird hier nicht als bestanden behauptet. Spätere Korrektur muss eindeutige lifecycle-gebundene Auflösung, ursprünglichen Inhaltshash und Negativtests zu fehlender/doppelter/manipulierter Quelle bewahren. Keine Governancequelle ändern, um technische Prüfungen grün zu bekommen.

*The functional validator still hard-codes an active intake path after archival. Governance alignment passes; no functional validator pass is claimed. Future repair must uniquely resolve the lifecycle-bound source and preserve content hashes and missing/duplicate/tampered-source negative tests. Do not alter governance to obtain a green result.*

## RQ-005: Dependency und Nachweise / Dependencies and Evidence

Der deklarierte Pin ist derzeit Terminal.Gui 2.4.17, Projekte `net10.0`; dies ist Inspektion, keine neue Freigabe oder Kompatibilitätsprüfung. Später vier Locks, genehmigten Pin/Graph und Preflight prüfen, Locked Restore ausführen. Drift erzwingt volle Kompatibilität/PTY/A11Y; kein automatisches Upgrade. Öffentliche Paketverfügbarkeit ist für diesen A11Y-Lauf kein Ersatz dieser Prüfung.

*Current declarations show Terminal.Gui 2.4.17 and net10.0, not renewed approval/compatibility proof. Future execution verifies all locks and approved graph and performs locked restore. Drift requires full evidence without automatic upgrade.*

## Restpunkte und Owner / Remaining Work and Owner

Keine unbeantwortete fachliche Entscheidung. Technische Ausführung offen: native Fokusansage, direkte Eingabe, lifecycle-fester Validator, Kontrastmessung und vollständige Plattform-/Dokumentationsmatrix. Owner Thorsten; Folgeaktion separat autorisierte Umsetzung nach Plan-/Taskprüfung; Wiedervorlage vor erster Produktänderung und finalem Kandidaten. Keine dieser offenen Ausführungen wird durch Planung als Pass geschlossen.

*No unanswered product choice remains. Native speech, direct input, lifecycle-aware validation, contrast and complete platform/docs proof await authorised execution. Thorsten owns follow-up before implementation and final candidate; planning closes none of these as passes.*
