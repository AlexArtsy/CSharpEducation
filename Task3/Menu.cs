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
    internal class Menu
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
            this.SelectedItem.IsSelected = false;
            this.SelectedItem = this.Items[id];
            this.SelectedItem.IsSelected = true;
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
            this.Items.ForEach((item) => item.Render(outerX, outerY));
        }
        #endregion

        #region Конструкторы
        public Menu(string[] itemsNames)
        {
            this.Items = new List<Item>();
            int itemWidth = itemsNames.OrderByDescending(n => n.Length).First().Length + 3;

            for (int i = 0; i < itemsNames.Length; i += 1)
            {
                this.Items.Add(new Item(i, itemsNames[i],  1 + i * itemWidth, 0, itemWidth));
            }
            this.SelectedItem = Items[0];
            SetItem(0);

        }
        #endregion
    }
}
