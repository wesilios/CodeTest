#include <stdbool.h>
#include <stddef.h>
#include <stdlib.h>

typedef struct Node {
    int value;
    struct Node *next;
} Node;

int hash(int value, int capacity) {
    int index = value % capacity;

    if (index < 0) {
        index += capacity;
    }

    return index;
}

bool contains(Node **table, int capacity, int value) {
    int index = hash(value, capacity);

    Node *current = table[index];

    while (current != NULL) {
        if (current->value == value) {
            return true;
        }

        current = current->next;
    }

    return false;
}

void insert(Node **table, int capacity, int value) {
    int index = hash(value, capacity);
    Node *node = malloc(sizeof(Node));

    node->value = value;
    node->next = table[index];
    table[index] = node;
}

void freeTable(Node **table, int capacity) {
    for (int i = 0; i < capacity; i++) {
        Node *current = table[i];

        while (current != NULL) {
            Node *next = current->next;
            free(current);
            current = next;
        }
    }

    free(table);
}

bool containsDuplicate(int *nums, int numsSize) {
    int capacity = numsSize * 2 + 1;

    Node **table = calloc(capacity, sizeof(Node *));
    for (int i = 0; i < numsSize; i++) {
        if (contains(table, capacity, nums[i])) {
            freeTable(table, capacity);
            return true;
        }

        insert(table, capacity, nums[i]);
    }

    freeTable(table, capacity);
    return false;
}
