using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;

namespace Bacchus
{
    class DBSQLite
    {
        public static void CreateDB(string dbName)
        {
            string dbPath = @"C:\code\TPnote\Bacchus\Bacchus\";

            string dbSource = dbPath + dbName + ".sqlite";

            if (File.Exists(dbSource)) File.Delete(dbSource);

            var connString = string.Format(@"Data Source={0}; Pooling=false; FailIfMissing=false;", dbSource);
            SQLiteReader(connString);

            //SQLiteConnection conn = new SQLiteConnection("Data source=" + dbSource);
            

            //
            //conn.Open();

            //conn.Close();
        }

        public static void SQLiteReader(string connString)
        {
            using(SQLiteConnection conn = new SQLiteConnection())
            {
                conn.Open();

                using(SQLiteCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT * FROM Familes";

                    using(SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        long RefFamile = reader.GetInt64(0);
                        string Nom = reader.GetString(1);
                    }

                }
                
                // Close SQLiteConnection
                if(conn.State != System.Data.ConnectionState.Closed)
                {
                    conn.Close();
                }
            }
        }

        public static Boolean NewDBFile(string dbPath)
        {
            try
            {
                SQLiteConnection.CreateFile(dbPath);
                return true;
            }
            catch(Exception ex)
            {
                throw new Exception("Failed to create db file " + dbPath + ":" + ex.Message);
            }
        }

        public static void NewTable(string dbPath, string tableName)
        {
            SQLiteConnection conn = new SQLiteConnection("Data source=" + dbPath);
            if(conn.State != System.Data.ConnectionState.Open)
            {
                conn.Open();
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.Connection = conn;
                cmd.CommandText = "CREATE TABLE " + tableName + "(name varchar, age int)";
                cmd.ExecuteNonQuery();
            }
            conn.Close();
        }
    }
}
