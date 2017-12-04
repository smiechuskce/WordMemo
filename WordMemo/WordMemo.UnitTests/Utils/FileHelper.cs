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
            string finalPath = GetLocalFilePath(filename);

            if (File.Exists(finalPath))
            {
                try
                {
                    File.Delete(finalPath);
                    return 1;
                }
                catch (IOException e)
                {
                    // TODO: Rewrite when the logging system will be ready
                    System.Console.WriteLine(e.Message); 
                }               
            }
            return 0;
        } 
    }
}