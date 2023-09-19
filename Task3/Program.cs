using System.Drawing;
using System.Runtime.CompilerServices;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            var state = new State();
            var phoneBook = PhoneBook.GetInstance(state);
            //var rendering = new RenderProcessor(state);
            MainWindow mainWindow = new MainWindow(state);
            EditWindow editWindow = new EditWindow(state);
            var control = new Control(state, mainWindow, editWindow, phoneBook);

            
            //var windows = new List<Window>();
            //windows.Add(mainWindow);
            //windows.Add(editWindow);

            control.Run(state);
        }

        //public static void InitMenuItemsActions(State state, PhoneBook phoneBook)
        //{
        //    state.mainWindow.MenuList[0].Items[0].Do = phoneBook.AddNewSubscriber;
        //    // state.mainWindow.MenuList[0].Items[1].Do = phoneBook.ChangeSubscriberData;
        //    state.mainWindow.MenuList[0].Items[2].Do = phoneBook.DeleteSubscriber;
        //    state.mainWindow.MenuList[0].Items[3].Do = phoneBook.DeleteAllSubscriber;

        //    state.editWindow.MenuList[0].Items[0].Do = phoneBook.AddNewPhoneNumber;
        //    //state.settingsWindow.MenuList[0].Items[1].Do = phoneBook.ChangeSubscriberData;
        //    state.editWindow.MenuList[0].Items[2].Do = phoneBook.DeleteSubscriber;
        //    state.editWindow.MenuList[0].Items[3].Do = phoneBook.DeleteAllSubscriber;

        //    //state.mainWindow.Areas[0].Do = state.mainWindow.Areas[0].UpdateList;
            
        //}

    }
}