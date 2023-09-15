using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Enumeration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task3
{
    internal class PhoneBook
    {
        #region Поля
        private readonly State state;
        private static PhoneBook instance;
        private readonly Regex newSubscriberRegex = new Regex(@"\d+");
        private readonly Regex newPhoneNumberRegex = new Regex(@"\d+");
        #endregion

        #region Свойства
        #endregion

        #region Методы

        #region Subscribers CRUD
        public void AddNewSubscriber(State state)
        {
            state.Subscribers.Add(new Subscriber(state.InputData));
            state.Subscribers.Sort((a, b) => string.Compare(a.Name, b.Name));
            SubscriberListChanged?.Invoke(state);
        }
        public void DeleteSubscriber(State state)
        {
            state.Subscribers.RemoveAll(s => s.Name == this.state.InputData);
            SubscriberListChanged?.Invoke(state);
        }
        public void DeleteAllSubscriber(State state)
        {
            state.Subscribers.RemoveAll(s => true);
            SubscriberListChanged?.Invoke(state);
        }
        #endregion

        #region PhoneNumbers CRUD
        public void AddNewPhoneNumber(State state)
        {
            if (state.isNewPhoneNumberCorrect)
            {
                state.SelectedSubscriber.PhoneNumberList.Add(this.state.newPhoneNumber);
            }
        }
        #endregion
        public bool CheckNewPhoneNumber(string number)
        {
            return this.newPhoneNumberRegex.IsMatch(number);
        }
        public static PhoneBook GetInstance(State state)
        {
            return instance ?? new PhoneBook(state);
        }
        #endregion

        #region Делегаты и события
        public delegate void PhoneBookHandler(State state);
        public event PhoneBookHandler SubscriberListChanged;
        #endregion

        #region Конструкторы
        private PhoneBook(State state)
        {
            this.state = state;
        }
        #endregion
    }
}
