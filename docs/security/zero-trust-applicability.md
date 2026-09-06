# Zero-Trust-Anwendbarkeit: TinyCalc Feature 003

## Deutscher Prüfblock

| Feld | Wert |
|---|---|
| Datum | 2026-08-30 |
| Feature | 003, Terminal.Gui-v2-Migration |
| Status | N/A, geprüft und begründet |
| Owner | Feature 003 |
| Reviewer | Security-/PR-Review am Exact Head |
| Kanonische Entscheidung | `docs/security/arc42-security.md`, Abschnitt 11 |

NIST SP 800-207 Zero Trust ist für Feature 003 nicht anwendbar. TinyCalc bleibt
ein lokaler Einprozessbetrieb ohne verteilten Dienst, Cloudgrenze,
Remoteverwaltung, Dienstidentität oder Netzwerkzugriff. Least Privilege und
sichere Defaults gelten dennoch innerhalb des lokalen Prozesses.

Eine Netzwerk-, Cloud-, Service-, Remote- oder Identitätsgrenze setzt den
Status auf `Open` und verlangt eine neue Architektur-, Trust-Boundary- und
Zero-Trust-Bewertung. T057/T067 muss am Exact Head bestätigen, dass der finale
Diff keinen solchen Trigger einführt.

## English review block

NIST SP 800-207 Zero Trust is not applicable to Feature 003 because TinyCalc
remains one local process without a distributed service, cloud boundary,
remote management, service identity, or network access. Least privilege and
fail-safe defaults still apply inside the local process.

Any network, cloud, service, remote, or identity boundary changes the status
to open and requires new architecture, trust-boundary, and Zero Trust review.
The canonical rationale and trigger remain in
`docs/security/arc42-security.md`, Section 11.

## Feature 005: Produkt und Lieferung / Product and delivery

**DE:** Prüftag ist 2026-09-06. Produkt-Zero-Trust bleibt `N/A`, weil TinyCalc
lokal und ohne Dienstidentität oder Remoteverwaltung läuft. Delivery-Zero-Trust
ist `Applicable`: Repository, CI, Provideridentität und Freigabe bilden
Ressourcen- und Identitätsgrenzen. Minimale Berechtigung, Head-Bindung,
Secret-Scans und explizite Provider-Evidenz sind aktuelle Kontrollen, aber
keine vollständige NIST-SP-800-207-Implementierung.

Owner ist die Repository-Maintenance-Rolle; Reviewer ist die unabhängige
technische Security-Review-Rolle. Ein Netzwerkdienst öffnet die Produktprüfung;
eine Änderung von Repository, CI, Identität oder Provider öffnet die
Lieferprüfung. Restrisiko bleiben Providerkonfiguration und Human-only-
Freigaben, bis echte Evidenz vorliegt.

**EN:** Review date is 2026-09-06. Product Zero Trust remains `N/A` for the
local single-process application. Delivery Zero Trust is `Applicable` to
repository, CI, provider identity, and release boundaries. Least privilege,
head binding, secret scans, and explicit provider evidence are controls, not a
claim of complete NIST SP 800-207 implementation.
