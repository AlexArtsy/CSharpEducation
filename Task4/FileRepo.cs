using System.IO;
using System.Text.Json;

namespace Task4
{
    public class FileRepo<T> : IRepository<T> where T : IEntity
    {
        #region Поля
        private readonly string filepath;
        #endregion

        #region Свойства
        #endregion

        #region Методы
        public void Create(T entity)
        {
            var data = JsonSerializer.Deserialize<List<T>>(File.ReadAllText(this.filepath));
            data.Add(entity);
            File.WriteAllText(this.filepath, JsonSerializer.Serialize(data));
        }

        public T Read(string id)
        {
            return JsonSerializer.Deserialize<List<T>>(File.ReadAllText(this.filepath)).Find(e => e.Id == id);
        }

        public void Update(T entity)
        {
            var data = JsonSerializer.Deserialize<List<T>>(File.ReadAllText(this.filepath));
            data[data.FindIndex(e => e.Id == entity.Id)] = entity;
            File.WriteAllText(this.filepath, JsonSerializer.Serialize(data));
        }

        public void Delete(string id)
        {
            var data = JsonSerializer.Deserialize<List<T>>(File.ReadAllText(this.filepath));
            if (!data.Remove(data.Find(e => e.Id == id)))
            {
                throw new Exception("Удаление не произошло: сущность не обнаружена в файле");
                return;
            }
            File.WriteAllText(this.filepath, JsonSerializer.Serialize(data));
        }
        #endregion

        #region Конструкторы
        public FileRepo(string filepath)
        {
            this.filepath = filepath;
        }
        #endregion
    }
}