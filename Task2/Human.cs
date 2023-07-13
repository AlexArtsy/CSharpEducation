using System;

namespace Task2
{
    public class Human
    {
        private KeyBoardControl input;
        public bool IsPlayerWin { get; set; }

        public string GameSymbol { get; }

        public Human(int resolution, string gameSymbol)
        {
            this.input = new KeyBoardControl(resolution);
            this.GameSymbol= gameSymbol;
            this.IsPlayerWin = false;
        }

        public Figure SelectFieldCell(Figure[,] field, out bool validation)
        {
            ConsoleKey key = Console.ReadKey(true).Key;
            validation = false;

            switch (key)
            {
                case ConsoleKey.DownArrow:
                case ConsoleKey.UpArrow:
                case ConsoleKey.RightArrow:
                case ConsoleKey.LeftArrow:
                    input.MoveCursor(key);
                    break;
                case ConsoleKey.Enter:
                    validation = true;
                    break;
            }

            return field[this.input.UserCursor.GetX(), this.input.UserCursor.GetY()];

        }
    }
}
