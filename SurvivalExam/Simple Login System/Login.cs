using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace Simple_Login_System
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        public string usernames;
        Authentication auth;

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e) //Hvis username og password felterne ikke er tomme, tjekker den i 
        {
            if (txtUsername.Text != string.Empty
                && txtPassword.Text != string.Empty)
            {
                checkAccount(txtUsername.Text, txtPassword.Text);
            }
        }

        private void checkAccount(string username, string password) //Læser fra databasen om indtaste username og password findes, og óm de matcher med det der tideligere er registeret
        {
            auth = new Authentication();
            auth.getConnection();
            using (SQLiteConnection con = new SQLiteConnection(auth.connectionString))
            {
                con.Open();
                SQLiteCommand cmd = new SQLiteCommand();
                string query = "SELECT * FROM user WHERE Username='" + username + "'";
                
                cmd.CommandText = query;
                cmd.Connection = con;
                int count = 0;
                SQLiteDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    count++;
                }

                if ( count == 1)
                {
                    MessageBox.Show("Login Successfu!", "Login success",MessageBoxButtons.OK, MessageBoxIcon.Information);
                    usernames = username;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Wrong username or password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            Register reg = new Register();
            reg.ShowDialog();
        }
    }
}
