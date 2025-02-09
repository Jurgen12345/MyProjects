using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Data.DB.Paginator
{
    //[C#]: This is an example of a static class. Such a class contains only class (static) methods and cannot be used to create objects
    public static class CDBTablePaginatorExtension
    {
        // --------------------------------------------------------------------------------------
        //[C#]: This is an example of an extension method. This is a method that is attached 
        // to the declaration of a class as non-static, allowing all its objects to use it.
        // Extension methods are essential plugins to existing classes.

        // To create this plugin method, we need to declare it as static with the keyword `this` at the start of the parameter list.
        // The class on which this plugin will be added is declared in the method's header after the keyword `this`.

        // This example adds to the CDBMSSQLLocal a factory method named CreatePaginator.
        // An object oDB of this class can call oDB.CreatePaginator<SOME_DATA_TYPE>(...)

        public static IRecordPaginator<T> CreatePaginator<T>(this CDBMSSQLLocal p_oDB, string p_sSelectSQL, string p_sOrderByFields, int p_nPageSize)
        {
            CDBTablePaginator<T> oPaginator = new CDBTablePaginator<T>(p_oDB, p_sSelectSQL, p_sOrderByFields, p_nPageSize);

            return oPaginator as IRecordPaginator<T>;
        }
        // --------------------------------------------------------------------------------------
    }
}
