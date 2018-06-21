using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace Simple_Login_System
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]


        static void Main() //Opretter Databasen i C drevet under mappen "SurvivalExamdb"
        {

            if (!System.IO.File.Exists("C:\\SurvivalExamdb\\Account.db"))
            {
                System.IO.Directory.CreateDirectory("C:\\SurvivalExamdb");
                SQLiteConnection.CreateFile("C:\\SurvivalExamdb\\Account.db");
                Authentication auth = new Authentication();
                auth.createTable();
            }
            

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main());
        }
    }
}
