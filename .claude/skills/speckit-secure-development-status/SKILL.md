---
name: speckit-secure-development-status
description: Secure-Development-Evidence vollständig und strikt read-only prüfen
compatibility: Requires spec-kit project structure with .specify/ directory
metadata:
  author: github-spec-kit
  source: secure-development-assurance-governance:commands/speckit.secure-development-status.md
---

# Secure Development Status

Syntax:

~~~text
$speckit-secure-development-status [<evidence-dir>]
~~~

Prüfe das ausdrücklich angegebene Evidence-Verzeichnis. Fehlt der Parameter,
verwende das lexikografisch neueste Verzeichnis unter
`docs/security/secure-development/`.

Führe auf Windows
`.specify/scripts/validate-secure-development-assurance.ps1` mit `-Action Status` aus.
Führe auf macOS/Linux
`.specify/scripts/validate-secure-development-assurance.sh status` aus.

Der Befehl ist strikt read-only. Er darf keine Evidence, Richtlinie,
Checkliste, Baseline, Freigabe, Git- oder Remote-Zustände verändern.

Berichte textorientiert und in stabiler Reihenfolge:

1. den ausgewählten Kontext;
2. Baseline-, Delta-, Closure- und Image-Impact-Ergebnis;
3. das strengste Gesamtergebnis;
4. `technicalValidation`, `pilotAuthorization`, `projectAcceptance` und
   `generalRelease` getrennt;
5. die exakt dokumentierte nächste Aktion.

Blockiere bei fehlenden Quellen, Drift, ungültigen Statuskombinationen,
abgelaufenen Reviews, unvollständigen Risiken, fehlender
`security-governance`-Voraussetzung oder unzulässigen
Zertifizierungsbehauptungen. Erfolgreiche technische Validierung darf niemals
als menschliche Freigabe ausgegeben werden.

## English

Inspect the selected evidence directory without changing it. Validate the
complete baseline binding and all four gates. Report every gate, the worst
overall outcome, all four human decision boundaries, and the exact recorded
next action. Never infer an approval or certification from technical success.