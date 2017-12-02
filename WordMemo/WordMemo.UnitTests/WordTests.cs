using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using WordMemo.ViewModels;

namespace WordMemo.UnitTests
{
    [TestFixture]
    public class WordTests
    {
        
        public WordManager<Word> WordManager;

        [SetUp]
        public void Init()
        {
            WordManager = new WordManager<Word>();
            WordManager.Init(new []
            {
                new Word(1, "issue", "problem"),
                new Word(2, "tempered", "hartowany"),
                new Word(3, "tighten", "dokręcać, napinać")
            });
        }

        [Test]
        public void initial_word_list_is_not_empty()
        {
            // Arrange
            // may be empty?

            // Act
            var wordsCount = WordManager.NumWords;

            // Assert
            Assert.GreaterOrEqual(wordsCount, 0);
        }

        [Test]
        public void initial_word_list_contains_more_than_3_words()
        {
            WordManager.Add(new Word(4, "test", "testować"));

            var wordsCount = WordManager.NumWords;

            Assert.GreaterOrEqual(wordsCount, 4);
        }

        [Test]
        public void word_is_being_deleted_from_initial_list()
        {
            Word word = new Word(2, "tempered", "hartowany");

            int numDeleted = WordManager.Delete(word);

            Assert.AreEqual(1, numDeleted);
        }
    }
}
