using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataApplication.Logic;
using Invoices.Logic.Entities;
using Invoices.Logic.Visitors;
using Lib.Common.Interfaces;

namespace Invoices.Logic.Models
{
    public class CItemListModel : List<CItem>
    {
        public IDBTable Table = CDBTableFactory.Instance.CreateTable("ITEM");

        private bool _isLookup = false;

        public CItemListModel(bool p_bIsLookup)
        {
            _isLookup = p_bIsLookup;
        }

        public void AcceptVisitAfterLoad(IVisitorToModel p_oEntityLoader)
        {
            this.Clear();
            if (_isLookup)
            {
                this.Add(new CItem() { itemId = -1, code = ""});

            }
            p_oEntityLoader.Visit(this.Table.RecordSet, this);
        }
        public void AcceptVisitBeforeSave(IVisitorToModel p_oRecordAdder)
        {
            p_oRecordAdder.Visit(this.Table.RecordSet, this);
        }

        

        

    }
}
