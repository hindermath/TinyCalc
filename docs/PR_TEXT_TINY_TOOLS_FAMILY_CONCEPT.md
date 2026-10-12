# Produktidee Lernwerkzeugfamilie / Learning tools family idea

## Deutsch

### Problem und Lösung

Die Idee zu TinyCalc, TinyEdit und TinyDB soll nachvollziehbar erhalten bleiben,
ohne die laufende Lastenheft-Serie zu ändern. Dieser PR dokumentiert den
unverbindlichen Konzeptstand mit Thorsten als Verantwortlichem und verlinkt
das [Diskussions-Issue #108](https://github.com/hindermath/TinyCalc/issues/108).

Leserpfad: Issue #108 → [Konzept](concepts/tiny-tools-family.md) →
[A11Y-Befunde #107](https://github.com/hindermath/TinyCalc/issues/107).
Die Dokumentationsauswirkung ist `UpdateRequired`, nachgewiesen in
`docs/documentation-impact/tiny-tools-family-concept.json`.

### Umfang und Risiken

- Gemeinsam: bestehendes Repository, drei separat startbare Programme,
  verwandte Bedienung, kleine Abläufe für Lernende der vier IHK-IT-Berufe.
- TinyEdit: Markdown, JSON, YAML, INI und PL/0; kleine IDE als mögliche
  Ausbaustufe. TinyDB: klassische dBASE-artige Tabellen und Masken.
  DBF-Kompatibilität, Formate, Bibliotheken, Framework und Lernziele bleiben offen.
- TinyEdit zuerst ist nur ein Vorschlag. Kein Intake, Feature, Projekt,
  Implementierungsauftrag, Repository-Rename oder neuer Serienblocker.
- README, Agenten-Guidance, Intakes, Seriennachweise, Produktcode, Tests,
  Abhängigkeiten, Assembly-Version und DocFX-Konfiguration bleiben unverändert.
- Risiko: Produktidee könnte als Ausführungsfreigabe gelesen werden. Beide
  Sprachblöcke schließen dies ausdrücklich aus; keine A11Y-Kompatibilität zugesagt.

### Prüfplan und Nachweisgrenzen

Vor Lieferung: Dokumentationsimpact, Intake-/Serien-/Review-Alignment,
Sprachgleichlauf, Links, UTF-8/LF, Secret-Scan und exakter gestagter Dateisatz.
DocFX nur mit `docfx build docfx.json`, ohne Metadata-/Produktbuild.
Konzeptseite und repräsentative Navigation: Accessibility-Snapshot, axe und lynx.
Statistik: Quellen und Ledger committen; Vorschau/Render an einem sauberen
Checkout desselben Commits, generierte Statistik separat committen, Check-only.
Die ungetrackte `sheet.mcalc.json` bleibt unverändert im ursprünglichen Checkout.

Lokale Ergebnisse vom 12.10.2026:

- Documentation-Impact-Validator bestanden; Sprachgleichlauf inhaltlich geprüft.
  UTF-8/LF, abschließende Zeilenumbrüche, Links und Git-Diffprüfung bestanden.
- Intake-/Serien-/Review-Alignment in PowerShell und Bash bestanden: 13 Ziele,
  vier Wurzeln, neun Abhängigkeiten; bestehender Serienreview weiterhin `Ready`.
  Auf macOS wurde Python 3.12 statt des ungeeigneten System-Python 3.9 verwendet.
- DocFX 2.81.0 temporär installiert, unveränderte `docfx.json`: Exit 0,
  208 HTML-Seiten, 84 Linkwarnungen außerhalb der neuen Konzept-/PR-Seiten.
  Keine API-Metadaten erzeugt; deren vorhandene Konfigurationsglobs finden
  hier keine API-Dateien. DocFX 2.78.4 scheiterte am bestehenden großen
  TUI-Katalog; dieser Fehlversuch ist kein bestandener Lauf.
- Playwright/Chrome: Konzept, README-Navigation, PR-Text und Statistikseite
  per Accessibility-Snapshot geprüft; axe mit WCAG-2/2.1/2.2-A/AA-Tags meldete
  null Verstöße. `color-contrast` und `link-in-text-block` bleiben als
  `incomplete` ausgewiesen, nicht als bestanden. Überschriften, Listen,
  Links und beide Sprachblöcke sind im Konzept-Snapshot zugänglich.
- lynx 2.9.3 mit `-display_charset=utf-8 -dump -nolist`: Konzept und
  README-Navigation textorientiert gelesen; Umlaute und Leserpfad lesbar.
- Gitleaks und getrackter Regex-Secret-Scan bestanden. Homogenitätsprüfung
  meldete zunächst ausschließlich Statistikdrift; finaler Check nach Render.

Finale technische
Provider-Gates und Review-Hinweise werden erst am endgültigen Head geprüft.
Claude-Review ist vom Eigentümer ausgenommen, nicht als bestanden zu werten.
MergeAndSync nutzt Admin-Bypass nur nach erfolgreichen technischen Gates und
bindet einen später genehmigten Merge an den geprüften Head. Der aktuelle
Auftrag erlaubt nur Commit/Push: PR #109 bleibt bis zu einer erneuten
Freigabe offen. Kein Folgefeature wird gestartet.

### Erweiterung vom 12.10.2026

Zielgruppe ab dem ersten Ausbildungsjahr, CEFR B2 und WCAG 2.2 AA soweit
anwendbar ergänzt. Kleine Apps erklären Prinzipien größerer Anwendungen;
konkrete Unterrichtseinheiten und IDE-Funktionen bleiben auszugestalten.
TinyCalcs PL/0-Integration ist bereits verbindlich geplant, die NuGet-Pakete
`TinyPl0.Core`/`TinyPl0.Vm` sind geliefert. TinyCalc-Preflight/Implementierung
bleiben offen; TinyEdits Nutzung ist eine neue, noch nicht implementierte
Konzeptrichtung. Lastenhefte und deren Gates bleiben unverändert.
Die oben dokumentierten lokalen Prüfungen werden für diese Erweiterung
wiederholt; abschließende Ergebnisse werden zusätzlich im PR festgehalten.

NIST SSDF und CWE Top 25 gelten für diese sichere Dokumentationslieferung;
WCAG 2.2 AA ist die anwendbare HTML-Prüfbasis. Neue Produkt-SBOM, VEX,
SLSA-Provenienz, ASVS, Zero Trust, STRIDE/CAPEC, SAMM-Neubewertung und AI-SBOM
sind hier N/A: keine Änderung an Produkt, Architektur, Abhängigkeiten, Release
oder KI-Runtime; KI dient nur der Dokumentationsarbeit. Bestehende Nachweise
bleiben maßgeblich. OpenSSF Scorecard, Cheat Sheets und Proactive Controls
bleiben ergänzende Referenzen, kein neuer Produkt-Auditauftrag.
Keine lokalen Produkt-Builds, Produkttests oder Restores. Automatische
HTML-Prüfung ist weder vollständige WCAG-Konformität noch native VoiceOver-/
Narrator-Abnahme. Bei einer späteren Produktentscheidung neu bewerten.

## English

### Problem and solution

The TinyCalc, TinyEdit and TinyDB idea needs a traceable home without changing
the current requirements series. This PR records a non-normative concept owned
by Thorsten and links [discussion issue #108](https://github.com/hindermath/TinyCalc/issues/108).

Reader path: issue #108 → [concept](concepts/tiny-tools-family.md) →
[accessibility findings #107](https://github.com/hindermath/TinyCalc/issues/107).
Documentation impact is `UpdateRequired`, recorded in
`docs/documentation-impact/tiny-tools-family-concept.json`.

### Scope and risks

- Shared repository, three independently startable programs, related controls
  and small workflows for trainees in the four IHK IT professions.
- TinyEdit: Markdown, JSON, YAML, INI and PL/0; a small IDE as a possible
  extension. TinyDB: classic dBASE-style tables and record forms.
  DBF compatibility, formats, libraries, framework and learning objectives stay open.
- Starting with TinyEdit is only a proposal. No new intake, feature, project,
  assignment, repository rename or blocking series dependency is created.
- README, agent guidance, intakes, series evidence, product, tests, packages,
  assembly version and DocFX configuration remain unchanged.
- Risk: readers may mistake the idea for execution approval. Both language
  blocks exclude this explicitly and promise no accessibility compatibility.

### Validation plan and evidence limits

Before delivery, check documentation impact, intake/series/review alignment,
language parity, links, UTF-8/LF, secrets and the exact staged paths.
Use `docfx build docfx.json` only, without metadata or product builds.
Check the concept and representative navigation with an accessibility snapshot,
axe and lynx. Commit sources and ledger, preview/render statistics in a clean
checkout of that same commit, commit generated statistics separately, then use
check-only. Preserve the untracked `sheet.mcalc.json` in the original checkout.

Local results on 12 October 2026:

- Documentation-impact validation, content-level language parity, UTF-8/LF,
  final newlines, links and Git whitespace checks passed.
- Intake/series/review alignment passed in PowerShell and Bash: 13 targets,
  four roots, nine dependencies; the existing Series review remains `Ready`.
  Python 3.12 replaced the unsuitable macOS system Python 3.9 for these checks.
- Temporary DocFX 2.81.0 with unchanged configuration completed with exit 0:
  208 HTML pages, 84 link warnings outside the new concept/PR pages. No API
  metadata was generated; existing API globs matched no files. DocFX 2.78.4
  failed on the existing large TUI catalogue; that attempt is not a pass.
- Playwright/Chrome accessibility snapshots covered the concept, README
  navigation, PR text and statistics. axe WCAG-2/2.1/2.2-A/AA tags reported
  zero violations. `color-contrast` and `link-in-text-block` remain `incomplete`,
  not passed. Concept headings, lists, links and both languages are accessible
  in the snapshot.
- lynx 2.9.3 with `-display_charset=utf-8 -dump -nolist` supported text review
  of the concept and README navigation, including umlauts and the reader path.
- Gitleaks and tracked-file regex secret checks passed. Initial homogeneity
  check found only statistics drift; final validation follows rendering.

Final provider gates and
review findings are checked at the final head. The owner waived Claude review;
it is not a pass. MergeAndSync uses admin bypass only after successful technical
gates and binds a later authorised merge to the checked head. The current
request permits commit/push only: PR #109 stays open until renewed approval.
Start no follow-up feature.

### Extension on 12 October 2026

Added trainees from their first training year, CEFR B2 and WCAG 2.2 AA wherever
applicable. Small apps explain principles of larger applications; specific
teaching units and IDE functions remain to be defined. TinyCalc's PL/0
integration is already binding planned scope, and the `TinyPl0.Core`/`TinyPl0.Vm`
NuGet packages are delivered. TinyCalc preflight/implementation remain open;
TinyEdit reuse is a new concept direction, not an implemented integration.
Requirements and their gates remain unchanged. Repeat the local checks above
for this extension and record final results additionally in the PR.

NIST SSDF/CWE Top 25 apply to this documentation delivery; WCAG 2.2 AA is the
applicable HTML baseline. New product SBOM, VEX, SLSA provenance, ASVS, Zero
Trust, STRIDE/CAPEC, SAMM reassessment and AI-SBOM are N/A: no product,
architecture, dependency, release or AI-runtime changes. AI is a documentation
tool only; existing evidence remains authoritative. OpenSSF Scorecard, Cheat
Sheets and Proactive Controls remain supporting references, not a new audit.
No local product build, product test or restore. Automated HTML checks do not
prove full WCAG conformance or native VoiceOver/Narrator acceptance. Reassess
these boundaries if a later product decision changes the scope.
