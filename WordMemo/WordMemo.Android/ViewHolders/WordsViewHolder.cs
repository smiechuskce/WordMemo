using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace WordMemo.ViewHolders
{
    public class WordsViewHolder : RecyclerView.ViewHolder
    {
        public EditText BaseWord { get; set; }
        public EditText WordTranslation { get; set; }

        public WordsViewHolder(View itemView) : base(itemView)
        {           
            BaseWord = itemView.FindViewById<EditText>(Resource.Id.edit_text_base_word);
            WordTranslation = itemView.FindViewById<EditText>(Resource.Id.edit_text_word_translation);     
        }
    }
}