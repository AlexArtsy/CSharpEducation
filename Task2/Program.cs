namespace Task2
{
    internal class Program
    {
        #region Поля и свойства
        static int resolution = 4;
        #endregion

        #region Методы
        static void Main(string[] args)
        {
            var isFinnished = false;

            while(!isFinnished)
            {
                var control = new KeyBoardControl(resolution);
                var player1 = new Human("X", control);
                var player2 = new Human("O", control);
                var game = new Game(resolution, player1, player2);
                game.Start();

                Console.WriteLine("Игра завершена!");
                Console.WriteLine("Хотите сиграть еще раз - нажмите Enter, для выхода нажмите ESC");

                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.Enter:
                        Console.Clear();
                        break;
                    case ConsoleKey.Escape:
                        isFinnished = true;
                        break;
                }
            }
        }
        #endregion
    }
}