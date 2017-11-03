using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Android.Support.V7.Widget;
using Android.Views;
using WordMemo.ViewHolders;
using WordMemo.ViewModels;


namespace WordMemo.ViewAdapters
{
    public class WordsAdapter : RecyclerView.Adapter
    {
        private readonly List<Word> _words;

        public WordsAdapter(List<Word> words)
        {
            _words = words;
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
            vh.BaseWord.Text = _words[position].BaseText;
            vh.WordTranslation.Text = _words[position].TranslationText;
        }

        public override int ItemCount => _words.Count;

        public void AddWord(Word newWord)
        {
            _words.Add(newWord);

            this.NotifyDataSetChanged();
        }
    }
}