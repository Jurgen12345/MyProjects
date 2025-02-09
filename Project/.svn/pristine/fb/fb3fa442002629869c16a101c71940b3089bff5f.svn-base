using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoices.Common
{
    public class CAppPaths
    {

        private static CAppPaths? __instance = null;
        public static CAppPaths Instance
        {
            get
            {
                // [PATTERNS] Lazy initialization. The only instance is created at the first time that is needed.
                if (__instance == null)
                    __instance = new CAppPaths();
                return __instance;
            }
        }
        // ....................................................................


        // ....................................................................
        public int SettingsFoldersBack { get; set; }
        // ....................................................................
        public string SettingsPath
        {
            get
            {
                // Back 3 folders that is ..\..\..
                return getParentPath(this.SettingsFoldersBack);
            }
        }
        // ....................................................................
        public int DBPathFoldersBack { get; set; }
        // ....................................................................
        public string DBPath
        {
            get
            {
                // Back 3 folders that is ..\..\..
                return Path.Join(getParentPath(this.DBPathFoldersBack), "DB");
            }

        }
        // ....................................................................
        public string WebRootPath
        {
            get
            {
                // Back 3 folders that is ..\..\..
                return Path.Join(getParentPath(1), "wwwroot");
            }

        }
        // ....................................................................





        // --------------------------------------------------------------------------------------
        private CAppPaths()
        {
            this.DBPathFoldersBack = 4;
            this.SettingsFoldersBack = 4;
        }
        // --------------------------------------------------------------------------------------
        private string getParentPath(int p_nStepsBack)
        {
            // Go back p_nStepsBack folders from the folder from which the executable runs
            string sResult = Environment.CurrentDirectory;
            for (int nPreviousFolder = 1; nPreviousFolder <= p_nStepsBack; nPreviousFolder++)
            {
                var oConfigFolder = Directory.GetParent(sResult);
                if (oConfigFolder != null)
                    sResult = oConfigFolder.FullName;
            }
            return sResult;

        }


    }
}
