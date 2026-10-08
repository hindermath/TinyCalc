# Recherche und Entscheidungen / Research and decisions

Stand: 2026-10-07, Basis `de65e8db85f3bc7fb4361aa0c49a894938ce3e56`. Diese Untersuchung liest lokale Quellen; sie behauptet keine aktuellen Paket-, CVE-, Rechts- oder Providerprüfungen.

*Local source research, not a current registry, vulnerability, legal or provider audit.*

## R-01 — Vier Projekte und echte UI-Pfade / Existing projects and real UI paths

`Program.cs` besitzt derzeit statische Engine/View-Felder und private Menü-, Tastatur-, Editor- und Dialogmethoden. `PromptButtonDefaultsTests` prüft nur die Enter-Rolle; `TuiSmokeTests` prüft Smoke, nicht den Gesamtvertrag. Entscheidung: minimale interne `TuiSession` mit Engine und Views je Sitzung; Program bleibt Lebenszyklus-/CLI-Einstieg. Tests verwenden dieselben Views und Bindings, keine doppelte Fachlogik. Vor jeder Extraktion Verhalten durch rote Tests binden; bei jeder Sitzung sauber dispose/reset, keine parallelen globalen Framework-Sitzungen.

*Static UI state currently limits independent contract tests. Introduce a minimal internal session with real production views and actions; retain Program as the entry point. Test-first extraction and deterministic disposal prevent cross-test state leaks.*

Alternative direkte Engine-Aufrufe verworfen: Sie können die dokumentierten Menü-, Editor- und Abbruchfehler nicht erkennen. Neue öffentliche CLI-Testbefehle oder ein neues Produktprojekt verworfen: unnötige Angriffsfläche und Schichten.

*Direct engine tests cannot establish UI paths; public test commands or another product project add unnecessary surface.*

## R-02 — Framework-Injektion plus echtes PTY / Input injection plus real PTY

Die lokal vorhandene Paketdokumentation von Terminal.Gui `2.4.17`, `lib/net10.0/Terminal.Gui.xml`, beschreibt `IApplication.GetInputInjector()`, `Application.Create(ITimeProvider)` und `VirtualTimeProvider`. Diese vorhandene Schnittstelle ist Kandidat für deterministische Tastaturtests. Ihr Treiber-/Loop-Verhalten muss beim ersten Infrastruktur-Slice im bestehenden Pin kompiliert und ausgeführt werden; Dokumentation allein beweist nicht, dass ein CI-Host ohne Terminal korrekt funktioniert.

*Installed package documentation supports instance-based input injection and virtual time. Verify actual driver and loop behaviour in the first infrastructure slice; documentation alone is not runtime proof.*

Entscheidung: injizierte Eingaben durch echte Root-/Dialog-Views für Linux/Windows, zusätzlich macOS-Prozess-PTY. `expect` ist lokal als `/usr/bin/expect` vorhanden. Ein kleiner testseitiger PTY-Protokolladapter darf diese bestehende Fähigkeit nutzen, weil umgeleitete PowerShell-Streams keine echte Terminalsitzung belegen; Bash/PowerShell-Einstiege bleiben die verbindlichen Bedienvarianten. Keine neue Produktlaufzeit, kein automatischer Toolinstall. Falls der Adapter fehlt oder die Framework-Testfähigkeit nicht passt, Infrastruktur-Gate stoppen und alternative Umsetzung reviewen, nicht auf Smoke oder manuell ersetzte Funktion zurückfallen.

*Use real UI injection for native platform tests and a separate real macOS PTY. The existing Expect tool may supply a test-only terminal adapter. Missing capabilities block infrastructure validation; never replace functional automation with smoke or manual proof.*

PTY-Prüfung setzt `80x24` beziehungsweise `120x40`, beantwortet tatsächliche Terminal-Fähigkeits-/Keyboard-Abfragen, verarbeitet ANSI-Ausgabe in einen beobachtbaren Textzustand und bindet Rohtrace plus Textresultate. Ein einfaches grep im Escape-Strom ist kein Raster-/Fokusbeweis. Deadlines, Prozessgruppen-Cleanup und Terminalwiederherstellung prüfen; nur den eigenen Kindprozess beenden.

*PTY tests must handle terminal negotiation and visible text state, not just search escape output. Bound timeouts and clean up only owned processes.*

## R-03 — Separater JSON-Vertrag, additive IDs / Separate JSON contract, additive IDs

Entscheidung: `docs/contracts/tui/product-contract.json` mit getrenntem `source-map.json`, unabhängige Resultatbundles pro Plattform. JSON bleibt Daten, niemals ausführbarer Befehl oder untrusted Expression. Schema- und semantische Prüfung kombiniert; stabile IDs niemals recyceln, Deprecation nur mit expliziter Autorität. Ein lesbarer Katalog wird daraus abgeleitet und auf Drift geprüft. Veraltete Sources/Tests dürfen keinen Pass erzeugen.

*Keep contract, source inventory and platform results separate; treat JSON as data. Combine structural and semantic validation. IDs are never recycled and removal needs explicit authority.*

Markdown-only verworfen: Vollständigkeit/Pfadbindung schwer zuverlässig automatisierbar. Ein reines Testnamen-Inventar verworfen: vorhandene Methoden beweisen keine ausgeführten Assertions. Testresultate müssen Outcome, erwartete/ausgeführte Pfade und Hashbindung liefern; negative Mutationfixtures prüfen Testschwächung.

*Markdown or test names alone do not prove executed, meaningful coverage. Bind outcomes and execution counts and prove detection of weakened tests.*

## R-04 — Versionsneutraler Preflight / Version-neutral preflight

`MicroCalc.Tui.csproj` deklariert Terminal.Gui `2.4.17`; die vier Produkt-/Testprojekte besitzen keine eigenen `packages.lock.json`. Die vorhandenen Locks unter `scripts/lib/maintenance-tui/` gelten nicht für `MicroCalc.sln`. Altes Migrationsevidence weist zwar einen Restore nach, ist jedoch keine aktuelle Lock-/Gesamtfreigabe.

*A direct package version exists, but the solution projects lack locks. Maintenance-tool locks and historic migration restore evidence cannot stand in for current solution proof.*

Entscheidung: Preflight read-only, keine Version fest verdrahten oder upgraden. Exakte Freigabe, alle Deklarationen/Locks, Resolver-/Quellmetadaten und Vergleichsevidenz prüfen. Ohne passende Lock-/Freigabequelle blockieren. Genehmigte Vorbereitung darf reviewed Lockdaten erstellen und dann Locked Restore prüfen; Veränderungen der Auflösung werden als Drift behandelt. Unveränderter Pin macht bisher fehlende Nachweise nicht gültig.

*Resolve the approved version from actual declarations and locks without upgrading. Missing or inconsistent sources block; separately authorised preparation may establish reviewed locks. Classify changed resolution as drift.*

## R-05 — Workflow-Namen sind keine Produktnachweise / Workflow names do not prove coverage

`.github/workflows/ci.yml` führt Linux/Windows Restore, Build, Test und Smoke aus. Pushfilter enthalten `main` und Agentenpräfixe, aber keinen nummerierten `006-*`-Branch. Hosted macOS-Governance ist kein lokaler TUI-/PTY-Nachweis. Entscheidung: Vollvertrag als verpflichtenden Schritt in beiden nativen CI-Jobs ergänzen; Pushfilter so erweitern, dass auch nummerierte Feature-Pushes erfasst sind. Tatsächlichen Befehl, Job, Runner, Commit und Ergebnis statt grünem Gesamtsymbol binden.

*Current CI has native build/test/smoke but no complete contract step and omits numbered feature push branches. Add complete native regression and bind actual execution, not aggregate green status.*

## R-06 — Datenintegrität und Dokumentationsdefekte / Integrity and documentation defects

`SpreadsheetJsonStorage.Load` leert derzeit die Engine vor dem Durchlauf aller Zellwerte. Das ist eine zu prüfende Integritätsgrenze, noch kein nachgewiesener neuer Defekt. Test zuerst fehlerhafte/ungültige Dateien; bei bestätigter Teilmutation minimal staged validieren und erst dann anwenden, ohne Formatwechsel. Formelerkennung im `EditCell`-Pfad gegen alle dokumentierten Funktionen prüfen; Evaluator-Unit-Tests allein reichen nicht.

*Load clears the engine before processing cells: test the integrity boundary before claiming a defect. Any necessary correction stages validation before application without changing format. Exercise every function through EditCell and the real editor.*

Zusätzliche COUNT-Backticks und Beispiele außerhalb `A1:G21` sind belegte Dokumentationsdefektklassen, keine neue Fachsemantik. Inhaltliche Angebote der Quellen bleiben Vertrag. Unklare Abweichungen bleiben blockierend, keine stille Umfangsverkleinerung.

*Known typo/grid-example classes are documentation defects, not new semantics. Substantive offers remain contractual; unresolved conflicts block.*

## R-07 — Offene Freigaben / Open approvals

Nachprüfung anhand CHK001–CHK036: RQ-001 (Slash), RQ-002 (zusätzliche/widersprüchliche gebündelte Editier-/Befehlsangebote) und RQ-003 (fehlende angebotsspezifische Formelsemantik) ergänzen die bisherigen offenen Gates. `Program.HandleKey` behandelt `/` vor dem allgemeinen ASCII-Zweig; das belegt nur den Ist-Stand und genehmigt keine Ausnahme vom Intake. Page 4–6 der gebündelten Hilfe bieten weitere Wege an. `FormulaEvaluator.Factorial` trunciert Eingaben, während sein Fehlertext Integer fordert; eine technische Implementierung darf diese Semantik nicht ohne Quellenentscheidung normativ festlegen. Ein Tabellen-/Hilfetextdefekt bleibt getrennt von diesen substanziellen Fragen.

*The checklist review exposes three source findings. Current slash dispatch and factorial truncation are observations, not authority to resolve conflicting offers. Preserve additional bundled-help capabilities and distinguish semantic conflicts from typos.*

Klärung danach: Nutzerantwort A entscheidet RQ-001 kontextabhängig (Raster Palette, Editor Slash-Eingabe). Diese ausdrücklich getroffene Entscheidung ersetzt die vorherige offene Slash-Frage, nicht die weiterhin offenen RQ-002/RQ-003 oder die spätere Quellen-/Produktevidenz.

*User answer A subsequently resolves slash by context; remaining source questions and execution proof are not resolved by that decision.*

Die zweite Nutzerantwort A erhält alle historischen Funktionen und Tasten und löst RQ-002 kontextabhängig: zusätzlicher Ctrl-G-Rechtsalias im Raster, Löschung rechts im Editor und Neuzeichnen beim Palettenöffnen. Alle übrigen dokumentierten Editier-/Befehlsaliase bleiben Pflicht. Diese Entscheidung genehmigt keine Umfangsentfernung; RQ-003 und Produkt-/Quellenproof bleiben offen.

*The second answer A resolves historical offers without removal; all editor and command aliases remain required. Formula semantics and product/source proof remain pending.*

Dritte Nutzerantwort A entscheidet FACT: ganze Argumente 0 bis 33, Null ergibt 1, andere Argumente Fehler ohne Truncation. Der beobachtete Cast nach `Math.Truncate` bleibt als Ist-Befund erhalten und weicht vom Zielvertrag ab, insbesondere bei `-0.5` und `33.9`. Eine spätere test-first Korrektur benötigt eigene Implementierungsfreigabe; übrige RQ-003-Semantik bleibt offen.

*The third answer A selects strict integer FACT arguments 0 through 33, zero returning 1 and clear errors otherwise. Observed truncation remains current-code drift, notably for -0.5 and 33.9. A later test-first fix requires implementation authority; remaining formula semantics is Open.*

Keine neue rechtliche Entscheidung durch Recherche. Datierte Security-Vorprüfung beibehalten; Thorsten/qualifizierter Reviewer müssen Produkt-, Tool- und Organisationsrollen bis Planfreigabe klären. Neue Supplier-/CVE-/Releaseprüfungen erst im autorisierten Preflight live durchführen. Kein Registry-/Provideraufruf ist hier als bestanden behauptet.

*Preserve dated screening; human role clarification is due before plan approval. Live supplier and vulnerability checks belong to authorised execution, not presumed results.*

Vierte Antwort A entscheidet Operatorbindung: Potenzketten rechts, Potenz vor unärem Vorzeichen, Klammern zuerst. `ParseTerm` verarbeitet aktuell Potenzen in einer Schleife links und ruft vorher `ParseSignedFactor` auf; dies ist Ist-Drift zum genehmigten Zielvertrag. Die Beispiele der Spec werden spätere test-first Regressionen; keine Parseränderung hier. RQ-003 bleibt für numerische Definitions-/Ergebnisgrenzen Open.

*Answer A selects right-associated powers before unary signs. The current ParseTerm loop and prior ParseSignedFactor call are implementation drift, not target semantics. Future fixes require failing regression tests and separate authority; numeric boundaries remain Open.*

Fünfte Antwort A: Nur endliche reelle Ergebnisse; Definitionsfehler, Überläufe und NaN/Unendlich ergeben verständliche Fehler statt erfolgreicher numerischer Zellwerte. Die vier Fehlerorakel der Spec und endliche Kontrollfälle bei späterer Umsetzung test-first binden; keine Produktprüfung hier. Alle fünf Fragen dieser Nachprüfung sind beantwortet. RQ-003 bleibt für fehlende Quellenbindung von SIN/COS/ARCTAN-Winkeleinheit, LN/LOG-Basis und ROUND-Oberpräzision Open; separat klären, nicht aus aktuellem Code ableiten. Menschliche Freigabe und Quellen-/Produktnachweise bleiben ausstehend. `Evaluate` übernimmt aktuell `ParseToEnd` ohne ausdrückliche Endlichkeitsprüfung in `EvaluationResult.Ok`; dies ist ein zukünftiger Prüfpunkt, keine bereits korrigierte Eigenschaft.

*The fifth answer A requires finite real results and clear numeric failures. Bind the specification's four error cases and finite controls test-first in future authorised work; no product tests run here. Five follow-up questions are answered. Trigonometric units, logarithm bases and ROUND's upper precision remain deferred source bindings under RQ-003; human clearance and source/product proof remain pending.*

2026-10-08, erste Antwort A dieses Klärungslaufs: SIN/COS-Eingabe und ARCTAN-Ausgabe in Bogenmaß; Orakel und Quellenbindung stehen im trigonometrischen Vertrag der Spec. Kein neues π-Syntaxangebot, kein Produktnachweis. RQ-003 bleibt für LN/LOG-Basis und ROUND-Oberpräzision Open.

*The first answer A in this clarification run binds SIN/COS inputs and ARCTAN output to radians, with specification oracles and no new π syntax or product proof. Logarithm bases and ROUND's upper precision keep RQ-003 Open.*

2026-10-08, zweite Antwort A: LN zur Basis e, LOG zur Basis 10; Null und negative Argumente für beide Funktionen als verständliche Fehler. Pflichtorakel und reviewte Toleranzen gemäß Logarithmusvertrag der Spec. Der offene LN/LOG-Teilbefund ist supersediert; RQ-003 bleibt nur für die obere ROUND-Präzision Open. Kein Produktnachweis oder menschliche Planfreigabe.

*The second answer A binds LN to base e and LOG to base 10, with clear zero/negative errors and specification oracles. This supersedes the logarithm source gap; only the upper ROUND precision keeps RQ-003 Open. Product proof and human plan clearance are pending.*

2026-10-08, dritte Antwort A: ROUND-Präzision nichtnegativ gegen null abschneiden, dann 0 bis 15 einschließlich; größere Werte Fehler ohne Begrenzung. Negative Rohargumente einschließlich -0.5 Fehler vor Abschneidung; Halbwerte weiterhin weg von null. Orakel gemäß Spec. RQ-001–RQ-003-Anforderungslücken Resolved; frühere Open-Fortschreibungen sind supersedierte Historie. Keine Produktabnahme oder menschliche Planfreigabe.

*The third answer A binds ROUND to truncated nonnegative precision 0–15 with clear larger/negative-raw errors and unchanged midpoint rounding. Specification oracles resolve the identified source findings; earlier Open entries are history. All 36 requirement-quality items pass, not product acceptance. Qualified dated role/scope evidence and owner confirmation are still required for human clearance; no implementation or delivery authority is granted.*

**Aktueller Governance-Stand 2026-10-08:** Owner bestätigt privates persönliches Projekt und supersediert die zusätzliche externe qualifizierte Rollen-/Scope-Review-Pflicht. Frühere Aussagen zu diesem fehlenden Plan-Gate sind historisch überholt. Repository bleibt öffentlich; historische regulatorische Einzelstatus und Neubewertung bei konkreten Scope-Triggern bleiben erhalten. 36 Anforderungsqualitäts-Punkte Pass, kein Produktnachweis. Plan als Dokumenten-PR zur Owner-Prüfung liefern; keine Implementierung, kein Merge. Technische Security-/Preflight-/A11Y-/Plattform-Gates unverändert.

*Current governance state on 2026-10-08: the owner's personal-project decision supersedes the added external qualified review prerequisite and earlier claims that this blocks the plan. Repository visibility remains public; historical applicability dispositions and concrete-trigger reassessment remain intact. All 36 requirement-quality items pass, not product proof. Submit the documentation PR for owner review, without implementation or merge; technical gates are unchanged.*
