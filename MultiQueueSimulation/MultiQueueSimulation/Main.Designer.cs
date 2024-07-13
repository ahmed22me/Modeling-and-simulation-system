namespace MultiQueueSimulation
{
    partial class Main
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
            this.openTestCaseButton = new System.Windows.Forms.Button();
            this.testCaseFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.numberOfServersLabel = new System.Windows.Forms.Label();
            this.stoppingNumberLabel = new System.Windows.Forms.Label();
            this.stoppingCriteriaLabel = new System.Windows.Forms.Label();
            this.selectionMethodLabel = new System.Windows.Forms.Label();
            this.numberOfServersTextBox = new System.Windows.Forms.TextBox();
            this.stoppingNumberTextBox = new System.Windows.Forms.TextBox();
            this.stoppingCriteriaTextBox = new System.Windows.Forms.TextBox();
            this.selectionMethodTextBox = new System.Windows.Forms.TextBox();
            this.simulateButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // openTestCaseButton
            // 
            this.openTestCaseButton.BackColor = System.Drawing.Color.Tan;
            this.openTestCaseButton.Font = new System.Drawing.Font("Tahoma", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openTestCaseButton.Location = new System.Drawing.Point(12, 86);
            this.openTestCaseButton.Name = "openTestCaseButton";
            this.openTestCaseButton.Size = new System.Drawing.Size(699, 84);
            this.openTestCaseButton.TabIndex = 0;
            this.openTestCaseButton.Text = "Open Test Case";
            this.openTestCaseButton.UseVisualStyleBackColor = false;
            this.openTestCaseButton.Click += new System.EventHandler(this.openTestCaseButton_Click);
            // 
            // testCaseFileDialog
            // 
            this.testCaseFileDialog.ReadOnlyChecked = true;
            this.testCaseFileDialog.ShowReadOnly = true;
            // 
            // numberOfServersLabel
            // 
            this.numberOfServersLabel.AutoSize = true;
            this.numberOfServersLabel.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numberOfServersLabel.Location = new System.Drawing.Point(61, 217);
            this.numberOfServersLabel.Name = "numberOfServersLabel";
            this.numberOfServersLabel.Size = new System.Drawing.Size(152, 18);
            this.numberOfServersLabel.TabIndex = 1;
            this.numberOfServersLabel.Text = "Number Of Servers";
            this.numberOfServersLabel.Click += new System.EventHandler(this.numberOfServersLabel_Click);
            // 
            // stoppingNumberLabel
            // 
            this.stoppingNumberLabel.AutoSize = true;
            this.stoppingNumberLabel.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stoppingNumberLabel.Location = new System.Drawing.Point(61, 305);
            this.stoppingNumberLabel.Name = "stoppingNumberLabel";
            this.stoppingNumberLabel.Size = new System.Drawing.Size(137, 18);
            this.stoppingNumberLabel.TabIndex = 2;
            this.stoppingNumberLabel.Text = "Stopping Number";
            // 
            // stoppingCriteriaLabel
            // 
            this.stoppingCriteriaLabel.AutoSize = true;
            this.stoppingCriteriaLabel.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stoppingCriteriaLabel.Location = new System.Drawing.Point(231, 217);
            this.stoppingCriteriaLabel.Name = "stoppingCriteriaLabel";
            this.stoppingCriteriaLabel.Size = new System.Drawing.Size(136, 18);
            this.stoppingCriteriaLabel.TabIndex = 3;
            this.stoppingCriteriaLabel.Text = "Stopping Criteria";
            // 
            // selectionMethodLabel
            // 
            this.selectionMethodLabel.AutoSize = true;
            this.selectionMethodLabel.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.selectionMethodLabel.Location = new System.Drawing.Point(231, 305);
            this.selectionMethodLabel.Name = "selectionMethodLabel";
            this.selectionMethodLabel.Size = new System.Drawing.Size(137, 18);
            this.selectionMethodLabel.TabIndex = 4;
            this.selectionMethodLabel.Text = "Selection Method";
            // 
            // numberOfServersTextBox
            // 
            this.numberOfServersTextBox.Location = new System.Drawing.Point(57, 250);
            this.numberOfServersTextBox.Name = "numberOfServersTextBox";
            this.numberOfServersTextBox.ReadOnly = true;
            this.numberOfServersTextBox.Size = new System.Drawing.Size(156, 20);
            this.numberOfServersTextBox.TabIndex = 5;
            // 
            // stoppingNumberTextBox
            // 
            this.stoppingNumberTextBox.Location = new System.Drawing.Point(57, 332);
            this.stoppingNumberTextBox.Name = "stoppingNumberTextBox";
            this.stoppingNumberTextBox.ReadOnly = true;
            this.stoppingNumberTextBox.Size = new System.Drawing.Size(156, 20);
            this.stoppingNumberTextBox.TabIndex = 6;
            // 
            // stoppingCriteriaTextBox
            // 
            this.stoppingCriteriaTextBox.Location = new System.Drawing.Point(234, 250);
            this.stoppingCriteriaTextBox.Name = "stoppingCriteriaTextBox";
            this.stoppingCriteriaTextBox.ReadOnly = true;
            this.stoppingCriteriaTextBox.Size = new System.Drawing.Size(133, 20);
            this.stoppingCriteriaTextBox.TabIndex = 7;
            // 
            // selectionMethodTextBox
            // 
            this.selectionMethodTextBox.Location = new System.Drawing.Point(234, 332);
            this.selectionMethodTextBox.Name = "selectionMethodTextBox";
            this.selectionMethodTextBox.ReadOnly = true;
            this.selectionMethodTextBox.Size = new System.Drawing.Size(133, 20);
            this.selectionMethodTextBox.TabIndex = 8;
            // 
            // simulateButton
            // 
            this.simulateButton.BackColor = System.Drawing.Color.Tan;
            this.simulateButton.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.simulateButton.Location = new System.Drawing.Point(561, 305);
            this.simulateButton.Name = "simulateButton";
            this.simulateButton.Size = new System.Drawing.Size(129, 47);
            this.simulateButton.TabIndex = 15;
            this.simulateButton.Text = "Run";
            this.simulateButton.UseVisualStyleBackColor = false;
            this.simulateButton.Click += new System.EventHandler(this.simulateButton_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 30F);
            this.label1.Location = new System.Drawing.Point(129, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(542, 54);
            this.label1.TabIndex = 16;
            this.label1.Text = "Multiple queue system";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Snow;
            this.ClientSize = new System.Drawing.Size(731, 397);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.simulateButton);
            this.Controls.Add(this.selectionMethodTextBox);
            this.Controls.Add(this.stoppingCriteriaTextBox);
            this.Controls.Add(this.stoppingNumberTextBox);
            this.Controls.Add(this.numberOfServersTextBox);
            this.Controls.Add(this.selectionMethodLabel);
            this.Controls.Add(this.stoppingCriteriaLabel);
            this.Controls.Add(this.stoppingNumberLabel);
            this.Controls.Add(this.numberOfServersLabel);
            this.Controls.Add(this.openTestCaseButton);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Main";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button openTestCaseButton;
        private System.Windows.Forms.OpenFileDialog testCaseFileDialog;
        private System.Windows.Forms.Label numberOfServersLabel;
        private System.Windows.Forms.Label stoppingNumberLabel;
        private System.Windows.Forms.Label stoppingCriteriaLabel;
        private System.Windows.Forms.Label selectionMethodLabel;
        private System.Windows.Forms.TextBox numberOfServersTextBox;
        private System.Windows.Forms.TextBox stoppingNumberTextBox;
        private System.Windows.Forms.TextBox stoppingCriteriaTextBox;
        private System.Windows.Forms.TextBox selectionMethodTextBox;
        private System.Windows.Forms.Button simulateButton;
        private System.Windows.Forms.Label label1;
    }
}

