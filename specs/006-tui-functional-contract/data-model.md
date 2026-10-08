# Datenmodell / Data model

Dieses Design beschreibt zukünftige Prüfartefakte, nicht ein neues Tabellenformat oder bereits ausgeführte Evidenz. Pflichtfelder werden beim Implementieren strukturell und semantisch geprüft; unbekannte Schema-Versionen und zusätzliche nicht erlaubte Felder blockieren.

*This models future validation artifacts, not spreadsheet storage or completed evidence. Validate structure and semantics; reject unsupported versions and fields.*

## Entitäten / Entities

| Entität / Entity | Pflichtfelder und Regeln / Required fields and rules |
|---|---|
| ContractRevision | `schemaVersion`, `revision`, `intakeHash`, `baselineDigest`, `sourceMapDigest`, `requirements`, `capabilities`. Revision monoton; alle 17 FR und sechs AC/SC verbunden, Quellhash entspricht Intake. / Monotonic revision, complete requirements and source binding. |
| Capability | `id`, `family`, `status` (Active/Deprecated/Retired), `mandatory`, `surfaceRefs`, `platforms`, `paths`, `requirementRefs`, `acceptanceRefs`. ID eindeutig, nie wiederverwendet; alle Baselinefamilien bleiben vertreten. / Unique never-reused identity and complete family coverage. |
| InteractionPath | `pathId`, `input`, `preconditions`, `steps`, `expectedState`, `expectedText`, `scenarioKind` (Success/Cancel/Error), `testRefs`, `automatable`, `humanSupplementReason`. Jeder Alias/Angebotsweg einzeln; jeder automatisierbare Weg braucht ausgeführten Test. / Every offered path has its own executed proof. |
| SourceMapping | `sourcePath`, `sourceHash`, `anchor`, `offerKind` (Substantive/DocumentationDefect), `capabilityRefs`, `defectRef`. Hash-/Ankerprüfung plus inhaltliches Review; keine stille Offer-Entfernung. / Trace sources and reviewed defect classification. |
| EvidenceBundle | `runId`, `commit`, `workingTreeDigest`, `contractDigest`, `pinDecisionDigest`, `platform`, `runner`, `job`, `command`, `toolVersions`, `startedAt`, `finishedAt`, `exitCode`, `payloadDigest`, `results`. UTC-Zeiten; reale Plattform, expliziter lokaler Jobwert statt erfundenem CI-Job. / Bind execution identity and payload. |
| PathResult | `capabilityId`, `pathId`, `kind` (Automated/HumanSupplement), `outcome` (Pass/Fail/Skipped/NotAssessed), `testRef`, `assertionProofRef`, `observedState`, `artifactRefs`. Skipped/NotAssessed kein Pass; HumanSupplement ersetzt keine Automation. / Honest outcomes and separate supplementary proof. |
| PinDecision | `dependency`, `resolvedVersion`, `approvalRef`, `declarationRefs`, `lockRefs`, `sourceRefs`, `comparisonEvidence`, `state` (AlreadySatisfied/Drift/Blocked), `requiredGates`, `decisionDigest`. Fehlende/floating/unfreigegebene Daten → Blocked; keine Upgradeaktion. / Resolve actual approved pin, no automatic upgrade. |
| ImpactDecision | `classes`, `changedPaths`, `reason`, `requiredGates`, `reviewer`, `decisionDigest`. Fünf Klassen aus Spec; Unsicherheit → FunctionalImpact+A11yImpact. / Fail-safe impact selection. |
| DriftFinding | `code`, `sourceRef`, `capabilityRef`, `expected`, `actual`, `category`, `blocking`, `owner`, `followUp`. Dokumentationsdefekt separat, aber unbehobene relevante Drift blockiert. / Distinguish defect classes without waiving consistency. |
| ChangeAuthority | `id`, `affectedIds`, `kind`, `approvalRef`, `date`, `successorIds`. Nur explizite genehmigte Deprecation/Breaking Change erlaubt Entfernung; Geschichte erhalten. / Preserve removal authority and history. |

Review-Ergänzung: InteractionPath benötigt außerdem `context`, `scenarioApplicability`, `sourceSemanticsRef`, `allowedMutations` und `focusAfter`. ImpactDecision bindet `interactionTimeoutSeconds`, `sessionTimeoutSeconds`, `cleanupTimeoutSeconds` und je numerischem Orakel `toleranceRef`. Fehlende fachliche Szenarien dürfen nicht als N/A verschwinden: der Grund muss aus der Angebotssemantik folgen und reviewt sein. RQ-001–RQ-003 werden als blockierende DriftFindings mit Owner, Aktion und Freigabegrenze geführt.

*Additional fields bind context, scenario applicability, source semantics, allowed mutations, focus, deadlines and numeric tolerances. Scenario exclusions need a reviewed source rationale. Preserve all three findings with their current decision status; only unresolved findings remain blocking.*

Aktueller Klärungsstand: RQ-001 erhält Resolved mit Referenz auf Nutzerantwort A; seine Pfade unterscheiden `context=Grid` (Palette) und `context=Editor` (Slash-Text/Division). RQ-002/RQ-003 bleiben Open/blocking. Der ursprüngliche Befund und seine Entscheidung bleiben historisch erhalten; Produkt-/Quellenangleichung ist separat nachzuweisen.

*RQ-001 is now Resolved with user-answer reference and separate grid/editor paths. The other two findings remain blocking; source and product proof are separate obligations.*

Zweite Antwort A: RQ-002 ebenfalls Resolved. InteractionPath unterscheidet nun Raster, Editor und Befehlsauswahl; jeder historische Alias bleibt einzeln inventarisiert. Beispiele: Ctrl-G Raster→rechts/Editor→rechts löschen; Raster-Slash→Neuzeichnen und Palette/Editor-Slash→Text. Nur RQ-003 bleibt semantisch Open; Ausführungsnachweise bleiben separat.

Dritte Antwort A: FACT-Orakel bindet `sourceSemanticsRef` an die FACT-Klärung der Spec: Argument ganzzahlig und 0 bis 33, Null ergibt 1, sonst verständlicher Fehler ohne Truncation. Erfolg, beide Grenzen und abgewiesene Bruchteile/negative/zu große Argumente sind eigene Szenariotupel. RQ-003 bleibt für übrige Formelsemantik Open; kein Ausführungsnachweis.

*The third answer A binds FACT expectations to the specification clarification: integers 0 through 33, zero returns 1, otherwise a clear error without truncation. Record separate success, boundary and error tuples; remaining formula semantics is Open and untested.*

*The second answer A resolves historical offers with separate grid, editor and command-selection paths. Preserve individual aliases; only formula semantics remains Open.*

Abdeckungsnenner: alle aktiven Pflicht-ID/Pfad/Plattform/anwendbaren Szenario-Tupel. Ein Resultat pro Tupel, keine doppelte Zählung durch mehrere Artefakte; jede Plattform separat vollständig. HumanSupplement zählt nie als Automated. Der Quellenkatalog muss die zusätzlich entdeckten historischen Hilfeangebote aufnehmen, auch solange ihr Konflikt noch Open ist.

*Count complete obligation tuples without duplicate artifact counting. Each platform must pass independently; supplementary human evidence never counts as automation. Retain unresolved offered capabilities in the inventory.*

`expectedState` enthält fachliche Orakel wie aktuelle Adresse, Contents/Typ/Value/Flags, AutoCalc, Fokus-/Dialogzustand und Dateihashes. Es enthält keine ungeprüft ausführbare Expression. Zahlen-/Formel-Toleranzen werden je Test begründet, keine pauschale Toleranz für exakte Text-/Dateiinvarianten.

*Expected state is typed observable data, not executable input. Numeric tolerances are justified per case; exact text/file invariants stay exact.*

## Beziehungen und Gültigkeit / Relationships and validity

Eine Revision enthält viele Capabilities, jede viele Pfade. Quellen können mehrere Capabilities anbieten. Jeder aktive Pflichtpfad muss zur aktuellen Revision passende Automationsresultate auf seinen Pflichtplattformen haben; zusätzliche menschliche Nachweise werden separat verlangt, wenn Impact das auslöst. Belege binden denselben Produktcommit und dieselbe Vertragsrevision. Unterschiedliche historische Checkpoints dürfen nicht zu einer scheinbaren Gesamtfreigabe gemischt werden.

*A revision has capabilities and paths, linked to sources and current platform proof. Bind one product commit and contract revision; do not combine historic checkpoints into a false full pass.*

Ein neuer Evidence-only-Commit ist keine erlaubte Ausnahme von finaler Commitgleichheit: seine neue Abschlussentscheidung benötigt neu gebundene Pflichtläufe. Alte Resultate bleiben historische Evidence und dürfen nicht durch Metadatenänderung auf den neuen Commit umetikettiert werden.

*Evidence-only commits do not waive exact final-head proof; keep older runs historical instead of relabelling them.*

Ein Arbeitsbaumdigest unterstützt lokale Rot-/Grün-Zwischenstände, ersetzt aber keine finale Commitbindung. Bundle-/Decision-Digests verwenden SHA-256 über definierte UTF-8/LF-Bytes. Der Digest eines Objekts wird ohne sein eigenes Digestfeld gebildet; der Algorithmus und die kanonische Feldreihenfolge werden im Implementierungsschema festgelegt und durch Paritätsfixtures gebunden. Resultate werden atomar außerhalb des Read-only-Validators erzeugt.

*Working-tree digests identify local intermediate runs but do not replace final commit binding. SHA-256 excludes self-digest fields and uses a documented canonical byte representation tested by fixtures. Producers, not the validator, write results.*

## Zustände / States

Vertrags-ID: Entwurf vor Aktivierung → Active → nur mit ChangeAuthority Deprecated → Retired. Retired bleibt als Tombstone erhalten; Rückkehr derselben fachlichen Funktion verwendet den genehmigten bestehenden Vertrag oder eine neue additive ID, niemals Recycling für andere Semantik.

*An ID becomes active, then may be deprecated and retired only with explicit authority; keep tombstones and never recycle identities.*

Preflight: unbekannt → Blocked bei fehlender Freigabe/Deklaration/Lockquelle; kohärente Quellen → AlreadySatisfied bei passend gebundener Vergleichsevidenz oder Drift bei geänderter Auflösung/fehlender Vergleichsgültigkeit. Drift verlangt vollständige neue Kompatibilitäts-/PTY-/A11Y-Evidenz. Ein gleiches Versionslabel allein führt nicht zu AlreadySatisfied.

*Missing sources block. Coherent sources allow reuse only with matching proof; changed or invalid comparison evidence requires full drift validation.*

Abnahme: NotAssessed → Blocked solange Pflichtbelege fehlen/abweichen → ReadyForIndependentReview bei vollständigen bestandenen technischen Gates → Accepted nur nach unabhängiger und erforderlicher menschlicher Prüfung. Produktfunktion, technisches Gate, Owner-Freigabe und Serienabschluss sind getrennte Entscheidungen.

*Technical completeness enables independent review, not automatic owner acceptance or series completion.*

Vierte Antwort A: Operator-Orakel unter `OP-*` binden `sourceSemanticsRef` an die Operator-Klärung der Spec. Potenzketten rechts, Vorzeichen nach Potenz, Klammern zuerst; Erfolgstupel enthalten alle sieben Spec-Beispiele. RQ-003 bleibt für numerische Definitions-/Ergebnisgrenzen Open, nicht für diese Bindungsregeln.

*Operator expectations bind the fourth answer A and all seven specification examples under OP-*. Numeric domain/result boundaries remain Open; operator binding is resolved but untested.*

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
