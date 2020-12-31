using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RiemannTest
{
    public partial class FormDisplay : Form
    {
        double m_dMinX = double.MaxValue;
        double m_dMaxX = double.MinValue;
        double m_dMinY = double.MaxValue;
        double m_dMaxY = double.MinValue;

        Point m_dimensionScreen = new Point();
        List<List<Complex>> m_lstVectors = new List<List<Complex>>();
        List<Complex> m_lstPoints = new List<Complex>();

        public FormDisplay()
        {
            InitializeComponent();
        }

        private void FormDisplay_Load(object sender, EventArgs e)
        {
            this.SetBounds(10, 10, 1000, 1000);

            m_dimensionScreen.X = this.Width;
            m_dimensionScreen.Y = this.Height;
        }

        private void FormDisplay_ResizeEnd(object sender, EventArgs e)
        {
            int iMin = Math.Min(this.Width, this.Height);
            this.Width = iMin;
            this.Height = iMin;
            m_dimensionScreen.X = this.Width;
            m_dimensionScreen.Y = this.Height;
            Invalidate();
        }

        public void addPoints(Complex pt)
        {
            m_lstPoints.Add(pt);

            if (m_dMinX > pt.Real)
            {
                m_dMinX = pt.Real;
            }
            if (m_dMaxX < pt.Real)
            {
                m_dMaxX = pt.Real;
            }
            if (m_dMinY > pt.Imaginary)
            {
                m_dMinY = pt.Imaginary;
            }
            if (m_dMaxY < pt.Imaginary)
            {
                m_dMaxY = pt.Imaginary;
            }
            double dMaxX = Math.Max(m_dMaxX, Math.Abs(m_dMinX));
            double dMaxY = Math.Max(m_dMaxY, Math.Abs(m_dMinY));
            double dMax = Math.Max(dMaxX, dMaxY);
            m_dMaxX = dMax;
            m_dMinX = -dMax;
            m_dMaxY = dMax;
            m_dMinY = -dMax;

            if (m_dMinX == m_dMaxX)
            {
                m_dMinX -= 1;
                m_dMaxX += 1;
            }
            if (m_dMinY == m_dMaxY)
            {
                m_dMinY -= 1;
                m_dMaxY += 1;
            }
        }

        public void addVectors(List<Complex> lstVectors)
        {
            m_lstVectors.Add(lstVectors);

            foreach (Complex c1 in lstVectors)
            {
                if (m_dMinX > c1.Real)
                {
                    m_dMinX = c1.Real;
                }
                if (m_dMaxX < c1.Real)
                {
                    m_dMaxX = c1.Real;
                }
                if (m_dMinY > c1.Imaginary)
                {
                    m_dMinY = c1.Imaginary;
                }
                if (m_dMaxY < c1.Imaginary)
                {
                    m_dMaxY = c1.Imaginary;
                }
            }

            double dMaxX = Math.Max(m_dMaxX, Math.Abs(m_dMinX));
            double dMaxY = Math.Max(m_dMaxY, Math.Abs(m_dMinY));
            double dMax = Math.Max(dMaxX, dMaxY);
            m_dMaxX = dMax;
            m_dMinX = -dMax;
            m_dMaxY = dMax;
            m_dMinY = -dMax;

            if (m_dMinX == m_dMaxX)
            {
                m_dMinX -= 1;
                m_dMaxX += 1;
            }
            if (m_dMinY == m_dMaxY)
            {
                m_dMinY -= 1;
                m_dMaxY += 1;
            }
        }

        public void readyToDisplay()
        {
            m_dMaxX *= 1.08;
            m_dMinX *= 1.08;
            m_dMaxY *= 1.08;
            m_dMinY *= 1.08;
        }

        private void FormDisplay_Paint(object sender, PaintEventArgs e)
        {
            Color[] arrColor = { Color.Red, Color.Blue, Color.Green, Color.Aqua, Color.Red, Color.Green, Color.Crimson, Color.DarkGreen, Color.Red, Color.DarkBlue };

            Point ptScreenOrig = Utilities.convertRealToScreen(new PointF(0, 0), m_dMinX, m_dMaxX, m_dMinY, m_dMaxY, m_dimensionScreen);
            e.Graphics.DrawLine(new Pen(Color.Blue, 1), ptScreenOrig.X - 5, ptScreenOrig.Y, ptScreenOrig.X + 5, ptScreenOrig.Y);
            e.Graphics.DrawLine(new Pen(Color.Blue, 1), ptScreenOrig.X, ptScreenOrig.Y - 5, ptScreenOrig.X, ptScreenOrig.Y + 5);

            for (int iSegment = 0; iSegment < m_lstVectors.Count; iSegment++)
            {

                int iLength = m_lstVectors.ElementAt(iSegment).Count;

                for (int j = 1; j < iLength; j++)
                {
                    Complex c1 = m_lstVectors.ElementAt(iSegment)[j - 1];
                    Complex c2 = m_lstVectors.ElementAt(iSegment)[j];
                    Point ptScreen1 = Utilities.convertRealToScreen(new PointF((float)c1.Real, (float)c1.Imaginary),
                        m_dMinX, m_dMaxX, m_dMinY, m_dMaxY, m_dimensionScreen);
                    Point ptScreen2 = Utilities.convertRealToScreen(new PointF((float)c2.Real, (float)c2.Imaginary),
                        m_dMinX, m_dMaxX, m_dMinY, m_dMaxY, m_dimensionScreen);

                    Color currentColor = arrColor[j % 10];
                    Color newColor = Color.FromArgb(30, currentColor);
                    e.Graphics.DrawLine(new Pen(newColor, 1f), ptScreen1, ptScreen2);
                }
            }

            for (int iPoint = 0; iPoint < m_lstPoints.Count; iPoint++)
            {
                Point ptScreen1 = Utilities.convertRealToScreen(new PointF((float)m_lstPoints[iPoint].Real, (float)m_lstPoints[iPoint].Imaginary),
                        m_dMinX, m_dMaxX, m_dMinY, m_dMaxY, m_dimensionScreen);
                Color currentColor = arrColor[iPoint % 10];
                Color newColor = Color.FromArgb(255, currentColor);
                int iLength = 4 * iPoint + 4;
                e.Graphics.DrawEllipse(new Pen(newColor, 2f), ptScreen1.X - iLength/2, ptScreen1.Y - iLength/2, iLength, iLength);
            }
        }
    }
}
