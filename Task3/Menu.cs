using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    internal class Menu
    {
        #region Поля
        public int selectedItemId = 1;
        public List<Item> items = new List<Item>();
        #endregion

        #region Свойства
        #endregion

        #region Методы

        public void SelectItemLeft()
        {
            this.selectedItemId = this.selectedItemId == 1 ? this.items.Count : (this.selectedItemId - 1);
        }
        public void SelectItemRight()
        {
            this.selectedItemId = this.selectedItemId == this.items.Count ? 1 : (this.selectedItemId + 1);
        }
        #endregion

        #region Конструкторы
        public Menu(string[] itemsNames)
        {
            int itemWith = itemsNames.OrderByDescending(n => n.Length).First().Length + 3;

            for (int i = 1; i <= itemsNames.Length; i += 1)
            {
                this.items.Add(new Item(i, itemsNames[i - 1],  1 + (i - 1) * itemWith, 0));
            }
        }
        #endregion
    }
}
