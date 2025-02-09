using Invoices.Logic.Visitors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoices.Logic
{
    public class CDataModule
    {

        private static int _nextModuleID = 1;

        private int _moduleID;

        public int ModuleID { get { return _moduleID; } }
        public string LastError { get; set; }
        public bool IsLoaded { get; set; }
        protected Object model = null;
        protected CVisitorEntityLoader entityLoader;
        protected CVisitorRecordAdder recordAdder;

        public CDataModule()
        {
            _moduleID = _nextModuleID;
            _nextModuleID++;
            LastError = "";
            IsLoaded = false;
            this.entityLoader = new CVisitorEntityLoader();
            this.recordAdder = new CVisitorRecordAdder();
        }

    }
}
