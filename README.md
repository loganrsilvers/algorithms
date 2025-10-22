# Algorithms

This repository contains different C# projects to demonstrate how algorithms and data structures work. Each assignment focuses on a specific topic, such as sorting, searching, shuffling, or working with trees. There’s also a project where a maze is solved through a search algorithm.

## Table of Contents
1. [Maze Solver](#maze-solver)
2. [Big O Notation Examples](#big-o-notation-examples)
3. [Fisher-Yates Shuffle](#fisher-yates-shuffle)
4. [Data Structures Examples](#data-structures-examples)
5. [Sorting Algorithms](#sorting-algorithms)
6. [Searching Algorithms](#searching-algorithms)
7. [Tree Structures](#tree-structures)

---

## Maze Solver
**Assignment 4**

### What It Does
This project uses Depth-First Search (DFS) to solve a maze. The AI starts at the beginning and finds its way to the exit, avoiding walls.

### Features
- The AI uses DFS to explore paths.
- The solution is animated so you can watch the AI move through the maze.
- It keeps track of visited spots to avoid getting stuck in loops.

### Key Ideas
- DFS works like a “pre-order traversal” in trees.
- The AI uses backtracking to explore different paths.

### Files
- `MazeSolver.cs`
- `README_MazeSolver.md`

---

## Big O Notation Examples
**Assignment 1**

### What It Does
This project shows examples of how fast different algorithms run based on the size of the input.

### Features
- **O(1)**: Always takes the same amount of time.
- **O(n)**: Takes more time as the input gets bigger.
- **O(n²)**: Takes even longer because of nested loops.

### Key Ideas
- Learn how to measure how “big” or “slow” an algorithm is.
- Compare performance for different inputs.

### Files
- `BigONotationExamples.cs`
- `README_BigONotation.md`

---

## Fisher-Yates Shuffle
**Assignment 2**

### What It Does
Uses the Fisher-Yates Shuffle to randomly mix up items in a list.

### Features
- Shuffles items so each order is equally likely.
- Does this efficiently without needing extra memory.

### Key Ideas
- How randomness works in programming.
- The algorithm is fast and works in O(n) time.

### Files
- `FisherYatesShuffle.cs`
- `README_FisherYatesShuffle.md`

---

## Data Structures Examples
**Assignment 3**

### What It Does
Explains common data structures, like:
- Stacks
- Queues
- Linked Lists
- Dictionaries

### Features
- Shows how to add, remove, and look at items.
- Explains how fast these operations are.

### Files
- `DataStructures.cs`
- `README_DataStructures.md`

---

## Sorting Algorithms
**Assignment 5**

### What It Does
Demonstrates different ways to sort data, including:
- Bubble Sort
- Insertion Sort
- Selection Sort
- HeapSort
- Quick Sort
- Merge Sort

### Features
- Times how long each algorithm takes to finish.
- Compares all the algorithms to see which one is best.

### Files
- `SortingAlgorithms.cs`
- `README_SortingAlgorithms.md`

---

## Searching Algorithms
**Assignment 6**

### What It Does
Shows how to search for a specific item in a list using:
- Linear Search
- Binary Search
- Interpolation Search

### Features
- Tests how fast each method works.
- Uses the same dataset to compare results.

### Files
- `SearchingAlgorithms.cs`
- `README_SearchingAlgorithms.md`

---

## Tree Structures
**Assignment 7**

### What It Does
Shows how to use trees to organize data.
- Loads data from a file.
- Sorts the data first.
- Builds a tree from the sorted data.
