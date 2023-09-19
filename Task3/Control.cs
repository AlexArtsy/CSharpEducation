using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Task3
{
    internal class Control
    {
        #region Поля
        #endregion

        #region Свойства
        public State State { get; set; }
        public MainWindow MainWindow { get; set; }
        public EditWindow EditWindow { get; set; }
        #endregion

        #region Методы

        public void Run(State state)
        {
            while (true)    //  Event loop.
            {
                if (MainWindow.isSelected)
                {
                    MainWindow.RenderWindow(state);
                }
                if (EditWindow.isSelected)
                {
                    EditWindow.RenderWindow(state);
                }
            }
        }
        public void SetInputData()
        {
            if (MainWindow.isSelected)
            {
                State.InputData = this.MainWindow.SelectedInputArea.Value;
                return;
            }
            if (EditWindow.isSelected)
            {
                State.InputData = this.EditWindow.SelectedInputArea.Value;
                return;
            }
        }
        public void DoMenuAction()
        {
            if (MainWindow.isSelected)
            {
                MainWindow.SelectedMenu.SelectedItem.Do();
                return;
            }
            if (EditWindow.isSelected)
            {
                EditWindow.SelectedMenu.SelectedItem.Do();
                return;
            }
        }
        public void SwitchWindows()
        {
            this.MainWindow.isSelected = !this.MainWindow.isSelected;
            this.EditWindow.isSelected = !this.EditWindow.isSelected;
        }
        public void UpdateDataFile()
        {
            var data = JsonSerializer.Serialize(State.Subscribers);
            File.WriteAllText(State.path, data);
        }
        public void SetSuitableSubscribers()
        {
            State.SuitableSubscribers = State.Subscribers.FindAll(s => s.Name.Contains(State.InputData));
        }
        public void UpdateSubscriberList()
        {
            this.MainWindow.UpdateSubscriberList(State);
        }
        public void UpdatePhoneNumberList()
        {
            if (MainWindow.isSelected)
            {
                this.MainWindow.UpdatePhoneNumberList(State);
                return;
            }
            if (EditWindow.isSelected)
            {
                this.EditWindow.UpdatePhoneNumberList(State);
                return;
            }
        }
        public void SetSelectedSubscriber()
        {
            if (State.SuitableSubscribers.Count > 0)
            {
                State.SelectedSubscriber = State.SuitableSubscribers[0];
            }
            else
            {
                State.SelectedSubscriber = State.nullSubscriber;
            }
        }
        #endregion

        #region Конструкторы
        public Control(State state, MainWindow mainWindow, EditWindow editWindow, PhoneBook phoneBook)
        {
            this.State = state;
            this.MainWindow = mainWindow;
            this.EditWindow = editWindow;

            this.MainWindow.BackspacePressed += SetInputData;
            this.MainWindow.BackspacePressed += SetSuitableSubscribers;
            this.MainWindow.BackspacePressed += SetSelectedSubscriber;
            this.MainWindow.BackspacePressed += UpdateSubscriberList;
            this.MainWindow.BackspacePressed += this.MainWindow.UpdateArea;
            this.MainWindow.BackspacePressed += UpdatePhoneNumberList;
            this.MainWindow.BackspacePressed += this.MainWindow.UpdateArea;

            this.MainWindow.EnyKeyPressed += SetInputData;
            this.MainWindow.EnyKeyPressed += SetSuitableSubscribers;
            this.MainWindow.EnyKeyPressed += SetSelectedSubscriber;
            this.MainWindow.EnyKeyPressed += UpdateSubscriberList;
            this.MainWindow.EnyKeyPressed += this.MainWindow.UpdateArea;
            this.MainWindow.EnyKeyPressed += UpdatePhoneNumberList;
            this.MainWindow.EnyKeyPressed += this.MainWindow.UpdateArea;

            this.MainWindow.EnterPressed += DoMenuAction;
            this.MainWindow.TabPressed += SwitchWindows;

            this.MainWindow.MenuList[0].Items[0].Do = phoneBook.AddNewSubscriber;
            this.MainWindow.MenuList[0].Items[1].Do = SwitchWindows;
            this.MainWindow.MenuList[0].Items[2].Do = phoneBook.DeleteSubscriber;

            this.EditWindow.BackspacePressed += SetInputData;
            this.EditWindow.BackspacePressed += UpdatePhoneNumberList;
            this.EditWindow.BackspacePressed += this.EditWindow.UpdateArea;

            this.EditWindow.EnyKeyPressed += SetInputData;
            this.EditWindow.EnyKeyPressed += UpdatePhoneNumberList;
            this.EditWindow.EnyKeyPressed += this.EditWindow.UpdateArea;

            this.EditWindow.EnterPressed += DoMenuAction;
            this.EditWindow.TabPressed += SwitchWindows;

            this.EditWindow.MenuList[0].Items[0].Do = SwitchWindows;
            this.EditWindow.MenuList[0].Items[1].Do = phoneBook.AddNewPhoneNumber;
            this.EditWindow.MenuList[0].Items[2].Do = SwitchWindows;
            this.EditWindow.MenuList[0].Items[3].Do = SwitchWindows;
            this.EditWindow.MenuList[0].Items[4].Do = SwitchWindows;

            phoneBook.SubscriberListChanged += UpdateDataFile;
            phoneBook.PhoneNumberListChanged += UpdateDataFile;
            phoneBook.PhoneNumberListChanged += UpdatePhoneNumberList;
            phoneBook.PhoneNumberListChanged += EditWindow.UpdateArea;
        }
        #endregion
    }
}
