# Secure Development Assurance – Integration

## Zweck und Profil / Purpose and Profile

TinyCalc verwendet das ausdrücklich freigegebene Profil
`secure-development-assurance-thirteen-governance-presets` aus
[`scripts/config/spec-kit-preset-profiles.json`](../../scripts/config/spec-kit-preset-profiles.json).
Die bisherige Assurance-Installation wurde nicht erneut installiert.
Die zwölf anderen Presets bleiben unverändert; ältere Profile und der globale
Standard bleiben erhalten. Die lokale Level-2-Registrierung wird erst nach
erfolgreichem Merge und Main-Synchronisation auf dieses Profil umgestellt.

*TinyCalc opts into the thirteen-preset profile. Its existing Assurance
installation is retained without reinstalling. The other twelve presets,
older profiles, and global default stay unchanged. The local Level-2 registry
is switched only after successful merge and main synchronization.*

## Verbindliche Paketquelle / Authoritative Package Source

- Repository: [Secure Development Assurance Governance](https://github.com/hindermath/spec-kit-preset-secure-development-assurance-governance).
- Tag: `v0.1.2`; Commit: `02423602592ad0183454e259df628ab940436ba6`.
- [Öffentliches Tag-ZIP / Public tag ZIP](https://github.com/hindermath/spec-kit-preset-secure-development-assurance-governance/archive/refs/tags/v0.1.2.zip).
- SHA-256: `4eb30804bb3c329681e0b7d44187c8daeb3e9e4f250bb6003d5b746c0ad0b656`.
- Installiert / installed: `0.1.2`, aktiviert / enabled, Priorität / priority `15`.
- Voraussetzung / prerequisite: `security-governance >=0.6.1`; vorhanden / present: `0.6.2`.
- v0.1.2 ist explizit gebunden, unabhängig von GitHubs „Latest“-Markierung.
  Die [Community-Einreichung #4455](https://github.com/github/spec-kit/issues/4455)
  ist keine Installationsquelle und kein Nachweis einer Katalogaufnahme.

*Published standalone GitHub repositories are the only preset product sources.
Installed copies are project integrations. The explicit version pin takes
precedence over GitHub's “Latest” marker. Submission is not catalog acceptance.*

## Bedienung und Grenzen / Usage and Boundaries

Der sichere Einstieg ist `$speckit-secure-development-status [<evidence-dir>]`
in der Codex-Skill-Oberfläche. Auf anderen Agentenflächen lautet der Befehl
`speckit.secure-development-status`. Ohne Verzeichnis wird der lexikografisch
neueste Evidence-Kontext gewählt. Direkter lesender Aufruf ab Projektwurzel:

```bash
bash .specify/presets/secure-development-assurance-governance/scripts/validate-secure-development-assurance.sh status
```

```powershell
pwsh -NoProfile -File .specify/presets/secure-development-assurance-governance/scripts/validate-secure-development-assurance.ps1 -Action Status
```

Der zweite Befehl ist
`$speckit-secure-development-review <baseline|delta|closure|image-impact> <context-id> <training|mixed|development>`.
Er setzt einen ausdrücklich autorisierten Review des benannten Kontexts voraus.
Diese Integration führt ihn nicht aus. Die projektgeführte Baseline bleibt
`3.2.0`; Richtlinien, Checklisten und menschliche Entscheidungen bleiben erhalten.

`CL-02-13 Cloud-Compliance-Assurance` stellt einen Bezug zu C5 her, aber das
Preset führt weder eine vollständige C5-Kriterienprüfung noch eine Testat- oder
Zertifizierungsprüfung durch. `Ready` bedeutet nur konsistente Evidence im
benannten Kontext. Es ersetzt keine Pilot-, Projekt- oder allgemeine Freigabe.
Vollständige Anleitung: [installierte Paket-README](../../.specify/presets/secure-development-assurance-governance/README.md).

*Start with the read-only status command above. The review command requires
explicit authority for the named gate and context and is not run by this
integration. Baseline 3.2.0, project evidence, policies, checklists, and human
decisions are retained. C5 is an applicability relationship, not a full
criteria, attestation, or certification assessment. `Ready` never implies
pilot authorization, project acceptance, or general release. The installed
package README provides the complete command contract.*

## Prüfungen am 2026-09-06 / Checks on 2026-09-06

- SHA-256 des öffentlichen Archivs stimmt mit der Freigabebindung überein.
- Exakte 13-Preset-Matrix bestanden; alle bestehenden Registereinträge und
  Profildefinitionen unverändert, 581 geschützte Dateien bytegleich.
- Paket-Vertragsfixtures und Installationstests bestanden: positive und
  negative Fälle, vier Gates, menschliche Entscheidungsgrenzen,
  LF/CRLF/BOM, Bash-/PowerShell-Parität und acht generierte Oberflächen.
  Alle schreibenden Fixtures liefen ausschließlich in temporären Projekten.
- Lesender Status: Kontext
  `docs/security/secure-development/2026-09-05-rl-se-self-assessment`;
  Baseline, Delta, Closure und Image-Impact jeweils `Ready`, insgesamt `Ready`.
  `technicalValidation=Fulfilled`; `pilotAuthorization`, `projectAcceptance`
  und `generalRelease` jeweils `Open`.
- Dokumentierte nächste Aktion dieses unveränderten Kontexts: unabhängiger
  technischer Review, menschliche Entscheidungen bis zu autorisierter Evidence
  offen halten. Dieser Statuscheck startet keinen solchen Review.
- Produktcode, Produktversion, APIs und Laufzeit unverändert. TDD und
  Changed-Code-Coverage `N/A` für diese reine Integrations-/Dokumentationsänderung;
  bei Produktcodeänderungen erneut bewerten. Produktregression bleibt im
  bestehenden PR-Workflow (`ci`, Linux/Windows, Build/Test/TUI-Smoke).

*The archive binding, exact matrix, byte preservation, isolated package
fixtures, shell parity, and generated command checks passed. Existing evidence
reports four Ready gates but three Open human authorization boundaries. Its
recorded next action is retained, not executed. No product runtime or API
changes are made; product regression remains in the existing PR CI.*

## Dokumentationsauswirkung / Documentation Impact

`UpdateRequired`; Owner: Thorsten Hindermann. Zielgruppen: Maintainer,
KI-Agenten und Lernende; Leserpfad: README → dieser Integrationsnachweis →
Paket-README → lesender Status. Kanonische Produktquelle: GitHub-Tag v0.1.2;
Integrationsquelle: lokaler Profilkatalog und 13er-Matrix. Betroffen sind README,
dieser Nachweis, fünf gemeinsam gepflegte Agenten-Dateien und Statistik-Ledger.
Dokumentklasse: Bedienung/Governance, Deutsch zuerst und Englisch danach;
Text-first ohne farbabhängige Bedeutung, Links und Befehlswege werden geprüft.
Distributionsklasse: Repository-Integration; kein Home-Sync, kein anderer
Rollout. Beide Constitutions wurden auf Auswirkung geprüft; Runtime,
Build/Test-, A11Y- und Statistikbasis bleiben unverändert.

NIST SSDF und CWE Top 25 gelten für die Integrationsprüfung. ASVS, Zero Trust,
Produkt-AI-SBOM und neue Produkt-SBOM sind hier `N/A`: keine neue Laufzeit,
Web-/Auth-Grenze oder Produktkomponente. Secret-Scan und Paketbindung bleiben
Pflicht. Wiedervorlage bei Paket-, Profil-, Baseline- oder Laufzeitänderung.

*Documentation impact is UpdateRequired, owned by Thorsten Hindermann. The
German-first bilingual reader path leads from README through this record to
the package manual and read-only status. Five agent guides are kept aligned.
Repository integration requires no Home sync or other rollout. Both
constitutions retain their runtime, test, accessibility, and statistics
contracts. SSDF/CWE and secret/supply-chain checks apply; no new product,
web/auth, or AI runtime makes the other listed scopes applicable. Reevaluate
when the package, profile, baseline, or runtime changes.*
