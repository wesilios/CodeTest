/*
 * Everything a C++ test needs, mirroring what LeetCode's C++ judge provides:
 * the whole standard library, `using namespace std;`, and the TreeNode /
 * ListNode definitions. So solution.cpp compiles here exactly as pasted.
 *
 * Helpers take LeetCode text so examples can be copied from the problem page:
 *   vec("[1,2,3]")              -> vector<int>
 *   vec2d("[[1,2],[3]]")        -> vector<vector<int>>
 *   strvec(R"(["a","b"])")      -> vector<string>
 *   buildTree("[1,null,2,3]")   -> TreeNode*      treeToString(root) -> "[1,null,2,3]"
 *   buildList("[1,2,3]")        -> ListNode*      listToString(head) -> "[1,2,3]"
 */
#pragma once

#include <bits/stdc++.h>
using namespace std;

struct TreeNode {
    int val;
    TreeNode *left;
    TreeNode *right;
    TreeNode() : val(0), left(nullptr), right(nullptr) {}
    TreeNode(int x) : val(x), left(nullptr), right(nullptr) {}
    TreeNode(int x, TreeNode *left, TreeNode *right) : val(x), left(left), right(right) {}
};

struct ListNode {
    int val;
    ListNode *next;
    ListNode() : val(0), next(nullptr) {}
    ListNode(int x) : val(x), next(nullptr) {}
    ListNode(int x, ListNode *next) : val(x), next(next) {}
};

#include "lc_test.h"

/*
 * LeetCode C++ solutions usually `new` nodes and never delete them, which is
 * fine there. Don't let AddressSanitizer fail C++ tests over leaks.
 * (C tests keep leak checking on.)
 */
extern "C" __attribute__((used)) const char *__asan_default_options() { return "detect_leaks=0"; }

inline vector<int> vec(const string &s) {
    int n;
    int *a = lc_parse_int_array(s.c_str(), &n);
    vector<int> out(a, a + n);
    free(a);
    return out;
}

inline vector<vector<int>> vec2d(const string &s) {
    int rows;
    int *cols;
    int **m = lc_parse_int_matrix(s.c_str(), &rows, &cols);
    vector<vector<int>> out;
    for (int i = 0; i < rows; i++) out.emplace_back(m[i], m[i] + cols[i]);
    lc_free_int_matrix(m, rows, cols);
    return out;
}

inline vector<string> strvec(const string &s) {
    int n;
    char **a = lc_parse_str_array(s.c_str(), &n);
    vector<string> out(a, a + n);
    lc_free_str_array(a, n);
    return out;
}

/* "[1,null,2,3]" -> tree (LeetCode level order). "[]" -> nullptr. */
inline TreeNode *buildTree(const string &s) {
    vector<TreeNode *> nodes;
    string token;
    for (char c : s) {
        if (c == '[' || c == ' ') continue;
        if (c == ',' || c == ']') {
            if (!token.empty()) nodes.push_back(token == "null" ? nullptr : new TreeNode(stoi(token)));
            token.clear();
        } else {
            token += c;
        }
    }

    size_t next = 1;
    for (size_t i = 0; i < nodes.size() && next < nodes.size(); i++) {
        if (!nodes[i]) continue;
        if (next < nodes.size()) nodes[i]->left = nodes[next++];
        if (next < nodes.size()) nodes[i]->right = nodes[next++];
    }
    return nodes.empty() ? nullptr : nodes[0];
}

inline string treeToString(TreeNode *root) {
    vector<TreeNode *> order{root};
    for (size_t i = 0; i < order.size(); i++) {
        if (order[i]) {
            order.push_back(order[i]->left);
            order.push_back(order[i]->right);
        }
    }
    while (!order.empty() && !order.back()) order.pop_back();

    string out = "[";
    for (size_t i = 0; i < order.size(); i++) {
        if (i) out += ",";
        out += order[i] ? to_string(order[i]->val) : "null";
    }
    return out + "]";
}

inline void freeTree(TreeNode *root) {
    if (!root) return;
    freeTree(root->left);
    freeTree(root->right);
    delete root;
}

inline ListNode *buildList(const string &s) {
    ListNode dummy;
    ListNode *tail = &dummy;
    for (int v : vec(s)) {
        tail->next = new ListNode(v);
        tail = tail->next;
    }
    return dummy.next;
}

/* Stops after 10000 nodes in case of a cycle. */
inline string listToString(ListNode *head) {
    string out = "[";
    int i = 0;
    for (; head && i < 10000; head = head->next, i++) {
        if (i) out += ",";
        out += to_string(head->val);
    }
    if (head) out += ",...(cycle?)";
    return out + "]";
}

inline void freeList(ListNode *head) {
    while (head) {
        ListNode *next = head->next;
        delete head;
        head = next;
    }
}
