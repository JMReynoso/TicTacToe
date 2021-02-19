using System;
using TicTacToe1.Parser;

namespace TicTacToe1
{
    class Program
    {
        static void Main(string[] args)
        {
            GameMechanics game = new GameMechanics();
            Interface ui = new Interface();

            while (true)
            {
                int turn = game.playerTurn;
                if (turn == 1)
                {
                    Console.WriteLine("Enter choice for player X in format 'x,y': ");
                }
                else if (turn == -1)
                {
                    Console.WriteLine("Enter choice for player O in format 'x,y': ");
                }

                string GetLine = Console.ReadLine();

                ValidateInputForPosition validate = new ValidateInputForPosition(GetLine);

                if (validate.verifyInput())
                {
                    string[] split = GetLine.Split(",");

                    int xPos = Convert.ToInt32(split[0]);
                    int yPos = Convert.ToInt32(split[1]);

                    ui.GameJudge(game, xPos, yPos);
                }

                else
                {
                    Console.WriteLine("Error: input did not start with a number.");
                    Environment.Exit(2);
                }
            }
        }
    }
}
