using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Android.Content;
using Android.Support.V7.Widget;
using Android.Views;
using WordMemo.ViewHolders;
using WordMemo.ViewModels;


namespace WordMemo.ViewAdapters
{
    public class WordsAdapter : RecyclerView.Adapter
    {
        private readonly List<Word> _words;
        private readonly MainActivity _activity;

        public WordsAdapter(MainActivity activity, ref List<Word> words)
        {
            _words = words;
            _activity = activity;
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

            vh.BaseWord.FocusChange += (sender, args) =>
            {
                if (!args.HasFocus)
                    _activity.WordManager.Save(_words[position]);
            };

            vh.WordTranslation.FocusChange += (sender, args) => 
            {
                if (!args.HasFocus)
                    _activity.WordManager.Save(_words[position]);
            };
        }

        public override int ItemCount => _words.Count;

        public void AddWord(Word newWord)
        {
            _words.Add(newWord);

            this.NotifyDataSetChanged();
        }
    }
}