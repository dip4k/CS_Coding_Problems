// See https://aka.ms/new-console-template for more information
using Numbers;

Console.WriteLine("Hello, World!");
var n = 12;
var fibonnaciSeq = NumbersAlgo.FibonnaciUsingLoop(n);
Console.WriteLine("{0} fibonnaci sequence");
foreach (var item in fibonnaciSeq)
{
    Console.Write(item + " ");
}
Console.WriteLine("\n---------");
