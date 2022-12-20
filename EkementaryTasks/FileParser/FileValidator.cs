using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileParser
{
    class FileValidator : IFileValidator
    {
        public bool isNotFileEmpty(string path)
        {
            return new FileInfo(path).Length == 0;
        }

        public bool isFileExist(string path)
        {
            return File.Exists(path);
        }

        public bool isFileTxt(string path)
        {
            return new FileInfo(path).Extension == ".txt";
        }

        public bool validateAll(string path, out IList<string> possibleErrors)
        {
            possibleErrors = new List<string>();

            if (!isFileExist(path))
            {
                possibleErrors.Add("File does'not exist!!!");
                return false;
            }

            if (isNotFileEmpty(path))
            {
                possibleErrors.Add("File is empty!!!");
                return false;
            }

            if (!isFileTxt(path))
            {
                possibleErrors.Add("File isn't have .txt extension!!!");
                return false;
            }

            return true;
        }
    }
}
