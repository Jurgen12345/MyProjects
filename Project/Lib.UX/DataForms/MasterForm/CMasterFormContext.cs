using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lib.UX.DataForms;

namespace Lib.UX.DataForms.MasterForm
{
    public class CMasterFormContext: CDataFormContext
    {

        public TabControl Views { get; set; }
        public TabPage BrowserView { get; set; }
        public TabPage EntityView { get; set; }

        public Button New {get; set; }
        public Button NewEntity { get; set; }
        public Button Open {get; set; }
        public Button Back { get; set; }
        public Button Edit { get; set; }
        public Button Save { get; set; }
        
        public Button Delete { get; set; }
        public Button DeleteEntity { get; set; }
        
        public Button RefreshBrowser {get; set; }
        public Button Cancel { get; set; }

        public DataGridView BrowserGrid { get; set;}


        protected IMasterForm form;

        // --------------------------------------------------------------------------------------
        public CMasterFormContext(IMasterForm p_iForm): base()
        {
            this.form = p_iForm;
        }
        // --------------------------------------------------------------------------------------
        private void doRefreshBrowser()  // [PATTERNS] Template Method:
        {
            if (form.ModuleLoadBrowser())
            {
                form.WriteBrowserListToTheUI();
                this.PerformAction("LoadBrowser");
            }
            else
                MessageBox.Show(form.LastErrorMessage(), " Error");
        }
        // --------------------------------------------------------------------------------------
        private void doShowBrowser()
        {
            this.PerformAction("ShowBrowser");
        }
        // --------------------------------------------------------------------------------------
        private void doNew()  
        {
            if (form.ModuleNew())
            {
                form.WriteMasterToUI();
                form.WriteDetailListToUI();
                this.PerformAction("NewEntity");
            }
            else
                MessageBox.Show(form.LastErrorMessage(), " Error");
        }
        // --------------------------------------------------------------------------------------
        private bool doOpen()   
        {
            bool bResult = false;
            if (form.HasSelectedInBrowser())
            {
                if (form.ModuleLoadEntity())
                {
                    this.PerformAction("OpenEntity");
                    form.WriteMasterToUI();
                    form.WriteDetailListToUI();
                    bResult = true;
                }
                else
                    MessageBox.Show(form.LastErrorMessage(), " Error");
            }
            return bResult;
        }
        // --------------------------------------------------------------------------------------
        private void doEdit()
        {
            if (form.IsModuleLoaded())
            { 
                form.WriteMasterToUI();
                form.WriteDetailListToUI();
                this.PerformAction("EditEntity");
            }
        }
        // --------------------------------------------------------------------------------------
        private void doSave()   
        {
            DialogResult oResult = MessageBox.Show("Save changes?", "Warning", MessageBoxButtons.YesNo
                                        , MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            if (oResult == DialogResult.Yes)
            {
                form.ReadMasterFromUI();
                if (form.ModuleSave())
                {
                    if (form.ModuleLoad())
                    {
                        form.WriteMasterToUI();
                        form.WriteDetailListToUI();
                        this.PerformAction("SaveEntity");
                    }
                    else
                        MessageBox.Show(form.LastErrorMessage(), " Error");
                }
                else
                    MessageBox.Show(form.LastErrorMessage(), " Error");
            }
        }
        // --------------------------------------------------------------------------------------
        private void doCancel()
        {
            if (form.ModuleLoad())
            {
                form.WriteMasterToUI();
                form.WriteDetailListToUI();
                this.PerformAction("Cancel");
            }
        }
        // --------------------------------------------------------------------------------------
        private void doDelete(bool p_bIsDeletionFromBrowser)    
        {
            DialogResult oResult = MessageBox.Show("Are you sure you want to delete this user?", "Warning", MessageBoxButtons.YesNo
                                        , MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (oResult == DialogResult.Yes)
            {
                bool bCanDelete = true;
                if (p_bIsDeletionFromBrowser)
                    // If the deletion is done from the browser view, we should first succesfully
                    // load the entity and then delete it.
                    bCanDelete = doOpen();

                if (bCanDelete)
                {
                    if (form.ModuleDelete())
                    { 
                        this.PerformAction("DeleteEntity");
                        // Reloads the browser after the deletion
                        doRefreshBrowser();
                    }
                    else
                        MessageBox.Show(form.LastErrorMessage(), " Error");

                }
            }
        }
        // --------------------------------------------------------------------------------------
        public bool HandleEvent(Object sender)
        {
            bool bIsHandled = true;
            if (sender == RefreshBrowser)
                doRefreshBrowser();
            else if ( (sender == Back)  ||  ((sender == Views) && (Views.SelectedIndex == 0)) )
            {  
                doShowBrowser();
                doRefreshBrowser();
            }
            else if ((sender == Open) || (sender == BrowserGrid))
                doOpen();
            else if (sender == Edit)
                doEdit();
            else if (sender == Save)
                doSave();
            else if ((sender == New) || (sender == NewEntity))
                doNew();
            else if ((sender == Delete) || (sender == DeleteEntity))
                doDelete(sender == Delete);
            else if (sender == Cancel)
                doCancel();
            else
                bIsHandled = false;
            return bIsHandled;
        }
        // --------------------------------------------------------------------------------------

    }
}
