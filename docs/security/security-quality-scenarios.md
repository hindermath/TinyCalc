# Sicherheits-Qualitätsszenarien: TinyCalc Feature 003

## Deutscher Szenarioblock

### Laufnachweis und Methode

| Feld | Wert |
|---|---|
| Projekt | TinyCalc, Level 2 |
| Feature | 003, Terminal.Gui-v2-Migration |
| Branch | `003-terminalgui-migration` |
| Baseline | `886a13f8866e79fe6c13e6e1227217294aabdee8` plus geprüfter Arbeitsbaum; Exact Head folgt |
| Datum | 2026-08-30 |
| Methode | iSAQB CPSA-F-Qualitätsszenarien, ISO A.8.27/A.8.28 |
| Owner | Feature 003 |
| Reviewer | Security-/PR-Review am unveränderten Exact Head |
| Entscheidung | drei Feature-Szenarien anwendbar; lokal belegt, Provider-/Exact-Head-Abschluss offen |

Jedes Szenario benennt Quelle, Stimulus, Artefakt, Umgebung, Reaktion und
Messwert (Antwortmetrik). Beobachtete lokale Evidenz wird als lokal verifiziert bezeichnet.
Noch nicht ausgeführte Provider- oder Exact-Head-Prüfungen bleiben `Pending`.
Dieses Dokument behauptet keinen Penetrationstest.

### QS-TG-SEC-001: Manipulierte oder unerwartete Taste

| Element | Beschreibung |
|---|---|
| Quelle | lokale Person oder fehlerhafte Terminal-Ereignisfolge an TB-1 |
| Stimulus | eine Taste außerhalb der 13 gebundenen Eingaben oder eine unerwartete Reihenfolge trifft Root oder Dialog |
| Artefakt | `MicroCalc.Tui.Program`, Fokuszustand und geschlossene Tastenzuordnung |
| Umgebung | interaktive Terminal.Gui-v2-Sitzung; normale lokale Bedienung |
| Reaktion | keine dynamische Ausführung und keine privilegierte Aktion; bekannte Tasten behalten genau ihre Bedeutung; Root oder aktiver Dialog bleibt kontrolliert |
| Messwert | Quellvertrag: genau 13 Bindungen (`8 + 4 + 1`), 0 alte Ctrl-/Alt-Masken; zwei reale PTY-Sitzungen enden ohne Traceback; unbekannte Eingabe fügt keinen Handler hinzu |
| Lokale Evidenz | `specs/003-terminalgui-migration/evidence/source-contract-green.md`, `manual-tui.md`, `docs/accessibility/terminalgui-migration.md` |
| Status | lokal verifiziert; Linux/Windows und Exact Head `Pending` |

### QS-TG-SEC-002: Manipuliertes Open-Source-Paket

| Element | Beschreibung |
|---|---|
| Quelle | kompromittierter Upstream, falsche Registry oder veränderter direkter/transitiver Paketgraph an TB-3 |
| Stimulus | Restore oder Release findet eine andere Quelle, Version, bekannte Schwachstelle, unbekannte Lizenz oder abweichende Paketmetadaten |
| Artefakt | Terminal.Gui 2.4.17, 23 transitive Pakete, Restore-/Asset-Graph und Liefernachweise |
| Umgebung | Restore, Build oder Release-Gate gegen NuGet.org |
| Reaktion | fail-closed: keine Lieferfreigabe; Update oder Ersatz nur mit ausdrücklicher Autorität und vollständiger Revalidierung; VEX darf keinen bekannten ausgelieferten Fund autorisieren |
| Messwert | exakt 1 direkte und 23 transitive Abhängigkeiten; 24/24 aus NuGet.org; 0 bekannte Schwachstellen; 0 unbekannte oder unvereinbare Lizenzen; SBOM/Provenance und Exact-Head-Validator müssen vor Merge Exit 0 liefern |
| Lokale Evidenz | `docs/security/dependency-audit.md`, `evidence/dependencies/*.json`, `docs/security/adr/003-terminalgui-lifecycle-supply-chain.md` |
| Status | lokaler Graph verifiziert; SBOM/Provenance und Exact Head `Pending` |

### QS-TG-SEC-003: Sichere Beendigung und Terminalrestauration

| Element | Beschreibung |
|---|---|
| Quelle | lokale Person, Dialogfehler oder Stop-Anforderung im Terminal-Lifecycle |
| Stimulus | Menü-Quit, `Ctrl+Q` oder Rückkehr aus einem verschachtelten Dialog beendet die aktive Sitzung |
| Artefakt | eine `IApplication`, Root, creator-owned Dialoge und Terminaltreiber |
| Umgebung | interaktive Sitzung auf jeder unterstützten Plattform; normaler Lauf und sicherer Fehlerpfad |
| Reaktion | genau die aktive App erhält `RequestStop`; verschachtelte Dialoge kehren zum Root zurück oder werden sicher freigegeben; Root und App werden entsorgt; Terminalmodi werden restauriert |
| Messwert | getrennte reale Menü-Quit- und `Ctrl+Q`-Sitzung jeweils Exit 0; 0 Tracebacks; beobachtete Rücksetzung von Alternate Screen, Mausmodi, Bracketed Paste und Cursor; Smoke Exit 0 mit exakt `SMOKE_OK`; Linux-/Windows-Jobs müssen ebenfalls Exit 0 liefern |
| Lokale Evidenz | `specs/003-terminalgui-migration/evidence/manual-tui.md`, `regression.md`, `docs/architecture/terminalgui-migration.md` |
| Status | macOS lokal verifiziert; Linux/Windows und Exact Head `Pending` |

### Szenarioübersicht und Freigabe

| ID | Priorität | Lokaler Status | Lieferstatus | Re-Evaluation-Trigger |
|---|:---:|---|---|---|
| QS-TG-SEC-001 | P1 | Pass | Pending | neue Taste, Handler-, Fokus- oder Terminaltreiberänderung |
| QS-TG-SEC-002 | P1 | Pass | Pending | Restore, Quelle, Version, Advisory, Lizenz oder SBOM-Änderung |
| QS-TG-SEC-003 | P1 | Pass | Pending | Lifecycle-, Dialog-, Quit-, Plattform- oder Fehlerpfadänderung |

Die drei Szenarien bestehen lokal. Sie sind erst vollständig lieferverifiziert,
wenn Linux und Windows in T066 sowie SBOM/Provenance und alle Primary-Gates in
T067 gegen denselben unveränderten PR-Head bestanden haben.

## English scenario block

### Method and evidence boundary

These three Feature 003 scenarios follow the iSAQB CPSA-F format: source,
stimulus, artifact, environment, response, and measurable response. Observed
local evidence is labelled locally verified. Provider and exact-head checks
that have not run remain pending. No penetration-test evidence is claimed.

### QS-TG-SEC-001: Manipulated or unexpected key

| Element | Description |
|---|---|
| Source | local user or faulty terminal event sequence at TB-1 |
| Stimulus | a key outside the 13 bound inputs, or an unexpected sequence, reaches the root or a dialog |
| Artifact | `MicroCalc.Tui.Program`, focus state, and closed key mapping |
| Environment | interactive Terminal.Gui v2 session under normal local use |
| Response | no dynamic execution or privileged action; known keys retain their exact meaning; root or active dialog remains controlled |
| Measure | exactly 13 bindings (`8 + 4 + 1`), zero legacy Ctrl/Alt masks, two real PTY sessions without traceback, and no new handler for unknown input |
| Status | locally verified; Linux, Windows, and exact head pending |

### QS-TG-SEC-002: Manipulated open-source package

| Element | Description |
|---|---|
| Source | compromised upstream, wrong registry, or changed direct/transitive graph at TB-3 |
| Stimulus | restore or release finds a different source/version, known vulnerability, unknown license, or changed metadata |
| Artifact | Terminal.Gui 2.4.17, 23 transitive packages, restored assets, and delivery evidence |
| Environment | NuGet.org restore, build, or release gate |
| Response | delivery fails closed; update or replacement needs explicit authority and full revalidation; VEX cannot authorize a known shipped finding |
| Measure | one direct and 23 transitive packages, 24/24 from NuGet.org, zero known vulnerabilities, zero unknown or incompatible licenses, and successful exact-head SBOM/provenance validation before merge |
| Status | local graph verified; SBOM/provenance and exact head pending |

### QS-TG-SEC-003: Safe termination and terminal restoration

| Element | Description |
|---|---|
| Source | local user, dialog error, or stop request in the terminal lifecycle |
| Stimulus | menu quit, `Ctrl+Q`, or return from a nested dialog ends the active session |
| Artifact | one application, root, creator-owned dialogs, and terminal driver |
| Environment | interactive session on every supported platform, including safe error paths |
| Response | the active application receives the stop request; dialogs return or dispose safely; root and application dispose; terminal modes restore |
| Measure | separate menu-quit and Ctrl+Q sessions each exit zero with no traceback; alternate screen, mouse modes, bracketed paste, and cursor restore; smoke prints exactly `SMOKE_OK`; Linux and Windows jobs exit zero |
| Status | locally verified on macOS; Linux, Windows, and exact head pending |

All three scenarios pass locally but are not delivery-complete until T066 and
T067 bind platform and primary-gate evidence to the unchanged pull-request
head.

## Referenzen / References

- `docs/security/threat-model.md`
- `docs/security/arc42-security.md`
- `docs/security/dependency-audit.md`
- `specs/003-terminalgui-migration/evidence/manual-tui.md`
- `specs/003-terminalgui-migration/evidence/regression.md`
- Constitution Principles XII and XIII
- iSAQB CPSA-F Quality Attribute Scenarios
