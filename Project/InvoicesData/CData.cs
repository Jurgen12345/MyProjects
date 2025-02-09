using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Invoices.Common;
using Lib.Data.DB;

namespace Invoices.Data
{
    public class CData
    {
        // ....................................................................
        //PATTERN: Singleton. There can be only one instance of the class CApp
        private static CData? __instance = null;
        public static CData Instance
        {
            get
            {
                //PATTERN: Lazy initialization. The only instance is created at the first time that is needed.
                if (__instance == null)
                    __instance = new CData();
                return __instance;
            }
        }
        // ....................................................................



        // ....................................................................
        private IDBFileBased? __db = null;
        public IDBFileBased DB
        {
            get
            {
                //PATTERN: Lazy initialization. The only instance is created at the first time that is needed.
                if (__db == null)
                {
                    if (CSettings.Instance.DBType.ToUpper() == "MSSQL")
                        //C#: Example of a shortcut syntax for instantiation of an object with a block that assigns its properties
                        __db = new CDBMSSQLLocal()
                        {
                            InstanceName = CSettings.Instance.DBInstanceName ?? "MyInstance",
                            DatabaseName = CSettings.Instance.DatabaseName ?? "DB",
                            DBPath = CAppPaths.Instance.DBPath
                        };
                    else if (CSettings.Instance.DBType.ToUpper() == "SQLITE")
                        __db = new CDBSQLite()
                        {
                            DatabaseName = CSettings.Instance.DatabaseName ?? "DB",
                            DBPath = CAppPaths.Instance.DBPath
                        };
                }
                return __db;
            }

            set
            {
                if (__db != null)
                    __db.Disconnect();
                __db = value;
            }
        }
        // ....................................................................



        // --------------------------------------------------------------------------------------
        private CData()
        {
        }
        // --------------------------------------------------------------------------------------
    }
}
