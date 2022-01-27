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
    public partial class AddBooks : Form
    {
        public AddBooks()
        {
            InitializeComponent();
        }

        private void btnX_Click(object sender, EventArgs e)
        {
            string message = "This will DELETE any Unsaved Progress\n   Do you want do it anyway?";
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

        //Confirm
        private void button1_Click(object sender, EventArgs e)
        {
            
            DB db = new DB();
            db.OpenConnection();
            if (txtBookName.Text == "" || txtBookAuthor.Text == "" || txtBookPublic.Text == ""|| IntBookPrice.Text == "" || IntBookQunatity.Text == "")
            {
                string message = "Empty Field is Invalid";
                string title = "Warning";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result = MessageBox.Show(message, title, buttons);
                if (result == DialogResult.OK)
                {
                    txtBookName.Clear();
                    txtBookAuthor.Clear();
                    txtBookPublic.Clear();
                    dateTimePicker1.Refresh();
                    IntBookPrice.Clear();
                    IntBookQunatity.Clear();
                }

            }
            else
            {

                MySqlCommand command = new MySqlCommand("INSERT INTO `books`(`BookName`, `BookAuthor`, `BookPublic`, `BookPurchaseDate`, `BookPrice`, `BookQuantity`) VALUES (@BookName,@BookAuthor,@BookPublic,@BookPurchaseDate,@BookPrice,@BookQunatity)", db.getConnection());

                command.Parameters.Add("@BookName", MySqlDbType.VarChar).Value = txtBookName.Text;
                command.Parameters.Add("@BookAuthor", MySqlDbType.VarChar).Value = txtBookAuthor.Text;
                command.Parameters.Add("@BookPublic", MySqlDbType.VarChar).Value = txtBookPublic.Text;
                command.Parameters.Add("@BookPurchaseDate", MySqlDbType.VarChar).Value = dateTimePicker1.Text;
                command.Parameters.Add("@BookPrice", MySqlDbType.Int64).Value = IntBookPrice.Text;
                command.Parameters.Add("@BookQunatity", MySqlDbType.Int64).Value = IntBookQunatity.Text;

               

                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("        Success!\nInformation Inputted");                    
                    string message = "Do you want to add a new book?";
                    string title = "Add New Book?";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result = MessageBox.Show(message, title, buttons);
                    if (result == DialogResult.Yes)
                    {
                        txtBookName.Clear();
                        txtBookAuthor.Clear();
                        txtBookPublic.Clear();
                        dateTimePicker1.Refresh();
                        IntBookPrice.Clear();
                        IntBookQunatity.Clear();
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
            txtBookName.Clear();
            txtBookAuthor.Clear();
            txtBookPublic.Clear();
            dateTimePicker1.Refresh();
            IntBookPrice.Clear();
            IntBookQunatity.Clear();
        }
    }
}
