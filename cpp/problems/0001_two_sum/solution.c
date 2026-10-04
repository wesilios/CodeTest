// 1. Two Sum
// https://leetcode.com/problems/two-sum/
// Constraints:
// 2 <= nums.length <= 104
// -109 <= nums[i] <= 109
// -109 <= target <= 109

#include <stdbool.h>
#include <stdlib.h>

typedef struct HashNode {
    int key;
    int value;
    struct HashNode *next;
} HashNode;

typedef struct Dict {
    HashNode **table;
    int capacity;
} Dict;

int hash(int key, int capacity) {
    int index = (int)key % capacity;

    if (index < 0) {
        index += capacity;
    }

    return index;
}

bool contains(Dict *dictionary, int key) {
    int index = hash(key, dictionary->capacity);

    HashNode *current = dictionary->table[index];

    while (current != NULL) {
        if (current->key == key) {
            return true;
        }

        current = current->next;
    }

    return false;
}

void insert(Dict *dictionary, int key, int value) {
    int index = hash(key, dictionary->capacity);
    HashNode *node = malloc(sizeof(HashNode));

    node->key = key;
    node->value = value;
    node->next = dictionary->table[index];
    dictionary->table[index] = node;
}

void freeDictionary(Dict *dictionary) {
    for (int i = 0; i < dictionary->capacity; i++) {
        HashNode *current = dictionary->table[i];

        while (current != NULL) {
            HashNode *next = current->next;
            free(current);
            current = next;
        }
    }

    free(dictionary->table);
    free(dictionary);
}

int getValue(Dict *dictionary, int key) {
    int index = hash(key, dictionary->capacity);
    HashNode *current = dictionary->table[index];

    while (current != NULL) {
        if (current->key == key) {
            return current->value;
        }

        current = current->next;
    }

    return 0;
}

/**
 * Note: The returned array must be malloced, assume caller calls free().
 */
int *twoSum(int *nums, int numsSize, int target, int *returnSize) {
    int remaining;
    int capacity = numsSize * 2 + 1;
    Dict *dictionary = calloc(capacity, sizeof(Dict *));
    dictionary->capacity = capacity;
    dictionary->table = calloc(dictionary->capacity, sizeof(HashNode *));
    *returnSize = 0;
    for (int i = 0; i < numsSize; i++) {
        remaining = target - nums[i];
        if (contains(dictionary, remaining)) {
            *returnSize = 2;
            int *result = malloc(*returnSize * sizeof(int));
            result[0] = getValue(dictionary, remaining);
            result[1] = i;
            freeDictionary(dictionary);
            return result;
        }

        insert(dictionary, nums[i], i);
    }

    freeDictionary(dictionary);
    int *result = malloc(*returnSize * sizeof(int));
    return result;
}
