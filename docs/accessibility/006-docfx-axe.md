# DocFX: gezielte Rot–Grün-Prüfung / Targeted red–green checks

## Deutscher Nachweis

2026-10-10, Feature 006, T073. Thorsten genehmigte die temporäre axe-Prüfumgebung
außerhalb des Repositories. Installation: `npm install --prefix <owned-temp-dir> --save-exact --ignore-scripts --registry https://registry.npmjs.org @axe-core/playwright@4.13.0`.
Keine NuGet-/Produktabhängigkeit wurde geändert. Tool-Lock SHA-256:
`0c1dc6a12ab30afd621eec75e63b3fef02094351d9443eb17ebaee02642eff729`.
Playwright 1.62.1 aus vorhandenem Runtime-Bundle; eigener Headless-Chrome
153.0.8010.53 ohne Nutzerprofil. Ein eigener HTTP-Server erlaubte ausschließlich
Dateien unter `_site/` auf Loopback und wurde wieder beendet.

Geprüfte Seiten: `README.html`, `docs/help/microcalc-help.html`,
`docs/contracts/tui/README.html`, `docs/contracts/tui/catalog.html`,
`api/MicroCalc.Core.Engine.MicroCalcEngine.html`. axe-Tags: wcag2a, wcag2aa,
wcag21a, wcag21aa, wcag22aa. Dazu echte ARIA-Snapshots, genau ein Main-Landmark,
Seitensprache `de` und HTTP-Prüfung der internen Artikel-Linkziele.

Rot: namenloser SVG-Startlink auf allen fünf Seiten; API-Link-/Syntaxkontraste
unter 4,5:1, zu kleine Navigationsziele und zwei fehlende leere Eltern-Namespaces.
Das kleine versionierte [Template-Overlay](../docfx-template/README.md) behebt
die Darstellung ohne generiertes HTML nachträglich zu verändern oder APIs
auszublenden. Öffentliche C#-Signaturen/XML-Kommentare wurden im unabhängigen
Review abgeglichen; keine neue öffentliche API, keine globale CS1591-Ausnahme.

Grün: `docfx docfx.json`, danach `docfx build docfx.json` für die letzte
CSS-Korrektur: null Fehler, 83 bestehende Warnungen. Abschließend fünf Seiten mit
null automatischen axe-Verstößen und null fehlenden Artikel-Linkzielen.
Die erste vollständige Grünprüfung erfolgte um 19:18:51 UTC am ausdrücklich schmutzigen
Implementierungsstand auf Basis `6a1154d`; kein finaler Lieferhead behauptet.
`lynx -dump -nolist -assume_charset=UTF-8 -display_charset=UTF-8 <page>` lieferte
lesbare Texte für alle fünf Seiten (595/251/135/1423/306 Zeilen vor späteren
Nachweisergänzungen). Neue Nachweisseiten sind damit nicht pauschal geprüft.

Nach den Nachweisergänzungen wurde DocFX erneut erfolgreich erzeugt und am
10.10.2026 um 19:32:07 UTC mit denselben fünf Seiten, axe/ARIA/Linkprüfung und
lynx geprüft: weiterhin null automatische Verstöße, null fehlende Artikelziele,
dieselben manuellen Prüffälle und dieselben Textzeilenzahlen. Auch diese Prüfung
bindet den tatsächlichen Arbeitsbaum, nicht einen künftigen Commit.

| Ignoriertes Original unter tests/MicroCalc.Tui.Tests/TestResults | SHA-256 |
|---|---|
| 006-axe115-final.json, einschließlich ARIA und incomplete | 54c1040acecd9ff9a757456e36f7b2b2fdd2757ec91db993c80f9a8c2f8ecc2c |
| 006-docfx115-final.log | 14c9c795e8d376221a557cfa546df120cd8611cf8bc23e75073e915ecd717db5 |
| 006-axe115-evidence.json, nach Nachweisergänzungen | 00d2aefc0d486ad99eddbe33daaf5fcbfebe4ffbf8520dfef4f11908b0517fca |
| 006-docfx115-evidence.log | f7ee77210ff4010cabbe4b9e67c6d3fb0a7167202b172185d10812069655a53f |

axe `incomplete` enthält manuell zu bewertende Kontrast-/Inline-Linkfälle:
2/2/2/1/1 je Seite. Null automatische Verstöße bedeutet keine vollständige
WCAG-Konformität und keine menschliche Freigabe. Sprachwechsel, visuelle
Sonderfälle und VoiceOver bleiben menschliche Prüfgrenzen. T065 und finale
ReleaseCloseout-Bindung T081 sind weiterhin offen. Keine Paketaktualisierung
oder A11Y-Folgefeature-Promotion.

## English evidence

The authorised temporary external environment used exact axe 4.13.0, bundled
Playwright 1.62.1 and an owned headless Chrome process. No product/NuGet package
changed. Five actual generated pages received WCAG2.2AA-tagged axe checks,
ARIA/language/main-landmark inspection, local article-link checks and UTF-8 lynx
cross-checks. Concrete initial failures led to the bounded template overlay.
The final sampled pages have zero automatic axe violations and missing article
targets; DocFX succeeded with 83 existing warnings and no errors. The matching
axe/ARIA/link and lynx checks after evidence edits also passed at 19:32:07 UTC.
Hashed originals
retain manual-review items as well as passing checks. This dirty-tree evidence
does not pretend to be a final commit, all-site WCAG proof, human VoiceOver or
owner acceptance. Final release binding and human requirements remain open.
