#!/usr/bin/env bash
# Build and run LeetCode tests.
#
#   ./scripts/test.sh              build everything, run all tests
#   ./scripts/test.sh 0094         only problems whose folder matches "0094"
#   ./scripts/test.sh two_sum      matching works on any part of the folder name
#   ./scripts/test.sh -v 0094      also show output of passing tests
#
# Env: BUILD_DIR (default: build)
set -euo pipefail
cd "$(dirname "$0")/.."

verbose=(--output-on-failure)
if [[ "${1:-}" == "-v" ]]; then
    verbose=(-V)
    shift
fi
filter="${1:-}"
build_dir="${BUILD_DIR:-build}"

if [[ ! -f "$build_dir/CMakeCache.txt" ]]; then
    generator=()
    command -v ninja >/dev/null && generator=(-G Ninja)
    cmake -S . -B "$build_dir" "${generator[@]}" -DCMAKE_BUILD_TYPE=Debug
fi

if [[ -n "$filter" ]]; then
    # Build only the matching problems, so a half-written solution elsewhere
    # doesn't stop you from testing this one.
    # A trailing "_cpp" (the C++ test name, e.g. 0001_two_sum_cpp) selects only the C++ test.
    folder_filter="${filter%_cpp}"
    targets=()
    for dir in problems/*"$folder_filter"*/; do
        [[ -d "$dir" ]] || continue
        name=$(basename "$dir")
        number=${name%%_*}
        [[ -f "$dir/test.c" && "$folder_filter" == "$filter" ]] && targets+=("p$number")
        [[ -f "$dir/test.cpp" ]] && targets+=("p${number}_cpp")
    done
    if [[ ${#targets[@]} -eq 0 ]]; then
        echo "No problem folder matches '$filter' (looked in problems/)." >&2
        exit 1
    fi
    cmake --build "$build_dir" --target "${targets[@]}"
    ctest --test-dir "$build_dir" "${verbose[@]}" -R "$filter"
else
    # Keep going past compile errors so the other problems still get tested.
    keep_going=()
    [[ -f "$build_dir/build.ninja" ]] && keep_going=(-- -k 0)
    [[ -f "$build_dir/Makefile" ]] && keep_going=(-- -k)
    cmake --build "$build_dir" "${keep_going[@]}" || true
    ctest --test-dir "$build_dir" "${verbose[@]}"
fi
