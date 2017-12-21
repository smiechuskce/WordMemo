﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using WordMemo.DataAccess.Contracts;
using WordMemo.DataAccess.Logic;
using WordMemo.DataAccess.Managers;
using WordMemo.DataAccess.SharedUtils;
using WordMemo.ViewModels;

namespace WordMemo.UnitTests
{
    [TestFixture]
    public class WordLogicTests
    {
        public WordLogic mWordLogic;

        [SetUp]
        public async void Init()
        {
            mWordLogic = new WordLogic(new PersistentWordManager<Word>(":memory:"));
            await mWordLogic.UpdateWordList();
        }

        [Test]
        public async void word_is_updated_after_modifying_it()
        {
            // Arrange
            Word word = new Word(1, "testować", "to test");
            mWordLogic.WordList.Add(word);

            // Act
            await SaveWord();

            //Assert
            Assert.AreEqual("1. robić => do", mWordLogic.WordList[0].ToString());
        }

        [Test]
        public async void word_is_being_deleted()
        {
            Word wordToDelete = new Word(1, "testować", "to Test");
            await mWordLogic.SaveWord(wordToDelete);

            await mWordLogic.DeleteWord(wordToDelete);
            var wordsGetResult = await mWordLogic.GetWords();

            Assert.AreEqual(wordsGetResult.ToList().Count, 0);
        }

        [Test]
        public void words_are_being_imported_from_csv_file()
        {
            var fileName = "words.csv";

            FileHelper fh = new FileHelper();
            mWordLogic.ImportFromFile(fileName);

            Assert.True(mWordLogic.WordList.Count > 0, "Word list is empty. Something went wrong during CSV import.");
        }

        public async Task SaveWord()
        {
            await mWordLogic.SaveWord(new Word("robić", "do"));
        } 
    }
}
