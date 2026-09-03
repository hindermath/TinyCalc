# PR: PL/0-Liefernachweis aktualisieren / Refresh PL/0 Delivery Evidence

## Problem / Problem

Das PL/0-Lastenheft beschreibt die öffentlichen TinyPl0-Pakete noch als
fehlend. Diese Ist-Aussage ist nach dem stabilen Release `v0.4.1` falsch. Ein
veralteter Lieferstatus könnte bei einer späteren Spezifikation entweder einen
erfüllten Nachweis übersehen oder den weiterhin offenen TinyCalc-Preflight
unklar darstellen.

*The PL/0 intake still describes the public TinyPl0 packages as missing. This
current-state statement became false after stable release `v0.4.1`. Stale
delivery status could hide completed evidence or make the still-open TinyCalc
preflight unclear during later specification work.*

## Lösung / Solution

- Den TinyPl0-Release `v0.4.1`, den Quellcommit und den erfolgreichen
  Release-Workflow als erfüllte externe Lieferstufe dokumentieren.
- Die versionsgleichen öffentlichen Pakete `TinyPl0.Core` und `TinyPl0.Vm`
  durch offizielle NuGet.org-Metadaten belegen.
- Die Integrationsversion weiter versionsneutral lassen; Auswahl, Pin,
  Locked Restore, Driftklassifikation und Contract-Tests bleiben Teil des
  späteren TinyCalc-Preflights.
- Den internen Secure-Development-Vorgänger, Rang 8 und den Zustand `Blocked`
  unverändert lassen.
- Intake-, Serien- und Review-Vorgänger byteidentisch archivieren, Hashes
  fortschreiben und den alten Review ausdrücklich supersedieren.

*The change records release `v0.4.1`, its source commit, successful release
workflow, and matching public packages as completed external delivery
evidence. It does not choose an integration version or perform the TinyCalc
preflight. Order, scope, and the blocked lifecycle state remain unchanged.*

## Risiken / Risks

Die wichtigste Gefahr wäre eine zu weit gehende Aussage: Ein erfolgreicher
TinyPl0-Release ersetzt weder den TinyCalc-Locked-Restore noch Driftprüfung,
Contract-Tests oder den internen Vorgänger. Deshalb trennt der Text beide
Gate-Stufen ausdrücklich. Öffentliche URLs werden nur als hashgebundene
Snapshots erfasst; Zugangsdaten oder private Quellen gehören nicht zur
Evidenz.

*The main risk is overclaiming completion. A successful TinyPl0 release does
not replace TinyCalc locked restore, drift review, contract tests, or the
internal predecessor. The two gate stages therefore remain explicit. Public
URLs are recorded only as hash-bound snapshots without credentials or private
sources.*

## Testplan / Test Plan

- Authoring-, Serien-, Alignment- und Governance-Validierung in PowerShell und
  Bash
- JSON-, UTF-8-, Hash-, Archiv- und Supersession-Prüfung
- Live-Abgleich von Release, Workflow-Jobs und beiden NuGet.org-Indizes
- Negativnachweis, dass kein veralteter aktiver Review bestehen bleibt
- Homogenitäts-, Secret-, Markdown- und `git diff --check`-Prüfung
- Statistikprüfung zuerst als Check/Vorschau, danach kontrolliertes Rendering

*No product build, test run, dependency restore, package update, or DocFX
regeneration is required because product code, tests, APIs, dependencies,
runtime, and DocFX content do not change.*
