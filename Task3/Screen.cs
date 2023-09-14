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
        #endregion

        #region Свойства
        public int XStartRenderingPosition { get; set; }
        public int YStartRenderingPosition { get; set; }
        public int Id { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public bool IsSelected { get; set; }
        public ConsoleColor Color { get; set; }
        public ConsoleColor BackgroundColor { get; set; }
        //  public List<Item> Items { get; set; }
        #endregion

        #region Методы
        #endregion

        #region Конструкторы
        public Screen(int id, int x, int y, int width, int height)
        {
            this.Id = id;
            this.XStartRenderingPosition = x;
            this.YStartRenderingPosition = y;
            this.Width = width;
            this.Height = height;
            this.IsSelected = false;
            this.BackgroundColor = ConsoleColor.Black;
            this.Color = ConsoleColor.White;
        }
        #endregion
    }
}
