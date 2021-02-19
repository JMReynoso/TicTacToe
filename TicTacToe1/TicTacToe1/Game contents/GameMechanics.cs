using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe1
{
    public class GameMechanics
    {

        private Board board;
        public Player PlayerX, PlayerO;
        public int playerTurn, boardSize;

        public GameMechanics()
        {
            board = new Board();
            playerTurn = 1;
            PlayerX = new Player();
            PlayerO = new Player();
            boardSize = board.GetSize();
        }

        //for CheckWinState
        public enum WinState
        {
            NoOneWins = 0,
            Draw = -2,
            XWins = 6,
            OWins = 7
        }

        //6 if X wins the match, 7 if O wins the match, 0 if no one wins
        //reset player turn so that X player always go first
        public int CheckWinState()
        {
            //check rows
            int row = checkRows();

            if(row == 6)
            {
                return (int)WinState.XWins;
            }
            else if(row == 7)
            {
                return (int)WinState.OWins;
            }

            //check cols
            int col = checkCol();

            if (col == 6)
            {
                return (int)WinState.XWins;
            }
            else if (col == 7)
            {
                return (int)WinState.OWins;
            }

            //check diagonal from top right
            int DiagonalFromTopRight = checkDiagonalFromTopRight();

            if (DiagonalFromTopRight == 6)
            {
                return (int)WinState.XWins;
            }
            else if (DiagonalFromTopRight == 7)
            {
                return (int)WinState.OWins;
            }

            //check diagonal from top left
            int DiagonalFromTopLeft = checkDiagonalFromTopLeft();

            if (DiagonalFromTopLeft == 6)
            {
                return (int)WinState.XWins;
            }
            else if (DiagonalFromTopLeft == 7)
            {
                return (int)WinState.OWins;
            }

            //no one wins
            return (int)WinState.NoOneWins;
        }

        public int checkRows()
        {
            int xProgression = 0, oProgression = 0;

            //check each row
            for (int i = 0; i < boardSize; i++)
            {
                //iterate the row array
                for (int j = 0; j < boardSize; j++)
                {
                    if (board.GetCell(i, j) == 1)
                    {
                        xProgression++;
                    }
                    else if (board.GetCell(i, j) == -1)
                    {
                        oProgression++;
                    }
                }

                if (xProgression == boardSize)
                {
                    PlayerX.PlayerWins();
                    switchToPlayerX();
                    return (int) WinState.XWins;
                }
                else if (oProgression == boardSize)
                {
                    PlayerO.PlayerWins();
                    switchToPlayerX();
                    return (int) WinState.OWins;
                }
            }

            return (int)WinState.NoOneWins;
        }

        public int checkCol()
        {
            int xProgression = 0, oProgression = 0;

            //check each col     
            for (int j = 0; j < boardSize; j++)
            {

                //iterate the col array
                for (int i = 0; i < boardSize; i++)
                {
                    if (board.GetCell(i, j) == 1)
                    {
                        xProgression++;
                    }
                    else if (board.GetCell(i, j) == -1)
                    {
                        oProgression++;
                    }
                }

                if (xProgression == boardSize)
                {
                    PlayerX.PlayerWins();
                    switchToPlayerX();
                    return (int) WinState.XWins;
                }
                else if (oProgression == boardSize)
                {
                    PlayerO.PlayerWins();
                    switchToPlayerX();
                    return (int) WinState.OWins;
                }
            }

            return (int)WinState.NoOneWins;
        }

        public int checkDiagonalFromTopRight()
        {
            int xProgression = 0, oProgression = 0;
            //check diagonals
            //diagonal from top left to bottom right
            for (int i = 0; i < boardSize; i++)
            {
                int j = i;
                if (board.GetCell(i, j) == 1)
                {
                    xProgression++;
                }
                else if (board.GetCell(i, j) == -1)
                {
                    oProgression++;
                }
            }

            if (xProgression == boardSize)
            {
                PlayerX.PlayerWins();
                switchToPlayerX();
                return (int) WinState.XWins;
            }
            else if (oProgression == boardSize)
            {
                PlayerO.PlayerWins();
                switchToPlayerX();
                return (int) WinState.OWins;
            }

            return (int)WinState.NoOneWins;
        }

        public int checkDiagonalFromTopLeft()
        {
            int xProgression = 0, oProgression = 0;
            //diagonal from top right to bottom left
            for (int i = 0; i < boardSize; i++)
            {
                for (int j = 0; j < boardSize; j++)
                {
                    if (((i + j) == boardSize - 1) && (board.GetCell(i, j) == 1))
                    {
                        xProgression++;
                    }

                    else if (((i + j) == boardSize - 1) && (board.GetCell(i, j) == -1))
                    {
                        oProgression++;
                    }
                }
            }

            if (xProgression == boardSize)
            {
                PlayerX.PlayerWins();
                switchToPlayerX();
                return (int) WinState.XWins;
            }
            else if (oProgression == boardSize)
            {
                PlayerO.PlayerWins();
                switchToPlayerX();
                return (int) WinState.OWins;
            }

            return (int)WinState.NoOneWins;
        }

        public bool IsBoardFull()
        {
            //check if board is not full
            for (int i = 0; i < boardSize; i++)
            {
                for (int j = 0; j < boardSize; j++)
                {
                    if (board.GetCell(i, j) == 0)
                    {
                        return false;
                    }
                }
            }

            //board is full, switch back to player X
            switchToPlayerX();
            return true;
        }

        public void switchToPlayerX()
        {
            playerTurn = 1;
        }

        public void switchToPlayerO()
        {
            playerTurn = -1;
        }

        public int[,] GetBoard()
        {
            return board.GetBoard();
        }

        public void ResetBoard()
        {
            for (int i = 0; i < board.GetSize(); i++)
            {
                for (int j = 0; j < board.GetSize(); j++)
                {
                    board.SetCell(0,i,j);
                }
            }
        }

        public bool ValidateChoice(int row, int col)
        {
            //check if spot is valid

            //if choice is out of bounds
            if (row > board.GetSize()-1 || col > board.GetSize()-1)
            {
                return false;
            }

            //if cell is already taken
            if ((board.GetCell(row,col) == 1) || (board.GetCell(row, col) == -1))
            {
                return false;
            }

            return true;
        }

        public void PlaceChoice(int row, int col)
        {
            //place player's choice on board
            board.SetCell(playerTurn, row, col);

            //change player
            if (playerTurn == 1)
            {
                switchToPlayerO();
            }
            else
            {
                switchToPlayerX();
            }
        }
    }
}
