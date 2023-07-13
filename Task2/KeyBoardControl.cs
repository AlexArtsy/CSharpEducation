namespace Task2;

public class KeyBoardControl
{
    public Cursor UserCursor { get; set; }

    public KeyBoardControl(int resolution)
    {
        UserCursor = new Cursor(resolution);
    }
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
}