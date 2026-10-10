# TUI-Vertragsdaten / TUI contract data

## Deutscher Leitfaden

`baseline-inventory.json` wurde vor Produktänderungen aus der Vereinigungsmenge
der fünf angebotstragenden Quellen und den geklärten Spec-Orakeln erstellt.
Es ist der unabhängige Pflichtnenner, nicht aus Testergebnissen erzeugt.
`source-map.json` hält Quellenanker, Hashes, Dokumentationsdefekte und die
Entscheidungen RQ-001–RQ-003 getrennt. Noch existierende Textdefekte sind kein
Nachweis ihrer Behebung. Aktive Angebote bleiben Pflicht; IDs werden nie
wiederverwendet, entfernte IDs bleiben als Tombstones mit genehmigter Authority.

Die zehn `*.schema.json` beschreiben strikt die Entitäten aus dem Datenmodell.
Zusätzliche Felder und unbekannte Schema-Versionen werden abgelehnt.
Schema-Erfolg ersetzt weder Quell-, Referenz- und Digestprüfung noch tatsächliche
Testausführung. Plattformen werden einzeln gezählt. Ein Arbeitsbaumdigest
bezeichnet ausschließlich einen lokalen Zwischenstand, keine finale Lieferung.

Digestregel: JSON-Objektschlüssel rekursiv ordinal sortieren, Array-Reihenfolge
bewahren, kompakt serialisieren, Strings mit JSON-Escapes für Steuerzeichen und
sonst unverändertem Unicode kodieren. Numerische JSON-Lexeme bleiben erhalten
(z. B. `1` und `1.0` sind verschiedene Bytes); keine Rundung großer Zahlen.
UTF-8 ohne BOM, genau ein abschließendes LF. Ein Decision-/Payload-Digest wird
ohne sein eigenes **Wurzel**-Digestfeld gebildet; gleichnamige Unterfelder bleiben.
Doppelte Schlüssel sind ungültig, auch das ausgeschlossene Feld darf nicht
doppelt vorkommen. Das ist ein lokaler Bytevertrag, keine RFC-8785-Behauptung.
Quell- und Datei-Artefakthashes außerhalb der JSON-Digests verwenden die exakten
Dateibytes, damit auch historische CRLF-/Steuerzeichen-Ressourcen gebunden bleiben.

Der read-only Helfer `scripts/lib/tui-contract/CanonicalJson.ps1` implementiert
diese Regel. Er startet keine Produkt-/Providerbefehle und schreibt keine Datei.
Die vollständige Abnahme wartet weiterhin auf echte, vollständige Resultate,
native Plattformnachweise, menschliches A11Y und unabhängiges Review.

## English guide

The independent baseline was authored from all five offered source surfaces
and clarified specification oracles before product edits, not from test results.
The source map keeps substantive offers, documentation defects and decisions
separate. Existing defects are not claimed fixed. IDs remain additive and are
never reused; retirement needs explicit authority and retained tombstones.

The ten strict schemas reject unknown versions and properties. Structural
validity is not evidence of source coherence or test execution. Count each
platform separately. A working-tree digest identifies local intermediate proof,
not final delivery.

Canonical JSON recursively sorts object keys ordinally, preserves array order
and numeric token spelling, uses compact JSON with control-character escapes
and otherwise unchanged Unicode, UTF-8 without BOM and one terminal LF. Exclude
only the named root self-digest property; nested names remain. Reject duplicate
keys before exclusion. This explicit local byte protocol does not claim RFC 8785
conformance. Other source/artifact hashes bind exact file bytes, preserving
historical CRLF and control-character resources. The shared read-only helper
never writes files or invokes product/provider commands. Full acceptance still
requires complete genuine results, native platforms, human accessibility and
independent review.
