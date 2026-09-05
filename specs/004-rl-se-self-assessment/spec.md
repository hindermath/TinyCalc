# Feature Specification: RL-SE-/Checklist-Selbstpruefung

**Feature Branch**: `004-rl-se-self-assessment`
**Created**: 2026-09-05
**Status**: Draft
**Binding Intake**: `requirements/intakes/active/Lastenheft_RL-SE-Checklist-Selbstpruefung.md`
**Input**: Eine getrennte, auditfaehige Selbstpruefung des aktuellen TinyCalc-Stands gegen die Richtlinie Sichere Entwicklung, alle 157 stabilen Checklistenpunkte, die mitgeltenden Dokumente, die Projekt-Constitution und die installierten Governance-Presets. Der Lauf bewertet und dokumentiert; er fuehrt keine automatische Produkthaertung durch.

## User Scenarios & Testing *(mandatory)*

### User Story 1 - Vollstaendige Sicherheits-Selbstpruefung (Priority: P1)

Als Projektverantwortlicher moechte ich jeden der 157 stabilen Pruefpunkte aus
`CL-01` bis `CL-12` in einer nachvollziehbaren Matrix wiederfinden. So erkenne
ich, was fuer TinyCalc gilt, was bereits belegt ist und wo noch Arbeit oder
eine spaetere Neubewertung erforderlich ist.

*As project owner, I want every one of the 157 stable checklist items to appear
in a traceable matrix. This shows what applies to TinyCalc, what is already
supported by evidence, and where work or later reassessment remains necessary.*

**Why this priority**: Ohne lueckenlose Abdeckung waere die Selbstpruefung nicht
auditfaehig und koennte Sicherheitsluecken durch stillschweigendes Auslassen
verdecken.

**Independent Test**: Die kanonischen Einzelchecklisten werden maschinell nach
stabilen IDs ausgewertet. Die Ergebnismatrix enthaelt jede dieser 157 IDs genau
einmal und keine erfundene ID.

**Acceptance Scenarios**:

1. **Given** die GSDB-Basis mit 157 stabilen Checklisten-IDs, **When** die
   Selbstpruefung abgeschlossen ist, **Then** enthaelt die Matrix fuer jede ID
   genau eine Zeile mit Status, Begruendung, Evidenz oder Open-Markierung,
   Owner, Folgeaktion, Neubewertungs-Trigger und Restrisiko.
2. **Given** ein anwendbarer Punkt mit belastbarer aktueller Evidenz, **When**
   er bewertet wird, **Then** wird er als `AlreadySatisfied` gefuehrt und
   verweist auf konkrete, pruefbare Evidenz.
3. **Given** ein anwendbarer Punkt ohne ausreichende Evidenz, **When** er
   bewertet wird, **Then** wird er als `Open` gefuehrt und nennt Owner,
   Prioritaet, Risiko, Folgeaktion und Neubewertungs-Trigger.

---

### User Story 2 - Verstaendliche Anwendbarkeitsentscheidungen (Priority: P2)

Als Entwickler oder Auszubildender moechte ich nachvollziehen koennen, warum
ein Sicherheitsstandard, ein Kontrollpunkt oder ein Nachweis fuer TinyCalc
gilt oder nicht gilt, ohne einer unbelegten Compliance-Aussage vertrauen zu
muessen.

*As a developer or apprentice, I want to understand why a security standard,
control, or evidence item applies to TinyCalc or does not apply, without having
to trust an unsupported compliance claim.*

**Why this priority**: Eine Statusmarke allein ist kein Nachweis. Die
Begruendung macht die Bewertung lernbar und spaeter erneut pruefbar.

**Independent Test**: Stichproben aus allen zwoelf Checklistenfamilien lassen
sich vom Matrixeintrag zur Quelle, zur Begruendung und zur Evidenz
zurueckverfolgen; Fachbegriffe sind kurz erklaert oder verlinkt.

**Acceptance Scenarios**:

1. **Given** ein nicht anwendbarer Kontrollpunkt, **When** ein Leser die
   Matrixzeile prueft, **Then** findet er eine technische oder fachliche
   `N/A`-Begruendung und einen konkreten Trigger fuer eine erneute Bewertung.
2. **Given** ein Human-only-Punkt, **When** keine menschliche Freigabe vorliegt,
   **Then** behauptet die Selbstpruefung keine Erfuellung und kennzeichnet die
   notwendige menschliche Entscheidung sichtbar.
3. **Given** eine positive Aussage, **When** ihr Evidenzpfad aufgerufen wird,
   **Then** belegt die referenzierte, aktuelle Quelle genau diese Aussage.

---

### User Story 3 - Steuerbare Folgearbeit ohne automatische Haertung (Priority: P3)

Als Projektverantwortlicher moechte ich offene oder bewusst spaeter zu
behandelnde Punkte priorisiert weitergeben koennen, ohne dass dieser Lauf
eigenmaechtig Produktcode, Provider-Einstellungen oder formale Freigaben
veraendert.

*As project owner, I want to hand off open or deliberately deferred items in a
prioritised form, without this assessment run changing product code, provider
settings, or formal approvals on its own.*

**Why this priority**: Der Lauf soll belastbare Entscheidungsgrundlagen
schaffen und seine Bewertungsgrenze einhalten.

**Independent Test**: Alle `Open`- und `FollowUp`-Zeilen sind als
eigenstaendige Arbeitsauftraege lesbar; der Feature-Diff enthaelt keine
automatische Produkthaertung.

**Acceptance Scenarios**:

1. **Given** eine festgestellte Produktluecke, **When** sie ausserhalb dieses
   Laufs behoben werden muss, **Then** dokumentiert die Matrix sie als `Open`
   oder `FollowUp`, ohne den Produktcode zu aendern.
2. **Given** eine nicht autorisierte externe Aktion, **When** sie fuer einen
   Nachweis hilfreich waere, **Then** bleibt sie ausserhalb der Bewertung und
   wird weder ausgefuehrt noch als erledigt behauptet.
3. **Given** der Abschlussbericht, **When** Folgearbeit geplant wird, **Then**
   sind Owner, Prioritaet, Risiko, Folgeaktion und Trigger direkt nutzbar.

### Edge Cases

- Eine stabile ID kommt im generierten Sammelband und in der kanonischen
  Einzelcheckliste vor: Die Einzelcheckliste ist die Quelle; die Matrix fuehrt
  die ID trotzdem nur einmal.
- Eine Datei existiert, belegt aber nicht die konkrete Aussage: Der Punkt darf
  nicht `AlreadySatisfied` werden und bleibt `Open` oder `FollowUp`.
- Eine Evidenz ist veraltet, unlesbar, ausserhalb des Repositorys oder nur
  visuell: Sie gilt nicht allein als belastbarer Nachweis.
- Ein Punkt passt zu mehreren Standards oder Presets: Eine Matrixzeile darf
  mehrere Quellen nennen, ohne die stabile ID zu duplizieren.
- Ein Punkt ist heute nicht anwendbar, kann es aber nach einer Architektur-,
  Distributions-, Cloud-, KI-, Daten- oder Rechtsaenderung werden: `N/A` nennt
  genau diesen Neubewertungs-Trigger.
- Ein Human-only-Nachweis fehlt: Die Bewertung bleibt offen und wird nicht
  durch Agentenannahmen ersetzt.
- Richtlinie, Sammelband und Einzelcheckliste widersprechen sich: Die Abweichung
  wird als `Open` dokumentiert und nicht stillschweigend aufgeloest.

## Requirements *(mandatory)*

### Functional Requirements

- **FR-001**: Der Lauf MUSS die Verzahnungsdatei zuerst als Zuordnungsbruecke
  fuer Richtlinie, Checklisten, mitgeltende Dokumente, Presets und typische
  Evidenzpfade verwenden.
- **FR-002**: Der Lauf MUSS die kanonischen Einzelchecklisten `CL_01` bis
  `CL_12` aus dem Baseline-Manifest lesen und deren 157 stabile IDs vollstaendig
  und genau einmal in einer Evidenzmatrix abbilden.
- **FR-003**: Jede Matrixzeile MUSS genau eine Hauptdisposition aus
  `Applicable`, `AlreadySatisfied`, `N/A`, `Open` oder `FollowUp` enthalten.
- **FR-004**: Jede Matrixzeile MUSS zusaetzlich die zweiachsige GSDB-Logik
  abbilden: Anwendbarkeit (`Applicable`, `N/A`, `Open`) und Umsetzungsstand
  (`Fulfilled`, `Partly Fulfilled`, `Not Fulfilled`, `Not Assessed`).
  `AlreadySatisfied` entspricht `Applicable` plus `Fulfilled`; `FollowUp`
  beschreibt eine nachgelagerte Behandlung und nennt trotzdem beide Achsen.
- **FR-005**: Jede Matrixzeile MUSS eine kurze Begruendung, einen konkreten
  Evidenzpfad oder eine ausdrueckliche Open-Markierung, eine verantwortliche
  Rolle, eine Folgeaktion, einen Neubewertungs-Trigger und ein Restrisiko
  enthalten.
- **FR-006**: `Applicable` und `AlreadySatisfied` MUESSEN auf konkrete,
  pruefbare Evidenz verweisen; die Existenz eines Dokuments allein reicht nicht.
- **FR-007**: `N/A` und `FollowUp` MUESSEN technisch oder fachlich begruendet
  sein. `N/A` MUSS ausserdem einen Neubewertungs-Trigger nennen.
- **FR-008**: `Open` MUSS Owner, Prioritaet, Risiko, konkrete Folgeaktion und
  Neubewertungs-Trigger nennen.
- **FR-009**: Human-only-Punkte MUESSEN sichtbar abgegrenzt werden. Der Lauf
  DARF keine menschliche Freigabe, Auditbestaetigung, QISMS-Bewertung oder
  Rechtsberatung erfinden.
- **FR-010**: Die Pruefung MUSS Richtlinie, Sammelband, alle Einzelchecklisten,
  alle im Baseline-Manifest gefuehrten mitgeltenden Dokumente, beide
  Constitutions, vorhandene `docs/security/`-Nachweise, Tests, CI,
  Review-Notizen und installierte Governance-Presets beruecksichtigen.
- **FR-011**: Fuer jeden relevanten Governance-Preset-Pruefpunkt MUSS eine
  Zuordnung oder eine begruendete Nichtanwendbarkeit vorliegen.
- **FR-012**: Der Abschlussbericht MUSS Bewertungsumfang, Quellenstand,
  Zusammenfassung je Checklistenfamilie, offene Risiken, Restrisiken,
  Human-only-Grenzen, Folgearbeiten und Neubewertungs-Trigger enthalten.
- **FR-013**: Die Ergebnisartefakte MUESSEN DE-first/EN-second auf CEFR-B2-
  Niveau formuliert und fuer Screenreader, Braillezeilen und Textbrowser ohne
  Farb- oder Layoutabhaengigkeit verstaendlich sein.
- **FR-014**: Der Lauf DARF keine automatische Produkthaertung, keine
  repo-uebergreifende Sammelpruefung, keine Provider-, Sichtbarkeits-,
  Branch-Protection-, Secret- oder Modellkonfiguration und keine Nutzung echter
  Kundendaten, produktiver Tokens oder privater Pfade vornehmen.
- **FR-015**: Konkrete Luecken MUESSEN als `Open` oder `FollowUp` dokumentiert
  werden. Ihre Umsetzung benoetigt einen getrennten Arbeitsauftrag.
- **FR-016**: Vollstaendigkeit und Eindeutigkeit der 157 IDs, erlaubte
  Statuswerte und lokale Evidenzpfade MUESSEN reproduzierbar validiert werden.
- **FR-017**: Produkt-Build, Tests und vorhandene Governance-Gates MUESSEN als
  Regressionsevidenz laufen, ohne daraus eine breitere Compliance zu folgern.
- **FR-018**: Das Ergebnis MUSS als projektspezifische Evidenz unter
  `docs/security/` sowie als Spec-Kit-Abschlussnotiz abgelegt werden.

### Constitution Requirements *(mandatory)*

- **CR-001**: TinyCalc MUSS die verbindliche Level-2-Environment-Registry-Zeile
  aus `constitution.md` fuer Runtime, Build/Test, A11Y, Statistik und
  Agentenflaechen verwenden.
- **CR-002**: WCAG 2.2 Level AA ist fuer nutzerorientierte Artefakte die
  Pruefbasis. Text-first ist verbindlich; essentielle Bedeutung darf nicht nur
  durch Farbe, Tabellenlayout oder Zeigerinteraktion vermittelt werden.
- **CR-003**: Lern- und nutzerorientierte Inhalte MUESSEN DE-first/EN-second
  auf CEFR B2 erscheinen. Fachbegriffe werden erklaert oder verlinkt.
- **CR-004**: `docs/project-statistics.md` MUSS aktualisiert werden. Die fuenf
  KI-Agenten-Guidance-Dateien werden nur synchron geaendert, wenn eine
  gemeinsame Governance-Aenderung erforderlich ist; fuer reine Befunde lautet
  die Entscheidung `NoUpdateRequired`.
- **CR-005**: C# auf .NET ist die primaere Laufzeit und eine MSL. Das ersetzt
  keine Pruefung von APIs, Eingaben, Fehlerpfaden, Datei-I/O, Abhaengigkeiten
  oder Toolchains.
- **CR-006**: NIST SSDF und CWE Top 25 sind immer anwendbar. STRIDE/CAPEC,
  SBOM/VEX/SLSA, CRA, BSI C3A/C5, NIS2, EU AI Act und DORA werden mit Evidenz
  oder ausdruecklicher `N/A`-Begruendung bewertet.
- **CR-007**: OWASP ASVS ist fuer den lokalen TUI ohne Web-, API-, HTTP- oder
  Authentifizierungsdienst `N/A`; die Einfuehrung eines solchen Dienstes ist
  der Neubewertungs-Trigger.
- **CR-008**: Fuer das releasefaehige .NET-Artefakt sind SBOM und Supply-Chain-
  Evidenz anwendbar. VEX wird bei bekannten Schwachstellen erforderlich;
  SLSA/Provenance wird fuer CI/CD und veroeffentlichte Artefakte geprueft.
- **CR-009**: KI ist nur Entwicklungswerkzeug und keine ausgelieferte
  Produktkomponente. AI-SBOM ist `N/A`; eine KI-Runtime im Produkt loest eine
  Neubewertung aus.
- **CR-010**: Das Feature aendert keine Trust Boundary und keine verteilte
  Architektur. Zero Trust ist fuer den lokalen TUI `N/A` und wird bei Cloud-,
  Remote-, Service- oder Netzwerkarchitektur neu bewertet. Vorhandene
  Trust Boundaries werden mit STRIDE/CAPEC betrachtet.
- **CR-011**: Die etablierten Nachweispfade in `docs/security/` und eine eigene
  RL-SE-Evidenzmatrix werden verwendet.
- **CR-012**: Alle installierten Governance-Presets werden in ihrer aktuellen
  Version inventarisiert; zusaetzliche Presets werden nicht ausgelassen.
- **CR-013**: Documentation Impact ist `UpdateRequired`. Zielgruppen sind
  Projektverantwortliche, Entwickler, Reviewer und Auszubildende; betroffen
  sind Spec-Kit, `docs/security/`, Abschlussnotiz, PR-Dokumentation und
  Statistik. Kanonische Quelle ist der RL-SE-Intake, Owner die Projekt- und
  Security-Review-Rolle. Navigation wird nur bei fehlender Auffindbarkeit
  angepasst. Sprache ist DE-first/EN-second; Plattformnachweis ist die
  registrierte macOS/.NET-Umgebung plus CI. Distribution ist repository-intern,
  Home Sync nicht erforderlich. Evidenz liefern Links, ID-Validator,
  Build/Test, Governance-Gates und Review. Trigger sind Baseline-, Architektur-,
  Distributions- oder Navigationsaenderungen.
- **CR-014**: Status, Abhaengigkeiten, Entscheidungen und naechste Aktionen
  MUESSEN vollstaendig als Text vorliegen.
- **CR-015**: Oeffentliche API, XML-Dokumentation und Produkt-Codekommentare
  sind `N/A`, da kein Produktcode geaendert wird. Spaetere Codehaertung loest
  eine neue Pruefung aus.
- **CR-016**: TDD und Changed-Code-Coverage sind fuer Bewertungsdokumente
  `N/A`. Stattdessen sind ein roter Vollstaendigkeits-/Schema-Test vor der
  Matrix, ein gruener Test danach und Build/Test/Governance-Regression Pflicht.

### Key Entities

- **Checklist Source**: Kanonische Einzelcheckliste mit Familien-ID, Version,
  Pfad und stabilen Pruefpunkt-IDs.
- **Assessment Row**: Einmalige Bewertung einer stabilen ID mit Disposition,
  beiden Statusachsen, Begruendung, Evidenz, Owner, Folgeaktion, Prioritaet,
  Risiko, Trigger, Restrisiko und Human-only-Kennzeichen.
- **Evidence Reference**: Pruefbarer Repository-Pfad oder Test-/CI-Nachweis,
  der genau die zugeordnete Aussage stuetzt.
- **Follow-up Item**: Offene oder nachgelagerte Arbeit mit Owner, Prioritaet,
  Risiko, Aktion und Trigger, die nicht automatisch umgesetzt wird.
- **Assessment Summary**: Unbeschoenigte Gesamtsicht auf Abdeckung,
  Dispositionen, Standards, Human-only-Grenzen und Restrisiken.

## Success Criteria *(mandatory)*

### Measurable Outcomes

- **SC-001**: 157 von 157 kanonischen IDs erscheinen genau einmal; fehlende,
  doppelte und unbekannte IDs: 0.
- **SC-002**: 100 % der Matrixzeilen enthalten alle Pflichtfelder und nur
  erlaubte Werte fuer Disposition und beide Statusachsen.
- **SC-003**: 100 % der positiven Aussagen verweisen auf konkrete, pruefbare
  Evidenz; unbelegte positive Compliance-Aussagen: 0.
- **SC-004**: 100 % der `N/A`-, `Open`- und `FollowUp`-Zeilen enthalten die
  vorgeschriebene Begruendung und Folgeinformation; stille Auslassungen: 0.
- **SC-005**: Alle zwoelf Checklistenfamilien, alle mitgeltenden Dokumente,
  beide Constitutions und alle installierten Presets sind sichtbar behandelt.
- **SC-006**: Build, Tests und anwendbare technische, Security-, A11Y-,
  Governance- und Evidenz-Gates sind erfolgreich; kein materieller Fehler wird
  durch eine positive Bewertung oder einen formalen Bypass verdeckt.
- **SC-007**: Ein textorientierter Review bestaetigt DE-first/EN-second,
  CEFR B2 und eine Nutzung ohne farb- oder layoutabhaengige Kernaussage.
- **SC-008**: Der Feature-Diff enthaelt keine automatische Produkthaertung oder
  unautorisierte externe Konfiguration; Produktluecken bleiben Folgearbeit.

## Assumptions

- `docs/secure-development/baseline-manifest.json` Version 3.2.0 und seine
  Einzelchecklisten sind kanonisch; der Sammelband ist eine Lesesicht.
- Die 157 stabilen IDs werden aus den Einzelchecklisten gewonnen und nicht
  manuell erfunden.
- Der nach PR #67 synchronisierte `main` ist die Bewertungsbasis.
- Repository-lokale Evidenz wird bevorzugt; externe Nachweise enthalten keine
  Secrets oder privaten Pfade.
- Owner werden als Rollen und nicht als private Kontaktdaten angegeben.
- `MergeAndSync` mit Admin-Bypass gilt nur fuer formale Merge-Regeln, nachdem
  alle materiellen Gates und Reviews erfolgreich sind.

## Non-Goals

- Produktcode oder Laufzeitverhalten automatisch haerten oder veraendern.
- Andere Repositories pruefen oder synchronisieren.
- Zertifizierung, Rechtsberatung, Auditfreigabe oder menschliche
  Compliance-Entscheidung ersetzen.
- Repo-Sichtbarkeit, Branch Protection, Secrets, Provider, Modelle oder
  produktive Umgebungen konfigurieren.
- Den GSDB-Folgelauf vor vollstaendig abgeschlossenem MergeAndSync beginnen.
