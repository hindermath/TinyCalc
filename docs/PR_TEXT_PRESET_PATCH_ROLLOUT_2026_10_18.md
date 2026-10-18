# PR: Vierzehn README-Patch-Releases / Fourteen README patch releases

## Problem / Problem

DE: Installierte Pakete enthalten noch nicht die abgenommenen README-Verbesserungen.
EN: Installed packages do not yet contain the accepted README improvements.

## Loesung / Solution

DE: Zentrale 14er-Matrix mit unveraenderlichen Quellenbindungen installieren;
aktuelle Guidance und technische GSDB-Versions-/Hashnachweise gemeinsam pflegen.
Gesondert genehmigte macOS-PTY-Testinfrastruktur korrigieren, ohne bestehende
Produktorakel oder Zeitlimits abzuschwaechen.
EN: Install the source-locked fourteen-preset profile and reconcile current
guidance and exact technical GSDB bindings without changing human decisions.
Separately authorized macOS PTY infrastructure repair preserves product
oracles and deadlines; no Feature 007 implementation.

## Risiken und Pruefplan / Risks and verification

DE: Keine Produkt-API-Aenderung; echte Produktregression, exakte Paketmatrix,
GSDB-Negativfaelle, Assurance-Reviews, Agentenparitaet, Secret-/Statistik-/CI-Gates.
EN: No product API change; require actual product regression and exact package,
GSDB, Assurance, parity, security, statistics and CI evidence before merge.

Details: [Rollout-Nachweis](maintenance/preset-readme-patch-rollout-2026-10-18.md).
