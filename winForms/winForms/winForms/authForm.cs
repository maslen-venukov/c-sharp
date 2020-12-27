using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace winForms
{
    public partial class authForm : Form
    {
        public authForm()
        {
            InitializeComponent();
        }

        void loginBtn_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-EHG48UJ\SQLEXPRESS01;Initial Catalog=TestDatabase; Integrated Security=True");
            SqlDataAdapter dataAdapter = new SqlDataAdapter($"Select Count (*) From Auth Where Login = '{loginTextBox.Text}' And Password = '{passwordTextBox.Text}'", connection);
            DataTable dataTable = new DataTable();

            dataAdapter.Fill(dataTable);

            if (dataTable.Rows[0][0].ToString() == "1")
            {
                Form1 form1 = new Form1();
                form1.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль");
            }
        }
    }
}
