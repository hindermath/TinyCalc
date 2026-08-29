# PR: Add the compiled PL/0 cell-functions intake

## Problem / Problem

TinyCalc can evaluate formulas, but it has no approved, traceable requirements
contract for compiled worksheet-local PL/0 functions. The dependency on a
reusable TinyPl0 compiler and VM also needs a binding delivery boundary.

*TinyCalc kann Formeln auswerten, besitzt aber noch keinen genehmigten und
rueckverfolgbaren Anforderungsvertrag fuer kompilierte, arbeitsblattbezogene
PL/0-Funktionen. Auch die Abhaengigkeit von einem wiederverwendbaren
TinyPl0-Compiler und einer VM benoetigt eine verbindliche Liefergrenze.*

## Lösung / Solution

- Add the Version-1 intake for `PL0.<Name>(...)` cell functions at rank 7 of
  the canonical TinyCalc delivery series.
- Include the strict TinyCalc PL/0 profile and the steppable debugger in
  Version 1.
- Require completed TinyPl0 delivery plus matching stable `TinyPl0.Core` and
  `TinyPl0.Vm` packages on NuGet.org before TinyCalc implementation starts.
- Ban a local `ProjectReference` fallback and retain `LocalImplementation`
  authority.
- Add bilingual CEFR-B2 first-use explanations for compiler, debugger,
  runtime, security, and supply-chain terminology.
- Preserve predecessor manifests and receipts with hash-bound supersession
  evidence and complete the ten-target review with status `Ready`.

*Der Intake wird an Rang 7 eingeordnet und umfasst bereits in Version 1 das
strenge Profil sowie den schrittweisen Debugger. Das zweistufige TinyPl0- und
NuGet-Gate bleibt fail-closed; eine lokale ProjectReference ist kein Fallback.*

## Risiken / Risks

This PR changes requirements and governance only. It does not add packages,
execute PL/0, modify product code or APIs, publish NuGet artifacts, or grant
remote implementation authority. The main risk is future dependency drift;
pinned package versions, locked restore, contract tests, and supply-chain
evidence are required before implementation.

*Dieser PR aendert nur Anforderungen und Governance. Das Hauptrisiko ist eine
spaetere Abweichung zwischen TinyCalc und TinyPl0; feste Paketversionen,
Locked Restore, Contract-Tests und Lieferkettennachweise begrenzen dieses
Risiko.*

## Testplan / Test Plan

- Intake-governance configuration validation in Bash and PowerShell
- Complete requirements/intake alignment in Bash and PowerShell
- Intake-review result validation in Bash and PowerShell
- Deterministic governance-renderer and statistics-renderer drift checks
- Request, target, archive, and supersession hash verification
- Agent secret scan and `git diff --check`

No product build, runtime test, or DocFX regeneration is required because no
product, test, API, runtime, or DocFX content changes.

*Kein Produkt-Build, Laufzeittest oder DocFX-Neubau ist erforderlich, weil
Produktcode, Tests, APIs, Laufzeit und DocFX-Inhalte unveraendert bleiben.*
