// See https://aka.ms/new-console-template for more information
using Numbers;

Console.WriteLine("Hello, World!");
var n = 10;
var fibonnaciSeq = NumbersAlgo.FibonnaciUsingLoop(n);
Console.WriteLine("{0} fibonnaci sequence");
foreach (var item in fibonnaciSeq)
{
    Console.Write(item + " ");
}

Console.WriteLine("\n---------------");
var fibonacciTerm = new Fibonacci().ComputeNthTerm(10);
Console.WriteLine("{0}th fibonacci term is {1}", 10, fibonacciTerm);
Console.WriteLine("\n---------");
