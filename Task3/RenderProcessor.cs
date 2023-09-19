using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    internal class RenderProcessor
    {
        #region Поля
        private readonly State state;
        #endregion

        #region Свойства
        #endregion

        #region Методы
        private void CheckChanges(Window window)
        {
            window.Areas.ForEach((area) =>
            {

            });
        }

        public void Render(Window window)
        {
            window.Render(state);
        } 

        #endregion

        #region Конструкторы
        public RenderProcessor(State state)
        {
            this.state = state;


        }
        #endregion
    }
}
