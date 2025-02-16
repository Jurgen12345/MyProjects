using Invoices.UX;
using Invoices.UX.Builders;
using Invoices.UX.WinForms;

namespace WindowsApp
{
    public partial class Form1 : Form
    {

        public CFormTableCustomer? FormTableCustomer = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void invoicesWindowsOpen(object sender, EventArgs e)
        {
            if (sender == tsmInvoices)
            {
                this.IsMdiContainer = true;
                new CMasterFormDirector(new CFormAppInvoicesBuilderAlt()).ConstructUX(this).Show();
            }
            else if (sender == tsmInvoiceLine)
            {
                this.IsMdiContainer = true;
                new CMasterFormDirector(new CFormAppInvoicesBuilder()).ConstructUX(this).Show();
            }
            else if (sender == tsmItems)
            {
                if (FormTableCustomer == null)
                {
                    FormTableCustomer = new CFormTableCustomer();
                }
                FormTableCustomer.ShowDialog();
            }
            else if (sender == tsmItems)
            {
                CFormTableItem oFormTableItem = new CFormTableItem();
                oFormTableItem.MdiParent = this;
                oFormTableItem?.Show();
            }
        }

        private void onCustomersClick(object sender, EventArgs e)
        {
            CFormTableCustomer oFormTableCustomers = new CFormTableCustomer();
            //oFormTableCustomers.MdiParent = this;
            oFormTableCustomers.Show();
        }

        private void onItemClick(object sender, EventArgs e)
        {
            CFormTableItem oFormTableItems = new CFormTableItem();
            oFormTableItems.Show();
        }

        private void onSupplierClick(object sender, EventArgs e)
        {
            CFormTableSupplier oFormTableSupplier = new CFormTableSupplier();
            oFormTableSupplier.Show();
        }

        
    }
}
