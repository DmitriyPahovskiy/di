using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagsCloudService.Images
{
    public class ImageFormatReslover : IResolveImageFormat
    {
        public ImageFormat Resolve(string imageFileExtension)
        {
            var format = imageFileExtension.Trim('.').ToLower();

            switch (format)
            {
                case "jpg":
                case "jpeg":
                    return ImageFormat.Jpeg;
                case "bmp":
                    return ImageFormat.Bmp;
                case "gif":
                    return ImageFormat.Gif;
                case "tiff":
                    return ImageFormat.Tiff;
                case "icon":
                    return ImageFormat.Icon;
                default:
                    return ImageFormat.Png;
            }
        }
    }
}
