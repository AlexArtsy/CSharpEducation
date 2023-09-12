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
        public State State { get; set; }
        public RenderProcessor Render { get; set; }
        public KeyboardControl Control { get; set; }
        public List<Subscriber> Subscribers { get; set; }
        #endregion

        #region Методы
        public void Run()
        {
            while (true)
            {
                Render.RenderMenu(State.StartMenu);
                Render.RenderUserSearchPanel();
                Control.KeyEventListener(State.StartMenu);
                
            }
            
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
            this.State = new State();
            this.Render = new RenderProcessor(this.State);
            this.Control = new KeyboardControl(this.State);
        }
        #endregion
    }
}
