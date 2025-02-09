using System.Collections.Generic;

namespace Lib.Data.DB.Paginator
{
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
                    __endOfRecords = oRecordSet.Count == 0;
            }
            return oRecordSet;
        }
        // --------------------------------------------------------------------------------------
        public bool EndOfRecords { get { return __endOfRecords; } }
        // --------------------------------------------------------------------------------------

        #endregion
    }

}
