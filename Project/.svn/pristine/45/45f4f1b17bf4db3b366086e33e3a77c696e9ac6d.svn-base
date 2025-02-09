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
    public class TableINVOICES : CDBTable<INVOICES>
    {
        public TableINVOICES()
        {
        }

        public override void LoadRecord(int p_nKeyValue)
        {
            this.records.Clear();

            INVOICES? oParams = new INVOICES();
            oParams.INVOICE_ID = p_nKeyValue;

            using (var iTransaction = CData.Instance.DB.BeginTransaction())
            {
                try
                {
                    var oRecords = CData.Instance.DB.SelectWithParams<INVOICES>(
                            "select * from INVOICE where ID = @INVOICE_ID", oParams, iTransaction);
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

            var oRecords = CData.Instance.DB.Select<INVOICES>("select * from INVOICE", p_iTransaction);

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
                try {
                    CData.Instance.DB.Execute<string>("SET IDENTITY_INSERT CUSTOMER ON;", null, p_iTransaction);
                    CData.Instance.DB.Execute<string>("SET IDENTITY_INSERT SUPPLIER ON;", null, p_iTransaction);


                    foreach (var oRecord in this.records)
                    {
                        if (oRecord.CUSTOMER_ID != null && !CustomerExists(oRecord.CUSTOMER_ID, p_iTransaction))
                        {
                            InsertDefaultCustomer(oRecord.CUSTOMER_ID, p_iTransaction);
                        }

                        if(oRecord.SUPPLIER_ID != null && !SupplierExitst(oRecord.SUPPLIER_ID, p_iTransaction))
                        {
                            InsertDefaultSupplier(oRecord.SUPPLIER_ID,p_iTransaction);
                        }
                    }

                    CData.Instance.DB.SaveChanges<INVOICES>(this.records,

                                // Provide the insert statement that will be used for new records
                                @"  insert into INVOICE
                                (
                                   IS_CUSTOMER_INVOICE,
                                   CUSTOMER_ID,
                                   SUPPLIER_ID,
                                   ITEM_ORDER_ID
                                )
                                values
                                (
                                     @IS_CUSTOMER_INVOICE,			
                                     @CUSTOMER_ID,	
                                     @SUPPLIER_ID,	
                                     @ITEM_ORDER_ID	
                                )",

                                // Provide the update statement that will be used for updated records
                                @"
                            update INVOICE set
                                 IS_CUSTOMER_INVOICE      = @IS_CUSTOMER_INVOICE,
                                 CUSTOMER_ID              = @CUSTOMER_ID,	
                                 SUPPLIER_ID              = @SUPPLIER_ID,	
                                 ITEM_ORDER_ID            = @ITEM_ORDER_ID
                            where
                                ID = @INVOICE_ID",

                                // Provide the delete statement that will be used for deleted records
                                @"delete from INVOICE where ID = @INVOICE_ID",

                                p_iTransaction
                            );

                    // We reload the table to reflect all the changes that have been saved in the DB
                    // With this we secure that fields altered by DB triggers are properly loaded
                    this.LoadTable(p_iTransaction);
                }
                finally
                {
                    CData.Instance.DB.Execute<string>("SET IDENTITY_INSERT CUSTOMER OFF;",null,p_iTransaction);
                    CData.Instance.DB.Execute<string>("SET IDENTITY_INSERT SUPPLIER OFF;", null, p_iTransaction);
                }
                }
        }

        public bool CustomerExists(int customerId, IDbTransaction? p_iTransaction)
        {
            var query = $"SELECT CASE WHEN EXISTS (SELECT 1 FROM CUSTOMER WHERE ID = {customerId}) THEN 1 ELSE 0 END";
            var result = CData.Instance.DB.Execute<int>(query, customerId, p_iTransaction);
            return result > 0;

        }

        public bool SupplierExitst(int supplierId, IDbTransaction? p_iTransaction)
        {
            var query = $"SELECT CASE WHEN EXISTS (SELECT 1 FROM SUPPLIER WHERE ID = {supplierId}) THEN 1 ELSE 0 END";
            var result = CData.Instance.DB.Execute<int>(query, supplierId, p_iTransaction);
            return result > 0;

        }



        public void InsertDefaultCustomer(int cusomterId, IDbTransaction p_iTransaction)
        {
            var query = $"INSERT INTO CUSTOMER (ID) VALUES ({cusomterId})";
            var parameters = new
            {
                CustmerId = cusomterId
            };
            CData.Instance.DB.Execute(query, parameters, p_iTransaction);

        }

        public void InsertDefaultSupplier(int supplierId, IDbTransaction p_iTransaction)
        {
            var query = $"INSERT INTO SUPPLIER (ID) VALUES ({supplierId})";
            var parameters = new
            {
                SupplierId = supplierId
            };
            CData.Instance.DB.Execute(query, parameters, p_iTransaction);

        }

    }
}
