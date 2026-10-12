# TinyCalc · TinyEdit · TinyDB

## Deutsch

### Status und Verantwortung

Stand: 12. Oktober 2026. **Produktidee – nicht normativ, keine Ausführungsfreigabe.**
Konzeptverantwortung: Thorsten.

Dieses Dokument hält den abgestimmten Konzeptstand fest. Das
[Diskussions-Issue #108](https://github.com/hindermath/TinyCalc/issues/108)
sammelt weitere Überlegungen als Kommentare. Eine Diskussion ändert dieses
Dokument nicht automatisch; neue Entscheidungen werden ausdrücklich abgestimmt.

### Gemeinsame Richtung

Die bewusst klassische Kombination aus Tabellenkalkulation, Texteditor und
Karteiverwaltung bildet eine kleine Lernwerkzeugfamilie. Die Programme sollen
im bestehenden Repository gebündelt werden, aber jeweils separat startbar sein.
Verwandte Tastaturbedienung und kleine, nachvollziehbare Abläufe sollen Lernenden
der vier IHK-IT-Berufe ab dem ersten Ausbildungsjahr helfen, Funktionsweise
und Quellcode zu verstehen. Erklärungen und Lernmaterialien richten sich nach
CEFR B2: Fachbegriffe werden eingeführt und an kleinen Beispielen erklärt.
Das ist keine vollständige Office-Suite und kein Versprechen einer bestimmten
Prüfungs- oder Lehrplanabdeckung. Der Repository-Name bleibt unverändert.

Die gemeinsame TUI-Basis ist Terminal.Gui wie bei TinyCalc. Diese Richtung
legt keine dauerhafte Paketversion oder neue gemeinsame UI-Bibliothek fest.
Die Familie bleibt auf drei eigenständige Programme begrenzt; PowerShell
ergänzt den Zugang zur Fachlogik, ist aber keine vierte App.

### Programmkerne

- **TinyCalc:** Tabellen, Formeln und Berechnungen; das bestehende Programm ist
  der Ausgangspunkt der Familie. Seine Anforderungen bleiben maßgeblich.
- **TinyEdit:** TUI-Editor für Markdown, JSON, YAML, INI und PL/0-Quelltext,
  keine grafische Textverarbeitung mit Seitenlayout. Öffnen, Bearbeiten und
  Speichern bilden den Kern. Formatspezifische Hilfen bleiben auszugestalten.
  Eine kleine TinyPl0-IDE ist eine mögliche spätere Ausbaustufe: Kompilieren,
  Ausführen, schrittweise Ausführung und verständliche Diagnosen, nicht der
  Anspruch einer vollständigen professionellen Entwicklungsumgebung.
- **TinyDB:** dBASE-artige Datenhaltung und Bearbeitung mit genau einer Tabelle
  pro Datei, einschließlich Felddefinitionen und Datensätzen. Tabellenansicht
  und Datensatzmaske bilden die Bedienrichtung. Mehrtabellenverwaltung und
  Beziehungen gehören nicht zum Einstieg. DBF-Kompatibilität oder eine
  dBASE-Programmiersprache werden nicht zugesagt.

### TinyDB-Speicherung und Lernvertiefungen

Gewünscht ist ein dokumentiertes, menschenlesbares Speicherformat. JSON ist
der bevorzugte Vorschlag, noch keine beschlossene Formatentscheidung. Eine
Datei könnte Felddefinitionen und Datensätze gemeinsam enthalten und mit
TinyEdit untersucht werden; ein konkreter Dateivertrag bleibt offen.
CSV-Import/-Export und ein Vergleich mit binärer Speicherung beziehungsweise
DBF bleiben mögliche spätere Lernvertiefungen, keine zusätzlichen Pflicht-
Backends. Der Vergleich könnte Header, Feldbeschreibungen, Zeichencodierung
und Datensatzlängen erklären. Die dBASE-artige Bedienung hängt nicht von DBF ab.

### PowerShell als Automatisierungs- und Lernzugang

Cmdlets sollen dieselben Fachmodelle ohne TUI bedienen: TinyCalc-Sheets und
TinyDB-Tabellen beziehungsweise Datensätze erstellen, lesen, bearbeiten und
speichern; bei TinyCalc außerdem Berechnungen auslösen. TinyPl0-Kompilierung
und begrenzte VM-Ausführung gehören ebenfalls zur Konzeptrichtung. Konkrete
Befehlsnamen, Parameter und Modulpaketierung bleiben späteren Spezifikationen
vorbehalten. Dies ist weder eine neue Paketabhängigkeit noch eine Umsetzung.

Provider sollen einen navigierbaren Zugang zu Zellen und Datensätzen bieten.
Ein Provider stellt Daten über PowerShell-Pfade dar; ein Cmdlet führt eine
benannte Aufgabe aus. Pfade, unterstützte Schreiboperationen und der Zeitpunkt
der Speicherung bleiben offen. Ein PL/0-Provider, etwa für Symbole oder
Instruktionen, ist nur eine lose Forschungsoption.

Für TinyEdit werden keine eigenen Cmdlets allein der Vollständigkeit halber
festgelegt. Formatspezifische Prüfung oder Konvertierung sind höchstens spätere
Ergänzungen; vorhandene PowerShell-Dateibefehle sind ein möglicher Einstieg.

Lernende sollen TUI und Automation am selben Fachmodell vergleichen können:
Objekte statt bloßer Bildschirmtexte, die Pipeline zur Weitergabe von Objekten,
Eingabeprüfung sowie die Trennung von Oberfläche, Fachlogik und Speicherung.
Textorientierte Hilfe und verständliche Fehler gelten auch für PowerShell;
Vorschau und Bestätigung bei Änderungen sind spätere Vertragsfragen. CEFR B2
und WCAG 2.2 AA soweit anwendbar bleiben die Basis. PowerShell ersetzt keine
native TUI-/Screenreader-Prüfung.

### PL/0: bestehende Grundlage und neue Erweiterung

Die PL/0-Integration in TinyCalc ist bereits im verbindlichen
[PL/0-Lastenheft](https://github.com/hindermath/TinyCalc/blob/main/requirements/intakes/active/Lastenheft_PL0-Zellfunktionen_V1.md)
vorgesehen, nicht nur eine unverbindliche Integrationsidee. Die wiederverwendbaren
Komponenten sind bereits als NuGet-Pakete geliefert: `TinyPl0.Core` und
`TinyPl0.Vm`. Das Lastenheft dokumentiert den erfüllten Liefernachweis für
[Release v0.4.1](https://github.com/hindermath/TinyPl0/releases/tag/v0.4.1).
Dies ist keine feste Versionsvorgabe für die spätere Integration.

Davon getrennt bleiben TinyCalcs technischer Preflight und Implementierung
noch offen; die bestehenden Gates werden nicht aufgehoben. Die Nutzung dieser
Komponenten durch TinyEdit ist die neue Konzeptrichtung. Sie ist noch nicht
implementiert und legt keine neue gemeinsame UI-Bibliothek fest.

### Lernen an kleinen Anwendungen

Die Familie soll Prinzipien größerer Anwendungen an überschaubaren Beispielen
zeigen: TinyCalc für Zellmodelle, Formeln und Berechnungen; TinyEdit für Texte,
strukturierte Dateien und kleine Programme; TinyDB für Datensätze, Tabellen
und Masken. Lernende können Datenfluss, Eingabeprüfung, Speicherung und die
Trennung von Bedienung und Fachlogik nachvollziehen.

Ein möglicher Lernweg beginnt beim Bearbeiten und Speichern einer kleinen
Datei, führt zu strukturierten Daten und später zu einem PL/0-Programm.
Das ist ein didaktischer Vorschlag, kein neuer Lieferplan. Berufsspezifische
Vertiefungen und konkrete Unterrichtseinheiten bleiben offen.

### Vorschläge und offene Entscheidungen

Ein späterer Einstieg mit TinyEdit ist ein Vorschlag, keine beschlossene
Reihenfolge. Für TinyDB sind beispielsweise Suchen, Filtern und Sortieren
mögliche Ausbauschritte, noch kein Funktionsvertrag.

Offen bleiben DBF-Kompatibilität, genaue Speicher- und Austauschformate,
gemeinsame Bibliotheken und konkrete Lernziele je Beruf. Gemeinsame
Bausteine sind nur eine Möglichkeit; Wiederverwendung soll nicht vor einer
nachgewiesenen gemeinsamen Aufgabe zu zusätzlicher Komplexität führen.
Es gibt noch keinen Zeitplan, keine Versionszusage und keine Architekturfreigabe.

### Barrierefreiheit und Nachweisgrenzen

Die [A11Y- und Eingabebefunde in Issue #107](https://github.com/hindermath/TinyCalc/issues/107)
bleiben ein wichtiger Ausgangspunkt. Zeilenweises Vorlesen kann bei der
Orientierung helfen, belegt aber keine verständliche Fokus- oder Buttonansage.
Die Grenzen zwischen Anwendung, Terminal.Gui, Terminalhost und Screenreader
müssen bei einer späteren Untersuchung getrennt betrachtet werden.

Dieses Konzept behauptet weder allgemeine Barrierefreiheit noch geprüfte
VoiceOver-/Narrator-Kompatibilität. Die Terminal.Gui-Richtung ersetzt keine
tatsächlichen Nachweise für die betrachteten Plattformen und Hilfsmittel.
Die Konzeptdokumentation bleibt textorientiert und deutsch/englisch lesbar.
WCAG 2.2 Level AA ist die Ziel- und Prüfbasis, soweit Kriterien anwendbar sind.
Für die native TUI sind zusätzliche plattform- und screenreaderspezifische
Nachweise erforderlich; eine HTML-Prüfung ersetzt sie nicht.

### Unveränderte Abarbeitung und möglicher späterer Schritt

Die laufende Lastenheft-Abarbeitung, ihre Reihenfolge und ihre Gates bleiben
unverändert. Diese Dokumentation erzeugt keine neuen Intakes, Features,
Projekte, Abhängigkeiten oder Implementierungsaufträge. Sie startet weder
TinyEdit noch TinyDB und ändert weder Produktcode noch Framework.

Falls Thorsten die Idee später weiterverfolgen möchte, werden Umfang,
Lernziele und Priorität gesondert entschieden. Erst danach käme ein eigener
Intake in Betracht. Dieses Dokument und Issue #108 sind keine blockierende
Abhängigkeit der bestehenden Serie.

## English

### Status and ownership

Updated: 12 October 2026. **Product idea – non-normative, not an execution approval.**
Concept owner: Thorsten.

This document records the agreed concept. The
[discussion issue #108](https://github.com/hindermath/TinyCalc/issues/108)
collects further ideas in comments. A discussion does not automatically change
this document; new decisions need explicit agreement.

### Shared direction

The deliberately classic combination of spreadsheet, text editor and card-file
manager forms a small family of learning tools. The programs are intended to
share the existing repository, but each should start independently.
Related keyboard controls and small, clear workflows should help trainees in
the four IHK IT professions understand the behaviour and source code from
their first training year. Explanations and learning materials target CEFR B2:
technical terms are introduced and explained through small examples.
This is not a complete office suite or a promise to cover a particular exam
or curriculum. The repository name remains unchanged.

The shared TUI foundation is Terminal.Gui, as used by TinyCalc. This direction
defines neither a permanent package version nor a new shared UI library. The
family stays limited to three independent programs; PowerShell adds access
to domain logic, but is not a fourth app.

### Program cores

- **TinyCalc:** tables, formulas and calculations; the existing program is the
  starting point for the family. Its requirements remain authoritative.
- **TinyEdit:** a TUI editor for Markdown, JSON, YAML, INI and PL/0 source,
  not a graphical word processor with page layout. Opening, editing and saving
  form the core. Format-specific support remains to be defined. A small TinyPl0
  IDE is a possible later extension: compilation, execution, stepping and clear
  diagnostics, without aiming for a full professional development environment.
- **TinyDB:** dBASE-style data storage and editing with exactly one table per
  file, including field definitions and records. A table view and record form
  define the interaction direction. Multi-table management and relationships
  are not part of the introduction. DBF compatibility or a dBASE programming
  language are not promised.

### TinyDB storage and learning extensions

A documented, human-readable storage format is the desired direction. JSON is
the preferred proposal, not an agreed format decision. One file could hold
field definitions and records together and be inspected with TinyEdit; a
concrete file contract remains open. CSV import/export and a comparison with
binary storage or DBF remain possible later learning extensions, not additional
required storage backends. The comparison could explain headers, field
descriptions, character encoding and record lengths. dBASE-style interaction
does not depend on DBF.

### PowerShell as an automation and learning access path

Cmdlets should operate on the same domain models without the TUI: create,
read, edit and save TinyCalc sheets and TinyDB tables or records, and trigger
TinyCalc calculations. TinyPl0 compilation and bounded VM execution are also
part of the concept direction. Command names, parameters and module packaging
remain for later specifications. This adds no package dependency or implementation.

Providers should offer navigable access to cells and records. A provider
exposes data through PowerShell paths; a cmdlet performs a named task. Paths,
supported write operations and when data is saved remain open. A PL/0 provider,
for example for symbols or instructions, is only a loose research option.

No TinyEdit cmdlets are defined merely for completeness. Format-specific
validation or conversion are at most later additions; existing PowerShell file
commands are a possible starting point.

Trainees should compare TUI and automation using the same domain model:
objects rather than screen text, the pipeline for passing objects, input
validation, and separation of interface, domain logic and storage. Text-oriented
help and clear errors also apply to PowerShell; previews and confirmation for
changes are later contract questions. CEFR B2 and WCAG 2.2 AA wherever applicable
remain the baseline. PowerShell does not replace native TUI/screenreader checks.

### PL/0: existing foundation and new extension

TinyCalc's PL/0 integration is already defined in the binding
[PL/0 requirements](https://github.com/hindermath/TinyCalc/blob/main/requirements/intakes/active/Lastenheft_PL0-Zellfunktionen_V1.md),
not merely a non-binding integration idea. Reusable components have already
been delivered as NuGet packages: `TinyPl0.Core` and `TinyPl0.Vm`. The intake
records the satisfied delivery gate for
[release v0.4.1](https://github.com/hindermath/TinyPl0/releases/tag/v0.4.1).
This is not a fixed version requirement for the later integration.

Separately, TinyCalc's technical preflight and implementation remain open;
existing gates are not waived. Using these components in TinyEdit is the new
concept direction. It is not implemented and defines no new shared UI library.

### Learning through small applications

The family should show principles of larger applications through small examples:
TinyCalc for cell models, formulas and calculations; TinyEdit for text,
structured files and small programs; TinyDB for records, tables and forms.
Trainees can follow data flow, input validation, storage and the separation of
user interaction from domain logic.

One possible learning path starts with editing and saving a small file,
continues with structured data and later reaches a PL/0 program. This is a
teaching proposal, not a new delivery plan. Profession-specific extensions
and specific teaching units remain open.

### Proposals and open decisions

Starting later with TinyEdit is a proposal, not an agreed sequence. Searching,
filtering and sorting in TinyDB are possible extensions, not a function contract.

DBF compatibility, exact storage and exchange formats, shared libraries and
specific learning objectives for each profession remain open.
Shared components are only an option; reuse should not add complexity before
a real shared task has been demonstrated. There is no schedule, version
commitment or architecture approval yet.

### Accessibility and evidence limits

The [accessibility and input findings in issue #107](https://github.com/hindermath/TinyCalc/issues/107)
remain an important starting point. Reading lines can support orientation,
but does not prove clear focus or button announcements. A later investigation
needs to distinguish the application, Terminal.Gui, terminal host and screenreader.

This concept claims neither general accessibility nor tested VoiceOver/Narrator
compatibility. The Terminal.Gui direction does not replace actual evidence for
the platforms and assistive tools under consideration. The concept documentation
remains text-oriented and readable in German and English.
WCAG 2.2 Level AA is the target and review baseline wherever criteria apply.
The native TUI needs additional platform- and screenreader-specific evidence;
HTML checks do not replace that evidence.

### Unchanged delivery sequence and possible later step

The current requirements work, its order and gates remain unchanged. This
documentation creates no new intakes, features, projects, dependencies or
implementation assignments. It starts neither TinyEdit nor TinyDB and changes
neither product code nor framework.

If Thorsten wants to pursue the idea later, scope, learning objectives and
priority will be decided separately. Only then could a separate intake be
considered. This document and issue #108 are not blocking dependencies of the
existing series.
