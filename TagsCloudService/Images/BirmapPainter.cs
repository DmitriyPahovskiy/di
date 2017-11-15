using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagsCloudService.Images
{
    public class BitmapPainter : IDisposable
    {
        private readonly string outputFileName;
        private readonly IResolveImageFormat imageFormatResolver;
        private readonly Bitmap bitmap;
        private string format;

        public Graphics Canvas { get; }

        public BitmapPainter(int width, int height, string outputFileName, IResolveImageFormat imageFormatResolver)
        {
            this.outputFileName = outputFileName;
            this.imageFormatResolver = imageFormatResolver;
            if(!string.IsNullOrWhiteSpace(outputFileName))
                format = Path.GetExtension(this.outputFileName);

            bitmap = new Bitmap(width, height);
            Canvas = Graphics.FromImage(bitmap);
        }


        public void Dispose()
        {
            if (!string.IsNullOrWhiteSpace(outputFileName))
            {
                Canvas.Save();
                bitmap.Save(outputFileName, imageFormatResolver.Resolve(format));
            }

            bitmap?.Dispose();
            Canvas?.Dispose();
        }
    }
}
