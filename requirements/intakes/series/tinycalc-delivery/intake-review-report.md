# Intake-Review: TinyCalc Delivery Series

## Identität / Identity

- Review-ID: `c00e3d93-58fe-4d36-b1a4-94090cca1137`
- Modus: `Series`
- Policy: `tinycalc-delivery-v1`
- Ergebnis: `Ready`
- Umfang: 13 Ziele, 4 Wurzeln und 9 verbindliche interne Abhängigkeiten
- Worker: keine
- Vorgängerreview: `2c338c63-9f64-47c1-ba50-a95c7ea3fce1`

*The complete re-review covers all thirteen current targets, four roots, and
nine binding internal dependencies. It explicitly supersedes the stale
ten-target review.*

## Ergebnis / Result

Die Intake-Serie ist für die nachgelagerte Spec-Kit-Bearbeitung bereit. Alle
13 Zielpfade und Hashes, die vier Wurzeln, die neun harten Kanten, die
Lebenszykluszustände und die Authority-Grenzen sind konsistent. Die Kette
lautet jetzt verbindlich:

`Terminal.Gui-Migration -> vollständige Funktionsabnahme -> A11Y -> Rename ->
didaktische Kommentare -> Secure Development -> PL/0 -> Legacy-Kompatibilität
-> Formelkopie und Tabellenoperationen`.

Die drei unabhängigen Governance-Wurzeln für Sandbox-Härtung, RL-SE-Prüfung
und GSDB-Prüfung bleiben ohne erfundene Produktabhängigkeiten erhalten.

*The series is ready for downstream Spec Kit processing. Target identities,
hashes, roots, hard gates, lifecycle states, and authority boundaries agree.
The independent governance roots remain independent.*

## Vollständiger Produktvertrag / Complete Product Contract

Der neue Funktionsvertrag erfasst alle heute über TUI, README und migrierte
Hilfe angebotenen Bedienwege mit stabilen, additiv erweiterbaren IDs. Seine
Quellen- und Konfliktregel unterscheidet echte Angebote von eindeutigen
Dokumentationsdefekten. Eine verbindliche Impact-Matrix ordnet Änderungen den
erforderlichen Funktions-, A11Y-, PTY-/VoiceOver-, DocFX/axe/lynx- und
Linux-/Windows-Nachweisen zu. Größere, unklare, dependency-bezogene,
Rename- und Release-Änderungen erhalten die vollständige Matrix.

*The new functional contract covers every capability currently offered by the
TUI, README, and migrated help. Stable additive IDs and the impact matrix let
future PL/0, legacy, and other features extend the contract without weakening
regression coverage.*

## Erweiterungen und Reihenfolge / Extensions And Order

- PL/0 bleibt hinter Secure Development und ergänzt den Produktvertrag, ohne
  bestehende IDs zu ersetzen. Der Dependency-Preflight löst die dann aktuell
  freigegebenen Repository-Pins auf und führt kein automatisches Upgrade aus.
- Legacy-Kompatibilität folgt PL/0. Version 1 umfasst belegte Standard- und
  8087-MCS-Dialekte mit compiler-authentischen Fixtures; BCD bleibt auf Basis
  der historischen Quellen ein ausdrücklich belegtes Nicht-Ziel.
- Formelkopie sowie Einfügen und Löschen von Zeilen oder Spalten folgen als
  eigenes Lastenheft. Überlappende Kopien verwenden einen unveränderlichen
  Quell-Snapshot; strukturelle Operationen verschieben vollständige Zellrecords
  atomar und machen ungültige Ziele als `#REF!` sichtbar.

*PL/0, evidenced MCS compatibility, and structural spreadsheet features are
separate ordered contracts. This separation keeps future additions traceable
and lets the regression baseline grow before implementation begins.*

## Sicherheit, A11Y und Authority / Security, A11Y And Authority

NIST SSDF und CWE Top 25 gelten für die Level-2-Arbeit. STRIDE/CAPEC werden
für Import- und Interpretergrenzen verwendet. SBOM und SLSA gelten für
verteilbare Artefakte; VEX wird bei bekannten Schwachstellen benötigt. ASVS,
Zero Trust und AI-SBOM sind für die lokale, nicht KI-basierte TUI jeweils mit
Begründung `N/A`. WCAG 2.2 Level AA, deutsch-zuerst/englisch-danach und
CEFR-B2 bleiben verbindlich.

Das Ergebnis `Ready` bestätigt ausschließlich Qualität und Konsistenz der
Intake-Artefakte. Es bestätigt keine fertige Produktimplementierung, keine
bestandene TUI-Funktions- oder A11Y-Abnahme und erteilt keine Commit-, Push-,
PR-, Merge-, Provider-, Paketveröffentlichungs- oder Bypass-Berechtigung.

*NIST SSDF, CWE Top 25, applicable threat and supply-chain evidence, and WCAG
2.2 AA are explicit. `Ready` applies only to intake quality; it is not product
acceptance and grants no remote or delivery authority.*

## Findings und nächste Aktion / Findings And Next Action

- Critical: 0
- High: 0
- Medium: 0
- Low: 0
- Akzeptierte Risiken: keine
- Offene Fragen: keine
- Nächste Aktion: `$speckit-intake-series-next tinycalc-delivery`

*No finding, accepted risk, or open question remains. The next read-only step
is to determine the currently eligible target from the validated series.*
