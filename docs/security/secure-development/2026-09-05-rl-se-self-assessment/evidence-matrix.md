# TinyCalc RL-SE-Selbstpruefung / RL-SE Self-Assessment

## Technische Grenze / Technical Boundary

**DE:** Diese repository-interne Bewertung bindet Baseline 3.2.0 und alle 157
kanonischen Pruefpunkte. Ein technischer Pass ist keine menschliche Freigabe,
Rechtsberatung oder Aussage ueber organisationsweite Wirksamkeit.

**EN:** This repository-internal assessment binds baseline 3.2.0 and all 157
canonical checkpoints. A technical pass is not a human approval, legal advice,
or a statement of organization-wide effectiveness.

## Aktueller Ueberblick / Current Summary

| Disposition | Count | Plain-language meaning |
|---|---:|---|
| `AlreadySatisfied` | 21 | Concrete repository evidence supports the bounded statement. |
| `N/A` | 32 | The current product boundary does not contain the named capability; every row has a trigger. |
| `Open` | 42 | A human or organizational decision is not present. |
| `FollowUp` | 62 | Partial context exists, but complete effectiveness is not claimed. |
| **Total** | **157** | Every canonical ID appears exactly once. |

The detailed, machine-readable rows are in `assessment-matrix.json`. A linear
DE-first/EN-second family view and the prioritised follow-up list are completed
before delivery.

## Behobener Baseline-Befund / Resolved Baseline Finding

**DE:** Der v0.1.2-Validator erkannte korrekt, dass das Manifest noch aeltere
Versionsangaben als die kontrollierten Dokumente enthielt. Thorsten hat die
eng begrenzte Korrektur ausdruecklich freigegeben. Das Manifest bindet nun
Baseline und Richtlinie 3.2.0, Sammelband sowie CL-09/CL-12 2.2.0 und die
SDLC-Richtlinie 1.2.0; die abhaengigen Hash- und Evidenzbindungen wurden neu
erzeugt. Die fachlichen Inhalte der kontrollierten Dokumente blieben dabei
unveraendert.

**EN:** The v0.1.2 validator correctly detected that the manifest still held
older version declarations than the controlled documents. Thorsten explicitly
approved the narrowly bounded correction. The manifest now binds baseline and
guideline 3.2.0, compendium and CL-09/CL-12 2.2.0, and the SDLC guideline
1.2.0; dependent hash and evidence bindings were regenerated. The controlled
documents' substantive content was not changed.

## Quellenstand / Source State

**DE:** Bewertet wurden die Richtlinie Sichere Entwicklung 3.2.0, der
Checklisten-Sammelband 2.2.0, alle zwoelf kanonischen Einzelchecklisten, alle
weiteren im Manifest gebundenen Textdokumente, beide Projekt-Constitutions,
die vorhandenen Sicherheitsnachweise, CI und Tests sowie 13 installierte
Governance-Presets. Insgesamt sind 30 Textdokumente durch normalisierte
SHA-256-Werte gebunden. Der Sammelband und die Einzeldateien enthalten dieselbe
Menge von 157 eindeutigen IDs.

**EN:** The assessment covers Secure Development Guideline 3.2.0, checklist
compendium 2.2.0, all twelve canonical individual checklists, every other text
document bound by the manifest, both project constitutions, the available
security evidence, CI and tests, and 13 installed governance presets. Normalized
SHA-256 values bind 30 text documents. The compendium and individual files
contain the same set of 157 unique IDs.

## Lineare Ergebnislesung / Linear Result Reading

**DE:** Die Tabelle oben ist nicht die einzige Ergebnisdarstellung. In linearer
Lesereihenfolge sind 21 Punkte mit konkreter Repository-Evidenz bereits
erfuellt, 32 Punkte fuer die aktuelle Produktgrenze begruendet nicht anwendbar,
42 Punkte wegen fehlender menschlicher oder organisatorischer Entscheidung
offen und 62 Punkte als fachliche Folgearbeit teilweise erfuellt. Es gibt
keinen still ausgelassenen und keinen technisch blockierten Punkt.

**EN:** The table above is not the only result representation. In linear reading
order, 21 items are already supported by concrete repository evidence, 32 are
justifiably not applicable to the current product boundary, 42 remain open for
a human or organizational decision, and 62 are partly fulfilled follow-up
items. No item is silently omitted or technically blocked.

## Zusammenfassung je Familie / Summary by Family

### Deutsche Lesefolge

- `CL-01` Standards-Anwendbarkeit: 12 Punkte; 4 bereits erfuellt, 3 `N/A`,
  1 menschlich offen und 4 als Folgearbeit. NIST SSDF und CWE Top 25 sind
  gebunden; zeitgebundene N/A-Entscheidungen bleiben zu ueberwachen.
- `CL-02` Sichere Softwarearchitektur: 13 Punkte; 2 bereits erfuellt, 2 `N/A`
  und 9 als Folgearbeit. Trust Boundaries und arc42 Section 8 sind vorhanden;
  die Wirksamkeit weiterer Architekturkontrollen wird nicht pauschal behauptet.
- `CL-03` Krypto-Mindestvorgaben: 15 Punkte; 12 `N/A` und 3 als Folgearbeit.
  TinyCalc stellt derzeit keine eigene Krypto-, Auth-, TLS-Server- oder
  Schluesselverwaltungsfunktion bereit; jede spaetere solche Funktion ist ein
  Neubewertungstrigger.
- `CL-04` Bedrohungsmodellierung: 10 Punkte; 8 bereits erfuellt und 2 als
  Folgearbeit. STRIDE, TB-1 bis TB-3, TH-001 bis TH-009 und CAPEC-153/538 sind
  konkret belegt; der wiederkehrende Review-Nachweis bleibt teilweise offen.
- `CL-05` Lieferkette und Build-Integritaet: 13 Punkte; 2 bereits erfuellt,
  2 `N/A` und 9 als Folgearbeit. SPDX-SBOM und Supply-Chain-Evidenz bestehen;
  SLSA-/Provenance-Reife und weitere Build-Kontrollen bleiben Folgearbeit.
- `CL-06` Schwachstellenoffenlegung: 11 Punkte; 2 menschlich offen und 9 als
  Folgearbeit. Technische Ausgangsnachweise sind vorhanden, ersetzen aber
  keine organisatorisch autorisierte Offenlegungs- oder Benachrichtigungslage.
- `CL-07` CRA-Anwendbarkeit: 12 Punkte; alle 12 bleiben Human-only `Open`.
  Dieser technische Lauf trifft keine Rechts-, Marktrollen-, CE- oder
  Konformitaetsentscheidung.
- `CL-08` Sicherheits-Code-Review: 13 Punkte; 1 bereits erfuellt, 3 `N/A` und
  9 als Folgearbeit. Das C#/.NET-Sicherheitsprofil ist gebunden; der Nachweis
  einzelner Kontrollen bleibt auf konkrete spaetere Codeaenderungen begrenzt.
- `CL-09` KI-Codeerzeugung: 17 Punkte; 7 menschlich offen und 10 als
  Folgearbeit. KI ist Entwicklungswerkzeug, keine ausgelieferte
  Produktkomponente; Human Review und Freigaben werden nicht erfunden.
- `CL-10` Sichere Entwicklungsumgebung: 17 Punkte; 2 bereits erfuellt,
  14 menschlich offen und 1 als Folgearbeit. Secret-Scan und
  plattformgleiche Validator-Einstiege sind belegt; Host- und
  Organisationsentscheidungen bleiben beim Projektverantwortlichen.
- `CL-11` Datenschutz-Folgenabschaetzung: 12 Punkte; 10 `N/A` und 2 menschlich
  offen. Der aktuelle Produktumfang sieht keine systematische Verarbeitung
  personenbezogener Daten vor; reale Felddaten oder neue Datenfluesse loesen
  die Neubewertung aus.
- `CL-12` Agentische KI und Sandbox: 12 Punkte; 2 bereits erfuellt,
  4 menschlich offen und 6 als Folgearbeit. Preset-Inventar und Laufspur sind
  belegt; Sandbox-Freigabe, periodische Aktualitaet und Mapping-Abdeckung
  bleiben getrennt sichtbar.

### English reading order

- `CL-01` standards applicability: 12 items; 4 already satisfied, 3 `N/A`,
  1 human decision open, and 4 follow-ups. NIST SSDF and CWE Top 25 are bound;
  time-bound N/A decisions still need monitoring.
- `CL-02` secure software architecture: 13 items; 2 already satisfied, 2
  `N/A`, and 9 follow-ups. Trust boundaries and arc42 Section 8 exist; broader
  control effectiveness is not inferred.
- `CL-03` cryptographic minimums: 15 items; 12 `N/A` and 3 follow-ups. TinyCalc
  currently provides no cryptographic, authentication, TLS-server, or key-
  management feature; adding one triggers reassessment.
- `CL-04` threat modelling: 10 items; 8 already satisfied and 2 follow-ups.
  STRIDE, TB-1 through TB-3, TH-001 through TH-009, and CAPEC-153/538 are
  evidenced; recurring review evidence remains partial.
- `CL-05` supply chain and build integrity: 13 items; 2 already satisfied,
  2 `N/A`, and 9 follow-ups. An SPDX SBOM and supply-chain evidence exist;
  SLSA/provenance maturity and further build controls remain follow-up work.
- `CL-06` vulnerability disclosure: 11 items; 2 human decisions open and 9
  follow-ups. Technical starting evidence cannot replace an organizationally
  authorized disclosure or notification decision.
- `CL-07` CRA applicability: 12 items; all 12 remain Human-only `Open`. This
  technical run does not make legal, market-role, CE, or conformity decisions.
- `CL-08` security code review: 13 items; 1 already satisfied, 3 `N/A`, and 9
  follow-ups. The C#/.NET security profile is bound; individual controls need
  concrete evidence when relevant code changes.
- `CL-09` AI code generation: 17 items; 7 human decisions open and 10
  follow-ups. AI is a development tool, not a shipped product component;
  human review and approvals are not invented.
- `CL-10` secure development environment: 17 items; 2 already satisfied,
  14 human decisions open, and 1 follow-up. Secret scanning and cross-platform
  validator entry points are evidenced; host and organization decisions remain
  with the project owner.
- `CL-11` data-protection impact assessment: 12 items; 10 `N/A` and 2 human
  decisions open. The current product scope has no intended systematic personal-
  data processing; real field data or new data flows trigger reassessment.
- `CL-12` agentic AI and sandbox: 12 items; 2 already satisfied, 4 human
  decisions open, and 6 follow-ups. Preset inventory and the run trail are
  evidenced; sandbox approval, periodic currency, and mapping coverage remain
  separately visible.

## Technische Gates und Entscheidungsgrenzen / Technical Gates and Decision Boundaries

**DE:** Baseline, Delta, Closure und Image Impact melden jeweils `Ready`; der
strengste Gesamtstatus ist ebenfalls `Ready`. Die technische Validierung ist
`Fulfilled`. Pilotfreigabe, Projektabnahme und allgemeine Freigabe bleiben
jeweils `Open`. Der einmalige unabhaengige Closure-Review meldete fuer denselben
Evidenzstand `Ready`. Diese Ergebnisse sind weder Zertifizierung noch
Rechtsberatung und ersetzen keinen menschlichen Beschluss.

**EN:** Baseline, delta, closure, and image impact each report `Ready`; the
strictest overall result is also `Ready`. Technical validation is `Fulfilled`.
Pilot authorization, project acceptance, and general release each remain
`Open`. The single independent closure review reported `Ready` for the same
evidence state. These results are not certification or legal advice and do not
replace a human decision.

## Priorisierte Folgearbeit / Prioritized Follow-up

**DE:** Die 42 Punkte mit Prioritaet `High` sind ausschliesslich Human-only-
Entscheidungen. Sie verteilen sich auf CL-01 (1), CL-06 (2), CL-07 (12),
CL-09 (7), CL-10 (14), CL-11 (2) und CL-12 (4). Verantwortlich ist die Rolle
`TinyCalc project owner role`; konkrete Evidenz steht jeweils noch auf
`NotProvided`. Dieser Lauf fuehrt keine dieser Entscheidungen stellvertretend
aus.

Die 62 Punkte mit Prioritaet `Medium` sind technische oder organisatorische
Folgearbeit: CL-01 (4), CL-02 (9), CL-03 (3), CL-04 (2), CL-05 (9), CL-06
(9), CL-08 (9), CL-09 (10), CL-10 (1) und CL-12 (6). Jede zugehoerige
Matrixzeile nennt Owner, konkrete Aktion, Risiko, Restrisiko und Trigger. Die
Umsetzung benoetigt einen getrennt autorisierten Arbeitsauftrag.

**EN:** The 42 `High` priority items are exclusively Human-only decisions.
They are distributed across CL-01 (1), CL-06 (2), CL-07 (12), CL-09 (7),
CL-10 (14), CL-11 (2), and CL-12 (4). The responsible role is
`TinyCalc project owner role`; their specific evidence remains `NotProvided`.
This run does not make any of those decisions by proxy.

The 62 `Medium` priority items are technical or organizational follow-up work:
CL-01 (4), CL-02 (9), CL-03 (3), CL-04 (2), CL-05 (9), CL-06 (9), CL-08
(9), CL-09 (10), CL-10 (1), and CL-12 (6). Every corresponding matrix row
names its owner, concrete action, risk, residual risk, and trigger. Delivery
requires a separately authorized work item.

## Restrisiken und Neubewertung / Residual Risks and Reassessment

**DE:** Positive Nachweise gelten nur fuer den aktuellen Repository- und
Produktstand. Dokumente koennen veralten; Produkt-, Architektur-, Abhaengigkeits-,
Workflow-, Distributions- oder Baseline-Aenderungen loesen eine erneute
Pruefung aus. Neue Krypto-, Web/API-, Auth-, Cloud-, KI-Runtime-, Netzwerk-
oder Personendatenfunktionen heben die jeweilige `N/A`-Begruendung auf. Ein
bekannter Fund in einer ausgelieferten Komponente aktiviert die VEX-Bewertung.
Preset-Aenderungen oder der naechste Quartalstermin aktivieren die Preset-
Aktualitaetspruefung. Die turnusmaessige Sicherheitspruefung und dokumentierte
Bedrohungsmodell-Aktualisierung bleiben erforderlich.

**EN:** Positive evidence applies only to the current repository and product
state. Documents can become stale; product, architecture, dependency, workflow,
distribution, or baseline changes trigger reassessment. New cryptographic,
web/API, authentication, cloud, AI-runtime, network, or personal-data features
invalidate the corresponding `N/A` rationale. A known finding in a shipped
component activates VEX assessment. Preset changes or the next quarterly date
activate the preset currency review. The scheduled security review and a
documented threat-model update remain necessary.

## Nachweispfade / Evidence Paths

**DE:** Die vollstaendige zeilenweise Bewertung mit allen 157 IDs steht in
`assessment-matrix.json`. Die vier Assurance-Gates stehen in `baseline.json`,
`deltas/rl-se-assessment.json`, `closure.json` und `image-impact.json`. Der
reproduzierbare Ablauf steht in
`specs/004-rl-se-self-assessment/quickstart.md`; die zeitliche Laufspur in
`specs/004-rl-se-self-assessment/autonomous-run-evidence.md`.

## Delivery-bezogene N/A-Entscheidungen / Delivery-related N/A Decisions

**DE:** Dieses Bewertungsfeature aendert weder Produktcode noch Architektur.
Darum sind ein Architekturdelta und ein allgemeiner S-ADR fuer diesen Lauf
`N/A`; jede kuenftige Komponente, Schnittstelle, Datenfluss- oder
Trust-Boundary-Aenderung hebt diese Entscheidung auf. Oeffentliche C#-APIs und
XML-Kommentare bleiben unveraendert, deshalb entstehen keine API- oder
XML-Dokumentationsarbeiten. DocFX-Navigation und generierte HTML-Ausgabe werden
nicht geaendert; eine spaetere Navigations- oder Publikationsaenderung erfordert
Regeneration und textorientierten A11Y-Smoke.

Produkt-TDD und Changed-product-code-Coverage sind wegen leerem `src/`- und
`tests/`-Delta `N/A`; jede spaetere Produkt- oder Testcodeaenderung aktiviert
das Mindestgate 70 Prozent und Ziel 80 Prozent. Eine oeffentliche Unix-Manpage
ist fuer den repository-internen Validator `N/A`; eine verteilte CLI hebt die
Entscheidung auf. Automatische Dependency-Updates sind nicht Teil dieser
Bewertung; ein kritischer Fund blockiert trotzdem und benoetigt eine getrennte
Remediation sowie gegebenenfalls VEX.

**EN:** This assessment feature changes neither product code nor architecture.
An architecture delta and general S-ADR are therefore `N/A` for this run; any
future component, interface, data-flow, or trust-boundary change invalidates
that decision. Public C# APIs and XML comments remain unchanged, so no API or
XML documentation work is created. DocFX navigation and generated HTML are not
changed; a later navigation or publication change requires regeneration and a
text-oriented accessibility smoke check.

Product TDD and changed-product-code coverage are `N/A` because the `src/` and
`tests/` delta is empty; any later product or test-code change activates the
70 percent minimum and 80 percent target. A public Unix manual page is `N/A`
for the repository-internal validator; distributing the CLI invalidates this
decision. Automated dependency updates are outside this assessment. A critical
finding still blocks delivery and requires separate remediation and VEX where
applicable.

**EN:** The complete row-by-row assessment with all 157 IDs is in
`assessment-matrix.json`. The four assurance gates are in `baseline.json`,
`deltas/rl-se-assessment.json`, `closure.json`, and `image-impact.json`. The
reproducible procedure is in `specs/004-rl-se-self-assessment/quickstart.md`;
the chronological run trail is in
`specs/004-rl-se-self-assessment/autonomous-run-evidence.md`.
