### Easy Category

#### 1. Find the Middle of a Linked List

**Problem Description:**
Given a non-empty, singly linked list with head node `head`, return a middle node of the linked list. If there are two middle nodes, return the second middle node.

**Edge Cases:**

-   Single node list
-   Even number of nodes

**Code Snippet:**

```csharp
public class ListNode {
    public int val;
    public ListNode next;
    public ListNode(int x) { val = x; }
}

public class Solution {
    public ListNode MiddleNode(ListNode head) {
        ListNode slow = head;
        ListNode fast = head;

        while (fast != null && fast.next != null) {
            slow = slow.next;
            fast = fast.next.next;
        }

        return slow;
    }
}

// Example:
// Input: head = [1,2,3,4,5]
// Output: Node with value 3

// Input: head = [1,2,3,4,5,6]
// Output: Node with value 4
```

#### 2. Linked List Cycle Detection

**Problem Description:**
Given a linked list, determine if it has a cycle in it.

**Edge Cases:**

-   Empty list
-   Single node pointing to itself

**Code Snippet:**

```csharp
public class ListNode {
    public int val;
    public ListNode next;
    public ListNode(int x) { val = x; }
}

public class Solution {
    public bool HasCycle(ListNode head) {
        if (head == null || head.next == null) return false;

        ListNode slow = head;
        ListNode fast = head;

        while (fast != null && fast.next != null) {
            slow = slow.next;
            fast = fast.next.next;

            if (slow == fast) return true;
        }

        return false;
    }
}

// Example:
// Input: head = [3,2,0,-4] with cycle at position 1
// Output: true

// Input: head = [1,2] with no cycle
// Output: false
```

#### 3. Happy Number

**Problem Description:**
Write an algorithm to determine if a number `n` is happy. A happy number is a number defined by the following process: Starting with any positive integer, replace the number by the sum of the squares of its digits, and repeat the process until the number equals 1 (where it will stay), or it loops endlessly in a cycle which does not include 1. Those numbers for which this process ends in 1 are happy numbers.

**Edge Cases:**

-   Small numbers like 1, 7, 10

**Code Snippet:**

```csharp
public class Solution {
    private int GetNext(int n) {
        int totalSum = 0;
        while (n > 0) {
            int d = n % 10;
            n = n / 10;
            totalSum += d * d;
        }
        return totalSum;
    }

    public bool IsHappy(int n) {
        int slow = n;
        int fast = GetNext(n);

        while (fast != 1 && slow != fast) {
            slow = GetNext(slow);
            fast = GetNext(GetNext(fast));
        }

        return fast == 1;
    }
}

// Example:
// Input: n = 19
// Output: true (19 -> 82 -> 68 -> 100 -> 1)

// Input: n = 2
// Output: false
```

#### 4. Palindrome Linked List

**Problem Description:**
Given a singly linked list, determine if it is a palindrome.

**Edge Cases:**

-   Empty list
-   Single node list

**Code Snippet:**

```csharp
public class ListNode {
    public int val;
    public ListNode next;
    public ListNode(int x) { val = x; }
}

public class Solution {
    public bool IsPalindrome(ListNode head) {
        if (head == null || head.next == null) return true;

        // Find the middle of the list
        ListNode slow = head, fast = head;
        while (fast != null && fast.next != null) {
            slow = slow.next;
            fast = fast.next.next;
        }

        // Reverse the second half
        ListNode prev = null, current = slow;
        while (current != null) {
            ListNode nextNode = current.next;
            current.next = prev;
            prev = current;
            current = nextNode;
        }

        // Compare the first and second half
        ListNode firstHalf = head, secondHalf = prev;
        while (secondHalf != null) {
            if (firstHalf.val != secondHalf.val) {
                return false;
            }
            firstHalf = firstHalf.next;
            secondHalf = secondHalf.next;
        }

        return true;
    }
}

// Example:
// Input: head = [1,2,2,1]
// Output: true

// Input: head = [1,2]
// Output: false
```

#### 5. Remove N-th Node From End of List

**Problem Description:**
Given the head of a linked list, remove the n-th node from the end of the list and return its head.

**Edge Cases:**

-   Removing the only node
-   Removing the head node

**Code Snippet:**

```csharp
public class ListNode {
    public int val;
    public ListNode next;
    public ListNode(int x) { val = x; }
}

public class Solution {
    public ListNode RemoveNthFromEnd(ListNode head, int n) {
        ListNode dummy = new ListNode(0);
        dummy.next = head;
        ListNode fast = dummy;
        ListNode slow = dummy;

        // Move fast ahead by n+1 steps
        for (int i = 0; i <= n; i++) {
            fast = fast.next;
        }

        // Move both pointers until fast reaches the end
        while (fast != null) {
            slow = slow.next;
            fast = fast.next;
        }

        // Remove the nth node
        slow.next = slow.next.next;

        return dummy.next;
    }
}

// Example:
// Input: head = [1,2,3,4,5], n = 2
// Output: [1,2,3,5]

// Input: head = [1], n = 1
// Output: []
```

### Medium Category

#### 1. Cycle Length in Linked List

**Problem Description:**
Given a linked list, return the length of the cycle if there is a cycle in the list. If there is no cycle, return 0.

**Edge Cases:**

-   No cycle
-   Small cycle length

**Code Snippet:**

```csharp
public class ListNode {
    public int val;
    public ListNode next;
    public ListNode(int x) { val = x; }
}

public class Solution {
    public int CycleLength(ListNode head) {
        ListNode slow = head;
        ListNode fast = head;

        while (fast != null && fast.next != null) {
            slow = slow.next;
            fast = fast.next.next;

            if (slow == fast) {
                return CalculateCycleLength(slow);
            }
        }

        return 0;
    }

    private int CalculateCycleLength(ListNode slow) {
        ListNode current = slow;
        int cycleLength = 0;
        do {
            current = current.next;
            cycleLength++;
        } while (current != slow);

        return cycleLength;
    }
}

// Example:
// Input: head = [3,2,0,-4] with cycle at position 1
// Output: 4

// Input: head = [1,2] with no cycle
// Output: 0
```

#### 2. Cycle Start Node in Linked List

**Problem Description:**
Given a linked list, return the node where the cycle begins. If there is no cycle, return null.

**Edge Cases:**

-   No cycle
-   Small cycle length

**Code Snippet:**

```csharp
public class ListNode {
    public int val;
    public ListNode next;
    public ListNode(int x) { val = x; }
}

public class Solution {
    public ListNode DetectCycle(ListNode head) {
        ListNode slow = head;
        ListNode fast = head;

        while (fast != null && fast.next != null) {
            slow = slow.next;
            fast = fast.next.next;

            if (slow == fast) {
                ListNode pointer = head;
                while (pointer != slow) {
                    pointer = pointer.next;
                    slow = slow.next;
                }
                return pointer;
            }
        }

        return null;
    }
}

// Example:
// Input: head = [3,2,0,-4] with cycle at position 1
// Output: Node with value 2

// Input: head = [1,2] with no cycle
// Output: null
```

#### 3. Reorder List

**Problem Description:**
Given a singly linked list L: L0→L1→…→Ln-1→Ln, reorder it to: L0→Ln→L1→Ln-1→L2→Ln-2→… without modifying the nodes' values, only rearranging the nodes.

**Edge Cases:**

-   Empty list
-   Single node list
-   Two node list

**Code Snippet:**

```csharp
public class ListNode {
    public int val;
    public ListNode next;
    public ListNode(int x) { val = x; }
}

public class Solution {
    public void ReorderList(ListNode head) {
        if (head == null || head.next == null) return;

        // Step 1: Find the middle of the list
        ListNode slow = head, fast = head;
        while (fast != null && fast.next != null) {
            slow = slow.next;
            fast = fast.next.next;
        }

        // Step 2: Reverse the second half of the list
        ListNode prev = null, curr = slow, next = null;
        while (curr != null) {
            next = curr.next;
            curr.next = prev;
            prev = curr;
            curr = next;
        }

        // Step 3: Merge the two halves
        ListNode first = head, second = prev;
        while (second.next != null) {
            ListNode temp1 = first.next;
            ListNode temp2 = second.next;

            first.next = second;
            second.next = temp1;

            first = temp1;
            second = temp2;
        }
    }
}

// Example:
// Input: head = [1,2,3,4]
// Output: [1,4,2,3]

// Input: head = [1,2,3,4,5]
// Output: [1,5,2,4,3]
```

#### 4. Linked List Cycle II

**Problem Description:**
Given a linked list, return the node where the cycle begins. If there is no cycle, return `null`.

**Code Snippet:**

```csharp
public class ListNode {
    public int val;
    public ListNode next;
    public ListNode(int x) {
        val = x;
        next = null;
    }
}

public class Solution {
    public ListNode DetectCycle(ListNode head) {
        if (head == null || head.next == null) return null;

        ListNode slow = head;
        ListNode fast = head;

        // Detect cycle using Floyd's Tortoise and Hare algorithm
        while (fast != null && fast.next != null) {
            slow = slow.next;
            fast = fast.next.next;
            if (slow == fast) break;
        }

        // No cycle detected
        if (fast == null || fast.next == null) return null;

        // Find the start of the cycle
        slow = head;
        while (slow != fast) {
            slow = slow.next;
            fast = fast.next;
        }

        return slow;
    }
}

// Example:
// Input: head = [3,2,0,-4], pos = 1
// Output: The node with value 2 (cycle starts at node with value 2)

// Input: head = [1,2], pos = 0
// Output: The node with value 1 (cycle starts at node with value 1)

// Input: head = [1], pos = -1
// Output: null (no cycle)
```

#### 5. Intersection of Two Linked Lists

**Problem Description:**
Write a program to find the node at which the intersection of two singly linked lists begins.

**Code Snippet:**

```csharp
public class ListNode {
    public int val;
    public ListNode next;
    public ListNode(int x) {
        val = x;
        next = null;
    }
}

public class Solution {
    public ListNode GetIntersectionNode(ListNode headA, ListNode headB) {
        if (headA == null || headB == null) return null;

        ListNode a = headA;
        ListNode b = headB;

        // Traverse both lists. If one reaches the end, start at the beginning of the other list.
        while (a != b) {
            a = (a == null) ? headB : a.next;
            b = (b == null) ? headA : b.next;
        }

        return a;
    }
}

// Example:
// Input: headA = [4,1,8,4,5], headB = [5,0,1,8,4,5]
// Output: The node with value 8 (intersection starts at node with value 8)

// Input: headA = [0,9,1,2,4], headB = [3,2,4]
// Output: The node with value 2 (intersection starts at node with value 2)

// Input: headA = [2,6,4], headB = [1,5]
// Output: null (no intersection)
```

### Hard Category

#### 1. Find Duplicate Number

**Problem Description:**
Given an array of integers `nums` containing `n + 1` integers where each integer is in the range `[1, n]` inclusive, there is only one repeated number in `nums`, return this repeated number.

**Code Snippet:**

```csharp
public class Solution {
    public int FindDuplicate(int[] nums) {
        int slow = nums[0];
        int fast = nums[0];

        // Phase 1: Finding the intersection point of the two runners.
        do {
            slow = nums[slow];
            fast = nums[nums[fast]];
        } while (slow != fast);

        // Phase 2: Find the entrance to the cycle.
        slow = nums[0];
        while (slow != fast) {
            slow = nums[slow];
            fast = nums[fast];
        }

        return slow;
    }
}

// Example:
// Input: nums = [1,3,4,2,2]
// Output: 2

// Input: nums = [3,1,3,4,2]
// Output: 3
```

#### 2. Linked List Cycle Detection with Constant Space

**Problem Description:**
Detect if a linked list has a cycle in it using constant space.

**Code Snippet:**

```csharp
public class ListNode {
    public int val;
    public ListNode next;
    public ListNode(int x) {
        val = x;
        next = null;
    }
}

public class Solution {
    public bool HasCycle(ListNode head) {
        if (head == null || head.next == null) return false;

        ListNode slow = head;
        ListNode fast = head;

        // Floyd's Tortoise and Hare algorithm to detect cycle
        while (fast != null && fast.next != null) {
            slow = slow.next;
            fast = fast.next.next;
            if (slow == fast) return true;
        }

        return false;
    }
}

// Example:
// Input: head = [3,2,0,-4], pos = 1
// Output: true (cycle exists)

// Input: head = [1,2], pos = 0
// Output: true (cycle exists)

// Input: head = [1], pos = -1
// Output: false (no cycle)
```

#### 3. Find the Duplicate Number II

This problem is essentially the same as the "Find Duplicate Number" problem. The code implementation is the same as provided earlier.

#### 4. Longest Substring Without Repeating Characters

**Problem Description:**
Given a string `s`, find the length of the longest substring without repeating characters.

**Code Snippet:**
```csharp
public class Solution {
    public int LengthOfLongestSubstring(string s) {
        int n = s.Length;
        int maxLen = 0;
        Dictionary<char, int> charIndexMap = new Dictionary<char, int>();
        int start = 0;

        for (int end = 0; end < n; end++) {
            if (charIndexMap.ContainsKey(s[end])) {
                start = Math.Max(charIndexMap[s[end]] + 1, start);
            }
            charIndexMap[s[end]] = end;
            maxLen = Math.Max(maxLen, end - start + 1);
        }

        return maxLen;
    }
}

// Example:
// Input: s = "abcabcbb"
// Output: 3 (The answer is "abc", with the length of 3.)

// Input: s = "bbbbb"
// Output: 1 (The answer is "b", with the length of 1.)

// Input: s = "pwwkew"
// Output: 3 (The answer is "wke", with the length of 3.)
```

#### 5. Circular Array Loop

**Problem Description:**
Given a circular array `nums` of positive and negative integers, determine if there is a cycle in the array. A cycle must start and end at the same index and the cycle's length must be greater than 1. Furthermore, movements in the cycle must all follow a single direction, either all forward or all backward.

**Code Snippet:**
```csharp
public class Solution {
    public bool CircularArrayLoop(int[] nums) {
        int n = nums.Length;

        for (int i = 0; i < n; i++) {
            if (nums[i] == 0) continue;

            int slow = i, fast = i;
            bool isForward = nums[i] > 0;

            while (true) {
                slow = GetNextIndex(nums, slow, isForward);
                fast = GetNextIndex(nums, fast, isForward);
                if (fast != -1) {
                    fast = GetNextIndex(nums, fast, isForward);
                }

                if (slow == -1 || fast == -1 || slow == fast) break;
            }

            if (slow != -1 && slow == fast) return true;

            slow = i;
            int val = nums[i];
            while (GetNextIndex(nums, slow, isForward) != -1) {
                int next = GetNextIndex(nums, slow, isForward);
                nums[slow] = 0;
                slow = next;
            }
        }

        return false;
    }

    private int GetNextIndex(int[] nums, int currentIndex, bool isForward) {
        bool direction = nums[currentIndex] > 0;
        if (direction != isForward) return -1;

        int nextIndex = (currentIndex + nums[currentIndex]) % nums.Length;
        if (nextIndex < 0) nextIndex += nums.Length;

        if (nextIndex == currentIndex) return -1;

        return nextIndex;
    }
}

// Example:
// Input: nums = [2, -1, 1, 2, 2]
// Output: true (There is a cycle 2 -> 3 -> 0 -> 2 in the array.)

// Input: nums = [-1, 2]
// Output: false (There is no cycle in the array.)

// Input: nums = [-2, 1, -1, -2, -2]
// Output: false (There is no cycle in the array.)
```

