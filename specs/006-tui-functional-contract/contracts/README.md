# Schnittstellenvertrag der Prüfinfrastruktur / Validation interface contract

Diese Datei spezifiziert geplante interne Werkzeuge. Sie ist weder der fertige Produktvertrag noch eine neue öffentliche C#-API. Die tatsächlichen JSON-Schemas, Skripte und ausführbaren Fälle entstehen erst in beauftragter Umsetzung.

*This designs future internal validation tools, not a finished product contract or public C# API. Implementation will supply schemas, scripts and executable cases.*

## C-01 — Vollständige Baseline / Complete baseline

Jede Tabellenzeile wird in einzelne stabile IDs und Pfade expandiert. Pflichtfälle sind nicht auf die Beispiele beschränkt; jede dokumentierte Grenz-/Fehlersemantik bleibt enthalten. Die Baseline wird zusätzlich als nicht aus dem Ergebnisvertrag abgeleitetes Pflichtinventar validiert, damit das Löschen von Vertrag und Tests gemeinsam nicht unbemerkt bleibt.

*Expand every row into stable IDs and individual paths, including all documented boundaries. An independently bound baseline inventory detects coordinated deletion of contract and tests.*

| Familie / Family | Verpflichtende Pfade / Required paths | Automationsnachweis / Automated proof |
|---|---|---|
| APP | Interaktiver Start, Smoke OK/FAIL, geordnetes Ende, Terminalwiederherstellung / start, smoke, shutdown, restoration | CLI + echte Sitzung/PTY / real session |
| GRID | A1:G21, Köpfe, aktive Zelle, Typ/AutoCalc, Ränder / headers, selection, status, bounds | UI-Zustand/Text + PTY |
| NAV-UP | Up, Ctrl-E; Innen/Rand / interior/edge | Je Taste UI-Key / every key |
| NAV-DOWN | Down, Ctrl-X, Ctrl-J; Innen/Rand | Je Taste UI-Key |
| NAV-RIGHT | Right, Ctrl-D, Ctrl-M, Enter, zusätzlich Ctrl-G; Innen/Rand / additional approved alias | Je Taste UI-Key |
| NAV-LEFT | Left, Ctrl-S, Ctrl-A; Innen/Rand | Je Taste UI-Key |
| EDIT | Esc bestehend; ASCII 32..126 einzeln, vorbehaltene Befehlswege korrekt einordnen; Enter/Esc im Dialog / existing content, printable input, reserved commands, accept/cancel | Echte Editor-/Dispatcherpfade, Zustandsvergleich / actual editor and dispatch |
| CELL | Leer/Text/Zahl/Formel, Flags, Überlauf, Breite, Dezimalstellen, Sperre, Fehler / all cell states and presentation | Core-Orakel + Editor/UI |
| OP | Unäre +/−, Klammern, + − * / ^ / unary signs and operators | Alle über Editor plus Core / every operator through editor |
| REF | Einzeladresse, >-Bereichssumme, leer/Text, Zyklus / references, range, empty/text, cycles | Editor plus Core |
| FUNC-LEGACY | ABS, SQRT, SQR, SIN, COS, ARCTAN, LN, LOG, EXP, FACT | Je Funktion Erfolg/Grenze/Fehler über Editor / success, boundary and error |
| FUNC-EXT | MIN, MAX, AVERAGE, COUNT, IF, ROUND | Je Funktion Erfolg/Grenze/Fehler über Editor |
| CMD | Load, Save, Recalculate, Print, Format, AutoCalc, Help, Clear, Quit; jeder über Menü und Palette, Ctrl-Q und / / both routes and shortcuts | Tatsächliche Views/Bindings / real controls |
| FILE | JSON-Rundreise, fehlend/ungültig, Druck/Rand, jeder Dateidialog-Abbruch / round trip, bad files, print/margin, cancel | Temporäre synthetische Dateien, Hash-/Statevergleich / isolated file checks |
| HELP | Ressource, P/N + Buttons, Esc + Schließen-Button, fehlend/beschädigt / all paging/close/error routes | Help-View/Dialog + Ressourcenfixtures |
| DIALOG | Editor, Load, Save, Print, Format, Clear, Palette; Bestätigung/Abbruch / every confirm/cancel | Fokus-, Datei- und Tabelleninvarianten / focus, file, sheet invariants |
| TERM | 80x24 und 120x40, Fokus/Kontrast, sichtbarer PTY-Text / size, focus, contrast, visible text | Automatisierte View-/PTY-Prüfung; ergänzendes Human-A11Y / supplemental human proof |

RQ-001/RQ-002 sind durch Nutzerantworten A kontextabhängig geklärt: Raster-`/` zeichnet neu und öffnet die Palette; Editor-`/` ist ASCII-Eingabetext einschließlich Division. Im Raster starten andere druckbare ASCII-Zeichen die Bearbeitung. Alle historischen Editierfunktionen/-aliase bleiben innerhalb EDIT Pflicht: Ctrl-S/Ctrl-D links/rechts, Ctrl-A/Ctrl-F Anfang/Ende, DEL/Ctrl-G linkes/rechtes Zeichen löschen, Ctrl-V/Ins Einfügen/Überschreiben. Ctrl-G ist außerdem zusätzlicher Raster-Rechtsalias. Die Befehlsbuchstaben Q/L/S/R/P/F/A sind separate Pfade in der Befehlsauswahl; ihr Angebot hebt normale Rastertexteingabe nicht auf. Ein neuer Familienbereich oder historische Scancode-Emulation ist nicht nötig.

*Both answers A preserve all offers with explicit context: grid navigation/redraw/palette, editor input/navigation/deletion/mode and command-selection letters. Keep every alias individually required without historical scancode emulation.*

Jeder Pfad dokumentiert Kontext, Angebotsquelle, Vorzustand, erlaubte Zustandsänderung, Fokusziel, Erfolgs-/Abbruch-/Fehlersemantik und Szenario-Anwendbarkeit. Abdeckungsnenner und Datenintegritätsregeln stehen in Spec §Präzisierungen aus dem Anforderungsreview; sie sind Pflicht für den ausführbaren Katalog. Fehlende Formelsemantik RQ-003 wird nicht allein aus aktuellen Tests ausgewählt.

*Path definitions must bind context, source, state and scenario semantics. Apply the refined coverage/integrity rules and resolve missing formula semantics rather than choosing current test behaviour as authority.*

## C-02 — Read-only Validator / Read-only validator

Geplanter PowerShell-Einstieg `scripts/test-tinycalc-contract.ps1`, Cmdlet `Test-TinyCalcContract`; Bash-Einstieg `scripts/test-tinycalc-contract.sh` ruft dieselbe Engine auf. Explizite Inputs: `RepositoryRoot`, `Contract`, `SourceMap`, `Evidence`, `PinDecision`, `ImpactDecision`, optional maschinenlesbares `Json`, `WhatIf` beziehungsweise kebab-case Bash-Flags und `--dry-run`.

*Both launchers share one engine and explicit root, contract, source, evidence, pin and impact inputs with JSON and zero-write preview options.*

Validierung prüft Schema, semantische Referenzen, alle Baseline-/Alias-Pflichten, aktive IDs, tatsächlich ausgeführte Tests/Assertions, Scope/Impact, Commit-/Pin-/Quellfrische, erforderliche Plattform-/Human-/DocFX-Evidenz und historische Additivität. Pfade müssen innerhalb des expliziten Repositories oder eines ausdrücklich erlaubten Evidenzverzeichnisses liegen; keine URL-Fetches, Installation, Restore, Tests oder Produktstarts im Validator. Er startet niemals Befehle aus JSON. Vorschau führt alle read-only Prüfungen aus, aber keine Schreibaktion.

*Validate structure, semantics, full obligations and actual execution bindings without fetching, installing, restoring or running tests/product code. Never execute commands from JSON; preview performs the same zero-write checks.*

Ausgabe: deterministisch sortierte DE/EN-Textbefunde oder ein JSON-Objekt mit `status`, `findings`, `requiredGates`, `counts` und `inputDigests`; keine Fortschritts-ANSI-Sequenzen, Secrets oder privaten absoluten Pfade. Exit `0` = alle für den angefragten Scope erforderlichen Gates gültig; `1` = erkannte Vertrags-/Driftverletzung; `2` = fehlende/ungültige Inputs oder blockierter Preflight. `0` bedeutet weder unabhängige Abnahme noch Mergefreigabe.

*Deterministic accessible output. Exit zero means valid scoped evidence, one means a violation and two means invalid/missing inputs or blocked preflight; no result grants owner acceptance or merge authority.*

## C-03 — Producer und Bindung / Producers and binding

Core-/TUI-xUnit-Fixtures erzeugen Resultate pro Capability/Pfad. Sie registrieren Start, ausgeführte Assertions und Endzustand; zählbare Pflichten werden gegen erwartete Fälle verglichen. Alle Tests laufen weiter in den bestehenden Projekten, Contract-Fälle mit eindeutigem Trait. Ein unvollständiger Filter, Skip, Timeout oder fehlendes Resultat sperrt das Bundle. Assertions müssen unabhängig vom Resultatschreiber sein: kein unconditional Pass. Negative Fixtures schwächen echte Orakel oder entfernen Pfade und müssen fehlschlagen.

*Test fixtures produce per-path records and execution counts; missing cases, skips and timeouts block. Independent assertions and deliberately weakened tests establish proof strength.*

macOS-PTY-Producer bindet Binary-/Quellcommit, tatsächlichen Terminaltreiber, Maße, Capability-/Path-IDs, Rohtrace/Textzustand und Cleanup. VoiceOver-Producer ist ein menschlich geführtes Protokoll mit denselben IDs/Commit, Terminal-/OS-/VoiceOver-Version, Bedienpfaden, Beobachtungen und Reviewer. Kein synthetisches Input-Event wird als Screenreader-Nachweis verkauft. Finale Plattformbundles binden exakt denselben finalen Commit; spätere Evidence-only-Commits benötigen für neue Abschlussentscheidungen neu gebundene Pflichtläufe. Keine stille historische Umdeutung oder Freigabe durch bloßen Tree-Vergleich.

*PTY records actual process/terminal state; VoiceOver records human observations separately. Final exact-head evidence must be renewed for a later completion commit, not waived through a tree comparison.*

FACT-Klärung (dritte Antwort A): In C-01 nur ganze Argumente 0 bis 33 zulassen; `FACT(0)=1`. Bruchteile, negative Argumente und Werte über 33 ergeben verständliche Fehler ohne Truncation. Katalogfälle müssen insbesondere `-0.5` und `33.9` ablehnen. Quelle ist die Spec-Klärung, nicht der aktuelle Evaluator. Übrige RQ-003-Semantik bleibt offen; keine Produktprüfung erfolgt.

*For C-01, FACT accepts integers 0 through 33 only, with FACT(0)=1; reject fractional, negative and larger inputs without truncation, including -0.5 and 33.9. Bind the specification clarification, not current code; other formula semantics remains Open and untested.*

## C-04 — Pin- und Impact-Entscheidung / Pin and impact decision

Preflight löst den Dependency-Namen aus Projekt-/Lockquellen auf und prüft dokumentierte Freigabe. Ohne Freigabe/Lockkohärenz `Blocked`; Versions-/Auflösungsdrift verlangt vollständige Kompatibilität/PTY/A11Y. `AlreadySatisfied` verlangt passende aktuelle Vergleichsevidenz; keine fest codierte Terminal.Gui-Version. Impact verwendet exakt die Spec-Matrix und einen gesonderten Decision-Digest. Ein unbekannter Fall wird Function+A11Y, niemals NoFunctionalImpact.

*Resolve approved dependency sources at execution time and apply the unchanged specification impact matrix. Unknown impact requires functional and accessibility proof.*

Operator-Klärung (vierte Antwort A): C-01 bindet `OP-*` an die sieben Spec-Orakel einschließlich `2^3^2=512`, `-2^2=-4`, `(-2)^2=4`, `2^-2=0.25`. Klammern zuerst, Potenz rechts und vor unärem Vorzeichen; Multiplikation/Division und binäre Addition/Subtraktion links. Verbleibende numerische Definitions-/Ergebnisgrenzen sind offen; keine Ausführungsnachweise.

*C-01 binds OP-* to the fourth answer A and all seven specification oracles. Parentheses precede right-associated powers, then unary signs and left-associated arithmetic groups. Numeric boundaries remain Open and product evidence is pending.*

Fünfte Antwort A: Nur endliche reelle Ergebnisse; Definitionsfehler, Überläufe und NaN/Unendlich ergeben verständliche Fehler statt erfolgreicher numerischer Zellwerte. Die vier Fehlerorakel der Spec und endliche Kontrollfälle bei späterer Umsetzung test-first binden; keine Produktprüfung hier. Alle fünf Fragen dieser Nachprüfung sind beantwortet. RQ-003 bleibt für fehlende Quellenbindung von SIN/COS/ARCTAN-Winkeleinheit, LN/LOG-Basis und ROUND-Oberpräzision Open; separat klären, nicht aus aktuellem Code ableiten. Menschliche Freigabe und Quellen-/Produktnachweise bleiben ausstehend.

*The fifth answer A requires finite real results and clear numeric failures. Bind the specification's four error cases and finite controls test-first in future authorised work; no product tests run here. Five follow-up questions are answered. Trigonometric units, logarithm bases and ROUND's upper precision remain deferred source bindings under RQ-003; human clearance and source/product proof remain pending.*

2026-10-08, erste Antwort A dieses Klärungslaufs: SIN/COS-Eingabe und ARCTAN-Ausgabe in Bogenmaß; Orakel und Quellenbindung stehen im trigonometrischen Vertrag der Spec. Kein neues π-Syntaxangebot, kein Produktnachweis. RQ-003 bleibt für LN/LOG-Basis und ROUND-Oberpräzision Open.

*The first answer A in this clarification run binds SIN/COS inputs and ARCTAN output to radians, with specification oracles and no new π syntax or product proof. Logarithm bases and ROUND's upper precision keep RQ-003 Open.*

2026-10-08, zweite Antwort A: LN zur Basis e, LOG zur Basis 10; Null und negative Argumente für beide Funktionen als verständliche Fehler. Pflichtorakel und reviewte Toleranzen gemäß Logarithmusvertrag der Spec. Der offene LN/LOG-Teilbefund ist supersediert; RQ-003 bleibt nur für die obere ROUND-Präzision Open. Kein Produktnachweis oder menschliche Planfreigabe.

*The second answer A binds LN to base e and LOG to base 10, with clear zero/negative errors and specification oracles. This supersedes the logarithm source gap; only the upper ROUND precision keeps RQ-003 Open. Product proof and human plan clearance are pending.*

2026-10-08, dritte Antwort A: ROUND-Präzision nichtnegativ gegen null abschneiden, dann 0 bis 15 einschließlich; größere Werte Fehler ohne Begrenzung. Negative Rohargumente einschließlich -0.5 Fehler vor Abschneidung; Halbwerte weiterhin weg von null. Orakel gemäß Spec. RQ-001–RQ-003-Anforderungslücken Resolved; frühere Open-Fortschreibungen sind supersedierte Historie. Keine Produktabnahme oder menschliche Planfreigabe.

*The third answer A binds ROUND to truncated nonnegative precision 0–15 with clear larger/negative-raw errors and unchanged midpoint rounding. Specification oracles resolve the identified source findings; earlier Open entries are history. All 36 requirement-quality items pass, not product acceptance. Qualified dated role/scope evidence and owner confirmation are still required for human clearance; no implementation or delivery authority is granted.*

**Aktueller Governance-Stand 2026-10-08:** Owner bestätigt privates persönliches Projekt und supersediert die zusätzliche externe qualifizierte Rollen-/Scope-Review-Pflicht. Frühere Aussagen zu diesem fehlenden Plan-Gate sind historisch überholt. Repository bleibt öffentlich; historische regulatorische Einzelstatus und Neubewertung bei konkreten Scope-Triggern bleiben erhalten. 36 Anforderungsqualitäts-Punkte Pass, kein Produktnachweis. Plan als Dokumenten-PR zur Owner-Prüfung liefern; keine Implementierung, kein Merge. Technische Security-/Preflight-/A11Y-/Plattform-Gates unverändert.

*Current governance state on 2026-10-08: the owner's personal-project decision supersedes the added external qualified review prerequisite and earlier claims that this blocks the plan. Repository visibility remains public; historical applicability dispositions and concrete-trigger reassessment remain intact. All 36 requirement-quality items pass, not product proof. Submit the documentation PR for owner review, without implementation or merge; technical gates are unchanged.*
