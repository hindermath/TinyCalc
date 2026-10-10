# ADR-006: Interne Session und unabhängige Evidenz / Internal session and independent evidence

## Deutscher Entscheidungsblock

Status: umgesetzt; unabhängiger Quell-/Delta-Review durchgeführt, keine Produktabnahme.
Datum 2026-10-10; Feature 006, LocalImplementation. Evidenzverantwortlich:
Feature-Entwicklung. Reviewer `independent_closeout_review`, ausdrücklich
genehmigt; [Nachweis](../../security/secure-development/006-tui-functional-contract/independent-review.md).
Grundlagen: Constitution Schichtentrennung, XII/XIII, ISO A.8.27/A.8.28.

Kontext: Engine- oder Smoke-Tests beweisen keine angebotenen Editor-/Dialogwege.
Statischer UI-Zustand behindert isolierte Tests. Gleichzeitig darf kein neues
Produkt-Testprotokoll oder zweiter Dispatcher entstehen.

Entscheidung: erst echte Legacy-Views durch Framework-Eingaben testen, danach
dieselben Views in eine interne instanzgebundene Session extrahieren. Tests und
Validator führen ein separates versioniertes Vertrags-/Nachweismodell; Core
bleibt davon frei. Der unabhängige Quellenkatalog ist nicht aus Pass-Ergebnissen
abgeleitet. Ein Producer prüft vollständige Pflichttupel und schreibt atomar;
der Validator liest nur und startet keine JSON-Befehle.

Alternativen: Engine-only verworfen, weil Editor-Erkennung/Fokus ungetestet
blieben. Öffentlicher Testmodus verworfen, weil er Produktfläche und alternative
Semantik erzeugt. Permanent breite Reflection verworfen; sie ist nur Übergang
mit enger Memberliste. Ungeprüfte Ergebnisdateien verworfen, weil fehlende
Assertions falsches Grün ermöglichen.

Konsequenz: serielle Framework-Sitzungen und getrennte native/PTY/Human-Gates
kosten Infrastrukturaufwand, erhalten aber die Beweisgrenzen. Restrisiken:
manipulierte oder nur behauptete Evidenz braucht zusätzlich unabhängigen Review
und Bindung an tatsächliche Läufe. Trigger: API-/Ownership-/Framework-/Vertrags-
oder Prozessänderung. Noch keine Produktabnahme oder externe Zertifizierung.

## English decision block

This implementation follows the owner-approved plan; independent review remains
open. Actual legacy-view input tests preceded internal
session extraction. The same product controls remain in use, Core stays free
of evidence dependencies, and an independent source catalog defines obligations.
Complete assertion-backed tuples permit atomic producer output; a read-only
validator never executes JSON commands.

Rejected alternatives are engine-only proof, a public product test mode,
permanent broad reflection and unvalidated result files. Serialization and
separate native/PTY/human gates are deliberate costs. Claimed evidence still
needs independently reviewed actual execution bindings. Ownership/API/framework/
contract changes reopen the decision. No acceptance or certification is claimed.
