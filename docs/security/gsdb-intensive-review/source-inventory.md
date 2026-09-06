# Quelleninventar der GSDB-Intensivprüfung / GSDB Intensive Review Source Inventory

## Zweck / Purpose

**DE:** Dieses Inventar bindet die am 6. September 2026 tatsächlich gelesenen
Quellen. Ein Hash bestätigt den beobachteten Dateiinhalt, aber nicht automatisch
die Erfüllung einer Kontrolle. `Current` bedeutet: im Feature-005-Preflight neu
gelesen. `Revalidated` bedeutet: ältere Evidenz wurde mit aktuellem Pfad, Hash,
Scope und Locator erneut geprüft.

**EN:** This inventory binds the sources actually read on 6 September 2026. A
hash confirms the observed file content but does not automatically prove that a
control is fulfilled. `Current` means newly read during the Feature 005
preflight. `Revalidated` means older evidence was checked again for current
path, hash, scope, and locator.

## Kontrollierte GSDB-Basis / Controlled GSDB Baseline

Das Manifest `docs/secure-development/baseline-manifest.json` hat Version
`3.2.0`, Veröffentlichungsdatum `2026-07-19` und den normalisierten SHA-256
`e7739adbf67b2d0f16273f52839c2cb6d4807753f7246b33bac6969b59355ad3`.
Es steuert genau 36 Dateien: Richtlinie, Sammelband, zwölf Einzelchecklisten,
15 mitgeltende Dokumente, einen Lernpfad, vier Referenzdateien sowie PDF und
Prüfsummendatei. / The manifest controls exactly 36 files: guideline,
compendium, twelve checklists, 15 related documents, one learning path, four
reference files, and the PDF plus checksum file.

| Klasse / Class | Pfad / Path | Version | Normalisierter SHA-256 / Normalized SHA-256 | Status und Locator / Status and locator |
|---|---|---|---|---|
| Guideline | `docs/secure-development/Richtlinie_Sichere-Entwicklung.md` | `3.2.0` | `bd2947abf2c367a23c3461ea84de50ac5202436c3b15b5c6d9b6bb64318e132e` | Current; vollständige Richtlinie / complete guideline |
| Compendium | `docs/secure-development/Checklistensammelband_Sichere-Entwicklung.md` | `2.2.0` | `ac4ebb80a4954db060074762f99c211930a347bec965902dc08becf608aa0b69` | Current; 157 Überschriften und Blöcke / 157 headings and blocks |
| Checklist | `docs/secure-development/checklisten/CL_01_Standards-Anwendbarkeit.md` | `2.0.0` | `b0b3b15c1ad7d46a8f83f563583d9538d72332787f4468d63e691ec37fc4decf` | Current; `CL-01-01` bis `CL-01-12` |
| Checklist | `docs/secure-development/checklisten/CL_02_Sichere-Softwarearchitektur.md` | `2.0.0` | `1b387329009286ce7a0a67b7af1f4bd3f60d290413f57c2eab307ca4b257ec9d` | Current; `CL-02-01` bis `CL-02-13` |
| Checklist | `docs/secure-development/checklisten/CL_03_Krypto-Mindestvorgaben.md` | `2.0.0` | `031cc40fa44877e34cafc1b398f4ea582c1088647cae4659824e8ff7b5e6b5e9` | Current; `CL-03-01` bis `CL-03-15` |
| Checklist | `docs/secure-development/checklisten/CL_04_Bedrohungsmodellierung.md` | `2.0.0` | `12d26d0051f4b6de966c7c67c5f0004e25c3136a269fd586a4a3f0f9418d512e` | Current; `CL-04-01` bis `CL-04-10` |
| Checklist | `docs/secure-development/checklisten/CL_05_Lieferkette-Build-Integritaet.md` | `2.0.0` | `058f9118d955f710953c1ef352189aaad2dda2dd833f82f26d350c5ae54260ec` | Current; `CL-05-01` bis `CL-05-13` |
| Checklist | `docs/secure-development/checklisten/CL_06_Schwachstellenoffenlegung.md` | `2.0.0` | `b5392a2109a08770aa06d5c2a318653058b9687029cdb404ebb08c615b81b972` | Current; `CL-06-01` bis `CL-06-11` |
| Checklist | `docs/secure-development/checklisten/CL_07_CRA-Anwendbarkeit.md` | `2.0.0` | `b661bb1ab93a5d8a4105f39ab77e2738d80664ac0c1057be04dfa02069de9874` | Current; `CL-07-01` bis `CL-07-12` |
| Checklist | `docs/secure-development/checklisten/CL_08_Sicherheits-Code-Review.md` | `2.0.0` | `59e55eba03904d1a1e80f2ad4fd67c700b998006adda6a0be838f60d09a17207` | Current; `CL-08-01` bis `CL-08-13` |
| Checklist | `docs/secure-development/checklisten/CL_09_KI-Codeerzeugung.md` | `2.2.0` | `071ed93b5c2bcdfa585f54e7c5386db8cc265d92c6b0bc018ed77d0adfabb766` | Current; `CL-09-01` bis `CL-09-17` |
| Checklist | `docs/secure-development/checklisten/CL_10_Sichere-Entwicklungsumgebung.md` | `2.0.0` | `f99e707e4a4186c6ab4031cccdb796981b766ff3d4e09f43798d223e37715f25` | Current; `CL-10-01` bis `CL-10-17` |
| Checklist | `docs/secure-development/checklisten/CL_11_Datenschutz-Folgenabschaetzung.md` | `2.0.0` | `f04655647392351e1fd283d39c7ac874a5974eb597068e286d11508fc4c16381` | Current; `CL-11-01` bis `CL-11-12` |
| Checklist | `docs/secure-development/checklisten/CL_12_Agentische-KI-Sandbox.md` | `2.2.0` | `2ef55845c8d66e7cd1da1ef4a3cb36c7c29b79a3ec1bc6b3a7edb4b4a0505784` | Current; `CL-12-01` bis `CL-12-12` |
| RelatedDocument | `docs/secure-development/mitgeltende-dokumente/BCM-Notfallhandbuch.md` | `1.0.0` | `215c3ce2663ac50929d05d42c853e6419d0b5df24b0261b04244fc4537520432` | Current; vollständiges Dokument / complete document |
| RelatedDocument | `docs/secure-development/mitgeltende-dokumente/Checkliste_Secure-Development-Life-Cycle.md` | `1.0.0` | `7f04bcf5fa25af9d7ef518d7198b87ac9e54db747445ee1b8aa42199421b0830` | Current; vollständiges Dokument / complete document |
| RelatedDocument | `docs/secure-development/mitgeltende-dokumente/Datenschutzleitlinie.md` | `1.0.0` | `867941dcb41cdfa870c514ed8906ba6cc39ac40116f86839ddba5da0daf4150f` | Current; vollständiges Dokument / complete document |
| RelatedDocument | `docs/secure-development/mitgeltende-dokumente/Gebrauch_kryptografischer_Massnahmen.md` | `1.0.0` | `d61943b4a3c1ba61f9524b6c1b30fee548c5a7c93afbf3219e80e323df59018a` | Current; vollständiges Dokument / complete document |
| RelatedDocument | `docs/secure-development/mitgeltende-dokumente/Kompetenzprofile_und_Schulungsplan_Sichere-Entwicklung.md` | `1.0.0` | `d48b8a49f1e2d28491b91e9c0b65bb1715e278ce79618647ea38aba32a6e70f0` | Current; vollständiges Dokument / complete document |
| RelatedDocument | `docs/secure-development/mitgeltende-dokumente/Leitlinie_Sichere-Entwicklungs-Sandbox.md` | `1.0.0` | `8b808faacad06e354d962bc3cfa6c93be1ca349603115f534cfaaecb40be2582` | Current; vollständiges Dokument / complete document |
| RelatedDocument | `docs/secure-development/mitgeltende-dokumente/Leitlinie_Sichere-Programmierung.md` | `1.0.0` | `37d095a65fa498e170cf6a0e21e303a5ad1d5cdd09b3275b8c8e8fff3cb3d805` | Current; vollständiges Dokument / complete document |
| RelatedDocument | `docs/secure-development/mitgeltende-dokumente/Leitlinie_Sicheres-Softwaredesign.md` | `1.0.0` | `ac9135ddeb4afbf66bc626988325817d22d9e3b1fadea27193b05858e455900b` | Current; vollständiges Dokument / complete document |
| RelatedDocument | `docs/secure-development/mitgeltende-dokumente/Richtlinie_Changemanagement.md` | `1.0.0` | `8db6c57dfb68d153cf32af5cdd9cf62549bc2d4817002ce3f2b08c6833313a55` | Current; vollständiges Dokument / complete document |
| RelatedDocument | `docs/secure-development/mitgeltende-dokumente/Richtlinie_Dienstleister-und-Lieferantenbeziehungen.md` | `1.0.0` | `07456bf83731b8fd9dbb6e40a685cf65066ff163928315dfd30cad942a9aad23` | Current; vollständiges Dokument / complete document |
| RelatedDocument | `docs/secure-development/mitgeltende-dokumente/Richtlinie_Secure-Development-Life-Cycle.md` | `1.2.0` | `52808b36e49db9a85f3f95866995ca7dacfd79e1a5a3622ecca324615584fd49` | Current; vollständiges Dokument / complete document |
| RelatedDocument | `docs/secure-development/mitgeltende-dokumente/Richtlinie_Testmanagement.md` | `1.0.0` | `7f45078247cf4776e0d14f3a89e3e5a7617d49ea475a9d04ed61c09267f84199` | Current; vollständiges Dokument / complete document |
| RelatedDocument | `docs/secure-development/mitgeltende-dokumente/Richtlinie_Zugangssteuerung.md` | `1.0.0` | `872541b8135315963b246c7678e6244a17dd44013ef5ad2bde30f41bcd0dfc41` | Current; vollständiges Dokument / complete document |
| RelatedDocument | `docs/secure-development/mitgeltende-dokumente/Standardsregister_Sichere-Entwicklung.md` | `1.0.0` | `f0aae0f1448d8bc800470804185974ef50b92be08de9f255f29864da6038709e` | Current; vollständiges Dokument / complete document |
| RelatedDocument | `docs/secure-development/mitgeltende-dokumente/Verzahnung_Richtlinie_Checklisten_Spec-Kit-Presets.md` | `1.1.0` | `779655e47fb608b689ab4aa299ddc8530144562674caf3e080d18e15bd28bbe7` | Current; vollständiges Dokument / complete document |
| LearningDocument | `docs/secure-development/Lernpfad_Sichere-Entwicklung_Lehrjahr-1-bis-3.md` | `1.0.0` | `ab1eb29b864b40f539d92e888684c2c485324ce72b747119d7e3b7ff46d1197b` | Current; vollständiges Dokument / complete document |
| ManagedReference | `docs/secure-development/README.md` | `Managed` | `9f9d3249fe430dd69b28cd07bee6efe8793c3c26af3db041f687708ac47b99d9` | Current; Index |
| ManagedReference | `docs/secure-development/mitgeltende-dokumente/README.md` | `Managed` | `0fcb099fbf10d821520b9c80040ead7bcc89503d395a9116d8509a2ae074d974` | Current; Index |
| ManagedReference | `docs/secure-development/mitgeltende-dokumente/THE-CASE-FOR-MEMORY-SAFE-ROADMAPS-TLP-CLEAR.DE.md` | `Managed` | `d729e0c1ca799d61ec96bd2dab53656f442deb2431f62dd5f615d343afb6b91d` | Current; deutsche Textfassung / German text version |
| ManagedReference | `docs/secure-development/mitgeltende-dokumente/THE-CASE-FOR-MEMORY-SAFE-ROADMAPS-TLP-CLEAR.EN.md` | `Managed` | `2898e053a0bf03cfc42f32089a91fb45860afc956dfa45a3f2fc099b849e86a7` | Current; englische Textfassung / English text version |
| ManagedBinary | `docs/secure-development/mitgeltende-dokumente/THE-CASE-FOR-MEMORY-SAFE-ROADMAPS-TLP-CLEAR.pdf` | `Managed` | `dfe3e72e075738e345aab81a541f72ab4c0cd149235426108090bf48787bc34b` | Current; PDF-Binärdatei / PDF binary |
| ManagedBinary | `docs/secure-development/mitgeltende-dokumente/THE-CASE-FOR-MEMORY-SAFE-ROADMAPS-TLP-CLEAR.sha256` | `Managed` | `fc62c1f879c6e17739e17c5114ccc38dea7e8552ddbad55e606e130dd5b696de` | Current; nennt denselben PDF-Hash / names the same PDF hash |

## Governance-, Workflow- und Projektevidenz / Governance, Workflow, and Project Evidence

| Klasse / Class | Pfad / Path | Normalisierter SHA-256 / Normalized SHA-256 | Scope, Freshness und Locator |
|---|---|---|---|
| Constitution | `constitution.md` | `c57f6e586d93a48b2254550367289e9e3e3ba6645ebb8f308f2e9e24dc7c93b9` | Current; Principles XI-XVIII und Registry-Zeile `RiderProjects/TinyCalc` |
| Constitution | `.specify/memory/constitution.md` | `c57f6e586d93a48b2254550367289e9e3e3ba6645ebb8f308f2e9e24dc7c93b9` | Current; byte-identischer Partner / byte-identical partner |
| Registry | `.specify/presets/.registry` | `3dd7cdd07cd9581a532749967d91115fac499b00f500822cefbcccca7723ad81` | Current; `presets` mit 13 Einträgen / 13 entries |
| Workflow | `.github/workflows/ci.yml` | `2b2dfb1606d9068b22b0eb1b5f9f4c266c03923bf1207bbb5d2a3b9fea4e79fc` | Current; Linux-/Windows-Produkt- und GSDB-Validatorjobs nach T059 |
| Workflow | `.github/workflows/agent-secret-scan.yml` | `2e604000c7c18c64420c3553f0db35e18222bafd9324a90295126667e567ada2` | Current; Secret-Scan |
| Workflow | `.github/workflows/gitleaks.yml` | `825705909c0a7c4f1b3844c73f30c46bc684a736adb959892add3f53897c8a8a` | Current; gitleaks |
| Workflow | `.github/workflows/homogeneity-check.yml` | `408c5ec7a8eaf5f6a269368032e0d32527cd5d3487d27b2a33467c971dd6a47b` | Current; Ubuntu/macOS/Windows |
| Workflow | `.github/workflows/powershell-analysis.yml` | `8d1a3b78cd161d630cbad34fc122305ecdb9cae5dc321b1a0c561d774e5d97b8` | Current; PSScriptAnalyzer |
| Workflow | `.github/workflows/requirements-intake-governance.yml` | `b3c36af60db78839159b3a6dd714c090792b38e8c4a957f4ec8a38f47116a752` | Current; Intake-Parität |
| Validator | `scripts/validate-rl-se-assessment.ps1` | `515dc2ace57c79ff209594ad9eb63eb440cb438dc1b719a7dbeba82c64618609` | Revalidated; Feature-004-Vertrag / Feature 004 contract |
| Validator | `scripts/validate-rl-se-assessment.sh` | `06e3150b58ea460f523b91ba1610d61cd035c218eacab5b89af2a1dca8e1c5b2` | Revalidated; Bash-Partner |
| Validator | `.specify/presets/autonomous-run-governance/scripts/validate-autonomous-run-state.ps1` | `ab45103607ce624349c33d830070984daa56833660ef8ec0d0528a07558cd05a` | Current; Run `69674c80-911c-40ff-9a0e-004f7b13b832` |
| Validator | `.specify/presets/autonomous-run-governance/scripts/validate-autonomous-phase-result.ps1` | `9cc2521a6a54d45bc34b72739881824b70d0d570212c7d02504c484c8b0d9793` | Current; sieben Vorgängerergebnisse / seven predecessor results |
| Validator | `.specify/presets/intake-review-governance/scripts/validate-intake-review-result.ps1` | `c94f3db6f5c8fe2f2237abafe6411484881bd404ee99311404c5558d17fff22e` | Current; Ready-Review |
| Validator | `.specify/presets/intake-sequencing-governance/scripts/validate-intake-series-manifest.ps1` | `03e52d13276d44945dd21028a5822f004460cc920e80d22e0f06dbc300a53521` | Current; `tinycalc-delivery` |
| IntakeEvidence | `requirements/intakes/active/Lastenheft_GSDB-Spec-Kit-Intensivpruefung.005-gsdb-intensive-review.md` | `f4dcb3fac6cb755faed296847ffd40170f0d008fa3640e5e5fa5bc38e4af5375` | Current; branchgestempelter bindender Scope / branch-stamped binding scope |
| IntakeEvidence | `requirements/intakes/series/tinycalc-delivery/manifest.json` | `586424d2424b31f16c1461583affb3b0204886ccca0e79fb59af7759842b6703` | Current; GSDB `Completed`, kein `declaredEligible` / no `declaredEligible` |
| IntakeEvidence | `requirements/intakes/series/tinycalc-delivery/intake-review-request.json` | `daf3027245df1d4681305746e771787c19d80d18c647dac5776b7e7eb5f2608d` | Current; Review-Anforderung / review request |
| IntakeEvidence | `requirements/intakes/series/tinycalc-delivery/intake-review-result.json` | `22bb15b3016d31f2dfcc65aff0a4979e2eac18af998c1a8be58440f6e293757b` | Current; `Ready` |
| IntakeEvidence | `requirements/intakes/series/tinycalc-delivery/intake-review-report.md` | `0a291a17ef43f4ef7a1178e20dc6504a4ff6e9c8ffb588a94ae7bf667f9915c0` | Current; lesbare Review-Sicht / readable review view |
| ProjectEvidence | `docs/security/secure-development/2026-09-05-rl-se-self-assessment/baseline.json` | `5e3fc21dc957a18e19c6a43edb5765b781cde3c8352e00fa6f16bf5721f85e1c` | Revalidated; Gate `baseline` |
| ProjectEvidence | `docs/security/secure-development/2026-09-05-rl-se-self-assessment/assessment-matrix.json` | `6ffe434f811571c02c5da951b2234dcbe5dd3564dbaa9176e4fffa40d44b0858` | Revalidated; 157 Feature-004-Zeilen |
| ProjectEvidence | `docs/security/secure-development/2026-09-05-rl-se-self-assessment/closure.json` | `07c34f1e576d23d4b1fa808ebbecc5d38466280a0fbc505a79f633aaeb914e5f` | Revalidated; technische Schließung, Human-only offen / technical closure, Human-only open |
| ProjectEvidence | `docs/security/secure-development/2026-09-05-rl-se-self-assessment/deltas/rl-se-assessment.json` | `81137a3d22381f0381c053ab61c2f187e6f2f483e1c472a8b99b7ac9d0dd2a33` | Revalidated; Feature-004-Delta |
| ProjectEvidence | `docs/security/secure-development/2026-09-05-rl-se-self-assessment/image-impact.json` | `fb52d3dd414d4d2d7af668a9f206e4a40beaf04a7d08d643ccc01289e345ad42` | Revalidated; Bildauswirkung / image impact |
| ProjectEvidence | `docs/security/secure-development/2026-09-05-rl-se-self-assessment/evidence-matrix.md` | `2c72d9d33e3269c98cb67c60c2d8551ea3f2272448871de06188401b92ea8fdc` | Revalidated; Lesesicht / reader view |

## Zeilenspezifische Evidenzbindungen / Row-Specific Evidence Bindings

**DE:** Zusätzlich zur kontrollierten Basis bindet die Matrix jeden in einer
Bewertungszeile verwendeten Repository-Pfad. Damit sind auch die aktuellen
Feature-005-Dispositionen für ASVS, Regulatorik, Cloud-Autonomie, C5,
Zero Trust, Qualitätsszenarien und Lieferkette hashgebunden. Insgesamt enthält
das kanonische Inventar 87 eindeutige Pfade. Ein Hash belegt den Inhalt, aber
nicht automatisch die Erfüllung einer Kontrolle.

**EN:** In addition to the controlled baseline, the matrix binds every
repository path used by an assessment row. This includes current Feature 005
dispositions for ASVS, regulation, cloud autonomy, C5, Zero Trust, quality
scenarios, and the supply chain. The canonical inventory contains 87 unique
paths. A hash proves content, not automatic control fulfilment.

| Klasse / Class | Pfad / Path | Normalisierter SHA-256 / Normalized SHA-256 | Status und Locator / Status and locator |
|---|---|---|---|
| ProjectEvidence | `docs/security/security-quality-scenarios.md` | `81427d45fd22554b09b09e2c46f3a0d92ac7b8f7338059330aae733ae4855d04` | Revalidated; Sicherheits-Qualitätsszenarien |
| ProjectEvidence | `docs/security/supply-chain-evidence.md` | `ce2ad04908b883ec2d1e8b44af0a9ce24c17580bf01dd09c35ffee12242c6e3f` | Revalidated; Supply-Chain-Evidenz |
| ProjectEvidence | `docs/security/threat-model.md` | `94093ec8a0b84d0362c6695c17280b0a3f5126c5185348ce0416542fbbd554ad` | Revalidated; Bedrohungsmodell / threat model |
| ProjectEvidence | `scripts/validate-rl-se-assessment.sh` | `06e3150b58ea460f523b91ba1610d61cd035c218eacab5b89af2a1dca8e1c5b2` | Revalidated; read-only shell entry point |
| ProjectEvidence | `scripts/scan-agent-secrets.ps1` | `0e8b8035b2b94b41cef29989fc373561650ece571f5ba42a16e07ef984aac0c9` | Revalidated; read-only script entry point |
| ProjectEvidence | `scripts/validate-rl-se-assessment.ps1` | `515dc2ace57c79ff209594ad9eb63eb440cb438dc1b719a7dbeba82c64618609` | Revalidated; read-only script entry point |
| ProjectEvidence | `docs/security/security-checklist.md` | `ec1f13a40631751a1828ceb7f1de263c89563895bb7cef689ea26ec4517299e8` | Revalidated; C#/.NET-Sicherheitsprüfung / security review |
| ProjectEvidence | `docs/security/zero-trust-applicability.md` | `24bbd7e6e6893ce694908da44657bcf4613f01a692dc9272203f15a72f6e3a8e` | Revalidated; Zero-Trust-Disposition |
| ProjectEvidence | `docs/security/sbom/tinycalc-terminalgui.spdx.json` | `3193a0f53e962ccaac8741331203990ba727a7ca0901ef17a8e3403678ffb398` | Revalidated; SPDX-JSON-Wurzel und Paketbeziehungen |
| ProjectEvidence | `docs/security/cloud-compliance-assurance.md` | `c92b6bd9506c3395b8bf113bc42c55d66ab39c61c78e7c3c04184e23dc9c275c` | Revalidated; BSI-C5-Assurance-Disposition |
| ProjectEvidence | `docs/security/regulatory-applicability.md` | `789b4aa74424dcf82bed27df4f1dd645dc4b7290dd5615b2f14abd44586d4259` | Revalidated; Regulatorik und Datenschutz / regulation and privacy |
| ProjectEvidence | `docs/security/README.md` | `773fd9460c8cefda7375c086345b90ae05195028a16e0f0a5261b7154906be69` | Revalidated; Security-Leserpfad / reader path |
| ProjectEvidence | `docs/security/dependency-audit.md` | `441e2567712441816448243498112e514dfaa4fcd21cee0ec69ce64335c141c5` | Revalidated; aktueller Paketgraph / current package graph |
| ProjectEvidence | `docs/security/cloud-autonomy-applicability.md` | `b34586ebbea57b0c9ce6aae99e00f9b8ef17b24c8f0455588dbd6a0703fa1349` | Revalidated; BSI-C3A-Disposition |
| ProjectEvidence | `docs/security/asvs-verification.md` | `32012026c330e0affbbd7e07f62fb5f00fee6393924b30c09b3161c1c02d315b` | Revalidated; ASVS-N/A und Trigger |
| ProjectEvidence | `docs/security/arc42-security.md` | `eb28c797c53a2eca5cc8902ade176a9f854d8f63f58d66f482a09d7cf7e31a57` | Revalidated; arc42 Section 8 |
| ProjectEvidence | `AGENTS.md` | `64b3050bf61ec3844601d60ab7adce9c889f573fb2fcb541d39c61bdbb6fded6` | Revalidated; Repository-Governance |
| ProjectEvidence | `.specify/presets/.registry` | `3dd7cdd07cd9581a532749967d91115fac499b00f500822cefbcccca7723ad81` | Revalidated; 13 installierte Presets |
| ProjectEvidence | `specs/004-rl-se-self-assessment/autonomous-run-evidence.md` | `d3ec4b95b39d12693a0d549760fa096078e22533ce412068b5f182416b81bece` | Revalidated; Feature-004-Laufevidenz |
| ProjectEvidence | `docs/security/samm-assessment.md` | `c6036128766f4aabb43ca32631db0a2c4b86f35b2c6d947296525cfa87c569e9` | Revalidated; OWASP-SAMM-Disposition |
| ProjectEvidence | `specs/004-rl-se-self-assessment/plan.md` | `984cb6e791dacae44dbf3c9d8a7d6baf9d4ba1d3fec33fb306b0117bc5a09861` | Revalidated; Feature-004-Planungsgrenze |

## ID- und Sammelbandnachweis / ID and Compendium Proof

**DE:** Die kanonischen Überschriften liefern 157 Vorkommen und 157 eindeutige
IDs. Die Familienzahlen sind `12/13/15/10/13/11/12/13/17/17/12/12`. Der
Sammelband enthält dieselbe ID-Menge. Die Blockinhalte werden durch den
Feature-005-Validator byte-normalisiert zwischen jeder Einzelcheckliste und dem
zugehörigen Sammelbandabschnitt verglichen.

**EN:** The canonical headings provide 157 occurrences and 157 unique IDs. The
family counts are `12/13/15/10/13/11/12/13/17/17/12/12`. The compendium holds
the same ID set. The Feature 005 validator compares normalized block content
between each individual checklist and its matching compendium section.

## Quellenrangfolge / Source Precedence

**DE:** Intake bestimmt den Feature-Scope; beide Constitutions bestimmen die
Governance; das Manifest bestimmt das kontrollierte Inventar; die einzelne
Checkliste bestimmt ID und Kontrolltext; Richtlinie und mitgeltende Dokumente
bestimmen zusätzliche Pflichten; der Sammelband ist nur die abgeleitete
Paritätssicht. Ein Widerspruch wird als Befund erfasst.

**EN:** The intake defines feature scope; both constitutions define governance;
the manifest defines controlled inventory; the individual checklist defines
the ID and control text; the guideline and related documents define additional
duties; the compendium is only the derived parity view. A contradiction becomes
a finding.
