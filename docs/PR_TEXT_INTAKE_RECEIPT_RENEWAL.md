# Intake-Receipt-Erneuerung / Intake receipt renewal

Zwei veraltete README-Quellhashes blockierten die Receipt-Pruefung. Die
ausdruecklich genehmigte Erneuerung erhaelt Intake-IDs und Inhalte, archiviert
Vorgaenger byte-identisch und erstellt neue Operationen und Einzelreviews.
Ein kanonischer Authoring-Backport behebt die Ablehnung der eigenen Version
0.3.4 durch deren Validator. Alle 15 Receipt-/Serienpruefungen und 36
Negativ-Fixtures bestehen; beide neuen Reviews benennen je einen bestehenden
Medium-Referenzbefund und erteilen keine Produktausfuehrungsfreigabe.

Two stale README source hashes blocked receipt validation. Explicitly approved
successors preserve intake identity/content and archive predecessor bytes.
New operations and Single reviews are recorded. A canonical authoring backport
fixes rejection of its own 0.3.4 generator. Fifteen artifact checks and 36
negative fixtures pass. Each review records one pre-existing Medium reference
finding; product execution and the pending Series review remain separate.

Details: [Maintenance evidence](maintenance/intake-lifecycle-fleet-rollout.md).
Risk: the local compatibility backport must be reconciled with the next public
authoring patch. No product, dependency, intake-content or series-order changes.
