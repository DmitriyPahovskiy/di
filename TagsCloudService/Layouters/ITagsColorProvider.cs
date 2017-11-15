using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagsCloudService.LayoutAlgorithms
{
    public interface ITagsColorProvider
    {
        Color Next();
    }
}
