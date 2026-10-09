# Drei Preset-Patches / Three preset patches

DE: Security 0.7.1, Architecture 0.6.2 und Sequencing 0.2.8 mit zentralen
Profilen, Quellenbindungen, installierten Paketen und technischen GSDB-
Versions-/Hashnachweisen gemeinsam aktualisieren. Kein Produktlauf und keine
neue fachliche Produkt-, Risiko- oder Releaseentscheidung.

EN: Adopt three approved patches and aligned profiles, immutable sources,
installed packages and targeted GSDB version/hash evidence. No product run or
new product, risk or release acceptance.

Problem / Problem: Die bisherigen Patch-Versionen sind im Projekt noch gebunden.
The project still binds the preceding patch releases.

Solution / Loesung: Nur diese drei Pakete, aktuelle Guidance/Templates und
sieben GSDB-Quellenbindungen erneuern; Zustandsachsen strukturell erhalten.
Refresh only these packages and current surfaces; preserve all assurance states.

Risks / Risiken: Veraltete Bindungen muessen blockieren; keine Hash-Promotion
von Intakes. Stale bindings must fail; existing intakes need their own preflight.

Test plan / Testplan: Volles 14er-Profil beider Shells, Pakettests, GSDB-
Voll-/Teilpruefungen und Negativfaelle, RL-SE, Restore/Release-Build/82 Tests/
TUI-Smoke, Secret-Scan, PSScriptAnalyzer, Homogeneity und Statistik.

[Nachweis / Evidence](maintenance/preset-patches-2026-10-10.md).
DeliveryMode: explicit MergeAndSync with Admin-Bypass only after successful
exact-head technical checks; actual merge/sync results follow in PR closeout.
