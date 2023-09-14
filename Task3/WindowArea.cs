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
       // public string Value { get; set; }
        #endregion

        #region Методы
        public void Render()
        {

        }
        public void RenderVerticalList(int x, int y, List<Item> list)
        {
            var i = 0;
            list.ForEach((l) =>
            {
                l.Render(x, y + i);
                i += 1;
            });
        }
        public void RenderHorizontalList(int x, int y, List<Item> list)
        {
            int i = 0;
            //var list = new List<Item>();
            //subscribers.ForEach((s) =>
            //{
            //    list.Add(new Item(i, s.Name, x, y + i, 50));
            //    i += 1;
            //});
            int itemWidth = list.Max((l) => l.Name.Length) + 3;
            list.ForEach((l) =>
            {
                l.Render(x + i * itemWidth, y);
                i += 1;
            });
        }
        #endregion

        #region Конструкторы
        public WindowArea(int id, int x, int y, int width, int height) : base(id, x, y, width, height)
        {
            this.id = id;
        }
        #endregion
    }
}
