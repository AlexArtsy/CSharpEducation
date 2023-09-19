using System;
using System.Collections.Generic;
using System.Data;
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
                    SetSelectedNumber();
                    EditWindow.RenderWindow(state);
                }
            }
        }
        public void SetInputData()
        {
            if (MainWindow.isSelected)
            {
                State.InputData = this.MainWindow.SelectedInputArea.Value;
                if (!State.newSubscriberRegex.IsMatch(State.InputData))
                {
                    this.MainWindow.Inputs[0].isCorrect = true;
                }
                else
                {
                    this.MainWindow.Inputs[0].isCorrect = false;
                }
                return;
            }
            if (EditWindow.isSelected)
            {
                State.InputData = this.EditWindow.SelectedInputArea.Value;
                if (!State.newPhoneNumberRegex.IsMatch(State.InputData))
                {
                    this.EditWindow.Inputs[0].isCorrect = true;
                }
                else
                {
                    this.EditWindow.Inputs[0].isCorrect = false;
                }
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
            this.MainWindow.UpdatePhoneNumberList(State);   // Нужно обновлять в обоих случаях, т.к. при возврате на главную страницу список номеров не обновлялся.
            
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
        public void SetSelectedNumber()
        {
            if (State.SelectedSubscriber.PhoneNumberList.Count > 0)
            {
                State.SelectedNumber = State.SelectedSubscriber.PhoneNumberList[0];
            }
            else
            {
                State.SelectedNumber = "";
            }
        }
        public void ShiftUpSelectedNumber()
        {
            if (State.SelectedSubscriber.PhoneNumberList.Count == 0)
            {
                return;
            }
            var itemList = this.EditWindow.Areas[0].List;
            var selectedId = itemList.Find(l => l.isSelected).Id;
            var newId = selectedId == 0 ? itemList.Count - 1 : selectedId - 1;
            var number = itemList.Find(l => l.Id == newId).Value;
            State.SelectedNumber = itemList.Find(s => s.Value == number).Value;
        }
        public void ShiftDownSelectedNumber()
        {
            if (State.SelectedSubscriber.PhoneNumberList.Count == 0)
            {
                return;
            }
            var itemList = this.EditWindow.Areas[0].List;
            var selectedId = itemList.Find(l => l.isSelected).Id;
            var newId = selectedId == itemList.Count - 1 ? 0 : selectedId + 1;
            var number = itemList.Find(l => l.Id == newId).Value;
            State.SelectedNumber = itemList.Find(s => s.Value == number).Value;
        }
        public void ShiftUpSelectedSubscriber()
        {
            var itemList = this.MainWindow.Areas[0].List;
            var selectedId = itemList.Find(l => l.isSelected).Id;
            var newId = selectedId == 0 ? itemList.Count - 1 : selectedId - 1;
            var name = itemList.Find(l => l.Id == newId).Value;
            State.SelectedSubscriber = State.Subscribers.Find(s => s.Name == name);
        }
        public void ShiftDownSelectedSubscriber()
        {
            var itemList = this.MainWindow.Areas[0].List;
            var selectedId = itemList.Find(l => l.isSelected).Id;
            var newId = selectedId == itemList.Count - 1 ? 0 : selectedId + 1;
            var name = itemList.Find(l => l.Id == newId).Value;
            State.SelectedSubscriber = State.Subscribers.Find(s => s.Name == name);
        }
        public void UpdateMainWindowAreas()
        {
            UpdateSubscriberList();
            this.MainWindow.UpdateArea();
            UpdatePhoneNumberList();
            this.MainWindow.UpdateArea();
        }
        public void UpdateEditWindowAreas()
        {
            UpdatePhoneNumberList();
            this.EditWindow.UpdateArea();
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
            this.MainWindow.BackspacePressed += UpdateMainWindowAreas;

            this.MainWindow.EnyKeyPressed += SetInputData;
            this.MainWindow.EnyKeyPressed += SetSuitableSubscribers;
            this.MainWindow.EnyKeyPressed += SetSelectedSubscriber;
            this.MainWindow.EnyKeyPressed += UpdateMainWindowAreas;

            this.MainWindow.UpArrowPressed += ShiftUpSelectedSubscriber;
            this.MainWindow.UpArrowPressed += UpdateMainWindowAreas;

            this.MainWindow.DownArrowPressed += ShiftDownSelectedSubscriber;
            this.MainWindow.DownArrowPressed += UpdateMainWindowAreas;

            this.MainWindow.EnterPressed += DoMenuAction;
            this.MainWindow.TabPressed += SwitchWindows;

            this.MainWindow.MenuList[0].Items[0].Do += phoneBook.AddNewSubscriber;
            this.MainWindow.MenuList[0].Items[1].Do = SwitchWindows;
            this.MainWindow.MenuList[0].Items[2].Do = phoneBook.DeleteSubscriber;
            this.MainWindow.MenuList[0].Items[3].Do = phoneBook.DeleteAllSubscriber;

            this.EditWindow.BackspacePressed += SetInputData;
            //this.EditWindow.BackspacePressed += SetSelectedNumber;

            this.EditWindow.EnyKeyPressed += SetInputData;
            //this.EditWindow.EnyKeyPressed += SetSelectedNumber;

            this.EditWindow.UpArrowPressed += ShiftUpSelectedNumber;
            this.EditWindow.UpArrowPressed += UpdateEditWindowAreas;

            this.EditWindow.DownArrowPressed += ShiftDownSelectedNumber;
            this.EditWindow.DownArrowPressed += UpdateEditWindowAreas;

            this.EditWindow.EnterPressed += DoMenuAction;
            this.EditWindow.TabPressed += SwitchWindows;

            this.EditWindow.MenuList[0].Items[0].Do = SwitchWindows;
            this.EditWindow.MenuList[0].Items[1].Do = phoneBook.AddNewPhoneNumber;
            this.EditWindow.MenuList[0].Items[2].Do = phoneBook.EditPhoneNumber;
            this.EditWindow.MenuList[0].Items[3].Do = phoneBook.DeletePhoneNumber;
            this.EditWindow.MenuList[0].Items[4].Do = phoneBook.DeleteAllPhoneNumber;

            phoneBook.SubscriberListChanged += UpdateDataFile;
            phoneBook.SubscriberListChanged += SetSuitableSubscribers;
            phoneBook.SubscriberListChanged += SetSelectedSubscriber;
            phoneBook.SubscriberListChanged += UpdateMainWindowAreas;

            phoneBook.PhoneNumberListChanged += UpdateDataFile;
            phoneBook.PhoneNumberListChanged += SetSelectedNumber;
            phoneBook.PhoneNumberListChanged += UpdatePhoneNumberList;
            phoneBook.PhoneNumberListChanged += EditWindow.UpdateArea;
            //phoneBook.PhoneNumberListChanged += MainWindow.UpdatePhoneNumberList();
        }
        #endregion
    }
}
