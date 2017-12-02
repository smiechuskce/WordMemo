using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using WordMemo.DataAccess.Contracts;

namespace WordMemo.ViewModels
{
    public class WordManager<T> : ISyncManager<T> where T: Word
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

        private List<T> Words { get; set; }

        public WordManager()
        {
            
        }

        public int NumWords => Words.Count();

        public void Init(IEnumerable<T> words)
        {
            if (words == null)
                throw new ArgumentNullException();

            Words = words.ToList();
        }

        public IEnumerable<T> GetAll()
        {
            if (Words == null)
                throw new ArgumentNullException();
            else
                return Words;
        }

        public T this[int index] => Words[index];

        public int Add(T word)
        {
            Words.Add(word);

            return 1;
        }

        public int Delete(T word)
        {
            return Words.Remove(Words.FirstOrDefault(w => w.ID == word.ID)) ? 1 : 0;
        }

        public T GetById(int id)
        {
            throw new NotImplementedException();
        }

        public T GetByBaseText(string baseText)
        {
            throw new NotImplementedException();
        }
    }
}
