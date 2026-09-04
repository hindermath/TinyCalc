# PR: TinyCalc-Delivery-Serie erneut prüfen / Re-review TinyCalc Delivery Series

## Problem / Problem

Die PL/0-Liefernachweise wurden nach dem öffentlichen TinyPl0-Release
aktualisiert. Dadurch änderten sich der PL/0-Intake-Hash und die gebundene
Serienevidenz. Der vorherige dreizehnteilige Review war deshalb korrekt
archiviert und supersediert, aber noch nicht durch einen aktuellen Review
ersetzt.

*The PL/0 delivery evidence changed after the public TinyPl0 release. This
changed the PL/0 intake hash and bound series evidence. The previous
thirteen-target review was correctly archived and superseded, but it still
needed a current successor review.*

## Lösung / Solution

- Alle 13 Zielintakes, vier Wurzeln und neun bindenden Hard Gates erneut
  prüfen und mit aktuellen Hashes binden.
- Einen schema-1.1-Request, ein maschinenlesbares Ergebnis und einen
  zweisprachigen Bericht veröffentlichen.
- Das Vorgängerreview ausdrücklich mit der neuen Review-ID verknüpfen.
- Die externe TinyPl0-Lieferstufe als erfüllt bestätigen, ohne den offenen
  TinyCalc-Preflight oder den internen Secure-Development-Vorgänger
  freizugeben.
- Den Governance-Renderer so begrenzen, dass entweder kein aktiver Review oder
  genau der vollständige Dreiersatz aus Request, Resultat und Bericht besteht.

*The change re-reviews all thirteen targets and binds the complete current
series. It records the external package delivery without clearing any TinyCalc
integration or predecessor gate. The renderer accepts either no active review
or the complete three-file review set.*

## Risiken / Risks

Die wichtigste Gefahr wäre, `Ready` als Produkt- oder Lieferfreigabe zu
missverstehen. Das Ergebnis bewertet ausschließlich die Qualität und
Konsistenz der Intake-Serie. Das aktuell `Eligible` Ziel erteilt ebenfalls
keine Implementierungs-, Paket-, Push-, Merge- oder Bypass-Berechtigung.

Ein unvollständiger aktiver Review-Satz bleibt fail-closed. Der Statistikblock
wird erst nach dem Governance-Commit aus einem sauberen Arbeitsbaum neu
erzeugt.

*The main risk is confusing review readiness with product or delivery
authority. `Ready` and `Eligible` are governance evidence only. Incomplete
active review evidence remains fail-closed.*

## Testplan / Test Plan

- Intake-Governance-Konfiguration in PowerShell und Bash
- Serienmanifest und Serienreceipt in PowerShell und Bash
- Review-Resultat und Request-Hashbindung in PowerShell und Bash
- vollständiges Requirements-/Intake-Alignment in PowerShell und Bash
- Git-/Evidenzhashvergleich vor und nach read-only Statusprüfungen
- JSON-, UTF-8-, Secret-, Homogenitäts-, Statistik- und `git diff --check`-
  Prüfung

*No local product build, restore, package update, API change, or DocFX rebuild
is required because the change affects only documentation, governance
evidence, and its validator.*
