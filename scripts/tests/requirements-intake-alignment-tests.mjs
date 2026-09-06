#!/usr/bin/env node

import fs from "node:fs";
import os from "node:os";
import path from "node:path";
import process from "node:process";
import {validate} from "../validate-requirements-intake-alignment.mjs";

const root = process.cwd();
const configSource = "requirements/intake-governance-config.json";
const manifestSource = "requirements/intakes/series/tinycalc-delivery/manifest.json";
const coverageSource = "specs/requirements-reconciliation-20260726/requirements-coverage.json";
const temp = fs.mkdtempSync(path.join(os.tmpdir(), "tinycalc-requirements-"));

function fixture(name, source, mutate) {
  const value = JSON.parse(fs.readFileSync(path.join(root, source), "utf8"));
  mutate(value);
  const target = path.join(temp, `${name}.json`);
  fs.writeFileSync(target, JSON.stringify(value, null, 2) + "\n");
  return target;
}

function expectFailure(name, options, pattern) {
  const errors = validate({root, ...options});
  if (!errors.some((error) => pattern.test(error))) {
    throw new Error(`${name} did not fail as expected: ${errors.join("; ")}`);
  }
}

if (validate({root}).length !== 0) throw new Error("positive fixture failed");
expectFailure("duplicate target", {
  manifestPath: fixture("duplicate-target", manifestSource, (value) =>
    value.orderedTargets.push({...value.orderedTargets[0]})),
}, /unique active targets/);
expectFailure("archive target", {
  manifestPath: fixture("archive-target", manifestSource, (value) => {
    value.orderedTargets[8].path = "requirements/intakes/archive/Missing.md";
  }),
}, /directory and series targets differ|archive or backlog/);
expectFailure("multiple eligible", {
  manifestPath: fixture("multiple-eligible", manifestSource, (value) => {
    const candidates = value.orderedTargets.filter((target) => target.status !== "Completed");
    if (candidates.length < 2) throw new Error("fixture needs two incomplete targets");
    candidates[0].status = "Eligible";
    candidates[1].status = "Eligible";
  }),
}, /at most one explicitly Eligible/);
expectFailure("schema 1 missing eligible", {
  configPath: fixture("schema1-missing-eligible-config", configSource, (value) => {
    value.schemaVersion = "1.0";
    value.activeIntakeCount = JSON.parse(fs.readFileSync(path.join(root, manifestSource), "utf8"))
      .orderedTargets.length;
    value.archiveIntakeCount = 0;
    value.preferredNext = JSON.parse(fs.readFileSync(path.join(root, manifestSource), "utf8"))
      .orderedTargets.find((target) => target.status !== "Completed").path;
  }),
}, /preferredNext requires exactly one explicitly Eligible/);
expectFailure("schema 1 mismatched eligible", {
  configPath: fixture("schema1-mismatched-eligible-config", configSource, (value) => {
    const manifest = JSON.parse(fs.readFileSync(path.join(root, manifestSource), "utf8"));
    const candidates = manifest.orderedTargets.filter((target) => target.status !== "Completed");
    if (candidates.length < 2) throw new Error("fixture needs two incomplete targets");
    value.schemaVersion = "1.0";
    value.activeIntakeCount = manifest.orderedTargets.length;
    value.archiveIntakeCount = 0;
    value.preferredNext = candidates[0].path;
  }),
  manifestPath: fixture("schema1-mismatched-eligible-manifest", manifestSource, (value) => {
    const candidates = value.orderedTargets.filter((target) => target.status !== "Completed");
    if (candidates.length < 2) throw new Error("fixture needs two incomplete targets");
    candidates[1].status = "Eligible";
  }),
}, /preferredNext must match the explicitly Eligible target/);
expectFailure("stale hash", {
  manifestPath: fixture("stale-hash", manifestSource, (value) => {
    value.orderedTargets[0].normalizedSha256 = "0".repeat(64);
  }),
}, /target hash drift/);
expectFailure("cycle", {
  manifestPath: fixture("cycle", manifestSource, (value) => {
    value.dependencies.push({
      from: value.orderedTargets[5].path,
      to: value.orderedTargets[0].path,
      kind: "HardCompletionGate",
      binding: true,
    });
    value.roots = value.roots.filter((item) => item !== value.orderedTargets[0].path);
  }),
}, /cycle/);
expectFailure("dangling target", {
  manifestPath: fixture("dangling", manifestSource, (value) => {
    value.orderedTargets[8].path = "requirements/intakes/active/Missing.md";
  }),
}, /directory and series targets differ|target is missing/);
expectFailure("duplicate requirement", {
  coveragePath: fixture("duplicate-requirement", coverageSource, (value) => {
    value.requirements[1].requirementId = value.requirements[0].requirementId;
  }),
}, /unique requirement IDs/);
expectFailure("missing owner", {
  coveragePath: fixture("missing-owner", coverageSource, (value) => {
    const openRequirement = value.requirements.find((item) =>
      ["Open", "PartiallySatisfied"].includes(item.status));
    if (!openRequirement) throw new Error("fixture has no open requirement to clear");
    openRequirement.proposedOwnerGroup = "N/A";
  }),
}, /lacks owner/);

fs.rmSync(temp, {recursive: true, force: true});
console.log("requirements/intake negative fixtures PASS (10 cases)");
