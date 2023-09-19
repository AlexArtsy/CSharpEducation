using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    internal class WindowArea : Screen
    {
        #region Поля
        public int id;
        #endregion

        #region Свойства
        public List<Item> List { get; set; }
        #endregion

        #region Методы
        public void Render(int outerX, int outerY)
        {
            this.Clear();
            RenderVerticalList(outerX, outerY);
        }
        public void RenderVerticalList(int outerX, int outerY)
        {
            var i = 0;
            this.List.ForEach((l) =>
            {
                l.Render(this.XStartRenderingPosition + outerX, this.YStartRenderingPosition + outerY);
                i += 1;
            });
        }
        #endregion

        #region Делегаты и события
        public delegate void WindowsAreaHandler(State state);
        public event WindowsAreaHandler ListUpdated;
        #endregion

        #region Конструкторы
        public WindowArea(int id, int x, int y, int width = 30, int height = 20) : base(id, x, y, width, height)
        {
            this.id = id;
            this.List = new List<Item>();
        }
        #endregion
    }
}
