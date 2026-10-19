# macOS-PTY: gezielte Korrektur / Targeted correction

Documentation Impact: `UpdateRequired`. Owner: @hindermath.

## Deutsch

Auftrag: Testpfad diagnostizieren und ohne abgeschwaechte Tests reparieren;
kein Feature-007-Start und keine Produktimplementierung. Ausgang: sechs
fehlende erste Titel-Snapshots und ein QuitTimeout in der vollstaendigen Suite.
Die Rohtraces enthielten spaeter den Titel: Eingaben und Snapshots konnten
vor dem fertigen Startbild erfolgen.

Der Expect-Adapter wartet jetzt auf ausdrueckliche, frische Zustandsmarker
fuer Grid, Editor und Commit. Nur fuer diese Bereitschaftserkennung werden
SGR-Farbsequenzen ausgeblendet. Rohtraces und Snapshots werden nicht veraendert.
Ein Snapshot darf nicht mit einem unvollstaendigen UTF-8-Zeichen oder einer
unvollstaendigen ANSI-Sequenz enden. Terminalabfragen besitzen einen getrennten
Suchcursor, damit sie den Frischecursor nicht ueberschreiben. Der bestehende
Accessibility-Ablauf navigiert nach B1; seine Editor-/Commit-Bereitschaft wird
deshalb ausdruecklich an B1 gebunden, der Standardablauf weiterhin an A1.

Unveraendert: Produktquellen, `TuiTerminalContractTests.cs`,
`TuiLifecycleContractTests.cs`, strikte UTF-8-Decodierung, Bildschirm-/Kontrast-
und Restore-Orakel, Trace-Obergrenze sowie aeussere 25-/30-Sekunden-Limits.
Interaktion wird innerhalb dieser Grenzen auf 20/25 Sekunden begrenzt;
Bereitschaftswarten maximal acht Sekunden, auf das gemeinsame Budget gekappt.
Es gibt keine Testfilter in der abschliessenden Produktsuite.

Neue synthetische Adaptertests pruefen verspaeteten Start/Commit, farbig
getrennten Menutext und fragmentiertes UTF-8. Sechs Negativfaelle muessen
Nonzero und `PTY_CAPTURE_FAIL:` liefern: fehlendes Grid, fehlender Wert,
fruehes Prozessende, fehlerhafter Exit, unvollstaendiges UTF-8 und ANSI.
Die synthetische Bash-Fixture deaktiviert XON/XOFF, damit Ctrl-Q den eigenen
Prozess erreicht. Sie ersetzt keinen Produktnachweis und erzeugt keinen
`ExecutedPathProof`.

Nachweise: korrigierter roter Fixture-Lauf 2 bestanden/3 fehlgeschlagen mit
altem Adapter; weitere Entwicklungslaeufe deckten SGR- und UTF-8-Grenzen auf.
Diese Fehler werden nicht als Pass gewertet. Abschliessender gezielter Lauf:
21/21 bestanden. Vollstaendiger ungefilterter Lauf: 217 Core + 461 TUI,
0 Fehler/Skips. Unveraenderter nativer Sammler: 364 macOS-Pfade, Exit 0.
Smoke: `SMOKE_OK`. Linux-/Windows-PTY, VoiceOver und Braille wurden hier nicht
abgenommen. CI bleibt ein eigener Liefergate.

Dokumentation: vorhandenes gepinntes DocFX 2.81.0 erzeugt HTML ohne API-
Metadatengenerierung, Exit 0. Vier betroffene Seiten wurden mit Chrome,
Playwright/axe 4.14.0 geprueft: keine gemeldeten Verstoesse, `lang=de`, ein
Main-Landmark, benannter erster Tastaturfokus. Textorientierter lynx-Smoke
prueft diese Diagnose. `color-contrast` sowie teilweise `link-in-text-block`
bleiben Incomplete, keine Gesamt-WCAG-/Screenreader-Abnahme.

## English

Explicitly authorized test-infrastructure repair only; no product change or
Feature 007 execution. The first full suite exposed early grid snapshots and a
quit timeout. Raw traces showed later startup output. Replace blind startup
sleep with fresh, explicit grid/editor/commit readiness, without changing raw
captures. Ignore SGR only for readiness; require complete UTF-8 and ANSI tails.
Separate terminal-query and freshness cursors. Bind the existing navigation
scenario to its selected B1 cell, while standard interaction remains at A1.

Preserve original product tests, strict decoding, screen/contrast/restoration
assertions, trace cap and 25/30-second hard limits. Internal interaction budgets
are 20/25 seconds, individual readiness waits at most eight and clipped to the
shared budget. Added synthetic cases cover delayed/fragmented output and six
mandatory nonzero failure modes; they are not product-path evidence.

Keep the valid initial red fixture result (two pass, three fail) and subsequent
development failures distinct from successful validation. Final focused run:
21 pass. Subsequent unfiltered product run: 217 Core and 461 TUI pass, no
failures/skips. The unchanged native collector binds 364 macOS paths, exit zero;
noninteractive smoke succeeds. Other platforms, native readers and human
acceptance remain separate gates. No validator or existing oracle is weakened.

Pinned DocFX 2.81.0 builds HTML only, exit zero. Four changed pages receive
Chrome/Playwright/axe 4.14.0 checks: no reported violations, German page
language, one main landmark and named first keyboard focus. A UTF-8 lynx smoke
checks this diagnosis. Contrast and some link-in-text checks remain incomplete;
no full WCAG or native-reader acceptance is claimed.
