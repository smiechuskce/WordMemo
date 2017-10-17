using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using WordMemo.DataAccess.Contracts;

namespace WordMemo.ViewModels
{
    public class WordManager : IWordManager
    {
        //static Word[] _mBuiltInWordsViewModel =
        //{
        //    new Word { mWordID = 1,
        //               mWordBaseText = "issue",
        //               mWordTranslationText = "problem" },

        //    new Word { mWordID = 2,
        //               mWordBaseText = "tempered",
        //               mWordTranslationText = "hartowany" },

        //    new Word { mWordID = 3,
        //               mWordBaseText = "tighten",
        //               mWordTranslationText = "dokręcać, napinać" }
        //};

        public List<Word> Words { get; private set; }

        public WordManager()
        {
            Words = GetAll().ToList();
        }

        public int NumWords => Words.Count();

        public IEnumerable<Word> GetAll()
        {
            Word[] words = new Word[]
            {
                new Word(1, "issue", "problem"),
                new Word(2, "tempered", "hartowany"),
                new Word(3, "tighten", "dokręcać, napinać")
            };

            return words;
        }

        public Word this[int index] => Words[index];

        public Word GetWord(int id)
        {
            throw new NotImplementedException();
        }

        public void Add()
        {
            throw new NotImplementedException();
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public void SearchById(int id)
        {
            throw new NotImplementedException();
        }

        public void SearchByBaseText(string baseText)
        {
            throw new NotImplementedException();
        }
    }
}
