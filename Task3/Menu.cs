using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    internal class Menu : Screen
    {
        #region Поля
        #endregion

        #region Свойства
        public List<Item> Items { get; set; }
        public Item SelectedItem { get; set; }
        #endregion

        #region Методы
        public void SetItem(int id)
        {
            this.SelectedItem.isSelected = false;
            this.SelectedItem = this.Items[id];
            this.SelectedItem.isSelected = true;
        }
        public void SelectItemLeft()
        {
            var newId = this.SelectedItem.Id == 0 ? this.Items.Count - 1 : (this.SelectedItem.Id - 1);
            SetItem(newId);
        }
        public void SelectItemRight()
        {
            var newId = this.SelectedItem.Id == this.Items.Count - 1 ? 0 : (this.SelectedItem.Id + 1);
            SetItem(newId);
        }
        public void Render(int outerX, int outerY)
        {
            this.Clear();
            this.Items.ForEach((item) => item.Render(outerX, outerY));
        }
        #endregion

        #region Конструкторы

        public Menu(int id, string[] itemsNames) : base(id, 0, 0, Console.WindowWidth, 1)
        {
            this.Items = new List<Item>();
            var xStartPosition = 0;
            for (int i = 0; i < itemsNames.Length; i += 1)
            {
                var width = itemsNames[i].Length + 3;
                this.Items.Add(new Item(i, itemsNames[i], xStartPosition, 0, width));
                xStartPosition += width;
            }

            this.SelectedItem = Items[0];
            SetItem(0);

        }

        #endregion
    }
}
