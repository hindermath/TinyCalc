# US3-Checkpoint

## Deutscher Prüfblock

Stand: 2026-08-30, lokaler Checkpoint
`886a13f8866e79fe6c13e6e1227217294aabdee8` plus geprüfter Arbeitsbaum.

User Story 3 ist lokal abgeschlossen, aber noch nicht plattformvollständig.
Linux und Windows bleiben bis zum echten Provider-CI-Gate T066 verbindliche
Lieferabhängigkeiten. Dieser Checkpoint erteilt keine Mergefreigabe und ersetzt
keinen späteren Exact-Head-Nachweis.

### Funktionale Anforderungen

| Anforderung | Lokaler Status | Evidenz | Offene Lieferbedingung |
|---|---|---|---|
| FR-005, Headless-Smoke | Pass | `evidence/regression.md`: Exit 0, exakt `SMOKE_OK`, deutlich unter 30 Sekunden | Linux-/Windows-Smoke in T066 |
| FR-006, vorhandene Tests | Pass | Release-Testlauf 79/79, 0 übersprungen | Linux-/Windows-Testläufe in T066 |
| FR-010, Befehle und Versionierung | Pass | `evidence/version-evidence.md`, ausgerichtete Version `1.3.1.13`, genau eine Build-Erhöhung je Build/Test-Aufruf | Exact-Head-Wiederholung vor Lieferung |
| FR-012, Paket- und Sicherheitsgraph | Pass | 1 direkte plus 23 transitive Pakete; 0 bekannte Schwachstellen; 24/24 bekannte kompatible Lizenzen; `evidence/dependencies/` und `docs/security/dependency-audit.md` | Advisory-/Quellen-/Lizenzprüfung am Exact Head |
| FR-013, Rot-Grün-Regression und Coverage | Pass | beobachtbares Source- und Compile-Red, grüner Vertikalschnitt, Regression; Changed-Code-Coverage 82,0 Prozent | Exact-Head-Schnitt muss 82/100 reproduzieren |

### Gates TG-GATE-003/-004/-007 bis -011

| Gate | Lokaler Status | Primärer Nachweis | Neubewertung |
|---|---|---|---|
| TG-GATE-003 | Pass | `package-selection.md`, `restore-final.txt`: Terminal.Gui 2.4.17 stabil gewählt, `net10.0`, nur im TUI-Projekt direkt, NuGet.org | nach Projekt- oder Quellenänderung |
| TG-GATE-004 | Pass | `packages-all.json`, `packages-vulnerable.json`, `licenses-shipped.json`, `dependency-review.md`: vollständiger ausgelieferter Graph, 0 Schwachstellen, 0 offene Lizenzfälle | nach Restore, Source-/Graphänderung oder neuem Advisory |
| TG-GATE-007 | Pass | Release-Build, Exit 0, 0 Warnungen, 0 Fehler, ausgerichtete Version | nach Source-, Projekt-, Generierungs- oder Versionsänderung |
| TG-GATE-008 | Pass | vollständige bestehende xUnit-Suite 79/79; `git diff --exit-code -- tests src/MicroCalc.Core CALC.HLP` Exit 0 | nach Produkt- oder Abhängigkeitsänderung |
| TG-GATE-009 | Pass | Headless-Smoke, Exit 0, exakt `SMOKE_OK` | nach Startup-, Lifecycle- oder Smoke-Änderung |
| TG-GATE-010 | Pass | `red-green-refactor/`: Source-Contract-Red, Dependency-only-Compile-Red, danach minimal vollständiger grüner v2-Vertikalschnitt | bei Änderung der Implementierungsreihenfolge oder des Schnitts |
| TG-GATE-011 | Pass | echte Out-of-process-Evidenz aus Tests, Smoke und realen PTY-Sitzungen; Cobertura; 82,0 Prozent, Mindestwert 70 und Ziel 80 bestanden | nach ausführbarer `Program.cs`- oder Coverage-Tool-Änderung |

### Checkpoint-Entscheidung

Lokale Regression, Abhängigkeitsprüfung und Coverage sind vollständig. Es gibt
keinen lokalen US3-Blocker. Der Lauf darf mit User Story 4 fortfahren. User
Story 3 darf jedoch erst nach T066 als plattformvollständig bezeichnet werden.

## English review block

Timestamp: 2026-08-30, local checkpoint
`886a13f8866e79fe6c13e6e1227217294aabdee8` plus the reviewed working tree.

User Story 3 is locally complete but not platform-complete. Linux and Windows
remain binding delivery dependencies until the real provider CI gate T066.
This checkpoint does not authorize merge and does not replace later exact-head
evidence.

FR-005, FR-006, FR-010, FR-012, and FR-013 pass locally. The headless smoke
returns zero and prints exactly `SMOKE_OK`; all 79 tests pass with no skips;
version increments are recorded; the shipped graph contains zero known
vulnerabilities and zero unresolved license cases; and real out-of-process
coverage reaches 82.0 percent of 100 changed executable lines.

TG-GATE-003, -004, and -007 through -011 also pass locally with the primary
evidence listed in the shared tables above. Their defined change triggers
remain binding. The run may continue to User Story 4, but User Story 3 must not
be described as platform-complete until T066 succeeds on Linux and Windows and
the exact PR head is revalidated.
