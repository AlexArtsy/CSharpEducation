using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Enumeration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Task3
{
    internal class PhoneBook
    {
        #region Поля
        private static string fileName = "phonebook.txt";
        private static PhoneBook instance;
        #endregion
        #region Свойства
        public List<Subscriber> Subscribers { get; set; }
        #endregion
        #region Методы

        private List<Subscriber> InitSubscribers()
        {
            var dir = Directory.GetCurrentDirectory();
            var path = @$"{dir}\{fileName}";

            if (!File.Exists(path))
            {
                File.Create(path).Close();
                File.WriteAllText(path, "[]");
            }

            var data = File.ReadAllText(path);
            return JsonSerializer.Deserialize<List<Subscriber>>(data) ?? new List<Subscriber>();
        }
        public bool AddNewPhoneNumber(Subscriber subscriber, string phoneNumber)
        {
            
            return true;
        }

        public bool DeletePhoneNumber(string phoneNumber)
        {
            return true;
        }

        public void DeleteSubscriber(string userName)
        {
            this.Subscribers.RemoveAll((subscriber) => subscriber.Name == userName);
        }

        //public Subscriber GetSubscriberByPhoneNumber(string phoneNumber)
        //{

        //}

        //public List<string> GetPhoneNumbersBySubscriber(Subscriber user)
        //{

        //}

        public static PhoneBook GetInstance()
        {
            return instance ?? new PhoneBook();
        }
        #endregion
        #region Конструкторы
        private PhoneBook()
        {
            this.Subscribers = InitSubscribers();
        }
        #endregion
    }
}
