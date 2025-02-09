using System.Collections.Generic;

namespace Lib.Data.DB
{
    // =========================================================================================================
    public class CDBTablePaginator<T> : IRecordPaginator<T>
    {
        private CDBMSSQLLocal __db;
        private string __selectSQL;
        private string __orderByFields;
        // ....................................................................
        private int __pageSize;
        public int PageSize { get { return __pageSize; } }
        // ....................................................................
        private int __startRecordIndex = 0;
        private bool __endOfRecords = false;

        // --------------------------------------------------------------------------------------
        public CDBTablePaginator(CDBMSSQLLocal p_oDB, string p_sSelectSQL, string p_sOrderByFields, int p_nPageSize)
        {
            __db = p_oDB;
            __selectSQL = p_sSelectSQL;
            __pageSize = p_nPageSize;
            __orderByFields = p_sOrderByFields;
        }
        // --------------------------------------------------------------------------------------


        #region // IRecordPaginator \\
        // --------------------------------------------------------------------------------------
        public List<T>? First()
        {
            __startRecordIndex = -__pageSize; // So the call to Next() will make it 0.
            __endOfRecords = false;
            return Next();
        }
        // --------------------------------------------------------------------------------------
        public List<T>? Next()
        {
            List<T>? oRecordSet = null;
            if (!__endOfRecords)
            { 
                __startRecordIndex += __pageSize;
                string sSQL = __selectSQL
                              + $"\r\nORDER BY {__orderByFields}"
                              + $"\r\nOFFSET {__startRecordIndex} ROWS"
                              + $"\r\nFETCH NEXT {__pageSize} ROWS ONLY";

                oRecordSet = __db.Select<T>(sSQL);
                
                if (oRecordSet == null)
                    __endOfRecords = true;
                else
                    __endOfRecords = (oRecordSet.Count == 0);
            }
            return oRecordSet;
        }
        // --------------------------------------------------------------------------------------
        public bool EndOfRecords { get { return __endOfRecords; } }
        // --------------------------------------------------------------------------------------

        #endregion
    }
    // =========================================================================================================
    //[C#]: This is an example of a static class. Such a class contains only class (static) methods and cannot be used to create objects
    public static class CDBMSSQLLocalExtensions
    {
        // --------------------------------------------------------------------------------------
        //[C#]: This is an example of an extension method. These are object (non-static) methods that are added as plugins to existing classes.
        //      To create this plugin method, we need to declare it as a static with the keyword `this` at the start of the parameter list.
        //      The class on which this plugin will be added is declared in the method's header after the keyword `this`.

        // This adds to the CDBMSSQLLocal a factory method named CreatePaginator.
        // An object oDB of this class can call oDB.CreatePaginator<SOME_DATA_TYPE>(...)

        public static IRecordPaginator<T> CreatePaginator<T>(this CDBMSSQLLocal p_oDB, string p_sSelectSQL, string p_sOrderByFields, int p_nPageSize)
        {
            CDBTablePaginator<T> oPaginator = new CDBTablePaginator<T>(p_oDB, p_sSelectSQL, p_sOrderByFields, p_nPageSize);

            return oPaginator as IRecordPaginator<T>;
        }
        // --------------------------------------------------------------------------------------
    }
    // =========================================================================================================

}
