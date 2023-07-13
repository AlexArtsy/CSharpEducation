namespace Task2
{
    internal interface ITicTacToePlaying
    {
        public string GameSymbol { get; }
        public KeyBoardControl Input { get; set; }
        public bool IsPlayerWin { get; set; }
        public Figure SelectFieldCell(Figure[,] field, out bool validation);
    }
}
