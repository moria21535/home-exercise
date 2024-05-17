using System;
using System.Collections.Generic;

namespace _2048_Game
{
    class Program
    { 
       
        public static void Main(string[] args)
        {
            int[,] a = { { 1, 0, 3, 3},
            {2, 2, 2, 0 },
            { 0, 4, 4, 4},
            { 1, 2, 3, 4} };
            int n = 4;
            for (int i = 0; i < n; i++)
            {
                List<int> v = new List<int>();
                List<int> w = new List<int>();
                int j;

                // for each element of
                // row from right to left
                for (j = n - 1; j >= 0; j--)
                {
                    // if not 0
                    if (a[i, j] != 0)
                        v.Add(a[i, j]);
                }

                // for each temporary array
                for (j = 0; j < v.Count; j++)
                {
                    // if two element have
                    // same value at
                    // consecutive position.
                    if (j < v.Count - 1 && v[j] == v[j + 1])
                    {
                        // insert only one element
                        // as sum of two same element.
                        w.Add(2 * v[j]);
                        j++;
                    }
                    else
                        w.Add(v[j]);
                }

                // filling the each
                // row element to 0.
                for (j = 0; j < n; j++)
                    a[i, j] = 0;

                j = n - 1;

                // Copying the temporary
                // array to the current row.
                for (int it = 0; it < w.Count; it++)
                    a[i, j--] = w[it];
            }

            for (int i = 0; i < a.GetLength(0); i++)
            {
                for(int j = 0; j < a.GetLength(1); j++)
                {
                    Console.Write(a[i, j] + "\t");
                }
                Console.WriteLine();
            }

        }

    }
}
