using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    public interface IRepository<T> where T : IEntity
    {
        void Create(T entity);
        T Read(string id);
        void Update(T entity);
        void Delete(string id);
    }
}
