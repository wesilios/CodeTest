/*
 * A tiny test framework for LeetCode solutions. Works from C and C++.
 *
 *   TEST(two_elements) {
 *       EXPECT_EQ_INT(add(1, 2), 3);
 *   }
 *
 *   int main(void) {
 *       RUN(two_elements);
 *       return TEST_SUMMARY();
 *   }
 *
 * Every check takes (actual, expected). A failed check prints what went wrong
 * and the test keeps going; TEST_SUMMARY() returns non-zero if anything failed.
 *
 * It also includes the standard headers LeetCode's C judge gives you for free
 * (stdlib, string, stdbool, limits, math, ...), so solution files compile the
 * same way here as they do on LeetCode.
 */
#ifndef LC_TEST_H
#define LC_TEST_H

#include <ctype.h>
#include <limits.h>
#include <math.h>
#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <time.h>
#include <unistd.h>

#include "lc_parse.h"

static int lc_tests_run = 0;
static int lc_tests_failed = 0;
static int lc_current_failed = 0;
static char lc_context[256] = "";

static inline const char *lc_color(const char *code) {
    return isatty(fileno(stdout)) ? code : "";
}
#define LC_RED lc_color("\033[31m")
#define LC_GREEN lc_color("\033[32m")
#define LC_RESET lc_color("\033[0m")

/* ---- defining and running tests ---- */

#define TEST(name) static void name(void)
#define RUN(name) lc_run(#name, name)
#define TEST_SUMMARY() lc_summary()

/*
 * Extra info printed with any failure in the current test. Handy in loops:
 *   for (int n = 1; n <= 19; n++) { TEST_CONTEXT("n = %d", n); EXPECT_EQ_INT(f(n), want[n]); }
 */
#define TEST_CONTEXT(...) snprintf(lc_context, sizeof lc_context, __VA_ARGS__)

static inline void lc_run(const char *name, void (*fn)(void)) {
    lc_current_failed = 0;
    lc_context[0] = '\0';
    printf("[ RUN  ] %s\n", name);
    fflush(stdout); /* so a crash still shows which test was running */

    clock_t start = clock();
    fn();
    double ms = 1000.0 * (double)(clock() - start) / CLOCKS_PER_SEC;

    lc_tests_run++;
    if (lc_current_failed) {
        lc_tests_failed++;
        printf("%s[ FAIL ]%s %s (%.0f ms)\n", LC_RED, LC_RESET, name, ms);
    } else {
        printf("%s[  OK  ]%s %s (%.0f ms)\n", LC_GREEN, LC_RESET, name, ms);
    }
    fflush(stdout);
}

static inline int lc_summary(void) {
    const char *color = lc_tests_failed ? LC_RED : LC_GREEN;
    printf("\n%s%d/%d tests passed%s\n", color, lc_tests_run - lc_tests_failed, lc_tests_run, LC_RESET);
    return lc_tests_failed ? 1 : 0;
}

/* Prints the first lines of a failure report. */
static inline void lc_fail(const char *file, int line, const char *check) {
    lc_current_failed = 1;
    printf("  %sFAILED%s %s:%d: %s\n", LC_RED, LC_RESET, file, line, check);
    if (lc_context[0]) printf("    context:  %s\n", lc_context);
}

/* ---- checks ---- */

#define EXPECT_TRUE(cond) \
    do { \
        if (!(cond)) lc_fail(__FILE__, __LINE__, "EXPECT_TRUE(" #cond ")"); \
    } while (0)

#define EXPECT_FALSE(cond) \
    do { \
        if (cond) lc_fail(__FILE__, __LINE__, "EXPECT_FALSE(" #cond ")"); \
    } while (0)

/* Any integer type (int, long, char, bool...). */
#define EXPECT_EQ_INT(actual, expected) \
    lc_expect_eq_int((long long)(actual), (long long)(expected), \
                     "EXPECT_EQ_INT(" #actual ", " #expected ")", __FILE__, __LINE__)
#define EXPECT_EQ_LONG EXPECT_EQ_INT

static inline void lc_expect_eq_int(long long actual, long long expected, const char *check,
                                    const char *file, int line) {
    if (actual == expected) return;
    lc_fail(file, line, check);
    printf("    expected: %lld\n    actual:   %lld\n", expected, actual);
}

/* Booleans, printed as true/false. Anything non-zero counts as true. */
#define EXPECT_EQ_BOOL(actual, expected) \
    lc_expect_eq_bool((actual) != 0, (expected) != 0, "EXPECT_EQ_BOOL(" #actual ", " #expected ")", __FILE__, __LINE__)

static inline void lc_expect_eq_bool(int actual, int expected, const char *check, const char *file, int line) {
    if (actual == expected) return;
    lc_fail(file, line, check);
    printf("    expected: %s\n    actual:   %s\n", expected ? "true" : "false", actual ? "true" : "false");
}

/* Floating point, equal within eps. */
#define EXPECT_EQ_DBL(actual, expected, eps) \
    lc_expect_eq_dbl((double)(actual), (double)(expected), (double)(eps), \
                     "EXPECT_EQ_DBL(" #actual ", " #expected ", " #eps ")", __FILE__, __LINE__)

static inline void lc_expect_eq_dbl(double actual, double expected, double eps, const char *check,
                                    const char *file, int line) {
    if (fabs(actual - expected) <= eps) return;
    lc_fail(file, line, check);
    printf("    expected: %.10g\n    actual:   %.10g\n", expected, actual);
}

/* C strings. NULL is allowed on either side. */
#define EXPECT_EQ_STR(actual, expected) \
    lc_expect_eq_str((actual), (expected), "EXPECT_EQ_STR(" #actual ", " #expected ")", __FILE__, __LINE__)

static inline void lc_expect_eq_str(const char *actual, const char *expected, const char *check,
                                    const char *file, int line) {
    if (actual == expected) return;
    if (actual != NULL && expected != NULL && strcmp(actual, expected) == 0) return;
    lc_fail(file, line, check);
    printf(expected ? "    expected: \"%s\"\n" : "    expected: %s\n", expected ? expected : "NULL");
    printf(actual ? "    actual:   \"%s\"\n" : "    actual:   %s\n", actual ? actual : "NULL");
}

/* Int arrays, same length and same order. */
#define EXPECT_INT_ARRAY(actual, actualSize, expected, expectedSize) \
    lc_expect_int_array((actual), (actualSize), (expected), (expectedSize), \
                        "EXPECT_INT_ARRAY(" #actual ", " #actualSize ", " #expected ", " #expectedSize ")", \
                        __FILE__, __LINE__)

/* Same, but the expected value is LeetCode text: EXPECT_INT_ARRAY_STR(result, n, "[1,3,2]") */
#define EXPECT_INT_ARRAY_STR(actual, actualSize, expected) \
    lc_expect_int_array_str((actual), (actualSize), (expected), \
                            "EXPECT_INT_ARRAY_STR(" #actual ", " #actualSize ", " #expected ")", __FILE__, __LINE__)

static inline void lc_expect_int_array(const int *actual, int actualSize, const int *expected, int expectedSize,
                                       const char *check, const char *file, int line) {
    int first_diff = -1;
    if (actualSize != expectedSize || (actual == NULL && actualSize > 0)) {
        first_diff = actualSize < expectedSize ? actualSize : expectedSize;
    } else {
        for (int i = 0; i < actualSize; i++) {
            if (actual[i] != expected[i]) {
                first_diff = i;
                break;
            }
        }
    }
    if (first_diff < 0) return;

    char *a = lc_int_array_to_str(actual, actualSize);
    char *e = lc_int_array_to_str(expected, expectedSize);
    lc_fail(file, line, check);
    printf("    expected: %s (size %d)\n    actual:   %s (size %d)\n", e, expectedSize, a, actualSize);
    if (actualSize == expectedSize) printf("    first difference at index %d\n", first_diff);
    free(a);
    free(e);
}

static inline void lc_expect_int_array_str(const int *actual, int actualSize, const char *expected,
                                           const char *check, const char *file, int line) {
    int expectedSize;
    int *e = lc_parse_int_array(expected, &expectedSize);
    lc_expect_int_array(actual, actualSize, e, expectedSize, check, file, line);
    free(e);
}

/*
 * 2D int arrays in LeetCode's C shape (rows + column sizes), same order:
 *   EXPECT_INT_MATRIX_STR(result, returnSize, returnColumnSizes, "[[1],[1,1]]")
 */
#define EXPECT_INT_MATRIX_STR(actual, rows, colSizes, expected) \
    lc_expect_int_matrix_str((actual), (rows), (colSizes), (expected), \
                             "EXPECT_INT_MATRIX_STR(" #actual ", " #rows ", " #colSizes ", " #expected ")", \
                             __FILE__, __LINE__)

static inline void lc_expect_int_matrix_str(int **actual, int rows, const int *colSizes, const char *expected,
                                            const char *check, const char *file, int line) {
    char *a = lc_int_matrix_to_str(actual, rows, colSizes);
    int eRows;
    int *eCols;
    int **e = lc_parse_int_matrix(expected, &eRows, &eCols);
    char *eStr = lc_int_matrix_to_str(e, eRows, eCols);

    if (strcmp(a, eStr) != 0) {
        lc_fail(file, line, check);
        printf("    expected: %s\n    actual:   %s\n", eStr, a);
    }

    free(a);
    free(eStr);
    lc_free_int_matrix(e, eRows, eCols);
}

/* ---- C++ only: EXPECT_EQ(actual, expected) for any comparable type ---- */

#ifdef __cplusplus
#include <sstream>
#include <string>
#include <type_traits>
#include <utility>
#include <vector>

namespace lc {

/* repr(x): turn a value into readable text for failure messages. */
template <class T> std::string repr(const T &value);
inline std::string repr(const std::string &s) { return "\"" + s + "\""; }
inline std::string repr(const char *s) { return s ? "\"" + std::string(s) + "\"" : "nullptr"; }
inline std::string repr(char c) { return std::string("'") + c + "'"; }
inline std::string repr(bool b) { return b ? "true" : "false"; }
template <class A, class B> std::string repr(const std::pair<A, B> &p);
template <class T> std::string repr(const std::vector<T> &v);

template <class T> std::string repr(const T &value) {
    if constexpr (requires(std::ostream &os) { os << value; }) {
        std::ostringstream os;
        os << value;
        return os.str();
    } else {
        return "<value>";
    }
}

template <class A, class B> std::string repr(const std::pair<A, B> &p) {
    return "(" + repr(p.first) + "," + repr(p.second) + ")";
}

template <class T> std::string repr(const std::vector<T> &v) {
    std::string out = "[";
    for (size_t i = 0; i < v.size(); i++) {
        if (i) out += ",";
        out += repr(v[i]);
    }
    return out + "]";
}

template <class T>
constexpr bool is_plain_int = std::is_integral_v<T> && !std::is_same_v<T, bool> && !std::is_same_v<T, char>;

template <class A, class E>
void expect_eq(const A &actual, const E &expected, const char *check, const char *file, int line) {
    bool ok;
    if constexpr (is_plain_int<A> && is_plain_int<E>) {
        ok = std::cmp_equal(actual, expected); /* no signed/unsigned surprises (size() vs int) */
    } else {
        ok = (actual == expected);
    }
    if (ok) return;
    lc_fail(file, line, check);
    printf("    expected: %s\n    actual:   %s\n", repr(expected).c_str(), repr(actual).c_str());
}

} // namespace lc

/* The expected side may contain commas: EXPECT_EQ(result, vector<int>{1, 3, 2}) */
#define EXPECT_EQ(actual, ...) \
    lc::expect_eq((actual), (__VA_ARGS__), "EXPECT_EQ(" #actual ", " #__VA_ARGS__ ")", __FILE__, __LINE__)

#endif /* __cplusplus */

#endif /* LC_TEST_H */
