using System;
using System.IO;

namespace Task2
{
    public class IO
    {
        #region Поля и свойства
        private Game game;
        private Cursor userCursor;
        private int row = 0;
        private int col = 0;
        private int xUserCoursorPos = 0;
        private int yUserCoursorPos = 0;
        #endregion

        #region Методы
        public void Render()
        {
            Console.Clear();
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

            Render();
        }

        private void PrintGrid()
        {
            Console.SetCursorPosition(col, row);

            string grid = "".PadRight(resolution * 4, '-') + "-\n";

            for (int i = 0; i < resolution; i += 1)
            {
                grid += "|";
                for (int j = 0; j < resolution; j += 1)
                {
                    grid += "   |";
                }
                grid += "\n".PadRight(resolution * 4, '-') + "--\n"; ;

            }
            Console.WriteLine(grid);
            

            this.row = Console.CursorTop();
        }


        #endregion

        #region Конструктор
        public IO(Game game, int resolution)
        {
            this.game = game;
            this.userCursor = new Cursor(resolution);
        }
        #endregion
    }
}
