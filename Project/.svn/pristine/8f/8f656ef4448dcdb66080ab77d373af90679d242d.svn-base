using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Lib.UX.Controls;

namespace Lib.UX.DataForms.MasterForm
{
    public class CMasterFormStateNewEntity : CMasterFormState, IFormState
    {
        // --------------------------------------------------------------------------------------
        public CMasterFormStateNewEntity(CMasterFormContext p_oContext) : base(p_oContext)
        {
            //[PATTERNS: State: In the constructor of the state we make any changes to the context, to reflect this state.
            this.context.Views.TabPages.Remove(this.context.BrowserView); // Hide the browser tab
            if (this.context.Views.TabPages.IndexOf(this.context.EntityView) < 0)
                this.context.Views.TabPages.Add(this.context.EntityView); // Show the entity tab
            this.context.Views.SelectedTab = this.context.EntityView;   // Switch to the entity tab

            this.context.EntityView.EnableDisableEditors(true);

            this.context.Edit.Visible = false;

            this.context.New.Enabled = false;
            this.context.Open.Enabled = false;
            this.context.Delete.Enabled = false;

            this.context.NewEntity.Enabled = false;
            this.context.DeleteEntity.Enabled = false;
            
            this.context.Save.Visible = true;
            this.context.Save.Enabled = true;
            this.context.Cancel.Visible = true;
            this.context.Cancel.Enabled = true;

        }
        // --------------------------------------------------------------------------------------

        #region //IFormState\\
        // --------------------------------------------------------------------------------------
        public void PerformAction(String p_sAction)
        {
            if (p_sAction == "SaveEntity")
                this.context.State = this.NextState();
            else if (p_sAction == "Cancel")
                // If the user cancels a new record then it will switch back to the browser.
                this.context.State = new CMasterFormStateBrowserLoaded(this.context);
        }
        // --------------------------------------------------------------------------------------
        public IFormState NextState()
        {
            return new CMasterFormStateOpenedEntity(this.context);
        }
        // --------------------------------------------------------------------------------------
        #endregion
    }
}
