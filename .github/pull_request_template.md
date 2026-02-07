## Summary

- What does this PR change?
- Why is this change needed?

## Scope

- [ ] `MicroCalc.Core` (Domain/Engine)
- [ ] `MicroCalc.Tui` (Terminal.Gui UI)
- [ ] Tests
- [ ] Docs
- [ ] CI/CD

## Problem

Describe the user-visible or technical problem this PR solves.

## Solution

Describe the implemented approach and key tradeoffs.

## Behavioral Notes

- Any intentional behavior differences from classic MicroCalc?
- Any known limitations still open?

## Test Plan

### Automated

- [ ] `dotnet build MicroCalc.sln`
- [ ] `dotnet test MicroCalc.sln`

### Manual

- [ ] App starts: `dotnet run --project src/MicroCalc.Tui/MicroCalc.Tui.csproj`
- [ ] Cell navigation works (arrows / Ctrl keys)
- [ ] Edit text, numeric values, formulas
- [ ] Recalculate works
- [ ] Save/Load JSON works
- [ ] Print export works
- [ ] Help dialog opens and pages navigate

## Screenshots / Terminal Captures

If UI changed, attach screenshots or terminal captures.

## Risks

List potential regressions and mitigations.

## Checklist

- [ ] Code follows repository conventions
- [ ] Tests added/updated where appropriate
- [ ] Documentation updated
- [ ] CI is green
