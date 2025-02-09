using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Diagnostics;
using Scale.Connect;


namespace Scale.UX
{
    public partial class CMainWindowForm : Form
    {
        public List<string> ipList { get; set; }
        protected int index = 1;
        protected CMinimizingForm childForm;
        protected Stopwatch timer;

        protected FileSystemWatcher fileWatcher;




        public CMainWindowForm()
        {
            InitializeComponent();
            pbLogo.Image = Image.FromStream(new MemoryStream(Properties.Resources.Final_Logo));
            //  this.FormClosed += CMainWindowForm_FormClosed;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            this.FormClosing += CMainWindowForm_FormClosing;

            ipList = new List<string>();

            fileWatcher = new FileSystemWatcher();

            


        }

        public void HideMain()
        {
            this.Hide();
        }

        public void ShowMain()
        {
            this.Show();
        }

        private void CMainWindowForm_FormClosing(object? sender, FormClosingEventArgs e)
        {

            e.Cancel = true;
            //this.Hide();


            if (childForm == null)
            {
                CMinimizingForm childForm = new CMinimizingForm(this);
                childForm.Show();

                Debug.WriteLine(childForm);
            }

        }

        private void CMainWindowForm_FormClosed(object? sender, FormClosedEventArgs e)
        {



        }

        private void onRemoveRowClick(object sender, EventArgs e)
        {
            try
            {
                if (dgvData.CurrentRow != null)
                {
                    index = dgvData.CurrentRow.Index;
                    Debug.WriteLine(index);
                    dgvData.Rows.RemoveAt(index);
                }
                else
                {
                    MessageBox.Show("Nuk eshte zgjedhur asnje rrjesht!");
                }
            }
            catch (System.InvalidOperationException)
            {
                MessageBox.Show("Nuke eshte zgjedhur asnje rrjesht per tu fshire!");
            }

        }

        private void onChooseFileClick(object sender, EventArgs e)
        {
            OpenFileDialog ofileDialog = new OpenFileDialog();
            ofileDialog.Title = "Zgjidh File";
            ofileDialog.InitialDirectory = @"C:\";
            //ofileDialog.Filter = "All files (*.*)";
            ofileDialog.FilterIndex = 1;
            ofileDialog.ShowDialog();
            if (!string.IsNullOrEmpty(ofileDialog.FileName))
            {
                tbFileName.Text = ofileDialog.FileName;
            }
            else
            {
                tbFileName.Text = "";
            }
        }

        private void onScanFileButtonClick(object sender, EventArgs e)
        {
            string file = tbFileName.Text;
            if (!string.IsNullOrEmpty(file))
            {
                try
                {
                    using (Stream stream = new FileStream(file, FileMode.Open))
                    {
                        MessageBox.Show("File u hap me sukses!");
                    }

                    fileWatcher.NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.Size;
                    fileWatcher.Changed += FileWatcher_changed;
                    fileWatcher.Renamed += FileWatcher_renamed;
                    fileWatcher.Deleted += FileWatcher_deleted;
                    fileWatcher.Path = Path.GetDirectoryName(file);
                    fileWatcher.Filter = Path.GetFileName(file);
                    fileWatcher.EnableRaisingEvents = true;

                    MessageBox.Show("File-ja filloj te rekordohet!");
                    




                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ndodhi nje error me kodin:\n {ex}");

                }
            }
            else
            {
                MessageBox.Show("Zgjidh file-n qe deshironi te kryeni veprimet para se te skanoni!");
            }

        }

        private void FileWatcher_deleted(object sender, FileSystemEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void FileWatcher_renamed(object sender, RenamedEventArgs e)
        {
            MessageBox.Show($"File {e.ChangeType} : {e.FullPath}");
        }

        private void FileWatcher_changed(object sender, FileSystemEventArgs e)
        {
            MessageBox.Show($"File {e.ChangeType} : {e.FullPath}");
        }

        private void onStopButtonClick(object sender, EventArgs e)
        {
            fileWatcher.EnableRaisingEvents = false;
            MessageBox.Show("File-ja nuk po rekordohet me!");


        }

        private void onButtonConnectClick(object sender, EventArgs e)
        {
            if(dgvData.Rows.Count > 0)
            {
                foreach(DataGridViewRow row in dgvData.Rows)
                {
                    
                    var cellValue = row.Cells[0].Value;
                    if (cellValue != null)
                    {
                        ipList.Add(cellValue.ToString());
                        Debug.Write(cellValue.ToString());
                    }
                }

                CScaleConnect connection = new CScaleConnect(ipList);
                connection.ReadPLU();

                foreach(string ip in ipList)
                {
                    
                    if (connection.ips.ContainsKey(ip))
                    {
                        // do some operation    
                    }
                }
                

            }
            else
            {
                MessageBox.Show("Nuk keni vendosur asnje ip!");
            }

            

        }
    }
}
