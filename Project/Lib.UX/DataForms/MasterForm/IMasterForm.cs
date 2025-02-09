using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.UX.DataForms.MasterForm
{
    public interface IMasterForm
    {
        
        public bool ModuleLoadLookups();
        public bool ModuleLoadBrowser();
        public bool HasSelectedInBrowser();
        public bool IsModuleLoaded();
        public bool ModuleNew();
        public bool ModuleLoadEntity();
        public bool ModuleLoad();
        public bool ModuleSave();
        public bool ModuleDelete();
        public string LastErrorMessage();
        public void WriteBrowserListToTheUI();
        public void WriteMasterToUI();
        public void ReadMasterFromUI();
        public void WriteDetailListToUI();
    }
}
