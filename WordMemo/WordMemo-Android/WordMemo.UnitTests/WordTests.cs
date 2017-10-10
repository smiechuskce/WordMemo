using System;
using NUnit.Framework;
using WordMemo.ViewModels;


namespace WordMemo.UnitTests
{
    [TestFixture]
    public class WordTests
    {
        [Test]
        public void InitialWordListIsNotEmpty()
        {
            Words allWords = new Words();
            
            Assert.GreaterOrEqual(allWords.NumWords, 0);      
        }
    }
}