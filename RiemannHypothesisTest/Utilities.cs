using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiemannHypothesisTest
{
    class Utilities
    {
        public static PointF convertScreenToReal(Point ptScreen, double dMinX, double dMaxX, double dMinY, double dMaxY, Point dimensionScreen)
        {
            double x = (1 - (dimensionScreen.X - ptScreen.X) / ((double)dimensionScreen.X)) * (dMaxX - dMinX) + dMinX;
            double y = (dimensionScreen.Y - ptScreen.Y) / ((double)dimensionScreen.Y) * (dMaxY - dMinY) + dMinY;
            return new PointF((float)x, (float)y);
        }

        public static Point convertRealToScreen(PointF ptReal, double dMinX, double dMaxX, double dMinY, double dMaxY, Point dimensionScreen)
        {
            int x = (int)((ptReal.X - dMinX) / (dMaxX - dMinX) * dimensionScreen.X);
            int y = dimensionScreen.Y - (int)((ptReal.Y - dMinY) / (dMaxY - dMinY) * dimensionScreen.Y);
            return new Point(x, y);
        }
    }
}
