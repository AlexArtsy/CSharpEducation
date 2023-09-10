using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Task3
{
    internal class Phonebook
    {
        #region Поля

        private static Phonebook instance;
        public List<Subscriber> subscribers;
        #endregion
        #region Свойства
        #endregion
        #region Методы

        public bool AddNewPhoneNumber(string phoneNumber)
        {
            return true;
        }

        public bool DeletePhoneNumber(string phoneNumber)
        {
            return true;
        }

        //public Subscriber SearchSubscriberByPhoneNumber(string phoneNumber)
        //{

        //}

        //public List<string> GetPhoneNumbersBySubscriber(Subscriber user)
        //{

        //}

        public static Phonebook GetInstance()
        {
            if (instance == null)
                instance = new Phonebook();
            return instance;
        }
        #endregion
        #region Конструкторы
        private Phonebook()
        {
            var dir = Directory.GetCurrentDirectory();
            var path = @$"{dir}\phonebook.txt";
            if (!File.Exists(path))
            {
                File.Create(path).Close();
                File.WriteAllText(path, "[]");
            }
            var data = File.ReadAllText(path);
            this.subscribers = JsonSerializer.Deserialize<List<Subscriber>>(data) ?? new List<Subscriber>();
            var user = new Subscriber("Vanya", "123456");
            this.subscribers.Add(user);
            File.WriteAllText(path, JsonSerializer.Serialize(this.subscribers));

            var user2 = new Subscriber("Sisya", "123456");
            this.subscribers.Add(user2);
            File.WriteAllText(path, JsonSerializer.Serialize(this.subscribers));

            Console.WriteLine(path);

        }
        #endregion
    }
}
