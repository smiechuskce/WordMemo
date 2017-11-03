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
        
        public Manager<Word> Manager;

        [SetUp]
        public void Init()
        {
            Manager = new Manager<Word>();
            Manager.Init(new []
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
            var wordsCount = Manager.NumWords;

            // Assert
            Assert.GreaterOrEqual(wordsCount, 0);
        }

        [Test]
        public void initial_word_list_contains_more_than_3_words()
        {
            Manager.Add(new Word(4, "test", "testować"));

            var wordsCount = Manager.NumWords;

            Assert.GreaterOrEqual(wordsCount, 4);
        }
    }
}
