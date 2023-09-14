using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    internal class Item : Screen
    {
        public delegate void DoAction(State state);
        #region Поля
        #endregion

        #region Свойства
        public string Name { get; set; }
        public DoAction Do { get; set; }
        #endregion

        #region Методы
        #endregion

        #region Конструкторы
        public Item(int id,string name, int x, int y, int width) : base(id, x, y, width, 1)
        {
            this.Name = name;
        }
        #endregion
    }
}
