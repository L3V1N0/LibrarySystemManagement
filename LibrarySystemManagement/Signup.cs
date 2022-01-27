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
    public partial class Signup : Form
    {
        //String mycon = "datasource = localhost; username = root; password = ; database = library_system_management;";

        public Signup()
        {
            InitializeComponent();
        }

        private void Signup_Load(object sender, EventArgs e)
        {

        }

        //Close
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            HomePage HomePf = new HomePage();
            HomePf.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void txtFname_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtLname_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMname_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtUsername_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void txtBday_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtRePassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void butSignUp_Click(object sender, EventArgs e)
        {
            DB db = new DB();
                             
            MySqlCommand command = new MySqlCommand("INSERT INTO `reg_form`( `FirstName`, `LastName`, `Contact_Number`, `UserName`, `Email`, `Password`) VALUES (@FirstName,@LastName,@Contact_Number,@UserName,@Email,@Password)", db.getConnection());

            command.Parameters.Add("@FirstName", MySqlDbType.Text).Value = txtFname.Text;
            command.Parameters.Add("@LastName", MySqlDbType.Text).Value = txtLname.Text;
            command.Parameters.Add("@Contact_Number", MySqlDbType.Int16).Value = IntPnum.Text;
            command.Parameters.Add("@Email", MySqlDbType.VarChar).Value = txtEmail.Text;
            command.Parameters.Add("@UserName", MySqlDbType.VarChar).Value = txtUsername.Text;
            command.Parameters.Add("@Password", MySqlDbType.VarChar).Value = txtPassword.Text;

            db.OpenConnection();
            
            if (txtPassword.Text == txtRePassword.Text)
            {
                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Success!\nInformation Inputted");
                    Login logInf = new Login();
                    logInf.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Failed!\nInformation Inputted Error\nPlease Try Again");
                }
            }
            else
            {
                MessageBox.Show("Password is not the same, Input the ssme Password");

            }
                        
            db.CloseConnection();
                                   
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        //Firstnamae
        private void txtFname_MouseEnter(object sender, EventArgs e)
        {

        }

        private void txtFname_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtFname.Text == "First Name")
            {
                txtFname.Clear();
            }
        }

        private void txtLname_MouseEnter(object sender, EventArgs e)
        {

        }

        private void txtLname_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtLname.Text == "Last Name")
            {
                txtLname.Clear();
            }
        }

        private void IntPnum_TextChanged(object sender, EventArgs e)
        {

        }

        private void IntPnum_MouseEnter(object sender, EventArgs e)
        {
            
        }

        private void IntPnum_MouseClick(object sender, MouseEventArgs e)
        {
            if (IntPnum.Text == "Phone Number")
            {
                IntPnum.Clear();
            }
        }

        private void txtEmail_MouseEnter(object sender, EventArgs e)
        {

        }

        private void txtEmail_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtEmail.Text == "Email")
            {
                txtEmail.Clear();
            }
        }

        private void txtUsername_MouseEnter(object sender, EventArgs e)
        {

        }

        private void txtUsername_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtUsername.Text == "Username")
            {
                txtUsername.Clear();
            }
        }

        private void txtPassword_MouseEnter(object sender, EventArgs e)
        {

        }

        private void txtPassword_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtPassword.Text == " ")
            {
                txtPassword.Clear();
                //txtPassword.PasswordChar = '*';
            }
        }

        private void txtRePassword_MouseEnter(object sender, EventArgs e)
        {

        }

        private void txtRePassword_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtRePassword.Text == " ")
            {
                txtRePassword.Clear();
                //txtRePassword.PasswordChar = '*';
            }
        }
    }
}
