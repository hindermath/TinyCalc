# Regulatorische Anwendbarkeit / Regulatory Applicability

## Feature 005 technical screening / Technische Vorprüfung Feature 005

## Deutscher Prüfblock

Prüftag ist 2026-09-06. Diese technische Vorprüfung ist keine Rechtsberatung.
Owner ist die Repository-Maintenance-Rolle. Die endgültige rechtliche
Anwendbarkeit und Risikoakzeptanz sind Human-only; Reviewer ist eine zuständige
Rechts-/Datenschutz-/Compliance-Rolle, deren Entscheidung nicht vorliegt.

| Regelwerk und Primärquelle | Technischer TinyCalc-Scope | Status | Trigger und Restrisiko |
|---|---|---|---|
| [NIS2, Richtlinie (EU) 2022/2555](https://eur-lex.europa.eu/legal-content/DE/TXT/?uri=celex%3A32022L2555) | Lokale Open-Source-TUI; keine belegte wesentliche/wichtige Einrichtung | `Open`, Human-only | Betreiber-, Sektor-, Größen- oder Lieferrollenänderung; nationale Umsetzung und Organisationskontext fehlen |
| [CRA, Verordnung (EU) 2024/2847](https://eur-lex.europa.eu/legal-content/EN/TXT/?uri=CELEX%3A02024R2847-20241120) | Verteilbares Produkt mit digitalen Elementen kann betroffen sein | `Open`, Human-only | Marktbereitstellung, wirtschaftliche Rolle, Distribution oder Release ändert sich; Herstellerpflichten rechtlich klären |
| [EU AI Act, Verordnung (EU) 2024/1689](https://eur-lex.europa.eu/eli/reg/2024/1689/oj?locale=de) | Keine KI-Runtime im Produkt; KI nur Entwicklungswerkzeug | Produkt `N/A`, Human-only nicht bestätigt | Modell, Dataset, Inferenzdienst oder KI-Funktion wird Teil des Produkts/Betriebs |
| [DORA, Verordnung (EU) 2022/2554](https://eur-lex.europa.eu/legal-content/EN/ALL/?uri=celex%3A32022R2554) | Kein belegtes Finanzunternehmen oder kritischer IKT-Drittdienst | `Open`, Human-only | Einsatz durch erfasste Finanzentität oder Einstufung als IKT-Drittdienst |
| [DSGVO, Verordnung (EU) 2016/679](https://eur-lex.europa.eu/legal-content/DE/TXT/?uri=CELEX%3A32016R0679) | Produkt ohne sichtbare personenbezogene Daten; Repository/Provider mit möglichen Accountdaten | Produkt `N/A`, Delivery `Applicable`, Human-only | Telemetrie, Nutzerkonto, personenbezogene Datei, Support- oder Providerprozess |

Die offene CRA-Frage ist wegen des verteilbaren Artefakts besonders wichtig.
Keine Zeile wird ohne zuständige menschliche Entscheidung als rechtlich
freigegeben markiert. Restrisiken und Folgearbeit bleiben in der Matrix sichtbar.

## English review block

Review date is 2026-09-06. This is technical screening, not legal advice.
NIS2, CRA, DORA, and delivery-side GDPR scope remain open for qualified human
review. Product AI Act scope is currently not applicable because no AI runtime
ships; any model, dataset, inference service, or AI feature reopens it. Product
GDPR scope is currently not applicable to the observed local TUI, while
repository and provider account data keep delivery privacy applicable. No
legal approval is inferred.
