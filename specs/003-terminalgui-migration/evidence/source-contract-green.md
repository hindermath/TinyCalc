# Grüner Quellvertrag / Green Source Contract

## Ergebnis / Result

- UTC: `2026-08-30T12:14:55Z`
- Plattform / Platform: `Darwin`
- Commit vor Delivery / Pre-delivery commit: `886a13f8866e79fe6c13e6e1227217294aabdee8`
- Befehl / Command: inline PowerShell 7 contract against
  `src/MicroCalc.Tui/MicroCalc.Tui.csproj` and
  `src/MicroCalc.Tui/Program.cs`.
- Ergebnis / Result: Exitcode `0`, `SOURCE_CONTRACT=PASS`.

Der Vertrag bestätigt Terminal.Gui `2.4.17`, den instanzbasierten Lifecycle,
die v2-Ereignisse und alle 13 bindenden Eingaben. / *The contract confirms
Terminal.Gui `2.4.17`, the instance lifecycle, v2 events, and all 13 binding
inputs.*

## Zählwerte / Counts

```text
CtrlMask=0
AltMask=0
ApplicationTop=0
StaticInit=0
StaticRun=0
StaticShutdown=0
StaticRequestStop=0
CreateInit=1
IApplicationOwner=1
RootRun=1
KeyDown=2
Accepting=5
WithCtrl=8
matrixExpected=13
contractFailures=0
```

Die acht `WithCtrl`-Treffer sind `E`, `X`, `J`, `D`, `M`, `S`, `A` und `Q`.
Die fünf weiteren Bindungen sind vier Pfeiltasten und `Enter`. Jeder der 13
Quelltokens kommt genau einmal vor. Unbekannte Tasten erhalten keine neue
Tabellenwirkung. / *The eight `WithCtrl` occurrences are the listed control
keys. Four arrow keys and Enter complete the matrix. Every source token occurs
exactly once, and unknown keys gain no new spreadsheet effect.*

## Validator-Historie / Validator History

Ein erster StrictMode-Lauf endete vor der Produktprüfung wegen einer zu breiten
XML-Property-Auswahl. Ein zweiter beobachtbarer Kalibrierungslauf erwartete
fälschlich neun statt acht `WithCtrl`-Treffer und endete mit Exitcode `1`,
obwohl alle 13 Tokens exakt einmal gezählt wurden. Der abschließende XPath-
Vertrag verwendet die korrekte Matrixaufteilung `8 + 4 + 1` und bestand mit
Exitcode `0`. / *The first StrictMode run failed before product checks because
its XML property selection was too broad. A visible calibration run then
expected nine instead of eight control bindings and exited `1`, while still
counting all 13 tokens exactly once. The final XPath contract uses the correct
`8 + 4 + 1` split and passed with exit code `0`.*

## Artefaktbindung / Artefact Binding

- `Program.cs`: `081079aa729ea410ce02e562179a9e1f36278d108b9b5069e7d0ef47877a7f66`
- `MicroCalc.Tui.csproj`: `4ec7597b21443a7ba10204df46ad2e4148397cbceea4c533413f65a36e3b484c`
