# PR: GSDB-Intensivprüfung / GSDB Intensive Review

## Problem / Problem

**DE:** Die globale Richtlinie zur sicheren Entwicklung besitzt 157
Einzelkontrollen und weitere querschnittliche Pflichten. TinyCalc benötigte
eine aktuelle, quellengebundene und ehrlich begrenzte Intensivbewertung.

**EN:** The global secure-development baseline contains 157 controls plus
cross-cutting duties. TinyCalc needed a current, source-bound, honestly bounded
intensive assessment.

## Lösung / Solution

**DE:** Diese Änderung liefert einen read-only PowerShell-Validator mit
Bash-Wrapper, negative Fixtures, exakt 157 Matrixzeilen, 16 externe Pflichten,
13 Preset-Zuordnungen sowie Security-, Architektur-, Regulatorik-, Supply-
Chain- und Accessibility-Evidenz. Die Security-Übersicht bietet einen linearen
Leserpfad. CI führt die Validatoren unter Linux und Windows aus.

**EN:** This change adds a read-only PowerShell validator with Bash wrapper,
negative fixtures, exactly 157 matrix rows, 16 external duties, all 13 preset
mappings, and security, architecture, regulatory, supply-chain, and
accessibility evidence. CI runs the validators on Linux and Windows.

## Betroffene Projekte und geschlossener Pfadsatz / Projects and closed paths

**DE:** Produktprojekte `MicroCalc.Core` und `MicroCalc.Tui` bleiben unverändert. Die
Änderungen sind auf die in Feature 005 freigegebenen Validator-, CI-,
Security-, Accessibility-, Dokumentations-, Statistik-, Versions- und
Feature-Evidenzpfade sowie die ausdrücklich genehmigte abgeleitete
CI-Hash-Korrektur im vorhandenen Intake-Autorisierungsbeleg begrenzt. `src/`,
`tests/`, Lösung, Projektdateien, Constitutions und die kontrollierte
GSDB-Basis werden nicht geändert.

**EN:** The product projects remain unchanged. Changes are limited to the approved
Feature 005 validator, CI, security, accessibility, documentation, statistics,
version, feature-evidence paths, and the explicitly approved derived CI-hash
correction in the existing intake-authoring receipt.

## Testplan und Plattformen / Test plan and platforms

- PowerShell fixtures `GSDB001` through `GSDB010` and complete matrix actions.
- Bash linewise fixture parity and complete matrix validation.
- PSScriptAnalyzer, shell syntax, secret scans, intake and homogeneity checks.
- Release restore/build/test and exact `SMOKE_OK` on macOS.
- CI definitions for Linux and Windows PowerShell plus Linux Bash.
- DocFX and text-oriented lynx review; browser harness when available.

## Risiken, Security und A11Y / Risks, security, and accessibility

**DE:** Offene Produkt-, Provider-, Rechts-, Risiko- und
Zertifizierungsfragen bleiben Befunde oder `Pending`. Keine menschliche
Freigabe wird abgeleitet. Die Dokumentation ist Deutsch zuerst, Englisch
danach, text-first und UTF-8; die anwendbaren WCAG-2.2-AA-Kriterien wurden
geprüft. Diese Bewertung führt keine Produkt-Härtung aus.

**EN:** Open product, provider, legal, risk, and certification questions remain
findings or `Pending`; no human approval is inferred. Documentation is German
first and English second, text-first, UTF-8, and reviewed against applicable
WCAG 2.2 AA criteria. This assessment performs no product hardening.

## Konfiguration und API / Configuration and API

Keine öffentliche API, Produktkonfiguration, Datenformat- oder
Laufzeitverhaltensänderung. Die einzige CI-Erweiterung führt den neuen
read-only Vertrag aus. / No public API, product configuration, data-format, or
runtime behavior changes. The only CI extension executes the new read-only
contract.
