# Feature-Spezifikation: Barrierefreie TUI / Feature Specification: Accessible TUI

**Feature Branch:** `007-tui-accessibility`
**Erstellt / Created:** 2026-10-12
**Status:** Clarified — zwei Entscheidungen geklärt; Spezifikation und vorhandene Planung dokumentarisch nachgeprüft, keine Implementierungsfreigabe / two decisions resolved; specification and existing planning reviewed as documents, not implementation approval

**Nachtrag / Addendum 2026-10-18:** Nach `/speckit.tasks` und zwei `/speckit.analyze`-Läufen wurden auf ausdrücklichen Auftrag Analysebefunde in Spec, Plan und Tasks korrigiert (Impact-Abgrenzung, DocFX-Seitenumfang, Reihenfolge der direkten Eingabe, Evidence-Pfad). Umfang, CQ-001/CQ-002 und Ausführungsrechte bleiben unverändert; weiterhin keine Implementierungsfreigabe. Die datierten Stopp-Klauseln unten sind historische Rechtegrenzen der jeweiligen Läufe. / After task generation and two analysis runs, analysis findings were corrected in the spec, plan and tasks on explicit request. Scope, accepted answers and execution authority are unchanged; still no implementation approval. Dated stop clauses below are historical limits of their runs.
**Verbindliches Intake / Binding intake:** [Lastenheft_A11Y_TUI.md](../../requirements/intakes/active/Lastenheft_A11Y_TUI.md)
**Input:** Nutzerauftrag vom 12.10.2026: vollständige A11Y-Spezifikation, read-only Vorprüfung, ergänzende Beobachtungen aus Issue #107, keine Umsetzung oder Lieferung.

*User request of 12 October 2026: specify the complete accessibility intake after read-only checks, consider issue #107 as supplementary evidence, and perform no implementation or delivery.*

## Lesehilfe und Quellen / Reading Guide and Sources

Deutsch ist kanonisch; gleichwertiges Englisch folgt jeweils direkt. Zielgruppe sind Anwendende, Lehrende und Lernende der vier IHK-IT-Berufe ab dem ersten Ausbildungsjahr sowie Entwicklung und Review. Grundlegende Tabellen-, Datei- und Tastaturbedienung genügt. Vorwissen zu Screenreadern oder Spec Kit wird nicht vorausgesetzt; beide Sprachfassungen zielen auf CEFR B2.

*German is canonical, with equivalent English directly following it. The audience includes users, teachers, trainees in the four IHK IT professions from their first year, developers and reviewers. Basic spreadsheet, file and keyboard knowledge is sufficient; no screen-reader or Spec Kit knowledge is assumed. Both languages target CEFR B2.*

Eine TUI ist eine textorientierte Oberfläche im Terminal. Ein Screenreader liest zugängliche Informationen vor oder gibt sie an eine Braillezeile weiter. Fokus bezeichnet das aktuell bedienbare Element. Ein PTY ist ein Pseudoterminal für echte prozessbasierte Ein-/Ausgabe. Ein Vertrag bindet stabile Kennungen an erwartetes Verhalten; Evidence ist ein prüfbarer Nachweis. Ein Preflight ist eine Vorprüfung; ein Gate eine verpflichtende Prüfschranke. WCAG 2.2 AA ist die Barrierefreiheitsbasis, soweit ein Kriterium auf das jeweilige Artefakt anwendbar ist.

*A TUI is a text-oriented terminal interface. A screen reader speaks accessible information or sends it to a Braille display. Focus identifies the currently operable control. A PTY is a pseudo-terminal for real process input/output. A contract binds stable IDs to expected behaviour; evidence is verifiable proof. Preflight means preliminary verification and a gate is a required checkpoint. WCAG 2.2 AA is the accessibility baseline wherever a criterion applies to the artefact.*

Verbindliche Quellen sind das Intake, die [Serie](../../requirements/intakes/series/tinycalc-delivery/manifest.json), der [Funktionsvertrag aus Feature 006](../006-tui-functional-contract/spec.md) und dessen [aktiver Produktvertrag](../../docs/contracts/tui/product-contract.json), [unabhängige Baseline](../../docs/contracts/tui/baseline-inventory.json), [Quellenzuordnung](../../docs/contracts/tui/source-map.json) und [lesbarer Katalog](../../docs/contracts/tui/catalog.md). Die Baseline wird vollständig übernommen, nicht aus Beispielen oder bestandenen Tests verkleinert. Substantielle Angebote sind Vertrag; eindeutige Tipp-, Syntax- oder Rasterfehler sind gesonderte Dokumentationsdefekte, keine stillschweigende Funktionsentfernung.

*Binding sources are the intake, series, Feature 006 specification and its active product contract, independent baseline, source map and readable catalogue linked above. Preserve the complete baseline rather than reducing it to examples or passing tests. Substantive offers are contractual; clear spelling, syntax or grid errors are separate documentation defects, not implicit removal of functionality.*

Read-only Vorprüfung am 12.10.2026, Basiscommit `935fce0d6946748bea4119877fecab43a88ae8cb`: Governance `Aligned`; Serie `Active`, 13 Ziele, vier Wurzeln, neun bindende Kanten; genau ein deklariertes `Eligible`-Ziel ist dieses A11Y-Intake. Die Sandbox-Härtung ist eine weitere strukturell unabhängige Wurzel im Status `Pending`, kein Startauftrag. Migration und Funktionsabnahme sind `Completed`. Review `30ca6838-1bdf-49e3-8f94-d72e990c6728` ist aktuell, `Ready`, mit 13 hashgebundenen Zielen. Authoring-Receipt des A11Y-Intakes `3f215855-e5df-4062-9ed4-d7b6f8eae911` ist mit vier Quellen aktuell. Diese Befunde erlauben Specify, nicht Implementierung. Vor späteren Phasen erneut prüfen.

*Read-only checks on 12 October 2026 at base commit 935fce0d6946748bea4119877fecab43a88ae8cb found aligned governance, an active series with 13 targets, four roots and nine binding edges. A11Y is the sole declared Eligible target. Sandbox hardening is a separate structurally independent Pending root, not a start instruction. Migration and functional acceptance are Completed. The current Ready review binds 13 targets; the A11Y authoring receipt has four current sources. This supports Specify only. Revalidate before later phases.*

## Klärungen / Clarifications

Dokumentennachprüfung am 18.10.2026, Basis `f373437`: Umfang und Antworten bleiben unverändert. Die 34 Durchführungshinweise werden gegen Quellen und bestehende Planung geprüft; es wird kein weiterer Specify-/Plan-/Tasks-Lauf und keine Produktprüfung gestartet. Aktuelle Governance-Bindungen werden separat erneut lesend validiert. Frühere datierte Prüfstände bleiben historische Aussagen, keine Ausführungsfreigabe.

*Document recheck on 18 October 2026 at f373437 preserves scope and accepted answers. Review all 34 instructions against sources and existing planning without starting another workflow phase or product test. Revalidate current governance bindings read-only; earlier dated checks remain historical, not execution permission.*

### Session 2026-10-12

- Q (CQ-001): Welche Umgebung ist die Referenz für die native VoiceOver-Abnahme? → A: Mac A mit Terminal.app und VoiceOver. Versionen und Einstellungen werden je Prüflauf dokumentiert, nicht dauerhaft festgeschrieben. Der historische Terminalhost von B01/B02 bleibt unbestätigt. 80x24 und 120x40 bleiben Pflichtgrößen; 120x28 ergänzt die Reproduktion.
  *Q (CQ-001): Which environment is the reference for native VoiceOver acceptance? → A: Mac A with Terminal.app and VoiceOver. Record versions and settings for each run without permanent version pins. The historical terminal host for B01/B02 remains unconfirmed. Required sizes remain 80x24 and 120x40; 120x28 supplements reproduction.*

- Q (CQ-002): Wie muss die fokussierte Dialogaktion mit VoiceOver erkennbar sein? → A: VoiceOver benennt beim Fokuswechsel die aktuelle Aktion unmittelbar eindeutig, ohne zusätzliche Leseschritte. Eine zusätzliche Tastatur-/Lesefolge ist kein Ersatz für diese Abnahme; eine bestimmte technische Lösung wird nicht vorgeschrieben.
  *Q (CQ-002): How must VoiceOver identify the focused dialog action? → A: VoiceOver immediately and unambiguously names the current action on focus change, without additional reading steps. An additional keyboard/reading sequence cannot substitute for this acceptance requirement; no specific technical solution is prescribed.*

## Nutzungsszenarien und Prüfung / User Scenarios & Testing

Prioritäten ordnen den Nutzerwert, verkleinern aber keine Pflicht. Jeder Ablauf ist separat prüfbar; vollständige Abnahme verlangt alle Abläufe und die gesamte aktive Baseline.

*Priorities order user value, not required scope. Each journey is independently testable; complete acceptance requires all journeys and the entire active baseline.*

### US-001 — Ohne Maus und Farbdeutung arbeiten / Work without a mouse or colour interpretation (P1)

Als Anwender möchte ich Raster, aktive Adresse, Zelltyp, AutoCalc, Menüs und Nachrichten vollständig über Tastatur und Text verstehen. Das ist die Grundlage für selbstständige Tabellenarbeit, auch mit Braillezeile.

*As a user, I want to understand and operate the grid, active address, cell type, AutoCalc, menus and messages through keyboard and text. This enables independent spreadsheet work, including use with a Braille display.*

**Unabhängige Prüfung / Independent test:** Jeden aktiven Navigationsweg und Alias, Randfall sowie Menü-/Palettenweg bedienen; sichtbare Textinformationen und Fokus prüfen, ohne Farbe oder Position als alleinige Bedeutung zu verwenden.

*Exercise every active navigation path and alias, boundary, menu and palette route; verify visible text and focus without relying only on colour or position.*

1. Gegeben ist das Raster an einer Innen- oder Randzelle. Wenn ein vertraglicher Navigationsweg verwendet wird, dann bleiben aktive Adresse, Zellkontext und Fokus eindeutig und die Grenzsemantik unverändert.
2. Gegeben ist eine verfügbare Aktion. Wenn sie ausgelöst wird, dann meldet sichtbarer Text Erfolg, Abbruch oder Fehler eindeutig; erforderliche Zustandsinformationen sind nicht nur farblich erkennbar.
3. Gegeben sind die definierten Terminalgrößen. Wenn Raster, Menü, Status und Nachrichten bedient werden, dann bleiben Pflichtinformationen und Aktionen erreichbar und lesbar.

*1. Given an interior or boundary cell, when a contractual navigation route is used, the active address, context and focus remain clear and boundary semantics remain unchanged. 2. Given an available action, invoking it produces clear visible success, cancellation or error text; required state is not colour-only. 3. At each required terminal size, essential information and actions remain reachable and readable.*

### US-002 — Eingaben und Dialogaktionen sicher unterscheiden / Distinguish input and dialog actions safely (P1)

Als Anwender möchte ich Zahlen, Text und Formeln fortlaufend eingeben, den Dialogkontext erkennen sowie Bestätigen und Abbrechen ohne Sichtkontrolle unterscheiden. Unbeabsichtigte Änderungen an Tabelle oder Dateien müssen ausgeschlossen sein.

*As a user, I want continuous number, text and formula entry, clear dialog context, and distinguishable confirmation and cancellation without looking. Unintended changes to the sheet or files must be prevented.*

**Unabhängige Prüfung / Independent test:** Editor, Palette, Load, Save, Print, Format und Clear über echte Tastaturpfade einschließlich Tab/Shift-Tab, Bestätigung, Abbruch und Fehler bedienen; Fokus, Text, Tabelle und Datei-Invarianten vergleichen. Native Screenreader-Prüfung zusätzlich und getrennt protokollieren.

*Operate the editor, palette, Load, Save, Print, Format and Clear through real keyboard routes, including Tab/Shift-Tab, confirmation, cancellation and errors. Compare focus, text, sheet and file invariants. Record native screen-reader verification separately as additional evidence.*

1. Wenn eine mehrstellige Zahl, ein Text oder eine Formel direkt getippt wird, dann wird die Eingabe gemäß bestehendem Editorvertrag fortgesetzt; eine vom Testhelfer zusätzlich gesendete Navigation ersetzt nicht den normalen Tippweg. Ein beobachteter Überschreibfehler bleibt ein zu untersuchender Befund, keine hier bestätigte Ursache.
2. Wenn der Fokus eine Dialogaktion erreicht, dann benennt VoiceOver die tatsächliche Aktion unmittelbar eindeutig, ohne zusätzliche Leseschritte; der Dialogkontext bleibt verständlich. Gleich lautende oder fehlende Aktionsinformationen bestehen die Screenreader-Abnahme nicht.
3. Wenn ein Dialog bestätigt, abgebrochen oder mit Fehler beendet wird, dann ändern sich Daten und Fokus nur wie im bestehenden Vertrag erlaubt; Abbruch verursacht keine Teilwirkung.

*1. Directly typing a multi-digit number, text or formula follows the existing editor contract; navigation inserted by a test helper is not a substitute for ordinary typing. Reported overwriting remains an investigation finding, not a confirmed cause here. 2. When a dialog action receives focus, VoiceOver immediately and unambiguously names the actual action without additional reading steps, with understandable dialog context; missing or indistinguishable action information fails screen-reader acceptance. 3. Confirmation, cancellation and errors change data and focus only as the existing contract permits; cancellation has no partial effect.*

### US-003 — Hilfe lesen und Orientierung behalten / Read help and retain orientation (P1)

Als Lernender möchte ich alle kontextuell verfügbaren Tasten und Befehle ohne widersprüchliche Doppelbelegung nachlesen und zwischen Hilfeseiten, Text und Aktionen navigieren können.

*As a trainee, I want a complete reference of contextual keys and commands without conflicting assignments, and navigation between help pages, text and actions.*

**Unabhängige Prüfung / Independent test:** Referenz mit allen aktiven Vertragswegen abgleichen; Hilfe mit Buttons, P/N, Esc, Seitenstatus und vollständiger Shortcut-Referenz bedienen. Textlesen und Steuerelementfokus separat prüfen.

*Compare the reference with all active contract routes; exercise help buttons, P/N, Esc, page status and the complete shortcut reference. Check text reading separately from control focus.*

1. Wenn Hilfe geöffnet, geblättert und geschlossen wird, dann sind Titel, Seitenstatus, Inhalt und Aktionen textuell verständlich; Rückkehrfokus und Datenzustand sind korrekt.
2. Wenn eine Taste kontextabhängig mehrere Aufgaben besitzt, dann erklärt die Hilfe den Kontext. Raster-`/` und Editor-`/` werden nicht als widersprüchliche globale Belegung behandelt.
3. Wenn Screenreader-Bedienhinweise aufgenommen werden, dann nennen sie nur tatsächlich geprüfte Plattform-/Terminal-/Screenreader-Kombinationen und ihre Grenzen; zeilenweises Lesen wird nicht mit fokussierter Bedienung gleichgesetzt.

*1. Opening, paging and closing help exposes clear title, page state, content and actions with correct return focus and unchanged data. 2. Context-dependent keys are explained by context; grid slash and editor slash are not treated as conflicting global assignments. 3. Any added screen-reader instructions describe actually verified platform/terminal/reader combinations and their limits; line reading is not equivalent to focused control operation.*

### US-004 — Nachweise verstehen und Wiederholungen auslösen / Understand evidence and trigger regression (P2)

Als Reviewer möchte ich pro Vertragsweg erkennen, was auf welcher Umgebung tatsächlich geprüft wurde und wann eine neue Prüfung erforderlich ist. Ein grüner Build darf kein unvollständiges A11Y-Ergebnis verdecken.

*As a reviewer, I want to identify the actual scope and environment of each verified path and when rechecking is required. A green build must not hide incomplete accessibility evidence.*

**Unabhängige Prüfung / Independent test:** Vollständigkeit der IDs, Quellen-/Commitbindung, Impact-Klasse, Plattformresultate und fehlende/fehlgeschlagene/unvollständige Nachweise prüfen; unzulässige Gesamt-Pass-Aussagen zurückweisen.

*Check complete IDs, source and commit bindings, impact category, platform results and missing, failing or incomplete evidence; reject unsupported overall pass claims.*

1. Wenn Pin- oder Quellenvergleich Drift zeigt, dann ist der bisherige Nachweis kein aktueller Pass; die Vollmatrix wird verlangt, kein Upgrade durchgeführt.
2. Wenn A11yImpact, größere TUI-Änderung, Dependency-Drift oder Release-Closeout vorliegt, dann wird die geforderte native macOS-VoiceOver-Sitzung demselben Commit zugeordnet.
3. Wenn DocFX regeneriert wird, dann liegen im selben Arbeitsgang repräsentative Playwright-/axe- und lynx-Nachweise im Sinne von R-A11Y-CALC-09 vor. Automatisierte Teilprüfung ist kein vollständiger WCAG- oder nativer Screenreader-Nachweis.

*1. Pin or source drift prevents reuse as a current pass and requires full evidence, without upgrading. 2. Accessibility impact, major TUI changes, dependency drift and release closeout require native macOS VoiceOver proof on the same commit. 3. Every DocFX regeneration has representative Playwright/axe and lynx proof, as defined in R-A11Y-CALC-09, in the same work item. Partial automation does not prove complete WCAG or native screen-reader acceptance.*

### Grenzfälle / Edge Cases

- Innen- und Randzellen, leere/gesperrte/fehlerhafte Zellen, abgeschnittene Meldungen und Fokus nach jedem Dialogausgang.
- Direkte fortlaufende Eingabe mit VoiceOver aus und an; Einfügen-/Überschreibmodus unterscheiden, keine zusätzliche End-Taste als stillen Testersatz.
- Kontextabhängige Aliasse, Hilfe am ersten/letzten Blatt, fehlende oder beschädigte Hilferessource und Rückkehr ins Raster.
- Fehlende/ungültige Datei, Abbruch vor Schreiben/Drucken/Löschen und unveränderte synthetische Daten bei Abbruch.
- Verkleinerung und Wiedervergrößerung; 80x24 und 120x40 als bestehende Baseline, 120x28 als ergänzendes berichtetes Mac-A-Szenario, kein Ersatz der Baseline.
- Unkontrollierbare Terminalfarben, unbekannter Host, fehlende Screenreader-Einstellungen, nicht protokollierte Ansage und verwechslungsfähige OK-/Cancel-Ausgabe: Lücke ausweisen, keinen Pass erfinden.
- Alter Commit, abweichendes Binary, fehlender/floating/unfreigegebener Pin, ungültiger Lockvergleich, teilweise Automation oder manuelle Stichprobe statt Vollabdeckung.

*Edge coverage includes cell boundaries and states, clipped messages, focus after every dialog exit; direct input with VoiceOver off/on and explicit insert/overwrite mode; contextual aliases and all help boundaries/errors; invalid files and cancellation without partial writes; resizing with baseline 80x24/120x40 plus supplementary reported 120x28; uncontrolled colours, unknown host/settings and unclear action announcements; stale commits, mismatched binaries, missing/floating/unapproved pins, invalid lock comparisons and incomplete coverage. Unknown or partial results are never fabricated passes.*

## Anforderungen / Requirements

### Funktionale Anforderungen / Functional Requirements

Die zehn `R-A11Y-CALC-*`-IDs bleiben mit identischer Bedeutung erhalten. Die bereits in Feature 006 geführten `A11Y-CALC-01` bis `A11Y-CALC-10` bleiben Nachweisanker; neue Einzelwege erhalten später additive `A11Y-*`-IDs. Diese Spezifikation ändert den ausführbaren Vertrag nicht.

*Preserve all ten intake requirement IDs and their meaning. Existing Feature 006 accessibility anchors remain stable; future additional paths receive additive A11Y IDs. This specification does not modify the executable contract.*

- **R-A11Y-CALC-01:** Status und Hilfe müssen alle kontextuell verfügbaren Tasten aus dem vollständigen Produktvertrag erklären, ohne widersprüchliche Doppelbelegung. Jeder Alias bleibt separat nachweispflichtig.
  *Status and help must explain every contextual contract key without conflicting assignments; each alias retains its own proof obligation.*
- **R-A11Y-CALC-02:** Jede benutzerinitiierte Aktion muss eine eindeutige sichtbare Textmeldung für Erfolg, Abbruch oder Fehler erzeugen. Farbe, Position und Fokusrahmen allein genügen nicht; Zellkontext und Auswahl müssen textuell erkennbar bleiben.
  *Every user action must produce clear visible success, cancellation or error text. Colour, position and focus borders alone are insufficient; cell context and selection must remain text-recognisable.*
- **R-A11Y-CALC-03:** Die mehrseitige Hilfe muss eine vollständige strukturierte Shortcut-/Befehlsreferenz enthalten, die Screenreader und Textbrowser nutzen können. Buttons, P/N, Esc und Seitenstatus bleiben erhalten. Geprüfte Screenreader-Hinweise dürfen keinen ungeprüften Plattformtransfer behaupten.
  *Paged help must provide a complete structured shortcut/command reference usable by screen readers and text browsers, retaining buttons, P/N, Esc and page state. Verified screen-reader guidance must not imply untested platform transfer.*
- **R-A11Y-CALC-04:** Vor Umsetzung muss der Preflight die abgeschlossene Migration als `AlreadySatisfied` belegen sowie aktuellen freigegebenen Repository-Pin, Deklarations- und Lockquellen auflösen. Unveränderter Pin erlaubt ausschließlich evidenzgebundene Wiederverwendung. Drift verlangt volle Kompatibilitäts-, PTY- und A11Y-Prüfung; fehlender, gleitender oder unfreigegebener Pin blockiert Umsetzung. Kein automatisches Upgrade.
  *Before implementation, prove migration AlreadySatisfied and resolve the current approved pin, declarations and locks. Unchanged pins allow only evidence-bound reuse; drift requires full compatibility, PTY and accessibility checks. Missing, floating or unapproved pins block implementation. No automatic upgrade.*
- **R-A11Y-CALC-05:** Text muss mindestens 4,5:1, große Textdarstellung mindestens 3:1 Kontrast erreichen, soweit das Terminal Farben kontrollierbar wiedergibt. Nicht-Text-Fokus-/Auswahlindikatoren müssen anwendbare WCAG-2.2-AA-Kriterien erfüllen und zusätzlich Textbedeutung besitzen. Umgebung, Messung und Grenzen müssen benannt sein; bei unkontrollierbaren Farben keine unbelegte Erfüllungsbehauptung.
  *Text requires at least 4.5:1 contrast and large text at least 3:1 where terminal colours are controllable. Non-text focus/selection indicators meet applicable WCAG 2.2 AA criteria and also convey textual meaning. Record environment, measurements and limitations; uncontrolled colours do not justify an unsupported pass.*
- **R-A11Y-CALC-06:** Alle Dialoge müssen logische Fokusreihenfolge, sichtbaren Fokus, eindeutig beschriftete Aktionen und vollständige Tastaturpfade für Bestätigung/Abbruch besitzen. Screenreader-Nachweise müssen den Dialogkontext und die tatsächlich fokussierte Aktion unterscheidbar belegen; lesbares „OK“ allein ist kein Nachweis einer verständlichen Fokusansage.
  *Every dialog requires logical order, visible focus, clear action labels and complete keyboard confirmation/cancellation. Screen-reader proof must distinguish the dialog context and actual focused action; readable OK text alone is not proof of understandable focus announcements.*
  Konkretisierung CQ-002: VoiceOver muss beim Fokuswechsel die tatsächliche Aktion unmittelbar eindeutig benennen, ohne zusätzliche Leseschritte. Eine zusätzliche Tastatur-/Lesefolge ersetzt diese Abnahme nicht. Dies schreibt keine technische Lösung oder native Rollenabbildung vor.
  *CQ-002 clarification: VoiceOver must immediately and unambiguously name the actual action on focus change without additional reading steps. An additional keyboard/reading sequence cannot replace acceptance. This prescribes neither a technical solution nor a native role mapping.*
- **R-A11Y-CALC-07:** Prozessbasierte PTY-Prüfungen müssen Navigation, Bearbeitung, Befehle, Hilfe, Datei- und Fehlerpfade mit beobachtbaren Textresultaten ausführen. Interne Widget-/Buffer-Tests ergänzen, ersetzen aber keine echte Terminalprozessprüfung; Fokus- und Dateninvarianten bleiben Pflicht.
  *Process-based PTY checks must execute navigation, editing, commands, help, file and error paths with observable text results. Internal widget/buffer tests supplement rather than replace real process interaction; focus and data invariants remain mandatory.*
- **R-A11Y-CALC-08:** `A11yImpact`, größere TUI-Änderungen (Abgrenzung unter der Impact-Matrix), Dependency-Drift und `ReleaseCloseout` müssen dokumentierte native macOS-VoiceOver-Prüfung auslösen. Reine Textänderungen ohne TUI-/DocFX-Wirkung wiederholen sie nicht; betroffene Text-/Driftvalidatoren bleiben Pflicht. Linux-/Windows-Automation ersetzt keine native VoiceOver-Sitzung.
  *Accessibility impact, major TUI changes (defined under the impact matrix), dependency drift and release closeout require documented native macOS VoiceOver verification. Text-only changes without TUI/DocFX effects do not repeat it, but affected text/drift checks remain mandatory. Linux/Windows automation is no substitute.*
- **R-A11Y-CALC-09:** Jede DocFX-Regeneration muss repräsentative Seiten mit Playwright plus `@axe-core/playwright` und zusätzlich `lynx` textorientiert prüfen. „Repräsentativ“ bedeutet mindestens: jede erzeugte Seite mit geänderter Quelle oder geändertem Template, die Startseite, die Navigation/TOC und bei API-Regeneration je eine geänderte API-Typseite; keine Stichprobe darunter. Betroffene Inhalte, Navigation, Sprache, Fokus und Struktur müssen nachvollziehbar sein. Nicht abschließbare axe-Prüfungen werden als unvollständig dokumentiert, nicht als bestanden.
  *Every DocFX regeneration requires representative Playwright plus axe-core/playwright and lynx text review. Representative means at least every generated page with a changed source or template, the start page, the navigation/TOC and, after API regeneration, each changed API type page; no smaller sample. Record affected content, navigation, language, focus and structure. Incomplete axe assessments are recorded as incomplete, not passed.*
- **R-A11Y-CALC-10:** Alle Nachweise müssen stabile `A11Y-*`-IDs mit dem wachsenden Produktvertrag, Einzelwegen, Plattform und Ergebnis verbinden. Alle früheren aktiven IDs bleiben Pflichtregression; keine Wiederverwendung oder stillschweigende Entfernung. Neue Anforderungen erhalten vor späterem Produktcode additive IDs und beobachtbar rote Tests.
  *Bind every proof to stable A11Y IDs, the growing contract, individual paths, platform and result. Retain all prior active IDs, with no recycling or silent removal. Future requirements add IDs and observably failing tests before product code.*

### Vollständige Funktionsbaseline / Complete Functional Baseline

Die folgenden Familien werden vollständig aus Feature 006 übernommen, einschließlich Erfolgs-, Abbruch-, Fehler-, Grenz- und Aliaspflichten. Der bestehende Katalog enthält 364 Pflichttupel pro Plattform, insgesamt 1.092 für Linux/Windows/macOS; diese Zahl ist kein Pass-Ergebnis und kein Deckel für additive Anforderungen. Der jeweils aktive, unabhängig gebundene Nenner bleibt maßgeblich.

*Carry forward every listed family with all success, cancellation, error, boundary and alias obligations from Feature 006. The existing catalogue has 364 obligation tuples per platform, 1,092 across Linux/Windows/macOS. This is neither a pass result nor a cap on additions; the active independently bound denominator governs completeness.*

| Bestehende IDs / Existing IDs | Unverkleinerter Umfang / Preserved scope |
|---|---|
| APP-001 | Start, Smoke OK/FAIL, Ende und Terminalwiederherstellung / start, smoke outcomes, shutdown and terminal restoration |
| GRID-001 | A1:G21, Köpfe, aktive Adresse, Typ, AutoCalc, Ränder / grid, headers, address, type, AutoCalc and boundaries |
| NAV-UP-001, NAV-DOWN-001, NAV-RIGHT-001, NAV-LEFT-001 | Jeder angebotene Alias in seinem Kontext, innen und am Rand / every contextual navigation alias, interior and edge |
| EDIT-001 | Druckbare ASCII-Zeichen 32–126, vorhandenen Inhalt öffnen, fortlaufende Eingabe, Editier-/Lösch-/Modus-Aliasse, Bestätigen/Abbrechen / printable input, existing content, continuous entry, editing/deletion/mode aliases and confirm/cancel |
| CELL-001 | Leer/Text/Zahl/Formel, Flags, Überlauf, Breite, Dezimalstellen, Sperre und Fehler / all cell kinds, flags, overflow, widths, decimals, locks and errors |
| OP-001, REF-001 | Unäre Zeichen, Klammern, Operatoren, Adressen, Bereichssumme, Leer-/Textreferenz und Zyklen / unary signs, parentheses, operators, addresses, ranges, empty/text references and cycles |
| FUNC-LEGACY-001 | ABS, SQRT, SQR, SIN, COS, ARCTAN, LN, LOG, EXP, FACT samt geklärter Grenzsemantik / every legacy function and clarified boundaries |
| FUNC-EXT-001 | MIN, MAX, AVERAGE, COUNT, IF, ROUND samt geklärter Grenzsemantik / every extended function and clarified boundaries |
| CMD-001 | Load, Save, Recalculate, Print, Format, AutoCalc, Help, Clear, Quit über Menü/Palette und angebotene Shortcuts / all commands through menus, palette and offered shortcuts |
| FILE-001 | JSON-Rundreise, fehlend/ungültig, Textdruck/Rand und Dateidialog-Abbruch / round trip, invalid/missing files, text printing/margins and cancellation |
| HELP-001 | Ressource, P/N, Prev/Next, Textscrolling, Esc/Close, Seitenstatus, fehlend/beschädigt / resources, every paging/scroll/close route, state and errors |
| DIALOG-001 | Editor, Load, Save, Print, Format, Clear, Palette; jeder Ausgang mit Fokus-/Datei-/Tabelleninvarianten / every dialog exit with focus, file and sheet invariants |
| TERM-001 | 80x24 und 120x40, Größenwechsel, Fokus/Kontrast und echte PTY-Texte / both baseline sizes, resizing, focus, contrast and actual PTY text |

Feature-006-Entscheidungen zu kontextuellen Tasten, historischen Hilfsangeboten, Winkeleinheiten, Logarithmusbasen, ROUND-Präzision, Formelfehlern und Toleranzen bleiben unverändert. Keine neue Formelsemantik wird aus Testergebnissen abgeleitet. Der neue A11Y-Nenner bindet die bestehenden Wege, nicht nur Beispiele oder die zehn übergeordneten Anforderungszeilen.

*Preserve Feature 006 decisions on contextual keys, historical help offers, angular units, logarithm bases, ROUND precision, formula errors and tolerances. Do not derive new formula semantics from test results. Accessibility coverage binds existing paths, not only examples or the ten high-level requirement rows.*

### Verfassungsanforderungen / Constitution Requirements

- **CR-001:** Die TinyCalc-Zeile des Level-2-Registers in `constitution.md` ist bindend: .NET 10/C#, bestehende Core-/TUI-Trennung, xUnit/Smoke, DocFX-A11Y und Statistikreferenzen 80/125 Zeilen pro Arbeitstag. Keine Runtimeänderung durch Specify.
  *The TinyCalc Level-2 registry row binds runtime, existing separation, verification, documentation and statistics baselines; Specify changes no runtime.*
- **CR-002:** Text, Tastatur, Fokus und anwendbare WCAG-2.2-AA-Kriterien bleiben Pflicht; Diagramme oder Farbe tragen nie allein Bedeutung.
  *Text, keyboard, focus and applicable WCAG 2.2 AA criteria are mandatory; diagrams or colour never carry essential meaning alone.*
- **CR-003:** Nutzertexte und Nachweise sind DE-first/EN-second, CEFR B2, mit erklärten Begriffen und ohne vorausgesetzte Spec-Kit-Erfahrung.
  *User-facing text and proof are German-first/English-second, CEFR B2, with defined terms and no assumed Spec Kit knowledge.*
- **CR-004:** Der ursprüngliche Specify-Lauf umfasste Spezifikation, Qualitätscheckliste, Feature-Zeiger und Statistikledger. Agentenguidance, Vorlagen, Verfassung und Serienartefakte bleiben unverändert.
  *The original Specify run covered the spec, quality checklist, feature pointer and ledger; shared guidance, templates, constitution and series remain unchanged.*
  Die aktuelle Dokumentennachprüfung darf zusätzlich vorhandene Planungsdateien und deren Checkliste korrigieren; der bereits korrekte Feature-Zeiger wird nicht geändert. Dies erweitert weder Produktumfang noch Ausführungsrechte.
  *The current document recheck may also correct existing design files and their checklist; retain the already correct feature pointer. This extends neither product scope nor execution authority.*
- **CR-005:** C# ist speichersicher. Sichere Eingaben, Deserialisierung, Datei-I/O und nicht offenlegende Fehlertexte bleiben erforderlich; Speichersicherheit ersetzt diese nicht.
  *C# is memory-safe; secure input, deserialisation, file I/O and safe errors remain required.*
- **CR-006:** NIST SSDF und CWE Top 25 gelten; die Governance-Matrix unten benennt Anwendbarkeit, Grenzen und Nachweispfade.
  *SSDF and CWE Top 25 apply; the matrix below states applicability, limits and evidence paths.*
- **CR-007:** ASVS-Level ist `N/A`: lokale TUI, kein Web/API/HTTP-/Auth-Dienst. Neue Dienste lösen Neubewertung aus.
  *ASVS level is N/A for the local TUI without web/API/HTTP/auth services; new services trigger reassessment.*
- **CR-008:** SBOM, bedingtes VEX und SLSA-Herkunft bleiben für spätere verteilbare Artefakte gebunden; dieser Specify-Lauf erzeugt kein Release und keinen neuen Produktnachweis.
  *SBOM, conditional VEX and SLSA provenance apply to later distribution; Specify produces neither a release nor new product proof.*
- **CR-009:** KI ist Entwicklungswerkzeug, keine Produkt-Runtime; Produkt-AI-SBOM ist begründet `N/A`, bei KI-Integration neu zu prüfen.
  *AI is development tooling, not product runtime; product AI-SBOM is N/A unless runtime AI is introduced.*
- **CR-010:** Bestehende Eingabe-, Datei-, Terminal-/Framework- und Evidenzgrenzen müssen bei der späteren Umsetzung geprüft werden; diese Spezifikation ist kein ausgeführter Nachweis. Keine neue native Brücke, Cloud-, Remote- oder Servicearchitektur wird beschlossen.
  *Review input, file, terminal/framework and evidence boundaries during future implementation; this specification is not executed evidence and approves no native bridge, cloud, remote or service architecture.*
- **CR-011:** Spätere A11Y-/Security-/Architekturnachweise verwenden `docs/accessibility/`, `docs/security/` und `docs/architecture/`. Anforderungen hier sind kein ausgefüllter Produktprüfnachweis.
  *Later evidence uses the existing accessibility, security and architecture locations; requirements here are not completed product verification.*
- **CR-012:** Die acht Basis-Presets plus installierte Intake-/Assurance-Regeln gelten; Installation erteilt keine autonome oder parallele Ausführungsfreigabe.
  *The eight baseline presets and installed intake/assurance rules apply without autonomous or parallel execution authority.*
- **CR-013:** Genau eine Documentation-Impact-Entscheidung gilt: `UpdateRequired`; Leserpfade, Grenzen und Quellen sind unten benannt.
  *The single Documentation Impact decision is UpdateRequired; reader paths, boundaries and sources follow below.*
- **CR-014:** Plattformnachweise binden Commit, Binary, Befehl, Plattform/Runner, Exit-Code bei Automation und vorhandene Payload-/Decision-SHA-256. Teilnachweise dürfen keinen Voll-Pass behaupten. Zero-write-Verifikationen sind getrennt von ausdrücklich vorgesehenen synthetischen Dateiaktionen zu belegen.
  *Platform proof binds commit, binary, command, runner/platform, automated exit status and applicable payload/decision hashes. Partial proof is not a complete pass. Distinguish zero-write verification from explicitly intended synthetic file operations.*

### Verbindliche Regressions- und Impact-Matrix / Binding Regression and Impact Matrix

| Impact-Klasse / Impact class | Unveränderte Pflicht / Preserved obligation |
|---|---|
| NoFunctionalImpact | Vertragsdrift und betroffene Dokumentationsvalidatoren; DocFX-Inhalt zusätzlich DocFX/axe/lynx / drift and affected docs checks; DocFX content also requires generation/axe/lynx |
| FunctionalImpact | Vollständiger aktiver automatisierter Produktvertrag auf jedem PR/Push, Linux und Windows / complete active automated contract on every PR/push, Linux and Windows |
| A11yImpact | FunctionalImpact plus vollständiges A11Y-Intake, macOS-PTY und VoiceOver / functional proof plus the entire intake, macOS PTY and VoiceOver |
| TestInfrastructureImpact | Vollständige Matrix und Erkennung von Testschwächung / full matrix and detection of weakened tests |
| ReleaseCloseout | Funktion/A11Y, DocFX/axe/lynx, macOS-PTY/VoiceOver, Linux-/Windows-CI auf demselben Commit / all functional, accessibility, docs and platform proof on one commit |

Größere TUI-, Formel-, Datei-, Hilfe-, Dependency-, Rename- und Releaseänderungen, Dependency-Drift und unsicherer Impact verlangen mindestens `FunctionalImpact + A11yImpact`. Reine Textänderung ohne TUI-/DocFX-Wirkung verlangt keine wiederholte native VoiceOver-Sitzung. Die Specify-Dateien sind Anforderungsarbeit, kein ausgeführter Produktlauf; ihre Qualitätsprüfung schließt kein Produktgate.

Abgrenzung „größere TUI-Änderung“: Größer ist jede Änderung, die Fokusreihenfolge, Default-Aktion, Beschriftung oder Rolle eines Steuerelements, Dialogaufbau, Tastaturbelegung, Menü-/Palettenstruktur, Status-/Meldungstext mit Zustandsbedeutung, Farben/Kontrast, Terminalinitialisierung/-rücksetzung oder die Terminal.Gui-Nutzung betrifft. Nicht größer sind Änderungen ohne Laufzeitwirkung auf die TUI, zum Beispiel Kommentare, Tests ohne Produktcodeänderung oder Tippfehlerkorrekturen in Dokumentation außerhalb der Laufzeithilfe. Inhaltliche Änderungen an `CALC.HLP` sind Hilfeänderungen und damit mindestens `FunctionalImpact + A11yImpact`. Bleibt die Einordnung zweifelhaft, gilt der unsichere Impact.

*Major TUI, formula, file, help, dependency, rename and release changes, dependency drift and uncertain impact require at least functional plus accessibility proof. Text-only work without TUI/DocFX effects does not repeat native VoiceOver. Specify artefacts are requirements work, not an executed product run; spec quality does not close product gates.*

*A major TUI change is any change affecting focus order, default action, control labels or roles, dialog structure, key bindings, menu/palette structure, status or message text that conveys state, colours/contrast, terminal initialisation/restoration or Terminal.Gui usage. Changes without runtime TUI effect, such as comments, tests without product-code changes or documentation typo fixes outside runtime help, are not major. Content changes to CALC.HLP are help changes and therefore require at least functional plus accessibility impact. Doubtful classifications count as uncertain impact.*

### Schlüsselobjekte und Ergebniszustände / Key Entities and Result States

- **Vertragsweg:** stabile ID, Kontext, Aktion/Alias, Vorzustand, erlaubte Datenänderung, Fokusziel, Erfolgs-/Abbruch-/Fehlererwartung, Plattform und Quellenanker.
- **A11Y-Nachweis:** Vertragsweg und A11Y-ID, Prüfart, Umgebung, tatsächliche Beobachtung, Erwartung, Ergebnis, Commit-/Binary-/Quellbindung, Reviewer und Zeitpunkt.
- **Impact-Entscheidung:** Änderungsumfang, Klasse, Pflichtgates, Begründung und Trigger für Wiederholung.
- **Befund:** berichtete oder reproduzierte Beobachtung, Auswirkung, offene Ursache und weiterführende Evidenz; keine automatische Serienpromotion.

*A contract path records identity, context, action/alias, state, allowed changes, focus, expectations, platform and source. Accessibility evidence adds actual observation, expected result, environment, evidence type, outcome, version bindings, reviewer and time. Impact decisions select required gates with rationale and repetition triggers. Findings distinguish reported and reproduced behaviour without automatically changing the series.*

Ergebnisse heißen `Pass`, `Fail`, `Open` oder `Incomplete`: Pass benötigt tatsächlich ausgeführten, vollständig gebundenen Nachweis für den genannten Umfang; Fail einen beobachteten Widerspruch; Open fehlende Prüfung/Entscheidung; Incomplete eine begonnene, nicht abschließend bewertbare Prüfung. N/A ist eine begründete Anwendbarkeitsentscheidung mit Trigger, kein Pass. Bericht → Reproduktion → verifizierter Nachweis sind verschiedene Evidenzstufen. Fehlende Informationen werden nicht ergänzt, als wären sie beobachtet worden.

*Pass requires an executed, complete and bound proof for the stated scope; Fail records an observed contradiction; Open means missing execution or decision; Incomplete means execution without a conclusive assessment. N/A is a justified applicability decision with a trigger, not a pass. Reported, reproduced and verified evidence are distinct levels; never invent missing observations.*

## Erfolgskriterien / Success Criteria

### Messbare Ergebnisse und Rückverfolgbarkeit / Measurable Outcomes and Traceability

Die acht Intake-Abnahmen bleiben unverändert. Die Tabelle ordnet jede der zehn Anforderungen einer Abnahme und einem unabhängig prüfbaren Nutzerablauf zu; spätere Einzel-ID-/Plattformmatrizen dürfen keine Pflicht entfernen.

*Preserve all eight intake acceptance criteria. Every requirement maps to acceptance and an independently testable journey below; later path/platform matrices must not remove obligations.*

| Abnahme / Acceptance | Messbares Ergebnis / Measurable outcome | Anforderungen; Ablauf / Requirements; journey |
|---|---|---|
| AK-A11Y-CALC-01 | 100 % der aktiven Vertragswege per Tastatur erreichbar und mit eindeutigem sichtbarem Text / all active paths keyboard-reachable with clear text | 01, 02, 06, 07, 10; US-001/002 |
| AK-A11Y-CALC-02 | Jeder Dialogausgang erhält korrekten Fokus und ausschließlich erlaubte Datenänderungen; null unbeabsichtigte Teilwirkungen / every dialog exit preserves required focus/data invariants, zero unintended effects | 02, 06, 07; US-002 |
| AK-A11Y-CALC-03 | 100 % der kontextuellen Tasten/Befehle in Hilfe und Status ohne Widerspruch / all contextual keys/commands explained without contradiction | 01, 03; US-003 |
| AK-A11Y-CALC-04 | Migration/aktueller Pin neutral belegt, alle Driftgates ausgelöst, null automatische Upgrades / migration/current pin proven, drift gates triggered, zero automatic upgrades | 04; US-004 |
| AK-A11Y-CALC-05 | Raster, Auswahl, Menü, Dialoge, Status und Nachrichten bestehen anwendbare Kontrast-/Fokus-/Nicht-Farb-Prüfungen / every listed surface passes applicable contrast, focus and non-colour checks | 05, 06; US-001/002 |
| AK-A11Y-CALC-06 | Linux-/Windows-Automation, macOS-PTY und geforderte VoiceOver-Sitzung bestehen auf demselben Commit / all required platform and native reader checks pass on one commit | 07, 08; US-001–004 |
| AK-A11Y-CALC-07 | Geänderte DocFX-Seiten ohne serious/critical axe-Verstoß und mit lynx vollständig verständlich; unvollständige Bewertungen getrennt / changed pages have no serious/critical axe findings and complete text usability; incomplete assessments remain separate | 03, 09; US-003/004 |
| AK-A11Y-CALC-08 | 100 % der alten/neuen aktiven A11Y-IDs bestehen; Build/Unit/Smoke allein kann keinen Abschluss auslösen / all old/new active accessibility IDs pass; build/unit/smoke alone cannot close acceptance | 01–10; US-004 |

### Plattform- und Nachweisvertrag / Platform and Evidence Contract

Je Prüfweg sind Umgebung, tatsächlicher Terminalhost und Version, Shell, Betriebssystem/Build, Paketpin/Locks, Commit, Binary-Version und eingebetteter Commit, Startbefehl, Arbeitsverzeichnis, Terminalgröße, Screenreader und Version/Zustand/Einstellungen, Datum/Zeitzone, Prüfer, Vorzustand/Testdaten, genaue Bedienfolge, vor der Sitzung festgehaltene Erwartung, tatsächliche Beobachtung, Ergebnis und verbleibende Grenzen erforderlich. Bei Automation zusätzlich tatsächlicher Workflow/Job/Runner, Befehl, Exit-Code und zugehörige Hashbindungen. Fehlende Sitzung bleibt Open; eine begonnene Sitzung mit fehlenden Pflichtangaben bleibt Incomplete und kann keinen Pass belegen. Ein beobachteter Widerspruch bleibt als Fail sichtbar, auch wenn andere Angaben fehlen; weitere Nachweislücken separat notieren. Ein neuer Build wird nicht aus einem alten Binary abgeleitet.

*Each path records the real host/version, shell, OS/build, pin/locks, source commit, binary version/embedded commit, command, directory, terminal size, reader version/state/settings, date/time zone, operator, setup/data, steps, expectation recorded before the session, actual observation, result and limits. Automation also records actual workflow/job/runner, command, exit status and relevant hashes. An absent session is Open; a started session missing required fields is Incomplete and cannot pass. Keep observed contradictions visible as Fail even if other fields are missing; record additional evidence gaps separately. An old binary cannot prove a new build.*

Linux und Windows benötigen die vollständige automatisierte Funktions-/A11Y-Matrix. macOS benötigt echte PTY-Bedienpfade und nach Impact die native VoiceOver-Sitzung. Jede Plattform erhält eigene Ergebnisse. Narrator/NVDA sind getrennt zu betrachten; dieses Intake verlangt keinen zusätzlichen pauschalen Windows-Human-Pass. Wenn solche Sitzungen vorliegen, werden sie separat gebunden, nicht aus VoiceOver abgeleitet. Vollständige Braille-Kompatibilität darf ohne tatsächlichen Gerätnachweis nicht behauptet werden; Textbedeutung bleibt Pflicht.

*Linux and Windows require complete automated functional/accessibility coverage; macOS requires real PTY interaction and impact-triggered native VoiceOver. Record each platform independently. Narrator/NVDA evidence is separate; the intake does not add a blanket Windows human-pass requirement. Any such sessions need their own binding, not inference from VoiceOver. Do not claim complete Braille compatibility without actual device evidence; textual meaning remains mandatory.*

Die native VoiceOver-Abnahme verwendet Mac A mit Terminal.app und VoiceOver als Referenz. Die tatsächlich verwendeten Versionen und Einstellungen werden je Prüflauf dokumentiert; diese Festlegung ist kein dauerhafter Versionspin und bestätigt nicht den historischen Host von B01/B02. Prüfungen umfassen 80x24 und 120x40 wie in Feature 006. Mac A bei 120x28 wird als ergänzendes Reproduktionsszenario aus #107 aufgenommen. Ein hilfreicher Zeilenlesemodus belegt Orientierung, nicht automatisch Dialogfokus, Aktionsnamen oder sichere Bestätigung/Abbruch.

*Native VoiceOver acceptance uses Mac A with Terminal.app and VoiceOver as the reference. Record actual versions and settings for each run; this is not a permanent version pin or confirmation of the historical B01/B02 host. Keep baseline 80x24 and 120x40. Add reported Mac A 120x28 as a supplementary reproduction scenario. Useful line reading proves orientation, not automatically dialog focus, action names or safe confirmation/cancellation.*

### Anwendbarkeit von WCAG und Zuständigkeitsgrenzen / WCAG Applicability and Responsibility Boundaries

AK-05 benötigt pro Oberfläche und Zustand die tatsächlich wirksamen Vorder-/Hintergrundfarben, Terminalprofil, Messweg und Kontrastwert. Normaler Text bleibt bei mindestens 4,5:1; 3:1 für große Darstellung ist nur mit belegter Einstufung nach WCAG 1.4.3 zulässig, nicht allein wegen einer vergrößerten Terminalschrift. Erforderliche Nicht-Text-Fokus-/Auswahlindikatoren benötigen nach anwendbarem WCAG 1.4.11 mindestens 3:1 zu angrenzenden Farben. Unkontrollierbare Farben sind eine Nachweislücke, keine bestandene Messung. Das konkretisiert R-05, ohne die Intake-Schwellen oder zulässige begründete Nichtanwendbarkeit zu verändern.

*For acceptance 05, record effective foreground/background colours, terminal profile, measurement method and ratio per surface/state. Normal text retains 4.5:1; the large-text 3:1 exception needs WCAG 1.4.3 classification, not merely user-enlarged terminal fonts. Required non-text focus/selection indicators need applicable WCAG 1.4.11 contrast of 3:1 against adjacent colours. Uncontrolled colours remain an evidence gap, not a passed measurement; intake thresholds and justified applicability remain intact.*

Für TUI gelten die anwendbaren Anforderungen an Tastaturbedienung, Fokusreihenfolge/-sichtbarkeit/-erreichbarkeit, Nicht-Farb-Bedeutung, kontrollierbaren Kontrast, Beschriftung, Kontext, Fehler- und Statusinformation. Für HTML kommen semantische Struktur, Seitensprache, Orientierung, Sprungmöglichkeiten, Link-/Bedienelementnamen und tastaturbedienbare Navigation hinzu. Pro Kriterium und Artefakttyp wird die spätere Evidenzmatrix Anwendbarkeit mit Begründung und Prüfweg festhalten; N/A darf keine inhaltliche Pflicht verbergen. Die Intake-Kontrastschwellen und axe-Abnahmegrenze werden nicht reduziert. Ein automatischer Scan allein ist keine vollständige WCAG-Konformitätsbewertung.

*Applicable TUI requirements cover keyboard use, focus order/visibility/reachability, non-colour meaning, controllable contrast, labels, context, errors and status. HTML also requires semantic structure, page language, orientation, bypass routes, names and keyboard navigation. The later evidence matrix records each criterion and artefact type with rationale and verification. N/A must not hide an obligation. Preserve intake thresholds; an automated scan alone is not full WCAG conformance.*

Kriterienanker aus [WCAG 2.2](https://www.w3.org/TR/WCAG22/), am 12.10.2026 geprüft: TUI-Prüfziele 1.3.1/1.3.2, 1.4.1/1.4.3/1.4.11, 2.1.1/2.1.2, 2.4.3/2.4.7/2.4.11, 3.3.1/3.3.2 und 4.1.2/4.1.3; HTML zusätzlich insbesondere 2.4.1/2.4.2/2.4.4/2.4.6 und 3.1.1/3.1.2. Das sind Zuordnungsanker, keine vollständige AA-Prüfliste. Bei TUI-Name/Rolle/Wert und Statusvermittlung bleibt die reale Terminal-/Screenreader-Kette zu prüfen; fehlende native Semantik darf nicht als erfüllt gelten. Andere A-/AA-Kriterien werden je Oberfläche auf Anwendbarkeit geprüft, nicht pauschal ausgeschlossen.

*WCAG 2.2 criterion anchors above were checked on 12 October 2026. They map TUI interaction and additional HTML concerns, not an exhaustive AA checklist. Evaluate name/role/value and status through the actual terminal/reader chain; missing native semantics are not fulfilled controls. Assess other A/AA criteria for each surface rather than excluding them wholesale.*

TinyCalc verantwortet Bedienkontext, Beschriftung, Rückmeldung, Fokusabläufe und Datenintegrität. Terminal.Gui stellt Widgets, Tastaturpfade und Terminaldarstellung bereit. Der Terminalhost vermittelt Text und plattformspezifische A11Y-Informationen; PowerShell ist Shell, kein Hostnachweis. VoiceOver/Narrator/NVDA vermitteln verfügbare Informationen abhängig von Modus und Einstellungen. Ein internes Widget oder ausgegebener Text ist kein nachgewiesenes natives zugängliches Steuerelement. Terminaltextlesen, tatsächlicher Anwendungsfokus und semantische Steuerelementnavigation werden getrennt beurteilt. Keine Lösung wird allein aus Bibliotheksnamen oder .NET-Version abgeleitet.

*TinyCalc owns context, labels, feedback, focus flows and data integrity. Terminal.Gui supplies widgets, keyboard routes and terminal rendering. The host exposes terminal text and platform accessibility information; PowerShell identifies a shell, not a host. Readers present available information according to mode/settings. A widget object or printed text is not proof of a native accessible control. Assess text reading, application focus and semantic navigation separately. Library names or .NET versions alone do not prove a solution.*

## Annahmen und Abhängigkeiten / Assumptions and Dependencies

### Reihenfolge und Nicht-Ziele / Order and Non-Goals

Migration → vollständige Funktionsabnahme → A11Y → Rename bleibt bindend. `Completed` bezeichnet den dokumentierten Lifecycle, keine allgemeine Fehlerfreiheitszusage. Issue #107 ändert weder diesen Status noch die Reihenfolge. Es darf aber ein neues A11Y-Ergebnis nicht ohne Untersuchung überdecken. Ein während der A11Y-Prüfung bestätigter Funktionsdefekt wird gegen den bestehenden Vertrag behandelt; keine allgemeine Neuentwicklung der Formel-/Tabellenlogik.

*Preserve migration → complete functional acceptance → accessibility → rename. Completed is the documented lifecycle state, not a guarantee of universal correctness. Issue #107 changes neither status nor order, but must not be ignored in new accessibility acceptance. Confirmed functional defects found during accessibility work follow the existing contract; do not redesign spreadsheet/formula logic generally.*

Nicht-Ziele: Migration wiederholen, automatisches Paketupgrade, interner Rename, PL/0-Integration, neue Tiny-Apps, Frameworkwechsel, vorgeschriebene native A11Y-Brücke oder linearer Ersatzmodus, Maus als Haupt-/Alleinbedienweg, ungeprüfte native UI-Automation-/Screenreader-Zusage. Ein separater Implementierungsauftrag ist erforderlich. Dieser Lauf führt keine Produkt-, Produktbuild-, Restore-, Produkttest- oder Screenreader-Sitzung aus und startet keinen Folgeauftrag. Ein lokaler DocFX-HTML-Smoke für den Statistikledger ist ausschließlich Dokumentationsprüfung, keine Produktabnahme.

*Non-goals include repeated migration, automatic package upgrades, rename, PL/0, new Tiny apps, framework replacement, prescribing a native accessibility bridge or linear replacement mode, pointer-primary interaction and untested native automation/reader promises. Implementation requires separate authority. This run performs no product, product build, restore, product test or screen-reader session and starts no follow-up command. Local DocFX HTML smoke for the statistics ledger is documentation verification only, not product acceptance.*

### Issue #107: ergänzende Beobachtungen / Issue #107: Supplementary Observations

Quelle: [Issue #107](https://github.com/hindermath/TinyCalc/issues/107), einschließlich [Zeilenlesen](https://github.com/hindermath/TinyCalc/issues/107#issuecomment-6110251682) und [.NET-/Terminalgrenzen](https://github.com/hindermath/TinyCalc/issues/107#issuecomment-6111810182), read-only gelesen am 12.10.2026. Die Recherche wird als Quellenkontext übernommen, nicht als neue reproduzierte Diagnose oder pauschal verifizierte Frameworkfähigkeit.

*Read the issue and both linked comments read-only on 12 October 2026. Research is supporting source context, not newly reproduced diagnosis or blanket verification of framework capabilities.*

- **B01, berichtet:** VoiceOver aus; zweites Zeichen überschreibt erstes bei Zahl/Text/Formel. Normalen Tippweg getrennt vom Testhelfer mit zusätzlichem `End` untersuchen. Der Helfer ist ein Hinweis auf mögliche Testlücke, keine bestätigte Ursache. Bezug US-002, EDIT-001, R-06/07/10, AK-02/06/08.
- **B02, berichtet:** VoiceOver vor Start per Command+F5 an; zunächst alle Zeilen, bei Eingabe nur Wert; Tab auf OK/Cancel ohne deren Labeltext. Ansagetext, Einstellungen und Wiederholungsumfang fehlen. Bezug US-002/003, R-02/03/06/08, AK-01/02/06.
- **Hilfreicher Leseweg, berichtet:** Control+Option+Pfeil hoch/runter liest laut Thorsten ganze Zeilen und hilft etwas bei Orientierung. Keine Agentenreproduktion und kein allgemeiner Pass; fehlende Aktionsansage bleibt davon unbewiesen.
- **Berichtsumgebung:** Mac A, MacBook Air M2 (2023), Mac14,15, 8 GB; macOS 27.0.1/26A434, pwsh 7.6.6, 120x28, `dotnet run --project ./src/MicroCalc.Tui`, lokale Debug-Ausgabe 1.6.19.117 mit Commit 222fe8c. Terminal.Gui 2.4.17 war der berichtete Pin. Installierte Terminal.app 2.15 bestätigt nicht den tatsächlich verwendeten Host. Diese historischen Angaben sind kein neuer Ausführungsnachweis und kein dauerhafter Versionspin.

*B01 reports overwriting with VoiceOver off; examine ordinary typing separately from a helper-inserted End key, without claiming causality. B02 reports missing action names with VoiceOver enabled before startup; exact speech, settings and repeat count are missing. Reported Control+Option+Up/Down line reading helps orientation but proves neither agent reproduction nor correct action announcements. Reported Mac A environment: MacBook Air M2 (2023), Mac14,15, 8 GB, macOS 27.0.1/26A434, pwsh 7.6.6, 120x28, dotnet run --project ./src/MicroCalc.Tui, Debug 1.6.19.117/222fe8c, Terminal.Gui 2.4.17. Installed Terminal.app 2.15 does not identify the actual host. These are historical inputs, not new execution proof or permanent pins.*

Historische Pass-Ergebnisse behalten ihren tatsächlich geprüften Szenario-, Plattform-, Commit- und Versionsumfang. Sie werden nicht pauschal widerrufen, auf spätere Kandidaten übertragen oder als vollständige Screenreader-/Braille-Kompatibilität ausgegeben. Neue Fail-/Open-/Incomplete-Befunde müssen sichtbar bleiben. Frühere Abnahmeprotokolle werden nicht umgeschrieben.

*Historical passes retain their tested scenario, platform, commit and version scope. Do not revoke them wholesale, transfer them to later candidates or present them as complete reader/Braille compatibility. Keep new failures and gaps visible; do not rewrite earlier acceptance records.*

### Geklärte fachliche Entscheidungen / Resolved Decisions

- **CQ-001 — Referenzumgebung, geklärt am 12.10.2026:** Thorsten wählt Mac A mit Terminal.app und VoiceOver als native Abnahmereferenz. Versionen und Einstellungen werden je Prüflauf dokumentiert; 80x24/120x40 bleiben Pflicht, 120x28 ergänzt die Reproduktion. Der historische Host von B01/B02 bleibt unbestätigt; dies blockiert keinen Bericht, erlaubt aber keine Behauptung vollständiger Reproduktion.
  *Reference environment, resolved on 12 October 2026: Thorsten selects Mac A with Terminal.app and VoiceOver for native acceptance. Record versions and settings per run; retain required 80x24/120x40 and supplementary 120x28. The historical B01/B02 host remains unconfirmed; reporting is allowed, but complete reproduction must not be claimed.*
- **CQ-002 — Fokussierte Aktion, geklärt am 12.10.2026:** Thorsten verlangt, dass VoiceOver beim Fokuswechsel die aktuelle Dialogaktion unmittelbar eindeutig benennt, ohne zusätzliche Leseschritte. Zusätzliche Tastatur-/Lesefolgen oder beliebiges Zeilenlesen sind kein Ersatz. Dialogkontext und sichere Bestätigung/Abbruch bleiben Pflicht; keine technische Lösung oder native Rollenabbildung wird vorgeschrieben.
  *Focused action, resolved on 12 October 2026: Thorsten requires VoiceOver to immediately and unambiguously name the current dialog action on focus change without additional reading steps. Additional keyboard/reading sequences or arbitrary line reading are not substitutes. Dialog context and safe confirmation/cancellation remain required; no technical solution or native role mapping is prescribed.*

Es gibt keine dritte erfundene Pflichtentscheidung. Windows-Human-Sitzungen bleiben zusätzliche getrennte Nachweise, kein automatischer neuer Intake-Umfang. B01/B02-Ursachen sind Untersuchungsbefunde, nicht durch Nutzerwahl festzulegende Fakten. Unbekannte Ergebnisse bleiben Open, bis tatsächliche Prüfung vorliegt.

*Do not invent a third mandatory decision. Windows human sessions are separate additional evidence, not automatic scope expansion. Root causes are investigated facts, not choices determined by user preference. Unknown outcomes stay Open until actually verified.*

## Governance-Anwendbarkeit und Evidenz / Governance Applicability and Evidence

### Security Governance und sichere Architektur / Security Governance and Secure Architecture

Die folgende Matrix dokumentiert Anforderungen dieses Specify-Laufs, keine bestandene Produktprüfung. Owner ist Thorsten; fachliche Dokumentenprüfung erfolgt hier durch den erstellenden Agenten, unabhängiger/menschlicher Produktreview ist nicht ausgeführt. Umsetzung aller zukünftigen Produktnachweise: `Not Assessed`. N/A-Zeilen bleiben ebenfalls `Not Assessed`. Restrisiko ist fehlende spätere Ausführung; Trigger ist die betroffene Umsetzung oder Scope-Änderung. Evidence-Pfade sind ausdrücklich erwartete Ablageorte, nicht neu erzeugte Nachweise.

*This matrix records Specify requirements, not passed product validation. Thorsten owns scope; the author performs document review only, with no independent/human product review executed. Future implementation evidence is Not Assessed, including N/A rows. Residual risk is missing future execution; triggers are implementation or scope changes. Paths identify expected evidence locations, not newly produced proof.*

| Standard / Checkpoint | Anwendbarkeit und Begründung / Applicability and rationale | Evidenzpfad und Wiederprüfung / Evidence path and trigger |
|---|---|---|
| NIST SSDF, CWE Top 25, sichere C#-Erzeugung / secure C# generation | Applicable; Anforderungen, Eingaben, Dateien, sichere Fehlerausgabe und Evidenzintegrität / requirements, boundaries, safe errors and evidence integrity | `docs/security/security-checklist.md`, `docs/security/secure-development/`; vor Produktcode und Review / before code and review |
| MSL | Applicable; C#/.NET bleibt speichersicher, kein Hardwarekonflikt / retained memory-safe C# without hardware conflict | Level-2-Register, diese Spec / registry and this spec; Runtimeänderung / runtime change |
| ASVS | N/A; keine Web/API/HTTP-/Auth-Dienste, kein ASVS-Level / no such services or selected level | `docs/security/asvs-verification.md` als erwarteter Pfad / expected path; neuer Dienst / new service |
| SBOM, SLSA | Applicable für spätere verteilbare/CI-Artefakte, keine Erzeugung in Specify / later distributable/CI artefacts, no generation now | `docs/security/supply-chain-evidence.md`; Release/Build-Lieferung / release or build delivery |
| VEX | Open, falls bekannte relevante Komponentenschwachstelle vorliegt; keine neue Schwachstellenbewertung ausgeführt / conditional on known relevant vulnerabilities, none assessed now | `docs/security/dependency-audit.md`, Supply-Chain-Evidenz; Preflight/Release / preflight or release |
| AI-SBOM | N/A für Produkt, KI nur Entwicklungswerkzeug / product has no runtime AI | Supply-Chain-Evidenz; Modelle/Daten/Inferenz im Produkt / runtime AI introduced |
| STRIDE/CAPEC, arc42 Security | Applicable als Review bestehender Eingabe-/Datei-/Terminal-/Nachweisgrenzen; keine neue Vertrauensgrenze beschlossen / review existing boundaries, no new boundary selected | `docs/security/threat-model.md`, `docs/security/arc42-security.md`; geänderte Daten-/Evidenzflüsse / changed flows |
| ADR / S-ADR | N/A für neue Entscheidung in Specify, keine Architekturentscheidung getroffen / no new architecture choice made now | `docs/architecture/`, `docs/security/adr/`; späterer materieller Entwurf / material design choice |
| Zero Trust | N/A für lokale TUI, keine verteilten oder remote-verwalteten Produktflüsse / local product without distributed or remote-managed flows | `docs/security/zero-trust-applicability.md`; neue Dienste / new services |
| BSI C3A/C5 | N/A für Produkt-/Deploymentänderung dieses Laufs, keine Cloud-Auswahl / no cloud selection or changed deployment | `docs/security/cloud-autonomy-applicability.md`, erwarteter Cloud-Assurance-Pfad / expected assurance path; Provider-/Cloudänderung / provider change |
| OWASP SAMM | Applicable als bestehender langlebiger Prozesskontext, kein Voll-Reassessment in Specify / retained long-lived process context, no full reassessment now | `docs/security/samm-assessment.md`; Befunde und periodisches Review / findings and periodic review |
| Cheat Sheets, Proactive Controls, OpenSSF Scorecard | Applicable als ergänzende sichere Entwicklungs-/OSS-Referenzen, kein neuer Score oder Audit behauptet / supporting secure-development and OSS references, no new audit claim | Security-Checkliste/Dependency-Audit; Umsetzung/Release / implementation or release |

Regulatorische Anwendbarkeit wird ausschließlich über [bestehende Security-Evidenz](../../docs/security/regulatory-applicability.md) geführt. Datierte Einzelstatus zu DS-GVO, KI-VO, CRA, NIS2 und DORA bleiben erhalten; keine neue Rechtsentscheidung oder pauschale N/A-Ausbildungsbefreiung. Produkt, Entwicklungswerkzeuge und mögliche Organisation getrennt betrachten. Unbekannte Rollen/Jurisdiktionen/Pflichten bleiben Open, Owner Thorsten, Neubewertung spätestens bei dortiger Frist oder vor konkreter Markt-/Kunden-/Organisations-, personenbezogener Daten-, KI-Runtime- oder Provideränderung. Die Owner-Entscheidung vom 08.10.2026 hebt das zusätzliche externe qualifizierte Rollen-/Scope-Plan-Gate auf; es wird hier nicht wieder eingeführt. Das ersetzt keine technischen Gates.

*Existing security evidence owns regulatory applicability. Preserve dated individual GDPR, AI Act, CRA, NIS2 and DORA statuses without new legal decisions or blanket educational exemptions. Assess product, tooling and organisation separately. Unknown roles, jurisdictions or duties remain Open, owned by Thorsten, for reassessment by the recorded due date or before concrete scope changes. Preserve the 8 October owner decision removing the added external qualified role/scope planning gate; do not reintroduce it or weaken technical gates.*

Synthetische Tabellen/Dateien verwenden; keine privaten Inhalte oder Secrets in Screenreader-Transkripten, Screenshots, Logs oder Prompts. Neue Telemetrie, Aufzeichnung oder Plattformbrücke ist keine implizite Anforderung. Spätere bestätigte Produktkorrekturen benötigen Rot–Grün–Refactor, mindestens 70 % Changed-Code-Coverage mit Ziel 80 %, sichere Datei-/Eingabepfade, moderate bilinguale Warum-Kommentare und vollständige öffentliche XML-Dokumentation. Für diese reine Specify-Arbeit sind Produkt-TDD, Coverage, API-/XML-Regeneration N/A; Trigger ist Produktcode/API-Änderung.

*Use synthetic data and exclude private content/secrets from transcripts, captures, logs and prompts. No telemetry, recording or platform bridge is implied. Later confirmed product fixes require red–green–refactor, at least 70% changed-code coverage with an 80% target, secure boundaries, moderate bilingual why-comments and complete public XML docs. Product TDD, coverage and API/XML regeneration are N/A for Specify; code/API changes trigger them.*

### Architektur, Plattform, A11Y und Agentenparität / Architecture, Platform, Accessibility and Agent Parity

iSAQB-Architekturkontext ist Applicable: Bedienbarkeit, Datenintegrität und nachweisbare Qualitätsgrenzen betreffen die vorhandene Laufzeitinteraktion, nicht eine neue Architektur. Szenarien US-001–004 formulieren Reiz, Kontext, Antwort und messbare Abnahme. Spätere Evidenz unter `docs/architecture/` beschreibt Verantwortungsgrenzen; neue ADRs erst bei wirklicher Entscheidung. Kein Entwurf von APIs, Modulen, Bridges oder Implementierungsschritten in dieser Spec.

*Architecture context applies to usability, integrity and verifiable quality limits within existing runtime interaction, not a new architecture. The user journeys express context, response and measurable acceptance. Later architecture evidence records responsibilities; add ADRs only for actual choices. This spec designs no APIs, modules, bridges or implementation steps.*

Cross-platform ist Applicable für macOS/Linux/Windows-Nachweise. Neue Skripte, Cmdlets, Manpages, Dry-run-/WhatIf-Semantik sind in diesem Specify-Lauf N/A, weil kein Werkzeug geschaffen oder geändert wird. Sollte spätere Planung ein Skript benötigen, gelten Bash/PowerShell-Parität, Verb-Noun, bilinguale Hilfe und Manpage; dieses Dokument erteilt keinen entsprechenden Bauauftrag. Lokaler sicherer macOS-Nachweis zuerst; fehlende Linux-/Windows-Hosts über getrennte native Proof-Wege im späteren beauftragten Lauf, keine automatische Provideraktion hier.

*Cross-platform evidence applies. New scripts, cmdlets, manpages and preview semantics are N/A now because no tool changes. Any later script design must meet Bash/PowerShell parity, approved Verb-Noun naming, bilingual help and manpage rules, without an implementation assignment here. Start with safe local macOS proof; later authorised native Linux/Windows paths supplement missing hosts. No provider execution now.*

A11Y-Preset ist Applicable für TUI, Hilfen, Status-/Fehlertexte und betroffene Dokumentation. Neue Code-Kommentare sind jetzt N/A, weil kein Code geändert wird; spätere nicht triviale Logik löst die Kommentarprüfung aus. Texte bleiben semantisch gegliedert, mit vollständiger Textalternative für Tabellen und ohne visuelle Alleinbedeutung. Kein neues Mermaid-Diagramm nötig: Reihenfolge und Matrix sind bereits vollständig textuell erklärt; es wird kein Lastenheft erstellt. Ein Feature-Abschlussbericht ist N/A für dieses einzelne Specify-Kommando, Trigger wäre ein vollständig beauftragter Feature-Lauf.

*Accessibility applies to the TUI, help, messages and affected docs. Code-comment review is N/A without code changes and is triggered by later non-trivial logic. Text uses semantic structure without visual-only meaning. A new Mermaid diagram is unnecessary because order and matrices are fully explained in text and no intake is authored. A whole-feature completion report is N/A for a single Specify command.*

Agentenparität: N/A für gemeinsame Änderungen, keine Agentenregel oder Vorlage betroffen. Bei späterem Trigger gemeinsam prüfen: `AGENTS.md`, `CLAUDE.md`, `GEMINI.md`, `.github/copilot-instructions.md`, `.github/agents/copilot-instructions.md`, betroffene `.specify/templates/` und Verfassungsspiegel. Keine beabsichtigte Divergenz.

*Agent parity changes are N/A: no guidance or template changes. If later affected, review all five maintained guidance files, relevant templates and constitution mirrors together. No intentional divergence.*

### Dokumentation und Ausführungsgrenzen / Documentation and Execution Boundaries

**Documentation Impact: `UpdateRequired`.** Jetzt: vorhandene Feature-Spec, Planungsbegleiter, beide Qualitätschecklisten und Statistikledger; der Feature-Zeiger bleibt unverändert. Später innerhalb separat beauftragter Umsetzung: betroffene Laufzeithilfe, Shortcut-Referenz, A11Y-/Security-/Architekturnachweise und gegebenenfalls DocFX/API-Dokumentation. Leserpfad: Serie → Intake → Feature-Spec → Planung/Prüfvertrag → aktiver Produktvertrag → Einzel-ID-/Plattformnachweis; ergänzend Issue #107 → Befund → zugehöriger Vertragsweg. Owner Thorsten, kanonische Scopequelle Intake; Quellenpartner ist jeweils der direkt folgende englische Block. Keine Navigation, README, Laufzeithilfe oder API wird jetzt verändert. Distribution `sourceOnly`, kein Home-sync. Beispiele ausschließlich synthetisch; Proof-Grenzen pro Plattform wie oben. Trigger: Änderungen an Funktion, Hilfe, Pin, Nachweis oder Veröffentlichungsumfang. Statistikdiagramme behalten den letzten commitgebundenen Profil-2-Stand; der Ledger dokumentiert die aktuelle uncommittete Dokumentennachprüfung ohne fingierten Commit. HTML-Smoke des Ledgers ist Dokumentenprüfung, kein HTML-/Produktnachweis der nicht veröffentlichten 007-Quellen.

*Documentation Impact is UpdateRequired. Now: existing spec/design files, both checklists and ledger, with unchanged feature pointer. Later authorised implementation updates help and relevant documentation/evidence. Reader path: series → intake → spec → design/verification contract → active contract → path/platform proof. Thorsten owns scope, the intake is canonical, and English follows German. Change no navigation, README, runtime help or API. Distribution is sourceOnly with no Home sync. Keep generated statistics at their historical source and record the uncommitted document recheck without inventing a commit. Ledger HTML smoke does not prove HTML/product accessibility of unpublished Feature 007 sources.*

Autonomous-/Parallel-Presets sind nur Berechtigungsrahmen. Der ursprüngliche Auftrag war Specify; die aktuelle Freigabe erlaubt allein die Dokumentennachprüfung und Korrektur vorhandener Spezifikations-/Planungsdateien samt Checklisten und Statistikledger. Kein autonomer Lauf und kein DeliveryMode. Neue Run-State-Datei, Mutable Tokens, Delivery-Entscheidung und Causal Closeout sind N/A: kein gestarteter Lauf und keine Lieferung. Unterbrechung erfordert erneute read-only Frischeprüfung vor Fortsetzung, keine stillschweigende Ausführung. Kein Commit, Push, PR, Merge, Admin-Bypass, Intake-/Serienupdate oder nachfolgender Spec-Kit-Befehl. `sheet.mcalc.json` bleibt unberührt.

*Autonomous/parallel presets constrain authority only. The original request was Specify; current authority covers document review and corrections to existing specification/design files, checklists and ledger only. No autonomous execution or delivery mode starts. New run state, mutable tokens, delivery decisions and causal closeout are N/A. Revalidate freshness after interruption; no commit, push, PR, merge, bypass, intake/series changes or subsequent workflow command. Preserve sheet.mcalc.json.*
