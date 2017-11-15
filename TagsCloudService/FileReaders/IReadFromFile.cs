using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagsCloudService.FileReaders
{
    public interface IReadFromFile
    {
        bool SupportFile(string fileExtension);

        IEnumerable<string> ReadRows(string fileName);
    }
}
