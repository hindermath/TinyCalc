# US2: lokale Befehls-, Datei- und Dialogwege / Local commands, files and dialogs

## Vollständiger nativer Abschluss / Complete native closeout

11.10.2026: Die [unveränderte Prüfserie 737348d](delivery-closeout.md) belegt
alle 92 US2-Pfade separat auf macOS, Linux und Windows, insgesamt 276 Tupel.
Die Originale enthalten Datei-/Blattintegrität, Zustand, sichtbare Meldungen
und Fokus; keine unbeabsichtigten Teilwirkungen. [Thorstens Abnahme](human-acceptance-20261011.md)
ersetzt keinen dieser automatisierten Pfade. Ältere lokale Open-Aussagen sind
historisch; finale Lieferhead-Bindung bleibt im Runtime-Nachweis erforderlich.

*Every full native run passes all 92 independent US2 paths, 276 tuples overall,
with file/state/focus integrity. Separate human acceptance is complete; original
and final delivery execution bindings remain distinct.*

## Deutscher Nachweis

Der [ungefilterte lokale Vollvertrag](platforms/macos/local-build105.md) enthält
alle 92 US2-Pfade: CMD 26, FILE 9, HELP 13, DIALOG 44. Eigene isolierte
Testfälle und Dateien prüfen jeden Alias sowie Erfolg/Abbruch/anwendbaren Fehler.
Die Resultate enthalten sichtbaren Dialog-/Raster-/Statustext, gespeicherte
Zellen und Fokus statt bloß behaupteter Funktionsnamen. Abbruch oder ungültiges
Load darf Blatt, Auswahl und AutoCalc nicht teilweise verändern.

Die ergänzende echte 80x24-PTY-Sitzung prüft Navigation, Recalculate-Palette,
Load/fehlende Datei und Hilfe. Sie ergänzt die typisierten 92 Pfadbelege, wird
aber nicht als zusätzlicher Pflichtpfad gezählt. Hilfedialoggröße, P/N und
Tab-Fokusumlauf waren echte rote Regressionen vor der Korrektur; Compiler-/
Fixturefehler wurden nicht als fachliches Rot verwendet. Die Hilfe benennt
historische Pascal-Seiten und aktuelle Portbedienung ausdrücklich getrennt.

T040 bleibt für die vollständige finale Plattform-/Versionsbindung offen.
Lokale unabhängige Testfälle sind keine unabhängige menschliche Produktabnahme;
VoiceOver und Owner-Abnahme bleiben getrennt. Keine neue Dateifunktion, kein
`.MCS`-Import, Paketupgrade oder Folgefeature.

## English evidence

The actual unfiltered macOS run contains all 92 US2 paths: 26 command, nine file,
13 help and 44 dialog paths. Isolated tests prove each contextual outcome with
visible text, stored state and focus, preserving integrity on cancellation/error.
An additional real 80x24 PTY session observes navigation, palette, load/error
and help without inflating the required-path denominator. Help-size/key/focus
regressions failed before their fixes; infrastructure errors are not product red.
T040 remains Open for final complete platform/version bindings. Human VoiceOver,
independent review and owner acceptance are separate obligations, not replaced
by automated tests or new features.
