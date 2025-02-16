﻿using System;
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
    public class TableCUSTOMER : CDBTable<CUSTOMER>
    {
        public TableCUSTOMER() { }


        public override void LoadRecord(int p_nKeyValue)
        {
            this.records.Clear();

            CUSTOMER? oParams = new CUSTOMER();
            oParams.CUSTOMER_ID = p_nKeyValue;

            using (var iTransaction = CData.Instance.DB.BeginTransaction())
            {
                try
                {
                    var oRecords = CData.Instance.DB.SelectWithParams<CUSTOMER>(
                            "select * from CUSTOMER where ID = @CUSTOMER_ID", oParams, iTransaction);
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

            var oRecords = CData.Instance.DB.Select<CUSTOMER>("select * from CUSTOMER", p_iTransaction);

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
                CData.Instance.DB.SaveChanges<CUSTOMER>(this.records,

                            // Provide the insert statement that will be used for new records
                            @"  insert into CUSTOMER
                                (
                                   ID
                                )
                                values
                                (
                                   @CUSTOMER_ID
                                )",

                            // Provide the update statement that will be used for updated records
                            @"
                            update INVOICE set
                                CUSTOMER_ID = @CUSTOMER_ID
                            where
                                ID = @CUSTOMER_ID",

                            // Provide the delete statement that will be used for deleted records
                            @"delete from CUSTOMER where ID = @CUSTOMER_ID",

                            p_iTransaction
                        );

                // We reload the table to reflect all the changes that have been saved in the DB
                // With this we secure that fields altered by DB triggers are properly loaded
                this.LoadTable(p_iTransaction);
            }
        }



    }
}
