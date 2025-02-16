﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Lib.Logic;
using Lib.Common.Attribs;
using Invoices.Data.Records;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Invoices.Logic.Entities
{
    public class CAppInvoices : CEntity<INVOICES>
    {
        [Key]
        public int id
        {
            get { return this.Record.INVOICE_ID; }
            set { this.Record.INVOICE_ID = value;}
        }

        public int isCustomerInvoice
        {
            get { return this.Record.IS_CUSTOMER_INVOICE; }
            set { this.Record.IS_CUSTOMER_INVOICE = value;}
        }

        public int customerId
        {
            get { return this.Record.CUSTOMER_ID ; }
            set { this.Record.CUSTOMER_ID = value; }
        }

        [Browsable(false)]
        public CCustomer? _Customer { get; set; } = null;

        [Browsable(false)]
        public CSupplier? _Supplier { get; set; } = null;
        



        public void LookupMaster(List<CCustomer> p_oCustomer,List<CSupplier> p_oSupplier,int p_bIsCustomer)
        {
            p_bIsCustomer = this.isCustomerInvoice;
            if(p_bIsCustomer == 1)
            {
                LookupCustomer(p_oCustomer);
            }
            else
            {
                LookupSupplier(p_oSupplier);
            }

        }


        public void LookupCustomer(List<CCustomer> p_oCustomer)
        {
            var oFound = p_oCustomer.Where(x => x.customerId == customerId).ToList();
            if (oFound.Count > 0) { 
                this._Customer = oFound[0];
            }
            else
            {
                this._Customer=null;
            }
        }

        public void LookupSupplier(List<CSupplier> p_oSupplier)
        {
            var oFound = p_oSupplier.Where(x => x.supplierId == this.supplierId).ToList();
            if (oFound.Count > 0) {
                this._Supplier = oFound[0];

            }
            else
            {
                this._Supplier = null;
            }
        }


        public int supplierId
        {
            get { return this.Record.SUPPLIER_ID; }
            set { this.Record.SUPPLIER_ID = value; }
        }

        public int itemOrderId
        {
            get { return this.Record.ITEM_ORDER_ID; }
            set { this.Record.ITEM_ORDER_ID = value; }

        }

        public CAppInvoices() : base() { }

        public override string ToString()
        {
            return $"Invoice Number : {id.ToString()}";
        }

    }
}
