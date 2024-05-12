using String_Manipulations.Easy;
using String_Manipulations.Hard;
using String_Manipulations.Medium;

namespace String_Manipulations
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var inputString1 = "I'm input string";
            var reverseString1 = ReverseString.ReverseWithBuiltInFunction(inputString1);
            Console.WriteLine(reverseString1);

            //var inputString2 = "I'm input string";
            //var reverseString2 = ReverseString.ReverseUsingForLoop(inputString2);
            //Console.WriteLine(reverseString2);

            //var inputString3 = "I'm input string";
            //var reverseString3 = ReverseString.ReverseUsingRecursion(inputString3);
            //Console.WriteLine(reverseString3);

            //var inputString4 = "I'm input string";
            //var reverseString4 = ReverseString.ReverseUsingStack(inputString4);
            //Console.WriteLine(reverseString4);

            //var charcount1 = CharacterCount.CharCountUsingDictionary(reverseString4);
            var charcount1 = CharacterCount.CharCountUsingLinq(reverseString1);
            foreach (var item in charcount1)
            {
                Console.WriteLine("{0} :: {1}", item.Key, item.Value);
            }

            // palindrome check
            var palindromeCheckString = "madam";
            bool isPalindrome = PalindromeCheck.IsPalindromeUsing2Pointer(palindromeCheckString);
            Console.WriteLine("{0} is a palindrome : {1}", palindromeCheckString, isPalindrome);

            var palindromeCheckString1 = "tomato";
            bool isPalindrome1 = PalindromeCheck.IsPalindromeUsing2Pointer(palindromeCheckString1);
            Console.WriteLine("{0} is a palindrome : {1}", palindromeCheckString1, isPalindrome1);

            //var palindromeCheckString2 = "racecar";
            //bool isPalindrome2 = PalindromeCheck.IsPalindromeUsingReverseString(palindromeCheckString2);
            //Console.WriteLine("{0} is a palindrome : {1}", palindromeCheckString2, isPalindrome2);

            //var palindromeCheckString3 = "apple";
            //bool isPalindrome3 = PalindromeCheck.IsPalindromeUsing2Pointer(palindromeCheckString3);
            //Console.WriteLine("{0} is a palindrome : {1}", palindromeCheckString3, isPalindrome3);

            var uniqueCharStrings = StringDuplicates.RemoveDuplicatesUsingHashset("iiaammmdddupppliccccattteiiimmmaa");
            Console.WriteLine(uniqueCharStrings);

            var uniqueCharStrings1 = StringDuplicates.RemoveDuplicatesUsingLinq("iiaammmdddupppliccccattteiiimmmaa");
            Console.WriteLine(uniqueCharStrings1);

            var firstNonRepeatCharacter = FirstNonRepeatingChar.FirstNonRepeatingCharUsingDictionary("firstNonRepeatingCharfs");
            Console.WriteLine(firstNonRepeatCharacter);
            //var firstNonRepeatCharacter1 = FirstNonRepeatingChar.FirstNonRepeatingCharUsingLinq("firstNonRepeatingCharfs");
            //Console.WriteLine(firstNonRepeatCharacter1);

            var isAnagram = Anagram.IsAnagramUsingDictionary("silent", "listen");
            Console.WriteLine("string is anagram : {0}", isAnagram);

            var isAnagram1 = Anagram.IsAnagramUsingDictionary("silenta", "hlisten");
            Console.WriteLine("string is anagram : {0}", isAnagram1);

            var isAnagram2 = Anagram.IsAnagramUsingLinq("silent", "listen");
            Console.WriteLine("string is anagram : {0}", isAnagram2);

            var isAnagram3 = Anagram.IsAnagramUsingLinq("silent1", "listgen");
            Console.WriteLine("string is anagram : {0}", isAnagram3);

            var inputCompressd = "aaabbcaadddd";
            var compressed = HardStringProblems.CompressStringUsingStringBuilder(inputCompressd);
            Console.WriteLine("Compression : {0} :: {1}", inputCompressd, compressed);
            Console.WriteLine("Hello, World!");
        }
    }
}
