using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SQLite;
using WordMemo.Contracts;
using WordMemo.Managers;
using WordMemo.ViewModels;

namespace WordMemo.UnitTests
{
    [TestFixture]
    public class PersistentWordTests
    {
        private string dbName;

        public IAsyncManager<Word> PersistentManager;

        [SetUp]
        public void Init()
        {
            dbName = "testdb.db";
            PersistentManager = new PersistentWordManager<Word>(dbName);
        }

        [Test]
        public async void word_table_exists()
        {
            var result = await PersistentManager.GetWordCount();

            Assert.That(result, Is.GreaterThanOrEqualTo(0));
        }

        [Test]
        public async void one_new_word_inserted_to_db()
        {
            var newWord = GetNewWordEntity();

            var insertedWordsCount = await PersistentManager.Save(newWord);

            Assert.AreEqual(1, insertedWordsCount);
        }

        [Test]
        public async void database_contains_no_words_after_word_delete()
        {
            string wordTextToDelete = GetExistingWordEntity().BaseText;
            var newWord = await PersistentManager.GetByBaseText(wordTextToDelete);

            if (newWord != null)
            {
                await PersistentManager.Delete(newWord);
            }
            
            var dbRowsCount = await PersistentManager.GetAll();

            Assert.AreEqual(0, dbRowsCount.ToList().Count);
        }

        [TearDown]
        public async void Finish()
        {
            string wordTextToDelete = GetExistingWordEntity().BaseText;
            var wordToDelete = await PersistentManager.GetByBaseText(wordTextToDelete);

            await PersistentManager.Delete(wordToDelete);
        }

        private Word GetExistingWordEntity()
        {
            return new Word()
            {
                ID = 1,
                BaseText = "order",
                TranslationText = "porządek"
            };
        }

        private Word GetNewWordEntity()
        {
            return new Word()
            {
                BaseText = "order",
                TranslationText = "porządek"
            };
        }
    }
}
