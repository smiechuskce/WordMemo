using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using WordMemo.DataAccess.Contracts;
using WordMemo.DataAccess.Logic;
using WordMemo.DataAccess.Managers;
using WordMemo.ViewModels;

namespace WordMemo.UnitTests
{
    [TestFixture]
    public class WordLogicTests
    {
        public WordLogic mWordLogic;

        [SetUp]
        public void Init()
        {
            mWordLogic = new WordLogic();
        }

        [Test]
        public void word_is_updated_after_modifying_it()
        {
            // Arrange
            Word word = new Word(1, "testować", "to test");
            mWordLogic.WordList.Add(word);

            // Act
            SaveWord();

            //Assert
            Assert.AreEqual("robić", mWordLogic.WordList[0]);
        }

        public void SaveWord()
        {
            mWordLogic.SaveWord(new Word(1, "robić", "do"));
        } 
    }
}
