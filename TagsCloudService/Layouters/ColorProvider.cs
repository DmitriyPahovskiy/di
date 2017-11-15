using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagsCloudService.LayoutAlgorithms
{
    public class ColorProvider : ITagsColorProvider
    {
        private readonly Color[] colors = new[] {Color.Red, Color.Green, Color.Yellow, Color.Blue};
        private int current = 0;

        public ColorProvider()
        {}

        public ColorProvider(IEnumerable<Color> colors)
        {
            this.colors = colors.ToArray();
        }

        public Color Next()
        {
            current = (++current) % colors.Length;
            return colors[current];
        }
    }
}
