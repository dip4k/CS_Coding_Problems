# C# String Manipulation Problems

## Easy

1. **Reverse a String**

   Problem: Write a C# program to reverse a string without using any built-in functions.

   Approach 1: Use a for loop to iterate through the string in reverse order and store the characters in a new string. 

   **Time Complexity: O(n)** 

   **Space Complexity: O(n)**

   **Algorithm: Iteration**

   Approach 2: Use recursion to reverse the string. 

   **Time Complexity: O(n)** 

   **Space Complexity: O(n)**

   **Algorithm: Recursion**

   **Best Approach: Approach 1** - It has the same time complexity as approach 2 but uses less space as it doesn't require a call stack.

2. **Count Occurrences of a Character**

   Problem: Write a C# program to count the number of occurrences of a specific character in a string.

   Approach 1: Use a for loop to iterate through the string and increment a counter whenever the specific character is found. 

   **Time Complexity: O(n)** 

   **Space Complexity: O(1)**

   **Algorithm: Iteration**

   Approach 2: Use LINQ to count the occurrences of the specific character. 

   **Time Complexity: O(n)** 

   **Space Complexity: O(1)**

   **Algorithm: LINQ**

   **Best Approach: Approach 1** - It has the same time complexity as approach 2 but doesn't require the overhead of LINQ.

3. **Check if a String is a Palindrome**

   Problem: Write a C# program to check if a given string is a palindrome or not.

   Approach 1: Use a two-pointer technique to compare characters from the start and end of the string. 

   **Time Complexity: O(n)** 

   **Space Complexity: O(1)**

   **Algorithm: Two-pointers**

   Approach 2: Reverse the string and compare it with the original string. 

   **Time Complexity: O(n)** 

   **Space Complexity: O(n)**

   **Algorithm: Iteration**

   **Best Approach: Approach 1** - It has the same time complexity as approach 2 but requires less space as it doesn't need to store the reversed string.

4. **Find the Length of a String**

   Problem: Write a C# program to find the length of a string without using any built-in functions.

   Approach 1: Use a while loop to iterate through the string until the end is reached, incrementing a counter at each step. 

   **Time Complexity: O(n)** 

   **Space Complexity: O(1)**

   **Algorithm: Iteration**

   Approach 2: Use recursion to count the characters in the string. 

   **Time Complexity: O(n)** 

   **Space Complexity: O(n)**

   **Algorithm: Recursion**

   **Best Approach: Approach 1** - It has the same time complexity as approach 2 but uses less space as it doesn't require a call stack.

## Medium

5. **Remove Duplicates from a String**

   Problem: Write a C# program to remove duplicate characters from a given string.

   Approach 1: Use a HashSet to store unique characters and build the result string. 

   **Time Complexity: O(n)** 

   **Space Complexity: O(n)**

   **Algorithm: HashSet**

   Approach 2: Use two nested loops, the outer loop picks a character, the inner loop checks for the character's duplicates. 

   **Time Complexity: O(n^2)** 

   **Space Complexity: O(1)**

   **Algorithm: Iteration**

   **Best Approach: Approach 1** - It has a lower time complexity than approach 2.

6. **First Non-Repeating Character**

   Problem: Write a C# program to find the first non-repeating character in a string.

   Approach 1: Use a dictionary to count the occurrences of each character, then iterate through the dictionary to find the first character with a count of 1. 

   **Time Complexity: O(n)** 

   **Space Complexity: O(n)**

   **Algorithm: HashMap**

   Approach 2: Use two loops, the outer loop picks characters one by one, the inner loop checks for the picked character's duplicates. 

   **Time Complexity: O(n^2)** 

   **Space Complexity: O(1)**

   **Algorithm: Iteration**

   **Best Approach: Approach 1** - It has a lower time complexity than approach 2.

7. **Anagram Check**

   Problem: Write a C# program to check if two given strings are anagrams of each other.

   Approach 1: Sort the characters of both strings and compare them. 

   **Time Complexity: O(n log n)** 

   **Space Complexity: O(n)**

   **Algorithm: Sorting**

   Approach 2: Use a count array to check the number of occurrences of each character in both strings. 

   **Time Complexity: O(n)** 

   **Space Complexity: O(1)**

   **Algorithm: Counting Sort**

   **Best Approach: Approach 2** - It has a lower time complexity than approach 1.

8. **String Compression**

   Problem: Implement a method to perform basic string compression using the counts of repeated characters.

   Approach 1: Use a StringBuilder to build the compressed string by iterating through the original string and counting the repeated characters. 

   **Time Complexity: O(n)** 

   **Space Complexity: O(n)**

   **Algorithm: Iteration**

   Approach 2: Use two pointers, one to track the current character and the other to track the next character. 

   **Time Complexity: O(n)** 

   **Space Complexity: O(1)**

   **Algorithm: Two-pointers**

   **Best Approach: Approach 1** - Both approaches have the same time complexity, but approach 1 is simpler and more intuitive.

## Hard

9. **String Rotation**

   Problem: Write a C# program to check if a string is a rotation of another string.

   Approach 1: Concatenate the original string with itself and check if the rotated string is a substring of the concatenated string. 

   **Time Complexity: O(n)** 

   **Space Complexity: O(n)**

   **Algorithm: Substring Check**

   Approach 2: Use two pointers and a counter to check the rotation. 

   **Time Complexity: O(n)** 

   **Space Complexity: O(1)**

   **Algorithm: Two-pointers**

   **Best Approach: Approach 1** - Both approaches have the same time complexity, but approach 1 is simpler and more intuitive.

10. **Longest Palindromic Substring**

    Problem: Write a C# program to find the longest palindromic substring in a given string.

    Approach 1: Use dynamic programming to check all substrings and find the longest palindromic substring. 

    **Time Complexity: O(n^2)** 

    **Space Complexity: O(n^2)**

    **Algorithm: Dynamic Programming**

    Approach 2: Expand around the center for each character and find the longest palindromic substring. 

    **Time Complexity: O(n^2)** 

    **Space Complexity: O(1)**

    **Algorithm: Iteration**

    **Best Approach: Approach 1** - Both approaches have the same time complexity, but approach 1 is more efficient in terms of space complexity.

11. **Longest Common Prefix**

    Problem: Write a C# program to find the longest common prefix string amongst an array of strings.

    Approach 1: Sort the array and compare the first and last strings to find the common prefix. 

    **Time Complexity: O(n log n)** 

    **Space Complexity: O(n)**

    **Algorithm: Sorting**

    Approach 2: Use a Trie data structure to insert all strings and find the longest common prefix. 

    **Time Complexity: O(n)** 

    **Space Complexity: O(n)**

    **Algorithm: Trie**

    **Best Approach: Approach 2** - It has a lower time complexity than approach 1.

12. **Wildcard Pattern Matching**

    Problem: Write a C# program to check if a string matches a given wildcard pattern.

    Approach 1: Use dynamic programming to build a 2D table of matches and fill it based on the pattern. 

    **Time Complexity: O(n*m)** 

    **Space Complexity: O(n*m)**

    **Algorithm: Dynamic Programming**

    Approach 2: Use two pointers, one for the string and one for the pattern, and a backtracking pointer for the '*' character. 

    **Time Complexity: O(n)** 

    **Space Complexity: O(1)**

    **Algorithm: Two-pointers**

    **Best Approach: Approach 2** - It has a lower time complexity than approach 1.
