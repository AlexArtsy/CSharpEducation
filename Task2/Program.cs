namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int resolution = 3;
            string[,] state = CreateGameField(resolution);
            int row = Console.CursorTop;
            int col = Console.CursorLeft;
            int x = 0;
            int y = 0;
            
            while (true)    //  Event loop
            {
                Render(state, y, x, resolution);
                Console.Write($"x: {x} y: {y}");

                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.DownArrow:
                        y = MoveYDown(y, resolution);
                        break;
                    case ConsoleKey.UpArrow:
                        y = MoveYUp(y, resolution);
                        break;
                    case ConsoleKey.RightArrow:
                        x = MoveXRight(x, resolution);
                        break;
                    case ConsoleKey.LeftArrow:
                        x = MoveXLeft(x, resolution);
                        break;
                }
            }
        }
        private static void Render(string[,] state, int row, int col, int resolution)
        {
            Console.SetCursorPosition(0, 0);

            for (int i = 0; i < resolution; i += 1)
            {
                for (int j = 0; j < resolution; j += 1)
                {
                    if (i == row && j == col)
                    {
                        Console.BackgroundColor = Console.ForegroundColor;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    Console.Write(state[i,j]);
                    Console.ResetColor();
                }
                Console.Write("\n");
            }
        }
        private static string[,] CreateGameField(int resolution)
        {
            string[,] field = new string[resolution, resolution]; 
            for (int i = 0; i < resolution; i += 1)
            {
                for (int j = 0; j < resolution; j += 1)
                {
                    field[i, j] = "U";
                }
            }
            return field;
        }
        private static int MoveXRight(int x, int resoluton) => x < resoluton - 1 ? (x + 1) : 0;
        private static int MoveXLeft(int x, int resoluton) => x = x >= 1 ? (x - 1) : resoluton - 1;
        private static int MoveYDown(int y, int resoluton) => y < resoluton - 1 ? (y + 1) : 0;
        private static int MoveYUp(int y, int resoluton) => y >= 1 ? (y - 1) : resoluton - 1;

    }
}