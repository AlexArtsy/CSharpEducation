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
       //    private readonly Subscriber nullSubscriber = new Subscriber("null"); //  Заглушка на случай отсутствия абонента.
        #endregion

        #region Свойства
        #endregion

        #region Методы

        #region Subscribers CRUD
        public void AddNewSubscriber()
        {
            this.state.Subscribers.Add(new Subscriber(state.searchData));
            this.state.Subscribers.Sort((a, b) => string.Compare(a.Name, b.Name));
            this.state.UpdateDataFile();
        }
        public void DeleteSubscriber()
        {
            this.state.Subscribers.RemoveAll(s => s.Name == this.state.searchData);
            state.UpdateDataFile();
        }
        public void DeleteAllSubscriber()
        {
            this.state.Subscribers.RemoveAll(s => true);
            this.state.UpdateDataFile();
        }
        #endregion

        #region PhoneNumbers CRUD
        public void AddNewPhoneNumber()
        {
            if (state.isNewPhoneNumberCorrect)
            {
                this.state.SelectedSubscriber.PhoneNumberList.Add(this.state.newPhoneNumber);
            }
        }
        #endregion
        public List<Subscriber> GetSuitableSubscriberList(string name)
        {
            return this.state.Subscribers.FindAll((s) => s.Name.Contains(name));
        }
        public bool CheckNewPhoneNumber(string number)
        {
            return this.newPhoneNumberRegex.IsMatch(number);
        }
        public static PhoneBook GetInstance(State state)
        {
            return instance ?? new PhoneBook(state);
        }
        #endregion

        #region Конструкторы
        private PhoneBook(State state)
        {
            this.state = state;
        }
        #endregion
    }
}
