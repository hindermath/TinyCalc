# Wartungspaket-Abschluss / Maintenance package closeout

## Deutsch

Problem: Die verteilte Wartungskopie liegt hinter dem geprueften Level-0-Paket.
Loesung: Nur die deklarierten Wartungsdateien aus Home-Baseline PR #306 und
#307 synchronisieren. Dazu gehoeren Container-Delegation, gueltige Eventphasen,
explizite Profilwahl sowie UI-Abbruch vor Engine-Preflight. Kein TinyCalc-
Fachcode, keine Assembly-Version, Provider- oder Credential-Konfiguration wird
geaendert; kein Spec-Kit-Lauf wird gestartet.

Pruefplan: Paketgleichheit, Bash-Syntax, Wrapper-Tests, alle 15 eigenstaendigen
Delegations-Vertragstests, exakte staged Delivery-Sets und Statistikstatus.
Sieben weitere Delegations-Integrationsfaelle benoetigen zentrale Level-0-
Dateien; die vollstaendige Suite wird zentral und im Sandbox-Image geprueft.
Die Repository-CI bleibt vor Merge verbindlich. Risiko: Wartungsaufrufe,
nicht Tabellenkalkulationsfunktionen. Der Owner genehmigt MergeAndSync mit
begrenztem Admin-Bypass; keine Umgehung technischer Gates.

Documentation Impact: UpdateRequired. Kanonische Quelle und Owner:
Home-Baseline-Wartungspaket / Repository-Owner. Die mitverteilte zweisprachige
Manpage dient Maintainern; die bestehende Statistik bleibt kanonisch und wird
fortgeschrieben. Kein Home-Sync aus diesem Consumer-Repository.

## English

The distributed maintenance copy is behind the verified Level-0 package.
Synchronize only declared files from Home-Baseline PR #306 and #307, covering
container delegation, valid event phases, explicit profiles and UI cancellation
before engine preflight. No TinyCalc product code, assembly version, provider
or credential configuration changes; no Spec Kit run.

Validation covers package equality, Bash syntax, wrapper tests, all fifteen
self-contained delegation contract cases, exact staged delivery sets and
statistics status. Seven additional integration cases require canonical
Level-0 files and run in the complete central/image suite. Repository CI is
mandatory before merge. Risk concerns maintenance, not spreadsheet functions.
The Owner authorized MergeAndSync with bounded admin bypass, not bypassing
technical gates. Documentation Impact is UpdateRequired: the bilingual
canonical manpage and existing statistics serve maintainers. Repository Owner
owns delivery; consumers do not run Home sync.
