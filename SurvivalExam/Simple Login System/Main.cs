using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SurvivalExam;

namespace Simple_Login_System
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        string username;
        private void Main_Load(object sender, EventArgs e) //Ándvender det indtastede brugernavn til velkomst skærmen
        {
            Login login = new Login();
            login.ShowDialog();

            username = login.usernames;
            lblWelcome.Text = "Welcome to Radical Survival, " + username + "!";
        }

        private void btnStartGame_Click(object sender, EventArgs e) //Skulle have startet spillet, men har PT ikke nogen funktion
        {
            SurvivalExam.Program.Main();
        }
    }
}
