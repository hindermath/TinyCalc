# PR-Entwurf: DocFX-Wiederherstellung / PR Draft: DocFX Recovery

## Deutsch

Problem: Globales DocFX 2.78.4 stürzt beim HTML-Build mit rekursivem Stack Overflow ab. Lösung: lokales Manifest für DocFX 2.81.0 und [Bedien-/Prüfnachweis](maintenance/docfx-stack-overflow.md). Konfiguration, Produkt, APIs, Locks, Lastenhefte und Serienstatus unverändert.

Documentation Impact: `UpdateRequired`. Quelle ist das lokale Werkzeugmanifest; Thorsten verantwortet den dokumentierten Bedienweg. Leserpfad: PR-Text → Wiederherstellungsnachweis → Manifest/HTML-Prüfung. Deutsch zuerst/Englisch danach, CEFR B2 und textorientiert. Distribution `sourceOnly`, keine Navigation, kein Home-sync. Wiedervorlage bei Werkzeug-/Konfigurations-/Templateänderung oder erneutem Buildfehler.

Globale Installation auf diesem Mac ebenfalls auf 2.81.0 aktualisiert; im Projekt bleibt `dotnet tool run docfx` maßgeblich. Andere Rechner benötigen nach späterer Repository-Synchronisierung `dotnet tool restore`; keine automatische Installation oder globale Flottenänderung. Kein vollständiger WCAG- oder nativer Screenreader-Pass. Die Nachweise nennen tatsächliche Ergebnisse und offene Regeln. Signaturprüfung wurde vom Restore übersprungen, nicht als bestanden ausgegeben. Ein lokaler Commit ist genehmigt, kein Push oder PR.

Testplan: Fehler mit 2.78.4 reproduzieren; lokale 2.81.0 wiederherstellen und unveränderten HTML-Build ausführen; repräsentative Seiten mit Snapshot, axe und lynx prüfen; Alignment, Secret-Scan, Manifest-/Link-/Whitespace-Prüfung. Keine Produkt-Builds oder Produkttests. Dieser Entwurf erstellt keinen PR und erteilt keine Push-/Mergefreigabe.

## English

Problem: global DocFX 2.78.4 aborts during recursive HTML link processing. Fix: local 2.81.0 manifest and linked recovery/verification guide. Configuration, product, APIs, locks and requirement lifecycle remain unchanged.

Documentation Impact is UpdateRequired; Thorsten owns the manifest-based usage path. Bilingual B2 reader path: PR draft → recovery evidence → manifest/HTML checks. Source-only distribution without navigation or Home sync. Re-evaluate after tooling/config/template changes or recurring failure.

The global tool on this Mac is also updated to 2.81.0; the local invocation remains authoritative. Other computers require later repository synchronisation and local tool restore, with no automatic installation or global fleet change. No full WCAG/native-reader success or verified package-signature claim. Verify reproduced failure, restored-tool success, representative HTML/text accessibility, alignment, secrets and formatting. Run no product build/test. A local commit is authorised, but no PR or remote delivery.
