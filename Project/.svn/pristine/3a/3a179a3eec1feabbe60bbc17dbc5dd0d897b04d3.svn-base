using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Lib.Common.Interfaces;
using Invoices.Logic.Entities;
using Invoices.Logic.Visitors;
using Lib.Data.DB;
using DataApplication.Logic;

namespace Invoices.Logic.Models
{
    public class CAppInvoicesBrowserModel : List<CAppInvoices>
    {
        public IDBTable View = CDBTableFactory.Instance.CreateTable("INVOICES");
        private Dictionary<string, object> _criteria = new Dictionary<string, object>();
        public Dictionary<string, object> Criteria { get { return _criteria; } }

        public void AcceptVisitAfterLoad(IVisitorToModel p_oEntityLoader)
        {
            this.Clear();
            p_oEntityLoader.Visit(this.View.RecordSet, this);
        }
    }
}
