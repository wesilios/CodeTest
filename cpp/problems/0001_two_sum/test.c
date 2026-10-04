// Tests for 1. Two Sum
// Run: ./scripts/test.sh 0001
#include "lc_test.h"

#include "solution.c"

// The answer may be returned in any order, so sort the two indices before
// comparing. Expected is LeetCode text with the smaller index first, e.g. "[0,1]".
#define CHECK(nums_text, target, expected) \
    do { \
        int n; \
        int *nums = lc_parse_int_array(nums_text, &n); \
        int size = -1; \
        TEST_CONTEXT("nums = %s, target = %d", nums_text, target); \
        int *result = twoSum(nums, n, target, &size); \
        if (result != NULL && size == 2 && result[0] > result[1]) { \
            int tmp = result[0]; \
            result[0] = result[1]; \
            result[1] = tmp; \
        } \
        EXPECT_INT_ARRAY_STR(result, size, expected); \
        free(result); \
        free(nums); \
    } while (0)

// Examples from the problem page
TEST(example_1) { CHECK("[2,7,11,15]", 9, "[0,1]"); }
TEST(example_2) { CHECK("[3,2,4]", 6, "[1,2]"); }
TEST(example_3) { CHECK("[3,3]", 6, "[0,1]"); }

// Edge cases (constraints: 2 <= length <= 10^4, -10^9 <= nums[i], target <= 10^9,
// exactly one valid answer, and the same element can't be used twice)
TEST(minimum_length) { CHECK("[1,2]", 3, "[0,1]"); }
TEST(same_element_not_reused) { CHECK("[5,1,3]", 4, "[1,2]"); } // 2 + 2 is not allowed
TEST(negative_numbers) {
    CHECK("[-1,-2,-3,-4,-5]", -8, "[2,4]");
    CHECK("[-3,4,3,90]", 0, "[0,2]");
}
TEST(zeros) { CHECK("[0,4,3,0]", 0, "[0,3]"); }
TEST(pair_at_the_end) { CHECK("[1,2,3,4,5,6]", 11, "[4,5]"); }
TEST(pair_far_apart) { CHECK("[8,1,2,3,4,9]", 17, "[0,5]"); }
// nums[i] and target both sit at the +/-10^9 limits.
TEST(boundary_values) {
    CHECK("[1000000000,-1000000000,3]", 0, "[0,1]");
    CHECK("[7,1000000000,0]", 1000000000, "[1,2]");
    CHECK("[7,-1000000000,0]", -1000000000, "[1,2]");
    // target - nums[0] = 2 * 10^9: still fits in an int, but only just.
    CHECK("[-1000000000,3,999999997]", 1000000000, "[1,2]");
}

// Largest input allowed by the constraints: 10^4 numbers, answer at the very end.
TEST(max_length) {
    int n = 10000;
    int *nums = (int *)malloc(n * sizeof(int));
    for (int i = 0; i < n; i++) {
        nums[i] = i * 2; // all even, so no earlier pair can hit an odd target
    }
    nums[n - 2] = 1;
    nums[n - 1] = 999999998;
    int size = -1;
    int *result = twoSum(nums, n, 999999999, &size);
    if (result != NULL && size == 2 && result[0] > result[1]) {
        int tmp = result[0];
        result[0] = result[1];
        result[1] = tmp;
    }
    EXPECT_INT_ARRAY_STR(result, size, "[9998,9999]");
    free(result);
    free(nums);
}

int main(void) {
    RUN(example_1);
    RUN(example_2);
    RUN(example_3);
    RUN(minimum_length);
    RUN(same_element_not_reused);
    RUN(negative_numbers);
    RUN(zeros);
    RUN(pair_at_the_end);
    RUN(pair_far_apart);
    RUN(boundary_values);
    RUN(max_length);
    return TEST_SUMMARY();
}
