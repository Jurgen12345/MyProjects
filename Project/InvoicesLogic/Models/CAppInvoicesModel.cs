using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Lib.Logic;
using Invoices.Logic.Entities;
using Invoices.Logic.Visitors;
using Lib.Common.Interfaces;
using System.Data;
using DataApplication.Logic;
using Invoices.Data;

namespace Invoices.Logic.Models
{
    public class CAppInvoicesModel : List<CAppInvoices>, IMasterDetailModel
    {
        public IDBTable MasterTable = CDBTableFactory.Instance.CreateTable("INVOICES");
        public IDBTable DetailTable = CDBTableFactory.Instance.CreateTable("INVOICES_LINE");

        public CAppInvoices Master
        {
            get
            {
                if (this.Count == 0)
                {
                    return null;
                }
                else
                {
                    return this[0];
                }
            }
        }


        public List<CAppInvoicesLine> Details = new List<CAppInvoicesLine>();
        public CAppInvoicesModel() { }

        public IEntity NewMasterDetail()
        {
            this.Clear();
            this.MasterTable?.RecordSet.Clear();

            this.Details.Clear();
            this.DetailTable?.RecordSet.Clear();

            CAppInvoices oNewMasterEntity = new CAppInvoices();
            oNewMasterEntity.Change = EntityChangeType.CREATED;
            this.Add(oNewMasterEntity);
            this.Details.Clear();

            return oNewMasterEntity;
        }

        public void LoadMasterDetail(int p_nMasterKeyValue)
        {
            this.MasterTable.LoadRecord(p_nMasterKeyValue);
            this.DetailTable.LoadTable(null, p_nMasterKeyValue);
        }

        public int SaveMasterDetail()
        {
            int nMasterID;
            using (IDbTransaction iTransaction = CData.Instance.DB.BeginTransaction())
            {
                try
                {
                    this.MasterTable?.SaveTable(iTransaction);
                    nMasterID = this.Master.id;
                    // Get the ID of the master and copy to the foreign key in the details.
                    foreach (var oDetail in this.Details)
                        oDetail.invoceId = nMasterID;
                    this.DetailTable?.SaveTable(iTransaction);        // Then insert/update the details.

                    iTransaction.Commit();
                }
                catch
                {
                    iTransaction.Rollback();
                    throw;
                }
            }
            return nMasterID;
        }

        public void DeleteMasterDetail()
        {
            this.Master.Change = EntityChangeType.DELETED;
            foreach (var oDetail in this.Details)
                oDetail.Change = EntityChangeType.DELETED;
            SaveMasterDetail();
        }

        public void AcceptVisitAfterLoad(IVisitorToModel p_oEntityLoader)
        {
            this.Clear();
            p_oEntityLoader.Visit(this.MasterTable.RecordSet, this);
            this.Details.Clear();
            p_oEntityLoader.Visit(this.DetailTable.RecordSet, this.Details);
        }

        public void AcceptVisitBeforeSave(IVisitorToModel p_oRecordAdder)
        {
            p_oRecordAdder.Visit(this.MasterTable.RecordSet, this);
            p_oRecordAdder.Visit(this.DetailTable.RecordSet, this.Details);
        }



    }
}
