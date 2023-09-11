using System.Drawing;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        { 
            var phoneBook = PhoneBook.GetInstance();
            var goExit = false;
            var menuItem = 1;

            string[] items = {"Добавить", "Изменить", "Удалить" };
            var menu = new Menu(items);
            menu.RenderMenu();

            while (!goExit)
            {
                ConsoleKey key = Console.ReadKey(true).Key;
                menu.KeyEventListener(key);
            }

        }
    }
}