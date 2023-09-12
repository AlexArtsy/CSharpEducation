using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    internal class RenderProcessor
    {
        #region Поля
        #endregion

        #region Свойства
        public State State { get; set; }
        #endregion

        #region Методы
        public void ClearLine(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write("                                                                          ");
            Console.SetCursorPosition(x, y);
        }
        public void RenderSubscriberSearchLine()
        {
            Console.SetCursorPosition(0, 3);
            Console.Write("Абонент:");
            ClearLine(10, 3);
            //Console.Write(Program.searchData);
        }
        public void RenderItem(Item item, int selectedItemId)
        {
            Console.SetCursorPosition(item.xRenderPosition, 0);
            if (item.Id == selectedItemId)
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
            }
            Console.Write(item.Name);
            Console.ResetColor();
        }
        public void RenderMenu(Menu menu)
        {
            Console.SetCursorPosition(0, 0);
            menu.items.ForEach((item) => RenderItem(item, menu.selectedItemId));
            Console.WriteLine();
        }
        #endregion

        #region Конструкторы
        public RenderProcessor(State state)
        {
            this.State = state;
        }
        #endregion
    }
}
