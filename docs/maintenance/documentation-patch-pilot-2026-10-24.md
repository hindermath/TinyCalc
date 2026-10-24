# Dokumentationspatches: TinyCalc-Pilot / Documentation patches: TinyCalc pilot

## Auftrag und Quelle / Authority and source

DE: Dieser Nachlauf aktualisiert den bestehenden PR #117 ausgehend von
`d9d2ed106e703a5a555bd42255c67055d936f3ea`. Die verbindliche Level-0-Quelle
ist Home Baseline PR #345, Merge `ded29751b58eece7711e80cf997a89b559812c93`.
Alle vierzehn veröffentlichten Dokumentationspatches werden installiert;
Profilnamen, Prioritäten und globaler Acht-Preset-Default bleiben erhalten.
Keine Modellaufrufe, Produkt-Spec-Kit-Läufe, Toolchainpflege, neue
Routingfunktion, Community-Einreichung oder Flottenausweitung.

EN: This follow-up updates existing PR #117 from the exact predecessor above.
Home Baseline PR #345 is the authoritative source. Install all fourteen
published documentation patches while retaining profile names, priorities
and the global eight-preset default. No model calls, product Spec Kit runs,
toolchain work, routing development, catalog submission or broader rollout.

## Pakete und Agentenflächen / Packages and agent surfaces

Die vollständigen Versionen, Tag-Commits, ZIP-URLs und SHA-256 stehen im
Quellen-Lock `docs/maintenance/preset-source-lock.json`; die beobachteten
installierten Bytes im getrennten `docs/maintenance/preset-installed-lock.json`. Die zentrale
14er-Matrix ist `scripts/config/spec-kit-project-statistics-governance-presets.json`.
Kein Home-only-Overlay oder privates Routingprofil wird übernommen.

The source lock records all versions, immutable tags, ZIP URLs and hashes.
The separate installed lock records the observed payload. The central
fourteen-preset matrix remains authoritative; no Home-only overlay or private
routing profile is copied.

SDK 0.12.8 erzeugt beim regulären Installieren drei unvollständige
Claude-Skills. Der vorhandene `CommandRegistrar` erzeugt Specify, Plan und
Tasks aus den **neu aufgelösten** Security-`.composed`-Dateien erneut.
Vorher wird jede Komposition gegen den aktuellen `PresetResolver` geprüft;
nur die bestehende Markdown-Leerraum-Normalisierung ist erlaubt.
Alle sechs Governance-Wrapper und der C3A-/C5-Vertrag müssen auf allen
gepflegten Flächen vollständig sein. Kein SDK-, Command- oder Testpatch.

SDK 0.12.8 produces three incomplete Claude skills during installation.
Its existing registrar re-renders Specify, Plan and Tasks from freshly
resolved Security composition. Compare each composition with the current
resolver first, allowing only existing trailing-space normalization.
All six wrappers and the cloud contract must remain complete on every
maintained surface. The SDK, command sources and test logic are unchanged.

## GSDB und Assurance / GSDB and Assurance

Die vorherige aktive Matrix bleibt bytegleich unter
`docs/security/gsdb-intensive-review/history/evidence-matrix-d9d2ed10.json`.
Aktuell ändern sich ausschließlich Paketversionen und technische Quellhashes.
Alle 157 Kontrollbewertungen, Findings, externen Pflichten, Human-only-Werte,
Zusammenfassungen und das fachliche Review-Datum bleiben erhalten.
Der strenge Validator erhält nur die vierzehn neuen ExpectedVersion-Werte;
seine Prüfregeln, Abbruchbedingungen und Negativfälle werden nicht gelockert.

The previous active matrix is archived byte-for-byte. Only package versions
and technical source hashes change; all 157 control conclusions, findings,
external duties, human-only values, summaries and semantic review date remain
unchanged. Only the strict validator's fourteen expected package versions
are rebound; its rules and negative tests are not weakened.

Der eigene technische Assurance-Kontext ist
`docs/security/secure-development/2026-10-24-tinycalc-documentation-patches/`.
Alle Vorgängerkontexte bleiben unverändert. Technische Gates erteilen keine
Produkt-, Rechts-, Risiko- oder allgemeine Freigabe. NIST SSDF und CWE Top 25
bleiben anwendbar; bestehende SBOM-/VEX-/SLSA- und Anwendbarkeitsentscheidungen
werden nicht durch Paketinstallation neu bewertet. KI bleibt Entwicklungswerkzeug.

The new context is limited to this technical integration. Preserve all older
contexts and human decisions. Technical gates grant no product, legal, risk
or general release acceptance. Existing standards and supply-chain scope
decisions remain unchanged; AI remains a development tool.

## Prüfungen und Grenzen / Checks and limits

Aktuelle Befehle, Exitcodes und Laufgrenzen werden in
`documentation-patch-pilot-2026-10-24-checks.json` festgehalten.
Historische Tests im ursprünglichen Rolloutbericht sind kein aktueller Pass.
Restore, Release-Build, vollständige Tests und TUI-Smoke werden einmal mit
den aktuellen Inputs ausgeführt; Buildzähler werden vor Build und Test erhöht.
Native Linux-/Windows-Evidence kommt aus den tatsächlichen PR-Jobs.
Keine vollständige WCAG-AA-, B2-, Screenreader- oder Braille-Abnahme behauptet.

Current commands, exit codes and limits are recorded in the checks JSON.
Historical results are not current passes. Run restore, Release build, full
tests and smoke once against current inputs, incrementing the build counter
before build and test. Native CI evidence belongs to its actual platform.
No complete WCAG, language, screenreader or Braille acceptance is claimed.

Lokaler aktueller Nachweis: Restore und Release-Build erfolgreich, Build mit
0 Warnungen und 0 Fehlern. Ein vollständiger Lauf besteht mit 217 Core- und
461 TUI-Tests (678 insgesamt, 0 übersprungen). Der native macOS-Collector
bindet 364 tatsächlich ausgeführte Pfade; Smoke-Ausgabe exakt `SMOKE_OK`.
660 Paketdateien entsprechen den 14 verifizierten Release-Archiven, ohne
Home-only-Ausnahmen. Alle acht Agenten-/Lock-/Profiltests, beide exakten
Matrixprüfungen und die GSDB-Produktions-/Negativprüfungen bestehen.
Ein erster Collector-Aufruf ohne lokale Runner-Metadaten wurde vor Testbeginn
abgewiesen; der tatsächliche Lauf verwendet `local-macos` und
`documentation-patch-pilot`. Dieser Fehlaufruf zählt nicht als bestandene Prüfung.

Current local evidence: restore and Release build succeed with no build warnings
or errors. One complete run passes 217 Core plus 461 TUI tests, with no skipped
tests. Native macOS evidence binds 364 executed paths and smoke is exactly
`SMOKE_OK`. All 660 stock files match the fourteen verified release archives,
with no Home-only exceptions. Eight agent/lock/profile tests, both exact
matrix checks and GSDB production/negative checks pass. An initial collector
call lacked local runner metadata and was rejected before any test started;
it is not a successful check. The actual run declares its local runner and job.

## Dokumentation und Lieferung / Documentation and delivery

Der zunächst korrekt blockierende Intake-Check fand acht veraltete
Quellenbindungen in fünf Receipts, bereits am Vorgänger `d9d2ed10` vorhanden.
Nach ausdrücklicher zusätzlicher Freigabe wurde ausschließlich deren
Provenienz erneuert: PL/0, Rename, Sandbox-Härtung, Secure-Development-Härtung
und TUI-Funktionsabnahme/Regression. Operation:
`363e883c-a20c-4a98-b4da-62a1a3b5a0f2` unter `specs/intake-authoring-operations/`.
Vorherige Targets und Receipts sind bytegleich archiviert; Intake-IDs bleiben
gleich, Receipt-IDs und Operation-ID sind neu. Alle 13 Targetbytes, Manifest,
Series-Receipt, DAG, Reihenfolge und Zustände bleiben unverändert.
Beide installierten Shellvalidatoren und der betroffene vollständige
Alignment-Check bestehen für die isoliert vorbereiteten, unverändert
publizierten Bytes. Die 678 Produkttests wurden nicht wiederholt.

The initially blocking check found eight stale bindings in five receipts,
already present at the predecessor. Separate explicit authority renewed only
their source provenance. Preserve all predecessor target/receipt bytes and
intake identities; assign new receipt and operation IDs. All thirteen targets,
manifest, series receipt, DAG, order and states remain unchanged. Both shell
validators and the affected full alignment check pass for the isolated prepared
bytes published without changes. The 678 product tests were not repeated.

Der vorherige Ready-Serienreview bleibt im neuen datierten Serienarchiv
bytegleich erhalten und ist für die neue Provenienz ausdrücklich supersediert.
Aktiv ist Review ausstehend, kein aus einem Altbericht übernommener Ready-Pass.
Dies ist kein Produkt-, Risiko- oder Releaseentscheid. Root-Merge-CI ist grün;
Host Home Runtime wurde separat als `df172e819770a4785423c4ce5f6f84b23577f0a0`
geliefert. Der Statistiknachlauf erfolgt genau einmal je bestehendem Kontext
nach dem sauberen Quellencommit; keine Methoden- oder Referenzänderung.

Preserve the old Ready review in the dated series archive and explicitly
supersede it for new provenance. The current review is pending; no old Ready
verdict is copied. This grants no product, risk or release approval. Root merge
CI and separately bound Home Runtime delivery are complete. Refresh each
existing statistics context once after the clean source commit, without
changing methodology or references.

`UpdateRequired`: aktuelle Guidance, Quelle, technische Delta-Evidence und
Leserpfade. `GeneratedUpdate`: bestehende kanonische Profil-2-Statistik;
separater Statistikpilot bleibt ein eigener Kontext. Owner: Thorsten Hindermann.
DE zuerst, gleichwertiges EN, CEFR B2 und anwendbare WCAG 2.2 AA.
Source-only im Pilot; kein Home-Sync, Imagebau oder Deployment.
Erneute Bewertung bei Paket-, Quellen-, Scope- oder Autoritätsdrift.

Update current guidance and technical evidence; regenerate canonical
statistics without replacing them with the separate pilot. Preserve bilingual
reader paths and applicable accessibility requirements. Source-only pilot
integration, without Home sync, image build or deployment. Reevaluate on drift.

Der ausdrückliche Auftrag erlaubt MergeAndSync mit Admin-Bypass ohne erneute
Einzel-Head-Sichtung für genau diesen begrenzten Diff. Voraussetzung bleiben
grüne technische Checks, geklärte Reviewbefunde und gelieferte Level-0/Home-Runtime.
Kein Bypass ersetzt technische Evidence oder menschliche Produktentscheidungen.

The explicit bounded delivery authority permits MergeAndSync with admin bypass
without another individual-head review. Green technical checks, resolved review
findings and completed Level 0/Home Runtime delivery remain mandatory.
Bypass never substitutes for technical evidence or human product decisions.
