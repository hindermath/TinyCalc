# Data Model: RL-SE-/Checklist-Selbstpruefung

## Ueberblick / Overview

Die fachliche Quelle bleibt Markdown; die maschinenpruefbare Instanz ist JSON.
Alle Identitaeten sind ordinal und case-sensitive.

*Markdown remains the domain source; JSON is the machine-verifiable instance.
All identities use ordinal, case-sensitive comparison.*

## Entities

### BaselineBinding

| Field | Type | Rule |
|---|---|---|
| `manifestPath` | string | exakt `docs/secure-development/baseline-manifest.json` |
| `baselineVersion` | string | exakt wirksame Manifestversion |
| `manifestNormalizedSha256` | digest | lowercase SHA-256 nach UTF-8/LF-Normalisierung |
| `documentBindings` | array | exakt alle vom Manifest kontrollierten Textdokumente, eindeutiger Pfad und Hash |

### AssessmentDocument

| Field | Type | Rule |
|---|---|---|
| `schemaVersion` | string | `1.0` |
| `assessmentId` | string | `rl-se-self-assessment-2026-09-05` |
| `baseline` | object | Baseline-Version, Manifestpfad und Hash |
| `sourceFiles` | array | genau 12 kanonische CL-Dateien in Manifestreihenfolge |
| `rows` | array | genau 157 `AssessmentRow`-Objekte |
| `summary` | object | Zaehlungen je Status und Familie; Summe immer 157 |

### AssessmentRow

| Field | Type | Required invariant |
|---|---|---|
| `id` | string | `^CL-(0[1-9]|1[0-2])-[0-9]{2}$`, kanonisch, genau einmal |
| `sourcePath` | string | repository-relativer Pfad der passenden Einzelcheckliste |
| `disposition` | enum | `Applicable`, `AlreadySatisfied`, `N/A`, `Open`, `FollowUp` |
| `applicability` | enum | `Applicable`, `N/A`, `Open` |
| `implementationStatus` | enum | `Fulfilled`, `Partly Fulfilled`, `Not Fulfilled`, `Not Assessed` |
| `rationale` | string | nicht leer, fachlich konkret |
| `evidence` | string array | relative lokale Pfade; leer nur bei ausdruecklichem Open-Marker |
| `openMarker` | boolean | wahr, wenn keine ausreichende positive Evidenz vorliegt |
| `owner` | string | Rollenbezeichnung, keine private Kontaktdaten |
| `followUp` | string | konkrete Aktion oder begruendetes `None` |
| `priority` | enum | `Critical`, `High`, `Medium`, `Low`, `None` |
| `risk` | string | konkretes Risiko oder begruendetes `None` |
| `reevaluationTrigger` | string | beobachtbares Ereignis, nie leer |
| `residualRisk` | string | verbleibendes Risiko oder begruendetes `None` |
| `humanOnly` | boolean | trennt menschliche Entscheidung von technischer Evidenz |
| `humanDecisionEvidence` | string | in diesem Lauf exakt `NotProvided`; keine technische Evidenz wird als menschliche Freigabe umgedeutet |

## Cross-field Invariants

1. `AlreadySatisfied` = `Applicable` + `Fulfilled`, `openMarker=false`,
   mindestens ein existierender Evidenzpfad.
2. `Applicable` nutzt Anwendbarkeit `Applicable`; ohne vollstaendige Evidenz
   darf der Umsetzungsstand nicht `Fulfilled` sein.
3. `N/A` = `N/A` + `Not Assessed`, `priority=None`; Begruendung und Trigger
   bleiben Pflicht.
4. `Open` nutzt `openMarker=true`, einen Umsetzungsstand ungleich `Fulfilled`,
   Owner, Folgeaktion, Prioritaet ungleich `None` und konkretes Risiko.
5. `FollowUp` nutzt eine fachlich passende Anwendbarkeit, Owner, Folgeaktion,
   Prioritaet ungleich `None`, Risiko und Trigger.
6. `humanOnly=true` verlangt `humanDecisionEvidence=NotProvided`, Disposition
   `Open` oder `FollowUp` und einen Umsetzungsstand ungleich `Fulfilled`.
7. Lokale Evidenzpfade duerfen nicht absolut sein, kein `..` enthalten und
   muessen innerhalb des Repositorys auf eine vorhandene Datei zeigen.
8. Der Familienprefix der ID muss zum `sourcePath` passen.
9. Die sortierte Zeilen-ID-Menge muss bytegleich zur sortierten kanonischen
   ID-Menge sein; Summary-Zaehlungen muessen aus den Zeilen ableitbar sein.

## State Transitions

```text
Not assessed
  -> N/A + Not Assessed
  -> Open + Not/Partly Fulfilled
  -> Applicable + Not/Partly Fulfilled
  -> AlreadySatisfied + Fulfilled

Open/Applicable
  -> FollowUp                 (bewusst spaeter, mit Owner und Trigger)
  -> AlreadySatisfied         (erst nach belastbarer Evidenz)

Any state
  -> reassess                 (Baseline-, Architektur-, Produkt-, Rechts- oder Evidenzaenderung)
```

Kein technischer Uebergang erteilt Pilotfreigabe, Projektabnahme oder
allgemeine Freigabe. Diese Entscheidungen bleiben in `closure.json` getrennt.

*No technical transition grants pilot authorization, project acceptance, or
general release. Those decisions remain separate in `closure.json`.*

## Validation Failure Classes

- `RLSE001`: Schema, JSON oder Pflichtfeld ungueltig.
- `RLSE002`: Kanonische ID fehlt, ist doppelt oder unbekannt.
- `RLSE003`: Disposition und beide Achsen widersprechen sich.
- `RLSE004`: Evidenzpfad unsicher, fehlt oder belegt eine positive Aussage
  nicht ausreichend.
- `RLSE005`: Open/FollowUp/N/A-Pflichtdaten fehlen.
- `RLSE006`: Human-only-Grenze verletzt.
- `RLSE007`: Summary, Familienzuordnung oder Baseline-Bindung driftet.
