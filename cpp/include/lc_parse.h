/*
 * Parse LeetCode-style text ("[1,2,3]", "[[1,2],[3]]", "[\"a\",\"b\"]") into C
 * arrays, and format C arrays back into the same text.
 *
 * Every function returns memory from malloc; free it with free() or the
 * matching lc_free_* helper. Parsers never return NULL, so free is always safe.
 *
 * Header-only and C/C++ compatible (hence the casts on malloc).
 */
#ifndef LC_PARSE_H
#define LC_PARSE_H

#include <ctype.h>
#include <stdarg.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>

/* ---- small growable string buffer, used by the *_to_str helpers ---- */

typedef struct {
    char *data;
    size_t len;
    size_t cap;
} lc_strbuf;

static inline void lc_sb_init(lc_strbuf *sb) {
    sb->cap = 64;
    sb->len = 0;
    sb->data = (char *)malloc(sb->cap);
    sb->data[0] = '\0';
}

static inline void lc_sb_appendf(lc_strbuf *sb, const char *fmt, ...) {
    va_list args;
    va_start(args, fmt);
    int needed = vsnprintf(NULL, 0, fmt, args);
    va_end(args);

    while (sb->len + (size_t)needed + 1 > sb->cap) {
        sb->cap *= 2;
        sb->data = (char *)realloc(sb->data, sb->cap);
    }

    va_start(args, fmt);
    vsnprintf(sb->data + sb->len, sb->cap - sb->len, fmt, args);
    va_end(args);
    sb->len += (size_t)needed;
}

/* ---- parsing ---- */

static inline const char *lc_skip_ws(const char *p) {
    while (*p && isspace((unsigned char)*p)) p++;
    return p;
}

static inline void lc_parse_error(const char *what, const char *near) {
    fprintf(stderr, "%s: cannot parse input near \"%.20s\"\n", what, near);
    abort();
}

/* Parses one "[...]" int list starting at *pp and moves *pp past the ']'. */
static inline int *lc_parse_int_array_at(const char **pp, int *size) {
    int cap = 8, n = 0;
    int *a = (int *)malloc(cap * sizeof(int));
    const char *p = lc_skip_ws(*pp);

    if (*p != '[') lc_parse_error("lc_parse_int_array", p);
    p++;

    for (;;) {
        p = lc_skip_ws(p);
        if (*p == ']') {
            p++;
            break;
        }

        char *end;
        long value = strtol(p, &end, 10);
        if (end == p) lc_parse_error("lc_parse_int_array", p);

        if (n == cap) {
            cap *= 2;
            a = (int *)realloc(a, cap * sizeof(int));
        }
        a[n++] = (int)value;

        p = lc_skip_ws(end);
        if (*p == ',') p++;
    }

    *pp = p;
    *size = n;
    return a;
}

/* "[1,-2,3]" -> {1, -2, 3}, *size = 3 */
static inline int *lc_parse_int_array(const char *s, int *size) {
    return lc_parse_int_array_at(&s, size);
}

/*
 * "[[1,2],[3]]" -> int** with *rows = 2 and (*colSizes) = {2, 1}.
 * Same shape LeetCode uses for 2D return values (returnSize / returnColumnSizes).
 * Free with lc_free_int_matrix.
 */
static inline int **lc_parse_int_matrix(const char *s, int *rows, int **colSizes) {
    int cap = 8, n = 0;
    int **m = (int **)malloc(cap * sizeof(int *));
    int *cols = (int *)malloc(cap * sizeof(int));
    const char *p = lc_skip_ws(s);

    if (*p != '[') lc_parse_error("lc_parse_int_matrix", p);
    p++;

    for (;;) {
        p = lc_skip_ws(p);
        if (*p == ']') break;

        if (n == cap) {
            cap *= 2;
            m = (int **)realloc(m, cap * sizeof(int *));
            cols = (int *)realloc(cols, cap * sizeof(int));
        }
        m[n] = lc_parse_int_array_at(&p, &cols[n]);
        n++;

        p = lc_skip_ws(p);
        if (*p == ',') p++;
    }

    *rows = n;
    *colSizes = cols;
    return m;
}

static inline void lc_free_int_matrix(int **m, int rows, int *colSizes) {
    if (m != NULL) {
        for (int i = 0; i < rows; i++) free(m[i]);
    }
    free(m);
    free(colSizes);
}

/* "[\"eat\",\"tea\"]" -> {"eat", "tea"}. Free with lc_free_str_array. */
static inline char **lc_parse_str_array(const char *s, int *size) {
    int cap = 8, n = 0;
    char **a = (char **)malloc(cap * sizeof(char *));
    const char *p = lc_skip_ws(s);

    if (*p != '[') lc_parse_error("lc_parse_str_array", p);
    p++;

    for (;;) {
        p = lc_skip_ws(p);
        if (*p == ']') break;
        if (*p != '"') lc_parse_error("lc_parse_str_array", p);
        p++;

        size_t len = 0, scap = 16;
        char *str = (char *)malloc(scap);
        while (*p && *p != '"') {
            if (*p == '\\' && p[1]) p++; /* \" and \\ */
            if (len + 1 == scap) {
                scap *= 2;
                str = (char *)realloc(str, scap);
            }
            str[len++] = *p++;
        }
        if (*p != '"') lc_parse_error("lc_parse_str_array", p);
        p++;
        str[len] = '\0';

        if (n == cap) {
            cap *= 2;
            a = (char **)realloc(a, cap * sizeof(char *));
        }
        a[n++] = str;

        p = lc_skip_ws(p);
        if (*p == ',') p++;
    }

    *size = n;
    return a;
}

static inline void lc_free_str_array(char **a, int size) {
    if (a != NULL) {
        for (int i = 0; i < size; i++) free(a[i]);
    }
    free(a);
}

/* ---- formatting ---- */

/* {1, 2, 3} -> "[1,2,3]" (malloc'd) */
static inline char *lc_int_array_to_str(const int *a, int n) {
    lc_strbuf sb;
    lc_sb_init(&sb);
    if (a == NULL && n > 0) {
        lc_sb_appendf(&sb, "(null)");
        return sb.data;
    }

    lc_sb_appendf(&sb, "[");
    for (int i = 0; i < n; i++) {
        lc_sb_appendf(&sb, i == 0 ? "%d" : ",%d", a[i]);
    }
    lc_sb_appendf(&sb, "]");
    return sb.data;
}

/* -> "[[1,2],[3]]" (malloc'd) */
static inline char *lc_int_matrix_to_str(int **m, int rows, const int *colSizes) {
    lc_strbuf sb;
    lc_sb_init(&sb);
    if ((m == NULL || colSizes == NULL) && rows > 0) {
        lc_sb_appendf(&sb, "(null)");
        return sb.data;
    }

    lc_sb_appendf(&sb, "[");
    for (int i = 0; i < rows; i++) {
        char *row = lc_int_array_to_str(m[i], colSizes[i]);
        lc_sb_appendf(&sb, i == 0 ? "%s" : ",%s", row);
        free(row);
    }
    lc_sb_appendf(&sb, "]");
    return sb.data;
}

#endif /* LC_PARSE_H */
