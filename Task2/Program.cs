namespace Task2
{
    internal class Program
    {
        #region Поля и свойства
        static int resolution = 6;
        static string[,] state = new string[resolution, resolution];
        #endregion
        #region Методы
        #region Controller
        static void Main(string[] args)
        {
            new Combination();

            state = CreateGameState();  //  Инициализируем игровое поле начальными символами " ".
            List<int[][]> gameModel = CreateGameModel();

            int x = 0;
            int y = 0;
            bool gamerSwitch = true;    //  Переключатель для смены игрока.
            string gameSymbol = "X";    //  Определяем кто из игроков ходит первым.

            int row = 0;
            int col = 0;
            PrintGameInfo(col, row);
            PrintGamingGrid(col, row + 4);  //  Рисуем игровую сетку с 4 строки.

            while (true)    //  Event loop.
            {
                PrintGamerTurnStatus(col: 0, row: 3, gameSymbol);   //  Рисуем очередь игрока с 3-й строки.

                col = Console.CursorLeft + 2;   //  Определяем где находится курсор после отрисовки игрового поля и сдвигаем координату в центр ячейки
                row = Console.CursorTop + 1;    //  Определяем где находится курсор после отрисовки игрового поля и сдвигаем на 1 строчки вниз.
                RenderGamingField(col, row, xRoundCoordinate: x, yRoundCoordinate: y);

                col = Console.CursorLeft;
                row = Console.CursorTop + 3;
                Console.SetCursorPosition(0, row);
                Console.Write($"x: {x} y: {y}");

                col = 0;
                row = Console.CursorTop + 3;
                ClearField(col, row);
                PrintState(col, row, gameModel);

                switch (Console.ReadKey(true).Key)  //  Слушаем нажатие кнопок.
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
                        if (state[y, x] == " ")  //  Проверяем, сделан ли ход в выбранной ячейке.
                        {
                            state[y, x] = gameSymbol;
                            gameSymbol = gamerSwitch ? "O" : "X";
                            gamerSwitch = !gamerSwitch;
                            gameModel = CheckGameModelState(gameModel);
                        }
                        break;
                }
            }
        }
        #endregion
        #region Model
        private static string[,] CreateGameState()
        {
            string[,] field = new string[resolution, resolution];
            for (int i = 0; i < resolution; i += 1)
            {
                for (int j = 0; j < resolution; j += 1)
                {
                    field[i, j] = " ";
                }
            }
            return field;
        }

        private static List<int[][]> CreateGameModel()
        {
            var gameModel = new List<int[][]>(resolution * 2 + 2);
            //  Заполняем нашу модель всеми строками.
            for (int i = 0; i < resolution; i += 1)
            {
                int[][] lineState = new int[resolution][];
                for (int j = 0; j < resolution; j += 1)
                {
                    lineState[j] = new int[2] { i, j };
                }
                gameModel.Add(lineState);
            }
            //  Заполняем модель всеми столбцами игрового поля.
            for (int i = 0; i < resolution; i += 1)
            {
                int[][] colState = new int[resolution][];
                for (int j = 0; j < resolution; j += 1)
                {
                    colState[j] = new int[2] { j, i };
                }
                gameModel.Add(colState);
            }
            //  Записываем главную диагональ.
            int[][] mainDiagonalState = new int[resolution][];
            for (int i = 0; i < resolution; i += 1)
            {
                mainDiagonalState[i] = new int[2] { i, i };
            }
            gameModel.Add(mainDiagonalState);
            //  Записываем в модель побочную диагональ.
            int[][] sideDiagonalState = new int[resolution][];
            int k = resolution - 1;
            for (int i = 0; i < resolution; i += 1)
            {
                sideDiagonalState[i] = new int[2] { i, k };
                k -= 1;
            }
            gameModel.Add(sideDiagonalState);

            return gameModel;
        }
        private static List<int[][]> CheckGameModelState(List<int[][]> gameModel)
        {
            List<int[][]> newModelState = gameModel;
            for (int i = 0; i < gameModel.Count; i += 1)
            {
                bool hasX = Array.Exists(GetStateLine(gameModel[i]), (symbol) => symbol == "X");
                bool hasO = Array.Exists(GetStateLine(gameModel[i]), (symbol) => symbol == "O");
                if (hasX && hasO)
                {
                    newModelState.Remove(gameModel[i]);
                }
            }
            return newModelState;
        }

        private static string[] GetStateLine(int[][] item)
        {
            string[] line = new string[resolution];
            for (int i = 0; i < resolution; i += 1)
            {
                int x = item[i][0];
                int y = item[i][1];
                line[i] = state[x, y];
            }
            return line;
        }
        #endregion
        #region View
        private static void ClearField(int col, int row)
        {
            Console.SetCursorPosition(col, row);

            for (int i = 0; i < 30; i += 1)
            {
                Console.WriteLine("                       ");
            }
        }
        /// <summary>
        /// Печатаем на экран состояние хода игры: установленные крестики и нолики (либо пустоты).
        /// </summary>
        /// <param name="col">Координата системного курсора по X</param>
        /// <param name="row">Координата системного курсора по Y</param>
        /// <param name="xRaundCoordinate">Координата пользовательского курсора по X</param>
        /// <param name="yRaundCoordinate">Координата пользовательского курсора по Y</param>
        private static void RenderGamingField(int col, int row, int xRoundCoordinate, int yRoundCoordinate)
        {
            int xCursorPos;
            int yCursorPos = row;

            for (int i = 0; i < resolution; i += 1)
            {
                xCursorPos = col;
                Console.SetCursorPosition(xCursorPos, yCursorPos);

                for (int j = 0; j < resolution; j += 1)
                {

                    Console.SetCursorPosition(xCursorPos, yCursorPos);

                    if (j == xRoundCoordinate && i == yRoundCoordinate)
                    {
                        Console.BackgroundColor = Console.ForegroundColor;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    Console.Write($"{state[i, j]}");
                    Console.ResetColor();

                    xCursorPos += 4;
                }
                yCursorPos += 2;
            }
        }

        /// <summary>
        /// Печатаем на экран красивую сетку.
        /// Магические числа нужны для корректного отображения сетки: 4 - четыре символа, заполняющие ячейку "   |" либо "----".ю
        /// </summary>
        /// <param name="col">Координата системного курсора по X</param>
        /// <param name="row">Координата системного курсора по Y</param>
        private static void PrintGamingGrid(int col, int row)   //  Понимаю, что это упоротость, но захотелось поразмять мозги.
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
        }

        private static void PrintState(int col, int row, List<int[][]> gameModel)
        {
            Console.SetCursorPosition(col, row);

            for (int i = 0; i < gameModel.Count; i += 1)
            {
                int[][] line = gameModel[i];
                for (int j = 0; j < resolution; j += 1)
                {
                    int x = line[j][0];
                    int y = line[j][1];
                    Console.Write(state[x, y]);
                }
                Console.WriteLine("\n");
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

        private static int MoveXRight(int x, int resoluton) => x < resoluton - 1 ? (x + 1) : 0;

        private static int MoveXLeft(int x, int resoluton) => x >= 1 ? (x - 1) : resoluton - 1;

        private static int MoveYDown(int y, int resoluton) => y < resoluton - 1 ? (y + 1) : 0;

        private static int MoveYUp(int y, int resoluton) => y >= 1 ? (y - 1) : resoluton - 1;
        #endregion
        #endregion
    }
}