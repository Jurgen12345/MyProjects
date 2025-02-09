using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

// LOOSELY-COUPLED DESIGN: There are no dependencies to custom code, and this template form could be moved to the library
using Lib.Common.Interfaces;
using Lib.Logic;
using Lib.UX.DataForms.MasterForm;
using Lib.UX.DataForms;
using Lib.UX.DataGrid;
using Invoices.Data;
using Invoices.Logic;

namespace Invoices.UX
{
    // ....................................................................
    public partial class CFormTemplateMaster : Form, IMasterForm
    {
        // ....................................................................
        protected IDataModule module;
        public IDataModule Module { get { return module; } }
        // ....................................................................
        protected CMasterFormContext formContext;
        public CMasterFormContext FormContext { get { return formContext; } }
        // ....................................................................
        protected IBrowserViewForm browserView;
        // ....................................................................
        protected IEntityViewForm? entityView;
        // ....................................................................
        protected CBrowserGridDecorator browserGrid;
        public CBrowserGridDecorator BrowserGrid {  get { return browserGrid; } }
        // ....................................................................
        // Support for multiple detail grids
        protected List<CEditableGridDecorator> detailGrids = new List<CEditableGridDecorator>();
        public List<CEditableGridDecorator> DetailGrids {  get { return detailGrids; } }
        // ....................................................................


        // --------------------------------------------------------------------------------------
        public CFormTemplateMaster(IDataModule p_iModule, IBrowserViewForm p_iBrowserView, Form p_oEntityView)
        {
            InitializeComponent();
            
            this.module = p_iModule;
            
            //[PATTERNS] Observer: Subscribe this form's data module to receive notifications by the observer (publisher)
            CDataModuleObserver.Instance.Subscribe(this.module);

            this.formContext = new CMasterFormContext(this)
            {
                Views = this.tabPages,
                BrowserView = this.tabViewBrowser,
                EntityView = this.tabViewEntity,
                New = this.btnNew,
                NewEntity = this.btnEntityNew,
                Open = this.btnOpen,
                Back = this.btnBackToBrowser,
                Edit = this.btnEdit,
                Save = this.btnSave,
                Delete = this.btnDelete,
                DeleteEntity = this.btnEntityDelete,
                RefreshBrowser = this.btnRefreshBrowser,
                BrowserGrid = this.dgvBrowser,
                Cancel = this.btnCancel
            };
            this.formContext.Initialize(typeof(CMasterFormStateInitial));
            
            this.browserGrid = new CBrowserGridDecorator(this.dgvBrowser, this.formContext);
            this.browserView = p_iBrowserView;
            this.browserView.SetParent(this);
            this.browserView.Dock(this.pnlBrowser);

            this.entityView = p_oEntityView as IEntityViewForm;
            if (this.entityView != null)
            {
                this.entityView.SetParent(this);

                // [.NET WINFORMS | ADVANCED] Hosting a form inside another form's panel
                p_oEntityView.TopLevel = false;
                p_oEntityView.FormBorderStyle = FormBorderStyle.None;
                p_oEntityView.Dock = DockStyle.Fill;
                this.pnlEntityView.Controls.Add(p_oEntityView);
                p_oEntityView.Show();
            }

            // We load all lookups during the startup of the form
            if (!ModuleLoadLookups())
                MessageBox.Show(LastErrorMessage(), "Error");
        }
        // --------------------------------------------------------------------------------------
        private void DoOnFormClosed(object sender, FormClosedEventArgs e)
        {
            //[PATTERNS] Observer: Unsubscribe this form's data module because its form has been destroyed.
            CDataModuleObserver.Instance.UnSubscribe(this.module);
        }
        // --------------------------------------------------------------------------------------
        private void DoOnAnyCommand(object sender, EventArgs e)
        {
            this.formContext.HandleEvent(sender);
        }
        // --------------------------------------------------------------------------------------


        #region // IMasterForm \\
        // --------------------------------------------------------------------------------------
        // [C#] We are using the lamda operator => to create expression-bodied methods,
        // since most of them had a single expression in their body.
        public bool ModuleLoadLookups() => this.module.ModuleLoadLookups();   // [PATTERNS] Proxy
        // --------------------------------------------------------------------------------------
        public bool ModuleLoadBrowser() => this.module.ModuleLoadBrowser();   // [PATTERNS] Proxy
        // --------------------------------------------------------------------------------------
        public bool IsModuleLoaded() => this.module.IsLoaded;   // [PATTERNS] Proxy
        // --------------------------------------------------------------------------------------
        public bool ModuleNew() => this.module.ModuleNew();  // [PATTERNS] Proxy
        // --------------------------------------------------------------------------------------
        public bool HasSelectedInBrowser() => this.browserView.HasSelectedInBrowser; // [PATTERNS] Proxy
        // --------------------------------------------------------------------------------------
        public bool ModuleLoadEntity()
        {
            // We give the event handler to each grid decorator, to attach it to new entities that it adds
            foreach(var oDetailGrid in this.detailGrids)
                oDetailGrid.EntityChangeHandler += this.module.ModuleOnAnyEntityChange;
            
            IEntity? oCurrentEntity = this.browserView.SelectedEntity;
            if (oCurrentEntity != null)
            { 
                this.module.MasterKeyValue = oCurrentEntity.PrimaryKeyValue;
                return this.module.ModuleLoad();
            }
            else
                return false;
        }
        // --------------------------------------------------------------------------------------
        public bool ModuleLoad() => this.module.ModuleLoad();  // [PATTERNS] Proxy
        // --------------------------------------------------------------------------------------
        public bool ModuleSave() => this.module.ModuleSave();   // [PATTERNS] Proxy
        // --------------------------------------------------------------------------------------
        public bool ModuleDelete() => this.module.ModuleDelete();  // [PATTERNS] Proxy
        // --------------------------------------------------------------------------------------
        public string LastErrorMessage()
        {
            // Here you can modify the error that will be shown to the user, before returning it
            return this.module.LastError;   // [PATTERNS] Proxy
        }
        // --------------------------------------------------------------------------------------
        public void WriteBrowserListToTheUI() => browserView?.WriteBrowserListToTheUI(); // [PATTERNS] Proxy;
        // --------------------------------------------------------------------------------------
        public void WriteMasterToUI() => entityView?.WriteMasterToUI(); // [PATTERNS] Proxy;
        // --------------------------------------------------------------------------------------
        public void ReadMasterFromUI() => entityView?.ReadMasterFromUI(); // [PATTERNS] Proxy;
        // --------------------------------------------------------------------------------------
        public void WriteDetailListToUI() => entityView?.WriteDetailListToUI(); // [PATTERNS] Proxy;
        // --------------------------------------------------------------------------------------
        #endregion
    }
}
