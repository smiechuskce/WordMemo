using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using PCLStorage;
using WordMemo.DataAccess;

namespace WordMemo.DataAccess.SharedUtils
{
    public class FileHelper : IFileHelper
    {
        public string GetLocalFilePath(string filename)
        {
            IFolder rootFolder = FileSystem.Current.LocalStorage;
            
            return Path.Combine(rootFolder.Path, filename);
        }

        public async void DeleteFile(string filename)
        {
            IFolder rootFolder = FileSystem.Current.LocalStorage;
            IFile file = await rootFolder.GetFileAsync(filename);

            await file.DeleteAsync();
        }

        public async Task<string> ReadFileContent(string fileName)
        {
            IFolder rootFolder = FileSystem.Current.LocalStorage;

            IFile file = await rootFolder.GetFileAsync(fileName);

            return await file.ReadAllTextAsync();
        }
    }
}