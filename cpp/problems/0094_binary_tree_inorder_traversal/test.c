// Tests for 94. Binary Tree Inorder Traversal
// Run: ./scripts/test.sh 0094
#include "lc_test.h"
#include "lc_tree.h"

#include "solution.c"

// Builds the tree, runs inorderTraversal and compares with the expected list.
// A macro (not a function) so a failure points at the line of the test case.
#define CHECK_INORDER(tree, expected) \
    do { \
        struct TreeNode *root = lc_tree_from_str(tree); \
        int size = -1; \
        int *result = inorderTraversal(root, &size); \
        TEST_CONTEXT("root = %s", tree); \
        EXPECT_INT_ARRAY_STR(result, size, expected); \
        free(result); \
        lc_tree_free(root); \
    } while (0)

// Examples from the problem page
TEST(example_1) { CHECK_INORDER("[1,null,2,3]", "[1,3,2]"); }
TEST(example_2) { CHECK_INORDER("[1,2,3,4,5,null,8,null,null,6,7,9]", "[4,2,6,5,7,1,3,9,8]"); }
TEST(example_3_empty_tree) { CHECK_INORDER("[]", "[]"); }
TEST(example_4_single_node) { CHECK_INORDER("[1]", "[1]"); }

// Edge cases
TEST(only_left_children) { CHECK_INORDER("[3,2,null,1]", "[1,2,3]"); }
TEST(only_right_children) { CHECK_INORDER("[1,null,2,null,3]", "[1,2,3]"); }
TEST(full_tree) { CHECK_INORDER("[1,2,3,4,5,6,7]", "[4,2,5,1,6,3,7]"); }
TEST(negative_and_zero_values) { CHECK_INORDER("[0,-100,100]", "[-100,0,100]"); }
TEST(zigzag) { CHECK_INORDER("[1,2,null,null,3,4]", "[2,4,3,1]"); }

// Largest input allowed by the constraints (100 nodes): a BST with values 1..100
// built as a right-leaning chain, so the inorder result must be 1..100.
TEST(max_size_chain) {
    struct TreeNode *root = NULL, *tail = NULL;
    for (int v = 1; v <= 100; v++) {
        struct TreeNode *node = lc_tree_node(v);
        if (root == NULL) root = node; else tail->right = node;
        tail = node;
    }

    int expected[100];
    for (int i = 0; i < 100; i++) expected[i] = i + 1;

    int size = -1;
    int *result = inorderTraversal(root, &size);
    EXPECT_INT_ARRAY(result, size, expected, 100);
    free(result);
    lc_tree_free(root);
}

int main(void) {
    RUN(example_1);
    RUN(example_2);
    RUN(example_3_empty_tree);
    RUN(example_4_single_node);
    RUN(only_left_children);
    RUN(only_right_children);
    RUN(full_tree);
    RUN(negative_and_zero_values);
    RUN(zigzag);
    RUN(max_size_chain);
    return TEST_SUMMARY();
}
