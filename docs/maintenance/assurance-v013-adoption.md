# Assurance v0.1.3 – Freigegebener Nachtrag / Approved Adoption

## Auftrag und Paketquelle / Authority and Package Source

Thorsten hat die kanonische Korrektur und ihre Integration in genau fünf
Level-2-Repositories freigegeben. TinyCalc verwendet Assurance v0.1.3,
aktiviert mit Priorität 15. Die zwölf anderen Presets, ihre Versionen,
Prioritäten und Aktivierungen sowie alle älteren Profile bleiben unverändert.
Das öffentliche Paket wird unverändert übernommen; lokale Produktkorrekturen
sind ausgeschlossen. Kein Home-Sync oder weiterer Flotten-Rollout.

*Thorsten approved the canonical correction and adoption in exactly five
Level-2 repositories. TinyCalc uses Assurance v0.1.3 at priority 15, enabled.
The other twelve presets, versions, priorities, enabled states and older
profiles are preserved. The public package is unchanged; no vendor patches,
Home sync or wider rollout are authorized.*

- [Release / Release](https://github.com/hindermath/spec-kit-preset-secure-development-assurance-governance/releases/tag/v0.1.3).
- Tag `v0.1.3`, Commit `0d03aa9ebe8f74a26e331815bca5609fb48d7a14`.
- [Öffentliches ZIP / Public ZIP](https://github.com/hindermath/spec-kit-preset-secure-development-assurance-governance/archive/refs/tags/v0.1.3.zip).
- SHA-256: `9023b442b4d82e25bee5a7fe9b73efb7f591a4f265f54061ae6e4a56b9b5c75f`.
- [13er-Matrix / Thirteen-preset matrix](../../scripts/config/spec-kit-secure-development-assurance-governance-presets.json).
- [Bedienung / Full usage](../../.specify/presets/secure-development-assurance-governance/README.md).

## Wirkung und Grenzen / Behavior and Boundaries

Review bindet jetzt die vollständige eindeutige datierte Kontext-ID sowie
Evidence-ID und Betriebsart an den Auftrag. Suffixe und Mehrdeutigkeit
blockieren. `acceptedRisks` ist bei Vorhandensein ausschließlich ein Array;
`ReadyWithAcceptedRisks` erfordert mindestens ein vollständiges Risiko.
Bestehende Evidence wird nicht automatisch migriert, neu bewertet oder
freigegeben. Status bleibt read-only. C5 bleibt ein begrenzter Bezug,
keine vollständige Kriterien-, Testat- oder Readiness-Prüfung.

*Reviews bind an exact unique dated context plus evidence ID and mode.
Suffix matches and ambiguity block. When present, acceptedRisks is an array;
ReadyWithAcceptedRisks requires at least one complete risk. No automatic
evidence migration, reassessment, human approval or C5 attestation is implied.
Status remains read-only.*

## Prüfung und Dokumentationsauswirkung / Validation and Documentation Impact

Vorher-Snapshot: 597 geschützte Dateien außerhalb der ausdrücklich
aktualisierten Assurance-Paket-/Command-Oberflächen. Die zwölf anderen
Registereinträge und ältere Profildefinitionen werden exakt verglichen.
Paketidentität, beide lesenden Statusläufe, Secret-Scan und bestehende
projektbezogene CI bleiben Liefergates. Die kanonischen Vertrags-, Negativ-,
Read-only-, LF/CRLF/BOM- und Shell-Paritätstests sowie generierten Oberflächen
müssen bestanden sein. Technische Gate-Fehler dürfen nicht per Bypass
umgangen werden. Menschliche Entscheidungsgrenzen bleiben unverändert.

`UpdateRequired`, Owner Thorsten Hindermann; Zielgruppen Maintainer, Lernende
und KI-Agenten. Leserpfad: README → historische Integration → dieser aktuelle
Nachtrag → Paket-README → read-only Status. Deutsch zuerst, Englisch danach,
textorientiert; fünf Agenten-Dateien, Matrix und Statistik werden gemeinsam
gepflegt. Produktquelle ist das eigenständige GitHub-Release. Keine Runtime-,
API- oder fachliche Review-Änderung. NIST SSDF/CWE gelten; neue ASVS-, Produkt-
AI-SBOM- und Zero-Trust-Pflichten entstehen ohne neue Runtime nicht.
Wiedervorlage bei Version, Profil, Baseline oder neuen Befunden.

*The snapshot protects 597 existing files outside the authorized
Assurance package/command update. Compare the original twelve registry
entries and profiles exactly. Package identity, both read-only status runs,
secrets, canonical regression/surface tests and project CI gate delivery.
Never bypass technical failures. Documentation impact is UpdateRequired;
Thorsten owns the bilingual text-first reader path, five agent guides,
matrix and statistics. No runtime/API change or substantive review. Existing
SSDF/CWE obligations remain; reevaluate at version/profile/baseline changes.*
## Technische Quellenbindung / Technical Source Binding

Aktueller read-only Status unter Bash und PowerShell: Kontext
`docs/security/secure-development/2026-09-05-rl-se-self-assessment`, vier Gates
und Overall `Ready`, `technicalValidation=Fulfilled`; Pilotfreigabe,
Projektabnahme und allgemeine Freigabe bleiben `Open`. Nächste dokumentierte
Aktion: unabhängiger technischer Review, bis dahin menschliche Entscheidungen
offen halten. Nicht ausgeführt. GSDB-Validierung und negative Fixtures
GSDB001–GSDB010 bestehen in beiden Shell-Einstiegen.

*Both status validators report the existing context's four Ready gates and
technicalValidation=Fulfilled; the other three human boundaries remain Open.
The recorded independent review is not started. GSDB validation and negative
fixtures pass through both shell entry points.*

Die genehmigte Aktualisierung bindet ausschliesslich vier geaenderte Quellen neu: PRESET-secure-development-assurance-governance (Manifest), SRC-049 (Validator), SRC-054 (Registry) und SRC-055 (AGENTS.md). Drei Assurance-Versionsfelder, die Preset-Mapping-Zeile und der erwartete Assurance-Versionswert im GSDB-Validator werden auf 0.1.3 fortgeschrieben. Der Bytevergleich erlaubt genau diese Versions-/Hashersetzungen. Alle Bewertungen, Kontrollzuordnungen, Risiken, Termine und menschlichen Freigaben bleiben unveraendert. Das ist keine neue fachliche GSDB-Pruefung oder Erfuellungsbehauptung; Vorgängercommits bewahren die alte Bindung.

*Only four changed technical sources are rebound: preset manifest, validator, registry and AGENTS.md. Three Assurance version fields, the mapping row and the validator's expected version follow 0.1.3. Preservation permits exactly these version/hash replacements. Dispositions, control mappings, risks, dates and human decisions are unchanged. This is not a new substantive GSDB review or fulfilment claim; previous commits retain the old bindings.*
