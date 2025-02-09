using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.UX.DataForms.MasterForm
{
    public class CMasterFormStateInitial: CMasterFormState, IFormState
    {
        // --------------------------------------------------------------------------------------
        public CMasterFormStateInitial(CMasterFormContext p_oContext) : base(p_oContext)
        {
            //[PATTERNS: State: In the constructor of the state we make any changes to the context, to reflect this state.
            this.context.Views.SelectedTab = this.context.BrowserView;   // Switch to the browser tab
            this.context.Views.TabPages.Remove(this.context.EntityView); // Hide the entity tab

            this.context.New.Enabled = false;
            this.context.Open.Enabled = false;
            this.context.Delete.Enabled = false;

            this.context.RefreshBrowser.Select(); // The focus is on the first control that will be used.
        }
        // --------------------------------------------------------------------------------------

        #region //IFormState\\
        // --------------------------------------------------------------------------------------
        public void PerformAction(String p_sAction)
        {
            bool bIsTransitioningToNextState = (p_sAction == "LoadBrowser");
            if (bIsTransitioningToNextState)
                this.context.State = this.NextState();

        }
        // --------------------------------------------------------------------------------------
        public IFormState NextState()
        {
            return new CMasterFormStateBrowserLoaded(this.context);
        }
        // --------------------------------------------------------------------------------------
        #endregion
    }
}
