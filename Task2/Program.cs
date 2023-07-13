namespace Task2
{
    internal class Program
    {
        #region Поля и свойства
        static int resolution = 6;
        #endregion

        #region Методы
        static void Main(string[] args)
        {
            var control = new KeyBoardControl(resolution);
            var player1 = new Human("X", control);
            var player2 = new NeuralNetwork("O", control);
            var game = new Game(resolution, player1, player2);
            game.Start();

            Console.ReadKey();
        }
        #endregion
    }
}