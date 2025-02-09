namespace Scale.UX
{
    partial class CMinimizingForm
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
            pbInfoLogo = new PictureBox();
            button1 = new Button();
            button2 = new Button();
            lblMinimize = new Label();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)pbInfoLogo).BeginInit();
            SuspendLayout();
            // 
            // pbInfoLogo
            // 
            pbInfoLogo.Location = new Point(29, 12);
            pbInfoLogo.Name = "pbInfoLogo";
            pbInfoLogo.Size = new Size(134, 125);
            pbInfoLogo.SizeMode = PictureBoxSizeMode.AutoSize;
            pbInfoLogo.TabIndex = 0;
            pbInfoLogo.TabStop = false;
            // 
            // button1
            // 
            button1.Location = new Point(200, 95);
            button1.Name = "button1";
            button1.Size = new Size(94, 42);
            button1.TabIndex = 1;
            button1.Text = "Po";
            button1.UseVisualStyleBackColor = true;
            button1.Click += onMinimizeButtonClick;
            // 
            // button2
            // 
            button2.Location = new Point(386, 95);
            button2.Name = "button2";
            button2.Size = new Size(94, 42);
            button2.TabIndex = 2;
            button2.Text = "Jo";
            button2.UseVisualStyleBackColor = true;
            button2.Click += onExitButtonClick;
            // 
            // lblMinimize
            // 
            lblMinimize.AutoSize = true;
            lblMinimize.Location = new Point(200, 12);
            lblMinimize.Name = "lblMinimize";
            lblMinimize.Size = new Size(251, 20);
            lblMinimize.TabIndex = 3;
            lblMinimize.Text = "Deshironi te minimizoni aplikacionin";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(200, 32);
            label1.Name = "label1";
            label1.Size = new Size(209, 20);
            label1.TabIndex = 4;
            label1.Text = "qe te qendroj ne background?";
            // 
            // CMinimizingForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(514, 149);
            Controls.Add(label1);
            Controls.Add(lblMinimize);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(pbInfoLogo);
            Name = "CMinimizingForm";
            Text = "CMinimizingForm";
            ((System.ComponentModel.ISupportInitialize)pbInfoLogo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pbInfoLogo;
        private Button button1;
        private Button button2;
        private Label lblMinimize;
        private Label label1;
    }
}