# Ausführungsautorität / Execution authority

## Deutscher Nachweisblock

Stand: 2026-10-10. Thorstens aktueller Implementierungsauftrag und die anschließende Bestätigung erlauben ausschließlich Feature `006-tui-functional-contract` in `LocalImplementation`. T001 und die eng begrenzte Lockdatei-Vorbereitung T005 für die vier vorhandenen Projekte sind ausdrücklich genehmigt. Keine Paketupgrades oder neuen Abhängigkeiten; unerwartete Auflösungsänderungen vor Übernahme melden. Die jüngste Bestätigung erlaubt die Fortsetzung mit später noch zu erbringenden Ausführungsnachweisen, nicht deren Umgehung.

Arbeitsbranch: `006-tui-functional-contract`; unveränderter Ausgangs-HEAD: `ffc3d56a8975341a686ff6985570369abefcfd2a`. Keine Commits, Pushes, Pull Requests, Merges, Admin-Bypasses oder Folgefeatures. Optionale Commit-Hooks bleiben ausgeschaltet. Die Checklisten-Korrektur gleicht ausschließlich dokumentierte Anforderungsqualität und abgeschlossenen Owner-Planreview ab; Produktabnahme bleibt offen.

Freigegebener Plan-Head: `6693ee58aabdc99e1532cea66cb38dc80bb7deda`, Thorstens Review vom 2026-10-08 auf PR #101, gemergt als `541d883127174a178bdb1a1070440253fd23f2b8`. Der lokale Vergleich seit diesem Head zeigt bei Spec/Plan nur Statusfortschreibung und präzisierte Test-first-Grenzen aus PR #102, keine Scope-Erweiterung. Die Tasks wurden anschließend ergänzt und die Producer-Rot-Anforderung konkretisiert. Specify, Plan und Tasks werden nicht erneut gestartet.

Umgebung: Darwin/macOS 27.0, arm64, PowerShell 7.6.6, .NET SDK 10.0.401, MSBuild 18.9.11 und Runtime 10.0.12. Beide vorhandenen Prerequisite-Varianten liefern das richtige Feature-Verzeichnis mit Research, Datenmodell, Verträgen, Quickstart und Tasks. Kein `global.json`. Die TinyCalc-Zeile im Level-2-Register der `constitution.md` und ihre lokale Verfassungsinstanz binden C#/.NET 10, vier Projekte, xUnit/Smoke, DocFX mit Text-A11Y sowie Statistikbasen 80/125 Zeilen pro Arbeitstag. C# ist speichersicher; keine Nicht-MSL-Ausnahme.

Anwendbare Sicherheitsgrundlagen: NIST SSDF und CWE Top 25; sichere C#-Eingabe-/Dateiverarbeitung und STRIDE/CAPEC für relevante Grenzen. SBOM und SLSA sind für verteilbare Artefakte anwendbar; VEX nur bei konkretem Fund. ASVS ist N/A für das lokale TUI ohne Web/API/HTTP-Dienst, Produkt-AI-SBOM N/A bei KI ausschließlich als Entwicklungswerkzeug, Zero Trust N/A für das nicht verteilte Produkt. SAMM und OpenSSF bleiben Pflege-/Supply-Chain-Referenzen. Keine dieser Dispositionen ersetzt spätere technische, Plattform- oder menschliche A11Y-Nachweise.

T003: Der dokumentierte private persönliche Zweck bei öffentlichem Repository bleibt unverändert. Keine neuen Produktdienste, personenbezogenen Testdaten, KI-Runtime, kommerziellen Rollen oder Provider. Historische CRA-/AI-Act-/DSGVO-/NIS2-/DORA-Einzelstatus in `docs/security/regulatory-applicability.md` bleiben erhalten. Neubewertung vor tatsächlich betroffener Produkt-, Daten-, Tool-, Provider-, Organisations- oder Veröffentlichungsscope-Änderung; keine zusätzliche pauschale externe Planfreigabe.

Quellenbindung SHA-256 (UTF-8/LF, vorhandene Dateien ohne BOM):

| Quelle | Hash |
|---|---|
| Intake | `c07016800b9e02e56f123ed6af187d0b5fedd22c1689a1b8909fcc6e8f70c6ac` |
| `spec.md` | `684dd5ac160ef3f7883c4a7a176e76c153bcd6e73114a6b070113c35a62c216f` |
| `plan.md` | `060950bad2cbd077c704bd3d285a3778fb33ffaf1739864beaeb6ef8bbcfe869` |
| `tasks.md` vor Fortschrittsmarkierung | `c49f36c3112a35f1a8749a535d52f252bf068c7c4195b76701e95594331d20b9` |

## English evidence block

On 2026-10-10, the owner's implementation request and confirmation authorize only feature 006 on its own branch in LocalImplementation mode. T001 and bounded generation/review of four missing product/test locks are approved. No upgrades, new dependencies, commits, pushes, PRs, merges, bypasses or follow-up features. Unexpected resolution changes require a decision before adoption. Proceeding with future proof pending does not waive any material gate.

The approved plan review and merged planning/task bases remain valid. The targeted diff contains status updates and stricter test-first boundaries, not a new feature. Both prerequisite variants resolve the intended artifacts. The environment and source hashes above bind this checkpoint, not product acceptance. The Level-2 registry, secure-development standards and 80/125 statistics references remain unchanged. Private personal purpose and public repository visibility introduce no new regulatory trigger; preserve historical dispositions and reassess before an affected scope change. Required functional, platform and human accessibility proof remains future work.

## Nachfolgende Lieferfreigabe / Subsequent delivery authority

Deutsch: Am 2026-10-10 genehmigt Thorsten ausdrücklich Commit und Push sowie
DeliveryMode MergeAndSync mit Admin-Bypass. Diese jüngere Freigabe ersetzt das
oben historisch dokumentierte Lieferverbot, nicht die materiellen Gates. Der
vorliegende Stand mit 39/83 nachgewiesenen Tasks wird als Zwischenstand auf dem
Feature-Branch und in einem Draft-PR gesichert. Kein Merge vor vollständiger
technischer, Plattform-, Security-, A11Y-, Evidenz- und Produktabnahme; Bypass
ausschließlich für formale Merge-Regeln. Keine Serienpromotion, Intake-Archivierung
oder Folgefeatures. Optionale Commit-Hooks bleiben ausgeschaltet.

English: On 2026-10-10, Thorsten explicitly authorises commit/push and MergeAndSync
with admin bypass. This newer authority supersedes the historical delivery
prohibition above, not material gates. Save the 39/83-task checkpoint on its
feature branch with a draft PR. Merge requires complete technical, platform,
security, accessibility, evidence and product acceptance; bypass applies only to
formal merge rules. No series promotion, intake archival or follow-up feature.
Optional commit hooks remain disabled.

## Zusätzliche begrenzte Freigaben / Additional bounded approvals

Deutsch, 2026-10-10: Thorsten hat die temporäre versionierte axe-Prüfumgebung
außerhalb des Repositories und einen unabhängigen read-only Review-Agenten
ausdrücklich genehmigt. Keine Produkt-/NuGet-Upgrades, dauerhafte Codex-Settings,
VoiceOver-Ersatznachweise oder Owner-Produktabnahme sind darin enthalten.

English: Thorsten explicitly authorised temporary version-pinned external axe
tooling and one independent read-only reviewer. This does not authorise product
package upgrades, persistent Codex settings, synthetic human evidence or owner
product acceptance.
