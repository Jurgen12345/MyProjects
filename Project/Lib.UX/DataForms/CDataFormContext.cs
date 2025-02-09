using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.UX.DataForms
{
    public class CDataFormContext
    {
        // ........................................................................
        //[PATTERNS]: State: An interface reference to the current state is kept on the form's context object
        internal IFormState? __state = null;
        public IFormState? State { get { return __state; } set { __state = value; } }
        // ........................................................................

        // --------------------------------------------------------------------------------------
        public CDataFormContext()
        {
        }
        // --------------------------------------------------------------------------------------
        //[ADVANCED OO]
        // Up to this point, you might have seen only references to objects and interfaces.
        // This method's parameter receives a references to a class type, that is provided by the client code (caller).
        // The caller uses typeof({some class}) to create a class type reference.
        public void Initialize(Type p_tStateClass)
        {
            //[ADVANCED OO] [DYNAMIC INSTANTIATION]
            // We can use a class type reference variable to instantiate an object dynamically, 
            // that is called dynamic instantitation. In C#/.Net the mechanism that supports that is called reflection.
            // The CreateInstance() method accepts a class and a list of parameters for the constructor,
            // here only one parameter in which we supply `this`.
            
            Object? oState = Activator.CreateInstance(p_tStateClass, this);
            this.__state = oState as IFormState;
        }
        // --------------------------------------------------------------------------------------
        //[PATTERNS] State: The context performs some action on the current state.
        public void PerformAction(String p_sAction)
        {
            if (__state != null) 
                __state.PerformAction(p_sAction);
        }
        // --------------------------------------------------------------------------------------

    }
}
