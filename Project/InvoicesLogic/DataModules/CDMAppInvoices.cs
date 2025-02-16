﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Invoices.Logic.Entities;
using Invoices.Logic.Models;
using Lib.Common.Interfaces;
using Lib.Logic;
using Invoices.Logic;
using Invoices.Data.Records;

namespace Invoices.Logic.DataModules
{
    public class CDMAppInvoices : CDataModule, IDataModule
    {
        public IMasterDetailModel Model { get { return (IMasterDetailModel) this.model; } }

        public CAppInvoicesModel AppInvoicesModel {  get { return (CAppInvoicesModel)this.model; } }

        public CAppInvoicesBrowserModel BrowserModel;

        private CCustomerModel _masterLookupCustomer;
        private CSupplierModel _masterLookupSupplier;

        public CCustomerModel MasterLookupCustomer { get { return this._masterLookupCustomer; } }
        public CSupplierModel MasterLookupSupplier { get { return this._masterLookupSupplier; } }

        public CItemListModel _detailLookup;
        public CItemListModel DetailLookup { get { return this._detailLookup; } }   

        public CDMAppInvoices() : base()
        {
            this.model = new CAppInvoicesModel();
            this.BrowserModel = new CAppInvoicesBrowserModel();

            this._masterLookupCustomer = new CCustomerModel(true);

            this._detailLookup = new CItemListModel(true);


        }

        public int MasterKeyValue { get; set; }


        public void ModuleOnAnyEntityChange(object? sender, PropertyChangedEventArgs e)
        {
            if (sender != null)
            {
                Debug.WriteLine($"Property {e.PropertyName} has changed on a :{sender.GetType().Name} entity.");

                if (sender is CAppInvoices)
                    ((CAppInvoices)sender).LookupCustomer(this._masterLookupCustomer);
                else if (sender is CAppInvoicesLine)
                    ((CAppInvoicesLine)sender).LookupItem(this._detailLookup);
            }
        }

        public bool ModuleLoadBrowser()
        {
            bool bResult = false;
            try
            {
                BrowserModel.View.LoadTable(null);
                BrowserModel.AcceptVisitAfterLoad(this.entityLoader);
                this.IsLoaded= true;
                bResult = true;
            }
            catch (Exception oException)
            {
                this.LastError = oException.Message;
            }
            return bResult;
        }

        public bool ModuleLoadLookups()
        {
            bool bResult = false;
            try
            {
                _masterLookupCustomer.Table.LoadTable(null);
                _masterLookupCustomer.AcceptVisitAfterLoad(this.entityLoader);

                _detailLookup.Table.LoadTable(null);
                _detailLookup.AcceptVisitAfterLoad(this.entityLoader);

                bResult = true;
            }
            catch (Exception oException)
            {
                this.LastError = oException.Message;
            }
            return bResult;
        }

        public bool ModuleNew()
        {
            IEntity iEntity = Model.NewMasterDetail();
            iEntity.OnPropertyChange += ModuleOnAnyEntityChange;
            return true;
        }

        public bool ModuleLoad()
        {
            bool bResult = false;
            try
            {
                Model.LoadMasterDetail(this.MasterKeyValue);
                this.entityLoader.EntityChangeHandler = ModuleOnAnyEntityChange;
                AppInvoicesModel.AcceptVisitAfterLoad(this.entityLoader);
                this.IsLoaded= true;
                bResult = true;
            }
            catch (Exception oException)
            {
                this.LastError = oException.Message;
            }
            return bResult;
        }


        public bool ModuleSave()
        {
            bool bResult = false;
            try
            {
                AppInvoicesModel.AcceptVisitBeforeSave(this.recordAdder); 
                this.MasterKeyValue = Model.SaveMasterDetail();
                bResult = true;
            }
            catch (Exception oException)
            {
                this.LastError = oException.Message;
            }
            return bResult;
        }

        public bool ModuleDelete()
        {
            bool bResult = false;
            try
            {
                Model.DeleteMasterDetail();
                bResult = true;
            }
            catch (Exception oException)
            {
                this.LastError = oException.Message;
            }
            return bResult;
        }


    }
}
