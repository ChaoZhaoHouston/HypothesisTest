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
    public partial class FormTestMain : Form
    {
        public FormTestMain()
        {
            InitializeComponent();
        }

        private void buttonTab1Calculate_Click(object sender, EventArgs e)
        {
            FormDisplay formDisplay = new FormDisplay();

            double dXValue = Convert.ToDouble(textBoxTab1X.Text);
            double dYValue = Convert.ToDouble(textBoxTab1Y.Text);

            List<Complex> lstComplex1 = new List<Complex>();
            List<Complex> lstComplex2 = new List<Complex>();
            List<Complex> lstComplex3 = new List<Complex>();

            int iNumberCalculated = 10000;

            //{
            //    Complex start = new Complex(0, 0);
            //    lstComplex1.Add(start);
            //    for (int i = 1; i < iNumberCalculated; i++)
            //    {
            //        Complex currentTerm = Complex.Pow(new Complex(i, 0), new Complex(-dXValue, -dYValue));

            //        start = currentTerm + start;
            //        lstComplex1.Add(start);
            //    }

            //    formDisplay.addVectors(lstComplex1);
            //    Complex last = lstComplex1.Last();
            //    formDisplay.addPoints(last);
            //}

            //{
            //    Complex start = new Complex(0, 0);
            //    lstComplex2.Add(start);
            //    for (int i = 1; i < iNumberCalculated; i++)
            //    {
            //        Complex currentTerm = Complex.Pow(new Complex(i, 0), new Complex(-dXValue, -dYValue));
            //        if (i % 2 == 0)
            //            start = start - currentTerm;
            //        else
            //            start = currentTerm + start;
            //        lstComplex2.Add(start);
            //    }

            //    formDisplay.addVectors(lstComplex2);
            //    Complex temp = Complex.Pow(new Complex(2, 0), new Complex(1 - dXValue, -dYValue));
            //    Complex last = lstComplex2.Last();
            //    Complex result = last / (new Complex(1, 0) - temp);
            //    formDisplay.addPoints(result);
            //}


            {
                Complex start = new Complex(0, 0);
                lstComplex3.Add(start);
                for (int i = 1; i < iNumberCalculated * 2; i += 2)
                {
                    Complex currentTerm = Complex.Pow(new Complex(i, 0), new Complex(-dXValue, -dYValue));

                    start = currentTerm + start;
                    lstComplex3.Add(start);
                }

                formDisplay.addVectors(lstComplex3);
                Complex temp = Complex.Pow(new Complex(2, 0), new Complex(-dXValue, -dYValue));
                Complex last = lstComplex3.Last();
                Complex result = last / (new Complex(1, 0) - temp);
                formDisplay.addPoints(result);
            }


            formDisplay.readyToDisplay();
            formDisplay.Show();
        }
    }
}
