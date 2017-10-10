using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordMemo.ViewModels
{
    public class WordViewModel
    {
        public int mWordID;

        public string mWordBaseText;

        public string mWordTranslationText;

        public int WordID
        {
            get { return mWordID; }
        }

        public string WordBaseText
        {
            get { return mWordBaseText; }
        }

        public string WordTranslationText
        {
            get { return mWordTranslationText; }
        }
    }

    public class Words // Temporary model initiation class
    {
        //static WordViewModel[] _mBuiltInWordsViewModel =
        //{
        //    new WordViewModel { mWordID = 1,
        //               mWordBaseText = "issue",
        //               mWordTranslationText = "problem" },

        //    new WordViewModel { mWordID = 2,
        //               mWordBaseText = "tempered",
        //               mWordTranslationText = "hartowany" },

        //    new WordViewModel { mWordID = 3,
        //               mWordBaseText = "tighten",
        //               mWordTranslationText = "dokręcać, napinać" }
        //};

        private WordViewModel[] _mWordsViewModel;

        public Words()
        {
            _mWordsViewModel = GetWordList();
        }

        public int NumWords
        {
            get { return _mWordsViewModel.Length; }
        }

        public WordViewModel this[int i]
        {
            get { return _mWordsViewModel[i];  }
        }

        private WordViewModel[] GetWordList()
        {
            WordViewModel[] words = new WordViewModel[]
            {
                new WordViewModel { mWordID = 1,
                    mWordBaseText = "issue",
                    mWordTranslationText = "problem" },

                new WordViewModel { mWordID = 2,
                           mWordBaseText = "tempered",
                           mWordTranslationText = "hartowany" },

                new WordViewModel { mWordID = 3,
                           mWordBaseText = "tighten",
                           mWordTranslationText = "dokręcać, napinać" }
            };

            return words;
        }
    }
}
