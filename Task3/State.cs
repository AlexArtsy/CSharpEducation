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
        public string path;
        //public MainWindow mainWindow;
        //public EditWindow editWindow;
        public readonly Subscriber nullSubscriber = new Subscriber("_"); //  Заглушка на случай отсутствия абонента.

        public bool isNewSubscriberNameCorrect = false;
        public string newPhoneNumber = "";
        public bool isNewPhoneNumberCorrect = false;
        #endregion

        #region Свойства
        public string InputData { get; set; }
        public Subscriber SelectedSubscriber { get; set; }
        public List<Subscriber> Subscribers { get; set; }
        public List<Subscriber> SuitableSubscribers { get; set; }
        //public Window SelectedWindow { get; set; }
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
        #endregion

        #region Конструкторы
        public State()
        {
            this.Subscribers = InitSubscriberList();
            this.SuitableSubscribers = this.Subscribers;
            this.InputData = "";
            if (this.Subscribers.Count > 0)
            {
                this.SelectedSubscriber = this.Subscribers[0];
            }
            else
            {
                this.SelectedSubscriber = nullSubscriber;
            }
        }
        #endregion
    }
}
