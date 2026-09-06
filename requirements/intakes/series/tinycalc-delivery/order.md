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
| 3 | `requirements/intakes/active/Lastenheft_TUI-Funktionsabnahme-und-Regressionsvertrag.md` | `Pending` | Terminal.Gui-Migration abgeschlossen; Feldtest ausstehend |
| 4 | `requirements/intakes/active/Lastenheft_A11Y_TUI.md` | `Blocked` | vollständige Funktionsabnahme |
| 5 | `requirements/intakes/active/Lastenheft_Rename_MicroCalc_TinyCalc.md` | `Blocked` | A11Y-Abnahme |
| 6 | `requirements/intakes/active/Lastenheft_Didactic-Inline-Code-Comment-Hardening.md` | `Blocked` | Rename |
| 7 | `requirements/intakes/active/Lastenheft_Secure-Development-Hardening.md` | `Blocked` | Kommentarhärtung |
| 8 | `requirements/intakes/active/Lastenheft_PL0-Zellfunktionen_V1.md` | `Blocked` | Security und TinyCalc-Preflight |
| 9 | `requirements/intakes/active/Lastenheft_Legacy-Kompatibilitaet_V1.md` | `Blocked` | PL/0-Erweiterung |
| 10 | `requirements/intakes/active/Lastenheft_Formelkopie-und-Tabellenoperationen_V1.md` | `Blocked` | Legacy-Kompatibilität |
| 11 | `requirements/intakes/active/Lastenheft_Sandbox-gestuetzte-Secure-Development-Haertung.md` | `Pending` | unabhängige Wurzel |
| 12 | `requirements/intakes/active/Lastenheft_RL-SE-Checklist-Selbstpruefung.004-rl-se-self-assessment.md` | `Completed` | unabhängige Wurzel |
| 13 | `requirements/intakes/active/Lastenheft_GSDB-Spec-Kit-Intensivpruefung.005-gsdb-intensive-review.md` | `Completed` | unabhängige Wurzel |

Nur ein ausdrücklich gesetzter Zustand `Eligible` bezeichnet eine bevorzugte
nächste Ausführung. Nach dem GSDB-Abschluss ist kein Ziel ausgewählt;
`Pending` erteilt keine automatische Ausführungsberechtigung.

*Only an explicitly assigned `Eligible` state identifies a preferred next
execution. No target is selected after GSDB closeout; `Pending` does not grant
automatic execution authority.*
