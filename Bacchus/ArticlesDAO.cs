using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;

namespace Bacchus
{
    class ArticlesDAO
    {
        SQLiteConnection conn;

        public ArticlesDAO()
        {

        }

        public void connectionDB(Articles article)
        {
            string dbName = @"C:\code\TPnote\MyDBtest.sqlite";
            createNewDB(dbName);
            createDBTables(dbName);
            Console.WriteLine("create tables");

            

        }

        public void createNewDB(string dbName)
        {
            if (File.Exists(dbName)) File.Delete(dbName);
            SQLiteConnection.CreateFile(dbName);
        }

        public void createDBTables(string dbName)
        {
            conn = new SQLiteConnection("Data Source="+dbName+";Version=3");
            if(conn.State != System.Data.ConnectionState.Open)
            {
                conn.Open();
                using(SQLiteCommand command = conn.CreateCommand())
                {
                    createTables(command);
                }
                
                
            }
            //closeConnection(conn);
            conn.Close();   
        }

        public void closeConnection(SQLiteConnection conn)
        {
            conn.Close();
        }

        public void createTables(SQLiteCommand command)
        { 
            createTableArticles(command);
            createTableSousFamiles(command);
            createTableFamiles(command);
            createTableMarques(command);
        }

        public void createTableArticles(SQLiteCommand command)
        {
            string sql = "create table if not exists `Articles`(" +
                "`RefArticle` varchar(8) Primary key NOT NULL, " +
                "`Description` varchar(150) NOT NULL," +
                "`RefSousFamile` int(11) NOT NULL," +
                "`RefMarque` int(11) NOT NULL," +
                "`PrixHT` float NOT NULL,"+
                "`Quantite` int(11) NOT NULL )";
            command.CommandText = sql;
            command.ExecuteNonQuery();
        }

        public void createTableFamiles(SQLiteCommand command)
        {
            string sql = "create table if not exists `Familes`(" +
                "`RefFamile` int(11) Primary key NOT NULL, " +
                "`Nom` varchar(50) NOT NULL)" ; 
            //SQLiteCommand command = new SQLiteCommand(sql, conn);
            command.CommandText = sql;
            command.ExecuteNonQuery();
        }

        public void createTableSousFamiles(SQLiteCommand command)
        {
            string sql = "create table if not exists `SousFamiles`(" +
                "`RefSousFamile` int(11) Primary key NOT NULL, " +
                "`RefFamile` int(11) NOT NULL, "+
                "`Nom` varchar(50) NOT NULL)"; 
            //SQLiteCommand command = new SQLiteCommand(sql, conn);
            command.CommandText = sql;
            command.ExecuteNonQuery();
        }

        public void createTableMarques(SQLiteCommand command)
        {
            string sql = "create table if not exists `Marques`(" +
                "`RefMarque` int(11) Primary key NOT NULL, " +
                "`Nom` varchar(50) NOT NULL)";
            //SQLiteCommand command = new SQLiteCommand(sql, conn);
            command.CommandText = sql;
            command.ExecuteNonQuery();
        }
 
        public void insertDataByEntityArticles(Articles article, string dbName)
        {
            conn = new SQLiteConnection("Data Source=" + dbName + ";Version=3");
            if (conn.State != System.Data.ConnectionState.Open)
            {
                conn.Open();
                using (SQLiteCommand command = conn.CreateCommand())
                {
                    StringBuilder strSql = new StringBuilder();

                    // 
                    string refArticles = article.refArticle;
                    string description = article.description;

                    // string marque is Nom dans table Marques
                    string marque = article.marque;

                    // string souFamile is Nom dans table SousFamiles
                    string sousFamile = article.sousFamile;

                    // Convert string prixHT with ";" to float prixHT
                    string prixHTVirgule = article.prixHT;
                    string prixHTString = prixHTVirgule.Replace(",", ".");
                    float prixHT = float.Parse(prixHTString);


                    //insert into table Articles
                    strSql.Append("insert into Article(");

                }


            }
            //closeConnection(conn);
            conn.Close(); 
        }


    }
}
