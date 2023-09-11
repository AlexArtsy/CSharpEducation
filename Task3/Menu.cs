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
        private int itemValue;
        private int itemId = 1;
        private string[] itemsNames;
        #endregion

        #region Свойства
        public List<string> ItemList { get; set; }
        public List<Item> Items { get; set; }
        #endregion

        #region Методы

        public void RenderItem(Item item)
        {
            Console.SetCursorPosition(item.xRenderPosition, 0);
            if (item.Id == this.itemId)
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
            }
            Console.Write(item.Name);
            Console.ResetColor();
        }
        public void RenderMenu()
        {
            Items.ForEach(RenderItem);
            Console.WriteLine();
        }

        public void AddItem(string itemName)
        {
            ItemList.Add(itemName);
        }

        public void KeyEventListener(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.LeftArrow:
                    this.itemId = this.itemId == 1 ? this.itemValue : this.itemId - 1;
                    RenderMenu();
                    break;
                case ConsoleKey.RightArrow:
                    this.itemId = this.itemId == this.itemValue ? 1 : this.itemId + 1;
                    RenderMenu();
                    break;
            }
        } 
        #endregion

        #region Конструкторы
        public Menu(string[] itemsNames)
        {
            this.itemValue = itemsNames.Length;
            this.itemsNames = itemsNames;

            Items = new List<Item>();
            int itemWith = this.itemsNames.OrderByDescending(n => n.Length).First().Length + 3;
            for (int i = 1; i <= this.itemValue; i += 1)
            {
                Items.Add(new Item(i, itemsNames[i - 1],  1 + (i - 1) * itemWith, 0));
            }
        }
        #endregion
    }
}
