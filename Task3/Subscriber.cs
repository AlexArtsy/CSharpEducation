using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public class Subscriber
    {
        #region Поля
        #endregion

        #region Свойства
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<string> PhoneNumberList { get; set; }
        #endregion

        #region Методы

        public bool AddPhoneNumber(string phoneNumber)
        {
            if (this.PhoneNumberList.Contains(phoneNumber))
            {
                return false;
            }
            this.PhoneNumberList.Add(phoneNumber);
            return true;
        }
        public bool DeletePhoneNumber(string phoneNumber)
        {
            return this.PhoneNumberList.Remove(phoneNumber);
        }

        #endregion

        #region Конструкторы
        public Subscriber() : this(string.Empty, string.Empty){}
        public Subscriber(string name) : this(name, string.Empty) {}
        public Subscriber(string name, string phoneNumber)
        {
            PhoneNumberList = new List<string>();
            this.Id = Guid.NewGuid();
            this.Name = name;
            this.PhoneNumberList.Add(phoneNumber);
        }
        #endregion
    }
}
