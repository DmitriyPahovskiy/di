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
        public IEnumerable<string> ReadRows(string fileName)
        {
            return File.ReadAllLines(fileName);
        }
    }
}
