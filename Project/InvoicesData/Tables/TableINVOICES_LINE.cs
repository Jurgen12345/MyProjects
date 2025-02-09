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
    public class TableINVOICES_LINE : CDBTable<INVOICES_LINE>
    {

        public int MasterID { get; set; }
        public TableINVOICES_LINE() { }


        public override void LoadTable(IDbTransaction? p_iTransaction, int p_nMasterKeyValue)
        {
            this.MasterID = p_nMasterKeyValue;
            this.LoadTable(p_iTransaction);
        }

        public override void LoadTable(IDbTransaction? p_iTransaction)
        {
            this.records.Clear();

            INVOICES_LINE? oParams = new INVOICES_LINE();
            oParams.ID = this.MasterID;
            var oRecords = CData.Instance.DB.SelectWithParams<INVOICES_LINE>(
                "select * from INVOICE_LINE where INVOICE_ID = @INVOICE_ID", oParams,p_iTransaction);

            if(oRecords != null)
            {
                this.records = oRecords;
                foreach(var oRecord in this.records)
                {
                    Debug.WriteLine(oRecord.ToString());
                }
            }
        }

        public override void SaveTable(IDbTransaction? p_iTransaction)
        {
            if (this.records != null)
            {
                CData.Instance.DB.SaveChanges<INVOICES_LINE>(this.records,

                            // Provide the insert statement that will be used for new records
                            @"  insert into INVOICE_LINE
                                (
                                   INVOICE_ID,
                                   ITEM_ID,
                                   QTY,
                                   PRICE,
                                   LINE_TOTAL
                                )
                                values
                                (
                                   @INVOICE_ID,
                                   @ITEM_ID,
                                   @QTY,
                                   @PRICE,
                                   @LINE_TOTAL
                                )",

                            // Provide the update statement that will be used for updated records
                            @"
                            update INVOICE_LINE set
                                 INVOICE_ID               = @INVOICE_ID,
                                 ITEM_ID                  = @ITEM_ID,	
                                 QTY                      = @QTY,	
                                 PRICE                    = @PRICE,
                                 LINE_TOTAL               = @LINE_TOTAL
                            where
                                ID = @ID",

                            // Provide the delete statement that will be used for deleted records
                            @"delete from INVOICE_LINE where ID = @ID",

                            p_iTransaction
                        );

                // We reload the table to reflect all the changes that have been saved in the DB
                // With this we secure that fields altered by DB triggers are properly loaded
                this.LoadTable(p_iTransaction);
            }
        }


    }
}
