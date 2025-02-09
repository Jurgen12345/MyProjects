namespace Invoices.UX.WinForms
{
    partial class CFormTableCustomer
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
            gridRecords = new DataGridView();
            btnLoadTabel = new Button();
            btnSaveTable = new Button();
            btnCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)gridRecords).BeginInit();
            SuspendLayout();
            // 
            // gridRecords
            // 
            gridRecords.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridRecords.Location = new Point(12, 12);
            gridRecords.Name = "gridRecords";
            gridRecords.RowTemplate.Height = 25;
            gridRecords.Size = new Size(651, 378);
            gridRecords.TabIndex = 0;
            // 
            // btnLoadTabel
            // 
            btnLoadTabel.Location = new Point(12, 396);
            btnLoadTabel.Name = "btnLoadTabel";
            btnLoadTabel.Size = new Size(128, 48);
            btnLoadTabel.TabIndex = 1;
            btnLoadTabel.Text = "Load";
            btnLoadTabel.UseVisualStyleBackColor = true;
            // 
            // btnSaveTable
            // 
            btnSaveTable.Location = new Point(224, 396);
            btnSaveTable.Name = "btnSaveTable";
            btnSaveTable.Size = new Size(128, 48);
            btnSaveTable.TabIndex = 2;
            btnSaveTable.Text = "Save";
            btnSaveTable.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(358, 396);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(128, 48);
            btnCancel.TabIndex = 3;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // CFormTableCustomer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnCancel);
            Controls.Add(btnSaveTable);
            Controls.Add(btnLoadTabel);
            Controls.Add(gridRecords);
            Name = "CFormTableCustomer";
            Text = "CFormTableCustomer";
            ((System.ComponentModel.ISupportInitialize)gridRecords).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView gridRecords;
        private Button btnLoadTabel;
        private Button btnSaveTable;
        private Button btnCancel;
    }
}