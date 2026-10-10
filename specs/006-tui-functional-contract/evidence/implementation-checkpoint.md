# Implementierungs-Zwischenstand / Implementation checkpoint

## Aktuelle Fortsetzung / Current continuation

Der historische Stand unten bleibt nachvollziehbar. Aktuell sind alle 364
Pflichtpfade in einem tatsächlichen lokalen macOS-Lauf belegt: 669 Tests grün,
null Fail/Skip, 462 serialisierte Assertions. Changed-Line-Coverage 97,02 %.
[Vollbeleg](platforms/macos/local-build105.md), [Coverage](coverage.md),
[Dokumentationswirkung](documentation-impact.md) und
[A11Y-Zuordnung](../../../docs/accessibility/006-tui-functional-contract.md)
trennen technische Automation von menschlicher Prüfung und finaler Lieferung.
Native Linux-/Windows-Läufe, VoiceOver, unabhängige Reviews und Owner-Abnahme
bleiben verpflichtend. Keine Pakete aktualisiert, kein Folgefeature gestartet.

*The historical checkpoint below remains intact. A single real local macOS run
now proves all 364 mandatory paths with 669 passing tests and 462 serialized
assertions. Changed-line coverage reaches 97.02%. Linked evidence distinguishes
automation from human and final-delivery proof. Native Linux/Windows, VoiceOver,
independent reviews and owner acceptance remain mandatory. No package upgrades
or follow-up feature are included.*

## Deutscher Status

2026-10-10, Branch `006-tui-functional-contract`. **Kein Feature-Abschluss.**
39 von 83 Tasks sind mit tatsächlich erarbeitetem Nachweis markiert:
T001–T031 einschließlich T014A sowie T033–T039. T032/T040 bleiben offen,
weil vollständige Tupel-, Terminal- und Plattformbindung noch nicht vorliegt.
Specify, Plan, Tasks und Folgefeatures wurden nicht neu gestartet.

Produkt: interne instanzgebundene TuiSession statt statischer UI; historische
Raster-/Editoraliase, korrekte sichtbare Zellwerte, mathematische Regeln gemäß
Owner-Klärung, Menü-/Palettenbedienung, ausgelieferte Hilfe und atomare validierte
JSON-Übernahme. Keine Paketupgrades oder neuen Produktabhängigkeiten. Vier
explizit genehmigte Lockdateien stimmen mit dem zuvor geprüften Paketgraphen überein.

Nachweise: vollständige Solution bei Build 60, Core 217/TUI 363, **580 Pass,
null Fail/Skip**. Produktkorrekturen folgen ihren echten roten Defekttests;
Details und TRX-Hashes stehen unter `red-green/`. Schema-/Quellenfundament:
17 Familien und 364 unabhängige Pfade. Validator-Zwischenstand: 28 semantische
Fixtures und acht Pfadsicherheitsfälle grün; vollständiger synthetischer
1.092-Tupel-Dateisatz akzeptiert, Skip abgelehnt, Normalprüfung und WhatIf identisch,
Repositorydigest vor/nach unverändert. Synthetische Fixtures sind kein Produktnachweis.

Validator-Rot: 27 ausdrückliche Ablehnungsassertions schlugen am permissiven
isolierten Teststub fehl, nicht an fehlendem Code oder Infrastruktur. Der Stub
ist ersetzt. Sicherheits-Rot: sieben unsichere Pfade wurden zunächst akzeptiert,
danach alle verworfen. Dateiintegration deckt tatsächliche Schemas, Quell-/Payload-
und Artefaktbindung ab. Zwischenkorrekturen für DateKind, numerische JSON-Lexeme
und PowerShells WhatIf-Property-Kurzform sind Infrastrukturkorrekturen.

| Ignoriertes Testartefakt | SHA-256 |
|---|---|
| `006-validator-red.log` | `4290e7edb532ef6066aac7d4100bc38786e3a8580b354e9a95e548850f66fa23` |
| `006-validator-green-reviewed.log` | `d8d4e045ade3b7d8fc7680b0b0055748119e63f5f87282121025c0599a2a71b7` |
| `006-safety-red.log` | `122df1d802d27b617d72eff71d539be941e01524cd372d78995245c0946f8a92` |
| `006-validator-file-boundaries-green.log` | `5ecd77ec87c82c9608aaf77b92ad747def6fa11b5aa69e1e97671675e635474e` |

### Offene Pflichtarbeit

T041–T059 sind begonnen, aber nicht als vollständig abgeschlossen markiert:
historische Additivität/ChangeAuthority, vollständige Pin-/Impact-Matrix,
Katalogableitung, permanente Linux-/Windows-Vertrags-CI und tatsächliche
Produkt-Producer-Bindung fehlen noch. Die bisherigen Producer-Unit-Fixtures und
580 xUnit-Tests ersetzen kein vollständiges finales EvidenceBundle.

T060–T077: tatsächliche PTY-Wege 80x24/120x40, native Linux/Windows-Läufe,
VoiceOver durch einen Menschen, Coverage geänderter Produktzeilen, finale
Security-/Architektur-/Supply-Chain-/Dokumentationsprüfung, unabhängige
Produktprüfung und Owner-Abnahme stehen aus. Aktuelle lokale Preview liefert
korrekt Blocked/Exit 2 statt eines falschen Pass. Anwendbare Standards bleiben
NIST SSDF/CWE Top 25, C# Secure Coding, STRIDE/CAPEC, SBOM/SLSA und WCAG 2.2 AA.

Neue Nutzerfreigabe erlaubt Commit/Push und DeliveryMode MergeAndSync. Dieser
Commit sichert nur den Zwischenstand. **Kein Merge**, keine Serienpromotion,
kein Completion-Report oder Intake-Archivierung, solange materielle Gates fehlen.
Admin-Bypass betrifft ausschließlich formale Merge-Regeln. Thorsten bleibt Owner;
nächste Aktion ist Fortführung derselben Implementierung, kein neues Feature.

### Dokumentationsprüfung des Zwischenstands

DocFX 2.78.5: Build erfolgreich, 84 Link-/Dokumentationswarnungen, null Fehler.
Playwright-ARIA-Snapshots und Lynx prüfen den erzeugten Text repräsentativ:
`README.html`, `docs/help/microcalc-help.html` und `docs/contracts/tui/README.html`.
Alle drei enthalten lesbaren Text, Überschriften und eine Main-Landmark über
`role="main"`. Das erzeugte HTML hat jedoch keine deklarierte Seitensprache.
Damit ausdrücklich **kein WCAG-AA-Pass**. Axe ist lokal nicht verfügbar; keine
Installation und keine behauptete Human-/VoiceOver-Abnahme. Die Dokumentations-
und finale A11Y-Abnahme bleiben offen. Generierte `api/`-/`_site/`-Dateien sind
ignorierte Buildausgaben, keine getrackte Evidenz oder Produktlieferung.

## English status

This is an implementation checkpoint, not feature completion. Of 83 tasks,
39 have actual evidence; complete US1/US2 tuple and terminal proof remains Open.
Product fixes cover the extracted real session, legacy key contexts, visible
cells, approved numeric semantics, commands, bundled help and atomic invalid-load
handling. Four authorised locks preserve the approved package graph, without upgrades.

Build 60 passed the full solution: 217 Core plus 363 TUI tests, zero failures or
skips. Real red-before-fix traces are separately bound. The contract retains all
17 families and 364 independent paths. Validator tests passed 28 semantic and
eight safety cases; an actual synthetic 1,092-tuple file set passed, Skip failed,
preview matched normal validation and repository bytes remained unchanged.
The table binds original red/green logs. These fixtures prove infrastructure,
not real platform execution or product acceptance.

US3/US4 safeguards, complete product result producers, permanent native CI,
PTY, human VoiceOver, changed-code coverage, final reviews and owner acceptance
remain mandatory future work. The local preview correctly blocks on missing
complete evidence. New commit/push/MergeAndSync authority permits saving this
checkpoint, not bypassing material gates. No merge, series promotion, final
completion report, intake archival or follow-up feature is performed.

DocFX succeeded with 84 link/documentation warnings and no errors. Representative
Playwright ARIA snapshots and Lynx text review show readable headings, content
and main landmarks on the three pages listed above. Generated pages have no
declared language: this is not WCAG AA acceptance. Axe is unavailable and no tool
was installed. Final documentation, accessibility and human VoiceOver gates remain
Open; generated API/site outputs are ignored build products, not tracked proof.
