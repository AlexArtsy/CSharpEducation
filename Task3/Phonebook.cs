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
        private static string fileName = "phonebook.txt";
        private static PhoneBook instance;
        private Subscriber nullSubscriber = new Subscriber("null"); //  Заглушка на случай отсутствия абонента.
        #endregion
        #region Свойства
        public State State { get; set; }
        public RenderProcessor Render { get; set; }
        public KeyboardControl Control { get; set; }
        #endregion

        #region Методы
        public void Run()
        {
            while (true)
            {
                Render.UpdateScreen();
                if (Render.startScreenSelected)
                {
                    Control.KeyEventListener(State.StartMenu, Render);
                    State.SuitableSubscribers = GetSuitableSubscriberList();
                    if (State.SuitableSubscribers.Count == 1)
                    {
                        State.SelectedSubscriber = State.SuitableSubscribers[0];
                    }
                    else
                    {
                        State.SelectedSubscriber = this.nullSubscriber;
                    }
                }
                else if (Render.subscriberScreenSelected)
                {
                    Control.KeyEventListener(State.SubscriberMenu, Render);
                    State.isNewPhoneNumberCorrect = CheckNewPhoneNumber(State.newPhoneNumber);
                }
            }
        }
        public List<Subscriber> GetSuitableSubscriberList()
        {
            return State.Subscribers.FindAll((s) => s.Name.Contains(State.searchData));
        }
        public void DeleteSubscriber(State state)
        {
            Render.RenderDeleteUserScreen();
            var answer = Console.ReadLine();
            if (answer == "Y" || answer == "y")
            {
                this.State.Subscribers.RemoveAll(s => s.Name == this.State.searchData);
                state.UpdateDataFile();
            }
            Render.ResetAllScreenSelecting();
            Render.startScreenSelected = true;
        }
        public void DeleteAllSubscriber(State state)
        {
            Render.RenderDeleteALLUserScreen();
            var answer = Console.ReadLine();
            if (answer == "Y" || answer == "y")
            {
                this.State.Subscribers.RemoveAll(s => true);
                state.UpdateDataFile();
            }
            Render.ResetAllScreenSelecting();
            Render.startScreenSelected = true;
        }

        public void AddNewSubscriber(State state)
        {
            state.Subscribers.Add(new Subscriber(state.searchData));
            state.Subscribers.Sort((a, b) => string.Compare(a.Name, b.Name));
            state.UpdateDataFile();
        }
        public void ChangeSubscriberData(State state)
        {
            Render.ResetAllScreenSelecting();
            Render.subscriberScreenSelected = true;
        }

        public void AddNewPhoneNumber(State state)
        {
            if (State.isNewPhoneNumberCorrect)
            {
                State.SelectedSubscriber.PhoneNumberList.Add(State.newPhoneNumber);
                State.newPhoneNumber = "";
                state.UpdateDataFile();
            }
        }
        public bool CheckNewPhoneNumber(string number)
        {
            Regex regex = new Regex(@"\d+");
            return regex.IsMatch(number);
        }
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
            State.SelectedSubscriber = this.nullSubscriber;

            this.State.StartMenu.items[0].Do = this.AddNewSubscriber;
            this.State.StartMenu.items[1].Do = this.ChangeSubscriberData;
            this.State.StartMenu.items[2].Do = this.DeleteSubscriber;
            this.State.StartMenu.items[3].Do = this.DeleteAllSubscriber;

            this.State.SubscriberMenu.items[0].Do = this.AddNewPhoneNumber;
            this.State.SubscriberMenu.items[1].Do = this.ChangeSubscriberData;
            this.State.SubscriberMenu.items[2].Do = this.DeleteSubscriber;
            this.State.SubscriberMenu.items[3].Do = this.DeleteAllSubscriber;
        }
        #endregion
    }
}
