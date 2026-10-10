# Feature 006: technischer Security-Checkpoint / Technical security checkpoint

## Deutscher Prüfblock

Stand 2026-10-10. Owner Thorsten; technische Selbstprüfung durch die
Feature-Entwicklung, **kein unabhängiger Review und keine Risikoakzeptanz**.
SSDF/CWE Top 25, C# Secure Coding, Constitution XII/XIII und ISO A.8.27/A.8.28
gelten. STRIDE/CAPEC-153/-538 bleiben im Bedrohungsmodell zugeordnet.

| Grenze / Risiko | Implementierte Kontrolle und tatsächlicher Beleg | Restgrenze |
|---|---|---|
| Formeln / CWE-20, CWE-400 | unabhängige Spec-Orakel, endliche Ergebnisse, Grenzen, echte UI-Tests | keine alternative Test-Fachlogik |
| Load / Integrität | vollständige Validierung vor Übernahme, Fehler/Abbruch erhalten Blatt, Auswahl und AutoCalc | Nutzende besitzen eigene Dateien; kein Sandbox-Versprechen |
| JSON/Evidence / CWE-20 | strikte Schemas, doppelte Schlüssel abweisen, unabhängiger Nenner, aktuelle Quell-/Pin-/Head-/Payload-Bindung | unabhängiger Reviewer muss Beleginhalt beurteilen |
| Pfade / CWE-22 | explizite Wurzeln, Symlink-/Traversal-Abwehr, sichere eigene Testausgabe, literal Hashpfade | kein JSON-gesteuertes Kommando |
| TRX / CWE-611, CWE-400 | kein DTD/Resolver, 20-MiB-Limit, exakte Klasse/ID/Zeiten/Pass, beide Suite-Dateien grün | synthetische Fixtures sind nie native Evidenz |
| Neue Anforderungen / Manipulation | eigene ID, rote Testquelle/TRX als historische Git-Blobs vor geändertem Produktcode | Review semantischer Testqualität bleibt nötig |
| PTY / Prozesse | echte Binary, feste Terminalabfragen, begrenzter Trace und eigene Prozessgruppe; 30/180/5 Sekunden | VoiceOver nicht automatisiert ersetzbar |
| macOS-Rücksetzung | validierter Snapshot, feste Argumentliste ohne Shell, stty-Fristen und später Restore-Hook | Fehlerrücksetzung unabhängig reviewen |
| Ausgabe / Disclosure | Validator ohne ANSI/private Absolutpfade; fehlende Datei nur mit bereinigtem Kurznamen | keine Secrets oder privaten Daten in Evidence |
| Lieferkette | vier unveränderte Locks, aktueller NuGet.org-Audit ohne bekannte CVEs, 24 geprüfte Produktlizenzen | finale SBOM/Provenance/Providerprüfung offen |

Lokaler Vollvertrag: 669 Pass, null Fail/Skip, 364 Pfade. Policy: 58 grün,
Semantik: 32 grün, historische Blobgrenzen: erst sechs Ablehnungsfälle rot,
danach alle sieben Fälle grün. Workflow-Guards erkennen fünf Abschwächungen;
vollständiger synthetischer Validator, Skip/wrong-class und identisches
zero-write WhatIf sind grün. Historische Prüfungen werden nicht als neue
Providerläufe ausgegeben.

ASVS N/A für das lokale Produkt ohne Web/API/Auth; kein ASVS-Level behauptet.
Produkt-AI-SBOM N/A: KI ist Entwicklungswerkzeug, kein ausgeliefertes Modell,
Dataset oder Inferenzdienst. Produkt-Zero-Trust sowie Produkt-C3A/C5 sind N/A
ohne verteilten Dienst/Cloud-Runtime. CI/Toolprovider bleiben getrennte
Applicable/Open-Bewertungen; kein neues Rechtsgutachten oder Zertifikat.
Trigger sind eine neue Produkt-, Daten-, Netzwerk-, Identitäts-, Cloud-, KI-
oder Providergrenze. Owner prüft den Trigger vor dem betroffenen Schritt.

Offen vor Abnahme: unabhängiger Security-/Architekturreview, finale native
Plattformbelege, menschliche A11Y und genaue Release-Provenance. Eine frühere
authentifizierte Feed-URL wurde aus lokaler Konfiguration/eigenen Logs entfernt;
Tool-/Chatverlauf lässt sich hier nicht löschen. Erneuerung betroffener externer
Zugangsdaten bleibt Owner-Folgeaktion; keine vertraulichen Werte werden übernommen.

## English review block

This is the implementation team's technical checkpoint, not independent review,
risk acceptance or certification. The table maps actual controls and proof to
input, file, JSON, path, TRX, historical test-first, process, disclosure and
supply-chain boundaries. Local execution passed 669 tests and all 364 paths;
policy, semantic, provenance and workflow guards passed their stated cases.
Fixtures are never native or human acceptance.

Local product ASVS, runtime AI-SBOM, distributed Zero Trust and cloud C3A/C5
remain N/A for the documented technical scope. CI/tool providers retain their
separate applicability and Open decisions. New service/data/identity/cloud/AI
or provider boundaries reopen review before the affected action. Independent
reviews, final native/human proof and release provenance remain Open. The prior
feed credential incident has no secret in this evidence; local removal cannot
delete chat/tool history or replace owner credential rotation.
