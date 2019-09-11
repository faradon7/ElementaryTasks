using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IFileValidator
    {
        bool isFileExist(string path);

        bool isFileTxt(string path);

        bool isNotFileEmpty(string path);

        bool validateAll(string path, out List<string> possibleErrors);
    }
}
