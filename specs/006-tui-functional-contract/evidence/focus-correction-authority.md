# Eng begrenzte Fokuskorrektur / Narrow focus correction

## Deutsch

Am 2026-10-10 genehmigte Thorsten im laufenden Implementierungsauftrag ausdrücklich:
„Ja, eng begrenzte Vertragskorrektur genehmigt“.

Die gestellte Frage beschränkte die Änderung auf fehlerhafte Fokusangaben im generierten Produktvertrag: Editor bestätigt/abgebrochen → Grid; Zellprüfung nach Eingabe → Grid; Smoke ohne UI → Terminal. Intake-Anforderungen, Pfade, Prüfschärfe und Belege bleiben erhalten. Dies ist keine Freigabe für weitere Orakeländerungen.

Revision 2 korrigiert ausschließlich `focusAfter` für die 13 `CELL`-Pfade, die vier `DIALOG-editor-*`-Pfade, `EDIT-slash-division` und `APP-smoke-ok`/`APP-smoke-fail`: insgesamt 20 Pfade. Die übrigen Fachwerte, 17 Familien, 364 Pfade und 1092 Plattformtupel bleiben unverändert. Revision 1 bleibt über den Historienanker nachvollziehbar.

Die echten UI-/CLI-Tests erfüllten ihre unabhängigen Fachassertions bereits vor der Korrektur. Ihre Belegpublikation scheiterte an den widersprüchlichen Fokusvorgaben. Die Korrektur ersetzt weder einen roten Produkttest noch eine Plattformabnahme. Terminal-Wiederherstellung ist nicht Teil dieser Freigabe.

Die Historienprüfung verlangt nun auch für Fokusänderungen eine verifizierte `BreakingChange`-Freigabe. Der neue Negativtest schlug vor dieser Korrektur fachlich fehl (`history-focus-without-authority`); er darf danach nicht mehr passieren.

## English

On 2026-10-10 Thorsten explicitly approved the narrow contract correction in the active implementation conversation. The approval covers incorrect generated focus expectations only: confirmed/cancelled editor and completed cell input return to Grid; non-interactive smoke returns to Terminal.

Revision 2 changes only `focusAfter` for 13 CELL paths, four editor-dialog paths, the division-editor path and two smoke paths: 20 paths. Business values, 17 families, 364 paths and 1092 platform tuples remain unchanged. The historical revision remains traceable. There is no permission to change other oracles or terminal-restoration requirements.

Independent real UI/CLI assertions already passed before this correction; publication failed on inconsistent focus expectations. This is neither product-red evidence nor platform acceptance. History validation now requires verified change authority for focus changes too; its new negative test failed before the validator fix.
