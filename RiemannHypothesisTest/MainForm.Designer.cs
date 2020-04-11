namespace RiemannHypothesisTest
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxX = new System.Windows.Forms.TextBox();
            this.buttonShowX = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxXMax = new System.Windows.Forms.TextBox();
            this.textBoxXMin = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBoxYMax = new System.Windows.Forms.TextBox();
            this.textBoxYMin = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxY = new System.Windows.Forms.TextBox();
            this.buttonShowY = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.buttonShowCalculationDetails = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonOnePoint = new System.Windows.Forms.Button();
            this.textBoxOnePointY = new System.Windows.Forms.TextBox();
            this.textBoxOnePointX = new System.Windows.Forms.TextBox();
            this.checkBoxUseOriginal = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.textBoxBase = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.buttonShowSimpleExponent = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxExponent_Y = new System.Windows.Forms.TextBox();
            this.textBoxExponent_X = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.checkBoxShowDetails = new System.Windows.Forms.CheckBox();
            this.buttonOnePair = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.textBoxOnePairY = new System.Windows.Forms.TextBox();
            this.textBoxOnePairX = new System.Windows.Forms.TextBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.textBoxShowPowerBase = new System.Windows.Forms.TextBox();
            this.buttonShowComplexPower = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.textBoxShowPowerImagine = new System.Windows.Forms.TextBox();
            this.textBoxShowPowerReal = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.textBoxCompareY2 = new System.Windows.Forms.TextBox();
            this.textBoxCompareX2 = new System.Windows.Forms.TextBox();
            this.buttonCompareTwocurves = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.textBoxCompareY1 = new System.Windows.Forms.TextBox();
            this.textBoxCompareX1 = new System.Windows.Forms.TextBox();
            this.buttonMultiplyComplex = new System.Windows.Forms.Button();
            this.buttonChangeA = new System.Windows.Forms.Button();
            this.buttonAnimationBall = new System.Windows.Forms.Button();
            this.buttonBallRotate = new System.Windows.Forms.Button();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.buttonShowSumBySkipping = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.textBoxBaseInSkip = new System.Windows.Forms.TextBox();
            this.buttonPlotSum = new System.Windows.Forms.Button();
            this.buttonBallCompare = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxX
            // 
            this.textBoxX.Location = new System.Drawing.Point(40, 55);
            this.textBoxX.Name = "textBoxX";
            this.textBoxX.Size = new System.Drawing.Size(54, 20);
            this.textBoxX.TabIndex = 4;
            this.textBoxX.Text = "0.5";
            // 
            // buttonShowX
            // 
            this.buttonShowX.Location = new System.Drawing.Point(233, 28);
            this.buttonShowX.Name = "buttonShowX";
            this.buttonShowX.Size = new System.Drawing.Size(98, 33);
            this.buttonShowX.TabIndex = 5;
            this.buttonShowX.Text = "Show X Results";
            this.buttonShowX.UseVisualStyleBackColor = true;
            this.buttonShowX.Click += new System.EventHandler(this.buttonShowX_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxXMax);
            this.groupBox1.Controls.Add(this.textBoxXMin);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.textBoxX);
            this.groupBox1.Controls.Add(this.buttonShowX);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(438, 102);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Line along X axis";
            // 
            // textBoxXMax
            // 
            this.textBoxXMax.Location = new System.Drawing.Point(122, 28);
            this.textBoxXMax.Name = "textBoxXMax";
            this.textBoxXMax.Size = new System.Drawing.Size(54, 20);
            this.textBoxXMax.TabIndex = 11;
            this.textBoxXMax.Text = "10";
            // 
            // textBoxXMin
            // 
            this.textBoxXMin.Location = new System.Drawing.Point(40, 28);
            this.textBoxXMin.Name = "textBoxXMin";
            this.textBoxXMin.Size = new System.Drawing.Size(54, 20);
            this.textBoxXMin.TabIndex = 10;
            this.textBoxXMin.Text = "0.1";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "X:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Y:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBoxYMax);
            this.groupBox2.Controls.Add(this.textBoxYMin);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.textBoxY);
            this.groupBox2.Controls.Add(this.buttonShowY);
            this.groupBox2.Location = new System.Drawing.Point(12, 145);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(438, 95);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Line along Y axis";
            // 
            // textBoxYMax
            // 
            this.textBoxYMax.Location = new System.Drawing.Point(122, 53);
            this.textBoxYMax.Name = "textBoxYMax";
            this.textBoxYMax.Size = new System.Drawing.Size(54, 20);
            this.textBoxYMax.TabIndex = 9;
            this.textBoxYMax.Text = "100";
            // 
            // textBoxYMin
            // 
            this.textBoxYMin.Location = new System.Drawing.Point(40, 53);
            this.textBoxYMin.Name = "textBoxYMin";
            this.textBoxYMin.Size = new System.Drawing.Size(54, 20);
            this.textBoxYMin.TabIndex = 8;
            this.textBoxYMin.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Y:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "X:";
            // 
            // textBoxY
            // 
            this.textBoxY.Location = new System.Drawing.Point(40, 19);
            this.textBoxY.Name = "textBoxY";
            this.textBoxY.Size = new System.Drawing.Size(54, 20);
            this.textBoxY.TabIndex = 4;
            this.textBoxY.Text = "0.5";
            // 
            // buttonShowY
            // 
            this.buttonShowY.Location = new System.Drawing.Point(233, 22);
            this.buttonShowY.Name = "buttonShowY";
            this.buttonShowY.Size = new System.Drawing.Size(98, 33);
            this.buttonShowY.TabIndex = 5;
            this.buttonShowY.Text = "Show Y Results";
            this.buttonShowY.UseVisualStyleBackColor = true;
            this.buttonShowY.Click += new System.EventHandler(this.buttonShowY_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.buttonShowCalculationDetails);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.buttonOnePoint);
            this.groupBox3.Controls.Add(this.textBoxOnePointY);
            this.groupBox3.Controls.Add(this.textBoxOnePointX);
            this.groupBox3.Location = new System.Drawing.Point(12, 277);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(438, 112);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            // 
            // buttonShowCalculationDetails
            // 
            this.buttonShowCalculationDetails.Location = new System.Drawing.Point(242, 44);
            this.buttonShowCalculationDetails.Name = "buttonShowCalculationDetails";
            this.buttonShowCalculationDetails.Size = new System.Drawing.Size(126, 23);
            this.buttonShowCalculationDetails.TabIndex = 5;
            this.buttonShowCalculationDetails.Text = "ShowCalculationDetails";
            this.buttonShowCalculationDetails.UseVisualStyleBackColor = true;
            this.buttonShowCalculationDetails.Click += new System.EventHandler(this.buttonShowCalculationDetails_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Y:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "X:";
            // 
            // buttonOnePoint
            // 
            this.buttonOnePoint.Location = new System.Drawing.Point(96, 43);
            this.buttonOnePoint.Name = "buttonOnePoint";
            this.buttonOnePoint.Size = new System.Drawing.Size(90, 23);
            this.buttonOnePoint.TabIndex = 2;
            this.buttonOnePoint.Text = "Show one point";
            this.buttonOnePoint.UseVisualStyleBackColor = true;
            this.buttonOnePoint.Click += new System.EventHandler(this.buttonOnePoint_Click);
            // 
            // textBoxOnePointY
            // 
            this.textBoxOnePointY.Location = new System.Drawing.Point(33, 59);
            this.textBoxOnePointY.Name = "textBoxOnePointY";
            this.textBoxOnePointY.Size = new System.Drawing.Size(48, 20);
            this.textBoxOnePointY.TabIndex = 1;
            this.textBoxOnePointY.Text = "2";
            // 
            // textBoxOnePointX
            // 
            this.textBoxOnePointX.Location = new System.Drawing.Point(33, 30);
            this.textBoxOnePointX.Name = "textBoxOnePointX";
            this.textBoxOnePointX.Size = new System.Drawing.Size(48, 20);
            this.textBoxOnePointX.TabIndex = 0;
            this.textBoxOnePointX.Text = "2";
            // 
            // checkBoxUseOriginal
            // 
            this.checkBoxUseOriginal.AutoSize = true;
            this.checkBoxUseOriginal.Location = new System.Drawing.Point(45, 550);
            this.checkBoxUseOriginal.Name = "checkBoxUseOriginal";
            this.checkBoxUseOriginal.Size = new System.Drawing.Size(118, 17);
            this.checkBoxUseOriginal.TabIndex = 12;
            this.checkBoxUseOriginal.Text = "Use original formula";
            this.checkBoxUseOriginal.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.textBoxBase);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.buttonShowSimpleExponent);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.textBoxExponent_Y);
            this.groupBox4.Controls.Add(this.textBoxExponent_X);
            this.groupBox4.Location = new System.Drawing.Point(483, 2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(378, 112);
            this.groupBox4.TabIndex = 13;
            this.groupBox4.TabStop = false;
            // 
            // textBoxBase
            // 
            this.textBoxBase.Location = new System.Drawing.Point(68, 80);
            this.textBoxBase.Name = "textBoxBase";
            this.textBoxBase.Size = new System.Drawing.Size(66, 20);
            this.textBoxBase.TabIndex = 7;
            this.textBoxBase.Text = "2";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(14, 83);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(34, 13);
            this.label9.TabIndex = 6;
            this.label9.Text = "Base:";
            // 
            // buttonShowSimpleExponent
            // 
            this.buttonShowSimpleExponent.Location = new System.Drawing.Point(242, 44);
            this.buttonShowSimpleExponent.Name = "buttonShowSimpleExponent";
            this.buttonShowSimpleExponent.Size = new System.Drawing.Size(126, 23);
            this.buttonShowSimpleExponent.TabIndex = 5;
            this.buttonShowSimpleExponent.Text = "ShowCalculationDetails";
            this.buttonShowSimpleExponent.UseVisualStyleBackColor = true;
            this.buttonShowSimpleExponent.Click += new System.EventHandler(this.buttonShowSimpleExponent_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(99, 34);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Y:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 34);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(17, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "X:";
            // 
            // textBoxExponent_Y
            // 
            this.textBoxExponent_Y.Location = new System.Drawing.Point(122, 30);
            this.textBoxExponent_Y.Name = "textBoxExponent_Y";
            this.textBoxExponent_Y.Size = new System.Drawing.Size(48, 20);
            this.textBoxExponent_Y.TabIndex = 1;
            this.textBoxExponent_Y.Text = "-2";
            // 
            // textBoxExponent_X
            // 
            this.textBoxExponent_X.Location = new System.Drawing.Point(33, 30);
            this.textBoxExponent_X.Name = "textBoxExponent_X";
            this.textBoxExponent_X.Size = new System.Drawing.Size(48, 20);
            this.textBoxExponent_X.TabIndex = 0;
            this.textBoxExponent_X.Text = "-0.5";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.checkBoxShowDetails);
            this.groupBox5.Controls.Add(this.buttonOnePair);
            this.groupBox5.Controls.Add(this.label11);
            this.groupBox5.Controls.Add(this.label12);
            this.groupBox5.Controls.Add(this.textBoxOnePairY);
            this.groupBox5.Controls.Add(this.textBoxOnePairX);
            this.groupBox5.Location = new System.Drawing.Point(483, 145);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(378, 106);
            this.groupBox5.TabIndex = 14;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Compare zeta function and theta function";
            // 
            // checkBoxShowDetails
            // 
            this.checkBoxShowDetails.AutoSize = true;
            this.checkBoxShowDetails.Location = new System.Drawing.Point(36, 82);
            this.checkBoxShowDetails.Name = "checkBoxShowDetails";
            this.checkBoxShowDetails.Size = new System.Drawing.Size(86, 17);
            this.checkBoxShowDetails.TabIndex = 6;
            this.checkBoxShowDetails.Text = "Show details";
            this.checkBoxShowDetails.UseVisualStyleBackColor = true;
            // 
            // buttonOnePair
            // 
            this.buttonOnePair.Location = new System.Drawing.Point(242, 44);
            this.buttonOnePair.Name = "buttonOnePair";
            this.buttonOnePair.Size = new System.Drawing.Size(126, 23);
            this.buttonOnePair.TabIndex = 5;
            this.buttonOnePair.Text = "ShowCalculationDetails";
            this.buttonOnePair.UseVisualStyleBackColor = true;
            this.buttonOnePair.Click += new System.EventHandler(this.buttonOnePair_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(99, 34);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(17, 13);
            this.label11.TabIndex = 4;
            this.label11.Text = "Y:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(10, 34);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(17, 13);
            this.label12.TabIndex = 3;
            this.label12.Text = "X:";
            // 
            // textBoxOnePairY
            // 
            this.textBoxOnePairY.Location = new System.Drawing.Point(122, 30);
            this.textBoxOnePairY.Name = "textBoxOnePairY";
            this.textBoxOnePairY.Size = new System.Drawing.Size(48, 20);
            this.textBoxOnePairY.TabIndex = 1;
            this.textBoxOnePairY.Text = "-2";
            // 
            // textBoxOnePairX
            // 
            this.textBoxOnePairX.Location = new System.Drawing.Point(33, 30);
            this.textBoxOnePairX.Name = "textBoxOnePairX";
            this.textBoxOnePairX.Size = new System.Drawing.Size(48, 20);
            this.textBoxOnePairX.TabIndex = 0;
            this.textBoxOnePairX.Text = "-0.5";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.textBoxShowPowerBase);
            this.groupBox6.Controls.Add(this.buttonShowComplexPower);
            this.groupBox6.Controls.Add(this.label10);
            this.groupBox6.Controls.Add(this.label13);
            this.groupBox6.Controls.Add(this.label14);
            this.groupBox6.Controls.Add(this.textBoxShowPowerImagine);
            this.groupBox6.Controls.Add(this.textBoxShowPowerReal);
            this.groupBox6.Location = new System.Drawing.Point(483, 277);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(378, 112);
            this.groupBox6.TabIndex = 14;
            this.groupBox6.TabStop = false;
            // 
            // textBoxShowPowerBase
            // 
            this.textBoxShowPowerBase.Location = new System.Drawing.Point(84, 73);
            this.textBoxShowPowerBase.Name = "textBoxShowPowerBase";
            this.textBoxShowPowerBase.Size = new System.Drawing.Size(66, 20);
            this.textBoxShowPowerBase.TabIndex = 9;
            this.textBoxShowPowerBase.Text = "2";
            // 
            // buttonShowComplexPower
            // 
            this.buttonShowComplexPower.Location = new System.Drawing.Point(204, 43);
            this.buttonShowComplexPower.Name = "buttonShowComplexPower";
            this.buttonShowComplexPower.Size = new System.Drawing.Size(153, 34);
            this.buttonShowComplexPower.TabIndex = 5;
            this.buttonShowComplexPower.Text = "Show Power calculation";
            this.buttonShowComplexPower.UseVisualStyleBackColor = true;
            this.buttonShowComplexPower.Click += new System.EventHandler(this.buttonShowComplexPower_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(30, 76);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(34, 13);
            this.label10.TabIndex = 8;
            this.label10.Text = "Base:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(99, 34);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(17, 13);
            this.label13.TabIndex = 4;
            this.label13.Text = "Y:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(10, 34);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(17, 13);
            this.label14.TabIndex = 3;
            this.label14.Text = "X:";
            // 
            // textBoxShowPowerImagine
            // 
            this.textBoxShowPowerImagine.Location = new System.Drawing.Point(122, 30);
            this.textBoxShowPowerImagine.Name = "textBoxShowPowerImagine";
            this.textBoxShowPowerImagine.Size = new System.Drawing.Size(48, 20);
            this.textBoxShowPowerImagine.TabIndex = 1;
            this.textBoxShowPowerImagine.Text = "-2";
            // 
            // textBoxShowPowerReal
            // 
            this.textBoxShowPowerReal.Location = new System.Drawing.Point(33, 30);
            this.textBoxShowPowerReal.Name = "textBoxShowPowerReal";
            this.textBoxShowPowerReal.Size = new System.Drawing.Size(48, 20);
            this.textBoxShowPowerReal.TabIndex = 0;
            this.textBoxShowPowerReal.Text = "-0.5";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 417);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(133, 39);
            this.button1.TabIndex = 15;
            this.button1.Text = "Animation";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.ButtonAnimation_Click);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.label17);
            this.groupBox7.Controls.Add(this.label18);
            this.groupBox7.Controls.Add(this.textBoxCompareY2);
            this.groupBox7.Controls.Add(this.textBoxCompareX2);
            this.groupBox7.Controls.Add(this.buttonCompareTwocurves);
            this.groupBox7.Controls.Add(this.label15);
            this.groupBox7.Controls.Add(this.label16);
            this.groupBox7.Controls.Add(this.textBoxCompareY1);
            this.groupBox7.Controls.Add(this.textBoxCompareX1);
            this.groupBox7.Location = new System.Drawing.Point(567, 475);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(378, 112);
            this.groupBox7.TabIndex = 16;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Compare two series";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(99, 71);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(23, 13);
            this.label17.TabIndex = 9;
            this.label17.Text = "Y2:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(10, 71);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(23, 13);
            this.label18.TabIndex = 8;
            this.label18.Text = "X1:";
            // 
            // textBoxCompareY2
            // 
            this.textBoxCompareY2.Location = new System.Drawing.Point(122, 67);
            this.textBoxCompareY2.Name = "textBoxCompareY2";
            this.textBoxCompareY2.Size = new System.Drawing.Size(48, 20);
            this.textBoxCompareY2.TabIndex = 7;
            this.textBoxCompareY2.Text = "-3";
            // 
            // textBoxCompareX2
            // 
            this.textBoxCompareX2.Location = new System.Drawing.Point(33, 67);
            this.textBoxCompareX2.Name = "textBoxCompareX2";
            this.textBoxCompareX2.Size = new System.Drawing.Size(48, 20);
            this.textBoxCompareX2.TabIndex = 6;
            this.textBoxCompareX2.Text = "-0.5";
            // 
            // buttonCompareTwocurves
            // 
            this.buttonCompareTwocurves.Location = new System.Drawing.Point(204, 34);
            this.buttonCompareTwocurves.Name = "buttonCompareTwocurves";
            this.buttonCompareTwocurves.Size = new System.Drawing.Size(124, 29);
            this.buttonCompareTwocurves.TabIndex = 5;
            this.buttonCompareTwocurves.Text = "ShowCalculationDetails";
            this.buttonCompareTwocurves.UseVisualStyleBackColor = true;
            this.buttonCompareTwocurves.Click += new System.EventHandler(this.buttonCompareTwocurves_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(99, 34);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(23, 13);
            this.label15.TabIndex = 4;
            this.label15.Text = "Y1:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(10, 34);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(23, 13);
            this.label16.TabIndex = 3;
            this.label16.Text = "X1:";
            // 
            // textBoxCompareY1
            // 
            this.textBoxCompareY1.Location = new System.Drawing.Point(122, 30);
            this.textBoxCompareY1.Name = "textBoxCompareY1";
            this.textBoxCompareY1.Size = new System.Drawing.Size(48, 20);
            this.textBoxCompareY1.TabIndex = 1;
            this.textBoxCompareY1.Text = "-2";
            // 
            // textBoxCompareX1
            // 
            this.textBoxCompareX1.Location = new System.Drawing.Point(33, 30);
            this.textBoxCompareX1.Name = "textBoxCompareX1";
            this.textBoxCompareX1.Size = new System.Drawing.Size(48, 20);
            this.textBoxCompareX1.TabIndex = 0;
            this.textBoxCompareX1.Text = "-0.5";
            // 
            // buttonMultiplyComplex
            // 
            this.buttonMultiplyComplex.Location = new System.Drawing.Point(374, 417);
            this.buttonMultiplyComplex.Name = "buttonMultiplyComplex";
            this.buttonMultiplyComplex.Size = new System.Drawing.Size(133, 39);
            this.buttonMultiplyComplex.TabIndex = 17;
            this.buttonMultiplyComplex.Text = "AnimationRotate";
            this.buttonMultiplyComplex.UseVisualStyleBackColor = true;
            this.buttonMultiplyComplex.Click += new System.EventHandler(this.buttonMultiplyComplex_Click);
            // 
            // buttonChangeA
            // 
            this.buttonChangeA.Location = new System.Drawing.Point(193, 417);
            this.buttonChangeA.Name = "buttonChangeA";
            this.buttonChangeA.Size = new System.Drawing.Size(133, 39);
            this.buttonChangeA.TabIndex = 18;
            this.buttonChangeA.Text = "AnimationChangeA";
            this.buttonChangeA.UseVisualStyleBackColor = true;
            this.buttonChangeA.Click += new System.EventHandler(this.buttonChangeA_Click);
            // 
            // buttonAnimationBall
            // 
            this.buttonAnimationBall.Location = new System.Drawing.Point(13, 475);
            this.buttonAnimationBall.Name = "buttonAnimationBall";
            this.buttonAnimationBall.Size = new System.Drawing.Size(149, 42);
            this.buttonAnimationBall.TabIndex = 19;
            this.buttonAnimationBall.Text = "AnimationDisplayBall";
            this.buttonAnimationBall.UseVisualStyleBackColor = true;
            this.buttonAnimationBall.Click += new System.EventHandler(this.buttonAnimationBall_Click);
            // 
            // buttonBallRotate
            // 
            this.buttonBallRotate.Location = new System.Drawing.Point(197, 475);
            this.buttonBallRotate.Name = "buttonBallRotate";
            this.buttonBallRotate.Size = new System.Drawing.Size(129, 40);
            this.buttonBallRotate.TabIndex = 20;
            this.buttonBallRotate.Text = "Ball rotate";
            this.buttonBallRotate.UseVisualStyleBackColor = true;
            this.buttonBallRotate.Click += new System.EventHandler(this.buttonBallRotate_Click);
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.buttonShowSumBySkipping);
            this.groupBox8.Controls.Add(this.label19);
            this.groupBox8.Controls.Add(this.textBoxBaseInSkip);
            this.groupBox8.Location = new System.Drawing.Point(883, 12);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(313, 90);
            this.groupBox8.TabIndex = 21;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Sum by skipping some items";
            // 
            // buttonShowSumBySkipping
            // 
            this.buttonShowSumBySkipping.Location = new System.Drawing.Point(162, 34);
            this.buttonShowSumBySkipping.Name = "buttonShowSumBySkipping";
            this.buttonShowSumBySkipping.Size = new System.Drawing.Size(126, 23);
            this.buttonShowSumBySkipping.TabIndex = 5;
            this.buttonShowSumBySkipping.Text = "ShowCalculationDetails";
            this.buttonShowSumBySkipping.UseVisualStyleBackColor = true;
            this.buttonShowSumBySkipping.Click += new System.EventHandler(this.buttonShowSumBySkipping_Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(22, 38);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(17, 13);
            this.label19.TabIndex = 4;
            this.label19.Text = "Y:";
            // 
            // textBoxBaseInSkip
            // 
            this.textBoxBaseInSkip.Location = new System.Drawing.Point(45, 34);
            this.textBoxBaseInSkip.Name = "textBoxBaseInSkip";
            this.textBoxBaseInSkip.Size = new System.Drawing.Size(48, 20);
            this.textBoxBaseInSkip.TabIndex = 1;
            this.textBoxBaseInSkip.Text = "2";
            // 
            // buttonPlotSum
            // 
            this.buttonPlotSum.Location = new System.Drawing.Point(914, 148);
            this.buttonPlotSum.Name = "buttonPlotSum";
            this.buttonPlotSum.Size = new System.Drawing.Size(131, 41);
            this.buttonPlotSum.TabIndex = 22;
            this.buttonPlotSum.Text = "Plot Sum";
            this.buttonPlotSum.UseVisualStyleBackColor = true;
            this.buttonPlotSum.Click += new System.EventHandler(this.buttonPlotSum_Click);
            // 
            // buttonBallCompare
            // 
            this.buttonBallCompare.Location = new System.Drawing.Point(374, 475);
            this.buttonBallCompare.Name = "buttonBallCompare";
            this.buttonBallCompare.Size = new System.Drawing.Size(129, 40);
            this.buttonBallCompare.TabIndex = 23;
            this.buttonBallCompare.Text = "Ball Compare";
            this.buttonBallCompare.UseVisualStyleBackColor = true;
            this.buttonBallCompare.Click += new System.EventHandler(this.buttonBallCompare_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1214, 635);
            this.Controls.Add(this.buttonBallCompare);
            this.Controls.Add(this.buttonPlotSum);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.buttonBallRotate);
            this.Controls.Add(this.buttonAnimationBall);
            this.Controls.Add(this.buttonChangeA);
            this.Controls.Add(this.buttonMultiplyComplex);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.checkBoxUseOriginal);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBoxX;
        private System.Windows.Forms.Button buttonShowX;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBoxY;
        private System.Windows.Forms.Button buttonShowY;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonOnePoint;
        private System.Windows.Forms.TextBox textBoxOnePointY;
        private System.Windows.Forms.TextBox textBoxOnePointX;
        private System.Windows.Forms.TextBox textBoxYMax;
        private System.Windows.Forms.TextBox textBoxYMin;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxXMax;
        private System.Windows.Forms.TextBox textBoxXMin;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox checkBoxUseOriginal;
        private System.Windows.Forms.Button buttonShowCalculationDetails;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox textBoxBase;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button buttonShowSimpleExponent;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxExponent_Y;
        private System.Windows.Forms.TextBox textBoxExponent_X;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button buttonOnePair;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBoxOnePairY;
        private System.Windows.Forms.TextBox textBoxOnePairX;
        private System.Windows.Forms.CheckBox checkBoxShowDetails;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox textBoxShowPowerBase;
        private System.Windows.Forms.Button buttonShowComplexPower;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textBoxShowPowerImagine;
        private System.Windows.Forms.TextBox textBoxShowPowerReal;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox textBoxCompareY2;
        private System.Windows.Forms.TextBox textBoxCompareX2;
        private System.Windows.Forms.Button buttonCompareTwocurves;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox textBoxCompareY1;
        private System.Windows.Forms.TextBox textBoxCompareX1;
        private System.Windows.Forms.Button buttonMultiplyComplex;
        private System.Windows.Forms.Button buttonChangeA;
        private System.Windows.Forms.Button buttonAnimationBall;
        private System.Windows.Forms.Button buttonBallRotate;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Button buttonShowSumBySkipping;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox textBoxBaseInSkip;
        private System.Windows.Forms.Button buttonPlotSum;
        private System.Windows.Forms.Button buttonBallCompare;
    }
}

