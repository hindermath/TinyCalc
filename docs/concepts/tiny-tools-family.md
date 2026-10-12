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
der vier IHK-IT-Berufe helfen, Funktionsweise und Quellcode zu verstehen.
Das ist keine vollständige Office-Suite und kein Versprechen einer bestimmten
Prüfungs- oder Lehrplanabdeckung. Der Repository-Name bleibt unverändert.

### Programmkerne

- **TinyCalc:** Tabellen, Formeln und Berechnungen; das bestehende Programm ist
  der Ausgangspunkt der Familie. Seine Anforderungen bleiben maßgeblich.
- **TinyEdit:** einfache Klartextbearbeitung in einer TUI, keine grafische
  Textverarbeitung mit Seitenlayout. Öffnen, Bearbeiten und Speichern sind der
  gedachte Kern; weitere Funktionen werden erst später festgelegt.
- **TinyDB:** klassische dBASE-artige Bedienung mit Tabellen und Masken für
  einzelne Datensätze, als überschaubare Karteiverwaltung. Die Bedienidee ist
  keine Zusage von DBF-Kompatibilität oder einer dBASE-Programmiersprache.

### Vorschläge und offene Entscheidungen

Ein späterer Einstieg mit TinyEdit ist ein Vorschlag, keine beschlossene
Reihenfolge. Für TinyDB sind beispielsweise Suchen, Filtern und Sortieren
mögliche Ausbauschritte, noch kein Funktionsvertrag.

Offen bleiben DBF-Kompatibilität, Speicher- und Austauschformate, gemeinsame
Bibliotheken, Frameworkwahl und konkrete Lernziele je Beruf. Gemeinsame
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
VoiceOver-/Narrator-Kompatibilität. Eine spätere Frameworkentscheidung braucht
tatsächliche Nachweise für die betrachteten Plattformen und Hilfsmittel.
Die Konzeptdokumentation bleibt textorientiert und deutsch/englisch lesbar.

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
the four IHK IT professions understand the behaviour and source code.
This is not a complete office suite or a promise to cover a particular exam
or curriculum. The repository name remains unchanged.

### Program cores

- **TinyCalc:** tables, formulas and calculations; the existing program is the
  starting point for the family. Its requirements remain authoritative.
- **TinyEdit:** simple plain-text editing in a TUI, not a graphical word
  processor with page layout. Opening, editing and saving form the proposed
  core; further functions will be defined later.
- **TinyDB:** classic dBASE-style interaction with tables and forms for
  individual records, as a small card-file manager. This interaction idea
  does not promise DBF compatibility or a dBASE programming language.

### Proposals and open decisions

Starting later with TinyEdit is a proposal, not an agreed sequence. Searching,
filtering and sorting in TinyDB are possible extensions, not a function contract.

DBF compatibility, storage and exchange formats, shared libraries, framework
choice and specific learning objectives for each profession remain open.
Shared components are only an option; reuse should not add complexity before
a real shared task has been demonstrated. There is no schedule, version
commitment or architecture approval yet.

### Accessibility and evidence limits

The [accessibility and input findings in issue #107](https://github.com/hindermath/TinyCalc/issues/107)
remain an important starting point. Reading lines can support orientation,
but does not prove clear focus or button announcements. A later investigation
needs to distinguish the application, Terminal.Gui, terminal host and screenreader.

This concept claims neither general accessibility nor tested VoiceOver/Narrator
compatibility. A later framework decision needs actual evidence for the
platforms and assistive tools under consideration. The concept documentation
remains text-oriented and readable in German and English.

### Unchanged delivery sequence and possible later step

The current requirements work, its order and gates remain unchanged. This
documentation creates no new intakes, features, projects, dependencies or
implementation assignments. It starts neither TinyEdit nor TinyDB and changes
neither product code nor framework.

If Thorsten wants to pursue the idea later, scope, learning objectives and
priority will be decided separately. Only then could a separate intake be
considered. This document and issue #108 are not blocking dependencies of the
existing series.
