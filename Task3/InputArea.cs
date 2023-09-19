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
        public bool isCorrect = true;
        #endregion

        #region Свойства
        public State State { get; set; }
        #endregion

        #region Методы
        public void Render(int outerX, int outerY)
        {
            //this.State.InputData = this.Value; //   перенести!
            this.Clear();
            var x = outerX + this.XStartRenderingPosition;
            var y = outerY + this.YStartRenderingPosition;
            Console.SetCursorPosition(x, y);

            if (this.isCorrect)
            {
                this.BackgroundColor = ConsoleColor.Red;
            }
            else
            {
                this.BackgroundColor = ConsoleColor.Black;
            }

            Console.BackgroundColor = this.BackgroundColor;
            Console.ForegroundColor = this.Color;

            if (this.isSelected)
            {
                Console.WriteLine(this.Value);
                //Console.BackgroundColor = ConsoleColor.White;
                //Console.ForegroundColor = ConsoleColor.Black;
            }
            Console.ResetColor();
            Console.SetCursorPosition(x + this.Value.Length, y);
            UpdateCurrentCursorPosition();
        }
        public void UpdateCurrentCursorPosition()
        {
            this.currentX = Console.CursorLeft;
            this.currentY = Console.CursorTop;
        }
        #endregion

        #region Конструкторы
        public InputArea(int id, int x, int y, int width = 30) : base(id, "", x, y, width)
        {
            
        }
        #endregion
    }
}
