using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagsCloudService.Validators
{
    public class BoringWordsFilter : IValidateTag
    {
        private readonly HashSet<string> boringWords = new HashSet<string>
        {
            "я","ты","он","она","мы","они","кто","что",
            "без","в","для","за","из","к","на","над","о","об","от","по","под","пред","перед","при","про","с","у","через",
            "ё-маё"
        };

        public bool IsValid(string tag)
        {
            return !boringWords.Contains(tag.ToLowerInvariant());
        }
    }
}
