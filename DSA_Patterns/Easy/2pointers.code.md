### Code Implementation

**Problem Category: Easy**

#### 1. Remove Duplicates from Sorted Array

**Problem**: Given a sorted array `nums`, remove the duplicates in-place such that each element appears only once and returns the new length.

**Approach**:

-   Use two pointers, one for iterating through the array and one for keeping track of the position to insert the next unique element.

**Code Snippet**:

```csharp
public int RemoveDuplicates(int[] nums) {
    if (nums.Length == 0) return 0;
    int insertPos = 1;
    for (int i = 1; i < nums.Length; i++) {
        if (nums[i] != nums[i - 1]) {
            nums[insertPos++] = nums[i];
        }
    }
    return insertPos;
}

// Example
// Input: [1, 1, 2]
// Output: 2, nums = [1, 2, _]
```

#### 2. Two Sum II - Input Array Is Sorted

**Problem**: Given an array of integers `numbers` that is already sorted in non-decreasing order, find two numbers such that they add up to a specific target number.

**Approach**:

-   Use two pointers, one starting from the beginning and one from the end.
-   Adjust the pointers based on the sum of the elements pointed by them.

**Code Snippet**:

```csharp
public int[] TwoSum(int[] numbers, int target) {
    int left = 0, right = numbers.Length - 1;
    while (left < right) {
        int sum = numbers[left] + numbers[right];
        if (sum == target) {
            return new int[] { left + 1, right + 1 };
        } else if (sum < target) {
            left++;
        } else {
            right--;
        }
    }
    return new int[0];
}

// Example
// Input: [2, 7, 11, 15], target = 9
// Output: [1, 2]
```

#### 3. Valid Palindrome

**Problem**: Given a string `s`, determine if it is a palindrome, considering only alphanumeric characters and ignoring cases.

**Approach**:

-   Use two pointers, one starting from the beginning and one from the end.
-   Skip non-alphanumeric characters and compare the characters pointed by the two pointers.

**Code Snippet**:

```csharp
public bool IsPalindrome(string s) {
    int left = 0, right = s.Length - 1;
    while (left < right) {
        while (left < right && !Char.IsLetterOrDigit(s[left])) left++;
        while (left < right && !Char.IsLetterOrDigit(s[right])) right--;
        if (Char.ToLower(s[left]) != Char.ToLower(s[right])) return false;
        left++;
        right--;
    }
    return true;
}

// Example
// Input: "A man, a plan, a canal: Panama"
// Output: true
```

#### 4. Reverse String

**Problem**: Write a function that reverses a string. The input string is given as an array of characters `s`.

**Approach**:

-   Use two pointers, one starting from the beginning and one from the end.
-   Swap the elements pointed by the two pointers and move them towards the center.

**Code Snippet**:

```csharp
public void ReverseString(char[] s) {
    int left = 0, right = s.Length - 1;
    while (left < right) {
        char temp = s[left];
        s[left] = s[right];
        s[right] = temp;
        left++;
        right--;
    }
}

// Example
// Input: ['h', 'e', 'l', 'l', 'o']
// Output: ['o', 'l', 'l', 'e', 'h']
```

#### 5. Move Zeroes

**Problem**: Given an integer array `nums`, move all 0's to the end of it while maintaining the relative order of the non-zero elements.

**Approach**:

-   Use two pointers, one for iterating through the array and one for keeping track of the position to insert the next non-zero element.

**Code Snippet**:

```csharp
public void MoveZeroes(int[] nums) {
    int insertPos = 0;
    for (int i = 0; i < nums.Length; i++) {
        if (nums[i] != 0) {
            nums[insertPos++] = nums[i];
        }
    }
    while (insertPos < nums.Length) {
        nums[insertPos++] = 0;
    }
}

// Example
// Input: [0, 1, 0, 3, 12]
// Output: [1, 3, 12, 0, 0
```

#### 6. Squares of a Sorted Array

**Problem**: Given an array of integers `nums` sorted in non-decreasing order, return an array of the squares of each number sorted in non-decreasing order.

**Approach**:

-   Use two pointers, one starting from the beginning and one from the end.
-   Compare the absolute values of the elements pointed by the two pointers, square the larger one, and insert it into the result array from the end.

**Code Snippet**:

```csharp
public int[] SortedSquares(int[] nums) {
    int n = nums.Length;
    int[] result = new int[n];
    int left = 0, right = n - 1;
    for (int i = n - 1; i >= 0; i--) {
        if (Math.Abs(nums[left]) > Math.Abs(nums[right])) {
            result[i] = nums[left] * nums[left];
            left++;
        } else {
            result[i] = nums[right] * nums[right];
            right--;
        }
    }
    return result;
}

// Example
// Input: [-4, -1, 0, 3, 10]
// Output: [0, 1, 9, 16, 100]
```

### Code Implementation: **Problem Category: Medium**

#### 1. 3Sum

**Problem**: Given an integer array `nums`, return all the triplets `[nums[i], nums[j], nums[k]]` such that `i != j`, `i != k`, and `j != k`, and `nums[i] + nums[j] + nums[k] == 0`.

**Approach**:

-   Sort the array.
-   Use a for loop to iterate through the array, and for each element, use two pointers to find the other two elements that sum up to zero.

**Code Snippet**:

```csharp
public IList<IList<int>> ThreeSum(int[] nums) {
    Array.Sort(nums);
    List<IList<int>> result = new List<IList<int>>();
    for (int i = 0; i < nums.Length - 2; i++) {
        if (i > 0 && nums[i] == nums[i - 1]) continue; // Skip duplicates
        int left = i + 1, right = nums.Length - 1;
        while (left < right) {
            int sum = nums[i] + nums[left] + nums[right];
            if (sum == 0) {
                result.Add(new List<int> { nums[i], nums[left], nums[right] });
                while (left < right && nums[left] == nums[left + 1]) left++; // Skip duplicates
                while (left < right && nums[right] == nums[right - 1]) right--; // Skip duplicates
                left++;
                right--;
            } else if (sum < 0) {
                left++;
            } else {
                right--;
            }
        }
    }
    return result;
}

// Example
// Input: [-1, 0, 1, 2, -1, -4]
// Output: [[-1, -1, 2], [-1, 0, 1]]
```

#### 2. Container With Most Water

**Problem**: Given `n` non-negative integers `a1, a2, ..., an` where each represents a point at coordinate `(i, ai)`. `n` vertical lines are drawn such that the two endpoints of the line `i` is at `(i, ai)` and `(i, 0)`. Find two lines, which together with the x-axis forms a container, such that the container contains the most water.

**Approach**:

-   Use two pointers, one starting from the beginning and one from the end.
-   Calculate the area formed by the lines pointed by the two pointers and adjust the pointers to try to find a larger area.

**Code Snippet**:

```csharp
public int MaxArea(int[] height) {
    int maxArea = 0;
    int left = 0, right = height.Length - 1;
    while (left < right) {
        int width = right - left;
        int currentHeight = Math.Min(height[left], height[right]);
        maxArea = Math.Max(maxArea, width * currentHeight);
        if (height[left] < height[right]) {
            left++;
        } else {
            right--;
        }
    }
    return maxArea;
}

// Example
// Input: [1,8,6,2,5,4,8,3,7]
// Output: 49
```

#### 3. Sort Colors

**Problem**: Given an array `nums` with `n` objects colored red, white, or blue, sort them in-place so that objects of the same color are adjacent, with the colors in the order red, white, and blue. We will use the integers `0`, `1`, and `2` to represent the color red, white, and blue, respectively.

**Approach**:

-   Use the Dutch National Flag algorithm by Edsger W. Dijkstra.
-   Maintain three pointers: `low`, `mid`, and `high`.
-   Iterate through the array and swap elements to ensure that all `0`s are moved to the beginning, all `2`s are moved to the end, and all `1`s are in the middle.

**Code Snippet**:

```csharp
public void SortColors(int[] nums) {
    int low = 0, mid = 0, high = nums.Length - 1;
    while (mid <= high) {
        if (nums[mid] == 0) {
            Swap(nums, low, mid);
            low++;
            mid++;
        } else if (nums[mid] == 1) {
            mid++;
        } else {
            Swap(nums, mid, high);
            high--;
        }
    }
}

private void Swap(int[] nums, int i, int j) {
    int temp = nums[i];
    nums[i] = nums[j];
    nums[j] = temp;
}

// Example
// Input: [2,0,2,1,1,0]
// Output: [0,0,1,1,2,2]
```

#### 4. Remove Duplicates from Sorted Array II

**Problem**: Given a sorted array `nums`, remove the duplicates in-place such that duplicates appeared at most twice and return the new length. Do not allocate extra space for another array; you must do this by modifying the input array in-place with O(1) extra memory.

**Approach**:

-   Use a pointer to keep track of the position to insert the next valid element.
-   Iterate through the array, allowing at most two occurrences of each element.

**Code Snippet**:

```csharp
public int RemoveDuplicates(int[] nums) {
    if (nums.Length <= 2) return nums.Length;

    int insertPos = 2; // Start from the third position
    for (int i = 2; i < nums.Length; i++) {
        if (nums[i] != nums[insertPos - 2]) {
            nums[insertPos] = nums[i];
            insertPos++;
        }
    }
    return insertPos;
}

// Example
// Input: nums = [0,0,1,1,1,1,2,3,3]
// Output: 7, with the first seven elements of nums being modified to [0,0,1,1,2,3,3]
```

#### 5. Longest Substring with At Most Two Distinct Characters

**Problem**: Given a string `s`, find the length of the longest substring `t` that contains at most 2 distinct characters.

**Approach**:

-   Use a sliding window technique with two pointers.
-   Use a hash map to keep track of the count of each character in the current window.
-   Adjust the window to ensure it contains at most 2 distinct characters.

**Code Snippet**:

```csharp
public int LengthOfLongestSubstringTwoDistinct(string s) {
    if (string.IsNullOrEmpty(s)) return 0;

    int maxLength = 0;
    int left = 0;
    Dictionary<char, int> charCount = new Dictionary<char, int>();

    for (int right = 0; right < s.Length; right++) {
        if (!charCount.ContainsKey(s[right])) {
            charCount[s[right]] = 0;
        }
        charCount[s[right]]++;

        while (charCount.Count > 2) {
            charCount[s[left]]--;
            if (charCount[s[left]] == 0) {
                charCount.Remove(s[left]);
            }
            left++;
        }

        maxLength = Math.Max(maxLength, right - left + 1);
    }

    return maxLength;
}

// Example
// Input: "eceba"
// Output: 3 (The answer is "ece" with length 3)
```

#### 6. Subarray Product Less Than K

**Problem**: Given an array of integers `nums` and an integer `k`, return the number of contiguous subarrays where the product of all the elements in the subarray is strictly less than `k`.

**Approach**:

-   Use a sliding window technique.
-   Maintain a product of the current window.
-   Adjust the window to ensure the product is less than `k`.

**Code Snippet**:

```csharp
public int NumSubarrayProductLessThanK(int[] nums, int k) {
    if (k <= 1) return 0;

    int count = 0;
    int left = 0;
    int product = 1;

    for (int right = 0; right < nums.Length; right++) {
        product *= nums[right];

        while (product >= k) {
            product /= nums[left];
            left++;
        }

        count += right - left + 1;
    }

    return count;
}

// Example
// Input: nums = [10, 5, 2, 6], k = 100
// Output: 8 (The 8 subarrays are [10], [5], [2], [6], [10, 5], [5, 2], [2, 6], [5, 2, 6])
```

#### 7. Remove Nth Node From End of List

**Problem**: Given the head of a linked list, remove the nth node from the end of the list and return its head.

**Approach**:

-   Use two pointers.
-   Move the first pointer `n` steps ahead.
-   Then move both pointers until the first pointer reaches the end.
-   The second pointer will be at the node just before the one to be removed.

**Code Snippet**:

```csharp
public ListNode RemoveNthFromEnd(ListNode head, int n) {
    ListNode dummy = new ListNode(0);
    dummy.next = head;
    ListNode first = dummy;
    ListNode second = dummy;

    // Move first pointer n+1 steps ahead
    for (int i = 0; i <= n; i++) {
        first = first.next;
    }

    // Move both pointers until first reaches the end
    while (first != null) {
        first = first.next;
        second = second.next;
    }

    // Remove the nth node from the end
    second.next = second.next.next;

    return dummy.next;
}

// Definition for singly-linked list.
public class ListNode {
    public int val;
    public ListNode next;
    public ListNode(int val=0, ListNode next=null) {
        this.val = val;
        this.next = next;
    }
}

// Example
// Input: head = [1,2,3,4,5], n = 2
// Output: [1,2,3,5]
```

### Code Implementation **Problem Category: Hard**

#### 1. Trapping Rain Water

**Problem**: Given `n` non-negative integers representing an elevation map where the width of each bar is 1, compute how much water it can trap after raining.

**Approach**:

-   Use two pointers to traverse the array from both ends.
-   Maintain left and right maximum heights.
-   Calculate trapped water based on the minimum of the two heights.

**Code Snippet**:

```csharp
public int Trap(int[] height) {
    if (height == null || height.Length == 0) return 0;

    int left = 0, right = height.Length - 1;
    int leftMax = 0, rightMax = 0;
    int waterTrapped = 0;

    while (left < right) {
        if (height[left] < height[right]) {
            if (height[left] >= leftMax) {
                leftMax = height[left];
            } else {
                waterTrapped += leftMax - height[left];
            }
            left++;
        } else {
            if (height[right] >= rightMax) {
                rightMax = height[right];
            } else {
                waterTrapped += rightMax - height[right];
            }
            right--;
        }
    }

    return waterTrapped;
}

// Example
// Input: height = [0,1,0,2,1,0,1,3,2,1,2,1]
// Output: 6
```

#### 2. Minimum Window Substring

**Problem**: Given two strings `s` and `t`, return the minimum window in `s` which will contain all the characters in `t`. If there is no such window, return the empty string `""`.

**Approach**:

-   Use a sliding window technique.
-   Maintain a count of characters in `t` and a count of characters in the current window.
-   Expand and contract the window to find the minimum window that contains all characters of `t`.

**Code Snippet**:

```csharp
public string MinWindow(string s, string t) {
    if (string.IsNullOrEmpty(s) || string.IsNullOrEmpty(t)) return "";

    Dictionary<char, int> tCount = new Dictionary<char, int>();
    foreach (char c in t) {
        if (!tCount.ContainsKey(c)) tCount[c] = 0;
        tCount[c]++;
    }

    int required = tCount.Count;
    int left = 0, right = 0, formed = 0;
    Dictionary<char, int> windowCounts = new Dictionary<char, int>();
    int[] ans = {-1, 0, 0}; // length, left, right

    while (right < s.Length) {
        char c = s[right];
        if (!windowCounts.ContainsKey(c)) windowCounts[c] = 0;
        windowCounts[c]++;

        if (tCount.ContainsKey(c) && windowCounts[c] == tCount[c]) {
            formed++;
        }

        while (left <= right && formed == required) {
            c = s[left];
            if (ans[0] == -1 || right - left + 1 < ans[0]) {
                ans[0] = right - left + 1;
                ans[1] = left;
                ans[2] = right;
            }

            windowCounts[c]--;
            if (tCount.ContainsKey(c) && windowCounts[c] < tCount[c]) {
                formed--;
            }
            left++;
        }
        right++;
    }

    return ans[0] == -1 ? "" : s.Substring(ans[1], ans[0]);
}

// Example
// Input: s = "ADOBECODEBANC", t = "ABC"
// Output: "BANC"
```

#### 3. Longest Substring with At Most K Distinct Characters

**Problem**: Given a string `s` and an integer `k`, return the length of the longest substring that contains at most `k` distinct characters.

**Approach**:

-   Use a sliding window technique with two pointers.
-   Use a hash map to keep track of the count of each character in the current window.
-   Adjust the window to ensure it contains at most `k` distinct characters.

**Code Snippet**:

```csharp
public int LengthOfLongestSubstringKDistinct(string s, int k) {
    if (string.IsNullOrEmpty(s) || k == 0) return 0;

    int maxLength = 0;
    int left = 0;
    Dictionary<char, int> charCount = new Dictionary<char, int>();

    for (int right = 0; right < s.Length; right++) {
        if (!charCount.ContainsKey(s[right])) {
            charCount[s[right]] = 0;
        }
        charCount[s[right]]++;

        while (charCount.Count > k) {
            charCount[s[left]]--;
            if (charCount[s[left]] == 0) {
                charCount.Remove(s[left]);
            }
            left++;
        }

        maxLength = Math.Max(maxLength, right - left + 1);
    }

    return maxLength;
}

// Example
// Input: s = "eceba", k = 2
// Output: 3 (The answer is "ece" with length 3)
```

#### 4. Sliding Window Maximum

**Problem**: Given an array `nums` and a sliding window size `k`, return the maximum values in the sliding window.

**Approach**:

-   Use a deque to store indices of array elements.
-   Ensure the deque contains indices of elements in the current window.
-   Maintain the deque in decreasing order of values.

**Code Snippet**:

```csharp
public int[] MaxSlidingWindow(int[] nums, int k) {
    if (nums == null || nums.Length == 0) return new int[0];

    int n = nums.Length;
    int[] result = new int[n - k + 1];
    int ri = 0;
    Deque<int> deque = new Deque<int>();

    for (int i = 0; i < nums.Length; i++) {
        // Remove indices that are out of the current window
        if (deque.Count > 0 && deque.First() == i - k) {
            deque.RemoveFirst();
        }

        // Remove elements that are smaller than the current element
        while (deque.Count > 0 && nums[deque.Last()] < nums[i]) {
            deque.RemoveLast();
        }

        deque.AddLast(i);

        // The first index in deque is the index of the maximum element in the current window
        if (i >= k - 1) {
            result[ri++] = nums[deque.First()];
        }
    }

    return result;
}

// Example
// Input: nums = [1,3,-1,-3,5,3,6,7], k = 3
// Output: [3,3,5,5,6,7]
```

#### 5. Longest Substring Without Repeating Characters

**Problem**: Given a string `s`, find the length of the longest substring without repeating characters.

**Approach**:

-   Use a sliding window technique with two pointers.
-   Use a hash set to keep track of characters in the current window.
-   Adjust the window to ensure it contains unique characters.

**Code Snippet**:

```csharp
public int LengthOfLongestSubstring(string s) {
    if (string.IsNullOrEmpty(s)) return 0;

    int maxLength = 0;
    int left = 0;
    HashSet<char> charSet = new HashSet<char>();

    for (int right = 0; right < s.Length; right++) {
        while (charSet.Contains(s[right])) {
            charSet.Remove(s[left]);
            left++;
        }
        charSet.Add(s[right]);
        maxLength = Math.Max(maxLength, right - left + 1);
    }

    return maxLength;
}

// Example
// Input: s = "abcabcbb"
// Output: 3 (The answer is "abc" with length 3)
```

#### 6. Longest Consecutive Sequence

**Problem**: Given an unsorted array of integers `nums`, find the length of the longest consecutive elements sequence.

**Approach**:

-   Use a hash set to store the elements.
-   Iterate through the array and check for the start of a sequence.
-   Count the length of the sequence starting from each element.

**Code Snippet**:

```csharp
public int LongestConsecutive(int[] nums) {
    if (nums == null || nums.Length == 0) return 0;

    HashSet<int> numSet = new HashSet<int>(nums);
    int longestStreak = 0;

    foreach (int num in numSet) {
        if (!numSet.Contains(num - 1)) {
            int currentNum = num;
            int currentStreak = 1;

                        while (numSet.Contains(currentNum + 1)) {
                currentNum++;
                currentStreak++;
            }

            longestStreak = Math.Max(longestStreak, currentStreak);
        }
    }

    return longestStreak;
}

// Example
// Input: nums = [100, 4, 200, 1, 3, 2]
// Output: 4 (The longest consecutive elements sequence is [1, 2, 3, 4]. Therefore its length is 4.)
```
