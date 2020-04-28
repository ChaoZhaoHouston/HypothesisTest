using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RiemannHypothesisTest
{
    public partial class FormPoints : Form
    {

        public FormPoints(int[] arr_Sum)
        {
            InitializeComponent();

            chart1.Series[0].Points.Clear();

            for (int i = 0; i < arr_Sum.Length; i++)
            {
                chart1.Series[0].Points.AddXY(i + 1, arr_Sum[i]);
            }
        }
    }
}
