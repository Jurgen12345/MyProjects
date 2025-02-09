using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using Dapper;


namespace Lib.Data.DB
{
    // Class for interaction with an MSSQL local DB database that supports an Object Persistence Framework (OPF)
    public class CDBMSSQLLocal: IDBFileBased
    {
        // ....................................................................
        private bool __isConnected = false;
        private SqlConnection? __connection = null;
        protected SqlConnection connection
        {
            get
            {
                //PATTERN: Lazy initialization. The only instance is created at the first time that is needed.
                if (__connection == null)
                {
                    string sConnectionStringLocalDB = $"Data Source=(LocalDB)\\{InstanceName};AttachDbFilename={DBFileName};Integrated Security=True";
                    __connection = new SqlConnection(sConnectionStringLocalDB);
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



        public string InstanceName { get; set; }
        public string DatabaseName { get; set; }
        public string DBPath { get; set; }
        public string DBFileName { get { return Path.Combine(DBPath, DatabaseName + ".mdf"); } }


        // --------------------------------------------------------------------------------------
        public CDBMSSQLLocal()
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
                catch (Exception E)
                {
                    Debug.WriteLine(E.Message);
                }
            }
            return __isConnected;
        }
        // --------------------------------------------------------------------------------------
        public void Disconnect()
        {
            if (__isConnected)
            {
                // Closing, disposing the connection and removing
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
        // This is a generic implementation of a select query. Instead of a specific type for the
        // returned records we use a placeholder T. This will be specified when the method is used.
        // Method Parameters:
        //      p_sSQL: A valid SQL syntax for a select statement without parameters.
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
        // Generic implementation for the execution a query that does not return records (insert/update/delete) 
        // Method Parameters:
        //      p_sSQL          : A valid insert SQL syntax with parameters marked with @.
        //      p_oParams       : An object for the parameters. It should have properties with the same name as the parameters.
        //      p_oTransaction  : The transaction context in which the query will be executed.
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
        // Generic implementation of an insert query that can retrieve an auto-generated key (identity)
        // Method Parameters:
        //      p_sInsertSQL    : A valid insert SQL syntax with parameters marked with @.
        //      p_oRecord       : An object for the record. It should have properties with the same name as the parameters.
        //      p_oTransaction  : The transaction context in which the query will be executed.
        public int Insert<T>(string p_sInsertSQL, T p_oRecord, IDbTransaction p_iTransaction)
        {
            if (!p_sInsertSQL.Trim().ToUpper().StartsWith("INSERT"))
                throw new Exception("Not a valid sql INSERT statement");

            int nID = -1;
            if (Connect())
            {
                string sSQL = p_sInsertSQL + ";select SCOPE_IDENTITY();";
                nID = connection.QuerySingle<int>(sSQL, p_oRecord, p_iTransaction);
                __lastSQL = sSQL;
            }
            return nID;
        }
        // --------------------------------------------------------------------------------------
        // Generic implementation of transaction that saves all the changes done to a set of records or table
        // Method Parameters:
        //      p_sInsertSQL    : A valid insert SQL syntax with parameters marked with @.
        //      p_sUpdateSQL    : A valid update SQL syntax with parameters marked with @.
        //      p_sDeleteSQL    : A valid update SQL syntax with parameters marked with @.
        public void SaveChanges<T>(List<T> p_oTable, string p_sInsertSQL, string p_sUpdateSQL, string p_sDeleteSQL) where T : CDBRecord
        {
            SaveChanges<T>(p_oTable, p_sInsertSQL, p_sUpdateSQL, p_sDeleteSQL, null);
        }
        // --------------------------------------------------------------------------------------
        // Generic implementation of transaction that saves all the changes done to a set of records or table
        // Method Parameters:
        //      p_sInsertSQL    : A valid insert SQL syntax with parameters marked with @.
        //      p_sUpdateSQL    : A valid update SQL syntax with parameters marked with @.
        //      p_sDeleteSQL    : A valid update SQL syntax with parameters marked with @.
        public void SaveChanges<T>(List<T> p_oTable, string p_sInsertSQL, string p_sUpdateSQL, string p_sDeleteSQL, IDbTransaction? p_iTransaction) where T : CDBRecord
        {
            // Checks the validity of SQL statements
            if (!p_sInsertSQL.Trim().ToUpper().StartsWith("INSERT"))
                throw new Exception("Not a valid sql INSERT statement");
            if (!p_sUpdateSQL.Trim().ToUpper().StartsWith("UPDATE"))
                throw new Exception("Not a valid sql UPDATE statement");
            if (!p_sDeleteSQL.Trim().ToUpper().StartsWith("DELETE"))
                throw new Exception("Not a valid sql DELETE statement");

            string? sPrimaryKeyName = null;

            // Segregates the records to those deleted, updated and added ones.
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
                // Run all the deletes
                foreach (T oRecord in oDeletedRecs)
                    Execute(p_sDeleteSQL, oRecord, p_iTransaction);

                // Run all the updates
                foreach (T oRecord in oUpdatedRecs)
                    Execute(p_sUpdateSQL, oRecord, p_iTransaction);


                // Run all the inserts
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
                        // Run all the deletes
                        foreach (T oRecord in oDeletedRecs)
                            Execute(p_sDeleteSQL, oRecord, iTransaction);

                        // Run all the updates
                        foreach (T oRecord in oUpdatedRecs)
                            Execute(p_sUpdateSQL, oRecord, iTransaction);


                        // Run all the inserts
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
        // --------------------------------------------------------------------------------------



    }
}
