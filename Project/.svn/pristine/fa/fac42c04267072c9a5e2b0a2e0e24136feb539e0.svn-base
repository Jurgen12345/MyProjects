using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Invoices.Logic.DataModules;
using Invoices.Logic.Entities;

namespace Invoices.UX.WinForms
{
    public partial class CFormTableItem : CFormTemplateTable
    {

        private CDMItem module;
        public CFormTableItem()
        {
            InitializeComponent();
            this.module = new CDMItem();
        }

        protected override void DisplayModelEntitiesOnGrid()
        {
            editableGridRecords.Populate<CItem>(this.module.Model);
        }

        protected override bool IsModuleLoaded()
        {
            return this.module.IsLoaded;
        }

        protected override bool LoadModule()
        {
            return this.module.ModuleLoad();
        }

        protected override bool SaveModule()
        {
            return this.module.ModuleSave();
        }

        protected override string LastErrorMessage()
        {
            return this.module.LastError;
        }




    }
}
