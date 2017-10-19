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

        private List<Word> Words { get; set; }

        public WordManager()
        {

        }

        public int NumWords => Words.Count();

        public void Init()
        {
            Word[] words = new Word[]
            {
                new Word(1, "issue", "problem"),
                new Word(2, "tempered", "hartowany"),
                new Word(3, "tighten", "dokręcać, napinać")
            };

            Words = words.ToList();
        }

        public IEnumerable<Word> GetAll()
        {
            if (Words == null)
                throw new ArgumentNullException();
            else
                return Words;
        }

        public Word this[int index] => Words[index];

        public void Add(Word word)
        {
            Words.Add(word);
        }

        public void Delete(Word word)
        {
            throw new NotImplementedException();
        }

        public Word GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Word GetByBaseText(string baseText)
        {
            throw new NotImplementedException();
        }
    }
}
