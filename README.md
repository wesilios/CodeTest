# Code Test Project

A personal playground for solving online coding problems (LeetCode, HackerRank, Turing assessments) and trying out language features, written in C# and C/C++.

## Repository structure

The repo holds two self-contained workspaces. Each has its own build tooling and README:

| Workspace | What it is | Tooling |
|---|---|---|
| [`c#/`](c%23) | A .NET solution: problem solutions as class libraries, one shared xUnit test project, and a few small demo apps | .NET 8 SDK |
| [`cpp/`](cpp) | A LeetCode workspace: one folder per problem (solution + test), with scripts to scaffold and run them | CMake, GCC/Clang |

Start with the README inside the workspace you want to work in for setup and run instructions.
