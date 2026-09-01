# TinyCalc Intake-Reihenfolge / Intake Order

Diese Ansicht wird aus der kanonischen Intake-Serie abgeleitet. Verbindliche
Maschinendaten stehen in
`requirements/intakes/series/tinycalc-delivery/manifest.json`.

*This view is derived from the canonical intake series. Binding machine data
lives in the series manifest.*

| Rang | Intake | Zustand | Abhängigkeit |
|---:|---|---|---|
| 1 | `requirements/intakes/active/Lastenheft_Constitution_Change.002-constitution-change.md` | `Completed` | keine |
| 2 | `requirements/intakes/active/Lastenheft_TerminalGui_Migration.003-terminalgui-migration.md` | `Completed` | Constitution abgeschlossen |
| 3 | `requirements/intakes/active/Lastenheft_TUI-Funktionsabnahme-und-Regressionsvertrag.md` | `Eligible` | Terminal.Gui-Migration abgeschlossen |
| 4 | `requirements/intakes/active/Lastenheft_A11Y_TUI.md` | `Blocked` | vollständige Funktionsabnahme |
| 5 | `requirements/intakes/active/Lastenheft_Rename_MicroCalc_TinyCalc.md` | `Blocked` | A11Y-Abnahme |
| 6 | `requirements/intakes/active/Lastenheft_Didactic-Inline-Code-Comment-Hardening.md` | `Blocked` | Rename |
| 7 | `requirements/intakes/active/Lastenheft_Secure-Development-Hardening.md` | `Blocked` | Kommentarhärtung |
| 8 | `requirements/intakes/active/Lastenheft_PL0-Zellfunktionen_V1.md` | `Blocked` | Security und TinyPl0-NuGet-Liefergate |
| 9 | `requirements/intakes/active/Lastenheft_Legacy-Kompatibilitaet_V1.md` | `Blocked` | PL/0-Erweiterung |
| 10 | `requirements/intakes/active/Lastenheft_Formelkopie-und-Tabellenoperationen_V1.md` | `Blocked` | Legacy-Kompatibilität |
| 11 | `requirements/intakes/active/Lastenheft_Sandbox-gestuetzte-Secure-Development-Haertung.md` | `Pending` | unabhängige Wurzel |
| 12 | `requirements/intakes/active/Lastenheft_RL-SE-Checklist-Selbstpruefung.md` | `Pending` | unabhängige Wurzel |
| 13 | `requirements/intakes/active/Lastenheft_GSDB-Spec-Kit-Intensivpruefung.md` | `Pending` | unabhängige Wurzel |

Nur der explizite Zustand `Eligible` bezeichnet die bevorzugte nächste
Ausführung. `Pending` erteilt keine automatische Ausführungsberechtigung.

*Only the explicit `Eligible` state identifies the preferred next execution.
`Pending` does not grant automatic execution authority.*
