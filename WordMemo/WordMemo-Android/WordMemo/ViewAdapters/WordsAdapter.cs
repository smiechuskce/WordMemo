using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Support.V7.Widget;
using WordMemo.ViewModels;
using WordMemo.ViewHolders;

namespace WordMemo.ViewAdapters
{
    public class WordsAdapter : RecyclerView.Adapter
    {
        private Words mWords;
        public WordsAdapter(Words words)
        {
            mWords = words;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.WordView, parent, false);

            WordsViewHolder vh = new WordsViewHolder(itemView);
            return vh;
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            WordsViewHolder vh = holder as WordsViewHolder;
            vh.BaseWord.Text = mWords[position].WordBaseText;
            vh.WordTranslation.Text = mWords[position].WordTranslationText;
        }

        public override int ItemCount => mWords.NumWords;
    }
}