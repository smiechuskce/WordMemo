﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordMemo.DataAccess.Contracts;
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

        public async Task UpdateWordList()
        {

            IEnumerable<Word> word = await _wordManager.GetAll();
            WordList = word.ToList();
        }
    }
}
