# Prüfablauf für die spätere Umsetzung / Future validation quickstart

Diese Anleitung ist ein geplanter Ablauf, kein Ausführungsnachweis. Die neuen Vertragswerkzeuge existieren noch nicht. Keine Befehle dieses Dokuments wurden im Plan-Aufruf als Produktprüfung ausgeführt. Gate bedeutet verpflichtende Prüfschranke; Locked Restore akzeptiert ausschließlich geprüfte Paket-Lockdaten.

*This is a future procedure, not execution evidence. New tools do not yet exist, and no product verification ran during planning.*

## 1. Freigaben und sichere lokale Vorprüfung / Approval and safe local preflight

Zuerst Betriebssystem, `pwsh`, SDK, Git-Branch/Status und Feature-Pointer prüfen. Owner-PR-Review und dokumentierte private Scope-Entscheidung prüfen; Intake-/Serienreview mit den vorhandenen Bash-/PowerShell-Validatoren read-only prüfen. Freigegebene Pin-/Lockquellen auflösen. Fehlende Lockdaten blockieren Produktcode; nur gesondert genehmigte Vorbereitung erzeugt reviewed Locks ohne automatisches Upgrade. Der lokale sichere Modus ist der geplante Read-only-Validator:

RQ-001–RQ-003 sind geklärt. Alle historischen Kontexte und mathematischen Orakel in den späteren Katalog/Quellenabgleich übernehmen. Vor Umsetzung bleiben Owner-PR-Review und konkrete Scope-Trigger zu prüfen; vor Produktcode zusätzlich Preflight und Locknachweise erheben. Zustand/Fokus, vollständigen Tupel-Nenner und vor Lauf reviewte Infrastrukturfristen 30/180/5 Sekunden im Decision-Hash binden.

*Source findings are resolved; preserve agreed contexts and mathematical oracles in future source alignment. Owner PR review and scope-trigger assessment remain required, dependency preflight before code; bind state/focus, complete coverage and reviewed deadlines.*

*Check environment, source bindings and human approval first. Missing lock evidence blocks code until authorised preparation has established it. The future safe local mode is read-only validation.*

```powershell
pwsh -NoProfile -File scripts/test-tinycalc-contract.ps1 -RepositoryRoot . -Contract docs/contracts/tui/product-contract.json -SourceMap docs/contracts/tui/source-map.json -Evidence specs/006-tui-functional-contract/evidence/platforms -PinDecision specs/006-tui-functional-contract/evidence/pin-decision.json -ImpactDecision specs/006-tui-functional-contract/evidence/impact-decision.json -WhatIf -Json
```

```bash
bash scripts/test-tinycalc-contract.sh --repository-root . --contract docs/contracts/tui/product-contract.json --source-map docs/contracts/tui/source-map.json --evidence specs/006-tui-functional-contract/evidence/platforms --pin-decision specs/006-tui-functional-contract/evidence/pin-decision.json --impact-decision specs/006-tui-functional-contract/evidence/impact-decision.json --dry-run --json
```

Bei noch fehlenden Implementierungsartefakten wird Exit 2 erwartet, nicht Pass. Beide Varianten müssen gleiche Befunde/Counts/Digests und null Schreibzugriffe zeigen. Der Modus ruft keinen Produktprozess, Restore oder Provider auf.

*Missing future artifacts produce exit two, not a pass. Both previews have matching results and zero writes.*

## 2. Rot–Grün–Refactor und Gesamtsuite / Test-first development and full suite

Erst nach autorisierter Umsetzung und geklärtem Preflight. Vor **jedem** `dotnet build`/`dotnet test` den Buildzähler erhöhen und alle drei Versionen gleich halten; Minor ist 6, Patch die passende Commitzahl. Version-/Statistikdateien seriell bearbeiten. Folgende bestehende Befehle sind die Basis, später ergänzt um vollständige Vertragsresultate:

*Only after implementation authority and preflight clearance. Increment aligned build metadata before each build/test and serialize shared writes.*

```powershell
dotnet restore MicroCalc.sln --locked-mode
dotnet build MicroCalc.sln --configuration Release --no-restore
dotnet test MicroCalc.sln --configuration Release --no-build --logger trx
dotnet run --no-build --configuration Release --project src/MicroCalc.Tui/MicroCalc.Tui.csproj -- --smoke
```

Smoke muss Exit 0 und exakt `SMOKE_OK` liefern, bleibt Teilnachweis. Vor dem ersten gezielten roten Test die vollständige Kompilierfläche validieren; erwartete rote Fehler isoliert dokumentieren, Infrastrukturfehler nicht als fachliches Rot zählen. Alle aktiven Contract-Pfade tatsächlich ausführen; gefilterte Entwicklungsfälle sind keine Gesamtabnahme. Coverage über Out-of-process-TUI und Core zusammenführen; historische sichere Managed-Collector-Konfiguration prüfen, temporäre Instrumentierung bytegenau zurücknehmen. Geänderte Produktzeilen ≥70%, Ziel ≥80%; Gesamtvertragsabdeckung unabhängig davon 100%.

*Smoke is partial proof. Separate intentional red failures from infrastructure failures, execute the full contract and restore temporary instrumentation. Line coverage and complete path coverage are independent gates.*

## 3. Plattform, A11Y und Nachweisstärke / Platforms, accessibility and proof strength

macOS: echten Prozess im PTY mit 80x24/120x40 und Terminalwiederherstellung prüfen. Linux/Windows: native vollständige Automationssuite, tatsächliche CI-Befehle/Runner bestätigen; kein Hosted-macOS-Governancejob als Produktbeleg. Bei eigenem A11yImpact vollständige verlinkte A11Y-Gates einschließlich VoiceOver, Tastatur/Text/Fokus/Kontrast und aller aktiven IDs. Human-only kann keine automatisierbare Funktion ersetzen.

*Obtain real macOS terminal and native Linux/Windows automated proof. Apply all linked accessibility gates when triggered; human evidence does not replace functional automation.*

Absichtliche Quell-/Testdrift, Skip, schwächeres Orakel, fremder Commit, fehlender Pin/Lock und Smoke-only müssen Abnahme blockieren. CLI-/Manpage-/Help-Parität auf macOS/Linux und Windows manuell prüfen. Öffentliche API/XML-/DocFX-Änderung verlangt DocFX-Regeneration und Playwright/axe plus lynx im selben Arbeitspaket; repräsentative Seiten ohne serious/critical axe-Befunde, mit verständlicher Textdarstellung.

*Prove negative drift detection, native launcher parity and required documentation accessibility without claiming skipped checks passed.*

## 4. Unabhängige Abnahme und Stopp / Independent acceptance and stop

Alle Plattformbundles müssen Produktcommit, Vertrags-/Quell-/Pin-/Decision-Digests, Befehl, tatsächlichen Job/Runner, Exit und Payload-SHA-256 binden. SC-001 bis SC-006 einzeln beurteilen; null offene In-Scope-Fehler. Technische Gates, menschlicher Review und Owner-Abnahme getrennt ausweisen. Ohne aktuellen Lieferauftrag lokal stoppen; kein automatischer Commit/Push/PR/Merge und kein Start des nächsten Intakes.

*Bind complete platform proof and independently assess all six criteria. Stop locally without fresh delivery authority or next-feature permission.*

Auch ein späterer Evidence-only-Commit benötigt neu gebundene finale Pflichtnachweise. Historische Ergebnisse niemals auf einen neuen Commit umetikettieren. Die permanente Linux-/Windows-Vollautomation bei jedem PR/Push gilt auch für NoFunctionalImpact; die Matrix ergänzt weitere Nachweise.

*Later evidence-only completion heads need renewed final proof. Full automated regression remains permanent for every PR/push; impact adds obligations.*

FACT ist durch dritte Antwort A fachlich geklärt: nur ganze Argumente 0 bis 33, `FACT(0)=1`, sonst Fehler ohne Truncation. Bei später autorisierter Umsetzung zuerst Erfolgs-/Grenz-/Fehlerfälle einschließlich `-0.5` und `33.9` rot prüfen; aktuelle Implementierung nicht als Orakel übernehmen. Übrige RQ-003-Semantik bleibt vor Planfreigabe zu klären; hier keine Ausführung.

*FACT now accepts integers 0 through 33 only, zero returning 1; other inputs fail without truncation. Future authorised work starts with failing contract tests, including -0.5 and 33.9. Remaining formula semantics blocks approval; no execution here.*

Statistik: bestehenden Ledger fortschreiben, nicht in den Pilot migrieren. An genehmigter sauberer Commit-Grenze Repo-Renderer zuerst `-WhatIf -Json`, dann schreiben, anschließend `-CheckOnly -Json`; Output und Quellenbindung prüfen. 80/125 Zeilen/Tag, 7.8 Stunden/Tag, 21.5 Tage/Monat sind Referenzen, keine gemessene Produktivität. Vollständiger Feature-Abschlussbericht erst beim abgeschlossenen Feature-Lauf.

*Use the existing ledger and clean-boundary renderer; keep reference estimates distinct from measured effort. A planning call does not create a feature completion report.*

Vierte Antwort A: Vor späterer Parserkorrektur die sieben Operatorfälle der Spec rot prüfen; Potenzketten rechts, Potenz vor Vorzeichen, Klammern zuerst. Diese Bindungsfrage ist geklärt, aber nicht produktgeprüft. RQ-003 bleibt wegen numerischer Definitions-/Ergebnisgrenzen vor Planfreigabe offen.

*The fourth answer A resolves operator binding; future parser work starts with the specification's seven failing regression cases. No product tests run here; numeric domain/result boundaries remain Open before approval.*

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
