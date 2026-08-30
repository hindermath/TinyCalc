# Changed-Code-Coverage / Changed Code Coverage

## Werkzeug und Eingaben / Tool and Inputs

- Plattform / Platform: Darwin, macOS 26.6, `osx-arm64`
- Tool: Microsoft `dotnet-coverage`
  `18.8.0+b3b276016e7a6850f5636374a8385bfe45dcff6a`
- Quellpfad / Source path: `src/MicroCalc.Tui/Program.cs`
- Modus / Mode: sichere statische Managed-Initialisierung; dynamische und
  native Instrumentierung deaktiviert. / *Safe static managed initialisation;
  dynamic and native instrumentation disabled.*

Die vier Pflichtdateien aus T040 wurden zuerst exakt zusammengeführt:

```text
tests.coverage             82748 bytes  67e6dd98b52207a9bbd3e65e4d284264a9942cb10e042cef861b62c9657e0ecb
smoke.coverage             82714 bytes  fe69d93924806b5bf0c9851531234ec60c041f7959d756f8eafafa6f3e94f967
manual-menu.coverage       27915 bytes  673f22abee3604dc6b5881bed3ec9c4d7e4b6cdb9c81f084257c9e15f72c0854
manual-ctrlq.coverage      27915 bytes  6aa38d27ae232ec68458081a10f10daf1273b1100858df7bc0f31b06c689478e
terminalgui.cobertura.xml 163820 bytes  5d440dfec650baea6cde7ec98ff1f8dd9912fa7d58487cab1f28b9a857d321cf
```

*The four mandatory files were merged first with the exact T040 command. The
result is valid Cobertura and contains `MicroCalc.Tui.Program` and
`Program.cs`.*

## Deterministischer Schnitt / Deterministic Intersection

Vor dem in T063 vorgesehenen einzigen Feature-Commit zeigen `main` und `HEAD`
beide auf
`886a13f8866e79fe6c13e6e1227217294aabdee8`. Deshalb liefert der geforderte
Befehl
`git diff --unified=0 main...HEAD -- src/MicroCalc.Tui/Program.cs` zu diesem
Zeitpunkt nachweislich null Zeilen. Der inhaltlich identische, beabsichtigte
Commitstand wurde mit
`git diff --unified=0 main -- src/MicroCalc.Tui/Program.cs` aus dem Worktree
geschnitten. Nach T063 muss der Exact-Head-Schnitt dieselben Zahlen erneut
bestätigen; ein abweichender Wert invalidiert dieses Gate.

*Before the single required feature commit, main and HEAD are the same commit,
so the required exact-head command correctly returns zero lines. The intended
commit content is measured from the main-to-working-tree diff. After T063, the
exact-head diff must reproduce these counts or this gate becomes invalid.*

Das read-only PowerShell-Verfahren liest neue Zeilennummern aus den
`--unified=0`-Hunks. Leere Zeilen, Kommentarzeilen und reine Klammerzeilen
werden getrennt ausgeschlossen. Weitere nicht ausführbare Zeilen werden nur
ausgeschlossen, wenn Cobertura für sie keinen Sequence Point enthält. Der
Nenner besteht damit aus geänderten ausführbaren Zeilen. Eine Zeile zählt im
Zähler, wenn ihr zusammengeführter Cobertura-Hitwert größer null ist.

*The read-only PowerShell procedure parses added line numbers from zero-context
hunks. It excludes blank, comment-only, and bracket-only lines separately.
Other non-executable lines are excluded only when Cobertura has no sequence
point. A changed executable line is covered when its merged hit count is above
zero.*

### Erster Schnitt und Fail-Closed-Reaktion / Initial Cut and Fail-Closed Response

```text
Hinzugefügte Zeilen / added lines:                 141
Leer / blank:                                        3
Kommentar / comment-only:                           10
Nur Klammern / bracket-only:                         6
Ohne Sequence Point / no sequence point:            22
Ausführbarer Nenner / executable denominator:       100
Abgedeckter Zähler / covered numerator:              49
Ergebnis / result:                                49.0%
```

49 Prozent unterschritten die bindende 70-Prozent-Schranke. Der Befund blieb
sichtbar und löste ausschließlich eine zusätzliche echte PTY-Sitzung aus. Es
wurde keine FakeDriver-Abstraktion, Testquelle, Produktfunktion oder neue
Schicht ergänzt. / *The 49 percent result failed the binding floor and remained
visible. Remediation used only another real PTY session, with no FakeDriver,
test-source, product-feature, or architecture expansion.*

## Ergänzende echte PTY-Evidenz / Supplemental Real PTY Evidence

Die ergänzende Sitzung prüfte auf demselben Release-Stand vorhandene Pfade:
Editor aus bestehendem Inhalt mit sicherem Abbruch; Save-, Print-, Recalculate-,
AutoCalc-, Format- und Clear-Menüaktionen; Help-Aufbau, `N`-/`P`-Tasten,
Button-Fokus und Close; abschließend `Ctrl+Q`. Jeder schreibende Datei- oder
Formatdialog wurde vor einer dauerhaften Aktion abgebrochen. Exitcode war `0`,
Terminalmodi wurden wiederhergestellt, und die Original-TUI-DLL wurde danach
bytegenau auf SHA-256
`0d36bd68e97d1b6025254514d67c9ec3655af4501f58d3f4ea9688c3be6488a1`
zurückgesetzt.

*The supplemental real PTY exercised existing editor, menu, help, focus, and
quit paths. Every persistent file or format action was cancelled. The process
exited zero, restored the terminal, and the original DLL was restored
byte-for-byte.*

```text
manual-supplemental.coverage  27915 bytes  c6f88f16806c23d49f7b805b5808ae9414482f2abbcfef6840b36d9335ee5ad1
```

Die vier Pflichtdateien blieben enthalten; der zusätzliche manuelle Nachweis
wurde ergänzend zusammengeführt. Die finale Datei ist:

```text
terminalgui.cobertura.xml  163832 bytes  079724fba738bca09d365cdbdaa46c19efce33cf49cbfb27cb34a71011549b1c
```

## Finales Ergebnis / Final Result

```text
Hinzugefügte Zeilen / added lines:                 141
Leer / blank:                                        3
Kommentar / comment-only:                           10
Nur Klammern / bracket-only:                         6
Ohne Sequence Point / no sequence point:            22
Ausführbarer Nenner / executable denominator:       100
Abgedeckter Zähler / covered numerator:              82
Nicht abgedeckt / uncovered:                        18
Ergebnis / result:                                82.0%
Mindestschranke / minimum floor:                  70.0%  PASS
Ziel / target:                                    80.0%  PASS
```

Nicht abgedeckte ausführbare Zeilen / Uncovered executable lines:
`264, 267, 273, 276, 282, 285, 288, 330, 382, 389, 396, 473, 503, 504, 568,
569, 576, 577`.

Die Restzeilen betreffen alternative Command-Palette-Zweige, weitere Schritte
mehrteiliger Datei-/Formatdialoge und alternative Dialogabschluss-Handler. Die
bindende Schranke und das Ziel sind ohne Scope-Erweiterung erreicht. / *The
remaining lines are alternate command-palette branches, later prompt steps,
and alternate dialog completion handlers. Both floor and target pass without
expanding scope.*
