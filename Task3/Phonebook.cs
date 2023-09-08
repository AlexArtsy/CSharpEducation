using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    internal class Phonebook
    {
        #region Поля
        private static Phonebook instance;
        #endregion
        #region Свойства
        #endregion
        #region Методы
        public bool AddNewPhoneNumber(string phoneNumber)
        {
            return true;
        }

        public bool DeletePhoneNumber(string phoneNumber)
        {
            return true;
        }

        public Subscriber SearchSubscriberByPhoneNumber(string phoneNumber)
        {

        }

        public List<string> GetPhoneNumbersBySubscriber(Subscriber user)
        {

        }

        public static Phonebook GetInstance()
        {
            if (instance == null)
                instance = new Phonebook();
            return instance;
        }
        #endregion
        #region Конструкторы
        private Phonebook()
        {

        }
        #endregion
    }
}
