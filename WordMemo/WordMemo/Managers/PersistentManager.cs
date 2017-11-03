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
    public class PersistentManager<T> : IAsyncManager<T> where T : Word, new()
    {
        private SQLiteAsyncConnection SQLiteConnection;

        public PersistentManager(string dbPath)
        {
            SQLiteConnection = new SQLiteAsyncConnection(dbPath);
            SQLiteConnection.CreateTableAsync<T>().Wait();
        }

        public void Init(IEnumerable<T> words)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await SQLiteConnection.Table<T>().ToListAsync();
        }

        public async Task<int> Add(T word)
        {
            return await SQLiteConnection.InsertAsync(word);
        }

        public async Task<int> Delete(T word)
        {
            return await SQLiteConnection.DeleteAsync(word);
        }

        public Task<T> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<T> GetByBaseText(string baseText)
        {
            return await SQLiteConnection.Table<T>().Where(w => w.BaseText.Equals(baseText)).FirstOrDefaultAsync();
        }
    }
}
