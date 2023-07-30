namespace Task2
{
    internal class RenderProcessor
    {
        #region Поля и свойства
        private int resolution;

        #endregion

        #region Методы
        public void Render(Game game, ITicTacToePlaying player)
        {
            PrintGameInfo(col: 0, row: 0);
            PrintGamerTurnStatus(col: 0, row: Console.CursorTop + 1, player.GameSymbol);
            PrintGamingField(col: 5, row: Console.CursorTop + 1, game.Field, player.Input);
            PrintGameStatus(col: 0, row: Console.CursorTop + 3, game.State, player);
        }

        private static void PrintGameInfo(int col, int row)
        {
            Console.SetCursorPosition(col, row);
            Console.WriteLine("Для завершения нажмите Ctrl+C");
        }

        private static void PrintGamerTurnStatus(int col, int row, string gameSymbol)
        {
            Console.SetCursorPosition(col, row);
            var gamer = gameSymbol == "X" ? "крестики" : "нолики";
            Console.WriteLine($"Ходит игрок: {gameSymbol} ({gamer})          ");    //  Пробелы в конце строки для затирания.
        }

        public void PrintGamingField(int col, int row, Figure[,] field, KeyBoardControl input)
        {
            Console.SetCursorPosition(col, row);
            PrintGrid(col, row);
            PrintField(col + 2, row + 1, field, input);
        }
        private void PrintGrid(int col, int row)
        {
            Console.SetCursorPosition(col, row);

            Console.WriteLine("".PadRight(this.resolution * 4, '-') + "-");

            for (var y = 0; y < this.resolution; y += 1)
            {
                Console.SetCursorPosition(col, Console.CursorTop);
                string line = "|";
                for (var x = 0; x < this.resolution; x += 1)
                {
                    line += "   |";
                }
                Console.WriteLine(line);

                Console.SetCursorPosition(col, Console.CursorTop);
                Console.WriteLine("".PadRight(this.resolution * 4, '-') + "-");
            }
        }

        private void PrintField(int col, int row, Figure[,] field, KeyBoardControl input)
        {
            Console.SetCursorPosition(col, row);

            var yCursorPos = row;

            for (var y = 0; y < resolution; y += 1)
            {
                var xCursorPos = col;
                Console.SetCursorPosition(xCursorPos, yCursorPos);

                for (var x = 0; x < resolution; x += 1)
                {
                    Console.SetCursorPosition(xCursorPos, yCursorPos);
                    Console.BackgroundColor = field[x, y].BackgroundColor;

                    if (x == input.UserCursor.GetX() && y == input.UserCursor.GetY())
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

        private void PrintGameStatus(int col, int row, string gameState, ITicTacToePlaying player)
        {
            Console.SetCursorPosition(col, row);
            var text = "Статус игры:";
            switch(gameState)
            {
                case "running":
                    Console.WriteLine($"{text} игра продолжается");
                    break;
                case "standoff":
                    Console.WriteLine($"{text} ничья!                 ");
                     break;
                case "completed":
                    Console.WriteLine($"{text} игра завершена, победил игрок: {player.GameSymbol}");
                    break;
            }
        }

        public void ChangeLineColor(Figure[] line, ConsoleColor color)
        {
            foreach (Figure fig in line)
            {
                fig.BackgroundColor = color;
            }
        }
        #endregion

        #region Конструктор
        public RenderProcessor(int resolution)
        {
            this.resolution = resolution;
        }
        #endregion
    }
}
