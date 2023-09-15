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
        private Window savedMainWindow;
        private Window savedSettingsWindow;
        #endregion

        #region Свойства
        #endregion

        #region Методы
        public void Render(Window window)
        {
            window.Render();
        }
        public void UpdateSubscriberItemList(State state)
        {
            int width = state.SubscriberItemList[0].Width;  //  Кривовато, потом переделать.
            state.SubscriberItemList = ConvertSubscribersToItems(state, width);
        }
        public List<Item> ConvertSubscribersToItems(State state, int width)
        {
            var list = new List<Item>();
            int i = 0;
            state.Subscribers.ForEach((s) =>
            {
                list.Add(new Item(i, s.Name, state.mainWindow.XStartRenderingPosition, state.mainWindow.YStartRenderingPosition + i, width));
            });
            return list;
        }
        private void CheckChanges(Window window)
        {
            window.Areas.ForEach((area) =>
            {

            });
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
