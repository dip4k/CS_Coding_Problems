using String_Manipulations.Easy;

namespace String_Manipulations.Medium;

public static class FirstNonRepeatingChar
{
    public static char FirstNonRepeatingCharUsingDictionary(string inputString)
    {
        // get character count of string
        var charcount = CharacterCount.CharCountUsingDictionary(inputString);
        char non_repeatChar = '\0';
        foreach (var item in inputString)
        {
            if (charcount[item] == 1)
            {
                non_repeatChar = item;
                break;
            }
        }
        return non_repeatChar;
    }

    public static char FirstNonRepeatingCharUsingLinq(string inputString)
    {
        var firstNonRepeatingChar = inputString
            .GroupBy(c => c)
            .FirstOrDefault(g => g.Count() == 1)?.Key;
        return firstNonRepeatingChar.Value;
    }
}
