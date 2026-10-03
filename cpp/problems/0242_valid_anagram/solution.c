#include <stdbool.h>
#include <stddef.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>

typedef struct HashNode {
    char key;
    unsigned int value;
    struct HashNode *next;
} HashNode;

unsigned int hash(char key, int capacity) {
    int index = (int)key % capacity;

    if (index < 0) {
        index += capacity;
    }

    return index;
}

bool contains(HashNode **table, int capacity, char key) {
    int index = hash(key, capacity);

    HashNode *current = table[index];

    while (current != NULL) {
        if (current->key == key && current->value > 0) {
            return true;
        }

        current = current->next;
    }

    return false;
}

void insert(HashNode **table, int capacity, char key, unsigned int value) {
    int index = hash(key, capacity);
    HashNode *node = malloc(sizeof(HashNode));

    node->key = key;
    node->value = value;
    node->next = table[index];
    table[index] = node;
}

void updateValue(HashNode **table, int capacity, char key, int updateValue) {
    int index = hash(key, capacity);

    HashNode *current = table[index];

    while (current != NULL) {
        if (current->key == key) {
            current->value += updateValue;
            break;
        }

        current = current->next;
    }
}

void freeTable(HashNode **table, int capacity) {
    for (int i = 0; i < capacity; i++) {
        HashNode *current = table[i];

        while (current != NULL) {
            HashNode *next = current->next;
            free(current);
            current = next;
        }
    }

    free(table);
}

bool isAnagram(char *s, char *t) {
    size_t sLen = strlen(s);
    size_t tLen = strlen(t);

    if (sLen != tLen) {
        return false;
    }
    int capacity = sLen * 2 + 1;

    HashNode **table = calloc(capacity, sizeof(HashNode *));

    for (unsigned long i = 0; i < sLen; i++) {
        if (contains(table, capacity, s[i])) {
            updateValue(table, capacity, s[i], 1);
            continue;
        }

        insert(table, capacity, s[i], 1);
    }

    for (unsigned long i = 0; i < tLen; i++) {
        if (contains(table, capacity, t[i])) {
            updateValue(table, capacity, t[i], -1);
            continue;
        }

        freeTable(table, capacity);
        return false;
    }

    freeTable(table, capacity);

    return true;
}
