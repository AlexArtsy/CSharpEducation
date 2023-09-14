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
            if (startScreenSelected)
            {
                RenderMenu(State.StartMenu);
                RenderUserSearchPanel();
                RenderPhoneNumberPanel();
                Console.SetCursorPosition("Абонент: ".Length + State.searchData.Length, 3);
            }
            else if (subscriberScreenSelected)
            {
                RenderMenu(State.SubscriberMenu);
                RenderSubscriberDataPanel();
                RenderPhoneNumberPanel(); 
                // Console.SetCursorPosition("Новый номер телефона: ".Length + State.newPhoneNumber.Length, 4);
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
        public void RenderDeleteALLUserScreen()
        {
            Console.Clear();
            var question = "Вы уверены? Точно удалить всех абонентов (Y/N) ";
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
            var xStartPosition = 0;
            var yStartPosition = 3;
            ClearArea(xStartPosition, yStartPosition, 50, 20);
            Console.Write($"Абонент: ");
            if (State.SelectedSubscriber.Name == State.searchData)
            {
                Console.BackgroundColor = ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.Write(State.searchData);
            Console.ResetColor();

            var i = 4;
            State.SuitableSubscribers.ForEach((subscriber) =>
            {
                Console.SetCursorPosition("Абонент: ".Length, i);
                Console.WriteLine(subscriber.Name);
                i += 1;
            });

            Console.SetCursorPosition("Абонент: ".Length + State.searchData.Length, 3);
        }
        public void RenderSubscriberDataPanel()
        {
            var xStartPosition = 3;
            var yStartPosition = 3;
            ClearArea(xStartPosition, yStartPosition, 50, 20);

            Console.WriteLine($"         Абонент: {State.SelectedSubscriber.Name}");
            Console.Write("Новый номер телефона: ");
            if (!State.isNewPhoneNumberCorrect)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;
            }
            RenderNewPhoneNumberInputArea(22, 4, State.newPhoneNumber);
            Console.ResetColor();

            
        }
        public void RenderPhoneNumberPanel()
        {
            var xStartPosition = 51;
            var yStartPosition = 3;
            ClearArea(xStartPosition, yStartPosition, 50, 20);

            var i = yStartPosition;
            State.SelectedSubscriber.PhoneNumberList.ForEach((number) =>
            {
                Console.SetCursorPosition(xStartPosition, i);
                Console.Write(number);
                i += 1;
            });
        }
        public void RenderNewPhoneNumberInputArea(int x, int y, string number)
        {
            ClearArea(x, y, 50, 1);
            Console.Write(number);
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
