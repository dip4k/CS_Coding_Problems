namespace Arrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] inputArr = [1, 2, 3, 4, 5, 6];
            var reverseArray = ArrayAlgo.ReverseArrayUsing2Pointers(inputArr);
            foreach (var item in reverseArray)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine("\n-------");
            int[] duplicateInput = [1, 1, 2, 2, 3, 4, 5, 6, 5, 2, 9, 6];
            var duplicateElements = ArrayAlgo.FindDuplicateElementsUsingDictionary(duplicateInput);
            Console.WriteLine("Duplicate Items : ");
            foreach (var item in duplicateElements)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine("\n-------");

            int[] duplicateInput1 = [1, 1, 2, 2, 3, 4, 5, 6, 5, 2, 9, 6];
            var duplicateElements1 = ArrayAlgo.FindDuplicateElementsUsingLinq(duplicateInput1);
            Console.WriteLine("Duplicate Items : ");
            foreach (var item in duplicateElements1)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine("\n-------");

            int[] inputSumPair = [1, 2, 3, 4, 5];
            var sumPair = ArrayAlgo.FindSumPairUsingHashset(inputSumPair, 5);
            Console.WriteLine("Array sum pair");
            foreach (var pair in sumPair)
            {
                foreach (var item in pair)
                {
                    Console.WriteLine(item + ",");
                }
                Console.Write(" ");
            }
            Console.WriteLine("\n-------");
            Console.WriteLine("Hello, World!");
        }
    }
}
