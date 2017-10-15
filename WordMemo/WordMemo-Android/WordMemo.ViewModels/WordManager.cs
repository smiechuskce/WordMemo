using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordMemo.ViewModels
{
    public class WordManager// Temporary model initiation class
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

        public Word[] _mWords { get; private set; }

        public WordManager()
        {
            _mWords = GetWordList();
        }

        public int NumWords
        {
            get { return _mWords.Length; }
        }

        public Word this[int i]
        {
            get { return _mWords[i]; }
        }

        private Word[] GetWordList()
        {
            Word[] words = new Word[]
            {
                new Word(1, "issue", "problem"),
                new Word(2,"tempered","hartowany"),
                new Word(3,"tighten","dokręcać, napinać")
            };

            return words;
        }
    }
}
