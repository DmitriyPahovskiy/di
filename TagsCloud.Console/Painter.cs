using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagsCloud.Console
{
    public class Painter : IDisposable
    {
        private readonly string outputFileName;
        private readonly Bitmap bitmap;

        public Graphics Canvas { get; }

        public Painter(int width, int height, string outputFileName)
        {
            this.outputFileName = outputFileName;

            bitmap = new Bitmap(width, height);
            Canvas = Graphics.FromImage(bitmap);
        }


        public void Dispose()
        {
            if (!string.IsNullOrWhiteSpace(outputFileName))
            {
                Canvas.Save();
                bitmap.Save(outputFileName);
            }

            bitmap?.Dispose();
            Canvas?.Dispose();
        }
    }
}
