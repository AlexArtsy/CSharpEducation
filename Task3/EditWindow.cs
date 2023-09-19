﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    internal class EditWindow : Window
    {
        #region Поля
        #endregion
        #region Свойства
        #endregion

        #region Методы

        public void RenderWindow(State state)
        {
            RenderCustomComponents();
            UpdatePhoneNumberList(state);
            this.Render(state);
        }
        public void RenderCustomComponents()
        {

        }

        public void UpdatePhoneNumberList(State state)
        {
            var itemList = new List<Item>();
            var i = 0;
            state.SelectedSubscriber.PhoneNumberList.ForEach(n =>
            {
                itemList.Add(new Item(i, n, this.XStartRenderingPosition, this.YStartRenderingPosition + i, this.Width));
                i += 1;
            });
            this.Areas[0].List = itemList;
        }
        #endregion

        #region Конструкторы
        public EditWindow(State state) : base(1, 0, 0)
        {
            string[] editMenuItems = { "Назад", "Добавить номер", "Изменить номер", "Удалить номер", "Удалить все" };
            Menu menu = new Menu(0, editMenuItems);
            this.MenuList.Add(menu);
            this.Areas.Add(new WindowArea(0, 50, 5));
            this.Inputs.Add(new InputArea(0,  50, 4));
            UpdatePhoneNumberList(state);
            this.Areas[0].isSelected = true;
            this.Inputs[0].isSelected = true;
            this.MenuList[0].isSelected = true;
            this.MenuList[0].Items[0].isSelected = true;
        }
        #endregion
    }
}