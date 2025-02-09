using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Common.Interfaces
{
    public interface IDBTable
    {
        public IList RecordSet { get; }
        public string TableName { get; set; }
        public void LoadRecord(int p_nKeyValue);
        public void LoadTable(IDbTransaction? p_iTransaction, int p_nMasterKeyValue);
        public void LoadTable(IDbTransaction? p_iTransaction);
        public void SaveTable(IDbTransaction? p_iTransaction) { }

    }
}
