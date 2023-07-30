namespace Task2
{
    public class KeyBoardControl
    {
        #region Поля и свойсва
        public Cursor UserCursor { get; set; }
        #endregion

        #region Методы
        public void MoveCursor(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.DownArrow:
                    UserCursor.MoveYDown();
                    break;
                case ConsoleKey.UpArrow:
                    UserCursor.MoveYUp();
                    break;
                case ConsoleKey.RightArrow:
                    UserCursor.MoveXRight();
                    break;
                case ConsoleKey.LeftArrow:
                    UserCursor.MoveXLeft();
                    break;
            }
        }
        #endregion

        #region Конструкторы
        public KeyBoardControl(int resolution)
        {
            UserCursor = new Cursor(resolution);
        }
        #endregion
    }
}