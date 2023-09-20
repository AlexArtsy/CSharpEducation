using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    internal class MainWindow : Window
    {
        #region Поля
        #endregion
        #region Свойства
        #endregion

        #region Методы

        public void RenderWindow(State state)
        {
            Console.Clear();
            RenderCustomComponents();
            this.Render(state);
        }
        public void RenderCustomComponents()
        {
            Console.SetCursorPosition(3, 3);
            Console.Write("Поиск: ");
            Console.SetCursorPosition(42, 3);
            Console.Write("Номера телефонов: ");
        }
        public void UpdateSelectedAreas(WindowArea area, State state)
        {
            this.Areas.ForEach(a => a.isSelected = false);
            area.isSelected = true;
            this.UpdateSelectedElements();
        }
        public void UpdateSubscriberList(State state)
        {
            UpdateSelectedAreas(this.Areas[0], state);

            var itemList = new List<Item>();
            var i = 0;
            state.SuitableSubscribers.ForEach(s =>
            {
                var newItem = new Item(i, s.Name, this.XStartRenderingPosition, this.YStartRenderingPosition + i, this.Width);
                newItem.isSelected = s.Name == state.SelectedSubscriber.Name;
                itemList.Add(newItem);
                i += 1;
            });
            this.Areas[0].List = itemList;
        }
        public void UpdatePhoneNumberList(State state)
        {
            UpdateSelectedAreas(this.Areas[1], state);

            var itemList = new List<Item>();
            var i = 0;
            state.SelectedSubscriber.PhoneNumberList.ForEach(n =>
            {
                itemList.Add(new Item(i, n, this.XStartRenderingPosition, this.YStartRenderingPosition + i, this.Width));
                i += 1;
            });
            this.Areas[1].List = itemList;
        }
        #endregion

        #region Конструкторы
        public MainWindow(State state) : base(0, 0, 0)
        {
            string[] mainMenuItems = { "Добавить", "Изменить", "Удалить", "Удалить всех" };
            Menu menu = new Menu(0, mainMenuItems);
            menu.isSelected = true;
            this.MenuList.Add(menu);
            this.Areas.Add(new WindowArea(0, 10, 4));
            this.Areas.Add(new WindowArea(1, 60, 3));
            this.Inputs.Add(new InputArea(0, 10,3));
            this.Areas[0].isSelected = true;
            this.Areas[1].isSelected = true;
            this.Inputs[0].isSelected = true;
            this.isSelected = true;

            UpdateSubscriberList(state);
            UpdatePhoneNumberList(state);
        }
        #endregion
    }
}
