using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public class Subscriber
    {
        #region Поля
        #endregion

        #region Свойства
        public string Name { get; set; }
        public List<string> PhoneNumberList { get; set; }
        #endregion

        #region Методы

        public bool AddPhoneNumber(string phoneNumber)
        {
            this.PhoneNumberList.Add(phoneNumber);
            return true;
        }
        public bool DeletePhoneNumber(string phoneNumber)
        {
            //return this.PhoneNumberList.Remove(phoneNumber);
            return true;
        }

        #endregion

        #region Конструкторы
        public Subscriber() : this(string.Empty, string.Empty){}
        public Subscriber(string name) : this(name, string.Empty) {}
        public Subscriber(string name, string phoneNumber)
        {
            PhoneNumberList = new List<string>();
            this.Name = name;
        }
        #endregion
    }
}
