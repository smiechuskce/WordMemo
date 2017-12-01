using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SQLite;
using WordMemo.DataAccess.Contracts;
using WordMemo.DataAccess.Managers;
using WordMemo.ViewModels;

namespace WordMemo.UnitTests
{
    [TestFixture]
    public class PersistentWordTests
    {
        public IAsyncManager<Word> PersistentManager;

        [SetUp]
        public void Init()
        {
            PersistentManager = new PersistentWordManager<Word>("testdb.db");
        }

        [Test]
        public async void word_table_exists()
        {

            var result = await PersistentManager.GetByBaseText("order");

            Assert.AreEqual(result.BaseText, "order");
        }

        [Test]
        public async void one_new_word_inserted_to_db()
        {
            var newWord = GetWordEntity();

            var insertedWordsCount = await PersistentManager.Save(newWord);

            Assert.AreEqual(insertedWordsCount, 1);
        }

        [Test]
        public void database_contains_no_words_after_word_delete()
        {
            var newWord = GetWordEntity();

            PersistentManager.Delete(newWord);
            var dbRowsCount = PersistentManager.GetAll().Result.ToList().Count;

            Assert.AreEqual(dbRowsCount, 0);
        }

        private Word GetWordEntity()
        {
            return new Word()
            {
                BaseText = "order",
                TranslationText = "porządek"
            };
        }

    }
}
