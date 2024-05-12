## Sure, I will provide four different approaches you can implement in C# to compress a string by counting the consecutively repeated characters. 
   
1. Using StringBuilder and Iterating through the string:
```csharp
public static string CompressString1(string str){
    StringBuilder compressed = new StringBuilder();
    int countConsecutive = 0;
    for (int i = 0; i < str.Length; i++){
        countConsecutive++;
        if (i+1 >= str.Length || str[i] != str[i + 1]){
            compressed.Append(str[i]);
            compressed.Append(countConsecutive);
            countConsecutive = 0;
        }
    }
    return compressed.Length < str.Length ? compressed.ToString() : str ;
}
```

2. Using two Pointers:
```csharp
public static string CompressString2(string str){
    StringBuilder compressed = new StringBuilder();
    int i = 0;
    while(i < str.Length){
        char currentChar = str[i];
        int count = 1;
        while(i+1 < str.Length && str[i] == str[i + 1]){
            i++;
            count++;
        }
        compressed.Append(currentChar);
        compressed.Append(count);
        i++;
    }
    return compressed.Length < str.Length ? compressed.ToString() : str ;
}
```

3. Using Counting Method:
```csharp
public static string CompressString3(string str){
    StringBuilder compressed = new StringBuilder();
    int[] freq = new int[26]; // Only for lowercase english letters.  
    for (int i = 0; i < str.Length; i++)
       freq[str[i] - 'a']++; 
        
    for (int i = 0; i < 26; i++){
        if (freq[i] > 0){
            compressed.Append((char) (i +'a'));
            compressed.Append(freq[i]);
        }
    }
    return compressed.Length < str.Length ? compressed.ToString() : str ;
}
```

4. Using Dictionary:
```csharp
public static string CompressString4(string str){
    Dictionary<char, int> dictionary = new Dictionary<char, int>();
    foreach (char c in str)
    {
        if (dictionary.ContainsKey(c))
            dictionary[c]++;
        else
            dictionary[c] = 1;
    }

    StringBuilder compressed = new StringBuilder();
    foreach (KeyValuePair<char, int> pair in dictionary)
    {
        compressed.Append(pair.Key);
        compressed.Append(pair.Value);
    }
    return compressed.Length < str.Length ? compressed.ToString() : str;
}
```

**Example:**
Input: "aaabbbbccc"
Output: "a3b4c3"

For all methods, it creates a compressed string and checks at the end if the compressed string is shorter than the original string. If it is, it returns the compressed string. Otherwise, it returns the original string.

Please note, method 3 compresses string with lowercase english letters only. And method 4 does not maintain the order of characters.
If the string can contain non-ASCII characters, or the order of characters is important you might need to modify these functions accordingly. 



## You can solve the problem "Checking if a string is a rotation of another" in various ways. Here are five different solutions:

**1. Concatenate and Check Substring** - This is probably the most straightforward one, with lower complexity compared to other solutions.

```csharp
public static bool IsRotation(string original, string possibleRotation)
{
    // Ensure both strings have the same length
    if (original.Length != possibleRotation.Length)
    {
        return false;
    }

    // Concatenate the rotated string to itself
    string concatenated = possibleRotation + possibleRotation;

    // Check if original string is a substring of concatenated string
    return concatenated.Contains(original);
}
```

**2. Iterative Rotation and String Compare** - An iterative solution, where possibleRotation is rotated one character at a time.

```csharp
public static bool IsRotation(string original, string possibleRotation)
{
    if (original.Length != possibleRotation.Length)
    {
        return false;
    }

    for (int i = 0; i < possibleRotation.Length; i++)
    {
        possibleRotation = possibleRotation.Substring(1) + possibleRotation[0];

        if (possibleRotation == original)
        {
            return true;
        }
    }
    return false;
}
```

**3. Two Pointers Method** - This method cycles through both strings, starting from the initial character, it compares each character.

```csharp
public static bool IsRotation(string s1, string s2)
{
    if (s1.Length != s2.Length) return false;

    int i = 0, j = s2.IndexOf(s1[0]);

    while (i < s1.Length && j < s2.Length)
    {
        if (s1[i] != s2[j]) return false;
        i++; 
        j = (j + 1) % s2.Length; // Using modulo to handle wrap around at the end of the string
    }

    return true;
}
```

**4. Using Queue or Stack** - Implement using a stack data structure.

```csharp
public static bool IsRotation(string original, string possibleRotation)
{
    if (original.Length != possibleRotation.Length)
    {
        return false;
    }

    char firstChar = original[0];
    int index = possibleRotation.IndexOf(firstChar);

    if (index == -1)
    {
        return false;
    }

    Stack<char> stack = new Stack<char>(original.ToCharArray());

    for (int i = 0; i < possibleRotation.Length; i++)
    {
        char ch = stack.Pop();
        if (ch != possibleRotation[(index + i) % possibleRotation.Length])
        {
            return false;
        }
    }

    return true;
}
```

**5. Brute Force** - An iterative solution, where every position in possibleRotation is checked to see if it matches the beginning of original, and if so, the characters in original and possibleRotation are compared for equality in a rotated manner.

```csharp
public static bool IsRotation(string original, string possibleRotation)
{
    if (original.Length != possibleRotation.Length)
    {
        return false;
    }

    for (int i = 0; i < possibleRotation.Length; i++)
    {
        bool isRotation = true;

        for (int j = 0; j < original.Length; j++)
        {
            if (original[j] != possibleRotation[(i + j) % possibleRotation.Length])
            {
                isRotation = false;
                break;
            }
        }

        if (isRotation)
        {
            return true;
        }
    }

    return false;
}
```

All functions are written to be self-contained with arguments for both the 'original' string and the 'possibleRotation' string, where they return a boolean indicating whether the second string is a rotation of the first string.