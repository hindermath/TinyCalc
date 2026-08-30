# Paketauswahl / Package Selection

## Entscheidung / Decision

Am `2026-08-30T11:27:48Z` wurde `Terminal.Gui` `2.4.17` erneut als aktuelle
stabile 2.x-Version bestaetigt. Neuere sichtbare Eintraege sind
`2.4.18-develop.*` und damit Vorabversionen. Die Paketgalerie weist `net10.0`
als enthaltenes Ziel-Framework aus und zeigt die exakte PackageReference
`2.4.17`.

*At the recorded UTC time, Terminal.Gui 2.4.17 was reconfirmed as the current
stable 2.x version. Newer visible entries are 2.4.18 development prereleases.
The package gallery lists net10.0 as an included target framework and shows the
exact 2.4.17 PackageReference.*

## Primaerquellen / Primary Sources

- NuGet Gallery: `https://www.nuget.org/packages/Terminal.Gui`
- Offizielles Release: `https://github.com/tui-cs/Terminal.Gui/releases/tag/v2.4.17`
- Offizielle Application-Dokumentation: `https://tui-cs.github.io/Terminal.Gui/docs/application.html`
- Offizieller v1-v2-Migrationsleitfaden: `https://tui-cs.github.io/Terminal.Gui/docs/migratingfromv1.html`

Das offizielle Release ist als `Latest` markiert, wurde am 7. Juli 2026
veroeffentlicht und bindet den verifizierten Commit `d0a0ed9`. Das Repository
zeigt aktuelle 2.x-Pflege nach diesem Release. Die offizielle Dokumentation
belegt den instanzbasierten Create-/Init-/Run-/Dispose-Lebenszyklus.

*The official release is marked Latest, was published on 7 July 2026, and
binds verified commit `d0a0ed9`. The repository shows continuing 2.x
maintenance after the release. Official documentation confirms the
instance-based create/init/run/dispose lifecycle.*

## Quellenkonfiguration / Source Configuration

`dotnet nuget list source --format Detailed` bestaetigte `nuget.org` unter
`https://api.nuget.org/v3/index.json` als aktiviert. Eine weitere aktivierte,
authentifizierte Anbieterquelle ist fuer diesen Nachweis absichtlich
redigiert; T010 muss die tatsaechliche `Terminal.Gui`-Aufloesung an NuGet.org
binden und blockiert bei einer abweichenden Quelle.

*The source listing confirmed nuget.org at the stated v3 endpoint as enabled.
Another enabled authenticated vendor source is intentionally redacted from
tracked evidence. T010 must bind the actual Terminal.Gui resolution to
NuGet.org and blocks on a different source.*

## Sicherheitsgrenze / Security Boundary

Die Auswahl bleibt nur gueltig, wenn Restore, vollstaendiger Paketgraph,
Schwachstellenpruefung, Lizenzpruefung und SBOM spaeter fail-closed bestehen.
Diese zeitabhaengige Auswahl behauptet noch keinen abgeschlossenen Audit.

*The selection remains valid only if restore, full package graph,
vulnerability review, licence review, and SBOM later pass fail-closed. This
time-bound selection does not yet claim a completed audit.*
