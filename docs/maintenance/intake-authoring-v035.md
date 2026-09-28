# Authoring-Patch v0.3.5 / Authoring patch v0.3.5

Datum / Date: 2026-09-28. Owner: Thorsten Hindermann.

## Änderung und Erhaltung / Change and preservation

Das bestehende Preset wird von 0.3.4 mit dokumentiertem Generator-Backport
auf das veröffentlichte 0.3.5-Paket aktualisiert. Priorität 64 und Aktivierung
bleiben erhalten. Die 13 übrigen Registry-Einträge sind unverändert.
Ausgangscommit: `43a3a0791412831e6d68376b0e2bce348fe57cde`.

Vor dem Update wichen genau die beiden Receipt-Wrapper und der Lifecycle-Test
vom 0.3.4-Archiv ab. Beide Wrapper entsprachen bereits der kanonischen
0.3.5-Quelle; der neue Lifecycle-Test erweitert deren Regression. Alle 42
installierten Dateien entsprechen jetzt dem unveränderlichen Tag-Paket.
Die drei Backport-Abweichungen sind damit vollständig durch das Release
ersetzt. Der historische September-13-Nachweis bleibt erhalten und beschreibt
keine aktuelle Abweichung mehr. Weitere lokale Paketabweichungen wurden im
Ausgangsstand nicht gefunden; insbesondere war der dort historisch genannte
Validator-Test inzwischen bereits paketgleich.

Profile und Bootstrap-Vorlagen werden angeglichen. Constitution und gemeinsame
Agenten-Guidance wurden geprüft; dort ist keine aktuelle 0.3.4-Bindung zu ändern.
Generierte Command-Inhalte bleiben unverändert. Keine Produktdatei, Assembly-
Version, API, fachliche Intake-Datei oder historisches Receipt wird verändert.
Es startet kein Spec-Kit-Lauf und keine neue fachliche oder menschliche Abnahme.

The existing 0.3.4 installation with its documented generator backport is
replaced by published 0.3.5, retaining priority 64, activation and all thirteen
other registry entries. Exactly two receipt wrappers and the lifecycle test
differed from the old archive. Both wrappers already matched the canonical
fix; the new lifecycle test extends its proof. All 42 installed files now
match the immutable release. Historical overlay evidence remains historical;
no additional current package overlay was found. Current profile/template
bindings are updated; constitution and shared guidance need no version edit.
Command contents, product code, assembly version, APIs, intakes and historical
receipts remain unchanged. No feature execution or human acceptance is implied.

## Quellenbindung / Source binding

- [Release v0.3.5](https://github.com/hindermath/spec-kit-preset-intake-authoring-governance/releases/tag/v0.3.5).
- [Release-PR / Release PR #10](https://github.com/hindermath/spec-kit-preset-intake-authoring-governance/pull/10).
- Tag-/Merge-Commit / tag and merge commit: `f90e707444237d768623f457f85d15a707c3476e`.
- Tag-ZIP SHA-256: `972b6106e9c0ecd95a90dc6bdb175e97a5cc5ef16261b84e56beca2928fa7ba8`.
- Release-ZIP SHA-256: `ed81f62f53dba7f46204ddd822b24747b55f428b9bb427cb2ea715dd56013339`.
- [Native Quell-CI / Native source CI](https://github.com/hindermath/spec-kit-preset-intake-authoring-governance/actions/runs/36429748508): macOS/Linux/Windows erfolgreich / passed; Head `2ad74f88caf67bb7d8eb8292fef62baea845b9fe`.

## Prüfung und Lieferung / Validation and delivery

Lokal bestanden: exakte 14-Preset-Matrix unter Bash und PowerShell,
Template-Integrität, installierte Lifecycle-Suite, drei Agentenparitätstests,
Secret-Scan und PSScriptAnalyzer 1.25.0 (79 Dateien, neun deklarierte generierte
Upstream-Dateien ausgenommen). Die Lifecycle-Suite prüft die tatsächlich
ausgelieferte Receipt-Vorlage, LF/CRLF/BOM, unveränderte Eingabe-Hashes,
bekannte Generatoren und erwartete Blockierung mit Exitcode 2.

Native Projekt-CI am exakten PR-Head bleibt ein Merge-Gate, einschließlich
der dort definierten Produktregression. Kein zusätzlicher lokaler .NET-Build,
keine Buildzähleränderung und keine DocFX-Regeneration für diesen Paketpatch.
Produkt-TDD/Changed-Code-Coverage: N/A, da kein Produktcode geändert wird;
neu bewerten bei Produktlogikänderung. Paket-Regression ist nicht N/A.

MergeAndSync mit Admin-Bypass gilt nur nach erfolgreichen technischen Checks.
Frühere Billing-Ausnahmen gelten nicht. Nicht gestartete oder fehlgeschlagene
CI blockiert; Ergebnisse werden nicht als bestanden umgedeutet.

Local exact matrix validation in both shells, shipped templates, installed
lifecycle suite, three agent-parity tests, secret scan and PSScriptAnalyzer
passed. Native exact-head project CI, including its product regression, remains
required before merge. No additional local product build, build-number update
or DocFX regeneration is performed for this package-only patch. Product TDD and
changed-code coverage are N/A until product logic changes; package regression
remains required. Authorized admin bypass covers only the formal review
boundary after successful technical checks, not failed or unavailable CI.

NIST SSDF/CWE und Paket-Provenienz gelten für das Update. Keine neue
Abhängigkeit oder KI-Runtime; AI-SBOM N/A. Kein neuer Web-/API-Dienst, daher
ASVS für diesen Patch N/A. Bestehende Sicherheits- und Freigabeentscheidungen
bleiben unverändert. / NIST SSDF/CWE and package provenance apply; no new
dependency, AI runtime or web/API service. AI-SBOM and patch-specific ASVS are
N/A; existing security and acceptance decisions remain unchanged.

## Dokumentation und Statistik / Documentation and statistics

Documentation Impact: `UpdateRequired`. Zielgruppe / audience: Maintainer.
Leserpfad / reader path: PR → [PR-Beschreibung / PR description](../PR_TEXT_AUTHORING_V035.md)
→ dieser Nachweis / this evidence → unveränderliches Release / immutable release.
Quelle / source: kanonisches Preset und zentrale Profilbindungen / canonical
preset and central profiles. Klasse / class: repository-local integration
evidence; DE/EN in dieser Datei / in this file. Kein Home-Sync / no Home sync.
Wiedervorlage / reevaluate: Versions-, Quellen-, Profil- oder Overlay-Drift /
version, source, profile or overlay drift.

Bestehendes Profil-2-Ledger und separater Statistik-Kontext werden nach dem
Inhaltscommit mit unveränderten Konfigurationen und Methodiken fortgeschrieben.
Die Referenzen 80/125 bleiben Modellannahmen, keine Arbeitszeitmessung.
Der getrennte Kontext bleibt ohne Referenzszenarien. / Refresh the existing
Profile-2 ledger and separate statistics context after the content commit,
without configuration/methodology changes. References 80/125 remain estimates;
the separate context keeps reference scenarios disabled.
