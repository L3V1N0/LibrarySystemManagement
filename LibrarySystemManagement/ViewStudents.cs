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
    public partial class ViewStudents : Form
    {
        MySqlConnection con = new MySqlConnection("datasource = localhost; port = 3306; username = root; password =; database = library_system_management");
        MySqlCommand Command;
        MySqlDataAdapter Adapter;
        DataTable Table;

        public ViewStudents()
        {
            InitializeComponent();
        }

        private void btnX_Click(object sender, EventArgs e)
        {
            string message = "This will DELETE any Unsaved Progress\n    Do you want do it anyway";
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

        private void ViewStudents_Load(object sender, EventArgs e)
        {
            //panel1.Visible = false;
            /*
            DB db = new DB();
            db.OpenConnection();

            //MySqlConnection con = new MySqlConnection("datasource = localhost; port = 3306; username = root; password =; database = library_system_management");
            string query = "SELECT * FROM `students`";
            using (MySqlDataAdapter adpt = new MySqlDataAdapter(query, con))
            {
                DataSet set = new DataSet();
                adpt.Fill(set);

                dataGridView1.DataSource = set.Tables[0];

            }
            */
            searchData(""); 

        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            db.OpenConnection();

            //MySqlConnection con = new MySqlConnection("datasource = localhost; port = 3306; username = root; password =; database = library_system_management");
            string query = "SELECT * FROM `students`";
            using (MySqlDataAdapter adpt = new MySqlDataAdapter(query, con))
            {
                DataSet set = new DataSet();
                adpt.Fill(set);

                dataGridView1.DataSource = set.Tables[0];
            }
            txtStudentNameSearch.Clear();

            db.CloseConnection();
        }

        private void txtSearch_Click(object sender, EventArgs e)
        {
            string ValueToSearch = txtStudentNameSearch.Text.ToString();
            searchData(ValueToSearch);
            panel1.Visible = true;
        }

        public void searchData(string valueToSearch)
        {

            string query = "SELECT * FROM `students` WHERE CONCAT(`id`, `StudentName`, `EnrollmentNumber`, `StudentContact`, `StudentEmail`) LIKE '%" + valueToSearch + "%'";
            Command = new MySqlCommand(query, con);
            Adapter = new MySqlDataAdapter(Command);
            Table = new DataTable();
            Adapter.Fill(Table);
            dataGridView1.DataSource = Table;
        }
                
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                dataGridView1.CurrentCell.Selected = true;
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["ID"].FormattedValue.ToString();
                txtStudentName.Text = dataGridView1.Rows[e.RowIndex].Cells["StudentName"].FormattedValue.ToString();
                txtEnrollmentNumber.Text = dataGridView1.Rows[e.RowIndex].Cells["EnrollmentNumber"].FormattedValue.ToString();
                intStudentContact.Text = dataGridView1.Rows[e.RowIndex].Cells["StudentContact"].FormattedValue.ToString();
                txtStudentEmail.Text = dataGridView1.Rows[e.RowIndex].Cells["StudentEmail"].FormattedValue.ToString();
                
                //panel1.Visible = true;
            }
             
        }
        
        //Cancel Button
        private void button3_Click(object sender, EventArgs e)
        {
            //panel1.Visible = false;
            this.Close();
            Dashboard ConPf = new Dashboard();
            ConPf.Show();

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string updateQuery = "UPDATE `students` SET `StudentName`= '" + txtStudentName.Text + "',`EnrollmentNumber`= '" + txtEnrollmentNumber.Text + "',`StudentContact`= '" + intStudentContact.Text + "',`StudentEmail`= '" + txtStudentEmail.Text + "' WHERE `id` = '" + textBox1.Text + "' ";
            con.Open();
            try
            {
                MySqlCommand Command = new MySqlCommand(updateQuery, con);
                if (Command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Data Updated");
                }
                else
                {
                    MessageBox.Show("Date not Updated, Please Try Again");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            con.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            db.OpenConnection();
            con.Open();
            MySqlCommand command = new MySqlCommand(" DELETE FROM `students` WHERE id = '" + textBox1.Text + "'", db.getConnection());

            string message = "    The Data you've selected will be gone forever\n   Do you want do it anyway?";
            string title = "Delete Window";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                command.ExecuteNonQuery();

                MessageBox.Show("Data Deleted Successfully!");
            }

            con.Close();
            db.CloseConnection();
        }
    }
}
