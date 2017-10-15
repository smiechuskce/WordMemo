using System;
using NUnit.Framework;
using WordMemo.ViewModels;

namespace WordMemo.LogicTests
{
    [TestFixture]
    public class WordTests
    {
        [Test]
        public void is_initial_word_list_not_empty()
        {
            WordManager allWordManager = new WordManager();

            Assert.GreaterOrEqual(allWordManager.NumWords, 0);
        }
    }
}
