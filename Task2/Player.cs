using System;

namespace Task2
{
    public class Player
    {
        private string gameSymbol;
        private bool isPlayerWin;
        private bool isPlayerRound = false;

        public bool IsPlayerRound
        {
            get { return isPlayerRound; }
            set { isPlayerRound = value; }
        }

        public bool IsPlayerWin 
        {
            get { return isPlayerWin; }
            set { isPlayerWin = value; }
        }

        public string GameSymbol
        {
            get { return  gameSymbol; }
        }

        public Player(string gameSymbol)
        {
            this.gameSymbol = gameSymbol;
            this.isPlayerWin = false;
        }
    }
}
