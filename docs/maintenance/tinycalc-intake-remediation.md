# TinyCalc Intake-Korrektur / Intake remediation

- Datum / date: 2026-09-13
- Owner: Thorsten Hindermann
- Auftrag: IR001-Referenzen berichtigen, Lifecycle konsistent archivieren,
  betroffene Receipts nachziehen und gesamte Serie reviewen.
- Lieferung / delivery: MergeAndSync mit / with Admin-Bypass.

## Ergebnis / Result

Die beiden IR001-Befunde sind behoben. Funktionsmatrix und A11Y-Gates werden
ueber die bestehenden fachlichen Intake-Namen gebunden, nicht ueber die
anderweitig belegten Nummern 004 und 005. Die beiden neuen Einzelreviews
sind Ready. A11Y und PL/0 erhalten wegen ihrer Quellbindung ebenfalls neue
Receipts; ihre Intake-Inhalte bleiben unveraendert.

Alle vier bereits Completed markierten Mitglieder (Constitution, Terminal.Gui,
RL-SE und GSDB) liegen mit gleichem Dateinamen und identischen Bytes im Archiv.
Ihre historischen Receipts bleiben unveraendert und werden ueber eindeutige
Manifest-/Namens-/Hash-Nachfolger aufgeloest. 13 Mitglieder, vier Wurzeln und
neun Abhaengigkeiten bleiben erhalten. Neun Intakes liegen aktiv vor; die im
Pflichtenheft bereits bevorzugte Funktionsabnahme ist jetzt explizit Eligible.

Die Gesamtserienreview ist durchgefuehrt: **NeedsRemediation**, drei neue
Medium-Befunde IR002-IR004 zur Lernenden-Verstaendlichkeit in Kommentar-,
Secure-Development- und Sandbox-Haertung. Critical/High/Low jeweils 0;
keine akzeptierten Risiken, keine offenen Rueckfragen, keine Produktausfuehrung.
Die zusaetzlichen Inhaltskorrekturen gehoeren zu einer getrennten Folgearbeit.

*Both IR001 references are repaired and the new Single reviews are Ready.
Four completed targets moved byte-for-byte to archive; historical receipts
resolve through unique manifest/name/hash successors. Four receipt successors
preserve lineage, including the two causally affected A11Y/PL0 source bindings.
Thirteen members, four roots and nine edges remain; nine targets are active
and the already preferred functional acceptance is explicitly Eligible.
The full Series review is NeedsRemediation for three new Medium learner-clarity
findings. No risks are accepted and no product run has started.*

## Hilfsskripte und Nachweis / Helper scripts and proof

Der lokale Alignment-Validator trennt aktive Mitglieder und archivierte
Vorgaenger. Er lehnt falsche Ablage, unbekannte Zustaende, fehlende oder
mehrdeutige Archivnachfolger und falsche Hash-/Serienbindungen ab. Der
Renderer liest die kanonische Serie und schreibt ausschliesslich die beiden
Reihenfolgeansichten; die alte fest eincodierte Manifest-/Receipt-Erzeugung
entfaellt. Archivierte Feature-Verknuepfungen benoetigen eine hashgebundene
Vorgaengerserie und unveraenderten Inhalt. Keine installierten Presets geaendert.

*The alignment validator separates active members from archived predecessors.
It rejects inconsistent lifecycle placement and invalid archive identity.
The renderer derives only the two order views from the canonical manifest;
it no longer recreates historical manifests or receipts. Archive feature
links require hash-bound predecessor evidence and unchanged content. Installed
preset packages are unchanged.*

Pruefpfad / validation path:

1. Bash: `bash scripts/validate-requirements-intake-alignment.sh`.
2. PowerShell: `pwsh -NoProfile -File scripts/validate-requirements-intake-alignment.ps1`.
3. `node scripts/tests/requirements-intake-alignment-tests.mjs`: 10 bestehende,
   26 verlinkte und 15 neue Lifecycle-/Archiv-/Renderer-Prueffaelle.
4. Vier neue Operationen und zwei Single-Reviews separat in beiden Shells;
   Konfiguration: 13 gesamt, neun aktiv, vier archiviert, ein Eligible.
5. Bytegleiche Archive, erhaltene alte Receipts/Review-Nachweise, lesende
   Validatoren und frischer Checkout vor/nach Lieferung.

Die alten Skripte scheiterten am vorbereiteten korrekten Archivbestand
(13 aktive statt neun erwartet; Renderer las entfernte aktive Pfade).
Nach der Korrektur bestehen diese Regressionen. Produkt-TDD, Changed-Code-
Coverage des Produkts und manuelles VoiceOver sind hier N/A: kein Produktcode,
keine TUI- oder DocFX-Aenderung; Wiedervorlage bei deren naechster Aenderung.
Die Hilfsskripte besitzen eigene positive/negative Regressionstests.

*The old scripts failed against the corrected archive layout. The updated
scripts pass the regression cases. Product TDD, product changed-code coverage
and manual VoiceOver are N/A because this changes neither product code, TUI
nor DocFX; reevaluate when those surfaces change. Helper logic has dedicated
positive and negative regression coverage.*

## Evidence und Dokumentation / Evidence and documentation

- [Vorschlag und Autorisierung](tinycalc-intake-remediation-proposal.json)
- [Identitaeten, Archive und Validierung](tinycalc-intake-remediation.json)
- [Gesamtserienreview](../../requirements/intakes/series/tinycalc-delivery/intake-review-report.md)
- [Ersetzte Review-Bindungen](../../specs/intake-review-remediation/20260913/superseded-reviews.json)

Documentation Impact: UpdateRequired fuer Inhalt, Betriebsbeschreibung und
Nachweise; GeneratedUpdate fuer Reihenfolgeansichten und Statistik aus deren
kanonischen Quellen. Leser: Maintainer, Lernende und Agenten. Leserpfad:
Pflichtenheft → Serienansicht → Review → gezielte Folgekorrektur. Kanonische
Quellen: Serienmanifest, Intakes, Receipts und Review-Ergebnisse; Owner Thorsten.
Dokumentklasse: Wartungs-/Review-Nachweis; DE/EN in denselben Dateien,
textorientiert nach CEFR B2. Distribution: sourceOnly, kein Home-Sync.
Plattformnachweise: macOS Bash zuerst, PowerShell danach; native CI an PR-Head.
Re-Evaluation: nach Intake-Aenderung oder vor Ausfuehrung. Keine Manpage fuer
neue Skripte erforderlich: ausschliesslich bestehende lokale Node-Helfer
angepasst; CLI-Hilfe und dieser Betriebsnachweis sind synchron aktualisiert.

*Documentation impact is UpdateRequired for the correction and operating
evidence, GeneratedUpdate for order views and statistics. Reader path:
requirements index → series view → review → scoped correction. Canonical
sources are the manifest, intakes, receipts and results; Thorsten owns them.
This bilingual, text-first maintenance evidence is sourceOnly and requires
no home sync. Reevaluate after intake changes or before execution. Existing
Node helper help and this operating record are updated together.*
