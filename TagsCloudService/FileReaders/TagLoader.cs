using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TagsCloudService.Validators;

namespace TagsCloudService.FileReaders
{
    public class TagLoader
    {
        private readonly IEnumerable<IReadFromFile> fileReaders;
        private readonly IEnumerable<IValidateTag> tagValidators;

        public TagLoader(IEnumerable<IReadFromFile> fileReaders, IEnumerable<IValidateTag> tagValidators)
        {
            this.fileReaders = fileReaders;
            this.tagValidators = tagValidators;
        }

        public IDictionary<string, int> ReadValidTagsWithWeights(string fileName)
        {
            var fileExtension = Path.GetExtension(fileName);
            var reader = fileReaders.FirstOrDefault(r => r.SupportFile(fileExtension));
            if(reader == null)
                throw new NotSupportedException($"File type \"{fileExtension}\" is not supported.");

            var result = new Dictionary<string,int>();

            var tags = reader.ReadRows(fileName)
                .Where(t=> tagValidators.Any(v=>v.IsValid(t)))
                .Select(t=>t.ToLowerInvariant());

            int count;
            foreach(var word in tags)
                result[word.ToLower()] = result.TryGetValue(word.ToLower(), out count) ? count + 1 : 1;

            return result;
        }
    }
}
