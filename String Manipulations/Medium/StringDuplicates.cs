using System.Text;

namespace String_Manipulations.Medium;

public static class StringDuplicates
{
    public static string RemoveDuplicatesUsingHashset(string inputString)
    {
        var visitedCharacters = new HashSet<char>();
        var uniqueString = new StringBuilder();

        foreach (var character in inputString)
        {
            if (!visitedCharacters.Contains(character))
            {
                uniqueString.Append(character);
                visitedCharacters.Add(character);
            }
        }

        return uniqueString.ToString();
    }

    public static string RemoveDuplicatesUsingLinq(string inputString)
    {
        var uniqueString = new string(inputString.AsEnumerable().Distinct().ToArray());
        return uniqueString;
    }
}
