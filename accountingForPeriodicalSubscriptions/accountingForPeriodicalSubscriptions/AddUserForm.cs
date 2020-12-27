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

namespace accountingForPeriodicalSubscriptions
{
    public partial class AddUserForm : Form
    {
        public AddUserForm()
        {
            InitializeComponent();
        }

        void addNewUserButton_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-JQD9UTD\SQLEXPRESS;Initial Catalog=Учет_подписки_на_периодические_печатные_издания; Integrated Security=True");
                SqlDataAdapter dataAdapter = new SqlDataAdapter($"Insert Into Пользователи (Роли_ID, Логин, Пароль, Аватарка) Values (2, '{ newUserLoginTextBox.Text }', '{ newUserPasswordTextBox.Text }', 'img\\220.jpg');", connection);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                MessageBox.Show("Пользователь добавлен", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                newUserLoginTextBox.Text = "";
                newUserPasswordTextBox.Text = "";
            }
            catch
            {
                MessageBox.Show("Что-то пошло не так", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void AddUserForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
