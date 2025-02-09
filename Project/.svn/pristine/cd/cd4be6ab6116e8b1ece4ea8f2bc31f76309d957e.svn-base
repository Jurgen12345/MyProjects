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
    public class TableSUPPLIER: CDBTable<SUPPLIER>
    {
        public TableSUPPLIER() { }


        public override void LoadRecord(int p_nKeyValue)
        {
            this.records.Clear();

            SUPPLIER? oParams = new SUPPLIER();
            oParams.SUPPLIER_ID = p_nKeyValue;

            using (var iTransaction = CData.Instance.DB.BeginTransaction())
            {
                try
                {
                    var oRecords = CData.Instance.DB.SelectWithParams<SUPPLIER>(
                            "select * from SUPPLIER where ID = @SUPPLIER_ID", oParams, iTransaction);
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

            var oRecords = CData.Instance.DB.Select<SUPPLIER>("select * from SUPPLIER", p_iTransaction);

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
                CData.Instance.DB.SaveChanges<SUPPLIER>(this.records,

                            // Provide the insert statement that will be used for new records
                            @"  insert into SUPPLIER
                                (
                                   SUPPLIER_CATEGORY_CID
                                )
                                values
                                (
                                   @SUPPLIER_CATEGORY_CID
                                )",

                            // Provide the update statement that will be used for updated records
                            @"
                            update SUPPLIER set
                                 SUPPLIER_CATEGORY_CID = @SUPPLIER_CATEGORY_CID
                            where
                                ID = @SUPPLIER_ID",

                            // Provide the delete statement that will be used for deleted records
                            @"delete from SUPPLIER where ID = @SUPPLIER_ID",

                            p_iTransaction
                        );

                // We reload the table to reflect all the changes that have been saved in the DB
                // With this we secure that fields altered by DB triggers are properly loaded
                this.LoadTable(p_iTransaction);
            }
        }



    }
}
