using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordMemo.Models
{
    public class Word
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

    public class Words
    {
        static Word[] mBuiltInWords =
        {
            new Word { mWordID = 1,
                       mWordBaseText = "issue",
                       mWordTranslationText = "problem" },

            new Word { mWordID = 2,
                       mWordBaseText = "tempered",
                       mWordTranslationText = "hartowany" },

            new Word { mWordID = 3,
                       mWordBaseText = "tighten",
                       mWordTranslationText = "dokręcać, napinać" }
        };

        private Word[] mWords;

        public Words()
        {
            mWords = mBuiltInWords;
        }

        public int NumWords
        {
            get { return mWords.Length; }
        }

        public Word this[int i]
        {
            get { return mWords[i];  }
        }
    }
}
