# HackerRank.SimpleEditor

C# solution for the HackerRank challenge **Simple Text Editor**.

## Problem

Implement a simple text editor that supports append, delete, print, and undo operations.

The editor starts with an empty string.

## Operations

| Operation | Description                                          |
|-----------|------------------------------------------------------|
| `1 W`     | Append string `W` to the end of the current text     |
| `2 k`     | Delete the last `k` characters from the current text |
| `3 k`     | Print the `k`-th character of the current text       |
| `4`       | Undo the last append or delete operation             |

Indexes for operation `3` are 1-based.

## Input Format

The first line contains an integer `q`, the number of operations.

Each of the next `q` lines contains one operation in one of the following forms:

```text
1 W 2 k 3 k 4
```

## Output Format

For each operation of type `3`, print the requested character on a new line.

## Sample Input

```text
8 1 abc 3 3 2 3 1 xy 3 2 4 4 3 1
```

## Sample Output

```text
c y a
```

## Explanation

Starting text: empty string `""`

1. `1 abc` — append `abc`, text becomes `"abc"`
2. `3 3` — print 3rd character: `c`
3. `2 3` — delete last 3 characters, text becomes `""`
4. `1 xy` — append `xy`, text becomes `"xy"`
5. `3 2` — print 2nd character: `y`
6. `4` — undo append `xy`, text becomes `""`
7. `4` — undo delete `abc`, text becomes `"abc"`
8. `3 1` — print 1st character: `a`

## How to Run

From the repository root:

```bash
dotnet run --project HackerRank.SimpleEditor
```

To run with the sample input:

```bash
dotnet run --project HackerRank.SimpleEditor < HackerRank.SimpleEditor/input.txt
```

## Approach

The editor stores previous versions of the text before every modifying operation.

- Before append, save the current text.
- Before delete, save the current text.
- On undo, restore the latest saved text.

This allows undo operations to be handled easily using a stack.

## Complexity

Let `n` be the current text length.

| Operation | Time Complexity  |
|-----------|------------------|
| Append    | `O(length of W)` |
| Delete    | `O(k)`           |
| Print     | `O(1)`           |
| Undo      | `O(n)`           |

Space complexity is `O(total saved text size)` because previous versions are stored for undo operations.