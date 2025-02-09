using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Lib.Common.Attribs;

namespace Lib.UX.DataGrid
{
    //[C#]: This is an example of a static class. Such a class contains only class (static) methods and cannot be used to create objects
    public static class DataGridViewExtensions
    {
        // --------------------------------------------------------------------------------------
        //[C#]: This is an example of an extension method. These are object (non-static) methods that are added as plugins to existing classes.
        //      To create this plugin method, we need to declare it as a static with the keyword `this` at the start of the parameter list.
        //      The class on which this plugin will be added is declared in the method's header after the keyword `this`.

        // This adds to the DataGridView a factory method named SetColumnSizes.
        // An object oGrid of this class can call oGrid.SetColumnSizes(...)

        public static void SetColumnSizes(this DataGridView p_oGrid, Type p_tClass)
        {   
            // [C#] [Advanced] Iterate on all properties of the given class type to find our custom attribute [ColumnWidth()]
            foreach (var oProperty in p_tClass.GetProperties())
            {
                var oColumnSizeAttrib = oProperty.GetCustomAttribute<ColumnWidth>();
                if (oColumnSizeAttrib != null)
                {   // If the property has the ColumnWidth attribute find a column that has the same name with the property
                    var oColumn = p_oGrid.Columns[oProperty.Name];
                    if (oColumn != null)
                    {
                        // Set the width to the column
                        oColumn.Width = oColumnSizeAttrib.Width;
                    }
                }
            }
        }
        // --------------------------------------------------------------------------------------
    }
}
