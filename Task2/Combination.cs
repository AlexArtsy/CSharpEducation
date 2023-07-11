using System;

namespace Task2
{
    public class Combination
    {
        private Figure[] line;

        public Figure[] Line { get { return line; } }

        public Combination(Figure[] line)
        {
            this.line = line;
        }

        public bool IsWinning(string symbol)
        {
            foreach (Figure fig in this.line)
            {
                if (symbol != fig.Value)
                {
                    return false;
                }
            }
            return true;
        }

        public bool IsStandoff()
        {
            string symbol1 = "X";
            string symbol2 = "O";
            bool hasSymbol1 = false;
            bool hasSymbol2 = false;

            foreach (Figure fig in this.line)
            {
                hasSymbol1 = fig.Value == symbol1 ? true : hasSymbol1;
                hasSymbol2 = fig.Value == symbol2 ? true : hasSymbol2;
            }
            return hasSymbol1 && hasSymbol2;
        }
    }
}
