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
        public void KeyEventListener(Menu menu, RenderProcessor render)
        {
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
                    menu.SelectedItem.Do(State);
                    break;
                case ConsoleKey.Backspace:
                    if (render.startScreenSelected)
                    {
                        State.searchData = State.searchData.Length == 0 
                            ? "" 
                            : State.searchData.Substring(0, State.searchData.Length - 1);
                    }
                    else if (render.subscriberScreenSelected)
                    {
                        State.newPhoneNumber = State.newPhoneNumber.Length == 0
                            ? ""
                            : State.newPhoneNumber.Substring(0, State.newPhoneNumber.Length - 1);
                    }
                    break;
                default:
                    if (render.startScreenSelected)
                    {
                        State.searchData += pressedKey.KeyChar;
                    }
                    else if (render.subscriberScreenSelected)
                    {
                        State.newPhoneNumber += pressedKey.KeyChar;
                    }
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
