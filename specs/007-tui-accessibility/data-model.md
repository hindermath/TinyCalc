# Daten- und Evidenzmodell / Data and Evidence Model

## Produktdaten bleiben unverändert / Product Data Remains Unchanged

Sheet, Cell, CellAddress, Formeln, Dateiformat und ein Blatt pro Datei bleiben unverändert. A11Y-Daten gehören zur Darstellung und Prüfung, nicht in persistierte Tabellen oder Core. Keine neuen öffentlichen C#-Typen oder Produkt-JSON-Felder werden hier definiert.

*Preserve sheet/cell/address/formula/file semantics and one sheet per file. Accessibility context belongs to presentation and verification, not persisted Core data. Define no new public C# types or product JSON fields here.*

## Fachliche Objekte / Domain Objects

| Objekt / Object | Identität und Inhalt / Identity and contents |
|---|---|
| Bedienkontext / Interaction context | Aktive Vertrags-ID/Einzelweg, Dialogtitel, Feldlabel, Wert, tatsächliches Fokusziel, aktuelle Aktion, Rückkehrfokus / path, title, label, value, focus, action and return focus |
| Rückmeldung / Feedback | Auslösende Aktion und Erfolg/Abbruch/Fehler; verständlicher sichtbarer Text ohne private Details / action, outcome and safe visible text |
| Prüfkonfiguration / Test configuration | Plattform, Host/Shell/OS/Reader mit Versionen/Einstellungen, Größen, Commit/Binary/Pin/Locks und synthetisches Setup / actual complete environment and bindings |
| Einzelprüfnachweis / Path proof | Stabile A11Y-ID plus Funktionsweg/Plattform/Prüfart, Schritte, Erwartung, Beobachtung, Status, Prüfer/Zeit und Artefakthashes / independently attributable execution |
| Anwendbarkeitszeile / Applicability record | WCAG-/Security-Kriterium, Artefakttyp, Applicable/N/A/Open, Begründung, Prüfweg, Owner, Trigger / justified scope and follow-up |
| Quellen-/Impactentscheidung / Source and impact decision | Unabhängige Baseline, Quellen-/Vertrags-/Pin-Digests, Impactklasse und Pflichtgates / immutable execution context |

Ein Nachweis ist eindeutig durch Run-ID + A11Y-ID + Einzelweg + Plattform + Prüfart. Mehrere Versuche erhalten eigene Runs, kein Überschreiben eines Fail durch einen ungebundenen Pass. Ein Reader-Name allein ist keine Umgebung. Ein Sprache-Transkript beweist nur die protokollierte Konfiguration und Aktion, nicht alle Wege.

*Uniqueness combines run, accessibility ID, path, platform and proof type. Preserve separate attempts and failures rather than overwriting them with unbound passes. A reader name alone is no environment; a transcript proves only its recorded configuration/path.*

## Zustände und Übergänge / States and Transitions

```text
Open -> Ausführung / execution -> Pass oder/or Fail
                           -> Incomplete, falls Bewertung fehlt / if inconclusive
Quell-/Pin-/Commitdrift -> keine aktuelle Pass-Wiederverwendung / no current pass reuse
N/A -> begründete Anwendbarkeit, keine bestandene Ausführung / scope, not execution
```

Pass benötigt vollständige aktuelle Bindung, tatsächliche Prüfung und passendes Orakel. Fehlende Aktion in der unmittelbaren Ansage ist Fail, fehlende Sitzung Open, begonnene unvollständige Sitzung Incomplete. Berichtet → reproduziert → verifiziert beschreibt Evidenzstärke, nicht automatische Pass-Übergänge. Keine historische Evidenz umetikettieren.

*Pass needs complete current bindings, actual execution and a suitable oracle. Missing required speech is Fail; missing execution is Open; inconclusive execution is Incomplete. Reported/reproduced/verified describe evidence strength, not automatic pass transitions.*

## Integritäts- und Speichergrenzen / Integrity and Storage Boundaries

Bestehende maschinenlesbare Bundle-/Decision-/Assertion-Schemas bleiben Ausgangspunkt. Neue Pflichtfelder sind bei strikten Schemas keine automatisch rückwärtskompatible Ergänzung: eine explizite neue Schemaversion samt test-first Reader-/Validator-Kompatibilität planen, historische Artefakte und deren Hashes unverändert erhalten. Alte gültige Nachweise bleiben historisch lesbar, erfüllen aber nicht automatisch neue Kandidatenpflichten. Jetzt keine ausführbaren Schemas ändern. Validator liest nur und führt keine Befehle aus Evidence aus. Native Protokolle dürfen Markdown sein, sofern Gate-Referenz, SHA-256, Commit und Prüfumfang eindeutig gebunden sind. Kein leeres Beispiel mit Status Pass erstellen.

*Reuse existing proof schemas. Required fields are not automatically backward-compatible in strict schemas: plan an explicit new schema version with test-first reader/validator compatibility and preserve historical bytes/hashes. Older valid evidence remains historically readable without automatically satisfying new candidate obligations. Change no executable schema now. Validators read rather than execute evidence. Native Markdown needs hashed references, commit and scope; never create empty passing examples.*

Produktaktionen schreiben nur ausdrücklich vorgesehene synthetische Dateien; lesende Validatoren müssen separat zero-write belegen. Terminal-/Sprachtranskripte minimieren, private Daten ausschließen, nur eigene Testressourcen bereinigen. Keine neue Telemetrie, Cloudspeicherung oder automatische Tonaufnahme.

*Product actions may write intended synthetic files; read-only validators separately prove zero writes. Minimise transcripts, exclude private data and clean up owned test resources only. No telemetry, cloud storage or automatic audio recording is introduced.*
