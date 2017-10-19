using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordMemo.ViewModels;

namespace WordMemo.DataAccess.Contracts
{
    public interface IWordManager
    {
        void Init();

        IEnumerable<Word> GetAll();

        void Add(Word word);

        void Delete(Word word);

        Word GetById(int id);

        Word GetByBaseText(string baseText);
    }
}
