using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.Content;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using WordMemo.Activities;
using WordMemo.ViewHolders;
using WordMemo.ViewModels;


namespace WordMemo.ViewAdapters
{
    public class WordsAdapter : RecyclerView.Adapter
    {
        private readonly List<Word> _words;
        private readonly MainActivity _activity;

        public WordsAdapter(MainActivity activity, List<Word> words)
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

            vh.BaseWord.TextChanged += (sender, args) =>
            {
                _words[position].BaseText = args.Text.ToString();
            };

            vh.WordTranslation.TextChanged += (sender, args) =>
            {
                _words[position].TranslationText = args.Text.ToString();
            };

            vh.BaseWord.FocusChange += async (sender, args) =>
            {
                if (_words.Count > 0 && !args.HasFocus)
                {
                    string text = _words[position].BaseText;
                    await _activity.WordLogic.SaveWord(_words[position]);
                }                    
            };

            vh.WordTranslation.FocusChange += async (sender, args) =>
            {
                if (_words.Count > 0 && !args.HasFocus)
                    await _activity.WordLogic.SaveWord(_words[position]);
            };

            vh.BaseWord.KeyPress += (sender, args) =>
            {
                if (args.KeyCode == Keycode.Enter)
                {
                    vh.WordTranslation.RequestFocus();
                    args.Handled = true;
                }
                else
                    args.Handled = false;
            };           
        }

        public override int ItemCount => _words?.Count ?? 0;

        public void AddWord(Word newWord)
        {
            _words.Add(newWord);
        }

        public void AddWords(IEnumerable<Word> words)
        {
            _words.AddRange(words);
        }

        public async void DeleteWord(int position)
        {
            Word wordToRemove = _words[position];
            _words.Remove(wordToRemove);
            await _activity.WordLogic.DeleteWord(wordToRemove);
        }

    }
}