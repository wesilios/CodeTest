# C/C++ LeetCode workspace

Write a LeetCode solution in C or C++, test it locally, then paste it into LeetCode.

## Workflow

```bash
cd cpp
./scripts/new.sh 1 two-sum c        # or cpp. Slug = the part of the URL after /problems/
# 1. paste LeetCode's starter code into problems/0001_two_sum/solution.c and solve it
# 2. add test cases to problems/0001_two_sum/test.c
./scripts/test.sh 0001              # build + run just this problem
# 3. all green? paste solution.c into LeetCode
```

`./scripts/test.sh` with no argument runs every problem. `-v` also shows the output of passing tests. The filter matches any part of the folder name (`0094`, `two_sum`, `tree`). Add `_cpp` to pick only the C++ version (`0001_two_sum_cpp`).

You can add both languages for the same problem: `new.sh 1 two-sum c`, then `new.sh 1 two-sum cpp`.

## Layout

```
problems/0094_binary_tree_inorder_traversal/
    solution.c     what you submit to LeetCode, no main(), no test code
    test.c         #includes solution.c and checks it
include/           test framework and helpers (lc_*.h)
templates/         starting files used by new.sh
playground/        scratch program: cmake --build build --target playground && build/playground
```

Every `problems/*/test.c` and `test.cpp` becomes its own program (`build/p0094`, `build/p0001_cpp`). New folders are found automatically, so you never edit `CMakeLists.txt`.

**Leave `struct TreeNode` / `struct ListNode` commented out in `solution.c`,** the way LeetCode's starter code has them. LeetCode already defines them, and so do the test helpers. Defining them again is a compile error in both places.

## Writing tests

Write inputs and expected outputs in LeetCode's text format, so you can copy the examples from the problem page.

### C (`#include "lc_test.h"`)

```c
TEST(example_1) {
    int n;
    int *nums = lc_parse_int_array("[2,7,11,15]", &n);
    int size;
    int *result = twoSum(nums, n, 9, &size);
    EXPECT_INT_ARRAY_STR(result, size, "[0,1]");
    free(result);                     // LeetCode's "returned array must be malloced"
    free(nums);
}

int main(void) {
    RUN(example_1);
    return TEST_SUMMARY();
}
```

| Check (always `actual, expected`) | For |
|---|---|
| `EXPECT_TRUE(x)` / `EXPECT_FALSE(x)` | conditions |
| `EXPECT_EQ_INT(a, e)` | any integer type |
| `EXPECT_EQ_BOOL(a, e)` | `bool` results, printed as true/false |
| `EXPECT_EQ_DBL(a, e, eps)` | floating point |
| `EXPECT_EQ_STR(a, e)` | C strings (NULL allowed) |
| `EXPECT_INT_ARRAY(a, n, e, m)` | int arrays, same order |
| `EXPECT_INT_ARRAY_STR(a, n, "[1,2]")` | int array vs LeetCode text |
| `EXPECT_INT_MATRIX_STR(a, rows, colSizes, "[[1],[2,3]]")` | `int**` results with `returnColumnSizes` |

`TEST_CONTEXT("n = %d", n)` adds a line to any failure in the current test, which helps in loops.

| Helper | Header |
|---|---|
| `lc_parse_int_array`, `lc_parse_int_matrix`, `lc_parse_str_array`, `lc_int_array_to_str` | `lc_parse.h` (included by `lc_test.h`) |
| `struct TreeNode`, `lc_tree_from_str("[1,null,2]")`, `lc_tree_to_str`, `lc_tree_free`, `lc_tree_free_many` (trees sharing nodes) | `lc_tree.h` |
| `struct ListNode`, `lc_list_from_str("[1,2,3]")`, `lc_list_to_str`, `lc_list_free` | `lc_list.h` |

### C++ (`#include "lc_cpp.hpp"`)

Like LeetCode, it provides the whole STL, `using namespace std;`, `TreeNode` and `ListNode`. It also includes `lc_test.h`, so all the C checks work, plus a generic `EXPECT_EQ` for vectors, strings and anything with `==`:

```cpp
TEST(example_1) {
    auto nums = vec("[2,7,11,15]");   // a named variable: LeetCode methods take vector<int>&
    EXPECT_EQ(Solution().twoSum(nums, 9), vec("[0,1]"));
    EXPECT_EQ(Solution().twoSum(nums, 9), vector<int>{0, 1});  // also fine
}
```

Helpers: `vec`, `vec2d`, `strvec`, `buildTree` / `treeToString` / `freeTree`, `buildList` / `listToString` / `freeList`. To compare trees or lists, compare their strings: `EXPECT_EQ(treeToString(root), "[1,2,3]")`. Comparing the pointers checks identity, not contents.

## Memory checking

Tests are built with AddressSanitizer and UndefinedBehaviorSanitizer. Out-of-bounds access, use-after-free, signed overflow and (in C) memory leaks make the test fail, with a stack trace pointing at the bad line of `solution.c`. LeetCode runs the same sanitizer, so these are real bugs. The exception is leaks: LeetCode doesn't check for them, so C++ tests ignore leaks, since `new`-ing nodes without deleting is normal there. To ignore leaks in C for one run: `ASAN_OPTIONS=detect_leaks=0 build/p0094`.

## Debugging

```bash
gdb build/p0094                                        # break inorderTraversal, run, next, print ...
cmake -S . -B build-nosan -DLC_SANITIZE=OFF && cmake --build build-nosan
valgrind --leak-check=full build-nosan/p0094           # valgrind needs a build without sanitizers
```

CLion: open `cpp/` as a CMake project. Each problem is a run/debug target (`p0094`), and the CTest tests show up in the test runner.
