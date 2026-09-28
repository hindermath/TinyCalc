# Authoring v0.3.5 liefern / Deliver Authoring v0.3.5

Problem: Der öffentliche 0.3.4-Validator lehnte eigene Generator-Receipts ab;
TinyCalc benötigte einen dokumentierten Drei-Dateien-Backport.
Lösung: veröffentlichtes v0.3.5 installieren, Backport gegen das Paket abgleichen,
Profilbindungen nachziehen und beide bestehenden Statistiken aktualisieren.

Problem: public 0.3.4 rejected its own generator receipts; TinyCalc required a
three-file backport. Install published v0.3.5, reconcile the backport, update
profile bindings and refresh both existing statistics contexts.

Umfang / scope: Governance-Paket, Tests, Quellenbindung und Dokumentation /
governance package, tests, source bindings and documentation. Kein Produktcode,
keine API-/TUI- oder Assembly-Änderung; keine Screenshots erforderlich. / No
product, API, TUI or assembly change; screenshots are not applicable.

Risiko, Documentation Impact und konkrete lokale Tests stehen im
[Integrationsnachweis](maintenance/intake-authoring-v035.md). Native PR-CI
einschließlich Produkt-Build/-Tests bleibt vor Merge verpflichtend.
Keine neue interaktive Produktabnahme wird behauptet.

Die gezielte GSDB-Nachprüfung wurde gesondert genehmigt: zwei Quellenbindungen
und Authoring-Version aktualisieren, Negativtests erweitern, bestehende
Kontroll-, Produkt-, Risiko- und Releaseentscheidungen erhalten.

See the [integration evidence](maintenance/intake-authoring-v035.md) for risks,
documentation impact and exact local tests. Native PR CI, including product
build/tests, remains mandatory before merge; no new interactive acceptance
is claimed. MergeAndSync/admin bypass never replaces successful technical CI.

The separately authorized bounded GSDB follow-up updates two source bindings
and the Authoring version, adds negative tests and preserves existing control,
product, risk and release decisions.
