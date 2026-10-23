# Begrenzter stabiler Preset-Rollout / Bounded stable preset rollout

## Zweck und Stand / Purpose and state

Dieses Update installiert ausschließlich die 14 veröffentlichten stabilen
Governance-Pakete. Die Pakete unterstützen die Projektarbeit; ihre Installation
startet keinen Spec-Kit-Lauf und erteilt keine Produkt- oder Risikofreigabe.
Die fachliche Sichtung des neuen TinyCalc-PR-Heads steht noch aus.

This update installs only the fourteen published stable governance packages.
Installation starts no Spec Kit run and grants no product or risk acceptance.
Human review of the new TinyCalc pull-request head is still required.

Verbindliche Quelle ist Home Baseline PR #341, Merge
`e00f126273a37695bf770b3253d75d606034420f`; alle sechs Merge-Workflows waren
erfolgreich. Die Host Home Runtime wurde separat als `ce01863c` synchronisiert.
TinyCalc enthält kein Home-only-Runner-Overlay. Das persönliche Routing-Profil
und die private Datei `sheet.mcalc.json` im dauerhaften Klon bleiben unberührt.

The authoritative source is Home Baseline PR #341 at merge `e00f1262`, with
six successful merge workflows. Host Home Runtime sync is separately recorded
at `ce01863c`. TinyCalc has no Home-only runner overlay. The personal routing
profile and the permanent clone's private `sheet.mcalc.json` remain untouched.

## Pakete und Quellen / Packages and sources

| Preset | Version | Priorität / Priority |
|---|---:|---:|
| Security Governance | 0.7.3 | 10 |
| Secure Development Assurance Governance | 0.1.7 | 15 |
| Architecture Governance | 0.6.4 | 20 |
| iSAQB Architecture Governance | 0.2.4 | 30 |
| A11Y Governance | 0.4.5 | 40 |
| Cross-Platform Governance | 0.2.4 | 50 |
| Agent Parity Governance | 0.4.4 | 60 |
| Model Routing Governance | 0.1.6 | 61 |
| Intake Authoring Governance | 0.3.9 | 64 |
| Intake Review Governance | 0.2.6 | 65 |
| Intake Sequencing Governance | 0.2.10 | 66 |
| Autonomous Run Governance | 0.4.6 | 70 |
| Parallel Autonomous Run Governance | 0.2.8 | 80 |
| Project Statistics Governance | 0.1.2 | 90 |

Die acht zentralen Matrizen behalten Profilnamen und Prioritäten. Der globale
Acht-Preset-Default bleibt unverändert. ZIP-Prüfsummen und Tag-Commits stehen
in `docs/maintenance/preset-source-lock.json`. Der getrennte Installed-Lock
`docs/maintenance/preset-installed-lock.json` bindet die tatsächliche
Installation an Commit `17660cff9daf059f475d5446d6558a930df6147e`.
Alle 604 Paketdateien wurden mit den unveränderlichen Archiven verglichen;
nur das bekannte Entfernen nachgestellter Markdown-Leerzeichen ist zulässig.

The eight central matrices retain their profile names and priorities; the
global eight-preset default is unchanged. The source lock records archive
hashes and immutable tag commits. The separate installed lock binds the
observed payload to installation commit `17660cff`. All 604 archive files
were compared; only the installer's documented Markdown trailing-space
normalisation is allowed.

## Technische Evidence / Technical evidence

Die vorherige aktive GSDB-Matrix ist unverändert unter
`docs/security/gsdb-intensive-review/history/evidence-matrix-a527f5a6.json`
gesichert. Die aktuelle Matrix erhält ausschließlich neue Paketversionen,
Manifest-/Registry-Hashes sowie Hashes der aktualisierten Constitution und
Agenten-Guidance. Alle 157 Kontrollbewertungen, Findings, externen Pflichten,
Zusammenfassungen und das fachliche Review-Datum bleiben unverändert.
Alte Oktober-20-Assurance-Kontexte und datierte Locks bleiben historisch.

The previous active GSDB matrix is preserved byte-for-byte in the history
snapshot. Only package versions and changed source hashes are refreshed.
All 157 control conclusions, findings, external duties, summaries and the
original semantic review date remain unchanged. Dated locks and the
20 October Assurance contexts remain historical evidence.

Der neue technische Kontext liegt unter
`docs/security/secure-development/2026-10-24-tinycalc-stable-preset-rollout/`.
Seine vier Gates begrenzen ihre Aussage auf diesen Rollout. Menschliche
Pilot-, Projekt- und allgemeine Freigaben bleiben `Open`; dies ist weder eine
Konformitätsbehauptung noch ein Testat oder eine Zertifizierung.

The new technical context has four gates limited to this rollout. Human
pilot, project and general release decisions remain `Open`. These technical
results are not compliance, attestation or certification claims.

## Prüfprotokoll / Test record

| Prüfung / Check | Lokales Ergebnis / Local result |
|---|---|
| 14 Archive und installierter Inhalt / archives and installed payload | SHA-256 stimmt; 604 Stock-Dateien / hashes match; 604 stock files |
| Matrix Bash und PowerShell / matrix parity | 14/14, Exit 0 |
| Agentenflächen, Registry, Profile und Locks / surfaces and bindings | 8 Tests, Exit 0 |
| Dokumentation aller 14 Pakete / package documentation | alle 14 Suites erfolgreich / all fourteen suites pass |
| Gemeinsamer stabiler Routing-Vertrag / shared stable routing contract | 238 Assertions; 49 Command-Deklarationen / declarations |
| Assurance mit stabiler Mindestkombination / stable minimum combination | 44 Assertions; Model Routing 0.1.5 und Autonomous 0.4.5 |
| Routing-Discovery-Fixtures / discovery fixtures | positive und negative Fälle, Exit 0 / positive and negative cases |
| GSDB-Validierung / validation | Quellen, Sammelband, Mappings und Matrix: Exit 0 / sources, compendium, mappings and matrix |
| GSDB-Negativfälle / negative cases | GSDB001–GSDB010; 28 zusätzliche alte Paketbindungen blockiert / 28 additional old bindings rejected |
| RL-SE | 157/157 IDs, 119 offene oder Follow-up-Marker erhalten / open or follow-up markers preserved |
| Assurance-Gates / gates | Status und vier Reviews in beiden Shells, Exit 0; rohe Evidence-Hashes unverändert / raw evidence hashes unchanged |
| Restore und Release-Build / restore and build | Exit 0; Build ohne Warnungen / no build warnings |
| Vollständige .NET-Tests / complete tests | 217 Core + 461 TUI = 678 bestanden; 0 übersprungen / passed; none skipped |
| Native macOS-Evidence / native evidence | 364 ausgeführte Pfade gebunden / executed paths bound |
| Nichtinteraktiver Smoke / noninteractive smoke | Exit 0, `SMOKE_OK` |
| DocFX-Metadaten und HTML / metadata and HTML | Exit 0; 105 Warnungen exakt wie vorher / same 105 warnings as baseline |
| Textorientierte Dokumentationsprüfung / text-oriented documentation | Lynx und semantischer Browser-Snapshot: drei Leserpfade / three reader paths |
| PowerShell-Analyse / analysis | 132 Dateien, keine Error-/Warning-Befunde / files; no error or warning findings |

Die native Test-Evidence bindet den tatsächlich geprüften Arbeitsbaum vor dem
abschließenden Dokumentations-/Statistik-Nachlauf. Danach wurde kein
Produktcode geändert. Der Repository-Buildzähler wurde regelkonform vor Build
und Test auf 135 beziehungsweise 136 erhöht; die Produkt-API bleibt unverändert.
TDD für geänderten Produktcode und Changed-Code-Coverage sind hier `N/A`:
dies ist ein Paket-/Nachweis-Rollout ohne geänderte Produktlogik. Bei einer
späteren Codeänderung gelten die regulären Red-/Green-/Coverage-Gates wieder.

Native test evidence binds the actual tested worktree before the final
documentation/statistics follow-up. No product code changed afterwards. The
required build counter was incremented before build and test to 135 and 136.
Product APIs are unchanged. Changed-product-code TDD and coverage are `N/A`
for this package/evidence rollout; regular red/green/coverage gates apply
again to later product changes.

Die DocFX-Warnungen wurden gegen eine isolierte Kopie des Ausgangscommits
`a527f5a6` verglichen: 105 vorher, 105 danach, keine neue Warnung. Die
ursprünglichen Warnungen werden nicht unterdrückt. Die Textprüfung verwendet
einen leeren Browserkontext mit bereits installiertem Chrome; keine
Zugangsdaten oder Benutzerprofile. Ein erster lokaler Browseraufruf hatte
keine gebündelte Browser-Binary; ein weiterer Prüfaufruf verwendete fälschlich
ein HTML-`main` statt des vorhandenen semantischen `role=main`.
Diese Prüfaufrufe wurden nicht als bestanden gewertet. Der abschließende
semantische Check besteht. Axe und physische Screenreader-/Braille-Prüfungen
wurden nicht ausgeführt; eine vollständige B2-/WCAG-AA-Abnahme wird nicht behauptet.

DocFX warnings were compared with an isolated baseline at `a527f5a6`:
105 before and after, no new warning, and no suppression. Text checks use an
empty browser context with existing Chrome, not personal profiles or credentials.
Initial local browser checks lacked a bundled browser or used the wrong
HTML-element selector instead of the existing main landmark. They are not
counted as passes; the final semantic check succeeds. Axe and physical
screenreader/Braille tests were not performed. No complete B2/AA acceptance
is claimed.

Native Linux-/Windows-Ergebnisse und der endgültige Statistikstatus werden
im PR separat nach tatsächlichem Abschluss dokumentiert. Die bestehenden
v0.1.0-Statistik-Receipts bleiben unverändert; die aktuelle Statistik-CI prüft
stattdessen den aktuellen vollständigen 14-Paket-Lock. Kein Validator wird
abgeschwächt, kein neues Freigabe-Gate eingeführt.

Native Linux/Windows results and final statistics status are recorded
separately in the PR after actual completion. Historical v0.1.0 statistics
receipts remain unchanged; current statistics CI checks the complete current
fourteen-package lock instead. No validator is weakened and no new approval
gate is introduced.

## Dokumentationsauswirkung / Documentation impact

- Entscheidung / Decision: `UpdateRequired`.
- Quelle / Source: veröffentlichte Preset-Tags, zentrale Matrizen und
  tatsächliche Installation / published tags, central matrices and observed installation.
- Owner: Repository Maintainer; technische Nachprüfung / technical revalidation: Codex.
- Zielgruppe / Audience: IT-Auszubildende aller vier Berufe einschließlich
  der vier Fachinformatik-Fachrichtungen und Entwickelnde ohne Spezialwissen /
  apprentices across all four IT occupations, including all four IT specialist
  disciplines, and developers without specialist knowledge.
- Leserpfade / Reader paths: README → Governance-Pakete → dieser Bericht →
  technische Evidence und Fehlerdiagnose / README → packages → this report →
  technical evidence and troubleshooting.
- Dokumentklasse / Class: aktueller Integrationsnachweis / current integration record.
- Sprache / Language: Deutsch zuerst, gleichwertiges Englisch; CEFR B2 /
  German first, equivalent English; CEFR B2.
- Navigation: bestehende Anker erhalten; neue Bericht-Verknüpfung /
  existing anchors retained; new report link.
- Plattform / Platform: lokale macOS-Prüfungen und separat ausgewiesene CI /
  local macOS checks and separately reported CI.
- Distribution: nur TinyCalc, kein Home-Sync / TinyCalc only, no Home sync.
- Re-Evaluation: Paket-, Quellen-, Scope- oder Berechtigungsänderung /
  package, source, scope or authority change.
- Zugänglichkeit / Accessibility: anwendbare WCAG 2.2 AA als Ziel; statische
  Prüfungen sind keine vollständige Hilfsmittelabnahme / applicable WCAG 2.2 AA
  remains the target; static checks do not establish full assistive acceptance.

## Nächste sichere Aktion / Next safe action

Nach grünen technischen Checks den exakten PR-Head fachlich sichten lassen.
Erst nach konkreter Lieferfreigabe mergen, `main` synchronisieren und Merge-CI
prüfen. Danach folgt die Sandbox; Show-CommandTui400 bleibt nachgelagert.
Keine Community-Einreichung, Modellprobe oder Produktimplementierung.

After green technical checks, request human review of the exact PR head.
Only after concrete delivery approval: merge, synchronise `main` and check
merge CI. Sandbox comes next, then Show-CommandTui400. No community submission,
model probe or product implementation is included.
