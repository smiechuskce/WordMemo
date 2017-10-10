using System;
using NUnit.Framework;
using WordMemo.ViewModels;

namespace WordMemo.LogicTests
{
    [TestFixture]
    public class WordTests
    {
        [Test]
        public void IsInitialWordListNotEmpty()
        {
            Words allWords = new Words();

            Assert.GreaterOrEqual(allWords.NumWords, 0);
        }
    }
}
