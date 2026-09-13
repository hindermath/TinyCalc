# TinyCalc Gesamtserienreview / Full-series review

Ergebnis: **NeedsRemediation**. 13 Ziele, keine Worker; Critical 0, High 0,
Medium 3, Low 0. Keine akzeptierten Risiken und keine offenen Rueckfragen.
Review-ID: 6b8925ec-2e33-45d5-b04f-04f947d26737. Request und alle Ziele sind durch normalisierte
SHA-256 gebunden; die Einzelnotizen stehen ebenfalls im JSON-Ergebnis.

Die beiden IR001-Referenzbefunde sind erledigt; ihre neuen Einzelreviews sind
Ready. Vier Completed-Mitglieder liegen bytegleich im Archiv. Die Serie
behaelt 13 Mitglieder, vier Wurzeln und neun Abhaengigkeiten; neun Mitglieder
liegen aktiv vor. Genau die bereits bevorzugte Funktionsabnahme ist Eligible.
Das ist eine Prioritaetsmarkierung und startet keinen Produktlauf.

## Neue Befunde / New findings

- **IR002, Medium – Kommentarhaertung:** Vorkenntnisse und Erstgebrauchs-
  erklaerungen fuer Formula/Recalc/Textoverflow/XML/DocFX fehlen; die
  normativen Kommentarregeln besitzen keine ausreichende englische Entsprechung.
- **IR003, Medium – Secure-Development-Hardening:** Vorkenntnisse und
  Einfuehrungen zu MSL, Vertrauensgrenzen und Lieferkettenbegriffen fehlen.
  Die normativen Abschnitte 1-9 sind nur deutsch ausgefuehrt.
- **IR004, Medium – Sandbox-Haertung:** Vorkenntnisse und Erklaerungen zu
  Mounts, Tokens, Caches und SBOM fehlen. Die detaillierten Anforderungen
  und Abnahmekriterien besitzen keine entsprechende englische Fassung.

Owner fuer alle drei: Thorsten Hindermann. Korrektur und Wiedervorlage vor
Ausfuehrung der betroffenen Intakes. Diese zusaetzlichen Inhaltsaenderungen
gehoeren nicht zur beauftragten IR001-/Lifecycle-Reparatur. Bestehende Inhalte
bleiben erhalten; keine Risiken wurden durch den Agenten akzeptiert.

*The two original IR001 findings are resolved and both Single reviews are
Ready. Four completed targets are preserved byte-for-byte in archive; nine
remain active, with one preferred Eligible target. The full series has three
new Medium learner-clarity findings: explicit prerequisites, first-use terms
and English normative coverage are missing in the comment, secure-development
and sandbox hardening intakes. Thorsten owns correction and reevaluation
before their execution. No risk is accepted and no product run is started.*

## Individuelle Pruefnotizen / Individual review notes

Die Notizen benennen fuer jedes Ziel Zweck, Abgrenzung und wesentliche
Pruefgrenze. Historische Completed-Ziele bleiben unveraenderte Evidence;
ihre alten Prompts oder Versionsangaben sind keine aktuelle Startfreigabe.
*Each note records purpose, boundaries and the main review conclusion.
Completed targets remain historical evidence, not current execution prompts.*

| Position | Lifecycle | Review note |
|---:|---|---|
| 1 | Completed | Historische Constitution-, XML- und TDD-Anforderungen bleiben abgeschlossene Evidence. / Constitution: historical bilingual/XML/TDD requirements preserved as completed evidence; old prompts and original wording are not executable instructions. |
| 2 | Completed | Abgeschlossene Migration; spaetere Intakes verwenden aktuelle Pins statt historischer Versionsvorgaben. / Terminal.Gui: historical migration version/API snapshots preserved; current successor intakes use execution-time pins and do not repeat migration. |
| 3 | Eligible | Vollstaendiger Produktvertrag, messbare Abnahme und reparierte fachliche Referenzen. / TUI acceptance: complete offered capability union, immutable contract IDs, measurable success/cancel/error coverage and impact gates; repaired semantic references. |
| 4 | Blocked | Tastatur, Text, Fokus und PTY/VoiceOver; folgt Funktionsabnahme und geht Rename voraus. / A11Y: keyboard/text/focus, PTY/VoiceOver and DocFX evidence are explicit; functional acceptance precedes this work and rename follows it. |
| 5 | Blocked | Atomarer Rename, Live-Inventar, historische Allowlist und JSON-Kompatibilitaet. / Rename: live inventory, atomic project identities, historical allowlist and JSON compatibility preserved; repaired functional/A11Y references. |
| 6 | Blocked | Keine Runtime-Aenderung; begrenzte Warum-Kommentare. Lernenden-Befund IR002 bleibt offen. / Didactic comments: runtime changes excluded, moderate why-comments and explicit dispositions; learner prerequisites and terminology need repair (IR002). |
| 7 | Blocked | Spaeterer begrenzter Sicherheitsreview mit Evidenzpflicht. Lernenden-Befund IR003 bleibt offen. / Secure development: bounded later applicability/evidence review, explicit risk and human authority boundaries; prerequisites and bilingual normative coverage need repair (IR003). |
| 8 | Blocked | Reine begrenzte Ganzzahl-VM; Paket-Integration bleibt vor Ausfuehrung zu pruefen. / PL/0: qualified pure integer functions, strict profile and bounded VM; package delivery evidence is dated, integration pin/locked restore/contract tests remain execution prerequisites. |
| 9 | Blocked | Zwei MCS-Dialekte, atomarer Import, authentische Fixtures; JSON bleibt Schreibformat. / Legacy: two evidenced MCS dialects, bounded atomic import, compiler-authentic fixtures, BCD excluded, JSON canonical and later structural operations separate. |
| 10 | Blocked | Snapshot und AST, sichere Vorschau, vollstaendige Zellrecords und atomarer Rollback. / Formula copy: immutable snapshot/AST reference changes, complete records for structural shifts, REF errors, previews, confirmation and atomic rollback. |
| 11 | Pending | Mount-, Schreib- und Token-Grenzen; keine Image-Aenderung. Lernenden-Befund IR004 bleibt offen. / Sandbox: mount/write/token boundaries and applicability evidence, no image mutation or automatic hardening; learner prerequisites and terminology need repair (IR004). |
| 12 | Completed | Abgeschlossene Selbstpruefung mit Evidenzklassen und menschlichen Entscheidungsgrenzen. / RL-SE: completed evidence classification and human-only boundaries retained; archived bytes are not rewritten to current learner templates. |
| 13 | Completed | Abgeschlossene GSDB-Pruefung; kein Ersatz fuer die ausstehende Produktabnahme. / GSDB: completed intensive-review scope and evidence/human-only boundaries retained; not a substitute for pending product acceptance. |

## Naechste Aktion / Next action

IR002-IR004 in einem gezielten Intake-Update korrigieren, danach dieselbe
Gesamtserie erneut reviewen. Ready wird nicht aus bestandenen technischen
Validatoren abgeleitet. Insbesondere PL/0 behaelt den offenen Integrations-
Preflight, und historische Governance-Abnahmen ersetzen keine Produktabnahme.
*Correct IR002-IR004 in a scoped update, then repeat the full-series review.
Passing validators do not imply semantic Ready; product gates remain separate.*
