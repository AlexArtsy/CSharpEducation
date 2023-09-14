using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Task3
{
    internal class State
    {
        #region Поля
        private string fileName = "phonebook.txt";
        private string path;
        public Window mainWindow;
        public Window settingsWindow;
        public QuestionScreen removeOneScreen;
        public QuestionScreen removeAllScreen;


        public string searchData = "";
        public bool isNewSubscriberNameCorrect = false;
        public string newPhoneNumber = "";
        public bool isNewPhoneNumberCorrect = false;
        public int maxSubscriberLengthName = 30;
        #endregion

        #region Свойства
        public Menu StartMenu { get; set; }
        public Menu SubscriberMenu { get; set; }
        public Subscriber SelectedSubscriber { get; set; }
        public List<Subscriber> Subscribers { get; set; }
        public List<Subscriber> SuitableSubscribers { get; set; }
        #endregion

        #region Методы
        private List<Subscriber> InitSubscriberList()
        {
            var dir = Directory.GetCurrentDirectory();
            this.path = @$"{dir}\{this.fileName}";

            if (!File.Exists(path))
            {
                File.Create(path).Close();
                File.WriteAllText(path, "[]");
            }

            var data = File.ReadAllText(path);
            return JsonSerializer.Deserialize<List<Subscriber>>(data) ?? new List<Subscriber>();
        }
        public void UpdateDataFile()
        {
            var data = JsonSerializer.Serialize(Subscribers);
            File.WriteAllText(path, data);
        }
        #endregion

        #region Конструкторы

        public State()
        {
            this.Subscribers = InitSubscriberList();
            this.SuitableSubscribers = this.Subscribers;

            string[] mainMenuItems = { "Добавить", "Изменить", "Удалить", "Удалить всех" };
            Menu mainMenu = new Menu(mainMenuItems);
            this.mainWindow = new Window(0, 0, 0);
            mainWindow.MenuList.Add(mainMenu);
            mainWindow.IsSelected = true;

            string[] subMenuItems = { "Добавить номер", "Изменить номер", "Удалить номер", "Удалить все" };
            Menu subMenu = new Menu(subMenuItems);
            this.settingsWindow = new Window(0, 0, 0);
            settingsWindow.MenuList.Add(subMenu);
        }
        #endregion
    }
}
