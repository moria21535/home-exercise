using System;
using System.Collections.Generic;

namespace ProjectOOP
{
    class Program
    {
        static void Main(string[] args)
        {
            //LinkedList lst = new LinkedList();
            //lst.Append(3);
            //lst.Append(2);
            //lst.Append(1);
            //Console.WriteLine(string.Join(" ", lst.ToList()));
            //Console.WriteLine($"first: {lst.First.Value}");
            //Console.WriteLine($"last: {lst.Last.Value}");

            //Console.WriteLine();
            //lst.Sort();
            //Console.WriteLine(string.Join(" ", lst.ToList()));

            //Console.WriteLine($"first: {lst.First.Value}");
            //Console.WriteLine($"last: {lst.Last.Value}");

            //List<int> list = new List<int>();
            //list.Add(8);
            //list.Add(9);
            //list.Add(10);
            //Console.WriteLine(string.Join(" ", list));
            //list.RemoveAt(list.Count - 1);
            //Console.WriteLine(string.Join(" ", list));
            //int x = list[0];
            //Console.WriteLine(x);

            LinkedList lst1 = new LinkedList();
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




        }
    }
}
