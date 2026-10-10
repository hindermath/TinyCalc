# US4: dauerhafte Schutzgrenzen / Permanent safeguards

## Deutscher Nachweis

Stand 2026-10-10. Dies implementiert künftige Schutzgrenzen innerhalb von
Feature 006; kein Folgefeature oder Paketupgrade wird gestartet.
[Policy-Checkpoint](validator-policy-checkpoint.md) bindet das ursprüngliche
Rot–Grün: 44/50 explizite Ablehnungsassertions rot, danach ursprüngliche Fälle
und additive Guards grün. Der aktuelle gezielte Lauf umfasst 58 Pass/0 Fail.

- Pinzustände: AlreadySatisfied braucht Graph, ursprüngliche Freigabe und
  überprüften Vergleich; Drift erzwingt volle Zusatzgates; Blocked erlaubt
  weder Produktarbeit noch automatische Upgrades.
- Impact: NoFunctionalImpact, FunctionalImpact, A11yImpact,
  TestInfrastructureImpact und ReleaseCloseout sind getrennt geprüft.
  Unbekannte Wirkung verlangt konservativ Funktion plus A11Y.
- Historie: Deprecation behält Regression; autorisierte Stilllegung behält
  Tombstones. Recycling, fehlende IDs, stille Plattform-/Oracle-Schwächung und
  unautorisierte Entfernung werden abgelehnt.
- Neue Anforderung: eindeutige ID und genau ein intern überprüfter Test-first-
  Beleg. Strikte Schemas akzeptieren keine selbstbehauptete proofVerified-
  Freigabe. Hashgeprüfte Testquelle und rotes TRX müssen bereits identische
  Git-Blobs im roten Commit sein. Testquelle muss seit Baseline geändert sein;
  betroffene Produktpfade dürfen bis Rot nicht geändert sein und müssen danach
  im nachfolgenden Implementierungscommit geändert sein. Beide Commits liegen
  in der lokalen HEAD-Abstammung. Keine Fetch-/Checkout-/Provideraktion.
- Workflow: jeder PR/Push, native Linux/Windows-Matrix, ungefilterte Vollsuite,
  Collector und fehlersensitiver Upload. Fünf Abschwächungen werden verworfen;
  grüner Workflow-Guard ist kein durchgeführter nativer CI-Produktlauf.

Die neue Historienintegration verwendet ein eigenes temporäres synthetisches
Git-Repository, nie die Produkt-Arbeitskopie. Zehn Ablehnungsassertions waren
am isolierten permissiven Stub rot; anschließend 11/11 grün. Geprüft sind
geordnete Positivkette, gleicher/umgekehrter/fremder Commit, falsche Klasse,
unveränderte Testquelle, vorgezogene/fehlende Produktänderung, Traversal und
veränderte beziehungsweise grüne Rot-Datei/Quelle. Synthetisches rotes TRX
ist ausschließlich Fixture-Daten, keine echte Anforderungs- oder Produktprüfung.
Der produktive Validator ruft exakt dieselbe geprüfte Historienfunktion nach
Schema-/Artefakthashprüfung auf. Semantische Testqualität bleibt Reviewpflicht.

| Ignoriertes Original | SHA-256 |
|---|---|
| 006-addition-provenance-red.log | b6243b3346600318e1b5a97392d5539104d13966000e6c89893f92e152126cdd |
| 006-addition-provenance-green.log | b75f27d8b6817019633760be04f87a2138ece22851ec9d3bffe5a2b6b0da03f6 |
| 006-policy-closeout.log | c800774879e59c466b8288491fff0617f3a596e2125c2fe39d6b60c143f4934f |

Befehle: `test-addition-provenance.ps1`, `test-decisions.ps1`,
`test-red-provenance.ps1` und `test-workflow.ps1`, jeweils über PowerShell
`-NoProfile -File scripts/tests/tui-contract/...`. T054/T055/T059 sind damit
technisch belegt. T057/T058 und native/human/finale Gateabnahme bleiben offen.

## English evidence

The 58-case policy suite separates all three pin states, five impact classes,
conservative fallback, lifecycle authority and retained regression/tombstones.
Workflow guards reject five weakenings without claiming native CI acceptance.
New requirements need a unique ID and internally verified test-first proof;
strict schemas reject self-asserted verification. Source and failed TRX must
already match historical Git blobs, tests must precede affected product changes,
and red/implementation commits must form the local HEAD ancestry.

An owned synthetic Git repository independently exercises the exact production
history function: ten negative assertions first fail at a permissive seam, then
all eleven cases pass. Synthetic failed execution is only validator fixture data,
never actual requirement, product or human proof. Hash/schema checks precede the
same function in public validation. Semantic test quality still requires review.
T054/T055/T059 are technically evidenced; native CI, human and final acceptance
remain Open. Original hashes above bind the ignored test logs.
