using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    internal class RenderProcessor
    {
        #region Поля

        public bool startScreenSelected = true;
        public bool subscriberScreenSelected = false;

        public bool deleteUserQuestionScreenSelected = false;

        #endregion

        #region Свойства
        public State State { get; set; }
        #endregion

        #region Методы
        public void ResetAllScreenSelecting()
        {
            startScreenSelected = false;
            subscriberScreenSelected = false;
            deleteUserQuestionScreenSelected = false;
            Console.Clear();
        }
        public void UpdateScreen()
        {
           // Console.Clear();
            if (startScreenSelected)
            {
                RenderMenu(State.StartMenu);
                RenderUserSearchPanel();
            }
            else if (subscriberScreenSelected)
            {
                RenderMenu(State.SubscriberMenu);
            }
            else if (deleteUserQuestionScreenSelected)
            {

            }
        }
        public void RenderDeleteUserScreen()
        {
            Console.Clear();
            var question = "Точно удалить абонента? (Y/N) ";
            var x = Console.WindowWidth / 2 - question.Length / 2;
            var y = Console.WindowHeight / 2;
            Console.SetCursorPosition(x, y);
            Console.Write(question);
        }
        public void ClearArea(int x, int y, int width, int height)
        {
            for (int i = y; i < height; i += 1)
            {
                Console.SetCursorPosition(x, i);
                Console.Write(new string(' ', width));
            }
            Console.SetCursorPosition(x, y);
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
            Console.Write("    <-- выбирать кнопкой Enter");
            Console.WriteLine();
        }
        public void RenderUserSearchPanel()
        {
            ClearArea(0, 3, 50, 20);
            Console.WriteLine($"Абонент: {State.searchData}");

            State.SuitableSubscribers.ForEach((subscriber) =>
            {
                Console.WriteLine(subscriber.Name);
            });
            Console.SetCursorPosition("Абонент: ".Length + State.searchData.Length, 3);

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
