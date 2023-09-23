using System.IO;
using System.Text.Json;

namespace Task4
{
    public class FileRepo<T> : IRepository<T> where T : IEntity, IDisposable
    {
        #region Поля
        private readonly string filepath;
        private List<T> fileData;
        private bool disposed = false;
        private FileInfo fileInfo;
        private DateTime lastWriteTime;
        #endregion

        #region Свойства

        #endregion

        #region Методы
        #region CRUD
        public void Create(T entity)
        {
            UpdateFileDataWhenChanged();

            this.fileData.Add(entity);
        }

        public T Read(string id)
        {
            UpdateFileDataWhenChanged();

            return this.fileData.Find(e => e.Id == id);
        }

        public void Update(T entity)
        {
            UpdateFileDataWhenChanged();

            this.fileData[this.fileData.FindIndex(e => e.Id == entity.Id)] = entity;
        }

        public void Delete(string id)
        {
            UpdateFileDataWhenChanged();

            if (!this.fileData.Remove(this.fileData.Find(e => e.Id == id)))
            {
                throw new Exception("Удаление не произошло: сущность не обнаружена в файле");
                return;
            }
        }
        #endregion

        private void UpdateFileDataWhenChanged()
        {
            if (IsFileChanged())
                SetFileData();
        }

        private List<T> SetFileData()
        {
            return JsonSerializer.Deserialize<List<T>>(File.ReadAllText(this.filepath));
        }

        private bool IsFileChanged()
        {
            return this.fileInfo.LastWriteTime != this.lastWriteTime;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed) return;
            if (disposing)
            {
                File.WriteAllText(this.filepath, JsonSerializer.Serialize(this.fileData));
                this.lastWriteTime = DateTime.Now;
            }
            disposed = true;
        }
        #endregion

        #region Конструкторы
        public FileRepo(string filepath)
        {
            this.filepath = filepath;
            this.fileInfo = new FileInfo(filepath);
            this.fileData = SetFileData();
        }
        #endregion

        #region Деструкторы
        ~FileRepo()
        {
            Dispose(false);
        }
        #endregion
    }
}