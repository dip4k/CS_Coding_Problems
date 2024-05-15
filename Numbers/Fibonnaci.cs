namespace Numbers;

public class Fibonacci
{
    private readonly Dictionary<int, int> _cache;

    public Fibonacci()
    {
        _cache = new()
        {
            [0] = 0,
            [1] = 1
        };

    }

    public int ComputeNthTerm(int number)
    {
        if (_cache.TryGetValue(number, out int value))
            return value;

        _cache[number] = ComputeNthTerm(number - 1) + ComputeNthTerm(number - 2);
        return _cache[number];
    }
}
