# Bedrohungsmodell: TinyCalc Feature 003

## Deutscher Prüfblock

### Laufnachweis und Geltungsbereich

| Feld | Wert |
|---|---|
| Projekt | TinyCalc, Level 2 |
| Feature | 003, Terminal.Gui-v2-Migration |
| Branch | `003-terminalgui-migration` |
| Phase | Implementierung |
| Baseline | `886a13f8866e79fe6c13e6e1227217294aabdee8` plus geprüfter Arbeitsbaum |
| Datum | 2026-08-30 |
| Methode | STRIDE, CIA, CAPEC-153 und CAPEC-538 |
| Standards | ISO 27001/27002 A.8.27/A.8.28, NIST SSDF, CWE Top 25, Constitution XII–XVIII |
| Entscheidung | anwendbar; lokale Mitigations bestanden, Exact-Head- und Plattformabschluss noch offen |

Das Modell deckt Tastatureingaben, Terminal-Lifecycle, Endnutzerfehler,
unveränderte Core-/Dateigrenzen, NuGet-Lieferkette sowie CI-/Exact-Head-
Integrität ab. Es deckt keine neuen Web-, API-, Authentifizierungs- oder
Clouddienste ab, weil Feature 003 solche Flächen nicht einführt.

Die Evidenz unterstützt interne Audit- und Zertifizierungsvorbereitung. Sie
ersetzt keine externe Auditierung, Rechtsberatung oder formale Zertifizierung.

### Asset-Inventar und CIA-Matrix

| Asset oder Funktion | Beschreibung | C | I | A | Schutzbedarf |
|---|---|:---:|:---:|:---:|:---:|
| Tabellenzustand | aktuell bearbeitete Zellen und bestehendes Arbeitsblatt | M | H | M | H |
| Tastatur- und Fokuszustand | 13 bekannte Eingaben, Fokusfolge und aktiver Dialog | L | H | H | H |
| Terminal-Lifecycle | App, Root, Dialoge, Eventloop und Terminalrestauration | L | H | H | H |
| Core-Verhalten und Dateiformat | unveränderte Berechnung, Formeln und Persistenz | M | H | H | H |
| Endnutzerfehler | sichtbare Meldung ohne interne oder geheime Details | M | M | L | M |
| Paketgraph | Terminal.Gui und 23 transitive Pakete samt Quelle und Lizenz | L | H | H | H |
| Delivery-Evidenz | Commit-SHA, Befehle, Plattform, Tests, Coverage, SBOM/Provenance | L | H | M | H |

Legende: C = Vertraulichkeit, I = Integrität, A = Verfügbarkeit; H = hoch,
M = mittel, L = niedrig. Assets mit hoher Integrität oder Verfügbarkeit
erhalten mindestens zwei unabhängige Schutzschichten.

### Vertrauensgrenzen

```text
Lokale Person
    |
    | TB-1 Tastatur / CAPEC-153
    v
MicroCalc.Tui ---- TB-2 ----> MicroCalc.Core ----> lokale Dateien
    |
    | Runtime-Lifecycle
    v
Terminal.Gui

NuGet.org
    |
    | TB-3 Lieferkette / CAPEC-538
    v
Restore + Build ---- TB-4 ----> Git/CI/PR Exact Head
```

Textalternative: TB-1 trennt lokale Tastaturereignisse von der TUI. TB-2 ist
die bestehende, unveränderte Grenze zum Core und zu lokalen Dateien. TB-3
trennt NuGet.org und den Paketgraph vom Build. TB-4 bindet Arbeitsbaum,
Commit, Provider-Artefakte und PR-Head aneinander.

### STRIDE-Analyse

| ID | Grenze oder Flow | STRIDE | Bedrohung | Wkt. | Auswirkung | Risiko | Mitigation | Status |
|---|---|---|---|:---:|:---:|:---:|---|---|
| TH-001 | TB-1 Tastatur | T | manipulierte oder unerwartete Tastensequenz löst falsche Navigation, Dialogaktion oder Quit aus | M | M | M | geschlossene 13er-Zuordnung, keine dynamische Ausführung, Quellvertrag, zwei reale PTY-Sitzungen | lokal mitigiert |
| TH-002 | Lifecycle | D | verschachtelter Dialog oder falsches Stop-Ziel blockiert den Eventloop | M | H | H | eine App, creator-owned Runnables, strukturierte Freigabe, Menü-Quit und `Ctrl+Q` getrennt geprüft | lokal mitigiert; Plattform offen |
| TH-003 | Fehlerpfad | I | Stacktrace, interner Pfad oder authentifizierte Paketquelle erscheint in Endnutzer- oder getrackter Evidenz | M | M | M | kurze Endnutzerfehler, Secret-Scan, keine authentifizierte URL in Evidenz, CI-Logprüfung | lokal mitigiert |
| TH-004 | TB-2 Core-Scope | T | UI-Migration verändert Berechnung, Testquelle oder Dateiformat | N | H | M | begrenztes Delivery-Set, leerer Git-Diff, vollständige 79 Tests | lokal mitigiert; Exact Head offen |
| TH-005 | TB-3 Paketquelle | T | manipulierte Open-Source-Bibliothek oder falsche Quelle gelangt in den Build | N | H | H | exakte Version, NuGet.org, Asset-/Cache-Bindung, Graph-, Lizenz- und Vulnerability-Prüfung, SBOM/Provenance | lokal mitigiert; Release-Evidenz offen |
| TH-006 | TB-3 Paketgraph | D | verwundbare oder defekte transitive Abhängigkeit verhindert Start oder sichere Bedienung | N | H | M | null bekannte Schwachstellen, fail-closed Blocker, Build/Test/Smoke auf drei Plattformen | macOS mitigiert; Linux/Windows offen |
| TH-007 | TB-4 Delivery | T | Evidenz gehört zu anderem Commit als der gemergte PR-Head | M | H | H | einzelner Feature-Commit, Exact-Head-Hashes, Provider-Head-Prüfung, Schema-2.0-Gates | **Pending bis T063/T067** |
| TH-008 | TB-4 Delivery | R | Build- oder Reviewentscheidung kann nicht dem Commit und Providerlauf zugeordnet werden | N | M | N | Commit-SHA, Run-ID, Provider-Run, Gate-Receipt und PR-Review | lokal vorbereitet; Provider offen |
| TH-009 | Fehler/Terminal | D | wiederholte Eingabe oder Ausnahme hinterlässt Terminalmodi und macht Sitzung unbenutzbar | M | M | M | `using`, beobachtete Terminalrestauration, sicherer Fehlerzustand, Smoke | lokal mitigiert; Plattform offen |

Wkt. = Wahrscheinlichkeit; H = hoch, M = mittel, N = niedrig.

### Bewertete Nichtanwendbarkeit von STRIDE-Kategorien

**Spoofing:** Für TB-1 und TB-2 ist Identitätsvortäuschung nicht anwendbar,
weil TinyCalc keine Identität, Anmeldung, Rolle oder Remote-Gegenstelle besitzt.
Die Echtheit der NuGet-Quelle ist dagegen als Supply-Chain-Integrität in
TH-005 abgedeckt. Eine spätere Authentifizierung oder Remote-Steuerung aktiviert
eine eigene Spoofing-Analyse.

**Repudiation:** Für einzelne lokale Tastendrücke besteht keine fachliche oder
regulatorische Nichtabstreitbarkeitsanforderung; ein Produkt-Auditlog wäre eine
neue Datenschutz- und Dateifläche. Repudiation ist dort begründet `N/A`.
Für den Lieferprozess ist Zuordenbarkeit erforderlich und durch Run-ID,
Commit-SHA, Provider-Artefakt und Review in TH-008 abgedeckt.

**Elevation of Privilege:** Das Produkt besitzt keine Rollen, privilegierten
Operationen, Dienstkonten oder Rechteerhöhung. Es läuft mit den vorhandenen
Rechten des Betriebssystemkontos. Deshalb ist Rechteausweitung innerhalb des
Feature-Scope `N/A`. Bösartiger Paketcode wäre dennoch kritisch, weil er mit
denselben Benutzerrechten ausgeführt würde; dieses Risiko ist als
Lieferketten-Tampering TH-005 erfasst. Neue privilegierte Installation,
Rollen oder Dienste lösen eine Neubewertung aus.

### CAPEC-Abdeckung

| Flow | CAPEC | Angriffsmuster | Relevanz | Mitigation |
|---|---|---|---|---|
| TB-1 Tastatur | CAPEC-153 | Input Data Manipulation | unerwartete Form oder Reihenfolge von Eingaben könnte die Verarbeitung beeinflussen | geschlossene Tastenmatrix, sichere Defaults, reale PTY-Abnahme |
| TB-3 Lieferkette | CAPEC-538 | Open-Source Library Manipulation | manipulierte OSS-Bibliothek könnte über direkte oder transitive Pakete verteilt werden | NuGet.org-Bindung, exakte Version, Graph-/Advisory-/Lizenzprüfung, SBOM/Provenance, OpenSSF-Review |

### Risiko- und Maßnahmenregister

| Risiko | Schwere | Owner | Maßnahme und messbarer Abschluss | Frist oder Trigger |
|---|---|---|---|---|
| R-003-01 Eventloop-/Lifecycle-DoS | hoch | Feature 003 | eine App; beide Quit-Pfade Exit 0; Plattformjobs grün | T066 vor Merge |
| R-003-02 Supply-Chain-Manipulation | hoch | Feature 003 / Delivery | 24/24 NuGet.org, 0 bekannte Schwachstellen, 0 offene Lizenzen, SBOM/Provenance Exact Head | T052/T067 vor Merge |
| R-003-03 Commit-/Evidenzdrift | hoch | Delivery | PR-Head identisch zu allen Primary-Gates; Schema-Validator Exit 0 | T067 vor Merge |
| R-003-04 Informationspreisgabe | mittel | Feature 003 | keine geheimen URLs, Stacktraces oder internen Details in Endnutzerausgabe/getrackter Evidenz | bei jeder Evidenzänderung |
| R-003-05 Core-Scope-Drift | mittel | Feature 003 | `git diff --exit-code -- tests src/MicroCalc.Core CALC.HLP` Exit 0 am Exact Head | T062/T067 |

### Residualrisiken und Exact-Head-Platzhalter

| ID | Residualrisiko | Aktuelle Disposition |
|---|---|---|
| RR-001 | Terminaltreiber verhält sich unter Linux oder Windows anders als unter macOS | offen bis echte Providerjobs T066 bestanden sind; keine Ableitung aus macOS |
| RR-002 | Advisory-Daten oder Upstream-Zustand ändern sich nach lokaler Prüfung | erneute NuGet-/Advisory-/Lizenzprüfung am unveränderten PR-Head |
| RR-003 | Provider- oder Registry-Kompromittierung trotz lokaler Metadatenprüfung | SBOM, Provenance/SLSA, Exact-Head-Bindung und OpenSSF-Review reduzieren, aber beseitigen das Risiko nicht vollständig |
| RR-004 | Exact-Head-Beleg existiert vor dem einzigen Feature-Commit noch nicht | **Pending**: T063 erzeugt den Commit; T067 validiert alle Primary-Gates gegen genau diesen PR-Head. Vorher kein Pass und keine Mergefreigabe. |

Das aktuelle lokale Modell ist bestanden, aber RR-001 und RR-004 sind
Lieferblocker bis zu ihren vorgesehenen Provider- und Exact-Head-Gates.

### Audit-Matrix

| Prüfpunkt | Ergebnis | Evidenz |
|---|---|---|
| Scope und Assets | OK | dieses Dokument, Architektur und Feature-Spec |
| STRIDE je Vertrauensgrenze | OK | TH-001 bis TH-009 |
| CAPEC-Hochrisikopfade | OK | CAPEC-153 und CAPEC-538 |
| Nichtanwendbarkeit | OK, begründet | Spoofing, Repudiation und Elevation mit konkreten Triggern |
| Lokale Mitigations | OK | Tests, Smoke, PTY, Coverage, Paket- und Lizenznachweis |
| Plattformbeleg | offen | T066 Linux/Windows |
| Exact-Head-Beleg | offen | T063/T067; ausdrücklich kein vorzeitiger Pass |

## English review block

### Scope and assets

This threat model covers keyboard input, Terminal.Gui lifecycle, user-facing
error disclosure, unchanged Core and file boundaries, the NuGet supply chain,
and CI/exact-head integrity for Feature 003. It uses STRIDE, CIA, CAPEC-153,
and CAPEC-538. It does not invent web, API, authentication, or cloud surfaces.

High-integrity or high-availability assets are spreadsheet state, keyboard and
focus state, terminal lifecycle, unchanged Core behaviour and file format, the
shipped package graph, and delivery evidence. The shared CIA table above is
authoritative for both language blocks.

### STRIDE and CAPEC results

The material threats are manipulated keyboard sequences, lifecycle denial of
service, error-detail disclosure, Core-scope tampering, open-source package
manipulation, broken transitive dependencies, and commit/evidence drift. Local
mitigations use the closed 13-key map, one creator-owned application, structured
disposal, safe errors, an unchanged-scope diff, all 79 tests, real PTY sessions,
82 percent changed-code coverage, and a fully reviewed NuGet graph.

CAPEC-153 Input Data Manipulation maps to unexpected keyboard form and order.
CAPEC-538 Open-Source Library Manipulation maps to the direct and transitive
NuGet graph. Exact source and version, advisory and license gates, SBOM/
provenance, and upstream review mitigate the supply-chain path.

### Non-applicability and residual risk

Identity spoofing is not applicable to the local product because it has no
identity or remote peer; source authenticity is covered as supply-chain
integrity. Non-repudiation is not required for local keystrokes, so no product
audit log is added; delivery attribution remains applicable and uses run IDs,
commits, provider runs, and review. Elevation of privilege is not applicable
inside the product because there are no roles, services, privileged operations,
or elevation. Malicious dependency code remains a high tampering risk even
when it runs only with existing user privileges.

Linux and Windows terminal behaviour remains open until T066. Exact-head
evidence is explicitly pending: T063 must create the feature commit, and T067
must validate every primary gate against that unchanged PR head. Neither item
is claimed as passed early, and both remain delivery blockers.

## Referenzen / References

- [MITRE CAPEC-153: Input Data Manipulation](https://capec.mitre.org/data/definitions/153.html)
- [MITRE CAPEC-538: Open-Source Library Manipulation](https://capec.mitre.org/data/definitions/538.html)
- `docs/architecture/terminalgui-migration.md`
- `docs/security/arc42-security.md`
- `docs/security/adr/003-terminalgui-lifecycle-supply-chain.md`
- `specs/003-terminalgui-migration/security-plan.md`
- Constitution Principles XII, XIII, and XVII
