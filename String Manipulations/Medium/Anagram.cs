namespace String_Manipulations.Medium;

public static class Anagram
{
    public static bool IsAnagramUsingDictionary(string input1, string input2)
    {
        // for string 1 increase char count for string 2 decrease char count
        var charcount = new Dictionary<char, int>();

        foreach (var c in input1)
        {
            if (charcount.ContainsKey(c))
            {
                charcount[c]++;
            }
            else
            {
                charcount[c] = 1;
            }
        }

        foreach (var c in input2)
        {
            if (!charcount.ContainsKey(c))
            {
                return false;
            }
            if (--charcount[c] == 0)
            {
                charcount.Remove(c);
            }
        }

        return charcount.Count == 0;
    }

    public static bool IsAnagramUsingLinq(string input1, string input2)
    {
        // sort and compare
        var sorted1 = input1.AsEnumerable().OrderBy(c => c).ToArray();
        var sorted2 = input2.AsEnumerable().OrderBy(c => c).ToArray();
        return new string(sorted1).Equals(new string(sorted2));
    }
}
