# Reconciliation Validation

## Nachweis / Evidence

- Neun Root-Lastenhefte besitzen genau eine primäre Entscheidung.
- Der historische Produktplan und beide Reihenfolgedokumente sind mit
  normalisierten SHA-256-Werten gebunden.
- Terminal.Gui `1.19.0` und die weiter aktiven `MicroCalc`-Projektbezeichner
  belegen die beiden wesentlichen offenen Produktintakes.
- Das Audit verändert keine Produktdatei, kein Intake und keine Spec-Kit-
  Feature-Metadaten.

*Nine root intake files have exactly one primary decision. The historical
product plan and both order documents are bound by normalized SHA-256 values.
Terminal.Gui `1.19.0` and the active `MicroCalc` project names prove the two
material open product intakes. The audit changes no product file, intake, or
Spec Kit feature metadata.*

## Reproduktion / Reproduction

```bash
node scripts/reconcile-requirements-intakes.mjs
jq '.summary' specs/requirements-reconciliation-20260726/requirements-coverage.json
git diff --check
```
