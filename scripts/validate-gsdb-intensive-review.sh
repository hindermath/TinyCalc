#!/usr/bin/env bash
set -euo pipefail

show_help() {
  printf '%s\n' \
    'Name / Name: validate-gsdb-intensive-review' \
    'Zweck / Purpose: Read-only validation of the intensive GSDB assessment.' \
    'Usage: validate-gsdb-intensive-review.sh [--action ACTION] [--assessment FILE] [--repository-root DIR]' \
    'Options:' \
    '  --action ACTION          Validate, ValidateFixtures, ValidateSources, ValidateCompendium, or ValidateMappings.' \
    '  --assessment FILE        Assessment JSON path.' \
    '  --repository-root DIR    Repository root.' \
    '  -h, --help               Show this help.'
}

action='Validate'
assessment='docs/security/gsdb-intensive-review/evidence-matrix.json'
repository_root='.'

while [ "$#" -gt 0 ]; do
  case "$1" in
    --action)
      [ "$#" -ge 2 ] || { printf '%s\n' 'GSDB001: --action requires a value.' >&2; exit 1; }
      action=$2
      shift 2
      ;;
    --assessment)
      [ "$#" -ge 2 ] || { printf '%s\n' 'GSDB001: --assessment requires a value.' >&2; exit 1; }
      assessment=$2
      shift 2
      ;;
    --repository-root)
      [ "$#" -ge 2 ] || { printf '%s\n' 'GSDB001: --repository-root requires a value.' >&2; exit 1; }
      repository_root=$2
      shift 2
      ;;
    -h|--help)
      show_help
      exit 0
      ;;
    --)
      shift
      break
      ;;
    *)
      printf '%s\n' 'GSDB001: unknown option.' >&2
      exit 1
      ;;
  esac
done

if [ "$#" -ne 0 ]; then
  printf '%s\n' 'GSDB001: positional arguments are not accepted.' >&2
  exit 1
fi

case "$action" in
  Validate|validate) action='Validate' ;;
  ValidateFixtures|validate-fixtures) action='ValidateFixtures' ;;
  ValidateSources|validate-sources) action='ValidateSources' ;;
  ValidateCompendium|validate-compendium) action='ValidateCompendium' ;;
  ValidateMappings|validate-mappings) action='ValidateMappings' ;;
  *)
    printf '%s\n' 'GSDB001: unsupported action.' >&2
    exit 1
    ;;
esac

script_dir=$(CDPATH= cd -- "$(dirname -- "$0")" && pwd)
exec pwsh -NoProfile -File "$script_dir/validate-gsdb-intensive-review.ps1" \
  -Action "$action" -Assessment "$assessment" -RepositoryRoot "$repository_root"
