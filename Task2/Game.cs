using System;

public class Game
{
    #region Поля и свойства
    private int resolution;
    private string[,] state = new string[resolution, resolution];
    #endregion
    #region Конструктор
    public Game(int resolution)
	{
        this.resolution = resolution;
        this.state = CreateGameState();
    }
    #endregion
    #region Методы
    private string[,] CreateGameState()
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
    #endregion
}
