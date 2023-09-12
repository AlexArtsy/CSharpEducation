using System.Drawing;

namespace Task3
{
    class Program
    {
        public static string searchData = "";
        static void Main(string[] args)
        { 
            var phoneBook = PhoneBook.GetInstance();
            var goExit = false;
            var menuItem = 1;

            string[] items = {"Добавить", "Изменить", "Удалить" };
            var menu = new Menu(items);
            menu.RenderMenu();
            Console.SetCursorPosition(0, 3);
            Console.Write("Абонент:");
            

            while (!goExit)
            {
                Console.SetCursorPosition(10 + searchData.Length, 3);
                ConsoleKey key = Console.ReadKey(true).Key;
                menu.KeyEventListener(key);
                
            }

        }
    }
}