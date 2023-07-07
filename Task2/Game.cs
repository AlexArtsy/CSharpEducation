using System;

public class Game
{
    #region Поля и свойства
    private int resolution;
    private string[,] state = new string[resolution, resolution];
    private GameField field;
    #endregion
    #region Конструктор
    public Game(int resolution)
	{
        this.resolution = resolution;
        this field = new GameField();
        this.state = CreateGameState();
    }
    #endregion
    #region Методы
    public GameField GetField() 
    { 
        return field; 
    }  

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
