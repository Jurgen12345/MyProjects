using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Data.DB
{
    public interface IDatabase
    {
        public string LastSQL { get; }
        public string DatabaseName { get; set; }

        public bool Connect();
        public void Disconnect();
        public IDbTransaction BeginTransaction();
        public List<T>? Select<T>(string p_sSQL);
        public List<T>? Select<T>(string p_sSQL, IDbTransaction? p_iTransaction);
        public List<T>? SelectWithParams<T>(string p_sSQL, object? p_oParams, IDbTransaction p_iTransaction);
        public int Execute<T>(string p_sSQL, T p_oParams, IDbTransaction p_iTransaction);
        public int Insert<T>(string p_sInsertSQL, T p_oRecord, IDbTransaction p_iTransaction);
        public void SaveChanges<T>(List<T> p_oTable, string p_sInsertSQL, string p_sUpdateSQL, string p_sDeleteSQL) where T : CDBRecord;
        public void SaveChanges<T>(List<T> p_oTable, string p_sInsertSQL, string p_sUpdateSQL, string p_sDeleteSQL, IDbTransaction? p_iTransaction) where T : CDBRecord;
    }
}
