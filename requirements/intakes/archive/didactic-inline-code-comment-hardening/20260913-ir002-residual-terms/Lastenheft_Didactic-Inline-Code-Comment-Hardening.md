<!-- intake-authoring:begin -->
# Lastenheft: Didactic Inline Code Comment Hardening fuer TinyCalc

**Dokument-Status:** Spec-Kit-Eingabedatei, bereit fuer `/speckit-specify`\
**Erstellt:** 2026-06-05\
**Betrifft:** `src/`, relevante TUI-/Engine-Test-Helfer in `tests/`, sowie Evidence-/Guide-Oberflaechen, wenn sie durch den Lauf beruehrt werden.

## 1. Ziel / Goal

Deutsch:
TinyCalc ist ein Lernprojekt fuer Tabellenkalkulationslogik und TUI-Bedienung. XML-Kommentare bleiben die primaere API- und DocFX-Erklaerung. Dieses Lastenheft ergaenzt kurze Code-nahe Kommentare dort, wo Lernende oder Maintainer sonst nicht erkennen, warum eine Engine-, Formel-, Recalc-, Textoverflow- oder TUI-Entscheidung so umgesetzt wurde.

English:
TinyCalc is a learning project for spreadsheet logic and TUI interaction. XML comments remain the primary API and DocFX explanation. This requirements document adds short code-near comments where learners or maintainers would otherwise not see why an engine, formula, recalculation, text-overflow, or TUI decision was implemented in that way.

## 2. Vorkenntnisse und Begriffe / Prior Knowledge and Terms

Deutsch:
Lernende sollen einfache C#-Methoden, Bedingungen und Schleifen lesen koennen. Spezielle Vorkenntnisse ueber Tabellenkalkulations-Engines, Terminal.Gui oder DocFX sind nicht erforderlich. Die folgenden Begriffe gelten im weiteren Dokument:

- Eine **Zelle (Cell)** ist ein einzelnes Feld der Tabelle. Sie kann Text, eine Zahl oder eine Formel enthalten.
- Eine **Formel (Formula)** ist ein Ausdruck in einer Zelle, der aus Werten oder anderen Zellen ein Ergebnis berechnet.
- **Neuberechnung (Recalc)** bedeutet, dass TinyCalc Formeln nach einer Aenderung erneut auswertet und abhaengige Ergebnisse aktualisiert.
- **Textueberlauf (Textoverflow)** bedeutet, dass langer Zelltext optisch in freie Nachbarzellen hineinragt, ohne deren gespeicherten Inhalt zu veraendern.
- Ein **Bereich (Range)** ist eine zusammenhaengende Gruppe von Zellen.
- **XML-Kommentare** sind strukturierte C#-Dokumentationskommentare fuer oeffentliche APIs. **DocFX** erzeugt daraus die API-Dokumentation.
- Eine **TUI** ist eine textbasierte Benutzeroberflaeche im Terminal.
- Ein **Proof-Pfad** ist der dokumentierte Test- oder Evidence-Weg, mit dem eine Aussage nachvollziehbar belegt wird.

English:
Learners should be able to read simple C# methods, conditions, and loops. No specialist knowledge of spreadsheet engines, Terminal.Gui, or DocFX is required. The following terms apply throughout this document:

- A **cell** is one field in the spreadsheet. It can contain text, a number, or a formula.
- A **formula** is an expression in a cell that calculates a result from values or other cells.
- **Recalculation (Recalc)** means that TinyCalc evaluates formulas again after a change and updates dependent results.
- **Text overflow** means that long cell text is displayed across empty neighbouring cells without changing their stored content.
- A **range** is a connected group of cells.
- **XML comments** are structured C# documentation comments for public APIs. **DocFX** uses them to generate the API documentation.
- A **TUI** is a text-based user interface in a terminal.
- A **proof path** is the documented test or evidence route that makes a statement verifiable.

## 3. Scope

Deutsch - im Scope:
- Formula-, Cell-, Recalc-, Textoverflow- und Range-Flows;
- TUI-Interaktionspfade und Status-/Fehlergrenzen;
- Test-Helfer fuer Engine- und TUI-Proofs;
- vorhandene Kommentare, die im geprueften Bereich veraltet, trivial oder irrefuehrend sind.

Deutsch - nicht im Scope:
- keine Runtime-Verhaltensaenderung;
- keine neue Tabellenkalkulationsfunktion;
- keine breite TUI-Migration;
- keine flaechenhafte Kommentierung jeder Methode;
- keine DocFX-Regeneration, solange nur `//`- oder `/* */`-Kommentare ohne XML-Kommentar- oder API-Aenderung betroffen sind.

English - in scope:
- formula, cell, recalculation, text-overflow, and range flows;
- TUI interaction paths and status or error boundaries;
- test helpers for engine and TUI proof paths;
- existing comments in the reviewed area that are outdated, trivial, or misleading.

English - out of scope:
- no runtime behaviour change;
- no new spreadsheet function;
- no broad TUI migration;
- no blanket commenting of every method;
- no DocFX regeneration while only `//` or `/* */` comments change and no XML comment or API changes are involved.

## 4. Kommentar-Intensitaet / Comment Intensity

Deutsch:
- 1 bis 3 Zeilen vor einem nicht-trivialen Block reichen im Regelfall.
- Mehrzeilig nur bei komplexen Engine-/TUI-Flows, historischen Calc-Abweichungen, Sicherheits-/A11Y-Randbedingungen oder Test-Proof-Pfaden.
- Kommentare erklaeren Warum, Trade-off, Randbedingung, historische Abweichung oder Proof-Grenze.
- Keine Kommentare, die nur offensichtlichen Code nacherzaehlen.
- German-first/English-second und CEFR-B2 fuer didaktische Erklaerbloecke.

English:
- One to three lines before a non-trivial block are normally sufficient.
- Use more lines only for complex engine or TUI flows, historical Calc differences, security or accessibility constraints, or test proof paths.
- Comments explain why, a trade-off, a constraint, a historical difference, or a proof boundary.
- Do not add comments that only repeat obvious code.
- Use German first, English second, and CEFR B2 language for didactic explanation blocks.

## 5. Review-Modell / Review Model

Deutsch:
- `CommentAdequate`: vorhandene Kommentare reichen.
- `CommentNeeded`: nicht-triviale Logik braucht eine kurze didaktische Erklaerung.
- `NoCommentNeeded`: Code ist selbsterklaerend; ein Kommentar waere Rauschen.
- `UpdateExistingComment`: vorhandener Kommentar ist veraltet oder zu ungenau.
- `FollowUpHardening`: beim Review wurde ein echtes Code-, Test- oder Architekturproblem sichtbar, das nicht in diesen Kommentar-Lauf gehoert.

English:
- `CommentAdequate`: the existing comments are sufficient.
- `CommentNeeded`: non-trivial logic needs a short didactic explanation.
- `NoCommentNeeded`: the code is self-explanatory, so a comment would add noise.
- `UpdateExistingComment`: an existing comment is outdated or too imprecise.
- `FollowUpHardening`: the review exposed a real code, test, or architecture problem that is outside this comment-only run.

## 6. Akzeptanzkriterien / Acceptance Criteria

Deutsch:
- Das Lastenheft nennt die benoetigten Vorkenntnisse und erklaert seine Fachbegriffe vor ihrer normativen Verwendung.
- Alle normativen Scope-, Review- und Abnahmeregeln liegen gleichwertig auf Deutsch und Englisch vor.
- Feature-Evidence dokumentiert gepruefte Dateien oder Flow-Bereiche, Entscheidung, Kommentarbedarf, Aenderung und Follow-up-Grenzen.
- Neue oder geaenderte didaktische Kommentare bleiben kurz und fachlich nuetzlich.
- Veraltete Kommentare in geprueften Bereichen werden aktualisiert oder entfernt.
- Agent-Guidance haelt die Regel fuer kuenftige neue oder geaenderte nicht-triviale Logik fest.
- XML-Kommentar- oder API-Aenderungen ziehen den normalen DocFX-/A11Y-Nachweispfad nach sich.

English:
- The requirements document states the required prior knowledge and explains specialist terms before using them normatively.
- All normative scope, review, and acceptance rules are equivalent in German and English.
- Feature evidence records the reviewed files or flow areas, the decision, the comment need, the change, and follow-up boundaries.
- New or changed didactic comments remain short and technically useful.
- Outdated comments in reviewed areas are updated or removed.
- Agent guidance retains the rule for future new or changed non-trivial logic.
- XML comment or API changes trigger the normal DocFX and accessibility evidence path.

## 7. Kopierbarer `/speckit-specify`-Prompt

```text
Ersetzter Alt-Prompt: speckit-specify Nutze requirements/intakes/active/Lastenheft_Didactic-Inline-Code-Comment-Hardening.md als verbindliche Eingabedatei. Erstelle die Feature-Spezifikation fuer einen didaktischen Inline-Code-Kommentar-Hardening-Lauf in TinyCalc.

Ziel: Zentrale TinyCalc-Engine-, Formula-, Recalc-, Textoverflow-, TUI- und Test-Helfer-Flows muessen fuer Auszubildende und Maintainer besser nachvollziehbar werden. XML-Kommentare bleiben die primaere API-/DocFX-Erklaerung; dieser Lauf ergaenzt nur Code-nahe didaktische Kommentare bei nicht-trivialer Logik.

Wichtig:
- Vorkenntnisse und die Begriffe Formula, Cell, Recalc, Textoverflow, Range, XML-Kommentar, DocFX, TUI und Proof-Pfad fuer Lernende vor ihrer normativen Verwendung erklaeren.
- Normative Scope-, Review- und Akzeptanzregeln gleichwertig auf Deutsch und Englisch festhalten.
- Keine Runtime-Verhaltensaenderung, keine neue Tabellenkalkulationsfunktion, keine breite TUI-Migration und kein globales "jede Methode kommentieren".
- Kommentarintensitaet moderat halten: 1 bis 3 Zeilen vor nicht-trivialen Blocks; mehrzeilig nur bei komplexen Flows, historischen Abweichungen, Sicherheits-/A11Y-Randbedingungen oder Test-Proof-Pfaden.
- Kommentare muessen Warum, Trade-off, Randbedingung, historische Abweichung oder Proof-Grenze erklaeren, nicht triviales Was.
- Review-Modell aufnehmen: `CommentAdequate`, `CommentNeeded`, `NoCommentNeeded`, `UpdateExistingComment`, `FollowUpHardening`.
- Mindestens pruefen: Formula-, Cell-, Recalc-, Textoverflow-, Range-, TUI-Interaktions- und Engine-/TUI-Test-Helfer-Flows.
- Wenn XML-Kommentare oder API-Signaturen beruehrt werden, gilt der normale DocFX-/A11Y-Nachweispfad; reine `//`- oder `/* */`-Kommentarhaertung loest keinen DocFX-Zwang aus.
```

---

## Spec-Kit-Intake-Reife / Spec Kit Intake Readiness

Dieses Lastenheft enthaelt bereits einen kopierbaren `/speckit-specify`-Prompt. Vor dem Start muss der aktuelle Repository-Stand trotzdem geprueft werden. Bereits erledigte oder branch-suffig archivierte Punkte werden nicht erneut umgesetzt; offene Punkte werden als `Applicable`, `AlreadySatisfied`, `N/A`, `Open` oder `FollowUp` klassifiziert.

*This requirements document already contains a copyable `/speckit-specify` prompt. Before starting, still check the current repository state. Completed or branch-suffixed archived items are not implemented again; open items are classified as `Applicable`, `AlreadySatisfied`, `N/A`, `Open`, or `FollowUp`.*
<!-- intake-authoring:prompts -->
## Kopierbare Spec-Kit-Prompts / Copy-Ready Spec Kit Prompts

Die folgenden Alternativen starten keinen Lauf automatisch. Der autonome
Prompt ist auf `LocalImplementation` begrenzt und erteilt keine Remote-,
PR-, Merge-, Bypass-, Secret- oder Provider-Berechtigung.

*The alternatives below do not start a run automatically. The autonomous
prompt is limited to `LocalImplementation` and grants no remote,
pull-request, merge, bypass, secret, or provider authority.*

### Specify

<!-- spec-kit-command-id: speckit.specify -->
```text
$speckit-specify Use requirements/intakes/active/Lastenheft_Didactic-Inline-Code-Comment-Hardening.md as the binding intake. Preserve its scope, non-goals, ordering, governance, evidence, and acceptance criteria. Create or update only the matching feature specification. Do not implement, commit, push, create a pull request, merge, or start another feature.
```

### Autonomous

<!-- spec-kit-command-id: speckit.autonomous -->
```text
$speckit-autonomous Execute one complete autonomous Spec Kit run using requirements/intakes/active/Lastenheft_Didactic-Inline-Code-Comment-Hardening.md as the binding intake. Delivery mode: LocalImplementation. Preserve all scope, ordering, security, accessibility, evidence, and acceptance boundaries. Do not push, create or merge a pull request, use bypass authority, expose secrets, or start a follow-up feature.
```
<!-- intake-authoring:end -->
