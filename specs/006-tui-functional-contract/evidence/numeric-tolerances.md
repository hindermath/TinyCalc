# Numerische Toleranzen / Numeric tolerances

## Deutscher Reviewblock

Vor Ausführung festgelegt, 2026-10-10. Integer-, Text-, Adress-, Flag-, Fokus-
und Datei-Invarianten werden exakt verglichen. Für binär exakt darstellbare
Operatororakel gilt ebenfalls exakte Gleichheit (512, -4, 4, 0.25, 1, 2).
Ergebnisse müssen immer endlich sein. Ein Fehlerorakel darf nie durch NaN oder
Unendlich als erfolgreiche Zahl erfüllt werden.

SIN/COS/ARCTAN und LN/LOG/EXP: absolute Toleranz `1e-12` für die kleinen,
explizit dokumentierten Orakel. Das berücksichtigt Double-Rundung und das
numerische π-Literal, nicht eine andere Winkeleinheit oder Logarithmusbasis.
FACT(33): relative Toleranz `1e-14` zum unabhängigen mathematischen Sollwert
`8.683317618811886e36`; Integer-Fälle bis FACT(5) bleiben exakt.
ROUND-/AVERAGE-Dezimalfälle: absolute Toleranz `1e-12`, ohne eine falsche
Halbwert- oder Präzisionsregel zu akzeptieren. Rohpräzisions- und Fehlergrenzen
werden exakt klassifiziert. Keine pauschale Toleranz für alle Vertragsergebnisse.

Infrastrukturfristen 30/180/5 Sekunden pro Schritt/Sitzung/Cleanup sind initiale
Sicherheitsgrenzen, keine gemessene Produkt-SLA. Timeout liefert Fail und sperrt
das Bundle; nur eigene Ressourcen bereinigen. Änderung erfordert neue Decision.

## English review block

Established before execution on 2026-10-10. Integer, text, address, flag, focus,
file and exactly representable operator expectations are exact. Every successful
numeric result must be finite. Domain errors cannot pass as NaN or infinity.
Use absolute `1e-12` for the documented small transcendental oracles; this covers
Double rounding and the numeric π literal, not a different angle unit/base.
FACT(33) uses relative `1e-14` against the independent mathematical value above;
small integer factorials remain exact. ROUND/AVERAGE decimal cases use absolute
`1e-12`, while midpoint, raw precision and error classifications remain exact.
These are per-oracle rules, not a blanket weakening.

The reviewed 30/180/5-second step/session/cleanup limits bound infrastructure,
not product performance. Timeouts fail and invalidate bundles; clean up only
owned resources. Any adjustment requires a newly bound decision.
