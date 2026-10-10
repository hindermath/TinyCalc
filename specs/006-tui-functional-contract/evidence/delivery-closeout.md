# Feature 006: verbindlicher Lieferabschluss / Binding delivery closeout

## Deutscher Nachweis

Stand 11.10.2026. Thorsten beauftragt ausdrücklich Abschlussdokumentation,
Commit, Push und **MergeAndSync** für ausschließlich Feature 006. Admin-Bypass
gilt nur für formale Merge-Regeln, niemals für fehlgeschlagene materielle Gates.
Optionale automatische Commit-Hooks bleiben aus; die gezielte Lieferung erfolgt
unter diesem aktuellen Auftrag. Kein Folgefeature, keine Paketaktualisierung.

### Vollständiger geprüfter Produktkandidat

Commit `737348debf6807d2d8b49e620d2dc068b62bf731`, Version `1.6.17.116`,
Vertragsrevision 2. [Menschliche Produktabnahme](human-acceptance-20261011.md).
Alle drei vollständigen nativen Suiten: je **671 Pass, 0 Fail, 0 Skip**
(Core 217, TUI 454); je **364 Pfade, 462 unabhängige Assertions**.
Zusammen **1092 automatisierte Pflichttupel** über 17 Funktionsfamilien.
US1 enthält 264, US2 92, TERM 8 Pfade pro Plattform.

Linux und Windows: [Push-CI 38086468591](https://github.com/hindermath/TinyCalc/actions/runs/38086468591),
Head exakt wie oben, kein umetikettierter PR-Testmerge.
Jobs: Linux `114313906258`, Windows `114313906375`.
Originale unter `tests/MicroCalc.Tui.Tests/TestResults/native-ci-38086468591/`;
pro Plattform 1147 referenzierte Originaldateien/Hashes geprüft.
Bundle-SHA-256 Linux:
`7d6d23cdf6470e52b0b55c961af81b507e53368e4079a6535b815cab2120e750`.
Bundle-SHA-256 Windows:
`8c9c1f9bf744a83f8e38c6d9a096dca885d306a5ed572b2f4f428107a93333c1`.
macOS-Bundle-SHA-256:
`b6fc86bbc8173b215050b007d73138fcbdeb6cd7bb40a2829cb4afb5035f9bd8`.

macOS: ungefilterter `dotnet test MicroCalc.sln --configuration Release
--no-restore --logger trx --results-directory
tests/MicroCalc.Tui.Tests/TestResults/native-ci`; tatsächliche PTY 80x24/120x40,
Launcher-/Cmdlet-/Bash-/Hilfen-/Zero-write-Parität und Binary-Smoke Pass.
CI führt dieselbe vollständige Suite sowie Collector, Launcher und Smoke aus.
Alle Originale werden erhalten; keine selektiven Slice- oder Smoke-only-Belege.

### Referenzkorrektur und endgültiger Lieferhead

Der vollständige Read-only-Abnahmelauf fand eine veraltete Hashreferenz in
`pin-approval.json`: `execution-authority.md` war um bereits genehmigte Liefer-
und Prüfautorität ergänzt worden. Nur dieser Referenzhash und der davon
abgeleitete kanonische Vergleichshash werden erneuert. Paketgraph, vier Locks,
Pin-Entscheidung und Vertrag bleiben unverändert. Keine neue Paketfreigabe.

Nach Abschlussdokumentation und sauberem Statistik-Render wird ein endgültiger
Lieferhead eingefroren. Die ignorierte Datei
`tests/MicroCalc.Tui.Tests/TestResults/delivery-manifest.json` bindet die dann
tatsächlich ausgeführten nativen Vollsuiten und Provideroriginale. Der echte
Validatorlauf in `delivery-gates-final-result.json` muss `Valid`, Exit 0,
1092/1092 Tupel und drei Plattformen liefern. CLI-/Cmdlet-/Bash-Vorschau bleibt
schreibfrei; fehlende oder falsche Evidence bleibt gesperrt.

Unveränderte Produktquellen seit `22ec768` erlauben den nachvollziehbar
historischen Coveragebeleg **488/503 = 97,02 %**, nicht einen erfundenen neuen
Coverage-Lauf. Human-A11Y bleibt ausschließlich an seinem Prüfcommit gebunden.
Neue finale technische Ergebnisse werden nicht vorab behauptet: bis zu deren
Erfolg bleibt Lieferung gesperrt. Provider- und Merge-/Sync-Nachweise werden
im bestehenden PR #104 und ignorierten Runtime-Nachweis ergänzt; kein weiterer
Commit nur für selbstreferenzielle IDs oder Zahlen.

### Security, Dokumentation und verbleibende Grenzen

NIST SSDF/CWE Top 25, sichere C#-/Datei-/Evidenzarchitektur und STRIDE/CAPEC
bleiben anwendbar. Unabhängiger Review einschließlich behobenem C006-01 sowie
gezielter Abschlussdelta-Prüfung bleibt getrennt von der Owner-Abnahme.
SBOM und tatsächliche Provenienz/SLSA-Zielmodell sind anwendbar, ohne signierte
Attestierung oder zugesicherten SLSA-Level. Produkt-AI-SBOM/ASVS/Zero Trust
bleiben scopebegründet N/A; VEX datiert N/A ohne bekannten Fund.

Der Claude-Workflow lieferte auf dem Prüfstand einen **Providerfehler**, keinen
fachlichen Review. Er bleibt ausdrücklich zurückgestellt, nicht Pass. Ein
benannter Pflichtreview darf dadurch nicht umgangen werden; formale doppelte
Provider-/Reviewregeln sind von tatsächlicher unabhängiger Prüfung zu trennen.
PR-Threads und aktuelle Checkursachen vor Merge einzeln beurteilen.

DocFX/axe/ARIA/lynx und Thorstens manuelle HTML-Prüfung sind getrennte Nachweise.
Keine allseitige WCAG-Zertifizierung. Zwei alte Statistik-Links zeigen auf
vorhandene Markdownquellen außerhalb des DocFX-Inhaltsumfangs; bekannte
historische Publikationslücke, keine fehlende Produktfunktion. Neue Abschluss-
seiten werden gezielt technisch geprüft. Keine wesentliche Bedeutung nur durch Farbe.

T082 ist eine bedingte **Prüfung nach Merge**, kein automatischer Rename:
das aktive hashgebundene Intake bleibt ohne ausdrücklichen Intake-/Serien-
Aktualisierungsauftrag erhalten. Das Rename-Werkzeug wird nicht ausgeführt,
keine Receipt-/Reviewlineage oder Serie stillschweigend geändert. Diese
Governancegrenze und das separat zu genehmigende NuGet-Update bleiben Restpunkte,
keine offenen In-Scope-Produktfehler oder Folgefeature-Startberechtigung.

## English closeout boundary

The owner now explicitly authorises documentation and MergeAndSync for Feature
006 only, with admin bypass limited to formal rules. The immutable accepted
candidate has 671 passing tests and 364 paths/462 assertions per native OS,
1092 required tuples overall, genuine PTY/launcher/smoke results, and separate
human acceptance. Original provider jobs and hashes are listed above.

One stale authority-reference hash and its derived comparison hash are repaired
without changing packages, locks, contract or pin decision. Freeze the delivery
head after documentation/statistics, execute and bind final native suites,
validate actual evidence with exit zero and record delivery in ignored runtime
proof and PR #104. Results remain pending until execution; never relabel old
runs or the human session. Reuse coverage only with unchanged-source proof.

Actual independent security/architecture review, human approval, documentation,
dated supply-chain proof and final provider checks remain separate. Deferred
Claude execution failure is not a review pass. No signed provenance, SLSA level
or full-site WCAG certification is claimed. Two historical statistics publication
links remain explicitly scoped. After merge, assess conditional archival without
renaming a hash-bound active intake absent explicit lifecycle authority. No
series promotion, dependency upgrade or follow-up feature is started.
