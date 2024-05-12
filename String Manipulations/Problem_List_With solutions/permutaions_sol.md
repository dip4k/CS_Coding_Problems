Sure, here are the mentioned methods with input and output:

**Method 1 – Using Recursion**
This method involves fixing a character and swapping the rest of characters till you have explored all the arrangements.

```csharp
/* GetPermutations takes a string as input and returns a List of all permutations */
public static List<string> GetPermutations1(string str)
{
    List<string> permutations = new List<string>();
    Permutate("", str, permutations);
    return permutations;
}

/* Recursive helper function to get permutations */
private static void Permutate(string prefix, string suffix, List<string> permutations)
{
    if (string.IsNullOrEmpty(suffix))
    {
        permutations.Add(prefix);    // Add to result list when suffix is empty
    }
    else 
    {
        for (int i = 0; i < suffix.Length; i++)
        {
            Permutate(prefix + suffix[i], suffix.Substring(0, i) + suffix.Substring(i + 1), permutations);
        }
    }
}

/* 
Input: GetPermutations1("abc")
Output: { "abc", "acb", "bac", "bca", "cab", "cba" }
*/


**Method 2 – Using Backtracking**
The backtracking approach picks and removes an element from array, finds the permutations of the rest of elements, and then reinserts the picked element at all possible positions.

```csharp
public static List<string> GetPermutations2(string str)
{
    List<string> results = new List<string>();
    Backtrack(new List<char>(), str.ToCharArray(), results);
    return results;
}

private static void Backtrack(List<char> current, char[] chars, List<string> results)
{
    if (current.Count == chars.Length)
    {
        results.Add(new string(current.ToArray())); // If current permutation is valid
    }

    for (int i = 0; i < chars.Length; i++)
    {
        if (current.Contains(chars[i]))  // Skip if the character is already in current
        {
            continue;
        }

        current.Add(chars[i]);
        Backtrack(current, chars, results);
        current.RemoveAt(current.Count - 1);
    }
}

/* 
Input: GetPermutations2("abc")
Output: { "abc", "acb", "bac", "bca", "cab", "cba" }
*/


**Method 3 – Using Heap’s Algorithm**
Heap’s algorithm generates all possible permutations of n objects. It generates each permutation from the previous one by interchanging a single pair of elements.

```csharp
public static List<string> GetPermutations3(string str)
{
    List<string> permutations = new List<string>();
    HeapsAlgorithm(str.Length, str.ToCharArray(), permutations);
    return permutations;
}

private static void HeapsAlgorithm(int num, char[] array, List<string> permutations)
{
    if (num == 1)
    {
        permutations.Add(new string(array)); // If current permutation is valid
        return;
    }

    for (int i = 0; i < num; i++)
    {
        HeapsAlgorithm(num - 1, array, permutations);
        int j = num % 2 == 0 ? i : 0;
        (array[j], array[num - 1]) = (array[num - 1], array[j]); // swap elements
    }
}

/* 
Input: GetPermutations3("abc")
Output: { "abc", "acb", "bac", "bca", "cab", "cba" }
*/


**Method 4 – Using Built-in Method**
C# has a built-in method to find permutations using the method available in LINQ. It is suited for small strings only.

```csharp
public static IEnumerable<string> GetPermutations4(string str)
{
    if (str.Length == 1) 
    {
        return new List<string>{str};
    }

    char ch = str[0];
    string subString = str.Substring(1);
    IEnumerable<string> subPermutations = GetPermutations4(subString);

    return from p in subPermutations
        from i in Enumerable.Range(0, subPermutations.First().Length+1)
        select p.Insert(i, ch.ToString());
}

/* 
Input: GetPermutations4("abc").ToList()
Output: { "abc", "bac", "bca", "acb", "cab", "cba" } */
```

For each method, you pass in the string and get an `IEnumerable` or `List` of string as the output, each output string being one possible permutation. For example, if `str = "abc"`, `GetPermutations1(str)` or any other method would return a collection containing "abc", "acb", "bac", "bca", "cab", "cba".
