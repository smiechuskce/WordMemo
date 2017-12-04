using System;
using System.IO;
using WordMemo.DataAccess;

namespace WordMemo.UnitTests.Utils
{
    public class FileHelper : IFileHelper
    {
        public string GetLocalFilePath(string filename)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;
            
            return Path.Combine(path, filename);
        }

        public int DeleteFile(string filename)
        {
            throw new NotImplementedException();
        } 
    }
}