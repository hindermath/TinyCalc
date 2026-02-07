# Contributing

Danke fuer deinen Beitrag zu TinyCalc.

Diese Regeln sind verbindlich, damit CI stabil bleibt und der PR-Prozess sauber funktioniert.

## 1) Branching

- Arbeite immer auf einem neuen Feature-Branch mit Prefix `codex/`.
- Branches nicht wiederverwenden, wenn ein PR bereits gemergt/geschlossen wurde.
- Nach jedem abgeschlossenen PR fuer Folgeaenderungen immer einen neuen `codex/*` Branch erstellen.

Empfohlenes Vorgehen:

```bash
git fetch origin
# Basis ist die aktuelle Integrations-Branch-Spitze:
git checkout -b codex/<kurzer-name> origin/codex/initial-microcalc-port
```

## 2) Pull Requests

- Pro Thema ein PR (klein und fokussiert).
- Fuer jeden PR eine passende Markdown-Beschreibung unter `docs/` anlegen, z. B.:
  - `docs/PR_TEXT_<THEMA>.md`
- PR-Beschreibung aus der Datei in GitHub uebernehmen.

## 3) CI-Regeln (wichtig)

Der Workflow baut in **Release** und testet mit `--no-build`:

```bash
dotnet build MicroCalc.sln --configuration Release --no-restore
dotnet test MicroCalc.sln --configuration Release --no-build
```

Deshalb gilt:

- Tests duerfen nicht implizit nur von `Debug` ausgehen.
- Wenn ein Test `dotnet run --no-build` startet, muss er die aktive Konfiguration (`Debug`/`Release`) explizit uebergeben.

## 4) Lokale Pruefung vor PR

Mindestens einmal lokal ausfuehren:

```bash
dotnet restore MicroCalc.sln
dotnet build MicroCalc.sln --configuration Release
dotnet test MicroCalc.sln --configuration Release --no-build
```

Optional (Smoke):

```bash
dotnet run --no-build --configuration Release --project src/MicroCalc.Tui/MicroCalc.Tui.csproj -- --smoke
```

## 5) Help-Datei / Ressourcen

- Die Help-Datei `CALC.HLP` muss weiterhin aufloesbar sein.
- Aenderungen an Pfaden nur so, dass Help sowohl im Build-Output als auch im Repository-Layout gefunden wird.

## 6) Nach dem Merge

- Feature-Branch lokal und remote aufraeumen.
- Integrations-Branch lokal wieder auf den aktuellen Remote-Stand ziehen.

Beispiel:

```bash
git checkout codex/initial-microcalc-port
git pull --ff-only origin codex/initial-microcalc-port
git push origin --delete codex/<alter-branch>
git branch -D codex/<alter-branch>
```

## 7) Code- und Doku-Qualitaet

- Relevante Tests fuer neue Logik hinzufuegen.
- Dokumentation bei Prozess-/Verhaltensaenderungen aktualisieren (`README.md`, `docs/*`, diese Datei).

