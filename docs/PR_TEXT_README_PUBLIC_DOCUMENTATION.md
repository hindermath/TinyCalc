## Title

`docs: expand README as public agentic migration showcase`

## Summary

This PR significantly expands `README.md` into a full public-facing documentation for the project.
It explains both the technical porting result (Pascal -> C#/.NET 10) and the agentic delivery process used to build it.

## Included Changes

- Updated `/Users/thorstenhindermann/Codex/TinyCalc/README.md` with:
  - project purpose and target audience
  - legacy source context (`CALC.PAS`, `CALC.INC`, `CALC.HLP`)
  - architecture and feature mapping
  - formula language and command overview
  - test strategy and CI overview
  - step-by-step agentic workflow used in this migration
  - branch/PR chronology from this repository process
  - practical guidance for teams that want to replicate this approach
- Added this PR description file:
  - `/Users/thorstenhindermann/Codex/TinyCalc/docs/PR_TEXT_README_PUBLIC_DOCUMENTATION.md`

## Validation

- Documentation-only change.
- No runtime behavior change.

## Risk / Impact

- No code impact.
- Improves project onboarding, transparency, and educational value for external users.
