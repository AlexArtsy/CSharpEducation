using System.Drawing;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        { 
            var phoneBook = PhoneBook.GetInstance();
            phoneBook.Run();
        }
    }
}