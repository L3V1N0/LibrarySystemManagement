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
    public partial class Dashboard : Form
    {

        MySqlConnection con = new MySqlConnection("datasource = localhost; port = 3306; username = root; password =; database = library_system_management");
        MySqlCommand Command;
        //MySqlDataAdapter Adapter;
        DataTable Table;
        DataSet dsone;
        DataSet dstwo;
        DataSet dsthree;
        DataSet dsfour;
        MySqlDataAdapter daone;
        MySqlDataAdapter datwo;
        MySqlDataAdapter dathree;
        MySqlDataAdapter dafour;
        MySqlCommandBuilder buildone;
        MySqlCommandBuilder buildtwo;
        MySqlCommandBuilder buildthree;
        MySqlCommandBuilder buildfour;


        public Dashboard()
        {
            //label1.text = txtUsername;
            InitializeComponent();
        }

        private void btnX_Click(object sender, EventArgs e)
        {
            string message = "Do you want to close this window?";
            string title = "Close Window";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }

        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string message = "Do you want to close this window?";
            string title = "Close Window";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                this.Close();
                HomePage HomePf = new HomePage();
                HomePf.Show();
            }
        }

        private void addStudentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close(); 
            AddStudents addStudentsf = new AddStudents();
            addStudentsf.Show();
        }

        private void viewStudentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            ViewStudents viewStudentsf = new ViewStudents();
            viewStudentsf.Show();
        }

        private void addNewBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            AddBooks addBooksf = new AddBooks();
            addBooksf.Show();
        }

        private void viewBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            ViewBooks viewBooksf = new ViewBooks();
            viewBooksf.Show();
        }

        private void issueBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            IssueBooks issueBooksf = new IssueBooks();
            issueBooksf.Show();
        }

        private void returnBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            ReturnBooks returnBooksf = new ReturnBooks();
            returnBooksf.Show();
        }

        //Total Students
        private void ts_Click(object sender, EventArgs e)
        {
                                    
        }

        //Toatal Book Issued
        private void tbi_Click(object sender, EventArgs e)
        {

        }

        //Total Books
        private void label5_Click(object sender, EventArgs e)
        {

        }

        //Total Users
        private void tu_Click(object sender, EventArgs e)
        {

        }

        public void Dashboard_Load(object sender, EventArgs e)
        {
            con.Open();
            //total Students
            string qry = "SELECT * FROM `students`";
            string poi = "SELECT * FROM `books`";
            string qas = "SELECT * FROM `issuebook`";
            string rin = "SELECT * FROM `returnbook`";

            dsone = new DataSet();
            dstwo = new DataSet();
            dsthree = new DataSet();
            dsfour = new DataSet();

            daone = new MySqlDataAdapter(qry,con);
            datwo = new MySqlDataAdapter(poi, con);
            dathree = new MySqlDataAdapter(qas, con);
            dafour = new MySqlDataAdapter(rin, con);

            daone.Fill(dsone);
            datwo.Fill(dstwo);
            dathree.Fill(dsthree);
            dafour.Fill(dsfour);

            buildone = new MySqlCommandBuilder(daone);
            buildtwo = new MySqlCommandBuilder(datwo);
            buildthree = new MySqlCommandBuilder(dathree);
            buildfour = new MySqlCommandBuilder(dafour);

            tsdgv.DataSource = dsone.Tables[0];
            tbidgv.DataSource = dstwo.Tables[0];
            tbdgv.DataSource = dsthree.Tables[0];
            tudgv.DataSource = dsfour.Tables[0];

            count();

        }

        public void count()
        {
            ts.Text = dsone.Tables[0].Rows.Count.ToString();
            tbi.Text = dstwo.Tables[0].Rows.Count.ToString();
            tb.Text = dsthree.Tables[0].Rows.Count.ToString();
            tu.Text = dsfour.Tables[0].Rows.Count.ToString();
        }

        private void tsdgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
