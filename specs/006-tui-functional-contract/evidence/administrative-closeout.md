# Feature 006: administrativer Abschluss / Administrative closeout

## Deutsch

Thorsten genehmigt Intake-Archivierung, Serienfortschreibung und die enge
Erneuerung der README-Quellbindungen von TUI und Rename sowie der AGENTS.md-
Quellbindung von PL/0. Lieferung:
MergeAndSync; Admin-Bypass nur für formale Regeln. Kein Folgefeature.
Produktlieferung: [PR #104](https://github.com/hindermath/TinyCalc/pull/104),
geprüfter Head 6a86182d86c6b80d29029eac8e1f71f344a6b261, Merge
946e392151fcaba5db0d76cf2974e055ba616e66.
Der [finale Nachweis](https://github.com/hindermath/TinyCalc/pull/104#issuecomment-6103024807)
belegt T076/T078/T079/T081. T082 wird durch diesen separat genehmigten
Verwaltungsabschluss vollzogen; die vorherige bedingte Prüfung bleibt historisch.

Das [Intake](../../../requirements/intakes/archive/Lastenheft_TUI-Funktionsabnahme-und-Regressionsvertrag.md) wird bytegleich verschoben, nicht fachlich
geändert oder gelöscht. Die vorherigen Intakes, Receipts, Serienmanifest,
Serienreceipt und Reviewdateien bleiben bytegleich archiviert. Neue Receipt-
Identitäten erhalten dieselben Intake-Identitäten. Die ursprünglichen Prompts
und der ehemalige aktive Pfad bleiben als historische Bindung erhalten; der
installierte Resolver prüft den eindeutigen abgeschlossenen Archivnachfolger.

Serie: 13 Mitglieder, 4 Roots und 9 harte Kanten unverändert. Aktive Mitglieder
9 -> 8; abgeschlossene Mitglieder 4 -> 5. Position 3 TUI wird Completed,
Position 4 A11Y wird Eligible, aber nicht gestartet oder abgenommen.
Der frühere Serienreview ist ausdrücklich supersediert. Ein neuer Intake Review
ist ausstehend und wird nicht als bestanden erfunden. Vor einem Folgefeature
ist er separat auszuführen. Keine automatische Auswahl oder Ausführung.

Sicherheitsbasis: NIST SSDF/CWE Top 25, begrenzte Datei-I/O und Hash-/Lineage-
Prüfung. Produktcode, Tests, Pakete und Laufzeit unverändert. TDD/Coverage,
neue SBOM/VEX, ASVS, Produkt-AI-SBOM und Zero Trust: für diese reine
Verwaltungsänderung N/A; bestehende Produktnachweise bleiben historisch gebunden.
SLSA: nachvollziehbare Git-/CI-Herkunft, keine signierte Attestation behauptet.
WCAG 2.2 AA soweit anwendbar: bilinguale Textstruktur, echte Links und
textorientierte HTML-Prüfung. Keine erneute menschliche Produktabnahme behauptet.
Mermaid N/A: diese kurze Statusfortschreibung enthält keinen neuen Ablauf.

## English

Thorsten explicitly authorised archival, series progression and bounded renewal
of both README source bindings and the PL/0 AGENTS.md binding. Delivery is MergeAndSync with formal-only admin
bypass. No follow-up feature starts. PR #104 and its final provider comment bind
the completed product and execution tasks. This separately approved operation
implements conditional T082 without relabelling historical product evidence.

The intake content is unchanged. Byte-identical predecessors and source inventories
are archived; intake IDs remain stable while receipts receive new identities.
Historical prompts retain their original active path and resolve uniquely through
the configured completed archive successor. The series retains 13 members,
four roots and nine hard edges: five completed, eight active. A11Y is eligible,
not started or accepted. The old review is superseded and a new review remains
pending; this maintenance action does not run it or grant downstream authority.

SSDF/CWE and bounded file/hash operations apply. Product sources, packages and
runtime remain unchanged. New product testing, coverage, SBOM/VEX, ASVS,
product AI-SBOM and Zero Trust are N/A for this administrative delta; existing
evidence keeps its original source binding. Git/CI provenance is not a signed
SLSA attestation. German-first text and meaningful links support accessible
documentation, with text-oriented HTML checks. No human acceptance is invented.
No new workflow is introduced, so a Mermaid diagram is unnecessary here.
