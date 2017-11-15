using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagsCloudService.LayoutAlgorithms
{
    public class CircularCloudLayouter
    {
        private readonly PointF center;
        private readonly List<RectangleF> tags = new List<RectangleF>();
        private readonly Graphics canvas;
        private readonly Font basicFont;
        private readonly IPositioner positioner;
        private readonly ITagsColorProvider colorProvider;


        public CircularCloudLayouter(Graphics canvas, 
            Font basicFont, 
            IPositioner positioner,
            ITagsColorProvider colorProvider)
        {
            this.center = new PointF(canvas.VisibleClipBounds.Width / 2, canvas.VisibleClipBounds.Height / 2);
            this.canvas = canvas;
            this.basicFont = basicFont;
            this.positioner = positioner;
            this.colorProvider = colorProvider;
        }

        public void DrawNextTag(string tag, int weight)
        {
            var tagFont = AdjustFont(weight);
            var tagSize = canvas.MeasureString(tag, tagFont);

            var tagRectangle = CreateRectangleAtCenter(tagSize);

            MoveToNextPosition(ref tagRectangle);

            tags.Add(tagRectangle);
            canvas.DrawString(tag, tagFont, new SolidBrush(colorProvider.Next()), tagRectangle);
        }

        private Font AdjustFont(int weigth)
        {
            return new Font(basicFont.FontFamily, basicFont.Size + weigth, basicFont.Style);
        }

        private RectangleF CreateRectangleAtCenter(SizeF rectangleSize)
        {
            return new RectangleF(center.X - rectangleSize.Width / 2, center.Y - rectangleSize.Height / 2,
                rectangleSize.Width, rectangleSize.Height);
        }

        private void MoveToNextPosition(ref RectangleF rectangle)
        {
            RectangleF copyRectangle;
            do
            {
                int dx, dy;
                positioner.NextPosition(out dx, out dy);
                rectangle.X += dx;
                rectangle.Y += dy;
                copyRectangle = rectangle;
            } while (tags.Any(t => t.IntersectsWith(copyRectangle)));
        }
    }
}
