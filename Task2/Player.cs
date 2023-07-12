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

        public Figure SelectFieldCell(Game game)
        {
            while (true)
            {
                game.io.Render(game, this);

                ConsoleKey key = Console.ReadKey(true).Key; //  Слушаем нажатие кнопки.
                switch (key)
                {
                    case ConsoleKey.DownArrow:
                    case ConsoleKey.UpArrow:
                    case ConsoleKey.RightArrow:
                    case ConsoleKey.LeftArrow:
                        game.io.MoveCursor(key);
                        break;
                    case ConsoleKey.Enter:
                        if (!game.Field[game.io.UserCursor.GetX(), game.io.UserCursor.GetY()].IsInizialized)
                        {
                            return game.Field[game.io.UserCursor.GetX(), game.io.UserCursor.GetY()];
                        }
                        break;
                }
            }
        }
    }
}
