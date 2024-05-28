### Easy Category: Sliding Window Pattern Problems

#### 1. Maximum Sum Subarray of Size K

**Problem Description:** Find the maximum sum of any contiguous subarray of size `K`.

**Solution Approach:**
1. Initialize the sum of the first `K` elements.
2. Slide the window by one element at a time, adding the next element and removing the first element of the previous window.
3. Keep track of the maximum sum encountered.

**Code Snippet:**
```csharp
public static int MaxSumSubarrayOfSizeK(int[] arr, int K) {
    int maxSum = 0, windowSum = 0;

    // Calculate the sum of the first window
    for (int i = 0; i < K; i++) {
        windowSum += arr[i];
    }
    maxSum = windowSum;

    // Slide the window
    for (int i = K; i < arr.Length; i++) {
        windowSum += arr[i] - arr[i - K];
        maxSum = Math.Max(maxSum, windowSum);
    }

    return maxSum;
}

// Example
// Input: arr = [2, 1, 5, 1, 3, 2], K = 3
// Output: 9 (subarray [5, 1, 3])
```

#### 2. Smallest Subarray with a Given Sum

**Problem Description:** Find the length of the smallest contiguous subarray whose sum is greater than or equal to a given number `S`.

**Solution Approach:**
1. Use two pointers to create a window.
2. Expand the window by adding elements until the sum is greater than or equal to `S`.
3. Shrink the window from the start to find the smallest length.

**Code Snippet:**
```csharp
public static int SmallestSubarrayWithGivenSum(int[] arr, int S) {
    int minLength = int.MaxValue, windowSum = 0;
    int start = 0;

    for (int end = 0; end < arr.Length; end++) {
        windowSum += arr[end];

        while (windowSum >= S) {
            minLength = Math.Min(minLength, end - start + 1);
            windowSum -= arr[start];
            start++;
        }
    }

    return minLength == int.MaxValue ? 0 : minLength;
}

// Example
// Input: arr = [2, 1, 5, 2, 3, 2], S = 7
// Output: 2 (subarray [5, 2])
```

#### 3. Longest Substring with K Distinct Characters

**Problem Description:** Find the length of the longest substring with no more than `K` distinct characters.

**Solution Approach:**
1. Use a dictionary to count characters in the current window.
2. Expand the window by adding characters until there are more than `K` distinct characters.
3. Shrink the window from the start until there are `K` or fewer distinct characters.

**Code Snippet:**
```csharp
public static int LongestSubstringWithKDistinct(string str, int K) {
    Dictionary<char, int> charCount = new Dictionary<char, int>();
    int maxLength = 0, start = 0;

    for (int end = 0; end < str.Length; end++) {
        if (!charCount.ContainsKey(str[end])) {
            charCount[str[end]] = 0;
        }
        charCount[str[end]]++;

        while (charCount.Count > K) {
            charCount[str[start]]--;
            if (charCount[str[start]] == 0) {
                charCount.Remove(str[start]);
            }
            start++;
        }

        maxLength = Math.Max(maxLength, end - start + 1);
    }

    return maxLength;
}

// Example
// Input: str = "araaci", K = 2
// Output: 4 (substring "araa")
```

---

### Medium Category: Sliding Window Pattern Problems

#### 4. Longest Substring Without Repeating Characters

**Problem Description:** Find the length of the longest substring without repeating characters.

**Solution Approach:**
1. Use a set to track characters in the current window.
2. Expand the window by adding characters until a duplicate is found.
3. Shrink the window from the start until no duplicates remain.

**Code Snippet:**
```csharp
public static int LongestSubstringWithoutRepeatingCharacters(string str) {
    HashSet<char> charSet = new HashSet<char>();
    int maxLength = 0, start = 0;

    for (int end = 0; end < str.Length; end++) {
        while (charSet.Contains(str[end])) {
            charSet.Remove(str[start]);
            start++;
        }
        charSet.Add(str[end]);
        maxLength = Math.Max(maxLength, end - start + 1);
    }

    return maxLength;
}

// Example
// Input: str = "abcabcbb"
// Output: 3 (substring "abc")
```

#### 5. Permutation in String

**Problem Description:** Given two strings `s1` and `s2`, check if `s2` contains a permutation of `s1`.

**Solution Approach:**
1. Use a frequency array to count characters in `s1`.
2. Use a sliding window of the same length as `s1` to count characters in `s2`.
3. Compare the frequency arrays.

**Code Snippet:**
```csharp
public static bool CheckInclusion(string s1, string s2) {
    if (s1.Length > s2.Length) return false;

    int[] s1Count = new int[26];
    int[] s2Count = new int[26];

    for (int i = 0; i < s1.Length; i++) {
        s1Count[s1[i] - 'a']++;
        s2Count[s2[i] - 'a']++;
    }

    for (int i = 0; i < s2.Length - s1.Length; i++) {
        if (s1Count.SequenceEqual(s2Count)) return true;

        s2Count[s2[i] - 'a']--;
        s2Count[s2[i + s1.Length] - 'a']++;
    }

    return s1Count.SequenceEqual(s2Count);
}

// Example
// Input: s1 = "ab", s2 = "eidbaooo"
// Output: true (s2 contains permutation "ba")
```

#### 6. Longest Subarray with Ones after Replacement

**Problem Description:** Find the length of the longest subarray containing only 1s after replacing no more than `K` 0s.

**Solution Approach:**
1. Use two pointers to create a window.
2. Expand the window by adding elements and count the number of 0s.
3. Shrink the window from the start if the number of 0s exceeds `K`.

**Code Snippet:**
```csharp
public static int LongestOnesAfterReplacement(int[] arr, int K) {
    int maxLength = 0, start = 0, maxOnesCount = 0;

    for (int end = 0; end < arr.Length; end++) {
        if (arr[end] == 1) {
            maxOnesCount++;
        }

        if (end - start + 1 - maxOnesCount > K) {
            if (arr[start] == 1) {
                maxOnesCount--;
            }
            start++;
        }

        maxLength = Math.Max(maxLength, end - start + 1);
    }

    return maxLength;
}

// Example
// Input: arr = [0, 1, 1, 0, 0, 1, 1, 0, 1, 1], K = 2
// Output: 6 (subarray [1, 1, 0, 0, 1, 1])
```

---
### Hard Category: Sliding Window Pattern Problems

#### 7. Minimum Window Substring

**Problem Description:** Given two strings `s` and `t`, find the minimum window in `s` which will contain all the characters in `t`.

**Solution Approach:**
1. Use a dictionary to count characters in `t`.
2. Use a sliding window to count characters in `s`.
3. Expand the window to include all characters of `t`.
4. Shrink the window to find the minimum length.

**Code Snippet:**
```csharp
public static string MinWindowSubstring(string s, string t) {
    if (string.IsNullOrEmpty(s) || string.IsNullOrEmpty(t)) return "";

    Dictionary<char, int> tCount = new Dictionary<char, int>();
    foreach (char c in t) {
        if (!tCount.ContainsKey(c)) {
            tCount[c] = 0;
        }
        tCount[c]++;
    }

    int start = 0, minLength = int.MaxValue, matched = 0, subStart = 0;
    Dictionary<char, int> windowCount = new Dictionary<char, int>();

    for (int end = 0; end < s.Length; end++) {
        char endChar = s[end];
        if (!windowCount.ContainsKey(endChar)) {
            windowCount[endChar] = 0;
        }
        windowCount[endChar]++;

        if (tCount.ContainsKey(endChar) && windowCount[endChar] <= tCount[endChar]) {
            matched++;
        }

        while (matched == t.Length) {
            if (minLength > end - start + 1) {
                minLength = end - start + 1;
                subStart = start;
            }

            char startChar = s[start];
            windowCount[startChar]--;
            if (tCount.ContainsKey(startChar) && windowCount[startChar] < tCount[startChar]) {
                matched--;
            }
            start++;
        }
    }

    return minLength == int.MaxValue ? "" : s.Substring(subStart, minLength);
}

// Example
// Input: s = "ADOBECODEBANC", t = "ABC"
// Output: "BANC"
```

#### 8. Sliding Window Maximum

**Problem Description:** Given an array `nums` and an integer `k`, find the maximum for each sliding window of size `k`.

**Solution Approach:**
1. Use a deque to store indices of elements.
2. Maintain the deque to always have the maximum element at the front.
3. Slide the window and adjust the deque accordingly.

**Code Snippet:**
```csharp
public static int[] MaxSlidingWindow(int[] nums, int k) {
    if (nums == null || nums.Length == 0) return new int[0];

    int[] result = new int[nums.Length - k + 1];
    LinkedList<int> deque = new LinkedList<int>();

    for (int i = 0; i < nums.Length; i++) {
        if (deque.Count > 0 && deque.First.Value < i - k + 1) {
            deque.RemoveFirst();
        }

        while (deque.Count > 0 && nums[deque.Last.Value] < nums[i]) {
            deque.RemoveLast();
        }

        deque.AddLast(i);

        if (i >= k - 1) {
            result[i - k + 1] = nums[deque.First.Value];
        }
    }

    return result;
}

// Example
// Input: nums = [1,3,-1,-3,5,3,6,7], k = 3
// Output: [3,3,5,5,6,7]
```

#### 9. Longest Substring with At Most Two Distinct Characters

**Problem Description:** Find the length of the longest substring that contains at most two distinct characters.

**Solution Approach:**
1. Use a dictionary to count characters in the current window.
2. Expand the window by adding characters until there are more than two distinct characters.
3. Shrink the window from the start until there are at most two distinct characters.

**Code Snippet:**
```csharp
public static int LongestSubstringWithTwoDistinct(string str) {
    Dictionary<char, int> charCount = new Dictionary<char, int>();
    int maxLength = 0, start = 0;

    for (int end = 0; end < str.Length; end++) {
        if (!charCount.ContainsKey(str[end])) {
            charCount[str[end]] = 0;
        }
        charCount[str[end]]++;

        while (charCount.Count > 2) {
            charCount[str[start]]--;
            if (charCount[str[start]] == 0) {
                charCount.Remove(str[start]);
            }
            start++;
        }

        maxLength = Math.Max(maxLength, end - start + 1);
    }
    public static int LongestSubstringWithTwoDistinct(string str) {
    Dictionary<char, int> charCount = new Dictionary<char, int>();
    int maxLength = 0, start = 0;

    for (int end = 0; end < str.Length; end++) {
        if (!charCount.ContainsKey(str[end])) {
            charCount[str[end]] = 0;
        }
        charCount[str[end]]++;

        while (charCount.Count > 2) {
            charCount[str[start]]--;
            if (charCount[str[start]] == 0) {
                charCount.Remove(str[start]);
            }
            start++;
        }

        maxLength = Math.Max(maxLength, end - start + 1);
    }

    return maxLength;
}

// Example
// Input: str = "eceba"
// Output: 3 (substring "ece")
```

#### 10. Subarrays with K Different Integers

**Problem Description:** Given an array `A` and an integer `K`, find the number of subarrays that contain exactly `K` different integers.

**Solution Approach:**
1. Use a helper function to count subarrays with at most `K` different integers.
2. Subtract the count of subarrays with at most `K-1` different integers from the count of subarrays with at most `K` different integers.

**Code Snippet:**
```csharp
public static int SubarraysWithKDistinct(int[] A, int K) {
    return AtMostKDistinct(A, K) - AtMostKDistinct(A, K - 1);
}

private static int AtMostKDistinct(int[] A, int K) {
    Dictionary<int, int> count = new Dictionary<int, int>();
    int start = 0, result = 0;

    for (int end = 0; end < A.Length; end++) {
        if (!count.ContainsKey(A[end])) {
            count[A[end]] = 0;
        }
        count[A[end]]++;

        while (count.Count > K) {
            count[A[start]]--;
            if (count[A[start]] == 0) {
                count.Remove(A[start]);
            }
            start++;
        }

        result += end - start + 1;
    }

    return result;
}

// Example
// Input: A = [1, 2, 1, 2, 3], K = 2
// Output: 7 (subarrays are [1,2], [2,1], [1,2], [2,3], [1,2,1], [2,1,2], [1,2,3])
```

#### 11. Longest Substring with At Most K Distinct Characters

**Problem Description:** Find the length of the longest substring that contains at most `K` distinct characters.

**Solution Approach:**
1. Use a dictionary to count characters in the current window.
2. Expand the window by adding characters until there are more than `K` distinct characters.
3. Shrink the window from the start until there are at most `K` distinct characters.

**Code Snippet:**
```csharp
public static int LongestSubstringWithKDistinct(string str, int K) {
    Dictionary<char, int> charCount = new Dictionary<char, int>();
    int maxLength = 0, start = 0;

    for (int end = 0; end < str.Length; end++) {
        if (!charCount.ContainsKey(str[end])) {
            charCount[str[end]] = 0;
        }
        charCount[str[end]]++;

        while (charCount.Count > K) {
            charCount[str[start]]--;
            if (charCount[str[start]] == 0) {
                charCount.Remove(str[start]);
            }
            start++;
        }

        maxLength = Math.Max(maxLength, end - start + 1);
    }

    return maxLength;
}

// Example
// Input: str = "araaci", K = 2
// Output: 4 (substring "araa")
```


   