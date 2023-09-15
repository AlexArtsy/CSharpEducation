using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    internal class InputArea : Item
    {
        #region Поля
        #endregion

        #region Свойства
        public State State { get; set; }
        #endregion

        #region Методы
        public void Render(int outerX, int outerY)
        {
            this.Clear();
            var x = outerX + this.XStartRenderingPosition;
            var y = outerY + this.YStartRenderingPosition;
            Console.SetCursorPosition(x, y);
            Console.BackgroundColor = this.BackgroundColor;
            Console.ForegroundColor = this.Color;

            if (this.IsSelected)
            {
                Console.WriteLine(this.State.InputData);
                //Console.BackgroundColor = ConsoleColor.White;
                //Console.ForegroundColor = ConsoleColor.Black;
            }
            Console.ResetColor();
            Console.SetCursorPosition(x + this.State.InputData.Length, y);
        }
        #endregion

        #region Конструкторы
        public InputArea(int id, State state, int x, int y, int width) : base(id, state.InputData, x, y, width)
        {
            this.State = state;
        }
        #endregion
    }
}
