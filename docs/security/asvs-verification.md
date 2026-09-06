# ASVS-Anwendbarkeit: TinyCalc Feature 003

## Deutscher Prüfblock

| Feld | Wert |
|---|---|
| Datum | 2026-08-30 |
| Feature | 003, Terminal.Gui-v2-Migration |
| Status | N/A, geprüft und begründet |
| Owner | Feature 003 |
| Reviewer | Security-/PR-Review am Exact Head |
| Kanonische Entscheidung | `docs/security/arc42-security.md`, Abschnitt 11 |

OWASP ASVS ist für Feature 003 nicht anwendbar. TinyCalc bleibt eine lokale
Terminalanwendung ohne Web-, HTTP-, API-, Authentifizierungs-, Session-, CORS-
oder Browserfläche. Es wird deshalb kein ASVS-Level erfunden und keine
Web-Verifikation als bestanden behauptet.

Eine Web-, HTTP-, API-, Authentifizierungs- oder Sessionfläche setzt den Status
auf `Open`. Dann müssen ASVS-Level, Scope, Owner, Prüfschritte und Evidenz vor
der Implementierung festgelegt werden. Der Exact-Head-Review in T057/T067 muss
bestätigen, dass kein solcher Trigger im finalen Diff entstanden ist.

## English review block

OWASP ASVS is not applicable to Feature 003 because TinyCalc remains a local
terminal application without a web, HTTP, API, authentication, session, CORS,
or browser surface. No ASVS level or web verification result is invented.

Any such new surface changes the status to open and requires an explicit ASVS
level, scope, owner, checks, and evidence before implementation. The canonical
rationale and trigger remain in `docs/security/arc42-security.md`, Section 11.

## Feature 005 review / Prüfung für Feature 005

**DE:** Prüftag ist 2026-09-06. Produkt-ASVS bleibt `N/A`: Die read-only
Prüfung fand keine Web-, API-, HTTP-, Browser-, Authentifizierungs- oder
Sessionfläche. Deshalb wird keine ASVS-Stufe gewählt oder als bestanden
gemeldet. Owner ist die Repository-Maintenance-Rolle; Reviewer ist die
unabhängige technische Security-Review-Rolle. Jede neue genannte Fläche setzt
den Status auf `Open` und verlangt Level, Scope und Verifikation.

**EN:** Review date is 2026-09-06. Product ASVS remains `N/A` because the
read-only review found no web, API, HTTP, browser, authentication, or session
surface. No ASVS level or passing verification is claimed. Any such surface
reopens applicability and requires a level, scope, and evidence.
