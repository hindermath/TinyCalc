<!-- intake-authoring:begin -->
# Lastenheft: Kompilierte PL/0-Zellfunktionen Version 1

**Status:** ReadyForReview  
**Zielgruppe:** Auszubildende ab dem ersten Ausbildungsjahr, Lehrende und TinyCalc-Anwendende  
**Vorausgesetztes Wissen:** Grundlegende Tabellenkalkulation und einfache Programmierbegriffe; Spec-Kit-Erfahrung wird nicht vorausgesetzt  
**Profil:** `level2-lastenheft`  
**Reihenfolge:** Rang 7 nach `Lastenheft_Secure-Development-Hardening.md`; bis zum bestandenen TinyPl0-Liefergate blockiert

*Status: Ready for review. Audience: apprentices from the first training year,
teachers, and TinyCalc users. Basic spreadsheet and programming knowledge is
assumed; no Spec Kit experience is required. This intake is ordered after the
secure-development hardening and remains blocked until the TinyPl0 delivery
gate passes.*

## Begriffe beim ersten Gebrauch / Terms At First Use

### Deutsch

- **PL/0 und Extended-Dialekt:** PL/0 ist eine kleine Lehrsprache. Der
  Extended-Dialekt ergänzt die hier benötigten Ein- und Ausgabeanweisungen
  `?` und `!`, ohne PL/0 zu einer allgemeinen Skriptsprache zu machen.
- **P-Code und virtuelle Maschine (VM):** Der Compiler übersetzt PL/0-Text in
  einfache P-Code-Befehle. Die VM führt diese Befehle kontrolliert aus; sie
  startet keinen nativen Programmcode des Betriebssystems.
- **Reine Zellfunktion und qualifizierter Name:** Eine reine Funktion berechnet
  nur aus ihren Argumenten ein Ergebnis und verändert keine Zelle. Das Präfix
  `PL0.` trennt solche Funktionen eindeutig von eingebauten TinyCalc-Funktionen.
- **`Int32` und `double`:** `Int32` ist der ganzzahlige Wertebereich von
  -2.147.483.648 bis 2.147.483.647. TinyCalc speichert Zellzahlen als `double`,
  also als Gleitkommazahlen; PL/0 übernimmt in Version 1 nur verlustfrei
  umwandelbare Ganzzahlen.
- **Strenges Profil und Profilvalidator:** Das Profil ist eine zusätzliche
  Regelmenge für sicheren PL/0-Zellcode. Der Validator prüft diese Regeln vor
  der Ausführung, zum Beispiel Eingaben am Anfang und genau eine Ausgabe am
  Ende des Hauptblocks.
- **Instruktionsbudget:** eine feste Obergrenze für ausgeführte P-Code-Befehle.
  Sie beendet auch eine Endlosschleife kontrolliert.
- **In-Memory-Cache und Quelltext-Hash:** Ein Cache hält kompilierten P-Code nur
  vorübergehend im Arbeitsspeicher. Der Hash ist ein digitaler Fingerabdruck
  des Quelltexts und verhindert, dass veralteter P-Code verwendet wird.
- **Steppable-Debugger, Register und Stack:** Ein schrittweiser Debugger führt
  jeweils einen VM-Befehl aus. Die Register `P`, `B` und `T` zeigen
  Befehlsposition, Basisadresse und Stackspitze; der Stack enthält die
  Arbeitswerte der VM.
- **I/O und AutoCalc:** I/O bedeutet Ein- und Ausgabe zwischen TinyCalc und der
  VM. AutoCalc berechnet betroffene Zellformeln nach einer Änderung automatisch
  neu.
- **NuGet-Paket, `ProjectReference` und Locked Restore:** NuGet verteilt
  versionierte .NET-Bibliotheken. Eine `ProjectReference` bindet stattdessen
  lokalen Quellcode direkt ein. Locked Restore stellt ausschließlich die in
  der Paket-Lockdatei festgeschriebenen Versionen wieder her.
- **Contract-Test:** ein automatisierter Test an der Grenze zwischen TinyCalc
  und TinyPl0. Er belegt, dass beide Seiten denselben öffentlichen API- und
  Laufzeitvertrag verstehen.
- **Fail-closed und Defense in Depth:** Fail-closed bedeutet, dass fehlende
  oder fehlerhafte Nachweise die Ausführung sperren. Defense in Depth schützt
  zusätzlich durch mehrere voneinander unabhängige Begrenzungen.
- **SBOM und VEX:** Eine SBOM ist eine maschinenlesbare Liste aller Bestandteile
  und Abhängigkeiten. VEX dokumentiert, ob eine bekannte Schwachstelle das
  ausgelieferte Paket tatsächlich betrifft.
- **Provenance und SLSA:** Provenance verbindet ein Paket mit Build,
  Quellcommit und Werkzeugkette. SLSA ist ein Stufenmodell zum Schutz dieser
  Software-Lieferkette.
- **STRIDE und CAPEC:** STRIDE ordnet Bedrohungen in feste Kategorien ein.
  CAPEC beschreibt bekannte Angriffsmuster für eine genauere Risikoanalyse.
- **OpenSSF Scorecard und OWASP SAMM:** Die Scorecard prüft öffentlich
  sichtbare Sicherheitspraktiken eines Open-Source-Repositories. SAMM hilft,
  die Reife des sicheren Entwicklungsprozesses zu bewerten und zu verbessern.

### English

- **PL/0 and extended dialect:** PL/0 is a small teaching language. The
  extended dialect adds the required `?` input and `!` output statements
  without turning PL/0 into a general scripting language.
- **P-Code and virtual machine (VM):** The compiler translates PL/0 source into
  simple P-Code instructions. The VM executes these instructions under
  control; it does not start native operating-system code.
- **Pure cell function and qualified name:** A pure function calculates a
  result only from its arguments and changes no cell. The `PL0.` prefix clearly
  separates these functions from TinyCalc's built-in functions.
- **`Int32` and `double`:** `Int32` is the integer range from -2,147,483,648 to
  2,147,483,647. TinyCalc stores cell numbers as `double` floating-point
  values; version 1 passes only integers that can be converted without loss.
- **Strict profile and profile validator:** The profile is an additional rule
  set for safe PL/0 cell code. The validator checks these rules before
  execution, such as inputs at the start and exactly one output at the end of
  the main block.
- **Instruction budget:** a fixed upper limit for executed P-Code
  instructions. It also stops an endless loop in a controlled way.
- **In-memory cache and source hash:** A cache keeps compiled P-Code only
  temporarily in memory. The hash is a digital fingerprint of the source and
  prevents the use of stale P-Code.
- **Steppable debugger, registers, and stack:** A step debugger executes one VM
  instruction at a time. Registers `P`, `B`, and `T` show the instruction
  position, base address, and stack top; the stack contains the VM's working
  values.
- **I/O and AutoCalc:** I/O means input and output between TinyCalc and the VM.
  AutoCalc automatically recalculates affected cell formulas after a change.
- **NuGet package, `ProjectReference`, and locked restore:** NuGet distributes
  versioned .NET libraries. A `ProjectReference` directly includes local
  source instead. Locked restore restores only the versions recorded in the
  package lock file.
- **Contract test:** an automated test at the boundary between TinyCalc and
  TinyPl0. It proves that both sides understand the same public API and runtime
  contract.
- **Fail-closed and defense in depth:** Fail-closed means missing or invalid
  evidence blocks execution. Defense in depth adds several independent
  safeguards.
- **SBOM and VEX:** An SBOM is a machine-readable inventory of all components
  and dependencies. VEX records whether a known vulnerability actually
  affects the delivered package.
- **Provenance and SLSA:** Provenance links a package to its build, source
  commit, and toolchain. SLSA is a maturity model for protecting this software
  supply chain.
- **STRIDE and CAPEC:** STRIDE groups threats into fixed categories. CAPEC
  describes known attack patterns for more detailed risk analysis.
- **OpenSSF Scorecard and OWASP SAMM:** Scorecard checks publicly visible
  security practices of an open-source repository. SAMM helps assess and
  improve the maturity of the secure development process.

## Zweck / Purpose

TinyCalc soll benannte PL/0-Programme als kompilierte, reine Zellfunktionen
verwenden können. Eine Formel wie `PL0.RABATT(A1,B1)` wertet ihre Argumente
zuerst im Arbeitsblatt aus, führt danach begrenzten P-Code aus und übernimmt
genau einen Ganzzahlwert als Ergebnis. Ein barrierefreier Editor und ein
schrittweiser Debugger gehören bereits zu Version 1.

*TinyCalc shall use named PL/0 programs as compiled, pure cell functions. A
formula such as `PL0.RABATT(A1,B1)` first evaluates its worksheet arguments,
then executes bounded P-Code, and accepts exactly one integer result. An
accessible editor and a step debugger are part of version 1.*

## Aktueller Zustand / Current State

- TinyCalc wertet Zahlen, Zellreferenzen und eingebaute Funktionen direkt als
  `double` aus.
- Der Formelparser unterstützt keinen qualifizierten Namensraum für
  benutzerdefinierte Funktionen und keine allgemeine Mehrargument-Schnittstelle.
- Arbeitsblattdateien speichern Zellen und AutoCalc, aber keinen Funktionskatalog
  und keine explizite Formatversion.
- TinyCalc verwendet Terminal.Gui 1.19; die TinyPl0-IDE verwendet Terminal.Gui
  2.0 und ist nicht als wiederverwendbare UI-Bibliothek aufgebaut.
- TinyPl0 stellt Compiler und VM als .NET-10-Projekte bereit, aber noch nicht
  über die für dieses Intake geforderten öffentlichen NuGet-Pakete.

*TinyCalc currently evaluates numbers, cell references, and built-in functions
as `double`. It has no qualified user-function namespace, worksheet function
catalog, or explicit file-format version. TinyPl0 provides compiler and VM
projects, but not yet the public NuGet delivery required here.*

## Zielzustand / Target State

- Jedes Arbeitsblatt kann einen eigenen Katalog benannter PL/0-Funktionen
  enthalten.
- Zellformeln rufen diese Funktionen ausschließlich als
  `PL0.<Funktionsname>(<Argumente>)` auf.
- Version 1 verwendet ausschließlich die Integer-Semantik von TinyPl0 und ein
  statisch geprüftes TinyCalc-PL/0-Profil.
- TinyCalc kompiliert Quellcode, führt ihn innerhalb fester Ressourcen- und
  Abbruchgrenzen aus und bietet Compile-, Test- und Step-Debug-Abläufe in der
  TUI an.
- Der PL/0-Code hat keinen direkten Zugriff auf Zellen, Dateien, Netzwerk,
  Prozesse oder andere Betriebssystemressourcen.

*Each worksheet can contain named PL/0 functions. Calls use the
`PL0.<name>(<arguments>)` syntax, retain TinyPl0 integer semantics, follow a
statically checked TinyCalc profile, and execute within fixed resource limits.
PL/0 code has no direct access to cells or operating-system resources.*

## Umfang / Scope

- Konsum der öffentlichen Pakete `TinyPl0.Core` und `TinyPl0.Vm` in derselben
  fest gepinnten stabilen Version.
- Formelparser-Erweiterung für qualifizierte PL/0-Namen und mehrere Argumente.
- Arbeitsblattbezogener Funktionskatalog mit Name, geordneten Parametern und
  kanonischem PL/0-Quellcode.
- Strenger Profilvalidator, Compilerintegration, Laufzeitadapter und
  kontrollierte Fehlerabbildung.
- JSON-Formatversion 2 mit rückwärtskompatiblem Laden bisheriger Dateien.
- Barrierefreier Funktionsmanager, mehrzeiliger Editor, Compilerdiagnosen,
  Testlauf und Steppable-Debugger.
- Unit-, Integrations-, Persistenz-, TUI-Smoke-, Sicherheits- und
  A11Y-Nachweise sowie zweisprachige Lern- und API-Dokumentation.

*Scope includes pinned public packages, formula parsing, a worksheet function
catalog, strict profile validation, bounded execution, JSON version 2, an
accessible editor and debugger, and complete test and documentation evidence.*

## Nicht-Ziele / Non-Goals

- Keine Dezimal-, Gleitkomma- oder Festkommaerweiterung der PL/0-VM.
- Keine Tabellenmakros und keine PL/0-Schreibzugriffe auf beliebige Zellen.
- Kein globaler, arbeitsblattübergreifender Funktionskatalog.
- Kein JIT-, CLR-, nativer oder anderer P-Code-fremder Ausführungspfad.
- Keine Einbettung oder Kopie der TinyPl0-IDE.
- Keine lokale `ProjectReference` auf ein benachbartes TinyPl0-Repository und
  kein stiller Paket-Fallback.
- Keine Speicherung von P-Code als kanonische Wahrheit im Arbeitsblatt.

*Version 1 adds no decimal VM, spreadsheet macros, global catalog, alternate
execution backend, embedded TinyPl0 IDE, local project-reference fallback, or
canonical persisted P-Code.*

## Funktionale Anforderungen / Functional Requirements

- **FR-001:** Funktionsnamen müssen ohne Beachtung der Groß-/Kleinschreibung
  eindeutig sein und in Formeln über `PL0.<Name>(...)` aufgelöst werden.
- **FR-002:** Eine Definition muss einen Namen, eine geordnete Liste eindeutiger
  PL/0-Parameterbezeichner und den vollständigen Quellcode speichern.
- **FR-003:** Der Formelparser muss null oder mehr komma-getrennte Argumentausdrücke
  parsen, jeden Ausdruck vor dem VM-Aufruf auswerten und bestehende
  Zykluserkennung beibehalten.
- **FR-004:** Jedes PL/0-Argument muss endlich, mathematisch ganzzahlig und im
  `Int32`-Bereich sein; andere Werte müssen ohne VM-Start fehlschlagen.
- **FR-005:** Das strenge Profil muss den Extended-Dialekt verwenden. Im
  Hauptblock müssen genau so viele `? ident`-Anweisungen wie deklarierte
  Parameter als zusammenhängender Anweisungsanfang stehen und dieselben
  Bezeichner in derselben Reihenfolge verwenden.
- **FR-006:** Das Profil muss genau eine `! expression`-Anweisung als letzte
  ausführbare Anweisung des Hauptblocks verlangen. Weitere Ein- oder Ausgaben,
  insbesondere in Prozeduren, sind unzulässig.
- **FR-007:** Prozeduren, Bedingungen und Schleifen bleiben zulässig, sofern sie
  die I/O-Regeln einhalten; das Instruktionsbudget schützt zusätzlich vor
  Endlosschleifen.
- **FR-008:** Profil-, Lexer- und Compilerdiagnosen müssen stabilen Code, Zeile,
  Spalte und eine verständliche deutschsprachige Meldung liefern; die
  englische Dokumentation muss die gleiche Bedeutung abdecken.
- **FR-009:** Erfolgreich kompilierter P-Code darf nur als verwerfbarer
  In-Memory-Cache mit Bindung an den Quelltext-Hash verwendet werden.
- **FR-010:** Jede Quelltextänderung muss alten P-Code sofort ungültig machen.
  Ein fehlerhafter Entwurf darf gespeichert, aber niemals ausgeführt werden.
- **FR-011:** Ein Lauf muss genau einen VM-Ausgabewert akzeptieren. Fehlende,
  zusätzliche oder nicht verbrauchte Ein-/Ausgaben müssen als Funktionsfehler
  erscheinen.
- **FR-012:** Die VM-Ausgabe muss verlustfrei als `double` in die bestehende
  Zellwertdarstellung übernommen werden.
- **FR-013:** Der Funktionsmanager muss Funktionen anlegen, auswählen,
  bearbeiten, kompilieren, mit Ganzzahlargumenten testen und sicher entfernen
  können; bestehende Referenzen müssen vor einer destruktiven Änderung
  textuell kenntlich gemacht werden.
- **FR-014:** Der Debugger muss Initialisieren, Einzelschritt, begrenztes
  Fortsetzen, Anhalten und Zurücksetzen unterstützen sowie aktuelle
  Instruktion, Register `P`, `B`, `T`, Stack, I/O und Instruktionszahl
  textorientiert anzeigen.
- **FR-015:** Kompilieren allein darf keinen Code ausführen. Test- und
  Debug-Ausführung müssen ausdrücklich gestartet werden.
- **FR-016:** Das JSON-Format 2 muss Quellcode und Metadaten, aber keinen
  P-Code oder VM-Zustand speichern. Dateien ohne Formatversion werden als
  bisheriges Format geladen.
- **FR-017:** Nach Laden oder Funktionsänderung muss AutoCalc alle betroffenen
  Formeln neu bewerten; ein Fehler darf keinen veralteten kompilierten Code
  verwenden.

*The functional contract covers qualified case-insensitive names, ordered
parameters, strict integer conversion, leading main-block inputs, one trailing
main-block output, no procedure I/O, source-bound compilation cache, exactly
one result, an accessible editor and step debugger, and backward-compatible
source-only persistence.*

## Verbindliches TinyPl0-Liefergate / Binding TinyPl0 Delivery Gate

Vor jeder TinyCalc-Implementierung müssen zwei Stufen erfolgreich sein:

1. **Liefernachweis:** Das TinyPl0-Intake ist abgeschlossen; Release-Tag und
   Quellcommit sind dokumentiert; `TinyPl0.Core` und `TinyPl0.Vm` liegen in
   derselben stabilen Version auf NuGet.org vor; SBOM-, VEX- und
   Provenance/SLSA-Evidenz ist verlinkt.
2. **Technischer Preflight:** `dotnet restore --locked-mode` stellt die exakt
   gepinnte Version wieder her; keine lokale `ProjectReference` ist vorhanden;
   Contract-Tests belegen Compile, Run, Step, Instruktionslimit, Abbruch und
   strukturierte Diagnosen.

Review, Spezifikation und Planung dürfen vorher vorbereitet werden. Ein
Implementierungs- oder autonomer Lauf muss jedoch vor Änderungen stoppen,
solange eine Gate-Stufe fehlt. Es gibt keinen lokalen Fallback.

*The binding gate requires completed TinyPl0 release evidence and a successful
locked package/API preflight. Review and planning may be prepared earlier, but
implementation must stop before any change while either stage is incomplete.
No local fallback is allowed.*

## Qualität und Governance / Quality And Governance

- C#/.NET 10 bleibt die speichersichere Hauptlaufzeit. Eingaben an den Grenzen
  JSON, Formel, PL/0-Quelle, P-Code und VM-I/O werden validiert.
- NIST SSDF und CWE Top 25 gelten immer. STRIDE und relevante CAPEC-Muster
  müssen die Ausführung nicht vertrauenswürdiger Arbeitsblattprogramme prüfen.
- Defense in Depth besteht mindestens aus strengem Profil sowie unabhängigem
  Instruktions-, Stack-, I/O- und Abbruchlimit. Fehlerpfade sind fail-closed.
- OWASP ASVS ist `N/A`, weil TinyCalc kein Web-, HTTP-, API- oder
  Authentifizierungssystem ist. Zero Trust ist für die lokale TUI `N/A`.
- SBOM und SLSA sind für das verteilbare TinyCalc-Artefakt anwendbar; VEX wird
  bei bekannten Schwachstellen gepflegt. AI-SBOM ist `N/A`, weil KI nur als
  Entwicklungswerkzeug eingesetzt wird.
- OpenSSF Scorecard und OWASP SAMM werden als ergänzende Supply-Chain- und
  Reifegradnachweise berücksichtigt.
- TUI, Diagnosen, Hilfen und Debugansichten erfüllen die anwendbaren Kriterien
  von WCAG 2.2 AA. Bedeutung darf nie nur durch Farbe oder Fokusrahmen entstehen.
- Lerninhalte und didaktische Kommentare stehen deutsch zuerst und englisch
  danach auf CEFR-B2-Niveau. Begriffe, Status, Abhängigkeiten und nächste
  Aktionen werden bei der ersten Verwendung textuell erklärt.

*The quality boundary applies NIST SSDF, CWE Top 25, STRIDE/CAPEC, defense in
depth, fail-closed execution, SBOM/VEX/SLSA, WCAG 2.2 AA, and bilingual CEFR-B2
delivery. ASVS, Zero Trust, and AI-SBOM are not applicable for the stated local
non-AI product scope and must be recorded with that rationale.*

## Abhängigkeiten und Risiken / Dependencies And Risks

- Interner Vorgänger: `Lastenheft_Secure-Development-Hardening.md`.
- Externer harter Vorgänger: TinyPl0
  `Lastenheft_Embeddable-VM-und-NuGet.md` einschließlich öffentlichem Release.
- Die Terminal.Gui-Migration, Umbenennung, TUI-A11Y und Kommentarhärtung liegen
  durch die bestehende Serienkette bereits vor diesem Intake.
- Risiken sind blockierende oder bösartige Programme, API-Drift, Paket-Tausch,
  Ganzzahlüberlauf, veralteter P-Code, schwer erkennbare Diagnosezustände und
  Tastatur-/Screenreader-Barrieren.
- Der Paket- und Quelltext-Hash sowie Contract-Tests bilden die technische
  Handoff-Grenze zwischen beiden Repositories.

*Dependencies include the internal security baseline and the completed public
TinyPl0 package release. Main risks are hostile programs, API or supply-chain
drift, integer boundaries, stale code, unclear diagnostics, and accessibility
barriers.*

## Erwartete Artefakte und Evidenz / Expected Artifacts And Evidence

- Funktionskatalog, Resolver, Profilvalidator und VM-Hostadapter in TinyCalc Core.
- JSON-Migration und rückwärtskompatible Persistenztests.
- TUI-Funktionsmanager und Steppable-Debugger mit Smoke- und A11Y-Nachweisen.
- Unit-, Integrations-, Grenzwert-, Abbruch-, Zyklus- und Fehlertests.
- Aktualisierte XML-Dokumentation, Lernhilfe, Architektur- und
  Sicherheitsdokumente unter `docs/security/`.
- Paket-Lockdatei, TinyPl0-Release-/SBOM-/VEX-/SLSA-Verweise und bestandener
  Cross-Repo-Contract-Test.
- Aktualisierte DocFX-Ausgabe mit Playwright/axe- und lynx-orientierter
  Textprüfung, sofern DocFX-Inhalte geändert werden.
- Aktualisierte Projektstatistik nach den Repository-Regeln.

*Evidence includes implementation, persistence and contract tests, accessible
TUI proof, security documentation, locked package provenance, DocFX/A11Y proof
where applicable, and updated project statistics.*

## Abnahmekriterien / Acceptance Criteria

- **AC-001:** Das zweistufige TinyPl0-Gate ist vollständig belegt; ohne Nachweis
  startet keine TinyCalc-Implementierung.
- **AC-002:** `PL0.RABATT(A1,B1)` liefert für dokumentierte Ganzzahlfälle das
  erwartete Ergebnis und nimmt keine Änderungen außerhalb der Zielzelle vor.
- **AC-003:** Dezimalwerte, Nicht-Endlichkeit, `Int32`-Überlauf sowie falsche
  Ein-/Ausgabeanzahl erzeugen reproduzierbare Diagnosen ohne VM-Absturz.
- **AC-004:** Profiltests lehnen nicht führende Eingaben, Prozedur-I/O,
  zusätzliche Ausgaben und eine nicht abschließende Ausgabe statisch ab.
- **AC-005:** Endlosschleifen, Stacküberlauf und Abbruch enden innerhalb der
  dokumentierten Grenzen mit strukturiertem Fehlerzustand.
- **AC-006:** Der Step-Debugger zeigt nach jedem Schritt konsistente Register,
  Stack, Instruktion, I/O und Zähler; Halt und Fehler erlauben keinen weiteren
  unbeabsichtigten Schritt.
- **AC-007:** Ein geänderter oder fehlerhafter Entwurf kann niemals alten
  P-Code ausführen.
- **AC-008:** Format-1-Dateien laden unverändert; Format-2-Dateien erhalten
  Quellcode und Funktionsmetadaten über Save/Load-Rundreisen.
- **AC-009:** Automatisierte Core-, TUI-, Sicherheits- und A11Y-Prüfungen laufen
  auf den verbindlichen Plattformen erfolgreich.
- **AC-010:** Dokumentation, Security-Evidenz, Paketnachweise und Statistik sind
  aktuell, zweisprachig und textorientiert prüfbar.

*Acceptance proves the package gate, pure integer calculation, strict-profile
rejection, bounded execution, consistent stepping, no stale-code fallback,
backward-compatible persistence, cross-platform tests, and complete evidence.*

## Annahmen und Entscheidungen / Assumptions And Decisions

- **IAD001 – beantwortet:** Zwei Intakes wurden mit dem genehmigten Vorschlag
  `tinycalc-pl0-v1-split-v1` und SHA-256
  `f36a20d34be1c682821321dd0b1a0c8d2a5c44b6ffbfaf54c77daa027868a10d`
  freigegeben.
- **IAD002 – beantwortet:** Das zweistufige Gate und das Verbot einer lokalen
  `ProjectReference` als Fallback wurden ausdrücklich genehmigt.
- Delivery Authority bleibt `LocalImplementation`; das Intake erteilt keine
  Commit-, Push-, PR-, Merge-, Paketveröffentlichungs- oder Bypass-Berechtigung.
- Es bestehen keine offenen fachlichen Intake-Fragen.

*The approved decisions bind the two-intake split and the two-stage fail-closed
gate. Delivery authority remains local implementation, and no material intake
questions remain open.*

<!-- intake-authoring:prompts -->
## Ausführbare Spec-Kit-Prompts / Copy-Ready Spec Kit Prompts

<!-- spec-kit-command-id: speckit.specify -->
### Specify

```text
$speckit-specify Nutze requirements/intakes/active/Lastenheft_PL0-Zellfunktionen_V1.md als verbindliches Intake. Prüfe zuerst beide Stufen des TinyPl0-Liefergates und dokumentiere fehlende Evidenz als Blocker. Erstelle oder aktualisiere ausschließlich die passende Feature-Spezifikation. Bewahre Scope, Nicht-Ziele, Reihenfolge, strenges PL/0-Profil, NuGet-Vertrag, Security-, A11Y-, Dokumentations- und Evidenzgrenzen. Implementiere nichts; committe und pushe nicht; erstelle oder merge keinen Pull Request und starte kein weiteres Feature.
```

<!-- spec-kit-command-id: speckit.autonomous -->
### Autonomous

```text
$speckit-autonomous Führe genau einen vollständigen autonomen Spec-Kit-Lauf mit requirements/intakes/active/Lastenheft_PL0-Zellfunktionen_V1.md als verbindlichem Intake aus. Delivery Mode: LocalImplementation. Prüfe vor jeder Änderung das zweistufige TinyPl0-Liefergate und stoppe fail-closed, wenn Release-, NuGet-, SBOM-/VEX-/SLSA-, Locked-Restore- oder Contract-Test-Evidenz fehlt. Bewahre Scope, Reihenfolge, strenges PL/0-Profil, Security-, A11Y-, Dokumentations- und Evidenzgrenzen. Nutze keine lokale ProjectReference als Fallback. Nicht pushen, keinen Pull Request erstellen oder mergen, keine Pakete veröffentlichen, keinen Bypass nutzen, keine Secrets offenlegen und kein Folgefeature starten.
```

<!-- intake-authoring:end -->
