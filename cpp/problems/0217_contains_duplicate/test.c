// Tests for 217. Contains Duplicate
// Run: ./scripts/test.sh 0217
#include "lc_test.h"

#include "solution.c"

// Parses the LeetCode array text, runs containsDuplicate and checks the result.
#define CHECK(nums_text, expected) \
    do { \
        int n; \
        int *nums = lc_parse_int_array(nums_text, &n); \
        TEST_CONTEXT("nums = %s", nums_text); \
        EXPECT_EQ_BOOL(containsDuplicate(nums, n), expected); \
        free(nums); \
    } while (0)

// Examples from the problem page
TEST(example_1) { CHECK("[1,2,3,1]", true); }
TEST(example_2) { CHECK("[1,2,3,4]", false); }
TEST(example_3) { CHECK("[1,1,1,3,3,4,3,2,4,2]", true); }

// Edge cases
TEST(single_element) { CHECK("[7]", false); }
TEST(two_equal) { CHECK("[5,5]", true); }
TEST(duplicate_at_both_ends) { CHECK("[9,1,2,3,4,5,6,7,8,9]", true); }
TEST(negative_numbers) { CHECK("[-1,-2,-3,-1]", true); }
TEST(negative_and_positive_same_abs) { CHECK("[-3,3,-2,2,0]", false); }
TEST(int_limits) {
    CHECK("[-2147483648,2147483647,0]", false);
    CHECK("[-2147483648,2147483647,-2147483648]", true);
}
// Different values that land in the same bucket of an 11-slot hash table (x mod 11 == 10).
// Catches hash tables that compare buckets instead of values.
TEST(values_that_collide_in_a_small_table) { CHECK("[10,-1,21,-12,32]", false); }

// Largest input allowed by the constraints: 10^5 numbers.
TEST(max_size_all_unique) {
    int n = 100000;
    int *nums = (int *)malloc(n * sizeof(int));
    for (int i = 0; i < n; i++) nums[i] = (i % 2 ? 1 : -1) * i * 7919; // spread out, all distinct
    EXPECT_FALSE(containsDuplicate(nums, n));
    free(nums);
}

TEST(max_size_duplicate_is_last) {
    int n = 100000;
    int *nums = (int *)malloc(n * sizeof(int));
    for (int i = 0; i < n - 1; i++) nums[i] = i;
    nums[n - 1] = 0;
    EXPECT_TRUE(containsDuplicate(nums, n));
    free(nums);
}

int main(void) {
    RUN(example_1);
    RUN(example_2);
    RUN(example_3);
    RUN(single_element);
    RUN(two_equal);
    RUN(duplicate_at_both_ends);
    RUN(negative_numbers);
    RUN(negative_and_positive_same_abs);
    RUN(int_limits);
    RUN(values_that_collide_in_a_small_table);
    RUN(max_size_all_unique);
    RUN(max_size_duplicate_is_last);
    return TEST_SUMMARY();
}
