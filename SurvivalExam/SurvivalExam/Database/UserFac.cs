using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SurvivalExam
{

    class UserFac
    {
        static SQLiteConnection dbConn = new SQLiteConnection("Data Source=Surviel.db;Version=3");
        static SQLiteCommand command;
        static string sql;

         public void InsertIntoTable(string username, string password)
        {
            dbConn.Open();
            sql = $"insert into user (id, usernames, passwords) values (null,'{username}', '{password}' )";

            command = new SQLiteCommand(sql, dbConn);
            command.ExecuteNonQuery();
            dbConn.Close();
        }

        public void DeleteFromTable()
        {
            dbConn.Open();
            sql = $"delete from user";

            command = new SQLiteCommand(sql, dbConn);
            command.ExecuteNonQuery();
            dbConn.Close();
        }
        public void UpdateFromTable()
        {
            dbConn.Open();
            sql = $"UPDATE user SET usernames='hej', passwords='20'";

            command = new SQLiteCommand(sql, dbConn);
            command.ExecuteNonQuery();
            dbConn.Close();
        }
        public DataTable SelectAllInTable() // metode til at vælge alle fra tabellen User
        {
            dbConn.Open(); // åbner forbindelsen til databasen

            DataTable dt = new DataTable(); // opretter en datatabel
            sql = "select * from user order by id desc"; // sql komandoen til at vælge alle brugerer 
            command = new SQLiteCommand(sql, dbConn); // sender sql komandoen og forbindelsen videre
            SQLiteDataReader reader = command.ExecuteReader(); // eksikvere kommandoen
            dt.Load(reader); // læser datatablen
            dbConn.Close(); // lukker forbindelsen til databasen

            return dt; //retunere datatablen
        }
    }
}
