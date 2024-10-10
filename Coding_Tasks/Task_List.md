# Smaple coding tasks

----
## 1. Given an array of binary digits, 0 and 1, sort the array so that all zeros are at one end and all ones are at the other. Which end does not matter. Determine the minimum number of swaps to sort the array.
Example:
> input arr=[0,1,0,1,0]
  With 1 move, switching elements 1 and 4, yields [0,0,0,1,1], a sorted array.

Prompt
> write C# code for given problem. include alternate approach and solution should have time complexity analysis and explaination.

## similiar problems
Here’s a categorized list of partitioning-based problems, along with descriptions, hints, and their time/space complexity.

### **Easy**

---

#### 1. **Move Zeroes**
   - **Problem Description**: Given an array, move all 0's to the end while maintaining the relative order of non-zero elements.
   - **Hint**: Use two pointers to swap zero elements with the next non-zero element.
   - **Time Complexity**: O(n)
   - **Space Complexity**: O(1)

---

#### 2. **Partition Array into Even and Odd Numbers**
   - **Problem Description**: Rearrange the array so that even numbers appear before odd numbers.
   - **Hint**: Use two pointers, one starting at the beginning and one at the end. Swap the odd and even elements.
   - **Time Complexity**: O(n)
   - **Space Complexity**: O(1)

---

#### 3. **Remove Element**
   - **Problem Description**: Given an array and a value, remove all instances of that value in-place and return the new length.
   - **Hint**: Use a pointer to track the position of valid elements as you iterate through the array.
   - **Time Complexity**: O(n)
   - **Space Complexity**: O(1)

---

### **Medium**

---

#### 1. **Dutch National Flag Problem**
   - **Problem Description**: Sort an array of 0s, 1s, and 2s in one pass without using extra space.
   - **Hint**: Use the two-pointer approach to keep track of boundaries for 0, 1, and 2. Swap elements to their correct partition.
   - **Time Complexity**: O(n)
   - **Space Complexity**: O(1)

---

#### 2. **Kth Largest Element in an Array**
   - **Problem Description**: Find the k-th largest element in an unsorted array.
   - **Hint**: Use the partition method from quicksort to find the k-th largest element.
   - **Time Complexity**: O(n) on average, O(n²) worst case
   - **Space Complexity**: O(1) with in-place partitioning

---

#### 3. **3-Way Partitioning**
   - **Problem Description**: Given an array and two values, partition the array such that elements smaller than the first value come first, then elements between the two values, and then elements greater than the second value.
   - **Hint**: Use two pointers to separate the elements into three parts.
   - **Time Complexity**: O(n)
   - **Space Complexity**: O(1)

---

#### 4. **Partition Labels**
   - **Problem Description**: Given a string, partition it into as many parts as possible so that no letter appears in more than one part.
   - **Hint**: Track the last occurrence of each character and partition the string based on the farthest last occurrence of any character in the current partition.
   - **Time Complexity**: O(n)
   - **Space Complexity**: O(1)

---

### **Hard**

---

#### 1. **Largest Rectangle in Histogram**
   - **Problem Description**: Given the heights of bars in a histogram, find the area of the largest rectangle that can be formed.
   - **Hint**: Use a stack-based approach to partition the heights and find the maximum possible rectangle.
   - **Time Complexity**: O(n)
   - **Space Complexity**: O(n)

---

#### 2. **Quickselect (Kth Smallest Element)**
   - **Problem Description**: Find the k-th smallest element in an unsorted array.
   - **Hint**: Use the partitioning technique from quicksort. Randomize the pivot for better performance.
   - **Time Complexity**: O(n) on average, O(n²) worst case
   - **Space Complexity**: O(1) in-place

---

#### 3. **Maximize Array Sum After K Negations**
   - **Problem Description**: Given an array of integers, you can flip the sign of any K elements. Maximize the sum of the array after performing exactly K negations.
   - **Hint**: Partition the array into negative and positive values. Try to minimize the impact of negations by using a greedy strategy.
   - **Time Complexity**: O(n log n)
   - **Space Complexity**: O(1)

---

#### 4. **Minimum Number of Arrows to Burst Balloons**
   - **Problem Description**: Given a number of balloons represented as intervals, determine the minimum number of arrows needed to burst all balloons.
   - **Hint**: Sort the intervals and partition them based on overlapping intervals.
   - **Time Complexity**: O(n log n)
   - **Space Complexity**: O(1)

---

#### 5. **Maximum Gap**
   - **Problem Description**: Given an unsorted array, find the maximum difference between the successive elements in its sorted form, but you cannot fully sort the array.
   - **Hint**: Use bucket sort to partition elements into different ranges, then find the largest gap between buckets.
   - **Time Complexity**: O(n)
   - **Space Complexity**: O(n)

---

### **Very Hard**

---

#### 1. **Trapping Rain Water**
   - **Problem Description**: Given an array of non-negative integers representing the height of bars, determine how much water can be trapped after raining.
   - **Hint**: Use two-pointer technique to find the maximum heights from both directions and compute the water trapped at each position.
   - **Time Complexity**: O(n)
   - **Space Complexity**: O(1)

---

#### 2. **Median of Two Sorted Arrays**
   - **Problem Description**: Given two sorted arrays, find the median of the two sorted arrays.
   - **Hint**: Use binary search and partitioning techniques to find the median without merging the arrays.
   - **Time Complexity**: O(log(min(m, n)))
   - **Space Complexity**: O(1)

---

These problems can help you practice partitioning techniques while handling different complexity levels and constraints.