namespace Arrays;

public static class ArrayAlgo
{
    #region Reverse Array
    public static int[] ReverseArrayUsing2Pointers(int[] input)
    {
        var left = 0;
        var right = input.Length - 1;
        while (left < right)
        {
            (input[right], input[left]) = (input[left], input[right]);
            //int temp = input[left];
            //input[left] = input[right];
            //input[right] = temp;
            left++;
            right--;
        }
        return input;
    }
    #endregion

    #region Find Duplicate in an array
    public static int[] FindDuplicateElementsUsingDictionary(int[] input)
    {
        var dictionary = new Dictionary<int, int>();
        foreach (var item in input)
        {
            if (dictionary.ContainsKey(item))
            {
                dictionary[item]++;
            }
            else
            {
                dictionary[item] = 1;
            }
        }

        return dictionary
            .Where(x => x.Value > 1)
            .Select(x => x.Key)
            .ToArray();
    }

    public static int[] FindDuplicateElementsUsingLinq(int[] input)
    {
        return input
            .GroupBy(x => x)
            .Where(g => g.Count() > 1)
            .Select(g => g.Key)
            .ToArray();
    }
    #endregion

    #region Find the pair of elements in an array that sum to a given value
    public static int[][] FindSumPairUsingHashset(int[] input, int sum)
    {
        var inpHashset = new HashSet<int>(input);
        var resultPair = new List<int[]>();

        foreach (var item in input)
        {
            var temp = sum - item;
            if (inpHashset.Contains(temp))
            {
                resultPair.Add([item, temp]);
            }
        }
        return [.. resultPair];
    }
    #endregion
}
