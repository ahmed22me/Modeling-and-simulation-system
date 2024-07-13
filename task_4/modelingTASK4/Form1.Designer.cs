namespace modelingTASK4
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.seedTextBox = new System.Windows.Forms.TextBox();
            this.multiplierTextBox = new System.Windows.Forms.TextBox();
            this.incrementTextBox = new System.Windows.Forms.TextBox();
            this.modulusTextBox = new System.Windows.Forms.TextBox();
            this.numberOfIterationsTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.seedLabel = new System.Windows.Forms.Label();
            this.multiplierLabel = new System.Windows.Forms.Label();
            this.incrementLabel = new System.Windows.Forms.Label();
            this.modulusLabel = new System.Windows.Forms.Label();
            this.numberOfIterationsLabel = new System.Windows.Forms.Label();
            this.cycleLengthLabel = new System.Windows.Forms.Label();
            this.cycleLengthTextBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.randomNumbersTable = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.randomNumbersTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // seedTextBox
            // 
            this.seedTextBox.Location = new System.Drawing.Point(267, 123);
            this.seedTextBox.Name = "seedTextBox";
            this.seedTextBox.Size = new System.Drawing.Size(125, 27);
            this.seedTextBox.TabIndex = 0;
            // 
            // multiplierTextBox
            // 
            this.multiplierTextBox.Location = new System.Drawing.Point(267, 174);
            this.multiplierTextBox.Name = "multiplierTextBox";
            this.multiplierTextBox.Size = new System.Drawing.Size(125, 27);
            this.multiplierTextBox.TabIndex = 1;
            // 
            // incrementTextBox
            // 
            this.incrementTextBox.Location = new System.Drawing.Point(267, 228);
            this.incrementTextBox.Name = "incrementTextBox";
            this.incrementTextBox.Size = new System.Drawing.Size(125, 27);
            this.incrementTextBox.TabIndex = 2;
            // 
            // modulusTextBox
            // 
            this.modulusTextBox.Location = new System.Drawing.Point(267, 285);
            this.modulusTextBox.Name = "modulusTextBox";
            this.modulusTextBox.Size = new System.Drawing.Size(125, 27);
            this.modulusTextBox.TabIndex = 3;
            // 
            // numberOfIterationsTextBox
            // 
            this.numberOfIterationsTextBox.Location = new System.Drawing.Point(267, 342);
            this.numberOfIterationsTextBox.Name = "numberOfIterationsTextBox";
            this.numberOfIterationsTextBox.Size = new System.Drawing.Size(125, 27);
            this.numberOfIterationsTextBox.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Sitka Heading", 19.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(399, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(263, 48);
            this.label1.TabIndex = 5;
            this.label1.Text = "Random Number";
            // 
            // seedLabel
            // 
            this.seedLabel.AutoSize = true;
            this.seedLabel.Font = new System.Drawing.Font("Sitka Display", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.seedLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.seedLabel.Location = new System.Drawing.Point(28, 112);
            this.seedLabel.Name = "seedLabel";
            this.seedLabel.Size = new System.Drawing.Size(69, 40);
            this.seedLabel.TabIndex = 6;
            this.seedLabel.Text = "Seed";
            // 
            // multiplierLabel
            // 
            this.multiplierLabel.AutoSize = true;
            this.multiplierLabel.Font = new System.Drawing.Font("Sitka Display", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.multiplierLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.multiplierLabel.Location = new System.Drawing.Point(28, 165);
            this.multiplierLabel.Name = "multiplierLabel";
            this.multiplierLabel.Size = new System.Drawing.Size(127, 40);
            this.multiplierLabel.TabIndex = 7;
            this.multiplierLabel.Text = "Multiplier";
            // 
            // incrementLabel
            // 
            this.incrementLabel.AutoSize = true;
            this.incrementLabel.Font = new System.Drawing.Font("Sitka Display", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.incrementLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.incrementLabel.Location = new System.Drawing.Point(28, 220);
            this.incrementLabel.Name = "incrementLabel";
            this.incrementLabel.Size = new System.Drawing.Size(132, 40);
            this.incrementLabel.TabIndex = 8;
            this.incrementLabel.Text = "Increment";
            // 
            // modulusLabel
            // 
            this.modulusLabel.AutoSize = true;
            this.modulusLabel.Font = new System.Drawing.Font("Sitka Display", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.modulusLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.modulusLabel.Location = new System.Drawing.Point(28, 274);
            this.modulusLabel.Name = "modulusLabel";
            this.modulusLabel.Size = new System.Drawing.Size(112, 40);
            this.modulusLabel.TabIndex = 9;
            this.modulusLabel.Text = "Modulus";
            // 
            // numberOfIterationsLabel
            // 
            this.numberOfIterationsLabel.AutoSize = true;
            this.numberOfIterationsLabel.Font = new System.Drawing.Font("Sitka Display", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numberOfIterationsLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.numberOfIterationsLabel.Location = new System.Drawing.Point(28, 330);
            this.numberOfIterationsLabel.Name = "numberOfIterationsLabel";
            this.numberOfIterationsLabel.Size = new System.Drawing.Size(223, 40);
            this.numberOfIterationsLabel.TabIndex = 10;
            this.numberOfIterationsLabel.Text = "Iterations Number";
            // 
            // cycleLengthLabel
            // 
            this.cycleLengthLabel.AutoSize = true;
            this.cycleLengthLabel.Font = new System.Drawing.Font("Sitka Display", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cycleLengthLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.cycleLengthLabel.Location = new System.Drawing.Point(337, 530);
            this.cycleLengthLabel.Name = "cycleLengthLabel";
            this.cycleLengthLabel.Size = new System.Drawing.Size(173, 40);
            this.cycleLengthLabel.TabIndex = 11;
            this.cycleLengthLabel.Text = "Period Length";
            // 
            // cycleLengthTextBox
            // 
            this.cycleLengthTextBox.Location = new System.Drawing.Point(576, 542);
            this.cycleLengthTextBox.Name = "cycleLengthTextBox";
            this.cycleLengthTextBox.Size = new System.Drawing.Size(125, 27);
            this.cycleLengthTextBox.TabIndex = 12;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.GhostWhite;
            this.button1.Font = new System.Drawing.Font("Sitka Banner", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(398, 428);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(275, 62);
            this.button1.TabIndex = 13;
            this.button1.Text = "Generate Random Number";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // randomNumbersTable
            // 
            this.randomNumbersTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.randomNumbersTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
            this.randomNumbersTable.Location = new System.Drawing.Point(804, 123);
            this.randomNumbersTable.Name = "randomNumbersTable";
            this.randomNumbersTable.RowHeadersWidth = 51;
            this.randomNumbersTable.RowTemplate.Height = 29;
            this.randomNumbersTable.Size = new System.Drawing.Size(177, 308);
            this.randomNumbersTable.TabIndex = 14;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Random Number";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.Width = 125;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::modelingTASK4.Properties.Resources.Real_estate_in_metaverse___Idea_Usher;
            this.pictureBox1.Location = new System.Drawing.Point(924, 464);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(105, 157);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.ClientSize = new System.Drawing.Size(1041, 633);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.randomNumbersTable);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cycleLengthTextBox);
            this.Controls.Add(this.cycleLengthLabel);
            this.Controls.Add(this.numberOfIterationsLabel);
            this.Controls.Add(this.modulusLabel);
            this.Controls.Add(this.incrementLabel);
            this.Controls.Add(this.multiplierLabel);
            this.Controls.Add(this.seedLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numberOfIterationsTextBox);
            this.Controls.Add(this.modulusTextBox);
            this.Controls.Add(this.incrementTextBox);
            this.Controls.Add(this.multiplierTextBox);
            this.Controls.Add(this.seedTextBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.randomNumbersTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox seedTextBox;
        private TextBox multiplierTextBox;
        private TextBox incrementTextBox;
        private TextBox modulusTextBox;
        private TextBox numberOfIterationsTextBox;
        private Label label1;
        private Label seedLabel;
        private Label multiplierLabel;
        private Label incrementLabel;
        private Label modulusLabel;
        private Label numberOfIterationsLabel;
        private Label cycleLengthLabel;
        private TextBox cycleLengthTextBox;
        private Button button1;
        private DataGridView randomNumbersTable;
        private DataGridViewTextBoxColumn Column1;
        private PictureBox pictureBox1;
    }
}