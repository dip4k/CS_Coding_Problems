# problem-solving patterns:

1. **Coding Patterns for DSA by Nishant4coding**:

   - This repository categorizes coding interview problems into a set of **16 patterns**. It covers various topics and provides solutions in JavaScript.
   - Some of the patterns included are:
     - Sliding Window
     - Two Pointers
     - Fast & Slow Pointers (Hare & Tortoise algorithm)
     - Merge Intervals
     - Cyclic Sort
     - In-place Reversal of a LinkedList
     - Tree Breadth First Search
     - Tree Depth First Search
     - Subsets
     - Modified Binary Search
     - Bitwise XOR
     - Top 'K' Elements
     - K-way Merge
     - 0-1 Knapsack (Dynamic Programming)
     - Topological Sort (Graph)
   - You can find the repository [here](https://github.com/Nishant4coding/Coding-Patterns-for-dsa).

2. **DSA Patterns by edsondsouza**:

   - This repository consists of pattern problems solved while learning data structures and algorithms. It's a great resource for beginners.
   - You can explore it [here](https://github.com/edsondsouza/DSA-Patterns).

3. **100 DSA Interview Problems by SohanR**:

   - SohanR curated a list of the top 100 DSA problems from LeetCode, covering a wide array of topics such as Array, String, Linked List, Graph, Dynamic Programming, Tree, Stack, Queue, and more.
   - Check it out [here](https://github.com/SohanR/100-DSA-Interview-Problems).

---

# **essential problem-solving patterns in data structures and algorithms (DSA)**. These patterns provide a structured approach to tackle various types of problems. Here are **20 examples** of such patterns:

1. **Two Pointer Technique**:

   - Usage: The two pointer technique is powerful for linear data structures like arrays, strings, or linked lists. It involves using two pointers to traverse the data in a coordinated manner, often moving in opposite directions or with a consistent interval between them.
   - Sample Problems:
     - Locating the nearest pair from two sorted arrays.
     - Identifying the pair in an array whose sum is closest to a given value, *x*¹.

2. **Sliding Window Technique**:

   - Usage: This technique involves maintaining a "window" of elements within an array or string. It's useful for problems involving subarrays or substrings.
   - Sample Problems:
     - Maximum sum subarray of fixed size _k_.
     - Longest substring without repeating characters.

3. **Binary Search**:

   - Usage: Binary search is efficient for sorted arrays. It divides the search space in half at each step.
   - Sample Problems:
     - Finding an element in a sorted array.
     - Rotated sorted array search.

4. **Depth-First Search (DFS)**:

   - Usage: DFS explores as far as possible along a branch before backtracking.
   - Sample Problems:
     - Connected components in an undirected graph.
     - Detecting cycles in a graph.

5. **Breadth-First Search (BFS)**:

   - Usage: BFS explores neighbors before moving to the next level.
   - Sample Problems:
     - Shortest path in an unweighted graph.
     - Level order traversal of a binary tree.

6. **Dynamic Programming (DP)**:

   - Usage: DP breaks down a problem into smaller subproblems and stores their solutions to avoid redundant computations.
   - Sample Problems:
     - Fibonacci sequence.
     - Longest common subsequence.

7. **Greedy Algorithms**:

   - Usage: Greedy algorithms make locally optimal choices at each step.
   - Sample Problems:
     - Activity selection problem.
     - Huffman coding.

8. **Hashing**:

   - Usage: Hashing allows efficient data retrieval based on keys.
   - Sample Problems:
     - Two Sum problem.
     - Group anagrams.

9. **Topological Sort**:

   - Usage: Topological sort orders nodes in a directed acyclic graph.
   - Sample Problems:
     - Course schedule.
     - Dependency resolution.

10. **Union-Find (Disjoint Set Union)**:

    - Usage: Union-Find tracks disjoint sets and performs union and find operations.
    - Sample Problems:
      - Detecting cycles in an undirected graph.
      - Kruskal's algorithm for minimum spanning tree.

11. **Graph Algorithms**:

    - **Depth-First Search (DFS)** and **Breadth-First Search (BFS)** are fundamental graph traversal techniques. Additionally, graph algorithms include:
      - **Dijkstra's Algorithm**: Finds the shortest path in a weighted graph.
      - **Bellman-Ford Algorithm**: Also finds the shortest path, but can handle negative edge weights.
      - **Floyd-Warshall Algorithm**: Computes all-pairs shortest paths.
      - **Minimum Spanning Tree (MST)** algorithms like Prim's and Kruskal's.

12. **Backtracking**:

    - Backtracking involves exploring all possible solutions by making choices and undoing them if they lead to a dead end.
    - Sample Problems:
      - **N-Queens**: Placing N queens on an N×N chessboard without attacking each other.
      - **Sudoku Solver**: Filling in a partially completed Sudoku grid.

13. **Trie (Prefix Tree)**:

    - A trie is a tree-like data structure used for efficient string matching and storage.
    - Sample Problems:
      - **Word Search II**: Finding words from a dictionary in a 2D board.
      - **Autocomplete System**: Implementing an autocomplete feature.

14. **Segment Tree**:

    - A segment tree is useful for range queries and updates on an array.
    - Sample Problems:
      - **Range Sum Queries**: Finding the sum of elements in a given range.
      - **Lazy Propagation**: Efficiently updating elements in a range.

15. **Binary Indexed Tree (BIT or Fenwick Tree)**:

    - BIT is another data structure for efficient range queries and updates.
    - Sample Problems:
      - **Count of Inversions**: Counting inversions in an array.
      - **Range Minimum Query (RMQ)**: Finding the minimum element in a range.

16. **Fast Exponentiation (Binary Exponentiation)**:

    - Efficiently computing large powers of a number.
    - Formula: $$ a^b \mod m = (a \mod m)^b \mod m $$
    - Sample Problems:
      - Calculating large Fibonacci numbers modulo _m_.
      - Modular exponentiation.

17. **Mo's Algorithm**:

    - A square root decomposition technique for offline queries on an array.
    - Sample Problems:
      - **Range Queries with Updates**: Handling range queries and updates efficiently.
      - **Distinct Elements in a Range**: Counting distinct elements in a subarray.

18. **Manacher's Algorithm**:

    - Finding the longest palindromic substring in linear time.
    - Sample Problems:
      - Longest palindromic substring.
      - Counting palindromic substrings.

19. **Suffix Array and Suffix Tree**:

    - Data structures for string processing and pattern matching.
    - Sample Problems:
      - Longest common prefix.
      - Longest repeated substring.

20. **Matrix Exponentiation**:
    - Efficiently computing large powers of a matrix.
    - Sample Problems:
      - Fibonacci numbers using matrix exponentiation.
      - Linear recurrence relations.

---

# examples for each of the problem-solving patterns mentioned earlier:

1. **Two Pointer Technique**:

   - **Problem**: Given a sorted array, find two elements whose sum equals a target value.
   - **Solution**: Use two pointers (one at the start and one at the end) to traverse the array and adjust their positions based on the sum.

2. **Sliding Window Technique**:

   - **Problem**: Find the maximum sum of a subarray of size _k_ in an array.
   - **Solution**: Maintain a sliding window of size _k_ and update the sum as you slide through the array.

3. **Binary Search**:

   - **Problem**: Given a sorted array, find the index of a specific element.
   - **Solution**: Divide the search space in half by comparing the middle element with the target.

4. **Depth-First Search (DFS)**:

   - **Problem**: Find all connected components in an undirected graph.
   - **Solution**: Recursively explore each vertex and mark visited nodes.

5. **Breadth-First Search (BFS)**:

   - **Problem**: Compute the shortest path in an unweighted graph.
   - **Solution**: Use a queue to explore neighbors level by level.

6. **Dynamic Programming (DP)**:

   - **Problem**: Compute the nth Fibonacci number.
   - **Solution**: Use memoization or tabulation to avoid redundant calculations.

7. **Greedy Algorithms**:

   - **Problem**: Select a subset of activities to maximize the number of non-overlapping activities.
   - **Solution**: Sort activities by end time and greedily select compatible ones.

8. **Hashing**:

   - **Problem**: Given an array, find two numbers that add up to a specific sum.
   - **Solution**: Use a hash table to store seen elements and check for complements.

9. **Topological Sort**:

   - **Problem**: Schedule courses with prerequisites.
   - **Solution**: Build a directed graph and perform a topological sort.

10. **Union-Find (Disjoint Set Union)**:

    - **Problem**: Detect cycles in an undirected graph.
    - **Solution**: Use union-find data structure to track connected components.

11. **Graph Algorithms**:

    - **Depth-First Search (DFS)** and **Breadth-First Search (BFS)** are fundamental graph traversal techniques. Additionally, graph algorithms include:
      - **Dijkstra's Algorithm**: Finds the shortest path in a weighted graph.
      - **Bellman-Ford Algorithm**: Also finds the shortest path, but can handle negative edge weights.
      - **Floyd-Warshall Algorithm**: Computes all-pairs shortest paths.
      - **Minimum Spanning Tree (MST)** algorithms like Prim's and Kruskal's.

12. **Backtracking**:

    - Backtracking involves exploring all possible solutions by making choices and undoing them if they lead to a dead end.
    - Sample Problems:
      - **N-Queens**: Placing N queens on an N×N chessboard without attacking each other.
      - **Sudoku Solver**: Filling in a partially completed Sudoku grid.

13. **Trie (Prefix Tree)**:

    - A trie is a tree-like data structure used for efficient string matching and storage.
    - Sample Problems:
      - **Word Search II**: Finding words from a dictionary in a 2D board.
      - **Autocomplete System**: Implementing an autocomplete feature.

14. **Segment Tree**:

    - A segment tree is useful for range queries and updates on an array.
    - Sample Problems:
      - **Range Sum Queries**: Finding the sum of elements in a given range.
      - **Lazy Propagation**: Efficiently updating elements in a range.

15. **Binary Indexed Tree (BIT or Fenwick Tree)**:

    - BIT is another data structure for efficient range queries and updates.
    - Sample Problems:
      - **Count of Inversions**: Counting inversions in an array.
      - **Range Minimum Query (RMQ)**: Finding the minimum element in a range.

16. **Fast Exponentiation (Binary Exponentiation)**:

    - Efficiently computing large powers of a number.
    - Formula: $$ a^b \mod m = (a \mod m)^b \mod m $$
    - Sample Problems:
      - Calculating large Fibonacci numbers modulo _m_.
      - Modular exponentiation.

17. **Mo's Algorithm**:

    - A square root decomposition technique for offline queries on an array.
    - Sample Problems:
      - **Range Queries with Updates**: Handling range queries and updates efficiently.
      - **Distinct Elements in a Range**: Counting distinct elements in a subarray.

18. **Manacher's Algorithm**:

    - Finding the longest palindromic substring in linear time.
    - Sample Problems:
      - Longest palindromic substring.
      - Counting palindromic substrings.

19. **Suffix Array and Suffix Tree**:

    - Data structures for string processing and pattern matching.
    - Sample Problems:
      - Longest common prefix.
      - Longest repeated substring.

20. **Matrix Exponentiation**:
    - Efficiently computing large powers of a matrix.
    - Sample Problems:
      - Fibonacci numbers using matrix exponentiation.
      - Linear recurrence relations.

---
