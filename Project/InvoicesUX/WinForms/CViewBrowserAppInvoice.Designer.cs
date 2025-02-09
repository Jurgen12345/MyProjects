namespace Invoices.UX.WinForms
{
    partial class CViewBrowserAppInvoice
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
            lstBrowser = new ListBox();
            lblSearch = new Label();
            txtSearch = new TextBox();
            btnFind = new Button();
            SuspendLayout();
            // 
            // lstBrowser
            // 
            lstBrowser.FormattingEnabled = true;
            lstBrowser.ItemHeight = 15;
            lstBrowser.Location = new Point(12, 67);
            lstBrowser.Name = "lstBrowser";
            lstBrowser.Size = new Size(776, 364);
            lstBrowser.TabIndex = 0;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Location = new Point(12, 23);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(59, 15);
            lblSearch.TabIndex = 1;
            lblSearch.Text = "Invoice ID";
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(111, 20);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(257, 23);
            txtSearch.TabIndex = 2;
            // 
            // btnFind
            // 
            btnFind.Location = new Point(374, 19);
            btnFind.Name = "btnFind";
            btnFind.Size = new Size(75, 23);
            btnFind.TabIndex = 3;
            btnFind.Text = "Search";
            btnFind.UseVisualStyleBackColor = true;
            // 
            // CViewBrowserAppInvoice
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnFind);
            Controls.Add(txtSearch);
            Controls.Add(lblSearch);
            Controls.Add(lstBrowser);
            Name = "CViewBrowserAppInvoice";
            Text = "CViewBrowserAppInvoice";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox lstBrowser;
        private Label lblSearch;
        private TextBox txtSearch;
        private Button btnFind;
    }
}