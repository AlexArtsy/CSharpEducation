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
        public void KeyEventListener(Window window)
        {
            var menu = window.MenuList[0];
            var pressedKey = Console.ReadKey(true);

            switch (pressedKey.Key)
            {
                case ConsoleKey.LeftArrow:
                    menu.SelectItemLeft();
                    break;
                case ConsoleKey.RightArrow:
                    menu.SelectItemRight();
                    break;
                case ConsoleKey.UpArrow:

                    break;
                case ConsoleKey.DownArrow:

                    break;
                case ConsoleKey.Enter:
                    menu.SelectedItem.Do(this.State);
                    break;
                case ConsoleKey.Backspace:
                    State.InputData = State.InputData.Length == 0 
                            ? "" 
                            : State.InputData.Substring(0, State.InputData.Length - 1);
                    window.Areas.ForEach((a) => a.Do(this.State));
                    break;
                default:
                    State.InputData += pressedKey.KeyChar;
                    window.Areas.ForEach((a) => a.Do(this.State));
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
