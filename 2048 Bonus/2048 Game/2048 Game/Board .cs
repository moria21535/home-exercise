using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048_Game
{
    class Board
    {
        public int[,] Data { get; protected set; }

        public Board()
        {
            Data = new int[4, 4];
        }

        private List<int[]> StatusBoard()
        {
            List<int[]> positions = new();
            for (int i = 0; i < Data.GetLength(0); i++)
            {
                for (int j = 0; j < Data.GetLength(1); j++)
                {
                    if (Data[i, j] == 0)
                    {
                        int[] position = { i, j };
                        positions.Add(position);
                    }
                }
            }

            return positions;
        }

        private static int TwoOrFour()
        {
            Random rnd = new();
            int[] numbers = { 2, 4 };
            return numbers[rnd.Next(numbers.Length)];
        }

        public void InitialRandomPositions()
        {
            for (int i = 0; i < 2; i++)
            {
                Random rnd = new();
                List<int[]> positions = StatusBoard();
                int[] position = positions[rnd.Next(positions.Count)];
                Data[position[0], position[1]] = TwoOrFour();
            }
        }

        private void RandomPosition()
        {
            Random rnd = new();
            List<int[]> positions = StatusBoard();
            int[] position = positions[rnd.Next(positions.Count)];
            Data[position[0], position[1]] = TwoOrFour();
        }

        public int Move(Direction direction)
        {
            return 0;
        }
    }
}
