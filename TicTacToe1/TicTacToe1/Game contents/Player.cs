using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe1
{
    public class Player
    {
        private int WinCount;
        public Player()
        {
            WinCount = 0;
        }

        public void PlayerWins()
        {
            WinCount++;
        }

        public int getWinCount()
        {
            return WinCount;
        }
    }
}
