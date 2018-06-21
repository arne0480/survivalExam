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
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        Authentication auth;
        private void button1_Click(object sender, EventArgs e) //Checker om alle felterne er fyldt ud med information, hvis ikke paswords matcher, kommer der en error message
        {
            if (txtUsername.Text != string.Empty
                && txtPassword.Text != string.Empty
                && txtConfirmPassword.Text != string.Empty
                && txtEmail.Text != string.Empty)
            {
                if (txtPassword.Text == txtConfirmPassword.Text)
                {
                    checkAccount(txtUsername.Text);
                }
                else
                {
                    MessageBox.Show("Entered passwords does not match", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void checkAccount(string username) //Checker om de indtaste informationer allerede eksisterer i tabellen
        {
            auth = new Authentication();
            auth.getConnection();

            using (SQLiteConnection con = new SQLiteConnection(auth.connectionString))
            {
                SQLiteCommand cmd = new SQLiteCommand();

                bool userInDatabase = false;
                con.Open();

                string query = @"SELECT * FROM user WHERE Username='" + username + "'";
                cmd.CommandText = query;
                cmd.Connection = con;

                SQLiteDataReader reader = cmd.ExecuteReader();
                
                while (reader.Read())
                {
                    string a = reader.GetString(2).ToString();
                    if (a == username)
                    {
                        MessageBox.Show("User already created!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        userInDatabase = true;
                        break;
                    }
                }
                if (userInDatabase == false)
                {
                    InsertData(txtUsername.Text, txtPassword.Text, txtEmail.Text);
                }

            }
        }

        private void InsertData(string usernames, string password, string email) //Indsætter data i tabellen
        {
            auth = new Authentication();
            auth.getConnection();

            using (SQLiteConnection con = new SQLiteConnection(auth.connectionString))
            {
                con.Open();
                SQLiteCommand cmd = new SQLiteCommand();
                string query = @"INSERT INTO user(Username, Password, Email) VALUES(@username, @password, @email)";
                cmd.CommandText = query;
                cmd.Connection = con;
                cmd.Parameters.Add(new SQLiteParameter("@username",usernames));
                cmd.Parameters.Add(new SQLiteParameter("@password", password));
                cmd.Parameters.Add(new SQLiteParameter("@email", email));
                cmd.ExecuteNonQuery();

                con.Close();
                MessageBox.Show("Successfully created user!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
        } 

    }
}
