# macOS-15-CI-Umstellung / macOS 15 CI runner migration

## Zusammenfassung / Summary

GitHub stellt macOS 14 am 2. November 2026 ein. Homogeneity wechselt auf
macOS 15; verteilte Wartungsworkflows erhalten die neue Labelbindung bei
unveraenderter Linux-only-Auswahl. Produkt-CI und macos-latest bleiben erhalten.

GitHub retires macOS 14 on 2 November 2026. Move Homogeneity to macOS 15 and
refresh distributed workflow labels while preserving Linux-only selection.
Product CI and the existing macos-latest intake job stay unchanged.

## Umfang und Pruefung / Scope and validation

Dokumentation und CI/CD aendern sich; Core, TUI und APIs bleiben erhalten.
Documentation Impact ist UpdateRequired fuer fuenf Guidance-Flaechen und den
Runner-Guide, GeneratedUpdate fuer Profil 2. Die aktive GSDB-Matrix erhaelt
nur neue Hashes fuer die drei geaenderten gebundenen Quellen, keine neuen
Bewertungen oder Freigaben. Vollvalidierung und GSDB001-GSDB010-Fixtures sind
lokal bestanden. Hosted CI muss auf dem exakten PR-Head erfolgreich sein,
einschliesslich bestehender .NET-Builds, Tests und nicht interaktivem Smoke.

Risiko: Das Hosted Image bringt andere Werkzeugversionen mit. Linux und
Windows bleiben geprueft. Lieferung: MergeAndSync mit vom Owner autorisiertem
Admin-Bypass fuer formales Review erst nach bestandenen technischen Checks
und bearbeiteten Reviewbefunden. Daraus folgt keine Produkt-Plattformabnahme.

Documentation and CI/CD change; Core, TUI and APIs remain unchanged.
Documentation Impact is UpdateRequired for five guidance surfaces and the
runner guide, GeneratedUpdate for Profile 2. Refresh only the three changed
source hashes in the active GSDB matrix without new assessments or approvals.
Full validation and GSDB001-GSDB010 fixtures passed locally. Hosted CI must
pass on the exact PR head, including existing .NET builds, tests and smoke.

Risk: hosted-image tool versions change. Linux and Windows retain coverage.
Delivery is MergeAndSync with owner-authorized admin bypass for formal review
only, after technical checks and review findings are resolved. This proves
no native product platform acceptance.
