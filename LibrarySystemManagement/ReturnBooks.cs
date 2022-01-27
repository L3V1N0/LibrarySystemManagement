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
    public partial class ReturnBooks : Form
    {

        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=library_system_management;");
        MySqlCommand Command;
        MySqlDataAdapter Adapter;
        DataTable Table;

        public ReturnBooks()
        {
            InitializeComponent();
            fillcombobox();
        }

        private void ReturnBooks_Load(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection("datasource = localhost; port = 3306; username = root; password =; database = library_system_management");
            string query = "SELECT * FROM `returnbook`";
            using (MySqlDataAdapter adpt = new MySqlDataAdapter(query, con))
            {
                DataSet set = new DataSet();
                adpt.Fill(set);

                dataGridView1.DataSource = set.Tables[0];
            }

            //searchData("");
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DB db = new DB();

            MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=library_system_management;");
            MySqlCommand command = new MySqlCommand("INSERT INTO `returnbook`( `Bid`, `Sid`, `IssueID`, `FA`, `ReturnDate`) VALUES (@Bid,@Sid,@IssueID,@FA,@ReturnDate)", db.getConnection());
            db.OpenConnection();
            connection.Open();
            command.Parameters.Add("@Bid", MySqlDbType.Int32).Value = txtbookid.Text;
            command.Parameters.Add("@Sid", MySqlDbType.Int32).Value = txtstudentid.Text;
            command.Parameters.Add("@IssueID", MySqlDbType.Int32).Value = comboBox1.Text;
            command.Parameters.Add("@FA", MySqlDbType.Int64).Value = txtFineAmount.Text; 
            command.Parameters.Add("@ReturnDate", MySqlDbType.Date).Value = txtReturnDate.Value;

            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Success!\nInformation Inputted");

            }
            connection.Close();
            db.CloseConnection();
        }
        
        public void fillcombobox()
        {
            MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=library_system_management;");
            string sql = "SELECT * FROM `issuebook`";
            MySqlCommand cmd = new MySqlCommand(sql, connection);
            MySqlDataReader myreader;

            try
            {
                connection.Open();
                myreader = cmd.ExecuteReader();
                while (myreader.Read())
                {
                    string bname = myreader.GetString(0);
                    comboBox1.Items.Add(bname);

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

        private void txtstudentid_TextChanged(object sender, EventArgs e)
        {

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

        private void txtFineAmount_MouseEnter(object sender, EventArgs e)
        {

        }

        private void txtFineAmount_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtFineAmount.Text == "Fine Amount")
            {
                txtFineAmount.Clear();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            db.OpenConnection();

            //MySqlConnection con = new MySqlConnection("datasource = localhost; port = 3306; username = root; password =; database = library_system_management");
            string query = "SELECT * FROM `returnbook`";
            using (MySqlDataAdapter adpt = new MySqlDataAdapter(query, connection))
            {
                DataSet set = new DataSet();
                adpt.Fill(set);

                dataGridView1.DataSource = set.Tables[0];
            }


            db.CloseConnection();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM `issuebook` WHERE issueID='" + comboBox1.SelectedItem.ToString() + "'";
            connection.Open();
            cmd.ExecuteNonQuery();
            MySqlDataReader dr;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                string bid = (String)dr["Bid"].ToString();
                txtbookid.Text = bid;

                string sid = (String)dr["Sid"].ToString();
                txtstudentid.Text = sid;
            }
            connection.Close();
            
        }
    }

}
