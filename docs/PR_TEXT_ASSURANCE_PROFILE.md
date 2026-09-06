# Assurance-Profilintegration / Assurance Profile Integration

## Problem

Assurance v0.1.2 ist bereits installiert; die lokale Profildefinition fehlte.
*Assurance v0.1.2 is already installed, but its local profile definition was missing.*

## Lösung / Solution

13er-Profil additiv ergänzen, fünf Agenten-Anleitungen und README angleichen.
Alle bestehenden Preset-Dateien und Registereinträge bleiben unverändert.
*Add the thirteen-preset profile and synchronize five agent guides and README.
All existing preset files and registry entries remain unchanged.*

## Risiken und Grenzen / Risks and Boundaries

Keine Produkt-, Baseline- oder Freigabeänderung, keine erneute Installation,
keine Reviews, kein Home-Sync. Profilregistrierung erst nach MergeAndSync.
*No product, baseline, authorization, reinstall, review, or Home-sync changes.
Register the selected profile only after MergeAndSync.*

## Testplan / Test Plan

Archiv-SHA-256, exakte 13er-Matrix, 581 bytegleiche geschützte Dateien,
isolierte Paket-/Oberflächentests, lesender Status, Secret-Scan,
Statistikrenderer und bestehende PR-CI.
*Verify the archive hash, exact matrix, byte preservation, isolated package and
surface fixtures, read-only status, secrets, statistics, and existing PR CI.*

Documentation Impact: `UpdateRequired`.
Details: [Integrationsnachweis / integration record](maintenance/secure-development-assurance-integration.md).
