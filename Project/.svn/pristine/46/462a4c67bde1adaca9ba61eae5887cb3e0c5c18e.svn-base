using System;
using System.Collections.Generic;
using System.Data;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;

using Dapper;
using System.Data.SQLite;

namespace Lib.Data.DB
{
    // Class for interaction with a SQLite database that supports an Object Persistence Framework (OPF)
    public class CDBSQLite: IDBFileBased
    {
        // ....................................................................
        private bool __isConnected = false;
        private SQLiteConnection? __connection = null;
        protected SQLiteConnection connection
        {
            get
            {
                // Lazy initialization. The only instance is created at the first time that it is needed.
                if (__connection == null)
                {
                    string sConnectionString = $"Data Source={DBFileName};Version=3;";
                    __connection = new SQLiteConnection(sConnectionString);
                }
                return __connection;
            }
            set
            {
                if (__connection != null)
                {
                    __connection.Close();
                    __connection.Dispose();
                }
                __connection = value;
            }
        }
        // ....................................................................
        public string __lastSQL = string.Empty;
        public string LastSQL { get { return __lastSQL; } }
        // ....................................................................

        public string DatabaseName { get; set; }
        public string DBPath { get; set; }
        public string DBFileName { get { return Path.Combine(DBPath, DatabaseName + ".db"); } }

        // --------------------------------------------------------------------------------------
        public CDBSQLite()
        {

        }
        // --------------------------------------------------------------------------------------
        public bool Connect()
        {
            if (!__isConnected)
            {
                try
                {
                    connection.Open();
                    __isConnected = true;
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message);
                }
            }
            return __isConnected;
        }
        // --------------------------------------------------------------------------------------
        public void Disconnect()
        {
            if (__isConnected)
            {
                connection.Close();
                connection.Dispose();
                __connection = null;
                __isConnected = false;
            }
        }
        // --------------------------------------------------------------------------------------
        public IDbTransaction BeginTransaction()
        {
            if (Connect())
                return connection.BeginTransaction();
            else
                throw new Exception("Cannot connect to the database.");
        }
        // --------------------------------------------------------------------------------------
        public List<T>? Select<T>(string p_sSQL)
        {
            return Select<T>(p_sSQL, null);
        }
        // --------------------------------------------------------------------------------------
        public List<T>? Select<T>(string p_sSQL, IDbTransaction? p_iTransaction)
        {
            List<T>? oRecordSet = null;
            if (Connect())
            {
                oRecordSet = connection.Query<T>(p_sSQL, null, p_iTransaction).ToList();
                __lastSQL = p_sSQL;
            }
            return oRecordSet;
        }
        // --------------------------------------------------------------------------------------
        public List<T>? SelectWithParams<T>(string p_sSQL, object? p_oParams, IDbTransaction p_iTransaction)
        {
            List<T>? oRecordSet = null;
            if (Connect())
            {
                oRecordSet = connection.Query<T>(p_sSQL, p_oParams, p_iTransaction).ToList();
                __lastSQL = p_sSQL;
            }
            return oRecordSet;
        }
        // --------------------------------------------------------------------------------------
        public int Execute<T>(string p_sSQL, T p_oParams, IDbTransaction p_iTransaction)
        {
            int nRowsAffected = 0;
            if (Connect())
            {
                nRowsAffected = connection.Execute(p_sSQL, p_oParams, p_iTransaction);
                __lastSQL = p_sSQL;
            }
            return nRowsAffected;
        }
        // --------------------------------------------------------------------------------------
        public int Insert<T>(string p_sInsertSQL, T p_oRecord, IDbTransaction p_iTransaction)
        {
            if (!p_sInsertSQL.Trim().ToUpper().StartsWith("INSERT"))
                throw new Exception("Not a valid SQL INSERT statement");

            int nID = -1;
            if (Connect())
            {
                // Use last_insert_rowid() in SQLite to retrieve the last inserted ID.
                string sSQL = p_sInsertSQL + ";SELECT last_insert_rowid();";
                nID = connection.QuerySingle<int>(sSQL, p_oRecord, p_iTransaction);
                __lastSQL = sSQL;
            }
            return nID;
        }
        // --------------------------------------------------------------------------------------
        public void SaveChanges<T>(List<T> p_oTable, string p_sInsertSQL, string p_sUpdateSQL, string p_sDeleteSQL) where T : CDBRecord
        {
            SaveChanges(p_oTable, p_sInsertSQL, p_sUpdateSQL, p_sDeleteSQL, null);
        }
        // --------------------------------------------------------------------------------------
        public void SaveChanges<T>(List<T> p_oTable, string p_sInsertSQL, string p_sUpdateSQL, string p_sDeleteSQL, IDbTransaction? p_iTransaction) where T : CDBRecord
        {
            if (!p_sInsertSQL.Trim().ToUpper().StartsWith("INSERT"))
                throw new Exception("Not a valid SQL INSERT statement");
            if (!p_sUpdateSQL.Trim().ToUpper().StartsWith("UPDATE"))
                throw new Exception("Not a valid SQL UPDATE statement");
            if (!p_sDeleteSQL.Trim().ToUpper().StartsWith("DELETE"))
                throw new Exception("Not a valid SQL DELETE statement");

            string? sPrimaryKeyName = null;
            List<T> oDeletedRecs = new List<T>();
            List<T> oUpdatedRecs = new List<T>();
            List<T> oNewRecs = new List<T>();

            foreach (T oRecord in p_oTable)
            {
                if (sPrimaryKeyName == null)
                    sPrimaryKeyName = oRecord.PrimaryKeyName;

                if (oRecord.IsDeleted)
                    oDeletedRecs.Add(oRecord);
                else if (oRecord.IsUpdated)
                    oUpdatedRecs.Add(oRecord);
                else if (oRecord.IsNew)
                    oNewRecs.Add(oRecord);
            }

            if (p_iTransaction != null)
            {
                foreach (T oRecord in oDeletedRecs)
                    Execute(p_sDeleteSQL, oRecord, p_iTransaction);

                foreach (T oRecord in oUpdatedRecs)
                    Execute(p_sUpdateSQL, oRecord, p_iTransaction);

                if (sPrimaryKeyName == "ID")
                    foreach (T oNewRecord in oNewRecs)
                    {
                        int nID = Insert(p_sInsertSQL, oNewRecord, p_iTransaction);
                        oNewRecord.PrimaryKeyValue = nID;
                    }
                else
                    foreach (T oNewRecord in oNewRecs)
                        Execute(p_sInsertSQL, oNewRecord, p_iTransaction);
            }
            else
            {
                using (IDbTransaction iTransaction = this.BeginTransaction())
                {
                    try
                    {
                        foreach (T oRecord in oDeletedRecs)
                            Execute(p_sDeleteSQL, oRecord, iTransaction);

                        foreach (T oRecord in oUpdatedRecs)
                            Execute(p_sUpdateSQL, oRecord, iTransaction);

                        if (sPrimaryKeyName == "ID")
                            foreach (T oNewRecord in oNewRecs)
                            {
                                int nID = Insert(p_sInsertSQL, oNewRecord, iTransaction);
                                oNewRecord.PrimaryKeyValue = nID;
                            }
                        else
                            foreach (T oNewRecord in oNewRecs)
                                Execute(p_sInsertSQL, oNewRecord, iTransaction);

                        iTransaction.Commit();
                    }
                    catch
                    {
                        iTransaction.Rollback();
                        throw;
                    }
                }
            }
        }
    }
}
