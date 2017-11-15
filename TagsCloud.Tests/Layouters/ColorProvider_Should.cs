using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using TagsCloudService.LayoutAlgorithms;

namespace TagsCloud.Tests.Layouters
{
    public class ColorProvider_Should
    {
        [Test]
        public void Provide_DifferentColors_OnNext()
        {
            var colors = new[] {Color.Red, Color.Green, Color.Yellow, Color.Blue, Color.Aqua, Color.Beige, Color.Violet};

            var target = new ColorProvider(colors);

            for (int i = 0; i < 5; i++)
            {
                var color1 = target.Next();
                var color2 = target.Next();

                colors.Should().Contain(new []{ color1, color2});
                color1.Should().NotBe(color2);
            }
        }
    }
}
