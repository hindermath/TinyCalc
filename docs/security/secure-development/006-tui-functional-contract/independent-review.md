# Unabhängiger Review-Nachweis / Independent review evidence

## Abschlussdisposition 11.10.2026 / Closeout disposition

Der genehmigte unabhängige Reviewer prüfte zusätzlich das reine Dokumentations-/
Versionsdelta `a9759f5..737348d` sowie die tatsächliche kopierte Releaseausgabe
mit 51 Dateien, macOS-Originale, 671 Tests/364 Pfade/462 Assertions, SBOM und
24 Lizenzbindungen read-only: kein neuer konkreter Korrekturbedarf.
Die [Humanabnahme](../../../../specs/006-tui-functional-contract/evidence/human-acceptance-20261011.md)
liegt jetzt vor; ursprüngliche Reviewrevisionen werden nicht umetikettiert.

Die Feature-Anforderungen benennen fachliche Security-/Architektur-/unabhängige
Review-Gates, keinen bestimmten Provider. Diese tatsächlichen Reviews erfüllen
den fachlichen Umfang. Der zusätzliche Claude-Providerjob bleibt Nicht-Pass,
keine fachliche Zustimmung. Nur eine danach verbleibende formale zusätzliche
Provider-/Approvalregel ist vom aktuellen Admin-Auftrag erfasst; offene
fachliche Befunde oder zusätzliche materielle Remote-Anforderungen nicht.

*The separately approved reviewer verified the documentation/version-only
candidate delta and actual frozen output/evidence without new actionable issues.
Human acceptance is now present. Substantive review obligations are fulfilled
by actual independent reviews, not a provider name. Claude execution failure
remains a non-pass; formal-rule authority never waives substantive findings.*

## Deutscher Nachweis

2026-10-10. Thorsten hat einen unabhängigen read-only Review-Agenten ausdrücklich
genehmigt. Reviewer: `independent_closeout_review`; getrennt vom implementierenden
Hauptagenten. Unveränderlicher Vergleich:
`ffc3d56a8975341a686ff6985570369abefcfd2a..6a1154d4887e7e8e42f08365245dede0982145c1`.
Der Reviewer hat keine Dateien geändert, Tests gestartet oder URLs abgerufen.

Alle 29 Quellinventar-Einträge des Security-Diff-Scans wurden geprüft: produktives
C#, Paketlocks, Collector/Validator/PowerShell/Bash, Workflow und Entscheidungen.
Direkte Unterstützungsprüfung umfasste geänderte C#-Tests, relevante Schemas und
Fixtures, Spec/Plan/Tasks, Architektur, ADR und S-ADR. Kein Anspruch auf eine
vollständige unabhängige redaktionelle Prüfung aller157 geänderten Artefakte.

Ergebnis: Schichten/Core-Trennung, tatsächliche UI-Injektion, serielle
Frameworkzustands-Rücksetzung, feste Prozessargumente/Fristen, atomare Ausgaben,
Pfad-/Symlink-/DTD-/TRX-/Hash-/Historienkontrollen entsprechen der Architektur.
NIST SSDF, CWE Top25, insbesondere CWE-20/22/400, und Constitution XII–XIII
wurden konkret auf diese Grenzen angewendet, keine Zertifizierung behauptet.

Ein echter Fehler C006-01 betraf die JSON-Größengrenze: vollständiges Einlesen
vor der 20-MiB-Prüfung. Ein gezielter öffentlicher Regressionstest war zuerst
rot. Danach begrenzt ein gemeinsamer Streamleser Bytes vor der Allokation und
auch bei Wachstum; Parser und Digest erhalten denselben strikten UTF-8-Snapshot.
Grün: übergroße Datei Blocked/InvalidInputSize,2735432 allokierte Bytes statt
der vollständigen Datei; Snapshot und ungültiges UTF-8 geprüft. Kein OOM-Test.
Der Reviewer hat diese Korrektur und das kleine DocFX-Overlay separat read-only
geprüft und ohne weiteren konkreten Korrekturbedarf freigegeben. Die ursprüngliche
Reviewrevision wurde dabei nicht umetikettiert.

| Ignoriertes Original unter tests/MicroCalc.Tui.Tests/TestResults | SHA-256 |
|---|---|
| 006-json-boundary-red.log | 3a066a0ea0893bf41225af52f1e765135d0f99d383fbcd7269fdeec17105bd78 |
| 006-json-boundary-green.log | fdfcbbb740d03b3479f3c16b820cc29fc6e8c140132d263b7a0107549c8bfc8d |

Der versiegelte Security-Scan `a91a8890-f0d5-44d5-b013-757806860334` hält
Discovery, Validation und Attack-Path-Entscheidung getrennt fest. C006-01 ist
eine behobene Ressourcen-Korrektur; mangels nachgewiesenem niedrigprivilegiertem
Angriffspfad und wegen lokalem operatorgesteuertem Einzelprozess-Impact kein
reportbarer Securityfund nach der Scan-Policy. Das war keine Risikoakzeptanz
und kein Grund, die tatsächliche Korrektur auszulassen.

Restrisiko: Die Coverage-Messung schneidet Reportzeilen mit Änderungszeilen.
Ein künftig vollständig fehlender geänderter Dateieintrag muss separat erkannt
werden. Im Build105 sind alle neun geänderten Produktdateien einschließlich
unbedeckter Zeilen enthalten; kein Nachweis einer aktuellen Aufblähung von488/503.
Owner Feature-Entwicklung, Trigger vor dem nächsten geänderten Coverage-Collector.

Offen bleiben reale VoiceOver-Bedienung, Owner-Produktentscheidung, finale
gemeinsame Plattform-/Headbindung und Lieferprovenienz. Dieser Quellreview
ersetzt diese Grenzen und den zurückgestellten Claude-Providerfehler nicht.

## English evidence

The separately authorised read-only reviewer inspected all29 authoritative source
inventory entries in the immutable range and directly supporting tests, schemas,
architecture and security decisions. It did not modify files, run tests or fetch
URLs; it is not a claim of editorial review of every157 changed artefacts.
Architecture and concrete input/file/process/evidence controls match the plan.

One actual resource-limit bug was corrected after a failing public-entry test:
bounded stream reads precede complete allocation and protect against growth;
strict UTF-8 parsing and digests share one snapshot. The same independent reviewer
approved the explicit working-tree delta and DocFX overlay. Original and delta
review bindings remain separate. The sealed scan retains the candidate and
policy suppression for operator-only impact; suppression never replaced the fix.
Current coverage includes all nine changed product files. Future missing-file
instrumentation is a recorded limitation, not an invented current failure.
Human VoiceOver, owner acceptance, final common-head proof and provenance remain
mandatory. No certification, human pass or deferred-provider pass is claimed.
