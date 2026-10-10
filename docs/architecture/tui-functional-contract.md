# TUI-Funktionsvertrag / TUI functional contract

## Deutscher Architekturblock

Feature 006, Implementierungscheckpoint 2026-10-10, lokaler Branch
`006-tui-functional-contract`, Basis `ffc3d56a8975341a686ff6985570369abefcfd2a`.
Verbindlich sind Intake, genehmigte Spec/Plan und 83 Tasks; keine neue öffentliche
API, Laufzeit, Produktabhängigkeit oder Produktdateiformat. Implementierung und
unabhängige Abnahme sind verschiedene Zustände.

```text
Anwendende -> produktive Terminal.Gui-Views -> interne TuiSession -> Core
Tests -----> dieselben Views/Bindings ------> beobachteter Zustand
Quellen ---> unabhängiges Pflichtinventar ---> versionierter Vertrag
Tests -----> Assertions/Resultate ----------> atomare Nachweisdatei
Validator -> liest Vertrag + Quellen + Nachweise; startet keine Befehle
```

Die Core-Schicht bleibt unabhängig von TUI und Evidenz. `Program` besitzt
Start/Smoke; nach dem Legacy-Rot wird eine interne instanzgebundene Session
extrahiert. Sie besitzt Views und Ressourcen, nicht alternative Test-Fachlogik.
Vorher ruft ausschließlich ein testseitiger Adapter `BuildWindow`/`RefreshUi`
über begrenzte Reflection auf. Eingaben laufen über Framework-Injektion, nie
direkt über HandleKey, Editor- oder Engine-Aktionen. Read-only Beobachtung und
definierter Setup/Reset sind zulässig. Die Session-Extraktion entfernt Reflection.

Qualitätsziele: vollständige angebotene Funktion, Datenintegrität bei Abbruch
und Fehler, zugängliche Bedienung, reproduzierbare Nachweise, sichere begrenzte
Ressourcen. Szenarien: ungültiges Load erhält das alte Blatt; Esc im zweiten
Print-Prompt erzeugt keine Datei; ein fehlender Alias oder geschwächter Test
sperrt das Bundle; 80x24 bleibt bedienbar; ein späterer Commit erbt keine finale
Freigabe. Native Linux/Windows-Resultate und macOS-PTY/VoiceOver bleiben getrennt.

Vertragsschemas sind strikt. Der unabhängige Nenner schützt gegen koordinierte
Löschung von Vertrag und Tests. Quelle, Vertragsrevision, Pin und Ausführung
werden per Hash gebunden. Ein lokaler Arbeitsbaumdigest ersetzt keinen finalen
Commit. Producer schreiben außerhalb des read-only Validators atomar und nur
nach vollständigen ausgeführten Assertions; Skip/Timeout sind kein Pass.

Risiken/Schulden: aktuelle statische Program-Zustände erfordern serielle Tests;
vorübergehende Reflection ist auf T016/T019 begrenzt. Framework-Injektion
beweist keinen realen Terminaltreiber oder VoiceOver. Plattform-/Human-Evidenz
und unabhängiger Review sind noch offen. Zeitgrenzen 30/180/5 Sekunden werden
als Fehlergrenzen, nicht als Produkt-SLA behandelt. Eigene temporäre Ressourcen
dürfen bereinigt werden, fremde Prozesse und Dateien nie.

## English architecture block

Feature 006 uses the existing four projects and approved plan without new
public APIs, runtime dependencies or product formats. Core remains independent
of TUI/evidence. The diagram separates real product interaction, independent
source obligations, actual assertion results and a read-only validator.

Before extraction, a test-only adapter uses narrow reflection only for existing
view construction/refresh and read-only observation. Framework input exercises
real controls; no direct business actions substitute for interaction. After
legacy functional red, an internal instance-owned session replaces static
ownership and removes reflection while preserving behaviour.

Quality scenarios cover atomic failed loads, cancellation without output,
missing/weak tests blocking proof, minimum-size usability and exact final-head
binding. Strict schemas, independent obligations and atomic producer output
support evidence integrity. Skip/timeout never counts as pass. Serialized
framework tests, temporary reflection and separate native/PTY/human evidence
are explicit costs and proof boundaries. Full acceptance and independent review
remain pending; the 30/180/5-second limits govern only owned infrastructure.

Related: [ADR](adr/006-internal-session-evidence.md),
[contract](../contracts/tui/README.md),
[security decision](../security/adr/004-tui-contract-evidence.md).
