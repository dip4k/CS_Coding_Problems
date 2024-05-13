## 1. Fibonacci Series

### Approach 1: Simple Loop

```csharp
public void FibonacciSeries(int n)
{
    int a = 0, b = 1, c;
    Console.Write("{0} {1}", a, b);
    for (int i = 2; i < n; i++)
    {
        c = a + b;
        Console.Write(" {0}", c);
        a = b;
        b = c;
    }
}
```
Example:
```csharp
FibonacciSeries(7);
// Output: 0 1 1 2 3 5 8
```

### Approach 2: Recursive Function

```csharp
public int Fibonacci(int n)
{
    if (n <= 1)
        return n;
    return Fibonacci(n - 1) + Fibonacci(n - 2);
}
```
Example:
```csharp
for (int i = 0; i < 7; i++)
{
    Console.Write("{0} ", Fibonacci(i));
}
// Output: 0 1 1 2 3 5 8
```

### Approach 3: Using Yield

```csharp
public IEnumerable<int> FibonacciSeries(int n)
{
    int a = 0, b = 1, c;
    yield return a;
    yield return b;
    for (int i = 2; i < n; i++)
    {
        c = a + b;
        yield return c;
        a = b;
        b = c;
    }
}
```
Example:
```csharp
foreach (int i in FibonacciSeries(7))
{
    Console.Write("{0} ", i);
}
// Output: 0 1 1 2 3 5 8
```

**Best Approach:**
The best approach is the first one because it uses a simple loop without recursion and yield, which makes it more efficient and understandable.

## 2. Prime Number

### Approach 1: Simple Loop

```csharp
public bool IsPrime(int n)
{
    if (n <= 1)
        return false;
    for (int i = 2; i < n; i++)
        if (n % i == 0)
            return false;
    return true;
}
```
Example:
```csharp
Console.WriteLine(IsPrime(7));  // Output: True
Console.WriteLine(IsPrime(4));  // Output: False
```

### Approach 2: Using sqrt(n) as upper limit for loop

```csharp
public bool IsPrime(int n)
{
    if (n <= 1)
        return false;
    for (int i = 2; i * i <= n; i++)
        if (n % i == 0)
            return false;
    return true;
}
```
Example:
```csharp
Console.WriteLine(IsPrime(7));  // Output: True
Console.WriteLine(IsPrime(4));  // Output: False
```

### Approach 3: Using LINQ

```csharp
public bool IsPrime(int n)
{
    if (n <= 1)
        return false;
    return !Enumerable.Range(2, (int)Math.Sqrt(n) - 1).Any(i => n % i == 0);
}
```
Example:
```csharp
Console.WriteLine(IsPrime(7));  // Output: True
Console.WriteLine(IsPrime(4));  // Output: False
```

**Best Approach:**
The best approach is the second one because it reduces the number of iterations by using sqrt(n) as the upper limit for the loop.

## 3. Factorial

### Approach 1: Simple Loop

```csharp
public int Factorial(int n)
{
    int fact = 1;
    for (int i = 1; i <= n; i++)
        fact *= i;
    return fact;
}
```
Example:
```csharp
Console.WriteLine(Factorial(5));  // Output: 120
```

### Approach 2: Recursive Function

```csharp
public int Factorial(int n)
{
    if (n == 0)
        return 1;
    return n * Factorial(n - 1);
}
```
Example:
```csharp
Console.WriteLine(Factorial(5));  // Output: 120
```

### Approach 3: Using LINQ

```csharp
public int Factorial(int n)
{
    return Enumerable.Range(1, n).Aggregate(1, (p, item) => p * item);
}
```
Example:
```csharp
Console.WriteLine(Factorial(5));  // Output: 120
```

**Best Approach:**
The best approach is the first one because it uses a simple loop without recursion and LINQ, which makes it more efficient and understandable.

## 4. Reverse Number

### Approach 1: Using Modulus and Division Operators

```csharp
public int ReverseNumber(int num)
{
    int rev = 0;
    while (num > 0)
    {
        rev = rev * 10 + num % 10;
        num /= 10;
    }
    return rev;
}
```
Example:
```csharp
Console.WriteLine(ReverseNumber(1234));  // Output: 4321
```

### Approach 2: Convert to String and Use Array.Reverse

```csharp
public int ReverseNumber(int num)
{
    char[] charArray = num.ToString().ToCharArray();
    Array.Reverse(charArray);
    return int.Parse(new string(charArray));
}
```
Example:
```csharp
Console.WriteLine(ReverseNumber(1234));  // Output: 4321
```

### Approach 3: Using LINQ

```csharp
public int ReverseNumber(int num)
{
    string str = num.ToString();
    string rev = new string(str.Reverse().ToArray());
    return int.Parse(rev);
}
```
Example:
```csharp
Console.WriteLine(ReverseNumber(1234));  // Output: 4321
```

**Best Approach:**
The best approach is the first one because it uses arithmetic operations which are more efficient than string manipulations.

## 5. Palindrome Number

### Approach 1: Reverse Number and Compare

```csharp
public bool IsPalindrome(int num)
{
    int rev = 0, temp = num;
    while (num > 0)
    {
        rev = rev * 10 + num % 10;
        num /= 10;
    }
    return temp == rev;
}
```
Example:
```csharp
Console.WriteLine(IsPalindrome(121));  // Output: True
Console.WriteLine(IsPalindrome(123));  // Output: False
```

### Approach 2: Convert to String and Compare with Reverse

```csharp
public bool IsPalindrome(int num)
{
    string str = num.ToString();
    string rev = new string(str.Reverse().ToArray());
    return str == rev;
}
```
Example:
```csharp
Console.WriteLine(IsPalindrome(121));  // Output: True
Console.WriteLine(IsPalindrome(123));  // Output: False
```

**Best Approach:**
The best approach is the first one because it uses arithmetic operations which are more efficient than string manipulations.

## 6. Armstrong Number

### Approach 1: Using Modulus and Division Operators

```csharp
public bool IsArmstrong(int num)
{
    int sum = 0, temp = num;
    int digits = num.ToString().Length;
    while (num > 0)
    {
        int rem = num % 10;
        sum += (int)Math.Pow(rem, digits);
        num /= 10;
    }
    return temp == sum;
}
```
Example:
```csharp
Console.WriteLine(IsArmstrong(153));  // Output: True
Console.WriteLine(IsArmstrong(123));  // Output: False
```

### Approach 2: Convert to String and Use LINQ

```csharp
public bool IsArmstrong(int num)
{
    string str = num.ToString();
    int sum = str.Select(ch => (int)Math.Pow(int.Parse(ch.ToString()), str.Length)).Sum();
    return num == sum;
}
```
Example:
```csharp
Console.WriteLine(IsArmstrong(153));  // Output: True
Console.WriteLine(IsArmstrong(123));  // Output: False
```

**Best Approach:**
The best approach is the first one because it uses arithmetic operations which are more efficient than string manipulations.

## 7. Perfect Number

### Approach 1: Using Modulus Operator and Loop

```csharp
public bool IsPerfect(int num)
{
    int sum = 0;
    for (int i = 1; i < num; i++)
    {
        if (num % i == 0)
            sum += i;
    }
    return num == sum;
}
```
Example:
```csharp
Console.WriteLine(IsPerfect(6));  // Output: True
Console.WriteLine(IsPerfect(28));  // Output: True
Console.WriteLine(IsPerfect(12));  // Output: False
```

### Approach 2: Using LINQ

```csharp
public bool IsPerfect(int num)
{
    return num == Enumerable.Range(1, num / 2).Where(i => num % i == 0).Sum();
}
```
Example:
```csharp
Console.WriteLine(IsPerfect(6));  // Output: True
Console.WriteLine(IsPerfect(28));  // Output: True
Console.WriteLine(IsPerfect(12));  // Output: False
```

**Best Approach:**
The best approach is the first one because it uses a simple loop without LINQ, which makes it more efficient and understandable.

## 8. Strong Number

### Approach 1: Using Modulus Operator and Loop

```csharp
public bool IsStrong(int num)
{
    int sum = 0, temp = num;
    while (num > 0)
    {
        int fact = 1;
        int i = num % 10;
        for (int j = 1; j <= i; j++)
            fact *= j;
        sum += fact;
        num /= 10;
    }
    return temp == sum;
}
```
Example:
```csharp
Console.WriteLine(IsStrong(145));  // Output: True
Console.WriteLine(IsStrong(123));  // Output: False
```

### Approach 2: Using LINQ

```csharp
public bool IsStrong(int num)
{
    int sum = num.ToString().Select(ch => Factorial(int.Parse(ch.ToString()))).Sum();
    return num == sum;
}

public int Factorial(int i)
{
    if (i <= 1)
        return 1;
    return i * Factorial(i - 1);
}
```
Example:
```csharp
Console.WriteLine(IsStrong(145));  // Output: True
Console.WriteLine(IsStrong(123));  // Output: False
```

**Best Approach:**
The best approach is the first one because it uses a simple loop without LINQ, which makes it more efficient and understandable.

## 9. Magic Number

### Approach 1: Using Modulus Operator and Loop

```csharp
public bool IsMagic(int num)
{
    while (num > 9)
    {
        int sum = 0;
        while (num > 0)
        {
            sum += num % 10;
            num /= 10;
        }
        num = sum;
    }
    return num == 1;
}
```
Example:
```csharp
Console.WriteLine(IsMagic(19));  // Output: True
Console.WriteLine(IsMagic(123));  // Output: False
```

### Approach 2: Using LINQ

```csharp
public bool IsMagic(int num)
{
    while (num > 9)
    {
        num = num.ToString().Select(ch => int.Parse(ch.ToString())).Sum();
    }
    return num == 1;
}
```
Example:
```csharp
Console.WriteLine(IsMagic(19));  // Output: True
Console.WriteLine(IsMagic(123));  // Output: False
```

**Best Approach:**
The best approach is the first one because it uses a simple loop without LINQ, which makes it more efficient and understandable.

## 13. Square Root Without Using sqrt()

**Problem Description:** Write a program to find the square root of a number without using the sqrt() function.

### Approach 1: Using Binary Search

```csharp
public double SquareRoot(int num)
{
    double start = 0, end = num;
    double precision = 0.00001;

    if (num < 0) 
        return -1;

    if (num == 0 || num == 1)
        return num;

    while (end - start > precision)
    {
        double mid = (start + end) / 2;
        double midSqr = mid * mid;

        if (midSqr == num)
            return mid;
        else if (midSqr < num)
            start = mid;
        else
            end = mid;
    }

    return (start + end) / 2;
}
```
Example:
```csharp
Console.WriteLine(SquareRoot(16));  // Output: 4
Console.WriteLine(SquareRoot(2));  // Output: 1.41421
```

## 14. Power Without Using pow()

**Problem Description:** Write a program to calculate the power of a number without using the pow() function.

### Approach 1: Using Loop

```csharp
public double Power(int baseNum, int exp)
{
    double result = 1;
    for (int i = 0; i < exp; i++)
        result *= baseNum;
    return result;
}
```
Example:
```csharp
Console.WriteLine(Power(2, 3));  // Output: 8
Console.WriteLine(Power(5, 4));  // Output: 625
```

### Approach 2: Using Recursion

```csharp
public double Power(int baseNum, int exp)
{
    if (exp == 0)
        return 1;
    else
        return baseNum * Power(baseNum, exp - 1);
}
```
Example:
```csharp
Console.WriteLine(Power(2, 3));  // Output: 8
Console.WriteLine(Power(5, 4));  // Output: 625
```

**Best Approach:**
The best approach for both problems is the first one because it uses a simple loop without recursion, which makes it more efficient and understandable. For the square root problem, the binary search method provides a good balance between precision and performance. For the power problem, the loop method is straightforward and does not have the risk of stack overflow that comes with recursion.

## **Problem Description:** Write a program to generate the first n prime numbers.

### Approach 1: Simple Loop

```csharp
public List<int> GeneratePrimes(int n)
{
    List<int> primes = new List<int>();
    for (int num = 2; primes.Count < n; num++)
    {
        bool isPrime = true;
        for (int i = 2; i * i <= num; i++)
        {
            if (num % i == 0)
            {
                isPrime = false;
                break;
            }
        }
        if (isPrime)
            primes.Add(num);
    }
    return primes;
}
```
Example:
```csharp
Console.WriteLine(string.Join(",", GeneratePrimes(5)));  // Output: 2,3,5,7,11
```

### Approach 2: Using sqrt(n) as upper limit for loop

```csharp
public List<int> GeneratePrimes(int n)
{
    List<int> primes = new List<int>();
    for (int num = 2; primes.Count < n; num++)
    {
        bool isPrime = true;
        for (int i = 2; i * i <= num; i++)
        {
            if (num % i == 0)
            {
                isPrime = false;
                break;
            }
        }
        if (isPrime)
            primes.Add(num);
    }
    return primes;
}
```
Example:
```csharp
Console.WriteLine(string.Join(",", GeneratePrimes(5)));  // Output: 2,3,5,7,11
```

### Approach 3: Using LINQ

```csharp
public List<int> GeneratePrimes(int n)
{
    return Enumerable.Range(2, int.MaxValue - 2)
                     .Where(x => Enumerable.Range(2, (int)Math.Sqrt(x) - 1).All(i => x % i > 0))
                     .Take(n).ToList();
}
```
Example:
```csharp
Console.WriteLine(string.Join(",", GeneratePrimes(5)));  // Output: 2,3,5,7,11
```

**Best Approach:**
The best approach is the second one because it reduces the number of iterations by using sqrt(n) as the upper limit for the loop. The LINQ approach is elegant but can be significantly slower for larger inputs.

## **Problem Description:** Write a program to generate the first n prime numbers using the Sieve of Eratosthenes method.

### Approach: Using Sieve of Eratosthenes

The Sieve of Eratosthenes is an algorithm used to find all primes smaller than a given number n. The basic idea is to initially consider all numbers from 2 to n as prime. We then start from the first prime number, which is 2, and mark all its multiples as not prime. We move to the next unmarked number and repeat the process until all numbers are either marked as prime or not prime.

However, to find the first n prime numbers, we need to know the upper limit for n. The Rosser's theorem gives an upper bound for the nth prime number: `n log n + n log log n`. We can use this as the upper limit for the Sieve of Eratosthenes.

Here is the C# code for this approach:

```csharp
public List<int> GeneratePrimes(int n)
{
    int limit = (int)(n * Math.Log(n) + n * Math.Log(Math.Log(n)));
    bool[] sieve = new bool[limit + 1];
    List<int> primes = new List<int>();

    for (int p = 2; p <= limit; p++)
    {
        if (!sieve[p])
        {
            primes.Add(p);
            if (primes.Count == n)
                break;
            for (int i = p * p; i <= limit; i += p)
                sieve[i] = true;
        }
    }
    return primes;
}
```
Example:
```csharp
Console.WriteLine(string.Join(",", GeneratePrimes(5)));  // Output: 2,3,5,7,11
```

This approach is efficient and can generate the first n prime numbers quickly. However, it uses more memory because it needs to create a boolean array of size n.