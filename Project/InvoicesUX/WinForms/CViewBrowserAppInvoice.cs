using Invoices.Logic.Models;
using Lib.Logic;
using Lib.UX.DataForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using static Dapper.SqlMapper;

namespace Invoices.UX.WinForms
{
    public partial class CViewBrowserAppInvoice : Form, IBrowserViewForm
    {
        protected CAppInvoicesBrowserModel browserModel;
        protected CFormTemplateMaster parent;

        public bool HasSelectedInBrowser
        {
            get
            {
                bool bResult = false;
                if(lstBrowser.SelectedItems != null)
                {
                    IEntity? oCurrentEntity = lstBrowser.SelectedItems as IEntity;
                    if (oCurrentEntity != null)
                    {
                        bResult = oCurrentEntity.PrimaryKeyValue > 0;
                    }
                    
                }
                return bResult;
            }
        }

        public IEntity? SelectedEntity { get { return lstBrowser.SelectedItem as IEntity; } }


        public CViewBrowserAppInvoice(CAppInvoicesBrowserModel p_oBrowserModel)
        {
            InitializeComponent();
            this.browserModel = p_oBrowserModel;
        }

        public void SetParent(Form p_oForm)
        {
            this.parent = (CFormTemplateMaster)p_oForm;
        }

        void IBrowserViewForm.Dock(Control p_oContainer)
        {
            // Hide all other controls in the given container
            foreach (Control oControl in p_oContainer.Controls)
                oControl.Visible = false;

            // [.NET WINFORMS | ADVANCED] Hosting a form inside a container control
            this.TopLevel = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Dock = DockStyle.Fill;
            p_oContainer.Controls.Add(this);
            this.Show();
        }

        public void WriteBrowserListToTheUI()
        {
            this.lstBrowser.DataSource = null;
            this.lstBrowser.DataSource = this.browserModel;
        }
        private void FindByName()
        {
            string sSearchStr = this.txtSearch.Text;

            // [C#/LINQ] This is an example of runing a SELECT query a generic list with a specific WHERE clause.
            var oFound = this.browserModel.Where(x => x.id.ToString().Contains(sSearchStr.ToLower())).ToList();
            if (oFound.Count > 0)
                this.lstBrowser.SelectedItem = oFound[0];
        }

        private void DoOnAnyCommand(object sender, EventArgs e)
        {
            if (sender == btnFind)
                FindByName();
            else if (sender == lstBrowser)
                // Trigger an open event on the parent form context, to switch to the entity view
                this.parent.FormContext.HandleEvent(this.parent.FormContext.Open);
        }

        private void DoOnAnyKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (sender == txtSearch)
                {
                    FindByName();
                    this.lstBrowser.Focus();
                    this.lstBrowser.Select();
                    e.Handled = true;
                }
                else if (sender == lstBrowser)
                {
                    // Trigger an open event on the parent form context, to switch to the entity view
                    this.parent.FormContext.HandleEvent(this.parent.FormContext.Open);
                    e.Handled = true;
                }
            }
        }

    }
}
