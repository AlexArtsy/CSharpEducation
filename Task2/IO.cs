using System;

public class Render
{
    #region Поля и свойства
    private Game game;
    #endregion

    #region Методы
    private static void UpdateGameField()
    {
        Console.Clear();
    }

    /// <summary>
    /// Печатаем на экран состояние хода игры: установленные крестики и нолики (либо пустоты).
    /// </summary>
    /// <param name="col">Координата системного курсора по X</param>
    /// <param name="row">Координата системного курсора по Y</param>
    /// <param name="xRaundCoordinate">Координата пользовательского курсора по X</param>
    /// <param name="yRaundCoordinate">Координата пользовательского курсора по Y</param>
    private void RenderGamingField(int col, int row, int xRoundCoordinate, int yRoundCoordinate)
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
    private void PrintGamingGrid(int col, int row)   //  Понимаю, что это упоротость, но захотелось поразмять мозги.
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

    private void PrintState(int col, int row, List<int[][]> gameModel)
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

    private void PrintGameInfo(int col, int row)
    {
        Console.SetCursorPosition(col, row);
        Console.WriteLine("Для завершения нажмите ESC или Ctrl+C");
    }

    private void PrintGamerTurnStatus(int col, int row, string gameSymbol)
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

    #region Конструктор
    public Render(Game game)
	{
        this.game = game;
	}
    #endregion
}
