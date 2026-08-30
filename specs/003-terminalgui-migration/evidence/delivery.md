# Liefernachweis Feature 003 / Feature 003 Delivery Evidence

## Deutscher Block

### Produktmerge

| Feld | Nachweis |
|---|---|
| Repository | `hindermath/TinyCalc` |
| Pull Request | `#60`, `https://github.com/hindermath/TinyCalc/pull/60` |
| Geprüfter Head | `d0a5bd435488d9c57a905f883e6c90a919b0c134` |
| Mergezeit | `2026-08-30T14:49:19Z` |
| Tatsächlicher Merge-Commit | `43e47d9a31b6c3bc79d58d834f95bf8dfecb5595` |
| Mergeverfahren | Merge-Commit; enger `--admin`-Bypass nur für Ruleset `13146993` |
| Provider-Prüfung | `gh pr view` meldete `MERGED`; `gh api` las die tatsächliche Commitnachricht unmittelbar danach |
| Co-author-Trailer | `Co-authored-by: Copilot <223556219+Copilot@users.noreply.github.com>` exakt einmal |
| Lokaler Sync | `git switch main` und `git pull --ff-only`; lokales `main`, `origin/main` und Merge-Commit sind `43e47d9a31b6c3bc79d58d834f95bf8dfecb5595` |

Der Merge erfolgte erst nach grünen Checks auf Linux und Windows, einem
erfolgreichen unabhängigen Claude-Code-Review, null offenen Review-Threads,
null Changes Requested, Schema-2.0-PreMerge-Validierung und unverändertem
Head. Der Admin-Bypass ersetzte nur den formalen Approval-/Code-Owner-Datensatz
des Repository-Rulesets.

Der lokale Fast-Forward-Sync ist abgeschlossen. PostMerge-Evidenz und kausaler
Closeout bleiben bis zu den jeweils nachfolgenden Aufgaben offen und werden
nicht vorweggenommen.

## English Block

### Product merge

| Field | Evidence |
|---|---|
| Repository | `hindermath/TinyCalc` |
| Pull request | `#60`, `https://github.com/hindermath/TinyCalc/pull/60` |
| Reviewed head | `d0a5bd435488d9c57a905f883e6c90a919b0c134` |
| Merged at | `2026-08-30T14:49:19Z` |
| Actual merge commit | `43e47d9a31b6c3bc79d58d834f95bf8dfecb5595` |
| Merge method | Merge commit; narrow `--admin` bypass only for ruleset `13146993` |
| Provider verification | `gh pr view` reported `MERGED`; `gh api` read the actual commit message immediately afterwards |
| Co-author trailer | `Co-authored-by: Copilot <223556219+Copilot@users.noreply.github.com>` exactly once |
| Local sync | `git switch main` and `git pull --ff-only`; local `main`, `origin/main`, and the merge commit are `43e47d9a31b6c3bc79d58d834f95bf8dfecb5595` |

The merge occurred only after green Linux and Windows checks, a successful
independent Claude code review, zero open review threads, zero Changes
Requested, schema-2.0 PreMerge validation, and an unchanged head. The admin
bypass replaced only the repository ruleset's formal approval/code-owner
record.

Local fast-forward synchronization is complete. PostMerge evidence and the
causal closeout remain pending until their respective later tasks.

## PostMerge-Bindung / PostMerge Binding

Der kausal nach dem Fast-Forward erzeugte Snapshot
`1fae8503-6a70-45fd-8353-11326bc37b67` bindet den akzeptierten PreMerge-Hash
`83b7cd2fdcea4e9417cd4d3d8eb4bfd6419129a0835a9b9b5a511cd824a14acf` und den
tatsächlichen Merge-Commit `43e47d9a31b6c3bc79d58d834f95bf8dfecb5595`.
Seine `changedPaths` sind leer, und der Schema-2.0-Validator bestand. Der
normalisierte Snapshot-Hash ist
`a06005a939644b199de57fd01f4252ab75461afd5960e3381d29757305702377`.

*The snapshot created causally after fast-forward synchronization binds the
accepted PreMerge hash and the actual merge commit. Its changed-path list is
empty, and schema-2.0 validation passed. The normalized snapshot hash is shown
above.*

## Closeout-Head und terminale Proof-Grenze / Closeout Head and Terminal Proof Boundary

Der Closeout-Head ist der einzige final amendierte Commit des Branches
`codex/003-terminalgui-migration-closeout` gegen Produkt-Merge-Commit
`43e47d9a31b6c3bc79d58d834f95bf8dfecb5595`. Seine Identität lautet
`T078-single-amended-closeout-commit`; der exakte Git-SHA wird unmittelbar nach
dem Amend read-only ermittelt, weil er nicht ohne Selbstreferenz in den eigenen
Inhalt aufgenommen werden kann.

Dieser getrackte Nachweis erwartet danach genau folgende Provider-Prüfung:

1. genau einen Closeout-PR vom vorbenannten Branch nach `main`;
2. grüne Pflichtchecks, unveränderten Head, unabhängigen befundfreien Review,
   null offene Threads und null Changes Requested;
3. `MergeAndSync` mit Admin-Bypass nur bei derselben engen formalen Policy-
   Blockade wie beim Produkt-PR;
4. unmittelbares read-only Lesen des tatsächlichen Merge-Commits und genau
   einer Co-author-Trailerzeile;
5. Fast-Forward-Sync von lokalem und remote `main` auf diesen Merge-Commit.

T077 ist die terminale getrackte Proof-Grenze. Nach dem T078-Amend werden alle
exakten Closeout-Head-/PR-/Check-/Review-/Merge-/Trailer-/Sync-Fakten nur in
`.specify/runtime/autonomous-routing/38ad4c1d-bf85-4053-b585-eb490176b727/closeout-provider-evidence.json`
gespeichert. Diese Datei und der operative Run-State sind lokal ignoriert und
gehören nicht zum Delivery-Set; nach dem Closeout-Merge gibt es keinen weiteren
getrackten Write.

*The closeout head is the branch's single commit completed by the T078 amend.
Its exact SHA is captured read-only afterwards because a commit cannot embed its
own final SHA. This file is the terminal tracked proof boundary. All later exact
provider facts are stored only in ignored runtime evidence, and no tracked file
is changed after the closeout merge.*
