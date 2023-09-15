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
            //phoneBook.SubscriberListChanged += 
            phoneBook.SubscriberListChanged += rendering.UpdateSubscriberItemList;
            phoneBook.SubscriberListChanged += state.UpdateDataFile;


            InitUI(state, rendering);
            InitMenuItemsActions(state, phoneBook);

            var windows = new List<Window>();
            windows.Add(state.mainWindow);
            windows.Add(state.settingsWindow);

            while (true)    //  Event loop.
            {
                rendering.Render(windows.Find((w) => w.IsSelected));
                control.KeyEventListener(windows.Find((w) => w.IsSelected));
            }
        }

        public static void InitUI(State state, RenderProcessor rendering)
        {
            string[] mainMenuItems = { "Добавить", "Изменить", "Удалить", "Удалить всех" };
            Menu mainMenu = new Menu(mainMenuItems);
            state.mainWindow = new Window(0, 0, 0);
            state.mainWindow = new Window(0, 0, 0);
            state.mainWindow.MenuList.Add(mainMenu);
            state.mainWindow.IsSelected = true;
            var input = new InputArea(0, state, 10, 2, 30);
            input.IsSelected = true;
            state.mainWindow.Inputs.Add(input);

            var subscriberList = new WindowArea(0, 10, 3, 50, 50);
            subscriberList.List = rendering.ConvertSubscribersToItems(state, subscriberList.Width);
            state.SubscriberItemList = rendering.ConvertSubscribersToItems(state, subscriberList.Width);
            state.mainWindow.Areas.Add(subscriberList);


            string[] subMenuItems = { "Добавить номер", "Изменить номер", "Удалить номер", "Удалить все" };
            Menu subMenu = new Menu(subMenuItems);
            state.settingsWindow = new Window(0, 0, 0);
            state.settingsWindow.MenuList.Add(subMenu);


        }
        public static void InitMenuItemsActions(State state, PhoneBook phoneBook)
        {
            state.mainWindow.MenuList[0].Items[0].Do = phoneBook.AddNewSubscriber;
            // state.mainWindow.MenuList[0].Items[1].Do = phoneBook.ChangeSubscriberData;
            state.mainWindow.MenuList[0].Items[2].Do = phoneBook.DeleteSubscriber;
            state.mainWindow.MenuList[0].Items[3].Do = phoneBook.DeleteAllSubscriber;

            state.settingsWindow.MenuList[0].Items[0].Do = phoneBook.AddNewPhoneNumber;
            //state.settingsWindow.MenuList[0].Items[1].Do = phoneBook.ChangeSubscriberData;
            state.settingsWindow.MenuList[0].Items[2].Do = phoneBook.DeleteSubscriber;
            state.settingsWindow.MenuList[0].Items[3].Do = phoneBook.DeleteAllSubscriber;

            state.mainWindow.Areas[0].Do = state.mainWindow.Areas[0].UpdateList;
        }

    }
}