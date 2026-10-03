// Tests for 242. Valid Anagram
// Run: ./scripts/test.sh 0242
#include "lc_test.h"

#include "solution.c"

// Copies the strings into writable buffers first: the signature takes char*,
// so a solution is allowed to modify them (e.g. sort in place).
#define CHECK(s_text, t_text, expected) \
    do { \
        char *s = strdup(s_text); \
        char *t = strdup(t_text); \
        TEST_CONTEXT("s = \"%s\", t = \"%s\"", s_text, t_text); \
        EXPECT_EQ_BOOL(isAnagram(s, t), expected); \
        free(s); \
        free(t); \
    } while (0)

// Examples from the problem page
TEST(example_1) { CHECK("anagram", "nagaram", true); }
TEST(example_2) { CHECK("rat", "car", false); }

// Edge cases (constraints: 1 <= length <= 5 * 10^4, lowercase English letters)
TEST(single_letter_same) { CHECK("a", "a", true); }
TEST(single_letter_different) { CHECK("a", "b", false); }
TEST(different_lengths) {
    CHECK("a", "ab", false);
    CHECK("ab", "a", false);
}
TEST(same_letters_different_counts) {
    CHECK("aacc", "ccac", false);
    CHECK("aab", "abb", false);
}
TEST(identical_strings) { CHECK("listen", "listen", true); }
TEST(reversed) { CHECK("abcdefghijklmnopqrstuvwxyz", "zyxwvutsrqponmlkjihgfedcba", true); }
TEST(one_letter_off) { CHECK("anagram", "nagaran", false); }

// Largest input allowed by the constraints: 5 * 10^4 letters.
TEST(max_length) {
    int n = 50000;
    char *s = (char *)malloc(n + 1);
    char *t = (char *)malloc(n + 1);
    for (int i = 0; i < n; i++) {
        s[i] = (char)('a' + i % 26);
        t[n - 1 - i] = s[i];
    }
    s[n] = t[n] = '\0';
    EXPECT_TRUE(isAnagram(s, t));

    t[0] = t[0] == 'a' ? 'b' : 'a'; // change one letter
    EXPECT_FALSE(isAnagram(s, t));

    free(s);
    free(t);
}

int main(void) {
    RUN(example_1);
    RUN(example_2);
    RUN(single_letter_same);
    RUN(single_letter_different);
    RUN(different_lengths);
    RUN(same_letters_different_counts);
    RUN(identical_strings);
    RUN(reversed);
    RUN(one_letter_off);
    RUN(max_length);
    return TEST_SUMMARY();
}
