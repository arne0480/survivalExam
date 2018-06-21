using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.SQLite;

namespace Simple_Login_System
{

   public class Authentication
    {
        public string connectionString { get; set; }
        string connection;

        public void getConnection() //Opretter forbindelse til databasen
        {
            connection = @"Data Source=C:\\SurvivalExamdb\\Account.db;Version=3;";
            connectionString = connection;
        }

        public void createTable() //Checker om der allerede eksisterer et table i databasen kaldet "user", og hvis der ikke gør det, bliver der oprettet et
        {
            getConnection();
            using (SQLiteConnection con = new SQLiteConnection(connection))
            {
                con.Open();
                SQLiteCommand cmd = new SQLiteCommand();

                string query = @"CREATE TABLE if not exists user (ID INTEGER PRIMARY KEY AUTOINCREMENT,Username Text(25), Password Text(25), Email Text (25))";
                cmd.CommandText = query;
                cmd.Connection = con;
                cmd.ExecuteNonQuery();




                con.Open();
                SQLiteCommand cmd1 = new SQLiteCommand();

                string query1 = @"CREATE TABLE if not exists user (ID INTEGER PRIMARY KEY AUTOINCREMENT,Username Text(25), Password Text(25), Email Text (25))";
                cmd.CommandText = query1;
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
            }
        }
    }
}
