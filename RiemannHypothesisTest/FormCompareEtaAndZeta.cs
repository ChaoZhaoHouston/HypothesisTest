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
    public partial class FormCompareEtaAndZeta : Form
    {
        Point m_dimensionScreen = new Point();
        double m_dMinX = double.MaxValue;
        double m_dMaxX = double.MinValue;
        double m_dMinY = double.MaxValue;
        double m_dMaxY = double.MinValue;
        List<Complex> m_lstData1_1;
        List<Complex> m_lstData2_1;
        List<Complex> m_lstData3_1;

        List<Complex> m_lstData1_2;
        List<Complex> m_lstData2_2;
        List<Complex> m_lstData3_2;


        List<Complex> m_lstData1_3;
        List<Complex> m_lstData2_3;
        List<Complex> m_lstData3_3;

        public FormCompareEtaAndZeta()
        {
            InitializeComponent();
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

        public void UpdateData(List<Complex> lstData1_1, List<Complex> lstData2_1, List<Complex> lstData3_1, string strText,
            List<Complex> lstData1_2, List<Complex> lstData2_2, List<Complex> lstData3_2,
            List<Complex> lstData1_3, List<Complex> lstData2_3, List<Complex> lstData3_3)
        {
            m_dMinX = double.MaxValue;
            m_dMaxX = double.MinValue;
            m_dMinY = double.MaxValue;
            m_dMaxY = double.MinValue;
            UpdateDataByOneVector(lstData1_1);
            UpdateDataByOneVector(lstData2_1);
            UpdateDataByOneVector(lstData3_1);
            UpdateDataByOneVector(lstData1_2);
            UpdateDataByOneVector(lstData2_2);
            UpdateDataByOneVector(lstData3_2);
            UpdateDataByOneVector(lstData1_3);
            UpdateDataByOneVector(lstData2_3);
            UpdateDataByOneVector(lstData3_3);
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
            m_dMinX = m_dMinY = -dMax;
            m_dMaxX = m_dMaxY = dMax;
            labelMax.Text = "Max: " + dMax.ToString();

            m_lstData1_1 = lstData1_1;
            m_lstData2_1 = lstData2_1;
            m_lstData3_1 = lstData3_1;

            m_lstData1_2 = lstData1_2;
            m_lstData2_2 = lstData2_2;
            m_lstData3_2 = lstData3_2;

            m_lstData1_3 = lstData1_3;
            m_lstData2_3 = lstData2_3;
            m_lstData3_3 = lstData3_3;

            pictureBox1.Refresh();
            labelCurrent.Text = "Current Complex: " + strText;
        }


        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            m_dimensionScreen.X = pictureBox1.Width;
            m_dimensionScreen.Y = pictureBox1.Height;
            Point ptScreenOrig = Utilities.convertRealToScreen(new PointF(0, 0),
                m_dMinX, m_dMaxX, m_dMinY, m_dMaxY, m_dimensionScreen);
            e.Graphics.DrawLine(new Pen(Color.Blue, 1), ptScreenOrig.X - 5, ptScreenOrig.Y, ptScreenOrig.X + 5, ptScreenOrig.Y);
            e.Graphics.DrawLine(new Pen(Color.Blue, 1), ptScreenOrig.X, ptScreenOrig.Y - 5, ptScreenOrig.X, ptScreenOrig.Y + 5);

            if (m_lstData1_1 != null)
            {
                int iLength1 = m_lstData1_1.Count;
                if (iLength1 > 1)
                {
                    for (int i = 1; i < iLength1; i++)
                    {
                        Complex c1 = m_lstData1_1[i - 1];
                        Complex c2 = m_lstData1_1[i];
                        Point ptScreen1 = Utilities.convertRealToScreen(new PointF((float)c1.Real, (float)c1.Imaginary),
                            m_dMinX, m_dMaxX, m_dMinY, m_dMaxY, m_dimensionScreen);
                        Point ptScreen2 = Utilities.convertRealToScreen(new PointF((float)c2.Real, (float)c2.Imaginary),
                            m_dMinX, m_dMaxX, m_dMinY, m_dMaxY, m_dimensionScreen);

                        e.Graphics.DrawLine(new Pen(Color.Green, 1f), ptScreen1, ptScreen2);
                    }
                }
            }
            if (m_lstData2_1 != null)
            {
                int iLength2 = m_lstData2_1.Count;
                if (iLength2 > 1)
                {
                    for (int i = 1; i < iLength2; i++)
                    {
                        Complex c1 = m_lstData2_1[i - 1];
                        Complex c2 = m_lstData2_1[i];
                        Point ptScreen1 = Utilities.convertRealToScreen(new PointF((float)c1.Real, (float)c1.Imaginary),
                            m_dMinX, m_dMaxX, m_dMinY, m_dMaxY, m_dimensionScreen);
                        Point ptScreen2 = Utilities.convertRealToScreen(new PointF((float)c2.Real, (float)c2.Imaginary),
                            m_dMinX, m_dMaxX, m_dMinY, m_dMaxY, m_dimensionScreen);

                        e.Graphics.DrawLine(new Pen(Color.Blue, 1f), ptScreen1, ptScreen2);
                    }
                }
            }
            if (m_lstData3_1 != null)
            {
                int iLength3 = m_lstData3_1.Count;
                if (iLength3 > 1)
                {
                    for (int i = 1; i < iLength3; i++)
                    {
                        Complex c1 = m_lstData3_1[i - 1];
                        Complex c2 = m_lstData3_1[i];
                        Point ptScreen1 = Utilities.convertRealToScreen(new PointF((float)c1.Real, (float)c1.Imaginary),
                            m_dMinX, m_dMaxX, m_dMinY, m_dMaxY, m_dimensionScreen);
                        Point ptScreen2 = Utilities.convertRealToScreen(new PointF((float)c2.Real, (float)c2.Imaginary),
                            m_dMinX, m_dMaxX, m_dMinY, m_dMaxY, m_dimensionScreen);

                        e.Graphics.DrawLine(new Pen(Color.Red, 1f), ptScreen1, ptScreen2);
                    }
                }
            }


            if (m_lstData1_2 != null)
            {
                int iLength1 = m_lstData1_2.Count;
                if (iLength1 > 1)
                {
                    for (int i = 1; i < iLength1; i++)
                    {
                        Complex c1 = m_lstData1_2[i - 1];
                        Complex c2 = m_lstData1_2[i];
                        Point ptScreen1 = Utilities.convertRealToScreen(new PointF((float)c1.Real, (float)c1.Imaginary),
                            m_dMinX, m_dMaxX, m_dMinY, m_dMaxY, m_dimensionScreen);
                        Point ptScreen2 = Utilities.convertRealToScreen(new PointF((float)c2.Real, (float)c2.Imaginary),
                            m_dMinX, m_dMaxX, m_dMinY, m_dMaxY, m_dimensionScreen);

                        e.Graphics.DrawLine(new Pen(Color.Green, 1f), ptScreen1, ptScreen2);
                    }
                }
            }
            if (m_lstData2_2 != null)
            {
                int iLength2 = m_lstData2_2.Count;
                if (iLength2 > 1)
                {
                    for (int i = 1; i < iLength2; i++)
                    {
                        Complex c1 = m_lstData2_2[i - 1];
                        Complex c2 = m_lstData2_2[i];
                        Point ptScreen1 = Utilities.convertRealToScreen(new PointF((float)c1.Real, (float)c1.Imaginary),
                            m_dMinX, m_dMaxX, m_dMinY, m_dMaxY, m_dimensionScreen);
                        Point ptScreen2 = Utilities.convertRealToScreen(new PointF((float)c2.Real, (float)c2.Imaginary),
                            m_dMinX, m_dMaxX, m_dMinY, m_dMaxY, m_dimensionScreen);

                        e.Graphics.DrawLine(new Pen(Color.Blue, 1f), ptScreen1, ptScreen2);
                    }
                }
            }
            if (m_lstData3_2 != null)
            {
                int iLength3 = m_lstData3_2.Count;
                if (iLength3 > 1)
                {
                    for (int i = 1; i < iLength3; i++)
                    {
                        Complex c1 = m_lstData3_2[i - 1];
                        Complex c2 = m_lstData3_2[i];
                        Point ptScreen1 = Utilities.convertRealToScreen(new PointF((float)c1.Real, (float)c1.Imaginary),
                            m_dMinX, m_dMaxX, m_dMinY, m_dMaxY, m_dimensionScreen);
                        Point ptScreen2 = Utilities.convertRealToScreen(new PointF((float)c2.Real, (float)c2.Imaginary),
                            m_dMinX, m_dMaxX, m_dMinY, m_dMaxY, m_dimensionScreen);

                        e.Graphics.DrawLine(new Pen(Color.Red, 1f), ptScreen1, ptScreen2);
                    }
                }
            }


            if (m_lstData1_3 != null)
            {
                int iLength1 = m_lstData1_3.Count;
                if (iLength1 > 1)
                {
                    for (int i = 1; i < iLength1; i++)
                    {
                        Complex c1 = m_lstData1_3[i - 1];
                        Complex c2 = m_lstData1_3[i];
                        Point ptScreen1 = Utilities.convertRealToScreen(new PointF((float)c1.Real, (float)c1.Imaginary),
                            m_dMinX, m_dMaxX, m_dMinY, m_dMaxY, m_dimensionScreen);
                        Point ptScreen2 = Utilities.convertRealToScreen(new PointF((float)c2.Real, (float)c2.Imaginary),
                            m_dMinX, m_dMaxX, m_dMinY, m_dMaxY, m_dimensionScreen);

                        e.Graphics.DrawLine(new Pen(Color.Green, 1f), ptScreen1, ptScreen2);
                    }
                }
            }
            if (m_lstData2_3 != null)
            {
                int iLength2 = m_lstData2_3.Count;
                if (iLength2 > 1)
                {
                    for (int i = 1; i < iLength2; i++)
                    {
                        Complex c1 = m_lstData2_3[i - 1];
                        Complex c2 = m_lstData2_3[i];
                        Point ptScreen1 = Utilities.convertRealToScreen(new PointF((float)c1.Real, (float)c1.Imaginary),
                            m_dMinX, m_dMaxX, m_dMinY, m_dMaxY, m_dimensionScreen);
                        Point ptScreen2 = Utilities.convertRealToScreen(new PointF((float)c2.Real, (float)c2.Imaginary),
                            m_dMinX, m_dMaxX, m_dMinY, m_dMaxY, m_dimensionScreen);

                        e.Graphics.DrawLine(new Pen(Color.Blue, 1f), ptScreen1, ptScreen2);
                    }
                }
            }
            if (m_lstData3_3 != null)
            {
                int iLength3 = m_lstData3_3.Count;
                if (iLength3 > 1)
                {
                    for (int i = 1; i < iLength3; i++)
                    {
                        Complex c1 = m_lstData3_3[i - 1];
                        Complex c2 = m_lstData3_3[i];
                        Point ptScreen1 = Utilities.convertRealToScreen(new PointF((float)c1.Real, (float)c1.Imaginary),
                            m_dMinX, m_dMaxX, m_dMinY, m_dMaxY, m_dimensionScreen);
                        Point ptScreen2 = Utilities.convertRealToScreen(new PointF((float)c2.Real, (float)c2.Imaginary),
                            m_dMinX, m_dMaxX, m_dMinY, m_dMaxY, m_dimensionScreen);

                        e.Graphics.DrawLine(new Pen(Color.Red, 1f), ptScreen1, ptScreen2);
                    }
                }
            }
        }

        private void pictureBox1_Resize(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
        }

        private void buttonZoomOut_Click(object sender, EventArgs e)
        {
            m_dMinX *= 2;
            m_dMinY *= 2;
            m_dMaxX *= 2;
            m_dMaxY *= 2;
            pictureBox1.Refresh();
        }

        private void buttonZoomIn_Click(object sender, EventArgs e)
        {
            m_dMinX /= 2;
            m_dMinY /= 2;
            m_dMaxX /= 2;
            m_dMaxY /= 2;
            pictureBox1.Refresh();
        }
    }
}
