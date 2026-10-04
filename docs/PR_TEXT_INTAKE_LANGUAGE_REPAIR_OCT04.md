# Intake-Sprachverträge und Quellen-Lineage / Intake contracts and provenance

## Zusammenfassung, Problem und Scope

Der vollständige Serienreview fand sechs mittlere Befunde: unvollständige
englische Verträge und Erstgebrauchserklärungen sowie zwei veraltete
README-Quellbindungen. Thorsten genehmigte ausdrücklich die enge Reparatur
von acht Intakes, Archiv-/Lineage-/Seriennachweise und den vollständigen
Wiederholungsreview. Lieferung: MergeAndSync, Admin-Bypass nur für formale
Merge-Regeln. Kein neuer Feature-Lauf, keine Produkt-/UI-/API-/CI-Änderung.

- [x] Dokumentation und Intake-/Governance-Evidence
- [ ] MicroCalc.Core, MicroCalc.Tui, Produkttests oder CI geändert

## Lösung und Verhaltensgrenzen

Lesehilfe und vollständiger englischer Vertragsblock ergänzen acht aktive
Lastenhefte. Deutsche Originale, IDs, Anforderungen, Schwellenwerte, Prompts,
Lieferbefugnisse und DAG bleiben unverändert. Byteidentische Vorgänger-Intakes
und Receipts bleiben archiviert, einschließlich sechs alter Markdown-Umbrüche.
Aktive Umbrüche werden gleichwertig mit Backslashes statt nachgestellten
Leerzeichen geschrieben. Erneuerte Receipts behalten die Intake-Identität,
binden den Vorgänger zuerst und erhalten das alte Quellinventar im Receipt-Archiv.
Beide README-Deltas sind fachlich abgeglichen und aktuell gebunden.
Die Serien-Receipt bindet das aktualisierte Manifest; die generierten
Reihenfolgen folgen demselben Zustand. Neuer vollständiger Review: Ready,
13 Mitglieder, null Befunde/Fragen/akzeptierte Risiken, explizite Supersession.
Der unmittelbar vorhergehende Review samt Archiv und Statistik gehört zum
genehmigten Wartungspaket. Künftige Feature-Prompts bleiben LocalImplementation.

## Risiken und Gegenmaßnahmen

Übersetzungsdrift wird durch vollständigen fachlichen Review und bytegenaue
Rekonstruktion der deutschen Vorgänger begrenzt. Archiv-/Quell-/Hash-Fehler
werden von beiden Validatorpfaden und vollständiger Ausrichtung geprüft.
Ein Struktur-PASS ersetzt keine fachliche Prüfung; Ready ist keine Startfreigabe.
Kein fachliches/technisches/Security-/A11Y-/Evidenz-Gate wird per Admin umgangen.
Historische relative Links behalten ihren ursprünglichen Basispfad. Ein eigener
Archiv-Wegweiser verlinkt alle 13 historischen Verträge, drei Feature-Nachweise
und den Vorgängerreview korrekt, ohne hashgebundene Archivbytes umzuschreiben.
Keine neuen Secrets, Produktabhängigkeiten oder Datenschutzdaten.

## Testplan und Nachweise

- [x] Konfiguration, acht erneuerte Receipts, Serienmanifest/-Receipt, Review
  und Operation: installierte PowerShell- und Bash-Validatoren im Staging.
- [x] Vollständige Requirements-/Receipt-Ausrichtung: 13 aktuelle Receipts.
- [x] Byteidentische Archive, Vorgänger-Rekonstruktion, identische Intake-IDs,
  Lieferbefugnisse und Seriensemantik.
- [x] Deterministischer Renderer und negative Fixtures: 10 Legacy-/26 Linked-Fälle.
- [x] DE-first/EN-second, B2 und text-first Review mit Diagramm-Textalternative.
- [ ] Provider-CI und fachliches PR-Review: vor Merge erfolgreich erforderlich.

Lokaler Produkt-Build/-Test und manuelle TUI/Screenshot/PTY/VoiceOver-Prüfung
sind N/A: keine Produkt-, API-, XML-, DocFX- oder UI-Änderung. Ausführbare
Governance-Prüfungen wurden dagegen frisch ausgeführt; spätere Produktgates
werden nicht abgeschwächt. Provider-Build-/Test-Gates bleiben verbindlich.
Statistik wird mit unveränderter 80/125-Zeilen-Basis fortgeschrieben.

## English

The full series review found six Medium findings: incomplete English contracts
and first-use explanations, plus two stale README source bindings. Thorsten
explicitly approved eight bounded intake updates, archive/lineage/series proof
and complete re-review. Maintenance delivery is MergeAndSync; admin bypass is
limited to formal merge rules. No feature, product/UI/API/CI change is included.

Reading guides and complete English contracts supplement eight active intakes.
German originals, IDs, requirements, thresholds, prompts, authority and DAG
remain unchanged. Byte-identical predecessor targets/receipts are archived.
Six existing metadata hard breaks use equivalent backslashes instead of trailing
spaces in active files; predecessor archives retain their exact original bytes.
Renewed receipts retain intake identities and bind predecessors first; prior
ordered source inventories remain in bound receipt archives. Both README deltas
are reconciled and current. The series receipt binds the updated manifest;
generated orders reflect unchanged lifecycle. The new complete review is Ready:
13 members, zero findings/questions/accepted risks, explicit supersession.
The preceding review, its archive and statistics are part of this approved
maintenance package. Future feature prompts remain LocalImplementation.

Translation risk is bounded by full semantic review and byte-exact reconstruction.
Both validator paths, complete alignment, hashes and archives address provenance
risk. Ready/structural PASS is not feature-start authority. Admin never bypasses
technical/security/A11Y/evidence/substantive-review failure. No new secrets,
personal data or product dependencies are added.
An archive companion maps all 13 old contracts, three feature proofs and the
preceding review through valid links; hash-bound archives retain original bytes.

Passed in staging: PowerShell/Bash configuration, eight renewed receipts,
manifest/receipt/review/operation; complete alignment of 13 receipts; exact
archives/predecessor reconstruction/identity/authority/series proof; deterministic
renderer; 10 legacy and 26 linked negative-fixture cases; bilingual B2/text-first
review and diagram alternative. Provider CI and substantive PR review must pass
before merge. Local product build/tests and UI/PTY/VoiceOver/screenshots are N/A
without product/API/XML/DocFX/UI changes, not waived for later work. Executable
governance validators were run afresh. Provider build/test gates remain binding;
statistics retain their 80/125-line baselines.
