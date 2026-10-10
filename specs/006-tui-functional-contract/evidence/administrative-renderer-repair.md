# Verwaltungsrenderer: begrenzte Korrektur / Bounded administrative renderer repair

## Deutsch

Thorsten hat am 11.10.2026 die enge Erweiterung auf Renderer, Regressionstest,
generierte Tabellen und zugehoerige Nachweise ausdruecklich genehmigt.
PR #105 bleibt derselbe Verwaltungsabschluss; kein Folgefeature wird gestartet.
NIST SSDF und CWE Top 25 gelten fuer die Datei-/Identitaetsgrenze.

Das unabhaengige Review fand eine falsche Zuordnung: T065 erwaehnt das
A11Y-Intake als Pruefkontext. Der portable direkte TUI-Intake-Beleg wurde deshalb
auch diesem noch nicht gestarteten Intake zugeordnet. Der neue ausfuehrbare
Node-Test reproduzierte vor der Korrektur genau diesen Fehler mit
`RED: contextual intake mention received another intake's portable feature proof`.

Direkte Intake-Belege ausserhalb ihres Feature-Verzeichnisses muessen jetzt einen
der bereits validierten Intake-/Archiv-Lineage-Pfade und den exakten Zielhash
binden. Eine fremde Identitaet wird nicht zugeordnet, auch bei identischem Inhalt.
Unsichere relative Pfade und falsche Beleginhalte bleiben Fehler.
Die gezielten Tests bestehen nach der Korrektur: korrekte Bindung, Kontext ohne
Zuordnung, Hashabweichung abgewiesen und bytegleiches fremdes Intake ohne Zuordnung.
Auch die bestehende Matrix mit zehn Legacy- und 26 Linked-Faellen besteht.
Beide Tabellen zeigen Feature 006 nur beim TUI-Intake; A11Y bleibt Eligible.

Die historische featurelokale PreMerge-Snapshot-Strategie, insbesondere Feature
005, bleibt unveraendert. Ihre Markdown-Kontextpruefung wird damit nicht zu einer
allgemeinen Identitaetsgarantie aufgewertet. Dieser Fix behauptet keine Migration
oder vollstaendige Haertung aller historischen Belegformate. Produktcode,
Pakete, Laufzeit und menschliche Abnahme bleiben unveraendert. Native finale
CI-, Review- und Merge-/Sync-Nachweise werden am tatsaechlichen PR-Head erfasst.

## English

Thorsten explicitly approved this bounded renderer, regression, generated-view
and evidence repair on 11 October 2026. It remains part of PR #105, not a new
feature. SSDF/CWE apply to the file and identity boundary.

The independent review found that an A11Y context mention in T065 incorrectly
received the direct TUI intake proof. The new executable Node regression failed
with that exact business error before the correction. Direct intake proofs now
require a validated accepted path and the exact target hash. Context mentions
and identical bytes at a foreign intake path do not establish identity.

The focused identity/context/hash tests and the existing ten legacy and 26
linked cases pass. Both generated views retain Feature 006 only for TUI, while
A11Y remains eligible and unstarted. Historical feature-local PreMerge snapshot
handling is unchanged; this repair does not claim that its Markdown context
check provides a general identity guarantee or that every legacy proof format
was migrated. Product code, packages, runtime and human acceptance are unchanged.
Final native CI, review and delivery evidence is recorded against the real head.
