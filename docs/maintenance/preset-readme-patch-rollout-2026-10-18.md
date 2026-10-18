# Vierzehn Preset-Patches / Fourteen preset patches

Documentation Impact: `UpdateRequired`. Owner: @hindermath.

## Auftrag und Quellen / Authority and sources

DE: Dieser begrenzte Rollout aktualisiert die vierzehn bereits installierten
Presets aus der zentralen Matrix. Level 0 wurde mit
[PR #335](https://github.com/hindermath/home-baseline/pull/335), Merge
`bd64c6076021200ea8a12f8d5a55b78b0e6decd1`, geliefert und Home Runtime
anschliessend synchronisiert. Die unveraenderlichen Paketbindungen stehen im
[Quellen-Lock](preset-readme-patch-source-lock-2026-10-18.json).
Prioritaeten und globales Acht-Preset-Default bleiben erhalten. Der TinyCalc-
Ausgangsstand ist `d23f6a754fd8eaaa90c15980e09e5365715560f0`.

EN: This bounded rollout updates the existing fourteen-preset installation
after central delivery and Home Runtime sync. The linked source lock binds
published tags, exact commits and ZIP SHA-256 values. Preserve priorities and
the global eight-preset default. A clean worktree isolates the original user's
untracked `sheet.mcalc.json`; it is never staged or changed.

## Integration und Nachpruefung / Integration and revalidation

DE: Vorherige Installation gegen die veroeffentlichten Tags verglichen: keine
lokalen funktionalen Overlays; nur drei abgeleitete Security-Commands.
Das Home-only-Runner-Overlay wird nicht uebernommen. Versionsprofile,
Constitution-Spiegel, aktuelle Guidance und zugehoerige Vorlagen werden
gemeinsam aktualisiert. Historische Kommentare, Releases und Feldtests bleiben
in ihrem damaligen Kontext erhalten. Ein Download-Timeout ist kein Pass;
unvollstaendige Zwischenstaende werden vor dem Commit vollstaendig validiert.

EN: The old installation has no local functional overlay. Preserve generated
composition, but do not import Home-specific runner changes. Update current
profiles, paired constitutions, all affected guidance and templates together.
Keep historical evidence. Reconcile interrupted downloads before delivery.

DE: Die ausdruecklich genehmigte technische GSDB-Nachpruefung bindet die
aktuellen Preset-Manifeste, Registry und betroffenen Guidance-Quellen erneut.
Die vierzehn Erwartungsversionen im Validator werden exakt angehoben, nicht
auf einen toleranten Bereich erweitert. Je Paket pruefen zwei neue Negativfaelle
den unmittelbar vorigen Hash (GSDB002) und die vorige Version (GSDB008).
Kontrollzeilen, externe Pflichten, Findings, Summen und urspruengliches
Gesamtreview bleiben strukturell unveraendert.

EN: Explicit technical authority refreshes source identities, not human
acceptance. Exact validator versions and twenty-eight added stale-binding
negative cases enforce the new installation without weakening validation.
Preserve all control rows, external duties, findings, totals and historical
overall review date. Four separately named Assurance gates and read-only hashes
remain independent evidence checks, not a new ReleaseAccepted decision.

## Liefergates und Grenzen / Delivery gates and boundaries

### Historischer erster Prueflauf: blockiert / Historical first run: blocked

DE: Der folgende rote Erststand bleibt als Historie erhalten; die anschliessend
ausdruecklich genehmigte Korrektur und vollstaendige Nachpruefung stehen unten.
EN: Preserve the initial failure as history; the authorized adapter correction
and complete subsequent revalidation follow below.

DE: Die 14er-Matrix beider Shells, alle fuenf Agentenparitaetstests,
GSDB-Vollpruefung und drei Teilvertraege, Documentation Impact beider Shells
und PSScriptAnalyzer fuer 108 Dateien bestehen. Locked Restore und Release-
Build bestehen ohne Warnungen/Fehler. Alle 217 Core-Tests bestehen, ebenso der
nichtinteraktive Smoke mit `SMOKE_OK`. Status und vier Assurance-Gate-Reviews
beider Shells liefern Exit 0; die sechs Kontextdateien bleiben rohbytegleich.
[Befehls-/Nullschreibnachweis](preset-readme-patch-rollout-2026-10-18-gates.json).

EN: Exact matrix, five parity tests, GSDB full and partial contracts,
documentation impact, static analysis, locked restore, warning-free Release
build, 217 core tests and noninteractive smoke pass. All ten Assurance calls
pass without evidence mutation; the linked proof records exact commands.

DE: Die abgeschlossene TUI-Testsuite liefert Exit 1: 447 bestanden,
7 fehlgeschlagen, 0 uebersprungen, insgesamt 454. Die Produktregression hat
macOS-PTY-Fehler: Der erwartete
Titel `MicroCalc .NET 10` fehlt im ersten Grid-Snapshot. In mehreren zugehoerigen
Rohtraces erscheint er erst in spaeteren Phasen. Das legt ein Start-/Timing-
Problem nahe, beweist dessen Ursache aber noch nicht. Produktcode, Produkt-
Testorakel und PTY-Adapter sind gegen den Ausgangscommit unveraendert.
Fehler bleiben Fehler; keine Filterung, keine Timeout-Erhoehung oder Umgehung.
Weitere laufende Pruefungen werden nicht vorzeitig als bestanden ausgewiesen.
Dieser Kandidat darf nicht gemergt werden; eine gesonderte gezielte Beauftragung
ist fuer eine erforderliche Produkt-/PTY-Testkorrektur einzuholen.

DE: Sechs Fehler betreffen den fehlenden Titel; ein weiterer Fall endet mit
`PTY_CAPTURE_FAIL:QuitTimeout`. Auch dieser Fehler wird nicht ausgeblendet.
EN: Six failures concern the missing title; one additional case ends with
`PTY_CAPTURE_FAIL:QuitTimeout`. Neither failure class is suppressed.

EN: The completed TUI suite returns exit 1: 447 passed, seven failed and zero
skipped out of 454. Multiple macOS PTY tests fail because the first grid snapshot lacks the
expected application title, although later captures contain it. This suggests,
but does not establish, a startup/timing cause. Product code, oracles and PTY
adapter remain unchanged. Do not filter tests, extend timeouts or bypass the
failure. Pending checks are not passes. Do not merge this candidate; obtain
separate authority for any necessary product/PTY-test correction.

### Autorisierte PTY-Korrektur / Authorized PTY correction

DE: Nach gesonderter Beauftragung wurde ausschliesslich die Testinfrastruktur
korrigiert: Zustandsbereitschaft statt starrer Startwartezeit, frische Ausgabe
je Eingabe, vollstaendige UTF-8-/ANSI-Grenzen und korrekte B1-Bindung des
Navigationsablaufs. Produktcode und bestehende Produkt-Testorakel bleiben
unveraendert; 25-/30-Sekunden-Hardlimits werden nicht erweitert.
[Diagnose und Negativnachweise](macos-pty-adapter-2026-10-18.md).

EN: The separately authorized correction changes test infrastructure only.
Observe fresh readiness and complete byte/escape boundaries; bind the existing
navigation scenario to B1. Preserve product code, original assertions and hard
deadlines. Added synthetic negatives are not product execution evidence.

DE: Gezielter Nachlauf: 21 bestanden, 0 Fehler, 0 uebersprungen. Anschliessend
vollstaendige Produktsuite ohne Filter: 217 Core und 461 TUI bestanden,
0 Fehler, 0 uebersprungen, Exit 0. Native Evidence-Sammlung: Exit 0,
`NATIVE_AUTOMATION_BOUND: macos; 364 paths`. Nichtinteraktiver Smoke:
`SMOKE_OK`. Alte fehlgeschlagene TRX-Dateien bleiben getrennt archiviert;
der neue Sammler liest nur seinen neuen, unveraenderlichen Ausfuehrungskontext.

EN: Focused recheck passes all 21 cases. The subsequent unfiltered suite passes
217 Core and 461 TUI tests with no failures/skips. The unchanged native collector
binds 364 macOS execution paths and exits zero; noninteractive smoke succeeds.
Preserve failed earlier TRX separately rather than misrepresenting them as passes.
This is macOS automation, not native-reader or cross-platform acceptance.

DE: Vor Lieferung sind die vollstaendige 14er-Matrix beider Shells,
Agentenparitaet, GSDB-Voll-/Teilpruefungen und Negativfaelle, Assurance-Status
und vier Reviews, installierte Preset-Tests, Secret-Scan, statische Analyse,
Homogeneity und Statistik zu belegen. Restore, Release-Build, Produkttests und
nichtinteraktiver TUI-Smoke bleiben echte Regressionen; vorgeschriebene
Buildzaehler werden vor Build/Test fortgeschrieben. Lokale Belege gelten fuer
macOS; andere Plattformen nur fuer ihre tatsaechlich ausgefuehrten CI-Gates.

EN: Deliver with exact-head MergeAndSync and authorized admin bypass only
after successful technical gates and resolved findings. Preserve statistics
methodology. Record actual commands, exit codes, platform limits, PR/head/merge
and synchronization in this delivery's PR. Pending gates are not passes.

DE: Kein neues Produktfeature, Intake- oder Serienlauf, keine Produkt-, Risiko-,
Pilot-, allgemeine Release-, C5-, Konformitaets- oder Zertifizierungsfreigabe.
Keine Community-Einreichung, weitere Flotte oder Home Runtime in TinyCalc.
Vor spaeteren Implementierungen Intake-Review-Frische, Serie, lokales
Modell-Routing und aktuelle Delivery-Autoritaet erneut pruefen.

EN: No feature run, new human acceptance, certification claim, community
submission or wider rollout. Installation does not refresh intake receipts or
authorize later implementation. Recheck intake review, series, routing and
current delivery authority before any future implementation.
