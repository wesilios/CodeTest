// Tests for {{NUMBER}}. {{TITLE}}
// Run: ./scripts/test.sh {{NUMBER4}}
#include "lc_test.h"
// #include "lc_tree.h"  // struct TreeNode + lc_tree_from_str("[1,null,2]")
// #include "lc_list.h"  // struct ListNode + lc_list_from_str("[1,2,3]")

#include "solution.c"

// Copy the examples from the problem page, then add edge cases.
// Example for "int* twoSum(int* nums, int numsSize, int target, int* returnSize)":
//
// TEST(example_1) {
//     int n;
//     int *nums = lc_parse_int_array("[2,7,11,15]", &n);
//     int size;
//     int *result = twoSum(nums, n, 9, &size);
//     EXPECT_INT_ARRAY_STR(result, size, "[0,1]");
//     free(result);
//     free(nums);
// }

TEST(write_tests) {
    EXPECT_TRUE(!"no tests yet: add some to test.c");
}

int main(void) {
    RUN(write_tests);
    return TEST_SUMMARY();
}
