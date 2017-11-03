using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using WordMemo.DataAccess.Annotations;

namespace WordMemo.ViewModels
{
    public class Word : INotifyPropertyChanged
    {

        [PrimaryKey, AutoIncrement] // Really need the SQLite.NET-PCL reference?...
        public int ID { get; set; }

        public string BaseText { get; set; }

        public string TranslationText { get; set; }

        public Word(int wordID, string wordBaseText, string wordTranslationText)
        {
            ID = wordID;
            BaseText = wordBaseText;
            TranslationText = wordTranslationText;
        }

        public Word()
        {
            
        }
      
        public override string ToString()
        {
            return $"{ID}. {BaseText} => {TranslationText}";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
