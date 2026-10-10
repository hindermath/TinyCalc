# TUI-Vertragsdaten / TUI contract data

## Deutscher Leitfaden

Der [vollständige lesbare Katalog](catalog.md) enthält 1.092 einzeln aufgeführte
Pflichttupel: je 364 auf Linux, Windows und macOS. Er ist aus dem Vertrag
abgeleitet, keine Liste bestandener Tests. `render-tui-contract-catalog.ps1
-CheckOnly` und der read-only Validator erkennen Katalogdrift. HumanVoiceOver
und verlinkte A11Y-Pflichten ergänzen die Automation, ersetzen sie aber nicht.

`history.json` bindet die vorherige Revision unveränderlich an einen vorhandenen
Git-Commit und Vertragsdigest. Der Validator liest diesen Blob, ohne Fetch oder
Checkout. Deprecation bleibt regressionspflichtig; nur ausdrücklich genehmigte
Stilllegung erlaubt einen Tombstone außerhalb des aktiven Nenners. IDs, Aliase
und Kontext werden nie für andere Funktionen recycelt. Neue Anforderungen
erhalten additive IDs und zunächst rote fachliche Tests vor Produktcode.

Für neue Anforderungen bindet `history.json:additions` den genauen roten TRX-Fall,
die Testquelle `testSourceRef` mit SHA-256, den Red-Commit, den späteren
Implementierungscommit und die Produktpfade. Testquelle und rotes TRX müssen
bereits als identische Git-Blobs im Red-Commit vorliegen. Testcode muss gegenüber
der Vertragsbasis geändert sein, Produktpfade dagegen noch nicht. Erst der
nachfolgende Implementierungscommit darf sie ändern. Fremde rote Protokolle,
gleiche Testnamen allein oder selbst behauptetes `proofVerified` reichen nicht.
Der Validator liest Git lokal, ohne Checkout, Fetch oder Git-Schreiboperationen.

Pinfreigabe und Vergleich sind separate, gehashte Dokumente. Sie bestätigen nur
den zuvor genehmigten und tatsächlich geprüften Paketgraphen, keine Produktabnahme
und keinen neuen Restore. Fehlende/unfreigegebene Quellen sperren; ungültiger oder
fehlender Vergleich verlangt Drift-Nachweise. Impact-Gates werden aus der festen
Spec-Matrix abgeleitet, nicht aus einer vom Aufrufer verkürzten Gateliste.

`baseline-inventory.json` wurde vor Produktänderungen aus der Vereinigungsmenge
der fünf angebotstragenden Quellen und den geklärten Spec-Orakeln erstellt.
Es ist der unabhängige Pflichtnenner, nicht aus Testergebnissen erzeugt.
`source-map.json` hält Quellenanker, Hashes, Dokumentationsdefekte und die
Entscheidungen RQ-001–RQ-003 getrennt. Noch existierende Textdefekte sind kein
Nachweis ihrer Behebung. Aktive Angebote bleiben Pflicht; IDs werden nie
wiederverwendet, entfernte IDs bleiben als Tombstones mit genehmigter Authority.

Die `*.schema.json` beschreiben strikt die Entitäten und ihre Quellenbindungen.
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

New requirements bind the exact failing TRX test, SHA-256 test source, red commit,
later implementation commit and product paths. Test source and failed TRX must
already exist as identical blobs in the red commit. Test code must differ from
the previous contract baseline while product paths remain unchanged until the
implementation. Foreign logs, matching names alone or self-claimed verification
are insufficient. Only local read-only Git operations are used.

The [complete readable catalogue](catalog.md) lists 1,092 obligation tuples:
364 each on Linux, Windows and macOS. It is derived, not a list of passed tests.
The renderer's CheckOnly mode and validator detect drift. Human VoiceOver and
linked accessibility proof supplement rather than replace automation.

History binds the previous contract to an existing immutable Git commit and
digest; reading it never fetches or checks out files. Deprecation keeps regression,
and authorised retirement preserves tombstones. Never recycle IDs, aliases or
contexts. New requirements need additive IDs and genuine red tests before code.

Hashed pin approval and comparison bind the previously approved, tested package
graph, not product acceptance or a newly performed restore. Missing sources block;
missing/invalid comparison requires drift proof. Required impact gates are derived
from the specification, not trusted from a potentially shortened caller list.

The independent baseline was authored from all five offered source surfaces
and clarified specification oracles before product edits, not from test results.
The source map keeps substantive offers, documentation defects and decisions
separate. Existing defects are not claimed fixed. IDs remain additive and are
never reused; retirement needs explicit authority and retained tombstones.

Strict entity and binding schemas reject unknown versions and properties. Structural
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
