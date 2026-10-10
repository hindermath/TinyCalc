# Kleine DocFX-Ergänzung / Small DocFX overlay

## Deutsch

Dieses Overlay ergänzt das unveränderte Standard-Template von DocFX 2.78.5.
Der Startlink besitzt sichtbaren Text, Links und Syntax bleiben auf hellem
Hintergrund lesbar und Navigationsziele sind mindestens 24 Pixel hoch.
Eine sichtbare Tastatur-Fokuslinie ergänzt die Standarddarstellung.

Die API-Namespacezeile zeigt den vollständigen Namen als Text. Dadurch entstehen
keine Links auf leere Eltern-Namespaces ohne generierte Seite. Die eigentliche
API-Navigation bleibt erhalten. Keine API wird hinzugefügt oder ausgeblendet.
Generiertes HTML wird nie nachträglich gepatcht. Die fünf repräsentativen Seiten
werden nach der Generierung mit Playwright/axe und lynx geprüft; das ersetzt
weder menschliche Prüfung noch einen Nachweis für jede Dokumentationsseite.

## English

This overlay extends DocFX 2.78.5's unchanged default template. The home link has
visible text, darker links and syntax suit the light background, navigation
targets are at least 24 pixels high, and keyboard focus has a visible outline.
The API namespace line shows its full name as text rather than broken links to
empty parent namespaces. API navigation remains available; no API is added or
hidden. Generated HTML is never patched afterwards. Five representative pages
receive matching Playwright/axe and lynx checks, not a claim of human review or
complete site-wide conformance.
