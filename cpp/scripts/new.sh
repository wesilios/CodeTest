#!/usr/bin/env bash
# Create a new problem folder from the templates.
#
#   ./scripts/new.sh <number> <slug> [c|cpp]
#   ./scripts/new.sh 1 two-sum cpp     -> problems/0001_two_sum/{solution.cpp,test.cpp}
#
# <slug> is the part of the LeetCode URL after /problems/.
# Running it again with the other language adds that language to the same folder.
set -euo pipefail
cd "$(dirname "$0")/.."

if [[ $# -lt 2 ]]; then
    sed -n '2,8p' "$0" | sed 's/^# \{0,1\}//'
    exit 1
fi

number=$(printf '%04d' "$((10#$1))")
slug=$(echo "$2" | tr '[:upper:]' '[:lower:]')
lang="${3:-c}"

if [[ "$lang" != "c" && "$lang" != "cpp" ]]; then
    echo "Language must be 'c' or 'cpp', got '$lang'." >&2
    exit 1
fi

dir="problems/${number}_${slug//-/_}"
title=$(echo "$slug" | tr '-' ' ' | awk '{ for (i = 1; i <= NF; i++) $i = toupper(substr($i, 1, 1)) substr($i, 2) } 1')

for file in "solution.$lang" "test.$lang"; do
    if [[ -e "$dir/$file" ]]; then
        echo "$dir/$file already exists, not overwriting." >&2
        exit 1
    fi
done

mkdir -p "$dir"
for file in "solution.$lang" "test.$lang"; do
    sed -e "s|{{NUMBER}}|$((10#$number))|g" \
        -e "s|{{NUMBER4}}|$number|g" \
        -e "s|{{TITLE}}|$title|g" \
        -e "s|{{SLUG}}|$slug|g" \
        "templates/$file" > "$dir/$file"
done

echo "Created $dir/solution.$lang and $dir/test.$lang"
echo "Next: paste LeetCode's starter code into solution.$lang, add tests, then run ./scripts/test.sh $number"
