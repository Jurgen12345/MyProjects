using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Invoices.Data;
using Invoices.Data.Records;
using Invoices.Data.Tables;
using Lib.Data.DB;
using Lib.Common.Interfaces;

namespace DataApplication.Logic
{
    public class CDBTableFactory
    {
        #region // Singleton \\
        // ....................................................................
        private static CDBTableFactory? __instance = null;
        public static CDBTableFactory Instance
        {
            get
            {
                //PATTERN: Lazy initialization. The only instance is created at the first time that is needed.
                if (__instance == null)
                    __instance = new CDBTableFactory();
                return __instance;
            }
        }
        private CDBTableFactory()
        {
        }
        // ....................................................................
        #endregion

        // --------------------------------------------------------------------------------------
        // [PATTERNS] Factory Method
        public IDBTable CreateTable(string p_sTableName)
        {
            if (p_sTableName == "INVOICES")
                return new TableINVOICES();
            else if (p_sTableName == "INVOICES_LINE")
                return new TableINVOICES_LINE();
            else if (p_sTableName == "CUSTOMER")
                return new TableCUSTOMER();
            else if (p_sTableName == "ITEM")
                return new TableITEM();
            else if (p_sTableName == "SUPPLIER")
                return new TableSUPPLIER();
            else
                return null;
        }
        // --------------------------------------------------------------------------------------
    }

}
