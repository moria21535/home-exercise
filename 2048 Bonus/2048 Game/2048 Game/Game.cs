using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048_Game
{
    class Game
    {
        public Board GameBoard { get; set; }
        public GameStatus CurrentGameStatus { get; set; }
        public int Points { get; protected set; }

        public Game()
        {
            GameBoard = new Board(4, 4);
            CurrentGameStatus = GameStatus.Idle;
            Points = 0;
        }

        private void CheckWin()
        {
            for (int i = 0; i < GameBoard.Data.GetLength(0); i++)
            {
                for (int j = 0; j < GameBoard.Data.GetLength(1); j++)
                {
                    if (GameBoard.Data[i, j] == 2048)
                    {
                        CurrentGameStatus = GameStatus.Win;
                        return;
                    }
                }
            }
        }

        //private void CheckLose()
        //{
        //    // if the board is full
        //    if (GameBoard.StatusBoard().Count == 0)
        //    {
        //        Board copyGameBoard = GameBoard;
        //        copyGameBoard.Move(Direction.Right);
        //        if (!CheckBoardsEqual(copyGameBoard, GameBoard))
        //        {
        //            return;
        //        }

        //        copyGameBoard = GameBoard;



        //    }
        //}

        private bool CheckBoardsEqual(Board board1, Board board2)
        {
            if (board1.Data.GetLength(0) != board2.Data.GetLength(0) || 
                board1.Data.GetLength(1) != board2.Data.GetLength(1))
            {
                return false;
            }

            for (int i = 0; i < board1.Data.GetLength(0); i++)
            {
                for (int j = 0; j < board1.Data.GetLength(1); j++)
                {
                    if (board1.Data[i, j] != board2.Data[i, j])
                    {
                        return false;
                    }
                }
            }

            return true;
        }
//        private void StatusGame()
//        {

//        }

//        public void Move(Direction direction)
//        {
//            if (CurrentGameStatus == GameStatus.Lose)
//            {
//                return;
//            }

//            Points = GameBoard.Move(direction);

//        }
//    }
//}
