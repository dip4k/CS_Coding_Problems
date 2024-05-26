> list down problem solving stratagies in data structures and algorithms.

## Some popular problem-solving strategies for tackling data structures and algorithms (DSA) problems:

1. **Incremental Approach using Single and Nested Loops**:

   - This strategy involves building the partial solution step by step using loops.
   - Variations include:
     - **Input-centric strategy**: At each iteration, process one input and build the partial solution.
     - **Output-centric strategy**: At each iteration, add one output to the solution and build the partial solution.
     - **Iterative improvement strategy**: Start with an approximation of a solution and continuously improve it.
   - Example problems: Insertion Sort, Finding max and min in an array, Valid mountain array, Dutch national flag problem, Sort an array in a waveform.

2. **Decrease and Conquer Approach**:

   - Find the solution to a problem via its subproblem solution.
   - Leads to recursive algorithms that reduce the problem to smaller input sizes.
   - Example problems: Euclid algorithm for finding GCD, Binary Search, Josephus problem.

3. **Problem-Solving using Binary Search**:

   - When an array has an order property (similar to a sorted array), use binary search.
   - Modify the standard binary search algorithm based on problem conditions.
   - Core idea: Calculate mid-index and iterate over left or right half of the array.
   - Example problems: Find Peak Element, Search a sorted 2D matrix, Find the square root of an integer, Search in Rotated Sorted Array.

4. **Divide and Conquer Approach**:

   - Divide a problem into subproblems, solve each, and combine their solutions.
   - Efficiently solves fundamental problems in computer science.
   - Example problems: Merge Sort, Quick Sort, Median of two sorted arrays.

5. **Two Pointers Approach**:

   - Optimize time and space complexity for searching problems on arrays and linked lists.
   - Use pairs of array indices or pointer references.
   - Simultaneously iterate over different input parts to perform fewer operations.

6. **Greedy Algorithms**:

   - Make locally optimal choices at each step to achieve a globally optimal solution.
   - Often used for optimization problems.
   - Example problems: Fractional Knapsack, Huffman Coding, Activity Selection.

7. **Backtracking**:

   - Solve problems by trying out different possibilities and undoing choices if they lead to a dead end.
   - Recursive approach that explores all possible solutions.
   - Example problems: N-Queens, Sudoku, Word Search.

8. **Dynamic Programming (DP)**:

   - Break down a problem into smaller overlapping subproblems and store their solutions.
   - Use memoization or tabulation to avoid redundant computations.
   - Example problems: Fibonacci series, Longest Common Subsequence, Edit Distance.

9. **Graph Algorithms**:

   - Solve problems related to graphs (nodes connected by edges).
   - Common graph algorithms include:
     - **Breadth-First Search (BFS)**: Explore nodes level by level.
     - **Depth-First Search (DFS)**: Explore as deeply as possible before backtracking.
     - **Dijkstra's Algorithm**: Find the shortest path in weighted graphs.
     - **Bellman-Ford Algorithm**: Find the shortest path with negative weights.
     - **Topological Sort**: Order nodes in a directed acyclic graph.
   - Example problems: Shortest path, Minimum spanning tree, Detect cycles.

10. **Hashing and Hash Tables**:

    - Use hash functions to map keys to indices in an array (hash table).
    - Efficient for searching, insertion, and deletion.
    - Example problems: Two Sum, Group Anagrams, Longest Substring Without Repeating Characters.

11. **Trie (Prefix Tree)**:

    - Store a dynamic set of strings efficiently.
    - Useful for autocomplete, spell check, and searching.
    - Example problems: Implement Trie, Word Search II.

12. **Segment Trees**:

    - Solve range query problems (e.g., minimum, maximum, sum) efficiently.
    - Divide the array into segments and build a tree structure.
    - Example problems: Range Minimum Query (RMQ), Count of Smaller Numbers After Self.

13. **Fenwick Tree (Binary Indexed Tree)**:

    - Efficiently update and query prefix sums in an array.
    - Useful for cumulative frequency problems.
    - Example problems: Range Sum Query, Inversion Count.

14. **Randomized Algorithms**:

    - Use randomness to solve problems.
    - Example problems: Randomized QuickSort, Randomized Selection.

15. **Network Flow Algorithms**:

    - Solve problems related to flow in networks (e.g., max flow, min cut).
    - Example problems: Ford-Fulkerson Algorithm, Edmonds-Karp Algorithm.

16. **Sliding Window Technique**:

    - Useful for problems involving contiguous subarrays or sublists.
    - Maintain a "window" of fixed size while iterating through the array.
    - Example problems: Maximum Sum Subarray of Size K, Longest Substring with At Most K Distinct Characters.

17. **Union-Find (Disjoint Set Union)**:

    - Efficiently manage disjoint sets and perform union and find operations.
    - Used in graph algorithms and dynamic connectivity problems.
    - Example problems: Detect Cycle in an Undirected Graph, Kruskal's Minimum Spanning Tree.

18. **Suffix Arrays and Suffix Trees**:

    - Represent all suffixes of a string in a compact data structure.
    - Useful for string matching and substring search.
    - Example problems: Longest Common Prefix, Longest Repeated Substring.

19. **Bit Manipulation**:

    - Perform operations at the bit level (AND, OR, XOR, shifts).
    - Useful for optimizing space and solving specific problems.
    - Example problems: Single Number, Counting Bits, Bitwise AND of Numbers Range.

20. **Matrix Problems**:

    - Solve problems related to matrices.
    - Common techniques include matrix traversal, rotation, and manipulation.
    - Example problems: Rotate Image, Spiral Matrix, Set Matrix Zeroes.

21. **Random Sampling and Reservoir Sampling**:

    - Select a random subset from a larger dataset.
    - Useful for streaming data or when memory is limited.
    - Example problems: Random Pick with Weight, Randomized Set.

22. **Parallel Binary Search**:

    - Perform binary search on multiple arrays simultaneously.
    - Useful for problems involving multiple sorted arrays.
    - Example problems: Find Kth Smallest Element in Sorted Matrix.

23. **Manhattan Distance and Grid Problems**:

    - Solve problems related to grid-based movements.
    - Use the Manhattan distance (L1 distance) for calculations.
    - Example problems: Robot in a Grid, Minimum Moves to Reach Target.

24. **Top-Down Dynamic Programming (Memoization)**:

    - Solve problems recursively by breaking them into smaller subproblems.
    - Cache intermediate results to avoid redundant computations.
    - Example problems: Fibonacci (using memoization), Longest Increasing Subsequence.

25. **Bottom-Up Dynamic Programming (Tabulation)**:
    - Solve problems iteratively by building solutions from the base case.
    - Fill a table or array with solutions to subproblems.
    - Example problems: Coin Change, Longest Common Substring.
