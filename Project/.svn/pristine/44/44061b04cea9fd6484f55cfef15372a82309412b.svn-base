using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Invoices.Data.Records;
using Lib.Data.DB;

namespace Invoices.Data.Tables
{
    public class TableITEM : CDBTable<ITEM>
    {
        public TableITEM() { }

        public override void LoadRecord(int p_nKeyValue)
        {
            this.records.Clear();

            ITEM? oParams = new ITEM();
            oParams.ID = p_nKeyValue;

            using (var iTransaction = CData.Instance.DB.BeginTransaction())
            {
                try
                {
                    var oRecords = CData.Instance.DB.SelectWithParams<ITEM>(
                            "select * from ITEM where ID = @ID", oParams, iTransaction);
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

            var oRecords = CData.Instance.DB.Select<ITEM>("select * from ITEM", p_iTransaction);

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
                CData.Instance.DB.SaveChanges<ITEM>(this.records,

                            // Provide the insert statement that will be used for new records
                            @"  insert into ITEM
                                (
                                   CODE,
                                   MEASUREMENT_UNIT_CID,
                                   ITEM_CATEGORY_CID
                                )
                                values
                                (
                                   @CODE,
                                   @MEASUREMENT_UNIT_CID,
                                   @ITEM_CATEGORY_CID
                                )",

                            // Provide the update statement that will be used for updated records
                            @"
                            update ITEM set
                                CODE                  = @CODE,
                                MEASUREMENT_UNIT_CID  = @MEASUREMENT_UNIT_CID,
                                ITEM_CATEGORY_CID     = @ITEM_CATEGORY_CID   
                            where
                                ID = @ID",

                            // Provide the delete statement that will be used for deleted records
                            @"delete from ITEM where ID = @ID",

                            p_iTransaction
                        );

                // We reload the table to reflect all the changes that have been saved in the DB
                // With this we secure that fields altered by DB triggers are properly loaded
                this.LoadTable(p_iTransaction);
            }
        }

    }
}
