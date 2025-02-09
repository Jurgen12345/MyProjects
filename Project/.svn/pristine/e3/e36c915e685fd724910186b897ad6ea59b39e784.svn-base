using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.UX.DataForms.TableForm
{
    public class CTableFormStateHasChanges: CTableFormState, IFormState
    {
        // --------------------------------------------------------------------------------------
        public CTableFormStateHasChanges(CTableFormContext p_oContext) : base(p_oContext)
        {
            //[PATTERNS: State: In the constructor of the state we make any changes to the context, to reflect this state.
            this.context.LoadTable.Visible = false;  // The user is not allowed to reload and lose change
            this.context.SaveChanges.Visible = true; // The user can save changes
            this.context.CancelChanges.Visible = true; // The user can cancel changes
        }
        // --------------------------------------------------------------------------------------

        #region //IFormState\\
        // --------------------------------------------------------------------------------------
        public void PerformAction(String p_sAction)
        {
            bool bIsTransitioningToNextState = (p_sAction == "TableLoaded");
            if (bIsTransitioningToNextState)
                this.context.State = this.NextState();
        }
        // --------------------------------------------------------------------------------------
        public IFormState NextState()
        {
            return new CTableFormStateLoaded(this.context);
        }
        // --------------------------------------------------------------------------------------
        #endregion
    }
}
