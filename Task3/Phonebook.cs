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
        #endregion

        #region Свойства
        #endregion

        #region Методы

        #region Subscribers CRUD
        public void AddNewSubscriber()
        {
            state.Subscribers.Add(new Subscriber(state.InputData));
            state.Subscribers.Sort((a, b) => string.Compare(a.Name, b.Name));
            SubscriberListChanged?.Invoke();
        }
        public void DeleteSubscriber()
        {
            state.Subscribers.RemoveAll(s => s.Name == this.state.SelectedSubscriber.Name); 
            SubscriberListChanged?.Invoke();
        }
        public void DeleteAllSubscriber()
        {
            state.Subscribers.Clear();
            SubscriberListChanged?.Invoke();
        }
        #endregion

        #region PhoneNumbers CRUD
        public void AddNewPhoneNumber()
        {
            if (CheckNewPhoneNumber(state.InputData))
            {
                state.SelectedSubscriber.PhoneNumberList.Add(state.InputData);
                PhoneNumberListChanged?.Invoke();
            }
        }
        public void DeletePhoneNumber()
        {
            state.SelectedSubscriber.PhoneNumberList.RemoveAll(n => n == state.SelectedNumber);
            PhoneNumberListChanged?.Invoke();
        }
        public void DeleteAllPhoneNumber()
        {
            state.SelectedSubscriber.PhoneNumberList.Clear();
            PhoneNumberListChanged?.Invoke();
        }
        public void EditPhoneNumber()
        {
            var index = state.SelectedSubscriber.PhoneNumberList.IndexOf(state.SelectedNumber);
            state.SelectedSubscriber.PhoneNumberList[index] = state.InputData;
            PhoneNumberListChanged?.Invoke();
        }
        #endregion
        public bool CheckNewPhoneNumber(string number)
        {
            return state.newPhoneNumberRegex.IsMatch(number);
        }
        public static PhoneBook GetInstance(State state)
        {
            return instance ?? new PhoneBook(state);
        }
        #endregion

        #region Делегаты и события
        public delegate void PhoneBookHandler();
        public event PhoneBookHandler SubscriberListChanged;
        public event PhoneBookHandler PhoneNumberListChanged;
        #endregion

        #region Конструкторы
        private PhoneBook(State state)
        {
            this.state = state;
        }
        #endregion
    }
}
