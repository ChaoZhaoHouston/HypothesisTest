using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
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

        private List<Complex> getSeriesOneExponentJustTwoPoints(Complex complex1, double dBase)
        {

            List<Complex> lstComplex = new List<Complex>();
            Complex c1 = new Complex(0, 0);
            lstComplex.Add(c1);
            c1 = Complex.Pow(new Complex(dBase, 0), new Complex(complex1.Real, complex1.Imaginary));
            lstComplex.Add(c1);

            return lstComplex;
        }

        private List<Complex> getSeriesOneExponentJustTwoPointsMultiply(Complex complex1, double dBase, Complex complex2)
        {

            List<Complex> lstComplex = new List<Complex>();
            Complex c1 = new Complex(0, 0);
            lstComplex.Add(c1);
            c1 = Complex.Pow(new Complex(dBase, 0), new Complex(complex1.Real, complex1.Imaginary));
            c1 = c1 * complex2;
            lstComplex.Add(c1);

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
            FormResult result = new FormResult(lstlstComplex, false);
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
            FormResult result = new FormResult(lstlstComplex, false);
            result.Show();
        }

        private void buttonOnePoint_Click(object sender, EventArgs e)
        {
            double dXValue = Convert.ToDouble(textBoxOnePointX.Text);
            double dYValue = Convert.ToDouble(textBoxOnePointY.Text);

            List<Complex> lstComplexes = getSeriesSumResultList(new Complex(dXValue, dYValue));

            List<List<Complex>> lstlstComplex = new List<List<Complex>>();
            lstlstComplex.Add(lstComplexes);
            FormResult result = new FormResult(lstlstComplex, false);
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
            
            FormResult result = new FormResult(lstlstComplex, false);
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

            FormResult result = new FormResult(lstlstComplex, false);
            result.Show();
        }

        private void buttonOnePair_Click(object sender, EventArgs e)
        {
            double dXValue = Convert.ToDouble(textBoxOnePairX.Text);
            double dYValue = Convert.ToDouble(textBoxOnePairY.Text);
            bool bShowDetails = checkBoxShowDetails.Checked;
            int iNumOfSeries = 10000;

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

                FormResult result = new FormResult(lstlstComplex, false);
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

                FormResult result = new FormResult(lstlstComplex, false);
                result.StartPosition = FormStartPosition.Manual;
                result.Location = new Point(800, 200);
                result.Show();
            }
        }



        private void buttonShowComplexPower_Click(object sender, EventArgs e)
        {
            double dXValue = Convert.ToDouble(textBoxShowPowerReal.Text);
            double dYValue = Convert.ToDouble(textBoxShowPowerImagine.Text);

            double dBase = Convert.ToDouble(textBoxShowPowerBase.Text);

            List<List<Complex>> lstlstComplex = new List<List<Complex>>();

            Complex start = new Complex(0, 0);

            List<Complex> lstComplexes = getSeriesOneExponent(new Complex(dXValue, dYValue), dBase);
            lstComplexes = addComplexToANumber(lstComplexes, start, false);
            lstlstComplex.Add(lstComplexes);


            FormResult result = new FormResult(lstlstComplex, false);
            result.Show();
        }

        private void ButtonAnimation_Click(object sender, EventArgs e)
        {
            double XStart = 0.5;
            double YStart = 0; // 8000;

            List<Complex> lstEta = new List<Complex>();
            List<Complex> lstZeta = new List<Complex>();
            List<Complex> lstComplex = new List<Complex>();
            FormCompareEtaAndZeta ZetaEta = new FormCompareEtaAndZeta();
            ZetaEta.UpdateData(lstComplex, lstComplex, lstComplex, "(0, 0)");
            ZetaEta.Show();

            double[] firstzeros = { 
                14.1347, 21.0220, 25.0209, 30.4248, 32.9351, 37.5862, 40.9187, 43.3271, 
                48.0052, 49.7738, 52.9703, 56.4462, 59.3470, 60.8318, 65.1125, 67.0798, 
                69.5464, 72.0672, 75.7047, 77.1448, 79.3374, 82.9104, 84.7355, 87.4253, 
                88.8091, 92.4919, 94.6513, 95.8706, 98.8312};


            for (int i = 0; i < 10000; i++)
            {
                Application.DoEvents();
                Thread.Sleep(1);
                double dXValue = XStart;
                double dYValue = YStart + i * 0.005;
            //    for (int i = 0; i < 10000; i++)
            //{
            //    Application.DoEvents();
            //    Thread.Sleep(5000);
            //    double dXValue = XStart;
            //    double dYValue = firstzeros[i % firstzeros.Length];
                Complex s = new Complex(dXValue, dYValue);
                lstComplex = GetVectors(s);
                Complex lastOne = lstComplex.Last();

                if (Math.Abs(lastOne.Real) < 0.01 && Math.Abs(lastOne.Imaginary) < 0.01)
                {
                    Console.WriteLine(dYValue);
                }
                lstEta.Add(lastOne);
                //Complex temp1 = Complex.Pow(new Complex(2, 0), s);
                //Complex temp2 = Complex.Divide(new Complex(2, 0), temp1);
                //Complex temp3 = Complex.Subtract(new Complex(1, 0), temp2);
                //lstZeta.Add(Complex.Divide(lastOne, temp3));
                ZetaEta.UpdateData(lstComplex.Take(5000).ToList(), lstEta, lstZeta, "(" + dXValue + ", " + dYValue + ")");
                //ZetaEta.UpdateData(lstComplex.GetRange(0, 10000).ToList(), lstEta, lstEta, "(" + dXValue + ", " + i * 0.02 + ")");
            }

            //FormResult result = new FormResult(lstlstComplex, false);
            //result.StartPosition = FormStartPosition.Manual;
            //result.Location = new Point(0, 200);
            //result.Show();


            //for (int i = 0; i < 50000; i++)
            //{
            //    Application.DoEvents();
            //    result.Show();
            //    Thread.Sleep(1);
            //    lstlstComplex = GetListsAtDifferentY(dXValue, i * 0.2);
            //    result.setDataAndUpdate(lstlstComplex, false);
            //    result.setLabel(dXValue, i * 0.02);
            //}


        }

        private List<Complex> GetVectors(Complex s)
        {
            int iNumOfSeries = 20000;
            //int iNumOfSeries = 5;
            List<Complex> lstComplex = new List<Complex>();
            Complex start = new Complex(0, 0);
            lstComplex.Add(start);
            for (int i = 1; i < iNumOfSeries; i++)
            {
                Complex term = Complex.Pow(new Complex(i, 0), new Complex(-s.Real, -s.Imaginary));
                Complex vectorEnd = (i % 2 == 0) ? start - term : start + term;
                //Complex vectorEnd = start + term;
                start = vectorEnd;
                lstComplex.Add(start);
            }
            return lstComplex;
        }

        private List<Complex> GetExpVectors(Complex s, int iNumOfSeries, int iBaseNum)
        {
            List<Complex> lstComplex = new List<Complex>();
            Complex start = new Complex(0, 0);
            lstComplex.Add(start);
            int iBase = 1;
            for (int i = 1; i < iNumOfSeries; i++)
            {
                Complex term = Complex.Pow(new Complex(iBase, 0), new Complex(-s.Real, -s.Imaginary));
                Complex vectorEnd = start + term;
                //Complex vectorEnd = start + term;
                start = vectorEnd;
                lstComplex.Add(start);
                iBase *= iBaseNum;
            }
            return lstComplex;
        }

        private List<Complex> GetPrimeProductVectors(Complex s, int iNumOfSeries, int iBaseNum)
        {
            List<Complex> lstComplex = new List<Complex>();
            Complex start = new Complex(0, 0);
            lstComplex.Add(start);
            double dBase = 1;
            for (int i = 1; i < iNumOfSeries; i++)
            {
                Complex term = Complex.Pow(new Complex(dBase, 0), new Complex(-s.Real, -s.Imaginary));
                Complex vectorEnd = start + term;
                //Complex vectorEnd = start + term;
                start = vectorEnd;
                lstComplex.Add(start);
                dBase *= iBaseNum;
            }
            return lstComplex;
        }

        private List<List<Complex>> GetListsAtDifferentY(double dXValue, double dYValue)
        {
            int iNumOfSeries = 20000;


            List<List<Complex>> lstlstComplex = new List<List<Complex>>();

            Complex start = new Complex(0, 0);
            for (int i = 1; i < iNumOfSeries; i++)
            {
                //List<Complex> lstComplexes = getSeriesOneExponent(new Complex(dXValue, dYValue), i);
                List<Complex> lstComplexes = getSeriesOneExponentJustTwoPoints(new Complex(dXValue, dYValue), i);
                List<Complex> lstComplexesShift = addComplexToANumber(lstComplexes, start, i % 2 == 0);
                List<Complex> lstLast = new List<Complex>();
                lstLast.Add(start);
                lstLast.Add(lstComplexesShift[lstComplexes.Count - 1]);
                lstlstComplex.Add(lstLast);

                start = lstComplexesShift[lstComplexes.Count - 1];
            }

            return lstlstComplex;
        }

        private void buttonCompareTwocurves_Click(object sender, EventArgs e)
        {

            int iNumOfSeries = 10000;
            List<List<Complex>> lstlstComplex1 = new List<List<Complex>>();
            List<List<Complex>> lstlstComplex2 = new List<List<Complex>>();
            {
                
                double dXValue = Convert.ToDouble(textBoxCompareX1.Text);
                double dYValue = Convert.ToDouble(textBoxCompareY1.Text);


                Complex start = new Complex(0, 0);
                for (int i = 1; i < iNumOfSeries; i++)
                {
                    List<Complex> lstComplexes = getSeriesOneExponent(new Complex(dXValue, dYValue), i);
                    List<Complex> lstComplexesShift = addComplexToANumber(lstComplexes, start, i % 2 == 0);
                   
                    List<Complex> lstLast = new List<Complex>();
                    lstLast.Add(start);
                    lstLast.Add(lstComplexesShift[lstComplexes.Count - 1]);
                    lstlstComplex1.Add(lstLast);

                    start = lstComplexesShift[lstComplexes.Count - 1];
                }

            }


            {
                double dXValue = Convert.ToDouble(textBoxCompareX2.Text);
                double dYValue = Convert.ToDouble(textBoxCompareY2.Text);


                Complex start = new Complex(0, 0);
                for (int i = 1; i < iNumOfSeries; i++)
                {
                    List<Complex> lstComplexes = getSeriesOneExponent(new Complex(dXValue, dYValue), i);
                    List<Complex> lstComplexesShift = addComplexToANumber(lstComplexes, start, i % 2 == 0);

                    List<Complex> lstLast = new List<Complex>();
                    lstLast.Add(start);
                    lstLast.Add(lstComplexesShift[lstComplexes.Count - 1]);
                    lstlstComplex2.Add(lstLast);

                    start = lstComplexesShift[lstComplexes.Count - 1];
                }

            }


            FormCompare result = new FormCompare(lstlstComplex1, lstlstComplex2);
            result.StartPosition = FormStartPosition.Manual;
            result.Location = new Point(0, 200);
            result.Show();
        }

        private List<List<Complex>> multplyAComplex(double dXValue, double dYValue, Complex complex2)
        {
            int iNumOfSeries = 10;

            List<List<Complex>> lstlstComplex = new List<List<Complex>>();

            Complex start = new Complex(0, 0);
            for (int i = 1; i < iNumOfSeries; i++)
            {
                List<Complex> lstComplexes = getSeriesOneExponentJustTwoPointsMultiply(new Complex(dXValue, dYValue), i, complex2);
                List<Complex> lstComplexesShift = addComplexToANumber(lstComplexes, start, i % 2 == 0);
                List<Complex> lstLast = new List<Complex>();
                lstLast.Add(start);
                lstLast.Add(lstComplexesShift[lstComplexes.Count - 1]);
                lstlstComplex.Add(lstLast);

                start = lstComplexesShift[lstComplexes.Count - 1];
            }

            return lstlstComplex;
        }

        private void buttonMultiplyComplex_Click(object sender, EventArgs e)
        {
            double dXValue = -0.8;
            double dYValue = 5;



            List<List<Complex>> lstlstComplex1 = multplyAComplex(dXValue, dYValue, new Complex(1, 0));

            //double dRotate3 = Math.Log(Math.E, 3) * Math.PI * 2 - dYValue;
            //double dRotate4 = Math.Log(Math.E, 4) * Math.PI * 2 - dYValue;
            //double dRotate6 = Math.Log(Math.E, 6) * Math.PI * 2 - dYValue;
            //double dRotate8 = Math.Log(Math.E, 8) * Math.PI * 2 - dYValue;

            List<List<Complex>> lstlstComplex2 = multplyAComplex(dXValue, dYValue, new Complex(1, 0));

            FormCompare result = new FormCompare(lstlstComplex1, lstlstComplex2);
            result.StartPosition = FormStartPosition.Manual;
            result.Location = new Point(0, 200);
            result.Show();

            int iLoopNum = 20;
            for (int i = 1; i <= iLoopNum; i++)
            {
                //double rotate2halfRound = Math.Log(Math.E, 2) * Math.PI * i;
                Complex cRotate = Complex.Exp(new Complex(0, Math.PI * i ));

                Application.DoEvents();
                result.Show();
                Thread.Sleep(200);
                lstlstComplex2 = multplyAComplex(dXValue, dYValue, cRotate);

                result.setDataAndUpdate(lstlstComplex1, lstlstComplex2);

                //for (int j = 1; j < iLoopNum; j++)
                //{
                //    double rotate3halfRound = Math.Log(Math.E, 3) * Math.PI * j;

                //    for (int k = 1; k < iLoopNum; k++)
                //    {
                //        double rotate4halfRound = Math.Log(Math.E, 4) * Math.PI * k;
                //        //if (Math.Abs(rotate2halfRound - rotate3halfRound) < 0.01 && Math.Abs(rotate4halfRound - rotate3halfRound) < 0.01)
                //        //{

                //        }
                //    }
                //}
            }
        }

        private void buttonChangeA_Click(object sender, EventArgs e)
        {
            double dXValue = 0;
            double dYValue = 21;

            List<List<Complex>> lstlstComplex = GetListsAtDifferentY(dXValue, dYValue);

            FormResult result = new FormResult(lstlstComplex, false);
            result.StartPosition = FormStartPosition.Manual;
            result.Location = new Point(0, 200);
            result.Show();


            for (int i = 0; i < 3500; i++)
            {
                Application.DoEvents();
                result.Show();
                //Thread.Sleep(100);
                lstlstComplex = GetListsAtDifferentY(-0.001 * i, dYValue);
                result.setDataAndUpdate(lstlstComplex, false);
                result.setLabel(0.001 * i, dYValue);
            }

        }

        private void buttonAnimationBall_Click(object sender, EventArgs e)
        {
            double dXValue = -0.95;
            double dYValue = 0;

            List<List<Complex>> lstlstComplex = GetListsAtDifferentY_Ball(dXValue, dYValue);

            FormResult result = new FormResult(lstlstComplex, false);
            result.StartPosition = FormStartPosition.Manual;
            result.Location = new Point(0, 200);
            result.Show();


            for (int i = 0; i < 105; i++)
            {
                Application.DoEvents();
                result.Show();
                Thread.Sleep(2000);
                lstlstComplex = GetListsAtDifferentY_Ball(dXValue, i * 0.2);
                result.setDataAndUpdate(lstlstComplex, false);
                result.setLabel(dXValue, i * 0.02);
            }

        }


        private List<List<Complex>> GetListsAtDifferentY_Ball(double dXValue, double dYValue)
        {
            int iNumOfSeries = 2000;

            List<List<Complex>> lstlstComplex = new List<List<Complex>>();

            Complex start = new Complex(0, 0);
            for (int i = 1; i < iNumOfSeries; i++)
            {
                //List<Complex> lstComplexes = getSeriesOneExponent(new Complex(dXValue, dYValue), i);
                List<Complex> lstComplexes = getSeriesOneExponentJustTwoPoints(new Complex(dXValue, dYValue), i);
                List<Complex> lstComplexesShift = addComplexToANumber(lstComplexes, start, i % 2 == 0);
                List<Complex> lstLast = new List<Complex>();
                lstLast.Add(start);
                lstLast.Add(lstComplexesShift[lstComplexes.Count - 1]);
                lstlstComplex.Add(lstLast);

            }

            return lstlstComplex;
        }

        private void buttonBallRotate_Click(object sender, EventArgs e)
        {
            double dXValue = -0.61;
            double dYValue = 8.2;


            List<List<Complex>> lstlstComplex = GetListsAtDifferentY_Ball(dXValue, dYValue);

            FormResult result = new FormResult(lstlstComplex, false);
            result.StartPosition = FormStartPosition.Manual;
            result.Location = new Point(0, 200);
            result.Show();


            Complex cRotate = Complex.Exp(new Complex(0, -dYValue * Math.Log(3)));
            //Complex cRotate = Complex.Exp(new Complex(0, Math.PI));

            List<List<Complex>> lstlstComplexRotated = new List<List<Complex>>();

            for (int i = 0; i < lstlstComplex.Count; i++)
            {
                List<Complex> lstRotated = new List<Complex>();
                for (int j = 0; j < lstlstComplex.ElementAt(i).Count; j++)
                {
                    lstRotated.Add(Complex.Multiply(lstlstComplex.ElementAt(i).ElementAt(j), cRotate));
                }
                lstlstComplexRotated.Add(lstRotated);
            }

            FormResult result1 = new FormResult(lstlstComplexRotated, false);
            result1.StartPosition = FormStartPosition.Manual;
            result1.Location = new Point(0, 200);
            result1.Show();
         
        }

        private void buttonShowSumBySkipping_Click(object sender, EventArgs e)
        {
            double dBase = Convert.ToDouble(textBoxBaseInSkip.Text);
            double dX = 0.5;
            double dY = 2;

            int iNumOfSeries = 10;


            {
                List<List<Complex>> lstlstComplex = new List<List<Complex>>();

                Complex start = new Complex(0, 0);
  
                for (int i = 1; i < iNumOfSeries; i++)
                {
                    List<Complex> lstComplexes = getSeriesOneExponent(new Complex(dX, dY), dBase * i);
                    List<Complex> lstComplexesShift = addComplexToANumber(lstComplexes, start, false);
                   
                    List<Complex> lstLast = new List<Complex>();
                    lstLast.Add(start);
                    lstLast.Add(lstComplexesShift[lstComplexes.Count - 1]);
                    lstlstComplex.Add(lstLast);

                    start = lstComplexesShift[lstComplexes.Count - 1];
                }

                FormResult result = new FormResult(lstlstComplex, false);
                result.StartPosition = FormStartPosition.Manual;
                result.Location = new Point(800, 200);
                result.Show();
            }

        }

        private void buttonPlotSum_Click(object sender, EventArgs e)
        {
            double dXValue = -0.61;
            double dYValue = 8.2;


            List<List<Complex>> lstlstComplex = GetListsAtDifferentY_Ball(dXValue, dYValue);

            FormResult result = new FormResult(lstlstComplex, false);
            result.StartPosition = FormStartPosition.Manual;
            result.Location = new Point(0, 200);
            result.Show();

        }

        private void buttonBallCompare_Click(object sender, EventArgs e)
        {
            //double dXValue = -1;
            double dYValue = 14.14;


            //List<List<Complex>> lstlstComplex = GetListsAtDifferentY_Ball(dXValue, dYValue);
            //lstlstComplex.Add(sumOfListComplex(lstlstComplex));
            
            //FormResult result = new FormResult(lstlstComplex, true);
            //result.StartPosition = FormStartPosition.Manual;
            //result.Location = new Point(0, 200);
            //result.Show();


            //Complex cRotate = Complex.Exp(new Complex(0, -dYValue * Math.Log(3)));
            //Complex cRotate = Complex.Exp(new Complex(0, Math.PI));

            List<List<Complex>> lstlstComplexDoubleA = GetListsAtDifferentY_Ball(-0.1, dYValue);
            lstlstComplexDoubleA.Add(sumOfListComplex(lstlstComplexDoubleA));

            FormResult result1 = new FormResult(lstlstComplexDoubleA, true);
            result1.StartPosition = FormStartPosition.Manual;
            result1.Location = new Point(0, 20);
            result1.Show();


            List<List<Complex>> lstlstComplexAnotherA = GetListsAtDifferentY_Ball(-0.9, dYValue);
            lstlstComplexAnotherA.Add(sumOfListComplex(lstlstComplexAnotherA));

            FormResult result2 = new FormResult(lstlstComplexAnotherA, true);
            result2.StartPosition = FormStartPosition.Manual;
            result2.Location = new Point(0, 20);
            result2.Show();
        }

        private List<Complex> sumOfListComplex(List<List<Complex>> lstlstComplex)
        {
            List<Complex> lstReturn = new List<Complex>();
            lstReturn.Add(new Complex(0, 0));
            Complex sum = new Complex(0, 0);
            for (int i = 0; i < lstlstComplex.Count; i++)
            {
                List<Complex> lstComplex = lstlstComplex[i];
                sum += lstComplex[1];
            }

            lstReturn.Add(sum);
            return lstReturn;
        }

        private List<Complex> sumOfPowerOfI(List<List<Complex>> lstlstComplex)
        {
            List<Complex> lstReturn = new List<Complex>();
            lstReturn.Add(new Complex(0, 0));
            Complex sum = new Complex(0, 0);
            for (int i = 0; i < lstlstComplex.Count; i++)
            {
                List<Complex> lstComplex = lstlstComplex[i];
                lstReturn.Add(Complex.Pow(new Complex(i + 1, 0), new Complex(0, 0.5)));
                sum += (Complex.Pow(new Complex(i + 1, 0), new Complex(0, 0.5)));
            }

            lstReturn.Add(sum);
            return lstReturn;
        }

        private void buttonCalculateCoefficient_Click(object sender, EventArgs e)
        {
            int iTotalNum = 10000;
            int[] arr_Sum1 = new int[iTotalNum];
            for (int i = 0; i < iTotalNum; i++)
            {
                arr_Sum1[i] = (i % 2 == 0 ? 1 : -1);
            }


            int[] arr_Sum = new int[iTotalNum];
            for (int i = 0; i < iTotalNum; i++)
            {
                arr_Sum[i] = 0;
            }

            CalculatePower(iTotalNum, arr_Sum, arr_Sum1);


            int[] arr_Sum2 = new int[iTotalNum];
            for (int i = 0; i < iTotalNum; i++)
            {
                arr_Sum2[i] = arr_Sum[i];
                //arr_Sum[i] = 0;
            }

            //CalculatePower(iTotalNum, arr_Sum, arr_Sum2);

            //int[] arr_Sum3 = new int[iTotalNum];
            //for (int i = 0; i < iTotalNum; i++)
            //{
            //    arr_Sum3[i] = arr_Sum[i];
               
            //}




            int maxValue = arr_Sum.Max();
            int minValue = arr_Sum.Min();
            int maxIndex = arr_Sum.ToList().IndexOf(maxValue) + 1;
            int minIndex = arr_Sum.ToList().IndexOf(minValue) + 1;

            MessageBox.Show(arr_Sum.Min().ToString() + " at " + minIndex.ToString() + "\n" +
                arr_Sum.Max().ToString() + " at " + maxIndex.ToString());



            var fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "numbers.txt");

            using (StreamWriter writetext = new StreamWriter(fileName))
            {
                //int iCount = 0;
                for (int i = 0; i < iTotalNum; i++)
                {
                    if (arr_Sum2[i] - 2 * arr_Sum1[i] < 0)
                    {
                        writetext.Write(arr_Sum2[i] - 2 * arr_Sum1[i] + "/" + (i + 1) + "^x ");
                        //iCount++;
                    }
                    else if (arr_Sum2[i] - 2 * arr_Sum1[i] > 0)
                    {
                        writetext.Write("+" + (arr_Sum2[i] - 2 * arr_Sum1[i]) + "/" + (i + 1) + "^x ");
                    }
                }

            }

            using (StreamWriter writetext = new StreamWriter(fileName))
            {

                for (int iSum = minValue; iSum <= maxValue; iSum++)
                {
                    StringBuilder str = new StringBuilder();

                    bool bFoundOne = false;
                    for (int i = 0; i < iTotalNum; i++)
                    {
                        if (iSum == arr_Sum[i])
                        {
                            str.Append((i + 1).ToString() + "\t");
                            bFoundOne = true;
                        }
                    }

                    if (bFoundOne)
                    {
                        writetext.WriteLine(iSum + ":");
                        writetext.WriteLine("\t" + str);
                        writetext.WriteLine();
                    }
                }
            }


            //FormPoints formPoints = new FormPoints(arr_SumFirst8);
            //formPoints.Show();






        }

        private static void CalculatePower(int iTotalNum, int[] arr_Sum, int[] arr_Sum2)
        {
            for (int j = 0; j < iTotalNum; j++)
            {

                int[] arr_N = new int[iTotalNum];
                for (int i = 0; i < iTotalNum; i++)
                {
                    arr_N[i] = 0;
                }

                int iSign = (j % 2 == 0) ? 1 : -1;
                int iCount_N = 0;
                for (int i = 0; i < iTotalNum; i++)
                {
                    if ((i + 1) % (j + 1) == 0)
                    {
                        arr_N[i] = (iSign * arr_Sum2[iCount_N]);
                        iCount_N++;
                    }
                }

                for (int i = 0; i < iTotalNum; i++)
                {
                    arr_Sum[i] += arr_N[i];
                }
            }
        }

        private void buttonSumRoot2_Click(object sender, EventArgs e)
        {
            double dSum = 0;

            for (int i = 1; i < 1000000; i++)
            {
                dSum += (Math.Pow(-1, i+1) /Math.Sqrt( i));
            }

            Console.WriteLine(dSum / (1-Math.Sqrt(2)) );
        }

        private void buttonShowImageChange_Click(object sender, EventArgs e)
        {
            double dXValue = -0.55;
            double dYValue = -0.86;


            List<List<Complex>> lstlstComplex = GetListsAtDifferentY_ImaginaryChange(dXValue, dYValue);

            FormResult result = new FormResult(lstlstComplex, false);
            result.StartPosition = FormStartPosition.Manual;
            result.Location = new Point(0, 200);
            result.Show();

        }

        private List<List<Complex>> GetListsAtDifferentY_ImaginaryChange(double dXValue, double dYValue)
        {
            int iNumOfSeries = 380;

            List<List<Complex>> lstlstComplex = new List<List<Complex>>();

            Complex start = new Complex(0, 0);
            for (int i = 1; i < iNumOfSeries; i++)
            {
                //List<Complex> lstComplexes = getSeriesOneExponent(new Complex(dXValue, dYValue), i);
                List<Complex> lstComplexes = getSeriesOneExponentJustTwoPoints(new Complex(dXValue, dYValue), i);
                //List<Complex> lstComplexesShift = addComplexToANumber(lstComplexes, start, i % 2 == 0);
                List<Complex> lstComplexesShift = addComplexToANumber(lstComplexes, start, false);
                List<Complex> lstLast = new List<Complex>();
                lstLast.Add(start);
                lstLast.Add(lstComplexesShift[lstComplexes.Count - 1]);
                lstlstComplex.Add(lstLast);

            }

            return lstlstComplex;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            int iNumOfSeries = 10000;
            List<List<Complex>> lstlstComplex1 = new List<List<Complex>>();
            List<List<Complex>> lstlstComplex2 = new List<List<Complex>>();
            List<List<Complex>> lstlstComplex3 = new List<List<Complex>>();

            {

                double dXValue = Convert.ToDouble(textBoxProjectionX1.Text);
                double dYValue = Convert.ToDouble(textBoxProjectionY1.Text);


                Complex start = new Complex(0, 0);
                for (int i = 1; i < iNumOfSeries; i++)
                {
                    List<Complex> lstComplexes = getSeriesOneExponent(new Complex(dXValue, dYValue), i);
                    List<Complex> lstComplexesShift = addComplexToANumber(lstComplexes, start, i % 2 == 0);

                    List<Complex> lstLast = new List<Complex>();
                    lstLast.Add(start);
                    lstLast.Add(lstComplexesShift[lstComplexes.Count - 1]);
                    lstlstComplex1.Add(lstLast);

                    start = lstComplexesShift[lstComplexes.Count - 1];
                }

            }


            {
                double dXValue = Convert.ToDouble(textBoxProjectionX2.Text);
                double dYValue = Convert.ToDouble(textBoxProjectionY2.Text);


                Complex start = new Complex(0, 0);
                for (int i = 1; i < iNumOfSeries; i++)
                {
                    List<Complex> lstComplexes = getSeriesOneExponent(new Complex(dXValue, dYValue), i);
                    List<Complex> lstComplexesShift = addComplexToANumber(lstComplexes, start, i % 2 == 0);

                    List<Complex> lstLast = new List<Complex>();
                    lstLast.Add(start);
                    lstLast.Add(lstComplexesShift[lstComplexes.Count - 1]);
                    lstlstComplex2.Add(lstLast);

                    start = lstComplexesShift[lstComplexes.Count - 1];
                }

            }

            {
                double dXValue = Convert.ToDouble(textBoxProjectionX3.Text);
                double dYValue = Convert.ToDouble(textBoxProjectionY3.Text);


                Complex start = new Complex(0, 0);
                for (int i = 1; i < iNumOfSeries; i++)
                {
                    List<Complex> lstComplexes = getSeriesOneExponent(new Complex(dXValue, dYValue), i);
                    List<Complex> lstComplexesShift = addComplexToANumber(lstComplexes, start, i % 2 == 0);

                    List<Complex> lstLast = new List<Complex>();
                    lstLast.Add(start);
                    lstLast.Add(lstComplexesShift[lstComplexes.Count - 1]);
                    lstlstComplex3.Add(lstLast);

                    start = lstComplexesShift[lstComplexes.Count - 1];
                }

            }


            FormCompare result = new FormCompare(lstlstComplex1, lstlstComplex2, lstlstComplex3);
            result.StartPosition = FormStartPosition.Manual;
            result.Location = new Point(0, 200);
            result.Show();
        }

        private void buttonSumExponentials_Click(object sender, EventArgs e)
        {
            double XStart = 0.7;
            double YStart = 0; // 20; // 800; // 8000;

            List<Complex> lstEta = new List<Complex>();
            List<Complex> lstZeta = new List<Complex>();
            List<Complex> lstComplex = new List<Complex>();
            FormCompareEtaAndZeta ZetaEta = new FormCompareEtaAndZeta();
            ZetaEta.UpdateData(lstComplex, lstComplex, lstComplex, "(0, 0)");
            ZetaEta.Show();
            double dMin = double.MaxValue;
            double dMax = double.MinValue;
            for (int i = 0; i < 10000; i++)
            {
                Application.DoEvents();
                Thread.Sleep(1);
                double dXValue = XStart;
                double dYValue = YStart + i * 0.01;

                if (dYValue > 25.010)
                    break;
                Complex s = new Complex(dXValue, dYValue);
                lstComplex = GetExpVectors(s, 20, 2);
                Complex lastOne = lstComplex.Last();
                lstEta.Add(lastOne);
                lstZeta.Add(Complex.Subtract(new Complex(2, 0), lastOne));
                //lstEta.Add(Complex.Subtract(new Complex(2, 0), lastOne));
                //dMin = Math.Min(lstEta.Last().Real, dMin);
                //dMax = Math.Max(lstEta.Last().Real, dMax);
                //Complex temp1 = Complex.Pow(new Complex(2, 0), s);
                //Complex temp2 = Complex.Divide(new Complex(2, 0), temp1);
                //Complex temp3 = Complex.Subtract(new Complex(1, 0), temp2);
                //lstZeta.Add(Complex.Divide(lastOne, temp3));
                ZetaEta.UpdateData(lstComplex.Take(5000).ToList(), lstEta, lstZeta, "(" + dXValue + ", " + dYValue + ")");
                //ZetaEta.UpdateData(lstComplex.GetRange(0, 10000).ToList(), lstEta, lstEta, "(" + dXValue + ", " + i * 0.02 + ")");
                Console.WriteLine(dMin + ", " + dMax + ", " + lstEta.Last().Magnitude);
            }

        }

        private void buttonPrimeProduct_Click(object sender, EventArgs e)
        {
            double XStart = 0.5;
            double YStart = 20; // 20; // 800; // 8000;

            List<Complex> lstEta = new List<Complex>();
            List<Complex> lstZeta = new List<Complex>();
            List<Complex> lstComplex = new List<Complex>();
            FormCompareEtaAndZeta ZetaEta = new FormCompareEtaAndZeta();
            ZetaEta.UpdateData(lstComplex, lstComplex, lstComplex, "(0, 0)");
            ZetaEta.Show();
            double dMin = double.MaxValue;
            double dMax = double.MinValue;
            for (int i = 0; i < 10000; i++)
            {
                Application.DoEvents();
                Thread.Sleep(1);
                double dXValue = XStart;
                double dYValue = YStart + i * 0.01;
                int iTermNumber = 20;
                if (dYValue > 65.010)
                    break;
                Complex s = new Complex(dXValue, dYValue);
                List<Complex> lstComplex2 = GetPrimeProductVectors(s, iTermNumber, 2);
                Complex lastOne2 = lstComplex2.Last();
                List<Complex> lstComplex3 = GetPrimeProductVectors(s, iTermNumber, 3);
                Complex lastOne3 = lstComplex3.Last();
                List<Complex> lstComplex5 = GetPrimeProductVectors(s, iTermNumber, 5);
                Complex lastOne5 = lstComplex5.Last();
                List<Complex> lstComplex7 = GetPrimeProductVectors(s, iTermNumber, 7);
                Complex lastOne7 = lstComplex7.Last();
                List<Complex> lstComplex11 = GetPrimeProductVectors(s, iTermNumber, 11);
                Complex lastOne11 = lstComplex11.Last();
                List<Complex> lstComplex13 = GetPrimeProductVectors(s, iTermNumber, 13);
                Complex lastOne13 = lstComplex13.Last();
                List<Complex> lstComplex17 = GetPrimeProductVectors(s, iTermNumber, 17);
                Complex lastOne17 = lstComplex17.Last();
                List<Complex> lstComplex19 = GetPrimeProductVectors(s, iTermNumber, 19);
                Complex lastOne19 = lstComplex19.Last();
                List<Complex> lstComplex23 = GetPrimeProductVectors(s, iTermNumber, 23);
                Complex lastOne23 = lstComplex23.Last();
                List<Complex> lstComplex29 = GetPrimeProductVectors(s, iTermNumber, 29);
                Complex lastOne29 = lstComplex29.Last();
                List<Complex> lstComplex31 = GetPrimeProductVectors(s, iTermNumber, 31);
                Complex lastOne31 = lstComplex31.Last();
                List<Complex> lstComplex37 = GetPrimeProductVectors(s, iTermNumber, 37);
                Complex lastOne37 = lstComplex37.Last();

                List<Complex> lstComplex41 = GetPrimeProductVectors(s, iTermNumber, 41);
                Complex lastOne41 = lstComplex41.Last();
                List<Complex> lstComplex43 = GetPrimeProductVectors(s, iTermNumber, 43);
                Complex lastOne43 = lstComplex43.Last();
                List<Complex> lstComplex47 = GetPrimeProductVectors(s, iTermNumber, 47);
                Complex lastOne47 = lstComplex47.Last();
                List<Complex> lstComplex53 = GetPrimeProductVectors(s, iTermNumber, 53);
                Complex lastOne53 = lstComplex53.Last();


                List<Complex> lstComplex59 = GetPrimeProductVectors(s, iTermNumber, 59);
                Complex lastOne59 = lstComplex59.Last();
                List<Complex> lstComplex61 = GetPrimeProductVectors(s, iTermNumber, 61);
                Complex lastOne61 = lstComplex61.Last();
                List<Complex> lstComplex67 = GetPrimeProductVectors(s, iTermNumber, 67);
                Complex lastOne67 = lstComplex67.Last();
                List<Complex> lstComplex71 = GetPrimeProductVectors(s, iTermNumber, 71);
                Complex lastOne71 = lstComplex71.Last();

                List<Complex> lstComplex73 = GetPrimeProductVectors(s, iTermNumber, 73);
                Complex lastOne73 = lstComplex73.Last();
                List<Complex> lstComplex79 = GetPrimeProductVectors(s, iTermNumber, 79);
                Complex lastOne79 = lstComplex79.Last();
                List<Complex> lstComplex83 = GetPrimeProductVectors(s, iTermNumber, 83);
                Complex lastOne83 = lstComplex83.Last();
                List<Complex> lstComplex89 = GetPrimeProductVectors(s, iTermNumber, 89);
                Complex lastOne89 = lstComplex89.Last();
                Complex lastOne2_corrected = Complex.Subtract(new Complex(2, 0), lastOne2);

                Complex Complex2_3_5_7 = Complex.Multiply(Complex.Multiply(lastOne2_corrected, lastOne3), Complex.Multiply(lastOne5, lastOne7));
                Complex Complex11_13_17_19 = Complex.Multiply(Complex.Multiply(lastOne11, lastOne13), Complex.Multiply(lastOne17, lastOne19));
                Complex Complex23_29_31_37 = Complex.Multiply(Complex.Multiply(lastOne23, lastOne29), Complex.Multiply(lastOne31, lastOne37));
                Complex Complex41_43_47_53 = Complex.Multiply(Complex.Multiply(lastOne41, lastOne43), Complex.Multiply(lastOne47, lastOne53));
                Complex Complex59_61_67_71 = Complex.Multiply(Complex.Multiply(lastOne59, lastOne61), Complex.Multiply(lastOne67, lastOne71));
                Complex Complex73_79_83_89 = Complex.Multiply(Complex.Multiply(lastOne73, lastOne79), Complex.Multiply(lastOne83, lastOne89));

                Complex prod1 = Complex.Multiply(Complex2_3_5_7, Complex11_13_17_19);
                Complex prod2 = Complex.Multiply(Complex41_43_47_53, Complex23_29_31_37);
                Complex prod3 = Complex.Multiply(Complex59_61_67_71, Complex73_79_83_89);
                Complex prod1_2 = Complex.Multiply(prod1, prod2);


                //lstZeta.Add(Complex.Subtract(new Complex(2, 0), lastOne));
                //lstEta.Add(Complex.Subtract(new Complex(2, 0), lastOne));
                //dMin = Math.Min(lstEta.Last().Real, dMin);
                //dMax = Math.Max(lstEta.Last().Real, dMax);
                //Complex temp1 = Complex.Pow(new Complex(2, 0), s);
                //Complex temp2 = Complex.Divide(new Complex(2, 0), temp1);
                //Complex temp3 = Complex.Subtract(new Complex(1, 0), temp2);
                //lstZeta.Add(Complex.Divide(lastOne, temp3));
                //lstEta.Add(Complex.Multiply(lastOne11, lastOne23));

                //lstEta.Add(Complex.Multiply(lastOne2, 1));
                lstEta.Add(Complex.Multiply(prod1_2, 1));
                lstZeta.Add(Complex.Multiply(lastOne2, 1));
                ZetaEta.UpdateData(lstComplex2.Take(5000).ToList(), lstEta, lstZeta, "(" + dXValue + ", " + dYValue + ")");

                Console.WriteLine(dMin + ", " + dMax + ", " + lstEta.Last().Magnitude);
            }
        }
    }
}
