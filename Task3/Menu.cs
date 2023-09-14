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
        #endregion

        #region Свойства
        public List<Item> Items { get; set; }
        public Item SelectedItem { get; set; }
        #endregion

        #region Методы
        private void ResetItem()
        {
            this.Items.ForEach((i) => i.IsSelected = false);
        }
        public void SetItem(int id)
        {
            ResetItem();
            this.SelectedItem = this.Items[id];
            this.SelectedItem.IsSelected = true;
        }
        private int GetCurrentItemId()
        {
            return this.Items.Find((i) => i.IsSelected == true).Id;
        }
        public void SelectItemLeft()
        {
            var currentId = GetCurrentItemId();
            var newId = currentId == 0 ? this.Items.Count : (currentId - 1);
            SetItem(newId);
        }
        public void SelectItemRight()
        {
            var currentId = GetCurrentItemId();
            var newId = currentId == this.Items.Count ? 0 : (currentId + 1);
            SetItem(newId);
        }
        public void Render(int outerX, int outerY)
        {
            this.Items.ForEach((item) => item.Render(outerX, outerY));
            Console.Write("    <-- выбирать кнопкой Enter");
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
            this.SelectedItem = this.Items[0];
        }
        #endregion
    }
}
