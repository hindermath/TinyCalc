# Preset-Zuordnung / Preset Mapping

## Ergebnis / Result

**DE:** Am 6. September 2026 waren 13 Presets installiert und aktiviert. Acht
bilden die verbindliche Standardmatrix. Fünf zusätzliche Presets bleiben
vollständig inventarisiert und werden als `NotInStandardMatrix` bewertet. Das
Starten eines parallelen Laufs ist für Feature 005 `N/A`; das installierte
Parallel-Preset selbst ist deshalb nicht fehlend oder unwirksam.

**EN:** On 6 September 2026, 13 presets were installed and enabled. Eight form
the binding standard matrix. Five additional presets remain fully inventoried
and are assessed as `NotInStandardMatrix`. Starting a parallel run is `N/A` for
Feature 005; this does not make the installed parallel preset missing or
inactive.

| Preset | Version | Priorität / Priority | Matrix | Primäre CL-/Gate-Zuordnung / Primary CL/gate mapping | Manifest SHA-256 |
|---|---:|---:|---|---|---|
| `security-governance` | 0.6.2 | 10 | Standard | CL-01, CL-03, CL-05, CL-07, CL-08; Gates 008-018, 024 | `356daaedfb3b0275c093d7e522b3e616091c1249a2622e071ae4ff690b5a239d` |
| `architecture-governance` | 0.5.2 | 20 | Standard | CL-02, CL-04; Gates 010, 015-018 | `e2dc16bd0a566424dadbdb14a32cae5805d23d5f72e57a3bb3b5e47821882293` |
| `isaqb-architecture-governance` | 0.2.2 | 30 | Standard | CL-02, CL-04; Gate 010 | `9f349a98c20f5200ec2cb50f9b18c2bee2cbfa48e7b7b5e643cd6970ac865eb9` |
| `a11y-governance` | 0.4.3 | 40 | Standard | CL-01; Gates 019, 020, 025 | `abed4e64a34853417674c8403a660daa8b97606b42782be404f0d5faa3347c10` |
| `cross-platform-governance` | 0.2.2 | 50 | Standard | CL-05, CL-10; Gates 021, 023, 026 | `9eff272453e338884da0c695fe79d56ec074e83661d95cccced8800b3337a64e` |
| `agent-parity-governance` | 0.4.2 | 60 | Standard | CL-09, CL-10, CL-12; Gates 025, 026 | `33ab3c1bd99a5069af5c0006899c26476d0cabd868bd7ac55659bdd4e4794952` |
| `autonomous-run-governance` | 0.4.1 | 70 | Standard | CL-05, CL-09, CL-12; Gates 001, 002, 027-033 | `9bdee271462fcecf84cdcf6b25cf70b615d9285c9107e4a30f7d4c00011f4759` |
| `parallel-autonomous-run-governance` | 0.2.6 | 80 | Standard | CL-09, CL-12; Gate 033 (`N/A` execution) | `70af07aa51506790ed99e2743ec7a51127936de0d9e82239e2b3f03716539b0d` |
| `secure-development-assurance-governance` | 0.1.2 | NotInStandardMatrix | Extra | CL-01 bis CL-12; Gates 003-018, 026 | `624d726e0afb71b852581b102f243b9c4d605b4e67e78bb0ec4433b89947750a` |
| `model-routing-governance` | 0.1.4 | NotInStandardMatrix | Extra | CL-09, CL-12; Gates 001, 002 | `a06eee81c3988b9ef617e131370c2522f4d4f8847c6dcfed833f465ed479fd0e` |
| `intake-authoring-governance` | 0.3.1 | NotInStandardMatrix | Extra | CL-09, CL-12; Gates 001, 032, 033 | `20e44082b29e58f7444777f31a9e2057585353567be52c81a40a9b65fef7aa4d` |
| `intake-review-governance` | 0.2.1 | NotInStandardMatrix | Extra | CL-08, CL-09, CL-12; Gates 001, 028, 032 | `81746b9764249a912de4f0570d1178ade21381e38c2409d87957e4a42eadc241` |
| `intake-sequencing-governance` | 0.2.3 | NotInStandardMatrix | Extra | CL-09, CL-12; Gates 001, 032, 033 | `5878fb4d4e075cea5215775ecf15d7b73bf00391c021773934477448edb4699f` |

## Prüfpfade und Drift / Check Paths and Drift

**DE:** Beide vorgeschriebenen Check-only-Einstiege wurden ausgeführt. Sie
vergleichen absichtlich die gesamte installierte ID-Menge mit der reinen
Achtermatrix und melden deshalb die fünf bekannten Extras. Die acht
Standardzeilen wurden zusätzlich einzeln gegen
`scripts/config/spec-kit-governance-presets.json` und `.specify/presets/.registry`
verglichen: ID, Version, Priorität, Aktivstatus und Manifestdatei stimmen. Diese
explizite 8+5-Klassifikation ist der geplante Feature-005-Nachweis; ältere
Aussagen zu sechs oder sieben Presets sind historische Drift.

**EN:** Both required check-only entrypoints were executed. They intentionally
compare the whole installed ID set with the pure eight-preset matrix and
therefore report the five known extras. The eight standard rows were also
compared individually with `scripts/config/spec-kit-governance-presets.json`
and `.specify/presets/.registry`: ID, version, priority, enabled state, and
manifest file match. This explicit 8+5 classification is the planned Feature
005 evidence; older statements about six or seven presets are historical drift.

The observed commands were:

```text
pwsh -NoProfile -File scripts/install-spec-kit-governance-presets.ps1 -CheckOnly
bash scripts/install-spec-kit-governance-presets.sh --check-only
```

Beide meldeten ausschließlich die bekannten zusätzlichen IDs; keine
Standard-ID, Version oder Priorität wich ab. / Both reported only the known
additional IDs; no standard ID, version, or priority differed.
