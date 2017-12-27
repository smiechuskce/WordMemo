using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using WordMemo.DataAccess;

namespace WordMemo.Utils
{
    public class FileHelper : IFileHelper<string>
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

        public string ReadFileContent(string fileName)
        {
            try
            {
                using (var sr = new StreamReader(fileName))
                {
                    StringBuilder sb = new StringBuilder();
                 
                    while (!sr.EndOfStream)
                    {
                        sb.Append(sr.ReadLine());
                    }

                    return sb.ToString();
                }
            }
            catch (Exception)
            {
                // TODO: Add error logging
                throw;
            }
        }
    }
}