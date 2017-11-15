using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FakeItEasy;
using FluentAssertions;
using NUnit.Framework;
using TagsCloudService.FileReaders;
using TagsCloudService.Validators;

namespace TagsCloud.Tests.FileReadersTests
{
    public class TagLoader_Should
    {
        [Test]
        public void Load_Tags_FromFile()
        {
            var tags = new[] {"a", "b", "c"};

            var fileReader = A.Fake<IReadFromFile>();
            A.CallTo(() => fileReader.SupportFile(A<string>._))
                .Returns(true);
            A.CallTo(() => fileReader.ReadRows(A<string>._))
                .Returns(tags);

            var target = new TagLoader(new[] {fileReader}, Enumerable.Empty<IValidateTag>(), Enumerable.Empty<IProcessTag>());

            var tagsWithWeights = target.ReadValidTagsWithWeights("fileName");

            tagsWithWeights.Keys.Should().BeEquivalentTo(tags);
        }

        [Test]
        public void ThrowException_IfFileFormat_NotSupported()
        {
            var fileReader = A.Fake<IReadFromFile>();
            A.CallTo(() => fileReader.SupportFile(A<string>._))
                .Returns(false);

            var target = new TagLoader(new[] { fileReader }, Enumerable.Empty<IValidateTag>(), Enumerable.Empty<IProcessTag>());

            Action action = ()=> target.ReadValidTagsWithWeights("fileName");
            action.ShouldThrow<NotSupportedException>();
        }
    }
}
