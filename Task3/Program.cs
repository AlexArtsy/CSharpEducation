using System.Drawing;
using System.Runtime.CompilerServices;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            var state = new State();
            var rendering = new RenderProcessor(state);
            var control = new KeyboardControl(state);

            var phoneBook = PhoneBook.GetInstance(state);

            state.mainWindow.MenuList[0].Items[0].Do = phoneBook.AddNewSubscriber;
            // state.mainWindow.MenuList[0].Items[1].Do = phoneBook.ChangeSubscriberData;
            state.mainWindow.MenuList[0].Items[2].Do = phoneBook.DeleteSubscriber;
            state.mainWindow.MenuList[0].Items[3].Do = phoneBook.DeleteAllSubscriber;

            state.settingsWindow.MenuList[0].Items[0].Do = phoneBook.AddNewPhoneNumber;
            //state.settingsWindow.MenuList[0].Items[1].Do = phoneBook.ChangeSubscriberData;
            state.settingsWindow.MenuList[0].Items[2].Do = phoneBook.DeleteSubscriber;
            state.settingsWindow.MenuList[0].Items[3].Do = phoneBook.DeleteAllSubscriber;

            var windows = new List<Window>();
            windows.Add(state.mainWindow);
            windows.Add(state.settingsWindow);

            while (true)    //  Event loop.
            {
                rendering.Render(windows.Find((w) => w.IsSelected));
                control.KeyEventListener(windows.Find((w) => w.IsSelected));
            }
        }
    }
}