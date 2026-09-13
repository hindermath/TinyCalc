## Summary / Zusammenfassung

Die beiden Intake-Verweise auf Feature 004/005 zeigten auf andere fachliche
Aufgaben, und vier abgeschlossene Serienmitglieder lagen weiterhin unter
`active`. Die Korrektur bindet Funktionsmatrix und A11Y-Gates ueber ihre
Intake-Namen, archiviert die vier Completed-Mitglieder bytegleich und erneuert
vier betroffene Receipts mit erhaltenen Vorgaengern. Die lokale Renderer- und
Alignment-Logik verarbeitet diesen Lifecycle jetzt ohne alte Manifest- oder
Receipt-Werte wiederherzustellen.

*Repair two stale feature references and archive four completed series members
without changing their bytes. Four affected receipts retain predecessor
evidence. Local alignment and rendering now follow the canonical lifecycle
without recreating old manifests or receipts.*

## Scope / Umfang

- [x] Tests: bestehende Node-Vertragstests erweitert / existing Node contract tests extended
- [x] Docs: Intakes, Manifest, Receipts, Reviews und Statistik / intake and delivery evidence
- Produktcode, Pakete und CI-Konfiguration unveraendert / product code, packages and CI unchanged

## Solution / Loesung

13 Mitglieder, vier Wurzeln und neun Kanten bleiben erhalten; vier Mitglieder
liegen archiviert, neun aktiv vor. Die im Pflichtenheft bevorzugte
Funktionsabnahme ist explizit Eligible. Alte Feature-Verknuepfungen bleiben
ueber den hashgebundenen Vorgaengermanifest-Nachweis erhalten.

Die zwei gezielten Einzelreviews sind Ready. Die vollstaendige Serienreview
ist NeedsRemediation: drei neue Medium-Befunde IR002-IR004 betreffen
Vorkenntnisse, Begriffserklaerungen und englische normative Texte in den
Kommentar-, Secure-Development- und Sandbox-Haertungsintakes. Keine Risiken
akzeptiert, keine Produktausfuehrung. Neue Befunde sind dokumentierte Folgearbeit.

*The series retains its identities and graph, with four archived and nine
active members. The existing preferred intake is explicitly Eligible. Two
Single reviews are Ready; the full Series review truthfully records three
new Medium learner-clarity findings. No risk acceptance or product execution.*

## Test Plan / Pruefung

- [x] Bash-Alignment einschliesslich 13 Receipts, Manifest und Serienreview
- [x] PowerShell-Paritaet derselben Pruefungen
- [x] 10 bestehende, 26 verlinkte und 15 neue Lifecycle-/Archiv-/Renderer-Faelle
- [x] Vier neue Operationsjournale und zwei Single-Reviews in beiden Shells
- [x] Bytegleiche Archive, unveraenderte historische Evidence und lesende Validatoren
- [x] Statistik: Vorschau, Bash-Rendering, PowerShell-Check
- Native PR-CI und frischer Checkout werden an den gelieferten Commit gebunden.
- Lokale Produkt-Builds, manuelle TUI-/VoiceOver- und DocFX-Laeufe: N/A,
  da keine dieser Produktflaechen geaendert wurde; bei naechster Aenderung neu pruefen.

*Validation covers paired shell gates, 51 fixture cases, operation/review
bindings, immutable archives, read-only validators and generated statistics.
Native CI and fresh-checkout evidence bind delivery. Local product/TUI/DocFX
runs are N/A for unchanged product surfaces; reevaluate on their next change.*

## Risks / Risiken

Falsche Archivaufloesung oder veraltete Feature-Links werden durch positive
und negative Hash-/Identitaets-/Serientests abgesichert. Die drei neuen
Lernendenbefunde bleiben vor Ausfuehrung ihrer Intakes offen. Admin-Bypass
betrifft die aktuell autorisierte Lieferung und ersetzt keine technische
Pruefung oder fachliche Risikoakzeptanz.

*Archive resolution and feature links have identity/hash/series regression
coverage. Three learner-clarity findings remain open before those intakes run.
Current admin delivery authority does not replace technical evidence or
human risk acceptance.*

## Documentation / Dokumentation

UpdateRequired fuer Intakes, Betriebsbeschreibung und Review-Evidence;
GeneratedUpdate fuer abgeleitete Reihenfolgeansichten und Statistik.
Kanonische Quellen, Owner, Leserpfad, Sprachpartner und Re-Evaluation stehen
im [Wartungsnachweis](maintenance/tinycalc-intake-remediation.md).
Source-only; kein Home-Sync. Keine sichtbare TUI-Aenderung, daher keine Screenshots.

*Documentation decisions and reader paths are recorded in the maintenance
evidence. Source-only; no home sync or UI screenshots required.*
