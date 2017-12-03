using System;
using System.IO;
using System.Runtime.InteropServices;
using WordMemo.DataAccess;

namespace WordMemo.Utils
{
    public class FileHelper : IFileHelper
    {
        private ExecutablePlatform platform;

        public FileHelper(ExecutablePlatform platform)
        {
            this.platform = platform;
        }

        public string GetLocalFilePath(string filename)
        {
            string path = null;

            switch (platform)
            {
                case ExecutablePlatform.Android:
                    path = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                    break;

                case ExecutablePlatform.PcRuntime:
                    path = AppDomain.CurrentDomain.BaseDirectory;
                    break;
            }

            return path == null ? null : Path.Combine(path, filename);
        }

        public int DeleteFile(string filename)
        {
            throw new NotImplementedException();
        }
    }

    public enum ExecutablePlatform
    {
        Android,
        iOS,
        PcRuntime
    }
}