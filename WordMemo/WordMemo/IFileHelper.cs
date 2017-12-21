﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordMemo.DataAccess
{
    public interface IFileHelper
    {
        string GetLocalFilePath(string filename);

        void DeleteFile(string filename);

        Task<string> ReadFileContent(string fileName);
    }
}
