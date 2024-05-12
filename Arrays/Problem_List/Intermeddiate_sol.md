## Intermediate Level

1. **Find the pair of elements in an array that sum to a given value**
   Write a C# program to find the pair of elements in an array that sum to a given value.

2. **Find the majority element in an array**
   Write a C# program to find the majority element in an array (an element that appears more than n/2 times).

3. **Find the longest consecutive subsequence in an array**
   Write a C# program to find the longest consecutive subsequence in an array.

4. **Find the "peak" element in an array**
   Write a C# program to find a peak element in an array. An element is a peak if it is greater than its neighbors.

5. **Rotate an array by N elements**
   Write a C# program to rotate an array by N elements.

6. **Find the median of two sorted arrays**
   Write a C# program to find the median of two sorted arrays.

## Sol
### Sure, here are three different approaches for each problem in the intermediate category.

1. **Find the pair of elements in an array that sum to a given value**

*Approach 1: Using two for loops (Brute force)*
```csharp
public void FindPair(int[] arr, int sum)
{
    for(int i = 0; i < arr.Length-1; i++)
    {
        for(int j = i+1; j < arr.Length; j++)
        {
            if(arr[i] + arr[j] == sum)
                Console.WriteLine("Pair: " + arr[i] + ", " + arr[j]);
        }
    }
}
```
Input: [1, 2, 3, 4, 5], sum = 5
Output: Pair: 1, 4 and Pair: 2, 3

*Approach 2: Using Sorting and Two-Pointers*
```csharp
public void FindPair(int[] arr, int sum)
{
    Array.Sort(arr);
    int low = 0;
    int high = arr.Length - 1;
    while(low < high)
    {
        if(arr[low] + arr[high] == sum)
        {
            Console.WriteLine("Pair: " + arr[low] + ", " + arr[high]);
            low++;
            high--;
        }
        else if(arr[low] + arr[high] < sum)
            low++;
        else
            high--;
    }
}
```
Input: [1, 2, 3, 4, 5], sum = 5
Output: Pair: 1, 4 and Pair: 2, 3

*Approach 3: Using HashSet*
```csharp
public void FindPair(int[] arr, int sum)
{
    HashSet<int> set = new HashSet<int>();
    for(int i = 0; i < arr.Length; i++)
    {
        int temp = sum - arr[i];
        if(set.Contains(temp))
            Console.WriteLine("Pair: " + temp + ", " + arr[i]);
        set.Add(arr[i]);
    }
}
```
Input: [1, 2, 3, 4, 5], sum = 5
Output: Pair: 1, 4 and Pair: 2, 3

Optimal Approach: The optimal approach would be Approach 3 using HashSet. It has a time complexity of O(n) and does not require the array to be sorted.

2. **Find the majority element in an array**

*Approach 1: Using Dictionary*
```csharp
public void FindMajority(int[] arr)
{
    Dictionary<int, int> dict = new Dictionary<int, int>();
    for(int i=0; i<arr.Length; i++)
    {
        if(dict.ContainsKey(arr[i]))
            dict[arr[i]]++;
        else
            dict.Add(arr[i], 1);
    }
    foreach(var pair in dict)
    {
        if(pair.Value > arr.Length/2)
        {
            Console.WriteLine("Majority: " + pair.Key);
            return;
        }
    }
    Console.WriteLine("No Majority Element");
}
```
Input: [2, 2, 1, 1, 1, 2, 2]
Output: Majority: 2

*Approach 2: Using Sorting*
```csharp
public void FindMajority(int[] arr)
{
    Array.Sort(arr);
    int count = 1;
    int maxCount = 1;
    int majority = arr[0];
    for(int i = 1; i < arr.Length; i++)
    {
        if(arr[i] == arr[i-1])
            count++;
        else
            count = 1;
        if(count > maxCount)
        {
            maxCount = count;
            majority = arr[i];
        }
    }
    if(maxCount > arr.Length/2)
        Console.WriteLine("Majority: " + majority);
    else
        Console.WriteLine("No Majority Element");
}
```
Input: [2, 2, 1, 1, 1, 2, 2]
Output: Majority: 2

*Approach 3: Using Moore’s Voting Algorithm*
```csharp
public void FindMajority(int[] arr)
{
    int majorityIndex = 0;
    int count = 1;
    for(int i = 1; i < arr.Length; i++)
    {
        if(arr[majorityIndex] == arr[i])
            count++;
        else
            count--;
        if(count == 0)
        {
            majorityIndex = i;
            count = 1;
        }
    }
    count = 0;
    for(int i = 0; i < arr.Length; i++)
    {
        if(arr[i] == arr[majorityIndex])
            count++;
    }
    if(count > arr.Length/2)
        Console.WriteLine("Majority: " + arr[majorityIndex]);
    else
        Console.WriteLine("No Majority Element");
}
```
Input: [2, 2, 1, 1, 1, 2, 2]
Output: Majority: 2

Optimal Approach: The optimal approach would be Approach 3 using Moore’s Voting Algorithm. It has a time complexity of O(n) and does not require extra space.

3. **Find the longest consecutive subsequence in an array**

*Approach 1: Using Sorting*
```csharp
public void FindLongestConsecutive(int[] arr)
{
    Array.Sort(arr);
    int count = 1;
    int maxCount = 1;
    for(int i = 1; i < arr.Length; i++)
    {
        if(arr[i] == arr[i-1] + 1)
            count++;
        else if(arr[i] != arr[i-1])
            count = 1;
        maxCount = Math.Max(maxCount, count);
    }
    Console.WriteLine("Longest Consecutive Subsequence: " + maxCount);
}
```
Input: [1, 9, 3, 10, 4, 20, 2]
Output: Longest Consecutive Subsequence: 4

*Approach 2: Using HashSet*
```csharp
public void FindLongestConsecutive(int[] arr)
{
    HashSet<int> set = new HashSet<int>(arr);
    int maxCount = 0;
    foreach(int num in set)
    {
        if(!set.Contains(num-1))
        {
            int count = 1;
            while(set.Contains(num+1))
            {
                num++;
                count++;
            }
            maxCount = Math.Max(maxCount, count);
        }
    }
    Console.WriteLine("Longest Consecutive Subsequence: " + maxCount);
}
```
Input: [1, 9, 3, 10, 4, 20, 2]
Output: Longest Consecutive Subsequence: 4

*Approach 3: Using Dictionary*
```csharp
public void FindLongestConsecutive(int[] arr)
{
    Dictionary<int, int> dict = new Dictionary<int, int>();
    int maxCount = 0;
    for(int i = 0; i < arr.Length; i++)
    {
        if(!dict.ContainsKey(arr[i]))
        {
            int left = dict.ContainsKey(arr[i]-1) ? dict[arr[i]-1] : 0;
            int right = dict.ContainsKey(arr[i]+1) ? dict[arr[i]+1] : 0;
            int count = left + right + 1;
            dict[arr[i]] = count;
            maxCount = Math.Max(maxCount, count);
            dict[arr[i]-left] = count;
            dict[arr[i]+right] = count;
        }
    }
    Console.WriteLine("Longest Consecutive Subsequence: " + maxCount);
}
```
Input: [1, 9, 3, 10, 4, 20, 2]
Output: Longest Consecutive Subsequence: 4

Optimal Approach: The optimal approach would be Approach 2 using HashSet. It has a time complexity of O(n) and does not require the array to be sorted.

Sure, here are the solutions for the remaining questions in the intermediate category.

4. **Find the "peak" element in an array**

*Approach 1: Linear Scan*
```csharp
public void FindPeak(int[] arr)
{
    if(arr[0] > arr[1])
        Console.WriteLine("Peak: " + arr[0]);
    for(int i = 1; i < arr.Length - 1; i++)
    {
        if(arr[i] > arr[i-1] && arr[i] > arr[i+1])
            Console.WriteLine("Peak: " + arr[i]);
    }
    if(arr[arr.Length - 1] > arr[arr.Length - 2])
        Console.WriteLine("Peak: " + arr[arr.Length - 1]);
}
```
Input: [1, 3, 7, 1, 2, 6, 0, 4, 2]
Output: Peak: 7, Peak: 6, Peak: 4

*Approach 2: Binary Search*
```csharp
public void FindPeak(int[] arr)
{
    int start = 0;
    int end = arr.Length - 1;
    while(start < end)
    {
        int mid = start + (end - start) / 2;
        if(arr[mid] < arr[mid + 1])
            start = mid + 1;
        else
            end = mid;
    }
    Console.WriteLine("Peak: " + arr[start]);
}
```
Input: [1, 3, 7, 1, 2, 6, 0, 4, 2]
Output: Peak: 7

*Approach 3: Using Stack*
```csharp
public void FindPeak(int[] arr)
{
    Stack<int> stack = new Stack<int>();
    for(int i = 0; i < arr.Length; i++)
    {
        while(stack.Count > 0 && arr[stack.Peek()] < arr[i])
            Console.WriteLine("Peak: " + arr[stack.Pop()]);
        stack.Push(i);
    }
    while(stack.Count > 0)
        Console.WriteLine("Peak: " + arr[stack.Pop()]);
}
```
Input: [1, 3, 7, 1, 2, 6, 0, 4, 2]
Output: Peak: 7, Peak: 6, Peak: 4

Optimal Approach: The optimal approach would be Approach 2 using Binary Search. It has a time complexity of O(log n).

5. **Rotate an array by N elements**

*Approach 1: Using Extra Array*
```csharp
public void RotateArray(int[] arr, int n)
{
    int[] temp = new int[arr.Length];
    for(int i = 0; i < arr.Length; i++)
        temp[(i + n) % arr.Length] = arr[i];
    foreach(int i in temp)
        Console.Write(i + " ");
}
```
Input: [1, 2, 3, 4, 5], n = 2
Output: 4 5 1 2 3 

*Approach 2: Reverse Parts of the Array*
```csharp
public void RotateArray(int[] arr, int n)
{
    n = n % arr.Length;
    ReverseArray(arr, 0, arr.Length - 1);
    ReverseArray(arr, 0, n - 1);
    ReverseArray(arr, n, arr.Length - 1);
    foreach(int i in arr)
        Console.Write(i + " ");
}

public void ReverseArray(int[] arr, int start, int end)
{
    while(start < end)
    {
        int temp = arr[start];
        arr[start] = arr[end];
        arr[end] = temp;
        start++;
        end--;
    }
}
```
Input: [1, 2, 3, 4, 5], n = 2
Output: 4 5 1 2 3 

*Approach 3: Using Array.Copy()*
```csharp
public void RotateArray(int[] arr, int n)
{
    int[] temp = new int[n];
    Array.Copy(arr, arr.Length - n, temp, 0, n);
    Array.Copy(arr, 0, arr, n, arr.Length - n);
    Array.Copy(temp, 0, arr, 0, n);
    foreach(int i in arr)
        Console.Write(i + " ");
}
```
Input: [1, 2, 3, 4, 5], n = 2
Output: 4 5 1 2 3 

Optimal Approach: The optimal approach would be Approach 2 using Reverse Parts of the Array. It has a time complexity of O(n) and does not require extra space.

6. **Find the median of two sorted arrays**

*Approach 1: Merge and Sort*
```csharp
public void FindMedian(int[] arr1, int[] arr2)
{
    int[] merged = new int[arr1.Length + arr2.Length];
    Array.Copy(arr1, merged, arr1.Length);
    Array.Copy(arr2, 0, merged, arr1.Length, arr2.Length);
    Array.Sort(merged);
    double median;
    if(merged.Length % 2 == 0)
        median = (merged[merged.Length/2 - 1] + merged[merged.Length/2]) / 2.0;
    else
        median = merged[merged.Length/2];
    Console.WriteLine("Median: " + median);
}
```
Input: [1, 3, 5], [2, 4, 6]
Output: Median: 3.5

*Approach 2: Using Two Pointers*
```csharp
public void FindMedian(int[] arr1, int[] arr2)
{
    int i = 0, j = 0, count;
    int m1 = -1, m2 = -1;
    int m = arr1.Length, n = arr2.Length;
    if((m + n) % 2 == 1)
    {
        for(count = 0; count <= (m + n)/2; count++)
        {
            if(i != m && j != n)
                m1 = (arr1[i] > arr2[j]) ? arr2[j++] : arr1[i++];
            else if(i < m)
                m1 = arr1[i++];
            else
                m1 = arr2[j++];
        }
        Console.WriteLine("Median: " + m1);
    }
    else
    {
        for(count = 0; count <= (m + n)/2; count++)
        {
            m2 = m1;
            if(i != m && j != n)
                m1 = (arr1[i] > arr2[j]) ? arr2[j++] : arr1[i++];
            else if(i < m)
                m1 = arr1[i++];
            else
                m1 = arr2[j++];
        }
        Console.WriteLine("Median: " + (m1 + m2)/2.0);
    }
}
```
Input: [1, 3, 5], [2, 4, 6]
Output: Median: 3.5

*Approach 3: Using Binary Search*
```csharp
public void FindMedian(int[] arr1, int[] arr2)
{
    if(arr1.Length > arr2.Length)
    {
        int[] temp = arr1; arr1 = arr2; arr2 = temp;
    }
    int x = arr1.Length;
    int y = arr2.Length;
    int start = 0;
    int end = x;
    while(start <= end)
    {
        int partitionX = (start + end)/2;
        int partitionY = (x + y + 1)/2 - partitionX;
        int maxLeftX = (partitionX == 0) ? int.MinValue : arr1[partitionX - 1];
        int minRightX = (partitionX == x) ? int.MaxValue : arr1[partitionX];
        int maxLeftY = (partitionY == 0) ? int.MinValue : arr2[partitionY - 1];
        int minRightY = (partitionY == y) ? int.MaxValue : arr2[partitionY];
        if(maxLeftX <= minRightY && maxLeftY <= minRightX)
        {
            if((x + y) % 2 == 0)
                Console.WriteLine("Median: " + ((double)Math.Max(maxLeftX, maxLeftY) + Math.Min(minRightX, minRightY))/2);
            else
                Console.WriteLine("Median: " + (double)Math.Max(maxLeftX, maxLeftY));
            break;
        }
        else if(maxLeftX > minRightY)
            end = partitionX - 1;
        else
            start = partitionX + 1;
    }
}
```
Input: [1, 3, 5], [2, 4, 6]
Output: Median: 3.5

Optimal Approach: The optimal approach would be Approach 3 using Binary Search. It has a time complexity of O(log(min(n, m))).