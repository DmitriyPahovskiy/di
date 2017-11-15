using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TagsCloudService.Validators;

namespace TagsCloud.Tests.ValidatorsTests
{
    public class BoringWordsFilter_Should
    {
        [TestCase("я", ExpectedResult = false)]
        [TestCase("Я", ExpectedResult = false)]
        [TestCase("мЫ", ExpectedResult = false)]
        [TestCase("в", ExpectedResult = false)]
        [TestCase("с", ExpectedResult = false)]
        [TestCase("перед", ExpectedResult = false)]
        [TestCase("ё-маЁ", ExpectedResult = false)]
        [TestCase("слово", ExpectedResult = true)]
        [TestCase("Вперёд", ExpectedResult = true)]
        public bool Filter_BoringWords_WithIgnoringCase(string word)
        {
            return new BoringWordsFilter().IsValid(word);
        }
    }
}
