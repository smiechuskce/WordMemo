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
        public void Init()
        {
            InMemorySqliteConnection = new SQLiteAsyncConnection(":memory:");

            PersistentWordManager = new PersistentWordManager<Word>(InMemorySqliteConnection);
        }

        [Test]
        public async void one_new_word_inserted_to_db()
        {
            var newWord = new Word()
            {
                BaseText = "order",
                TranslationText = "porządek"
            };
            var result = await CreateWordTable();

            var insertedWordsCount = await PersistentWordManager.Add(newWord);

            Assert.AreEqual(insertedWordsCount, 1);
        }

        [Test]
        public async void word_table_exists()
        {
            var tableResult = await CreateWordTable();

            var result = await PersistentWordManager.GetByBaseText("order");

            Assert.AreEqual(result.BaseText, "order");
        }

        private async Task<CreateTablesResult> CreateWordTable()
        {
            return await InMemorySqliteConnection.CreateTableAsync<Word>();
        }

    }
}
