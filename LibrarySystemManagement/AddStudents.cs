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
    public partial class AddStudents : Form
    {
        public AddStudents()
        {
            InitializeComponent();
        }

        private void btnX_Click(object sender, EventArgs e)
        {
            string message = "This will DELETE any Unsaved Progress\n    Do you want do it anyway?";
            string title = "Close Window";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                this.Close();
                Dashboard ConPf = new Dashboard();
                ConPf.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            db.OpenConnection();
            if (txtStudentName.Text == "" || txtEnrollmentNumber.Text == "" || intStudentContact.Text == "" || txtStudentEmail.Text == "") 
            {
                string message = "Empty Field is Invalid";
                string title = "Warning";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result = MessageBox.Show(message, title, buttons);
                if (result == DialogResult.OK)
                {
                    txtStudentName.Clear();
                    txtEnrollmentNumber.Clear();
                    intStudentContact.Clear();                    
                    txtStudentEmail.Clear();                    
                }

            }
            else
            {

                MySqlCommand command = new MySqlCommand("INSERT INTO `students`(`StudentName`, `EnrollmentNumber`, `StudentContact`, `StudentEmail`) VALUES (@StudentName,@EnrollmentNumber,@StudentContact,@StudentEmail)", db.getConnection());

                command.Parameters.Add("@StudentName", MySqlDbType.VarChar).Value = txtStudentName.Text;
                command.Parameters.Add("@EnrollmentNumber", MySqlDbType.VarChar).Value = txtEnrollmentNumber.Text;
                command.Parameters.Add("@StudentContact", MySqlDbType.Int64).Value = intStudentContact.Text;
                command.Parameters.Add("@StudentEmail", MySqlDbType.VarChar).Value = txtStudentEmail.Text;

                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("         Success!\nInformation Inputted");
                    string message = "Do you want to add a new student?";
                    string title = "Add New Student?";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result = MessageBox.Show(message, title, buttons);
                    if (result == DialogResult.Yes)
                    {
                        txtStudentName.Clear();
                        txtEnrollmentNumber.Clear();
                        intStudentContact.Clear();
                        txtStudentEmail.Clear();
                    }
                    else
                    {
                        this.Close();
                        Dashboard ConPf = new Dashboard();
                        ConPf.Show();
                    }
                }
                else
                {
                    MessageBox.Show("...");
                }
            }


            db.CloseConnection();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtStudentName.Clear();
            txtEnrollmentNumber.Clear();
            intStudentContact.Clear();
            txtStudentEmail.Clear();
        }
    }
}
