using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordMemo.DataAccess.Contracts;
using WordMemo.DataAccess.SharedUtils;
using WordMemo.ViewModels;

namespace WordMemo.DataAccess.Logic
{
    public class WordLogic
    {
        private readonly IAsyncManager<Word> _wordManager; 

        public List<Word> WordList { get; private set; }

        public WordLogic(IAsyncManager<Word> wordManager)
        {          
            _wordManager = wordManager;
            //UpdateWordList();
        }

        public async Task SaveWord(Word word)
        {
            await _wordManager.Save(word);
            await UpdateWordList();
        }

        public async Task DeleteWord(Word word)
        {
            await _wordManager.Delete(word);
            await UpdateWordList();
        }

        public async Task UpdateWordList()
        {
            IEnumerable<Word> words = await _wordManager.GetAll();
            WordList = words?.ToList() ?? new List<Word>();
        }

        public async Task<IEnumerable<Word>> GetWords()
        {
            return await _wordManager.GetAll();
        }

        public void ImportFromCsv(string csv)
        {
            WordList.AddRange(GetWordsFromCsv(csv));
        }

        private IEnumerable<Word> GetWordsFromCsv(string csv)
        {
            List<Word> words = new List<Word>();

            using (var reader = new StreamReader(new MemoryStream(Encoding.UTF8.GetBytes(csv))))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    words.Add(new Word(line.Split(',')[0], line.Split(',')[1]));
                }
            }
           
            return words;
        }
    }
}
