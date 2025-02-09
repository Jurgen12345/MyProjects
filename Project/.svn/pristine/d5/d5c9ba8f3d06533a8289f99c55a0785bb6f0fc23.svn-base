using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Invoices.Logic.Models;
using Lib.Common.Interfaces;

namespace Invoices.Logic.DataModules
{
    public class CDMCustomer : CDataModule, IDataModuleSimple
    {
        public CCustomerModel Model { get { return (CCustomerModel)this.model; } }


        public CDMCustomer() : base()
        {
            this.model = new CCustomerModel(false);
        }

        public bool ModuleLoad()
        {
            bool bResult = false;
            try
            {
                Model?.Table.LoadTable(null);
                Model?.AcceptVisitAfterLoad(this.entityLoader);
                this.IsLoaded= true;
                bResult = true;
            }
            catch (Exception oException)
            {
                this.LastError = oException.Message;
            }
            return bResult;
        }


        public bool ModuleSave()
        {
            bool bResult = false;
            try
            {
                Model?.AcceptVisitBeforeSave(this.recordAdder);
                Model?.Table.SaveTable(null);

                //[PATTERNS] Observer: We send a notification to all modules to reload their lookups.
                // For example: We have saved a new record and we would like it to become immediately available
                // to any other module/form that uses this as a lookup table.
                CDataModuleObserver.Instance.NotifyAllToReloadLookups();

                bResult = true;
            }
            catch (Exception oException)
            {
                this.LastError = oException.Message;
            }
            return bResult;
        }

    }
}
