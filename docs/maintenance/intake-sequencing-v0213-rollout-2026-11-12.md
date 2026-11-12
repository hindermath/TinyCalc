# Intake Sequencing Governance v0.2.13

## Deutsch

Nur Intake Sequencing Governance wurde von 0.2.12 auf 0.2.13 aktualisiert;
die anderen 13 Presets behalten Version, Prioritaet und installierten Inhalt.
Das Dokumentationspatch beschreibt die Sicherheitspruefungen aus 0.2.12
korrekt. Skripte, Commands und Templates sind unveraendert; der
Receipt-Generator bleibt 0.2.12. Keine neue Produkt- oder Ausfuehrungsfreigabe.

Quelle: Quell-PR hindermath/spec-kit-preset-intake-sequencing-governance#22,
Merge-/Tag-Commit 41ffb8fc93f857d1914e8be3693b7f6d021f5231.
ZIP SHA-256: 7dd29964d16bb8a8e0a107c2054ae8e0f69da99bdb7a6d5f320337d055fde3de.
Die 63 Archivdateien wurden bytegleich zum Tag geprueft. Eine isolierte
Installation und die Aufloesung aller 12 Templates und sechs Commands
bestanden. Alle sechs nativen Quell-CI-Checks bestanden. Der zentrale
Installer wurde mit einem Ein-Preset-Profil nach Vorschau ausgefuehrt;
danach binden die Source-/Installed-Locks den neuen Stand. Weitere lokale
und gehostete Rollout-Pruefergebnisse stehen am zugehoerigen Liefer-PR.

## English

Only Intake Sequencing Governance changes from 0.2.12 to 0.2.13. The other
thirteen packages retain their versions, priorities and installed payloads.
The documentation patch accurately describes the security checks introduced
in 0.2.12. Runtime scripts, commands and templates are unchanged; receipt
generator remains 0.2.12. This grants no product or execution authority.

The tag/archive binding above was verified byte-for-byte. Isolated
installation and all twelve template/six command resolutions passed, as did
all six native source CI checks. A preview preceded the focused one-preset
installer. Source and installed locks bind the resulting state; current
local/hosted delivery checks are recorded on the delivery PR.

Documentation Impact: UpdateRequired. Owner: Thorsten Hindermann. Audience:
workspace maintainers and reviewers. Canonical sources: preset release,
profile matrices and separate source/installed locks. Navigation: this record
and project-statistics ledger. DE/EN together; text-first Markdown.
Distribution: installed package/source evidence plus homeRuntime profile
matrices where assigned by the distribution manifest. Home sync is checked
after Level-0 merge; consumer repositories receive no Home sync.
Re-evaluate on source, matrix, installed payload or review drift.

## TinyCalc GSDB binding

DE: Die aktuelle GSDB-Matrix und die strikte Validator-Konstante binden Sequencing 0.2.13. Der unveraenderte JSON-Vorgaenger liegt im History-Verzeichnis. Neue Negativfaelle verwerfen das Manifest-Hash und die Version 0.2.12. Alle Kontrollzeilen, Findings und externen Pflichten wurden strukturgleich erhalten.

EN: Updated the current GSDB version/manifest binding and strict validator constant; preserved the previous JSON snapshot. Added stale-0.2.12 hash/version negatives. Control rows, findings and external duties remain structurally identical.

Technischer Nachpruefer / technical reviewer: OpenAI Codex. Dies ist keine unabhaengige menschliche Nachpruefung / this is not independent human review. Die Registry-Bindung wurde ebenfalls aktualisiert, nachdem die Unveraendertheit der anderen 13 Eintraege geprueft wurde / the registry binding was refreshed after verifying the other thirteen entries are unchanged.

Pruefung / verification: Productive Validate, Bash/PowerShell parity fixtures and the separate PowerShell GSDB001-GSDB010 suite passed. Structural comparison preserves all 157 checklist rows, 14 findings and 16 external duties; only two source bindings and the Sequencing assessment differ.

DE/EN: Die aktuellen Sequencing-Versionsverweise in gemeinsamer Guidance und beiden Constitutions wurden auf 0.2.13 angeglichen; die drei davon in der GSDB gebundenen Quellen wurden erneut gehasht / aligned current Sequencing references in shared guidance and both constitutions, rehashing the three GSDB-bound sources. Datierte historische Paketnachweise bleiben erhalten / dated historical package evidence is preserved.
