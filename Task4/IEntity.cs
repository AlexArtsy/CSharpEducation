using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    public interface IEntity
    {
        //  Например зададим следующие свойства.
        string Id { get; set; }
        string Name { get; set; }
        int Age { get; set; }
    }
}
