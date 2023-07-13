namespace Task2
{
    internal class NeuralNetwork : ITicTacToePlaying
    {
        public KeyBoardControl Input { get; set; }
        public bool IsPlayerWin { get; set; }

        public string GameSymbol { get; }

        public NeuralNetwork(string gameSymbol, KeyBoardControl input)
        {
            Input = input; 
            GameSymbol = gameSymbol;
            IsPlayerWin = false;
        }

        public Figure SelectFieldCell(Figure[,] field, out bool validation)
        {
            ConsoleKey key = Console.ReadKey(true).Key;
            validation = false;

            switch (key)
            {
                case ConsoleKey.DownArrow:
                case ConsoleKey.UpArrow:
                case ConsoleKey.RightArrow:
                case ConsoleKey.LeftArrow:
                    Input.MoveCursor(key);
                    break;
                case ConsoleKey.Enter:
                    validation = validation = !field[Input.UserCursor.GetX(), Input.UserCursor.GetY()].Initialized;
                    break;
            }

            return field[Input.UserCursor.GetX(), Input.UserCursor.GetY()];

        }
    }
}
