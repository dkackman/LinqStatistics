#!/usr/bin/env bash
# Regenerates every T4 template (*.tt) in src/LinqStatistics and normalizes the
# output so it matches what Visual Studio's TextTemplatingFileGenerator produced:
#   - whitespace-only lines become empty lines
#   - trailing whitespace is removed
#   - files are written as UTF-8 with a BOM
#
# Usage: scripts/transform-t4.sh
# Requires the .NET SDK; dotnet-t4 is pinned in the repo's dotnet-tools.json.
set -euo pipefail

repo_root="$(cd "$(dirname "${BASH_SOURCE[0]}")/.." && pwd)"
template_dir="$repo_root/src/LinqStatistics"

cd "$repo_root"
dotnet tool restore >/dev/null

shopt -s nullglob
templates=("$template_dir"/*.tt)
if [ ${#templates[@]} -eq 0 ]; then
  echo "No .tt templates found in $template_dir" >&2
  exit 1
fi

failed=0
for tt in "${templates[@]}"; do
  out="${tt%.tt}.cs"
  if ! dotnet t4 "$tt" -o "$out"; then
    echo "FAILED: $tt" >&2
    failed=1
    continue
  fi
  # Strip any BOM and trailing whitespace, then write a single BOM back.
  perl -i -pe 's/^\x{EF}\x{BB}\x{BF}// if $. == 1; s/[ \t]+$//; $_ = "\x{EF}\x{BB}\x{BF}$_" if $. == 1' "$out"
done

if [ $failed -ne 0 ]; then
  exit 1
fi
echo "Transformed ${#templates[@]} templates."
