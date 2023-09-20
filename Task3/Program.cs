using System.Drawing;
using System.Runtime.CompilerServices;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            var state = new State();
            var phoneBook = PhoneBook.GetInstance(state);
            MainWindow mainWindow = new MainWindow(state);
            EditWindow editWindow = new EditWindow(state);
            var control = new Control(state, mainWindow, editWindow, phoneBook);

            control.Run(state);
        }
    }
}