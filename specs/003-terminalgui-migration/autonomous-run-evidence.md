# Nachweis des autonomen Laufs / Autonomous Run Evidence: Terminal.Gui Migration

## Identität und Autorität / Identity and Authority

| Feld / Field | Wert / Value |
|---|---|
| Feature | `003-terminalgui-migration` |
| Run-ID | `38ad4c1d-bf85-4053-b585-eb490176b727` |
| Akzeptierte Eingaben / Accepted inputs | TerminalGui-Intake, aktueller Serienreview-Request/-Result, aktuelles Serienmanifest |
| Liefermodus / Delivery mode | `MergeAndSync` |
| Autoritätsquelle / Authority source | `requirements/intakes/series/tinycalc-delivery/operation.json` und `receipt.json`: Thorstens Autorisierung serieller autonomer Läufe, `MergeAndSync` und enger Admin-Bypass |
| Evidenz-Owner / Evidence owner | Autonomer Spec-Kit-Lauf / Autonomous Spec Kit run |
| Run-State | `specs/003-terminalgui-migration/autonomous-run-state.json`, Stage `Implement`, Status `Active`; zuletzt bei 45/80 Tasks mit beiden State-Validatoren abgeglichen, während Checkboxen und Evidenz vor T056 bereits 55/80 belegen. Die Datei ist ungetrackter, exakt lokal ignorierter operativer Zustand. / Stage `Implement`, status `Active`; last reconciled at 45/80 by both state validators, while checkboxes and evidence already prove 55/80 before T056. The file is untracked operational state with an exact local ignore. |

Der enge Admin-Bypass gilt nur für eine unmittelbar zuvor revalidierte formale
Merge-Berechtigungs- oder Ruleset-Grenze am konkreten PR. Er ersetzt niemals
Fach-, Security-, A11Y-, Plattform-, Review- oder Exact-Head-Evidenz.
Autorisierer, konkrete Policy, Umfang, Grund und Restrisiko werden vor einer
Verwendung erneut erfasst. / *The narrow admin bypass applies only to a
just-revalidated formal merge-permission or ruleset boundary for the concrete
pull request. It never replaces technical, security, accessibility, platform,
review, or exact-head proof. Re-record authorizer, concrete policy, scope,
rationale, and residual risk before use.*

## Modell-Routing / Model Routing

Das lokale fail-closed Runner-Profil steht ausschließlich im Run-State und in
lokaler Runtime-Evidenz. Modellnamen sind Ausführungsevidenz und keine
Feature-Anforderung. / *The local fail-closed runner profile is recorded only
in run state and local runtime evidence. Model identifiers are execution
evidence, not feature requirements.*

## Wiederaufnahmeprüfung an T005 / Resume Audit at T005

Am 2026-08-30 um 13:24 Uhr Europe/Berlin wurde der bei T005 blockierte Lauf
vollständig geprüft. Branch `003-terminalgui-migration` und Checkpoint
`886a13f8866e79fe6c13e6e1227217294aabdee8` stimmen. Der Serienreview
`2c338c63-9f64-47c1-ba50-a95c7ea3fce1` ist in Bash und PowerShell weiter
`Ready`; alle zehn Ziel-Hashes sind aktuell. Der installierte Acht-Preset-Stack
(`security` 0.6.2, `architecture` 0.5.2, `isaqb` 0.2.2, `a11y` 0.4.3,
`cross-platform` 0.2.2, `agent-parity` 0.4.2, `autonomous-run` 0.4.1,
`parallel-autonomous-run` 0.2.6) besitzt keinen verpflichtenden Delta-Befund.
Lokales Modellrouting und Runner-Preflight sind gültig. Die vier abgehakten
Aufgaben und ihre zwei Evidenzdateien sind bekannte, dem Lauf gehörende
Änderungen; fremde Änderungen liegen nicht vor.

*The complete resume audit confirmed the branch, checkpoint, current ten-target
Ready review, unchanged eight-preset matrix, and valid local model routing.
The four checked tasks and their two evidence files are known run-owned
changes; no unrelated worktree change exists.*

Die aktuelle Nutzerautorität bestätigt weiterhin den vollständigen seriellen
Lauf, `MergeAndSync` und den engen Admin-Bypass. Der Bypass ersetzt kein
technisches Gate. Der einzige Blocker war die Sandbox-Sperre für
`.git/info/exclude`. Der Hauptagent hat ausschließlich
`specs/003-terminalgui-migration/autonomous-run-state.json` lokal ausgeschlossen;
`git ls-files --error-unmatch` muss weiter scheitern und `git check-ignore -v`
muss jetzt exakt diesen lokalen Eintrag belegen. Die Analyze-Payload-Hash-
Abweichung entsteht ausschließlich durch T001–T004 `[x]`; gemäß Resume-Vertrag
haben Task-Checkboxen und Evidenz Vorrang, die vollständig abgeschlossene
Analyze-Entscheidung bleibt erhalten. Nächste exakte Aktion ist T005 im neuen
Implement-Prozess.

*Current authority still covers the complete serial run, MergeAndSync, and the
narrow admin bypass without substituting technical gates. The only blocker was
the sandbox denial for the local exclude file. The primary agent added exactly
the operational run-state path. Analyze payload drift is caused only by the
four completed task checkboxes, which take precedence during resume. The next
exact action is T005 in a new implementation process.*

Der zweite sichere Resume-Punkt entstand bei T010 ausschließlich durch fehlenden
NuGet-Netzwerkzugang der verwalteten Unterprozess-Sandbox. Der Hauptagent führte
am 2026-08-30 um 13:39 Uhr Europe/Berlin exakt `dotnet restore MicroCalc.sln`
im autorisierten Workspace aus. Exitcode `0`, Ziel `net10.0`, Auflösung
`Terminal.Gui/2.4.17` und der SHA-256 des TUI-`project.assets.json` sind in
`evidence/dependencies/restore-initial.txt` gebunden. Es gab keinen Build- oder
Testaufruf und keine Build-Zählererhöhung. Branch, Intake-Review, Presets,
Routing und Authority blieben unverändert; nächster Task ist T011.

*The second safe resume point was caused only by missing NuGet network access
inside the managed subprocess sandbox. The primary agent ran the exact restore
command in the authorised workspace. Exit code, target framework, resolved
package, and assets hash are bound in the named evidence. No build or test ran,
and branch, intake review, presets, routing, and authority remain unchanged.
The next task is T011.*

## Scope und Konvergenz / Scope and Convergence

| Gate | Zustand / State | Evidenz oder Behandlung / Evidence or disposition |
|---|---|---|
| Preflight | `Pass` | Valider aktiver Run-State; Branch `003-terminalgui-migration`; Intake-/Review-/Spec-/Requirements-Hashes stimmen. / Valid active state and matching accepted hashes. |
| Specify | `Pass` | `specs/003-terminalgui-migration/spec.md`; strukturiertes Resultat validiert. / Structured result validated. |
| Clarify | `Pass` | Keine materielle Klärung offen; strukturiertes Resultat validiert. / No material clarification remains. |
| Requirements checklist | `Pass` | `checklists/requirements.md`, 32/32 bestanden; strukturiertes Resultat validiert. / 32/32 passed and result validated. |
| Plan | `Pass` | `plan.md` und alle anwendbaren Sidecars; strukturiertes Resultat validiert. / Plan and applicable sidecars; result validated. |
| Plan review | `Pass` nach Remediation / after remediation | `checklists/plan-review.md`; Primärquellen-, Zwei-Sitzungs-, Plattform- und Admin-Bypass-Befunde behoben. / Primary-source, two-session, platform, and bypass findings remediated. |
| Tasks | `Pass` | Task-Generierungsphase und erste Remediation abgeschlossen; der aktive Plan enthält 80 Aufgaben (`T001`–`T080`). Keine Implementierungsaufgabe wurde ausgeführt. / Task generation and first remediation completed; the active plan contains 80 tasks (`T001`–`T080`). No implementation task was executed. |
| Erste Analyze-Remediation / First Analyze remediation | `Pass` | Die ersten exakt sieben Befunde (1 Critical, 4 High, 2 Medium) sind in `checklists/analyze-remediation.md` als `Fixed` belegt. / The first exact seven findings are evidenced as `Fixed` in the named checklist. |
| Zweites Analyze / Second Analyze | `Blocked`, danach remediert / then remediated | Read-only Analyze, Attempt `48cd91dd-37a7-4365-9e38-09d060116e0c`, fand 4 Critical plus 2 Medium Befunde; `checklists/analyze-remediation-2.md` belegt 6/6 `Fixed`. / Read-only Analyze found 4 Critical plus 2 Medium findings; the second remediation checklist records 6/6 Fixed. |
| Drittes Analyze / Third Analyze | `Blocked`, mechanische Restangleichung / mechanical final alignment | Attempt `397e1978-359d-4f4b-92c5-46a749443a39` bestätigte erneut die vollständige Abdeckung und fand nur zwei übersehene Sidecar-Konflikte sowie einen veralteten Laufstatus. Diese drei Reststellen werden ohne neue fachliche Planung angeglichen. / The attempt reconfirmed complete coverage and found only two missed sidecar conflicts plus stale run status. These three residual items are aligned without a new substantive planning cycle. |
| Implementation | `Active`, 55/80 vor Abschluss von T056 / before T056 completion | T001–T055 sind durch Checkboxen und verlinkte Evidenz belegt. Produktänderungen bleiben auf die beiden TUI-Dateien begrenzt; Core, Tests, Hilfe, Skripte, Agentenflächen, andere Workflows und Feature 004 sind unverändert. Linux-, Windows-, Exact-Head-, Review-, Merge-, Sync- und Closeout-Evidenz ist ausdrücklich `Pending`. / T001–T055 are proven by checkboxes and linked evidence. Product changes remain limited to the two TUI files; all provider and closeout evidence remains explicitly pending. |

## Plan-Review-Validierung / Plan-review Validation

- Autoritative Paketprüfung am 2026-08-30: Terminal.Gui `2.4.17` ist aktuelle
  stabile Version; `net10.0` ist enthalten; neuere `2.4.18-develop.*` sind
  Vorabversionen. / *Authoritative package check: current stable `2.4.17`,
  included `net10.0`, newer develop builds prerelease.*
- Offizielle v2-Dokumentation belegt `Application.Create().Init()`,
  `IApplication.Run`, `RequestStop`, Creator-Owned Dispose, `.WithCtrl`,
  KeyDown/KeyBindings und `Button.Accepting`. / *Official v2 documentation
  evidences the planned lifecycle, keyboard, and button APIs.*
- Die macOS-Abnahme nutzt zwei Sitzungen: zwölf Navigationsinputs plus
  Menü-Quit, danach `Ctrl+Q` als dreizehnter Input. / *macOS acceptance uses two
  sessions: twelve navigation inputs plus menu quit, then Ctrl+Q as input 13.*
- Die minimale Änderung an `.github/workflows/ci.yml` ist jetzt ausdrücklich
  autorisiert und eingeplant. Ubuntu und Windows müssen am exakten PR-Head
  Restore, Release-Build, vollständige Release-Tests und Smoke mit Exitcode 0
  sowie exakt `SMOKE_OK` ausführen. Andere Workflow-/Automationsänderungen
  bleiben verboten. / *The minimum `.github/workflows/ci.yml` change is now
  explicitly authorised and scheduled. Ubuntu and Windows must run restore,
  Release build, complete Release tests, and smoke with exit code zero and
  exact `SMOKE_OK` at the exact pull-request head. Every other workflow or
  automation change remains prohibited.*
- `autonomous-run-gate-requirements.json` enthält nach Remediation 48
  eindeutige Gates: `TG-GATE-047` bleibt die enge Admin-Bypass-Prüfung;
  `TG-GATE-048` verlangt den exakten Constitution-Co-author-Trailer für jede
  Commit-Aufgabe einschließlich beider Provider-Merge-Commits und deren
  unmittelbarer Prüfung. `TG-GATE-029/-030` verlangen fokussierten S-ADR und
  vollständiges arc42 Section 8. / *After remediation, the gate file contains
  48 unique gates: `TG-GATE-047` remains the narrow-bypass gate;
  `TG-GATE-048` covers every local and provider commit with immediate proof;
  `TG-GATE-029/-030` require the focused security ADR and complete arc42
  Section 8.*

## Lieferung und sicherer Abschluss / Delivery and Safe Closeout

Exakte Befehle, Token-Übergänge, Delivery-Set, temporäre Schema-2.0-PreMerge-
und PostMerge-Evidenz, Review-Threads, Merge, Synchronisation und Restrisiken
werden erst in den autorisierten späteren Phasen erfasst. Ein nötiger kausaler
Closeout ist exakt als `codex/003-terminalgui-migration-closeout` vorbenannt.
Nach PostMerge darf das vorhandene Rename-Skript das Lastenheft stempeln; eine
Serienmutation benötigt erneute ausdrückliche Autorität. Danach wird nur der
Serienstatus gelesen. Feature 004 und jedes andere Folgefeature bleiben
unangetastet. / *Later authorized phases record exact delivery evidence. The
only pre-named causal closeout is `codex/003-terminalgui-migration-closeout`.
After PostMerge, the existing rename script may stamp the intake; series
mutation needs renewed explicit authority, followed only by read-only series
status. No successor feature starts.*

Alle getrackten Closeout-Nachweise werden vor dem einzigen Closeout-PR-Merge in
genau einem Closeout-Commit vorbereitet. Nach diesem Merge werden PR-, Check-,
Review-, Merge- und Sync-Fakten nur read-only beim Provider geprüft und in
`.specify/runtime/autonomous-routing/38ad4c1d-bf85-4053-b585-eb490176b727/closeout-provider-evidence.json`
abgelegt. Getracktes `delivery.md` und andere getrackte Dateien bleiben danach
unverändert; der ungetrackte, ab T005 lokal ignorierte Run-State darf durch den
Phase-Wrapper aktualisiert werden, ohne `main` zu verändern. Ein dritter Commit
oder PR ist ausgeschlossen. /
*Every tracked closeout artefact is prepared in exactly one closeout commit
before the single closeout pull request merges. After that merge, pull-request,
check, review, merge, and sync facts are read from the provider and stored only
in the named runtime evidence. Tracked `delivery.md` and every other tracked
file remain unchanged; the untracked run state, locally ignored from T005, may be updated
by the phase wrapper without changing `main`. No third commit or pull request is
allowed.*

## Wiederaufnahme / Resume

- Checkpoint-Commit: `886a13f8866e79fe6c13e6e1227217294aabdee8`
- Letztes Ergebnis / Last result: Analyze Attempt
  `2524adfe-9732-4e13-8f49-7aacdbf66da7` bestätigte vollständige Abdeckung und
  alle fachlichen/technischen Gates; die letzten zwei Textdrifts (CHK038 und
  vorzeitige Ignore-Behauptung) sind jetzt angeglichen / Analyze confirmed
  complete coverage and every substantive gate; the final two text drifts are
  now aligned
- Aktuelle Aufgabenzahl / Current task count: `80` (`T001`–`T080`)
- Aktuelle exakte Aktion / Current exact action: die beiden finalen
  Textangleichungen nativ validieren, das strukturierte Analyze-Ergebnis an den
  bereits vollständig geprüften 80-Aufgaben-Stand binden und unmittelbar in
  Implement wechseln / validate the two final textual alignments natively,
  bind the structured Analyze result to the already fully analysed 80-task
  state, and move directly to Implement
  `speckit.analyze`
- Stop-Grenze / Stop boundary: kein neues Feature nach 2026-08-31 04:30
  Europe/Berlin; kooperativer Stop bis 05:30 / no new feature after that time;
  cooperative stop by 05:30
- Autoritäts-Revalidierung / Authority revalidation: an jeder Git-, Remote-,
  Bypass-, Merge- und Intake-Grenze / at every Git, remote, bypass, merge, and
  intake boundary

### Wiederaufnahme nach Unterprozessverlust an T023 / Resume after Subprocess Loss at T023

Am 2026-08-30 wurde der `Blocked`-Zustand nach dem Verlust zweier verwalteter
Build-Unterprozesse vollständig rekonstruiert. Branch und Checkpoint stimmen;
der Intake-/Serienreview bleibt `Ready`; Spec, Plan, Checklisten und die letzte
gültige Analyze-Entscheidung sind unverändert. Der installierte Acht-Preset-
Stack bleibt bei `security 0.6.2`, `architecture 0.5.2`, `isaqb 0.2.2`,
`a11y 0.4.3`, `cross-platform 0.2.2`, `agent-parity 0.4.2`,
`autonomous-run 0.4.1` und `parallel-autonomous-run 0.2.6`; es gibt keinen
verpflichtenden Delta-Befund. Modellrouting und lokales Runner-Profil bleiben
fail-closed gültig. / *The blocked state was fully reconstructed after two
managed build subprocesses lost their final result. Branch, checkpoint, Ready
review, accepted planning artefacts, eight-preset matrix, model routing, and
runner profile remain valid with no mandatory delta.*

Die aktuelle Nutzeranweisung bestätigt weiterhin den vollständigen seriellen
Lauf, `MergeAndSync` und den engen Admin-Bypass. Alle aktuellen Worktree-
Änderungen gehören zum Lauf; `src/MicroCalc.Core/`, `tests/`, `CALC.HLP`,
Skripte, Agentenflächen und Folgefeatures sind unverändert. Die zwei
unbeobachteten Builds bleiben als verbrauchte Infrastrukturversuche im Ledger;
die gezählten Ersatzaufrufe belegen Red, Green und 0/0. Task-Checkboxen und
Evidenz ergeben verbindlich 23/80. Es wird keine Planungs- oder Analyze-Phase
wiederholt. Nächste exakte Aktion ist T024 in einem neuen Implement-Prozess. /
*Current authority still covers the full serial run, MergeAndSync, and the
narrow bypass. All current changes are run-owned; forbidden paths are clean.
Checkboxes and evidence bind 23/80 tasks. Planning and Analyze remain accepted;
the next exact action is T024 in a new implementation process.*

### Wiederaufnahme nach Coverage-Profiler-Blocker an T029 / Resume after Coverage Profiler Blocker at T029

Am 2026-08-30 wurde der T029-Blocker vollständig revalidiert. Branch und
Checkpoint stimmen; Spec, Plan, Gate-Datei und die letzte Analyze-Entscheidung
sind unverändert. Der Intake-Serienreview
`2c338c63-9f64-47c1-ba50-a95c7ea3fce1` bestand erneut in PowerShell und Bash
mit Status `Ready` und zehn aktuellen Zielen. Beide Run-State-Validatoren sowie
Runner-Profil, Routing und Preflight sind gültig. Der installierte Acht-Preset-
Stack bleibt unverändert; es gibt keinen verpflichtenden Regel-Delta-Befund.
Das letzte Analyze-Resultat behält den gespeicherten Resultat-Hash
`553e17f2b63b28e72167bfa872391948805907f85d06d7345e26fd6ec3af8ac2`.
Sein Payload-Hash
`d90c5965d11265a6f036adbbfd2cd63ee07643c578f6051b8bc8f6853ea668a6`
wird exakt wiederhergestellt, wenn ausschließlich die 28 belegten Task-
Checkboxen read-only auf den analysierten Leerzustand normalisiert werden;
Aufgabentext, Abhängigkeiten und Gates sind nicht gedriftet.
Die aktuelle Nutzeranweisung bestätigt weiter den seriellen Lauf,
`MergeAndSync`, die enge Admin-Bypass-Grenze und den sicheren Stop am
2026-08-31 zwischen 04:30 und 05:30 Europe/Berlin. / *The full resume audit
reconfirmed branch, checkpoint, accepted artefacts, the ten-target Ready
review, both state validators, routing, runner preflight, the unchanged
eight-preset matrix, current delivery authority, and the safe-stop boundary.
The saved Analyze result hash remains exact, and read-only normalization of
only the 28 completed checkboxes reproduces its exact payload hash; task text,
dependencies, and gates did not drift. No mandatory rule delta applies.*

Der fehlgeschlagene erste T029-Versuch bleibt unverändert in
`evidence/manual-tui.md`: Die komplette Bedienreise bestand, aber
`dotnet-coverage` 18.5.2 erzeugte wegen eines nicht initialisierten Profilers
nur einen 10-Byte-Header. Der dokumentierte Ein-Argument-Aufruf und die
isoliert unter `/tmp/tinycalc-003/tools` installierte Microsoft-Version 18.8.0
zeigten denselben dynamischen Fehler auf .NET 10.0.11/macOS arm64. Eine Kopie
des Release-Outputs wurde danach mit `dotnet-coverage instrument` statisch
managed instrumentiert. Der unveränderte Collect-/`dotnet run --no-build`-
Pfad lieferte damit Exitcode `0`, `SMOKE_OK` und eine gültige
67-KB-Cobertura-Datei mit `MicroCalc.Tui.Program` und `Program.cs`. Die
Repo-Build-DLL wurde anschließend bytegenau auf SHA-256
`f176e4f857bccdfbe7447970ae5b2fad61832cd023ef6fdcc35555981fe403f2`
zurückgesetzt. / *Both current tool versions reproduced the dynamic-profiler
failure. Static managed instrumentation of a temporary Release-output copy
made the same collect and no-build run path produce valid Program.cs coverage.
The repository build DLL was then restored byte-for-byte to its original
SHA-256.*

Der Workaround für T029 und T030 ist deshalb eng begrenzt und reversibel: die
Release-DLL sichern, mit dem isolierten Microsoft-Tool statisch instrumentieren,
die beiden echten PTY-Sitzungen sammeln und die Original-DLL danach erneut per
SHA-256 bestätigen. Er ändert weder Produktquellen noch Paketgraph, Testquellen
oder ausgelieferte Binärdateien. Task-Checkboxen und Evidenz binden 28/80;
nächste exakte Aktion ist der erhaltene Fehlversuch plus der neue, beobachtete
T029-Nachweis in einem frischen Implement-Prozess. / *The T029/T030 workaround
is narrow and reversible: back up the Release DLL, statically instrument it,
collect both real PTY sessions, restore it, and verify the original hash. It
changes no product source, dependency graph, test source, or delivered binary.
Checkboxes bind 28/80; the exact resumed action is T029 in a new implementation
process while preserving the failed attempt.*

### Sicherer Block nach statischem T029-Retry / Safe Block after Static T029 Retry

Am 2026-08-30 um 14:41 Uhr Europe/Berlin wurde der eng begrenzte statische
T029-Retry ausgeführt. Akzeptierte Artefakthashes, 28 Checkboxen,
Source-Contract und Original-DLL-Hash waren vor dem Start unverändert. Die
isolierte Version 18.8.0 instrumentierte ausschließlich eine temporäre DLL;
die instrumentierte Kopie lag nur während des Versuchs am Release-Ausgabepfad.
Der Collector startete in einer echten PTY, doch der Kindprozess erreichte in
mehr als 40 Sekunden keine sichtbare Terminalinitialisierung und die PTY blieb
im Echo-Modus. Nach dem gezielten Abbruch nur dieser Session lautete der
Exitcode `130`; der Collector meldete erneut einen nicht initialisierten
Profiler und hinterließ wieder nur 10 Byte. / *The bounded static T029 retry
started in a real PTY, but the child did not reach visible terminal
initialisation within more than 40 seconds and the PTY remained in echo mode.
Only that exact session was terminated. It exited 130, reported the profiler
as uninitialised again, and left another 10-byte file.*

Der Retry ist als eigener Fehlversuch in `evidence/manual-tui.md` erhalten. Die
Original-DLL wurde sofort bytegenau auf SHA-256
`f176e4f857bccdfbe7447970ae5b2fad61832cd023ef6fdcc35555981fe403f2`
zurückgesetzt. T029 bleibt offen, T030 wurde nicht gestartet, und keine
Produktquelle, PDB, Paketauflösung oder getrackte Konfiguration wurde durch den
Workaround verändert. Der autonome Lauf stoppt fail-closed an der sicheren
Aufgabengrenze bei 28/80. / *The retry remains separate failed-attempt
evidence. The original DLL was restored byte-for-byte. T029 remains open,
T030 did not start, and the workaround changed no product source, PDB, package
resolution, or tracked configuration. The run stops fail-closed at the safe
task boundary with 28/80 tasks.*

### Wiederaufnahme mit sicherer statischer Initialisierung / Resume with Safe Static Initialization

Die anschließende fokussierte Diagnose nutzte dieselbe isolierte Microsoft-
Version 18.8.0 und ergänzte ausschließlich die offiziell dokumentierte
Coverage-Einstellung
`EnableStaticManagedInstrumentationSafeInitialization=True`. Dynamische
Managed-Instrumentierung sowie statische und dynamische Native-
Instrumentierung waren deaktiviert; die Konfiguration lag nur unter
`/tmp/tinycalc-003/static-safe.settings.xml`. Die so erzeugte instrumentierte
DLL lag nur für den Diagnose-Slice am Release-Ausgabepfad. / *The focused
diagnostic added only Microsoft's documented safe-initialization option to the
isolated 18.8.0 static managed instrumentation. Dynamic managed and all native
instrumentation were disabled, and the settings file exists only under the
temporary task directory.*

Der unveränderte `dotnet-coverage collect`-/`dotnet run --no-build`-Pfad
erreichte danach in einer echten PTY sofort die Terminal.Gui-Aushandlung. Nach
den bekannten ANSI-Fähigkeitsantworten waren genau ein Root-Fenster,
Startzelle `A1` und das File-Menü sichtbar. Menü-Quit beendete denselben
Prozess mit Exitcode `0`; Alternate Screen, Mausmodi, Bracketed Paste und
Cursor wurden zurückgesetzt. Die erzeugte Coverage-Datei ist 27.915 Byte groß,
ließ sich mit `dotnet-coverage merge` fehlerfrei in Cobertura konvertieren und
enthält `MicroCalc.Tui.Program` sowie den Quellpfad `Program.cs`. / *The same
collect and no-build run path then reached Terminal.Gui negotiation
immediately in a real PTY. One root, A1, the File menu, menu quit, exit zero,
and terminal restoration were observed. The 27,915-byte coverage file merged
successfully to Cobertura and contains MicroCalc.Tui.Program and Program.cs.*

Die Original-DLL wurde unmittelbar danach wieder auf SHA-256
`f176e4f857bccdfbe7447970ae5b2fad61832cd023ef6fdcc35555981fe403f2`
hergestellt. Branch, Checkpoint, aktueller Zehn-Ziel-Review, installierte
Preset-Versionen, Routing, Autorität, Aufgaben und verbotene Pfade wurden erneut
bestätigt; es gibt keinen materiellen Drift und keinen verpflichtenden
Regel-Delta-Befund. Nächste exakte Aktion ist T029 mit derselben sicheren
statischen Initialisierung und unmittelbaren ANSI-Antworten in einem neuen
Implement-Prozess. / *The original DLL was restored to its exact SHA-256.
Branch, checkpoint, Ready review, presets, routing, authority, tasks, and
forbidden paths were revalidated with no material drift or mandatory delta.
The exact next action is T029 with the proven safe static initialization and
prompt terminal capability responses in a new implementation process.*

### Erfolgreicher T029-/T030-Abschluss und US2-Gate / Successful T029/T030 Completion and US2 Gate

Am 2026-08-30 wurden T029 und T030 mit der zuvor bewiesenen sicheren statischen
Managed-Initialisierung vollständig abgeschlossen. Sitzung 1 wiederholte alle
zwölf Navigationsinputs aus bekannten Zellen, Eingabe-, Funktions- und
Dateidialog, `Tab`, `Shift+Tab`, `Esc` sowie Menü-Quit. Sitzung 2 prüfte
`Ctrl+Q` getrennt als Input 13. Beide echten PTY-Sitzungen endeten mit Exitcode
`0`, ohne Traceback und mit sichtbarer Terminalrestauration. / *Both real PTY
sessions completed with exit code zero, no traceback, and visible terminal
restoration. Session 1 covered all twelve navigation inputs, three dialog
types, forward and reverse focus, Escape, and menu quit; session 2 covered
Ctrl+Q independently as input 13.*

Beide Coverage-Dateien sind je 27.915 Byte groß, lassen sich nach Cobertura
zusammenführen und enthalten `MicroCalc.Tui.Program` mit `Program.cs`. Die
nicht instrumentierte Release-DLL wurde danach bytegenau auf SHA-256
`f176e4f857bccdfbe7447970ae5b2fad61832cd023ef6fdcc35555981fe403f2`
wiederhergestellt. Die früheren 10-Byte- und PTY-Fehlversuche bleiben
unverändert als historische Befunde erhalten. / *Both coverage files are
27,915 bytes, merge to Cobertura, and contain the migrated program and source
file. The original Release DLL was restored byte-for-byte; all earlier failed
attempts remain preserved as historical findings.*

T031 und T032 dokumentieren den vollständigen linearen Bedienpfad sowie WCAG
2.2 AA 1.4.1, 2.1.1, 2.1.2, 2.4.3 und 2.4.7 mit Status, Beobachtung und
Wiedervorlage. Pointer-, Bild-, Medien- und Animationskriterien sind begründet
`N/A`. Der abschließende T033-Vertrag bestätigt null Diff in `tests/`,
`src/MicroCalc.Core/` und `CALC.HLP`, Terminal.Gui exakt 2.4.17, null alte
Masken/Lifecycle-Aufrufe und die vollständige 13er-Matrix `8 + 4 + 1`.
Checkboxen und Evidenz binden damit 33/80; nächste exakte Aktion ist T034. /
*The accessibility evidence records each applicable criterion and justified
N/A with re-review triggers. The final US2 contract confirms forbidden paths
unchanged, exact package version, no legacy masks or lifecycle, and all 13
bindings. Evidence now binds 33/80 tasks; the next exact action is T034.*

### Lokaler US3-Abschluss / Local US3 Closure

T034 bis T045 wurden am 2026-08-30 seriell abgeschlossen. Der finale Restore
bindet `Terminal.Gui` exakt an 2.4.17 und den ausgelieferten TUI-Graph an ein
direktes plus 23 transitive Pakete aus NuGet.org. Der Release-Build bestand mit
null Warnungen und null Fehlern; alle 79 vorhandenen Tests bestanden ohne Skip;
der Headless-Smoke endete mit Exitcode `0` und exakt `SMOKE_OK`. / *The final
restore binds Terminal.Gui exactly to 2.4.17 and the shipped TUI graph to one
direct plus 23 transitive NuGet.org packages. Release build, all 79 tests, and
the exact headless smoke token pass locally.*

Die echte Out-of-process-Coverage aus Tests, Smoke und realen PTY-Sitzungen
erreicht 82 von 100 geänderten ausführbaren Zeilen, also 82,0 Prozent. Die
Abhängigkeitsprüfung meldet null bekannte Schwachstellen, 24 von 24 bekannte
und kompatible Lizenzen sowie keine unbekannte oder unvereinbare Lizenz. Eine
nicht für den ausgelieferten Graph verwendete authentifizierte lokale Quelle
wurde aus allen getrackten Nachweisen ausgeschlossen. / *Real out-of-process
coverage reaches 82.0 percent. The dependency review reports zero known
vulnerabilities and 24 of 24 known compatible licenses. No authenticated local
source remains in tracked evidence.*

Der Scope-Vertrag `git diff --exit-code -- tests src/MicroCalc.Core CALC.HLP`
bestand ohne Ausgabe. `evidence/us3-checkpoint.md` bindet FR-005/-006/-010/
-012/-013 und TG-GATE-003/-004/-007..011. Damit sind 45 von 80 Aufgaben
belegt. User Story 3 ist lokal abgeschlossen, aber nicht plattformvollständig:
Linux und Windows bleiben bis T066 offen, und die Coverage muss nach dem
Feature-Commit als Exact-Head-Schnitt reproduziert werden. Nächste exakte
Aktion ist T046. / *The forbidden-scope diff is empty and the US3 checkpoint
maps all required feature requirements and gates. Evidence now binds 45 of 80
tasks. Linux, Windows, and post-commit exact-head revalidation remain binding;
the next exact action is T046.*

### Lokaler US4-Implementierungsstand an T056 / Local US4 Implementation State at T056

Die lokale Architektur-, Security-, Supply-Chain-, Dokumentations- und
Statistikarbeit T046–T055 ist abgeschlossen. Owner dieser Evidenz ist der
autonome Spec-Kit-Lauf. Der unabhängige Reviewer ist bis zum konkreten Pull
Request und dessen unverändertem Head `Pending`; diese Rolle wird nicht durch
die lokale Selbstevidenz ersetzt. / *Local architecture, security,
supply-chain, documentation, and statistics work T046–T055 is complete. The
autonomous run owns the evidence. The independent reviewer remains pending
until the concrete pull request and unchanged reviewed head exist.*

| Gates | Lokaler Zustand / Local state | Primäre Evidenz / Primary evidence |
|---|---|---|
| `TG-GATE-001..002` | `Pass` | `evidence/preflight.md`, akzeptierte Spec-/Plan-/Checklist-Hashes und dieses Laufdokument |
| `TG-GATE-003..004` | `Pass` lokal / locally | `evidence/dependencies/package-selection.md`, `dependency-review.md`, `packages-all.json`, `packages-vulnerable.json`, `licenses-shipped.json`, `docs/security/dependency-audit.md` |
| `TG-GATE-005..006` | `Pass` | `evidence/source-contract-green.md`, `evidence/manual-tui.md`, `evidence/regression.md` |
| `TG-GATE-007..011` | `Pass` lokal; Exact-Head-Reproduktion `Pending` | `evidence/regression.md`, `evidence/coverage-summary.md`, `evidence/red-green-refactor/`, `evidence/us3-checkpoint.md` |
| `TG-GATE-012..014` | `Pass` lokal / locally | `evidence/manual-tui.md`, `docs/accessibility/terminalgui-migration.md`, `evidence/documentation-review.md` |
| `TG-GATE-015` | Vorläufig `Pass`; finaler Index-/Staging-Beleg `Pending` | `evidence/delivery-set-intent.md` und unveränderte verbotene Pfade |
| `TG-GATE-016..018` | `Pass` lokal; Rebind am Delivery-Head `Pending` | `docs/security/threat-model.md`, `security-checklist.md`, `security-quality-scenarios.md`, `samm-assessment.md` |
| `TG-GATE-019` | `Pass` lokal; Commit-Bindung `Pending` | `docs/security/sbom/tinycalc-terminalgui.spdx.json`, `evidence/sbom-generation.md` |
| `TG-GATE-020` | Tatsächliche lokale Haltung dokumentiert; Providerbeleg `Pending` | `docs/security/supply-chain-evidence.md`: keine SLSA-Stufe ohne verifizierbare Provenance behauptet |
| `TG-GATE-021` | `Pass` lokal / locally | datierter OpenSSF-Review in `docs/security/supply-chain-evidence.md` |
| `TG-GATE-029..030` | `Pass` lokal / locally | genau ein fokussierter S-ADR `docs/security/adr/003-terminalgui-lifecycle-supply-chain.md` und vollständiges `docs/security/arc42-security.md` |
| `TG-GATE-035` | Zwischenstand `Pass`; finale Commitzahl `Pending` | `evidence/version-evidence.md`, `Directory.Build.props` |
| `TG-GATE-036` | `Pass` | Feature-003-Profil in `docs/project-statistics.config.json`; Renderer und `-CheckOnly` melden `CURRENT` |
| `TG-GATE-037..038` | `Pending` | reale Ubuntu-/Windows-Produktjobs am späteren exakten PR-Head in `evidence/platform-ci.md` |
| `TG-GATE-039` | Vorläufig `Pass`; Index-/Commitbeleg `Pending` | `evidence/delivery-set-intent.md`; finaler Diff, Index und Commit fehlen noch |
| `TG-GATE-040..045` | `Pending` | Schema-2.0 PreMerge/PostMerge, Review, MergeAndSync, Sync und kausaler Closeout werden nicht vorweggenommen |
| `TG-GATE-047` | Nutzerautorität vorhanden; konkrete PR-/Ruleset-Revalidierung `Pending` | Abschnitt „Identität und Autorität“; kein technisches Gate darf ersetzt werden |
| `TG-GATE-048` | `Pending` | Trailerprüfung unmittelbar nach jedem späteren lokalen oder Provider-Commit |

#### Exact-Head-Platzhalter / Exact-head Placeholder

| Beleg / Proof | Zustand / State |
|---|---|
| Produkt-Commit-SHA / Product commit SHA | `Pending` |
| Pull-Request-Head-SHA | `Pending` |
| Ubuntu-Produktjob und unveränderliche URL | `Pending` |
| Windows-Produktjob und unveränderliche URL | `Pending` |
| Exact-Head-Build, Tests, Smoke und Coverage-Reproduktion | `Pending` |
| Unveränderter Review-Head und unabhängiger Reviewer | `Pending` |
| Produkt-Merge-Commit, lokaler Fast-forward-Sync und PostMerge-Evidenz | `Pending` |

Das verbleibende lokale Restrisiko liegt vor allem in plattformspezifischen
Terminal.Gui-Unterschieden sowie in noch nicht vorhandenen Provider- und
Exact-Head-Belegen. Diese Risiken bleiben fail-closed: Ein lokaler Erfolg, ein
Jobname oder der enge Admin-Bypass ersetzt sie nicht. Die nächste sichere
Aktion ist T057, die erneute N/A-Triggerbewertung gegen den tatsächlichen Diff.
Es wurde weder gepusht noch ein PR eröffnet, geprüft, gemergt oder
synchronisiert. / *Residual risk is concentrated in platform-specific
Terminal.Gui behaviour and still-missing provider/exact-head proof. These
risks remain fail-closed. The next safe action is T057. No push, pull request,
review, merge, or synchronization has been performed or claimed.*

### N/A-Neubewertung gegen den tatsächlichen Diff / N/A Re-evaluation Against the Actual Diff

T057 hat die N/A-Trigger gegen den tatsächlichen Feature-Diff erneut geprüft.
`git diff --name-only` liefert für `scripts/`, alle fünf gemeinsamen
Agentenflächen, `docfx.json`, `_site/`, `src/MicroCalc.Core/`, `tests/` und
`CALC.HLP` keinen Pfad. Feature 003 ergänzt weder Web/API/Cloud/Remote/KI-
Runtime noch Dependency-Automation. / *T057 re-evaluated each N/A trigger
against the actual feature diff. Scripts, all five shared agent surfaces,
DocFX, generated site output, Core, tests, and help remain unchanged. The
feature adds no web, API, cloud, remote, AI-runtime, or dependency-automation
surface.*

| Gate oder Entscheidung / Gate or decision | Disposition | Begründung / Rationale | Wiedervorlage / Trigger | Genehmigter Evidenzort / Approved evidence location |
|---|---|---|---|---|
| `TG-GATE-022` VEX | bedingt `N/A` | null bekannte Schwachstellen und kein Fehlalarm; VEX darf einen bekannten ausgelieferten Fund niemals genehmigen | belegter Fehlalarm oder bewertete nicht ausgelieferte Komponente | `docs/security/supply-chain-evidence.md` |
| `TG-GATE-023` ASVS | `N/A` | lokale TUI ohne Web, HTTP, API, Authentifizierung oder Session | Einführung einer dieser Flächen; dann Level und Scope festlegen | `docs/security/arc42-security.md`, Wrapper `asvs-verification.md` |
| `TG-GATE-024` AI-SBOM | `N/A` | KI ist nur Entwicklungswerkzeug und kein ausgelieferter Produktbestandteil | Modell, KI-Dienst, Datensatz, Inferenz- oder KI-Runtime im Produkt | `docs/security/supply-chain-evidence.md` |
| `TG-GATE-025` Zero Trust | `N/A` | lokaler Einprozessbetrieb ohne verteilten Dienst oder Remoteverwaltung | Netzwerk-, Cloud-, Service-, Remote- oder Identitätsgrenze | `docs/security/arc42-security.md`, Wrapper `zero-trust-applicability.md` |
| `TG-GATE-026` BSI C3A | `N/A` | kein Cloud-Service, keine Cloud-API, kein Cloud-Kundenbetrieb | Cloud-Funktion oder Cloud-Service-Lieferung | `docs/security/arc42-security.md` |
| `TG-GATE-027` BSI C5 | `N/A` | kein Cloud-Dienst und keine Kundendatenverarbeitung in der Cloud | Cloud-Betrieb oder Cloud-Service-Provider | `docs/security/arc42-security.md` |
| `TG-GATE-028` NIS2/CRA/EU AI Act/DORA | kein Feature-Delta bzw. `N/A` | keine neue Betreiber-, Markt-, KI-Produkt- oder Finanzdienstrolle; keine allgemeine Rechtsentscheidung | geänderter Organisations-, Distributions-, KI- oder Kunden-/Vertragsscope | `docs/security/arc42-security.md` |
| allgemeiner Architektur-ADR | `N/A` | Intake und Plan binden die v2-Migration; kein neues Subsystem oder neue Schicht | neue allgemeine Architekturwahl oder Schicht | `docs/security/arc42-security.md` |
| `TG-GATE-031` Script-/Cmdlet-Parität | `N/A` | kein Skript oder Cmdlet geändert oder ergänzt | neue/geänderte Automation oder plattformspezifischer Skriptpfad | dieses Laufdokument; final Schema-2.0 |
| `TG-GATE-032` Agentenflächen-Parität | `N/A` | keine gemeinsame KI-Agenten-Guidance geändert | Änderung an einer gemeinsamen Agentenfläche oder Workflowregel | dieses Laufdokument; final Schema-2.0 |
| `TG-GATE-033` Parallel-Parität | `N/A` | ausdrücklich serieller autonomer Lauf, keine Kampagne oder Delegation | parallele Kampagne, Delegation oder Kampagnenzustand | dieses Laufdokument; final Schema-2.0 |
| `TG-GATE-034` XML/DocFX/A11Y-Smoke | `N/A` | keine öffentliche API-Signatur/XML-Doku, DocFX-Navigation oder HTML-Ausgabe geändert | entsprechende API-, XML-, DocFX- oder `_site`-Änderung | dieses Laufdokument; final Schema-2.0 |
| `TG-GATE-046` Dependency-Automation | `N/A` | kein genehmigter Dependabot-, Renovate-, Dependency-Track- oder Lockfile-Scope | eigenes Supply-Chain-Intake oder ausdrückliche Automationsautorität | `docs/security/supply-chain-evidence.md` |

Der fokussierte S-ADR `docs/security/adr/003-terminalgui-lifecycle-supply-chain.md`
und `docs/security/arc42-security.md` bleiben dagegen `Applicable` und sind
vollständig. Es wurde keine N/A-Funktion, kein Paritätsskript, keine
Agentendatei und keine sonstige N/A-Implementierung ergänzt. Alle
Dispositionen werden in T067/T072 in die Schema-2.0-Evidenz übernommen. /
*The focused security ADR and arc42 Section 8 remain applicable and complete.
No N/A function, parity script, agent file, or other N/A implementation was
added. T067/T072 will carry every disposition into schema-2.0 evidence.*

### Git-/Remote-Revalidierung vor Delivery / Git and Remote Revalidation Before Delivery

T060 wurde am 2026-08-30 um 16:17 Uhr CEST vor der ersten Git-/Remote-
Schreibaktion ausgeführt. Die sichere Stopgrenze ist noch nicht erreicht und
der Run-State enthält keinen Stop-Request. / *T060 ran before the first Git or
remote write. The safe-stop boundary has not been reached, and the run state
contains no stop request.*

| Prüfung / Check | Ergebnis / Result |
|---|---|
| Branch und Checkpoint | `003-terminalgui-migration`; `886a13f8866e79fe6c13e6e1227217294aabdee8` |
| Run | `38ad4c1d-bf85-4053-b585-eb490176b727`, `Implement`, `Active`, `MergeAndSync` |
| Intake-Review | `2c338c63-9f64-47c1-ba50-a95c7ea3fce1`, `Ready`, zehn Ziele; PowerShell und Bash `Pass` |
| Serienoperation | `6a5e02a3-1cd2-4453-b383-99637d1ace81`, `Published`; Nutzerautorität nennt serielle autonome Läufe, `MergeAndSync` und engen Admin-Bypass |
| Serienreceipt | `d6666733-1254-4bb9-8b31-389a30d79733`, `Ready`; Manifest-Hash stimmt |
| GitHub-Anmeldung | aktives Konto `hindermath`; HTTPS, erforderlicher Repo-/Workflow-Zugriff vorhanden |
| Konkretes Repository | öffentliches `hindermath/TinyCalc`, Default-Branch `main` |
| Routing | lokales Profil nach festgestelltem Drift eng aktualisiert; anschließender Status `Aligned` |
| Run-State-Hashes | nach T060 auf 60/80 abgeglichen; PowerShell- und Bash-State-Validator `Pass` |

Die Autorität umfasst Commit, Push, fokussierten PR und `MergeAndSync`. Der
Admin-Bypass bleibt auf eine später konkret nachgewiesene formale
Merge-Berechtigungs- oder Ruleset-Grenze beschränkt. Er darf erst nach
bestandenen technischen, Security-, A11Y-, Plattform-, Exact-Head- und
Review-Gates verwendet werden. Die nächste sichere Aktion ist T061, die
prospektive Feature-Version ohne weiteren Build- oder Testaufruf auszurichten.

*Authority covers commit, push, the focused pull request, and MergeAndSync.
The narrow bypass remains limited to a concrete formal merge-permission or
ruleset boundary after every substantive gate passes. The next safe action is
T061, aligning the prospective feature version without another build or test.*

### Liefermengenvalidierung vor Staging / Delivery-set Validation Before Staging

T062 prüfte den noch vollständig ungestagten Arbeitsbaum. Der erste
read-only Validatorlauf meldete ausschließlich nachgestellte Leerzeichen in
neu erzeugten Markdown-Dateien und einer Projektdatei. Sie wurden mechanisch
in genau acht beabsichtigten Pfaden entfernt; keine Textzeile, Anforderung,
Reihenfolge oder Gate-Aussage änderte sich. Die dadurch geänderten SHA-256-
Bindungen werden im Run-State neu erfasst, und `delivery-set-intent.md` bindet
den whitespace-normalisierten Plan. Ein neuer Build oder Test lief nicht. /
*The first read-only validator found only trailing whitespace. It was removed
mechanically from exactly eight intended paths without changing any line of
meaning, requirement, ordering, or gate. Updated hashes are rebound in run
state and the delivery intent; no build or test ran.*

Der wiederholte Validatorlauf bestand mit folgendem Ergebnis:

- `67` tatsächlich geänderte Pfade sind jeweils exakte Allowlist-Einträge.
- `49` ungetrackte Lieferpfade wurden dem Validator einzeln übergeben;
  sachfremde ungetrackte Pfade: `0`.
- Indexbaum vor und nach der Prüfung:
  `309bd2071df57be30cf7568986c1d0b3bc25248c`; der Index blieb leer.
- `git diff --name-status main...HEAD` blieb leer, weil vor T063 noch kein
  Feature-Commit existiert.
- `git diff --check` bestand.
- Core, bestehende Tests, `CALC.HLP`, Skripte, fünf Agentenflächen, DocFX,
  `_site`, Feature 004 und der Rename-Intake besitzen keinen Diff.
- Unter `.github/workflows/` ist ausschließlich `.github/workflows/ci.yml`
  geändert.

*The repeated validator passed: all 67 changed paths are allowlisted, all 49
untracked delivery files were supplied individually, no unrelated untracked
path exists, the index stayed empty, the pre-commit branch diff is empty,
whitespace validation passes, every forbidden area is unchanged, and the CI
workflow is the sole workflow delta.*

### Produkt-Commit und Push / Product Commit and Push

T063 erzeugte den fokussierten Commit
`c07012af6cf26840104c71ad76fa997e0ab5b4e1`. Er enthält exakt die 67 zuvor
validierten Pfade, `git rev-list --count main..HEAD` ist `1`, alle drei
Versionsfelder sind `1.3.1.13`, und die vorgeschriebene Co-author-Zeile steht
genau einmal in der tatsächlichen Commitnachricht. / *T063 created the focused
commit shown above. It contains exactly the 67 validated paths, has feature
commit count one, aligns all version fields to 1.3.1.13, and contains the
required co-author trailer exactly once.*

T064 revalidierte am 2026-08-30 um 16:24 Uhr CEST den aktiven Stopstatus,
GitHub-Konto `hindermath`, Remote `https://github.com/hindermath/TinyCalc.git`,
Commitbaum, Trailer und leeren Delivery-Validator. Der Branch wurde ohne
Force-Push veröffentlicht. `git ls-remote` lieferte für
`refs/heads/003-terminalgui-migration` exakt
`c07012af6cf26840104c71ad76fa997e0ab5b4e1`. Es existierte zu diesem Zeitpunkt
noch kein Pull Request. / *T064 revalidated authority and the exact clean
commit, pushed without force, and proved that the remote branch head equals
the local exact head. No pull request existed at that point.*

### Fokussierter Produkt-PR / Focused Product Pull Request

T065 eröffnete mit der authentifizierten `gh`-CLI genau einen Pull Request:

| Feld / Field | Wert / Value |
|---|---|
| PR | `#60` |
| URL | `https://github.com/hindermath/TinyCalc/pull/60` |
| Titel / Title | `feat: migrate Terminal.Gui to 2.x` |
| Base | `main` |
| Head | `003-terminalgui-migration` |
| `headRefOid` | `c07012af6cf26840104c71ad76fa997e0ab5b4e1` |
| Zustand bei Anlage / Initial state | `OPEN`; Checks und Review noch `Pending` |

Der Provider-Body entspricht
`docs/PR_TEXT_TERMINALGUI_MIGRATION.md`. Die Abfrage fand genau einen offenen
PR für den Branch. Zu diesem Zeitpunkt wurden weder ein Check als bestanden
vorweggenommen noch ein Review, Merge oder Sync behauptet. / *The provider body
matches the prepared PR text, exactly one open pull request exists for the
branch, and its head equals the verified product commit. Checks, review,
merge, and synchronization remain pending.*

### Exact-Head-Reparatur nach Homogeneity-Befund / Exact-head Repair after Homogeneity Finding

Der erste vollständige PR-Checklauf meldete ausschließlich einen Drift des
generierten ASCII-Statistikprofils. Produktjobs, Security-Scans,
PSScriptAnalyzer, Maintenance TUI und Claude Review waren nicht die Ursache.
Der vorhandene Renderer wurde ohne Skriptänderung auf dem getrackten
Produkt-Head ausgeführt; `-CheckOnly` meldete danach `CURRENT`. Weil
`docs/project-statistics.md` und `Directory.Build.props` vom Statistik-
Historienmodell ausgeschlossen sind, bleibt der Generator-Quellstand nach dem
engen Reparaturcommit stabil auf `c07012af6cf2`. / *The first complete PR
check found only generated statistics drift. The existing renderer was run
without a script change and then reported CURRENT. The statistics ledger and
version file are excluded from the history model, so the generated source
revision remains stable after the focused repair commit.*

Der zweite, themengleiche Commit
`6d8612ec8ff5b969890c093fcf228af4a3d0e137` enthielt ausschließlich
`docs/project-statistics.md` und `Directory.Build.props`. Sein Block war jedoch
aus dem laufenden Evidenz-Workspace erzeugt und zählte 43 noch uncommittete
Zeilen mit; der Provider meldete deshalb erneut Drift. Dieser Head und seine
T066-/T067-Belege sind ausdrücklich ungültig. / *The second same-topic commit
changed only the statistics ledger and version file, but its block had been
rendered from the active evidence workspace and counted 43 uncommitted lines.
The provider therefore reported drift again; that head and its platform and
PreMerge evidence are invalid.*

Der finale Reparaturblock wurde danach aus einem sauberen, detached Worktree
des tatsächlichen Provider-Heads erzeugt. Commit
`d0a5bd435488d9c57a905f883e6c90a919b0c134` enthält wiederum nur die zwei
ausgeschlossenen Statistik-/Versionspfade, richtet ohne lokalen Build/Test auf
`1.3.3.13` aus und besitzt den vorgeschriebenen Trailer genau einmal. Ein
zweiter sauberer detached Worktree bestätigte vor dem normalen Push
`CURRENT`, Quelle `c07012af6cf2`, 150.578 Textzeilen. Es gab keinen Force-Push.

*The final block was generated from a clean detached worktree at the actual
provider head. Commit d0a5bd4 changes only the two excluded statistics/version
paths, aligns 1.3.3.13 without a local build or test, and has the exact trailer
once. Another clean detached worktree reported CURRENT before the normal,
non-force push.*

Der endgültige Pull-Request-Run `33317549562` bestand auf diesem Head.
Ubuntu-Job `99273646336` und Windows-Job `99273646446` führten alle vier
exakten Produktbefehle erfolgreich aus, bestanden 79/79 Tests und gaben jeweils
exakt einmal `SMOKE_OK` aus. Die aktuelle Bindung steht ausschließlich in
`evidence/platform-ci.md`. / *Final replacement run 33317549562 passes on the
current head. Both immutable platform jobs reran the exact commands, passed all
79 tests, and emitted exactly one SMOKE_OK. Platform evidence now binds only
the final head.*

### PreMerge und Review-Konvergenz / PreMerge and Review Convergence

T067 erzeugte für den unveränderten PR-Head
`d0a5bd435488d9c57a905f883e6c90a919b0c134` den Schema-2.0-Snapshot
`1a017fa4-3530-441d-85bd-32d65b0487de`. Er enthält exakt 48 Primary-Zeilen
und zwei zusätzliche historische Trailerbelege. Der Validator bestand; der
normalisierte SHA-256 lautet
`83b7cd2fdcea4e9417cd4d3d8eb4bfd6419129a0835a9b9b5a511cd824a14acf`.

T068 konvergierte PR `#60` am 2026-08-30 auf demselben Head:

| Prüfung / Check | Ergebnis / Result |
|---|---|
| `gh pr checks --watch` | alle 17 gemeldeten Check-Runs `SUCCESS`, einschließlich Linux, Windows, Security, Homogeneity, Maintenance, PSScriptAnalyzer und Claude Review |
| Review-Threads per GraphQL | `0` Threads, daher `0` offen und `0` veraltet |
| Formale Reviews per GraphQL | `0` Changes Requested; GitHub `reviewDecision=REVIEW_REQUIRED` |
| Unabhängiger inhaltlicher Reviewer | Workflow `Claude Code Review`, Run `33317549564`, Job `99273646238`, `SUCCESS`, zehn Review-Turns und keine gepufferten Inline-Befunde |
| Exact Head | `headRefOid=d0a5bd435488d9c57a905f883e6c90a919b0c134`, unverändert |
| Providerzustand | `mergeStateStatus=BLOCKED` ausschließlich durch Ruleset `main` (`13146993`): ein Approval plus Code-Owner-Review |

Der unabhängige Review ist damit vorhanden und befundfrei. Der Claude-Job
besitzt absichtlich nur Leserechte und kann keinen formalen GitHub-Approval-
Datensatz schreiben. Die verbleibende `REVIEW_REQUIRED`-Anzeige ist daher eine
konkrete formale Repository-Policy-Blockade und kein fehlender inhaltlicher
Review. Sie darf nur nach T069 unter Thorstens enger Autorität überbrückt
werden; kein Fach-, Security-, A11Y-, Plattform-, Thread-, Changes-Requested-
oder Exact-Head-Gate wird dadurch ersetzt.

*T067 produced and validated the schema-2.0 PreMerge snapshot for the unchanged
head. T068 then converged all 17 reported checks, zero review threads, zero
Changes Requested, and an independent successful Claude code-review job with no
inline findings. GitHub still reports REVIEW_REQUIRED solely because the
read-only reviewer cannot create the approval record required by ruleset
13146993. This is a formal policy block, not missing substantive review, and may
only be bypassed after the narrow T069 authority revalidation.*

### Enge Merge-Bypass-Revalidierung / Narrow Merge-bypass Revalidation

T069 revalidierte am 2026-08-30 um 16:48 Uhr CEST unmittelbar vor der
Mergeaktion folgende konkrete Bindung für `TG-GATE-047`:

| Feld / Field | Bindung / Binding |
|---|---|
| Autorisierer / Authorizer | Thorsten Hindermann |
| Autorität / Authority | Operation `6a5e02a3-1cd2-4453-b383-99637d1ace81`, `Published`; Receipt `d6666733-1254-4bb9-8b31-389a30d79733`, `Ready`; ausdrücklich `MergeAndSync` mit engem Admin-Bypass |
| Konkreter Gegenstand / Concrete target | `hindermath/TinyCalc`, PR `#60`, Head `d0a5bd435488d9c57a905f883e6c90a919b0c134`, Base `main` |
| Konkrete Policy / Concrete policy | aktives Ruleset `main` (`13146993`), ein Approval plus Code-Owner-Review; `current_user_can_bypass=always` |
| Grund / Rationale | GitHub meldet trotz grünem unabhängigem Claude-Review, null Threads und null Changes Requested ausschließlich `REVIEW_REQUIRED`; der Owner kann den eigenen PR nicht formal genehmigen |
| Restrisiko / Residual risk | GitHub besitzt keinen formalen Approval-Datensatz. Das wird durch den immutable, erfolgreichen, befundfreien unabhängigen Review-Job transparent begrenzt, aber nicht als formales Approval ausgegeben |

Der Admin-Bypass wird ausschließlich für diese formale Merge-Berechtigung
verwendet. Er ersetzt kein Fach-, Security-, A11Y-, Linux-, Windows-,
Exact-Head-, Review-Inhalts-, Thread- oder Changes-Requested-Gate. Bei Head-
Drift, neuem Befund oder fehlgeschlagenem Check erlischt diese Freigabe vor dem
Merge.

*T069 revalidated Thorsten's current authority, the exact repository, pull
request, head and active ruleset immediately before merge. The narrow admin
bypass is authorized only for the formal approval/code-owner record that the
owner cannot create on the owner's own pull request. It does not replace any
technical, security, accessibility, platform, exact-head or substantive review
gate, and head drift or a new finding revokes it before merge.*

### Produktmerge, Synchronisation und PostMerge / Product Merge, Synchronization, and PostMerge

PR `#60` wurde am `2026-08-30T14:49:19Z` mit dem unveränderten geprüften Head
gemerged. Der tatsächliche Provider-Merge-Commit ist
`43e47d9a31b6c3bc79d58d834f95bf8dfecb5595`. Seine unmittelbar per `gh api`
gelesene Nachricht enthält die vorgeschriebene Co-author-Zeile exakt einmal.
Lokales `main` und `origin/main` wurden ausschließlich per Fast-Forward auf
genau diesen Commit synchronisiert.

Der danach kausal erzeugte Schema-2.0-PostMerge-Snapshot
`1fae8503-6a70-45fd-8353-11326bc37b67` bindet:

- Reviewed Head `d0a5bd435488d9c57a905f883e6c90a919b0c134`;
- akzeptierten PreMerge-SHA-256
  `83b7cd2fdcea4e9417cd4d3d8eb4bfd6419129a0835a9b9b5a511cd824a14acf`;
- Merge-Commit `43e47d9a31b6c3bc79d58d834f95bf8dfecb5595`;
- leere `changedPaths`;
- exakt 48 Primary- und zwei Supplemental-Zeilen.

`validate-autonomous-gate-evidence.ps1` bestand mit Exitcode 0. Der
normalisierte PostMerge-SHA-256 lautet
`a06005a939644b199de57fd01f4252ab75461afd5960e3381d29757305702377`.
Erst ab dieser bestandenen Grenze darf der separate kausale Intake-Closeout
beginnen.

*PR 60 was merged at the unchanged reviewed head. The actual provider merge
commit contains the required trailer exactly once, and local and remote main
were synchronized to it by fast-forward only. The causal schema-2.0 PostMerge
snapshot binds the accepted PreMerge hash, actual merge commit, empty changed
paths, 48 Primary entries, and two Supplemental entries. The validator passed,
so the separate intake closeout may now begin.*

### Closeout-Autorität / Closeout Authority

T073 revalidierte am 2026-08-30 um 16:52 Uhr CEST den aktiven Run-State ohne
Stopanforderung, den bestandenen PostMerge-Hash
`a06005a939644b199de57fd01f4252ab75461afd5960e3381d29757305702377` und
exakt synchrones lokales/remote `main` auf
`43e47d9a31b6c3bc79d58d834f95bf8dfecb5595`.

Thorstens aktuelle Anweisung zu weiteren seriellen autonomen Spec-Kit-Läufen
mit `MergeAndSync` sowie Operation
`6a5e02a3-1cd2-4453-b383-99637d1ace81` und Receipt
`d6666733-1254-4bb9-8b31-389a30d79733` autorisieren für diesen kausalen
Closeout genau:

1. den branchgestempelten Rename von
   `Lastenheft_TerminalGui_Migration.md` für Feature 003;
2. genau eine Mutation der Serie `tinycalc-delivery`, die Feature 003 als
   geliefert fortschreibt und ihre Vorgängerlinie erhält;
3. genau einen vorbenannten Closeout-Branch und genau einen Closeout-PR mit
   `MergeAndSync` unter derselben engen Bypass-Grenze.

Nicht autorisiert sind eine andere Serie, Feature 004, ein weiterer Intake,
ein dritter Commit-/PR-Pfad oder sonstige Produktänderungen.

*T073 revalidated the active non-stopped run, the passing PostMerge hash, and
exact synchronized main. Thorsten's current serial autonomous-run instruction,
together with the published operation and ready receipt, authorizes exactly one
Feature 003 Lastenheft rename, one causal tinycalc-delivery series mutation, and
one pre-named Closeout branch and pull request. No other series, next feature,
intake, product change, or third commit/PR path is authorized.*

### Vorläufiger Closeout-Commit / Provisional Closeout Commit

T074 erzeugte ausschließlich den vorbenannten Branch
`codex/003-terminalgui-migration-closeout` vom synchronisierten Produkt-Merge-
Commit. Das auf macOS exakt ausgeführte Bash-Skript benannte nur
`Lastenheft_TerminalGui_Migration.md` nach
`Lastenheft_TerminalGui_Migration.003-terminalgui-migration.md` um.

Der vorläufige Commit `f65276eb6f6225880553eb51c187e17016a682f6`
enthält ausschließlich dieses Rename-Paar. `git commit --amend --no-edit`
wurde unmittelbar ausgeführt; die vorgeschriebene Co-author-Zeile steht laut
tatsächlicher Commitnachricht exakt einmal. Es gibt weder eine Skript- noch
eine Feature-004-Änderung und keinen zweiten Closeout-Commit.

*T074 created only the pre-named closeout branch from synchronized main. The
exact Bash command renamed only the Feature 003 Lastenheft. The provisional
commit contains that rename pair alone and was immediately amended; its actual
message contains the required co-author trailer exactly once. No script,
Feature 004, or second closeout commit exists.*

### Kausale Serienmutation / Causal Series Mutation

T075 führte unter der T073-Autorität genau den Skill
`speckit-intake-series-update` für `tinycalc-delivery` aus. Der akzeptierte
Vorgänger wurde zuerst am unveränderten Produkt-Merge-Commit mit PowerShell-
und Bash-Validatoren erfolgreich geprüft. Seine Manifest- und Receipt-Dateien
liegen byteidentisch unter
`requirements/intakes/series-archive/tinycalc-delivery/20260830T145602Z/`.

Die exakten Unterschiede sind:

- Ziel 2 verwendet den branchgestempelten Pfad und wechselt von `Eligible` zu
  `Completed`;
- Ziel 3 `Lastenheft_Rename_MicroCalc_TinyCalc.md` wechselt von `Blocked` zu
  `Eligible`;
- genau die beiden Kanten mit dem alten Terminal.Gui-Pfad verwenden nun den
  branchgestempelten Pfad;
- Reihenfolge, zehn Ziele, vier Wurzeln, sechs Kanten und Evidence-Pfade bleiben
  unverändert;
- die Zustandskardinalität ist jetzt zwei `Completed`, ein `Eligible`, vier
  `Blocked` und drei `Pending`;
- kein Intake-Inhalt, keine andere Serie und kein Feature 004 wurde geändert.

Successor-Operation `f02706bb-83bd-4c66-946f-d2080cfac62f` ist `Published`;
Receipt `51757b18-f1fb-4742-b562-a6ac61728d47` ist `Ready`; Manifest-SHA-256
ist `fd56a58477bbde71d0c41e4c5e3d25b1da95ccfa6197b103a197004200db5ffc`.
PowerShell und Bash bestanden jeweils Manifest- und Receipt-Validierung. Die
einzige sichere Folgeaktion ist `$speckit-intake-series-status`.

*T075 used the intake-series-update skill exactly once for tinycalc-delivery.
The accepted predecessor passed both validator surfaces at the immutable product
merge commit and is archived byte-identically. Only the completed Feature 003
path and lifecycle, the directly unlocked rename intake, its two incident edges,
the derived order view, and successor operation/receipt changed. Cardinalities,
archive proof, validation results, and the exact next action are recorded above.*

### Read-only-Serienstatus / Read-only Series Status

T076 führte `speckit-intake-series-status` ohne Schreibzugriff aus. Die
Schema-2.0-Requirements-Governance ist auf PowerShell und Bash `Aligned` und
löst den kanonischen Serienpfad sowie den bevorzugten Kandidaten
`Lastenheft_Rename_MicroCalc_TinyCalc.md` gleich auf. Manifest- und Receipt-
Validator bestanden ebenfalls auf beiden Flächen.

| Feld / Field | Status |
|---|---|
| Serienidentität / Series identity | `5b4523b4-d946-4091-9cbc-11825af94332`, `Active` |
| Ziele, Wurzeln, Kanten / Targets, roots, edges | `10`, `4`, `6` |
| Deklariert bevorzugt / Declared eligible | genau `requirements/intakes/active/Lastenheft_Rename_MicroCalc_TinyCalc.md` |
| Weitere strukturell freie Wurzeln / Other structurally free roots | drei `Pending`-Wurzeln; keine automatische Ausführungsautorität |
| Blocker | vier lineare Nachfolger bleiben durch Rename, A11Y, Kommentarhärtung beziehungsweise Security blockiert |
| Receipt-Linie / Receipt lineage | `51757b18-f1fb-4742-b562-a6ac61728d47` verweist auf die byteidentische Vorgängerarchivierung `20260830T145602Z` |
| Tombstone | `N/A`, weil die Serie aktiv bleibt |
| Manifest/Order-Abgleich | jeder der zehn aufgelösten Zielpfade steht exakt einmal in `order.md` |
| Drift | keiner; alle Vorher-/Nachher-Hashes und `git status --porcelain` waren identisch |

`no-next-feature` ist ausdrücklich belegt: aktueller Branch ist nur
`codex/003-terminalgui-migration-closeout`, `.specify/feature.json` verweist
weiterhin auf `specs/003-terminalgui-migration`, und der Commit-Diff gegen
`main` enthält nur das Feature-003-Lastenheft-Rename. Weder der nun bevorzugte
Rename-Intake noch Feature 004 wurde spezifiziert oder ausgeführt. Der Status
erteilt keine Folgeautorität.

*T076 inspected the active series read-only. Requirements governance, manifest,
receipt, lineage, blockers, resolved paths, and the human order view are aligned
on both validator surfaces. Before/after hashes and Git status are identical.
No next feature was started: the repository remains on the Feature 003 closeout
branch and feature metadata still points to Feature 003. Status does not grant
authority to execute the newly eligible intake.*

### Terminale getrackte Closeout-Grenze / Terminal Tracked Closeout Boundary

Alle bis zum einzigen Closeout-Head kausal bekannten Fakten sind vor dessen
finalem T078-Amend getrackt vorbereitet: Produkt-PR und dessen Trailer,
Fast-Forward-Sync, PreMerge-/PostMerge-Bindung, enge Bypass-Revalidierung,
branchgestempeltes Lastenheft, Serien-Supersession, Archivlinie, beide
Validatorflächen und `no-next-feature`.

Der Closeout-Head ist definitionsgemäß genau der eine durch T078 per
`git commit --amend --no-edit` abgeschlossene Commit auf
`codex/003-terminalgui-migration-closeout`. Sein exakter SHA kann ohne
Selbstreferenz nicht in denselben Commit geschrieben werden. Er wird daher
unmittelbar nach dem Amend read-only ermittelt und zusammen mit PR, Checks,
Reviews, tatsächlichem Provider-Merge-Commit, sofortiger Trailerprüfung und
Fast-Forward-Sync ausschließlich in
`.specify/runtime/autonomous-routing/38ad4c1d-bf85-4053-b585-eb490176b727/closeout-provider-evidence.json`
gebunden.

Nach dem T078-Amend sind keine getrackten Writes mehr zulässig. Insbesondere
werden `delivery.md`, `autonomous-run-evidence.md`, `tasks.md`, die Serie und
die Statistik nach dem Closeout-Merge nicht mehr geändert. Der ignorierte
lokale Run-State und die ignorierte Runtime-/Provider-Evidenz bleiben außerhalb
jedes Delivery-Sets. Erwartete Provider-Verifikation: genau ein Closeout-PR,
grüne Checks am unveränderten Closeout-Head, unabhängiger befundfreier Review,
null offene Threads und Changes Requested, MergeAndSync, exakter Provider-
Trailer genau einmal und identisches lokales/remote `main`.

*All facts known before the single closeout head are prepared as tracked
evidence. The closeout head is the one commit completed by the T078 amend. Its
exact SHA cannot be embedded in itself, so it will be bound read-only with all
later provider facts in the ignored runtime evidence file. No tracked write is
allowed after that amend; provider merge, trailer, checks, reviews, and sync are
verified read-only only.*

### Statistikabschluss T077 / T077 Statistics Closeout

Die Closeout-Phase `003x` bilanziert vor dem Statistik-Selbstnachweis `0`
Produktions-, `0` Test- und `669` Dokumentations-/Evidenzzeilen netto. Das
entspricht `8.4` konservativen Arbeitstagen beziehungsweise `65.2` Stunden und
`0.4` Monaten sowie `5.4` Thorsten-Solo-Tagen beziehungsweise `41.7` Stunden
und `0.2` Monaten. Gegen einen sichtbaren Aktivtag sind `8.4x` und `5.4x`
gemischte Repository-Lieferdichte, keine Stoppuhrmessung.

Die exakt benannten terminalen Closeout-Proof-Dateien werden in `003x` manuell
gezählt und sind eng aus der automatischen History-/Snapshot-Selbstreferenz
ausgeschlossen. Dadurch bleibt der vorgeschriebene einzige Closeout-Commit
möglich, ohne seinen erst nach dem Commit bekannten SHA in den eigenen
Statistikblock schreiben zu müssen. Das Renderer-Skript und der Workflow blieben
unverändert. Der Renderer aktualisierte den Block in einem isolierten sauberen
Worktree mit demselben finalen Inhalt; anschließend meldete der exakte lokale
`-CheckOnly -Json`-Aufruf `CURRENT`, Quelle `c07012af6cf2`, 149.480
automatisch gezählte Textzeilen und 72 Git-Aktivitätstage.

*Phase 003x manually records 669 net closeout documentation/evidence lines and
the two required manual baselines. The exact terminal proof files are narrowly
excluded from automatic snapshot/history self-reference so one closeout commit
does not have to contain its own future SHA. Neither renderer nor workflow was
changed. Rendering used an isolated clean worktree with the same final content,
and the real workspace check then reported CURRENT.*

### Finaler Closeout-Diff vor T078-Amend / Final Closeout Diff before T078 Amend

Der abschließende Pfadsatz besteht ausschließlich aus dem branchgestempelten
Feature-003-Lastenheft, vier aktiven `tinycalc-delivery`-Serienartefakten, zwei
byteidentischen Vorgängerarchiven, zwei Statistikdateien, `tasks.md`, dieser
Run-Evidenz sowie `evidence/delivery.md` und `evidence/platform-ci.md`.

Der Exact-Path-Delivery-Validator, `git diff --name-status main`,
`git diff --check main`, die verbotenen Pfadprüfungen und der Statistik-
`-CheckOnly`-Aufruf müssen unmittelbar vor dem Amend bestehen. Core, TUI-
Produktcode, Tests, Hilfe, Skripte, Agentenflächen, Workflows, DocFX, Feature
004, FakeDriver und jede andere Intake-Serie bleiben diff-frei. Nur dieser
validierte Satz wird exakt gestagt und in den vorhandenen Rename-Commit
amendiert; danach folgen ausschließlich read-only Provider- und Runtime-
Nachweise.

*The final closeout path set is limited to the branch-stamped Feature 003
intake, four active series artefacts, two byte-identical predecessor archives,
two statistics files, tasks, run evidence, delivery evidence, and platform
evidence. Exact-path, whitespace, forbidden-scope, and statistics checks must
pass immediately before the single amend. Product, tests, scripts, agents,
workflows, DocFX, Feature 004, and every other series remain unchanged.*
