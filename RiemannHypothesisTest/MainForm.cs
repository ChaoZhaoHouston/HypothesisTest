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
using System.Windows.Forms.DataVisualization.Charting;

namespace RiemannHypothesisTest
{
    public partial class MainForm : Form
    {

        public MainForm()
        {
            InitializeComponent();

        }



        private Complex getSeriesSumResult(Complex complex1)
        {
            if (checkBoxUseOriginal.Checked)
                return Method2(complex1);
            else
                return Method1(complex1);
        }

        private static Complex Method2(Complex complex1)
        {
            if (complex1.Real > 1)
            {
                Complex complex2 = new Complex(-complex1.Real, -complex1.Imaginary);
                int iMax = 10000;
                double[] arrReal = new double[iMax];
                double[] arrImagine = new double[iMax];
                Parallel.For(0, iMax, i =>
                {
                    Complex c2 = Complex.Pow(new Complex(i, 0), complex2);
                    arrReal[i] = c2.Real;
                    arrImagine[i] = c2.Imaginary;
                });
                double sum_Real = arrReal.Sum();
                double sum_Imagine = arrImagine.Sum();
                Complex res = new Complex(sum_Real, sum_Imagine);
                return res;
            }
            return Method1(complex1);
        }

        private static Complex Method1(Complex complex1)
        {
            Complex complex2 = new Complex(-complex1.Real, -complex1.Imaginary);
            int iMax = 10000;
            double[] arrReal = new double[iMax];
            double[] arrImagine = new double[iMax];
            Parallel.For(0, iMax, i =>
            {
                int k1 = 2 * i + 1;
                int k2 = 2 * i + 2;

                Complex c2 = Complex.Pow(new Complex(k1, 0), complex2) - Complex.Pow(new Complex(k2, 0), complex2);
                arrReal[i] = c2.Real;
                arrImagine[i] = c2.Imaginary;
            });
            double sum_Real = arrReal.Sum();
            double sum_Imagine = arrImagine.Sum();

            //double sum_Real = 0;
            //double sum_Imagine = 0;
            //for (int i = 0; i < iMax; i++)
            //{
            //    int k1 = 2 * i + 1;
            //    int k2 = 2 * i + 2;

            //    Complex c2 = Complex.Pow(new Complex(k1, 0), complex2) - Complex.Pow(new Complex(k2, 0), complex2);
            //    sum_Real += c2.Real;
            //    sum_Imagine += c2.Imaginary;
            //}
            Complex d2 = (1 - 2 / Complex.Pow(2, complex1));
            Complex res = new Complex(sum_Real, sum_Imagine) / d2;
            return res;

        }

        private List<Complex> getSeriesSumResultList(Complex complex1)
        {
            Complex complex2 = new Complex(-complex1.Real, -complex1.Imaginary);
            int iMax = 1000;
            double[] arrReal = new double[iMax];
            double[] arrImagine = new double[iMax];
            //Parallel.For(0, iMax, i =>
            //{
            //    int k1 = 2 * i + 1;
            //    int k2 = 2 * i + 2;

            //    Complex c2 = Complex.Pow(new Complex(k1, 0), complex2) - Complex.Pow(new Complex(k2, 0), complex2);
            //    arrReal[i] = c2.Real;
            //    arrImagine[i] = c2.Imaginary;
            //});
            //double sum_Real = arrReal.Sum();
            //double sum_Imagine = arrImagine.Sum();

            double sum_Real = 0;
            double sum_Imagine = 0;

            List<Complex> lstComplex = new List<Complex>();
            for (int i = 0; i < iMax; i++)
            {
                int k1 = 2 * i + 1;
                int k2 = 2 * i + 2;

                Complex c2 = Complex.Pow(new Complex(k1, 0), complex2) - Complex.Pow(new Complex(k2, 0), complex2);
                sum_Real += c2.Real;
                sum_Imagine += c2.Imaginary;

                Complex d2 = (1 - 2 / Complex.Pow(2, complex1));
                Complex res = new Complex(sum_Real, sum_Imagine) / d2;
                lstComplex.Add(res);
            }

            return lstComplex;
        }


        private List<Complex> getSeriesOneExponent(Complex complex1, int k1, Complex start)
        {

            List<Complex> lstComplex = new List<Complex>();
            Complex c1= new Complex(0, 0);
            //lstComplex.Add(c1);
            //c1 = Complex.Pow(new Complex(k1, 0), complex1);
            //lstComplex.Add(c1);
            //c1 = new Complex(0, 0);
            //lstComplex.Add(c1);

            //for (int i = 0; i <= 100; i++)
            //{
            //    c1 = Complex.Pow(new Complex(k1, 0), new Complex(complex1.Real / 100.0 * i, 0));
            //    lstComplex.Add(c1 + start);
            //}
            lstComplex.Add(start);
            c1 = Complex.Pow(new Complex(k1, 0), new Complex(complex1.Real, 0));
            lstComplex.Add(c1 + start);

            int iNum = 10;
            for (int i = 0; i <= iNum; i++)
            {
                Complex c2 = Complex.Pow(new Complex(k1, 0), new Complex(0, complex1.Imaginary / (double)iNum * i));
                lstComplex.Add(c1 * c2 + start);
            }


            return lstComplex;
        }

        private List<Complex> getSeriesOneExponent(Complex complex1, double dBase)
        {

            List<Complex> lstComplex = new List<Complex>();
            Complex c1 = new Complex(0, 0);
            lstComplex.Add(c1);
            c1 = Complex.Pow(new Complex(dBase, 0), new Complex(complex1.Real, 0));
            lstComplex.Add(c1);

            int iNum = 100;
            for (int i = 0; i <= iNum; i++)
            {
                Complex c2 = Complex.Pow(new Complex(dBase, 0), new Complex(0, complex1.Imaginary / (double)iNum * i));
                lstComplex.Add(c1 * c2);
            }

            return lstComplex;
        }

        private void buttonShowX_Click(object sender, EventArgs e)
        {
            List<Complex> lstComplexes = new List<Complex>();
            double dYValue = Convert.ToDouble(textBoxX.Text);
            double dCurrentSmallestDistance = 1000;
            double dXMin = Convert.ToDouble(textBoxXMin.Text);
            double dXMax = Convert.ToDouble(textBoxXMax.Text);
            double dXStep = (dXMax - dXMin) / 10000;
            Complex closestComplex = new Complex(0, 0);
            for (double dXValue = dXMin; dXValue <= dXMax; dXValue += dXStep)
            {
                Complex c1 = getSeriesSumResult(new Complex(dXValue, dYValue));

                lstComplexes.Add(c1);

                if (c1.Magnitude < 0.01)
                {
                    if (dCurrentSmallestDistance > c1.Magnitude)
                    {
                        dCurrentSmallestDistance = c1.Magnitude;
                        closestComplex = c1;
                    }
                    else
                    {
                        Console.WriteLine(dXValue + ", " + dYValue);
                        dCurrentSmallestDistance = 1000;
                        closestComplex = new Complex(0, 0);
                    }
                }
            }
            List<List<Complex>> lstlstComplex = new List<List<Complex>>();
            lstlstComplex.Add(lstComplexes);
            FormResult result = new FormResult(lstlstComplex);
            result.Show();
        }

        private void buttonShowY_Click(object sender, EventArgs e)
        {
            List<Complex> lstComplexes = new List<Complex>();
            double dXValue = Convert.ToDouble(textBoxY.Text);
            double dCurrentSmallestDistance = 1000;
            double dYMin = Convert.ToDouble(textBoxYMin.Text);
            double dYMax = Convert.ToDouble(textBoxYMax.Text);
            double dYStep = (dYMax - dYMin) / 10000;
            Complex closestComplex = new Complex(0, 0);
            for (double dYValue = dYMin; dYValue <= dYMax; dYValue += dYStep)
            {
                Complex c1 = getSeriesSumResult(new Complex(dXValue, dYValue));

                lstComplexes.Add(c1);

                if (c1.Magnitude < 0.01)
                {
                    if (dCurrentSmallestDistance > c1.Magnitude)
                    {
                        dCurrentSmallestDistance = c1.Magnitude;
                        closestComplex = c1;
                    }
                    else
                    {
                        Console.WriteLine(dXValue + ", " + dYValue);
                        dCurrentSmallestDistance = 1000;
                        closestComplex = new Complex(0, 0);
                    }
                }
            }
            List<List<Complex>> lstlstComplex = new List<List<Complex>>();
            lstlstComplex.Add(lstComplexes);
            FormResult result = new FormResult(lstlstComplex);
            result.Show();
        }

        private void buttonOnePoint_Click(object sender, EventArgs e)
        {
            double dXValue = Convert.ToDouble(textBoxOnePointX.Text);
            double dYValue = Convert.ToDouble(textBoxOnePointY.Text);

            List<Complex> lstComplexes = getSeriesSumResultList(new Complex(dXValue, dYValue));

            List<List<Complex>> lstlstComplex = new List<List<Complex>>();
            lstlstComplex.Add(lstComplexes);
            FormResult result = new FormResult(lstlstComplex);
            result.Show();
        }

        private void buttonShowCalculationDetails_Click(object sender, EventArgs e)
        {
            double dXValue = Convert.ToDouble(textBoxOnePointX.Text);
            double dYValue = Convert.ToDouble(textBoxOnePointY.Text);

            
            List<List<Complex>> lstlstComplex = new List<List<Complex>>();
            Complex start = new Complex(0, 0);
            for (int i = 118; i < 120; i++)
            {
                List<Complex> lstComplexes = getSeriesOneExponent(new Complex(-dXValue, -dYValue), i, start);
                start = lstComplexes.Last();
                lstlstComplex.Add(lstComplexes);
            }
            
            FormResult result = new FormResult(lstlstComplex);
            result.Show();
        }


        private List<Complex> addComplexToANumber(List<Complex> lstComplex, Complex num, bool bNegative)
        {
            List<Complex> lstResults = new List<Complex>();
            for(int i = 0; i < lstComplex.Count(); i++)
            {
                lstResults.Add((bNegative ? -lstComplex[i] : lstComplex[i]) + num);
            }
            return lstResults;
        }
        private void buttonShowSimpleExponent_Click(object sender, EventArgs e)
        {
            double dXValue = Convert.ToDouble(textBoxExponent_X.Text);
            double dYValue = Convert.ToDouble(textBoxExponent_Y.Text);

            double dBase = Convert.ToDouble(textBoxBase.Text);

            List<List<Complex>> lstlstComplex = new List<List<Complex>>();

            Complex start = new Complex(0, 0);
            for (int i = 1; i < 1000; i++)
            {
                List<Complex> lstComplexes = getSeriesOneExponent(new Complex(dXValue, dYValue), i);
                lstComplexes = addComplexToANumber(lstComplexes, start, false);
                lstlstComplex.Add(lstComplexes);

                start = lstComplexes[lstComplexes.Count - 1];
            }

            FormResult result = new FormResult(lstlstComplex);
            result.Show();
        }

        private void buttonOnePair_Click(object sender, EventArgs e)
        {
            double dXValue = Convert.ToDouble(textBoxOnePairX.Text);
            double dYValue = Convert.ToDouble(textBoxOnePairY.Text);
            bool bShowDetails = checkBoxShowDetails.Checked;
            int iNumOfSeries = 50;

            {
                List<List<Complex>> lstlstComplex = new List<List<Complex>>();

                Complex start = new Complex(0, 0);
                for (int i = 1; i < iNumOfSeries; i++)
                {
                    List<Complex> lstComplexes = getSeriesOneExponent(new Complex(dXValue, dYValue), i);
                    List<Complex> lstComplexesShift = addComplexToANumber(lstComplexes, start, i % 2 == 0);
                    if (bShowDetails)
                        lstlstComplex.Add(lstComplexesShift);
                    else
                    {
                        List<Complex> lstLast = new List<Complex>();
                        lstLast.Add(start);
                        lstLast.Add(lstComplexesShift[lstComplexes.Count - 1]);
                        lstlstComplex.Add(lstLast);
                    }
                    start = lstComplexesShift[lstComplexes.Count - 1];
                }

                FormResult result = new FormResult(lstlstComplex);
                result.StartPosition = FormStartPosition.Manual;
                result.Location = new Point(0, 200);
                result.Show();
            }

            {
                List<List<Complex>> lstlstComplex = new List<List<Complex>>();

                Complex start = new Complex(0, 0);
                for (int i = 1; i < iNumOfSeries; i++)
                {
                    List<Complex> lstComplexes = getSeriesOneExponent(new Complex(dXValue, dYValue), i);
                    List<Complex> lstComplexesShift = addComplexToANumber(lstComplexes, start, false);
                    if (bShowDetails)
                        lstlstComplex.Add(lstComplexesShift);
                    else
                    {
                        List<Complex> lstLast = new List<Complex>();
                        lstLast.Add(start);
                        lstLast.Add(lstComplexesShift[lstComplexes.Count - 1]);
                        lstlstComplex.Add(lstLast);
                    }
                    start = lstComplexesShift[lstComplexes.Count - 1];
                }

                FormResult result = new FormResult(lstlstComplex);
                result.StartPosition = FormStartPosition.Manual;
                result.Location = new Point(800, 200);
                result.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hello Jane");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Test");
        }
    }
}
