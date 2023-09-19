using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    internal class Screen
    {
        #region Поля
        public bool isSelected = false;
        public int currentX;
        public int currentY;
        #endregion

        #region Свойства
        public DoAction Do { get; set; }
        public int XStartRenderingPosition { get; set; }
        public int YStartRenderingPosition { get; set; }
        public int Id { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public ConsoleColor Color { get; set; }
        public ConsoleColor BackgroundColor { get; set; }
        #endregion

        #region Методы
        public void Clear()
        {
            var height = this.Height < Console.WindowHeight ? this.Height : Console.WindowHeight;
            for (int i = 0; i < this.Height; i += 1)
            {
                Console.SetCursorPosition(this.XStartRenderingPosition, this.YStartRenderingPosition + i);
                Console.Write(new String(' ', this.Width));
            }
        }
        #endregion

        #region Делегаты и события
        public delegate void DoAction();
        #endregion
        #region Конструкторы
        public Screen(int id, int x, int y, int width, int height)
        {
            this.Id = id;
            this.XStartRenderingPosition = x;
            this.YStartRenderingPosition = y;
            this.Width = width;
            this.Height = height;
            this.BackgroundColor = ConsoleColor.Black;
            this.Color = ConsoleColor.White;
        }
        #endregion
    }
}
