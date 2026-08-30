# Feature-Spezifikation / Feature Specification: Terminal.Gui-2.x-Migration

**Feature-Branch / Feature Branch**: `003-terminalgui-migration`
**Erstellt / Created**: 2026-08-30
**Status / Status**: Bereit für die Klärungsphase / Ready for clarification
**Verbindliche Eingabe / Binding Input**: `requirements/intakes/active/Lastenheft_TerminalGui_Migration.md`
**Akzeptierter SHA-256 / Accepted SHA-256**: `fd59040e8bb736b0944e74ab855b72a3a8b843487ae64509926d4a9e79c68160`
**Serienprüfung / Series Review**: `Ready`, geprüft am / reviewed on 2026-08-29
**Feature-Verzeichnis / Feature Directory**: `specs/003-terminalgui-migration`

## Ziel und Nutzen / Goal and Value

TinyCalc soll seine vorhandene Terminal-Oberfläche mit einer unterstützten
Terminal.Gui-2.x-Version betreiben. Bedienabläufe, Tabellenlogik und der
nicht-interaktive Smoke-Modus bleiben fachlich unverändert. Die Migration
beseitigt veraltete Lifecycle- und Tastatur-APIs, ohne neue
Tabellenkalkulationsfunktionen einzuführen.

*TinyCalc shall run its existing terminal user interface on a supported
Terminal.Gui 2.x version. User journeys, spreadsheet logic, and the
non-interactive smoke mode remain functionally unchanged. The migration removes
deprecated lifecycle and keyboard APIs without adding spreadsheet features.*

## Geltungsbereich und Reihenfolge / Scope and Ordering

Der Produktänderungsbereich umfasst ausschließlich
`src/MicroCalc.Tui/MicroCalc.Tui.csproj` und
`src/MicroCalc.Tui/Program.cs`. Test-, Sicherheits-, Architektur-,
Barrierefreiheits-, Statistik- und PR-Dokumente dürfen nur als Nachweise der
Migration aktualisiert werden; sie erweitern den Produktumfang nicht.
Als einzige Automationsänderung im Delivery-Umfang ist exakt
`.github/workflows/ci.yml` autorisiert, damit `ubuntu-latest` und
`windows-latest` für denselben PR-Head Restore, Release-Build, vollständige
Release-Tests und Smoke mit Exitcode 0 sowie exakt `SMOKE_OK` ausführen.
`MicroCalc.Core` und die bestehenden Testprojekte bleiben inhaltlich
unverändert.

*The product-change scope contains only
`src/MicroCalc.Tui/MicroCalc.Tui.csproj` and
`src/MicroCalc.Tui/Program.cs`. Test, security, architecture, accessibility,
statistics, and pull-request documents may be updated only as migration
evidence; they do not expand product scope. As the sole automation change in
delivery scope, exactly `.github/workflows/ci.yml` is authorised so
`ubuntu-latest` and `windows-latest` run restore, Release build, complete
Release tests, and smoke with exit code zero and exact `SMOKE_OK` for the same
pull-request head. `MicroCalc.Core` and existing test projects remain unchanged
in content.*

Feature 003 folgt dem akzeptierten Feature 002 in der geordneten
`tinycalc-delivery`-Serie. Es wird als eigener Lieferumfang abgeschlossen,
bevor Feature 004, die Umbenennung von MicroCalc zu TinyCalc, begonnen wird.
Diese Spezifikation startet weder Feature 004 noch einen anderen Intake.

*Feature 003 follows accepted Feature 002 in the ordered `tinycalc-delivery`
series. It is completed as a separate delivery scope before Feature 004, the
MicroCalc-to-TinyCalc rename, begins. This specification starts neither
Feature 004 nor another intake.*

## Nutzer-Szenarien und Tests / User Scenarios and Testing *(mandatory)*

### User Story 1 – TUI zuverlässig starten und beenden / Start and stop the TUI reliably (Priority: P1)

Als Nutzer*in möchte ich TinyCalc wie bisher starten, das Hauptfenster sehen,
Menüs und Dialoge öffnen und die Anwendung kontrolliert beenden. So bleibt die
TUI nach dem Abhängigkeitswechsel sofort nutzbar.

*As a user, I want to start TinyCalc as before, see the main window, open menus
and dialogs, and stop the application in a controlled way. This keeps the TUI
usable immediately after the dependency change.*

**Prioritätsgrund / Why this priority**: Ohne einen funktionierenden Start- und
Beenden-Lebenszyklus ist die Anwendung nicht nutzbar. / *Without a working
start-and-stop lifecycle, the application is not usable.*

**Unabhängiger Test / Independent Test**: Die Release-Anwendung wird in einem
geeigneten Terminal gestartet. Das Hauptfenster, ein Menü und ein Dialog werden
geöffnet; anschließend wird über Menü und `Ctrl+Q` beendet. Jeder Ablauf endet
ohne unbehandelte Ausnahme. / *Start the Release application in a suitable
terminal, open the main window, a menu, and a dialog, then quit through both the
menu and `Ctrl+Q`. Each journey ends without an unhandled exception.*

**Akzeptanzszenarien / Acceptance Scenarios**:

1. **Given / Angenommen** eine wiederhergestellte und gebaute Release-Version,
   **When / Wenn** die TUI ohne `--smoke` gestartet wird, **Then / Dann** wird
   genau ein bedienbares Hauptfenster ohne Startausnahme angezeigt.
2. **Given / Angenommen** das Hauptfenster läuft, **When / Wenn** eine Person
   einen vorhandenen Dialog öffnet und schließt, **Then / Dann** kehrt der Fokus
   in einen nutzbaren Hauptfensterzustand zurück.
3. **Given / Angenommen** die TUI läuft, **When / Wenn** der Menüpunkt zum
   Beenden oder `Ctrl+Q` verwendet wird, **Then / Dann** endet die Anwendung
   kontrolliert und ohne sichtbaren internen Stack-Trace.

---

### User Story 2 – Tastaturbedienung beibehalten / Preserve keyboard operation (Priority: P1)

Als Tastaturnutzer*in möchte ich Zellen mit den vorhandenen Pfeil-, Steuerungs-
und Eingabetasten erreichen. Die technische Syntaxänderung darf die bekannte
Bedienung nicht verändern.

*As a keyboard user, I want to reach cells with the existing arrow, control,
and Enter keys. The technical syntax change must not alter familiar operation.*

**Prioritätsgrund / Why this priority**: TinyCalc ist eine Terminal-Anwendung;
die Tastatur ist der primäre Eingabekanal und eine wesentliche
Barrierefreiheitsanforderung. / *TinyCalc is a terminal application; the
keyboard is its primary input channel and an essential accessibility need.*

**Unabhängiger Test / Independent Test**: Alle 13 vorhandenen Navigations- und
Beenden-Eingaben werden einzeln ausgelöst: Pfeil hoch, runter, rechts, links,
`Ctrl+E`, `Ctrl+X`, `Ctrl+J`, `Ctrl+D`, `Ctrl+M`, `Enter`, `Ctrl+S`, `Ctrl+A`
und `Ctrl+Q`. / *Exercise all 13 existing navigation and quit inputs
individually: the four arrow keys, `Ctrl+E`, `Ctrl+X`, `Ctrl+J`, `Ctrl+D`,
`Ctrl+M`, `Enter`, `Ctrl+S`, `Ctrl+A`, and `Ctrl+Q`.*

**Akzeptanzszenarien / Acceptance Scenarios**:

1. **Given / Angenommen** eine ausgewählte Zelle, **When / Wenn** eine der
   vorhandenen Navigationsvarianten verwendet wird, **Then / Dann** bewegt sich
   die Auswahl genau in die bisher zugeordnete Richtung.
2. **Given / Angenommen** die TUI läuft, **When / Wenn** `Ctrl+Q` verwendet
   wird, **Then / Dann** wird das Beenden angefordert und die Eingabe nicht als
   Zellinhalt verarbeitet.
3. **Given / Angenommen** der migrierte Quellstand, **When / Wenn** nach alten
   `CtrlMask`- oder `AltMask`-Verknüpfungen gesucht wird, **Then / Dann** werden
   im Produktcode null Treffer gefunden.

---

### User Story 3 – Regressionen schnell erkennen / Detect regressions quickly (Priority: P2)

Als Entwickler*in oder Reviewer möchte ich den bestehenden Smoke-Modus und die
gesamte Testsuite unverändert erfolgreich ausführen. Dadurch ist erkennbar,
dass die Migration keine Tabellen- oder Hilfefunktion beschädigt.

*As a developer or reviewer, I want the existing smoke mode and complete test
suite to pass unchanged. This shows that the migration did not damage
spreadsheet or help behaviour.*

**Prioritätsgrund / Why this priority**: Der technische Wechsel ist nur
akzeptabel, wenn bestehendes Verhalten nachweisbar erhalten bleibt. / *The
technical change is acceptable only when existing behaviour is demonstrably
preserved.*

**Unabhängiger Test / Independent Test**: Nach einem Release-Build wird der
Smoke-Befehl ausgeführt und danach die vollständige Solution getestet. Der
Smoke-Befehl liefert Exitcode 0 und `SMOKE_OK`; alle Tests bestehen. / *After a
Release build, run the smoke command and then test the full solution. The smoke
command returns exit code 0 and `SMOKE_OK`; every test passes.*

**Akzeptanzszenarien / Acceptance Scenarios**:

1. **Given / Angenommen** ein erfolgreicher Release-Build, **When / Wenn**
   TinyCalc mit `--smoke` gestartet wird, **Then / Dann** enthält die Ausgabe
   exakt das Erfolgstoken `SMOKE_OK` und der Prozess endet mit Exitcode 0.
2. **Given / Angenommen** der gebaute Migrationsstand, **When / Wenn** alle
   Solution-Tests im Release-Modus laufen, **Then / Dann** bestehen alle
   Core- und TUI-Tests ohne neuen Fehler.

---

### User Story 4 – Lieferumfang nachvollziehbar prüfen / Review the delivery scope (Priority: P3)

Als Reviewer oder lernende Person möchte ich in deutsch-englischen
CEFR-B2-Nachweisen erkennen, was geändert, geprüft, ausgeschlossen und später
nachgeholt wird. So kann ich die Migration ohne Vorwissen zu Spec Kit oder
Terminal.Gui bewerten.

*As a reviewer or learner, I want German-English CEFR-B2 evidence that shows
what changed, what was checked, what is excluded, and what follows later. This
lets me assess the migration without prior knowledge of Spec Kit or
Terminal.Gui.*

**Prioritätsgrund / Why this priority**: Der Nachweis macht Sicherheits-,
Barrierefreiheits- und Lieferentscheidungen prüfbar, ohne die Migration mit dem
Folge-PR zu vermischen. / *The evidence makes security, accessibility, and
delivery decisions reviewable without mixing the migration with its follow-up
pull request.*

**Unabhängiger Test / Independent Test**: Eine Person prüft die Scope-Matrix,
Akzeptanzkriterien und Evidenzpfade ausschließlich als linearen Text. Alle
Status- und `N/A`-Entscheidungen besitzen Begründung und Wiedervorlage. / *A
person reviews the scope matrix, acceptance criteria, and evidence paths as
linear text. Every status and `N/A` decision has a rationale and a
re-evaluation trigger.*

**Akzeptanzszenarien / Acceptance Scenarios**:

1. **Given / Angenommen** die abgeschlossene Migration, **When / Wenn** ein
   Review die Evidenzliste liest, **Then / Dann** sind Paketwahl, Tests,
   Sicherheit, A11Y, Scope und Folgearbeit jeweils eindeutig belegt.
2. **Given / Angenommen** eine Screenreader-, Braille- oder Textbrowser-Nutzung,
   **When / Wenn** die Feature-Nachweise gelesen werden, **Then / Dann** bleiben
   Status, Entscheidungen und nächste Schritte ohne Farbe oder visuelle
   Position vollständig verständlich.

### Grenz- und Fehlerfälle / Edge Cases

- Wenn die gewählte 2.x-Version nicht wiederherstellbar, nicht gepflegt oder
  von einer bekannten Schwachstelle betroffen ist, bleibt die
  Lieferung blockiert; es erfolgt kein stiller Rückfall auf 1.19.0.
- Wenn die 2.x-API mehrere gültige Lifecycle-Muster anbietet, wird genau ein
  nicht veraltetes Muster genutzt. Das statische `Application.Top`-Muster darf
  nicht als Kompatibilitätsabkürzung erhalten bleiben.
- Wenn ein Dialog einen eigenen Laufzyklus besitzt, muss sein Schließen zum
  aufrufenden Fenster zurückkehren und darf nicht die gesamte Anwendung
  unbeabsichtigt beenden.
- Wenn ein Steuerungszeichen, eine Groß-/Kleinschreibungsvariante oder eine
  unbekannte Taste eintrifft, darf es nicht versehentlich als anderer
  Navigations- oder Beenden-Befehl behandelt werden.
- Wenn `--smoke` gesetzt ist, darf kein interaktiver Terminal-Lifecycle
  initialisiert werden; der Modus bleibt headless-fähig.
- Wenn das Terminal keine interaktive TUI darstellen kann, darf der
  nicht-interaktive Smoke-Nachweis trotzdem funktionieren. Eine neue
  Plain-Text-Ersatzoberfläche ist nicht Teil dieses Features.
- Wenn eine Migration einen internen Fehler auslöst, darf der Endnutzer keinen
  neuen Stack-Trace, keine Paketpfade und keine internen Zustandsdetails sehen.
  Bestehende, nicht durch die Migration verursachte Fehlertexte werden in
  diesem Feature nicht fachlich umgestaltet.
- Wenn die geforderte Changed-Code-Coverage ohne Erweiterung des
  Produktumfangs nicht belegt werden kann, bleibt das Gate blockiert. Der Scope
  darf nicht stillschweigend um FakeDriver-Tests erweitert werden.

*The same boundaries apply in English: an unavailable, unmaintained, or
known-vulnerable package blocks delivery; deprecated lifecycle fallbacks
are not accepted; nested dialogs return safely; unknown keys do not gain a new
meaning; smoke mode stays non-interactive; migration errors reveal no new
internal details; and missing coverage evidence blocks the gate without
silently adding FakeDriver scope.*

## Anforderungen / Requirements *(mandatory)*

### Intake-Klassifikation / Intake Classification

| Intake-ID | Status | Festlegung und Nachweis / Decision and evidence |
|---|---|---|
| R-TG-TC-01 | `Applicable` | `MicroCalc.Tui.csproj` verwendet noch 1.19.0. Die direkte Abhängigkeit wird auf eine gepflegte Version >= 2.0.0 innerhalb der 2.x-Linie angehoben. |
| R-TG-TC-02 | `Applicable` | `Program.cs` verwendet noch `Application.Top` und einen parameterlosen Hauptlauf. Beides wird durch ein nicht veraltetes instanzbasiertes 2.x-Lifecycle-Muster ersetzt. |
| R-TG-TC-03 | `Applicable` | Im aktuellen Produktcode bestehen acht alte `Key.CtrlMask`-Ausdrücke. Alle alten `CtrlMask`-/`AltMask`-Verknüpfungen werden durch die 2.x-Syntax ersetzt. |
| R-TG-TC-04 | `Applicable` | Der vorhandene `--smoke`-Modus bleibt unverändert nutzbar und liefert `SMOKE_OK`. |
| R-TG-TC-05 | `Applicable` | Alle vorhandenen Tests bleiben grün; die Testprojekte werden durch dieses Feature nicht fachlich geändert. |
| R-TG-TC-06 | `FollowUp` | Mindestens drei FakeDriver-Integrationstests bleiben ein ausdrücklich separater Folge-PR. Owner: Repository-Maintainer. Wiedervorlage: nach Abschluss von Feature 003 und vor einer weitergehenden TUI-Funktionsänderung. |

*R-TG-TC-01 through R-TG-TC-05 are applicable because the repository still
contains version 1.19.0, the deprecated main lifecycle, eight legacy control-key
expressions, and the existing smoke and regression gates. R-TG-TC-06 remains a
separate follow-up exactly as required by the binding intake.*

### Funktionale Anforderungen / Functional Requirements

- **FR-001**: Die direkte Terminal.Gui-Abhängigkeit MUSS eine gepflegte stabile
  2.x-Version ab 2.0.0 verwenden. Die gewählte exakte Version MUSS im
  Abhängigkeitsnachweis festgehalten werden und darf zum Prüfzeitpunkt keine
  bekannte Schwachstelle besitzen. / *The direct Terminal.Gui dependency MUST
  use a maintained stable 2.x version at or above 2.0.0. Evidence MUST record
  the exact selected version, which must have no known vulnerability at review
  time.*
- **FR-002**: Der Hauptlauf MUSS ohne `Application.Top` und ohne den veralteten
  parameterlosen Hauptaufruf arbeiten. Initialisierung, genau ein Hauptlauf und
  kontrolliertes Herunterfahren bleiben erhalten. / *The main lifecycle MUST
  avoid `Application.Top` and the deprecated parameterless main run. It retains
  initialization, exactly one main run, and controlled shutdown.*
- **FR-003**: Alle vorhandenen Steuerungs- und Alt-Tastenkombinationen im
  Produktcode MÜSSEN die 2.x-Tastensyntax verwenden. Nach der Migration DÜRFEN
  keine `Key.CtrlMask`- oder `Key.AltMask`-Ausdrücke verbleiben. / *All existing
  control and Alt key combinations in product code MUST use the 2.x key syntax.
  No `Key.CtrlMask` or `Key.AltMask` expression may remain.*
- **FR-004**: Die 13 bestehenden Navigations- und Beenden-Eingaben MÜSSEN ihre
  bisherige Bedeutung behalten. Menüaktionen, Dialogläufe und vorhandene
  Stop-Anforderungen MÜSSEN weiterhin funktionieren. / *All 13 existing
  navigation and quit inputs MUST retain their meaning. Menu actions, dialog
  runs, and existing stop requests MUST continue to work.*
- **FR-005**: Der Aufruf mit `--smoke` MUSS ohne interaktive
  Terminal-Initialisierung ausführbar bleiben, Exitcode 0 liefern und
  `SMOKE_OK` ausgeben. / *The `--smoke` invocation MUST remain executable
  without interactive terminal initialization, return exit code 0, and emit
  `SMOKE_OK`.*
- **FR-006**: Alle vorhandenen Tests in `MicroCalc.Core.Tests` und
  `MicroCalc.Tui.Tests` MÜSSEN im Release-Modus ohne neue Fehler bestehen. / *All
  existing tests in `MicroCalc.Core.Tests` and `MicroCalc.Tui.Tests` MUST pass
  in Release mode without new failures.*
- **FR-007**: Ein manueller TUI-Nachweis MUSS Start, Menüöffnung,
  Zellnavigation, Dialogrückkehr, Menü-Beenden und `Ctrl+Q` abdecken. / *A
  manual TUI proof MUST cover startup, menu opening, cell navigation, dialog
  return, menu quit, and `Ctrl+Q`.*
- **FR-008**: `MicroCalc.Core`, Formelverhalten, Speicherformat und vorhandene
  Testquellen DÜRFEN fachlich nicht geändert werden. / *`MicroCalc.Core`,
  formula behaviour, file format, and existing test sources MUST not be changed
  functionally.*
- **FR-009**: Das Feature DARF weder die MicroCalc-zu-TinyCalc-Umbenennung noch
  neue Funktionen, FakeDriver-Tests oder einen weiteren Intake aufnehmen. / *The
  feature MUST NOT include the MicroCalc-to-TinyCalc rename, new features,
  FakeDriver tests, or another intake.*
- **FR-010**: Restore, Build, Tests und Smoke-Nachweis MÜSSEN die
  Repository-Befehle und die versionsgebundene Build-Regel einhalten. / *Restore,
  build, tests, and smoke evidence MUST follow repository commands and the
  version-bound build rule.*
- **FR-011**: Die Migration MUSS die bestehende Tastaturbedienbarkeit,
  Fokusreihenfolge, sichtbare Fokuswahrnehmung und textuelle Statusdarstellung
  ohne neue farb- oder mausabhängige Information erhalten. / *The migration
  MUST preserve existing keyboard operation, focus order, visible focus, and
  textual status without introducing colour-only or pointer-only information.*
- **FR-012**: Sicherheits- und Abhängigkeitsprüfungen MÜSSEN die neue direkte
  und transitive Paketmenge bewerten. In ausgelieferten direkten oder
  transitiven Abhängigkeiten DARF keine bekannte Schwachstelle verbleiben.
  Jeder solche Fund blockiert bis zu einer ausdrücklich autorisierten und
  abgeschlossenen Aktualisierung oder Ersetzung. VEX DARF nur Fehlalarme sowie
  bewertete, nicht ausgelieferte Komponenten klassifizieren und niemals eine
  bekannte Schwachstelle im ausgelieferten Graph autorisieren. Für jede direkte
  und transitive ausgelieferte Abhängigkeit MÜSSEN Lizenz, Quelle,
  Kompatibilität und Disposition belegt sein; unbekannte oder inkompatible
  Lizenzen blockieren. / *Security and dependency checks MUST assess the new
  direct and transitive package set. No known vulnerability may remain in a
  shipped direct or transitive dependency. Such a finding blocks until an
  explicitly authorised update or replacement is complete. VEX may classify
  false positives and evaluated non-shipped components, but can never
  authorise a known vulnerability in the shipped graph. Every shipped direct
  and transitive dependency requires evidence of licence, source,
  compatibility, and disposition; unknown or incompatible licences block.*
- **FR-013**: Produktcodeänderungen MÜSSEN beobachtbare Rot-, Grün- und
  Regression-/Aufräum-Nachweise sowie mindestens 70 Prozent Changed-Code-
  Coverage mit einem Ziel von 80 Prozent besitzen. / *Product-code changes MUST
  have observable red, green, and regression/refactor evidence plus at least
  70% changed-code coverage with an 80% target.*
- **FR-014**: Neue oder veränderte nutzer- und lernseitige Texte MÜSSEN Deutsch
  zuerst und Englisch danach auf CEFR B2 liefern. Fachbegriffe werden beim
  ersten Auftreten erklärt. / *New or changed user- and learner-facing text
  MUST be German first and English second at CEFR B2, defining domain terms on
  first use.*

### Verfassungsanforderungen / Constitution Requirements *(mandatory)*

- **CR-001 – Level-2-Kontext**: Der TinyCalc-Registereintrag ist bindend:
  .NET 10/C#, Release-Restore-Build-Test, xUnit und nicht-interaktiver
  TUI-Smoke-Nachweis. / *The TinyCalc Level-2 registry row is binding.*
- **CR-002 – Barrierefreiheit**: WCAG 2.2 AA gilt für die betroffene TUI und
  ihre Nachweise, insbesondere 1.4.1 Use of Color, 2.1.1 Keyboard, 2.1.2 No
  Keyboard Trap, 2.4.3 Focus Order und 2.4.7 Focus Visible. / *WCAG 2.2 AA
  applies to the affected TUI and evidence, especially the listed criteria.*
- **CR-003 – Lernzielgruppe**: Auszubildende ab dem ersten Ausbildungsjahr,
  Entwickler*innen, Reviewer und KI-Agenten gehören zur Zielgruppe. Spec-Kit-
  Vorwissen wird nicht vorausgesetzt. / *The audience includes first-year
  apprentices, developers, reviewers, and AI agents; no Spec Kit knowledge is
  assumed.*
- **CR-004 – Statistik und Agentenflächen**: `docs/project-statistics.md` ist
  nach der Implementierungsphase zu aktualisieren. Gemeinsame Agentenregeln
  ändern sich nicht; Agent-Parität ist deshalb für diese Migration `N/A`.
  Wiedervorlage: sobald eine gemeinsame Regel oder ein Template geändert wird.
  / *Project statistics require an implementation-phase update. Shared agent
  rules do not change, so agent parity is `N/A`; re-evaluate on any shared rule
  or template change.*
- **CR-005 – Speichersicherheit**: Primärsprache ist C# auf .NET 10. C# steht
  auf der MSL-Erlaubnisliste; Laufzeit und Hardware erzwingen keine nicht
  speichersichere Sprache. C#/.NET-Secure-Coding-Regeln bleiben trotzdem
  verpflichtend. / *The primary language is C# on .NET 10, an allowed
  memory-safe language. Secure coding remains mandatory.*
- **CR-006 – Standards**: NIST SSDF und CWE Top 25 sind `Applicable`.
  C#/.NET-Secure-Coding, STRIDE/CAPEC, WCAG 2.2 AA, SBOM und SLSA sind für
  diesen Abhängigkeits- und TUI-Lauf ebenfalls `Applicable`. / *The named
  standards are applicable to this dependency and TUI migration.*
- **CR-007 – ASVS**: OWASP ASVS ist `N/A`, weil TinyCalc in diesem Feature
  keinen Web-, API-, HTTP-, Authentifizierungs- oder Mehrbenutzerdienst
  einführt. Wiedervorlage: bei einem solchen Dienst. / *OWASP ASVS is `N/A`;
  re-evaluate when web, API, HTTP, authentication, or multi-user service scope
  appears.*
- **CR-008 – Lieferkette**: SBOM und SLSA sind `Applicable`, weil TinyCalc ein
  releasefähiges Artefakt mit CI-Build und geänderter Abhängigkeit ist. VEX ist
  `N/A`, solange der Abschluss-Scan keinen zu bewertenden Fund meldet. VEX darf
  Fehlalarme und nicht ausgelieferte Komponenten klassifizieren, aber keinen
  bekannten Fund im ausgelieferten Graph freigeben. Direkte und transitive
  Paketlizenzen werden mit Quelle, Kompatibilität und Disposition belegt; null
  unbekannte oder inkompatible ausgelieferte Lizenzen sind Pflicht. / *SBOM and
  SLSA apply. VEX is `N/A` only while final scanning reports no finding that
  needs evaluation; it may classify false positives and non-shipped
  components, but cannot release a known finding in the shipped graph. Direct
  and transitive package licences require source, compatibility, and
  disposition evidence, with zero unknown or incompatible shipped licences.*
- **CR-009 – KI-Klassifikation**: KI wird nur als Entwicklungswerkzeug genutzt
  und ist keine ausgelieferte oder betriebene Runtime-Komponente. AI-SBOM ist
  `N/A`; Wiedervorlage bei Modell, Datensatz, Inferenzdienst oder KI-Runtime im
  Produkt. / *AI is development tooling only, so AI-SBOM is `N/A`; re-evaluate
  if AI becomes a product/runtime component.*
- **CR-010 – Bedrohungen**: Die lokale Tastatureingabe und die Paketlieferkette
  werden mit STRIDE und den CAPEC-Mustern CAPEC-153 „Input Data Manipulation“
  und CAPEC-538 „Open-Source Library Manipulation“ geprüft. Es entsteht keine
  neue Trust Boundary. / *Review the existing keyboard-input and package-supply
  boundaries with STRIDE, CAPEC-153, and CAPEC-538. No new trust boundary is
  created.*
- **CR-011 – Evidenzorte**: Standardorte unter `docs/security/` werden genutzt:
  `threat-model.md`, `security-checklist.md`, `dependency-audit.md` und
  `supply-chain-evidence.md`. Zusätzlich werden `arc42-security.md` vollständig
  aktualisiert, ein fokussierter S-ADR unter
  `docs/security/adr/003-terminalgui-lifecycle-supply-chain.md` erstellt und
  `docs/security/README.md` von `Stub` auf den abgeschlossenen Stand gesetzt,
  einschließlich Index des S-ADR. A11Y-Evidenz wird unter
  `docs/accessibility/terminalgui-migration.md` und Architektur-Evidenz unter
  `docs/architecture/terminalgui-migration.md` geführt. / *Use the stated
  default security, accessibility, and architecture evidence paths, fully
  update arc42 Section 8, create the focused security ADR, and complete the
  security README including its ADR index.*
- **CR-012 – Presets**: Es gilt die exakte Acht-Preset-Matrix:
  `security-governance` v0.6.2, `architecture-governance` v0.5.2,
  `isaqb-architecture-governance` v0.2.2, `a11y-governance` v0.4.3,
  `cross-platform-governance` v0.2.2, `agent-parity-governance` v0.4.2,
  `autonomous-run-governance` v0.4.1 und
  `parallel-autonomous-run-governance` v0.2.6. / *The exact standard
  eight-preset matrix applies.*
- **CR-013 – Documentation Impact**: Die verbindliche Entscheidung lautet
  `UpdateRequired`; Einzelheiten stehen in der folgenden
  Dokumentationsmatrix. / *The single binding Documentation Impact decision is
  `UpdateRequired`; details are in the documentation matrix below.*
- **CR-014 – Sprache und Textzugang**: Jeder neue Lern- oder Nutzertext ist
  DE-first/EN-second auf CEFR B2. Status, Abhängigkeiten, Entscheidungen und
  nächste Aktionen bleiben linear und ohne Farbe vollständig. / *All new
  learner/user text is DE-first/EN-second at CEFR B2 and complete as linear,
  colour-independent text.*
- **CR-015 – API und Kommentare**: Falls durch die Migration eine öffentliche
  API berührt wird, erhält sie vollständige XML-Dokumentation; CS1591 bleibt
  aktiv. Nicht triviale neue Kompatibilitätslogik erhält moderate zweisprachige
  Warum-Kommentare. Reine API-Syntaxänderungen erhalten keinen Kommentar, der
  nur den Code wiederholt. / *Affected public APIs receive complete XML docs;
  CS1591 remains active; non-trivial compatibility logic gets moderate
  bilingual why-comments.*
- **CR-016 – TDD und Coverage**: Rot -> Grün -> Aufräumen ist sichtbar zu
  belegen. Changed-Code-Coverage hat mindestens 70 Prozent und als Ziel 80
  Prozent. Fehlende Evidenz blockiert die Lieferung. / *Red -> green ->
  refactor is observable; changed-code coverage has a 70% minimum and 80%
  target; missing evidence blocks delivery.*

### Dokumentationswirkung / Documentation Impact

**Entscheidung / Decision**: `UpdateRequired`

| Pflichtfeld / Required field | Festlegung / Decision |
|---|---|
| Zielgruppen / Audiences | Nutzer*innen, Auszubildende ab Jahr 1, Entwickler*innen, Reviewer, KI-Agenten / users, first-year apprentices, developers, reviewers, AI agents |
| Dokumentfamilien / Families | Feature-Spec, Sicherheits-, Architektur-, A11Y-, Statistik- und PR-Nachweise; keine neue Produktanleitung / feature spec plus security, architecture, accessibility, statistics, and PR evidence; no new product guide |
| Leserpfade / Reader paths | `specs/003-terminalgui-migration/`, `docs/security/`, `docs/accessibility/`, `docs/architecture/`, `docs/project-statistics.md`, fokussierter PR-Text / focused PR text |
| Kanonische Quelle und Owner / Canonical source and owner | Dieses `spec.md` für Scope; binding intake für Anforderungen; Repository-Maintainer als Owner / this `spec.md` for scope, binding intake for requirements, repository maintainer as owner |
| Navigation | Keine DocFX-Navigation betroffen; neue Evidenz wird über bestehende Verzeichnisstruktur und PR verlinkt / no DocFX navigation impact; evidence is linked through existing folders and PR |
| Dokumentklasse / Class | Feature- und Audit-Evidenz, keine normative Verfassungsänderung / feature and audit evidence, not a normative constitution change |
| Sprachstrategie und Partner / Language strategy and partner | Inline DE-first/EN-second, CEFR B2; kein `.EN.md`-Sidecar nötig / inline German-first/English-second, CEFR B2; no sidecar needed |
| Plattform-/Beispielnachweis / Platform and example proof | Release-Build/Test unter vorhandener CI sowie manueller TUI-/Smoke-Nachweis auf dem Implementierungsbetriebssystem; Plattformabweichungen werden benannt / existing CI Release proof plus manual TUI/smoke proof on the implementation OS; record platform differences |
| Distribution | Repository- und PR-Evidenz; SBOM als Release-/Supply-Chain-Nachweis / repository and PR evidence; SBOM as release/supply-chain evidence |
| Home-Sync | `N/A`: keine gemeinsame Home-Baseline ändert sich. Wiedervorlage bei Governance- oder Template-Änderung / no shared Home baseline change; re-evaluate on governance/template changes |
| Evidenz / Evidence | Die in CR-011 genannten Dateien, Test-/Smoke-Ausgabe, Paket- und Coverage-Bericht |
| Wiedervorlage / Re-evaluation trigger | Abweichende API-Semantik, geänderte Nutzertexte, DocFX-Änderung, neue Plattformanforderung oder zusätzlicher Scope |

`CALC.HLP` bleibt unverändert, weil die Migration keine Befehle oder
Nutzerfunktionen ändert. DocFX-Regeneration und der zugehörige A11Y-Smoke-Test
sind `N/A`, solange weder öffentliche API-Dokumentation noch DocFX-Inhalt
geändert wird; bei einer solchen Änderung werden beide gemeinsam `Applicable`.

*`CALC.HLP` remains unchanged because commands and user features do not change.
DocFX regeneration and its A11Y smoke test are `N/A` while no public API docs or
DocFX content changes; either trigger makes both applicable together.*

## Nicht-Ziele und Liefergrenzen / Non-Goals and Delivery Boundaries

- Keine Migration oder fachliche Änderung von `MicroCalc.Core`.
- Keine Änderung der Formel-Engine, Tabellenlogik oder Dateiformate.
- Keine Änderung vorhandener Testquellen und keine FakeDriver-Tests in diesem
  Feature.
- Keine Umbenennung von MicroCalc zu TinyCalc.
- Keine neue TUI-Funktion, kein neues Layout und kein A11Y-Redesign.
- Keine neue Web-, API-, Cloud-, Authentifizierungs- oder Remotefunktion.
- Kein neues Skript, keine Änderung von Bash-/PowerShell-Automation.
- Keine Änderung gemeinsamer Agentenregeln, Spec-Kit-Templates oder der
  Constitution.
- Diese Specify-Phase implementiert, committet, pusht, eröffnet oder merged
  keinen PR, aktualisiert keine Intake-Serie und startet kein Folgefeature.

*The feature excludes Core migration, formula or file-format changes, test
source changes, FakeDriver tests, product renaming, new TUI features, web/cloud
or remote services, scripts, shared agent or constitution changes, and every
other intake. This Specify phase performs no implementation, commit, push,
pull-request, merge, intake-series update, or follow-up start.*

## Architektur und Vertrauensgrenzen / Architecture and Trust Boundaries

Die Migration betrifft die Laufzeitkopplung der TUI, die Tastatur-Schnittstelle,
Dialog-Lebenszyklen und die externe Paketabhängigkeit. Systemkontext,
Tabellen-Engine, Dateizugriffe, Deployment-Topologie und Berechtigungsmodell
bleiben unverändert. Die Qualitätsziele sind Kompatibilität, Bedienbarkeit,
Zuverlässigkeit, Wartbarkeit und prüfbare Lieferkettenintegrität.

*The migration affects TUI runtime coupling, keyboard interfaces, dialog
lifecycles, and the external package dependency. System context, spreadsheet
engine, file access, deployment topology, and permissions remain unchanged.
Quality goals are compatibility, usability, reliability, maintainability, and
reviewable supply-chain integrity.*

| Grenze oder Fluss / Boundary or flow | Klassifikation | Entscheidung |
|---|---|---|
| Lokale Tastatur -> Terminal.Gui -> `Program` | intern eingegebene Nutzerdaten / user-entered internal data | Bestehende Grenze; STRIDE und CAPEC-153 prüfen unerwartete Tastenwerte und Fehlinterpretation. |
| NuGet-Registry -> Restore -> TinyCalc-Artefakt | öffentliche Paketmetadaten und ausführbarer Drittcode / public metadata and executable third-party code | Bestehende Lieferkettengrenze; CAPEC-538, Registry-Herkunft, Version, CVE, SBOM und Provenance prüfen. |
| TUI -> `MicroCalc.Core` | interne Anwendungsdaten / internal application data | Unverändert; keine neue Validierungs- oder Berechtigungsgrenze. |
| TUI -> lokale Tabellen-/Hilfedateien | lokale interne Daten / local internal data | Unverändert; vorhandene Datei- und Fehlerpfade werden nicht erweitert. |

STRIDE ist `Applicable`, weil Eingabe- und Abhängigkeitsgrenzen überprüft
werden. Die erwarteten Schwerpunkte sind Tampering und Denial of Service an der
Paketgrenze sowie Tampering/Fehlinterpretation und Denial of Service an der
Eingabegrenze. Spoofing, Information Disclosure und Elevation of Privilege
werden geprüft, aber es wird keine neue Authentitäts-, Geheimnis- oder
Privileggrenze eingeführt. Das Bedrohungsmodell dokumentiert Ergebnis und
Restrisiko.

*STRIDE applies because input and dependency boundaries are reviewed. Focus on
tampering and denial of service at the package boundary, and input
misinterpretation/tampering and denial of service at the keyboard boundary.
Review the remaining STRIDE categories while noting that no identity, secret,
or privilege boundary is added.*

Ein allgemeiner nicht sicherheitsbezogener ADR bleibt `N/A`, weil keine neue
Komponente oder Schicht gewählt wird. Ein fokussierter S-ADR und die vollständige
Aktualisierung von `docs/security/arc42-security.md` sind dagegen verpflichtende
Implementierungsevidenz. Der S-ADR hält Lifecycle-Ownership und die
fail-closed Lieferkettenentscheidung fest. arc42 Section 8 deckt für dieses
Feature Lifecycle, Trust Boundaries, Eingaben, Abhängigkeiten, Fehler,
Logging und Deployment ausdrücklich ab, auch wenn einzelne Teilkonzepte
unverändert bleiben.

*A general non-security ADR remains `N/A` because no new component or layer is
selected. A focused security ADR and a complete update of
`docs/security/arc42-security.md` are mandatory implementation evidence. The
S-ADR records lifecycle ownership and the fail-closed supply-chain decision.
arc42 Section 8 explicitly covers this feature's lifecycle, trust boundaries,
input, dependencies, errors, logging, and deployment, even where an individual
concept remains unchanged.*

Zero Trust nach NIST SP 800-207, BSI C3A Cloud Autonomy und BSI C5 Cloud
Assurance sind jeweils `N/A`: Das Feature ist eine lokale TUI-Migration ohne
Cloud-, Service-, Remote-Management- oder Provider-Abhängigkeit. Wiedervorlage:
Einführung eines verteilten, cloudbasierten oder remote verwalteten Betriebs.

*NIST SP 800-207 Zero Trust, BSI C3A Cloud Autonomy, and BSI C5 Cloud Assurance
are `N/A` because this is a local TUI migration without cloud, service, remote
management, or provider dependency. Re-evaluate for distributed, cloud, or
remotely managed operation.*

## Sicherheits- und Lieferketten-Governance / Security and Supply-Chain Governance

| Standard oder Checkpoint | Anwendbarkeit | Implementierungsstand bei Specify | Evidenz, Owner, Review, Restrisiko und Wiedervorlage |
|---|---|---|---|
| NIST SSDF SP 800-218 | `Applicable` | `Partly Fulfilled` | `spec.md`, später `docs/security/security-checklist.md`; Owner: Implementer, Review: Security-Reviewer. Rest: Implementierungsbeleg fehlt. Trigger: jede Produktänderung. |
| CWE Top 25 | `Applicable` | `Partly Fulfilled` | C#-, Eingabe-, Fehler- und Abhängigkeitsreview in `docs/security/security-checklist.md`; Rest: neuer Code noch nicht geprüft. Trigger: Implementierung oder Paketänderung. |
| C#/.NET Secure Coding | `Applicable` | `Partly Fulfilled` | MSL bestätigt; Fehlerpfade, Ressourcen-Lifecycle und Abhängigkeit werden geprüft. Owner: Implementer; Review: C#-Reviewer. Trigger: Codeänderung. |
| STRIDE + CAPEC-153/-538 | `Applicable` | `Partly Fulfilled` | Scope in dieser Spec; Abschluss in `docs/security/threat-model.md`. Owner: Implementer; Review: Security-Reviewer. Trigger: geänderter Datenfluss oder Paketbefund. |
| OWASP ASVS | `N/A` | `Not Assessed` | Kein Web/API/HTTP/Auth. Owner: Maintainer. Trigger: entsprechender Dienst. |
| SBOM | `Applicable` | `Not Fulfilled` | `docs/security/supply-chain-evidence.md` und maschinenlesbare Release-Komponentenliste. Owner: Release-Owner; Review: Security-Reviewer. Trigger: Abschluss-Restore/Release. |
| VEX | `N/A` | `Not Assessed` | Disposition in `docs/security/supply-chain-evidence.md`. VEX klassifiziert nur Fehlalarme oder nicht ausgelieferte Komponenten und gibt keinen bekannten Fund im ausgelieferten Graph frei. Owner: Security-Reviewer. Trigger: jeder zu bewertende Fund. |
| AI-SBOM | `N/A` | `Not Assessed` | KI nur Entwicklungswerkzeug. Owner: Maintainer. Trigger: KI-Runtime, Modell, Datensatz oder Inferenzdienst im Produkt. |
| SLSA | `Applicable` | `Partly Fulfilled` | Vorhandene CI ist Basis; Provenance-Status in `docs/security/supply-chain-evidence.md`. Owner: Release-Owner; Review: Security-Reviewer. Rest: migrationsgebundener Nachweis fehlt. |
| OpenSSF Scorecard | `Applicable` | `Not Fulfilled` | Terminal.Gui ist eine zentrale externe OSS-Abhängigkeit; Upstream-Posture wird im Dependency Audit festgehalten. Trigger: Versionswahl und Release. |
| OWASP SAMM | `Applicable` | `Partly Fulfilled` | Bestehendes `docs/security/samm-assessment.md`; Migration übernimmt nur neue Befunde. Owner: Maintainer. Trigger: Sicherheits- oder Prozesslücke. |
| OWASP Cheat Sheets / Proactive Controls | `Applicable` | `Partly Fulfilled` | Ergänzende Review-Linse, soweit C#/.NET-Regeln nicht strenger sind. Trigger: Eingabe-, Fehler- oder Abhängigkeitscode. |
| NIS2, CRA, EU AI Act, DORA | `N/A` | `Not Assessed` | Kein neuer Markt-, Kunden-, KI-, Finanzsektor- oder Betreiberumfang. Owner: Maintainer. Trigger: Release-/Marktplatzierung, Kundenübergabe, regulierter Betrieb oder KI-Produktanteil. |
| Zero Trust | `N/A` | `Not Assessed` | Lokale Einzelprozess-TUI. Trigger: verteilte, Remote- oder Cloud-Architektur. |
| BSI C3A / BSI C5 | `N/A` | `Not Assessed` | Keine Cloud- oder Provider-Auswahl. Trigger: Cloud-, Hosting- oder Managed-Service-Abhängigkeit. |
| Fokussierter S-ADR | `Applicable` | `Not Fulfilled` | `docs/security/adr/003-terminalgui-lifecycle-supply-chain.md` dokumentiert Lifecycle-Ownership und fail-closed Lieferkettenentscheidung. |
| arc42 Section 8 | `Applicable` | `Not Fulfilled` | `docs/security/arc42-security.md` wird für Lifecycle, Trust Boundaries, Eingaben, Abhängigkeiten, Fehler, Logging und Deployment vollständig aktualisiert. |
| Security-Index | `Applicable` | `Not Fulfilled` | `docs/security/README.md` wechselt von `Stub` auf abgeschlossen und indexiert alle Pflichtartefakte sowie den S-ADR. |

Kein Checkpoint ist `Open`. Falls während Planung oder Implementierung ein
bekannter Schwachstellenfund, eine unbekannte oder inkompatible ausgelieferte
Lizenz, eine nicht gepflegte Paketversion, eine neue Trust Boundary oder eine
neue Regulierungsannahme erscheint, wird der betroffene Status vor Fortsetzung
neu bewertet; ein `N/A` darf dann nicht bestehen bleiben.

*No checkpoint is Open. A known vulnerability, unknown or incompatible shipped
licence, unmaintained package, new trust boundary, or new regulatory assumption
forces re-evaluation before work continues; the corresponding `N/A` cannot
remain.*

## Barrierefreiheit und Lernpolicy / Accessibility and Learner Policy

Betroffene nutzerseitige Artefakte sind die TUI, ihre Tastaturereignisse,
Fokuszustände, Meldungen und die Migrationsnachweise. Mausbedienung,
Zeigerzielgröße, Dragging, Bilder und Animation sind `N/A`, weil dieses Feature
keine solche Interaktion einführt. Wiedervorlage: sobald Maus- oder grafische
Interaktion hinzukommt.

*Affected user-facing artefacts are the TUI, keyboard events, focus states,
messages, and migration evidence. Pointer target size, dragging, images, and
animation are `N/A` because the feature adds no such interaction; re-evaluate
when mouse or graphical interaction appears.*

Alle Nachweise verwenden semantische Überschriften, Listen und Tabellen. Jede
Tabelle muss auch zeilenweise verständlich bleiben. Wesentliche Aussagen
stehen nicht ausschließlich in Farbe, Layout, Symbolen oder einem Diagramm.
Codeblöcke besitzen Sprachkennzeichnung; Fachbegriffe wie Lifecycle
(Start-, Lauf- und Beenden-Ablauf) werden beim ersten Auftreten erklärt.

*Evidence uses semantic headings, lists, and tables that remain understandable
row by row. No essential meaning depends only on colour, layout, symbols, or a
diagram. Code blocks use language tags, and domain terms are explained on
first use.*

Neue didaktische Inline-Kommentare sind nur `Applicable`, wenn die Migration
nicht triviale Kompatibilitätslogik benötigt. Bei rein mechanischer API-Syntax
sind sie `N/A`, weil ein Kommentar den Code nur wiederholen würde. Owner:
Implementer; Review: C#-Reviewer; Wiedervorlage: erste nicht offensichtliche
Lifecycle-, Fokus- oder Eingabeentscheidung.

*New didactic inline comments apply only if non-trivial compatibility logic is
needed. They are `N/A` for mechanical API syntax because a comment would merely
repeat the code. Re-evaluate at the first non-obvious lifecycle, focus, or
input decision.*

## Plattform-, Skript- und Agent-Parität / Platform, Script, and Agent Parity

TinyCalc bleibt eine .NET-Terminalanwendung für macOS, Linux und Windows. Der
vorhandene CI-Nachweis auf Ubuntu und ein manueller Nachweis auf dem
Implementierungsbetriebssystem werden festgehalten. Ein neues Versprechen für
eine zusätzliche Plattform oder Terminalart entsteht nicht.

*TinyCalc remains a .NET terminal application for macOS, Linux, and Windows.
Record existing Ubuntu CI evidence and manual proof on the implementation OS.
The feature makes no new promise for another platform or terminal type.*

Script-Parität ist `N/A`: Es wird kein skriptförmiges Werkzeug hinzugefügt,
geändert oder entfernt. Daher sind Bash-/PowerShell-Paar, Manpage,
`Verb-Noun`-Cmdlet, `--dry-run` und `-WhatIf` nicht anwendbar. Wiedervorlage:
jede neue oder geänderte Automationsdatei.

*Script parity is `N/A`: no script-shaped tool is added, changed, or removed.
Therefore Bash/PowerShell pairing, man page, `Verb-Noun` cmdlet, `--dry-run`,
and `-WhatIf` do not apply. Re-evaluate for any automation-file change.*

Agent-Parität ist `N/A`: `AGENTS.md`, `CLAUDE.md`, `GEMINI.md`,
`.github/copilot-instructions.md`, `.github/agents/copilot-instructions.md`,
`.specify/memory/constitution.md` und `.specify/templates/` werden nicht
geändert. Es gibt keine beabsichtigte Abweichung. Wiedervorlage: sobald eine
gemeinsame Regel, ein Template oder Modell-Routing-Hinweis geändert werden
muss.

*Agent parity is `N/A`: the maintained agent surfaces, constitution memory, and
templates do not change, and there is no intentional divergence. Re-evaluate
when a shared rule, template, or model-routing instruction changes.*

Parallel-autonome Ausführung ist `N/A`: Dieses Feature ist ein einzelner
geordneter Lauf ohne Kampagne, Worker oder Konsolidierung. Wiedervorlage:
ausdrückliche Autorisierung einer parallelen Kampagne.

*Parallel autonomous execution is `N/A`: this is one ordered run without a
campaign, worker, or consolidation. Re-evaluate only after explicit campaign
authority.*

## Autonomer Lauf und Gates / Autonomous Run and Gates

Der akzeptierte Zustand liegt in
`specs/003-terminalgui-migration/autonomous-run-state.json`; Run-ID ist
`38ad4c1d-bf85-4053-b585-eb490176b727`. Der Zustand nennt
`MergeAndSync` als beabsichtigten Liefermodus. Diese Angabe ist kein
zusätzliches Recht: Die aktuelle Specify-Phase hat ausdrücklich keine Commit-,
Push-, PR-, Merge-, Bypass-, Secret-, Provider- oder Folgefeature-Berechtigung.
Spätere Aktionen dürfen nur an ihrer sicheren Phasengrenze und innerhalb der
dann noch gültigen Autorität erfolgen.

*Accepted state is stored at the stated feature-local path with run ID
`38ad4c1d-bf85-4053-b585-eb490176b727`. It records `MergeAndSync` as intended
delivery mode, but grants no extra authority. This Specify phase has no commit,
push, PR, merge, bypass, secret, provider, or follow-up authority. Later actions
remain bounded by their safe phase boundary and current authority.*

Akzeptierte Eingaben sind das bindende Lastenheft mit dem oben genannten Hash
sowie die im Run-State gebundenen Serienreview-Artefakte. Scope, Nicht-Ziele,
Reihenfolge und Hash dürfen durch Autonomie nicht erweitert oder ersetzt
werden. Provider-Zugangsdaten und konkrete Modellnamen gehören nicht in diese
Spezifikation.

*Accepted inputs are the binding intake and the series-review artefacts bound
in run state. Autonomy cannot expand or replace scope, non-goals, order, or
hash. Provider credentials and concrete model names do not belong in this
specification.*

| Gate-ID | Zustand | Erforderlicher Nachweis / Required evidence | Token, Plattform und Trigger / Token, platform, trigger |
|---|---|---|---|
| TG-G01 Intake | `Applicable` | Ready-Review, exakter Intake-Pfad und akzeptierter SHA-256 | Hash und Branch vor jeder Phase neu prüfen; Drift blockiert. |
| TG-G02 Specify | `Applicable` | `spec.md`, vollständige `checklists/requirements.md`, kein offener Klärungsmarker | Phasenresultat bindet den normalisierten Spec-Hash. |
| TG-G03 Dependency | `Applicable` | Gewählte 2.x-Version, Registry-/Maintenance-/Vulnerability-/Lizenznachweis, transitive Pakete | Version ist ein veränderliches Validierungstoken; nach Restore und vor Release neu prüfen. |
| TG-G04 Lifecycle | `Applicable` | Null `Application.Top`, nicht veralteter Hauptlauf, sicherer Start/Stop | Quellprüfung plus manueller TUI-Lauf auf Implementierungs-OS. |
| TG-G05 Keyboard | `Applicable` | Null `CtrlMask`/`AltMask`; alle 13 Eingaben behalten ihr Verhalten | Quellprüfung plus manueller Tastaturnachweis. |
| TG-G06 Build/Test | `Applicable` | Repository-konformer Restore/Release-Build; 100% vorhandene Tests grün | `dotnet restore MicroCalc.sln`; `dotnet build ...`; `dotnet test ...`; Build-Zähler vorher anpassen. |
| TG-G07 Smoke | `Applicable` | Exitcode 0 und `SMOKE_OK` | Bindender Intake-Befehl nach Release-Build; headless. |
| TG-G08 A11Y | `Applicable` | Tastatur, Fokus, Textstatus, keine neue Farb-/Mausabhängigkeit; bilingualer Nachweis | Manuell + `docs/accessibility/terminalgui-migration.md`; bei UI-Abweichung neu prüfen. |
| TG-G09 Security | `Applicable` | NIST SSDF, CWE Top 25, C#/.NET, STRIDE/CAPEC, Dependency Audit, null bekannte Schwachstellen oder unbekannte/inkompatible Lizenzen im ausgelieferten Graph, vollständiges arc42 und fokussierter S-ADR | `docs/security/`-Evidenz; jeder Paket- oder Grenzfund triggert neue Bewertung. |
| TG-G10 Supply chain | `Applicable` | SBOM und SLSA/Provenance-Status; VEX- und Lizenzentscheidung | Release-/CI-Evidenz; ein bekannter ausgelieferter Fund blockiert statt durch VEX freigegeben zu werden. |
| TG-G11 TDD/Coverage | `Applicable` | Rot, Grün, Regression/Aufräumen; Changed-Code >=70%, Ziel 80% | Reproduzierbarer Coverage-Bericht; Unterschreitung blockiert. |
| TG-G12 Scope | `Applicable` | Keine fachliche Änderung an Core/Tests, kein Rename, kein FakeDriver, kein weiterer Intake; exakt `.github/workflows/ci.yml` ist die einzige Workflow-Ausnahme | `git diff --name-only` und Review; unerwarteter Pfad oder anderer Workflow blockiert. |
| TG-G13 Script parity | `N/A` für Skripte/Cmdlets | Keine Skript-/Cmdlet-Änderung; die autorisierte CI-Datei nutzt dieselben .NET-Befehle auf Ubuntu/Windows | Trigger: abweichende Plattformlogik, Wrapper oder weitere Automationsdatei. |
| TG-G14 Agent parity | `N/A` | Keine Agenten-/Template-/Constitution-Regel betroffen | Trigger: Änderung einer gemeinsamen Regeloberfläche. |
| TG-G15 Remote closeout | `N/A` für Specify | Kein Commit, Push, PR oder Merge in dieser Phase | Nur spätere explizit autorisierte sichere Grenze kann den Status ändern. |

Die Migration ändert weder Delivery-Set-Validierung noch Semantik
strukturierter Phasenresultate oder Gate-Evidence-Lifecycle; diese Punkte sind
für die Produktanforderung `N/A`. Wiedervorlage: Änderung an Runner-,
Delivery-Set- oder Gate-Verträgen. Schema 2.0 gilt für neue
Delivery-Entscheidungen; Schema 1.0 bleibt historische Evidenz.

*The migration changes neither delivery-set validation, structured phase-result
semantics, nor gate-evidence lifecycle, so these are `N/A` for product scope.
Re-evaluate on runner, delivery-set, or gate-contract changes. Schema 2.0 is
used for new delivery decisions; schema 1.0 remains historical evidence.*

Ein kausaler Closeout ist erst `Applicable`, wenn später tatsächlich eine
Remote-Lieferaktion autorisiert und ausgeführt wird. Dann müssen Aktion,
Provider-Ereignis, exakter Head, Gate-Status und Default-Branch-Synchronität
zusammenpassen. Alle getrackten Closeout-Nachweise müssen vor dem einzigen
Closeout-PR-Merge committed sein. Danach werden Provider- und Sync-Fakten nur
read-only in Runtime-Evidenz geprüft; `delivery.md`, Run-State und andere
getrackte Dateien bleiben unverändert, und es gibt keinen dritten Commit/PR.
Ohne Remote-Aktion bleibt der Closeout `N/A`.

*Causal closeout becomes applicable only after a later authorized and executed
remote delivery action. It must then bind action, provider event, exact head,
gates, and default-branch synchronization. Every tracked closeout artefact must
be committed before the single closeout pull request merges. Afterwards,
provider and sync facts are verified read only in runtime evidence; tracked
`delivery.md`, run state, and every other tracked file remain unchanged, with
no third commit or pull request. It remains `N/A` without a remote action.*

Jede Commit-erzeugende oder Commit-ändernde Aufgabe muss exakt
`Co-authored-by: Copilot <223556219+Copilot@users.noreply.github.com>` genau
einmal erzeugen oder erhalten. Dies umfasst die Provider-erzeugten Produkt- und
Closeout-Merge-Commits in T070 und T079: Beide `gh pr merge`-Aufrufe verwenden
explizite Subject-/Body-Optionen mit diesem Trailer und prüfen den tatsächlichen
Merge-Commit unmittelbar read-only, bevor die nächste Aufgabe beginnt. T080
ist nur die finale Wiederholungsprüfung.

*Every commit-producing or commit-amending task must create or preserve exactly
the stated co-author trailer once. This includes the provider-generated product
and closeout merge commits in T070 and T079: both merge calls use explicit
subject/body options with the trailer and verify the actual merge commit read
only before the next task starts. T080 is only final repeat verification.*

Ein absichtliches `PausedByUser` darf nur durch den Resume-Workflow fortgesetzt
werden. Nach unerwarteter Unterbrechung, Drift, fehlendem oder ungültigem
Phasenresultat, Hash-Abweichung oder Autoritätsänderung ist vollständige
Revalidierung erforderlich. Ein Stop beendet kooperativ an der nächsten
sicheren Grenze und erweitert keine Rechte.

*A deliberate `PausedByUser` state resumes only through the resume workflow.
Unexpected interruption, drift, missing/invalid phase result, hash mismatch, or
authority change requires full revalidation. A stop cooperates at the next safe
boundary and grants no authority.*

Portable Retrospektive darf nur wiederverwendbare Erkenntnisse aus der
abgeschlossenen Migration enthalten. FakeDriver-Tests, Rename und andere
Verbesserungen bleiben klar gekennzeichnete Folgearbeit und werden nicht
automatisch gestartet.

*A portable retrospective may contain only reusable learning from the completed
migration. FakeDriver tests, rename work, and other improvements remain clearly
labelled follow-ups and are not started automatically.*

## Abhängigkeiten und Annahmen / Dependencies and Assumptions

- Der akzeptierte Intake-Hash, das Ready-Serienreview, Feature 003 und der
  aktive Branch bleiben bis zum Phasenabschluss unverändert.
- Der grüne Repository-Ausgangszustand ist ein Preflight-Gate; die Specify-
  Phase führt wegen der versionsgebundenen Build-Regel keinen Build aus.
- Eine gepflegte stabile Terminal.Gui-2.x-Version ist über die verifizierte
  Paketquelle verfügbar und mit .NET 10 kompatibel. Die genaue Version wird als
  veränderliches Token vor Implementierung und Release erneut geprüft.
- Die 13 vorhandenen Navigations-/Beenden-Eingaben bilden den bindenden
  Bedienumfang. Andere Tastenfunktionen bleiben ebenfalls regressionsfrei,
  werden aber durch dieses Feature nicht neu definiert.
- Bestehende Testquellen reichen als fachlicher Regressionsvertrag; zusätzliche
  FakeDriver-Tests bleiben FollowUp. Coverage darf durch separate, reproduzier-
  bare Laufnachweise belegt werden, ohne Testquellen zu ändern.
- Bestehende Paket-, Security- und Supply-Chain-Dokumente dürfen für Feature
  003 aktualisiert werden; sie ändern den Produktumfang nicht.
- Wenn eine Annahme fehlschlägt, wird nicht stillschweigend Scope ergänzt. Das
  betroffene Gate blockiert und wird an der sicheren Phasengrenze neu bewertet.

*The accepted intake/review/branch remain stable; a green baseline is a
preflight gate; a maintained .NET-10-compatible Terminal.Gui 2.x package is
available and revalidated; the 13 existing inputs define the binding keyboard
scope; FakeDriver remains follow-up; evidence documents may change without
expanding product scope; and a failed assumption blocks rather than silently
expands the feature.*

## Erfolgskriterien / Success Criteria *(mandatory)*

### Messbare Ergebnisse / Measurable Outcomes

- **SC-001**: Alle sechs Intake-Akzeptanzkriterien AK-TG-TC-01 bis
  AK-TG-TC-06 bestehen; kein Kriterium ist nur teilweise erfüllt. / *All six
  intake acceptance criteria pass with none partly fulfilled.*
- **SC-002**: Im Produktcode verbleiben null Verwendungen der veralteten
  Hauptfenster- und Tastaturmuster. / *Zero uses of the deprecated main-window
  and keyboard patterns remain in product code.*
- **SC-003**: Alle 13 vorhandenen Navigations- und Beenden-Eingaben erreichen
  in manueller Prüfung bei jedem Versuch ihre bisherige Wirkung. / *All 13
  existing navigation and quit inputs retain their effect in every manual
  check.*
- **SC-004**: Der gebaute Smoke-Lauf endet innerhalb von 30 Sekunden mit
  Exitcode 0 und genau einem sichtbaren `SMOKE_OK`-Erfolgstoken. / *The built
  smoke run finishes within 30 seconds with exit code 0 and one visible
  `SMOKE_OK` success token.*
- **SC-005**: 100 Prozent der vorhandenen Solution-Tests bestehen im
  Release-Modus; es gibt null neue Warnungen, die im Release-Build als Fehler
  behandelt werden. / *100% of existing solution tests pass in Release mode,
  with zero new warnings promoted to errors.*
- **SC-006**: Ein Reviewer kann Start, Menü, Zellnavigation, Dialogrückkehr und
  beide Beenden-Wege im ersten Durchgang vollständig ausführen. / *A reviewer
  completes startup, menu, navigation, dialog return, and both quit paths on
  the first run.*
- **SC-007**: Changed-Code-Coverage erreicht mindestens 70 Prozent; 80 Prozent
  bleibt das dokumentierte Ziel. Rot-, Grün- und Regression-/Aufräum-Nachweise
  sind vorhanden. / *Changed-code coverage reaches at least 70%, with 80% as
  the recorded target, and red/green/regression-refactor evidence exists.*
- **SC-008**: Der Abschluss-Scan meldet null bekannte Schwachstellen in der
  ausgelieferten direkten und transitiven Paketmenge. Für alle ausgelieferten
  Pakete sind Lizenz, Quelle, Kompatibilität und Disposition belegt; null
  unbekannte oder inkompatible Lizenzen verbleiben. SBOM- und SLSA-Status sind
  nachvollziehbar dokumentiert. / *Final scanning reports zero known
  vulnerabilities in the shipped direct and transitive package graph. Every
  shipped package has licence, source, compatibility, and disposition evidence,
  with zero unknown or incompatible licences. SBOM and SLSA status are
  reviewable.*
- **SC-009**: Alle anwendbaren A11Y-Prüfungen bestehen ohne neue Tastaturfalle,
  Fokus- oder farbabhängige Information. / *All applicable accessibility checks
  pass without a new keyboard trap, focus issue, or colour-only information.*
- **SC-010**: Der Abschluss-Diff enthält null fachliche Änderung in
  `MicroCalc.Core`, vorhandenen Testquellen, Rename-Artefakten, Agentenregeln,
  Skripten oder einem anderen Intake. / *The final diff contains zero
  functional changes to Core, existing test sources, rename artefacts, agent
  rules, scripts, or another intake.*

## Abnahmematrix / Acceptance Matrix

| Intake-AK | Zugeordnete Anforderungen / Requirements | Erfolg und Evidenz / Success and evidence |
|---|---|---|
| AK-TG-TC-01 | FR-001, FR-012 | Projektdatei, Restore, Dependency Audit, CVE-Prüfung, SBOM |
| AK-TG-TC-02 | FR-002 | Quellsuche ohne `Application.Top`, Release-Build, manueller Start/Stop |
| AK-TG-TC-03 | FR-003, FR-004 | Quellsuche ohne Masken; 13 Tastatureingaben manuell geprüft |
| AK-TG-TC-04 | FR-005 | Intake-Smoke-Befehl, Exitcode 0, `SMOKE_OK` |
| AK-TG-TC-05 | FR-006, FR-010, FR-013 | Vollständige Release-Tests, Rot/Grün/Regression, Coverage |
| AK-TG-TC-06 | FR-004, FR-007, FR-011 | Manueller TUI-Lauf: Start, Menü, Navigation, Dialog, Quit |

*Each original acceptance criterion maps to testable requirements and explicit
evidence. This matrix preserves the intake without introducing another feature.*

## Risiken und Folgepunkte / Risks and Follow-ups

- **API-Kompatibilität**: Terminal.Gui 2.x kann weitere Compile- oder
  Laufzeitänderungen verlangen. Mitigierung: kleinste migrationsbezogene
  Anpassung, Build-, Dialog- und Tastaturnachweis. Restrisiko: terminalabhängige
  Unterschiede.
- **Lieferkette**: Eine neue Hauptversion verändert direkte und transitive
  Komponenten. Mitigierung: verifizierte Registry, Maintenance-/CVE-Prüfung,
  vollständige Lizenzprüfung, Dependency Audit, SBOM, SLSA/Provenance und
  fail-closed Schranke für jede bekannte ausgelieferte Schwachstelle.
- **Bedienregression**: Neue Tastendarstellung kann Vergleiche oder Fokus
  verändern. Mitigierung: alle 13 Eingaben und beide Beenden-Wege prüfen.
- **Testlücke**: Es gibt noch keine FakeDriver-Integrationstests. Restrisiko:
  interaktive TUI-Pfade sind stärker auf manuellen Nachweis angewiesen.
  FollowUp: R-TG-TC-06, mindestens drei Tests in separatem PR.
- **Scope-Kopplung**: Ein gleichzeitiger Rename würde Evidenz vermischen.
  Mitigierung: Feature 003 zuerst separat abschließen; Feature 004 nicht starten.

*Risks cover API compatibility, supply-chain change, keyboard/focus regression,
the intentional FakeDriver test gap, and accidental rename coupling. Each has a
bounded mitigation, and the FakeDriver work remains a separate follow-up.*
