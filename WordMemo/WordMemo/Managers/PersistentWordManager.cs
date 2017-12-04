using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using WordMemo.DataAccess.Contracts;
using WordMemo.ViewModels;

namespace WordMemo.DataAccess.Managers
{
    public class PersistentWordManager<T> : IAsyncManager<T> where T : Word, new()
    {
        private SQLiteAsyncConnection SQLiteConnection;

        public PersistentWordManager(string dbPath)
        {
            SQLiteConnection = new SQLiteAsyncConnection(dbPath);
            InitConnection();
        }

        public void Init(IEnumerable<T> words)
        {
            throw new NotImplementedException();
        }

        public async void InitConnection()
        {
            await SQLiteConnection.CreateTableAsync<T>();
        }

        //public async Task<IEnumerable<T>> GetAll()
        public async Task<IEnumerable<T>> GetAll()
        {
            return await SQLiteConnection.Table<T>().ToListAsync();
        }

        public async Task<int> Save(T word)
        {
            if (word.ID != 0)
                return await SQLiteConnection.UpdateAsync(word);
            
            return await SQLiteConnection.InsertAsync(word);
        }

        public async Task<int> Delete(T word)
        {
            return await SQLiteConnection.DeleteAsync(word);
        }

        public async Task<T> GetById(int id)
        {
            return await SQLiteConnection.Table<T>().Where(w => w.ID == id).FirstOrDefaultAsync();
        }

        public async Task<T> GetByBaseText(string baseText)
        {
            return await SQLiteConnection.Table<T>().Where(w => w.BaseText.Equals(baseText)).FirstOrDefaultAsync();
        }

        public async Task<int> GetWordCount()
        {
            var result = await SQLiteConnection.Table<T>().CountAsync();
            return result;
        }
    }
}
