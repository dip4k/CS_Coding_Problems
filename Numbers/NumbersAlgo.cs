namespace Numbers;

public static class NumbersAlgo
{
    #region Fibonnaci
    public static int[] FibonnaciUsingLoop(int terms)
    {
        const int first = 1;
        const int second = 1;
        var fibonnaci = new int[terms];
        fibonnaci[0] = first; fibonnaci[1] = second;
        for (int i = 2; i < terms; i++)
        {
            int ithTerm = fibonnaci[i - 1] + fibonnaci[i - 2];
            fibonnaci[i] = ithTerm;
        }
        return fibonnaci;
    }

    public static int FibonacciNthTermUsingRecursion(int term)
    {
        if (term == 0) return 0;
        if (term == 1) return 1;
        return FibonacciNthTermUsingRecursion(term - 1) + FibonacciNthTermUsingRecursion(term - 2);
    }
    #endregion
}
