﻿using Lib.UX.DataForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Invoices.Logic.DataModules;
using Invoices.Logic.Entities;
using Lib.Logic;
using Lib.UX.DataGrid;
using Lib.UX.DataForms;
using System.Runtime.CompilerServices;

namespace Invoices.UX.WinForms
{
    public partial class CViewEntityAppInvoice : Form, IEntityViewForm
    {

        protected CDMAppInvoices module { get; set; }
        protected CEditableGridDecorator detailsGrid;
        protected DataGridViewComboBoxColumn? cbcItem = null;
        public CViewEntityAppInvoice()
        {
            InitializeComponent();
        }

        public void SetParent(Form p_oForm)
        {
            CFormTemplateMaster oMasterForm = (CFormTemplateMaster)p_oForm;

            this.detailsGrid = new CEditableGridDecorator(this.dgvDetails, oMasterForm.FormContext);
            oMasterForm.DetailGrids.Add(this.detailsGrid);
            this.module = (CDMAppInvoices)oMasterForm.Module;
        }

        public void WriteMasterToUI()
        {
            CAppInvoices oCurrentInvoice = this.module.AppInvoicesModel.Master;

            //this.txtCustomerId.Text = oCurrentInvoice.customerId.ToString();
            //this.addLookupOnDetailList();
            this.displayCustomerIDLookup(oCurrentInvoice);
        }

        public void ReadMasterFromUI()
        {
            CAppInvoices oCurrentInvoice = this.module.AppInvoicesModel.Master;
            //oCurrentInvoice.customerId = Convert.ToInt32(this.txtCustomerId.Text);
            oCurrentInvoice.Change = EntityChangeType.UPDATED;
        }

        public void WriteDetailListToUI()
        {
            this.detailsGrid.Populate<CAppInvoicesLine>(this.module.AppInvoicesModel.Details);
            this.addLookupOnDetailList();

        }

        private void displayCustomerIDLookup(CAppInvoices p_oCurrentAppInvoice)
        {
            this.txtCustomerId.ValueMember = "CustomerId";
            this.txtCustomerId.DisplayMember = "Customer id";
            this.txtCustomerId.Items.Clear();
            foreach(CCustomer oCustomer in this.module.MasterLookupCustomer)
            {
                this.txtCustomerId.Items.Add(oCustomer);
            }

            p_oCurrentAppInvoice.LookupCustomer(this.module.MasterLookupCustomer);
            this.txtCustomerId.SelectedItem = p_oCurrentAppInvoice.customerId.ToString();
            

        }


        protected void addLookupOnDetailList()
        {
            DataGridViewColumn? oFoundColumn = null;
            int nIndex = 0;
            foreach (DataGridViewColumn oColumn in this.dgvDetails.Columns)
            {
                if (oColumn.DataPropertyName == "itemId")
                {
                    oFoundColumn = oColumn;
                    break;
                }
                nIndex++;
            }
            if (oFoundColumn != null)
            {
                oFoundColumn.Visible = false;
            }

            this.cbcItem = new DataGridViewComboBoxColumn()
            {
                HeaderText = "Item",
                Width = 200,
                ValueMember = "itemId",     
                DisplayMember = "code", 
                DataPropertyName = "itemId", 
                FlatStyle = FlatStyle.Popup,
            };

            if (oFoundColumn == null) { 
                this.dgvDetails.Columns.Add(cbcItem);
            }
            else
            {
                this.dgvDetails.Columns.Insert(nIndex, cbcItem);
            }

            this.cbcItem.DataSource = null;
            if (this.module.DetailLookup != null)
            {
                this.cbcItem.DataSource = this.module.DetailLookup;
            }



        }



        private void DoOnAnyCommand(object sender, EventArgs e)
        {
            if (sender == btnNewDetail)
            {
                this.detailsGrid.CreateRow<CAppInvoicesLine>(new CAppInvoicesLine());
            }
            else if (sender == btnDeleteDetail)
            {
                this.detailsGrid.DeleteRow();
            }
        }
    }
}
