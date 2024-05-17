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

        public Board(int row, int column)
        {
            Data = new int[row, column];
        }

        public List<int[]> StatusBoard()
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

        private void RandomPosition()
        {
            Random rnd = new();
            List<int[]> positions = StatusBoard();
            int[] position = positions[rnd.Next(positions.Count)];
            Data[position[0], position[1]] = TwoOrFour();
        }

        public void InitialRandomPositions()
        {
            for (int i = 0; i < 2; i++)
            {
                RandomPosition();
            }
        }

        private int MoveRight()
        {
            int points = 0;

            // for each row from
            // top to bottom
            for (int i = 0; i < Data.GetLength(0); i++)
            {
                List<int> values = new();
                List<int> mergingValues = new();
                int j;

                // for each element of
                // row from right to left
                for (j = Data.GetLength(1) - 1; j >= 0; j--)
                {
                    // if not 0
                    if (Data[i, j] != 0)
                        values.Add(Data[i, j]);
                }

                // for each temporary array
                for (j = 0; j < values.Count; j++)
                {
                    // if two element have
                    // same value at
                    // consecutive position.
                    if (j < values.Count - 1 && values[j] == values[j + 1])
                    {
                        // insert only one element
                        // as sum of two same element.
                        mergingValues.Add(2 * values[j]);
                        points += 2 * values[j];
                        j++;
                    }
                    else
                        mergingValues.Add(values[j]);
                }

                // filling the each
                // row element to 0.
                for (j = 0; j < Data.GetLength(1); j++)
                    Data[i, j] = 0;

                j = Data.GetLength(1) - 1;

                // Copying the temporary
                // array to the current row.
                for (int it = 0; it < mergingValues.Count; it++)
                    Data[i, j--] = mergingValues[it];
            }

            return points;
        }

        private int MoveLeft()
        {
            int points = 0;

            // for each row
            for (int i = 0; i < Data.GetLength(0); i++)
            {
                List<int> values = new();
                List<int> mergingValues = new();
                int j;

                // for each element of the
                // row from left to right
                for (j = 0; j < Data.GetLength(1); j++)
                {
                    // if not 0
                    if (Data[i, j] != 0)
                        values.Add(Data[i, j]);
                }

                // for each temporary array
                for (j = 0; j < values.Count; j++)
                {
                    // if two element have
                    // same value at
                    // consecutive position.
                    if (j < values.Count - 1 && values[j] == values[j + 1])
                    {
                        // insert only one element
                        // as sum of two same element.
                        mergingValues.Add(2 * values[j]);
                        points += 2 * values[j];
                        j++;
                    }
                    else
                        mergingValues.Add(values[j]);
                }

                // filling the each
                // row element to 0.
                for (j = 0; j < Data.GetLength(1); j++)
                    Data[i, j] = 0;

                j = 0;

                for (int it = 0; it < mergingValues.Count; it++)
                    Data[i, j++] = mergingValues[it];
            }

            return points;
        }

        private int MoveDown()
        {
            int points = 0;

            // for each column
            for (int i = 0; i < Data.GetLength(1); i++)
            {
                List<int> values = new();
                List<int> mergingValues = new();
                int j;

                // for each element of
                // column from bottom to top
                for (j = Data.GetLength(0) - 1; j >= 0; j--)
                {
                    // if not 0
                    if (Data[j, i] != 0)
                        values.Add(Data[j, i]);
                }

                // for each temporary array
                for (j = 0; j < values.Count; j++)
                {

                    // if two element have same
                    // value at consecutive position.
                    if (j < values.Count - 1 && values[j] == values[j + 1])
                    {
                        // insert only one element
                        // as sum of two same element.
                        mergingValues.Add(2 * values[j]);
                        points += 2 * values[j];
                        j++;
                    }
                    else
                        mergingValues.Add(values[j]);
                }

                // filling the each
                // column element to 0.
                for (j = 0; j < Data.GetLength(0); j++)
                    Data[j, i] = 0;

                j = Data.GetLength(0) - 1;

                // Copying the temporary array
                // to the current column
                for (int it = 0; it < mergingValues.Count; it++)
                    Data[j--, i] = mergingValues[it];
            }

            return points;
        }

        private int MoveUp()
        {
            int points = 0;

            // for each column
            for (int i = 0; i < Data.GetLength(1); i++)
            {
                List<int> values = new();
                List<int> mergingValues = new();
                int j;

                // for each element of column
                // from top to bottom
                for (j = 0; j < Data.GetLength(0); j++)
                {
                    // if not 0
                    if (Data[j, i] != 0)
                        values.Add(Data[j, i]);
                }

                // for each temporary array
                for (j = 0; j < values.Count; j++)
                {
                    // if two element have same
                    // value at consecutive position.
                    if (j < values.Count - 1 && values[j] == values[j + 1])
                    {
                        // insert only one element
                        // as sum of two same element.
                        mergingValues.Add(2 * values[j]);
                        points += 2 * values[j];
                        j++;
                    }
                    else
                        mergingValues.Add(values[j]);
                }

                // filling the each
                // column element to 0.
                for (j = 0; j < Data.GetLength(0); j++)
                    Data[j, i] = 0;

                j = 0;

                // Copying the temporary array
                // to the current column

                for (int it = 0; it < mergingValues.Count; it++)
                    Data[j++, i] = mergingValues[it];
            }

            return points;
        }

        private int MoveMatrix(Direction direction)
        {
            if (Direction.Right == direction)
            {
                return MoveRight();
            }

            else if (Direction.Left == direction)
            {
                return MoveLeft();
            }

            else if (Direction.Down == direction)
            {
                return MoveDown();
            }

            else
            {
                return MoveUp();
            }
        }

        public int Move(Direction direction)
        {
            int points = MoveMatrix(direction);
            RandomPosition();
            return points;
        }
    }
}
