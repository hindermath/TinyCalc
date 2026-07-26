# Abarbeitungsreihenfolge der Lastenhefte

Stand: 2026-06-19

## Zweck

Deutsch:
Diese Datei haelt die empfohlene Reihenfolge fest, in der die vorhandenen
Lastenhefte fuer spaetere Spec-Kit-Laeufe abgearbeitet werden sollen. Sie ist
ein Vorbereitungs- und Orientierungsdokument. Sie startet keinen Spec-Kit-Lauf
und ersetzt nicht die spaeteren `spec.md`, `plan.md` und `tasks.md`.

English:
This file records the recommended order for processing the existing
requirements documents in later Spec Kit runs. It is a preparation and
orientation document. It does not start a Spec Kit run and does not replace the
later `spec.md`, `plan.md`, and `tasks.md` files.

## Leitentscheidung

Deutsch:
Die Reihenfolge folgt drei Regeln: Erst werden Governance-Regeln stabilisiert,
dann werden grosse technische und mechanische Aenderungen erledigt, und erst
danach folgen Qualitaets-, A11Y-, Kommentar- und Sicherheitspruefungen. So
werden spaetere Nachweise auf einem stabilen Projektstand erstellt.

English:
The order follows three rules: first stabilize governance rules, then complete
large technical and mechanical changes, and only then run quality, accessibility,
comment, and security reviews. This keeps later evidence based on a stable
project state.

## Empfohlene Reihenfolge

| Nr. | Lastenheft | Empfohlener Lauf | Begruendung |
|---:|---|---|---|
| 1 | `Lastenheft_Constitution_Change.md` | Governance- und Constitution-Lauf | Dieser Lauf setzt die Regeln fuer Bilingualitaet, CEFR-B2, XML-Dokumentation, DocFX und TDD. Diese Regeln sollen alle folgenden Spec-Kit-Laeufe bereits kennen. |
| 2 | `Lastenheft_TerminalGui_Migration.md` | Technischer TUI-Migrationslauf | Die Migration auf Terminal.Gui 2.x ist technische Grundlage fuer Teile der A11Y-Anforderungen und sollte vor dem grossen Rename erfolgen, damit Konflikte klein bleiben. |
| 3 | `Lastenheft_Rename_MicroCalc_TinyCalc.md` | Mechanischer Rename-Lauf | Der Rename ist breit und betrifft Solution, Projekte, Namespaces, CI und Dokumentation. Danach arbeiten alle spaeteren Laeufe mit stabilen TinyCalc-Namen. |
| 4 | `Lastenheft_A11Y_TUI.md` | TUI-A11Y-Lauf | Die A11Y-Arbeit baut auf der Terminal.Gui-Migration auf und profitiert davon, dass der Rename bereits abgeschlossen ist. Sichtbares Textfeedback, Shortcuts, Hilfe und Kontrastpruefung sollen danach auf dem finalen Namenstand erfolgen. |
| 5 | `Lastenheft_Didactic-Inline-Code-Comment-Hardening.md` | Didaktischer Kommentar-Hardening-Lauf | Dieser Lauf sollte nach den groesseren Code- und TUI-Aenderungen erfolgen, damit Kommentare nicht kurz danach durch Migration, Rename oder A11Y-Arbeit veralten. |
| 6 | `Lastenheft_Secure-Development-Hardening.md` | Querschnittlicher Security-Hardening-Lauf | Dieser Lauf prueft Governance, Code, TUI, A11Y, Tests, CI, Dokumentation und Supply Chain. Er sollte als zusammenfassende Haertung nach den vorherigen Umstellungen laufen. |

## Abhaengigkeiten

Deutsch:
`Lastenheft_Constitution_Change.md` steht bewusst an erster Stelle, weil es die
Regeln fuer die weiteren Laeufe schaerft. `Lastenheft_TerminalGui_Migration.md`
muss vor dem vollstaendigen A11Y-Lauf liegen. `Lastenheft_Rename_MicroCalc_TinyCalc.md`
soll nach der TUI-Migration, aber vor A11Y-, Kommentar- und Security-Laeufen
kommen. Der Security-Hardening-Lauf steht am Ende, weil er die Ergebnisse der
anderen Laeufe als Pruefgrundlage nutzen soll.

English:
`Lastenheft_Constitution_Change.md` is intentionally first because it sharpens
the rules for the later runs. `Lastenheft_TerminalGui_Migration.md` must happen
before the complete accessibility run. `Lastenheft_Rename_MicroCalc_TinyCalc.md`
should happen after the TUI migration, but before accessibility, comment, and
security runs. The security hardening run is last because it should use the
results of the other runs as review input.

## Hinweise fuer spaetere Spec-Kit-Laeufe

Deutsch:
Vor jedem einzelnen Lauf ist das jeweilige Lastenheft erneut gegen den aktuellen
Repository-Stand zu pruefen. Wenn der Rename bereits abgeschlossen ist, muessen
noch vorhandene historische `MicroCalc`-Pfadangaben im Eingabe-Lastenheft auf
den dann gueltigen TinyCalc-Stand uebertragen werden. Nach erfolgreicher
Umsetzung eines dedizierten Feature-Branches gilt die lokale Regel zur
Rueckverfolgbarkeit: Das umgesetzte Lastenheft wird mit dem Feature-Branch-
Suffix umbenannt.

English:
Before each individual run, re-check the selected requirements document against
the current repository state. If the rename has already been completed, any
remaining historical `MicroCalc` path references in the input document must be
translated to the then-current TinyCalc state. After a dedicated feature branch
has implemented a requirements document, the local traceability rule applies:
rename the implemented requirements document with the feature-branch suffix.

## Nicht-Ziele

Deutsch:
Diese Datei erzeugt keine Branches, keine Specs, keine Tasks, keine Tests und
keine Implementierung. Sie legt nur die Abarbeitungsreihenfolge fest.

English:
This file creates no branches, specs, tasks, tests, or implementation changes.
It only records the processing order.
