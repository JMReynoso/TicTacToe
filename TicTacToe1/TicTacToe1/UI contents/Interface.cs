using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe1
{
    class Interface
    {
        public void PrintBoard(GameMechanics game)
        {
            int[,] board = game.GetBoard();
            Console.WriteLine("-------------------------");
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (board[i, j] == 1)
                    {
                        Console.Write("X\t");
                    }
                    else if (board[i, j] == -1)
                    {
                        Console.Write("O\t");
                    }
                    else
                    {
                        Console.Write("-\t");
                    }
                }
                Console.Write("|\n");
            }

            Console.WriteLine("-------------------------");
        }

        public void GameJudge(GameMechanics game, int xPos, int yPos)
        {
            if (game.ValidateChoice(xPos, yPos).Equals("valid"))
            {
                game.PlaceChoice(xPos, yPos);
                PrintBoard(game);
                int winningCode = game.CheckWinState();

                //if player X wins
                if (winningCode == (int) GameMechanics.WinState.XWins)
                {
                    Console.WriteLine("\nPlayer X wins the round!");
                    Console.WriteLine("X win count: {0}", game.PlayerX.getWinCount());
                    Console.WriteLine("O win count: {0}", game.PlayerO.getWinCount());
                    Console.WriteLine("Resetting board...\n");
                    game.ResetBoard();
                }
                //if player O wins
                else if (winningCode == (int) GameMechanics.WinState.OWins)
                {
                    Console.WriteLine("\nPlayer X wins the round!");
                    Console.WriteLine("X win count: {0}", game.PlayerX.getWinCount());
                    Console.WriteLine("O win count: {0}", game.PlayerO.getWinCount());
                    Console.WriteLine("Resetting board...\n");
                    game.ResetBoard();
                }
                else if ((winningCode == (int) GameMechanics.WinState.NoOneWins) && game.IsBoardFull())
                {
                    Console.WriteLine("\nDRAW!");
                    Console.WriteLine("X win count: {0}", game.PlayerX.getWinCount());
                    Console.WriteLine("O win count: {0}", game.PlayerO.getWinCount());
                    Console.WriteLine("Resetting board...\n");
                    game.ResetBoard();
                }
            }

            else
            {
                Console.WriteLine("Not a valid choice! Try again... ");
            }
        }
    }
}
