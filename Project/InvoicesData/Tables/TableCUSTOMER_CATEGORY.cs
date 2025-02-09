using Invoices.Data.Records;
using Lib.Data.DB;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoices.Data.Tables
{
    public class TableCUSTOMER_CATEGORY : CDBTable<CUSTOMER_CATEGORY>
    {
        public TableCUSTOMER_CATEGORY() { }

        public override void LoadRecord(int p_nKeyValue)
        {
            this.records.Clear();

            CUSTOMER_CATEGORY? oParams = new CUSTOMER_CATEGORY();
            oParams.CID = p_nKeyValue;

            using (var iTransaction = CData.Instance.DB.BeginTransaction())
            {
                try
                {
                    var oRecords = CData.Instance.DB.SelectWithParams<CUSTOMER_CATEGORY>(
                            "select * from CUSTOMER_CATEGORY where CID = @CID", oParams, iTransaction);
                    iTransaction.Commit();

                    // When a select returns no records a null object might be returned by the method
                    if (oRecords != null)
                    {
                        this.records = oRecords;

                        foreach (var oRecord in this.records)
                            Debug.WriteLine(oRecord.ToString());
                    }
                }
                catch
                {
                    iTransaction.Rollback();
                    throw;
                }
            }
        }

        public override void LoadTable(IDbTransaction? p_iTransaction)
        {
            this.records.Clear(); // Empty the existing records

            var oRecords = CData.Instance.DB.Select<CUSTOMER_CATEGORY>("select * from CUSTOMER_CATEGORY", p_iTransaction);

            // When a select returns no records a null object might be returned by the method
            if (oRecords != null)
            {
                this.records = oRecords;

                foreach (var oRecord in this.records)
                    Debug.WriteLine(oRecord.ToString());
            }
        }

        public override void SaveTable(IDbTransaction? p_iTransaction)
        {
            if (this.records != null)
            {
                
                CData.Instance.DB.SaveChanges<CUSTOMER_CATEGORY>(this.records,


                    @"  insert into CUSTOMER_CATEGORY
                (
                   CID,
                   LEVEL
                )
                values
                (
                   @CID,
                   @LEVEL
                )",


                    @"
            update CUSTOMER_CATEGORY set
                LEVEL = @LEVEL
            where
                CID = @CID", 

                    
                    @"delete from CUSTOMER_CATEGORY where CID = @CID",

                    p_iTransaction
                );

                // After saving changes, reload the table to reflect the latest state of records
                // This is important if your database triggers or other operations modify the data
                this.LoadTable(p_iTransaction);
            }
        }


    }
}
