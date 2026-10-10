# S-ADR-004: TUI-Vertrag und Nachweisgrenzen / TUI contract and proof boundaries

## Deutscher Sicherheitsblock

Feature 006, Phase Implement, 2026-10-10, Branch `006-tui-functional-contract`.
Basis `ffc3d56a8975341a686ff6985570369abefcfd2a`, kein PR/Commit-Auftrag.
Status Entwurf nach genehmigtem Plan; unabhängiger Review Open, Owner
Feature-Entwicklung, Trigger vor Abnahme. ISO A.8.27/A.8.28, Constitution XII–XVIII,
SSDF/CWE sind anwendbar. Dieses Dokument ist keine Auditierung oder Zertifizierung.

Entscheidung: Tastatur/Formeln, Dateien/Hilfe, NuGet und Evidenz sind getrennte
Vertrauensgrenzen. Produkt akzeptiert keine ausführbaren Ausdrücke aus
Vertrags-JSON. Validator nutzt strikte lokale Schemas, sichere Repository-Pfade,
Hash-/Quell-/Pin-/Head-Bindungen und unabhängige Baseline. Er führt keine Befehle,
Downloads, Installationen, Tests oder Restore aus. Fail-safe: unbekannte,
fehlende, doppelte, übersprungene oder zeitüberschrittene Pflichtresultate sperren.
Least Privilege: keine Secrets, Provider oder fremden Prozesse im Prüflauf;
Producer besitzen nur ihre Ausgabedateien und temporären Ressourcen.

Defense in Depth: reale unabhängige Assertions plus vollständiger Tupelabgleich;
strikte Strukturprüfung plus semantische Source-/Digestprüfung; gestufte
Dateivalidierung plus atomare Zustandsübernahme bei später bestätigtem Load-Defekt.
Kein unconditional Pass und keine bloß selbst behauptete Soll-Digestbindung.

Alternativen ohne unabhängigen Nenner, mit JSON-Befehlsausführung oder Smoke als
Gesamtfreigabe wurden verworfen. Restrisiken: kompromittierter Registry-/Runner-
oder Reviewer-Kontext; daher SBOM/Provenance, datierter Audit und unabhängige
Abnahme. ASVS/Produkt-AI-SBOM/Zero Trust bleiben im lokalen Scope begründet N/A;
KI ist Entwicklungswerkzeug, kein ausgelieferter Dienst. VEX bei konkretem Fund.
Human-A11Y, native Plattformen und Secure-Development-Review bleiben offen.

## English security block

The feature's proposed implementation decision separates keyboard/formula,
file/help, registry and evidence trust boundaries. SSDF/CWE, ISO A.8.27/A.8.28 and
the named constitution principles apply. Independent review remains Open before
acceptance; no certification is claimed.

Use strict local schemas, safe rooted paths, source/pin/head hashes, independent
obligations and actual assertions. The validator never executes JSON commands,
fetches, restores, installs or starts tests. Missing/duplicate/skipped/timed-out
proof fails closed. Producers own only their files/resources. Independent
assertions plus tuple completeness and structure plus semantic bindings provide
two layers. Staged load validation and atomic application require test-first
proof of an actual defect. Registry/runner/reviewer compromise remains residual
risk addressed by audit, provenance and independent acceptance. Local-product
ASVS/AI-SBOM/Zero Trust are N/A with their existing scope triggers; VEX is
conditional. Native platforms, human accessibility and secure review remain open.
