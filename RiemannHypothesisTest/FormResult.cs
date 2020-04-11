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
    public partial class FormResult : Form
    {
        Point m_dimensionScreen = new Point();
        double m_dMinX = double.MaxValue;
        double m_dMaxX = double.MinValue;
        double m_dMinY = double.MaxValue;
        double m_dMaxY = double.MinValue;
        List<List<Complex>> m_lstlstComplexes = null;
        bool m_bHighlightLast = false;

        public FormResult(List<List<Complex>> lstlstComplexes, bool highlightLast)
        {
            InitializeComponent();
            m_bHighlightLast = highlightLast;
            m_lstlstComplexes = lstlstComplexes;
            UpdateMinMax();
        }

        public void setDataAndUpdate(List<List<Complex>> lstlstComplexes, bool highlightLast)
        {
            m_bHighlightLast = highlightLast;
            m_lstlstComplexes = lstlstComplexes;
            UpdateMinMax();
            pictureBox1.Invalidate();
        }

        private void UpdateMinMax()
        {
            m_dimensionScreen.X = pictureBox1.Width;
            m_dimensionScreen.Y = pictureBox1.Height;
            foreach (List<Complex> lstComplex in m_lstlstComplexes)
            {
                foreach (Complex c1 in lstComplex)
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

            //Fixed the axis
            //m_dMaxX = 8;
            //m_dMinX = -8;
            //m_dMaxY = 8;
            //m_dMinY = -8;


            textBoxXMin.Text = m_dMinX.ToString();
            textBoxXMax.Text = m_dMaxX.ToString();
            textBoxYMin.Text = m_dMinY.ToString();
            textBoxYMax.Text = m_dMaxY.ToString();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            //Point ptX1 = Utilities.convertRealToScreen(new PointF((float)m_dMinX, 0), m_dMinX, m_dMaxX, m_dMinY, m_dMaxY, m_dimensionScreen);
            //Point ptX2 = Utilities.convertRealToScreen(new PointF((float)m_dMaxX, 0), m_dMinX, m_dMaxX, m_dMinY, m_dMaxY, m_dimensionScreen);
            //e.Graphics.DrawLine(new Pen(Color.Black, 2f), ptX1, ptX2);

            //Point ptY1 = Utilities.convertRealToScreen(new PointF(0, (float)m_dMinY), m_dMinX, m_dMaxX, m_dMinY, m_dMaxY, m_dimensionScreen);
            //Point ptY2 = Utilities.convertRealToScreen(new PointF(0, (float)m_dMaxY), m_dMinX, m_dMaxX, m_dMinY, m_dMaxY, m_dimensionScreen);
            //e.Graphics.DrawLine(new Pen(Color.Black, 2f), ptY1, ptY2);

            Point ptScreenOrig = Utilities.convertRealToScreen(new PointF(0, 0),
                    m_dMinX, m_dMaxX, m_dMinY, m_dMaxY, m_dimensionScreen);
            e.Graphics.DrawLine(new Pen(Color.Blue, 1), ptScreenOrig.X - 5, ptScreenOrig.Y, ptScreenOrig.X + 5, ptScreenOrig.Y);
            e.Graphics.DrawLine(new Pen(Color.Blue, 1), ptScreenOrig.X , ptScreenOrig.Y - 5, ptScreenOrig.X, ptScreenOrig.Y + 5);

            Brush aBrush = (Brush)Brushes.Red;

            int iListLength = m_lstlstComplexes.Count;

            //for(int i = 0; i < iLength; i++)
            //{
            //    Complex c1 = m_lstComplexes[i];
            //    Point ptScreen = Utilities.convertRealToScreen(new PointF((float)c1.Real, (float)c1.Imaginary), 
            //        m_dMinX, m_dMaxX, m_dMinY, m_dMaxY, m_dimensionScreen);

            //    if (i < iLength /3)
            //    {
            //        aBrush = (Brush)Brushes.Green;
            //    }
            //    else if (i < 2 * iLength /3)
            //    {
            //        aBrush = (Brush)Brushes.Blue;
            //    }
            //    else
            //    {
            //        aBrush = (Brush)Brushes.Red;
            //    }
            //    e.Graphics.FillEllipse(aBrush, ptScreen.X, ptScreen.Y, 2, 2);
            //}

            if (iListLength > 1)
            {
                Color[] arrColor = { Color.Red, Color.Blue, Color.Green, Color.Aqua, Color.Black };
                for (int i = 0; i < iListLength; i++)
                {
                    List<Complex> lstComplex = m_lstlstComplexes[i];
                    int iLength = m_lstlstComplexes[i].Count;

                    for (int j = 1; j < iLength; j++)
                    {
                        Complex c1 = lstComplex[j - 1];
                        Complex c2 = lstComplex[j];
                        Point ptScreen1 = Utilities.convertRealToScreen(new PointF((float)c1.Real, (float)c1.Imaginary),
                            m_dMinX, m_dMaxX, m_dMinY, m_dMaxY, m_dimensionScreen);
                        Point ptScreen2 = Utilities.convertRealToScreen(new PointF((float)c2.Real, (float)c2.Imaginary),
                            m_dMinX, m_dMaxX, m_dMinY, m_dMaxY, m_dimensionScreen);

                        e.Graphics.DrawLine(new Pen(arrColor[i % 5], 1f), ptScreen1, ptScreen2);
                    }
                }
            }
            else
            {
                int iLength = m_lstlstComplexes[0].Count;
                if (iLength > 1)
                {
                    for (int i = 1; i < iLength; i++)
                    {
                        Complex c1 = m_lstlstComplexes[0][i - 1];
                        Complex c2 = m_lstlstComplexes[0][i];
                        Point ptScreen1 = Utilities.convertRealToScreen(new PointF((float)c1.Real, (float)c1.Imaginary),
                            m_dMinX, m_dMaxX, m_dMinY, m_dMaxY, m_dimensionScreen);
                        Point ptScreen2 = Utilities.convertRealToScreen(new PointF((float)c2.Real, (float)c2.Imaginary),
                            m_dMinX, m_dMaxX, m_dMinY, m_dMaxY, m_dimensionScreen);

                        if (i < iListLength / 2)
                            e.Graphics.DrawLine(new Pen(Color.Green, 1f), ptScreen1, ptScreen2);
                        else
                            e.Graphics.DrawLine(new Pen(Color.Red, 1f), ptScreen1, ptScreen2);
                    }
                }
                else
                {
                    Complex c1 = m_lstlstComplexes[0].ElementAt(0);
                    Point ptScreen1 = Utilities.convertRealToScreen(new PointF((float)c1.Real, (float)c1.Imaginary),
                        m_dMinX, m_dMaxX, m_dMinY, m_dMaxY, m_dimensionScreen);
                    e.Graphics.DrawEllipse(new Pen(Color.Red, 1f), new Rectangle(ptScreen1.X, ptScreen1.Y, 4, 4));
                }
            }
        }

        private void buttonZoomIn_Click(object sender, EventArgs e)
        {
            m_dMinX /= 2;
            m_dMaxX /= 2;
            m_dMinY /= 2;
            m_dMaxY /= 2;
            pictureBox1.Invalidate();
        }

        private void buttonZoomout_Click(object sender, EventArgs e)
        {
            m_dMinX *= 2;
            m_dMaxX *= 2;
            m_dMinY *= 2;
            m_dMaxY *= 2;
            pictureBox1.Invalidate();
        }

        public void setLabel(double dX, double dY)
        {
            labelCurrentXY.Text = "Current X/Y: " + dX.ToString() + "   " + dY.ToString();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            m_dMinX = Convert.ToDouble(textBoxXMin.Text);
            m_dMaxX = Convert.ToDouble(textBoxXMax.Text);
            m_dMinY = Convert.ToDouble(textBoxYMin.Text);
            m_dMaxY = Convert.ToDouble(textBoxYMax.Text);
            pictureBox1.Invalidate();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            Point coordinates = me.Location;

            PointF pt= Utilities.convertScreenToReal(coordinates,
                    m_dMinX, m_dMaxX, m_dMinY, m_dMaxY, m_dimensionScreen);
            labelCurrentPoint.Text = "Current Point: " +  pt.ToString();

        }

        private void FormResult_Resize(object sender, EventArgs e)
        {
            UpdateMinMax();
            pictureBox1.Invalidate();
        }
    }
}
