# Cloud-Autonomie-Anwendbarkeit / Cloud Autonomy Applicability

## Feature-005-C3A-Bewertung / Feature 005 C3A assessment

## Deutscher Prüfblock

| Feld | Entscheidung |
|---|---|
| Prüftag | 2026-09-06 |
| Quelle | [BSI C3A – Criteria enabling Cloud Computing Autonomy](https://www.bsi.bund.de/SharedDocs/Downloads/EN/BSI/Publications/CloudComputing/C3A_Cloud_Computing_Autonomy.html?nn=520690) |
| Scope | Repository-, CI- und Artefaktprovider; nicht die lokale TUI-Laufzeit |
| Status | `Applicable`, teilweise erfüllt; keine Anbieterfreigabe |
| Owner | Repository-Maintenance-Rolle |
| Reviewer | unabhängige technische Security-Review-Rolle; Beschaffungs-/Rechtsprüfung Human-only |

C3A betrachtet strategische, rechtliche, Daten-, Betriebs-, Lieferketten- und
Technologie-Souveränität. Für TinyCalc sind Quellverfügbarkeit, Export,
Identitätskontrolle, Abhängigkeitswechsel, Providerwechsel und
Wiederherstellbarkeit relevant. Lokale Git-Kopien und offene Quellformate
reduzieren Bindung, beweisen aber keine Providerautonomie. Vertrags-,
Jurisdiktions- und Exit-Zusagen liegen nicht als geprüfte menschliche Evidenz
vor und bleiben `Open`.

Trigger sind Provider-, Vertrags-, Jurisdiktions-, Identitäts-, Export-,
Backup- oder Lieferkettenänderungen. Restrisiko sind externe Providerkontrolle,
fehlende formale Exit-Übung und fehlende Rechts-/Beschaffungsfreigabe.

## English review block

BSI C3A is reviewed for repository, CI, and artifact providers, not for the
local TUI runtime. Source availability, export, identity control, dependency
replacement, provider exit, and recovery are applicable. Local Git copies and
open formats reduce lock-in but do not prove provider autonomy. Contractual,
jurisdictional, and exit assurances remain open Human-only work.
