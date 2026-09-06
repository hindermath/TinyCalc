# Cloud-Compliance-Assurance / Cloud Compliance Assurance

## Feature-005-C5-Bewertung / Feature 005 C5 assessment

## Deutscher Prüfblock

| Feld | Entscheidung |
|---|---|
| Prüftag | 2026-09-06 |
| Quelle | [BSI C5: Kriterienkatalog Cloud Computing](https://www.bsi.bund.de/SharedDocs/Downloads/DE/BSI/Publikationen/Broschueren/C5_2020.pdf?__blob=publicationFile&v=3) |
| Scope | Repository-, CI- und Artefaktprovider |
| Status | `Applicable` als Assurance-Prüfung; Provider-Testat `NotProvided` |
| Owner | Repository-Maintenance-Rolle |
| Reviewer | unabhängige technische Security-Review-Rolle; Testatbewertung Human-only |

C5 beschreibt Sicherheitskriterien und die geteilte Verantwortung zwischen
Cloudanbieter und Kunde. Lokale Workflow-, Secret-, Abhängigkeits- und
Delivery-Evidenz deckt nur die Kundenseite teilweise ab. Ein C5-Testat ist laut
BSI keine BSI-Zertifizierung und ersetzt nicht die Bewertung des konkreten
Dienstes. Deshalb wird weder Zertifizierung noch Providerfreigabe behauptet.

Trigger sind Provider-, Service-, Region-, Vertrags-, Kontroll- oder
Testatänderungen. Restrisiko bleiben nicht vorliegende aktuelle Testate,
Providerkontrollen und die menschliche Bewertung der Verantwortungsteilung.

## English review block

BSI C5 is applicable as an assurance lens for repository, CI, and artifact
providers. Local workflow, secret, dependency, and delivery evidence covers
only part of the customer responsibility. No current provider attestation was
supplied, and no BSI certification or provider approval is claimed. Provider,
service, region, contract, control, or attestation changes reopen the review.
