# TUI-Funktionsvertrag / TUI functional contract

## Deutscher Architekturblock

Feature 006, Implementierungscheckpoint 2026-10-10, lokaler Branch
`006-tui-functional-contract`, Basis `ffc3d56a8975341a686ff6985570369abefcfd2a`.
Verbindlich sind Intake, genehmigte Spec/Plan und 83 Tasks; keine neue öffentliche
API, Laufzeit, Produktabhängigkeit oder Produktdateiformat. Implementierung und
unabhängige Abnahme sind verschiedene Zustände. Der
[unabhängige Architektur-/Securityreview](../security/secure-development/006-tui-functional-contract/independent-review.md)
einschließlich JSON-/DocFX-Korrekturprüfung wurde am 2026-10-10 durchgeführt.
Human-/Owner-Abnahme und finale Headbindung bleiben getrennt.

```text
Anwendende -> produktive Terminal.Gui-Views -> interne TuiSession -> Core
Tests -----> dieselben Views/Bindings ------> beobachteter Zustand
Quellen ---> unabhängiges Pflichtinventar ---> versionierter Vertrag
Tests -----> Assertions/Resultate ----------> atomare Nachweisdatei
Validator -> liest Vertrag + Quellen + Nachweise; startet keine Befehle
```

Die Core-Schicht bleibt unabhängig von TUI und Evidenz. `Program` besitzt
Start/Smoke. Nach echtem Legacy-Rot wurde dieselbe UI als interne instanzgebundene
Session extrahiert; der aktuelle Adapter verwendet keine Reflection mehr.
Sie besitzt Views und Ressourcen, nicht alternative Test-Fachlogik. Eingaben
laufen über Framework-Injektion, nie direkt über HandleKey, Editor- oder
Engine-Aktionen. Read-only Beobachtung und definierter Setup/Reset bleiben zulässig.
Auf macOS umschließt `TerminalStateLease` App und Session: Zustand vor Init lesen,
Treiber/Views abbauen, Zustand zurückgeben und späte ProcessExit-Rücksetzung
danach erneut absichern. Nur feste `/bin/stty`-Argumente und begrenzte Prozesse;
kein erratenes natives Strukturformat oder aus JSON ausgeführter Befehl.

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

Risiken/Schulden: Terminal.Gui-Prozesszustand erfordert weiterhin serielle Tests;
historische Reflection ist entfernt. Framework-Injektion beweist keinen realen
Terminaltreiber oder VoiceOver. Der echte macOS-Vollvertrag ist lokal gebunden,
natives Linux/Windows ist am dokumentierten PR-Testmerge grün. Finale gemeinsame
Headbindung und Human-/Owner-Evidenz bleiben offen; Quell-/Delta-Review ist erfolgt.
Zeitgrenzen 30/180/5 Sekunden werden
als Fehlergrenzen, nicht als Produkt-SLA behandelt. Eigene temporäre Ressourcen
dürfen bereinigt werden, fremde Prozesse und Dateien nie.

## English architecture block

Feature 006 uses the existing four projects and approved plan without new
public APIs, runtime dependencies or product formats. Core remains independent
of TUI/evidence. The diagram separates real product interaction, independent
source obligations, actual assertion results and a read-only validator.

Actual legacy functional red preceded internal session extraction. The current
adapter no longer uses reflection. Framework input exercises the same product
controls; no direct business actions substitute for interaction. On macOS an
outer terminal lease captures configuration before driver init, restores it
after app/session disposal and registers a final restore after late driver
exit hooks. Fixed stty arguments, owned processes and bounded deadlines avoid
native-layout guesses or execution of evidence-controlled commands.

Quality scenarios cover atomic failed loads, cancellation without output,
missing/weak tests blocking proof, minimum-size usability and exact final-head
binding. Strict schemas, independent obligations and atomic producer output
support evidence integrity. Skip/timeout never counts as pass. Serialized
framework tests and separate native/PTY/human evidence
are explicit costs and proof boundaries. Full acceptance and independent review
remain separate from the completed independent source/delta review. Native CI
passes at its recorded testmerge, not a later final head. Human/owner acceptance
and final common-head binding remain pending. The 30/180/5-second limits govern
only owned infrastructure.

Related: [ADR](adr/006-internal-session-evidence.md),
[contract](../contracts/tui/README.md),
[security decision](../security/adr/004-tui-contract-evidence.md).
