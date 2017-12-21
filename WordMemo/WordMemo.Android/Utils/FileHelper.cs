using System;
using System.IO;
using System.Threading.Tasks;
using WordMemo.DataAccess;

namespace WordMemo.Utils
{
    public class FileHelper : IFileHelper
    {
        public string GetLocalFilePath(string filename)
        {
            string path = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal);
             
            return Path.Combine(path, filename);
        }

        public void DeleteFile(string filename)
        {
            throw new NotImplementedException();
        }

        public Task<string> ReadFileContent(string fileName)
        {
            throw new NotImplementedException();
        }
    }
}