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
using WordMemo.Models;

namespace WordMemo.UnitTests
{
    [TestFixture]
    public class PersistentWordTests
    {
        public SQLiteAsyncConnection InMemorySqliteConnection;

        public IAsyncWordManager<Word> PersistentWordManager;

        [SetUp]
        public async void Init()
        {
            InMemorySqliteConnection = new SQLiteAsyncConnection(":memory:");

            PersistentWordManager = new PersistentWordManager<Word>(InMemorySqliteConnection);
            await CreateWordTable();
        }

        [Test]
        public async void word_table_exists()
        {

            var result = await PersistentWordManager.GetByBaseText("order");

            Assert.AreEqual(result.BaseText, "order");
        }

        [Test]
        public async void one_new_word_inserted_to_db()
        {
            var newWord = GetWordEntity();

            var insertedWordsCount = await PersistentWordManager.Add(newWord);

            Assert.AreEqual(insertedWordsCount, 1);
        }

        [Test]
        public void database_contains_no_words_after_word_delete()
        {
            var newWord = GetWordEntity();

            PersistentWordManager.Delete(newWord);
            var dbRowsCount = PersistentWordManager.GetAll().Result.ToList().Count;

            Assert.AreEqual(dbRowsCount, 0);
        }

        

        private async Task<CreateTablesResult> CreateWordTable()
        {
            return await InMemorySqliteConnection.CreateTableAsync<Word>();
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
