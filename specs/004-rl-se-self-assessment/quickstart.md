# Quickstart: RL-SE-/Checklist-Selbstpruefung

## Zweck / Purpose

**DE:** Diese Befehlsfolge prueft die 157-Zeilen-Selbstbewertung reproduzierbar.
Sie erteilt keine Zertifizierung oder menschliche Freigabe.

**EN:** This command sequence validates the 157-row self-assessment
reproducibly. It grants no certification or human approval.

## 1. Voraussetzungen / Prerequisites

```powershell
pwsh -NoProfile -File .specify/presets/autonomous-run-governance/scripts/validate-autonomous-run-state.ps1 `
  -State specs/004-rl-se-self-assessment/autonomous-run-state.json
```

Der Arbeitsbaum muss zum aktiven Feature gehoeren. Secrets, Runtime-Logs und
private absolute Pfade duerfen nicht in die Evidenz gelangen.

## 2. RED-Vertrag / RED Contract

Eine frische, garantiert fehlende Temp-Datei macht RED auch nach Erstellung der
realen Matrix wiederholbar:

```powershell
$MissingAssessment = Join-Path ([IO.Path]::GetTempPath()) `
  ("tinycalc-rlse-missing-{0}.json" -f [guid]::NewGuid())
pwsh -NoProfile -File scripts/validate-rl-se-assessment.ps1 -Assessment $MissingAssessment
```

Erwartung: Exitcode ungleich 0 und eine `RLSE...`-Fehler-ID. Der Fehler ist
beabsichtigte RED-Evidenz und keine Freigabe zum Ueberspringen.

## 3. GREEN und Paritaet / GREEN and Parity

```powershell
pwsh -NoProfile -File scripts/validate-rl-se-assessment.ps1 `
  -Assessment docs/security/secure-development/2026-09-05-rl-se-self-assessment/assessment-matrix.json

bash scripts/validate-rl-se-assessment.sh `
  --assessment docs/security/secure-development/2026-09-05-rl-se-self-assessment/assessment-matrix.json
```

Beide Varianten muessen 157/157 eindeutige kanonische IDs melden.
Dieselben Entry-Points laufen in `.github/workflows/ci.yml` auf Linux und
Windows. Isolierte Ein-Zeilen-Fixtures pruefen nur Row-Regeln; sie sind keine
gueltigen Produktionsdokumente.

## 4. Assurance-Gates / Assurance Gates

```powershell
pwsh -NoProfile -File .specify/presets/secure-development-assurance-governance/scripts/validate-secure-development-assurance.ps1 `
  -EvidenceDirectory docs/security/secure-development/2026-09-05-rl-se-self-assessment `
  -Action Status
```

Danach folgt ein getrennter fachlicher Review. Ein technischer Pass ersetzt
keine Pilotfreigabe, Projektabnahme oder allgemeine Freigabe.

## 5. Produktregression / Product Regression

Vor jedem Build oder Test wird der Build-Zaehler gemaess
`Directory.Build.props` erhoeht.

```powershell
dotnet restore MicroCalc.sln
dotnet build MicroCalc.sln --configuration Release --no-restore
dotnet test MicroCalc.sln --configuration Release --no-build
dotnet run --no-build --configuration Release `
  --project src/MicroCalc.Tui/MicroCalc.Tui.csproj -- --smoke
```

Smoke muss exakt `SMOKE_OK` ausgeben.

## 6. Dokumentation und Governance / Documentation and Governance

```powershell
pwsh -NoProfile -File scripts/test-documentation-impact.ps1
pwsh -NoProfile -File scripts/render-project-statistics.ps1 -CheckOnly
pwsh -NoProfile -File scripts/check-homogeneity.ps1 -TargetDir . -DryRun -NoPatch
pwsh -NoProfile -File scripts/scan-agent-secrets.ps1 -FailOnHigh .
```

Materiale Fehler blockieren die Lieferung. Admin-Bypass gilt nur fuer eine
danach verbleibende formale Merge-Regel.
