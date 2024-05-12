using System.Text;

namespace String_Manipulations.Hard;

public static class HardStringProblems
{
    #region String Compression
    public static string CompressStringUsingStringBuilder(string input)
    {
        var compressed = new StringBuilder();
        int charRepeatCount = 0;
        for (int index = 0; index < input.Length; index++)
        {
            charRepeatCount++;
            if (index + 1 >= input.Length || input[index] != input[index + 1])
            {
                compressed.Append(input[index]);
                compressed.Append(charRepeatCount);
                charRepeatCount = 0;
            }
        }
        return compressed.ToString();
    }
    #endregion
}
