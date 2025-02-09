namespace LabelTransfer
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
            pbLogo = new PictureBox();
            tbUserLicense = new TextBox();
            lblEnterLicenseKey = new Label();
            btnValidate = new Button();
            ((System.ComponentModel.ISupportInitialize)pbLogo).BeginInit();
            SuspendLayout();
            // 
            // pbLogo
            // 
            pbLogo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pbLogo.Location = new Point(182, 12);
            pbLogo.Name = "pbLogo";
            pbLogo.Size = new Size(220, 80);
            pbLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            pbLogo.TabIndex = 0;
            pbLogo.TabStop = false;
            // 
            // tbUserLicense
            // 
            tbUserLicense.Location = new Point(148, 191);
            tbUserLicense.Name = "tbUserLicense";
            tbUserLicense.Size = new Size(294, 23);
            tbUserLicense.TabIndex = 1;
            // 
            // lblEnterLicenseKey
            // 
            lblEnterLicenseKey.AutoSize = true;
            lblEnterLicenseKey.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblEnterLicenseKey.Location = new Point(199, 154);
            lblEnterLicenseKey.Name = "lblEnterLicenseKey";
            lblEnterLicenseKey.Size = new Size(192, 20);
            lblEnterLicenseKey.TabIndex = 2;
            lblEnterLicenseKey.Text = "Vendos Numrin e Licenses";
            // 
            // btnValidate
            // 
            btnValidate.Location = new Point(244, 241);
            btnValidate.Name = "btnValidate";
            btnValidate.Size = new Size(101, 54);
            btnValidate.TabIndex = 3;
            btnValidate.Text = "Vazhdo";
            btnValidate.UseVisualStyleBackColor = true;
            btnValidate.Click += onValidate;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(584, 361);
            Controls.Add(btnValidate);
            Controls.Add(lblEnterLicenseKey);
            Controls.Add(tbUserLicense);
            Controls.Add(pbLogo);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pbLogo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pbLogo;
        private TextBox tbUserLicense;
        private Label lblEnterLicenseKey;
        private Button btnValidate;
    }
}
