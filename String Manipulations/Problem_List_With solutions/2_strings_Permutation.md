### **Problem Description:** Write a program to determine if one string is a permutation of another string. A permutation is a rearrangement of letters.

### Approach 1: Sorting and Comparing

```csharp
public bool IsPermutation(string str1, string str2)
{
    // If lengths of str1 and str2 are not same, they cannot be permutations
    if (str1.Length != str2.Length)
        return false;

    // Convert strings to char arrays
    char[] charArray1 = str1.ToCharArray();
    char[] charArray2 = str2.ToCharArray();

    // Sort the char arrays
    Array.Sort(charArray1);
    Array.Sort(charArray2);

    // Compare sorted strings
    return new string(charArray1) == new string(charArray2);
}
```
Example:
```csharp
Console.WriteLine(IsPermutation("abc", "bca"));  // Output: True
Console.WriteLine(IsPermutation("abc", "def"));  // Output: False
```

### Approach 2: Using Dictionary

```csharp
public bool IsPermutation(string str1, string str2)
{
    // If lengths of str1 and str2 are not same, they cannot be permutations
    if (str1.Length != str2.Length)
        return false;

    // Create a dictionary to count the frequency of each character in str1
    Dictionary<char, int> charCount = new Dictionary<char, int>();
    foreach (char c in str1)
    {
        if (charCount.ContainsKey(c))
            charCount[c]++;
        else
            charCount[c] = 1;
    }

    // Check the frequency of each character in str2
    foreach (char c in str2)
    {
        if (!charCount.ContainsKey(c))
            return false;
        if (--charCount[c] == 0)
            charCount.Remove(c);
    }

    // If the dictionary is empty, str1 and str2 are permutations
    return charCount.Count == 0;
}
```
Example:
```csharp
Console.WriteLine(IsPermutation("abc", "bca"));  // Output: True
Console.WriteLine(IsPermutation("abc", "def"));  // Output: False
```

### Approach 3: Using Array

```csharp
public bool IsPermutation(string str1, string str2)
{
    // If lengths of str1 and str2 are not same, they cannot be permutations
    if (str1.Length != str2.Length)
        return false;

    // Create an array to count the frequency of each character in str1
    int[] charCount = new int[256];
    foreach (char c in str1)
        charCount[c]++;

    // Check the frequency of each character in str2
    foreach (char c in str2)
    {
        if (--charCount[c] < 0)
            return false;
    }

    // If all counts are zero, str1 and str2 are permutations
    return true;
}
```
Example:
```csharp
Console.WriteLine(IsPermutation("abc", "bca"));  // Output: True
Console.WriteLine(IsPermutation("abc", "def"));  // Output: False
```

**Best Approach:**
The best approach would depend on the specific requirements of your program. If you care about performance, the third approach using an array is the fastest. If you care about readability, the first approach using sorting is the most straightforward. If you care about memory usage, the second approach using a dictionary uses less memory than the other approaches.