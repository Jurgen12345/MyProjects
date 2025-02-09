using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scale.UX
{
    public partial class CMinimizingForm : Form
    {
        private CMainWindowForm mainForm;

        public CMinimizingForm(CMainWindowForm parentForm)
        {
            InitializeComponent();
            //pbInfoLogo.Image = Image.FromStream(new MemoryStream(Properties.Resources.Final_Logo));
            this.mainForm = parentForm;
        }

        private void onMinimizeButtonClick(object sender, EventArgs e)
        {
            this.mainForm.HideMain();
            this.Close();


        }

        private void onExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
            Environment.Exit(1);
            
        }
    }
}
