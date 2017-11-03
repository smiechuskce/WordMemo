using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordMemo.ViewModels;

namespace WordMemo.DataAccess.Contracts
{
    public interface ISyncManager<T> : IManager<T>
    {
        void Init(IEnumerable<T> words = null);

        IEnumerable<T> GetAll();

        int Add(T word);

        int Delete(T word);

        T GetById(int id);

        T GetByBaseText(string baseText);
    }
}
