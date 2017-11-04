using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordMemo.ViewModels;

namespace WordMemo.DataAccess.Logic
{
    public class WordLogic
    {
        public List<Word> WordList { get; }

        public WordLogic()
        {
            WordList = new List<Word>();
        }

        public void SaveWord(Word word)
        {
            // TODO: Implement add new or update word on list

            throw new NotImplementedException();
        }
    }
}
