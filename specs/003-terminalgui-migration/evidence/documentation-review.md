# Dokumentationsreview Feature 003

## Deutscher Prüfblock

### Entscheidung

Die durch Feature 003 neuen oder wesentlich aktualisierten Architektur-,
Security-, A11Y- und Ausführungsnachweise sind für den lokalen Arbeitsbaum
akzeptiert. Sie sind Deutsch zuerst und Englisch danach, verwenden CEFR-B2-
nahe Sätze, semantische Überschriften, verständliche Tabellen und
Textalternativen neben ASCII-Diagrammen. Kein wesentliches Ergebnis hängt von
Farbe, Bild, Zeigerbedienung oder räumlichem Layout allein ab.

Der Review ist an Checkpoint
`886a13f8866e79fe6c13e6e1227217294aabdee8` plus den geprüften Arbeitsbaum
gebunden. Der Exact-Head-Review vor Merge bleibt `Pending`.

### Leserpfad und Zielgruppen

```text
1. docs/security/README.md
   |
   +-- 2. Architektur und arc42
   |      |
   |      +-- 3. Threat Model und S-ADR
   |
   +-- 4. Security-Checkliste und Qualitätsszenarien
   |
   +-- 5. Dependency Audit, SBOM und Supply-Chain-Evidenz
   |
   +-- 6. A11Y-Bedienpfad
   |
   +-- 7. Feature-Evidenz: Regression, Coverage, Pakete, Checkpoints
```

Textalternative: Der Security-Index ist der Einstieg. Danach folgen
Architektur und Sicherheitskonzepte, Bedrohungen und Entscheidung, die
Prüfchecklisten, Lieferkette und SBOM, der barrierefreie Bedienpfad und zuletzt
die detaillierten Ausführungsnachweise.

| Zielgruppe | Primärer Bedarf | Empfohlener Einstieg |
|---|---|---|
| Lernende und neue Mitwirkende | Systemgrenzen, Lifecycle, Tastatur und sichere Gründe verstehen | Architektur, A11Y und Qualitätsszenarien |
| C#-/TUI-Entwickelnde | Ownership, sichere Fehler, Scope und Regression prüfen | Architektur, S-ADR, Checkliste und Regression |
| Security-/Supply-Chain-Review | STRIDE/CAPEC, Pakete, Lizenzen, SBOM und Provenance bewerten | Threat Model, Dependency Audit und Supply-Chain-Evidenz |
| PR-/Release-Review | Plattform-, Exact-Head- und Gate-Status sehen | Security-README, US3-Checkpoint und Evidence Index nach T058 |
| Screenreader-, Braille- und Textbrowser-Nutzende | lineare Aussagen ohne farb- oder bildabhängige Information | alle Markdown-Artefakte; Diagramme besitzen direkte Textalternativen |

### Dokumentklassen, Quelle und Owner

| Klasse | Artefakte | Quelle | Owner | Reviewstatus |
|---|---|---|---|---|
| Feature-Architektur | `docs/architecture/terminalgui-migration.md` | bindendes Intake, Spec, Plan und tatsächlicher TUI-Diff | Feature 003 | lokal Pass |
| A11Y-Nachweis | `docs/accessibility/terminalgui-migration.md` | tatsächliche 13 Tasten, Fokus und reale PTY-Sitzungen | Feature 003 / A11Y-Review | lokal Pass |
| Security-Architektur | arc42, Threat Model und S-ADR | Constitution XII–XVIII, STRIDE/CAPEC, tatsächliche Trust Boundaries | Feature 003 / Security-Review | lokal Pass |
| Secure-Coding-/Qualitätsreview | Checkliste und drei Qualitätsszenarien | NIST SSDF, CWE Top 25, Microsoft C# und beobachtete Evidenz | Feature 003 / Security-Review | lokal Pass |
| Supply-Chain-Nachweis | Dependency Audit, SPDX-SBOM und Supply-Chain-Evidenz | NuGet.org-Metadaten, Syft, OpenSSF/GitHub-Signale | Feature 003 / Delivery | lokal Pass, Provenance Pending |
| Ausführungsevidenz | Regression, Coverage, PTY, Paketberichte und Checkpoints | tatsächliche Befehle, Exitcodes, Hashes und Plattform | autonomer Lauf | lokal Pass, Exact Head Pending |

### Sprache, Plattform und Distribution

- Deutsch steht vor Englisch. Gemeinsame Tabellen mit technischen IDs und
  Hashes sind sprachneutral und werden in beiden Sprachblöcken erklärt.
- Fachbegriffe wie Trust Boundary, creator-owned, VEX, SBOM und Provenance
  werden beim ersten relevanten Auftreten erklärt oder im Kontext eindeutig
  beschrieben.
- Die lokale Ausführungsevidenz ist klar als macOS/`osx-arm64` markiert.
  Linux und Windows bleiben bis T066 offen und werden nicht aus macOS
  abgeleitet.
- Distribution erfolgt als Repository-Markdown und maschinenlesbare SPDX-/JSON-
  Evidenz. Es entsteht kein neues Website-, PDF-, Bild- oder Binärdokument.
- Tabellen besitzen eindeutige Kopfzeilen. Statuswerte nennen `Pass`, `N/A`
  oder `Pending` zusammen mit Begründung und Trigger.

### Navigation, DocFX und Home-Sync

**Dokumentationsnavigation: N/A für Änderung.** Die neuen Security-Dokumente
sind über `docs/security/README.md` linear indexiert. Feature 003 ändert keine
DocFX-Konfiguration, keinen DocFX-Inhaltspfad, keine API-Navigation und keine
öffentliche XML-Dokumentation. Deshalb wurde kein DocFX-Output regeneriert und
kein dazugehöriger HTML-A11Y-Lauf behauptet. Trigger sind eine spätere
Aufnahme in DocFX, eine ToC-Änderung oder eine öffentliche API-/XML-Änderung;
dann sind Regeneration, Playwright/axe und textorientierter Check erforderlich.

**Home-Sync: N/A.** Alle Texte sind TinyCalc- und Feature-003-spezifisch. Es
ändert sich keine gemeinsame Home-Baseline, kein globales Preset und keine
agentenübergreifende Guidance. Trigger ist eine tatsächlich wiederverwendbare
repoübergreifende Regel; erst dann ist ein getrennt autorisierter Home-Sync zu
prüfen.

### Dokumentations-Impact und sichere Grenzen

Akzeptierte Impact-Entscheidung: Repository-spezifische Markdown-/JSON-
Dokumentation ist erforderlich und vollständig; Produkt-Hilfe, DocFX,
Agentendateien und Home-Sync sind nicht ausgelöst.

Read-only-Verträge:

```text
git diff --exit-code -- CALC.HLP AGENTS.md CLAUDE.md GEMINI.md \
  .github/copilot-instructions.md .github/agents/copilot-instructions.md \
  docfx.json
Exit: 0

git diff --exit-code -- tests src/MicroCalc.Core
Exit: 0
```

Die Entscheidung wird neu geöffnet bei:

- neuer oder geänderter Endnutzer-Hilfe in `CALC.HLP`;
- öffentlicher API-/XML-Dokumentation oder DocFX-ToC-/Website-Änderung;
- Bild, Video, interaktiver Grafik oder layoutabhängiger Information;
- gemeinsamer Agenten-, Preset- oder Home-Baseline-Regel;
- neuem Betriebssystembeleg oder einer abweichenden Plattformbehauptung;
- geändertem Produkt-, Security-, Supply-Chain- oder Exact-Head-Befund.

### Ergebnis

Der lokale Dokumentationsreview ist `Pass`. Es wurde keine DocFX-, Home-Sync-,
`CALC.HLP`- oder Agentenänderung vorgenommen. Die spätere Exact-Head-Prüfung
muss Leserpfad, Dateimenge, Sprache, Plattformmarkierung und Trigger erneut
gegen den finalen Diff bestätigen.

## English review block

### Decision and reader path

The new or materially updated Feature 003 architecture, security,
accessibility, and execution evidence passes the local documentation review.
It is German first and English second, uses semantic headings, readable tables,
and direct text alternatives for ASCII diagrams. No essential meaning depends
only on colour, images, pointer input, or spatial layout.

The shared reader path starts at `docs/security/README.md`, then moves through
architecture and arc42, threat model and the focused security ADR, secure-
coding checks and measurable scenarios, dependency/SBOM evidence,
accessibility, and finally detailed execution evidence.

### Classification and boundaries

The documents serve learners, C#/TUI developers, security and supply-chain
reviewers, release reviewers, and assistive-technology users. Sources and
owners are recorded in the shared document-class table above. Local execution
evidence is labelled macOS/`osx-arm64`; Linux and Windows remain pending.
Distribution is repository Markdown plus machine-readable SPDX/JSON, not a new
website, PDF, image, or binary document.

Documentation navigation is not applicable to this change because the local
security index provides the reader path and no DocFX configuration, API
navigation, or public XML documentation changes. A future DocFX/ToC/API trigger
requires regeneration and the matching Playwright/axe and text-oriented
accessibility check. Home sync is not applicable because every change is
TinyCalc-specific; a reusable cross-repository rule would require separate
authority.

The read-only contracts confirm no `CALC.HLP`, agent-guidance, DocFX, test, or
Core diff. The local documentation review passes, while exact-head confirmation
of files, language order, platform labels, and triggers remains pending.
