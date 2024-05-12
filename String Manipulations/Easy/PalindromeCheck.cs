namespace String_Manipulations.Easy;

public static class PalindromeCheck
{
    public static bool IsPalindromeUsing2Pointer(string inputString)
    {
        var left = 0;
        var right = inputString.Length - 1;
        bool isPalindrome = true;

        while (left <= right)
        {
            if (inputString[left] != inputString[right])
            {
                isPalindrome = false;
                break;
            }
            left++;
            right--;
        }
        return isPalindrome;
    }

    public static bool IsPalindromeUsingReverseString(string inputString)
    {
        var reversedString = ReverseString.ReverseUsingStack(inputString);
        return inputString.Equals(reversedString, StringComparison.OrdinalIgnoreCase);
    }
}
