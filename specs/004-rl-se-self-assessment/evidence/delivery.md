# Liefernachweis Feature 004 / Feature 004 Delivery Evidence

## Deutscher Block

### Feature-PR und Exact-Head-Gates

| Feld | Nachweis |
|---|---|
| Repository | `hindermath/TinyCalc` |
| Pull Request | `#68`, `https://github.com/hindermath/TinyCalc/pull/68` |
| Gepruefter Head | `ebda8ad45d455f9a2a7d82daa73a86be0fecde50` |
| Finaler CI-Lauf | `33985257787`; Linux und Windows bestanden |
| Finaler Claude-Review | Lauf `33985257791`, Job `101357470647`, erfolgreich am exakten Head |
| Reviewzustand | null aktive Threads, null `Changes Requested` |
| PreMerge | Schema 2.0, 20/20 `Primary`, Hash `bacb87d1a195b6a3b45c94084aaccf3cb7e8f6de164f68dc39b32f1750f987c5` |
| Mergezeit | `2026-09-05T18:54:52Z` |
| Provider-Merge | `aa647ec39ff7b1013f19a551d9d34ca919069474` |
| Mergeform | Merge-Commit mit zwei Eltern; `--admin` nur fuer Ruleset `13146993` |
| Subject | `docs: assess RL-SE checklist compliance` |
| Co-author-Trailer | `Co-authored-by: Copilot <223556219+Copilot@users.noreply.github.com>` exakt einmal |
| Lokaler Sync | lokales `main`, `origin/main` und Provider-Merge waren nach `git pull --ff-only` identisch |

Die erste Provider-Runde auf Head `dc74bf0c83e2e86c19415c8ec8a1f447cbf4ff6d`
war technisch gruen, danach erschienen jedoch zwei neue Copilot-Threads. Sie
zeigten eine fehlende vollstaendige JSON-Schema-Auswertung und eine veraltete
Baseline-Angabe in der Hilfe. Beide Befunde wurden behoben und beantwortet.
Ein erster CI-Negativtest legte zudem eine plattformabhaengige Fehlerbehandlung
offen; die Fixture wird nun mit `Start-Process` isoliert. Erst die vollstaendig
gruene Runde am finalen Head wurde akzeptiert. Kein materielles Gate wurde
umgangen.

`REVIEW_REQUIRED` blieb danach als einzige formale Ruleset-Bedingung uebrig.
Der ausdruecklich genehmigte Admin-Bypass ersetzte nur diese fehlende formale
Code-Owner-Freigabe. Die technische Validierung, Security-, A11Y-, Evidence-,
Plattform- und Review-Gates blieben verbindlich.

### PostMerge und Serienfortschreibung

Der kausal nach dem Fast-Forward erzeugte PostMerge-Snapshot
`2921590b-4c8a-41c0-9f54-ee5089e86fbd` bindet den akzeptierten PreMerge-Hash,
den geprueften Feature-Head und den echten Provider-Merge. `changedPaths` ist
leer; der Schema-2.0-Validator meldete `mergeAuthorized: true`. Der
normalisierte PostMerge-Hash ist
`e18386d3b60faba07a1a320be0ea832b498278d5eb03ff29336f641af3834ca8`.

Der macOS-Bash-Einstieg benannte ausschliesslich
`Lastenheft_RL-SE-Checklist-Selbstpruefung.md` nach
`Lastenheft_RL-SE-Checklist-Selbstpruefung.004-rl-se-self-assessment.md` um.
Die Intake-Serie `tinycalc-delivery` wurde danach genau einmal fortgeschrieben:

- 13 Ziele, vier Wurzeln, neun Abhaengigkeiten und die Reihenfolge bleiben
  erhalten;
- RL-SE verwendet den branchgestempelten Pfad und ist `Completed`;
- GSDB ist der einzige deklarierte `Eligible`-Kandidat, wurde aber nicht
  gestartet;
- der TUI-Funktionsfeldtest bleibt strukturell frei, ist bis zur menschlichen
  Feldabnahme jedoch wieder `Pending`;
- Sandbox-Haertung bleibt `Pending`, sieben lineare Nachfolger bleiben
  `Blocked`;
- Manifest und Receipt des Vorgaengers sind byteidentisch unter
  `requirements/intakes/series-archive/tinycalc-delivery/20260905T185700Z/`
  archiviert;
- der fuer das Vorgaengermanifest gueltige Review
  `05b0ee98-6bd1-420c-a4bc-3ae15e59f1c4` ist byteidentisch unter dem
  gleichnamigen `-review`-Archiv supersediert; es wird kein aktueller Review
  erfunden oder in diesem Closeout gestartet;
- Operation `e8b26612-01d1-4dfb-94b3-f9f9b5231ec3` ist `Published`, Receipt
  `81b13f03-e73b-4ebf-a8fe-88aa0795ca8d` ist `Ready` und der neue Manifest-Hash
  lautet `24552c219bd516067da0c2fe6f6be39a935aac8f3e38f7237db9b505d68ad99b`.

Schema-2.0-Requirements-Governance, Manifest und Receipt bestanden jeweils in
PowerShell und Bash. Beide Order-Ansichten enthalten alle 13 aufgeloesten
Pfade genau einmal. Vorher-/Nachher-Hash und Git-Status der read-only
Statuspruefung waren identisch.

### Terminale getrackte Closeout-Grenze

Der Closeout-Head ist der einzige final amendierte Commit des Branches
`codex/004-rl-se-self-assessment-closeout` gegen Feature-Merge
`aa647ec39ff7b1013f19a551d9d34ca919069474`. Sein exakter SHA kann ohne
Selbstreferenz nicht in den eigenen Inhalt aufgenommen werden.

Nach dem finalen Amend folgen nur noch read-only Provideraktionen: ein
evidence-only PR, Checks und Reviews am unveraenderten Head, bei Bedarf der
bereits begrenzte formale Admin-Bypass, unmittelbare Merge-/Eltern-/Trailer-
Pruefung und lokaler Fast-Forward. Diese spaeteren Fakten werden ausschliesslich
in der ignorierten Datei
`.specify/runtime/autonomous-routing/faae97c9-e61b-480e-b6dd-24b8121868d0/closeout-provider-evidence.json`
gespeichert. Nach dem Closeout-Merge wird keine getrackte Datei mehr geaendert.

## English Block

### Feature PR and exact-head gates

| Field | Evidence |
|---|---|
| Repository | `hindermath/TinyCalc` |
| Pull request | `#68`, `https://github.com/hindermath/TinyCalc/pull/68` |
| Reviewed head | `ebda8ad45d455f9a2a7d82daa73a86be0fecde50` |
| Final CI run | `33985257787`; Linux and Windows passed |
| Final Claude review | Run `33985257791`, job `101357470647`, successful on the exact head |
| Review state | zero active threads and zero `Changes Requested` |
| PreMerge | Schema 2.0, 20/20 `Primary`, hash `bacb87d1a195b6a3b45c94084aaccf3cb7e8f6de164f68dc39b32f1750f987c5` |
| Merged at | `2026-09-05T18:54:52Z` |
| Provider merge | `aa647ec39ff7b1013f19a551d9d34ca919069474` |
| Merge form | Two-parent merge commit; `--admin` only for ruleset `13146993` |
| Subject | `docs: assess RL-SE checklist compliance` |
| Co-author trailer | `Co-authored-by: Copilot <223556219+Copilot@users.noreply.github.com>` exactly once |
| Local sync | local `main`, `origin/main`, and provider merge matched after `git pull --ff-only` |

Two Copilot findings arrived after the first technically green provider round.
They identified missing full JSON Schema enforcement and a stale help version.
Both were fixed and answered. An initial negative CI check also exposed
platform-specific process error handling; the fixture now runs in an isolated
`Start-Process` child. Only the fully green final-head round was accepted, and
no material gate was bypassed.

The remaining `REVIEW_REQUIRED` state was solely the formal code-owner rule.
The explicitly approved admin bypass replaced only that formal record. All
technical, security, accessibility, evidence, platform, and review gates
remained mandatory.

### Post-merge and series update

The causal PostMerge snapshot binds the accepted PreMerge hash, reviewed
feature head, and actual provider merge. It has an empty `changedPaths` list,
passes schema 2.0, and reports `mergeAuthorized: true`.

The macOS Bash entry point renamed only the RL-SE intake with the Feature 004
branch stamp. The one authorised `tinycalc-delivery` series update preserves
13 targets, four roots, nine dependencies, and order. RL-SE is `Completed`;
GSDB is the sole declared `Eligible` target but was not started. The TUI
functional field test remains structurally free but is `Pending` until human
field acceptance. The prior manifest and receipt are archived byte-identically.
The review that was valid for the predecessor manifest is also archived
byte-identically and marked superseded; this closeout neither fabricates nor
starts a successor review.
PowerShell and Bash validate schema-2.0 requirements governance, manifest, and
receipt; both order views contain all 13 resolved paths exactly once. The
read-only status inspection changed neither evidence hashes nor Git status.

### Terminal tracked closeout boundary

The closeout head is the one final amended commit on
`codex/004-rl-se-self-assessment-closeout`. Its future SHA cannot be embedded in
itself. After that amend, only read-only provider actions remain. Their exact
PR, check, review, merge, parent, trailer, and synchronization facts are stored
in the ignored runtime provider-evidence file. No tracked file is changed after
the closeout merge, and no GSDB run is started by this closeout.
