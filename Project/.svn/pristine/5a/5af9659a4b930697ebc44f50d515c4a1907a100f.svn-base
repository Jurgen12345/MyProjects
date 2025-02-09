using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Invoices.Data.Records;
using Invoices.Logic.Entities;
using Invoices.Logic.Models;
using Lib.Logic;

namespace Invoices.Logic.Visitors
{
    public class CVisitorEntityLoader : IVisitorToModel
    {
        public PropertyChangedEventHandler? EntityChangeHandler { get; set; } = null;

        public void Visit(IList p_oRecordSet, List<CAppInvoices> p_oEntityList)
        {
            foreach (INVOICES oRecord in p_oRecordSet)
            {
                CAppInvoices oEntity = new CAppInvoices();
                oEntity.Record = oRecord;
                oEntity.OnPropertyChange += EntityChangeHandler;
                p_oEntityList.Add(oEntity);
            }
        }

        public void Visit(IList p_oRecordSet, List<CAppInvoicesLine> p_oEntityList)
        {
            foreach (INVOICES_LINE oRecord in p_oRecordSet)
            {
                CAppInvoicesLine oEntity = new CAppInvoicesLine();
                oEntity.Record = oRecord;
                oEntity.OnPropertyChange += EntityChangeHandler;
                oEntity.itemId = oEntity.itemId;
                p_oEntityList.Add(oEntity);
            }
        }

        public void Visit(IList p_oRecordSet, List<CCustomer> p_oEntityList)
        {
            foreach (CUSTOMER oRecord in p_oRecordSet)

            {
                CCustomer oEntity = new CCustomer();
                oEntity.Record = oRecord;
                oEntity.OnPropertyChange += EntityChangeHandler;
                p_oEntityList.Add(oEntity);
            }
        }

        public void Visit(IList p_oRecordSet, List<CItem> p_oEntityList)
        {
            foreach (ITEM oRecord in p_oRecordSet)
            {
                CItem oEntity = new CItem();
                oEntity.Record = oRecord;
                oEntity.OnPropertyChange += EntityChangeHandler;
                p_oEntityList.Add(oEntity);
            }
        }

        public void Visit(IList p_oRecordSet, List<CSupplier> p_oEntityList)
        {
            foreach (SUPPLIER oRecord in p_oRecordSet)
            {
                CSupplier oEntity = new CSupplier();
                oEntity.Record = oRecord;
                oEntity.OnPropertyChange += EntityChangeHandler;
                p_oEntityList.Add(oEntity);
            }
        }

        
    }
}
