using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagsCloudService.Images
{
    public interface IResolveImageFormat
    {
        ImageFormat Resolve(string imageFileExtension);
    }
}
