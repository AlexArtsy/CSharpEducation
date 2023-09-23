using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Task4
{
    internal class DataBaseRepo<T> : IRepository<T> where T : IEntity, new()
    {
        #region Поля
        private readonly string connectionString;
        #endregion

        #region Методы
        public void Create(T entity)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                SqlCommand command = new SqlCommand();
                command.CommandText = $"INSERT INTO {connection.Database}(Id, Name, Age) VALUES({entity.Id}, {entity.Name}, {entity.Age})";
                command.Connection = connection;
                command.ExecuteNonQuery();
            }
        }

        public T Read(string id)
        {
            T entity = new T();

            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                SqlCommand command = new SqlCommand();
                command.CommandText = $"SELECT Id, Name, Age FROM {connection.Database} WHERE Id='{id}'";
                command.Connection = connection;

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var Id = reader.GetString(0);
                            var name = reader.GetString(1);
                            var age = reader.GetInt32(2);

                            entity.Id = Id;
                            entity.Name = name;
                            entity.Age = age;
                        }
                    }
                }
            }
            return entity;

        }

        public void Update(T entity)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                SqlCommand command = new SqlCommand();
                command.CommandText = $"UPDATE {connection.Database} SET Age={entity.Age}, Name='{entity.Name}' WHERE Id='{entity.Id}'";
                command.Connection = connection;
                command.ExecuteNonQuery();
            }
        }

        public void Delete(string id)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                SqlCommand command = new SqlCommand();
                command.CommandText = $"DELETE FROM {connection.Database} WHERE Id='{id}'";
                command.Connection = connection;
                command.ExecuteNonQuery();
            }
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
