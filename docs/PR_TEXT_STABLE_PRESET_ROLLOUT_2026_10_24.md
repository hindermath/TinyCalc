# Begrenzter Rollout: 14 stabile Governance-Pakete

## Auftrag / Scope

TinyCalc folgt dem gelieferten Level-0-Stand aus Home Baseline PR #341
(`e00f1262`). Keine Produktfunktion, Modellprobe, neue Routing-Entwicklung,
Toolchain-Wartung oder Community-Einreichung. Home-only-Overlay und private
`sheet.mcalc.json` bleiben ausgeschlossen.

TinyCalc follows delivered Level 0 from Home Baseline PR #341. No product
feature, model call, new routing development, toolchain maintenance or
community submission. No Home-only overlay or private sheet is included.

## Änderungen / Changes

- Vierzehn veröffentlichte stabile Pakete einschließlich Security 0.7.3,
  Assurance 0.1.7 und Model Routing 0.1.6; exakte Versionstabelle im Bericht.
- Unveränderliche Archiv-/Tag-Quellen getrennt von beobachtetem Installed-Lock;
  Profilnamen, Prioritäten und globaler Acht-Preset-Default erhalten.
- Vollständige Wrapper/Agentenflächen; keine persönlichen Profile.
- Technische GSDB-Versions-/Hash-Nachprüfung mit unverändert gesicherten
  157 Kontrollbewertungen, Findings und menschlichen Entscheidungen.
- Eigener begrenzter Assurance-Kontext, aktuelle Guidance und beide Statistiken.
- Native Statistik-CI an aktuellen 14-Paket-Lock gebunden; historisches
  v0.1.0-Receipt erhalten, keine abgeschwächte Payload-Prüfung.

The changes bind fourteen published stable packages, retain defaults and
priorities, preserve historical and human decisions, and use the current
complete installed lock instead of rewriting the old statistics receipt.

## Technische Nachweise / Technical evidence

- 604 Stock-Archivdateien und alle 14 SHA-256-Bindungen geprüft.
- Bash/PowerShell: exakte Matrix, Status und vier read-only Assurance-Gates.
- 8 Agenten-/Lock-Tests; 14 Dokumentationssuites; 238 gemeinsame Assertions,
  49 stabile Command-Deklarationen; 44 Mindestkombinations-Assertions.
- GSDB-Quellen/Sammelband/Mappings/Matrix und Negativfixtures grün;
  28 zusätzliche veraltete Paketbindungen müssen blockieren.
- Restore und Release-Build grün; 678 vollständige Tests ohne Skip;
  macOS-Collector bindet 364 Pfade; nichtinteraktiver Smoke `SMOKE_OK`.
- DocFX mit 105 bereits am Baseline-Commit vorhandenen Warnungen und keiner
  neuen Warnung; drei Leserpfade per Lynx und semantischem Browser-Snapshot.
- PowerShell-Analyse: 132 Dateien, keine Error-/Warning-Befunde.
- Secretscan: keine High-/Medium-Befunde.

See the versioned rollout report and checks JSON for commands, limits and
technical evidence. Local macOS success is not native Linux/Windows evidence.
Physical screenreader/Braille and complete WCAG/B2 acceptance remain separate.

## Dokumentationsauswirkung / Documentation impact

`UpdateRequired` für aktuelle Guidance und Integrationsnachweise;
`GeneratedUpdate` für Statistik-Ausgaben. Deutsch zuerst, gleichwertiges
Englisch, CEFR B2 und anwendbare WCAG 2.2 AA. Owner: Thorsten Hindermann.
Bericht: `docs/maintenance/stable-preset-rollout-2026-10-24.md`.
Maschinenlesbare Evidence:
`docs/maintenance/stable-preset-rollout-2026-10-24-checks.json`.

## Liefergate / Delivery gate

Zur fachlichen Sichtung am exakten PR-Head pausieren. Nicht mergen, bevor
Thorsten diesen TinyCalc-Head freigegeben hat und technische Checks grün sind.
Danach gegebenenfalls MergeAndSync mit ausdrücklich bestätigtem Admin-Bypass,
lokalem `0/0` und erfolgreicher Merge-CI. Sandbox und Show folgen erst danach.

Pause for human review of this exact TinyCalc head. Merge only after concrete
approval and green technical checks. Then synchronise and verify merge CI
before proceeding to the next pilot.
