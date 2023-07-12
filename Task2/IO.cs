<<<<<<< Updated upstream
﻿using System;
using System.IO;

namespace Task2
=======
﻿namespace Task2
>>>>>>> Stashed changes
{
    public class IO
    {
        #region Поля и свойства
        private int resolution;
        private Cursor userCursor;

<<<<<<< Updated upstream
        public Cursor UserCursor { get { return userCursor; } }
=======
        public Cursor UserCursor
        {
            get { return userCursor; }
        }
>>>>>>> Stashed changes
        #endregion

        #region Методы
        public void Render(Game game, Player player)
        {
            PrintGameInfo(col: 0, row: 0);
            PrintGamerTurnStatus(col: 0, row: Console.CursorTop + 1, player.GameSymbol);
            PrintGamingField(col: 5, row: Console.CursorTop + 1, game.Field);
            PrintGameStatus(col: 0, row: Console.CursorTop + 3, game.State);
        }

        public void MoveCursor(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.DownArrow:
                    userCursor.MoveYDown();
                    break;
                case ConsoleKey.UpArrow:
                    userCursor.MoveYUp();
                    break;
                case ConsoleKey.RightArrow:
                    userCursor.MoveXRight();
                    break;
                case ConsoleKey.LeftArrow:
                    userCursor.MoveXLeft();
                    break;
            }
        }

        private static void PrintGameInfo(int col, int row)
        {
            Console.SetCursorPosition(col, row);
            Console.WriteLine("Для завершения нажмите ESC или Ctrl+C");
        }

        private static void PrintGamerTurnStatus(int col, int row, string gameSymbol)
        {
            Console.SetCursorPosition(col, row);
            string gamer = gameSymbol == "X" ? "крестики" : "нолики";
            Console.WriteLine($"Ходит игрок: {gameSymbol} ({gamer})          ");    //  Пробелы в конце строки для затирания.
        }

        private void PrintGamingField(int col, int row, Figure[,] field)
        {
            Console.SetCursorPosition(col, row);
            PrintGrid(col, row);
            PrintField(col + 2, row + 1, field);
        }
        private void PrintGrid(int col, int row)
        {
            Console.SetCursorPosition(col, row);

            Console.WriteLine("".PadRight(this.resolution * 4, '-') + "-");

            for (int y = 0; y < this.resolution; y += 1)
            {
                Console.SetCursorPosition(col, Console.CursorTop);
                string line = "|";
                for (int x = 0; x < this.resolution; x += 1)
                {
                    line += "   |";
                }
                Console.WriteLine(line);

                Console.SetCursorPosition(col, Console.CursorTop);
                Console.WriteLine("".PadRight(this.resolution * 4, '-') + "-");
            }
        }

        private void PrintField(int col, int row, Figure[,] field)
        {
            Console.SetCursorPosition(col, row);
            int xCursorPos;
            int yCursorPos = row;

            for (int y = 0; y < resolution; y += 1)
            {
                xCursorPos = col;
                Console.SetCursorPosition(xCursorPos, yCursorPos);

                for (int x = 0; x < resolution; x += 1)
                {

                    Console.SetCursorPosition(xCursorPos, yCursorPos);
                    Console.BackgroundColor = field[x, y].BGColor;

                    if (x == userCursor.GetX() && y == userCursor.GetY())
                    {
                        Console.BackgroundColor = Console.ForegroundColor;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    Console.Write($"{field[x, y].Value}");
                    Console.ResetColor();

                    xCursorPos += 4;
                }
                yCursorPos += 2;
            }
        }

        private void PrintGameStatus(int col, int row, string gameState)
        {
            Console.SetCursorPosition(col, row);
            Console.WriteLine(gameState);
        }

        public void ChangeLineColor(Figure[] line, ConsoleColor color)
        {
            foreach (Figure fig in line)
            {
                fig.BGColor = color;
            }
        }
        #endregion

        #region Конструктор
        public IO(int resolution)
        {
            this.resolution = resolution;
            this.userCursor = new Cursor(resolution);
        }
        #endregion
    }
}
