## Easy Level Problems

1. **Find the maximum and minimum element in an array**

```csharp
public void FindMaxMin(int[] arr)
{
    int min = arr[0];
    int max = arr[0];

    for (int i = 1; i < arr.Length; i++)
    {
        if (arr[i] > max)
            max = arr[i];
        else if (arr[i] < min)
            min = arr[i];
    }

    Console.WriteLine("Max: " + max);
    Console.WriteLine("Min: " + min);
}
```
Time Complexity: O(n)  
Space Complexity: O(1)

2. **Reverse an array**

```csharp
public void ReverseArray(int[] arr)
{
    int start = 0;
    int end = arr.Length - 1;

    while (start < end)
    {
        int temp = arr[start];
        arr[start] = arr[end];
        arr[end] = temp;

        start++;
        end--;
    }

    foreach (int i in arr)
        Console.Write(i + " ");
}
```
Time Complexity: O(n)  
Space Complexity: O(1)

3. **Check if an array is sorted**

```csharp
public bool IsArraySorted(int[] arr)
{
    for (int i = 1; i < arr.Length; i++)
    {
        if (arr[i] < arr[i - 1])
            return false;
    }

    return true;
}
```
Time Complexity: O(n)  
Space Complexity: O(1)

4. **Find the sum of an array**

```csharp
public int SumArray(int[] arr)
{
    int sum = 0;

    for (int i = 0; i < arr.Length; i++)
        sum += arr[i];

    return sum;
}
```
Time Complexity: O(n)  
Space Complexity: O(1)

5. **Find duplicate elements in an array**

```csharp
public void FindDuplicates(int[] arr)
{
    Dictionary<int, int> dict = new Dictionary<int, int>();

    for (int i = 0; i < arr.Length; i++)
    {
        if (dict.ContainsKey(arr[i]))
            Console.WriteLine("Duplicate: " + arr[i]);
        else
            dict.Add(arr[i], 1);
    }
}
```
Time Complexity: O(n)  
Space Complexity: O(n)

## Intermediate Level Problems

1. **Find the second largest number in an array**

```csharp
public int SecondLargest(int[] arr)
{
    int first = int.MinValue, second = int.MinValue;

    for (int i = 0; i < arr.Length; i++)
    {
        if (arr[i] > first)
        {
            second = first;
            first = arr[i];
        }
        else if (arr[i] > second && arr[i] < first)
            second = arr[i];
    }

    if (second == int.MinValue)
        Console.WriteLine("No second largest number.");
    else
        return second;
}
```
Time Complexity: O(n)  
Space Complexity: O(1)

2. **Rotate an array by N elements**

```csharp
public void RotateArray(int[] arr, int N)
{
    int[] temp = new int[N];

    for (int i = 0; i < N; i++)
        temp[i] = arr[i];

    for (int i = N; i < arr.Length; i++)
        arr[i - N] = arr[i];

    for (int i = 0; i < N; i++)
        arr[arr.Length - N + i] = temp[i];
}
```
Time Complexity: O(n)  
Space Complexity: O(n)

3. **Find the intersection of two arrays**

```csharp
public int[] Intersect(int[] nums1, int[] nums2)
{
    Array.Sort(nums1);
    Array.Sort(nums2);

    int i = 0, j = 0;
    List<int> list = new List<int>();

    while (i < nums1.Length && j < nums2.Length)
    {
        if (nums1[i] < nums2[j])
            i++;
        else if (nums1[i] > nums2[j])
            j++;
        else
        {
            list.Add(nums1[i]);
            i++;
            j++;
        }
    }

    return list.ToArray();
}
```
Time Complexity: O(n log n)  
Space Complexity: O(n)

4. **Find the majority element in an array**

```csharp
public int MajorityElement(int[] nums)
{
    Dictionary<int, int> dict = new Dictionary<int, int>();

    for (int i = 0; i < nums.Length; i++)
    {
        if (dict.ContainsKey(nums[i]))
            dict[nums[i]]++;
        else
            dict[nums[i]] = 1;

        if (dict[nums[i]] > nums.Length / 2)
            return nums[i];
    }

    return -1;
}
```
Time Complexity: O(n)  
Space Complexity: O(n)

5. **Find the "K" smallest elements in an array**

```csharp
public int[] KSmallest(int[] arr, int K)
{
    Array.Sort(arr);
    int[] result = new int[K];

    for (int i = 0; i < K; i++)
        result[i] = arr[i];

    return result;
}
```
Time Complexity: O(n log n)  
Space Complexity: O(n)

## Advanced Level Problems

1. **Find the longest consecutive subsequence in an array**

```csharp
public int LongestConsecutive(int[] nums)
{
    if (nums.Length == 0)
        return 0;

    Array.Sort(nums);

    int longestStreak = 1;
    int currentStreak = 1;

    for (int i = 1; i < nums.Length; i++)
    {
        if (nums[i] != nums[i - 1])
        {
            if (nums[i] == nums[i - 1] + 1)
                currentStreak++;
            else
                currentStreak = 1;

            if (currentStreak > longestStreak)
                longestStreak = currentStreak;
        }
    }

    return longestStreak;
}
```
Time Complexity: O(n log n)  
Space Complexity: O(1)

2. **Find the smallest missing number in a sorted array**

```csharp
public int FindMissingNumber(int[] arr, int m)
{
    int l = 0, r = arr.Length - 1;

    while (l <= r)
    {
        int mid = l + (r - l) / 2;

        if (arr[mid] != mid)
            r = mid - 1;
        else
            l = mid + 1;
    }

    return l;
}
```
Time Complexity: O(log n)  
Space Complexity: O(1)

3. **Find the longest increasing subarray**

```csharp
public int LongestIncreasingSubarray(int[] arr)
{
    int len = 1, maxLen = 1;

    for (int i = 1; i < arr.Length; i++)
    {
        if (arr[i] > arr[i - 1])
            len++;
        else
        {
            if (maxLen < len)
                maxLen = len;

            len = 1;
        }
    }

    if (maxLen < len)
        maxLen = len;

    return maxLen;
}
```
Time Complexity: O(n)  
Space Complexity: O(1)

4. **Find the maximum sum subarray**

```csharp
public int MaxSubArray(int[] nums)
{
    int maxSum = nums[0];
    int currSum = nums[0];

    for (int i = 1; i < nums.Length; i++)
    {
        currSum = Math.Max(nums[i], currSum + nums[i]);
        maxSum = Math.Max(maxSum, currSum);
    }

    return maxSum;
}
```
Time Complexity: O(n)  
Space Complexity: O(1)

5. **Find the median of two sorted arrays**

```csharp
public double FindMedianSortedArrays(int[] nums1, int[] nums2)
{
    if (nums1.Length > nums2.Length)
    {
        int[] temp = nums1; nums1 = nums2; nums2 = temp;
    }

    int x = nums1.Length;
    int y = nums2.Length;

    int start = 0;
    int end = x;

    while (start <= end)
    {
        int partitionX = (start + end) / 2;
        int partitionY = (x + y + 1) / 2 - partitionX;

        int maxLeftX = (partitionX == 0) ? int.MinValue : nums1[partitionX - 1];
        int minRightX = (partitionX == x) ? int.MaxValue : nums1[partitionX];

        int maxLeftY = (partitionY == 0) ? int.MinValue : nums2[partitionY - 1];
        int minRightY = (partitionY == y) ? int.MaxValue : nums2[partitionY];

        if (maxLeftX <= minRightY && maxLeftY <= minRightX)
        {
            if ((x + y) % 2 == 0)
                return ((double)Math.Max(maxLeftX, maxLeftY) + Math.Min(minRightX, minRightY)) / 2;
            else
                return (double)Math.Max(maxLeftX, maxLeftY);
        }
        else if (maxLeftX > minRightY)
            end = partitionX - 1;
        else
            start = partitionX + 1;
    }

    throw new ArgumentException("Input arrays are not sorted");
}
```
Time Complexity: O(log(min(m,n)))  
Space Complexity: O(1)