using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataApplication.Logic;
using Invoices.Data;
using Invoices.Logic.Entities;
using Invoices.Logic.Visitors;
using Lib.Common.Interfaces;
using Lib.Logic;

namespace Invoices.Logic.Models
{
    public class CCustomerModel : List<CCustomer>
    {

        public IDBTable Table = CDBTableFactory.Instance.CreateTable("CUSTOMER");

        private bool _isLookup = false;

        public CCustomerModel(bool p_bIsLookup)
        {
            _isLookup = p_bIsLookup;
        }

        public void AcceptVisitAfterLoad(IVisitorToModel p_oEntityLoader)
        {
            this.Clear();
            if (_isLookup)
            {
                this.Add(new CCustomer() { customerId = -1});
            }
            p_oEntityLoader.Visit(this.Table.RecordSet,this);
        }

        public void AcceptVisitBeforeSave(IVisitorToModel p_oRecordAdder)
        {
            p_oRecordAdder.Visit(this.Table.RecordSet,this);
        }


    }
}
