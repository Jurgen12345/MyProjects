using DataApplication.Logic;
using Lib.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Lib.Logic;
using Invoices.Data.Records;
using Lib.Common.Interfaces;
using Invoices.Logic.Entities;
using Invoices.Logic.Visitors;
using Invoices.Data;
using System.Data;

namespace Invoices.Logic.Models
{
    public class CSupplierModel : List<CSupplier>
    {
        public IDBTable Table = CDBTableFactory.Instance.CreateTable("SUPPLIER");

        private bool _isLookup = false;

        public CSupplierModel(bool p_bIsLookup)
        {
            _isLookup = p_bIsLookup;
        }

        public void AcceptVisitAfterLoad(IVisitorToModel p_oEntityLoader)
        {
            this.Clear();
            if (_isLookup)
            {
                this.Add(new CSupplier() { supplierId = -1, supplierCategoryCid = -1 });
            }
            p_oEntityLoader.Visit(this.Table.RecordSet,this);
        }

        public void AcceptVisitBeforeSave(IVisitorToModel p_oRecordAdder)
        {
            p_oRecordAdder.Visit(this.Table.RecordSet,this);
        }
       

    }
}
