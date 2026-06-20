# Lastenheft: Didactic Inline Code Comment Hardening fuer TinyCalc

**Dokument-Status:** Spec-Kit-Eingabedatei, bereit fuer `/speckit-specify`  
**Erstellt:** 2026-06-05  
**Betrifft:** `src/`, relevante TUI-/Engine-Test-Helfer in `tests/`, sowie Evidence-/Guide-Oberflaechen, wenn sie durch den Lauf beruehrt werden.

## 1. Ziel / Goal

Deutsch:
TinyCalc ist ein Lernprojekt fuer Tabellenkalkulationslogik und TUI-Bedienung. XML-Kommentare bleiben die primaere API- und DocFX-Erklaerung. Dieses Lastenheft ergaenzt kurze Code-nahe Kommentare dort, wo Lernende oder Maintainer sonst nicht erkennen, warum eine Engine-, Formel-, Recalc-, Textoverflow- oder TUI-Entscheidung so umgesetzt wurde.

English:
TinyCalc is a learning project for spreadsheet logic and TUI interaction. XML comments remain the primary API and DocFX explanation. This requirements document adds short code-near comments where learners or maintainers would otherwise not see why an engine, formula, recalculation, text-overflow, or TUI decision was implemented in that way.

## 2. Scope

In Scope:
- Formula-, Cell-, Recalc-, Textoverflow- und Range-Flows;
- TUI-Interaktionspfade und Status-/Fehlergrenzen;
- Test-Helfer fuer Engine- und TUI-Proofs;
- vorhandene Kommentare, die im geprueften Bereich veraltet, trivial oder irrefuehrend sind.

Out of Scope:
- keine Runtime-Verhaltensaenderung;
- keine neue Tabellenkalkulationsfunktion;
- keine breite TUI-Migration;
- keine flaechenhafte Kommentierung jeder Methode;
- keine DocFX-Regeneration, solange nur `//`- oder `/* */`-Kommentare ohne XML-Kommentar- oder API-Aenderung betroffen sind.

## 3. Kommentar-Intensitaet

- 1 bis 3 Zeilen vor einem nicht-trivialen Block reichen im Regelfall.
- Mehrzeilig nur bei komplexen Engine-/TUI-Flows, historischen Calc-Abweichungen, Sicherheits-/A11Y-Randbedingungen oder Test-Proof-Pfaden.
- Kommentare erklaeren Warum, Trade-off, Randbedingung, historische Abweichung oder Proof-Grenze.
- Keine Kommentare, die nur offensichtlichen Code nacherzaehlen.
- German-first/English-second und CEFR-B2 fuer didaktische Erklaerbloecke.

## 4. Review-Modell

- `CommentAdequate`: vorhandene Kommentare reichen.
- `CommentNeeded`: nicht-triviale Logik braucht eine kurze didaktische Erklaerung.
- `NoCommentNeeded`: Code ist selbsterklaerend; ein Kommentar waere Rauschen.
- `UpdateExistingComment`: vorhandener Kommentar ist veraltet oder zu ungenau.
- `FollowUpHardening`: beim Review wurde ein echtes Code-, Test- oder Architekturproblem sichtbar, das nicht in diesen Kommentar-Lauf gehoert.

## 5. Akzeptanzkriterien

- Feature-Evidence dokumentiert gepruefte Dateien oder Flow-Bereiche, Entscheidung, Kommentarbedarf, Aenderung und Follow-up-Grenzen.
- Neue oder geaenderte didaktische Kommentare bleiben kurz und fachlich nuetzlich.
- Veraltete Kommentare in geprueften Bereichen werden aktualisiert oder entfernt.
- Agent-Guidance haelt die Regel fuer kuenftige neue oder geaenderte nicht-triviale Logik fest.
- XML-Kommentar- oder API-Aenderungen ziehen den normalen DocFX-/A11Y-Nachweispfad nach sich.

## 6. Kopierbarer `/speckit-specify`-Prompt

```text
/speckit-specify Nutze Lastenheft_Didactic-Inline-Code-Comment-Hardening.md als verbindliche Eingabedatei. Erstelle die Feature-Spezifikation fuer einen didaktischen Inline-Code-Kommentar-Hardening-Lauf in TinyCalc.

Ziel: Zentrale TinyCalc-Engine-, Formula-, Recalc-, Textoverflow-, TUI- und Test-Helfer-Flows muessen fuer Auszubildende und Maintainer besser nachvollziehbar werden. XML-Kommentare bleiben die primaere API-/DocFX-Erklaerung; dieser Lauf ergaenzt nur Code-nahe didaktische Kommentare bei nicht-trivialer Logik.

Wichtig:
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
