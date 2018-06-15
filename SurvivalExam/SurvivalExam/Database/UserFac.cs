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
        public DataTable SelectAllInTable()
        {
            dbConn.Open();

            DataTable dt = new DataTable();
            sql = "select * from user order by id desc";
            command = new SQLiteCommand(sql, dbConn);
            SQLiteDataReader reader = command.ExecuteReader();
            dt.Load(reader);
            dbConn.Close();

            return dt;
        }
    }
}
