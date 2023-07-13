﻿namespace Task2
{
    public class Figure
    {
        public ConsoleColor Color { get; set; }
        public ConsoleColor BackgroundColor { get; set; }

        public bool Initialized { get; set; }

        public int X { get; set; }

        public int Y { get; set; }

        public string Value { get; set; }

        public Figure(int x, int y, string value)
        {
            X = x;
            Y = y;
            Value = value;
            Color = ConsoleColor.White;
            BackgroundColor = ConsoleColor.Black;
            Initialized = false;
        }
    }
}
