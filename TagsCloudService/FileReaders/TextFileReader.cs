using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagsCloudService.FileReaders
{
    public class TextFileReader : IReadFromFile
    {
        private const string SupportedFileExtension = "txt";
        public bool SupportFile(string fileExtension)
        {
            return fileExtension.Trim('.').ToLowerInvariant() == SupportedFileExtension;
        }

        public IEnumerable<string> ReadRows(string fileName)
        {
            return File.ReadAllLines(fileName);
        }
    }
}
