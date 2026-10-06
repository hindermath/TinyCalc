# PL/0 macOS-15 governance refresh

## Zusammenfassung

Das PL/0-Intake bindet den am 6. Oktober 2026 geänderten
GitHub-Actions-/Runner-Nachweis. TinyCalc PR 99 migrierte explizit gepinnte
macOS-14-Jobs auf `macos-15`. Die Änderung präzisiert, dass nur tatsächlich
ausgeführte Exact-Head-Jobs als CI-Evidenz zählen und dass Hosted CI keine
native TUI-, PTY-, VoiceOver- oder A11Y-Produktabnahme ersetzt.

Die erfüllte externe TinyPl0-Lieferstufe, der offene TinyCalc-Preflight,
17 funktionale Anforderungen, 12 Abnahmekriterien, Rang 8 und der
Serienstatus `Blocked` bleiben unverändert.

## Summary

The PL/0 intake now binds the GitHub Actions and runner evidence changed on
6 October 2026. TinyCalc PR 99 moved explicitly pinned macOS 14 jobs to
`macos-15`. The update clarifies that only jobs that actually ran on the
exact head count as CI evidence and that hosted CI does not replace native
TUI, PTY, VoiceOver, or accessibility product acceptance.

The satisfied external TinyPl0 delivery stage, open TinyCalc preflight,
17 functional requirements, 12 acceptance criteria, rank 8, and the series
`Blocked` state remain unchanged.

## Problem

Der bisherige hashgebundene Intake und sein Review entstanden vor der
Runner-Migration. AC-009 verlangte Prüfungen auf den verbindlichen Plattformen,
benannte aber die neue CI-/Produktabnahme-Grenze nicht ausdrücklich.

The previous hash-bound intake and review predated the runner migration.
AC-009 required checks on binding platforms but did not explicitly state the
new boundary between CI evidence and product-platform acceptance.

## Lösung / Solution

- Vorgänger-Intake, Receipt, Serienartefakte und Review-Triplette byteidentisch
  archivieren.
- Runner-Guide, Documentation-Impact, drei Workflow-Dateien, gemeinsame
  Agenten-Guidance und PR-99-Metadaten als geordnete Quellen binden.
- AC-009 und die erwartete Evidenz deutsch zuerst und englisch danach
  präzisieren.
- Neuen Zielhash kausal in Manifest, Receipt und Operation übernehmen.
- Den bisherigen `Ready`-Review ausdrücklich supersedieren und vor dem
  unabhängigen Serienreview stoppen.
- Die unveränderte archivierte Reihenfolge durch einen bilingualen
  Archiv-Wegweiser mit gültigen, unveränderlichen Zielen ergänzen.

- Archive predecessor intake, receipt, series artefacts, and review triplet
  byte-for-byte.
- Bind the runner guide, documentation impact, three workflows, shared agent
  guidance, and PR 99 metadata as ordered sources.
- Clarify AC-009 and expected evidence in German-first/English-second form.
- Propagate the new target hash causally through manifest, receipt, and
  operation.
- Explicitly supersede the prior `Ready` review and stop before independent
  series review.
- Add a bilingual archive-navigation companion with valid immutable targets
  while leaving the archived order unchanged.

## Risiken und Grenzen / Risks and boundaries

- Keine Produktcode-, API-, Paket-, Lockfile-, Assembly-Version- oder
  DocFX-Änderung.
- Kein Produktlauf, Paketupgrade oder Flotten-Rollout. Die Remote-Lieferung
  bleibt auf diese Governance-Artefakte und den geprüften Exact Head begrenzt.
- NIST SSDF und CWE Top 25 gelten. SBOM/VEX/SLSA bleiben spätere
  Produktliefer-Gates. ASVS, Zero Trust und AI-SBOM sind für diese lokale
  Governance-Dokumentation begründet nicht anwendbar.
- No product code, API, package, lockfile, assembly-version, or DocFX change.
  No product run, package upgrade, or fleet rollout. Remote delivery is
  limited to these governance artefacts at the verified exact head. The
  update grants no PL/0 implementation authority.

## Testplan / Test plan

- Byteidentität aller Archive mit SHA-256 prüfen.
- Authoring-, Serien-, Alignment- und Governance-Validatoren mit PowerShell
  und Bash ausführen.
- JSON/YAML parsen, Homogenität und Secrets prüfen sowie `git diff --check`
  ausführen.
- 13 Ziele, 4 Wurzeln, 9 harte Abhängigkeiten, Rang 8 und `Blocked`
  bestätigen.
- Projektstatistik zuerst als Vorschau und danach kontrolliert aktualisieren.
- Kein `dotnet build`, `dotnet test`, DocFX-, PTY- oder VoiceOver-Lauf:
  Produkt, API, Runtime und UI bleiben unverändert.

## Nächste getrennte Aktion / Next separate action

```text
$speckit-intake-review requirements/intakes/series/tinycalc-delivery/manifest.json
```
