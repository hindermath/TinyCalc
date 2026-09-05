#!/usr/bin/env bash
set -euo pipefail

usage() {
  cat <<'EOF'
DE: Prueft die TinyCalc-RL-SE-Selbstbewertung mit dem gemeinsamen PowerShell-Vertrag.
EN: Validates the TinyCalc RL-SE self-assessment through the shared PowerShell contract.

Usage:
  validate-rl-se-assessment.sh [--assessment PATH] [--repository-root PATH]
EOF
}

assessment='docs/security/secure-development/2026-09-05-rl-se-self-assessment/assessment-matrix.json'
repository_root='.'

while (($# > 0)); do
  case "$1" in
    --assessment)
      if (($# < 2)); then
        printf 'RLSE_VALIDATION_BLOCKED: --assessment requires a path\n' >&2
        exit 2
      fi
      assessment=$2
      shift 2
      ;;
    --repository-root)
      if (($# < 2)); then
        printf 'RLSE_VALIDATION_BLOCKED: --repository-root requires a path\n' >&2
        exit 2
      fi
      repository_root=$2
      shift 2
      ;;
    -h|--help)
      usage
      exit 0
      ;;
    *)
      printf 'RLSE_VALIDATION_BLOCKED: unknown argument: %s\n' "$1" >&2
      usage >&2
      exit 2
      ;;
  esac
done

script_dir=$(CDPATH= cd -- "$(dirname -- "$0")" && pwd)
exec pwsh -NoProfile -File "$script_dir/validate-rl-se-assessment.ps1" \
  -RepositoryRoot "$repository_root" \
  -Assessment "$assessment"
