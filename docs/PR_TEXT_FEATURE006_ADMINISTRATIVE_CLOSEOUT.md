# Feature 006: Verwaltungsabschluss / Administrative closeout

## Problem / Problem

Feature 006 ist geliefert; Intake und Serie waren noch offen. Zwei README-Quellbindungen und eine PL/0-AGENTS.md-Bindung waren veraltet. / Product delivery was complete while lifecycle records and three source bindings lagged.

## Lösung / Solution

Bytegleiche Archivierung, neue Receipts mit stabilen Intake-IDs, Serienfortschreibung und ehrliche Reviewsupersession. Keine Produkt-/Paketänderung, kein Folgefeature. / Preserve bytes and identities, renew source lineage and progress lifecycle without product changes or a successor run.

Genehmigte enge Renderer-Korrektur: direkte Intake-Belege binden exakten Pfad und Hash; eine A11Y-Kontexterwähnung erhält keinen TUI-Featurebeleg. Roter Regressionstest vor Fix, danach grüne Identitäts-/Hash-/Kontexttests. Historische featurelokale Snapshot-Strategie unverändert. / Approved bounded fix: direct intake proofs require exact path and hash, with red/green regression evidence; historical feature-local snapshots are unchanged. [Nachweis / Evidence](../specs/006-tui-functional-contract/evidence/administrative-renderer-repair.md).

## Risiken und Prüfplan / Risks and validation

Hash-/Pfad-/Lifecycle-Konsum erfordert echte Validatoren: beide Shell-Wrapper, Alignment samt negativen Fixtures, native Governance-CI und staged Delivery-Set/Secretprüfung. Alter Review bleibt historisch; neuer Review ist pending. Admin nur formal. / Validate consumers and native CI; never replace pending review with a fabricated pass. See [administrative evidence](../specs/006-tui-functional-contract/evidence/administrative-closeout.md).
