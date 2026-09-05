# RL-SE-Checklist-Selbstpruefung

## Deutscher PR-Block

### Zusammenfassung

Dieser Pull Request bewertet den aktuellen TinyCalc-Stand gegen die
Secure-Development-Baseline 3.2.0 und alle 157 kanonischen Punkte aus `CL-01`
bis `CL-12`. Er liefert eine validierte maschinenlesbare Matrix, einen
linearen zweisprachigen Leserbericht, vier Assurance-Gates und konkrete
Folgearbeit. Produktcode und Produktverhalten bleiben unveraendert.

### Problem

Die vorhandenen Sicherheitsdokumente decken viele Themen ab, boten aber noch
keine einzelne, reproduzierbare Zuordnung aller stabilen RL-SE-IDs zum
TinyCalc-Stand. Dadurch waren belegte Aussagen, begruendete Nichtanwendbarkeit,
menschliche Entscheidungen und spaetere Haertung nicht in einer gemeinsamen
Pruefsicht getrennt.

Der Assurance-Validator fand ausserdem eine echte Versionsdrift im
Baseline-Manifest. Nach ausdruecklicher enger Scope-Freigabe wurden nur die
veralteten Versionsangaben auf den bereits vorhandenen Dokumentstand
angehoben und alle abhaengigen Hashbindungen neu erzeugt. Fachliche Inhalte
der kontrollierten Dokumente wurden dabei nicht veraendert.

### Loesung

- `assessment-matrix.json` bildet jede der 157 kanonischen IDs genau einmal ab.
- Jede Zeile nennt Disposition, Anwendbarkeit, Umsetzungsstand, Begruendung,
  Evidenz, Owner, Folgeaktion, Prioritaet, Risiko, Trigger und Restrisiko.
- Positive Aussagen benoetigen konkrete Repository-Evidenz; Dateiexistenz
  allein gilt nicht als Erfuellungsnachweis.
- Human-only-Punkte bleiben ohne autorisierte menschliche Evidenz `Open` und
  `NotProvided`.
- Ein PowerShell-Validator und ein duennes Bash-Frontend pruefen das gesamte
  JSON-Schema, IDs, Statuskombinationen, Pfade, Baseline-Versionen und
  normalisierte SHA-256-Bindungen reproduzierbar.
- Baseline, Delta, Closure und Image Impact entsprechen Assurance Governance
  0.1.2. Der read-only Status und genau ein unabhaengiger Closure-Review
  melden fuer den lokalen Evidenzstand `Ready`.
- Der Leserbericht fasst alle zwoelf Familien, Entscheidungsgrenzen,
  Restrisiken und priorisierte Folgearbeit DE-first/EN-second zusammen.

### Ergebnis

- 21 `AlreadySatisfied`
- 32 begruendete `N/A`
- 42 Human-only `Open`
- 62 technische oder organisatorische `FollowUp`
- 157 von 157 IDs vorhanden; 0 fehlend, 0 doppelt, 0 unbekannt
- 0 unbelegte positive Aussagen und 0 still ausgelassene Entscheidungen

Die technische Validierung ist `Fulfilled`. Pilotfreigabe, Projektabnahme und
allgemeine Freigabe bleiben getrennt `Open`.

### Scope und Nicht-Ziele

Im Scope sind die Feature-Spezifikation und -Evidenz, die RL-SE-Matrix und
Assurance-Dateien, beide Validator-Einstiege, Documentation Impact, der
Sicherheitsindex, die spaetere minimale Linux-/Windows-CI-Ergaenzung,
Versionierung und Projektstatistik.

Nicht im Scope sind:

- Aenderungen unter `src/` oder `tests/`;
- automatische Produkthaertung oder Dependency-Updates;
- neue Architektur, APIs, XML-Kommentare oder DocFX-Navigation;
- Rechtsberatung, Zertifizierung, Auditbestaetigung oder erfundene Freigabe;
- externe Provider-Aktionen ausserhalb des autorisierten Delivery-Ablaufs;
- der GSDB-Folgelauf.

### Security und Lieferkette

NIST SSDF und CWE Top 25 gelten immer. C#/.NET ist die speichersichere
Primaersprache. STRIDE, CAPEC-153/538, SBOM, bedingtes VEX,
SLSA/Provenance, OpenSSF und SAMM sind sichtbar bewertet. ASVS,
Produkt-AI-SBOM und Zero Trust sind fuer den aktuellen lokalen TUI-Scope mit
konkreten Triggern `N/A`. CRA, NIS2, EU AI Act, DORA und BSI C3A/C5 erhalten
keine technische Scheinentscheidung; die betroffenen Punkte bleiben offen.

### Barrierefreiheit und Dokumentation

Der Leserbericht ist Deutsch zuerst und Englisch danach auf CEFR-B2-Niveau.
Eine lineare Textalternative ergaenzt die Ergebnistabelle. Keine Bedeutung
haengt nur an Farbe, Zeigerbedienung oder raeumlicher Anordnung. Der bestehende
Sicherheitsindex erhaelt einen relativen Link; DocFX-Navigation und generierte
HTML-Ausgabe werden nicht veraendert.

### Konfigurationswirkung

Produkt-, Runtime-, Paket- und Providerkonfiguration bleiben unveraendert.
Die vorhandene CI-Datei wird spaeter nur um die beiden RL-SE-Validatoren fuer
Linux und Windows ergaenzt. Die drei Repository-Versionsfelder bleiben gemaess
Build-Ledger identisch.

### Testplan

Lokal auszufuehren:

```text
pwsh -NoProfile -File scripts/validate-rl-se-assessment.ps1 -Assessment <matrix>
bash scripts/validate-rl-se-assessment.sh --assessment <matrix>
schema-negative fixture with an unexpected root property (must exit 2)
bash <assurance-validator> status <evidence-directory>
bash <assurance-validator> review closure rl-se-self-assessment development
dotnet restore MicroCalc.sln
dotnet build MicroCalc.sln --configuration Release --no-restore
dotnet test MicroCalc.sln --configuration Release --no-build
dotnet run --no-build --configuration Release --project src/MicroCalc.Tui/MicroCalc.Tui.csproj -- --smoke
```

Zusaetzlich laufen Dokumentations-, Statistik-, Homogenitaets-, Secret-,
Shell- und PowerShell-Gates. Vor dem Merge muessen echte Linux- und Windows-
Providerjobs sowie Reviews auf demselben unveraenderten PR-Head gruen sein.

### Risiken und Begrenzungen

| Risiko | Begrenzung |
|---|---|
| unbelegte Compliance-Aussage | konkrete Evidenzpflicht und konservative Statuswerte |
| veraltete Quelle oder Evidenz | normalisierte Hashbindung und explizite Trigger |
| technische Pruefung wird als Freigabe gelesen | vier getrennte Entscheidungsgrenzen |
| offene Punkte werden versehentlich umgesetzt | eigener autorisierter Arbeitsauftrag erforderlich |
| plattformabweichender Validator | gemeinsamer PowerShell-Kern plus Linux-/Windows-CI |
| Evidenz gehoert zu anderem Commit | Exact-Head-Gates, PreMerge und kausaler PostMerge-Nachweis |

### Delivery-Grenze

DeliveryMode ist `MergeAndSync`. Admin-Bypass darf nur eine nach allen
materiellen Gates verbleibende formale Merge-Regel ueberwinden. Er ersetzt
niemals technische, Security-, A11Y-, Governance-, Evidence-, Plattform- oder
Review-Gates. Nach dem Feature-Merge folgt genau ein evidence-only Closeout;
erst dessen vollstaendiger MergeAndSync-Abschluss darf den GSDB-Lauf
freischalten.

## English PR block

### Summary and problem

This pull request assesses the current TinyCalc state against Secure
Development Baseline 3.2.0 and all 157 canonical items from `CL-01` through
`CL-12`. Existing security documents did not yet provide one reproducible view
that separates supported statements, justified non-applicability, human
decisions, and later hardening.

The assurance validator also found real version drift in the baseline
manifest. After explicit narrow scope approval, only stale version declarations
were aligned with the already existing document versions and dependent hashes
were regenerated. Controlled document content was not changed.

### Solution and result

The machine-readable matrix contains each canonical ID exactly once and gives
every row its disposition, two status axes, rationale, evidence, owner,
follow-up, priority, risk, trigger, residual risk, and Human-only boundary.
PowerShell and Bash entry points validate the complete JSON Schema contract
and normalized source bindings. The result is 21 `AlreadySatisfied`, 32 justified `N/A`, 42
Human-only `Open`, and 62 `FollowUp` items. All 157 IDs are present with no
missing, duplicate, or invented ID.

All four assurance gates and the strictest overall result are `Ready`.
Technical validation is `Fulfilled`; pilot authorization, project acceptance,
and general release remain independently `Open`. One independent closure
review reports `Ready` for the same local evidence state.

### Scope, security, and accessibility

This is an assessment and evidence feature. It does not change `src/`, tests,
product behavior, dependencies, architecture, APIs, XML comments, or DocFX
navigation. It does not perform hardening or make a legal, audit,
certification, or human approval decision.

NIST SSDF, CWE Top 25, C# secure coding, STRIDE/CAPEC, supply-chain evidence,
SBOM, conditional VEX, SLSA/provenance, OpenSSF, and SAMM are explicitly
handled. ASVS, product AI-SBOM, and Zero Trust have narrow technical `N/A`
decisions with triggers. Regulatory and organizational decisions remain open.

Reader documentation is German first and English second at CEFR B2 level. A
linear text alternative accompanies the result table, and no meaning depends
only on color, pointer input, or spatial layout.

### Tests, risks, and delivery

Local gates cover both matrix-validator entry points, assurance status, one
independent closure review, restore, Release build, full tests, exact smoke,
documentation impact, statistics, homogeneity, secrets, shell, and PowerShell.
Real Linux and Windows jobs and provider reviews must pass on the unchanged PR
head before merge.

Main risks are unsupported compliance claims, stale evidence, confused human
approval boundaries, unauthorized follow-up implementation, platform drift,
and commit/evidence mismatch. Conservative status rules, normalized hashes,
separate decisions, explicit authorization boundaries, cross-platform CI, and
exact-head gates mitigate them.

DeliveryMode is `MergeAndSync`. Admin bypass may address only a remaining
formal merge rule after every material gate passes. It never replaces a
technical, security, accessibility, governance, evidence, platform, or review
gate. The GSDB follow-up remains blocked until the causal evidence-only
closeout is also merged and synchronized.
