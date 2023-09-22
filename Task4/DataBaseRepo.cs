using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    internal class DataBaseRepo<T> : IRepository<T> where T : IEntity
    {
        #region Поля
        private string connectionString;
        private SqlConnection connection;
        #endregion

        #region Свойства
        #endregion

        #region Методы
        public void Create(T entity)
        {

        }

        public T Read(string id)
        {

        }

        public void Update(T entity)
        {

        }

        public void Delete(string id)
        {

        }
        #endregion

        #region Конструкторы
        public DataBaseRepo(string connectionString)
        {
            this.connectionString = connectionString;
        }
        #endregion
    }
}
