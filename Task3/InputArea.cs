using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    internal class InputArea : Item
    {
        #region Поля
        public int id;
        #endregion

        #region Свойства
        public string Value { get; set; }
        #endregion

        #region Методы
        public void Render()
        {

        }
        #endregion

        #region Конструкторы
        public InputArea(int id, string value, int x, int y, int width) : base(id, value, x, y, width)
        {
            this.id = id;
            this.Value = value;
        }
        #endregion
    }
}
