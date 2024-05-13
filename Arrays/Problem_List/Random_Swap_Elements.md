### **Problem Description:** Write a program to randomly swap elements in an array.

### Approach 1: Using for loop and Random class

```csharp
public void RandomlySwapElements(int[] array)
{
    // Create an instance of Random class
    Random random = new Random();

    // Start from the last element and swap one by one
    for (int i = array.Length - 1; i > 0; i--)
    {
        // Pick a random index from 0 to i
        int randomIndex = random.Next(i + 1);

        // Swap array[i] with the element at random index
        int temp = array[i];
        array[i] = array[randomIndex];
        array[randomIndex] = temp;
    }
}
```
Example:
```csharp
int[] array = {1, 2, 3, 4, 5};
RandomlySwapElements(array);
Console.WriteLine(string.Join(",", array));  // Output: Randomly swapped array
```

### Approach 2: Using LINQ and OrderBy

```csharp
public int[] RandomlySwapElements(int[] array)
{
    // Create an instance of Random class
    Random random = new Random();

    // Use OrderBy to randomly rearrange the elements
    return array.OrderBy(x => random.Next()).ToArray();
}
```
Example:
```csharp
int[] array = {1, 2, 3, 4, 5};
array = RandomlySwapElements(array);
Console.WriteLine(string.Join(",", array));  // Output: Randomly swapped array
```

### Approach 3: Using List and while loop

```csharp
public int[] RandomlySwapElements(int[] array)
{
    // Convert array to list
    List<int> list = array.ToList();

    // Create an instance of Random class
    Random random = new Random();

    // Create an array to store the result
    int[] result = new int[array.Length];
    int i = 0;

    // While there are elements in the list
    while (list.Count > 0)
    {
        // Pick a random index
        int randomIndex = random.Next(list.Count);

        // Add the element at the random index to the result
        result[i++] = list[randomIndex];

        // Remove the element at the random index from the list
        list.RemoveAt(randomIndex);
    }

    return result;
}
```
Example:
```csharp
int[] array = {1, 2, 3, 4, 5};
array = RandomlySwapElements(array);
Console.WriteLine(string.Join(",", array));  // Output: Randomly swapped array
```

**Best Approach:**
The best approach is the first one using a for loop and the Random class. This is known as the Fisher-Yates shuffle algorithm, which is an efficient algorithm for generating a random permutation of a finite sequence. The other approaches are less efficient as they involve sorting or removing elements from a list, which are more expensive operations.

### Here is the C# code for the Fisher-Yates shuffle algorithm:

```csharp
public void FisherYatesShuffle(int[] array)
{
    // Create a new instance of the Random class
    Random random = new Random();

    // Start from the last element and swap one by one
    for (int i = array.Length - 1; i > 0; i--)
    {
        // Pick a random index from 0 to i
        int j = random.Next(i + 1);

        // Swap array[i] with the element at random index
        int temp = array[i];
        array[i] = array[j];
        array[j] = temp;
    }
}
```
Example:
```csharp
int[] array = {1, 2, 3, 4, 5};
FisherYatesShuffle(array);
Console.WriteLine(string.Join(",", array));  // Output: Randomly shuffled array
```

**Time Complexity:** The time complexity of the Fisher-Yates shuffle algorithm is O(n), where n is the number of elements in the array. This is because the algorithm makes one pass over the array.

**Space Complexity:** The space complexity of the Fisher-Yates shuffle algorithm is O(1), which means it uses a constant amount of space. This is because the algorithm shuffles the array in place and does not use any additional data structures whose size depends on the input.