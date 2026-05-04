# HackerRank.QueueUsingTwoStack

C# solution for the HackerRank challenge **Queue using Two Stacks**.

## Problem

Implement a queue that supports the following operations:

| Query | Description                                    |
|-------|------------------------------------------------|
| `1 x` | Enqueue integer `x` into the back of the queue |
| `2`   | Dequeue the element at the front of the queue  |
| `3`   | Print the element at the front of the queue    |

The queue is implemented using two stacks.

## Input Format

The first line contains an integer `q`, the number of queries.

Each of the next `q` lines contains one query in one of the following forms:

```text
1 x 2 3
```

## Output Format

For each query of type `3`, print the element at the front of the queue on a new line.

## Sample Input

```text
10 1 42 2 1 14 3 1 28 3 1 60 1 78 2 2
```

## Sample Output

```text
14 14
```

## Explanation

1. Enqueue `42`
2. Dequeue `42`
3. Enqueue `14`
4. Print front: `14`
5. Enqueue `28`
6. Print front: `14`
7. Enqueue `60`
8. Enqueue `78`
9. Dequeue `14`
10. Dequeue `28`

Only the two print operations produce output.

## How to Run

From the repository root:

```bash
bash dotnet run --project HackerRank.QueueUsingTwoStack
```

To run with the sample input:

```bash
bash dotnet run --project HackerRank.QueueUsingTwoStack < HackerRank.QueueUsingTwoStack/input.txt
```

## Complexity

Each operation is amortized:

| Operation   | Time Complexity  |
|-------------|------------------|
| Enqueue     | `O(1)`           |
| Dequeue     | `O(1)` amortized |
| Print front | `O(1)` amortized |

Space complexity is `O(n)`, where `n` is the number of elements in the queue.