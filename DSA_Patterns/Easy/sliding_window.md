### Sliding Window Pattern: Commonly Asked Problems

#### Easy Problems

1. **Maximum Sum Subarray of Size K**
   - **Description:** Find the maximum sum of any contiguous subarray of size `K`.
   - **Data Structure:** Array
   - **Time Complexity:** O(N)
   - **Space Complexity:** O(1)
   - **Solution Description:**
     - Initialize the sum of the first `K` elements.
     - Slide the window by one element at a time, adding the next element and removing the first element of the previous window.
     - Keep track of the maximum sum encountered.

2. **Smallest Subarray with a Given Sum**
   - **Description:** Find the length of the smallest contiguous subarray whose sum is greater than or equal to a given number `S`.
   - **Data Structure:** Array
   - **Time Complexity:** O(N)
   - **Space Complexity:** O(1)
   - **Solution Description:**
     - Use two pointers to create a window.
     - Expand the window by adding elements until the sum is greater than or equal to `S`.
     - Shrink the window from the start to find the smallest length.

3. **Longest Substring with K Distinct Characters**
   - **Description:** Find the length of the longest substring with no more than `K` distinct characters.
   - **Data Structure:** String, Dictionary (for character count)
   - **Time Complexity:** O(N)
   - **Space Complexity:** O(K)
   - **Solution Description:**
     - Use a dictionary to count characters in the current window.
     - Expand the window by adding characters until there are more than `K` distinct characters.
     - Shrink the window from the start until there are `K` or fewer distinct characters.

#### Medium Problems

4. **Longest Substring Without Repeating Characters**
   - **Description:** Find the length of the longest substring without repeating characters.
   - **Data Structure:** String, HashSet
   - **Time Complexity:** O(N)
   - **Space Complexity:** O(min(N, M)) where `M` is the character set size
   - **Solution Description:**
     - Use a HashSet to track characters in the current window.
     - Expand the window by adding characters while ensuring no duplicates.
     - Shrink the window from the start to remove duplicates.

5. **Permutation in String**
   - **Description:** Given two strings `s1` and `s2`, return true if `s2` contains a permutation of `s1`.
   - **Data Structure:** String, Dictionary (for character count)
   - **Time Complexity:** O(N)
   - **Space Complexity:** O(1)
   - **Solution Description:**
     - Use a dictionary to count characters in `s1`.
     - Slide a window of size equal to `s1` over `s2`.
     - Compare character counts in the current window with those of `s1`.

6. **Longest Subarray with Ones after Replacement**
   - **Description:** Find the length of the longest contiguous subarray with all 1s after replacing at most `K` 0s with 1s.
   - **Data Structure:** Array
   - **Time Complexity:** O(N)
   - **Space Complexity:** O(1)
   - **Solution Description:**
     - Use two pointers to create a window.
     - Expand the window by adding elements and count the number of 0s.
     - Shrink the window from the start until the number of 0s is within the allowed limit.

#### Hard Problems

7. **Minimum Window Substring**
   - **Description:** Given a string `s` and a string `t`, find the minimum window in `s` which will contain all the characters in `t`.
   - **Data Structure:** String, Dictionary (for character count)
   - **Time Complexity:** O(N)
   - **Space Complexity:** O(N)
   - **Solution Description:**
     - Use a dictionary to count characters in `t`.
     - Slide a window over `s` and keep track of the count of characters from `t`.
     - Shrink the window from the start to find the minimum length.

8. **Longest Substring with At Most Two Distinct Characters**
   - **Description:** Find the length of the longest substring with at most two distinct characters.
   - **Data Structure:** String, Dictionary (for character count)
   - **Time Complexity:** O(N)
   - **Space Complexity:** O(1)
   - **Solution Description:**
     - Use a dictionary to count characters in the current window.
     - Expand the window by adding characters until there are more than two distinct characters.
     - Shrink the window from the start to maintain at most two distinct characters.

9. **Longest Substring with At Most K Distinct Characters**
   - **Description:** Find the length of the longest substring with at most `K` distinct characters.
   - **Data Structure:** String, Dictionary (for character count)
   - **Time Complexity:** O(N)
   - **Space Complexity:** O(K)
   - **Solution Description:**
     - Use a dictionary to count characters in the current window.
     - Expand the window by adding characters until there are more than `K` distinct characters.
     - Shrink the window from the start to maintain at most `K` distinct characters.

10. **Maximum Number of Vowels in a Substring of Given Length**
    - **Description:** Find the maximum number of vowels in any substring of a given length `K`.
    - **Data Structure:** String
    - **Time Complexity:** O(N)
    - **Space Complexity:** O(1)
    - **Solution Description:**
      - Initialize the count of vowels in the first `K` characters.
      - Slide the window by one character at a time, adding the next character and removing the first character of the previous window.
      - Keep track of the maximum count of vowels encountered.

---

### Summary

Here is a summary of the commonly asked sliding window pattern problems categorized by difficulty level:

#### Easy
1. **Maximum Sum Subarray of Size K**
2. **Smallest Subarray with a Given Sum**
3. **Longest Substring with K Distinct Characters**

#### Medium
4. **Longest Substring Without Repeating Characters**
5. **Permutation in String**
6. **Longest Subarray with Ones after Replacement**

#### Hard
7. **Minimum Window Substring**
8. **Longest Substring with At Most Two Distinct Characters**
9. **Longest Substring with At Most K Distinct Characters**
10. **Maximum Number of Vowels in a Substring of Given Length**
