namespace String_Manipulations.Easy;

public static class CharacterCount
{
    public static Dictionary<char, int> CharCountUsingDictionary(string inputString)
    {

        var characterMap = new Dictionary<char, int>();
        foreach (var character in inputString.Where(Char.IsLetterOrDigit))
        {
            if (characterMap.ContainsKey(character))
            {
                characterMap[character] += 1;
            }
            else
            {
                characterMap[character] = 1;
            }
        }
        return characterMap;
    }

    public static Dictionary<char, int> CharCountUsingLookup(string inputString)
    {
        var characterMap = new Dictionary<char, int>();
        var charLookup = inputString.Where(char.IsLetterOrDigit).ToLookup(c => c);
        foreach (var c in charLookup)
        {
            characterMap.Add(c.Key, charLookup[c.Key].Count());
        }
        return characterMap;
    }

    public static Dictionary<char, int> CharCountUsingLinq(string inputString)
    {
        return inputString
            .GroupBy(c => c)
            .Where(c => Char.IsLetterOrDigit(c.Key))
            .Select(x => new KeyValuePair<char, int>(x.Key, x.Count()))
            .ToDictionary();
    }
}
