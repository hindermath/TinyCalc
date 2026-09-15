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
