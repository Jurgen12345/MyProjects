using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Invoices.Logic.DataModules;
using Invoices.Logic.Entities;

using Invoices.UX.WinForms;
using Lib.UX.DataForms;

namespace Invoices.UX.Builders
{
    public class CFormAppInvoicesBuilder : CMasterFormBuilder
    {
        protected CDMAppInvoices module;
        protected IBrowserViewForm browserView;
        protected Form entityView;

        public override void BuildDataModule()
        {
            this.module = new CDMAppInvoices();
        }

        public override void BuildBrowserView()
        {
            this.browserView = new CViewBrowserDefault<CAppInvoices>(this.module.BrowserModel);
        }

        public override void BuildEntityView()
        {
            this.entityView = new CViewEntityAppInvoice();
        }

        public override void BuildForm()
        {
            this.Product = new CFormTemplateMaster(module,browserView,entityView);
        }

    }
}
