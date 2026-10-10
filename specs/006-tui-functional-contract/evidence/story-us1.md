# US1: lokale vollständige Tabellenwege / Complete local spreadsheet paths

## Vollständiger nativer Abschluss / Complete native closeout

11.10.2026: Die [unveränderte Prüfserie 737348d](delivery-closeout.md) belegt
alle 264 US1-Pfade separat auf macOS, Linux und Windows, insgesamt 792 Tupel.
Jeder vollständige ungefilterte Lauf enthält die echten sichtbaren Zustände,
Core-Orakel und unabhängigen Assertions. [Menschliche Abnahme](human-acceptance-20261011.md)
ist ergänzend erfolgt. Die folgenden lokalen Zwischenstände sind historisch;
finale Lieferhead-Bindung wird gesondert im Runtime-Nachweis erfasst.

*All 264 US1 paths pass in each full native run, 792 tuples overall, on the
immutable candidate. Visible state, independent oracles and human acceptance
are retained; final delivery-head binding remains separately required.*

## Deutscher Nachweis

Der [ungefilterte lokale Vollvertrag](platforms/macos/local-build105.md) enthält
alle 264 US1-Pfade: APP 5, GRID 6, NAV-UP 4, NAV-DOWN 6, NAV-RIGHT 10,
NAV-LEFT 6, EDIT 116, CELL 13, OP 14, REF 6, FUNC-LEGACY 37, FUNC-EXT 41.
Jeder Pfad erhält unabhängige Assertions, tatsächliche UI-Eingaben und
sichtbaren Zustandsbeleg. Zahlenorakel und Toleranzen stammen aus dem vorab
gebundenen Vertrag, nicht aus einer nachgebauten Test-Fachlogik.

[Test-first US1](red-green/us1.md) und weitere Protokolle unter `red-green/`
halten echte Defekte von Infrastrukturkorrekturen getrennt. Die Session-
Extraktion ersetzt keine Formelkorrektur und kein Orakel. Alle Alias-/Rand- und
Editorzeichenfälle bleiben eigene Pfade; Slash im Raster ist kein Editor-Slash.

Dies ist vollständige lokale macOS-Abdeckung, kein gemeinsamer finaler
Linux-/Windows-/macOS-Abnahmekopf. T032 bleibt bis zur vollständigen geforderten
Plattform-/Versionsbindung offen. Historische Filterläufe werden nicht als
Storyvollabnahme ausgegeben. Menschliche A11Y bleibt ergänzend verpflichtend.

## English evidence

The unfiltered actual macOS run contains all 264 US1 paths, broken down above.
Each path uses real UI inputs, visible state and independent approved oracles
and tolerances. Test-first records distinguish genuine defects from infrastructure
issues. Aliases, boundaries, editor characters and contextual slash behaviour
retain separate obligations. This is complete local coverage, not one final
three-platform acceptance head. T032 and human accessibility remain Open until
their required bindings are complete; filtered historical slices are not relabelled.
