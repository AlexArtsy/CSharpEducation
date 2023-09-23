using System.IO;
using System.Text.Json;

namespace Task4
{
    public class FileRepo<T> : IRepository<T> where T : IEntity, IDisposable
    {
        #region Поля
        private readonly string filepath;
        private EntityListRepo<T> fileData;
        private bool disposed = false;
        private DateTime lastWriteTime;
        #endregion

        #region Методы
        #region CRUD
        public void Create(T entity)
        {
            UpdateFileDataWhenChanged();

            this.fileData.Create(entity);
        }

        public T Read(string id)
        {
            UpdateFileDataWhenChanged();

            return this.fileData.Read(id);
        }

        public void Update(T entity)
        {
            UpdateFileDataWhenChanged();

            this.fileData.Update(entity);
        }

        public void Delete(string id)
        {
            UpdateFileDataWhenChanged();

            this.fileData.Delete(id);
        }
        #endregion

        private void UpdateFileDataWhenChanged()
        {
            if (IsFileChanged())
                SetFileData();
        }

        private void SetFileData()
        {
            var data = JsonSerializer.Deserialize<List<T>>(File.ReadAllText(this.filepath));
            this.fileData = new EntityListRepo<T>(data);
        }

        private bool IsFileChanged()
        {

            var fileInfo = new FileInfo(this.filepath);
            return fileInfo.LastWriteTime != this.lastWriteTime;
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
            SetFileData();
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