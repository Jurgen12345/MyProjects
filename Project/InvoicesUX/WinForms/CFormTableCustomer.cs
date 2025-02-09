using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Invoices.Logic.DataModules;
using Invoices.Logic.Entities;
using Invoices.UX;

namespace Invoices.UX.WinForms
{
    public partial class CFormTableCustomer : CFormTemplateTable
    {
        protected CDMCustomer module;
        public CFormTableCustomer()
        {
            InitializeComponent();
            this.module = new CDMCustomer();
        }
        protected override void DisplayModelEntitiesOnGrid()
        {
            editableGridRecords.Populate<CCustomer>(this.module.Model);
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
