using System.Text;

namespace String_Manipulations.Easy;

internal static class ReverseString
{
    public static string ReverseWithBuiltInFunction(string inputString)
    {
        var charArray = inputString.ToCharArray();
        //Array.Reverse(charArray); // Reverse the char array
        //string reversedString = new string(charArray); // Convert char array back to string
        var reversedCharArray = charArray.Reverse().ToArray();
        var result = new string(reversedCharArray);
        return result;
    }

    public static string ReverseUsingForLoop(string inputString)
    {
        var reverseStringBuilder = new StringBuilder();
        for (int index = inputString.Length - 1; index >= 0; index--)
        {
            reverseStringBuilder.Append(inputString[index]);
        }
        return reverseStringBuilder.ToString();
    }

    public static string ReverseUsingRecursion(string inputString)
    {
        if (inputString.Length <= 1)
            return inputString;
        return ReverseUsingRecursion(inputString.Substring(1)) + inputString[0];
        //return ReverseUsingRecursion(inputString[1..]) + inputString[0];
    }

    public static string ReverseUsingStack(string inputString)
    {
        var stringStack = new Stack<char>(inputString);
        var reverseString = new StringBuilder();
        while (stringStack.Count > 0)
        {
            reverseString.Append(stringStack.Pop());
        }
        return reverseString.ToString();
    }
}
