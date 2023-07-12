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
            var player1 = new Human(resolution,"X");
            var player2 = new Human(resolution,"O");
            var game = new Game(resolution, player1, player2);
            game.Start();

            Console.ReadKey();
        }
        #endregion
    }
}