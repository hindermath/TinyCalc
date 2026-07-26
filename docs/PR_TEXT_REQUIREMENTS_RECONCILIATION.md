# PR: TinyCalc Requirements and Intake Reconciliation

## Problem / Problem

Die neun aktiven Lastenhefte und zwei unterschiedliche Reihenfolgedokumente
machen den nächsten verbindlichen Intake uneindeutig.

*Nine active intake files and two different order documents make the next
binding intake ambiguous.*

## Lösung / Solution

Ein reproduzierbarer, read-only Abgleich bindet alle Quellen an Hashes,
klassifiziert den aktuellen Erfüllungsstand und beschreibt die spätere
Strukturmigration. Es wird kein Feature gestartet und keine Anforderung
verschoben.

*A reproducible read-only reconciliation binds every source to hashes,
classifies current completion, and describes the later structural migration.
It starts no feature and moves no requirement.*

## Risiko / Risk

Das Audit trifft noch keine Produktentscheidung. Seine Klassifikationen müssen
im getrennten Migrations-PR als aktuelle Eingabe erneut validiert werden.

## Testplan / Test Plan

- Generator zweimal mit identischem Ergebnis ausführen.
- JSON-Summary und Quellhashes prüfen.
- `specify check`, `git diff --check` und Homogeneity ausführen.
