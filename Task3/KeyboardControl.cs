using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    internal class KeyboardControl
    {
        #region Поля
        #endregion

        #region Свойства
        public State State { get; set; }
        #endregion

        #region Методы
        public void KeyEventListener(Menu menu)
        {
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.LeftArrow:
                    menu.SelectItemLeft();
                    break;
                case ConsoleKey.RightArrow:
                    menu.SelectItemRight();
                    break;
                case ConsoleKey.Backspace:
                    //Program.searchData = Program.searchData.Substring(0, Program.searchData.Length - 2);
                    //RenderSearchLine();
                    break;
                default:
                    //Program.searchData += Console.ReadKey().KeyChar;
                    //RenderSearchLine();
                    break;
            }
        }
        #endregion

        #region Конструкторы
        public KeyboardControl(State state)
        {
            this.State = state;
        }
        #endregion
    }
}
