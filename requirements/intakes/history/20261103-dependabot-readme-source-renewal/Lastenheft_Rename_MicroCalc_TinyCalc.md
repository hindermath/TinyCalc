<!-- intake-authoring:begin -->
# Lastenheft: Umbenennung MicroCalc zu TinyCalc

## Lesehilfe und Workflow / Reading Guide and Workflow

Deutsch: Grundlegende Tabellen-, Datei- und Tastaturbedienung genügt zum Einstieg;
Spec-Kit- oder Security-Erfahrung wird nicht vorausgesetzt. Ein Intake legt den
Umfang fest. `Specify` erstellt nur `spec.md` (Anforderungen), `plan.md` beschreibt
den Lösungsweg und `tasks.md` einzelne Schritte. `Autonomous` führt einen separat
beauftragten Lauf aus. `LocalImplementation` erlaubt lokale Arbeit, keine
Veröffentlichung. `Eligible` bezeichnet einen Kandidaten, keine Startfreigabe.
Ein Receipt ist ein Herkunftsnachweis; Evidence ein prüfbarer Beleg und ein Hash
ein Inhaltsfingerabdruck. Preflight bedeutet Vorprüfung, Gate eine Prüfschranke.

Deutsch: Secure Coding schützt Codepfade, Secure Architecture ihre
Vertrauensgrenzen (Trust Boundaries). Eine MSL ist eine speichersichere Sprache,
ersetzt aber keine Eingabeprüfung. I/O heißt Ein-/Ausgabe, Auth Anmeldung und
Berechtigung, Crypto Kryptografie. Eine Sandbox begrenzt Prozesszugriffe;
Mounts stellen Host-Dateien bereit, Tokens sind Zugriffsschlüssel, Caches
Zwischenspeicher. SBOM listet Software, AI-SBOM KI-Komponenten, VEX die
Betroffenheit von bekannten Schwachstellen, SLSA Build-Herkunft und Integrität.
NIST SSDF beschreibt sichere Entwicklung, CWE Fehlerarten, STRIDE Bedrohungen,
CAPEC Angriffsmuster, ASVS Web-Prüfungen, Zero Trust Zugriffe ohne stilles
Vertrauen, SAMM Security-Reife und Scorecard OSS-Sicherheitspraktiken. C3A/C5
betreffen Cloud-Autonomie/Nachweise. WCAG AA ist die anwendbare A11Y-Basis;
CEFR B2 bezeichnet verständliche Sprache. CI automatisiert Prüfungen, DocFX
erzeugt Dokumentation, axe prüft Barrieren und lynx liest Seiten als Text.
Ein Lockfile fixiert Abhängigkeiten. Diese Erläuterungen erweitern den Umfang nicht.

English: Basic spreadsheet, file and keyboard use is enough to begin. Prior
Spec Kit/security experience is not assumed. The intake defines scope. Specify
creates only spec.md (requirements), plan.md describes the approach and tasks.md
lists work steps. Autonomous executes a separately requested run.
LocalImplementation permits local work, not publication. Eligible identifies a
candidate, not start permission. A receipt records provenance; evidence is
verifiable proof and a hash a content fingerprint. Preflight means preliminary
check; a gate is a mandatory checkpoint.

English: Secure coding protects code paths, secure architecture their trust
boundaries. An MSL is memory-safe but still needs validation. I/O means input/output,
Auth authentication/authorization and Crypto cryptography. A sandbox limits
process access; mounts expose host files, tokens are access keys and caches
store intermediate results. SBOM inventories software, AI-SBOM AI components,
VEX vulnerability impact and SLSA build origin/integrity. NIST SSDF covers secure
development, CWE weaknesses, STRIDE threats, CAPEC attack patterns, ASVS web
verification, Zero Trust access without implicit trust, SAMM security maturity
and Scorecard OSS practices. C3A/C5 concern cloud autonomy/assurance. WCAG AA is
the applicable A11Y baseline; CEFR B2 the readability level. CI automates checks,
DocFX generates documentation, axe checks accessibility and lynx reads pages as
text. A lockfile fixes dependencies. These explanations add no scope or authority.


**Status:** ReadyForReview
**Zielgruppe:** TinyCalc-Anwendende, Auszubildende, Lehrende, Entwicklung und Review
**Vorausgesetztes Wissen:** Grundlegende Projekt- und Namespace-Begriffe; Spec-Kit-Erfahrung wird nicht vorausgesetzt
**Profil:** `level2-lastenheft`
**Reihenfolge:** Nach der vollständigen TUI-A11Y-Abnahme und vor der didaktischen Kommentarhärtung

*Status: Ready for review. This intake follows complete TUI accessibility
acceptance and precedes didactic comment hardening.*

## Begriffe beim ersten Gebrauch / Terms At First Use

### Deutsch

- **Rename:** konsistente Umbenennung einer technischen Identität mit allen
  aktiven Verweisen.
- **Namespace:** hierarchischer Name, der C#-Typen eindeutig zuordnet.
- **Live-Inventar:** zur Ausführungszeit aus dem aktuellen Git-Stand erzeugte
  Liste aller betroffenen Dateien und Referenzen.
- **Historische Allowlist:** ausdrücklich begründete Orte, an denen der frühere
  Name als Herkunftsnachweis erhalten bleibt.
- **Atomar:** der Repository-Stand ist vor und nach der Änderung konsistent; es
  gibt keinen ausgelieferten Zwischenstand mit gemischten Identitäten.

### English

- **Rename:** a consistent change of technical identity and all active
  references.
- **Namespace:** the hierarchical name that identifies C# types.
- **Live inventory:** the execution-time list of affected files and references
  generated from the current Git state.
- **Historical allowlist:** justified locations where the former name remains
  as provenance.
- **Atomic:** the repository is consistent before and after the change without
  a delivered mixed-name state.

## Zweck / Purpose

Das Projekt heißt nach außen TinyCalc, verwendet intern aber weiterhin
MicroCalc in Solution-, Projekt-, Assembly-, Namespace-, Test-, UI- und
Dokumentationsflächen. Ein atomarer Rename stellt eine einheitliche aktive
Produktidentität her, ohne Legacy-Quellen oder historische Evidenz
umzuschreiben.

*The repository shall use TinyCalc consistently on active product surfaces
while preserving legacy sources, historical evidence, and compatibility
boundaries.*

## Aktueller Zustand / Current State

- Repository und README verwenden TinyCalc als äußere Identität.
- Solution, Projekte, Namespaces, Tests und Teile der UI heißen noch MicroCalc.
- Frühere feste Datei- und Trefferzahlen sind datierte Snapshots und können bis
  zur späteren Ausführung veraltet sein.
- Die Terminal.Gui-Migration, vollständige Funktionsabnahme und TUI-A11Y-
  Abnahme liegen gemäß Serienkette vor diesem Intake.
- Das native JSON-Format und die Erweiterung `.mcalc.json` enthalten
  bestehende Nutzerdaten und dürfen nicht unbeabsichtigt inkompatibel werden.

*The external name is TinyCalc, while active internal surfaces still use
MicroCalc. Static inventories are stale-prone, and existing JSON data is a
compatibility boundary.*

## Zielzustand / Target State

- Das Ausführungs-Preflight erzeugt ein vollständiges Live-Inventar aus dem
  aktuellen Git-Stand und klassifiziert jeden Treffer.
- Alle aktiven technischen und nutzerseitigen Identitäten heißen TinyCalc.
- Historische Pascal-Quellen, Archive, frühere PR-Nachweise und erklärte
  Herkunftstexte bleiben unverändert oder ausdrücklich allowlisted.
- Build, Tests, Smoke, Produktvertrag, A11Y, Dokumentation und CI bestehen für
  denselben Rename-Commit.
- Persistierte Arbeitsblätter bleiben lesbar; der Rename ändert keine
  Tabellenfachlogik.

*Active identities become TinyCalc, historical evidence remains traceable, and
all functional, accessibility, build, documentation, and compatibility gates
pass on the same commit.*

## Umfang / Scope

- Solution-, Projektordner-, Projektdatei-, Assembly- und Root-Namespace-Namen.
- Namespaces, `using`-Anweisungen, Tests, Projektverweise und Buildskripte.
- Aktive UI-Titel, Status-/Fehlertexte, README, Hilfe, DocFX, API-Dokumentation,
  CI, Entwickler- und Agentenhinweise.
- Umbenennung der aktiven migrierten Hilfedatei
  `docs/help/microcalc-help.md` nach `docs/help/tinycalc-help.md` samt
  Verweisen.
- Live-Inventar für Git-getrackte Textdateien, Pfade und generierte
  Dokumentationsnavigation.
- Explizite historische Allowlist mit Begründung, Owner und Prüfbefehl.

*Scope covers all active technical, UI, documentation, CI, test, and agent
surfaces plus an execution-time inventory and historical allowlist.*

## Wichtige Schnittstellenänderungen / Important Interface Changes

- `MicroCalc.sln` wird zu `TinyCalc.sln`.
- Die Projekte und Assemblies werden zu `TinyCalc.Core`,
  `TinyCalc.Tui`, `TinyCalc.Core.Tests` und `TinyCalc.Tui.Tests`.
- Öffentliche C#-Namespaces wechseln von `MicroCalc.*` zu `TinyCalc.*`;
  alle internen Konsumenten, XML-Verweise und Tests werden atomar angepasst.
- Es gibt derzeit kein veröffentlichtes NuGet-Paket, dessen Paket-ID migriert
  werden müsste.
- JSON-Schema, gespeicherte Zellbedeutung und Lesbarkeit bestehender
  `.mcalc.json`-Dateien bleiben unverändert. Eine neue Dateierweiterung ist
  kein Bestandteil dieses Intakes.
- Die GitHub-Repository-URL bleibt `github.com/hindermath/TinyCalc`.

*The rename changes solution, project, assembly, and C# namespace identities.
It does not change the repository URL or existing JSON data semantics.*

## Nicht-Ziele / Non-Goals

- Keine Änderung von Formel-, Tabellen-, PL/0-, Legacy- oder
  Persistenzfachlogik.
- Keine Umbenennung oder inhaltliche Bereinigung der historischen
  `CALC.PAS`, `CALC.INC` und `CALC.HLP`.
- Kein massenhaftes Umschreiben archivierter Intakes, Specs, PR-Texte,
  Statistikprotokolle oder unveränderlicher Provenienz.
- Keine Änderung der Repository-URL oder Einführung eines neuen öffentlichen
  Pakets.
- Kein automatisches Dependency-Upgrade.
- Keine erneute Funktions- oder A11Y-Implementierung; vorhandene Verträge werden
  vollständig regressiv geprüft.

*The feature changes identity, not product behaviour, historical sources,
archives, repository location, packages, or dependencies.*

## Funktionale Anforderungen / Functional Requirements

- **R-RN-TC-01:** Vor jeder Änderung erzeugt ein reproduzierbarer Preflight mit
  `rg`, Git-Inventar und Projektmetadaten eine vollständige Liste aller
  aktiven Pfade und Inhalte mit `MicroCalc` oder abgeleiteten technischen
  Namen.
- **R-RN-TC-02:** Jeder Inventartreffer wird als `Rename`,
  `HistoricalAllowlist`, `GeneratedRegenerate` oder `Defect`
  klassifiziert. Unklassifizierte Treffer blockieren.
- **R-RN-TC-03:** Solution, Projektordner, Projektdateien, Assembly-Namen,
  Root-Namespaces, C#-Namespaces, `using`-Anweisungen und Projektverweise
  werden in einem atomaren Feature geändert.
- **R-RN-TC-04:** CI, lokale Build-/Test-/Smoke-Befehle, Skripte, DocFX,
  Entwickler- und Agentenhinweise verwenden anschließend die neuen Pfade.
- **R-RN-TC-05:** UI-Titel, aktive Lerntexte, README und migrierte Hilfe
  verwenden TinyCalc; Links und Navigation zeigen auf die umbenannte
  Hilfedatei.
- **R-RN-TC-06:** Historische Quellen und Archive werden nicht global ersetzt.
  Jeder verbleibende frühere Name außerhalb aktiver Produktflächen steht in
  der geprüften Allowlist mit Begründung.
- **R-RN-TC-07:** Bestehende JSON-Dateien vor dem Rename laden unverändert,
  lassen sich erneut speichern und behalten dieselbe fachliche Bedeutung.
- **R-RN-TC-08:** Der vollständige aktive Produktvertrag einschließlich
  Funktionsmatrix aus `Lastenheft_TUI-Funktionsabnahme-und-Regressionsvertrag.md` und A11Y-Gates aus `Lastenheft_A11Y_TUI.md` besteht nach dem
  Rename auf demselben Commit.
- **R-RN-TC-09:** Linux-/Windows-CI, macOS-PTY/VoiceOver sowie
  DocFX/axe/lynx bestehen gemäß `ReleaseCloseout`-Matrix.
- **R-RN-TC-10:** Öffentliche XML-Dokumentation, API-Links und generierte
  DocFX-Seiten enthalten keine gebrochenen Namespace- oder Assembly-Verweise.
- **R-RN-TC-11:** Ein abschließender Drift-Scan meldet jeden nicht allowlisteten
  alten aktiven Namen, jeden fehlenden neuen Pfad und jede gebrochene Referenz
  als blockierenden Fehler.
- **R-RN-TC-12:** Exakte Dependency-Versionen werden aus den aktuellen
  Repository-Pins aufgelöst; der Rename führt kein Upgrade durch.

*Requirements bind a live inventory, explicit disposition, atomic identity
changes, historical preservation, JSON compatibility, complete regression,
cross-platform A11Y, documentation integrity, drift scanning, and
version-neutral dependency handling.*

Die Funktionsmatrix ist durch [TUI-Funktionsabnahme und Regressionsvertrag](Lastenheft_TUI-Funktionsabnahme-und-Regressionsvertrag.md)
gebunden; die Barrierefreiheits-Gates durch [A11Y TUI](Lastenheft_A11Y_TUI.md).
Diese fachlichen Intake-Namen bleiben verbindlich, auch wenn spaeter andere
Feature-Nummern vergeben werden. Feature 004 (RL-SE) und Feature 005 (GSDB)
sind eigenstaendige Governance-Nachweise, keine Funktions- oder A11Y-Abnahme.

*The functional matrix is defined by the linked TUI acceptance and regression
intake; accessibility gates are defined by the linked A11Y TUI intake.
These semantic intake names remain binding independently of future feature
numbers. Features 004 (RL-SE) and 005 (GSDB) are separate governance evidence,
not functional or accessibility acceptance.*

## Qualität, Sicherheit und Governance / Quality, Security And Governance

- C#/.NET bleibt die speichersichere Hauptlaufzeit. NIST SSDF und CWE Top 25
  gelten für Skripte, Dateipfade, Build- und Dokumentationsverarbeitung.
- Rename-Skripte arbeiten nur auf dem geprüften Git-Inventar, verwenden keine
  unbeschränkten Dateisystem-Globs und bewahren historische Allowlist-Pfade.
- SBOM und SLSA werden für verteilbare Artefakte auf die neuen Assembly-Namen
  aktualisiert; VEX wird bei bekannten Schwachstellen gepflegt.
- ASVS und Zero Trust sind für die lokale TUI begründet `N/A`. AI-SBOM ist
  `N/A`, weil KI nur Entwicklungswerkzeug ist.
- Nutzerseitige Texte bleiben deutsch zuerst und englisch danach auf
  CEFR-B2-Niveau sowie für Screenreader, Braillezeile und Textbrowser geeignet.

*The rename uses bounded inventory-based tooling, secure C#/.NET and
supply-chain evidence, explicit N/A decisions, and accessible bilingual text.*

## Abhängigkeiten, Risiken und Evidenz / Dependencies, Risks And Evidence

- Harte Vorgänger: vollständige TUI-Funktionsabnahme und TUI-A11Y-Abnahme.
- Harter Nachfolger: didaktische Inline-Code-Kommentarhärtung.
- Risiken sind veraltete statische Inventare, gebrochene Projektverweise,
  gemischte Assembly-Namen, fehlerhafte DocFX-Links, unbeabsichtigte
  JSON-Inkompatibilität, überschriebenes historisches Material und
  abgeschwächte Tests.
- Evidenz umfasst Vorher-/Nachher-Inventar, Klassifikationsmatrix,
  Allowlist-Scan, Build/Test/Smoke, Produktvertrag, Linux-/Windows-CI,
  macOS-PTY/VoiceOver und DocFX/axe/lynx.
- Die exakten Dateizahlen werden erst aus dem Ausführungscommit gewonnen und
  als Evidenz gebunden; keine Zahl in diesem Intake gilt als zeitlos.

*The intake depends on functional and A11Y acceptance and requires live,
same-commit inventory, compatibility, platform, terminal, screen-reader, and
documentation evidence.*

## Erwartete Artefakte / Expected Artifacts

- Umbenannte Solution, Projekte, Assemblies, Namespaces und aktive Hilfedatei.
- Vollständige Live-Inventar-, Dispositions- und historische Allowlist-Datei.
- Aktualisierte Projektverweise, CI, Skripte, XML-Dokumentation, DocFX,
  README, Hilfe und Agentenhinweise.
- JSON-Kompatibilitäts-, Build-, Test-, Smoke-, Produktvertrags-, PTY-,
  VoiceOver-, axe- und lynx-Evidenz.
- Aktualisierte SBOM-/SLSA-, Security- und Projektstatistik-Evidenz.

*Expected artefacts cover renamed active identities, inventories, allowlists,
references, documentation, compatibility, tests, accessibility, security, and
statistics.*

## Abnahmekriterien / Acceptance Criteria

- **AK-RN-TC-01:** Live-Inventar und Dispositionsmatrix enthalten jeden
  Git-getrackten Treffer des alten Namens und jeden betroffenen Pfad.
- **AK-RN-TC-02:** Solution, vier Projekte, Assemblies, Namespaces,
  Projektverweise und Tests verwenden ausschließlich die neue aktive Identität.
- **AK-RN-TC-03:** Jeder verbleibende alte Name ist historisch notwendig,
  allowlisted und mit Begründung belegt.
- **AK-RN-TC-04:** Bestehende `.mcalc.json`-Fixtures laden vor und nach dem
  Rename mit identischer fachlicher Bedeutung.
- **AK-RN-TC-05:** Restore, Release-Build, vollständige Tests und `--smoke`
  bestehen über die neuen Pfade.
- **AK-RN-TC-06:** Alle bisherigen Vertrags- und A11Y-IDs bestehen auf dem
  Rename-Commit.
- **AK-RN-TC-07:** Linux-/Windows-CI, macOS-PTY/VoiceOver und
  DocFX/axe/lynx bestehen auf demselben Commit.
- **AK-RN-TC-08:** Die migrierte Hilfe besitzt den neuen Pfad; alle aktiven
  Links, XML-Verweise und DocFX-Navigationen sind gültig.
- **AK-RN-TC-09:** Ein absichtlich wieder eingefügter alter aktiver Name wird
  vom Drift-Scan zuverlässig erkannt und blockiert.

*Acceptance proves complete inventory, active identity consistency, justified
history, JSON compatibility, build and product regression, cross-platform
A11Y, documentation links, and effective drift detection.*

## Annahmen und Entscheidungen / Assumptions And Decisions

- **IAD001 – beantwortet:** Rename folgt erst nach vollständiger
  Funktionsabnahme und TUI-A11Y.
- **IAD002 – beantwortet:** Dateipfade und Trefferzahlen werden zur Ausführung
  live ermittelt und nicht in diesem Intake eingefroren.
- **IAD003 – beantwortet:** Historische Quellen und Evidenz behalten den
  früheren Namen; aktive Produktflächen verwenden TinyCalc.
- **IAD004 – beantwortet:** JSON-Semantik und `.mcalc.json` bleiben
  kompatibel; eine neue Dateierweiterung ist kein Bestandteil dieses Intakes.
- **IAD005 – beantwortet:** Der Rename löst die vollständige
  ReleaseCloseout-Regressionsmatrix aus.
- Delivery Authority bleibt `LocalImplementation`; dieses Intake erteilt keine
  Commit-, Push-, PR-, Merge-, Bypass- oder Folgefeature-Berechtigung.

## Vollständiger englischer Vertragsblock / Complete English Contract

Deutsch: Die Ergänzung übersetzt den Vertrag, ohne Rename auszuführen. Der
deutsche Vertrag einschließlich `.mcalc.json`-Kompatibilität bleibt kanonisch.

### English: purpose, scope and interfaces

Audience: users, apprentices, teachers, developers/reviewers. Basic project/
namespace knowledge is assumed, not Spec Kit experience. TinyCalc is external
identity, active solution/projects/assemblies/namespaces/tests/UI still MicroCalc.
Static hit counts are dated snapshots. Migration/function/A11Y precede rename;
existing JSON/.mcalc.json data must stay compatible.
Generate a complete execution-time Git inventory, classify every hit and rename
active identities atomically. Historical Pascal/archives/PR proof/provenance stays
unchanged or justified in allowlist. Build/tests/smoke/product/A11Y/docs/CI pass
on one commit; stored sheets remain readable, no sheet logic changes.
Scope: solution/project folders/files/assemblies/root namespaces, C# using/references/
tests/scripts, UI/status/errors/README/help/DocFX/API/CI/developer/agent surfaces;
docs/help/microcalc-help.md -> docs/help/tinycalc-help.md with links; tracked text/
paths/generated navigation; allowlist with reason/owner/check command.
MicroCalc.sln becomes TinyCalc.sln; projects/assemblies become TinyCalc.Core,
TinyCalc.Tui and both .Tests projects. Namespaces change atomically with consumers,
XML/tests. No released NuGet ID needs migration. JSON schema/cell meaning and
.mcalc.json readability stay; no new extension; repository URL stays
github.com/hindermath/TinyCalc.
Non-goals: formula/sheet/PL0/Legacy/persistence behavior changes, CALC.PAS/INC/HLP
rewrites, mass archive/spec/PR/statistics/provenance replacement, new public package,
URL change, upgrades or repeated functional/A11Y implementation.

### English: functional requirements

- R-RN-TC-01: Before changes, reproduce complete active old-name/path inventory with rg, Git and project metadata.
- R-RN-TC-02: Classify each hit Rename/HistoricalAllowlist/GeneratedRegenerate/Defect; unknown classifications block.
- R-RN-TC-03: Atomically change solution/project folders/files/assemblies/root/C# namespaces/using/references.
- R-RN-TC-04: CI/local build/test/smoke/scripts/DocFX/developer/agent guidance use new paths.
- R-RN-TC-05: UI/active learning text/README/migrated help use TinyCalc; links/navigation resolve renamed help.
- R-RN-TC-06: No global historical replacement; retained old names outside active surfaces have justified allowlist entries.
- R-RN-TC-07: Pre-rename JSON loads/saves with identical meaning.
- R-RN-TC-08: Full preceding function matrix and A11Y gates pass on that same rename commit.
- R-RN-TC-09: Linux/Windows, macOS PTY/VoiceOver and DocFX/axe/lynx satisfy ReleaseCloseout.
- R-RN-TC-10: Public XML/API/generated DocFX has no broken namespace/assembly reference.
- R-RN-TC-11: Final drift scan blocks unallowlisted active old names, missing new paths and broken references.
- R-RN-TC-12: Resolve exact dependencies from current pins; perform no upgrade.

### English: governance, order and artifacts

C#/.NET stays memory-safe; SSDF/CWE cover scripts/paths/build/docs. Use bounded
Git inventory, no unrestricted filesystem globs, preserving history allowlists.
Update distributable SBOM/SLSA identities and VEX for known vulnerabilities.
ASVS/Zero Trust are justified local-TUI N/A; AI-SBOM N/A because AI is tooling.
Deliver accessible DE-first/EN-second B2 text.
Hard predecessors: full function and A11Y acceptance. Didactic comments follow.
RL-SE/GSDB are governance, not function/A11Y acceptance. Risks: stale inventory,
broken references/mixed assemblies/DocFX/JSON, overwritten history/weakened tests.
Artifacts/evidence: renamed identities/help; before/after inventory, classification,
allowlist; references/CI/scripts/XML/DocFX/README/help/agent updates; JSON/build/
test/smoke/product/Linux/Windows/PTY/VoiceOver/axe/lynx; SBOM/SLSA/security/statistics.
Exact counts come from the execution commit, never a timeless intake count.

### English: acceptance and decisions

- AK-RN-TC-01: Inventory/classification includes every tracked old-name hit and affected path.
- AK-RN-TC-02: Solution/four projects/assemblies/namespaces/references/tests use only new active identity.
- AK-RN-TC-03: Every retained old name is necessary history, allowlisted/justified.
- AK-RN-TC-04: Existing .mcalc.json fixtures retain identical before/after meaning.
- AK-RN-TC-05: Restore/Release build/full tests/smoke pass through new paths.
- AK-RN-TC-06: All old product/A11Y IDs pass on rename commit.
- AK-RN-TC-07: Linux/Windows, macOS PTY/VoiceOver and DocFX/axe/lynx pass on one commit.
- AK-RN-TC-08: New help path and all active links/XML/navigation are valid.
- AK-RN-TC-09: A deliberately restored active old name is detected and blocks.

Answered IAD001..005 bind function/A11Y predecessors, live counts, preserved
history, JSON/.mcalc.json without new extension and full ReleaseCloseout.
Canonical Specify prepares only the specification; separately requested
Autonomous stops without acceptance/live inventory/classification/allowlist.
Delivery stays LocalImplementation: this intake grants no commit/push/PR/merge/
bypass/follow-up permission to the future rename feature.


<!-- intake-authoring:prompts -->
## Ausführbare Spec-Kit-Prompts / Copy-Ready Spec Kit Prompts

### Specify

<!-- spec-kit-command-id: speckit.specify -->
```text
$speckit-specify Nutze requirements/intakes/active/Lastenheft_Rename_MicroCalc_TinyCalc.md als verbindliches Intake. Erstelle oder aktualisiere ausschließlich die passende Feature-Spezifikation. Erzeuge das Live-Inventar zur Ausführungszeit und bewahre die Reihenfolge Funktionsabnahme -> A11Y -> Rename, historische Allowlist, JSON-Kompatibilität, atomaren Solution-/Projekt-/Assembly-/Namespace-Rename, vollständigen Produktvertrag, ReleaseCloseout-Matrix sowie Security-, A11Y-, Plattform-, Dokumentations- und Evidenzgrenzen. Implementiere nichts; committe und pushe nicht; erstelle oder merge keinen Pull Request und starte kein Folgefeature.
```

### Autonomous

<!-- spec-kit-command-id: speckit.autonomous -->
```text
$speckit-autonomous Führe genau einen vollständigen autonomen Spec-Kit-Lauf mit requirements/intakes/active/Lastenheft_Rename_MicroCalc_TinyCalc.md als verbindlichem Intake aus. Delivery Mode: LocalImplementation. Stoppe vor Änderungen, solange Funktions- und A11Y-Abnahme oder das Live-Inventar mit Disposition und historischer Allowlist fehlen. Bewahre JSON-Kompatibilität, atomaren Rename, vollständigen Produktvertrag, Linux-/Windows-, macOS-PTY-/VoiceOver-, DocFX/axe/lynx-, Security-, Dokumentations- und Evidenzgrenzen. Nicht pushen, keinen Pull Request erstellen oder mergen, keinen Bypass nutzen, keine Secrets offenlegen und kein Folgefeature starten.
```
<!-- intake-authoring:end -->
