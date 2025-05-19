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

namespace RiemannHypothesisTest
{
    public partial class FormCompareAlphas : Form
    {
        Point m_dimensionScreen = new Point();
        double m_dMinX = double.MaxValue;
        double m_dMaxX = double.MinValue;
        double m_dMinY = double.MaxValue;
        double m_dMaxY = double.MinValue;
        List<Complex> m_lstData1;
        List<Complex> m_lstData2;
        List<Complex> m_lstData3;
        List<Complex> m_lstData4;

        public FormCompareAlphas()
        {
            InitializeComponent();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            m_dimensionScreen.X = pictureBox1.Width;
            m_dimensionScreen.Y = pictureBox1.Height;
            Point ptScreenOrig = Utilities.convertRealToScreen(new PointF(0, 0),
                m_dMinX, m_dMaxX, m_dMinY, m_dMaxY, m_dimensionScreen);
            e.Graphics.DrawLine(new Pen(Color.Blue, 1), ptScreenOrig.X - 5, ptScreenOrig.Y, ptScreenOrig.X + 5, ptScreenOrig.Y);
            e.Graphics.DrawLine(new Pen(Color.Blue, 1), ptScreenOrig.X, ptScreenOrig.Y - 5, ptScreenOrig.X, ptScreenOrig.Y + 5);

            int iLength1 = m_lstData1.Count;
            if (iLength1 > 1)
            {
                for (int i = 1; i < iLength1; i++)
                {
                    Complex c1 = m_lstData1[i - 1];
                    Complex c2 = m_lstData1[i];
                    Point ptScreen1 = Utilities.convertRealToScreen(new PointF((float)c1.Real, (float)c1.Imaginary),
                        m_dMinX, m_dMaxX, m_dMinY, m_dMaxY, m_dimensionScreen);
                    Point ptScreen2 = Utilities.convertRealToScreen(new PointF((float)c2.Real, (float)c2.Imaginary),
                        m_dMinX, m_dMaxX, m_dMinY, m_dMaxY, m_dimensionScreen);

                    e.Graphics.DrawLine(new Pen(Color.Green, 1f), ptScreen1, ptScreen2);
                }
            }
            int iLength2 = m_lstData2.Count;
            if (iLength2 > 1)
            {
                for (int i = 1; i < iLength2; i++)
                {
                    Complex c1 = m_lstData2[i - 1];
                    Complex c2 = m_lstData2[i];
                    Point ptScreen1 = Utilities.convertRealToScreen(new PointF((float)c1.Real, (float)c1.Imaginary),
                        m_dMinX, m_dMaxX, m_dMinY, m_dMaxY, m_dimensionScreen);
                    Point ptScreen2 = Utilities.convertRealToScreen(new PointF((float)c2.Real, (float)c2.Imaginary),
                        m_dMinX, m_dMaxX, m_dMinY, m_dMaxY, m_dimensionScreen);

                    e.Graphics.DrawLine(new Pen(Color.Blue, 1f), ptScreen1, ptScreen2);
                }
                Complex cLast = m_lstData2.Last();
                Point ptLast = Utilities.convertRealToScreen(new PointF((float)cLast.Real, (float)cLast.Imaginary),
                        m_dMinX, m_dMaxX, m_dMinY, m_dMaxY, m_dimensionScreen);
                e.Graphics.DrawEllipse(new Pen(Color.Red, 1f), ptLast.X, ptLast.Y, 4, 4);
            }

            int iLength3 = m_lstData3.Count;
            if (iLength3 > 1)
            {
                for (int i = 1; i < iLength3; i++)
                {
                    Complex c1 = m_lstData3[i - 1];
                    Complex c2 = m_lstData3[i];
                    Point ptScreen1 = Utilities.convertRealToScreen(new PointF((float)c1.Real, (float)c1.Imaginary),
                        m_dMinX, m_dMaxX, m_dMinY, m_dMaxY, m_dimensionScreen);
                    Point ptScreen2 = Utilities.convertRealToScreen(new PointF((float)c2.Real, (float)c2.Imaginary),
                        m_dMinX, m_dMaxX, m_dMinY, m_dMaxY, m_dimensionScreen);

                    e.Graphics.DrawLine(new Pen(Color.Purple, 1f), ptScreen1, ptScreen2);
                }
            }

            int iLength4 = m_lstData4.Count;
            if (iLength4 > 1)
            {
                for (int i = 1; i < iLength4; i++)
                {
                    Complex c1 = m_lstData4[i - 1];
                    Complex c2 = m_lstData4[i];
                    Point ptScreen1 = Utilities.convertRealToScreen(new PointF((float)c1.Real, (float)c1.Imaginary),
                        m_dMinX, m_dMaxX, m_dMinY, m_dMaxY, m_dimensionScreen);
                    Point ptScreen2 = Utilities.convertRealToScreen(new PointF((float)c2.Real, (float)c2.Imaginary),
                        m_dMinX, m_dMaxX, m_dMinY, m_dMaxY, m_dimensionScreen);

                    e.Graphics.DrawLine(new Pen(Color.Navy, 1f), ptScreen1, ptScreen2);
                }
                Complex cLast = m_lstData4.Last();
                Point ptLast = Utilities.convertRealToScreen(new PointF((float)cLast.Real, (float)cLast.Imaginary),
                        m_dMinX, m_dMaxX, m_dMinY, m_dMaxY, m_dimensionScreen);
                e.Graphics.DrawEllipse(new Pen(Color.Moccasin, 1f), ptLast.X, ptLast.Y, 4, 4);
            }
        }


        private void pictureBox1_Resize(object sender, EventArgs e)
        {
            int iMin = Math.Min(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Width = iMin;
            pictureBox1.Height = iMin;
            pictureBox1.Refresh();
        }

        public void UpdateData(List<Complex> lstData1, List<Complex> lstData2, List<Complex> lstData3, List<Complex> lstData4)
        {
            m_lstData1 = lstData1;
            m_lstData2 = lstData2;
            m_lstData3 = lstData3;
            m_lstData4 = lstData4;
            m_dMinX = double.MaxValue;
            m_dMaxX = double.MinValue;
            m_dMinY = double.MaxValue;
            m_dMaxY = double.MinValue;
            UpdateDataByOneVector(lstData1);
            UpdateDataByOneVector(lstData2);
            UpdateDataByOneVector(lstData3);
            UpdateDataByOneVector(lstData4);
            if (m_dMinX >= m_dMaxX)
            {
                m_dMinX = -1;
                m_dMaxX = 1;
            }
            if (m_dMinY >= m_dMaxY)
            {
                m_dMinY = -1;
                m_dMaxY = 1;
            }
            double dMaxX = Math.Max(Math.Abs(m_dMinX), Math.Abs(m_dMaxX));
            double dMaxY = Math.Max(Math.Abs(m_dMinY), Math.Abs(m_dMaxY));
            double dMax = Math.Max(dMaxX, dMaxY);
            //m_dMinX = m_dMinY = 0; // -dMax;
            //m_dMaxX = dMax / 3;
            //m_dMaxY = dMax;

            m_dMinX = m_dMinY = -dMax;
            m_dMaxX = m_dMaxY = dMax;

            pictureBox1.Refresh();
        }
            public void UpdateDataByOneVector(List<Complex> lstData)
        {
            foreach (Complex c1 in lstData)
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
        }
    }
}
