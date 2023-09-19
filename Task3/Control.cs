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
        public void SwitchWindows()
        {
            if (State.SelectedSubscriber.Name == "_")
            {
                this.MainWindow.ShowMessage("Сперва нужно выбрать абонента");
                return;
            }
            this.MainWindow.isSelected = !this.MainWindow.isSelected;
            this.EditWindow.isSelected = !this.EditWindow.isSelected;
        }
        public void SetInputData()
        {
            if (MainWindow.isSelected)
            {
                State.InputData = this.MainWindow.SelectedInputArea.Value;
                this.MainWindow.Inputs[0].isCorrect = State.newSubscriberRegex.IsMatch(State.InputData);
                return;
            }
            if (EditWindow.isSelected)
            {
                State.InputData = this.EditWindow.SelectedInputArea.Value;
                this.EditWindow.Inputs[0].isCorrect = State.newPhoneNumberRegex.IsMatch(State.InputData);
                return;
            }
        }
        public void SetSelectedSubscriber()
        {
            State.SelectedSubscriber = State.SuitableSubscribers.Count > 0 ? State.SuitableSubscribers[0] : State.nullSubscriber;
        }
        public void SetSelectedNumber()
        {
            State.SelectedNumber = State.SelectedSubscriber.PhoneNumberList.Count > 0
                ? State.SelectedSubscriber.PhoneNumberList[0]
                : "";
        }
        public void SetSuitableSubscribers()
        {
            State.SuitableSubscribers = State.Subscribers.FindAll(s => s.Name.Contains(State.InputData) || s.PhoneNumberList.Contains(State.InputData));
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
        
        public void UpdateDataFile()
        {
            var data = JsonSerializer.Serialize(State.Subscribers);
            File.WriteAllText(State.path, data);
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
            }
        }
        
        public void ShiftUpSelectedNumber()
        {
            if (State.SelectedSubscriber.PhoneNumberList.Count > 0)
            {
                var itemList = this.EditWindow.Areas[0].List;
                var selectedId = itemList.Find(l => l.isSelected).Id;
                var newId = selectedId == 0 ? itemList.Count - 1 : selectedId - 1;
                var number = itemList.Find(l => l.Id == newId).Value;
                State.SelectedNumber = itemList.Find(s => s.Value == number).Value;
            }
        }
        public void ShiftDownSelectedNumber()
        {
            if (State.SelectedSubscriber.PhoneNumberList.Count > 0)
            {
                var itemList = this.EditWindow.Areas[0].List;
                var selectedId = itemList.Find(l => l.isSelected).Id;
                var newId = selectedId == itemList.Count - 1 ? 0 : selectedId + 1;
                var number = itemList.Find(l => l.Id == newId).Value;
                State.SelectedNumber = itemList.Find(s => s.Value == number).Value;
            }
        }
        public void ShiftUpSelectedSubscriber()
        {
            if (this.MainWindow.Areas[0].List.Count > 0)
            {
                var itemList = this.MainWindow.Areas[0].List;
                var selectedId = itemList.Find(l => l.isSelected).Id;
                var newId = selectedId == 0 ? itemList.Count - 1 : selectedId - 1;
                var name = itemList.Find(l => l.Id == newId).Value;
                State.SelectedSubscriber = State.Subscribers.Find(s => s.Name == name);
            }
        }
        public void ShiftDownSelectedSubscriber()
        {
            if(this.MainWindow.Areas[0].List.Count > 0)
            {
                var itemList = this.MainWindow.Areas[0].List;
                var selectedId = itemList.Find(l => l.isSelected).Id;
                var newId = selectedId == itemList.Count - 1 ? 0 : selectedId + 1;
                var name = itemList.Find(l => l.Id == newId).Value;
                State.SelectedSubscriber = State.Subscribers.Find(s => s.Name == name);
            }
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

        private void PrintMessage(string message)
        {
            if (MainWindow.isSelected)
            {
                MainWindow.ShowMessage(message);
            }
            if (EditWindow.isSelected)
            {
                EditWindow.ShowMessage(message);
            }
        }
        private void ClearMessage()
        {
            if (MainWindow.isSelected)
            {
                MainWindow.ClearMessageArea();
            }
            if (EditWindow.isSelected)
            {
                EditWindow.ClearMessageArea();
            }
        }
        private void InitMainWindowKeyEvents()
        {
            this.MainWindow.BackspacePressed += SetInputData;
            this.MainWindow.BackspacePressed += SetSuitableSubscribers;
            this.MainWindow.BackspacePressed += SetSelectedSubscriber;
            this.MainWindow.BackspacePressed += UpdateMainWindowAreas;
            this.MainWindow.BackspacePressed += ClearMessage;

            this.MainWindow.EnyKeyPressed += SetInputData;
            this.MainWindow.EnyKeyPressed += SetSuitableSubscribers;
            this.MainWindow.EnyKeyPressed += SetSelectedSubscriber;
            this.MainWindow.EnyKeyPressed += UpdateMainWindowAreas;
            this.MainWindow.EnyKeyPressed += ClearMessage;

            this.MainWindow.UpArrowPressed += ShiftUpSelectedSubscriber;
            this.MainWindow.UpArrowPressed += UpdateMainWindowAreas;

            this.MainWindow.DownArrowPressed += ShiftDownSelectedSubscriber;
            this.MainWindow.DownArrowPressed += UpdateMainWindowAreas;

            this.MainWindow.EnterPressed += DoMenuAction;
            this.MainWindow.TabPressed += SwitchWindows;
        }
        private void InitEditWindowKeyEvents()
        {
            this.EditWindow.BackspacePressed += SetInputData;
            this.EditWindow.BackspacePressed += ClearMessage;
            this.EditWindow.EnyKeyPressed += SetInputData;
            this.EditWindow.EnyKeyPressed += ClearMessage;

            this.EditWindow.UpArrowPressed += ShiftUpSelectedNumber;
            this.EditWindow.UpArrowPressed += UpdateEditWindowAreas;

            this.EditWindow.DownArrowPressed += ShiftDownSelectedNumber;
            this.EditWindow.DownArrowPressed += UpdateEditWindowAreas;

            this.EditWindow.EnterPressed += DoMenuAction;
            this.EditWindow.EnterPressed += SetInputData;
        }
        private void InitMainWindowMenuEvents(PhoneBook book)
        {
            this.MainWindow.MenuList[0].Items[0].Do = book.AddNewSubscriber;
            this.MainWindow.MenuList[0].Items[1].Do = SwitchWindows;
            this.MainWindow.MenuList[0].Items[1].Do += SetInputData;
            this.MainWindow.MenuList[0].Items[2].Do = book.DeleteSubscriber;
            this.MainWindow.MenuList[0].Items[3].Do = book.DeleteAllSubscriber;
        }
        private void InitEditWindowMenuEvents(PhoneBook book)
        {
            this.EditWindow.MenuList[0].Items[0].Do = SwitchWindows;
            this.EditWindow.MenuList[0].Items[0].Do += SetInputData;
            this.EditWindow.MenuList[0].Items[1].Do = book.AddNewPhoneNumber;
            this.EditWindow.MenuList[0].Items[2].Do = book.EditPhoneNumber;
            this.EditWindow.MenuList[0].Items[3].Do = book.DeletePhoneNumber;
            this.EditWindow.MenuList[0].Items[4].Do = book.DeleteAllPhoneNumber;
        }
        private void SubscribePhoneBookEvents(PhoneBook book)
        {
            book.SubscriberListChanged += UpdateDataFile;
            book.SubscriberListChanged += SetSuitableSubscribers;
            book.SubscriberListChanged += SetSelectedSubscriber;
            book.SubscriberListChanged += UpdateMainWindowAreas;

            book.PhoneNumberListChanged += UpdateDataFile;
            book.PhoneNumberListChanged += SetSelectedNumber;
            book.PhoneNumberListChanged += UpdatePhoneNumberList;
            book.PhoneNumberListChanged += EditWindow.UpdateArea;
        }
        #endregion

        #region Конструкторы
        public Control(State state, MainWindow mainWindow, EditWindow editWindow, PhoneBook phoneBook)
        {
            this.State = state;
            this.MainWindow = mainWindow;
            this.EditWindow = editWindow;

            phoneBook.PrintMessage = PrintMessage;

            InitMainWindowKeyEvents();
            InitEditWindowKeyEvents();
            InitMainWindowMenuEvents(phoneBook);
            InitEditWindowMenuEvents(phoneBook);
            SubscribePhoneBookEvents(phoneBook);
        }
        #endregion
    }
}
