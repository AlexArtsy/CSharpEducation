﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    internal class Item : Screen
    {
        #region Свойства
        public string Value { get; set; }
        #endregion

        #region Методы
        public void Render(int outerX, int outerY)
        {
            Console.SetCursorPosition(outerX + this.XStartRenderingPosition, outerY + this.YStartRenderingPosition);
            Console.BackgroundColor = this.BackgroundColor;
            Console.ForegroundColor = this.Color;

            if (this.isSelected)
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
            }

            Console.Write(this.Value);
            Console.ResetColor();
        }
        #endregion

        #region Конструкторы
        public Item(int id,string value, int x, int y, int width) : base(id, x, y, width, 1)
        {
            this.Value = value;
        }
        #endregion
    }
}
