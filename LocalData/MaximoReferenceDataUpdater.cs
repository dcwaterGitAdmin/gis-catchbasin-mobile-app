using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Configuration;

namespace DCWaterMobile.LocalData
{
    public class MaximoReferenceDataUpdater : IDisposable
    {
        private SQLiteConnection _mainConnection ;
        private string _mainConnectionString;
        private string _updateConnectionString;

        public MaximoReferenceDataUpdater()
        {
            _mainConnectionString =
                System.Configuration.ConfigurationManager.ConnectionStrings["MxLocalCacheDatabase"].ConnectionString;
            _updateConnectionString =
                System.Configuration.ConfigurationManager.ConnectionStrings["MxLocalCacheUpdateDatabase"]
                    .ConnectionString;
            _mainConnection = new SQLiteConnection(_mainConnectionString);
        }

        public void Execute()
        {
            var updateDBPath = _updateConnectionString.Replace("data source=","");
            string attachStmt = "ATTACH '" + updateDBPath + "' as REF";
            SQLiteCommand cmd = new SQLiteCommand(attachStmt);
            cmd.Connection = _mainConnection;
            int retval = 0;
            try
            {
                _mainConnection.Open();
                retval = cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                _mainConnection.Close();
                throw;
            }
            finally
            {
                cmd.Dispose();
            }

            try
            {
                DoTable("ALNDOMAIN");
                DoTable("ASSETATTRIBUTE");
                DoTable("MAXROWSTAMP");
                DoTable("CLASSSPEC");
                DoTable("CROSSOVERDOMAIN");
                DoTable("DOCTYPES");
                DoTable("FAILURECODE");
                DoTable("FAILURELIST");
                DoTable("INVENTORY");
                DoTable("LABORCRAFTRATE");
                DoTable("MAXATTRIBUTE");
                DoTable("MAXDOMAIN");
                DoTable("MAXTABLEDOMAIN");
                DoTable("PERSON");
                DoTable("PERSONGROUP");
                DoTable("PERSONGROUPTEAM");
                DoTable("SYNONYMDOMAIN");
                DoTable("WORKTYPE");
            }
            catch (Exception)
            {
                _mainConnection.Close();
                throw;
            }
         }

        private void DoTable(string tableName)
        {
            using (var transaction = _mainConnection.BeginTransaction())
            {
                try
                {
                    string deleteStmt = "DELETE FROM " + tableName;
                    using (var cmd = new SQLiteCommand(deleteStmt))
                    {
                        cmd.Connection = _mainConnection;
                        int retval = cmd.ExecuteNonQuery();
                    }
                    string copyStmt = "INSERT INTO " + tableName + " SELECT * FROM REF." + tableName;
                    using (var cmd = new SQLiteCommand(copyStmt))
                    {
                       cmd.Connection = _mainConnection;
                        int retval = cmd.ExecuteNonQuery();
                    }
                    transaction.Commit();

                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
            
        }

        void IDisposable.Dispose()
        {
            _mainConnection.Dispose();
        }
    }
}
