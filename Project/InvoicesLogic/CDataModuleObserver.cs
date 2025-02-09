using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Lib.Common.Interfaces;


namespace Invoices.Logic;

public class CDataModuleObserver : List<IDataModule>
{
    private static CDataModuleObserver? __instance = null;

    public static CDataModuleObserver Instance
    {
        get
        {
            if(__instance == null)
            {
                __instance = new CDataModuleObserver();
            }
            return __instance;
        }
    }

    private CDataModuleObserver() { }

    public void Subscribe(IDataModule p_iModule)
    {
        // Add it only once.
        if (this.IndexOf(p_iModule) == -1)
            this.Add(p_iModule);
    }
    // --------------------------------------------------------------------------------
    public void UnSubscribe(IDataModule p_iModule)
    {
        // Remove it if it is subscribed.
        if (this.IndexOf(p_iModule) != -1)
            this.Remove(p_iModule);
    }
    // --------------------------------------------------------------------------------
    public void NotifyAllToReloadLookups()
    {
        foreach (IDataModule iModule in this)
            iModule.ModuleLoadLookups();
    }


}
