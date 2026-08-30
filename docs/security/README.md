# Sicherheitsdokumentation: TinyCalc

## Deutscher Index

Repository: TinyCalc, Level 2

Stand: 2026-08-30

Constitution: Principles XII–XVIII

Die Sicherheitsdokumentation für Feature 003 ist lokal abgeschlossen. Der
Status ist keine Mergefreigabe: Linux, Windows, Provider-Review, Provenance und
Exact Head bleiben bis zu den späteren Delivery-Gates `Pending`.

Die Dokumente sind Deutsch zuerst und Englisch danach aufgebaut. Tabellen,
ASCII-Diagramme und lineare Textalternativen bleiben in Textbrowsern, mit
Screenreadern und auf Braillezeilen verständlich.

### Pflichtartefakte

| Dokument | Feature-003-Status | Hauptinhalt oder begründete N/A-Entscheidung |
|---|---|---|
| [Bedrohungsmodell](threat-model.md) | lokal abgeschlossen; Plattform/Exact Head Pending | STRIDE, CIA, CAPEC-153/-538, vier Trust Boundaries und Residualrisiken |
| [Sicherheits-Checkliste](security-checklist.md) | lokal Pass | NIST SSDF, CWE Top 25, C#/.NET, Inputs, Lifecycle, Fehler und Dependencies |
| [arc42 Section 8](arc42-security.md) | abgeschlossen | Lifecycle, Trust Boundaries, Fehler, Logging, Abhängigkeiten, Deployment und N/A-Register |
| [Abhängigkeits-Audit](dependency-audit.md) | lokal Pass; Exact Head Pending | 1 direkte + 23 transitive Pakete, 0 bekannte Schwachstellen, 0 offene Lizenzen |
| [Security-Qualitätsszenarien](security-quality-scenarios.md) | lokal Pass; Provider Pending | manipulierte Taste, Paketmanipulation und sichere Beendigung |
| [ASVS-Anwendbarkeit](asvs-verification.md) | geprüft N/A | keine Web-/API-/Auth-Fläche; Trigger in arc42 Abschnitt 11 |
| [Supply-Chain-Evidenz](supply-chain-evidence.md) | lokal Pass; Provenance/Exact Head Pending | SPDX-SBOM, VEX, AI-SBOM, SLSA v1.2 und OpenSSF-Review |
| [Zero-Trust-Anwendbarkeit](zero-trust-applicability.md) | geprüft N/A | lokaler Einprozessbetrieb; Trigger in arc42 Abschnitt 11 |
| [SAMM-Review](samm-assessment.md) | reviewed, unchanged | migrationsbezogener Prozessreview ohne Nebenprojekt |
| [S-ADR-003](adr/003-terminalgui-lifecycle-supply-chain.md) | akzeptiert | creator-owned Lifecycle und fail-closed Lieferkette |
| [SPDX-2.3-SBOM](sbom/tinycalc-terminalgui.spdx.json) | gültig lokal; Exact Head Pending | Syft 1.51.0, alle 24 ausgelieferten NuGet-Pakete enthalten |

### Ergänzende Artefakte

| Dokument | Status | Zweck |
|---|---|---|
| [S-ADR-Index](adr/README.md) | aktuell | Index der Security Architecture Decision Records |
| [GSDB-Selbsteinschätzung](gsdb-self-assessment.md) | bestehender Preflight | sichere Entwicklungsrichtlinie und Preset-Voraussetzungen |
| [Feature-Architektur](../architecture/terminalgui-migration.md) | abgeschlossen | Kontext-, Baustein-, Laufzeit-, Deployment-, Qualitäts- und Risikosichten |
| [Feature-Evidenz](../../specs/003-terminalgui-migration/evidence/) | lokal fortgeschrieben | Befehle, Hashes, Tests, PTY, Coverage, Pakete und Checkpoints |

### Gültigkeits- und Review-Regeln

- Ein neuer Trust Boundary, eine neue Datei-/Netzwerk-/Auth-Fläche oder eine
  zweite App-Instanz öffnet Architektur, Threat Model, Checkliste und S-ADR.
- Ein Restore, Paket-, Quellen-, Advisory- oder Lizenzwechsel öffnet Dependency
  Audit, SBOM und Supply-Chain-Evidenz.
- Ein Produkt-, Workflow- oder Commitwechsel öffnet Build, Tests, Smoke,
  Coverage, Plattform- und Exact-Head-Belege.
- Admin-Bypass darf nur eine formale Merge-Policy betreffen und ersetzt kein
  fachliches, Security-, A11Y-, Plattform-, Review- oder Exact-Head-Gate.

## English index

The Feature 003 security documentation is locally complete. This is not merge
approval: Linux, Windows, provider review, provenance, and exact-head evidence
remain pending until the later delivery gates.

The mandatory table above indexes the threat model, secure-coding checklist,
arc42 Section 8, dependency audit, measurable security scenarios, ASVS and
Zero Trust applicability decisions, supply-chain evidence, SAMM review, the
focused security ADR, and the SPDX SBOM. Each document is German first and
English second, with text-first diagrams and linear alternatives.

Any new trust boundary, input or I/O surface, application instance, package,
source, advisory, license, product/workflow change, or commit invalidates the
matching evidence. Admin bypass can address only a formal merge policy and
cannot replace technical or review gates.
