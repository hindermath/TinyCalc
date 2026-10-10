# Feature 006: TUI-Funktionsvertrag / TUI functional contract

## Problem und Lösung / Problem and solution

Bestätigte Formel-, Anzeige-, Dialog-, Datei- und Hilfefehler wurden test-first
korrigiert. Interne reale Session, unabhängige Orakel, echte PTY, vollständiger
Vertrag und fail-closed read-only Validator liefern überprüfbare Nachweise.
17 Familien, 364 Pfade je OS, keine neue öffentliche C#-API oder Paketupgrades.

*Test-first corrections cover actual UI/domain defects. The internal real session,
independent oracles, PTY, complete contract and read-only validator preserve all
17 families and 364 paths per OS without public API or dependency upgrades.*

## Tatsächliche Abnahme / Actual acceptance

- Prüfstand 737348debf6807d2d8b49e620d2dc068b62bf731, Binary 1.6.17.116, Vertragsrevision 2.
- Je macOS/Linux/Windows: 671 Pass, 0 Fail/Skip, 364 Pfade, 462 Assertions; insgesamt 1092 native Tupel.
- Changed-line-Coverage 488/503 = 97,02 %; unveränderte Produktquellen seit 22ec768, kein umetikettierter Coverage-Lauf.
- Thorsten: F01–F14 Pass bei 134x27/80x24, VoiceOver V1–V6 Pass bei verifiziertem 120x40, zusätzlich 80x24 insgesamt Pass; HTML H1–H4 je angeforderter Seite Pass, keine gemeldeten Befunde.
- [Menschlicher Nachweis](../specs/006-tui-functional-contract/evidence/human-acceptance-20261011.md), [Abnahme](../specs/006-tui-functional-contract/evidence/acceptance.md), [Lieferabschluss](../specs/006-tui-functional-contract/evidence/delivery-closeout.md), [Abschlussbericht](../specs/006-tui-functional-contract/completion-report.md).

*The immutable tested candidate has complete native and separate human proof.
Later delivery documentation/version metadata is not relabelled as human testing.
Final exact-head execution must pass before merge.*

## Gate-Zuordnung und Testplan / Gate mapping and test plan

| Gate | Workflow / Job / Runner / tatsächlicher Command |
|---|---|
| vollständige native Funktion / full native function | ci.yml, build-test, ubuntu-latest/windows-latest: Capture → ungefiltertes dotnet test MicroCalc.sln --configuration Release --no-build --logger trx --results-directory tests/MicroCalc.Tui.Tests/TestResults/native-ci → Collect → Upload |
| macOS/PTY | lokal macOS 27 arm64: Capture → dotnet test MicroCalc.sln --configuration Release --no-restore --logger trx --results-directory tests/MicroCalc.Tui.Tests/TestResults/native-ci → Collect; reale 80x24/120x40 |
| Launcher/Hilfe/Zero-write | dieselben nativen Jobs und lokales macOS: pwsh -NoProfile -File scripts/tests/tui-contract/test-launchers.ps1; Bash zusätzlich macOS/Linux |
| Smoke | native Jobs/lokal: tatsächliche Release-Binary --smoke, exakt SMOKE_OK |
| Vollvertrag und Gatebindung | lokal pwsh -NoProfile -File scripts/test-tinycalc-contract.ps1 -RepositoryRoot . -Evidence tests/MicroCalc.Tui.Tests/TestResults/delivery-gates-final -Json; gleiche CLI/WhatIf-/Bash-/Cmdlet-Ergebnisse, null Schreibwirkung |
| Security/Architektur | unabhängiger read-only Quell-/Delta-Review, versiegelter Securityscan, C006-01 test-first behoben; keine Provider-Namensbindung der fachlichen Gates |
| Supply Chain | tatsächliche finale SPDX-SBOM, vierprojektiger NuGet.org-CVE-Audit, 24 unveränderte Lizenzen, vier Lockhashes, tatsächliche Provider-/Head-/Tool-/Output-Provenienz |
| Dokumentation/A11Y | docfx build docfx.json → temporäre versionsgebundene axe/ARIA-/Linkprüfung → lynx; separate tatsächliche menschliche Abnahme |
| Secrets/Governance | Agent Secret Scan, Gitleaks, Homogeneity, Linked intake native proof, GSDB-Quellbindungen; echte aktuelle Outcomes prüfen |

Projekte: MicroCalc.Core, MicroCalc.Tui und beide vorhandenen Testprojekte.
Konfigurationsimpact: vier genehmigte Locks, CI-Vollvertragsbindung und begrenztes
DocFX-Overlay. Paketgraph unverändert. TUI-Captures sind gehashte reale Roh-/Text-
Originale, keine synthetischen Screenshots oder Humanfreigaben.
Statistik am sauberen Commit gerendert; technische GSDB-SRC-067-Hashfortschreibung
ändert weder historische Kontrollbewertungen noch menschliche Risikoannahmen.

*The table identifies actual commands and runner obligations, not just check
names. Full original execution, strict evidence binding, documentation and human
proof stay separate. No API, package graph, intake or regulatory scope expansion.*

## Risiken und Liefergrenzen / Risks and delivery boundaries

Untrusted Datei-/JSON-/TRX-/Git-Evidenz braucht Pfad-, Größen-, UTF-8-, Hash- und
Zeitgrenzen. Der begrenzte Streamleser bindet Parser/Digest an denselben Snapshot.
Die unveränderte neun-Dateien-Coverage wird historisch nachvollziehbar verwendet.
axe-Stichproben sind kein Voll-WCAG-Zertifikat; zwei alte Statistiklinks liegen
außerhalb des DocFX-Inhaltsumfangs. Keine signierte SLSA-Attestierung behauptet.

Claude-Providerfehler bleibt **Nicht-Pass**, ausdrücklich zurückgestellt.
Die fachlichen Security-/Architektur-/unabhängigen Review-Gates sind durch
tatsächliche separate Reviews erfüllt. Nur eine verbleibende formale zusätzliche
Provider-Status-/Approvalregel darf der genehmigte Admin-Bypass überbrücken;
kein fachlich fehlgeschlagener Check, offener Reviewbefund oder fehlender Nachweis.

DeliveryMode MergeAndSync ist aktuell ausdrücklich genehmigt. Bis die finale
Lieferhead-Prüfung wirklich abgeschlossen ist bleibt der PR Draft; danach
Provider-Mergecommit/Trailer unmittelbar read-only prüfen, main nur Fast-Forward.
Ignorierter Runtime-Nachweis und dieser PR dokumentieren T076/T078/T079/T081/T082
nach tatsächlicher Erfüllung, ohne selbstreferenzielle neue Commit-Schleife.
T082: nur Archivierungsprüfung, kein Rename aktiver hashgebundener Intakes ohne
separaten Lifecycle-Auftrag. Kein Folgefeature und kein NuGet-Update.

*Admin bypass is limited to formal duplicate provider/approval rules after all
substantive checks and independent reviews pass. A provider error remains a
non-pass, never a fabricated successful review. Freeze and validate final head,
verify actual merge/trailer, fast-forward main and stop. No follow-up feature,
silent intake promotion, dependency upgrade or signed-attestation claim.*
