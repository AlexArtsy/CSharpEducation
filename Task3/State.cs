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
        private string[] startMenuItemNames = { "Добавить абонента", "Изменить данные", "Удалить абонента", "Удалить всех" };
        private string[] subscriberMenuItemNames = { "Добавить номер", "Изменить номер", "Удалить номер", "Удалить все номера" };
        public string searchData = "";
        #endregion

        #region Свойства
        public Menu StartMenu { get; set; }
        public Menu SubscriberMenu { get; set; }
        public Subscriber selectedSubscriber;
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
            this.StartMenu = new Menu(startMenuItemNames);
            this.SubscriberMenu = new Menu(subscriberMenuItemNames);
            this.Subscribers = InitSubscriberList();
            this.SuitableSubscribers = this.Subscribers;
        }
        #endregion
    }
}
