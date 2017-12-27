using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordMemo.DataAccess
{
    public interface IFileHelper<T>
    {
        string GetLocalFilePath(string filename);

        void DeleteFile(string filename);

        T ReadFileContent(string fileName);
    }
}
