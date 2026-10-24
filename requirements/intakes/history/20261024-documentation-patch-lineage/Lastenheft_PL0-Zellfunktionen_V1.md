<!-- intake-authoring:begin -->
# Lastenheft: Kompilierte PL/0-Zellfunktionen Version 1

## Lesehilfe und Workflow / Reading Guide and Workflow

Deutsch: Grundlegende Tabellen-, Datei- und Tastaturbedienung genügt zum Einstieg;
Spec-Kit- oder Security-Erfahrung wird nicht vorausgesetzt. Ein Intake legt den
Umfang fest. `Specify` erstellt nur `spec.md` (Anforderungen), `plan.md` beschreibt
den Lösungsweg und `tasks.md` einzelne Schritte. `Autonomous` führt einen separat
beauftragten Lauf aus. `LocalImplementation` erlaubt lokale Arbeit, keine
Veröffentlichung. `Eligible` bezeichnet einen Kandidaten, keine Startfreigabe.
Ein Receipt ist ein Herkunftsnachweis; Evidence ein prüfbarer Beleg und ein Hash
ein Inhaltsfingerabdruck. Preflight bedeutet Vorprüfung, Gate eine Prüfschranke.

Deutsch: Secure Coding schützt Codepfade, Secure Architecture ihre
Vertrauensgrenzen (Trust Boundaries). Eine MSL ist eine speichersichere Sprache,
ersetzt aber keine Eingabeprüfung. I/O heißt Ein-/Ausgabe, Auth Anmeldung und
Berechtigung, Crypto Kryptografie. Eine Sandbox begrenzt Prozesszugriffe;
Mounts stellen Host-Dateien bereit, Tokens sind Zugriffsschlüssel, Caches
Zwischenspeicher. SBOM listet Software, AI-SBOM KI-Komponenten, VEX die
Betroffenheit von bekannten Schwachstellen, SLSA Build-Herkunft und Integrität.
NIST SSDF beschreibt sichere Entwicklung, CWE Fehlerarten, STRIDE Bedrohungen,
CAPEC Angriffsmuster, ASVS Web-Prüfungen, Zero Trust Zugriffe ohne stilles
Vertrauen, SAMM Security-Reife und Scorecard OSS-Sicherheitspraktiken. C3A/C5
betreffen Cloud-Autonomie/Nachweise. WCAG AA ist die anwendbare A11Y-Basis;
CEFR B2 bezeichnet verständliche Sprache. CI automatisiert Prüfungen, DocFX
erzeugt Dokumentation, axe prüft Barrieren und lynx liest Seiten als Text.
Ein Lockfile fixiert Abhängigkeiten. Diese Erläuterungen erweitern den Umfang nicht.

English: Basic spreadsheet, file and keyboard use is enough to begin. Prior
Spec Kit/security experience is not assumed. The intake defines scope. Specify
creates only spec.md (requirements), plan.md describes the approach and tasks.md
lists work steps. Autonomous executes a separately requested run.
LocalImplementation permits local work, not publication. Eligible identifies a
candidate, not start permission. A receipt records provenance; evidence is
verifiable proof and a hash a content fingerprint. Preflight means preliminary
check; a gate is a mandatory checkpoint.

English: Secure coding protects code paths, secure architecture their trust
boundaries. An MSL is memory-safe but still needs validation. I/O means input/output,
Auth authentication/authorization and Crypto cryptography. A sandbox limits
process access; mounts expose host files, tokens are access keys and caches
store intermediate results. SBOM inventories software, AI-SBOM AI components,
VEX vulnerability impact and SLSA build origin/integrity. NIST SSDF covers secure
development, CWE weaknesses, STRIDE threats, CAPEC attack patterns, ASVS web
verification, Zero Trust access without implicit trust, SAMM security maturity
and Scorecard OSS practices. C3A/C5 concern cloud autonomy/assurance. WCAG AA is
the applicable A11Y baseline; CEFR B2 the readability level. CI automates checks,
DocFX generates documentation, axe checks accessibility and lynx reads pages as
text. A lockfile fixes dependencies. These explanations add no scope or authority.


**Status:** ReadyForReview
**Zielgruppe:** Auszubildende ab dem ersten Ausbildungsjahr, Lehrende und TinyCalc-Anwendende
**Vorausgesetztes Wissen:** Grundlegende Tabellenkalkulation und einfache Programmierbegriffe; Spec-Kit-Erfahrung wird nicht vorausgesetzt
**Profil:** `level2-lastenheft`
**Reihenfolge:** Nach `Lastenheft_Secure-Development-Hardening.md`; die exakte
Rangnummer wird aus der jeweils gültigen Intake-Serie abgeleitet. Bis zum
bestandenen TinyPl0-Liefergate bleibt dieses Intake blockiert.

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
- **Repository-gepinnte Version und Dependency-Drift:** Eine gepinnte Version
  ist im Repository ausdrücklich festgelegt und reproduzierbar. Dependency-
  Drift bedeutet, dass sich diese Festlegung seit der letzten Abnahme geändert
  hat und deshalb erneut geprüft werden muss.
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
- **Repository-pinned version and dependency drift:** A pinned version is
  explicitly selected in the repository and can be restored reproducibly.
  Dependency drift means this selection changed since the last acceptance and
  therefore requires renewed validation.
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
- Die konkrete Terminal.Gui-Version ist ein datierter Repository-Iststand und
  keine zeitlose PL/0-Anforderung. Vor Spezifikation und Implementierung muss
  die dann im Repository ausdrücklich gepinnte und freigegebene Version samt
  Deklarations- und Lockquelle ermittelt werden.
- Die TinyPl0-IDE ist nicht als wiederverwendbare UI-Bibliothek aufgebaut und
  wird unabhängig von ihrer dann aktuellen TUI-Abhängigkeit nicht eingebettet.
- TinyPl0 hat den zugehörigen Liefer-Intake abgeschlossen. Der stabile Release
  `v0.4.1` stellt `TinyPl0.Core` und `TinyPl0.Vm` versionsgleich öffentlich auf
  NuGet.org bereit. Diese nachgewiesene Lieferung ist noch kein TinyCalc-Pin;
  die freigegebene Integrationsversion wird erst im technischen Preflight
  ausgewählt und festgeschrieben.
- Seit dem 6. Oktober 2026 verwendet der Homogenitätsworkflow den fest
  gepinnten GitHub-Hosted-Runner `macos-15`. Produkt-Build und Produkttests
  bleiben auf Linux und Windows; Requirements-Intake-Governance verwendet
  weiterhin `macos-latest`. Erfolgreiche Hosted-CI belegt nur die ausgeführten
  Jobs und ersetzt keine native TUI-, PTY- oder A11Y-Produktabnahme.

*TinyCalc currently evaluates numbers, cell references, and built-in functions
as `double`. It has no qualified user-function namespace, worksheet function
catalog, or explicit file-format version. The concrete Terminal.Gui version is
a dated repository snapshot, not a permanent PL/0 requirement. TinyPl0 has
completed the corresponding delivery intake. Stable release `v0.4.1` provides
matching public `TinyPl0.Core` and `TinyPl0.Vm` packages on NuGet.org. This
evidenced delivery is not yet a TinyCalc pin; the approved integration version
is selected and locked only by the technical preflight. Since 6 October 2026,
the homogeneity workflow pins GitHub-hosted `macos-15`; product build and tests
remain on Linux and Windows, while requirements-intake governance retains
`macos-latest`. Passing hosted CI proves only the jobs that ran, not native TUI,
PTY, or accessibility product acceptance.*

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

- Konsum der öffentlichen Pakete `TinyPl0.Core` und `TinyPl0.Vm` in derselben,
  zum Ausführungszeitpunkt ausdrücklich ausgewählten und fest gepinnten
  stabilen Version.
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
2. **Technischer Preflight:** Die aktuellen Repository-Deklarationen bestimmen
   die freigegebenen, exakt gepinnten TinyPl0- und Terminal.Gui-Versionen.
   `dotnet restore --locked-mode` stellt sie reproduzierbar wieder her; keine
   lokale `ProjectReference` ist vorhanden; Contract-Tests belegen Compile,
   Run, Step, Instruktionslimit, Abbruch und strukturierte Diagnosen.

### Gate-Status am 3. September 2026 / Gate Status On 3 September 2026

- **Stufe 1 - Erfüllt:** TinyPl0-Release
  [`v0.4.1`](https://github.com/hindermath/TinyPl0/releases/tag/v0.4.1) ist an
  Quellcommit `edab567e1e7cd3ea8eb8e3bea425b54f24d4b506` gebunden. Der
  [Release-Lauf 33757534918](https://github.com/hindermath/TinyPl0/actions/runs/33757534918)
  hat Paketbau, SBOM-, VEX- und Provenienz-Eingaben, Attestierung, paarweise
  Veröffentlichung sowie den öffentlichen NuGet-only-Consumer erfolgreich
  abgeschlossen. `TinyPl0.Core` und `TinyPl0.Vm` sind versionsgleich als
  stabile Pakete auf NuGet.org verfügbar.
- **Stufe 2 - Offen:** TinyCalc hat noch keine Integrationsversion ausgewählt
  oder gepinnt und noch keinen Locked Restore, Driftentscheid oder
  Cross-Repo-Contract-Test für Compile, Run, Step, Instruktionslimit, Abbruch
  und strukturierte Diagnosen ausgeführt. Der interne Vorgänger
  `Lastenheft_Secure-Development-Hardening.md` bleibt ebenfalls blockierend.
- `0.4.1` ist der nachgewiesene Lieferkandidat, aber keine zeitlose normative
  Versionsvorgabe. Der spätere Preflight muss die dann freigegebene Version
  aus den aktuellen Repository-Deklarationen bestimmen.

*Stage 1 is satisfied: TinyPl0 release `v0.4.1` is bound to source commit
`edab567e1e7cd3ea8eb8e3bea425b54f24d4b506`. Release run `33757534918`
successfully completed package creation, SBOM, VEX and provenance input,
attestation, paired publication, and the public NuGet-only consumer. Stage 2
remains open: TinyCalc has not selected or pinned an integration version and
has not run locked restore, drift classification, or the cross-repository
contract tests. The internal secure-development predecessor also remains
blocking. Version `0.4.1` is the evidenced delivery candidate, not a permanent
normative integration pin.*

### CI- und Plattformnachweis am 6. Oktober 2026 / CI And Platform Evidence On 6 October 2026

- [TinyCalc PR 99](https://github.com/hindermath/TinyCalc/pull/99) migrierte
  die fest gepinnten macOS-14-Jobs auf `macos-15`. Der Merge-Commit
  `09156155a571d94e29a2cd27c3d568f0fbcecc7a` ist an den geprüften PR-Head
  `4e039ba36598312ad25da0dfb85e4c60e2b500c6` gebunden.
- Nur tatsächlich ausgelöste, am exakten Commit erfolgreiche Jobs zählen als
  CI-Nachweis. Required-Check-Namen, Runner-Labels und die ausgeführte Matrix
  werden vor der PL/0-Lieferung erneut gegen die aktuellen Workflows geprüft.
- Die Runner-Migration ändert weder die erfüllte TinyPl0-Lieferstufe noch
  Paketversion, Produktplattformen oder PL/0-Scope. Native TUI-, PTY-,
  VoiceOver- und weitere A11Y-Nachweise bleiben eigene Feature-Gates.

*TinyCalc PR 99 moved explicitly pinned macOS 14 jobs to `macos-15`. Merge
commit `09156155a571d94e29a2cd27c3d568f0fbcecc7a` is bound to reviewed PR head
`4e039ba36598312ad25da0dfb85e4c60e2b500c6`. Only jobs that actually ran and
passed on the exact commit count as CI evidence. Required-check names, runner
labels, and the executed matrix must be rechecked before PL/0 delivery. This
runner migration changes neither the satisfied TinyPl0 delivery stage nor the
package version, product platforms, or PL/0 scope. Native TUI, PTY, VoiceOver,
and other accessibility evidence remain separate feature gates.*

Der Preflight klassifiziert Terminal.Gui als `Unchanged`, `DependencyDrift`
oder `Unpinned`. `DependencyDrift` verlangt erneute Build-, vollständige TUI-,
PTY- und A11Y-Prüfung. `Unpinned` blockiert fail-closed. Der Preflight führt
kein automatisches Upgrade durch. Die aufgelösten Versionen, ihre Quelle und
der Lockfile-Hash werden als Evidence festgehalten.

Review, Spezifikation und Planung dürfen vorher vorbereitet werden. Ein
Implementierungs- oder autonomer Lauf muss jedoch vor Änderungen stoppen,
solange eine Gate-Stufe fehlt. Es gibt keinen lokalen Fallback.

*The binding gate requires completed TinyPl0 release evidence and a successful
locked package/API preflight. The preflight resolves the currently approved
repository pins, classifies UI dependency drift, records the version sources
and lock hash, and never performs an automatic upgrade. Review and planning
may be prepared earlier, but implementation must stop before any change while
either stage is incomplete. No local fallback is allowed.*

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
- Die vollständige TUI-Funktionsabnahme ist der verbindliche
  Produktvertrags-Vorgänger. TUI-A11Y, Umbenennung und Kommentarhärtung liegen
  durch die bestehende Serienkette ebenfalls vor diesem Intake.
- PL/0 ergänzt vor jeder Produktänderung neue `PL0-*`-Vertrags-IDs; sämtliche
  bis dahin aktiven IDs bleiben Pflichtregression.
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
- Dependency-Preflight mit aufgelösten TinyPl0- und Terminal.Gui-Versionen,
  Deklarationsquellen, Lockfile-Hash und Driftklassifikation.
- Exact-Head-CI-Nachweis mit den tatsächlich ausgeführten Jobnamen,
  Runner-Labels und Plattformen; native TUI-/PTY-/A11Y-Abnahme wird getrennt
  ausgewiesen und nicht aus einem grünen Hosted-Runner abgeleitet.
- Aktualisierter maschinenlesbarer Produktvertrag mit neuen `PL0-*`-IDs und
  vollständiger Regression aller bisherigen aktiven IDs.
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
  auf den verbindlichen Plattformen am exakten Commit erfolgreich. Der Nachweis
  nennt tatsächlich ausgeführte Jobs, Runner-Labels und Plattformen; Hosted-CI
  ersetzt keine erforderliche native TUI-, PTY- oder A11Y-Abnahme.
- **AC-010:** Dokumentation, Security-Evidenz, Paketnachweise und Statistik sind
  aktuell, zweisprachig und textorientiert prüfbar.
- **AC-011:** Der Dependency-Preflight erkennt unveränderte, geänderte und
  ungepinnte Terminal.Gui-Zustände korrekt; Drift löst die vollständigen
  TUI-/PTY-/A11Y-Gates aus und kein Pfad führt selbstständig ein Upgrade durch.
- **AC-012:** Alle neuen `PL0-*`-IDs und alle zuvor aktiven Vertrags-IDs
  bestehen auf demselben Commit; kein PL/0-Pfad schwächt bestehende TUI-,
  Datei-, Formel-, Hilfe- oder A11Y-Evidenz.

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
- **IAD003 – beantwortet:** Versionsnummern in Anforderungen sind datierte
  Ist-Snapshots. Maßgeblich ist die zum späteren Ausführungszeitpunkt aktuelle,
  ausdrücklich repository-gepinnte und freigegebene Version; Drift wird neu
  geprüft und kein automatisches Upgrade ist erlaubt.
- **IAD004 – beantwortet:** PL/0 ist eine additive Erweiterung des zuvor
  abgenommenen Produktvertrags und darf keine bestehende Vertrags-ID ersetzen
  oder aus der Regression entfernen.
- Delivery Authority bleibt `LocalImplementation`; das Intake erteilt keine
  Commit-, Push-, PR-, Merge-, Paketveröffentlichungs- oder Bypass-Berechtigung.
- Es bestehen keine offenen fachlichen Intake-Fragen.

*The approved decisions bind the two-intake split and the two-stage fail-closed
gate. Delivery authority remains local implementation, and no material intake
questions remain open.*

## Vollständiger englischer Vertragsblock / Complete English Contract

Deutsch: Die Ergänzung übersetzt die Detailregeln. Strenges Profil, zweistufiges
Liefergate und datierter Nachweisstand bleiben unverändert.

### English: scope and functional requirements

Each worksheet owns named functions called exclusively PL0.<name>(<arguments>).
Version 1 retains TinyPl0 integer semantics/static profile and bounded compile/
test/step-debug execution without direct cell/file/network/process/OS access.
Use public TinyPl0.Core/TinyPl0.Vm in one expressly selected stable exact version.
Scope: qualified/multi-argument parser, catalog name/ordered parameters/source,
profile/compiler/host/error mapping, backward-compatible JSON v2, accessible
manager/multiline editor/diagnostics/test/Steppable debugger, unit/integration/
persistence/TUI-smoke/security/A11Y and bilingual learner/API docs. Current cells
use double, no user catalog/versioned file format. Resolve Terminal.Gui at
execution time from approved declarations/lock, not a timeless snapshot.
Non-goals: decimal/float/fixed-point VM, macros/arbitrary writes, global catalog,
JIT/CLR/native/non-P-Code paths, embedded/copied IDE, local ProjectReference/
silent fallback or canonical stored P-Code.

- FR-001: Case-insensitively unique names resolve through PL0.<Name>(...).
- FR-002: Store name, ordered unique PL/0 parameter identifiers and full source.
- FR-003: Parse zero-or-more comma-separated expressions, evaluate before VM call, retain cycle detection.
- FR-004: Require finite mathematical integers within Int32; reject other values before VM start.
- FR-005: Extended dialect; exactly one contiguous leading main-block ? ident per parameter, same names/order.
- FR-006: Exactly one ! expression is last executable main-block statement; prohibit all further I/O, including procedures.
- FR-007: Procedures/conditions/loops remain allowed under I/O rules; instruction budget additionally bounds infinite loops.
- FR-008: Profile/lexer/compiler diagnostics have stable code/line/column and clear German message; English docs convey the same meaning.
- FR-009: Successful P-Code is only discardable in-memory cache bound to source hash.
- FR-010: Every source change invalidates old code immediately; invalid drafts may save, never execute.
- FR-011: Exactly one VM output; missing/additional/unconsumed I/O becomes a function error.
- FR-012: Losslessly convert output to existing double cell value.
- FR-013: Manager supports create/select/edit/compile/integer test/safe removal; text exposes existing references before destructive change.
- FR-014: Debugger initialize/step/bounded continue/halt/reset; text shows instruction, P/B/T, stack, I/O and instruction count.
- FR-015: Compilation executes nothing; test/debug require explicit start.
- FR-016: JSON v2 stores source/metadata, no P-Code/VM state; unversioned files load as previous format.
- FR-017: Load/function edits cause AutoCalc reevaluation; errors cannot reuse stale code.

### English: gate, quality, dependencies and evidence

Before implementation both stages must pass. Stage 1: completed TinyPl0 intake,
release tag/source commit, matching stable public packages, SBOM/VEX/provenance-
SLSA links. Stage 2: approved exact TinyPl0/Terminal.Gui declarations, locked-mode
restore, no local ProjectReference, compile/run/step/instruction-limit/cancel/
structured-diagnostic contract tests. Dated proof on 3 September 2026 names
v0.4.1, commit edab567e1e7cd3ea8eb8e3bea425b54f24d4b506 and release run
33757534918 as satisfied stage 1. It is a delivery candidate, not a permanent
integration pin. Stage 2 was Open; internal security predecessor also blocks.
Classify Terminal.Gui Unchanged/DependencyDrift/Unpinned: drift requires build/
full TUI/PTY/A11Y; unpinned fails closed. Record versions/sources/lockfile hash,
never upgrade automatically. Review/spec/plan can precede implementation, but
missing gate stages stop implementation/autonomous before changes; no fallback.

Validate JSON/formula/source/P-Code/VM I/O. Keep memory-safe C#/.NET 10, NIST SSDF/
CWE Top 25, STRIDE/relevant CAPEC for untrusted worksheet programs. Defense in
depth combines strict profile with independent instruction/stack/I/O/cancel
limits; errors fail closed. ASVS is N/A without web/HTTP/API/auth, Zero Trust
N/A for local TUI, AI-SBOM N/A for development-tool-only AI. SBOM/SLSA apply to
distributed artifacts, VEX to known vulnerabilities; consider Scorecard/SAMM.
UI/diagnostics/help/debug meet applicable WCAG AA; meaning never color/frame-only.
DE-first/EN-second B2 learner/why-comments explain terms/status/dependencies/actions.
Predecessors: internal security and external embeddable-VM/NuGet release;
function/A11Y/rename/didactic also precede via series. Add PL0-* IDs before product
code, keep all old IDs. Risks: hostile/blocking programs, API/package drift,
integer overflow, stale code, unclear errors/keyboard/screen-reader barriers.
Package/source hashes and contract tests bind the cross-repository handoff.
Artifacts: catalog/resolver/profile/VM host; JSON migration/persistence;
manager/step debugger with smoke/A11Y; unit/integration/boundary/cancel/cycle/error
tests; XML/help/architecture/security; locks/release/SBOM/VEX/SLSA/cross-repo proof;
version/source/lock/drift preflight; full old/new contract; affected DocFX/axe/lynx;
repository statistics.

The CI evidence boundary dated 6 October 2026 binds TinyCalc PR 99, reviewed
head `4e039ba36598312ad25da0dfb85e4c60e2b500c6`, and merge commit
`09156155a571d94e29a2cd27c3d568f0fbcecc7a`. Homogeneity pins `macos-15`;
product build/tests remain on Linux/Windows and intake governance retains
`macos-latest`. Before PL/0 delivery, recheck required-check names, runner
labels, and the jobs that actually ran on the exact commit. Hosted CI is not
native TUI, PTY, VoiceOver, or accessibility product acceptance.

### English: acceptance and decisions

- AC-001: Both delivery stages proved; no implementation otherwise.
- AC-002: PL0.RABATT(A1,B1) gives documented integer results, no changes outside target cell.
- AC-003: Decimals/non-finite/Int32 overflow/wrong I/O counts produce reproducible diagnosis without VM crash.
- AC-004: Static tests reject non-leading input, procedure I/O, extra/non-final output.
- AC-005: Infinite loop/stack overflow/cancel end within documented limits with structured error.
- AC-006: Each step has consistent instruction/registers/stack/I/O/count; halt/error prevents unintended steps.
- AC-007: Changed/invalid draft never runs old code.
- AC-008: Format 1 loads unchanged; format 2 round trips preserve source/metadata.
- AC-009: Automated Core/TUI/security/A11Y passes binding platforms on the exact
  commit; evidence names jobs, runner labels, and platforms that actually ran,
  while hosted CI does not replace required native TUI/PTY/A11Y acceptance.
- AC-010: Docs/security/package/statistics are current, bilingual, text-reviewable.
- AC-011: Correct unchanged/drift/unpinned classification; drift triggers full TUI/PTY/A11Y, no auto-upgrade.
- AC-012: All PL0-* and old active IDs pass on one commit without weakened TUI/file/formula/help/A11Y proof.

IAD001 approves split tinycalc-pl0-v1-split-v1, SHA-256
f36a20d34be1c682821321dd0b1a0c8d2a5c44b6ffbfaf54c77daa027868a10d;
IAD002 approves both stages/no local fallback; IAD003 binds dated snapshots,
current pins/drift proof/no upgrade; IAD004 binds additive IDs/full regression.
No open material question. Specify prepares only the matching specification.
Separately requested Autonomous remains LocalImplementation and stops fail-closed
on missing gate proof. No commit/push/PR/merge/package publication/bypass permission
is conferred on the future feature by this maintenance delivery.


<!-- intake-authoring:prompts -->
## Ausführbare Spec-Kit-Prompts / Copy-Ready Spec Kit Prompts

<!-- spec-kit-command-id: speckit.specify -->
### Specify

```text
$speckit-specify Nutze requirements/intakes/active/Lastenheft_PL0-Zellfunktionen_V1.md als verbindliches Intake. Prüfe zuerst beide Stufen des TinyPl0-Liefergates sowie den versionsneutralen Dependency-Preflight und dokumentiere fehlende, geänderte oder ungepinnte Evidenz als Blocker. Erstelle oder aktualisiere ausschließlich die passende Feature-Spezifikation. Bewahre Scope, Nicht-Ziele, Reihenfolge, strenges PL/0-Profil, NuGet-Vertrag, Security-, A11Y-, Dokumentations- und Evidenzgrenzen. Implementiere nichts; committe und pushe nicht; erstelle oder merge keinen Pull Request und starte kein weiteres Feature.
```

<!-- spec-kit-command-id: speckit.autonomous -->
### Autonomous

```text
$speckit-autonomous Führe genau einen vollständigen autonomen Spec-Kit-Lauf mit requirements/intakes/active/Lastenheft_PL0-Zellfunktionen_V1.md als verbindlichem Intake aus. Delivery Mode: LocalImplementation. Prüfe vor jeder Änderung das zweistufige TinyPl0-Liefergate und den versionsneutralen Dependency-Preflight; stoppe fail-closed, wenn Release-, NuGet-, SBOM-/VEX-/SLSA-, Locked-Restore-, Contract-Test- oder Pin-Evidenz fehlt oder ungeklärte Dependency-Drift besteht. Führe kein automatisches Upgrade aus. Bewahre Scope, Reihenfolge, strenges PL/0-Profil, Security-, A11Y-, Dokumentations- und Evidenzgrenzen. Nutze keine lokale ProjectReference als Fallback. Nicht pushen, keinen Pull Request erstellen oder mergen, keine Pakete veröffentlichen, keinen Bypass nutzen, keine Secrets offenlegen und kein Folgefeature starten.
```

<!-- intake-authoring:end -->
