using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagsCloudService.LayoutAlgorithms
{
    public class ArchimedeanSpiralPositioner : IPositioner
    {
        private readonly double factorDelta;
        private readonly double spiralPower;

        private double factor = 0;
        private int angle = 0;

        public ArchimedeanSpiralPositioner(double factorDelta, double spiralPower)
        {
            this.factorDelta = factorDelta;
            this.spiralPower = spiralPower;
        }

        public void NextPosition(out int x, out int y)
        {
            x = (int) (factor * Math.Pow(angle, spiralPower) * Math.Cos(angle));
            y = (int) (factor * Math.Pow(angle, spiralPower) * Math.Sin(angle));

            factor += factorDelta;
            angle = (++angle) % 361 + 1;
        }
    }
}
