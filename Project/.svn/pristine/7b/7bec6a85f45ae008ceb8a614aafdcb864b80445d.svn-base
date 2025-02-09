using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.UX.DataForms.MasterForm
{
    public class CMasterFormStateBrowserLoaded : CMasterFormState, IFormState
    {
        // --------------------------------------------------------------------------------------
        public CMasterFormStateBrowserLoaded(CMasterFormContext p_oContext) : base(p_oContext)
        {
            //[PATTERNS: State: In the constructor of the state we make any changes to the context, to reflect this state.
            this.context.Views.TabPages.Remove(this.context.EntityView); // Hide the entity tab

            if (this.context.Views.TabPages.IndexOf(this.context.BrowserView) < 0)
                this.context.Views.TabPages.Insert(0, this.context.BrowserView); // Show the browser tab
            this.context.Views.SelectedTab = this.context.BrowserView;   // Switch to the browser tab
            this.context.EntityView.Visible = false;
            this.context.BrowserGrid.Focus();


            this.context.New.Enabled = true;
            this.context.Open.Enabled = true;
            this.context.Delete.Enabled = true;

            this.context.NewEntity.Enabled = true;
            this.context.DeleteEntity.Enabled = false;
            this.context.Save.Visible = false;
            this.context.Cancel.Visible = false;

        }
        // --------------------------------------------------------------------------------------

        #region //IFormState\\
        // --------------------------------------------------------------------------------------
        public void PerformAction(String p_sAction)
        {
            if (p_sAction == "OpenEntity")
                this.context.State = this.NextState();
            else if (p_sAction == "NewEntity")
                this.context.State = new CMasterFormStateNewEntity(this.context);
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
