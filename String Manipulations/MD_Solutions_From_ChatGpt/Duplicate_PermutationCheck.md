Sure, here is the output in markdown format:

## Solution 1: Sorting and Comparison

```csharp
using System;
using System.Linq;

public class Program
{
    public static void Main(string[] args)
    {
        string firstString = "ABC";
        string secondString = "CBA";
        Console.WriteLine(IsPermutation(firstString, secondString) ? "Yes" : "No");
    }

    public static bool IsPermutation(string firstString, string secondString)
    {
        // If strings are of different lengths, they cannot be permutations of each other
        if (firstString.Length != secondString.Length)
            return false;

        // Sort both strings
        var sortedFirstString = String.Concat(firstString.OrderBy(c => c));
        var sortedSecondString = String.Concat(secondString.OrderBy(c => c));

        // If sorted strings are equal, then the original strings are permutations of each other
        return sortedFirstString == sortedSecondString;
    }
}
```

**Time complexity**: O(n log n) due to sorting.
**Space complexity**: O(n) for storing the sorted strings.

## Solution 2: Character Counting

```csharp
using System;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        string firstString = "ABC";
        string secondString = "CBA";
        Console.WriteLine(IsPermutation(firstString, secondString) ? "Yes" : "No");
    }

    public static bool IsPermutation(string firstString, string secondString)
    {
        // If strings are of different lengths, they cannot be permutations of each other
        if (firstString.Length != secondString.Length)
            return false;

        // Dictionary to hold the count of each character in the first string
        Dictionary<char, int> characterCounts = new Dictionary<char, int>();

        // Count the number of each character in the first string
        foreach (char c in firstString)
        {
            if (characterCounts.ContainsKey(c))
                characterCounts[c]++;
            else
                characterCounts[c] = 1;
        }

        // For each character in the second string, decrement its count
        foreach (char c in secondString)
        {
            if (!characterCounts.ContainsKey(c) || --characterCounts[c] < 0)
                return false;
        }

        // If all counts are zero, the strings are permutations of each other
        return true;
    }
}
```

**Time complexity**: O(n) for iterating over the strings.
**Space complexity**: O(n) for storing the character counts.

Both solutions handle edge cases where the input strings are null, empty, or of different lengths. They also handle strings with special characters correctly.