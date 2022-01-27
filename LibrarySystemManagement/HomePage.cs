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
    public partial class HomePage : Form
    {
        public HomePage()
        {
            InitializeComponent();
        }

        //Login
        private void butLogIn_Click(object sender, EventArgs e)
        {
            Login logInf = new Login();
            logInf.Show();
            this.Hide();
        }

        //Signup
        private void butSignUp_Click(object sender, EventArgs e)
        {
            Signup Signupf = new Signup();
            Signupf.Show();
            this.Hide();
        }

        //exit
        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /*private void button1_Click(object sender, EventArgs e)
        {
            ControlPanel controlPanelf = new ControlPanel();
            controlPanelf.Show();

        }*/
    }
}
