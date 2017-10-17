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
        IEnumerable<Word> GetAll();

        Word GetWord(int id);

        void Add();

        void Delete();

        void SearchById(int id);

        void SearchByBaseText(string baseText);
    }
}
