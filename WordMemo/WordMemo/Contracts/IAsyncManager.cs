﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordMemo.ViewModels;

namespace WordMemo.Contracts
{
    public interface IAsyncManager<T> : IManager<T>
    {
        void Init(IEnumerable<T> words = null);

        Task<IEnumerable<T>> GetAll();

        Task<int> Save(T word);

        Task<int> Delete(T word);

        Task<T> GetById(int id);

        Task<T> GetByBaseText(string baseText);

        Task<int> GetWordCount();
    }
}
