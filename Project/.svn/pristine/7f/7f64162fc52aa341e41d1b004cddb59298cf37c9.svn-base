using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.UX.DataForms.TableForm
{
    public class CTableFormStateInitial: CTableFormState, IFormState
    {
        // --------------------------------------------------------------------------------------
        public CTableFormStateInitial(CTableFormContext p_oContext) : base(p_oContext)
        {
            //[PATTERNS: State: In the constructor of the state we make necessary changes to the context, to reflect this state.
            this.context.LoadTable.Visible = true;
            this.context.SaveChanges.Visible = false;
            this.context.CancelChanges.Visible = false;
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
