using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataApplication.Logic;
using Invoices.Data.Records;
using Invoices.Logic.Entities;
using Invoices.Logic.Visitors;
using Lib.Common.Interfaces;
using Lib.Data.DB;

namespace Invoices.Logic.Models
{
    public class CSupplierBrowserModel : List<CSupplier>
    {
        public IDBTable View = CDBTableFactory.Instance.CreateTable("SUPPLIER");

        private Dictionary<string, object> _criteria = new Dictionary<string, object>();
        public Dictionary<string, object> Criteria { get { return _criteria; } }

        public void AcceptVisitAfterLoad(IVisitorToModel p_oEntityLoader)
        {
            this.Clear();
            p_oEntityLoader.Visit(this.View.RecordSet, this);
        }

    }
}
