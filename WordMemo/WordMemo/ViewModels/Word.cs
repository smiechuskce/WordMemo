using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordMemo.ViewModels
{
    public class Word
    {

        public int WordID { get; private set; }

        public string WordBaseText { get; private set; }

        public string WordTranslationText { get; private set; }

        public Word(int wordID, string wordBaseText, string wordTranslationText)
        {
            WordID = wordID;
            WordBaseText = wordBaseText;
            WordTranslationText = wordTranslationText;
        }

        public override string ToString()
        {
            return $"{WordID}. {WordBaseText} => {WordTranslationText}";
        }
    }
}
