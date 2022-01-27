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
    public partial class IssueBooks : Form
    {
        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=library_system_management;");
        MySqlCommand Command;
        MySqlDataAdapter Adapter;
        DataTable Table;

        public IssueBooks()
        {
            InitializeComponent();
            fillcombobox();
            fillcombobox2();
        }

        private void IssueBooks_Load(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection("datasource = localhost; port = 3306; username = root; password =; database = library_system_management");
            string query = "SELECT * FROM `issuebook`";
            using (MySqlDataAdapter adpt = new MySqlDataAdapter(query, con))
            {
                DataSet set = new DataSet();
                adpt.Fill(set);

                dataGridView1.DataSource = set.Tables[0];
            }

            //searchData("");
        }

        //Book ID
        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            /*
            DB db = new DB();
            db.OpenConnection();
            connection.Open();
            MySqlCommand command=  new MySqlCommand ("SELECT  `BookName` FROM `books` WHERE id  = '"+ txtbookid + "'");
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);

            if (table.Rows.Count > 0){
                    textBox1.Text = table(0)(0);
            }


            connection.Close();
            db.CloseConnection();
            */
        }
        /*
        //Search button
        private void button1_Click(object sender, EventArgs e)
        {
            string ValueToSearch = txtbookid.Text.ToString();
            searchData(ValueToSearch);
            
        }

        public void searchData(string valueToSearch)
        {

            string query = "SELECT * FROM `issuebook` WHERE CONCAT(`issueID`, `Bid`, `Sid`, `Bname`, `Sname`, `IssueDate`, `ReturnDate`) LIKE '%" + valueToSearch + "%'";
            Command = new MySqlCommand(query, connection);
            Adapter = new MySqlDataAdapter(Command);
            Table = new DataTable();
            Adapter.Fill(Table);
            dataGridView1.DataSource = Table;
        }
        */

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

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

        //Add
        private void txtAdd_Click(object sender, EventArgs e)
        {
            DB db = new DB();
 
            MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=library_system_management;");
            MySqlCommand command = new MySqlCommand("INSERT INTO `issuebook`( `Bid`, `Sid`, `Bname`, `Sname`, `IssueDate`, `ReturnDate`) VALUES (@Bid,@Sid,@Bname,@Sname,@IssueDate,@ReturnDate)",db.getConnection());
            db.OpenConnection();
            connection.Open();
            command.Parameters.Add("@Bid", MySqlDbType.Int64).Value = txtbookid.Text;
            command.Parameters.Add("@Sid", MySqlDbType.Int64).Value = txtstudentid.Text;
            command.Parameters.Add("@Bname", MySqlDbType.Text).Value = comboBox1.Text;
            command.Parameters.Add("@Sname", MySqlDbType.Text).Value = comboBox2.Text;
            command.Parameters.Add("@IssueDate", MySqlDbType.Date).Value = txtIssueDate.Value;
            command.Parameters.Add("@ReturnDate", MySqlDbType.Date).Value = txtReturnDate.Value;

            if (command.ExecuteNonQuery() == 1) 
            {
                MessageBox.Show("Success!\nInformation Inputted");
            }
            else
            {
                MessageBox.Show("Invalid Information Please try Agian");
            }
            connection.Close();
            db.CloseConnection();
        }// end method

        public void fillcombobox()
        {
            MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=library_system_management;");
            string sql = "SELECT * FROM `books`";
            MySqlCommand cmd = new MySqlCommand(sql, connection);
            MySqlDataReader myreader;

            try
            {
                connection.Open();
                myreader = cmd.ExecuteReader();
                while (myreader.Read())
                {
                    string bname = myreader.GetString(1);
                    comboBox1.Items.Add(bname);

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public void fillcombobox2()
        {
            MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=library_system_management;");
            string sql = "SELECT * FROM `students`";
            MySqlCommand cmd = new MySqlCommand(sql, connection);
            MySqlDataReader myreader;

            try
            {
                connection.Open();
                myreader = cmd.ExecuteReader();
                while (myreader.Read())
                {
                    string bname = myreader.GetString(1);
                    comboBox2.Items.Add(bname);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        private void txtbookid_MouseEnter(object sender, EventArgs e)
        {

        }

        private void txtbookid_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtbookid.Text == "ID (Book)")
            {
                txtbookid.Clear();
            }
        }

        private void txtstudentid_MouseEnter(object sender, EventArgs e)
        {

        }

        private void txtstudentid_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtstudentid.Text == "ID (Student)")
            {
                txtstudentid.Clear();
            }
        }

        private void txtstudentid_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            
                DB db = new DB();
                db.OpenConnection();

                //MySqlConnection con = new MySqlConnection("datasource = localhost; port = 3306; username = root; password =; database = library_system_management");
                string query = "SELECT * FROM `issuebook`";
                using (MySqlDataAdapter adpt = new MySqlDataAdapter(query, connection))
                {
                    DataSet set = new DataSet();
                    adpt.Fill(set);

                    dataGridView1.DataSource = set.Tables[0];
                }
                

                db.CloseConnection();
            
        }
    }
}
