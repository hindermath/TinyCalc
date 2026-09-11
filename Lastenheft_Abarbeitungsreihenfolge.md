# TinyCalc Intake-Reihenfolge / Intake Order

<!-- linked-intake-generation: 044f43d7740370499df528a07d6451f9431d690621f444dbdace9be159b5b005 -->

Diese Ansicht wird aus der kanonischen Intake-Serie abgeleitet. Verbindliche
Maschinendaten stehen im [Serienmanifest](requirements/intakes/series/tinycalc-delivery/manifest.json).

*This view is derived from the canonical intake series. The linked series
manifest contains the binding machine-readable data.*

| Position | Status | Lastenheft/Intake | Abhängigkeiten / Dependencies | Spec-Kit-Feature |
|---:|---|---|---|---|
| 1 | Completed | [Lastenheft_Constitution_Change.002-constitution-change.md](requirements/intakes/active/Lastenheft_Constitution_Change.002-constitution-change.md) | — (Root / keine direkte Abhängigkeit) | [002-constitution-change](specs/002-constitution-change/) |
| 2 | Completed | [Lastenheft_TerminalGui_Migration.003-terminalgui-migration.md](requirements/intakes/active/Lastenheft_TerminalGui_Migration.003-terminalgui-migration.md) | [Lastenheft_Constitution_Change.002-constitution-change.md](requirements/intakes/active/Lastenheft_Constitution_Change.002-constitution-change.md) → current (`HardCompletionGate`, binding: true) | — (kein Spec-Kit-Feature / no Spec Kit feature) |
| 3 | Pending | [Lastenheft_TUI-Funktionsabnahme-und-Regressionsvertrag.md](requirements/intakes/active/Lastenheft_TUI-Funktionsabnahme-und-Regressionsvertrag.md) | [Lastenheft_TerminalGui_Migration.003-terminalgui-migration.md](requirements/intakes/active/Lastenheft_TerminalGui_Migration.003-terminalgui-migration.md) → current (`HardCompletionGate`, binding: true) | — (kein Spec-Kit-Feature / no Spec Kit feature) |
| 4 | Blocked | [Lastenheft_A11Y_TUI.md](requirements/intakes/active/Lastenheft_A11Y_TUI.md) | [Lastenheft_TUI-Funktionsabnahme-und-Regressionsvertrag.md](requirements/intakes/active/Lastenheft_TUI-Funktionsabnahme-und-Regressionsvertrag.md) → current (`HardCompletionGate`, binding: true) | — (kein Spec-Kit-Feature / no Spec Kit feature) |
| 5 | Blocked | [Lastenheft_Rename_MicroCalc_TinyCalc.md](requirements/intakes/active/Lastenheft_Rename_MicroCalc_TinyCalc.md) | [Lastenheft_A11Y_TUI.md](requirements/intakes/active/Lastenheft_A11Y_TUI.md) → current (`HardCompletionGate`, binding: true) | — (kein Spec-Kit-Feature / no Spec Kit feature) |
| 6 | Blocked | [Lastenheft_Didactic-Inline-Code-Comment-Hardening.md](requirements/intakes/active/Lastenheft_Didactic-Inline-Code-Comment-Hardening.md) | [Lastenheft_Rename_MicroCalc_TinyCalc.md](requirements/intakes/active/Lastenheft_Rename_MicroCalc_TinyCalc.md) → current (`HardCompletionGate`, binding: true) | — (kein Spec-Kit-Feature / no Spec Kit feature) |
| 7 | Blocked | [Lastenheft_Secure-Development-Hardening.md](requirements/intakes/active/Lastenheft_Secure-Development-Hardening.md) | [Lastenheft_Didactic-Inline-Code-Comment-Hardening.md](requirements/intakes/active/Lastenheft_Didactic-Inline-Code-Comment-Hardening.md) → current (`HardCompletionGate`, binding: true) | — (kein Spec-Kit-Feature / no Spec Kit feature) |
| 8 | Blocked | [Lastenheft_PL0-Zellfunktionen_V1.md](requirements/intakes/active/Lastenheft_PL0-Zellfunktionen_V1.md) | [Lastenheft_Secure-Development-Hardening.md](requirements/intakes/active/Lastenheft_Secure-Development-Hardening.md) → current (`HardCompletionGate`, binding: true) | — (kein Spec-Kit-Feature / no Spec Kit feature) |
| 9 | Blocked | [Lastenheft_Legacy-Kompatibilitaet_V1.md](requirements/intakes/active/Lastenheft_Legacy-Kompatibilitaet_V1.md) | [Lastenheft_PL0-Zellfunktionen_V1.md](requirements/intakes/active/Lastenheft_PL0-Zellfunktionen_V1.md) → current (`HardCompletionGate`, binding: true) | — (kein Spec-Kit-Feature / no Spec Kit feature) |
| 10 | Blocked | [Lastenheft_Formelkopie-und-Tabellenoperationen_V1.md](requirements/intakes/active/Lastenheft_Formelkopie-und-Tabellenoperationen_V1.md) | [Lastenheft_Legacy-Kompatibilitaet_V1.md](requirements/intakes/active/Lastenheft_Legacy-Kompatibilitaet_V1.md) → current (`HardCompletionGate`, binding: true) | — (kein Spec-Kit-Feature / no Spec Kit feature) |
| 11 | Pending | [Lastenheft_Sandbox-gestuetzte-Secure-Development-Haertung.md](requirements/intakes/active/Lastenheft_Sandbox-gestuetzte-Secure-Development-Haertung.md) | — (Root / keine direkte Abhängigkeit) | — (kein Spec-Kit-Feature / no Spec Kit feature) |
| 12 | Completed | [Lastenheft_RL-SE-Checklist-Selbstpruefung.004-rl-se-self-assessment.md](requirements/intakes/active/Lastenheft_RL-SE-Checklist-Selbstpruefung.004-rl-se-self-assessment.md) | — (Root / keine direkte Abhängigkeit) | [004-rl-se-self-assessment](specs/004-rl-se-self-assessment/) |
| 13 | Completed | [Lastenheft_GSDB-Spec-Kit-Intensivpruefung.005-gsdb-intensive-review.md](requirements/intakes/active/Lastenheft_GSDB-Spec-Kit-Intensivpruefung.005-gsdb-intensive-review.md) | — (Root / keine direkte Abhängigkeit) | [005-gsdb-intensive-review](specs/005-gsdb-intensive-review/) |

Nur `Eligible` bezeichnet die bevorzugte nächste Ausführung. `Pending` oder
`Blocked` erteilen keine automatische Ausführungsberechtigung.

*Only `Eligible` identifies the preferred next execution. `Pending` and
`Blocked` grant no automatic execution authority.*
