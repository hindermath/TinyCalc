# macOS-15 CI runner migration / macOS-15-CI-Umstellung

## Summary

GitHub stellt macOS 14 am 2. November 2026 ein. Homogeneity wechselt auf
macOS 15; verteilte Wartungsworkflows erhalten die neue Labelbindung bei
unveraenderter Linux-only-Auswahl. Produkt-CI und macos-latest bleiben erhalten.

GitHub retires macOS 14 on 2 November 2026. Move Homogeneity to macOS 15 and
refresh distributed workflow labels while preserving Linux-only selection.
Product CI and the existing macos-latest intake job stay unchanged.

## Scope and validation

- Docs and CI/CD; no Core/TUI/API changes or interactive smoke requirement.
- Documentation Impact: UpdateRequired; five guidance surfaces and runner guide.
- Hosted CI must pass on the exact PR head, including the existing .NET build,
  tests and non-interactive smoke; successful names alone are insufficient.
- Risk: changed hosted-image tooling. Linux/Windows coverage remains enabled.
- Delivery: MergeAndSync with owner-authorized admin bypass for formal review
  only, after technical checks and review findings are resolved.
