using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.UX.DataForms.TableForm
{
    public class CTableFormStateLoaded: CTableFormState, IFormState
    {
        // --------------------------------------------------------------------------------------
        public CTableFormStateLoaded(CTableFormContext p_oContext) : base(p_oContext)
        {
            //[PATTERNS: State: In the constructor of the state we make any changes to the context, to reflect this state.
            this.context.LoadTable.Visible = true;  // The user is allowed to reload a loaded table
            this.context.SaveChanges.Visible = false; // The user is not allowed to save a loaded table without any changes
            this.context.CancelChanges.Visible = false;
        }
        // --------------------------------------------------------------------------------------

        #region //IFormState\\
        // --------------------------------------------------------------------------------------
        //[PATTERNS] State: This method performs the action, decides if a transition to the next state is done,
        //                  and performs the transition by assigning a new state to the context
        public void PerformAction(String p_sAction)
        {
            // Default value if none of the desired actions are performed
            bool bIsTransitioningToNextState = false;

            // Decision for each different action (generally written, in this specific example it can be simplified)
            if (p_sAction == "CreateRow") 
                bIsTransitioningToNextState = true;
            else if (p_sAction == "EditRow")
                bIsTransitioningToNextState = true;
            else if (p_sAction == "DeleteRow")
                bIsTransitioningToNextState = true;

            if (bIsTransitioningToNextState)
                this.context.State = this.NextState();
        }
        // --------------------------------------------------------------------------------------
        //[PATTERNS] State: This is the state transition method that creates the next state object,
        //                  provides the context to its constructor, and returns an interface reference 
        //                  for the newly created state object.
        public IFormState NextState()
        {
            return new CTableFormStateHasChanges(this.context);
        }
        // --------------------------------------------------------------------------------------
        #endregion
    }
}
