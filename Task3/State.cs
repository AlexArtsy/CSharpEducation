using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task3
{
    internal class State
    {
        #region Поля
        private string fileName = "phonebook.txt";
        public string path;
        public readonly Regex newSubscriberRegex = new Regex(@"^([a-zа-яё]+)$");
        public readonly Regex newPhoneNumberRegex = new Regex(@"^[0-9 ]+$");
 
        public readonly Subscriber nullSubscriber = new Subscriber("_"); //  Заглушка на случай отсутствия абонента.
        #endregion

        #region Свойства
        public string InputData { get; set; }
        public Subscriber SelectedSubscriber { get; set; }
        public string SelectedNumber { get; set; }
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
        #endregion

        #region Конструкторы
        public State()
        {
            this.Subscribers = InitSubscriberList();
            this.SuitableSubscribers = this.Subscribers;
            this.InputData = "";

            this.SelectedSubscriber = this.Subscribers.Count > 0 ? this.Subscribers[0] : this.nullSubscriber;
        }
        #endregion
    }
}
