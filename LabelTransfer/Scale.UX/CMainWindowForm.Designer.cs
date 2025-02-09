namespace Scale.UX
{
    partial class CMainWindowForm
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
            dgvData = new DataGridView();
            IP = new DataGridViewTextBoxColumn();
            Status = new DataGridViewTextBoxColumn();
            btnScan = new Button();
            btnStop = new Button();
            btnAdd = new Button();
            label1 = new Label();
            pbLogo = new PictureBox();
            tbFileName = new TextBox();
            btnChoseFile = new Button();
            lblChoose = new Label();
            btnConnect = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvData).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbLogo).BeginInit();
            SuspendLayout();
            // 
            // dgvData
            // 
            dgvData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvData.Columns.AddRange(new DataGridViewColumn[] { IP, Status });
            dgvData.Location = new Point(0, 0);
            dgvData.Margin = new Padding(3, 4, 3, 4);
            dgvData.Name = "dgvData";
            dgvData.RowHeadersWidth = 51;
            dgvData.RowTemplate.Height = 25;
            dgvData.Size = new Size(286, 600);
            dgvData.TabIndex = 0;
            // 
            // IP
            // 
            IP.HeaderText = "Ip";
            IP.MinimumWidth = 6;
            IP.Name = "IP";
            IP.Width = 125;
            // 
            // Status
            // 
            Status.DataPropertyName = "0";
            Status.HeaderText = "Statusi";
            Status.MinimumWidth = 6;
            Status.Name = "Status";
            Status.ReadOnly = true;
            Status.Width = 125;
            // 
            // btnScan
            // 
            btnScan.Location = new Point(330, 461);
            btnScan.Margin = new Padding(3, 4, 3, 4);
            btnScan.Name = "btnScan";
            btnScan.Size = new Size(115, 92);
            btnScan.TabIndex = 1;
            btnScan.Text = "Scan";
            btnScan.UseVisualStyleBackColor = true;
            btnScan.Click += onScanFileButtonClick;
            // 
            // btnStop
            // 
            btnStop.Location = new Point(478, 461);
            btnStop.Margin = new Padding(3, 4, 3, 4);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(115, 92);
            btnStop.TabIndex = 2;
            btnStop.Text = "Stop";
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Click += onStopButtonClick;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(298, 16);
            btnAdd.Margin = new Padding(3, 4, 3, 4);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(51, 55);
            btnAdd.TabIndex = 4;
            btnAdd.Text = "-";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += onRemoveRowClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Roboto Black", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(391, 121);
            label1.Name = "label1";
            label1.Size = new Size(185, 33);
            label1.TabIndex = 6;
            label1.Text = "LabelTransfer";
            // 
            // pbLogo
            // 
            pbLogo.Location = new Point(405, 16);
            pbLogo.Margin = new Padding(3, 4, 3, 4);
            pbLogo.Name = "pbLogo";
            pbLogo.Size = new Size(134, 101);
            pbLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            pbLogo.TabIndex = 5;
            pbLogo.TabStop = false;
            // 
            // tbFileName
            // 
            tbFileName.Location = new Point(365, 359);
            tbFileName.Name = "tbFileName";
            tbFileName.Size = new Size(228, 27);
            tbFileName.TabIndex = 7;
            // 
            // btnChoseFile
            // 
            btnChoseFile.Location = new Point(314, 359);
            btnChoseFile.Name = "btnChoseFile";
            btnChoseFile.Size = new Size(40, 29);
            btnChoseFile.TabIndex = 8;
            btnChoseFile.Text = "..";
            btnChoseFile.UseVisualStyleBackColor = true;
            btnChoseFile.Click += onChooseFileClick;
            // 
            // lblChoose
            // 
            lblChoose.AutoSize = true;
            lblChoose.Location = new Point(381, 328);
            lblChoose.Name = "lblChoose";
            lblChoose.Size = new Size(197, 20);
            lblChoose.TabIndex = 9;
            lblChoose.Text = "Zgjidh File qe do te Skanosh";
            // 
            // btnConnect
            // 
            btnConnect.Location = new Point(417, 208);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(105, 47);
            btnConnect.TabIndex = 10;
            btnConnect.Text = "Konekto";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += onButtonConnectClick;
            // 
            // CMainWindowForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(612, 600);
            Controls.Add(btnConnect);
            Controls.Add(lblChoose);
            Controls.Add(btnChoseFile);
            Controls.Add(tbFileName);
            Controls.Add(label1);
            Controls.Add(pbLogo);
            Controls.Add(btnAdd);
            Controls.Add(btnStop);
            Controls.Add(btnScan);
            Controls.Add(dgvData);
            Margin = new Padding(3, 4, 3, 4);
            Name = "CMainWindowForm";
            Text = "CMainWindowForm";
            ((System.ComponentModel.ISupportInitialize)dgvData).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbLogo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvData;
        private Button btnScan;
        private Button btnStop;
        private Button btnAdd;
        private Label label1;
        private PictureBox pbLogo;
        private TextBox tbFileName;
        private Button btnChoseFile;
        private Label lblChoose;
        private DataGridViewTextBoxColumn IP;
        private DataGridViewTextBoxColumn Status;
        private Button btnConnect;
    }
}