using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    internal class Window : Screen
    {
        #region Поля
        #endregion

        #region Свойства
        public List<Menu> MenuList { get; set; }
        public List<WindowArea> Areas { get; set; }
        public List<InputArea> Inputs { get; set; }
        #endregion

        #region Методы

        public void Render()
        {
            if (this.IsSelected)
            {
                this.Areas.ForEach((a) => a.Render());
                this.Inputs.ForEach((i) => i.Render());
                this.MenuList.ForEach((m) => m.Render(this.XStartRenderingPosition, this.YStartRenderingPosition));
            }
        }
        #endregion

        #region Конструкторы
        public Window(int id, int x, int y) : base(id, x, y, Console.WindowWidth, Console.WindowHeight)
        {
            this.MenuList = new List<Menu>();
            this.Areas = new List<WindowArea>();
            this.Inputs = new List<InputArea>();
        }
        #endregion
    }
}
