# Dependabot-Wartung / Dependabot Maintenance

DE: Ergaenzt woechentliche, gebuendelte Minor-/Patch-Updates sowie separate
Major- und Sicherheitsupdates fuer GitHub Actions, NuGet und .NET-Tools.
Zentrale Wartungskopien und historische Fixtures bleiben bei ihren Quellen.
Keine Paket- oder Produktcodeaenderung, kein Auto-Merge und kein Home-Sync.

EN: Adds weekly grouped minor/patch updates and separate major and security
updates for GitHub Actions, NuGet and .NET tools. Central maintenance copies
and historical fixtures retain their existing ownership. No package or product
code changes, auto-merge or Home sync.

Validation: YAML round-trip, Dependabot schema, manifest and policy checks,
Documentation Impact, exact staged paths and secret scan. Hosted checks are
recorded on this PR before merge. Documentation Impact: UpdateRequired;
see the [maintenance guide](../.github/DEPENDENCY-MAINTENANCE.md).

Risk: dependency proposals still require compatibility and security review.
