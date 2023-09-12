using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    internal class Item
    {
        public delegate void DoAction(State state);
        #region Поля
        public bool isSelected = false;
        public int xRenderPosition;
        public int yRenderPosition;
        #endregion

        #region Свойства
        public int Id { get; set; }
        public string Name { get; set; }
        public DoAction Do { get; set; }
        #endregion

        #region Методы

        #endregion

        #region Конструкторы
        public Item(int id, string name, int xRenderPosition, int yRenderPosition)
        {
            this.Id = id;
            this.Name = name;
            this.xRenderPosition = xRenderPosition;
            this.yRenderPosition = yRenderPosition;
        }
        #endregion
    }
}
