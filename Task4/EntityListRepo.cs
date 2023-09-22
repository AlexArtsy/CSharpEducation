using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Task4
{
    internal class EntityListRepository<T> : IRepository<T> where T : IEntity
    {
        #region Поля
        #endregion

        #region Свойства
        public List<T> Storage { get; set; }
        #endregion

        #region Методы
        public void Create(T entity)
        { 
            this.Storage.Add(entity);
        }

        public T Read(string id)
        {
            return this.Storage.Find(e => e.Id == id);
        }

        public void Update(T entity)
        {
            Storage[Storage.FindIndex(e => e.Id == entity.Id)] = entity;
        }

        public void Delete(string id)
        {
            if (!Storage.Remove(Storage.Find(e => e.Id == id)))
            {
                throw new Exception("Удаление не произошло: сущность не обнаружена в памяти");
                return;
            }
        }
        #endregion

        #region Конструкторы
        public EntityListRepository(List<T> storage)
        {
            this.Storage = storage;
        }
        #endregion 
    }
}
