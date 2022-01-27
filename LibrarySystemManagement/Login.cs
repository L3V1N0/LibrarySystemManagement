using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace LibrarySystemManagement
{
    public partial class Login : Form
    {
        //MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=library_system_management;");
               
        public Login()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        //Log In
        private void butLogIn_Click(object sender, EventArgs e)
        {
            meh: 
            DB db = new DB();
            
            String Email = txtEmail.Text;
            String Password = txtPassword.Text;

            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT  `Email`, `Password` FROM `reg_form` WHERE  Email = @Email AND Password = @Password", db.getConnection());

            command.Parameters.Add("@Email", MySqlDbType.VarChar).Value = txtEmail.Text;
            command.Parameters.Add("@Password", MySqlDbType.VarChar).Value = txtPassword.Text;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if(table.Rows.Count > 0)
            {
                Dashboard ConPf = new Dashboard();
                ConPf.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid Account, Please Try Agian Later");
                //txtEmail.Clear();
                //txtPassword.Clear();
                
            }            
        }

        //Sign Up
        private void butSignUp_Click(object sender, EventArgs e)
        {
            this.Close();
            Signup Signupf = new Signup();
            Signupf.Show();
        }

        //Close
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            HomePage HomePf = new HomePage();
            HomePf.Show();
        }
                                
        //Password
        private void txtPassword_MouseEnter(object sender, EventArgs e)
        {
            
        }

        private void txtPassword_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtPassword.Text == "Password")
            {
                txtPassword.Clear();
                txtPassword.PasswordChar = '*';
            }
        }

        //Email
        private void txtEmail_MouseEnter(object sender, EventArgs e)
        {

        }

        private void txtEmail_MouseClick_1(object sender, MouseEventArgs e)
        {
            if( txtEmail.Text == "Email")
            {
                txtEmail.Clear();
            }
        }
    }
}
