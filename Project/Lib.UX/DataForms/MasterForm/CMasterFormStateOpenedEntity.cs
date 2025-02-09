using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Lib.UX.Controls;

namespace Lib.UX.DataForms.MasterForm
{
    public class CMasterFormStateOpenedEntity : CMasterFormState, IFormState
    {
        // --------------------------------------------------------------------------------------
        public CMasterFormStateOpenedEntity(CMasterFormContext p_oContext) : base(p_oContext)
        {
            //[PATTERNS: State: In the constructor of the state we make any changes to the context, to reflect this state.
            if (this.context.Views.TabPages.IndexOf(this.context.BrowserView) < 0)
                this.context.Views.TabPages.Insert(0, this.context.BrowserView); // Show the browser tab
            if (this.context.Views.TabPages.IndexOf(this.context.EntityView) < 0)
                this.context.Views.TabPages.Add(this.context.EntityView); // Show the entity tab
            this.context.Views.SelectedTab = this.context.EntityView;    // Switch to the entity tab

            this.context.EntityView.EnableDisableEditors(false);

            this.context.Edit.Visible = true;

            this.context.New.Enabled = true;
            this.context.Open.Enabled = true;
            this.context.Edit.Enabled = true;
            this.context.Delete.Enabled = true;

            this.context.NewEntity.Enabled = true;
            this.context.DeleteEntity.Enabled = true;

            this.context.Save.Visible = false;
            this.context.Cancel.Visible = false;
        }
        // --------------------------------------------------------------------------------------

        #region //IFormState\\
        // --------------------------------------------------------------------------------------
        public void PerformAction(String p_sAction)
        {
            if (p_sAction == "EditEntity")
                this.context.State = this.NextState();
            else if ((p_sAction == "DeleteEntity") || (p_sAction == "ShowBrowser"))
                this.context.State = new CMasterFormStateBrowserLoaded(this.context);
            else if (p_sAction == "NewEntity")
                this.context.State = new CMasterFormStateNewEntity(this.context);
        }
        // --------------------------------------------------------------------------------------
        public IFormState NextState()
        {
            return new CMasterFormStateEditingEntity(this.context);
        }
        // --------------------------------------------------------------------------------------
        #endregion
    
    }
}
