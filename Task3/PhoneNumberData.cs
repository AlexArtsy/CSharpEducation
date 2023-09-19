using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public class PhoneNumberData
    {
        public Guid Id { get; set; }
        public string Value { get; set; }
        public PhoneNumberData(Guid id, string value)
        {
            this.Id = id;
            this.Value = value;
        }
    }
}
