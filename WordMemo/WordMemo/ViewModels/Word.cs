using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WordMemo.DataAccess.Annotations;

namespace WordMemo.ViewModels
{
    public class Word : INotifyPropertyChanged
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

        public Word()
        {
            
        }

        public override string ToString()
        {
            return $"{WordID}. {WordBaseText} => {WordTranslationText}";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
