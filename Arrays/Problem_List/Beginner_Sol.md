## Beginner Level

1. **Find the Maximum and Minimum element in an array**
   Write a C# program to find the maximum and minimum element in an array.

2. **Reverse an array**
   Write a C# program to reverse an array.

3. **Find the duplicate elements in an array**
   Write a C# program to find duplicate elements in an array.

4. **Find the common elements in two arrays**
   Write a C# program to find common elements in two arrays.

5. **Find the missing number in an array**
   Write a C# program to find the missing number in an array of 1 to n.

6. **Find the Kth largest and smallest elements in an array**
   Write a C# program to find the Kth largest and smallest elements in an array.

## Sol
### three different approaches for each problem in the beginner category.

1. **Find the Maximum and Minimum element in an array**

*Approach 1: Using for loop*
```csharp
public void FindMaxMin(int[] arr)
{
    int max = arr[0];
    int min = arr[0];
    for(int i=1; i<arr.Length; i++)
    {
        if(arr[i] > max)
            max = arr[i];
        if(arr[i] < min)
            min = arr[i];
    }
    Console.WriteLine("Max: " + max);
    Console.WriteLine("Min: " + min);
}
```
Input: [1, 2, 3, 4, 5]
Output: Max: 5, Min: 1

*Approach 2: Using built-in Min and Max functions*
```csharp
using System.Linq;
int max = arr.Max();
int min = arr.Min();
```
Input: [1, 2, 3, 4, 5]
Output: Max: 5, Min: 1

*Approach 3: Using Array.Sort()*
```csharp
Array.Sort(arr);
int min = arr[0]; //first element
int max = arr[arr.Length - 1]; //last element
```
Input: [1, 2, 3, 4, 5]
Output: Max: 5, Min: 1

2. **Reverse an array**

*Approach 1: Using a for loop*
```csharp
public void ReverseArray(int[] arr)
{
    int start = 0;
    int end = arr.Length - 1;
    while(start < end)
    {
        int temp = arr[start];
        arr[start] = arr[end];
        arr[end] = temp;
        start++;
        end--;
    }
    foreach(int i in arr)
        Console.Write(i + " ");
}
```
Input: [1, 2, 3, 4, 5]
Output: 5 4 3 2 1 

*Approach 2: Using Array.Reverse()*
```csharp
Array.Reverse(arr);
```
Input: [1, 2, 3, 4, 5]
Output: 5 4 3 2 1 

*Approach 3: Using LINQ*
```csharp
arr = arr.Reverse().ToArray();
```
Input: [1, 2, 3, 4, 5]
Output: 5 4 3 2 1 

3. **Find the duplicate elements in an array**

*Approach 1: Using a Dictionary*
```csharp
public void FindDuplicates(int[] arr)
{
    Dictionary<int, int> dict = new Dictionary<int, int>();
    for(int i=0; i<arr.Length; i++)
    {
        if(dict.ContainsKey(arr[i]))
            Console.Write(arr[i] + " ");
        else
            dict.Add(arr[i], 1);
    }
}
```
Input: [1, 2, 3, 2, 1]
Output: 2 1 

*Approach 2: Using LINQ*
```csharp
var duplicates = arr.GroupBy(i => i).Where(g => g.Count() > 1).Select(g => g.Key);
```
Input: [1, 2, 3, 2, 1]
Output: 2 1 

*Approach 3: Using Array.Sort()*
```csharp
Array.Sort(arr);
for(int i = 1; i < arr.Length; i++)
{
    if(arr[i] == arr[i - 1])
        Console.Write(arr[i] + " ");
}
```
Input: [1, 2, 3, 2, 1]
Output: 1 2 

4. **Find the common elements in two arrays**

*Approach 1: Using HashSet*
```csharp
public void FindCommon(int[] arr1, int[] arr2)
{
    HashSet<int> set = new HashSet<int>(arr1);
    for(int i=0; i<arr2.Length; i++)
    {
        if(set.Contains(arr2[i]))
            Console.Write(arr2[i] + " ");
    }
}
```
Input: [1, 2, 3, 4, 5], [4, 5, 6, 7, 8]
Output: 4 5 

*Approach 2: Using LINQ*
```csharp
var common = arr1.Intersect(arr2);
```
Input: [1, 2, 3, 4, 5], [4, 5, 6, 7, 8]
Output: 4 5 

*Approach 3: Using two for loops*
```csharp
for(int i = 0; i < arr1.Length; i++)
{
    for(int j = 0; j < arr2.Length; j++)
    {
        if(arr1[i] == arr2[j])
            Console.Write(arr1[i] + " ");
    }
}
```
Input: [1, 2, 3, 4, 5], [4, 5, 6, 7, 8]
Output: 4 5 

5. **Find the missing number in an array**

*Approach 1: Using Sum of N numbers formula*
```csharp
public void FindMissingNumber(int[] arr, int count)
{
    int total = count*(count+1)/2;
    for(int i=0; i<arr.Length; i++)
        total -= arr[i];
    Console.WriteLine("Missing Number: " + total);
}
```
Input: [1, 2, 4, 5], count = 5
Output: Missing Number: 3

*Approach 2: Using XOR operation*
```csharp
int xor1 = arr[0];
int xor2 = 1;
for (int i = 1; i < arr.Length; i++)
    xor1 = xor1 ^ arr[i];
for (int i = 2; i <= arr.Length + 1; i++)
    xor2 = xor2 ^ i;
int missingNumber = xor1 ^ xor2;
```
Input: [1, 2, 4, 5], count = 5
Output: Missing Number: 3

*Approach 3: Using LINQ*
```csharp
int missingNumber = Enumerable.Range(1, arr.Length + 1).Except(arr).FirstOrDefault();
```
Input: [1, 2, 4, 5], count = 5
Output: Missing Number: 3

6. **Find the Kth largest and smallest elements in an array**

*Approach 1: Using Array.Sort()*
```csharp
public void FindKthLargestSmallest(int[] arr, int k)
{
    Array.Sort(arr);
    Console.WriteLine("Kth Largest: " + arr[arr.Length - k]);
    Console.WriteLine("Kth Smallest: " + arr[k - 1]);
}
```
Input: [1, 2, 3, 4, 5], k = 2
Output: Kth Largest: 4, Kth Smallest: 2

*Approach 2: Using SortedSet*
```csharp
// For Kth smallest
var pq = new SortedSet<int>(arr);
int kthSmallest = pq.ElementAt(k - 1);

// For Kth largest
int kthLargest = pq.ElementAt(arr.Length - k);
```
Input: [1, 2, 3, 4, 5], k = 2
Output: Kth Largest: 4, Kth Smallest: 2

*Approach 3: Using LINQ*
```csharp
int kthSmallest = arr.OrderBy(i => i).ElementAt(k - 1);
int kthLargest = arr.OrderByDescending(i => i).ElementAt(k - 1);
```
Input: [1, 2, 3, 4, 5], k = 2
Output: Kth Largest: 4, Kth Smallest: 2
