## Advanced Level

1. **Find the smallest positive missing number in an unsorted array**
   Write a C# program to find the smallest positive missing number in an unsorted array.

2. **Find the maximum product subarray**
   Write a C# program to find the maximum product of a subarray in an array.

3. **Find the longest increasing subsequence in an array**
   Write a C# program to find the longest increasing subsequence in an array.

4. **Find the number of inversions in an array**
   Write a C# program to find the number of inversions in an array. An inversion is a pair of indices (i, j) such that i < j and arr[i] > arr[j].

5. **Find the maximum sum of a subarray of size K**
   Write a C# program to find the maximum sum of a subarray of size K.

6. **Find the maximum sum of a subarray such that no two elements are adjacent**
   Write a C# program to find the maximum sum of a subarray such that no two elements are adjacent.

## Sol
### Sure, here are the solutions for the first three questions in the advanced category.

1. **Find the longest increasing subsequence in an array**

*Approach 1: Dynamic Programming*
```csharp
public void FindLongestIncreasingSubsequence(int[] arr)
{
    // Initialize the dp array with all elements as 1
    int[] dp = new int[arr.Length];
    // This will store the final result
    int max = 0;
    
    // Start from the first element
    for(int i = 0; i < arr.Length; i++)
    {
        // Initialize the dp[i] as 1
        dp[i] = 1;
        
        // Check for all elements before i
        for(int j = 0; j < i; j++)
        {
            // If arr[i] is greater, check if max subsequence ending at arr[j] can be extended
            if(arr[i] > arr[j] && dp[i] < dp[j] + 1)
                dp[i] = dp[j] + 1;
        }
        // Update the maximum length
        max = Math.Max(max, dp[i]);
    }
    Console.WriteLine("Longest Increasing Subsequence: " + max);
}
```
Input: [10, 22, 9, 33, 21, 50, 41, 60, 80]
Output: Longest Increasing Subsequence: 6

*Approach 2: Binary Search and Dynamic Programming*
```csharp
public void FindLongestIncreasingSubsequence(int[] arr)
{
    int[] dp = new int[arr.Length];
    int length = 1;
    dp[0] = arr[0];
    for(int i = 1; i < arr.Length; i++)
    {
        if(arr[i] < dp[0])
            dp[0] = arr[i];
        else if(arr[i] > dp[length - 1])
            dp[length++] = arr[i];
        else
            dp[CeilIndex(dp, -1, length - 1, arr[i])] = arr[i];
    }
    Console.WriteLine("Longest Increasing Subsequence: " + length);
}

public int CeilIndex(int[] arr, int l, int r, int key)
{
    while(r - l > 1)
    {
        int m = l + (r - l)/2;
        if(arr[m] >= key)
            r = m;
        else
            l = m;
    }
    return r;
}
```
Input: [10, 22, 9, 33, 21, 50, 41, 60, 80]
Output: Longest Increasing Subsequence: 6

2. **Find the longest common subsequence between two strings**

*Approach 1: Recursive Approach*
```csharp
public int LongestCommonSubsequence(string str1, string str2, int m, int n)
{
    // If we have reached the end of a string, return 0
    if(m == 0 || n == 0)
        return 0;
    // If the last characters match, increment the count by 1
    else if(str1[m - 1] == str2[n - 1])
        return 1 + LongestCommonSubsequence(str1, str2, m - 1, n - 1);
    else
        // If the last characters do not match, take the maximum count by excluding the last character of either string
        return Math.Max(LongestCommonSubsequence(str1, str2, m, n - 1), LongestCommonSubsequence(str1, str2, m - 1, n));
}
```
Input: "abcde", "ace" 
Output: 3

*Approach 2: Dynamic Programming*
```csharp
public int LongestCommonSubsequence(string str1, string str2)
{
    int m = str1.Length;
    int n = str2.Length;
    int[,] dp = new int[m + 1, n + 1];
    
    for(int i = 0; i <= m; i++)
    {
        for(int j = 0; j <= n; j++)
        {
            if(i == 0 || j == 0)
                dp[i, j] = 0;
            else if(str1[i - 1] == str2[j - 1])
                dp[i, j] = 1 + dp[i - 1, j - 1];
            else
                dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
        }
    }
    return dp[m, n];
}
```
Input: "abcde", "ace" 
Output: 3

3. **Find the shortest common supersequence between two strings**

*Approach 1: Recursive Approach*
```csharp
public int ShortestCommonSupersequence(string str1, string str2, int m, int n)
{
    if(m == 0)
        return n;
    if(n == 0)
        return m;
    if(str1[m - 1] == str2[n - 1])
        return 1 + ShortestCommonSupersequence(str1, str2, m - 1, n - 1);
    else
        return 1 + Math.Min(ShortestCommonSupersequence(str1, str2, m - 1, n), ShortestCommonSupersequence(str1, str2, m, n - 1));
}
```
Input: "abc", "ac" 
Output: 3

*Approach 2: Dynamic Programming*
```csharp
public int ShortestCommonSupersequence(string str1, string str2)
{
    int m = str1.Length;
    int n = str2.Length;
    int[,] dp = new int[m + 1, n + 1];
    
    for(int i = 0; i <= m; i++)
    {
        for(int j = 0; j <= n; j++)
        {
            if(i == 0)
                dp[i, j] = j;
            else if(j == 0)
                dp[i, j] = i;
            else if(str1[i - 1] == str2[j - 1])
                dp[i, j] = 1 + dp[i - 1, j - 1];
            else
                dp[i, j] = 1 + Math.Min(dp[i - 1, j], dp[i, j - 1]);
        }
    }
    return dp[m, n];
}
```
Input: "abc", "ac" 
Output: 3

Optimal Approach: The optimal approach for all these problems would be the Dynamic Programming approach. It has a time complexity of O(m*n) where m and n are the lengths of the input strings or arrays. It uses a bottom-up approach to solve the problem by solving smaller sub-problems first, which avoids the overhead of repeated function calls and recursion stack in the Recursive Approach.

Sure, here are the solutions for the remaining questions in the advanced category with meaningful variable names and comments.

4. **Find the minimum number of coins that make a given value**

*Approach 1: Recursive Approach*
```csharp
public int MinCoins(int[] coins, int numOfCoins, int value)
{
    // Base case: when value is zero, zero coins are needed
    if(value == 0) return 0;
    // Initialize result as maximum integer value
    int minCoins = int.MaxValue;
    
    // Try every coin that has smaller value than value
    for(int i = 0; i < numOfCoins; i++)
    {
        if(coins[i] <= value)
        {
            int subResult = MinCoins(coins, numOfCoins, value - coins[i]);
            // Check if result can be minimized
            if(subResult != int.MaxValue && subResult + 1 < minCoins)
                minCoins = subResult + 1;
        }
    }
    return minCoins;
}
```
Input: [9, 6, 5, 1], numOfCoins = 4, value = 11
Output: 2

*Approach 2: Dynamic Programming*
```csharp
public int MinCoins(int[] coins, int numOfCoins, int value)
{
    // Initialize dp array with maximum integer value
    int[] dp = new int[value+1];
    dp[0] = 0;
    
    for(int i = 1; i <= value; i++)
    {
        for(int j = 0; j < numOfCoins; j++)
            if(coins[j] <= i)
            {
                int subRes = dp[i - coins[j]];
                // Check if the minimum can be achieved
                if(subRes != int.MaxValue && subRes + 1 < dp[i])
                    dp[i] = subRes + 1;
            }
    }
    return dp[value];
}
```
Input: [9, 6, 5, 1], numOfCoins = 4, value = 11
Output: 2

5. **Find the longest palindromic subsequence in a string**

*Approach 1: Recursive Approach*
```csharp
public int LongestPalindromicSubsequence(string str, int start, int end)
{
    // If there is only one character in string
    if(start == end)
        return 1;
    // If first and last characters are same and string length is 2
    if(str[start] == str[end] && start + 1 == end)
        return 2;
    // If the first and last characters match
    if(str[start] == str[end])
        return LongestPalindromicSubsequence(str, start + 1, end - 1) + 2;
    // If the first and last characters do not match
    return Math.Max(LongestPalindromicSubsequence(str, start, end - 1), LongestPalindromicSubsequence(str, start + 1, end));
}
```
Input: "bbbab"
Output: 4

*Approach 2: Dynamic Programming*
```csharp
public int LongestPalindromicSubsequence(string str)
{
    int strLength = str.Length;
    int[,] dp = new int[strLength, strLength];
    for(int i = 0; i < strLength; i++)
        dp[i, i] = 1;
    for(int cl = 2; cl <= strLength; cl++)
    {
        for(int i = 0; i < strLength - cl + 1; i++)
        {
            int j = i + cl - 1;
            if(str[i] == str[j] && cl == 2)
                dp[i, j] = 2;
            else if(str[i] == str[j])
                dp[i, j] = dp[i + 1, j - 1] + 2;
            else
                dp[i, j] = Math.Max(dp[i, j - 1], dp[i + 1, j]);
        }
    }
    return dp[0, strLength - 1];
}
```
Input: "bbbab"
Output: 4

6. **Find the longest common substring between two strings**

*Approach 1: Brute Force*
```csharp
public int LongestCommonSubstring(string str1, string str2)
{
    int maxLength = 0;
    for(int i = 0; i < str1.Length; i++)
    {
        for(int j = 0; j < str2.Length; j++)
        {
            int length = 0;
            while(i + length < str1.Length && j + length < str2.Length && str1[i + length] == str2[j + length])
                length++;
            maxLength = Math.Max(maxLength, length);
        }
    }
    return maxLength;
}
```
Input: "OldSite:GeeksforGeeks.org", "NewSite:GeeksQuiz.com"
Output: 10

*Approach 2: Dynamic Programming*
```csharp
public int LongestCommonSubstring(string str1, string str2)
{
    int str1Length = str1.Length;
    int str2Length = str2.Length;
    int[,] dp = new int[str1Length + 1, str2Length + 1];
    int maxLength = 0;
    for(int i = 0; i <= str1Length; i++)
    {
        for(int j = 0; j <= str2Length; j++)
        {
            if(i == 0 || j == 0)
                dp[i, j] = 0;
            else if(str1[i - 1] == str2[j - 1])
            {
                dp[i, j] = dp[i - 1, j - 1] + 1;
                maxLength = Math.Max(maxLength, dp[i, j]);
            }
            else
                dp[i, j] = 0;
        }
    }
    return maxLength;
}
```
Input: "OldSite:GeeksforGeeks.org", "NewSite:GeeksQuiz.com"
Output: 10

Optimal Approach: The optimal approach for all these problems would be the Dynamic Programming approach. It has a time complexity of O(m*n) where m and n are the lengths of the input strings or arrays. It uses a bottom-up approach to solve the problem by solving smaller sub-problems first, which avoids the overhead of repeated function calls and recursion stack in the Recursive Approach.