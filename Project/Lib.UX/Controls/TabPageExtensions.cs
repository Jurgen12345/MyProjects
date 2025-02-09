using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace Lib.UX.Controls
{
    //[C#]: This is an example of a static class. Such a class contains only class (static) methods and cannot be used to create objects
    public static class TabPageExtensions
    {
        // --------------------------------------------------------------------------------------
        //[C#]: This is an example of an extension method. These are object (non-static) methods that are added as plugins to existing classes.
        //      To create this plugin method, we need to declare it as a static with the keyword `this` at the start of the parameter list.
        //      The class on which this plugin will be added is declared in the method's header after the keyword `this`.

        // This adds to the TabPage a method EnableDisableEditors().
        // An object oTab of this class can call oTab.EnableDisableEditors(...)
        public static void EnableDisableEditors(this TabPage p_oTab, bool p_bIsEnabled)
        {
            recurseEnableDisableEditors(p_oTab, p_bIsEnabled);
        }
        // --------------------------------------------------------------------------------------
        private static void recurseEnableDisableEditors(Control p_oParent, bool p_bIsEnabled) 
        {
            // Iterate on all controls under that tab
            foreach (var oControl in p_oParent.Controls)
            {
                if (oControl is TextBox)
                    ((TextBox)oControl).Enabled = p_bIsEnabled;
                else if (oControl is ComboBox)
                    ((ComboBox)oControl).Enabled = p_bIsEnabled;
                else if (oControl is DateTimePicker)
                    ((DateTimePicker)oControl).Enabled = p_bIsEnabled;
                else if (oControl is DataGridView)
                {
                    if (p_bIsEnabled)
                    {
                        ((DataGridView)oControl).RowsDefaultCellStyle.BackColor = SystemColors.Window;
                        ((DataGridView)oControl).RowsDefaultCellStyle.ForeColor = SystemColors.WindowText;
                    }
                    else
                    {
                        ((DataGridView)oControl).RowsDefaultCellStyle.BackColor = SystemColors.ControlLight;
                        ((DataGridView)oControl).RowsDefaultCellStyle.ForeColor = SystemColors.GrayText;
                    }

                    ((DataGridView)oControl).ReadOnly = !p_bIsEnabled;
                    ((DataGridView)oControl).Enabled = true;
                }
                else if (oControl is Panel)
                    recurseEnableDisableEditors((Panel)oControl, p_bIsEnabled);
                else if (oControl is GroupBox)
                    recurseEnableDisableEditors((GroupBox)oControl, p_bIsEnabled);
                else if (oControl is Form)
                    recurseEnableDisableEditors((Form)oControl, p_bIsEnabled);

            }
        }
        // --------------------------------------------------------------------------------------
    }
}
