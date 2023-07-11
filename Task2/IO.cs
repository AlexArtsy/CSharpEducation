using System;
using System.IO;

namespace Task2
{
    public class IO
    {
        #region Поля и свойства
        private int resolution;
        private Cursor userCursor;
        private int row = 0;
        private int col = 0;
        private int xUserCoursorPos = 0;
        private int yUserCoursorPos = 0;

        public Cursor UserCursor { get { return userCursor; } }
        #endregion

        #region Методы
        public void Render(GameField field, List<Combination> model)
        {
            PrintGrid(0, 0);
            PrintGameField(2, 1, field);
            PrintModel(0, 15, model);
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

        private void PrintGrid(int col, int row)
        {
            Console.SetCursorPosition(col, row);

            string grid = "".PadRight(this.resolution * 4, '-') + "-\n";

            for (int y = 0; y < this.resolution; y += 1)
            {
                grid += "|";
                for (int x = 0; x < this.resolution; x += 1)
                {
                    grid += "   |";
                }
                grid += "\n".PadRight(this.resolution * 4, '-') + "--\n";
            }
            Console.WriteLine(grid);
        }

        private void PrintGameField(int col, int row, GameField gameField)
        {
            Console.SetCursorPosition(col, row);
            Figure[,] field = gameField.GetField();
            int xCursorPos;
            int yCursorPos = row;

            for (int y = 0; y < resolution; y += 1)
            {
                xCursorPos = col;
                Console.SetCursorPosition(xCursorPos, yCursorPos);

                for (int x = 0; x < resolution; x += 1)
                {

                    Console.SetCursorPosition(xCursorPos, yCursorPos);

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

        private void PrintModel(int col, int row, List<Combination> model)  /////////////////////////////////////////////////////
        {
            Console.SetCursorPosition(col, row);

            foreach(Combination line in model)
            {
                foreach(Figure fig in line.Line)
                {
                    Console.Write($"{fig.Value} ");
                }
                Console.WriteLine("\n");
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
