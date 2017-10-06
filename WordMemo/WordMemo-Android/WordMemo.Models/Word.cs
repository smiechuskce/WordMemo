using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite.Net.Attributes;
using Xamarin.Forms;

namespace WordMemo.Models
{
    public class Word
    {
        [PrimaryKey, AutoIncrement] // Really need the SQLite.NET-PCL reference?...
        public int ID { get; set; }

        public string BaseText { get; set; }

        public string TranslationText { get; set; }

        public Word()
        {
            
        }
    }
}
