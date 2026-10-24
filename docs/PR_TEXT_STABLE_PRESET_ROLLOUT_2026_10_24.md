# Begrenzter Rollout: 14 stabile Governance-Pakete

## Aktueller Dokumentationspatch-Nachlauf / Current documentation patch follow-up

Verbindliche Quelle: Home Baseline PR #345, Merge
`ded29751b58eece7711e80cf997a89b559812c93`. Dieser Nachlauf ersetzt die
Paketbindungen des früheren PR-Heads `d9d2ed10`; die folgenden historischen
Ergebnisse bleiben als Vorgänger erhalten und sind keine aktuellen Passes.
Aktueller Bericht: `docs/maintenance/documentation-patch-pilot-2026-10-24.md`.
Aktuelle Checks: `docs/maintenance/documentation-patch-pilot-2026-10-24-checks.json`.

The current follow-up uses Home Baseline PR #345 and preserves the previous
head's historical evidence. Use the new report and checks record for current
technical results, not the historical sections below.

Alle 14 Dokumentationspatches: 660 Stockdateien gegen verifizierte Archive,
vollständige native SDK-Agentenkomposition ohne SDK-Patch und ohne Home-only-
Overlay. 678 vollständige lokale Tests ohne Skip, 364 native macOS-Pfade und
`SMOKE_OK`; Restore und Release-Build ohne Fehler oder Warnungen. Die aktuelle
GSDB-Matrix erhält nur technische Paket-/Hashbindungen; 157 Kontrollbewertungen,
Findings und menschliche Entscheidungen bleiben unverändert. Neuer eigener
Assurance-Kontext; alte Kontexte bleiben historisch erhalten.

All fourteen documentation patches: 660 verified stock files, complete native
SDK composition without SDK patches or Home-only overlays. One complete local
run passes 678 tests without skips, binds 364 macOS paths and returns
`SMOKE_OK`; restore and Release build succeed without errors or warnings.
Preserve GSDB conclusions, findings, human decisions and older contexts.

Explizite aktuelle Lieferfreigabe: MergeAndSync mit Admin-Bypass ohne erneute
Einzel-Head-Sichtung dieses begrenzten Diffs. Grüne technische Checks,
geklärte Reviewbefunde und gelieferte Level-0/Home-Runtime bleiben Voraussetzung.
Keine Produkt-, Rechts-, Risiko- oder allgemeine Freigabe und kein Modelllauf.

Current explicit delivery authority permits bounded MergeAndSync with admin
bypass without another individual-head review. Green technical checks, resolved
findings and delivered Level 0/Home Runtime remain mandatory. No product,
legal, risk or general approval and no model call are inferred.

---

## Historischer Vorgänger / Historical predecessor

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
