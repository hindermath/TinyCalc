# Statistik-Pilotinstallation / Statistics pilot installation

Problem: Das genehmigte Statistik-Preset fehlt im TinyCalc-Pilot.
Loesung: v0.1.0 aus geprueftem Tag-ZIP, Prioritaet 90, additive 14er-Matrix,
generierte Agenten-Commands, getrennte zukuenftige Ausgaben und Guidance.
Kein Produktcode, keine neue Messung, keine Statistik-Migration.

Problem: the approved statistics preset is absent. Add the verified v0.1.0
package and fourteen-preset profile without changing product code, measuring
the project or replacing existing statistics.

Documentation Impact: UpdateRequired. Owner Thorsten Hindermann.
Quelle, Leserpfad, Sprachpartner, Plattformnachweis, Distributionsklasse,
Grenzen und Wiedervorlage: [Integrationsnachweis](maintenance/project-statistics-installation-v010.md).

Pruefplan / Test plan: ausgefuehrte lokale Bash-/PowerShell-Matrixpruefung,
Paket- und Erhaltungs-Hashes, list/info/resolve/check, isolierter Lifecycle;
vor Lieferung zusaetzlich Staged-Delivery-Set, Secret-Scan, Inhaltscommit,
regulaeres Statistik-Rendering, CI und exakter Head. Neue native
Projekt-CI ist noch nicht gestartet. Kein TUI-Screenshot erforderlich:
keine UI- oder DocFX-Aenderung. TDD/Changed-Code-Coverage N/A: unveraendertes
C#-Produkt; Wiedervorlage bei Produktlogikaenderung.

Risiko / Risk: Noch kein Feldergebnis; der operative Registry-Eintrag folgt
erst nach Merge. Kein Admin-Bypass fuer technische Fehler.
Tracking bleibt offen: [TinyCalc #84](https://github.com/hindermath/TinyCalc/issues/84).

## Autorisierte GSDB-Nachprüfung / Authorized GSDB follow-up

Die CI hat veraltete Bindungen von Guidance und Registry erkannt. Die gezielt
genehmigte [Nachprüfung](security/gsdb-intensive-review/statistics-pilot-follow-up-2026-09-15.md)
führt Inventar, Schema und Validator auf 14 Presets fort. Fünf neue negative
Testfälle verhindern fehlende oder falsch klassifizierte Statistik-Evidence.
Alle 157 Kontrollzeilen, 16 externen Pflichten und 13 Findings bleiben unverändert.
Die ursprüngliche Installationsaufnahme oben ist historisch; die aktuelle
native CI läuft in PR #85 und muss am finalen Head grün sein.

CI exposed stale guidance/registry bindings. The authorized follow-up updates
inventory/schema/validator for fourteen presets, with five new negative cases.
All control rows, external duties and findings are preserved. The original
installation snapshot above is historical; exact-head CI in PR #85 governs delivery.
