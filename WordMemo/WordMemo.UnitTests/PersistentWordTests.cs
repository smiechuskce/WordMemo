﻿using System;
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

            Assert.AreEqual("order", result.BaseText);
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
            var newWord = GetExistingWordEntity();

            await PersistentManager.Delete(newWord);
            var dbRowsCount = await PersistentManager.GetAll();

            Assert.AreEqual(0, dbRowsCount.ToList().Count);
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

        [TearDown]
        public void Finish()
        {
            // TODO: Remove database file from executable path
        }

    }
}
