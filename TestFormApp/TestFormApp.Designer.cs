namespace TestFormApp
{
    partial class TestFormApp
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
            clickMeBtn = new Button();
            displayLabel = new Label();
            testLabelCount = new Label();
            SuspendLayout();
            // 
            // clickMeBtn
            // 
            clickMeBtn.Location = new Point(677, 392);
            clickMeBtn.Name = "clickMeBtn";
            clickMeBtn.Size = new Size(94, 29);
            clickMeBtn.TabIndex = 0;
            clickMeBtn.Text = "Show Label";
            clickMeBtn.UseVisualStyleBackColor = true;
            clickMeBtn.Click += clickMeBtn_Click;
            // 
            // displayLabel
            // 
            displayLabel.AutoSize = true;
            displayLabel.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            displayLabel.Location = new Point(296, 189);
            displayLabel.Name = "displayLabel";
            displayLabel.Size = new Size(218, 41);
            displayLabel.TabIndex = 1;
            displayLabel.Text = "You clicked it!!!";
            displayLabel.Visible = false;
            // 
            // testLabelCount
            // 
            testLabelCount.AutoSize = true;
            testLabelCount.Location = new Point(692, 9);
            testLabelCount.Name = "testLabelCount";
            testLabelCount.Size = new Size(96, 20);
            testLabelCount.TabIndex = 2;
            testLabelCount.Text = "Test Labels: 0";
            // 
            // TestFormApp
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(testLabelCount);
            Controls.Add(displayLabel);
            Controls.Add(clickMeBtn);
            Name = "TestFormApp";
            Text = "TestFormApp";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button clickMeBtn;
        private Label displayLabel;
        private Label testLabelCount;
    }
}