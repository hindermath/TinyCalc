# Lokale Pruefevidence / Local verification evidence

## Stand / Status

Am 2026-09-18 auf macOS arm64 gestartet; PowerShell 7.6.6, Git 2.54.0,
Spec Kit 0.12.8. Installation unveraendert: v0.1.0, 26 Paketdateien.
Git-Ausgangsstand `31f4c729d0992823c6512d88d92d6a5bd9bbd63c` sauber,
volle Historie, Remote-main identisch; keine Partial-Clone-Konfiguration.

Started on macOS arm64 with the stated versions and unchanged package. The
initial checkout was clean, complete and matched remote main.

## Lokale Ergebnisse / Local results

| Pruefung / Check | Ergebnis / Result |
| --- | --- |
| Explizite 14er-Matrix, Bash und PowerShell CheckOnly | Je Exit 0 / each exit 0 |
| Payload gegen Receipt und frisch verifiziertes Tag-ZIP | 26/26 bytegleich / byte-identical |
| Init-Vorschau, dann Init im expliziten Pilotkontext | Exit 0; DRY_RUN / INITIALIZED |
| Installierte deterministische Suite | Exit 0; 67 Assertions, Unix, PowerShell 7.6.6 |
| YAML-Struktur und beide eingebetteten PowerShell-Bloecke | PASS; PSScriptAnalyzer 1.25.0, keine Errors/Warnings |
| Kandidatenmessung / candidate measurement | UPDATED, Exit 0; 1374 Textdateien, 215686 Zeilen, 80 UTC-Aktivtage |
| Identisches Update mit expliziter Revision und Stichtag | CURRENT, changed=false; fuenf Datei-Hashes und Git-Zustand unveraendert |
| Vollstaendiger nativer Workflowblock, lokal macOS | Exit 0; Suite 67 Assertions, 8 Encoding-/Shell-Faelle, 6 rohe Blob-Faelle |
| Zusaetzlicher aktueller Lieferstand-Status, Bash und PowerShell | Beide CURRENT, reproducible=true, current=true, changed=false; Hashes/Git unveraendert |
| Kanonischer Profil-2-Renderer, Bash und PowerShell CheckOnly | Beide CURRENT; 206466 Zeilen, 83 Europe/Berlin-Aktivtage |
| GSDB ValidateSources/Compendium/Mappings/Validate | Je PASS / each PASS |
| RL-SE bestehende Matrix | PASS, 157/157 kanonische IDs; Dispositionen unveraendert |
| Homogeneity, DryRun/NoPatch | Exit 0; 29/29 Checks |
| Agent-Secret-Scan | Exit 0; high=0, medium=0 |
| Native GitHub Linux-/Windows-Pruefung | Noch nicht ausgefuehrt / not yet executed |
| Fachliche Abnahme und Remote-Lieferung | Offen / open |

Die Fixture-Suite prueft erwartete Fehlerausgaenge 1 und 2 in temporaeren
Repositories: manipulierte Ausgaben, veraltete Quellen/Fenster, dirty tree,
fehlende Revision, ungueltiges Datum/Schema/Pfad, shallow/promisor Historie
und fehlendes/veraltetes PowerShell. Keine Negativmutation im Projektcheckout.

The suite checks expected exits 1/2 for output drift, stale source/window,
dirty trees, invalid revisions/dates/schema/paths, incomplete history and
missing/old PowerShell in temporary repositories, not the project checkout.
This proves neither human acceptance nor product security.

## Messbindung und Unterschiede / Measurement binding and differences

Quelle: `fac1335c592b40c82a055acad7d111dc5c9f2af9`, Stichtag 2026-09-18.
Die 215686 Pilotzeilen und 206466 Profil-2-Zeilen sind **kein Paritaetsfehler**:
die bestehende Profil-2-Konfiguration schliesst zusaetzliche projektspezifische
Intake-/Evidence-/Versionsdateien aus; der portable Pilot nutzt seine Defaults.
Beide messen bewusst unterschiedliche Umfaenge. UTC gegen Europe/Berlin
erklaert zusaetzlich moegliche Aktivtag-Unterschiede. Keine Konfiguration
wurde zur kuenstlichen Zahlengleichheit angepasst.

Both snapshots bind the stated source and cutoff. Their different line
counts are not a parity failure: legacy configuration excludes additional
project-specific intake/evidence/version files; portable pilot defaults do
not. UTC and Europe/Berlin can additionally produce different active days.
No configuration was adjusted to force equal numbers.

| Artefakt / Artifact | SHA-256 |
| --- | --- |
| Pilot config | `34e979ce0fb394a2ef10099cd193ef9e7221f43bb072b124cbafcf6cfc531e3f` |
| Pilot report | `fac066eaff4b280eb534ef429f6b378cff66e33886d7df0063ed79cfef1048c7` |
| Pilot snapshot | `32b0a7c816c737a6d1767b397c715bfd041e6bf5ab11ffcd30062b1965229806` |
| Legacy config, unveraendert / unchanged | `55e2dcae65671f20cb2ab9f3fa01ae116e75f7ed45d9861351c2576e72f6dcb8` |
| Legacy ledger | `cc88718f472529bc8572c9d6ea51c31cb8dc461d7a9c444c4ad371772f5e77b8` |
| Native workflow | `87a12fe81cb4d11c1e12bddf45febc76e93b382c8e371231f175905111611c2d` |

## Ausfuehrungsnachweise und Grenzen / Execution evidence and limits

Der lokal extrahierte Workflowblock lief mit `PROOF_RUNNER=macos-local`;
Linux-/Windows-Guards wurden weder als bestanden behauptet noch entfernt.
Der Test nutzte eine getrennte Git-Arbeitskopie auf
`be92a1916af65526202e1e7676598ea3a39804b6`. LF/CRLF mit/ohne UTF-8-BOM
ergaben in Bash und PowerShell dieselbe CURRENT-Entscheidung; jede Statuspruefung
bewahrte Hashes und Git-Zustand. Sechs rohe Git-Blobs bewiesen unabhaengig
Zeilenzaehlung ohne Checkout-Normalisierung. Checked content changes: 0;
kein vollstaendiger Dateisystem-I/O-Trace.

The exact extracted workflow block ran locally as macos-local; this does not
claim Linux or Windows coverage. An isolated worktree proved eight equal
encoding/shell decisions and six raw-blob cases. Hash and Git-state checks
found zero checked content changes; this is not a complete filesystem trace.

- [Maschinenlesbarer lokaler Nachweis / Machine-readable local proof](native-evidence.json)
- [Aktueller Bash-Nachweis / Current Bash proof](delivery-Bash-evidence.json)
- [Aktueller PowerShell-Nachweis / Current PowerShell proof](delivery-PowerShell-evidence.json)

Die Nachweise binden den ausgefuehrten Kandidaten, nicht selbstreferenziell den
spaeteren Dokumentationscommit. Kontext-only-Nachlaeufe veraendern die Messquelle
nicht; vor Lieferung Status erneut pruefen. Temporaere Detaildateien bleiben zur
Diagnose erhalten, sind aber keine dauerhafte kanonische Evidence.

Evidence binds the executed candidate, not a later self-referential documentation
commit. Context-only follow-ups do not change the measured source; rerun status
before delivery. Temporary detailed output is retained for diagnosis, not used
as the sole permanent evidence. Native CI, product checks and human review remain open.
