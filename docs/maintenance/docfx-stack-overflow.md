# DocFX: Stack Overflow und Wiederherstellung / Stack Overflow and Recovery

## Deutsch

Stand: 18.10.2026. Verantwortlich: Thorsten. Reine Dokumentations-Toolchainarbeit auf `007-tui-accessibility`, keine Produktimplementierung oder native Screenreader-Abnahme.

### Fehler und begrenzte Ursache

Das globale DocFX `2.78.4` bricht bei `docfx build docfx.json` mit Exit 134 ab. Der Stack wiederholt `ResolveLinkExtension.UpdateLinks` etwa 4.706-mal. Der Fehler wurde nach Quellencommit `44c8b68` erneut mit unveränderter Konfiguration und eigenem temporärem Ausgabeordner reproduziert.

Ein isoliert installiertes DocFX `2.81.0` verarbeitet dieselben Quellen und dieselbe `docfx.json` erfolgreich, Exit 0. Dies belegt einen versionsabhängigen Fehler der alten Dokumentations-Toolchain. Der genaue auslösende Markdown-Knoten und eine einzelne verantwortliche Upstream-Änderung sind nicht isoliert. Insbesondere enthält die Linkauflösung in beiden untersuchten Upstream-Versionen rekursive Traversierung; wir behaupten nicht, diese Methode selbst repariert zu haben.

Quellen: [offizielles Release 2.81.0](https://github.com/dotnet/docfx/releases/tag/v2.81.0), [NuGet-Paket](https://www.nuget.org/packages/docfx/2.81.0). Offizielle Änderungen umfassen auch Markdig-Abhängigkeiten; dies allein beweist keine einzelne Fehlerursache.

### Reproduzierbare Korrektur

Das lokale Werkzeugmanifest `.config/dotnet-tools.json` bindet DocFX exakt an `2.81.0`. Es ist Repository-Konfiguration, keine veröffentlichte HTML-Ressource. Zusätzlich wurde DocFX auf diesem Mac mit `dotnet tool update --global docfx --version 2.81.0` global aktualisiert. Im Projekt bleibt dennoch der explizite lokale Aufruf maßgeblich:

```powershell
dotnet tool restore --tool-manifest .config/dotnet-tools.json
dotnet tool run docfx -- --version
dotnet tool run docfx -- build docfx.json
dotnet tool run docfx -- serve _site --port 8189
```

Diese Befehle gelten identisch in PowerShell 7 und Bash. `build` erzeugt hier nur HTML aus vorhandenen Quellen; `metadata` und Produkt-Build/-Test/-Restore werden nicht gestartet. `_site` ist generierte, nicht für den Commit bestimmte Ausgabe. Für Prüfungen darf `--output` einen eigenen temporären Zielordner wählen. Ohne Manifest oder Restoreerfolg stoppen, nicht still auf die globale Altversion zurückfallen.

Auf anderen Rechnern steht das Werkzeug erst nach späterer Repository-Synchronisierung und `dotnet tool restore` bereit; das Manifest überträgt keine Binärdateien und installiert nichts automatisch. Eine globale Installation ist dort optional und separat auszuführen. Dieser Auftrag aktualisiert nur diesen Mac und erzeugt einen lokalen Quellencommit, keinen Push oder Rollout.

NuGet.org lieferte das exakt benannte Entwicklungswerkzeug. Der lokale Restore meldet übersprungene Paketsignaturprüfung; deshalb wird keine kryptografisch verifizierte Paketsignatur behauptet. Keine Produkt-Paketreferenz oder Lockdatei wurde geändert. Das Manifest erneuert keine Runtime-/Statistikbasis und keine gemeinsame Agentenregel; Verfassung und Agentenguidance bleiben unverändert. Keine neue Skriptschnittstelle wird eingeführt.

### Nachweisgrenze

HTML-Build, Text-/Landmark-Snapshot, Tastaturfokus, axe und lynx werden auf der reparierten Ausgabe geprüft. Geprüfte URLs, Werkzeugversionen und tatsächlich erzielte Ergebnisse werden unten dokumentiert. Ein automatischer Scan ist keine vollständige WCAG-2.2-AA-Bewertung; manuelle oder nicht abschließbare Regeln bleiben offen. Native VoiceOver-/Narrator-/Braille-Gerätenachweise werden nicht durch HTML ersetzt. Vorhandene nicht erzeugte API-Seiten sind nicht Teil dieses HTML-Smokes; keine API-Regeneration oder deren Bestehen behaupten.

NIST SSDF/CWE Top 25 gelten für die sichere Dokumentationslieferung. ASVS, Produkt-AI-SBOM, Zero Trust und C3A/C5 sind hier N/A: kein Webdienst, keine Produkt-KI, keine verteilte Produktarchitektur und keine Cloud-Auswahl. Entwicklerwerkzeuge sind keine Produktkomponenten. SBOM/SLSA bleiben spätere Releasepflichten, kein neuer Release in diesem Lauf. Synthetische Inhalte, keine Secrets oder privaten Tabellen verwenden; alte Nachweise und die Lastenheft-Reihenfolge bleiben unverändert.

### Tatsächliche Prüfungen am 18.10.2026

- Rot: globales DocFX 2.78.4, unveränderter HTML-Build, Exit 134 mit Stack Overflow.
- Grün: lokales Manifest-Restore und Versionsprüfung 2.81.0, anschließend `dotnet tool run docfx -- build docfx.json --output <eigener temporärer Ordner> --logLevel Error`, Exit 0. Keine Produktkompilierung und keine Metadatengenerierung. Der verwendete Error-Loglevel ist kein Nachweis, dass alle historischen Linkwarnungen behoben sind.
- Playwright mit installiertem Google Chrome und `@axe-core/playwright` 4.14.0, Tags wcag2a/wcag2aa/wcag21a/wcag21aa/wcag22aa: sechs Seiten, jeweils null gemeldete axe-Verstöße, `html lang=de`, ein Main-Landmark, verständliche Überschriften und per Tab erreichbarer benannter Link. ARIA-Snapshots wurden textorientiert gelesen; keine reine Screenshot-Freigabe.
- Seiten: `/README.html`, `/docs/project-statistics.html`, `/docs/concepts/tiny-tools-family.html`, `/docs/PR_TEXT_TINY_TOOLS_FAMILY_CONCEPT.html`, `/docs/maintenance/docfx-stack-overflow.html`, `/docs/PR_TEXT_DOCFX_RECOVERY.html`.
- `color-contrast` und `link-in-text-block` bleiben auf den geprüften Seiten `Incomplete`; hierfür keine Kontrasterfüllung oder Gesamt-AA-Freigabe behaupten. Tastaturstichprobe belegt den ersten Fokusweg, nicht sämtliche Interaktionen. Englische Teilblöcke und weitere manuelle Kriterien benötigen weiterhin gesonderte Bewertung.
- lynx mit explizitem UTF-8 prüft Text/Überschriften, Befehle und DE/EN-Blöcke. Intake-/Serien-/Review-Alignment bestanden; Manifest und neue Dokumente werden zusätzlich auf JSON-/UTF-8-/LF-/Link-/Secret-/Diff-Integrität kontrolliert. Die genaue Liefermenge bleibt ohne generiertes HTML und ohne private Tabellen.

Die vorangegangene HTML-Prüflücke ist für den Build und diese automatisierte/textorientierte Stichprobe behoben, nicht für offene manuelle Kriterien. Die Prüfung wurde nach dem globalen Update erneut auf den sechs Seiten ausgeführt. Globaler und projektlokaler Versionsaufruf liefern 2.81.0. Manifest, Reparaturdokumentation und Statistiknachtrag werden mit diesem Quellenstand lokal versioniert; kein Push oder PR. Die letzte commitgebundene generierte Gesamtstatistik bleibt historisch und wird nicht als frisch gerendert ausgegeben.

## English

Recorded on 18 October 2026, owned by Thorsten. This is documentation-tool recovery, not product implementation or native-reader acceptance.

Global DocFX 2.78.4 reproducibly aborts with exit 134 and about 4,706 recursive link-resolution frames. Isolated 2.81.0 builds the same sources and unchanged configuration successfully. This establishes a version-dependent old-toolchain failure, not its exact triggering Markdown node or a single upstream fix. Both inspected versions still use recursive link traversal.

The local manifest pins 2.81.0 without changing product dependencies. The global installation on this Mac was also explicitly updated to 2.81.0; the local manifest-based invocation remains authoritative for the project. Use the commands above in either shell. Generate HTML from existing sources only; do not run metadata or product builds/restores/tests. Missing manifest/restore must stop execution rather than fall back to old global tooling. Generated output is not for tracking.

Other computers receive the tool only after later repository synchronisation and `dotnet tool restore`. The manifest transfers no binaries and installs nothing automatically. A global installation there is optional and separate. This work updates this Mac only and creates a local source commit, with no push or rollout.

NuGet supplied the exact development-tool version. Restore reported skipped signature verification; no verified package-signature claim is made. Runtime/statistics baselines, constitution, shared guidance, product package declarations and lockfiles remain unchanged. No new script interface is introduced.

HTML checks cover actual pages, text structure, keyboard focus, axe and lynx. Incomplete/manual assessments remain open and automated results do not certify WCAG conformance or native reader/Braille compatibility. Unproduced API pages are outside this smoke, not successful API regeneration. SSDF/CWE apply; ASVS, runtime AI inventory, Zero Trust and cloud assurance are not applicable to this bounded local documentation change. Preserve release evidence obligations, synthetic-data privacy and the existing requirement sequence.

Actual results on 18 October: old tool exit 134; restored pinned tool and unchanged HTML build exit 0. Error-level logging does not establish that historical warnings were fixed. Playwright/Chrome and axe 4.14.0 checked the six paths listed above: no reported violations, German page language, one main landmark, readable headings and named initial keyboard focus. Text snapshots and UTF-8 lynx output supplement the scan. Contrast and link-in-text-block remain incomplete; initial keyboard focus is not full interaction coverage and mixed-language/manual criteria remain separately assessable. Governance alignment passed. The six-page verification was repeated after the global update; both version invocations return 2.81.0. This closes the build and bounded automated/text-smoke gap, not full AA or native-reader acceptance. This source change versions the repair locally without remote delivery; generated overall metrics retain their historical committed source rather than claiming a fresh render.
