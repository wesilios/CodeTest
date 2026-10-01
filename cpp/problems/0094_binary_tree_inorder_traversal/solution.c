#include <stddef.h>
#include <stdlib.h>

/**
 * Definition for a binary tree node.
 * struct TreeNode {
 *     int val;
 *     struct TreeNode *left;
 *     struct TreeNode *right;
 * };
 */

int countNodes(struct TreeNode *root) {
    if (root == NULL)
        return 0;
    return 1 + countNodes(root->left) + countNodes(root->right);
}

void inOrder(struct TreeNode *root, int *arr, int *index) {

    if (root == NULL)
        return;

    inOrder(root->left, arr, index);
    arr[(*index)++] = root->val;
    inOrder(root->right, arr, index);
}

int *inorderTraversal(struct TreeNode *root, int *returnSize) {
    if (root == NULL) {
        *returnSize = 0;
        return NULL;
    }
    *returnSize = countNodes(root);

    int *result = (int *)malloc((*returnSize) * sizeof(int));

    int index = 0;
    inOrder(root, result, &index);

    return result;
}
