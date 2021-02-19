using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe1
{
    class Board
    {
        private int[,] board;

        public Board()
        {
            //board will always be a square
            Console.WriteLine("Please enter a board size (single integer number): ");

            string inputString = Console.ReadLine();

            if(int.TryParse(inputString, out int n))
            {
                int size = Convert.ToInt32(inputString);
                board = new int[size, size];

                //fill board with 0s
                for (int row = 0; row < size; row++)
                {
                    for (int col = 0; col < size; col++)
                    {
                        SetCell(0, row, col);
                    }
                }
            }

            else
            {
                Console.WriteLine("Error: size is not a number.");
                Environment.Exit(2);
            }

        }

        public void SetCell(int value, int row, int col)
        {
            board[row, col] = value;
        }

        public int GetCell(int row, int col)
        {
            return board[row, col];
        }

        public int[,] GetBoard()
        {
            return board;
        }

        public int GetSize()
        {
            return board.GetLength(0);
        }
    }
}
