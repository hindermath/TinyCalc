# TinyCalc Intake-Reihenfolge / Intake Order

Diese Ansicht wird aus der kanonischen Intake-Serie abgeleitet. Verbindliche
Maschinendaten stehen in
`requirements/intakes/series/tinycalc-delivery/manifest.json`.

*This view is derived from the canonical intake series. Binding machine data
lives in the series manifest.*

| Rang | Intake | Zustand | Abhängigkeit |
|---:|---|---|---|
| 1 | `requirements/intakes/active/Lastenheft_Constitution_Change.002-constitution-change.md` | `Eligible` | keine |
| 2 | `requirements/intakes/active/Lastenheft_TerminalGui_Migration.md` | `Blocked` | Constitution |
| 3 | `requirements/intakes/active/Lastenheft_Rename_MicroCalc_TinyCalc.md` | `Blocked` | Terminal.Gui |
| 4 | `requirements/intakes/active/Lastenheft_A11Y_TUI.md` | `Blocked` | Rename |
| 5 | `requirements/intakes/active/Lastenheft_Didactic-Inline-Code-Comment-Hardening.md` | `Blocked` | A11Y |
| 6 | `requirements/intakes/active/Lastenheft_Secure-Development-Hardening.md` | `Blocked` | Kommentarhärtung |
| 7 | `requirements/intakes/active/Lastenheft_PL0-Zellfunktionen_V1.md` | `Blocked` | Security und TinyPl0-NuGet-Liefergate |
| 8 | `requirements/intakes/active/Lastenheft_Sandbox-gestuetzte-Secure-Development-Haertung.md` | `Pending` | unabhängige Wurzel |
| 9 | `requirements/intakes/active/Lastenheft_RL-SE-Checklist-Selbstpruefung.md` | `Pending` | unabhängige Wurzel |
| 10 | `requirements/intakes/active/Lastenheft_GSDB-Spec-Kit-Intensivpruefung.md` | `Pending` | unabhängige Wurzel |

Nur der explizite Zustand `Eligible` bezeichnet die bevorzugte nächste
Ausführung. `Pending` erteilt keine automatische Ausführungsberechtigung.
