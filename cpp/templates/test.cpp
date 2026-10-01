// Tests for {{NUMBER}}. {{TITLE}}
// Run: ./scripts/test.sh {{NUMBER4}}
#include "lc_cpp.hpp"

#include "solution.cpp"

// Copy the examples from the problem page, then add edge cases.
// Example for "vector<int> twoSum(vector<int>& nums, int target)":
//
// TEST(example_1) {
//     auto nums = vec("[2,7,11,15]");  // a named variable: LeetCode methods take vector<int>&
//     EXPECT_EQ(Solution().twoSum(nums, 9), vec("[0,1]"));
// }

TEST(write_tests) {
    EXPECT_TRUE(!"no tests yet: add some to test.cpp");
}

int main() {
    RUN(write_tests);
    return TEST_SUMMARY();
}
