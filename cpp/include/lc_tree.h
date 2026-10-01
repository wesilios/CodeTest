/*
 * Binary tree helpers for C tests.
 *
 * Defines struct TreeNode exactly like LeetCode does, so solution.c must NOT
 * define it again (keep LeetCode's commented-out definition instead).
 *
 * Trees are written in LeetCode's level-order text: "[1,null,2,3]".
 */
#ifndef LC_TREE_H
#define LC_TREE_H

#include <stdint.h>
#include <stdlib.h>
#include <string.h>

#include "lc_parse.h"

struct TreeNode {
    int val;
    struct TreeNode *left;
    struct TreeNode *right;
};

static inline struct TreeNode *lc_tree_node(int val) {
    struct TreeNode *node = (struct TreeNode *)malloc(sizeof(struct TreeNode));
    node->val = val;
    node->left = NULL;
    node->right = NULL;
    return node;
}

/* "[1,null,2,3]" -> tree. "[]" -> NULL. Free with lc_tree_free. */
static inline struct TreeNode *lc_tree_from_str(const char *s) {
    /* 1. split into tokens; NULL entries mean "null" */
    int cap = 16, n = 0;
    struct TreeNode **nodes = (struct TreeNode **)malloc(cap * sizeof(struct TreeNode *));
    const char *p = lc_skip_ws(s);

    if (*p != '[') lc_parse_error("lc_tree_from_str", p);
    p++;

    for (;;) {
        p = lc_skip_ws(p);
        if (*p == ']') break;

        struct TreeNode *node = NULL;
        if (strncmp(p, "null", 4) == 0) {
            p += 4;
        } else {
            char *end;
            long value = strtol(p, &end, 10);
            if (end == p) lc_parse_error("lc_tree_from_str", p);
            node = lc_tree_node((int)value);
            p = end;
        }

        if (n == cap) {
            cap *= 2;
            nodes = (struct TreeNode **)realloc(nodes, cap * sizeof(struct TreeNode *));
        }
        nodes[n++] = node;

        p = lc_skip_ws(p);
        if (*p == ',') p++;
    }

    /* 2. link them level by level: each non-null node takes the next two tokens as children */
    struct TreeNode *root = n > 0 ? nodes[0] : NULL;
    int next = 1;
    for (int i = 0; i < n && next < n; i++) {
        if (nodes[i] == NULL) continue;
        if (next < n) nodes[i]->left = nodes[next++];
        if (next < n) nodes[i]->right = nodes[next++];
    }

    free(nodes);
    return root;
}

static inline int lc_tree_size(const struct TreeNode *root) {
    return root == NULL ? 0 : 1 + lc_tree_size(root->left) + lc_tree_size(root->right);
}

/* tree -> "[1,null,2,3]" (malloc'd), the same format LeetCode prints. */
static inline char *lc_tree_to_str(const struct TreeNode *root) {
    int count = lc_tree_size(root);
    /* each real node adds at most two queue entries, plus the root */
    const struct TreeNode **queue =
        (const struct TreeNode **)malloc((2 * (size_t)count + 1) * sizeof(struct TreeNode *));
    int head = 0, tail = 0;
    queue[tail++] = root;

    /* BFS that also records nulls, then drop the trailing nulls */
    int last_real = -1;
    for (head = 0; head < tail; head++) {
        if (queue[head] == NULL) continue;
        last_real = head;
        queue[tail++] = queue[head]->left;
        queue[tail++] = queue[head]->right;
    }

    lc_strbuf sb;
    lc_sb_init(&sb);
    lc_sb_appendf(&sb, "[");
    for (int i = 0; i <= last_real; i++) {
        if (i > 0) lc_sb_appendf(&sb, ",");
        if (queue[i] == NULL) {
            lc_sb_appendf(&sb, "null");
        } else {
            lc_sb_appendf(&sb, "%d", queue[i]->val);
        }
    }
    lc_sb_appendf(&sb, "]");

    free(queue);
    return sb.data;
}

static inline void lc_tree_free(struct TreeNode *root) {
    if (root == NULL) return;
    lc_tree_free(root->left);
    lc_tree_free(root->right);
    free(root);
}

static inline int lc_compare_ptr(const void *a, const void *b) {
    uintptr_t x = (uintptr_t)*(void *const *)a, y = (uintptr_t)*(void *const *)b;
    return (x > y) - (x < y);
}

static inline void lc_tree_collect(struct TreeNode *root, struct TreeNode ***all, int *n, int *cap) {
    if (root == NULL) return;
    if (*n == *cap) {
        *cap *= 2;
        *all = (struct TreeNode **)realloc(*all, *cap * sizeof(struct TreeNode *));
    }
    (*all)[(*n)++] = root;
    lc_tree_collect(root->left, all, n, cap);
    lc_tree_collect(root->right, all, n, cap);
}

/*
 * Frees several trees that may SHARE nodes (e.g. results of "generate all
 * trees" problems, where subtrees are often reused). Each node is freed once.
 * Does not free the roots array itself.
 */
static inline void lc_tree_free_many(struct TreeNode **roots, int count) {
    int n = 0, cap = 64;
    struct TreeNode **all = (struct TreeNode **)malloc(cap * sizeof(struct TreeNode *));
    for (int i = 0; i < count; i++) lc_tree_collect(roots[i], &all, &n, &cap);

    qsort(all, n, sizeof(struct TreeNode *), lc_compare_ptr);
    for (int i = 0; i < n; i++) {
        if (i == 0 || all[i] != all[i - 1]) free(all[i]);
    }
    free(all);
}

#endif /* LC_TREE_H */
