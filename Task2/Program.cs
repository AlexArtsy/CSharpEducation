namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int resolution = 6;
            string initSymbol = "U";
            string[,] state = CreateGameState(resolution, initSymbol);
            int row = Console.CursorTop;
            int col = Console.CursorLeft;
            int x = 0;
            int y = 0;
            bool gamerSwitch = true;
            string gameSymbol = "X";

            Console.WriteLine("Для завершения нажмите ESC или Ctrl+C");

            while (true)    //  Event loop 
            {
                PrintGamerTurnStatus(col: 0, row: 3, gameSymbol);

                Render(col: 5, row: 5, state, y, x, resolution);

                Console.Write($"x: {x} y: {y}");

                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.Escape:
                        return;
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
                    case ConsoleKey.Enter:
                        if (state[y, x] == initSymbol)  //  проверяем, сделан ли ход в выбранной ячейке 
                        {
                            state[y, x] = gameSymbol;
                            gameSymbol = gamerSwitch ? "O" : "X";
                            gamerSwitch = !gamerSwitch;
                        }
                        break;
                }
            }
        }
        private static void Render(int col, int row, string[,] state, int x, int y, int resolution = 3)
        {


            for (int i = 0; i < resolution; i += 1)
            {
                Console.SetCursorPosition(col, row + i);
                for (int j = 0; j < resolution; j += 1)
                {
                    Console.SetCursorPosition(col + j, row + i);
                    if (i == x && j == y)
                    {
                        Console.BackgroundColor = Console.ForegroundColor;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    Console.Write($"{state[i, j]}");
                    Console.ResetColor();
                }
                //Console.Write("\n");
                Console.WriteLine("\n");
            }
        }
        private static void PrintGamerTurnStatus(int col, int row, string gameSymbol)
        {
            Console.SetCursorPosition(col, row);
            string gamer = gameSymbol == "X" ? "крестики" : "нолики";
            Console.WriteLine($"Ходит игрок: {gameSymbol} ({gamer})          ");
        }
        private static string[,] CreateGameState(int resolution, string initSymbol)
        {
            string[,] field = new string[resolution, resolution]; 
            for (int i = 0; i < resolution; i += 1)
            {
                for (int j = 0; j < resolution; j += 1)
                {
                    field[i, j] = initSymbol;
                }
            }
            return field;
        }
        private static int MoveXRight(int x, int resoluton) => x < resoluton - 1 ? (x + 1) : 0;
        private static int MoveXLeft(int x, int resoluton) => x >= 1 ? (x - 1) : resoluton - 1;
        private static int MoveYDown(int y, int resoluton) => y < resoluton - 1 ? (y + 1) : 0;
        private static int MoveYUp(int y, int resoluton) => y >= 1 ? (y - 1) : resoluton - 1;

    }
}