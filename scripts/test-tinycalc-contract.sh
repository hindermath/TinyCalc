#!/usr/bin/env bash
# DE: Bash-3-Einstieg derselben ausschließlich lesenden PowerShell-Engine.
# EN: Bash 3 entry point for the same read-only PowerShell engine.
set -euo pipefail
script_dir="$(cd -- "$(dirname -- "${BASH_SOURCE[0]}")" && pwd -P)"
args=()
while [ "$#" -gt 0 ]; do
  case "$1" in
    --repository-root|--contract|--source-map|--evidence|--pin-decision|--impact-decision|--evidence-root|--gate-evidence)
      if [ "$#" -lt 2 ] || [ -z "$2" ]; then
        printf '%s\n' 'Fehlender Parameterwert. / Missing parameter value.' >&2
        exit 2
      fi
      case "$1" in
        --repository-root) name='RepositoryRoot' ;;
        --contract) name='Contract' ;;
        --source-map) name='SourceMap' ;;
        --evidence) name='Evidence' ;;
        --pin-decision) name='PinDecision' ;;
        --impact-decision) name='ImpactDecision' ;;
        --evidence-root) name='EvidenceRoot' ;;
        --gate-evidence) name='GateEvidence' ;;
      esac
      args+=("-$name" "$2")
      shift 2
      ;;
    --json) args+=('-Json'); shift ;;
    --dry-run) args+=('-WhatIf'); shift ;;
    --help|-h)
      printf '%s\n' 'TUI-Vertragsprüfung, ausschließlich lesend. / Read-only TUI contract validation.' \
        'Options: --repository-root --contract --source-map --evidence --pin-decision --impact-decision' \
        '         --evidence-root --gate-evidence --json --dry-run --help' \
        'Exit 0: valid; 1: violation; 2: blocked/invalid input. No acceptance or delivery authority.'
      exit 0
      ;;
    *) printf '%s\n' 'Unbekannte Option. / Unknown option.' >&2; exit 2 ;;
  esac
done
if ! command -v pwsh >/dev/null 2>&1; then
  printf '%s\n' 'PowerShell 7 fehlt. / PowerShell 7 is required.' >&2
  exit 2
fi
exec pwsh -NoLogo -NoProfile -File "$script_dir/test-tinycalc-contract.ps1" "${args[@]}"
