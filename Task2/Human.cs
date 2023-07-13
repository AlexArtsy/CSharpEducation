﻿namespace Task2
{
    public class Human : ITicTacToePlaying
    {
        public KeyBoardControl Input { get; set; }
        public bool IsPlayerWin { get; set; }

        public string GameSymbol { get; }

        public Human(string gameSymbol, KeyBoardControl input)
        {
            Input = input;
            GameSymbol= gameSymbol;
            IsPlayerWin = false;
        }

        public Figure SelectFieldCell(Figure[,] field, out bool validation)
        {
            var key = Console.ReadKey(true).Key;
            validation = false;

            switch (key)
            {
                case ConsoleKey.DownArrow:
                case ConsoleKey.UpArrow:
                case ConsoleKey.RightArrow:
                case ConsoleKey.LeftArrow:
                    Input.MoveCursor(key);
                    break;
                case ConsoleKey.Enter:
                    validation = !field[Input.UserCursor.GetX(), Input.UserCursor.GetY()].Initialized;
                    break;
            }

            return field[Input.UserCursor.GetX(), Input.UserCursor.GetY()];

        }
    }
}
