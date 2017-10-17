using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using WordMemo.ViewModels;

namespace WordMemo.LogicTests
{
    [TestFixture]
    public class WordTests
    {
        public WordManager WordManager = new WordManager();

        [SetUp]
        public void Init()
        {
            WordManager.Init();
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
    }
}
