using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using WordMemo.Contracts;
using WordMemo.Logic;
using WordMemo.Managers;
using WordMemo.SharedUtils;
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
            await mWordLogic.UpdateWordList();
            Word word = new Word(1, "testować", "to test");
            mWordLogic.WordList.Add(word);

            // Act
            UpdateWord(word);

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
        public void words_are_being_imported_from_csv_text()
        {
            string wordCsvTextContent = File.ReadAllText("words.csv");

            mWordLogic.ImportFromCsv(wordCsvTextContent);

            Assert.True(mWordLogic.WordList.Count > 0, "Word list is empty. Something went wrong during CSV import.");
        }

        private async void UpdateWord(Word word)
        {
            word.BaseText = "robić";
            word.TranslationText = "do";
            await mWordLogic.SaveWord(word);
        } 
    }
}
