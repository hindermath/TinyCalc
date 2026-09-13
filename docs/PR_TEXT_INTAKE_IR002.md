# IR002: Lernendenklarheit / Learner clarity

## Problem und Lösung / Problem and solution

Das Kommentar-Lastenheft setzte Fachbegriffe voraus und enthielt nicht alle
normativen Regeln zweisprachig. Die vorhandene Überarbeitung ergänzt Begriffe,
Vorkenntnisse und englische Regeln samt aktualisierter Intake-Belegkette.

The comment-hardening intake assumed specialist terms and lacked some English
normative rules. The existing revision adds terms, prerequisites, equivalent
English rules, and updated intake evidence.

## Prüfung und Grenzen / Validation and boundaries

Konfiguration, Serienmanifest und Receipt bestehen die Bash- und PowerShell-
Validatoren. Der Serienreview ist aktuell, bleibt aber wegen IR003 und IR004
an anderen Lastenheften `NeedsRemediation`. Kein Spec-Kit-Lauf wird gestartet.

Configuration, series manifest, and receipt pass Bash and PowerShell validators.
The series review is current but remains `NeedsRemediation` because IR003 and
IR004 concern other intakes. No Spec Kit run is started.

Documentation Impact: `UpdateRequired`; Owner: Thorsten Hindermann. Kanonische
Quelle und Leserpfad: aktives Kommentar-Lastenheft unter `requirements/intakes/active/`,
erreichbar über die unveränderte Serienordnung. Deutsch/Englisch stehen gemeinsam
im Markdown; textorientierte Nutzung bleibt möglich. Source-only, kein Home-Sync.
Erneut prüfen bei der nächsten Änderung des Lastenhefts.

Documentation impact is `UpdateRequired`, owned by Thorsten Hindermann. The active
comment-hardening intake is canonical and remains reachable through the unchanged
series order. German and English share the text-first Markdown document. This is
source-only; no home sync is required. Re-evaluate on the next intake change.

NIST SSDF und CWE Top 25: Integrität der Belege und Secret-Prüfung. Keine Produkt-,
API-, Abhängigkeits- oder Laufzeitänderung; ASVS, SBOM, AI-SBOM, VEX und Zero Trust
sind für diesen Text-Diff nicht neu betroffen. TDD und Changed-Code-Coverage:
`N/A`, erneut bei Produktcodeänderung prüfen. CI-Ergebnisse werden im PR ergänzt;
Admin-Bypass ist kein technischer Prüfnachweis.

NIST SSDF and CWE Top 25 apply through evidence integrity and secret scanning.
No product, API, dependency, or runtime changes affect ASVS, SBOM, AI-SBOM, VEX,
or Zero Trust in this text diff. TDD and changed-code coverage are `N/A` and must
be reconsidered for product-code changes. CI evidence is recorded in the PR;
admin bypass is not technical proof.

## Genehmigte Lieferkorrektur / Authorized delivery repair

Sechs Markdown-Zeilenumbrüche in drei noch nicht gelieferten Intake-Snapshots
verwenden jetzt explizite Backslashes statt nachgestellter Leerzeichen. Die
abhängigen Hashes wurden kausal aktualisiert. Originalbytes sämtlicher 21
betroffener Dokument-/Belegdateien sind verlustfrei und hashgebunden in
`specs/intake-review-remediation/20260913/whitespace-delivery/normalization.json`
gesichert; die lesbaren Archive sind normalisierte Kopien. Historische Aussagen
über Bytegleichheit beziehen sich auf diese Originalbytes, nicht die Kopien.

Six Markdown breaks in three undelivered intake snapshots now use explicit
backslashes instead of trailing spaces. Dependent hashes were causally rebound.
Original bytes of all 21 affected document/evidence files remain losslessly
hash-bound in the normalization record; readable archives are normalized copies.
Historical byte-identity claims refer to the preserved originals, not the copies.

Der neue vollständige Einzelreview unter demselben Evidence-Verzeichnis ist
`Ready` und supersediert den vorherigen Einzelreview ausdrücklich. Die aktuelle
Serie bleibt `NeedsRemediation`; weder IR003 noch IR004 wird geschlossen.
Keine historische Whitespace-Ausnahme oder Umgehung des Commit-Gates verwendet.

The new complete Single review in the same evidence directory is `Ready` and
explicitly supersedes its predecessor. The series remains `NeedsRemediation`;
neither IR003 nor IR004 is closed. No historical-whitespace allowance or local
commit-gate bypass is used.
