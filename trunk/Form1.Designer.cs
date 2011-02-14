namespace SpykeeWifiPositionFancy
{
    partial class Form1
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
            this.openFD = new System.Windows.Forms.OpenFileDialog();
            this.loadXML = new System.Windows.Forms.Button();
            this.saveFD = new System.Windows.Forms.SaveFileDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelYPos = new System.Windows.Forms.Label();
            this.labelXPos = new System.Windows.Forms.Label();
            this.buttonFindPosition = new System.Windows.Forms.Button();
            this.labelSectors = new System.Windows.Forms.Label();
            this.labelAps = new System.Windows.Forms.Label();
            this.labelMapName = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBoxFindCount = new System.Windows.Forms.TextBox();
            this.textBoxMapCreationCount = new System.Windows.Forms.TextBox();
            this.textBoxMinRange = new System.Windows.Forms.TextBox();
            this.textBoxScanPause = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxStandardFluctuation = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.checkBoxStandardFluctuation = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBoxSaveY = new System.Windows.Forms.TextBox();
            this.textBoxSaveX = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.labelSectorNumber = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.buttonMeasure = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFD
            // 
            this.openFD.FileName = "openFileDialog1";
            // 
            // loadXML
            // 
            this.loadXML.Location = new System.Drawing.Point(217, 126);
            this.loadXML.Name = "loadXML";
            this.loadXML.Size = new System.Drawing.Size(75, 23);
            this.loadXML.TabIndex = 0;
            this.loadXML.Text = "Load Map";
            this.loadXML.UseVisualStyleBackColor = true;
            this.loadXML.Click += new System.EventHandler(this.loadXML_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelYPos);
            this.groupBox1.Controls.Add(this.labelXPos);
            this.groupBox1.Controls.Add(this.buttonFindPosition);
            this.groupBox1.Controls.Add(this.labelSectors);
            this.groupBox1.Controls.Add(this.labelAps);
            this.groupBox1.Controls.Add(this.labelMapName);
            this.groupBox1.Controls.Add(this.loadXML);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(309, 162);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Find Position";
            // 
            // labelYPos
            // 
            this.labelYPos.AutoSize = true;
            this.labelYPos.Location = new System.Drawing.Point(54, 51);
            this.labelYPos.Name = "labelYPos";
            this.labelYPos.Size = new System.Drawing.Size(27, 13);
            this.labelYPos.TabIndex = 13;
            this.labelYPos.Text = "N/A";
            // 
            // labelXPos
            // 
            this.labelXPos.AutoSize = true;
            this.labelXPos.Location = new System.Drawing.Point(54, 29);
            this.labelXPos.Name = "labelXPos";
            this.labelXPos.Size = new System.Drawing.Size(27, 13);
            this.labelXPos.TabIndex = 12;
            this.labelXPos.Text = "N/A";
            // 
            // buttonFindPosition
            // 
            this.buttonFindPosition.Location = new System.Drawing.Point(9, 125);
            this.buttonFindPosition.Name = "buttonFindPosition";
            this.buttonFindPosition.Size = new System.Drawing.Size(75, 23);
            this.buttonFindPosition.TabIndex = 11;
            this.buttonFindPosition.Text = "Find Position";
            this.buttonFindPosition.UseVisualStyleBackColor = true;
            this.buttonFindPosition.Click += new System.EventHandler(this.buttonFindPosition_Click);
            // 
            // labelSectors
            // 
            this.labelSectors.AutoSize = true;
            this.labelSectors.Location = new System.Drawing.Point(217, 55);
            this.labelSectors.Name = "labelSectors";
            this.labelSectors.Size = new System.Drawing.Size(27, 13);
            this.labelSectors.TabIndex = 10;
            this.labelSectors.Text = "N/A";
            // 
            // labelAps
            // 
            this.labelAps.AutoSize = true;
            this.labelAps.Location = new System.Drawing.Point(217, 29);
            this.labelAps.Name = "labelAps";
            this.labelAps.Size = new System.Drawing.Size(27, 13);
            this.labelAps.TabIndex = 9;
            this.labelAps.Text = "N/A";
            // 
            // labelMapName
            // 
            this.labelMapName.AutoSize = true;
            this.labelMapName.Location = new System.Drawing.Point(54, 101);
            this.labelMapName.Name = "labelMapName";
            this.labelMapName.Size = new System.Drawing.Size(27, 13);
            this.labelMapName.TabIndex = 8;
            this.labelMapName.Text = "N/A";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(129, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Sectors:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(129, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Access Points:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Map:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Y =";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "X =";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBoxFindCount);
            this.groupBox2.Controls.Add(this.textBoxMapCreationCount);
            this.groupBox2.Controls.Add(this.textBoxMinRange);
            this.groupBox2.Controls.Add(this.textBoxScanPause);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.textBoxStandardFluctuation);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.checkBoxStandardFluctuation);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(337, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(309, 281);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Configuration";
            // 
            // textBoxFindCount
            // 
            this.textBoxFindCount.Location = new System.Drawing.Point(185, 95);
            this.textBoxFindCount.Name = "textBoxFindCount";
            this.textBoxFindCount.Size = new System.Drawing.Size(100, 20);
            this.textBoxFindCount.TabIndex = 10;
            // 
            // textBoxMapCreationCount
            // 
            this.textBoxMapCreationCount.Location = new System.Drawing.Point(185, 70);
            this.textBoxMapCreationCount.Name = "textBoxMapCreationCount";
            this.textBoxMapCreationCount.Size = new System.Drawing.Size(100, 20);
            this.textBoxMapCreationCount.TabIndex = 9;
            // 
            // textBoxMinRange
            // 
            this.textBoxMinRange.Location = new System.Drawing.Point(185, 47);
            this.textBoxMinRange.Name = "textBoxMinRange";
            this.textBoxMinRange.Size = new System.Drawing.Size(100, 20);
            this.textBoxMinRange.TabIndex = 8;
            // 
            // textBoxScanPause
            // 
            this.textBoxScanPause.Location = new System.Drawing.Point(185, 24);
            this.textBoxScanPause.Name = "textBoxScanPause";
            this.textBoxScanPause.Size = new System.Drawing.Size(100, 20);
            this.textBoxScanPause.TabIndex = 7;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(16, 98);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(153, 13);
            this.label10.TabIndex = 6;
            this.label10.Text = "Scan counter (finding position):";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 73);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(144, 13);
            this.label9.TabIndex = 5;
            this.label9.Text = "Scan counter (map creation):";
            // 
            // textBoxStandardFluctuation
            // 
            this.textBoxStandardFluctuation.Location = new System.Drawing.Point(236, 129);
            this.textBoxStandardFluctuation.Name = "textBoxStandardFluctuation";
            this.textBoxStandardFluctuation.Size = new System.Drawing.Size(49, 20);
            this.textBoxStandardFluctuation.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(167, 131);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "Fluctuation:";
            // 
            // checkBoxStandardFluctuation
            // 
            this.checkBoxStandardFluctuation.AutoSize = true;
            this.checkBoxStandardFluctuation.Location = new System.Drawing.Point(19, 131);
            this.checkBoxStandardFluctuation.Name = "checkBoxStandardFluctuation";
            this.checkBoxStandardFluctuation.Size = new System.Drawing.Size(124, 17);
            this.checkBoxStandardFluctuation.TabIndex = 2;
            this.checkBoxStandardFluctuation.Text = "Standard Fluctuation";
            this.checkBoxStandardFluctuation.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 50);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Min range (-dB):";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Scanpause (ms):";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBoxSaveY);
            this.groupBox3.Controls.Add(this.textBoxSaveX);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Controls.Add(this.labelSectorNumber);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.buttonMeasure);
            this.groupBox3.Location = new System.Drawing.Point(13, 181);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(309, 113);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Create Map";
            // 
            // textBoxSaveY
            // 
            this.textBoxSaveY.Location = new System.Drawing.Point(132, 52);
            this.textBoxSaveY.Name = "textBoxSaveY";
            this.textBoxSaveY.Size = new System.Drawing.Size(39, 20);
            this.textBoxSaveY.TabIndex = 16;
            // 
            // textBoxSaveX
            // 
            this.textBoxSaveX.Location = new System.Drawing.Point(44, 51);
            this.textBoxSaveX.Name = "textBoxSaveX";
            this.textBoxSaveX.Size = new System.Drawing.Size(40, 20);
            this.textBoxSaveX.TabIndex = 15;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(102, 54);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(23, 13);
            this.label14.TabIndex = 11;
            this.label14.Text = "Y =";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(15, 54);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(23, 13);
            this.label12.TabIndex = 11;
            this.label12.Text = "X =";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(217, 79);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 14;
            this.button1.Text = "Save Map";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // labelSectorNumber
            // 
            this.labelSectorNumber.AutoSize = true;
            this.labelSectorNumber.Location = new System.Drawing.Point(77, 26);
            this.labelSectorNumber.Name = "labelSectorNumber";
            this.labelSectorNumber.Size = new System.Drawing.Size(27, 13);
            this.labelSectorNumber.TabIndex = 11;
            this.labelSectorNumber.Text = "N/A";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(15, 26);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(46, 13);
            this.label11.TabIndex = 11;
            this.label11.Text = "Sectors:";
            // 
            // buttonMeasure
            // 
            this.buttonMeasure.Location = new System.Drawing.Point(9, 79);
            this.buttonMeasure.Name = "buttonMeasure";
            this.buttonMeasure.Size = new System.Drawing.Size(75, 23);
            this.buttonMeasure.TabIndex = 0;
            this.buttonMeasure.Text = "Measure";
            this.buttonMeasure.UseVisualStyleBackColor = true;
            this.buttonMeasure.Click += new System.EventHandler(this.buttonMeasure_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 306);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Spykee WLAN Positionierung";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFD;
        private System.Windows.Forms.Button loadXML;
        private System.Windows.Forms.SaveFileDialog saveFD;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelSectors;
        private System.Windows.Forms.Label labelAps;
        private System.Windows.Forms.Label labelMapName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox checkBoxStandardFluctuation;
        private System.Windows.Forms.TextBox textBoxStandardFluctuation;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textBoxFindCount;
        private System.Windows.Forms.TextBox textBoxMapCreationCount;
        private System.Windows.Forms.TextBox textBoxMinRange;
        private System.Windows.Forms.TextBox textBoxScanPause;
        private System.Windows.Forms.Button buttonMeasure;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label labelSectorNumber;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBoxSaveY;
        private System.Windows.Forms.TextBox textBoxSaveX;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button buttonFindPosition;
        private System.Windows.Forms.Label labelYPos;
        private System.Windows.Forms.Label labelXPos;
    }
}

