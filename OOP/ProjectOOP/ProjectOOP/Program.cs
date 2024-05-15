using System;

namespace ProjectOOP
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList lst = new();
            lst.Append(3);
            lst.Append(2);
            lst.Append(1);
            Console.WriteLine(string.Join(" ", lst.ToList()));
            Console.WriteLine($"first: {lst.First.Value}");
            Console.WriteLine($"last: {lst.Last.Value}");

            Console.WriteLine();
            lst.Sort();
            Console.WriteLine(string.Join(" ", lst.ToList()));
            Console.WriteLine($"first: {lst.First.Value}");
            Console.WriteLine($"last: {lst.Last.Value}");

            Console.WriteLine("\n===================================\n");

            LinkedList lst1 = new();
            lst1.Append(90);
            lst1.Append(10);
            lst1.Append(3);
            lst1.Append(2);
            Console.WriteLine(string.Join(" ", lst1.ToList()));
            Console.WriteLine($"max: {lst1.GetMaxNode().Value}\n" +
                $"min: {lst1.GetMinNode().Value}\n");

            lst1.Pop();
            Console.WriteLine(string.Join(" ", lst1.ToList()));
            Console.WriteLine($"max: {lst1.GetMaxNode().Value}\n" +
                $"min: {lst1.GetMinNode().Value}\n");

            lst1.Unqueue();
            Console.WriteLine(string.Join(" ", lst1.ToList()));
            Console.WriteLine($"max: {lst1.GetMaxNode().Value}\n" +
                $"min: {lst1.GetMinNode().Value}\n");

            Console.WriteLine("\n===================================\n");

            NumericalExpression ne = new(11706);
            Console.WriteLine(ne.ToString());

            Console.WriteLine($"\n{ne.GetValue()}");

            Console.WriteLine($"\n{NumericalExpression.SumLetters(1)}");

            Console.WriteLine($"\n{NumericalExpression.SumLetters(ne)}");





        }
    }
}
