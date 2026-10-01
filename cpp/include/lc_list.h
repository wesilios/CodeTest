/*
 * Singly linked list helpers for C tests.
 *
 * Defines struct ListNode exactly like LeetCode does, so solution.c must NOT
 * define it again (keep LeetCode's commented-out definition instead).
 *
 * Lists are written as LeetCode text: "[1,2,3]".
 */
#ifndef LC_LIST_H
#define LC_LIST_H

#include <stdlib.h>

#include "lc_parse.h"

struct ListNode {
    int val;
    struct ListNode *next;
};

static inline struct ListNode *lc_list_node(int val) {
    struct ListNode *node = (struct ListNode *)malloc(sizeof(struct ListNode));
    node->val = val;
    node->next = NULL;
    return node;
}

/* "[1,2,3]" -> 1 -> 2 -> 3. "[]" -> NULL. Free with lc_list_free. */
static inline struct ListNode *lc_list_from_str(const char *s) {
    int n;
    int *values = lc_parse_int_array(s, &n);

    struct ListNode dummy = {0, NULL};
    struct ListNode *tail = &dummy;
    for (int i = 0; i < n; i++) {
        tail->next = lc_list_node(values[i]);
        tail = tail->next;
    }

    free(values);
    return dummy.next;
}

/* list -> "[1,2,3]" (malloc'd). Stops after 10000 nodes in case of a cycle. */
static inline char *lc_list_to_str(const struct ListNode *head) {
    lc_strbuf sb;
    lc_sb_init(&sb);
    lc_sb_appendf(&sb, "[");

    int i = 0;
    for (; head != NULL && i < 10000; head = head->next, i++) {
        lc_sb_appendf(&sb, i == 0 ? "%d" : ",%d", head->val);
    }
    if (head != NULL) lc_sb_appendf(&sb, ",...(cycle?)");

    lc_sb_appendf(&sb, "]");
    return sb.data;
}

static inline void lc_list_free(struct ListNode *head) {
    while (head != NULL) {
        struct ListNode *next = head->next;
        free(head);
        head = next;
    }
}

#endif /* LC_LIST_H */
