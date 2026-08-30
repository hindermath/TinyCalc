# PR: TinyCalc-Intake-Serie nach Feature 002 fortschreiben

## Problem

Feature 002 ist vollständig geliefert, die aktive Intake-Serie führte den
Constitution-Intake jedoch weiterhin als `Eligible`. Dadurch blieb der
verbindliche Nachfolger Terminal.Gui formal blockiert.

*Feature 002 is fully delivered, but the active intake series still marked the
constitution intake as `Eligible`. Its binding Terminal.Gui successor therefore
remained formally blocked.*

## Lösung / Solution

- Constitution-Intake auf `Completed` setzen
- Terminal.Gui-Migration auf `Eligible` setzen
- Reihenfolge, vier Wurzeln und sechs Abhängigkeiten unverändert lassen
- vorheriges Manifest und Receipt bytegleich archivieren
- Manifest, Receipt, Operation, Reihenfolge, Index und Generator synchronisieren

*The change advances only the two lifecycle states, preserves order and graph,
archives the previous manifest and receipt byte-identically, and synchronizes
all generated governance views.*

## Risiken / Risks

Die drei unabhängigen Wurzeln bleiben `Pending` und erhalten keine automatische
Ausführungsberechtigung. Dieses Update startet weder Intake-Review noch ein
Feature.

*The three independent roots remain `Pending` and gain no automatic execution
authority. This update starts neither intake review nor a feature.*

## Testplan / Test Plan

- Bash- und PowerShell-Validatoren für Governance-Konfiguration, Manifest und Receipt
- vollständige Requirements-/Intake-Alignment-Prüfung
- bytegleiche Hashprüfung der beiden Archivkopien
- Homogenitätsprüfung und aktuelles Statistikprofil

*Validation covers both shell implementations, complete requirements alignment,
byte-identical archive hashes, repository homogeneity, and the statistics
profile.*
