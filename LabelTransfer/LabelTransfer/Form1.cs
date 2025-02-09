using Scale.UX;
using Scale.UX.Properties;
using System.Windows.Forms;
using License.Logic;
using System.Configuration;


namespace LabelTransfer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            pbLogo.Image = Image.FromStream(new MemoryStream(Resources.Final_Logo));
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            if (!string.IsNullOrEmpty(Settings1.Default["CurrentUser"].ToString()))
            {
                tbUserLicense.Text = Settings1.Default["CurrentUser"].ToString();
            }
        }

        private void onValidate(object sender, EventArgs e)
        {
            string? userLicense = tbUserLicense.Text.ToUpper();



            CCreateConnection userConnection = new CCreateConnection(userLicense);
            if (userConnection.isValid && userConnection.checkingValidity.Equals("true"))
            {
                //MessageBox.Show(userConnection.validationResult.ToString());

                Settings1.Default["CurrentUser"] = userLicense;
                Settings1.Default.Save();

                CMainWindowForm mainForm = new CMainWindowForm();

                this.Hide();
                mainForm.Show();
                
            }
            else if (!userConnection.isValid)
                MessageBox.Show("Licensa qe keni vendosur nuk ekziston");
            else if (userConnection.checkingValidity.Equals("false"))
                MessageBox.Show("Licensa qe keni vendosur nuk eshte aktive. Ju lutem" +
                    " kontaktoni : info-shimani@gmail.com");
            
        }
    }
}
